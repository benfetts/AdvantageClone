Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProductControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductControl))
            Me.TabControlControl_ProductSetup = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelGeneral_General = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelSetup_Setup = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ComboBoxOptions_Office = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelOptions_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxGeneral_NewBusiness = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelGeneral_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabControlGeneral_General = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxOptions_LatePaymentFee = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputLatePaymentFee_Percentage = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelLatePaymentFee_Percentage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxLatePaymentFee_Calculate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemGeneral_BillingTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOptionsTab_Options = New DevComponents.DotNetBar.TabControlPanel()
            Me.TableLayoutPanelOptions_TableLayout = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelTableLayout_RightColumn = New System.Windows.Forms.Panel()
            Me.DataGridViewRightColumn_SortOptions = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelTableLayout_LeftColumn = New System.Windows.Forms.Panel()
            Me.GroupBoxLeftColumn_UserDefinedFields = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxUserDefinedFields_Field4 = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxUserDefinedFields_Field3 = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxUserDefinedFields_Field2 = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxUserDefinedFields_Field1 = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ComboBoxOptions_Currency = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelOptions_Currency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelOptions_AttentionLine = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxOptions_AttentionLine = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemGeneral_OptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAddressesTab_Addresses = New DevComponents.DotNetBar.TabControlPanel()
            Me.TableLayoutPanelAddresses_Addresses = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelAddresses_RightColumn = New System.Windows.Forms.Panel()
            Me.GroupBoxRightColumn_Statement = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.PanelStatement_ContactInformation = New System.Windows.Forms.Panel()
            Me.TextBoxStatementContactInformation_FaxExt = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelStatementContactInformation_Phone = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelStatementContactInformation_FaxExt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelStatementContactInformation_Fax = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxStatementContactInformation_PhoneExt = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxStatementContactInformation_Phone = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelStatementContactInformation_PhoneExt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxStatementContactInformation_Fax = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.AddressControlRightColumn_StatementAddress = New AdvantageFramework.WinForm.Presentation.Controls.AddressControl()
            Me.ButtonRightColumn_RefreshStatement = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemRefreshStatement_Client = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemRefreshStatement_Division = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemRefreshStatement_BillingAddress = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelAddresses_LeftColumn = New System.Windows.Forms.Panel()
            Me.GroupBoxLeftColumn_Billing = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.PanelBilling_ContactInformation = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.LabelBillingContactInformation_Phone = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxBillingContactInformation_FaxExt = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxBillingContactInformation_Fax = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxBillingContactInformation_Phone = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelBillingContactInformation_FaxExt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelBillingContactInformation_PhoneExt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelBillingContactInformation_Fax = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxBillingContactInformation_PhoneExt = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.AddressControlLeftColumn_BillingAddress = New AdvantageFramework.WinForm.Presentation.Controls.AddressControl()
            Me.ButtonLeftSection_RefreshBilling = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemRefreshBilling_Client = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemRefreshBilling_Division = New DevComponents.DotNetBar.ButtonItem()
            Me.TabItemGeneral_AddressesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.LabelSetup_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxGeneral_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxGeneral_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ComboBoxGeneral_Division = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TextBoxGeneral_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ComboBoxGeneral_Client = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelSetup_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemProductSetup_GeneralTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelContactsTab_Contacts = New DevComponents.DotNetBar.TabControlPanel()
            Me.ClientContactManagerControlContacts_ProductContacts = New AdvantageFramework.WinForm.Presentation.Controls.ClientContactManagerControl()
            Me.TabItemProductSetup_ContactsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelBroadcastMedia_BroadcastMedia = New DevComponents.DotNetBar.TabControlPanel()
            Me.TableLayoutPanelBroadcastMedia_BroadcastMedia = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelBroadcastMedia_RightColumn = New System.Windows.Forms.Panel()
            Me.GroupBoxRightColumn_Television = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputTelevision_Rebate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTelevision_Markup = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ComboBoxTelevision_TaxCode = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxTelevision_BillingSetupComplete = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxTelevision_VendorDiscounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTelevision_TaxCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxTelevision_ApplySalesTaxTo = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToTelevision_Rebate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToTelevision_Commission = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToTelevision_LineNet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonControlTelevision_PostBill = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxTelevision_CommissionOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonControlTelevision_Prebill = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxTelevision_BillNet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTelevision_RebatePercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTelevision_MarkupPercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTelevision_StationPricesGross = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTelevision_StationPricesNet = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxTelevision_NumberOfDaysToBill = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputNumberOfDaysToBillTelevision_Days = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelNumberOfDaysToBillTelevision_Days = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelBroadcastMedia_LeftColumn = New System.Windows.Forms.Panel()
            Me.GroupBoxLeftColumn_Radio = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputRadio_Rebate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputRadio_Markup = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ComboBoxRadio_TaxCode = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxRadio_BillingSetupComplete = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRadio_VendorDiscounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelRadio_TaxCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxRadio_ApplySalesTaxTo = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToRadio_Rebate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToRadio_Commission = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToRadio_NetCharge = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToRadio_LineNet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToRadio_UseFlags = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonControlRadio_PostBill = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxRadio_CommissionOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonControlRadio_Prebill = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxRadio_BillNet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelRadio_RebatePercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRadio_MarkupPercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRadio_StationPricesGross = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRadio_StationPricesNet = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxRadio_NumberOfDaysToBill = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputNumberOfDaysToBillRadio_Days = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelNumberOfDaysToBillRadio_Days = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemProductSetup_BroadcastMedia = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProduction_Production = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxProduction_AvalaraTaxExemptOverride = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputProduction_EmployeeTimeBillingRate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.GroupBoxProduction_ProductionEstimateFormat = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelProductionEstimateFormat_StandardFormat = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelProductionEstimateFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxProductionEstimateFormat_Type = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.NumericInputProduction_DefaultMarkupPercent = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputProduction_ContingencyPercent = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelProduction_EmployeeTimeBillableMessage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxProduction_DefaultTaxCode = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxProduction_UseEstimateBillingRate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxProduction_DefaultAlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.GroupBoxProduction_BillingOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputBillingOptions_EarlyPayDaysOverride = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxBillingOptions_BillingSetupComplete = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelBillingOptions_EarlyPayDaysOverride = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxBillingOptions_AllowVendorDiscounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxBillingOptions_BillNet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxBillingOptions_ConsolidateFunctions = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelProduction_DefaultAlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelProduction_DefaultTaxCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelProduction_EmployeeTimeBillingRate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelProduction_DefaultMarkupPercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelProduction_ContingencyPercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemProductSetup_Production = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCompanyProfileTab_CompanyProfile = New DevComponents.DotNetBar.TabControlPanel()
            Me.CompanyProfileControlCompanyProfile_CompanyProfile = New AdvantageFramework.WinForm.Presentation.Controls.CompanyProfileControl()
            Me.TabItemProductSetup_CompanyProfileTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelActivitySummaryTab_ActivitySummary = New DevComponents.DotNetBar.TabControlPanel()
            Me.ActivitySummaryControlActivitySummary_ActivitySummary = New AdvantageFramework.WinForm.Presentation.Controls.ActivitySummaryControl()
            Me.TabItemProductSetup_ActivitySummaryTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelContractsTab_ContractsOpportunities = New DevComponents.DotNetBar.TabControlPanel()
            Me.ContractManagerControlContracts_ProductContracts = New AdvantageFramework.WinForm.Presentation.Controls.ContractManagerControl()
            Me.TabItemProductSetup_ContractsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelAccountExecutives_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_AddAccountExecutive = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_RemoveAccountExecutive = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_AccountExecutives = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlAccountExecutives_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelAccountExecutives_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_Employees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemProductSetup_AccountExecutivesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia = New DevComponents.DotNetBar.TabControlPanel()
            Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelInternetOutOfHome_RightColumn = New System.Windows.Forms.Panel()
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputOutOfHome_Rebate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputOutOfHome_Markup = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ComboBoxOutOfHome_TaxCode = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxOutOfHome_BillingSetupComplete = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxOutOfHome_VendorDiscounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelOutOfHome_TaxCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxOutOfHome_ApplySalesTaxTo = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonControlOutOfHome_PostBill = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxOutOfHome_CommissionOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonControlOutOfHome_Prebill = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxOutOfHome_BillNet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelOutOfHome_RebatePercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelOutOfHome_MarkupPercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelOutOfHome_VendorPriceGross = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelOutOfHome_VendorPriceNet = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxOutOfHome_NumberOfDaysToBill = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelNumberOfDaysToBillOutOfHome_Days = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelInternetOutOfHome_LeftColumn = New System.Windows.Forms.Panel()
            Me.GroupBoxOutOfHomeInternetMedia_Internet = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputInternet_Rebate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputInternet_Markup = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ComboBoxInternet_TaxCode = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxInternet_BillingSetupComplete = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxInternet_VendorDiscounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelInternet_TaxCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxInternet_ApplySalesTaxTo = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToInternet_Rebate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToInternet_Commission = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToInternet_NetCharge = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToInternet_LineNet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToInternet_UseFlags = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonControlInternet_PostBill = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxInternet_CommissionOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonControlInternet_Prebill = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxInternet_BillNet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelInternet_RebatePercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelInternet_MarkupPercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelInternet_VendorPriceGross = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelInternet_VendorPriceNet = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxInternet_NumberOfDaysToBill = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputNumberOfDaysToBillInternet_Days = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelNumberOfDaysToBillInternet_Days = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemProductSetup_OutOfHomeInternetMedia = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelPrintMedia_PrintMedia = New DevComponents.DotNetBar.TabControlPanel()
            Me.TableLayoutPanelPrintMedia_PrintMedia = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelPrintMedia_RightColumn = New System.Windows.Forms.Panel()
            Me.GroupBoxRightColumn_Newspaper = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputNewspaper_Rebate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputNewspaper_Markup = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ComboBoxNewspaper_TaxCode = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxNewspaper_BillingSetupComplete = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxNewspaper_VendorDiscounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelNewspaper_TaxCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxNewspaper_ApplySalesTaxTo = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToNewspaper_Commission = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonControlNewspaper_PostBill = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxNewspaper_CommissionOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonControlNewspaper_Prebill = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxNewspaper_BillNet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelNewspaper_RebatePercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelNewspaper_MarkupPercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelNewspaper_PubPricesGross = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelNewspaper_PubPricesNet = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxNewspaper_NumberOfDaysToBill = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputNumberOfDaysToBillNewspaper_Days = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelNumberOfDaysToBillNewspaper_Days = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelPrintMedia_LeftColumn = New System.Windows.Forms.Panel()
            Me.GroupBoxLeftColumn_Magazine = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputMagazine_Rebate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputMagazine_Markup = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ComboBoxMagazine_TaxCode = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxMagazine_BillingSetupComplete = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMagazine_VendorDiscounts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelMagazine_TaxCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxMagazine_ApplySalesTaxTo = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToMagazine_Rebate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToMagazine_Commission = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToMagazine_LineNet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonControlMagazine_PostBill = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxMagazine_CommissionOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonControlMagazine_Prebill = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxMagazine_BillNet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelMagazine_RebatePercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMagazine_MarkupPercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMagazine_PubPricesGross = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMagazine_PubPricesNet = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxMagazine_NumberOfDaysToBill = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputNumberOfDaysToBillMagazine_Days = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelNumberOfDaysToBillMagazine_Days = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemProductSetup_PrintMedia = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDocumentsTab_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlDocuments_ProductDocuments = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemProductSetup_DocumentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlControl_ProductSetup, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_ProductSetup.SuspendLayout()
            Me.TabControlPanelGeneral_General.SuspendLayout()
            CType(Me.PanelSetup_Setup, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSetup_Setup.SuspendLayout()
            CType(Me.TabControlGeneral_General, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlGeneral_General.SuspendLayout()
            Me.TabControlPanel1.SuspendLayout()
            CType(Me.GroupBoxOptions_LatePaymentFee, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxOptions_LatePaymentFee.SuspendLayout()
            CType(Me.NumericInputLatePaymentFee_Percentage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelOptionsTab_Options.SuspendLayout()
            Me.TableLayoutPanelOptions_TableLayout.SuspendLayout()
            Me.PanelTableLayout_RightColumn.SuspendLayout()
            Me.PanelTableLayout_LeftColumn.SuspendLayout()
            CType(Me.GroupBoxLeftColumn_UserDefinedFields, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxLeftColumn_UserDefinedFields.SuspendLayout()
            Me.TabControlPanelAddressesTab_Addresses.SuspendLayout()
            Me.TableLayoutPanelAddresses_Addresses.SuspendLayout()
            Me.PanelAddresses_RightColumn.SuspendLayout()
            CType(Me.GroupBoxRightColumn_Statement, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxRightColumn_Statement.SuspendLayout()
            Me.PanelStatement_ContactInformation.SuspendLayout()
            Me.PanelAddresses_LeftColumn.SuspendLayout()
            CType(Me.GroupBoxLeftColumn_Billing, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxLeftColumn_Billing.SuspendLayout()
            CType(Me.PanelBilling_ContactInformation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBilling_ContactInformation.SuspendLayout()
            Me.TabControlPanelContactsTab_Contacts.SuspendLayout()
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.SuspendLayout()
            Me.TableLayoutPanelBroadcastMedia_BroadcastMedia.SuspendLayout()
            Me.PanelBroadcastMedia_RightColumn.SuspendLayout()
            CType(Me.GroupBoxRightColumn_Television, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxRightColumn_Television.SuspendLayout()
            CType(Me.NumericInputTelevision_Rebate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTelevision_Markup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxTelevision_ApplySalesTaxTo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxTelevision_ApplySalesTaxTo.SuspendLayout()
            CType(Me.GroupBoxTelevision_NumberOfDaysToBill, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxTelevision_NumberOfDaysToBill.SuspendLayout()
            CType(Me.NumericInputNumberOfDaysToBillTelevision_Days.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelBroadcastMedia_LeftColumn.SuspendLayout()
            CType(Me.GroupBoxLeftColumn_Radio, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxLeftColumn_Radio.SuspendLayout()
            CType(Me.NumericInputRadio_Rebate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputRadio_Markup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxRadio_ApplySalesTaxTo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxRadio_ApplySalesTaxTo.SuspendLayout()
            CType(Me.GroupBoxRadio_NumberOfDaysToBill, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxRadio_NumberOfDaysToBill.SuspendLayout()
            CType(Me.NumericInputNumberOfDaysToBillRadio_Days.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelProduction_Production.SuspendLayout()
            CType(Me.NumericInputProduction_EmployeeTimeBillingRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxProduction_ProductionEstimateFormat, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxProduction_ProductionEstimateFormat.SuspendLayout()
            CType(Me.NumericInputProduction_DefaultMarkupPercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputProduction_ContingencyPercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxProduction_BillingOptions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxProduction_BillingOptions.SuspendLayout()
            CType(Me.NumericInputBillingOptions_EarlyPayDaysOverride.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.SuspendLayout()
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.SuspendLayout()
            Me.TabControlPanelContractsTab_ContractsOpportunities.SuspendLayout()
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.SuspendLayout()
            CType(Me.PanelAccountExecutives_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelAccountExecutives_RightSection.SuspendLayout()
            CType(Me.PanelAccountExecutives_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelAccountExecutives_LeftSection.SuspendLayout()
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.SuspendLayout()
            Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome.SuspendLayout()
            Me.PanelInternetOutOfHome_RightColumn.SuspendLayout()
            CType(Me.GroupBoxOutOfHomeInternetMedia_OutOfHome, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.SuspendLayout()
            CType(Me.NumericInputOutOfHome_Rebate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputOutOfHome_Markup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxOutOfHome_ApplySalesTaxTo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxOutOfHome_ApplySalesTaxTo.SuspendLayout()
            CType(Me.GroupBoxOutOfHome_NumberOfDaysToBill, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxOutOfHome_NumberOfDaysToBill.SuspendLayout()
            CType(Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelInternetOutOfHome_LeftColumn.SuspendLayout()
            CType(Me.GroupBoxOutOfHomeInternetMedia_Internet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxOutOfHomeInternetMedia_Internet.SuspendLayout()
            CType(Me.NumericInputInternet_Rebate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputInternet_Markup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxInternet_ApplySalesTaxTo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxInternet_ApplySalesTaxTo.SuspendLayout()
            CType(Me.GroupBoxInternet_NumberOfDaysToBill, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxInternet_NumberOfDaysToBill.SuspendLayout()
            CType(Me.NumericInputNumberOfDaysToBillInternet_Days.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelPrintMedia_PrintMedia.SuspendLayout()
            Me.TableLayoutPanelPrintMedia_PrintMedia.SuspendLayout()
            Me.PanelPrintMedia_RightColumn.SuspendLayout()
            CType(Me.GroupBoxRightColumn_Newspaper, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxRightColumn_Newspaper.SuspendLayout()
            CType(Me.NumericInputNewspaper_Rebate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputNewspaper_Markup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxNewspaper_ApplySalesTaxTo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxNewspaper_ApplySalesTaxTo.SuspendLayout()
            CType(Me.GroupBoxNewspaper_NumberOfDaysToBill, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxNewspaper_NumberOfDaysToBill.SuspendLayout()
            CType(Me.NumericInputNumberOfDaysToBillNewspaper_Days.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelPrintMedia_LeftColumn.SuspendLayout()
            CType(Me.GroupBoxLeftColumn_Magazine, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxLeftColumn_Magazine.SuspendLayout()
            CType(Me.NumericInputMagazine_Rebate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputMagazine_Markup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxMagazine_ApplySalesTaxTo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMagazine_ApplySalesTaxTo.SuspendLayout()
            CType(Me.GroupBoxMagazine_NumberOfDaysToBill, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMagazine_NumberOfDaysToBill.SuspendLayout()
            CType(Me.NumericInputNumberOfDaysToBillMagazine_Days.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelDocumentsTab_Documents.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControlControl_ProductSetup
            '
            Me.TabControlControl_ProductSetup.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlControl_ProductSetup.CanReorderTabs = False
            Me.TabControlControl_ProductSetup.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlControl_ProductSetup.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlControl_ProductSetup.Controls.Add(Me.TabControlPanelGeneral_General)
            Me.TabControlControl_ProductSetup.Controls.Add(Me.TabControlPanelProduction_Production)
            Me.TabControlControl_ProductSetup.Controls.Add(Me.TabControlPanelContactsTab_Contacts)
            Me.TabControlControl_ProductSetup.Controls.Add(Me.TabControlPanelBroadcastMedia_BroadcastMedia)
            Me.TabControlControl_ProductSetup.Controls.Add(Me.TabControlPanelCompanyProfileTab_CompanyProfile)
            Me.TabControlControl_ProductSetup.Controls.Add(Me.TabControlPanelActivitySummaryTab_ActivitySummary)
            Me.TabControlControl_ProductSetup.Controls.Add(Me.TabControlPanelContractsTab_ContractsOpportunities)
            Me.TabControlControl_ProductSetup.Controls.Add(Me.TabControlPanelAccountExecutivesTab_AccountExecutives)
            Me.TabControlControl_ProductSetup.Controls.Add(Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia)
            Me.TabControlControl_ProductSetup.Controls.Add(Me.TabControlPanelPrintMedia_PrintMedia)
            Me.TabControlControl_ProductSetup.Controls.Add(Me.TabControlPanelDocumentsTab_Documents)
            Me.TabControlControl_ProductSetup.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_ProductSetup.Location = New System.Drawing.Point(0, 0)
            Me.TabControlControl_ProductSetup.Name = "TabControlControl_ProductSetup"
            Me.TabControlControl_ProductSetup.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_ProductSetup.SelectedTabIndex = 0
            Me.TabControlControl_ProductSetup.Size = New System.Drawing.Size(602, 573)
            Me.TabControlControl_ProductSetup.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_ProductSetup.TabIndex = 31
            Me.TabControlControl_ProductSetup.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_ProductSetup.Tabs.Add(Me.TabItemProductSetup_GeneralTab)
            Me.TabControlControl_ProductSetup.Tabs.Add(Me.TabItemProductSetup_Production)
            Me.TabControlControl_ProductSetup.Tabs.Add(Me.TabItemProductSetup_BroadcastMedia)
            Me.TabControlControl_ProductSetup.Tabs.Add(Me.TabItemProductSetup_PrintMedia)
            Me.TabControlControl_ProductSetup.Tabs.Add(Me.TabItemProductSetup_OutOfHomeInternetMedia)
            Me.TabControlControl_ProductSetup.Tabs.Add(Me.TabItemProductSetup_AccountExecutivesTab)
            Me.TabControlControl_ProductSetup.Tabs.Add(Me.TabItemProductSetup_ContactsTab)
            Me.TabControlControl_ProductSetup.Tabs.Add(Me.TabItemProductSetup_CompanyProfileTab)
            Me.TabControlControl_ProductSetup.Tabs.Add(Me.TabItemProductSetup_ActivitySummaryTab)
            Me.TabControlControl_ProductSetup.Tabs.Add(Me.TabItemProductSetup_ContractsTab)
            Me.TabControlControl_ProductSetup.Tabs.Add(Me.TabItemProductSetup_DocumentsTab)
            Me.TabControlControl_ProductSetup.Text = "TabControl1"
            '
            'TabControlPanelGeneral_General
            '
            Me.TabControlPanelGeneral_General.Controls.Add(Me.PanelSetup_Setup)
            Me.TabControlPanelGeneral_General.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelGeneral_General.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGeneral_General.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGeneral_General.Name = "TabControlPanelGeneral_General"
            Me.TabControlPanelGeneral_General.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGeneral_General.Size = New System.Drawing.Size(602, 546)
            Me.TabControlPanelGeneral_General.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelGeneral_General.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneral_General.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGeneral_General.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGeneral_General.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGeneral_General.Style.GradientAngle = 90
            Me.TabControlPanelGeneral_General.TabIndex = 2
            Me.TabControlPanelGeneral_General.TabItem = Me.TabItemProductSetup_GeneralTab
            '
            'PanelSetup_Setup
            '
            Me.PanelSetup_Setup.Controls.Add(Me.ComboBoxOptions_Office)
            Me.PanelSetup_Setup.Controls.Add(Me.LabelOptions_Office)
            Me.PanelSetup_Setup.Controls.Add(Me.CheckBoxGeneral_NewBusiness)
            Me.PanelSetup_Setup.Controls.Add(Me.LabelGeneral_Code)
            Me.PanelSetup_Setup.Controls.Add(Me.LabelSetup_Client)
            Me.PanelSetup_Setup.Controls.Add(Me.TabControlGeneral_General)
            Me.PanelSetup_Setup.Controls.Add(Me.LabelSetup_Division)
            Me.PanelSetup_Setup.Controls.Add(Me.CheckBoxGeneral_Inactive)
            Me.PanelSetup_Setup.Controls.Add(Me.TextBoxGeneral_Code)
            Me.PanelSetup_Setup.Controls.Add(Me.ComboBoxGeneral_Division)
            Me.PanelSetup_Setup.Controls.Add(Me.TextBoxGeneral_Description)
            Me.PanelSetup_Setup.Controls.Add(Me.ComboBoxGeneral_Client)
            Me.PanelSetup_Setup.Controls.Add(Me.LabelSetup_Name)
            Me.PanelSetup_Setup.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelSetup_Setup.Location = New System.Drawing.Point(1, 1)
            Me.PanelSetup_Setup.Name = "PanelSetup_Setup"
            Me.PanelSetup_Setup.Size = New System.Drawing.Size(600, 544)
            Me.PanelSetup_Setup.TabIndex = 0
            '
            'ComboBoxOptions_Office
            '
            Me.ComboBoxOptions_Office.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxOptions_Office.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxOptions_Office.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxOptions_Office.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxOptions_Office.AutoFindItemInDataSource = False
            Me.ComboBoxOptions_Office.AutoSelectSingleItemDatasource = False
            Me.ComboBoxOptions_Office.BookmarkingEnabled = False
            Me.ComboBoxOptions_Office.ClientCode = ""
            Me.ComboBoxOptions_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Office
            Me.ComboBoxOptions_Office.DisableMouseWheel = False
            Me.ComboBoxOptions_Office.DisplayMember = "Name"
            Me.ComboBoxOptions_Office.DisplayName = ""
            Me.ComboBoxOptions_Office.DivisionCode = ""
            Me.ComboBoxOptions_Office.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxOptions_Office.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxOptions_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxOptions_Office.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxOptions_Office.FocusHighlightEnabled = True
            Me.ComboBoxOptions_Office.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxOptions_Office.FormattingEnabled = True
            Me.ComboBoxOptions_Office.ItemHeight = 16
            Me.ComboBoxOptions_Office.Location = New System.Drawing.Point(64, 107)
            Me.ComboBoxOptions_Office.Name = "ComboBoxOptions_Office"
            Me.ComboBoxOptions_Office.ReadOnly = False
            Me.ComboBoxOptions_Office.SecurityEnabled = True
            Me.ComboBoxOptions_Office.Size = New System.Drawing.Size(531, 22)
            Me.ComboBoxOptions_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxOptions_Office.TabIndex = 11
            Me.ComboBoxOptions_Office.TabOnEnter = True
            Me.ComboBoxOptions_Office.ValueMember = "Code"
            Me.ComboBoxOptions_Office.WatermarkText = "Select Office"
            '
            'LabelOptions_Office
            '
            Me.LabelOptions_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_Office.Location = New System.Drawing.Point(4, 107)
            Me.LabelOptions_Office.Name = "LabelOptions_Office"
            Me.LabelOptions_Office.Size = New System.Drawing.Size(54, 20)
            Me.LabelOptions_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_Office.TabIndex = 10
            Me.LabelOptions_Office.Text = "Office:"
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
            Me.CheckBoxGeneral_NewBusiness.Location = New System.Drawing.Point(153, 3)
            Me.CheckBoxGeneral_NewBusiness.Name = "CheckBoxGeneral_NewBusiness"
            Me.CheckBoxGeneral_NewBusiness.OldestSibling = Nothing
            Me.CheckBoxGeneral_NewBusiness.SecurityEnabled = True
            Me.CheckBoxGeneral_NewBusiness.SiblingControls = CType(resources.GetObject("CheckBoxGeneral_NewBusiness.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneral_NewBusiness.Size = New System.Drawing.Size(100, 20)
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
            Me.LabelGeneral_Code.Location = New System.Drawing.Point(4, 4)
            Me.LabelGeneral_Code.Name = "LabelGeneral_Code"
            Me.LabelGeneral_Code.Size = New System.Drawing.Size(54, 20)
            Me.LabelGeneral_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Code.TabIndex = 0
            Me.LabelGeneral_Code.Text = "Code:"
            '
            'LabelSetup_Client
            '
            Me.LabelSetup_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_Client.Location = New System.Drawing.Point(4, 56)
            Me.LabelSetup_Client.Name = "LabelSetup_Client"
            Me.LabelSetup_Client.Size = New System.Drawing.Size(54, 20)
            Me.LabelSetup_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_Client.TabIndex = 6
            Me.LabelSetup_Client.Text = "Client: "
            '
            'TabControlGeneral_General
            '
            Me.TabControlGeneral_General.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlGeneral_General.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
            Me.TabControlGeneral_General.CanReorderTabs = False
            Me.TabControlGeneral_General.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlGeneral_General.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlGeneral_General.Controls.Add(Me.TabControlPanel1)
            Me.TabControlGeneral_General.Controls.Add(Me.TabControlPanelAddressesTab_Addresses)
            Me.TabControlGeneral_General.Controls.Add(Me.TabControlPanelOptionsTab_Options)
            Me.TabControlGeneral_General.Location = New System.Drawing.Point(3, 133)
            Me.TabControlGeneral_General.Name = "TabControlGeneral_General"
            Me.TabControlGeneral_General.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlGeneral_General.SelectedTabIndex = 0
            Me.TabControlGeneral_General.Size = New System.Drawing.Size(594, 406)
            Me.TabControlGeneral_General.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlGeneral_General.TabIndex = 15
            Me.TabControlGeneral_General.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlGeneral_General.Tabs.Add(Me.TabItemGeneral_AddressesTab)
            Me.TabControlGeneral_General.Tabs.Add(Me.TabItemGeneral_OptionsTab)
            Me.TabControlGeneral_General.Tabs.Add(Me.TabItemGeneral_BillingTab)
            Me.TabControlGeneral_General.Text = "TabControl1"
            '
            'TabControlPanel1
            '
            Me.TabControlPanel1.Controls.Add(Me.GroupBoxOptions_LatePaymentFee)
            Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel1.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel1.Name = "TabControlPanel1"
            Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel1.Size = New System.Drawing.Size(594, 379)
            Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel1.Style.GradientAngle = 90
            Me.TabControlPanel1.TabIndex = 7
            Me.TabControlPanel1.TabItem = Me.TabItemGeneral_BillingTab
            '
            'GroupBoxOptions_LatePaymentFee
            '
            Me.GroupBoxOptions_LatePaymentFee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxOptions_LatePaymentFee.Controls.Add(Me.NumericInputLatePaymentFee_Percentage)
            Me.GroupBoxOptions_LatePaymentFee.Controls.Add(Me.LabelLatePaymentFee_Percentage)
            Me.GroupBoxOptions_LatePaymentFee.Controls.Add(Me.CheckBoxLatePaymentFee_Calculate)
            Me.GroupBoxOptions_LatePaymentFee.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxOptions_LatePaymentFee.Name = "GroupBoxOptions_LatePaymentFee"
            Me.GroupBoxOptions_LatePaymentFee.Size = New System.Drawing.Size(586, 51)
            Me.GroupBoxOptions_LatePaymentFee.TabIndex = 14
            Me.GroupBoxOptions_LatePaymentFee.Text = "Late Payment Fee"
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
            'TabItemGeneral_BillingTab
            '
            Me.TabItemGeneral_BillingTab.AttachedControl = Me.TabControlPanel1
            Me.TabItemGeneral_BillingTab.Name = "TabItemGeneral_BillingTab"
            Me.TabItemGeneral_BillingTab.Text = "Billing"
            '
            'TabControlPanelOptionsTab_Options
            '
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.TableLayoutPanelOptions_TableLayout)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ComboBoxOptions_Currency)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_Currency)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_AttentionLine)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.TextBoxOptions_AttentionLine)
            Me.TabControlPanelOptionsTab_Options.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOptionsTab_Options.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOptionsTab_Options.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOptionsTab_Options.Name = "TabControlPanelOptionsTab_Options"
            Me.TabControlPanelOptionsTab_Options.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOptionsTab_Options.Size = New System.Drawing.Size(594, 379)
            Me.TabControlPanelOptionsTab_Options.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelOptionsTab_Options.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOptionsTab_Options.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOptionsTab_Options.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOptionsTab_Options.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOptionsTab_Options.Style.GradientAngle = 90
            Me.TabControlPanelOptionsTab_Options.TabIndex = 0
            Me.TabControlPanelOptionsTab_Options.TabItem = Me.TabItemGeneral_OptionsTab
            '
            'TableLayoutPanelOptions_TableLayout
            '
            Me.TableLayoutPanelOptions_TableLayout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelOptions_TableLayout.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelOptions_TableLayout.ColumnCount = 2
            Me.TableLayoutPanelOptions_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.97436!))
            Me.TableLayoutPanelOptions_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.02564!))
            Me.TableLayoutPanelOptions_TableLayout.Controls.Add(Me.PanelTableLayout_RightColumn, 1, 0)
            Me.TableLayoutPanelOptions_TableLayout.Controls.Add(Me.PanelTableLayout_LeftColumn, 0, 0)
            Me.TableLayoutPanelOptions_TableLayout.Location = New System.Drawing.Point(3, 31)
            Me.TableLayoutPanelOptions_TableLayout.Name = "TableLayoutPanelOptions_TableLayout"
            Me.TableLayoutPanelOptions_TableLayout.RowCount = 1
            Me.TableLayoutPanelOptions_TableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelOptions_TableLayout.Size = New System.Drawing.Size(585, 228)
            Me.TableLayoutPanelOptions_TableLayout.TabIndex = 12
            '
            'PanelTableLayout_RightColumn
            '
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.DataGridViewRightColumn_SortOptions)
            Me.PanelTableLayout_RightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTableLayout_RightColumn.Location = New System.Drawing.Point(345, 0)
            Me.PanelTableLayout_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTableLayout_RightColumn.Name = "PanelTableLayout_RightColumn"
            Me.PanelTableLayout_RightColumn.Size = New System.Drawing.Size(240, 228)
            Me.PanelTableLayout_RightColumn.TabIndex = 1
            '
            'DataGridViewRightColumn_SortOptions
            '
            Me.DataGridViewRightColumn_SortOptions.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightColumn_SortOptions.AllowDragAndDrop = False
            Me.DataGridViewRightColumn_SortOptions.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightColumn_SortOptions.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightColumn_SortOptions.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightColumn_SortOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightColumn_SortOptions.AutoFilterLookupColumns = False
            Me.DataGridViewRightColumn_SortOptions.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightColumn_SortOptions.AutoUpdateViewCaption = True
            Me.DataGridViewRightColumn_SortOptions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightColumn_SortOptions.DataSource = Nothing
            Me.DataGridViewRightColumn_SortOptions.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightColumn_SortOptions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightColumn_SortOptions.ItemDescription = "Sort Option(s)"
            Me.DataGridViewRightColumn_SortOptions.Location = New System.Drawing.Point(3, 0)
            Me.DataGridViewRightColumn_SortOptions.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewRightColumn_SortOptions.MultiSelect = True
            Me.DataGridViewRightColumn_SortOptions.Name = "DataGridViewRightColumn_SortOptions"
            Me.DataGridViewRightColumn_SortOptions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewRightColumn_SortOptions.RunStandardValidation = True
            Me.DataGridViewRightColumn_SortOptions.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightColumn_SortOptions.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightColumn_SortOptions.Size = New System.Drawing.Size(237, 201)
            Me.DataGridViewRightColumn_SortOptions.TabIndex = 6
            Me.DataGridViewRightColumn_SortOptions.UseEmbeddedNavigator = False
            Me.DataGridViewRightColumn_SortOptions.ViewCaptionHeight = -1
            '
            'PanelTableLayout_LeftColumn
            '
            Me.PanelTableLayout_LeftColumn.BackColor = System.Drawing.Color.White
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.GroupBoxLeftColumn_UserDefinedFields)
            Me.PanelTableLayout_LeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTableLayout_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelTableLayout_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTableLayout_LeftColumn.Name = "PanelTableLayout_LeftColumn"
            Me.PanelTableLayout_LeftColumn.Size = New System.Drawing.Size(345, 228)
            Me.PanelTableLayout_LeftColumn.TabIndex = 0
            '
            'GroupBoxLeftColumn_UserDefinedFields
            '
            Me.GroupBoxLeftColumn_UserDefinedFields.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxLeftColumn_UserDefinedFields.Controls.Add(Me.TextBoxUserDefinedFields_Field4)
            Me.GroupBoxLeftColumn_UserDefinedFields.Controls.Add(Me.TextBoxUserDefinedFields_Field3)
            Me.GroupBoxLeftColumn_UserDefinedFields.Controls.Add(Me.TextBoxUserDefinedFields_Field2)
            Me.GroupBoxLeftColumn_UserDefinedFields.Controls.Add(Me.TextBoxUserDefinedFields_Field1)
            Me.GroupBoxLeftColumn_UserDefinedFields.Location = New System.Drawing.Point(0, 0)
            Me.GroupBoxLeftColumn_UserDefinedFields.Name = "GroupBoxLeftColumn_UserDefinedFields"
            Me.GroupBoxLeftColumn_UserDefinedFields.Size = New System.Drawing.Size(342, 128)
            Me.GroupBoxLeftColumn_UserDefinedFields.TabIndex = 5
            Me.GroupBoxLeftColumn_UserDefinedFields.Text = "User Defined Fields"
            '
            'TextBoxUserDefinedFields_Field4
            '
            Me.TextBoxUserDefinedFields_Field4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxUserDefinedFields_Field4.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxUserDefinedFields_Field4.Border.Class = "TextBoxBorder"
            Me.TextBoxUserDefinedFields_Field4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxUserDefinedFields_Field4.CheckSpellingOnValidate = False
            Me.TextBoxUserDefinedFields_Field4.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxUserDefinedFields_Field4.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxUserDefinedFields_Field4.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxUserDefinedFields_Field4.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxUserDefinedFields_Field4.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxUserDefinedFields_Field4.FocusHighlightEnabled = True
            Me.TextBoxUserDefinedFields_Field4.ForeColor = System.Drawing.Color.Black
            Me.TextBoxUserDefinedFields_Field4.Location = New System.Drawing.Point(6, 103)
            Me.TextBoxUserDefinedFields_Field4.MaxFileSize = CType(0, Long)
            Me.TextBoxUserDefinedFields_Field4.Name = "TextBoxUserDefinedFields_Field4"
            Me.TextBoxUserDefinedFields_Field4.SecurityEnabled = True
            Me.TextBoxUserDefinedFields_Field4.ShowSpellCheckCompleteMessage = True
            Me.TextBoxUserDefinedFields_Field4.Size = New System.Drawing.Size(330, 21)
            Me.TextBoxUserDefinedFields_Field4.StartingFolderName = Nothing
            Me.TextBoxUserDefinedFields_Field4.TabIndex = 3
            Me.TextBoxUserDefinedFields_Field4.TabOnEnter = True
            '
            'TextBoxUserDefinedFields_Field3
            '
            Me.TextBoxUserDefinedFields_Field3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxUserDefinedFields_Field3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxUserDefinedFields_Field3.Border.Class = "TextBoxBorder"
            Me.TextBoxUserDefinedFields_Field3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxUserDefinedFields_Field3.CheckSpellingOnValidate = False
            Me.TextBoxUserDefinedFields_Field3.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxUserDefinedFields_Field3.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxUserDefinedFields_Field3.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxUserDefinedFields_Field3.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxUserDefinedFields_Field3.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxUserDefinedFields_Field3.FocusHighlightEnabled = True
            Me.TextBoxUserDefinedFields_Field3.ForeColor = System.Drawing.Color.Black
            Me.TextBoxUserDefinedFields_Field3.Location = New System.Drawing.Point(6, 77)
            Me.TextBoxUserDefinedFields_Field3.MaxFileSize = CType(0, Long)
            Me.TextBoxUserDefinedFields_Field3.Name = "TextBoxUserDefinedFields_Field3"
            Me.TextBoxUserDefinedFields_Field3.SecurityEnabled = True
            Me.TextBoxUserDefinedFields_Field3.ShowSpellCheckCompleteMessage = True
            Me.TextBoxUserDefinedFields_Field3.Size = New System.Drawing.Size(330, 21)
            Me.TextBoxUserDefinedFields_Field3.StartingFolderName = Nothing
            Me.TextBoxUserDefinedFields_Field3.TabIndex = 2
            Me.TextBoxUserDefinedFields_Field3.TabOnEnter = True
            '
            'TextBoxUserDefinedFields_Field2
            '
            Me.TextBoxUserDefinedFields_Field2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxUserDefinedFields_Field2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxUserDefinedFields_Field2.Border.Class = "TextBoxBorder"
            Me.TextBoxUserDefinedFields_Field2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxUserDefinedFields_Field2.CheckSpellingOnValidate = False
            Me.TextBoxUserDefinedFields_Field2.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxUserDefinedFields_Field2.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxUserDefinedFields_Field2.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxUserDefinedFields_Field2.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxUserDefinedFields_Field2.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxUserDefinedFields_Field2.FocusHighlightEnabled = True
            Me.TextBoxUserDefinedFields_Field2.ForeColor = System.Drawing.Color.Black
            Me.TextBoxUserDefinedFields_Field2.Location = New System.Drawing.Point(6, 51)
            Me.TextBoxUserDefinedFields_Field2.MaxFileSize = CType(0, Long)
            Me.TextBoxUserDefinedFields_Field2.Name = "TextBoxUserDefinedFields_Field2"
            Me.TextBoxUserDefinedFields_Field2.SecurityEnabled = True
            Me.TextBoxUserDefinedFields_Field2.ShowSpellCheckCompleteMessage = True
            Me.TextBoxUserDefinedFields_Field2.Size = New System.Drawing.Size(330, 21)
            Me.TextBoxUserDefinedFields_Field2.StartingFolderName = Nothing
            Me.TextBoxUserDefinedFields_Field2.TabIndex = 1
            Me.TextBoxUserDefinedFields_Field2.TabOnEnter = True
            '
            'TextBoxUserDefinedFields_Field1
            '
            Me.TextBoxUserDefinedFields_Field1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxUserDefinedFields_Field1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxUserDefinedFields_Field1.Border.Class = "TextBoxBorder"
            Me.TextBoxUserDefinedFields_Field1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxUserDefinedFields_Field1.CheckSpellingOnValidate = False
            Me.TextBoxUserDefinedFields_Field1.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxUserDefinedFields_Field1.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxUserDefinedFields_Field1.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxUserDefinedFields_Field1.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxUserDefinedFields_Field1.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxUserDefinedFields_Field1.FocusHighlightEnabled = True
            Me.TextBoxUserDefinedFields_Field1.ForeColor = System.Drawing.Color.Black
            Me.TextBoxUserDefinedFields_Field1.Location = New System.Drawing.Point(6, 25)
            Me.TextBoxUserDefinedFields_Field1.MaxFileSize = CType(0, Long)
            Me.TextBoxUserDefinedFields_Field1.Name = "TextBoxUserDefinedFields_Field1"
            Me.TextBoxUserDefinedFields_Field1.SecurityEnabled = True
            Me.TextBoxUserDefinedFields_Field1.ShowSpellCheckCompleteMessage = True
            Me.TextBoxUserDefinedFields_Field1.Size = New System.Drawing.Size(330, 21)
            Me.TextBoxUserDefinedFields_Field1.StartingFolderName = Nothing
            Me.TextBoxUserDefinedFields_Field1.TabIndex = 0
            Me.TextBoxUserDefinedFields_Field1.TabOnEnter = True
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
            Me.ComboBoxOptions_Currency.Location = New System.Drawing.Point(81, 265)
            Me.ComboBoxOptions_Currency.Name = "ComboBoxOptions_Currency"
            Me.ComboBoxOptions_Currency.ReadOnly = False
            Me.ComboBoxOptions_Currency.SecurityEnabled = True
            Me.ComboBoxOptions_Currency.Size = New System.Drawing.Size(508, 22)
            Me.ComboBoxOptions_Currency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxOptions_Currency.TabIndex = 4
            Me.ComboBoxOptions_Currency.TabOnEnter = True
            Me.ComboBoxOptions_Currency.ValueMember = "Code"
            Me.ComboBoxOptions_Currency.Visible = False
            Me.ComboBoxOptions_Currency.WatermarkText = "Select Currency Code"
            '
            'LabelOptions_Currency
            '
            Me.LabelOptions_Currency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_Currency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_Currency.Location = New System.Drawing.Point(3, 265)
            Me.LabelOptions_Currency.Name = "LabelOptions_Currency"
            Me.LabelOptions_Currency.Size = New System.Drawing.Size(72, 20)
            Me.LabelOptions_Currency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_Currency.TabIndex = 3
            Me.LabelOptions_Currency.Text = "Currency:"
            Me.LabelOptions_Currency.Visible = False
            '
            'LabelOptions_AttentionLine
            '
            Me.LabelOptions_AttentionLine.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_AttentionLine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_AttentionLine.Location = New System.Drawing.Point(3, 4)
            Me.LabelOptions_AttentionLine.Name = "LabelOptions_AttentionLine"
            Me.LabelOptions_AttentionLine.Size = New System.Drawing.Size(72, 20)
            Me.LabelOptions_AttentionLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_AttentionLine.TabIndex = 1
            Me.LabelOptions_AttentionLine.Text = "Attention Line:"
            '
            'TextBoxOptions_AttentionLine
            '
            Me.TextBoxOptions_AttentionLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxOptions_AttentionLine.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxOptions_AttentionLine.Border.Class = "TextBoxBorder"
            Me.TextBoxOptions_AttentionLine.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxOptions_AttentionLine.CheckSpellingOnValidate = False
            Me.TextBoxOptions_AttentionLine.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxOptions_AttentionLine.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxOptions_AttentionLine.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxOptions_AttentionLine.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxOptions_AttentionLine.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxOptions_AttentionLine.FocusHighlightEnabled = True
            Me.TextBoxOptions_AttentionLine.ForeColor = System.Drawing.Color.Black
            Me.TextBoxOptions_AttentionLine.Location = New System.Drawing.Point(81, 4)
            Me.TextBoxOptions_AttentionLine.MaxFileSize = CType(0, Long)
            Me.TextBoxOptions_AttentionLine.Name = "TextBoxOptions_AttentionLine"
            Me.TextBoxOptions_AttentionLine.SecurityEnabled = True
            Me.TextBoxOptions_AttentionLine.ShowSpellCheckCompleteMessage = True
            Me.TextBoxOptions_AttentionLine.Size = New System.Drawing.Size(507, 21)
            Me.TextBoxOptions_AttentionLine.StartingFolderName = Nothing
            Me.TextBoxOptions_AttentionLine.TabIndex = 2
            Me.TextBoxOptions_AttentionLine.TabOnEnter = True
            '
            'TabItemGeneral_OptionsTab
            '
            Me.TabItemGeneral_OptionsTab.AttachedControl = Me.TabControlPanelOptionsTab_Options
            Me.TabItemGeneral_OptionsTab.Name = "TabItemGeneral_OptionsTab"
            Me.TabItemGeneral_OptionsTab.Text = "Options"
            '
            'TabControlPanelAddressesTab_Addresses
            '
            Me.TabControlPanelAddressesTab_Addresses.Controls.Add(Me.TableLayoutPanelAddresses_Addresses)
            Me.TabControlPanelAddressesTab_Addresses.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAddressesTab_Addresses.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAddressesTab_Addresses.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAddressesTab_Addresses.Name = "TabControlPanelAddressesTab_Addresses"
            Me.TabControlPanelAddressesTab_Addresses.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAddressesTab_Addresses.Size = New System.Drawing.Size(594, 379)
            Me.TabControlPanelAddressesTab_Addresses.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAddressesTab_Addresses.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAddressesTab_Addresses.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAddressesTab_Addresses.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAddressesTab_Addresses.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAddressesTab_Addresses.Style.GradientAngle = 90
            Me.TabControlPanelAddressesTab_Addresses.TabIndex = 0
            Me.TabControlPanelAddressesTab_Addresses.TabItem = Me.TabItemGeneral_AddressesTab
            '
            'TableLayoutPanelAddresses_Addresses
            '
            Me.TableLayoutPanelAddresses_Addresses.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelAddresses_Addresses.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelAddresses_Addresses.ColumnCount = 2
            Me.TableLayoutPanelAddresses_Addresses.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelAddresses_Addresses.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelAddresses_Addresses.Controls.Add(Me.PanelAddresses_RightColumn, 1, 0)
            Me.TableLayoutPanelAddresses_Addresses.Controls.Add(Me.PanelAddresses_LeftColumn, 0, 0)
            Me.TableLayoutPanelAddresses_Addresses.Location = New System.Drawing.Point(4, 4)
            Me.TableLayoutPanelAddresses_Addresses.Name = "TableLayoutPanelAddresses_Addresses"
            Me.TableLayoutPanelAddresses_Addresses.RowCount = 1
            Me.TableLayoutPanelAddresses_Addresses.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelAddresses_Addresses.Size = New System.Drawing.Size(587, 293)
            Me.TableLayoutPanelAddresses_Addresses.TabIndex = 0
            '
            'PanelAddresses_RightColumn
            '
            Me.PanelAddresses_RightColumn.Controls.Add(Me.GroupBoxRightColumn_Statement)
            Me.PanelAddresses_RightColumn.Controls.Add(Me.ButtonRightColumn_RefreshStatement)
            Me.PanelAddresses_RightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelAddresses_RightColumn.Location = New System.Drawing.Point(293, 0)
            Me.PanelAddresses_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelAddresses_RightColumn.Name = "PanelAddresses_RightColumn"
            Me.PanelAddresses_RightColumn.Size = New System.Drawing.Size(294, 293)
            Me.PanelAddresses_RightColumn.TabIndex = 1
            '
            'GroupBoxRightColumn_Statement
            '
            Me.GroupBoxRightColumn_Statement.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxRightColumn_Statement.Controls.Add(Me.PanelStatement_ContactInformation)
            Me.GroupBoxRightColumn_Statement.Controls.Add(Me.AddressControlRightColumn_StatementAddress)
            Me.GroupBoxRightColumn_Statement.Location = New System.Drawing.Point(3, 26)
            Me.GroupBoxRightColumn_Statement.Name = "GroupBoxRightColumn_Statement"
            Me.GroupBoxRightColumn_Statement.Size = New System.Drawing.Size(291, 263)
            Me.GroupBoxRightColumn_Statement.TabIndex = 1
            Me.GroupBoxRightColumn_Statement.Text = "Statement"
            '
            'PanelStatement_ContactInformation
            '
            Me.PanelStatement_ContactInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelStatement_ContactInformation.Controls.Add(Me.TextBoxStatementContactInformation_FaxExt)
            Me.PanelStatement_ContactInformation.Controls.Add(Me.LabelStatementContactInformation_Phone)
            Me.PanelStatement_ContactInformation.Controls.Add(Me.LabelStatementContactInformation_FaxExt)
            Me.PanelStatement_ContactInformation.Controls.Add(Me.LabelStatementContactInformation_Fax)
            Me.PanelStatement_ContactInformation.Controls.Add(Me.TextBoxStatementContactInformation_PhoneExt)
            Me.PanelStatement_ContactInformation.Controls.Add(Me.TextBoxStatementContactInformation_Phone)
            Me.PanelStatement_ContactInformation.Controls.Add(Me.LabelStatementContactInformation_PhoneExt)
            Me.PanelStatement_ContactInformation.Controls.Add(Me.TextBoxStatementContactInformation_Fax)
            Me.PanelStatement_ContactInformation.Location = New System.Drawing.Point(5, 211)
            Me.PanelStatement_ContactInformation.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelStatement_ContactInformation.Name = "PanelStatement_ContactInformation"
            Me.PanelStatement_ContactInformation.Size = New System.Drawing.Size(280, 46)
            Me.PanelStatement_ContactInformation.TabIndex = 1
            '
            'TextBoxStatementContactInformation_FaxExt
            '
            Me.TextBoxStatementContactInformation_FaxExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxStatementContactInformation_FaxExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxStatementContactInformation_FaxExt.Border.Class = "TextBoxBorder"
            Me.TextBoxStatementContactInformation_FaxExt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxStatementContactInformation_FaxExt.CheckSpellingOnValidate = False
            Me.TextBoxStatementContactInformation_FaxExt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxStatementContactInformation_FaxExt.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxStatementContactInformation_FaxExt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxStatementContactInformation_FaxExt.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxStatementContactInformation_FaxExt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxStatementContactInformation_FaxExt.FocusHighlightEnabled = True
            Me.TextBoxStatementContactInformation_FaxExt.ForeColor = System.Drawing.Color.Black
            Me.TextBoxStatementContactInformation_FaxExt.Location = New System.Drawing.Point(229, 25)
            Me.TextBoxStatementContactInformation_FaxExt.MaxFileSize = CType(0, Long)
            Me.TextBoxStatementContactInformation_FaxExt.Name = "TextBoxStatementContactInformation_FaxExt"
            Me.TextBoxStatementContactInformation_FaxExt.SecurityEnabled = True
            Me.TextBoxStatementContactInformation_FaxExt.ShowSpellCheckCompleteMessage = True
            Me.TextBoxStatementContactInformation_FaxExt.Size = New System.Drawing.Size(47, 21)
            Me.TextBoxStatementContactInformation_FaxExt.StartingFolderName = Nothing
            Me.TextBoxStatementContactInformation_FaxExt.TabIndex = 7
            Me.TextBoxStatementContactInformation_FaxExt.TabOnEnter = True
            '
            'LabelStatementContactInformation_Phone
            '
            Me.LabelStatementContactInformation_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelStatementContactInformation_Phone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelStatementContactInformation_Phone.Location = New System.Drawing.Point(0, 0)
            Me.LabelStatementContactInformation_Phone.Name = "LabelStatementContactInformation_Phone"
            Me.LabelStatementContactInformation_Phone.Size = New System.Drawing.Size(37, 20)
            Me.LabelStatementContactInformation_Phone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelStatementContactInformation_Phone.TabIndex = 0
            Me.LabelStatementContactInformation_Phone.Text = "Phone:"
            '
            'LabelStatementContactInformation_FaxExt
            '
            Me.LabelStatementContactInformation_FaxExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelStatementContactInformation_FaxExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelStatementContactInformation_FaxExt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelStatementContactInformation_FaxExt.Location = New System.Drawing.Point(192, 25)
            Me.LabelStatementContactInformation_FaxExt.Name = "LabelStatementContactInformation_FaxExt"
            Me.LabelStatementContactInformation_FaxExt.Size = New System.Drawing.Size(31, 20)
            Me.LabelStatementContactInformation_FaxExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelStatementContactInformation_FaxExt.TabIndex = 6
            Me.LabelStatementContactInformation_FaxExt.Text = "Ext:"
            '
            'LabelStatementContactInformation_Fax
            '
            Me.LabelStatementContactInformation_Fax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelStatementContactInformation_Fax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelStatementContactInformation_Fax.Location = New System.Drawing.Point(0, 25)
            Me.LabelStatementContactInformation_Fax.Name = "LabelStatementContactInformation_Fax"
            Me.LabelStatementContactInformation_Fax.Size = New System.Drawing.Size(37, 20)
            Me.LabelStatementContactInformation_Fax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelStatementContactInformation_Fax.TabIndex = 4
            Me.LabelStatementContactInformation_Fax.Text = "Fax:"
            '
            'TextBoxStatementContactInformation_PhoneExt
            '
            Me.TextBoxStatementContactInformation_PhoneExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxStatementContactInformation_PhoneExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxStatementContactInformation_PhoneExt.Border.Class = "TextBoxBorder"
            Me.TextBoxStatementContactInformation_PhoneExt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxStatementContactInformation_PhoneExt.CheckSpellingOnValidate = False
            Me.TextBoxStatementContactInformation_PhoneExt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxStatementContactInformation_PhoneExt.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxStatementContactInformation_PhoneExt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxStatementContactInformation_PhoneExt.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxStatementContactInformation_PhoneExt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxStatementContactInformation_PhoneExt.FocusHighlightEnabled = True
            Me.TextBoxStatementContactInformation_PhoneExt.ForeColor = System.Drawing.Color.Black
            Me.TextBoxStatementContactInformation_PhoneExt.Location = New System.Drawing.Point(229, 0)
            Me.TextBoxStatementContactInformation_PhoneExt.MaxFileSize = CType(0, Long)
            Me.TextBoxStatementContactInformation_PhoneExt.Name = "TextBoxStatementContactInformation_PhoneExt"
            Me.TextBoxStatementContactInformation_PhoneExt.SecurityEnabled = True
            Me.TextBoxStatementContactInformation_PhoneExt.ShowSpellCheckCompleteMessage = True
            Me.TextBoxStatementContactInformation_PhoneExt.Size = New System.Drawing.Size(47, 21)
            Me.TextBoxStatementContactInformation_PhoneExt.StartingFolderName = Nothing
            Me.TextBoxStatementContactInformation_PhoneExt.TabIndex = 3
            Me.TextBoxStatementContactInformation_PhoneExt.TabOnEnter = True
            '
            'TextBoxStatementContactInformation_Phone
            '
            Me.TextBoxStatementContactInformation_Phone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxStatementContactInformation_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxStatementContactInformation_Phone.Border.Class = "TextBoxBorder"
            Me.TextBoxStatementContactInformation_Phone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxStatementContactInformation_Phone.CheckSpellingOnValidate = False
            Me.TextBoxStatementContactInformation_Phone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxStatementContactInformation_Phone.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxStatementContactInformation_Phone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxStatementContactInformation_Phone.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxStatementContactInformation_Phone.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxStatementContactInformation_Phone.FocusHighlightEnabled = True
            Me.TextBoxStatementContactInformation_Phone.ForeColor = System.Drawing.Color.Black
            Me.TextBoxStatementContactInformation_Phone.Location = New System.Drawing.Point(41, 0)
            Me.TextBoxStatementContactInformation_Phone.MaxFileSize = CType(0, Long)
            Me.TextBoxStatementContactInformation_Phone.Name = "TextBoxStatementContactInformation_Phone"
            Me.TextBoxStatementContactInformation_Phone.SecurityEnabled = True
            Me.TextBoxStatementContactInformation_Phone.ShowSpellCheckCompleteMessage = True
            Me.TextBoxStatementContactInformation_Phone.Size = New System.Drawing.Size(141, 21)
            Me.TextBoxStatementContactInformation_Phone.StartingFolderName = Nothing
            Me.TextBoxStatementContactInformation_Phone.TabIndex = 1
            Me.TextBoxStatementContactInformation_Phone.TabOnEnter = True
            '
            'LabelStatementContactInformation_PhoneExt
            '
            Me.LabelStatementContactInformation_PhoneExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelStatementContactInformation_PhoneExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelStatementContactInformation_PhoneExt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelStatementContactInformation_PhoneExt.Location = New System.Drawing.Point(192, 0)
            Me.LabelStatementContactInformation_PhoneExt.Name = "LabelStatementContactInformation_PhoneExt"
            Me.LabelStatementContactInformation_PhoneExt.Size = New System.Drawing.Size(31, 20)
            Me.LabelStatementContactInformation_PhoneExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelStatementContactInformation_PhoneExt.TabIndex = 2
            Me.LabelStatementContactInformation_PhoneExt.Text = "Ext:"
            '
            'TextBoxStatementContactInformation_Fax
            '
            Me.TextBoxStatementContactInformation_Fax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxStatementContactInformation_Fax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxStatementContactInformation_Fax.Border.Class = "TextBoxBorder"
            Me.TextBoxStatementContactInformation_Fax.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxStatementContactInformation_Fax.CheckSpellingOnValidate = False
            Me.TextBoxStatementContactInformation_Fax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxStatementContactInformation_Fax.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxStatementContactInformation_Fax.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxStatementContactInformation_Fax.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxStatementContactInformation_Fax.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxStatementContactInformation_Fax.FocusHighlightEnabled = True
            Me.TextBoxStatementContactInformation_Fax.ForeColor = System.Drawing.Color.Black
            Me.TextBoxStatementContactInformation_Fax.Location = New System.Drawing.Point(41, 25)
            Me.TextBoxStatementContactInformation_Fax.MaxFileSize = CType(0, Long)
            Me.TextBoxStatementContactInformation_Fax.Name = "TextBoxStatementContactInformation_Fax"
            Me.TextBoxStatementContactInformation_Fax.SecurityEnabled = True
            Me.TextBoxStatementContactInformation_Fax.ShowSpellCheckCompleteMessage = True
            Me.TextBoxStatementContactInformation_Fax.Size = New System.Drawing.Size(141, 21)
            Me.TextBoxStatementContactInformation_Fax.StartingFolderName = Nothing
            Me.TextBoxStatementContactInformation_Fax.TabIndex = 5
            Me.TextBoxStatementContactInformation_Fax.TabOnEnter = True
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
            Me.AddressControlRightColumn_StatementAddress.Location = New System.Drawing.Point(5, 24)
            Me.AddressControlRightColumn_StatementAddress.Margin = New System.Windows.Forms.Padding(4)
            Me.AddressControlRightColumn_StatementAddress.Name = "AddressControlRightColumn_StatementAddress"
            Me.AddressControlRightColumn_StatementAddress.ReadOnly = False
            Me.AddressControlRightColumn_StatementAddress.ShowCountry = True
            Me.AddressControlRightColumn_StatementAddress.ShowCounty = True
            Me.AddressControlRightColumn_StatementAddress.Size = New System.Drawing.Size(281, 181)
            Me.AddressControlRightColumn_StatementAddress.State = Nothing
            Me.AddressControlRightColumn_StatementAddress.TabIndex = 0
            Me.AddressControlRightColumn_StatementAddress.Title = "Address"
            Me.AddressControlRightColumn_StatementAddress.Zip = Nothing
            '
            'ButtonRightColumn_RefreshStatement
            '
            Me.ButtonRightColumn_RefreshStatement.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightColumn_RefreshStatement.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonRightColumn_RefreshStatement.AutoExpandOnClick = True
            Me.ButtonRightColumn_RefreshStatement.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightColumn_RefreshStatement.CommandParameter = "AddressControlSetup_StatementAddress"
            Me.ButtonRightColumn_RefreshStatement.Location = New System.Drawing.Point(219, 0)
            Me.ButtonRightColumn_RefreshStatement.Name = "ButtonRightColumn_RefreshStatement"
            Me.ButtonRightColumn_RefreshStatement.SecurityEnabled = True
            Me.ButtonRightColumn_RefreshStatement.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightColumn_RefreshStatement.SplitButton = True
            Me.ButtonRightColumn_RefreshStatement.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightColumn_RefreshStatement.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRefreshStatement_Client, Me.ButtonItemRefreshStatement_Division, Me.ButtonItemRefreshStatement_BillingAddress})
            Me.ButtonRightColumn_RefreshStatement.TabIndex = 0
            Me.ButtonRightColumn_RefreshStatement.Text = "Refresh"
            '
            'ButtonItemRefreshStatement_Client
            '
            Me.ButtonItemRefreshStatement_Client.CommandParameter = ""
            Me.ButtonItemRefreshStatement_Client.Name = "ButtonItemRefreshStatement_Client"
            Me.ButtonItemRefreshStatement_Client.Text = "Client"
            '
            'ButtonItemRefreshStatement_Division
            '
            Me.ButtonItemRefreshStatement_Division.CommandParameter = ""
            Me.ButtonItemRefreshStatement_Division.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemRefreshStatement_Division.Name = "ButtonItemRefreshStatement_Division"
            Me.ButtonItemRefreshStatement_Division.Text = "Division"
            '
            'ButtonItemRefreshStatement_BillingAddress
            '
            Me.ButtonItemRefreshStatement_BillingAddress.CommandParameter = ""
            Me.ButtonItemRefreshStatement_BillingAddress.Name = "ButtonItemRefreshStatement_BillingAddress"
            Me.ButtonItemRefreshStatement_BillingAddress.Text = "Billing"
            '
            'PanelAddresses_LeftColumn
            '
            Me.PanelAddresses_LeftColumn.Controls.Add(Me.GroupBoxLeftColumn_Billing)
            Me.PanelAddresses_LeftColumn.Controls.Add(Me.ButtonLeftSection_RefreshBilling)
            Me.PanelAddresses_LeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelAddresses_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelAddresses_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelAddresses_LeftColumn.Name = "PanelAddresses_LeftColumn"
            Me.PanelAddresses_LeftColumn.Size = New System.Drawing.Size(293, 293)
            Me.PanelAddresses_LeftColumn.TabIndex = 1
            '
            'GroupBoxLeftColumn_Billing
            '
            Me.GroupBoxLeftColumn_Billing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxLeftColumn_Billing.Controls.Add(Me.PanelBilling_ContactInformation)
            Me.GroupBoxLeftColumn_Billing.Controls.Add(Me.AddressControlLeftColumn_BillingAddress)
            Me.GroupBoxLeftColumn_Billing.Location = New System.Drawing.Point(0, 26)
            Me.GroupBoxLeftColumn_Billing.Name = "GroupBoxLeftColumn_Billing"
            Me.GroupBoxLeftColumn_Billing.Size = New System.Drawing.Size(290, 263)
            Me.GroupBoxLeftColumn_Billing.TabIndex = 2
            Me.GroupBoxLeftColumn_Billing.Text = "Billing"
            '
            'PanelBilling_ContactInformation
            '
            Me.PanelBilling_ContactInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelBilling_ContactInformation.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelBilling_ContactInformation.Controls.Add(Me.LabelBillingContactInformation_Phone)
            Me.PanelBilling_ContactInformation.Controls.Add(Me.TextBoxBillingContactInformation_FaxExt)
            Me.PanelBilling_ContactInformation.Controls.Add(Me.TextBoxBillingContactInformation_Fax)
            Me.PanelBilling_ContactInformation.Controls.Add(Me.TextBoxBillingContactInformation_Phone)
            Me.PanelBilling_ContactInformation.Controls.Add(Me.LabelBillingContactInformation_FaxExt)
            Me.PanelBilling_ContactInformation.Controls.Add(Me.LabelBillingContactInformation_PhoneExt)
            Me.PanelBilling_ContactInformation.Controls.Add(Me.LabelBillingContactInformation_Fax)
            Me.PanelBilling_ContactInformation.Controls.Add(Me.TextBoxBillingContactInformation_PhoneExt)
            Me.PanelBilling_ContactInformation.Location = New System.Drawing.Point(5, 211)
            Me.PanelBilling_ContactInformation.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelBilling_ContactInformation.Name = "PanelBilling_ContactInformation"
            Me.PanelBilling_ContactInformation.Size = New System.Drawing.Size(279, 46)
            Me.PanelBilling_ContactInformation.TabIndex = 3
            '
            'LabelBillingContactInformation_Phone
            '
            Me.LabelBillingContactInformation_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelBillingContactInformation_Phone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelBillingContactInformation_Phone.Location = New System.Drawing.Point(0, 0)
            Me.LabelBillingContactInformation_Phone.Name = "LabelBillingContactInformation_Phone"
            Me.LabelBillingContactInformation_Phone.Size = New System.Drawing.Size(37, 20)
            Me.LabelBillingContactInformation_Phone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelBillingContactInformation_Phone.TabIndex = 0
            Me.LabelBillingContactInformation_Phone.Text = "Phone:"
            '
            'TextBoxBillingContactInformation_FaxExt
            '
            Me.TextBoxBillingContactInformation_FaxExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxBillingContactInformation_FaxExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxBillingContactInformation_FaxExt.Border.Class = "TextBoxBorder"
            Me.TextBoxBillingContactInformation_FaxExt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxBillingContactInformation_FaxExt.CheckSpellingOnValidate = False
            Me.TextBoxBillingContactInformation_FaxExt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxBillingContactInformation_FaxExt.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxBillingContactInformation_FaxExt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxBillingContactInformation_FaxExt.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxBillingContactInformation_FaxExt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxBillingContactInformation_FaxExt.FocusHighlightEnabled = True
            Me.TextBoxBillingContactInformation_FaxExt.ForeColor = System.Drawing.Color.Black
            Me.TextBoxBillingContactInformation_FaxExt.Location = New System.Drawing.Point(229, 25)
            Me.TextBoxBillingContactInformation_FaxExt.MaxFileSize = CType(0, Long)
            Me.TextBoxBillingContactInformation_FaxExt.Name = "TextBoxBillingContactInformation_FaxExt"
            Me.TextBoxBillingContactInformation_FaxExt.SecurityEnabled = True
            Me.TextBoxBillingContactInformation_FaxExt.ShowSpellCheckCompleteMessage = True
            Me.TextBoxBillingContactInformation_FaxExt.Size = New System.Drawing.Size(47, 21)
            Me.TextBoxBillingContactInformation_FaxExt.StartingFolderName = Nothing
            Me.TextBoxBillingContactInformation_FaxExt.TabIndex = 7
            Me.TextBoxBillingContactInformation_FaxExt.TabOnEnter = True
            '
            'TextBoxBillingContactInformation_Fax
            '
            Me.TextBoxBillingContactInformation_Fax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxBillingContactInformation_Fax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxBillingContactInformation_Fax.Border.Class = "TextBoxBorder"
            Me.TextBoxBillingContactInformation_Fax.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxBillingContactInformation_Fax.CheckSpellingOnValidate = False
            Me.TextBoxBillingContactInformation_Fax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxBillingContactInformation_Fax.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxBillingContactInformation_Fax.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxBillingContactInformation_Fax.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxBillingContactInformation_Fax.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxBillingContactInformation_Fax.FocusHighlightEnabled = True
            Me.TextBoxBillingContactInformation_Fax.ForeColor = System.Drawing.Color.Black
            Me.TextBoxBillingContactInformation_Fax.Location = New System.Drawing.Point(41, 25)
            Me.TextBoxBillingContactInformation_Fax.MaxFileSize = CType(0, Long)
            Me.TextBoxBillingContactInformation_Fax.Name = "TextBoxBillingContactInformation_Fax"
            Me.TextBoxBillingContactInformation_Fax.SecurityEnabled = True
            Me.TextBoxBillingContactInformation_Fax.ShowSpellCheckCompleteMessage = True
            Me.TextBoxBillingContactInformation_Fax.Size = New System.Drawing.Size(141, 21)
            Me.TextBoxBillingContactInformation_Fax.StartingFolderName = Nothing
            Me.TextBoxBillingContactInformation_Fax.TabIndex = 5
            Me.TextBoxBillingContactInformation_Fax.TabOnEnter = True
            '
            'TextBoxBillingContactInformation_Phone
            '
            Me.TextBoxBillingContactInformation_Phone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxBillingContactInformation_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxBillingContactInformation_Phone.Border.Class = "TextBoxBorder"
            Me.TextBoxBillingContactInformation_Phone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxBillingContactInformation_Phone.CheckSpellingOnValidate = False
            Me.TextBoxBillingContactInformation_Phone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxBillingContactInformation_Phone.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxBillingContactInformation_Phone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxBillingContactInformation_Phone.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxBillingContactInformation_Phone.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxBillingContactInformation_Phone.FocusHighlightEnabled = True
            Me.TextBoxBillingContactInformation_Phone.ForeColor = System.Drawing.Color.Black
            Me.TextBoxBillingContactInformation_Phone.Location = New System.Drawing.Point(41, 0)
            Me.TextBoxBillingContactInformation_Phone.MaxFileSize = CType(0, Long)
            Me.TextBoxBillingContactInformation_Phone.Name = "TextBoxBillingContactInformation_Phone"
            Me.TextBoxBillingContactInformation_Phone.SecurityEnabled = True
            Me.TextBoxBillingContactInformation_Phone.ShowSpellCheckCompleteMessage = True
            Me.TextBoxBillingContactInformation_Phone.Size = New System.Drawing.Size(141, 21)
            Me.TextBoxBillingContactInformation_Phone.StartingFolderName = Nothing
            Me.TextBoxBillingContactInformation_Phone.TabIndex = 1
            Me.TextBoxBillingContactInformation_Phone.TabOnEnter = True
            '
            'LabelBillingContactInformation_FaxExt
            '
            Me.LabelBillingContactInformation_FaxExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelBillingContactInformation_FaxExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelBillingContactInformation_FaxExt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelBillingContactInformation_FaxExt.Location = New System.Drawing.Point(192, 25)
            Me.LabelBillingContactInformation_FaxExt.Name = "LabelBillingContactInformation_FaxExt"
            Me.LabelBillingContactInformation_FaxExt.Size = New System.Drawing.Size(31, 20)
            Me.LabelBillingContactInformation_FaxExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelBillingContactInformation_FaxExt.TabIndex = 6
            Me.LabelBillingContactInformation_FaxExt.Text = "Ext:"
            '
            'LabelBillingContactInformation_PhoneExt
            '
            Me.LabelBillingContactInformation_PhoneExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelBillingContactInformation_PhoneExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelBillingContactInformation_PhoneExt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelBillingContactInformation_PhoneExt.Location = New System.Drawing.Point(192, 0)
            Me.LabelBillingContactInformation_PhoneExt.Name = "LabelBillingContactInformation_PhoneExt"
            Me.LabelBillingContactInformation_PhoneExt.Size = New System.Drawing.Size(31, 20)
            Me.LabelBillingContactInformation_PhoneExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelBillingContactInformation_PhoneExt.TabIndex = 2
            Me.LabelBillingContactInformation_PhoneExt.Text = "Ext:"
            '
            'LabelBillingContactInformation_Fax
            '
            Me.LabelBillingContactInformation_Fax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelBillingContactInformation_Fax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelBillingContactInformation_Fax.Location = New System.Drawing.Point(0, 25)
            Me.LabelBillingContactInformation_Fax.Name = "LabelBillingContactInformation_Fax"
            Me.LabelBillingContactInformation_Fax.Size = New System.Drawing.Size(37, 20)
            Me.LabelBillingContactInformation_Fax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelBillingContactInformation_Fax.TabIndex = 4
            Me.LabelBillingContactInformation_Fax.Text = "Fax:"
            '
            'TextBoxBillingContactInformation_PhoneExt
            '
            Me.TextBoxBillingContactInformation_PhoneExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxBillingContactInformation_PhoneExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxBillingContactInformation_PhoneExt.Border.Class = "TextBoxBorder"
            Me.TextBoxBillingContactInformation_PhoneExt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxBillingContactInformation_PhoneExt.CheckSpellingOnValidate = False
            Me.TextBoxBillingContactInformation_PhoneExt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxBillingContactInformation_PhoneExt.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxBillingContactInformation_PhoneExt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxBillingContactInformation_PhoneExt.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxBillingContactInformation_PhoneExt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxBillingContactInformation_PhoneExt.FocusHighlightEnabled = True
            Me.TextBoxBillingContactInformation_PhoneExt.ForeColor = System.Drawing.Color.Black
            Me.TextBoxBillingContactInformation_PhoneExt.Location = New System.Drawing.Point(229, 0)
            Me.TextBoxBillingContactInformation_PhoneExt.MaxFileSize = CType(0, Long)
            Me.TextBoxBillingContactInformation_PhoneExt.Name = "TextBoxBillingContactInformation_PhoneExt"
            Me.TextBoxBillingContactInformation_PhoneExt.SecurityEnabled = True
            Me.TextBoxBillingContactInformation_PhoneExt.ShowSpellCheckCompleteMessage = True
            Me.TextBoxBillingContactInformation_PhoneExt.Size = New System.Drawing.Size(47, 21)
            Me.TextBoxBillingContactInformation_PhoneExt.StartingFolderName = Nothing
            Me.TextBoxBillingContactInformation_PhoneExt.TabIndex = 3
            Me.TextBoxBillingContactInformation_PhoneExt.TabOnEnter = True
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
            Me.AddressControlLeftColumn_BillingAddress.Location = New System.Drawing.Point(5, 24)
            Me.AddressControlLeftColumn_BillingAddress.Margin = New System.Windows.Forms.Padding(4)
            Me.AddressControlLeftColumn_BillingAddress.Name = "AddressControlLeftColumn_BillingAddress"
            Me.AddressControlLeftColumn_BillingAddress.ReadOnly = False
            Me.AddressControlLeftColumn_BillingAddress.ShowCountry = True
            Me.AddressControlLeftColumn_BillingAddress.ShowCounty = True
            Me.AddressControlLeftColumn_BillingAddress.Size = New System.Drawing.Size(279, 181)
            Me.AddressControlLeftColumn_BillingAddress.State = Nothing
            Me.AddressControlLeftColumn_BillingAddress.TabIndex = 3
            Me.AddressControlLeftColumn_BillingAddress.Title = "Address"
            Me.AddressControlLeftColumn_BillingAddress.Zip = Nothing
            '
            'ButtonLeftSection_RefreshBilling
            '
            Me.ButtonLeftSection_RefreshBilling.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonLeftSection_RefreshBilling.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonLeftSection_RefreshBilling.AutoExpandOnClick = True
            Me.ButtonLeftSection_RefreshBilling.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonLeftSection_RefreshBilling.CommandParameter = "AddressControlSetup_BillingAddress"
            Me.ButtonLeftSection_RefreshBilling.Location = New System.Drawing.Point(215, 0)
            Me.ButtonLeftSection_RefreshBilling.Name = "ButtonLeftSection_RefreshBilling"
            Me.ButtonLeftSection_RefreshBilling.SecurityEnabled = True
            Me.ButtonLeftSection_RefreshBilling.Size = New System.Drawing.Size(75, 20)
            Me.ButtonLeftSection_RefreshBilling.SplitButton = True
            Me.ButtonLeftSection_RefreshBilling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonLeftSection_RefreshBilling.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRefreshBilling_Client, Me.ButtonItemRefreshBilling_Division})
            Me.ButtonLeftSection_RefreshBilling.TabIndex = 0
            Me.ButtonLeftSection_RefreshBilling.Text = "Refresh"
            '
            'ButtonItemRefreshBilling_Client
            '
            Me.ButtonItemRefreshBilling_Client.CommandParameter = ""
            Me.ButtonItemRefreshBilling_Client.Name = "ButtonItemRefreshBilling_Client"
            Me.ButtonItemRefreshBilling_Client.Text = "Client"
            '
            'ButtonItemRefreshBilling_Division
            '
            Me.ButtonItemRefreshBilling_Division.CommandParameter = ""
            Me.ButtonItemRefreshBilling_Division.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemRefreshBilling_Division.Name = "ButtonItemRefreshBilling_Division"
            Me.ButtonItemRefreshBilling_Division.Text = "Division"
            '
            'TabItemGeneral_AddressesTab
            '
            Me.TabItemGeneral_AddressesTab.AttachedControl = Me.TabControlPanelAddressesTab_Addresses
            Me.TabItemGeneral_AddressesTab.Name = "TabItemGeneral_AddressesTab"
            Me.TabItemGeneral_AddressesTab.Text = "Addresses"
            '
            'LabelSetup_Division
            '
            Me.LabelSetup_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_Division.Location = New System.Drawing.Point(4, 82)
            Me.LabelSetup_Division.Name = "LabelSetup_Division"
            Me.LabelSetup_Division.Size = New System.Drawing.Size(54, 20)
            Me.LabelSetup_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_Division.TabIndex = 8
            Me.LabelSetup_Division.Text = "Division: "
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
            Me.CheckBoxGeneral_Inactive.Location = New System.Drawing.Point(531, 29)
            Me.CheckBoxGeneral_Inactive.Name = "CheckBoxGeneral_Inactive"
            Me.CheckBoxGeneral_Inactive.OldestSibling = Nothing
            Me.CheckBoxGeneral_Inactive.SecurityEnabled = True
            Me.CheckBoxGeneral_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxGeneral_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneral_Inactive.Size = New System.Drawing.Size(64, 20)
            Me.CheckBoxGeneral_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGeneral_Inactive.TabIndex = 5
            Me.CheckBoxGeneral_Inactive.TabOnEnter = True
            Me.CheckBoxGeneral_Inactive.Text = "Inactive"
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
            Me.TextBoxGeneral_Code.Location = New System.Drawing.Point(64, 3)
            Me.TextBoxGeneral_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Code.Name = "TextBoxGeneral_Code"
            Me.TextBoxGeneral_Code.SecurityEnabled = True
            Me.TextBoxGeneral_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Code.Size = New System.Drawing.Size(83, 21)
            Me.TextBoxGeneral_Code.StartingFolderName = Nothing
            Me.TextBoxGeneral_Code.TabIndex = 1
            Me.TextBoxGeneral_Code.TabOnEnter = True
            '
            'ComboBoxGeneral_Division
            '
            Me.ComboBoxGeneral_Division.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneral_Division.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_Division.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_Division.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_Division.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_Division.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_Division.BookmarkingEnabled = False
            Me.ComboBoxGeneral_Division.ClientCode = ""
            Me.ComboBoxGeneral_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Division
            Me.ComboBoxGeneral_Division.DisableMouseWheel = False
            Me.ComboBoxGeneral_Division.DisplayMember = "Description"
            Me.ComboBoxGeneral_Division.DisplayName = ""
            Me.ComboBoxGeneral_Division.DivisionCode = ""
            Me.ComboBoxGeneral_Division.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_Division.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxGeneral_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxGeneral_Division.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_Division.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_Division.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxGeneral_Division.FormattingEnabled = True
            Me.ComboBoxGeneral_Division.ItemHeight = 16
            Me.ComboBoxGeneral_Division.Location = New System.Drawing.Point(64, 81)
            Me.ComboBoxGeneral_Division.Name = "ComboBoxGeneral_Division"
            Me.ComboBoxGeneral_Division.ReadOnly = False
            Me.ComboBoxGeneral_Division.SecurityEnabled = True
            Me.ComboBoxGeneral_Division.Size = New System.Drawing.Size(531, 22)
            Me.ComboBoxGeneral_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_Division.TabIndex = 9
            Me.ComboBoxGeneral_Division.TabOnEnter = True
            Me.ComboBoxGeneral_Division.ValueMember = "Code"
            Me.ComboBoxGeneral_Division.WatermarkText = "Select Division"
            '
            'TextBoxGeneral_Description
            '
            Me.TextBoxGeneral_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxGeneral_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxGeneral_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_Description.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_Description.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxGeneral_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxGeneral_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Description.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Description.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneral_Description.Location = New System.Drawing.Point(64, 29)
            Me.TextBoxGeneral_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Description.Name = "TextBoxGeneral_Description"
            Me.TextBoxGeneral_Description.SecurityEnabled = True
            Me.TextBoxGeneral_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Description.Size = New System.Drawing.Size(461, 21)
            Me.TextBoxGeneral_Description.StartingFolderName = Nothing
            Me.TextBoxGeneral_Description.TabIndex = 4
            Me.TextBoxGeneral_Description.TabOnEnter = True
            '
            'ComboBoxGeneral_Client
            '
            Me.ComboBoxGeneral_Client.AddInactiveItemsOnSelectedValue = True
            Me.ComboBoxGeneral_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_Client.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_Client.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_Client.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_Client.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_Client.BookmarkingEnabled = False
            Me.ComboBoxGeneral_Client.ClientCode = ""
            Me.ComboBoxGeneral_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Client
            Me.ComboBoxGeneral_Client.DisableMouseWheel = False
            Me.ComboBoxGeneral_Client.DisplayMember = "Name"
            Me.ComboBoxGeneral_Client.DisplayName = ""
            Me.ComboBoxGeneral_Client.DivisionCode = ""
            Me.ComboBoxGeneral_Client.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_Client.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxGeneral_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxGeneral_Client.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_Client.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_Client.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxGeneral_Client.FormattingEnabled = True
            Me.ComboBoxGeneral_Client.ItemHeight = 16
            Me.ComboBoxGeneral_Client.Location = New System.Drawing.Point(64, 55)
            Me.ComboBoxGeneral_Client.Name = "ComboBoxGeneral_Client"
            Me.ComboBoxGeneral_Client.ReadOnly = False
            Me.ComboBoxGeneral_Client.SecurityEnabled = True
            Me.ComboBoxGeneral_Client.Size = New System.Drawing.Size(531, 22)
            Me.ComboBoxGeneral_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_Client.TabIndex = 7
            Me.ComboBoxGeneral_Client.TabOnEnter = True
            Me.ComboBoxGeneral_Client.ValueMember = "Code"
            Me.ComboBoxGeneral_Client.WatermarkText = "Select Client"
            '
            'LabelSetup_Name
            '
            Me.LabelSetup_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_Name.Location = New System.Drawing.Point(4, 30)
            Me.LabelSetup_Name.Name = "LabelSetup_Name"
            Me.LabelSetup_Name.Size = New System.Drawing.Size(54, 20)
            Me.LabelSetup_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_Name.TabIndex = 3
            Me.LabelSetup_Name.Text = "Name:"
            '
            'TabItemProductSetup_GeneralTab
            '
            Me.TabItemProductSetup_GeneralTab.AttachedControl = Me.TabControlPanelGeneral_General
            Me.TabItemProductSetup_GeneralTab.Name = "TabItemProductSetup_GeneralTab"
            Me.TabItemProductSetup_GeneralTab.Text = "General"
            '
            'TabControlPanelContactsTab_Contacts
            '
            Me.TabControlPanelContactsTab_Contacts.Controls.Add(Me.ClientContactManagerControlContacts_ProductContacts)
            Me.TabControlPanelContactsTab_Contacts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelContactsTab_Contacts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelContactsTab_Contacts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelContactsTab_Contacts.Name = "TabControlPanelContactsTab_Contacts"
            Me.TabControlPanelContactsTab_Contacts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelContactsTab_Contacts.Size = New System.Drawing.Size(602, 546)
            Me.TabControlPanelContactsTab_Contacts.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelContactsTab_Contacts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelContactsTab_Contacts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelContactsTab_Contacts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelContactsTab_Contacts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelContactsTab_Contacts.Style.GradientAngle = 90
            Me.TabControlPanelContactsTab_Contacts.TabIndex = 9
            Me.TabControlPanelContactsTab_Contacts.TabItem = Me.TabItemProductSetup_ContactsTab
            '
            'ClientContactManagerControlContacts_ProductContacts
            '
            Me.ClientContactManagerControlContacts_ProductContacts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ClientContactManagerControlContacts_ProductContacts.Location = New System.Drawing.Point(6, 6)
            Me.ClientContactManagerControlContacts_ProductContacts.Margin = New System.Windows.Forms.Padding(4)
            Me.ClientContactManagerControlContacts_ProductContacts.Name = "ClientContactManagerControlContacts_ProductContacts"
            Me.ClientContactManagerControlContacts_ProductContacts.Size = New System.Drawing.Size(590, 536)
            Me.ClientContactManagerControlContacts_ProductContacts.TabIndex = 0
            '
            'TabItemProductSetup_ContactsTab
            '
            Me.TabItemProductSetup_ContactsTab.AttachedControl = Me.TabControlPanelContactsTab_Contacts
            Me.TabItemProductSetup_ContactsTab.Name = "TabItemProductSetup_ContactsTab"
            Me.TabItemProductSetup_ContactsTab.Text = "Contacts"
            '
            'TabControlPanelBroadcastMedia_BroadcastMedia
            '
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.Controls.Add(Me.TableLayoutPanelBroadcastMedia_BroadcastMedia)
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.Name = "TabControlPanelBroadcastMedia_BroadcastMedia"
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.Size = New System.Drawing.Size(602, 546)
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.Style.GradientAngle = 90
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.TabIndex = 3
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.TabItem = Me.TabItemProductSetup_BroadcastMedia
            '
            'TableLayoutPanelBroadcastMedia_BroadcastMedia
            '
            Me.TableLayoutPanelBroadcastMedia_BroadcastMedia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelBroadcastMedia_BroadcastMedia.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelBroadcastMedia_BroadcastMedia.ColumnCount = 2
            Me.TableLayoutPanelBroadcastMedia_BroadcastMedia.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelBroadcastMedia_BroadcastMedia.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelBroadcastMedia_BroadcastMedia.Controls.Add(Me.PanelBroadcastMedia_RightColumn, 1, 0)
            Me.TableLayoutPanelBroadcastMedia_BroadcastMedia.Controls.Add(Me.PanelBroadcastMedia_LeftColumn, 0, 0)
            Me.TableLayoutPanelBroadcastMedia_BroadcastMedia.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanelBroadcastMedia_BroadcastMedia.Name = "TableLayoutPanelBroadcastMedia_BroadcastMedia"
            Me.TableLayoutPanelBroadcastMedia_BroadcastMedia.RowCount = 1
            Me.TableLayoutPanelBroadcastMedia_BroadcastMedia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelBroadcastMedia_BroadcastMedia.Size = New System.Drawing.Size(602, 438)
            Me.TableLayoutPanelBroadcastMedia_BroadcastMedia.TabIndex = 30
            '
            'PanelBroadcastMedia_RightColumn
            '
            Me.PanelBroadcastMedia_RightColumn.Controls.Add(Me.GroupBoxRightColumn_Television)
            Me.PanelBroadcastMedia_RightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelBroadcastMedia_RightColumn.Location = New System.Drawing.Point(301, 0)
            Me.PanelBroadcastMedia_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelBroadcastMedia_RightColumn.Name = "PanelBroadcastMedia_RightColumn"
            Me.PanelBroadcastMedia_RightColumn.Size = New System.Drawing.Size(301, 438)
            Me.PanelBroadcastMedia_RightColumn.TabIndex = 1
            '
            'GroupBoxRightColumn_Television
            '
            Me.GroupBoxRightColumn_Television.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxRightColumn_Television.Controls.Add(Me.NumericInputTelevision_Rebate)
            Me.GroupBoxRightColumn_Television.Controls.Add(Me.NumericInputTelevision_Markup)
            Me.GroupBoxRightColumn_Television.Controls.Add(Me.ComboBoxTelevision_TaxCode)
            Me.GroupBoxRightColumn_Television.Controls.Add(Me.CheckBoxTelevision_BillingSetupComplete)
            Me.GroupBoxRightColumn_Television.Controls.Add(Me.CheckBoxTelevision_VendorDiscounts)
            Me.GroupBoxRightColumn_Television.Controls.Add(Me.LabelTelevision_TaxCode)
            Me.GroupBoxRightColumn_Television.Controls.Add(Me.GroupBoxTelevision_ApplySalesTaxTo)
            Me.GroupBoxRightColumn_Television.Controls.Add(Me.RadioButtonControlTelevision_PostBill)
            Me.GroupBoxRightColumn_Television.Controls.Add(Me.CheckBoxTelevision_CommissionOnly)
            Me.GroupBoxRightColumn_Television.Controls.Add(Me.RadioButtonControlTelevision_Prebill)
            Me.GroupBoxRightColumn_Television.Controls.Add(Me.CheckBoxTelevision_BillNet)
            Me.GroupBoxRightColumn_Television.Controls.Add(Me.LabelTelevision_RebatePercent)
            Me.GroupBoxRightColumn_Television.Controls.Add(Me.LabelTelevision_MarkupPercent)
            Me.GroupBoxRightColumn_Television.Controls.Add(Me.LabelTelevision_StationPricesGross)
            Me.GroupBoxRightColumn_Television.Controls.Add(Me.LabelTelevision_StationPricesNet)
            Me.GroupBoxRightColumn_Television.Controls.Add(Me.GroupBoxTelevision_NumberOfDaysToBill)
            Me.GroupBoxRightColumn_Television.Location = New System.Drawing.Point(3, 6)
            Me.GroupBoxRightColumn_Television.Name = "GroupBoxRightColumn_Television"
            Me.GroupBoxRightColumn_Television.Size = New System.Drawing.Size(291, 424)
            Me.GroupBoxRightColumn_Television.TabIndex = 0
            Me.GroupBoxRightColumn_Television.Text = "Television"
            '
            'NumericInputTelevision_Rebate
            '
            Me.NumericInputTelevision_Rebate.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTelevision_Rebate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTelevision_Rebate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTelevision_Rebate.EnterMoveNextControl = True
            Me.NumericInputTelevision_Rebate.Location = New System.Drawing.Point(74, 103)
            Me.NumericInputTelevision_Rebate.Name = "NumericInputTelevision_Rebate"
            Me.NumericInputTelevision_Rebate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputTelevision_Rebate.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTelevision_Rebate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputTelevision_Rebate.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputTelevision_Rebate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTelevision_Rebate.Properties.EditFormat.FormatString = "f"
            Me.NumericInputTelevision_Rebate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTelevision_Rebate.Properties.Mask.EditMask = "f"
            Me.NumericInputTelevision_Rebate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTelevision_Rebate.SecurityEnabled = True
            Me.NumericInputTelevision_Rebate.Size = New System.Drawing.Size(73, 20)
            Me.NumericInputTelevision_Rebate.TabIndex = 6
            '
            'NumericInputTelevision_Markup
            '
            Me.NumericInputTelevision_Markup.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTelevision_Markup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTelevision_Markup.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTelevision_Markup.EnterMoveNextControl = True
            Me.NumericInputTelevision_Markup.Location = New System.Drawing.Point(74, 51)
            Me.NumericInputTelevision_Markup.Name = "NumericInputTelevision_Markup"
            Me.NumericInputTelevision_Markup.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputTelevision_Markup.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputTelevision_Markup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputTelevision_Markup.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputTelevision_Markup.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTelevision_Markup.Properties.EditFormat.FormatString = "f"
            Me.NumericInputTelevision_Markup.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTelevision_Markup.Properties.Mask.EditMask = "f"
            Me.NumericInputTelevision_Markup.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTelevision_Markup.SecurityEnabled = True
            Me.NumericInputTelevision_Markup.Size = New System.Drawing.Size(73, 20)
            Me.NumericInputTelevision_Markup.TabIndex = 3
            '
            'ComboBoxTelevision_TaxCode
            '
            Me.ComboBoxTelevision_TaxCode.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxTelevision_TaxCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxTelevision_TaxCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxTelevision_TaxCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxTelevision_TaxCode.AutoFindItemInDataSource = False
            Me.ComboBoxTelevision_TaxCode.AutoSelectSingleItemDatasource = False
            Me.ComboBoxTelevision_TaxCode.BookmarkingEnabled = False
            Me.ComboBoxTelevision_TaxCode.ClientCode = ""
            Me.ComboBoxTelevision_TaxCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.TaxCode
            Me.ComboBoxTelevision_TaxCode.DisableMouseWheel = False
            Me.ComboBoxTelevision_TaxCode.DisplayMember = "Name"
            Me.ComboBoxTelevision_TaxCode.DisplayName = ""
            Me.ComboBoxTelevision_TaxCode.DivisionCode = ""
            Me.ComboBoxTelevision_TaxCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxTelevision_TaxCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxTelevision_TaxCode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxTelevision_TaxCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxTelevision_TaxCode.FocusHighlightEnabled = True
            Me.ComboBoxTelevision_TaxCode.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxTelevision_TaxCode.FormattingEnabled = True
            Me.ComboBoxTelevision_TaxCode.ItemHeight = 16
            Me.ComboBoxTelevision_TaxCode.Location = New System.Drawing.Point(75, 264)
            Me.ComboBoxTelevision_TaxCode.Name = "ComboBoxTelevision_TaxCode"
            Me.ComboBoxTelevision_TaxCode.ReadOnly = False
            Me.ComboBoxTelevision_TaxCode.SecurityEnabled = True
            Me.ComboBoxTelevision_TaxCode.Size = New System.Drawing.Size(211, 22)
            Me.ComboBoxTelevision_TaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxTelevision_TaxCode.TabIndex = 15
            Me.ComboBoxTelevision_TaxCode.TabOnEnter = True
            Me.ComboBoxTelevision_TaxCode.ValueMember = "ID"
            Me.ComboBoxTelevision_TaxCode.WatermarkText = "Select Tax Code"
            '
            'CheckBoxTelevision_BillingSetupComplete
            '
            Me.CheckBoxTelevision_BillingSetupComplete.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxTelevision_BillingSetupComplete.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTelevision_BillingSetupComplete.CheckValue = 0
            Me.CheckBoxTelevision_BillingSetupComplete.CheckValueChecked = 1
            Me.CheckBoxTelevision_BillingSetupComplete.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTelevision_BillingSetupComplete.CheckValueUnchecked = 0
            Me.CheckBoxTelevision_BillingSetupComplete.ChildControls = CType(resources.GetObject("CheckBoxTelevision_BillingSetupComplete.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTelevision_BillingSetupComplete.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTelevision_BillingSetupComplete.Location = New System.Drawing.Point(149, 238)
            Me.CheckBoxTelevision_BillingSetupComplete.Name = "CheckBoxTelevision_BillingSetupComplete"
            Me.CheckBoxTelevision_BillingSetupComplete.OldestSibling = Nothing
            Me.CheckBoxTelevision_BillingSetupComplete.SecurityEnabled = True
            Me.CheckBoxTelevision_BillingSetupComplete.SiblingControls = CType(resources.GetObject("CheckBoxTelevision_BillingSetupComplete.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTelevision_BillingSetupComplete.Size = New System.Drawing.Size(138, 20)
            Me.CheckBoxTelevision_BillingSetupComplete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTelevision_BillingSetupComplete.TabIndex = 13
            Me.CheckBoxTelevision_BillingSetupComplete.TabOnEnter = True
            Me.CheckBoxTelevision_BillingSetupComplete.Text = "Billing Setup Complete"
            '
            'CheckBoxTelevision_VendorDiscounts
            '
            '
            '
            '
            Me.CheckBoxTelevision_VendorDiscounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTelevision_VendorDiscounts.CheckValue = 0
            Me.CheckBoxTelevision_VendorDiscounts.CheckValueChecked = 1
            Me.CheckBoxTelevision_VendorDiscounts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTelevision_VendorDiscounts.CheckValueUnchecked = 0
            Me.CheckBoxTelevision_VendorDiscounts.ChildControls = CType(resources.GetObject("CheckBoxTelevision_VendorDiscounts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTelevision_VendorDiscounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTelevision_VendorDiscounts.Location = New System.Drawing.Point(5, 238)
            Me.CheckBoxTelevision_VendorDiscounts.Name = "CheckBoxTelevision_VendorDiscounts"
            Me.CheckBoxTelevision_VendorDiscounts.OldestSibling = Nothing
            Me.CheckBoxTelevision_VendorDiscounts.SecurityEnabled = True
            Me.CheckBoxTelevision_VendorDiscounts.SiblingControls = CType(resources.GetObject("CheckBoxTelevision_VendorDiscounts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTelevision_VendorDiscounts.Size = New System.Drawing.Size(137, 20)
            Me.CheckBoxTelevision_VendorDiscounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTelevision_VendorDiscounts.TabIndex = 12
            Me.CheckBoxTelevision_VendorDiscounts.TabOnEnter = True
            Me.CheckBoxTelevision_VendorDiscounts.Text = "Vendor Discounts"
            '
            'LabelTelevision_TaxCode
            '
            Me.LabelTelevision_TaxCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTelevision_TaxCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTelevision_TaxCode.Location = New System.Drawing.Point(5, 264)
            Me.LabelTelevision_TaxCode.Name = "LabelTelevision_TaxCode"
            Me.LabelTelevision_TaxCode.Size = New System.Drawing.Size(63, 20)
            Me.LabelTelevision_TaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTelevision_TaxCode.TabIndex = 14
            Me.LabelTelevision_TaxCode.Text = "Tax Code:"
            '
            'GroupBoxTelevision_ApplySalesTaxTo
            '
            Me.GroupBoxTelevision_ApplySalesTaxTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxTelevision_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToTelevision_NetDiscount)
            Me.GroupBoxTelevision_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToTelevision_Rebate)
            Me.GroupBoxTelevision_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToTelevision_Commission)
            Me.GroupBoxTelevision_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToTelevision_AddlCharge)
            Me.GroupBoxTelevision_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToTelevision_NetCharge)
            Me.GroupBoxTelevision_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToTelevision_LineNet)
            Me.GroupBoxTelevision_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToTelevision_UseFlags)
            Me.GroupBoxTelevision_ApplySalesTaxTo.Location = New System.Drawing.Point(5, 290)
            Me.GroupBoxTelevision_ApplySalesTaxTo.Name = "GroupBoxTelevision_ApplySalesTaxTo"
            Me.GroupBoxTelevision_ApplySalesTaxTo.Size = New System.Drawing.Size(282, 129)
            Me.GroupBoxTelevision_ApplySalesTaxTo.TabIndex = 16
            Me.GroupBoxTelevision_ApplySalesTaxTo.Text = "Apply Sales Tax To"
            '
            'CheckBoxApplySalesTaxToTelevision_NetDiscount
            '
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.CheckValue = 0
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToTelevision_NetDiscount.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.Location = New System.Drawing.Point(158, 103)
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.Name = "CheckBoxApplySalesTaxToTelevision_NetDiscount"
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToTelevision_NetDiscount.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.Size = New System.Drawing.Size(96, 20)
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.TabIndex = 6
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToTelevision_NetDiscount.Text = "Net Discount"
            '
            'CheckBoxApplySalesTaxToTelevision_Rebate
            '
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.CheckValue = 0
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToTelevision_Rebate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.Location = New System.Drawing.Point(158, 77)
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.Name = "CheckBoxApplySalesTaxToTelevision_Rebate"
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToTelevision_Rebate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.Size = New System.Drawing.Size(96, 20)
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.TabIndex = 5
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToTelevision_Rebate.Text = "Rebate"
            '
            'CheckBoxApplySalesTaxToTelevision_Commission
            '
            Me.CheckBoxApplySalesTaxToTelevision_Commission.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToTelevision_Commission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToTelevision_Commission.CheckValue = 0
            Me.CheckBoxApplySalesTaxToTelevision_Commission.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToTelevision_Commission.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToTelevision_Commission.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToTelevision_Commission.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToTelevision_Commission.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToTelevision_Commission.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToTelevision_Commission.Location = New System.Drawing.Point(158, 51)
            Me.CheckBoxApplySalesTaxToTelevision_Commission.Name = "CheckBoxApplySalesTaxToTelevision_Commission"
            Me.CheckBoxApplySalesTaxToTelevision_Commission.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToTelevision_Commission.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToTelevision_Commission.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToTelevision_Commission.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToTelevision_Commission.Size = New System.Drawing.Size(96, 20)
            Me.CheckBoxApplySalesTaxToTelevision_Commission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToTelevision_Commission.TabIndex = 4
            Me.CheckBoxApplySalesTaxToTelevision_Commission.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToTelevision_Commission.Text = "Commission"
            '
            'CheckBoxApplySalesTaxToTelevision_AddlCharge
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.CheckValue = 0
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToTelevision_AddlCharge.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.Location = New System.Drawing.Point(24, 103)
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.Name = "CheckBoxApplySalesTaxToTelevision_AddlCharge"
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToTelevision_AddlCharge.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.TabIndex = 3
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToTelevision_AddlCharge.Text = "Addl Charge"
            '
            'CheckBoxApplySalesTaxToTelevision_NetCharge
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.CheckValue = 0
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToTelevision_NetCharge.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.Location = New System.Drawing.Point(24, 77)
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.Name = "CheckBoxApplySalesTaxToTelevision_NetCharge"
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToTelevision_NetCharge.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.TabIndex = 2
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToTelevision_NetCharge.Text = "Net Charge"
            '
            'CheckBoxApplySalesTaxToTelevision_LineNet
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.CheckValue = 0
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToTelevision_LineNet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.Location = New System.Drawing.Point(24, 51)
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.Name = "CheckBoxApplySalesTaxToTelevision_LineNet"
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToTelevision_LineNet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.TabIndex = 1
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToTelevision_LineNet.Text = "Line Net"
            '
            'CheckBoxApplySalesTaxToTelevision_UseFlags
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.CheckValue = 0
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToTelevision_UseFlags.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.Name = "CheckBoxApplySalesTaxToTelevision_UseFlags"
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToTelevision_UseFlags.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.TabIndex = 0
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToTelevision_UseFlags.Text = "Use Flags"
            '
            'RadioButtonControlTelevision_PostBill
            '
            Me.RadioButtonControlTelevision_PostBill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlTelevision_PostBill.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlTelevision_PostBill.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlTelevision_PostBill.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlTelevision_PostBill.Location = New System.Drawing.Point(164, 51)
            Me.RadioButtonControlTelevision_PostBill.Name = "RadioButtonControlTelevision_PostBill"
            Me.RadioButtonControlTelevision_PostBill.SecurityEnabled = True
            Me.RadioButtonControlTelevision_PostBill.Size = New System.Drawing.Size(123, 20)
            Me.RadioButtonControlTelevision_PostBill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlTelevision_PostBill.TabIndex = 8
            Me.RadioButtonControlTelevision_PostBill.TabOnEnter = True
            Me.RadioButtonControlTelevision_PostBill.TabStop = False
            Me.RadioButtonControlTelevision_PostBill.Text = "Post Bill"
            '
            'CheckBoxTelevision_CommissionOnly
            '
            Me.CheckBoxTelevision_CommissionOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxTelevision_CommissionOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTelevision_CommissionOnly.CheckValue = 0
            Me.CheckBoxTelevision_CommissionOnly.CheckValueChecked = 1
            Me.CheckBoxTelevision_CommissionOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTelevision_CommissionOnly.CheckValueUnchecked = 0
            Me.CheckBoxTelevision_CommissionOnly.ChildControls = CType(resources.GetObject("CheckBoxTelevision_CommissionOnly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTelevision_CommissionOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTelevision_CommissionOnly.Location = New System.Drawing.Point(164, 103)
            Me.CheckBoxTelevision_CommissionOnly.Name = "CheckBoxTelevision_CommissionOnly"
            Me.CheckBoxTelevision_CommissionOnly.OldestSibling = Nothing
            Me.CheckBoxTelevision_CommissionOnly.SecurityEnabled = True
            Me.CheckBoxTelevision_CommissionOnly.SiblingControls = CType(resources.GetObject("CheckBoxTelevision_CommissionOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTelevision_CommissionOnly.Size = New System.Drawing.Size(123, 20)
            Me.CheckBoxTelevision_CommissionOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTelevision_CommissionOnly.TabIndex = 10
            Me.CheckBoxTelevision_CommissionOnly.TabOnEnter = True
            Me.CheckBoxTelevision_CommissionOnly.Text = "Commission Only"
            '
            'RadioButtonControlTelevision_Prebill
            '
            Me.RadioButtonControlTelevision_Prebill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlTelevision_Prebill.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlTelevision_Prebill.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlTelevision_Prebill.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlTelevision_Prebill.Checked = True
            Me.RadioButtonControlTelevision_Prebill.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlTelevision_Prebill.CheckValue = "Y"
            Me.RadioButtonControlTelevision_Prebill.Location = New System.Drawing.Point(164, 25)
            Me.RadioButtonControlTelevision_Prebill.Name = "RadioButtonControlTelevision_Prebill"
            Me.RadioButtonControlTelevision_Prebill.SecurityEnabled = True
            Me.RadioButtonControlTelevision_Prebill.Size = New System.Drawing.Size(123, 20)
            Me.RadioButtonControlTelevision_Prebill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlTelevision_Prebill.TabIndex = 7
            Me.RadioButtonControlTelevision_Prebill.TabOnEnter = True
            Me.RadioButtonControlTelevision_Prebill.Text = "Prebill"
            '
            'CheckBoxTelevision_BillNet
            '
            Me.CheckBoxTelevision_BillNet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxTelevision_BillNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTelevision_BillNet.CheckValue = 0
            Me.CheckBoxTelevision_BillNet.CheckValueChecked = 1
            Me.CheckBoxTelevision_BillNet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTelevision_BillNet.CheckValueUnchecked = 0
            Me.CheckBoxTelevision_BillNet.ChildControls = CType(resources.GetObject("CheckBoxTelevision_BillNet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTelevision_BillNet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTelevision_BillNet.Location = New System.Drawing.Point(164, 77)
            Me.CheckBoxTelevision_BillNet.Name = "CheckBoxTelevision_BillNet"
            Me.CheckBoxTelevision_BillNet.OldestSibling = Nothing
            Me.CheckBoxTelevision_BillNet.SecurityEnabled = True
            Me.CheckBoxTelevision_BillNet.SiblingControls = CType(resources.GetObject("CheckBoxTelevision_BillNet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTelevision_BillNet.Size = New System.Drawing.Size(123, 20)
            Me.CheckBoxTelevision_BillNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTelevision_BillNet.TabIndex = 9
            Me.CheckBoxTelevision_BillNet.TabOnEnter = True
            Me.CheckBoxTelevision_BillNet.Text = "Bill Net"
            '
            'LabelTelevision_RebatePercent
            '
            Me.LabelTelevision_RebatePercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTelevision_RebatePercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTelevision_RebatePercent.Location = New System.Drawing.Point(5, 103)
            Me.LabelTelevision_RebatePercent.Name = "LabelTelevision_RebatePercent"
            Me.LabelTelevision_RebatePercent.Size = New System.Drawing.Size(63, 20)
            Me.LabelTelevision_RebatePercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTelevision_RebatePercent.TabIndex = 5
            Me.LabelTelevision_RebatePercent.Text = "Rebate %:"
            '
            'LabelTelevision_MarkupPercent
            '
            Me.LabelTelevision_MarkupPercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTelevision_MarkupPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTelevision_MarkupPercent.Location = New System.Drawing.Point(5, 51)
            Me.LabelTelevision_MarkupPercent.Name = "LabelTelevision_MarkupPercent"
            Me.LabelTelevision_MarkupPercent.Size = New System.Drawing.Size(63, 20)
            Me.LabelTelevision_MarkupPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTelevision_MarkupPercent.TabIndex = 2
            Me.LabelTelevision_MarkupPercent.Text = "Markup %:"
            '
            'LabelTelevision_StationPricesGross
            '
            Me.LabelTelevision_StationPricesGross.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTelevision_StationPricesGross.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTelevision_StationPricesGross.Location = New System.Drawing.Point(5, 77)
            Me.LabelTelevision_StationPricesGross.Name = "LabelTelevision_StationPricesGross"
            Me.LabelTelevision_StationPricesGross.Size = New System.Drawing.Size(142, 20)
            Me.LabelTelevision_StationPricesGross.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTelevision_StationPricesGross.TabIndex = 4
            Me.LabelTelevision_StationPricesGross.Text = "If Station Prices are Gross:"
            '
            'LabelTelevision_StationPricesNet
            '
            Me.LabelTelevision_StationPricesNet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTelevision_StationPricesNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTelevision_StationPricesNet.Location = New System.Drawing.Point(5, 25)
            Me.LabelTelevision_StationPricesNet.Name = "LabelTelevision_StationPricesNet"
            Me.LabelTelevision_StationPricesNet.Size = New System.Drawing.Size(142, 20)
            Me.LabelTelevision_StationPricesNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTelevision_StationPricesNet.TabIndex = 1
            Me.LabelTelevision_StationPricesNet.Text = "If Station Prices are Net:"
            '
            'GroupBoxTelevision_NumberOfDaysToBill
            '
            Me.GroupBoxTelevision_NumberOfDaysToBill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxTelevision_NumberOfDaysToBill.Controls.Add(Me.NumericInputNumberOfDaysToBillTelevision_Days)
            Me.GroupBoxTelevision_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate)
            Me.GroupBoxTelevision_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate)
            Me.GroupBoxTelevision_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate)
            Me.GroupBoxTelevision_NumberOfDaysToBill.Controls.Add(Me.LabelNumberOfDaysToBillTelevision_Days)
            Me.GroupBoxTelevision_NumberOfDaysToBill.Location = New System.Drawing.Point(5, 129)
            Me.GroupBoxTelevision_NumberOfDaysToBill.Name = "GroupBoxTelevision_NumberOfDaysToBill"
            Me.GroupBoxTelevision_NumberOfDaysToBill.Size = New System.Drawing.Size(282, 103)
            Me.GroupBoxTelevision_NumberOfDaysToBill.TabIndex = 11
            Me.GroupBoxTelevision_NumberOfDaysToBill.Text = "# of Days to Bill"
            '
            'NumericInputNumberOfDaysToBillTelevision_Days
            '
            Me.NumericInputNumberOfDaysToBillTelevision_Days.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputNumberOfDaysToBillTelevision_Days.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputNumberOfDaysToBillTelevision_Days.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputNumberOfDaysToBillTelevision_Days.EnterMoveNextControl = True
            Me.NumericInputNumberOfDaysToBillTelevision_Days.Location = New System.Drawing.Point(46, 25)
            Me.NumericInputNumberOfDaysToBillTelevision_Days.Name = "NumericInputNumberOfDaysToBillTelevision_Days"
            Me.NumericInputNumberOfDaysToBillTelevision_Days.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputNumberOfDaysToBillTelevision_Days.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputNumberOfDaysToBillTelevision_Days.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputNumberOfDaysToBillTelevision_Days.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputNumberOfDaysToBillTelevision_Days.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNumberOfDaysToBillTelevision_Days.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputNumberOfDaysToBillTelevision_Days.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNumberOfDaysToBillTelevision_Days.Properties.IsFloatValue = False
            Me.NumericInputNumberOfDaysToBillTelevision_Days.Properties.Mask.EditMask = "f0"
            Me.NumericInputNumberOfDaysToBillTelevision_Days.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputNumberOfDaysToBillTelevision_Days.Properties.MaxLength = 11
            Me.NumericInputNumberOfDaysToBillTelevision_Days.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputNumberOfDaysToBillTelevision_Days.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputNumberOfDaysToBillTelevision_Days.SecurityEnabled = True
            Me.NumericInputNumberOfDaysToBillTelevision_Days.Size = New System.Drawing.Size(71, 20)
            Me.NumericInputNumberOfDaysToBillTelevision_Days.TabIndex = 1
            '
            'RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate
            '
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate.Location = New System.Drawing.Point(139, 77)
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate.Name = "RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate"
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate.TabIndex = 4
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate.TabStop = False
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate.Text = "Before Close Date"
            '
            'RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate
            '
            Me.RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate.Location = New System.Drawing.Point(139, 51)
            Me.RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate.Name = "RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate"
            Me.RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate.TabIndex = 3
            Me.RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate.TabStop = False
            Me.RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate.Text = "After Broadcast Date"
            '
            'RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate
            '
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.Checked = True
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.CheckValue = "Y"
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.Location = New System.Drawing.Point(139, 25)
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.Name = "RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate"
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.TabIndex = 2
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate.Text = "Before Broadcast Date"
            '
            'LabelNumberOfDaysToBillTelevision_Days
            '
            Me.LabelNumberOfDaysToBillTelevision_Days.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNumberOfDaysToBillTelevision_Days.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNumberOfDaysToBillTelevision_Days.Location = New System.Drawing.Point(5, 25)
            Me.LabelNumberOfDaysToBillTelevision_Days.Name = "LabelNumberOfDaysToBillTelevision_Days"
            Me.LabelNumberOfDaysToBillTelevision_Days.Size = New System.Drawing.Size(35, 20)
            Me.LabelNumberOfDaysToBillTelevision_Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNumberOfDaysToBillTelevision_Days.TabIndex = 0
            Me.LabelNumberOfDaysToBillTelevision_Days.Text = "Days:"
            '
            'PanelBroadcastMedia_LeftColumn
            '
            Me.PanelBroadcastMedia_LeftColumn.Controls.Add(Me.GroupBoxLeftColumn_Radio)
            Me.PanelBroadcastMedia_LeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelBroadcastMedia_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelBroadcastMedia_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelBroadcastMedia_LeftColumn.Name = "PanelBroadcastMedia_LeftColumn"
            Me.PanelBroadcastMedia_LeftColumn.Size = New System.Drawing.Size(301, 438)
            Me.PanelBroadcastMedia_LeftColumn.TabIndex = 0
            '
            'GroupBoxLeftColumn_Radio
            '
            Me.GroupBoxLeftColumn_Radio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxLeftColumn_Radio.Controls.Add(Me.NumericInputRadio_Rebate)
            Me.GroupBoxLeftColumn_Radio.Controls.Add(Me.NumericInputRadio_Markup)
            Me.GroupBoxLeftColumn_Radio.Controls.Add(Me.ComboBoxRadio_TaxCode)
            Me.GroupBoxLeftColumn_Radio.Controls.Add(Me.CheckBoxRadio_BillingSetupComplete)
            Me.GroupBoxLeftColumn_Radio.Controls.Add(Me.CheckBoxRadio_VendorDiscounts)
            Me.GroupBoxLeftColumn_Radio.Controls.Add(Me.LabelRadio_TaxCode)
            Me.GroupBoxLeftColumn_Radio.Controls.Add(Me.GroupBoxRadio_ApplySalesTaxTo)
            Me.GroupBoxLeftColumn_Radio.Controls.Add(Me.RadioButtonControlRadio_PostBill)
            Me.GroupBoxLeftColumn_Radio.Controls.Add(Me.CheckBoxRadio_CommissionOnly)
            Me.GroupBoxLeftColumn_Radio.Controls.Add(Me.RadioButtonControlRadio_Prebill)
            Me.GroupBoxLeftColumn_Radio.Controls.Add(Me.CheckBoxRadio_BillNet)
            Me.GroupBoxLeftColumn_Radio.Controls.Add(Me.LabelRadio_RebatePercent)
            Me.GroupBoxLeftColumn_Radio.Controls.Add(Me.LabelRadio_MarkupPercent)
            Me.GroupBoxLeftColumn_Radio.Controls.Add(Me.LabelRadio_StationPricesGross)
            Me.GroupBoxLeftColumn_Radio.Controls.Add(Me.LabelRadio_StationPricesNet)
            Me.GroupBoxLeftColumn_Radio.Controls.Add(Me.GroupBoxRadio_NumberOfDaysToBill)
            Me.GroupBoxLeftColumn_Radio.Location = New System.Drawing.Point(6, 6)
            Me.GroupBoxLeftColumn_Radio.Name = "GroupBoxLeftColumn_Radio"
            Me.GroupBoxLeftColumn_Radio.Size = New System.Drawing.Size(292, 424)
            Me.GroupBoxLeftColumn_Radio.TabIndex = 0
            Me.GroupBoxLeftColumn_Radio.Text = "Radio"
            '
            'NumericInputRadio_Rebate
            '
            Me.NumericInputRadio_Rebate.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRadio_Rebate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputRadio_Rebate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRadio_Rebate.EnterMoveNextControl = True
            Me.NumericInputRadio_Rebate.Location = New System.Drawing.Point(74, 103)
            Me.NumericInputRadio_Rebate.Name = "NumericInputRadio_Rebate"
            Me.NumericInputRadio_Rebate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputRadio_Rebate.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputRadio_Rebate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputRadio_Rebate.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputRadio_Rebate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRadio_Rebate.Properties.EditFormat.FormatString = "f"
            Me.NumericInputRadio_Rebate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRadio_Rebate.Properties.Mask.EditMask = "f"
            Me.NumericInputRadio_Rebate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRadio_Rebate.SecurityEnabled = True
            Me.NumericInputRadio_Rebate.Size = New System.Drawing.Size(73, 20)
            Me.NumericInputRadio_Rebate.TabIndex = 6
            '
            'NumericInputRadio_Markup
            '
            Me.NumericInputRadio_Markup.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRadio_Markup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputRadio_Markup.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRadio_Markup.EnterMoveNextControl = True
            Me.NumericInputRadio_Markup.Location = New System.Drawing.Point(74, 51)
            Me.NumericInputRadio_Markup.Name = "NumericInputRadio_Markup"
            Me.NumericInputRadio_Markup.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputRadio_Markup.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputRadio_Markup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputRadio_Markup.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputRadio_Markup.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRadio_Markup.Properties.EditFormat.FormatString = "f"
            Me.NumericInputRadio_Markup.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRadio_Markup.Properties.Mask.EditMask = "f"
            Me.NumericInputRadio_Markup.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRadio_Markup.SecurityEnabled = True
            Me.NumericInputRadio_Markup.Size = New System.Drawing.Size(73, 20)
            Me.NumericInputRadio_Markup.TabIndex = 3
            '
            'ComboBoxRadio_TaxCode
            '
            Me.ComboBoxRadio_TaxCode.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxRadio_TaxCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxRadio_TaxCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxRadio_TaxCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxRadio_TaxCode.AutoFindItemInDataSource = False
            Me.ComboBoxRadio_TaxCode.AutoSelectSingleItemDatasource = False
            Me.ComboBoxRadio_TaxCode.BookmarkingEnabled = False
            Me.ComboBoxRadio_TaxCode.ClientCode = ""
            Me.ComboBoxRadio_TaxCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.TaxCode
            Me.ComboBoxRadio_TaxCode.DisableMouseWheel = False
            Me.ComboBoxRadio_TaxCode.DisplayMember = "Name"
            Me.ComboBoxRadio_TaxCode.DisplayName = ""
            Me.ComboBoxRadio_TaxCode.DivisionCode = ""
            Me.ComboBoxRadio_TaxCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxRadio_TaxCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxRadio_TaxCode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxRadio_TaxCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxRadio_TaxCode.FocusHighlightEnabled = True
            Me.ComboBoxRadio_TaxCode.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxRadio_TaxCode.FormattingEnabled = True
            Me.ComboBoxRadio_TaxCode.ItemHeight = 16
            Me.ComboBoxRadio_TaxCode.Location = New System.Drawing.Point(75, 264)
            Me.ComboBoxRadio_TaxCode.Name = "ComboBoxRadio_TaxCode"
            Me.ComboBoxRadio_TaxCode.ReadOnly = False
            Me.ComboBoxRadio_TaxCode.SecurityEnabled = True
            Me.ComboBoxRadio_TaxCode.Size = New System.Drawing.Size(212, 22)
            Me.ComboBoxRadio_TaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxRadio_TaxCode.TabIndex = 15
            Me.ComboBoxRadio_TaxCode.TabOnEnter = True
            Me.ComboBoxRadio_TaxCode.ValueMember = "ID"
            Me.ComboBoxRadio_TaxCode.WatermarkText = "Select Tax Code"
            '
            'CheckBoxRadio_BillingSetupComplete
            '
            Me.CheckBoxRadio_BillingSetupComplete.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxRadio_BillingSetupComplete.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRadio_BillingSetupComplete.CheckValue = 0
            Me.CheckBoxRadio_BillingSetupComplete.CheckValueChecked = 1
            Me.CheckBoxRadio_BillingSetupComplete.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxRadio_BillingSetupComplete.CheckValueUnchecked = 0
            Me.CheckBoxRadio_BillingSetupComplete.ChildControls = CType(resources.GetObject("CheckBoxRadio_BillingSetupComplete.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRadio_BillingSetupComplete.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRadio_BillingSetupComplete.Location = New System.Drawing.Point(149, 238)
            Me.CheckBoxRadio_BillingSetupComplete.Name = "CheckBoxRadio_BillingSetupComplete"
            Me.CheckBoxRadio_BillingSetupComplete.OldestSibling = Nothing
            Me.CheckBoxRadio_BillingSetupComplete.SecurityEnabled = True
            Me.CheckBoxRadio_BillingSetupComplete.SiblingControls = CType(resources.GetObject("CheckBoxRadio_BillingSetupComplete.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRadio_BillingSetupComplete.Size = New System.Drawing.Size(138, 20)
            Me.CheckBoxRadio_BillingSetupComplete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRadio_BillingSetupComplete.TabIndex = 13
            Me.CheckBoxRadio_BillingSetupComplete.TabOnEnter = True
            Me.CheckBoxRadio_BillingSetupComplete.Text = "Billing Setup Complete"
            '
            'CheckBoxRadio_VendorDiscounts
            '
            '
            '
            '
            Me.CheckBoxRadio_VendorDiscounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRadio_VendorDiscounts.CheckValue = 0
            Me.CheckBoxRadio_VendorDiscounts.CheckValueChecked = 1
            Me.CheckBoxRadio_VendorDiscounts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxRadio_VendorDiscounts.CheckValueUnchecked = 0
            Me.CheckBoxRadio_VendorDiscounts.ChildControls = CType(resources.GetObject("CheckBoxRadio_VendorDiscounts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRadio_VendorDiscounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRadio_VendorDiscounts.Location = New System.Drawing.Point(5, 238)
            Me.CheckBoxRadio_VendorDiscounts.Name = "CheckBoxRadio_VendorDiscounts"
            Me.CheckBoxRadio_VendorDiscounts.OldestSibling = Nothing
            Me.CheckBoxRadio_VendorDiscounts.SecurityEnabled = True
            Me.CheckBoxRadio_VendorDiscounts.SiblingControls = CType(resources.GetObject("CheckBoxRadio_VendorDiscounts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRadio_VendorDiscounts.Size = New System.Drawing.Size(137, 20)
            Me.CheckBoxRadio_VendorDiscounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRadio_VendorDiscounts.TabIndex = 12
            Me.CheckBoxRadio_VendorDiscounts.TabOnEnter = True
            Me.CheckBoxRadio_VendorDiscounts.Text = "Vendor Discounts"
            '
            'LabelRadio_TaxCode
            '
            Me.LabelRadio_TaxCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRadio_TaxCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRadio_TaxCode.Location = New System.Drawing.Point(5, 264)
            Me.LabelRadio_TaxCode.Name = "LabelRadio_TaxCode"
            Me.LabelRadio_TaxCode.Size = New System.Drawing.Size(63, 20)
            Me.LabelRadio_TaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRadio_TaxCode.TabIndex = 14
            Me.LabelRadio_TaxCode.Text = "Tax Code:"
            '
            'GroupBoxRadio_ApplySalesTaxTo
            '
            Me.GroupBoxRadio_ApplySalesTaxTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxRadio_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToRadio_NetDiscount)
            Me.GroupBoxRadio_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToRadio_Rebate)
            Me.GroupBoxRadio_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToRadio_Commission)
            Me.GroupBoxRadio_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToRadio_AddlCharge)
            Me.GroupBoxRadio_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToRadio_NetCharge)
            Me.GroupBoxRadio_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToRadio_LineNet)
            Me.GroupBoxRadio_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToRadio_UseFlags)
            Me.GroupBoxRadio_ApplySalesTaxTo.Location = New System.Drawing.Point(5, 290)
            Me.GroupBoxRadio_ApplySalesTaxTo.Name = "GroupBoxRadio_ApplySalesTaxTo"
            Me.GroupBoxRadio_ApplySalesTaxTo.Size = New System.Drawing.Size(282, 129)
            Me.GroupBoxRadio_ApplySalesTaxTo.TabIndex = 16
            Me.GroupBoxRadio_ApplySalesTaxTo.Text = "Apply Sales Tax To"
            '
            'CheckBoxApplySalesTaxToRadio_NetDiscount
            '
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.CheckValue = 0
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToRadio_NetDiscount.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.Location = New System.Drawing.Point(158, 103)
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.Name = "CheckBoxApplySalesTaxToRadio_NetDiscount"
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToRadio_NetDiscount.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.Size = New System.Drawing.Size(96, 20)
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.TabIndex = 6
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToRadio_NetDiscount.Text = "Net Discount"
            '
            'CheckBoxApplySalesTaxToRadio_Rebate
            '
            Me.CheckBoxApplySalesTaxToRadio_Rebate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToRadio_Rebate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToRadio_Rebate.CheckValue = 0
            Me.CheckBoxApplySalesTaxToRadio_Rebate.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToRadio_Rebate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToRadio_Rebate.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToRadio_Rebate.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToRadio_Rebate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToRadio_Rebate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToRadio_Rebate.Location = New System.Drawing.Point(158, 77)
            Me.CheckBoxApplySalesTaxToRadio_Rebate.Name = "CheckBoxApplySalesTaxToRadio_Rebate"
            Me.CheckBoxApplySalesTaxToRadio_Rebate.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToRadio_Rebate.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToRadio_Rebate.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToRadio_Rebate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToRadio_Rebate.Size = New System.Drawing.Size(96, 20)
            Me.CheckBoxApplySalesTaxToRadio_Rebate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToRadio_Rebate.TabIndex = 5
            Me.CheckBoxApplySalesTaxToRadio_Rebate.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToRadio_Rebate.Text = "Rebate"
            '
            'CheckBoxApplySalesTaxToRadio_Commission
            '
            Me.CheckBoxApplySalesTaxToRadio_Commission.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToRadio_Commission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToRadio_Commission.CheckValue = 0
            Me.CheckBoxApplySalesTaxToRadio_Commission.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToRadio_Commission.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToRadio_Commission.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToRadio_Commission.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToRadio_Commission.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToRadio_Commission.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToRadio_Commission.Location = New System.Drawing.Point(158, 51)
            Me.CheckBoxApplySalesTaxToRadio_Commission.Name = "CheckBoxApplySalesTaxToRadio_Commission"
            Me.CheckBoxApplySalesTaxToRadio_Commission.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToRadio_Commission.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToRadio_Commission.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToRadio_Commission.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToRadio_Commission.Size = New System.Drawing.Size(96, 20)
            Me.CheckBoxApplySalesTaxToRadio_Commission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToRadio_Commission.TabIndex = 4
            Me.CheckBoxApplySalesTaxToRadio_Commission.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToRadio_Commission.Text = "Commission"
            '
            'CheckBoxApplySalesTaxToRadio_AddlCharge
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.CheckValue = 0
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToRadio_AddlCharge.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.Location = New System.Drawing.Point(24, 103)
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.Name = "CheckBoxApplySalesTaxToRadio_AddlCharge"
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToRadio_AddlCharge.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.TabIndex = 3
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToRadio_AddlCharge.Text = "Addl Charge"
            '
            'CheckBoxApplySalesTaxToRadio_NetCharge
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.CheckValue = 0
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToRadio_NetCharge.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.Location = New System.Drawing.Point(24, 77)
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.Name = "CheckBoxApplySalesTaxToRadio_NetCharge"
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToRadio_NetCharge.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.TabIndex = 2
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToRadio_NetCharge.Text = "Net Charge"
            '
            'CheckBoxApplySalesTaxToRadio_LineNet
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToRadio_LineNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToRadio_LineNet.CheckValue = 0
            Me.CheckBoxApplySalesTaxToRadio_LineNet.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToRadio_LineNet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToRadio_LineNet.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToRadio_LineNet.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToRadio_LineNet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToRadio_LineNet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToRadio_LineNet.Location = New System.Drawing.Point(24, 51)
            Me.CheckBoxApplySalesTaxToRadio_LineNet.Name = "CheckBoxApplySalesTaxToRadio_LineNet"
            Me.CheckBoxApplySalesTaxToRadio_LineNet.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToRadio_LineNet.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToRadio_LineNet.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToRadio_LineNet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToRadio_LineNet.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToRadio_LineNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToRadio_LineNet.TabIndex = 1
            Me.CheckBoxApplySalesTaxToRadio_LineNet.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToRadio_LineNet.Text = "Line Net"
            '
            'CheckBoxApplySalesTaxToRadio_UseFlags
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.CheckValue = 0
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToRadio_UseFlags.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.Name = "CheckBoxApplySalesTaxToRadio_UseFlags"
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToRadio_UseFlags.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.TabIndex = 0
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToRadio_UseFlags.Text = "Use Flags"
            '
            'RadioButtonControlRadio_PostBill
            '
            Me.RadioButtonControlRadio_PostBill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlRadio_PostBill.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlRadio_PostBill.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlRadio_PostBill.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlRadio_PostBill.Location = New System.Drawing.Point(164, 51)
            Me.RadioButtonControlRadio_PostBill.Name = "RadioButtonControlRadio_PostBill"
            Me.RadioButtonControlRadio_PostBill.SecurityEnabled = True
            Me.RadioButtonControlRadio_PostBill.Size = New System.Drawing.Size(123, 20)
            Me.RadioButtonControlRadio_PostBill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlRadio_PostBill.TabIndex = 8
            Me.RadioButtonControlRadio_PostBill.TabOnEnter = True
            Me.RadioButtonControlRadio_PostBill.TabStop = False
            Me.RadioButtonControlRadio_PostBill.Text = "Post Bill"
            '
            'CheckBoxRadio_CommissionOnly
            '
            Me.CheckBoxRadio_CommissionOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxRadio_CommissionOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRadio_CommissionOnly.CheckValue = 0
            Me.CheckBoxRadio_CommissionOnly.CheckValueChecked = 1
            Me.CheckBoxRadio_CommissionOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxRadio_CommissionOnly.CheckValueUnchecked = 0
            Me.CheckBoxRadio_CommissionOnly.ChildControls = CType(resources.GetObject("CheckBoxRadio_CommissionOnly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRadio_CommissionOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRadio_CommissionOnly.Location = New System.Drawing.Point(164, 103)
            Me.CheckBoxRadio_CommissionOnly.Name = "CheckBoxRadio_CommissionOnly"
            Me.CheckBoxRadio_CommissionOnly.OldestSibling = Nothing
            Me.CheckBoxRadio_CommissionOnly.SecurityEnabled = True
            Me.CheckBoxRadio_CommissionOnly.SiblingControls = CType(resources.GetObject("CheckBoxRadio_CommissionOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRadio_CommissionOnly.Size = New System.Drawing.Size(123, 20)
            Me.CheckBoxRadio_CommissionOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRadio_CommissionOnly.TabIndex = 10
            Me.CheckBoxRadio_CommissionOnly.TabOnEnter = True
            Me.CheckBoxRadio_CommissionOnly.Text = "Commission Only"
            '
            'RadioButtonControlRadio_Prebill
            '
            Me.RadioButtonControlRadio_Prebill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlRadio_Prebill.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlRadio_Prebill.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlRadio_Prebill.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlRadio_Prebill.Checked = True
            Me.RadioButtonControlRadio_Prebill.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlRadio_Prebill.CheckValue = "Y"
            Me.RadioButtonControlRadio_Prebill.Location = New System.Drawing.Point(164, 25)
            Me.RadioButtonControlRadio_Prebill.Name = "RadioButtonControlRadio_Prebill"
            Me.RadioButtonControlRadio_Prebill.SecurityEnabled = True
            Me.RadioButtonControlRadio_Prebill.Size = New System.Drawing.Size(123, 20)
            Me.RadioButtonControlRadio_Prebill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlRadio_Prebill.TabIndex = 7
            Me.RadioButtonControlRadio_Prebill.TabOnEnter = True
            Me.RadioButtonControlRadio_Prebill.Text = "Prebill"
            '
            'CheckBoxRadio_BillNet
            '
            Me.CheckBoxRadio_BillNet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxRadio_BillNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxRadio_BillNet.CheckValue = 0
            Me.CheckBoxRadio_BillNet.CheckValueChecked = 1
            Me.CheckBoxRadio_BillNet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxRadio_BillNet.CheckValueUnchecked = 0
            Me.CheckBoxRadio_BillNet.ChildControls = CType(resources.GetObject("CheckBoxRadio_BillNet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRadio_BillNet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxRadio_BillNet.Location = New System.Drawing.Point(164, 77)
            Me.CheckBoxRadio_BillNet.Name = "CheckBoxRadio_BillNet"
            Me.CheckBoxRadio_BillNet.OldestSibling = Nothing
            Me.CheckBoxRadio_BillNet.SecurityEnabled = True
            Me.CheckBoxRadio_BillNet.SiblingControls = CType(resources.GetObject("CheckBoxRadio_BillNet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRadio_BillNet.Size = New System.Drawing.Size(123, 20)
            Me.CheckBoxRadio_BillNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRadio_BillNet.TabIndex = 9
            Me.CheckBoxRadio_BillNet.TabOnEnter = True
            Me.CheckBoxRadio_BillNet.Text = "Bill Net"
            '
            'LabelRadio_RebatePercent
            '
            Me.LabelRadio_RebatePercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRadio_RebatePercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRadio_RebatePercent.Location = New System.Drawing.Point(5, 103)
            Me.LabelRadio_RebatePercent.Name = "LabelRadio_RebatePercent"
            Me.LabelRadio_RebatePercent.Size = New System.Drawing.Size(63, 20)
            Me.LabelRadio_RebatePercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRadio_RebatePercent.TabIndex = 5
            Me.LabelRadio_RebatePercent.Text = "Rebate %:"
            '
            'LabelRadio_MarkupPercent
            '
            Me.LabelRadio_MarkupPercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRadio_MarkupPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRadio_MarkupPercent.Location = New System.Drawing.Point(5, 51)
            Me.LabelRadio_MarkupPercent.Name = "LabelRadio_MarkupPercent"
            Me.LabelRadio_MarkupPercent.Size = New System.Drawing.Size(63, 20)
            Me.LabelRadio_MarkupPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRadio_MarkupPercent.TabIndex = 2
            Me.LabelRadio_MarkupPercent.Text = "Markup %:"
            '
            'LabelRadio_StationPricesGross
            '
            Me.LabelRadio_StationPricesGross.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRadio_StationPricesGross.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRadio_StationPricesGross.Location = New System.Drawing.Point(5, 77)
            Me.LabelRadio_StationPricesGross.Name = "LabelRadio_StationPricesGross"
            Me.LabelRadio_StationPricesGross.Size = New System.Drawing.Size(142, 20)
            Me.LabelRadio_StationPricesGross.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRadio_StationPricesGross.TabIndex = 4
            Me.LabelRadio_StationPricesGross.Text = "If Station Prices are Gross:"
            '
            'LabelRadio_StationPricesNet
            '
            Me.LabelRadio_StationPricesNet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRadio_StationPricesNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRadio_StationPricesNet.Location = New System.Drawing.Point(5, 25)
            Me.LabelRadio_StationPricesNet.Name = "LabelRadio_StationPricesNet"
            Me.LabelRadio_StationPricesNet.Size = New System.Drawing.Size(142, 20)
            Me.LabelRadio_StationPricesNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRadio_StationPricesNet.TabIndex = 1
            Me.LabelRadio_StationPricesNet.Text = "If Station Prices are Net:"
            '
            'GroupBoxRadio_NumberOfDaysToBill
            '
            Me.GroupBoxRadio_NumberOfDaysToBill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxRadio_NumberOfDaysToBill.Controls.Add(Me.NumericInputNumberOfDaysToBillRadio_Days)
            Me.GroupBoxRadio_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate)
            Me.GroupBoxRadio_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate)
            Me.GroupBoxRadio_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate)
            Me.GroupBoxRadio_NumberOfDaysToBill.Controls.Add(Me.LabelNumberOfDaysToBillRadio_Days)
            Me.GroupBoxRadio_NumberOfDaysToBill.Location = New System.Drawing.Point(5, 129)
            Me.GroupBoxRadio_NumberOfDaysToBill.Name = "GroupBoxRadio_NumberOfDaysToBill"
            Me.GroupBoxRadio_NumberOfDaysToBill.Size = New System.Drawing.Size(282, 103)
            Me.GroupBoxRadio_NumberOfDaysToBill.TabIndex = 11
            Me.GroupBoxRadio_NumberOfDaysToBill.Text = "# of Days to Bill"
            '
            'NumericInputNumberOfDaysToBillRadio_Days
            '
            Me.NumericInputNumberOfDaysToBillRadio_Days.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputNumberOfDaysToBillRadio_Days.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputNumberOfDaysToBillRadio_Days.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputNumberOfDaysToBillRadio_Days.EnterMoveNextControl = True
            Me.NumericInputNumberOfDaysToBillRadio_Days.Location = New System.Drawing.Point(46, 25)
            Me.NumericInputNumberOfDaysToBillRadio_Days.Name = "NumericInputNumberOfDaysToBillRadio_Days"
            Me.NumericInputNumberOfDaysToBillRadio_Days.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputNumberOfDaysToBillRadio_Days.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputNumberOfDaysToBillRadio_Days.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputNumberOfDaysToBillRadio_Days.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputNumberOfDaysToBillRadio_Days.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNumberOfDaysToBillRadio_Days.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputNumberOfDaysToBillRadio_Days.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNumberOfDaysToBillRadio_Days.Properties.IsFloatValue = False
            Me.NumericInputNumberOfDaysToBillRadio_Days.Properties.Mask.EditMask = "f0"
            Me.NumericInputNumberOfDaysToBillRadio_Days.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputNumberOfDaysToBillRadio_Days.Properties.MaxLength = 11
            Me.NumericInputNumberOfDaysToBillRadio_Days.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputNumberOfDaysToBillRadio_Days.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputNumberOfDaysToBillRadio_Days.SecurityEnabled = True
            Me.NumericInputNumberOfDaysToBillRadio_Days.Size = New System.Drawing.Size(71, 20)
            Me.NumericInputNumberOfDaysToBillRadio_Days.TabIndex = 1
            '
            'RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate
            '
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate.Location = New System.Drawing.Point(139, 77)
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate.Name = "RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate"
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate.TabIndex = 4
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate.TabStop = False
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate.Text = "Before Close Date"
            '
            'RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate
            '
            Me.RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate.Location = New System.Drawing.Point(139, 51)
            Me.RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate.Name = "RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate"
            Me.RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate.TabIndex = 3
            Me.RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate.TabStop = False
            Me.RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate.Text = "After Broadcast Date"
            '
            'RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate
            '
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.Checked = True
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.CheckValue = "Y"
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.Location = New System.Drawing.Point(139, 25)
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.Name = "RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate"
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.TabIndex = 2
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate.Text = "Before Broadcast Date"
            '
            'LabelNumberOfDaysToBillRadio_Days
            '
            Me.LabelNumberOfDaysToBillRadio_Days.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNumberOfDaysToBillRadio_Days.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNumberOfDaysToBillRadio_Days.Location = New System.Drawing.Point(5, 25)
            Me.LabelNumberOfDaysToBillRadio_Days.Name = "LabelNumberOfDaysToBillRadio_Days"
            Me.LabelNumberOfDaysToBillRadio_Days.Size = New System.Drawing.Size(35, 20)
            Me.LabelNumberOfDaysToBillRadio_Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNumberOfDaysToBillRadio_Days.TabIndex = 0
            Me.LabelNumberOfDaysToBillRadio_Days.Text = "Days:"
            '
            'TabItemProductSetup_BroadcastMedia
            '
            Me.TabItemProductSetup_BroadcastMedia.AttachedControl = Me.TabControlPanelBroadcastMedia_BroadcastMedia
            Me.TabItemProductSetup_BroadcastMedia.Name = "TabItemProductSetup_BroadcastMedia"
            Me.TabItemProductSetup_BroadcastMedia.Text = "Broadcast Media"
            '
            'TabControlPanelProduction_Production
            '
            Me.TabControlPanelProduction_Production.Controls.Add(Me.CheckBoxProduction_AvalaraTaxExemptOverride)
            Me.TabControlPanelProduction_Production.Controls.Add(Me.NumericInputProduction_EmployeeTimeBillingRate)
            Me.TabControlPanelProduction_Production.Controls.Add(Me.GroupBoxProduction_ProductionEstimateFormat)
            Me.TabControlPanelProduction_Production.Controls.Add(Me.NumericInputProduction_DefaultMarkupPercent)
            Me.TabControlPanelProduction_Production.Controls.Add(Me.NumericInputProduction_ContingencyPercent)
            Me.TabControlPanelProduction_Production.Controls.Add(Me.LabelProduction_EmployeeTimeBillableMessage)
            Me.TabControlPanelProduction_Production.Controls.Add(Me.ComboBoxProduction_DefaultTaxCode)
            Me.TabControlPanelProduction_Production.Controls.Add(Me.CheckBoxProduction_UseEstimateBillingRate)
            Me.TabControlPanelProduction_Production.Controls.Add(Me.ComboBoxProduction_DefaultAlertGroup)
            Me.TabControlPanelProduction_Production.Controls.Add(Me.GroupBoxProduction_BillingOptions)
            Me.TabControlPanelProduction_Production.Controls.Add(Me.LabelProduction_DefaultAlertGroup)
            Me.TabControlPanelProduction_Production.Controls.Add(Me.LabelProduction_DefaultTaxCode)
            Me.TabControlPanelProduction_Production.Controls.Add(Me.LabelProduction_EmployeeTimeBillingRate)
            Me.TabControlPanelProduction_Production.Controls.Add(Me.LabelProduction_DefaultMarkupPercent)
            Me.TabControlPanelProduction_Production.Controls.Add(Me.LabelProduction_ContingencyPercent)
            Me.TabControlPanelProduction_Production.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProduction_Production.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProduction_Production.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProduction_Production.Name = "TabControlPanelProduction_Production"
            Me.TabControlPanelProduction_Production.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProduction_Production.Size = New System.Drawing.Size(602, 546)
            Me.TabControlPanelProduction_Production.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProduction_Production.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProduction_Production.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProduction_Production.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProduction_Production.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProduction_Production.Style.GradientAngle = 90
            Me.TabControlPanelProduction_Production.TabIndex = 1
            Me.TabControlPanelProduction_Production.TabItem = Me.TabItemProductSetup_Production
            '
            'CheckBoxProduction_AvalaraTaxExemptOverride
            '
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.CheckValue = 0
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.CheckValueChecked = 1
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.CheckValueUnchecked = 0
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.ChildControls = Nothing
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.Location = New System.Drawing.Point(154, 165)
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.Name = "CheckBoxProduction_AvalaraTaxExemptOverride"
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.OldestSibling = Nothing
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.SecurityEnabled = True
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.SiblingControls = Nothing
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.Size = New System.Drawing.Size(246, 20)
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.TabIndex = 31
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.TabOnEnter = True
            Me.CheckBoxProduction_AvalaraTaxExemptOverride.Text = "Avalara Tax Exempt Override"
            '
            'NumericInputProduction_EmployeeTimeBillingRate
            '
            Me.NumericInputProduction_EmployeeTimeBillingRate.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputProduction_EmployeeTimeBillingRate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputProduction_EmployeeTimeBillingRate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputProduction_EmployeeTimeBillingRate.Enabled = False
            Me.NumericInputProduction_EmployeeTimeBillingRate.EnterMoveNextControl = True
            Me.NumericInputProduction_EmployeeTimeBillingRate.Location = New System.Drawing.Point(154, 58)
            Me.NumericInputProduction_EmployeeTimeBillingRate.Name = "NumericInputProduction_EmployeeTimeBillingRate"
            Me.NumericInputProduction_EmployeeTimeBillingRate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputProduction_EmployeeTimeBillingRate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputProduction_EmployeeTimeBillingRate.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputProduction_EmployeeTimeBillingRate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputProduction_EmployeeTimeBillingRate.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputProduction_EmployeeTimeBillingRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputProduction_EmployeeTimeBillingRate.Properties.EditFormat.FormatString = "f"
            Me.NumericInputProduction_EmployeeTimeBillingRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputProduction_EmployeeTimeBillingRate.Properties.Mask.EditMask = "f"
            Me.NumericInputProduction_EmployeeTimeBillingRate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputProduction_EmployeeTimeBillingRate.SecurityEnabled = True
            Me.NumericInputProduction_EmployeeTimeBillingRate.Size = New System.Drawing.Size(109, 20)
            Me.NumericInputProduction_EmployeeTimeBillingRate.TabIndex = 5
            '
            'GroupBoxProduction_ProductionEstimateFormat
            '
            Me.GroupBoxProduction_ProductionEstimateFormat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxProduction_ProductionEstimateFormat.Controls.Add(Me.LabelProductionEstimateFormat_StandardFormat)
            Me.GroupBoxProduction_ProductionEstimateFormat.Controls.Add(Me.LabelProductionEstimateFormat_Type)
            Me.GroupBoxProduction_ProductionEstimateFormat.Controls.Add(Me.ComboBoxProductionEstimateFormat_Type)
            Me.GroupBoxProduction_ProductionEstimateFormat.Location = New System.Drawing.Point(7, 196)
            Me.GroupBoxProduction_ProductionEstimateFormat.Name = "GroupBoxProduction_ProductionEstimateFormat"
            Me.GroupBoxProduction_ProductionEstimateFormat.Size = New System.Drawing.Size(589, 51)
            Me.GroupBoxProduction_ProductionEstimateFormat.TabIndex = 21
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
            Me.LabelProductionEstimateFormat_StandardFormat.Size = New System.Drawing.Size(357, 20)
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
            'NumericInputProduction_DefaultMarkupPercent
            '
            Me.NumericInputProduction_DefaultMarkupPercent.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputProduction_DefaultMarkupPercent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputProduction_DefaultMarkupPercent.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputProduction_DefaultMarkupPercent.EnterMoveNextControl = True
            Me.NumericInputProduction_DefaultMarkupPercent.Location = New System.Drawing.Point(154, 32)
            Me.NumericInputProduction_DefaultMarkupPercent.Name = "NumericInputProduction_DefaultMarkupPercent"
            Me.NumericInputProduction_DefaultMarkupPercent.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputProduction_DefaultMarkupPercent.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputProduction_DefaultMarkupPercent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputProduction_DefaultMarkupPercent.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputProduction_DefaultMarkupPercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputProduction_DefaultMarkupPercent.Properties.EditFormat.FormatString = "f"
            Me.NumericInputProduction_DefaultMarkupPercent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputProduction_DefaultMarkupPercent.Properties.Mask.EditMask = "f"
            Me.NumericInputProduction_DefaultMarkupPercent.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputProduction_DefaultMarkupPercent.SecurityEnabled = True
            Me.NumericInputProduction_DefaultMarkupPercent.Size = New System.Drawing.Size(109, 20)
            Me.NumericInputProduction_DefaultMarkupPercent.TabIndex = 3
            '
            'NumericInputProduction_ContingencyPercent
            '
            Me.NumericInputProduction_ContingencyPercent.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputProduction_ContingencyPercent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputProduction_ContingencyPercent.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputProduction_ContingencyPercent.EnterMoveNextControl = True
            Me.NumericInputProduction_ContingencyPercent.Location = New System.Drawing.Point(154, 6)
            Me.NumericInputProduction_ContingencyPercent.Name = "NumericInputProduction_ContingencyPercent"
            Me.NumericInputProduction_ContingencyPercent.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputProduction_ContingencyPercent.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputProduction_ContingencyPercent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputProduction_ContingencyPercent.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputProduction_ContingencyPercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputProduction_ContingencyPercent.Properties.EditFormat.FormatString = "f"
            Me.NumericInputProduction_ContingencyPercent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputProduction_ContingencyPercent.Properties.Mask.EditMask = "f"
            Me.NumericInputProduction_ContingencyPercent.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputProduction_ContingencyPercent.SecurityEnabled = True
            Me.NumericInputProduction_ContingencyPercent.Size = New System.Drawing.Size(109, 20)
            Me.NumericInputProduction_ContingencyPercent.TabIndex = 1
            '
            'LabelProduction_EmployeeTimeBillableMessage
            '
            Me.LabelProduction_EmployeeTimeBillableMessage.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProduction_EmployeeTimeBillableMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProduction_EmployeeTimeBillableMessage.ForeColor = System.Drawing.Color.Red
            Me.LabelProduction_EmployeeTimeBillableMessage.Location = New System.Drawing.Point(269, 58)
            Me.LabelProduction_EmployeeTimeBillableMessage.Name = "LabelProduction_EmployeeTimeBillableMessage"
            Me.LabelProduction_EmployeeTimeBillableMessage.Size = New System.Drawing.Size(131, 20)
            Me.LabelProduction_EmployeeTimeBillableMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProduction_EmployeeTimeBillableMessage.TabIndex = 12
            Me.LabelProduction_EmployeeTimeBillableMessage.Text = "Employee Time Is Billable"
            Me.LabelProduction_EmployeeTimeBillableMessage.Visible = False
            '
            'ComboBoxProduction_DefaultTaxCode
            '
            Me.ComboBoxProduction_DefaultTaxCode.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxProduction_DefaultTaxCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxProduction_DefaultTaxCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxProduction_DefaultTaxCode.AutoFindItemInDataSource = False
            Me.ComboBoxProduction_DefaultTaxCode.AutoSelectSingleItemDatasource = False
            Me.ComboBoxProduction_DefaultTaxCode.BookmarkingEnabled = False
            Me.ComboBoxProduction_DefaultTaxCode.ClientCode = ""
            Me.ComboBoxProduction_DefaultTaxCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.TaxCode
            Me.ComboBoxProduction_DefaultTaxCode.DisableMouseWheel = False
            Me.ComboBoxProduction_DefaultTaxCode.DisplayMember = "Name"
            Me.ComboBoxProduction_DefaultTaxCode.DisplayName = ""
            Me.ComboBoxProduction_DefaultTaxCode.DivisionCode = ""
            Me.ComboBoxProduction_DefaultTaxCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxProduction_DefaultTaxCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxProduction_DefaultTaxCode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxProduction_DefaultTaxCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxProduction_DefaultTaxCode.FocusHighlightEnabled = True
            Me.ComboBoxProduction_DefaultTaxCode.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxProduction_DefaultTaxCode.FormattingEnabled = True
            Me.ComboBoxProduction_DefaultTaxCode.ItemHeight = 14
            Me.ComboBoxProduction_DefaultTaxCode.Location = New System.Drawing.Point(154, 110)
            Me.ComboBoxProduction_DefaultTaxCode.Name = "ComboBoxProduction_DefaultTaxCode"
            Me.ComboBoxProduction_DefaultTaxCode.ReadOnly = False
            Me.ComboBoxProduction_DefaultTaxCode.SecurityEnabled = True
            Me.ComboBoxProduction_DefaultTaxCode.Size = New System.Drawing.Size(246, 20)
            Me.ComboBoxProduction_DefaultTaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxProduction_DefaultTaxCode.TabIndex = 8
            Me.ComboBoxProduction_DefaultTaxCode.TabOnEnter = True
            Me.ComboBoxProduction_DefaultTaxCode.ValueMember = "ID"
            Me.ComboBoxProduction_DefaultTaxCode.WatermarkText = "Select Tax Code"
            '
            'CheckBoxProduction_UseEstimateBillingRate
            '
            Me.CheckBoxProduction_UseEstimateBillingRate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxProduction_UseEstimateBillingRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxProduction_UseEstimateBillingRate.CheckValue = 0
            Me.CheckBoxProduction_UseEstimateBillingRate.CheckValueChecked = 1
            Me.CheckBoxProduction_UseEstimateBillingRate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxProduction_UseEstimateBillingRate.CheckValueUnchecked = 0
            Me.CheckBoxProduction_UseEstimateBillingRate.ChildControls = CType(resources.GetObject("CheckBoxProduction_UseEstimateBillingRate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxProduction_UseEstimateBillingRate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxProduction_UseEstimateBillingRate.Location = New System.Drawing.Point(154, 84)
            Me.CheckBoxProduction_UseEstimateBillingRate.Name = "CheckBoxProduction_UseEstimateBillingRate"
            Me.CheckBoxProduction_UseEstimateBillingRate.OldestSibling = Nothing
            Me.CheckBoxProduction_UseEstimateBillingRate.SecurityEnabled = True
            Me.CheckBoxProduction_UseEstimateBillingRate.SiblingControls = CType(resources.GetObject("CheckBoxProduction_UseEstimateBillingRate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxProduction_UseEstimateBillingRate.Size = New System.Drawing.Size(246, 20)
            Me.CheckBoxProduction_UseEstimateBillingRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxProduction_UseEstimateBillingRate.TabIndex = 6
            Me.CheckBoxProduction_UseEstimateBillingRate.TabOnEnter = True
            Me.CheckBoxProduction_UseEstimateBillingRate.Text = "Use Estimate Billing Rate"
            '
            'ComboBoxProduction_DefaultAlertGroup
            '
            Me.ComboBoxProduction_DefaultAlertGroup.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxProduction_DefaultAlertGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxProduction_DefaultAlertGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxProduction_DefaultAlertGroup.AutoFindItemInDataSource = False
            Me.ComboBoxProduction_DefaultAlertGroup.AutoSelectSingleItemDatasource = False
            Me.ComboBoxProduction_DefaultAlertGroup.BookmarkingEnabled = False
            Me.ComboBoxProduction_DefaultAlertGroup.ClientCode = ""
            Me.ComboBoxProduction_DefaultAlertGroup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.AlertGroup
            Me.ComboBoxProduction_DefaultAlertGroup.DisableMouseWheel = False
            Me.ComboBoxProduction_DefaultAlertGroup.DisplayMember = "Description"
            Me.ComboBoxProduction_DefaultAlertGroup.DisplayName = ""
            Me.ComboBoxProduction_DefaultAlertGroup.DivisionCode = ""
            Me.ComboBoxProduction_DefaultAlertGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxProduction_DefaultAlertGroup.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxProduction_DefaultAlertGroup.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxProduction_DefaultAlertGroup.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxProduction_DefaultAlertGroup.FocusHighlightEnabled = True
            Me.ComboBoxProduction_DefaultAlertGroup.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxProduction_DefaultAlertGroup.FormattingEnabled = True
            Me.ComboBoxProduction_DefaultAlertGroup.ItemHeight = 14
            Me.ComboBoxProduction_DefaultAlertGroup.Location = New System.Drawing.Point(154, 136)
            Me.ComboBoxProduction_DefaultAlertGroup.Name = "ComboBoxProduction_DefaultAlertGroup"
            Me.ComboBoxProduction_DefaultAlertGroup.ReadOnly = False
            Me.ComboBoxProduction_DefaultAlertGroup.SecurityEnabled = True
            Me.ComboBoxProduction_DefaultAlertGroup.Size = New System.Drawing.Size(246, 20)
            Me.ComboBoxProduction_DefaultAlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxProduction_DefaultAlertGroup.TabIndex = 10
            Me.ComboBoxProduction_DefaultAlertGroup.TabOnEnter = True
            Me.ComboBoxProduction_DefaultAlertGroup.ValueMember = "Code"
            Me.ComboBoxProduction_DefaultAlertGroup.WatermarkText = "Select Alert Group"
            '
            'GroupBoxProduction_BillingOptions
            '
            Me.GroupBoxProduction_BillingOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxProduction_BillingOptions.Controls.Add(Me.NumericInputBillingOptions_EarlyPayDaysOverride)
            Me.GroupBoxProduction_BillingOptions.Controls.Add(Me.CheckBoxBillingOptions_BillingSetupComplete)
            Me.GroupBoxProduction_BillingOptions.Controls.Add(Me.LabelBillingOptions_EarlyPayDaysOverride)
            Me.GroupBoxProduction_BillingOptions.Controls.Add(Me.CheckBoxBillingOptions_ApprovedEstimateRequired)
            Me.GroupBoxProduction_BillingOptions.Controls.Add(Me.CheckBoxBillingOptions_AllowVendorDiscounts)
            Me.GroupBoxProduction_BillingOptions.Controls.Add(Me.CheckBoxBillingOptions_BillNet)
            Me.GroupBoxProduction_BillingOptions.Controls.Add(Me.CheckBoxBillingOptions_ConsolidateFunctions)
            Me.GroupBoxProduction_BillingOptions.Location = New System.Drawing.Point(406, 6)
            Me.GroupBoxProduction_BillingOptions.Name = "GroupBoxProduction_BillingOptions"
            Me.GroupBoxProduction_BillingOptions.Size = New System.Drawing.Size(189, 184)
            Me.GroupBoxProduction_BillingOptions.TabIndex = 11
            Me.GroupBoxProduction_BillingOptions.Text = "Billing Options"
            '
            'NumericInputBillingOptions_EarlyPayDaysOverride
            '
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.EnterMoveNextControl = True
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.Location = New System.Drawing.Point(136, 156)
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.Name = "NumericInputBillingOptions_EarlyPayDaysOverride"
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.Properties.IsFloatValue = False
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.Properties.Mask.EditMask = "f0"
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.SecurityEnabled = True
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.Size = New System.Drawing.Size(48, 20)
            Me.NumericInputBillingOptions_EarlyPayDaysOverride.TabIndex = 18
            '
            'CheckBoxBillingOptions_BillingSetupComplete
            '
            Me.CheckBoxBillingOptions_BillingSetupComplete.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxBillingOptions_BillingSetupComplete.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxBillingOptions_BillingSetupComplete.CheckValue = 0
            Me.CheckBoxBillingOptions_BillingSetupComplete.CheckValueChecked = 1
            Me.CheckBoxBillingOptions_BillingSetupComplete.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxBillingOptions_BillingSetupComplete.CheckValueUnchecked = 0
            Me.CheckBoxBillingOptions_BillingSetupComplete.ChildControls = CType(resources.GetObject("CheckBoxBillingOptions_BillingSetupComplete.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBillingOptions_BillingSetupComplete.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxBillingOptions_BillingSetupComplete.Location = New System.Drawing.Point(6, 130)
            Me.CheckBoxBillingOptions_BillingSetupComplete.Name = "CheckBoxBillingOptions_BillingSetupComplete"
            Me.CheckBoxBillingOptions_BillingSetupComplete.OldestSibling = Nothing
            Me.CheckBoxBillingOptions_BillingSetupComplete.SecurityEnabled = True
            Me.CheckBoxBillingOptions_BillingSetupComplete.SiblingControls = CType(resources.GetObject("CheckBoxBillingOptions_BillingSetupComplete.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBillingOptions_BillingSetupComplete.Size = New System.Drawing.Size(178, 20)
            Me.CheckBoxBillingOptions_BillingSetupComplete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxBillingOptions_BillingSetupComplete.TabIndex = 16
            Me.CheckBoxBillingOptions_BillingSetupComplete.TabOnEnter = True
            Me.CheckBoxBillingOptions_BillingSetupComplete.Text = "Billing Setup Complete"
            '
            'LabelBillingOptions_EarlyPayDaysOverride
            '
            Me.LabelBillingOptions_EarlyPayDaysOverride.BackColor = System.Drawing.SystemColors.Window
            '
            '
            '
            Me.LabelBillingOptions_EarlyPayDaysOverride.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelBillingOptions_EarlyPayDaysOverride.Location = New System.Drawing.Point(6, 156)
            Me.LabelBillingOptions_EarlyPayDaysOverride.Name = "LabelBillingOptions_EarlyPayDaysOverride"
            Me.LabelBillingOptions_EarlyPayDaysOverride.Size = New System.Drawing.Size(128, 20)
            Me.LabelBillingOptions_EarlyPayDaysOverride.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelBillingOptions_EarlyPayDaysOverride.TabIndex = 17
            Me.LabelBillingOptions_EarlyPayDaysOverride.Text = "Early Pay Days Override:"
            '
            'CheckBoxBillingOptions_ApprovedEstimateRequired
            '
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.CheckValue = 0
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.CheckValueChecked = 1
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.CheckValueUnchecked = 0
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.ChildControls = CType(resources.GetObject("CheckBoxBillingOptions_ApprovedEstimateRequired.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.Location = New System.Drawing.Point(6, 104)
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.Name = "CheckBoxBillingOptions_ApprovedEstimateRequired"
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.OldestSibling = Nothing
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.SecurityEnabled = True
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.SiblingControls = CType(resources.GetObject("CheckBoxBillingOptions_ApprovedEstimateRequired.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.Size = New System.Drawing.Size(178, 20)
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.TabIndex = 15
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.TabOnEnter = True
            Me.CheckBoxBillingOptions_ApprovedEstimateRequired.Text = "Approved Estimate Required"
            '
            'CheckBoxBillingOptions_AllowVendorDiscounts
            '
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.CheckValue = 0
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.CheckValueChecked = 1
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.CheckValueUnchecked = 0
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.ChildControls = CType(resources.GetObject("CheckBoxBillingOptions_AllowVendorDiscounts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.Location = New System.Drawing.Point(6, 78)
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.Name = "CheckBoxBillingOptions_AllowVendorDiscounts"
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.OldestSibling = Nothing
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.SecurityEnabled = True
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.SiblingControls = CType(resources.GetObject("CheckBoxBillingOptions_AllowVendorDiscounts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.Size = New System.Drawing.Size(178, 20)
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.TabIndex = 14
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.TabOnEnter = True
            Me.CheckBoxBillingOptions_AllowVendorDiscounts.Text = "Allow Vendor Discounts"
            '
            'CheckBoxBillingOptions_BillNet
            '
            Me.CheckBoxBillingOptions_BillNet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxBillingOptions_BillNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxBillingOptions_BillNet.CheckValue = 0
            Me.CheckBoxBillingOptions_BillNet.CheckValueChecked = 1
            Me.CheckBoxBillingOptions_BillNet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxBillingOptions_BillNet.CheckValueUnchecked = 0
            Me.CheckBoxBillingOptions_BillNet.ChildControls = CType(resources.GetObject("CheckBoxBillingOptions_BillNet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBillingOptions_BillNet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxBillingOptions_BillNet.Location = New System.Drawing.Point(6, 52)
            Me.CheckBoxBillingOptions_BillNet.Name = "CheckBoxBillingOptions_BillNet"
            Me.CheckBoxBillingOptions_BillNet.OldestSibling = Nothing
            Me.CheckBoxBillingOptions_BillNet.SecurityEnabled = True
            Me.CheckBoxBillingOptions_BillNet.SiblingControls = CType(resources.GetObject("CheckBoxBillingOptions_BillNet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBillingOptions_BillNet.Size = New System.Drawing.Size(178, 20)
            Me.CheckBoxBillingOptions_BillNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxBillingOptions_BillNet.TabIndex = 13
            Me.CheckBoxBillingOptions_BillNet.TabOnEnter = True
            Me.CheckBoxBillingOptions_BillNet.Text = "Bill Net"
            '
            'CheckBoxBillingOptions_ConsolidateFunctions
            '
            Me.CheckBoxBillingOptions_ConsolidateFunctions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxBillingOptions_ConsolidateFunctions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxBillingOptions_ConsolidateFunctions.CheckValue = 0
            Me.CheckBoxBillingOptions_ConsolidateFunctions.CheckValueChecked = 1
            Me.CheckBoxBillingOptions_ConsolidateFunctions.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxBillingOptions_ConsolidateFunctions.CheckValueUnchecked = 0
            Me.CheckBoxBillingOptions_ConsolidateFunctions.ChildControls = CType(resources.GetObject("CheckBoxBillingOptions_ConsolidateFunctions.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBillingOptions_ConsolidateFunctions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxBillingOptions_ConsolidateFunctions.Location = New System.Drawing.Point(6, 26)
            Me.CheckBoxBillingOptions_ConsolidateFunctions.Name = "CheckBoxBillingOptions_ConsolidateFunctions"
            Me.CheckBoxBillingOptions_ConsolidateFunctions.OldestSibling = Nothing
            Me.CheckBoxBillingOptions_ConsolidateFunctions.SecurityEnabled = True
            Me.CheckBoxBillingOptions_ConsolidateFunctions.SiblingControls = CType(resources.GetObject("CheckBoxBillingOptions_ConsolidateFunctions.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBillingOptions_ConsolidateFunctions.Size = New System.Drawing.Size(178, 20)
            Me.CheckBoxBillingOptions_ConsolidateFunctions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxBillingOptions_ConsolidateFunctions.TabIndex = 12
            Me.CheckBoxBillingOptions_ConsolidateFunctions.TabOnEnter = True
            Me.CheckBoxBillingOptions_ConsolidateFunctions.Text = "Consolidate Functions"
            '
            'LabelProduction_DefaultAlertGroup
            '
            Me.LabelProduction_DefaultAlertGroup.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProduction_DefaultAlertGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProduction_DefaultAlertGroup.Location = New System.Drawing.Point(7, 136)
            Me.LabelProduction_DefaultAlertGroup.Name = "LabelProduction_DefaultAlertGroup"
            Me.LabelProduction_DefaultAlertGroup.Size = New System.Drawing.Size(141, 20)
            Me.LabelProduction_DefaultAlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProduction_DefaultAlertGroup.TabIndex = 9
            Me.LabelProduction_DefaultAlertGroup.Text = "Default Alert Group: "
            '
            'LabelProduction_DefaultTaxCode
            '
            Me.LabelProduction_DefaultTaxCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProduction_DefaultTaxCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProduction_DefaultTaxCode.Location = New System.Drawing.Point(7, 110)
            Me.LabelProduction_DefaultTaxCode.Name = "LabelProduction_DefaultTaxCode"
            Me.LabelProduction_DefaultTaxCode.Size = New System.Drawing.Size(141, 20)
            Me.LabelProduction_DefaultTaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProduction_DefaultTaxCode.TabIndex = 7
            Me.LabelProduction_DefaultTaxCode.Text = "Default Tax Code: "
            '
            'LabelProduction_EmployeeTimeBillingRate
            '
            Me.LabelProduction_EmployeeTimeBillingRate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProduction_EmployeeTimeBillingRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProduction_EmployeeTimeBillingRate.Location = New System.Drawing.Point(6, 58)
            Me.LabelProduction_EmployeeTimeBillingRate.Name = "LabelProduction_EmployeeTimeBillingRate"
            Me.LabelProduction_EmployeeTimeBillingRate.Size = New System.Drawing.Size(142, 20)
            Me.LabelProduction_EmployeeTimeBillingRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProduction_EmployeeTimeBillingRate.TabIndex = 4
            Me.LabelProduction_EmployeeTimeBillingRate.Text = "Employee Time Billing Rate:"
            '
            'LabelProduction_DefaultMarkupPercent
            '
            Me.LabelProduction_DefaultMarkupPercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProduction_DefaultMarkupPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProduction_DefaultMarkupPercent.Location = New System.Drawing.Point(6, 32)
            Me.LabelProduction_DefaultMarkupPercent.Name = "LabelProduction_DefaultMarkupPercent"
            Me.LabelProduction_DefaultMarkupPercent.Size = New System.Drawing.Size(142, 20)
            Me.LabelProduction_DefaultMarkupPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProduction_DefaultMarkupPercent.TabIndex = 2
            Me.LabelProduction_DefaultMarkupPercent.Text = "Default Markup %: "
            '
            'LabelProduction_ContingencyPercent
            '
            Me.LabelProduction_ContingencyPercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProduction_ContingencyPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProduction_ContingencyPercent.Location = New System.Drawing.Point(6, 6)
            Me.LabelProduction_ContingencyPercent.Name = "LabelProduction_ContingencyPercent"
            Me.LabelProduction_ContingencyPercent.Size = New System.Drawing.Size(142, 20)
            Me.LabelProduction_ContingencyPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProduction_ContingencyPercent.TabIndex = 0
            Me.LabelProduction_ContingencyPercent.Text = "Contingency %: "
            '
            'TabItemProductSetup_Production
            '
            Me.TabItemProductSetup_Production.AttachedControl = Me.TabControlPanelProduction_Production
            Me.TabItemProductSetup_Production.Name = "TabItemProductSetup_Production"
            Me.TabItemProductSetup_Production.Text = "Production"
            '
            'TabControlPanelCompanyProfileTab_CompanyProfile
            '
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.Controls.Add(Me.CompanyProfileControlCompanyProfile_CompanyProfile)
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.Name = "TabControlPanelCompanyProfileTab_CompanyProfile"
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.Size = New System.Drawing.Size(602, 546)
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.Style.GradientAngle = 90
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.TabIndex = 8
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.TabItem = Me.TabItemProductSetup_CompanyProfileTab
            '
            'CompanyProfileControlCompanyProfile_CompanyProfile
            '
            Me.CompanyProfileControlCompanyProfile_CompanyProfile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CompanyProfileControlCompanyProfile_CompanyProfile.BackColor = System.Drawing.Color.White
            Me.CompanyProfileControlCompanyProfile_CompanyProfile.Location = New System.Drawing.Point(6, 4)
            Me.CompanyProfileControlCompanyProfile_CompanyProfile.Margin = New System.Windows.Forms.Padding(4)
            Me.CompanyProfileControlCompanyProfile_CompanyProfile.Name = "CompanyProfileControlCompanyProfile_CompanyProfile"
            Me.CompanyProfileControlCompanyProfile_CompanyProfile.Size = New System.Drawing.Size(590, 538)
            Me.CompanyProfileControlCompanyProfile_CompanyProfile.TabIndex = 0
            '
            'TabItemProductSetup_CompanyProfileTab
            '
            Me.TabItemProductSetup_CompanyProfileTab.AttachedControl = Me.TabControlPanelCompanyProfileTab_CompanyProfile
            Me.TabItemProductSetup_CompanyProfileTab.Name = "TabItemProductSetup_CompanyProfileTab"
            Me.TabItemProductSetup_CompanyProfileTab.Text = "Company Profile"
            '
            'TabControlPanelActivitySummaryTab_ActivitySummary
            '
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.Controls.Add(Me.ActivitySummaryControlActivitySummary_ActivitySummary)
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.Name = "TabControlPanelActivitySummaryTab_ActivitySummary"
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.Size = New System.Drawing.Size(602, 546)
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.Style.GradientAngle = 90
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.TabIndex = 11
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.TabItem = Me.TabItemProductSetup_ActivitySummaryTab
            '
            'ActivitySummaryControlActivitySummary_ActivitySummary
            '
            Me.ActivitySummaryControlActivitySummary_ActivitySummary.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ActivitySummaryControlActivitySummary_ActivitySummary.BackColor = System.Drawing.Color.White
            Me.ActivitySummaryControlActivitySummary_ActivitySummary.Location = New System.Drawing.Point(6, 4)
            Me.ActivitySummaryControlActivitySummary_ActivitySummary.Margin = New System.Windows.Forms.Padding(4)
            Me.ActivitySummaryControlActivitySummary_ActivitySummary.Name = "ActivitySummaryControlActivitySummary_ActivitySummary"
            Me.ActivitySummaryControlActivitySummary_ActivitySummary.Size = New System.Drawing.Size(590, 538)
            Me.ActivitySummaryControlActivitySummary_ActivitySummary.TabIndex = 0
            '
            'TabItemProductSetup_ActivitySummaryTab
            '
            Me.TabItemProductSetup_ActivitySummaryTab.AttachedControl = Me.TabControlPanelActivitySummaryTab_ActivitySummary
            Me.TabItemProductSetup_ActivitySummaryTab.Name = "TabItemProductSetup_ActivitySummaryTab"
            Me.TabItemProductSetup_ActivitySummaryTab.Text = "Activity Summary"
            '
            'TabControlPanelContractsTab_ContractsOpportunities
            '
            Me.TabControlPanelContractsTab_ContractsOpportunities.Controls.Add(Me.ContractManagerControlContracts_ProductContracts)
            Me.TabControlPanelContractsTab_ContractsOpportunities.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelContractsTab_ContractsOpportunities.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelContractsTab_ContractsOpportunities.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelContractsTab_ContractsOpportunities.Name = "TabControlPanelContractsTab_ContractsOpportunities"
            Me.TabControlPanelContractsTab_ContractsOpportunities.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelContractsTab_ContractsOpportunities.Size = New System.Drawing.Size(602, 546)
            Me.TabControlPanelContractsTab_ContractsOpportunities.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelContractsTab_ContractsOpportunities.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelContractsTab_ContractsOpportunities.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelContractsTab_ContractsOpportunities.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelContractsTab_ContractsOpportunities.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelContractsTab_ContractsOpportunities.Style.GradientAngle = 90
            Me.TabControlPanelContractsTab_ContractsOpportunities.TabIndex = 10
            Me.TabControlPanelContractsTab_ContractsOpportunities.TabItem = Me.TabItemProductSetup_ContractsTab
            '
            'ContractManagerControlContracts_ProductContracts
            '
            Me.ContractManagerControlContracts_ProductContracts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ContractManagerControlContracts_ProductContracts.Location = New System.Drawing.Point(6, 6)
            Me.ContractManagerControlContracts_ProductContracts.Margin = New System.Windows.Forms.Padding(4)
            Me.ContractManagerControlContracts_ProductContracts.Name = "ContractManagerControlContracts_ProductContracts"
            Me.ContractManagerControlContracts_ProductContracts.Size = New System.Drawing.Size(590, 536)
            Me.ContractManagerControlContracts_ProductContracts.TabIndex = 0
            '
            'TabItemProductSetup_ContractsTab
            '
            Me.TabItemProductSetup_ContractsTab.AttachedControl = Me.TabControlPanelContractsTab_ContractsOpportunities
            Me.TabItemProductSetup_ContractsTab.Name = "TabItemProductSetup_ContractsTab"
            Me.TabItemProductSetup_ContractsTab.Text = "Contracts / Opportunities"
            '
            'TabControlPanelAccountExecutivesTab_AccountExecutives
            '
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.Controls.Add(Me.PanelAccountExecutives_RightSection)
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.Controls.Add(Me.ExpandableSplitterControlAccountExecutives_LeftRight)
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.Controls.Add(Me.PanelAccountExecutives_LeftSection)
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.Name = "TabControlPanelAccountExecutivesTab_AccountExecutives"
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.Size = New System.Drawing.Size(602, 546)
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.Style.GradientAngle = 90
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.TabIndex = 6
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.TabItem = Me.TabItemProductSetup_AccountExecutivesTab
            '
            'PanelAccountExecutives_RightSection
            '
            Me.PanelAccountExecutives_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelAccountExecutives_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelAccountExecutives_RightSection.Controls.Add(Me.ButtonRightSection_AddAccountExecutive)
            Me.PanelAccountExecutives_RightSection.Controls.Add(Me.ButtonRightSection_RemoveAccountExecutive)
            Me.PanelAccountExecutives_RightSection.Controls.Add(Me.DataGridViewRightSection_AccountExecutives)
            Me.PanelAccountExecutives_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelAccountExecutives_RightSection.Location = New System.Drawing.Point(289, 1)
            Me.PanelAccountExecutives_RightSection.Name = "PanelAccountExecutives_RightSection"
            Me.PanelAccountExecutives_RightSection.Size = New System.Drawing.Size(312, 544)
            Me.PanelAccountExecutives_RightSection.TabIndex = 9
            '
            'ButtonRightSection_AddAccountExecutive
            '
            Me.ButtonRightSection_AddAccountExecutive.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddAccountExecutive.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddAccountExecutive.Location = New System.Drawing.Point(6, 5)
            Me.ButtonRightSection_AddAccountExecutive.Name = "ButtonRightSection_AddAccountExecutive"
            Me.ButtonRightSection_AddAccountExecutive.SecurityEnabled = True
            Me.ButtonRightSection_AddAccountExecutive.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddAccountExecutive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddAccountExecutive.TabIndex = 9
            Me.ButtonRightSection_AddAccountExecutive.Text = ">"
            '
            'ButtonRightSection_RemoveAccountExecutive
            '
            Me.ButtonRightSection_RemoveAccountExecutive.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveAccountExecutive.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveAccountExecutive.Location = New System.Drawing.Point(6, 31)
            Me.ButtonRightSection_RemoveAccountExecutive.Name = "ButtonRightSection_RemoveAccountExecutive"
            Me.ButtonRightSection_RemoveAccountExecutive.SecurityEnabled = True
            Me.ButtonRightSection_RemoveAccountExecutive.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveAccountExecutive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveAccountExecutive.TabIndex = 10
            Me.ButtonRightSection_RemoveAccountExecutive.Text = "<"
            '
            'DataGridViewRightSection_AccountExecutives
            '
            Me.DataGridViewRightSection_AccountExecutives.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightSection_AccountExecutives.AllowDragAndDrop = False
            Me.DataGridViewRightSection_AccountExecutives.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_AccountExecutives.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_AccountExecutives.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_AccountExecutives.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_AccountExecutives.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_AccountExecutives.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_AccountExecutives.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_AccountExecutives.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_AccountExecutives.DataSource = Nothing
            Me.DataGridViewRightSection_AccountExecutives.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_AccountExecutives.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_AccountExecutives.ItemDescription = ""
            Me.DataGridViewRightSection_AccountExecutives.Location = New System.Drawing.Point(87, 5)
            Me.DataGridViewRightSection_AccountExecutives.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewRightSection_AccountExecutives.MultiSelect = True
            Me.DataGridViewRightSection_AccountExecutives.Name = "DataGridViewRightSection_AccountExecutives"
            Me.DataGridViewRightSection_AccountExecutives.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_AccountExecutives.RunStandardValidation = True
            Me.DataGridViewRightSection_AccountExecutives.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightSection_AccountExecutives.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_AccountExecutives.Size = New System.Drawing.Size(215, 534)
            Me.DataGridViewRightSection_AccountExecutives.TabIndex = 1
            Me.DataGridViewRightSection_AccountExecutives.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_AccountExecutives.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlAccountExecutives_LeftRight
            '
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.ExpandableControl = Me.PanelAccountExecutives_LeftSection
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.Location = New System.Drawing.Point(283, 1)
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.Name = "ExpandableSplitterControlAccountExecutives_LeftRight"
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.Size = New System.Drawing.Size(6, 544)
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.TabIndex = 11
            Me.ExpandableSplitterControlAccountExecutives_LeftRight.TabStop = False
            '
            'PanelAccountExecutives_LeftSection
            '
            Me.PanelAccountExecutives_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelAccountExecutives_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelAccountExecutives_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Employees)
            Me.PanelAccountExecutives_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelAccountExecutives_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelAccountExecutives_LeftSection.Name = "PanelAccountExecutives_LeftSection"
            Me.PanelAccountExecutives_LeftSection.Size = New System.Drawing.Size(282, 544)
            Me.PanelAccountExecutives_LeftSection.TabIndex = 10
            '
            'DataGridViewLeftSection_Employees
            '
            Me.DataGridViewLeftSection_Employees.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_Employees.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_Employees.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_Employees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_Employees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_Employees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Employees.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Employees.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Employees.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_Employees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewLeftSection_Employees.DataSource = Nothing
            Me.DataGridViewLeftSection_Employees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_Employees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Employees.ItemDescription = ""
            Me.DataGridViewLeftSection_Employees.Location = New System.Drawing.Point(10, 5)
            Me.DataGridViewLeftSection_Employees.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewLeftSection_Employees.MultiSelect = True
            Me.DataGridViewLeftSection_Employees.Name = "DataGridViewLeftSection_Employees"
            Me.DataGridViewLeftSection_Employees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Employees.RunStandardValidation = True
            Me.DataGridViewLeftSection_Employees.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_Employees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Employees.Size = New System.Drawing.Size(266, 534)
            Me.DataGridViewLeftSection_Employees.TabIndex = 0
            Me.DataGridViewLeftSection_Employees.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Employees.ViewCaptionHeight = -1
            '
            'TabItemProductSetup_AccountExecutivesTab
            '
            Me.TabItemProductSetup_AccountExecutivesTab.AttachedControl = Me.TabControlPanelAccountExecutivesTab_AccountExecutives
            Me.TabItemProductSetup_AccountExecutivesTab.Name = "TabItemProductSetup_AccountExecutivesTab"
            Me.TabItemProductSetup_AccountExecutivesTab.Text = "Account Executives"
            '
            'TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia
            '
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.Controls.Add(Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome)
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.Name = "TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia"
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.Size = New System.Drawing.Size(602, 546)
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.Style.GradientAngle = 90
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.TabIndex = 5
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.TabItem = Me.TabItemProductSetup_OutOfHomeInternetMedia
            '
            'TableLayoutPanelInternetOutOfHome_InternetOutOfHome
            '
            Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome.ColumnCount = 2
            Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome.Controls.Add(Me.PanelInternetOutOfHome_RightColumn, 1, 0)
            Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome.Controls.Add(Me.PanelInternetOutOfHome_LeftColumn, 0, 0)
            Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome.Name = "TableLayoutPanelInternetOutOfHome_InternetOutOfHome"
            Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome.RowCount = 1
            Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome.Size = New System.Drawing.Size(602, 438)
            Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome.TabIndex = 32
            '
            'PanelInternetOutOfHome_RightColumn
            '
            Me.PanelInternetOutOfHome_RightColumn.Controls.Add(Me.GroupBoxOutOfHomeInternetMedia_OutOfHome)
            Me.PanelInternetOutOfHome_RightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelInternetOutOfHome_RightColumn.Location = New System.Drawing.Point(301, 0)
            Me.PanelInternetOutOfHome_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelInternetOutOfHome_RightColumn.Name = "PanelInternetOutOfHome_RightColumn"
            Me.PanelInternetOutOfHome_RightColumn.Size = New System.Drawing.Size(301, 438)
            Me.PanelInternetOutOfHome_RightColumn.TabIndex = 1
            '
            'GroupBoxOutOfHomeInternetMedia_OutOfHome
            '
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Controls.Add(Me.NumericInputOutOfHome_Rebate)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Controls.Add(Me.NumericInputOutOfHome_Markup)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Controls.Add(Me.ComboBoxOutOfHome_TaxCode)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Controls.Add(Me.CheckBoxOutOfHome_BillingSetupComplete)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Controls.Add(Me.CheckBoxOutOfHome_VendorDiscounts)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Controls.Add(Me.LabelOutOfHome_TaxCode)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Controls.Add(Me.GroupBoxOutOfHome_ApplySalesTaxTo)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Controls.Add(Me.RadioButtonControlOutOfHome_PostBill)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Controls.Add(Me.CheckBoxOutOfHome_CommissionOnly)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Controls.Add(Me.RadioButtonControlOutOfHome_Prebill)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Controls.Add(Me.CheckBoxOutOfHome_BillNet)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Controls.Add(Me.LabelOutOfHome_RebatePercent)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Controls.Add(Me.LabelOutOfHome_MarkupPercent)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Controls.Add(Me.LabelOutOfHome_VendorPriceGross)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Controls.Add(Me.LabelOutOfHome_VendorPriceNet)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Controls.Add(Me.GroupBoxOutOfHome_NumberOfDaysToBill)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Location = New System.Drawing.Point(3, 6)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Name = "GroupBoxOutOfHomeInternetMedia_OutOfHome"
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Size = New System.Drawing.Size(291, 424)
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.TabIndex = 1
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.Text = "Out of Home"
            '
            'NumericInputOutOfHome_Rebate
            '
            Me.NumericInputOutOfHome_Rebate.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputOutOfHome_Rebate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputOutOfHome_Rebate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputOutOfHome_Rebate.EnterMoveNextControl = True
            Me.NumericInputOutOfHome_Rebate.Location = New System.Drawing.Point(74, 103)
            Me.NumericInputOutOfHome_Rebate.Name = "NumericInputOutOfHome_Rebate"
            Me.NumericInputOutOfHome_Rebate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputOutOfHome_Rebate.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputOutOfHome_Rebate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputOutOfHome_Rebate.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputOutOfHome_Rebate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputOutOfHome_Rebate.Properties.EditFormat.FormatString = "f"
            Me.NumericInputOutOfHome_Rebate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputOutOfHome_Rebate.Properties.Mask.EditMask = "f"
            Me.NumericInputOutOfHome_Rebate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputOutOfHome_Rebate.SecurityEnabled = True
            Me.NumericInputOutOfHome_Rebate.Size = New System.Drawing.Size(73, 20)
            Me.NumericInputOutOfHome_Rebate.TabIndex = 7
            '
            'NumericInputOutOfHome_Markup
            '
            Me.NumericInputOutOfHome_Markup.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputOutOfHome_Markup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputOutOfHome_Markup.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputOutOfHome_Markup.EnterMoveNextControl = True
            Me.NumericInputOutOfHome_Markup.Location = New System.Drawing.Point(74, 51)
            Me.NumericInputOutOfHome_Markup.Name = "NumericInputOutOfHome_Markup"
            Me.NumericInputOutOfHome_Markup.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputOutOfHome_Markup.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputOutOfHome_Markup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputOutOfHome_Markup.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputOutOfHome_Markup.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputOutOfHome_Markup.Properties.EditFormat.FormatString = "f"
            Me.NumericInputOutOfHome_Markup.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputOutOfHome_Markup.Properties.Mask.EditMask = "f"
            Me.NumericInputOutOfHome_Markup.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputOutOfHome_Markup.SecurityEnabled = True
            Me.NumericInputOutOfHome_Markup.Size = New System.Drawing.Size(73, 20)
            Me.NumericInputOutOfHome_Markup.TabIndex = 4
            '
            'ComboBoxOutOfHome_TaxCode
            '
            Me.ComboBoxOutOfHome_TaxCode.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxOutOfHome_TaxCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxOutOfHome_TaxCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxOutOfHome_TaxCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxOutOfHome_TaxCode.AutoFindItemInDataSource = False
            Me.ComboBoxOutOfHome_TaxCode.AutoSelectSingleItemDatasource = False
            Me.ComboBoxOutOfHome_TaxCode.BookmarkingEnabled = False
            Me.ComboBoxOutOfHome_TaxCode.ClientCode = ""
            Me.ComboBoxOutOfHome_TaxCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.TaxCode
            Me.ComboBoxOutOfHome_TaxCode.DisableMouseWheel = False
            Me.ComboBoxOutOfHome_TaxCode.DisplayMember = "Name"
            Me.ComboBoxOutOfHome_TaxCode.DisplayName = ""
            Me.ComboBoxOutOfHome_TaxCode.DivisionCode = ""
            Me.ComboBoxOutOfHome_TaxCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxOutOfHome_TaxCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxOutOfHome_TaxCode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxOutOfHome_TaxCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxOutOfHome_TaxCode.FocusHighlightEnabled = True
            Me.ComboBoxOutOfHome_TaxCode.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxOutOfHome_TaxCode.FormattingEnabled = True
            Me.ComboBoxOutOfHome_TaxCode.ItemHeight = 16
            Me.ComboBoxOutOfHome_TaxCode.Location = New System.Drawing.Point(75, 264)
            Me.ComboBoxOutOfHome_TaxCode.Name = "ComboBoxOutOfHome_TaxCode"
            Me.ComboBoxOutOfHome_TaxCode.ReadOnly = False
            Me.ComboBoxOutOfHome_TaxCode.SecurityEnabled = True
            Me.ComboBoxOutOfHome_TaxCode.Size = New System.Drawing.Size(211, 22)
            Me.ComboBoxOutOfHome_TaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxOutOfHome_TaxCode.TabIndex = 16
            Me.ComboBoxOutOfHome_TaxCode.TabOnEnter = True
            Me.ComboBoxOutOfHome_TaxCode.ValueMember = "ID"
            Me.ComboBoxOutOfHome_TaxCode.WatermarkText = "Select Tax Code"
            '
            'CheckBoxOutOfHome_BillingSetupComplete
            '
            Me.CheckBoxOutOfHome_BillingSetupComplete.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxOutOfHome_BillingSetupComplete.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxOutOfHome_BillingSetupComplete.CheckValue = 0
            Me.CheckBoxOutOfHome_BillingSetupComplete.CheckValueChecked = 1
            Me.CheckBoxOutOfHome_BillingSetupComplete.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxOutOfHome_BillingSetupComplete.CheckValueUnchecked = 0
            Me.CheckBoxOutOfHome_BillingSetupComplete.ChildControls = CType(resources.GetObject("CheckBoxOutOfHome_BillingSetupComplete.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOutOfHome_BillingSetupComplete.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxOutOfHome_BillingSetupComplete.Location = New System.Drawing.Point(149, 238)
            Me.CheckBoxOutOfHome_BillingSetupComplete.Name = "CheckBoxOutOfHome_BillingSetupComplete"
            Me.CheckBoxOutOfHome_BillingSetupComplete.OldestSibling = Nothing
            Me.CheckBoxOutOfHome_BillingSetupComplete.SecurityEnabled = True
            Me.CheckBoxOutOfHome_BillingSetupComplete.SiblingControls = CType(resources.GetObject("CheckBoxOutOfHome_BillingSetupComplete.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOutOfHome_BillingSetupComplete.Size = New System.Drawing.Size(137, 20)
            Me.CheckBoxOutOfHome_BillingSetupComplete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxOutOfHome_BillingSetupComplete.TabIndex = 14
            Me.CheckBoxOutOfHome_BillingSetupComplete.TabOnEnter = True
            Me.CheckBoxOutOfHome_BillingSetupComplete.Text = "Billing Setup Complete"
            '
            'CheckBoxOutOfHome_VendorDiscounts
            '
            '
            '
            '
            Me.CheckBoxOutOfHome_VendorDiscounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxOutOfHome_VendorDiscounts.CheckValue = 0
            Me.CheckBoxOutOfHome_VendorDiscounts.CheckValueChecked = 1
            Me.CheckBoxOutOfHome_VendorDiscounts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxOutOfHome_VendorDiscounts.CheckValueUnchecked = 0
            Me.CheckBoxOutOfHome_VendorDiscounts.ChildControls = CType(resources.GetObject("CheckBoxOutOfHome_VendorDiscounts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOutOfHome_VendorDiscounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxOutOfHome_VendorDiscounts.Location = New System.Drawing.Point(5, 238)
            Me.CheckBoxOutOfHome_VendorDiscounts.Name = "CheckBoxOutOfHome_VendorDiscounts"
            Me.CheckBoxOutOfHome_VendorDiscounts.OldestSibling = Nothing
            Me.CheckBoxOutOfHome_VendorDiscounts.SecurityEnabled = True
            Me.CheckBoxOutOfHome_VendorDiscounts.SiblingControls = CType(resources.GetObject("CheckBoxOutOfHome_VendorDiscounts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOutOfHome_VendorDiscounts.Size = New System.Drawing.Size(137, 20)
            Me.CheckBoxOutOfHome_VendorDiscounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxOutOfHome_VendorDiscounts.TabIndex = 13
            Me.CheckBoxOutOfHome_VendorDiscounts.TabOnEnter = True
            Me.CheckBoxOutOfHome_VendorDiscounts.Text = "Vendor Discounts"
            '
            'LabelOutOfHome_TaxCode
            '
            Me.LabelOutOfHome_TaxCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOutOfHome_TaxCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOutOfHome_TaxCode.Location = New System.Drawing.Point(5, 264)
            Me.LabelOutOfHome_TaxCode.Name = "LabelOutOfHome_TaxCode"
            Me.LabelOutOfHome_TaxCode.Size = New System.Drawing.Size(63, 20)
            Me.LabelOutOfHome_TaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOutOfHome_TaxCode.TabIndex = 15
            Me.LabelOutOfHome_TaxCode.Text = "Tax Code:"
            '
            'GroupBoxOutOfHome_ApplySalesTaxTo
            '
            Me.GroupBoxOutOfHome_ApplySalesTaxTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxOutOfHome_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount)
            Me.GroupBoxOutOfHome_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToOutOfHome_Rebate)
            Me.GroupBoxOutOfHome_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToOutOfHome_Commission)
            Me.GroupBoxOutOfHome_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge)
            Me.GroupBoxOutOfHome_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge)
            Me.GroupBoxOutOfHome_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToOutOfHome_LineNet)
            Me.GroupBoxOutOfHome_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags)
            Me.GroupBoxOutOfHome_ApplySalesTaxTo.Location = New System.Drawing.Point(5, 290)
            Me.GroupBoxOutOfHome_ApplySalesTaxTo.Name = "GroupBoxOutOfHome_ApplySalesTaxTo"
            Me.GroupBoxOutOfHome_ApplySalesTaxTo.Size = New System.Drawing.Size(281, 129)
            Me.GroupBoxOutOfHome_ApplySalesTaxTo.TabIndex = 17
            Me.GroupBoxOutOfHome_ApplySalesTaxTo.Text = "Apply Sales Tax To"
            '
            'CheckBoxApplySalesTaxToOutOfHome_NetDiscount
            '
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.CheckValue = 0
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToOutOfHome_NetDiscount.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.Location = New System.Drawing.Point(158, 103)
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.Name = "CheckBoxApplySalesTaxToOutOfHome_NetDiscount"
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToOutOfHome_NetDiscount.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.TabIndex = 6
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToOutOfHome_NetDiscount.Text = "Net Discount"
            '
            'CheckBoxApplySalesTaxToOutOfHome_Rebate
            '
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.CheckValue = 0
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToOutOfHome_Rebate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.Location = New System.Drawing.Point(158, 77)
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.Name = "CheckBoxApplySalesTaxToOutOfHome_Rebate"
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToOutOfHome_Rebate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.TabIndex = 5
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToOutOfHome_Rebate.Text = "Rebate"
            '
            'CheckBoxApplySalesTaxToOutOfHome_Commission
            '
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.CheckValue = 0
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToOutOfHome_Commission.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.Location = New System.Drawing.Point(158, 51)
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.Name = "CheckBoxApplySalesTaxToOutOfHome_Commission"
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToOutOfHome_Commission.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.TabIndex = 4
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToOutOfHome_Commission.Text = "Commission"
            '
            'CheckBoxApplySalesTaxToOutOfHome_AddlCharge
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.CheckValue = 0
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToOutOfHome_AddlCharge.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.Location = New System.Drawing.Point(24, 103)
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.Name = "CheckBoxApplySalesTaxToOutOfHome_AddlCharge"
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToOutOfHome_AddlCharge.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.TabIndex = 3
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToOutOfHome_AddlCharge.Text = "Addl Charge"
            '
            'CheckBoxApplySalesTaxToOutOfHome_NetCharge
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.CheckValue = 0
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToOutOfHome_NetCharge.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.Location = New System.Drawing.Point(24, 77)
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.Name = "CheckBoxApplySalesTaxToOutOfHome_NetCharge"
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToOutOfHome_NetCharge.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.TabIndex = 2
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToOutOfHome_NetCharge.Text = "Net Charge"
            '
            'CheckBoxApplySalesTaxToOutOfHome_LineNet
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.CheckValue = 0
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToOutOfHome_LineNet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.Location = New System.Drawing.Point(24, 51)
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.Name = "CheckBoxApplySalesTaxToOutOfHome_LineNet"
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToOutOfHome_LineNet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.TabIndex = 1
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToOutOfHome_LineNet.Text = "Line Net"
            '
            'CheckBoxApplySalesTaxToOutOfHome_UseFlags
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.CheckValue = 0
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToOutOfHome_UseFlags.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.Name = "CheckBoxApplySalesTaxToOutOfHome_UseFlags"
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToOutOfHome_UseFlags.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.TabIndex = 0
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToOutOfHome_UseFlags.Text = "Use Flags"
            '
            'RadioButtonControlOutOfHome_PostBill
            '
            Me.RadioButtonControlOutOfHome_PostBill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlOutOfHome_PostBill.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlOutOfHome_PostBill.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlOutOfHome_PostBill.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlOutOfHome_PostBill.Location = New System.Drawing.Point(164, 51)
            Me.RadioButtonControlOutOfHome_PostBill.Name = "RadioButtonControlOutOfHome_PostBill"
            Me.RadioButtonControlOutOfHome_PostBill.SecurityEnabled = True
            Me.RadioButtonControlOutOfHome_PostBill.Size = New System.Drawing.Size(122, 20)
            Me.RadioButtonControlOutOfHome_PostBill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlOutOfHome_PostBill.TabIndex = 9
            Me.RadioButtonControlOutOfHome_PostBill.TabOnEnter = True
            Me.RadioButtonControlOutOfHome_PostBill.TabStop = False
            Me.RadioButtonControlOutOfHome_PostBill.Text = "Post Bill"
            '
            'CheckBoxOutOfHome_CommissionOnly
            '
            Me.CheckBoxOutOfHome_CommissionOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxOutOfHome_CommissionOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxOutOfHome_CommissionOnly.CheckValue = 0
            Me.CheckBoxOutOfHome_CommissionOnly.CheckValueChecked = 1
            Me.CheckBoxOutOfHome_CommissionOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxOutOfHome_CommissionOnly.CheckValueUnchecked = 0
            Me.CheckBoxOutOfHome_CommissionOnly.ChildControls = CType(resources.GetObject("CheckBoxOutOfHome_CommissionOnly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOutOfHome_CommissionOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxOutOfHome_CommissionOnly.Location = New System.Drawing.Point(164, 103)
            Me.CheckBoxOutOfHome_CommissionOnly.Name = "CheckBoxOutOfHome_CommissionOnly"
            Me.CheckBoxOutOfHome_CommissionOnly.OldestSibling = Nothing
            Me.CheckBoxOutOfHome_CommissionOnly.SecurityEnabled = True
            Me.CheckBoxOutOfHome_CommissionOnly.SiblingControls = CType(resources.GetObject("CheckBoxOutOfHome_CommissionOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOutOfHome_CommissionOnly.Size = New System.Drawing.Size(122, 20)
            Me.CheckBoxOutOfHome_CommissionOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxOutOfHome_CommissionOnly.TabIndex = 11
            Me.CheckBoxOutOfHome_CommissionOnly.TabOnEnter = True
            Me.CheckBoxOutOfHome_CommissionOnly.Text = "Commission Only"
            '
            'RadioButtonControlOutOfHome_Prebill
            '
            Me.RadioButtonControlOutOfHome_Prebill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlOutOfHome_Prebill.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlOutOfHome_Prebill.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlOutOfHome_Prebill.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlOutOfHome_Prebill.Checked = True
            Me.RadioButtonControlOutOfHome_Prebill.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlOutOfHome_Prebill.CheckValue = "Y"
            Me.RadioButtonControlOutOfHome_Prebill.Location = New System.Drawing.Point(164, 25)
            Me.RadioButtonControlOutOfHome_Prebill.Name = "RadioButtonControlOutOfHome_Prebill"
            Me.RadioButtonControlOutOfHome_Prebill.SecurityEnabled = True
            Me.RadioButtonControlOutOfHome_Prebill.Size = New System.Drawing.Size(122, 20)
            Me.RadioButtonControlOutOfHome_Prebill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlOutOfHome_Prebill.TabIndex = 8
            Me.RadioButtonControlOutOfHome_Prebill.TabOnEnter = True
            Me.RadioButtonControlOutOfHome_Prebill.Text = "Prebill"
            '
            'CheckBoxOutOfHome_BillNet
            '
            Me.CheckBoxOutOfHome_BillNet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxOutOfHome_BillNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxOutOfHome_BillNet.CheckValue = 0
            Me.CheckBoxOutOfHome_BillNet.CheckValueChecked = 1
            Me.CheckBoxOutOfHome_BillNet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxOutOfHome_BillNet.CheckValueUnchecked = 0
            Me.CheckBoxOutOfHome_BillNet.ChildControls = CType(resources.GetObject("CheckBoxOutOfHome_BillNet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOutOfHome_BillNet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxOutOfHome_BillNet.Location = New System.Drawing.Point(164, 77)
            Me.CheckBoxOutOfHome_BillNet.Name = "CheckBoxOutOfHome_BillNet"
            Me.CheckBoxOutOfHome_BillNet.OldestSibling = Nothing
            Me.CheckBoxOutOfHome_BillNet.SecurityEnabled = True
            Me.CheckBoxOutOfHome_BillNet.SiblingControls = CType(resources.GetObject("CheckBoxOutOfHome_BillNet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOutOfHome_BillNet.Size = New System.Drawing.Size(122, 20)
            Me.CheckBoxOutOfHome_BillNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxOutOfHome_BillNet.TabIndex = 10
            Me.CheckBoxOutOfHome_BillNet.TabOnEnter = True
            Me.CheckBoxOutOfHome_BillNet.Text = "Bill Net"
            '
            'LabelOutOfHome_RebatePercent
            '
            Me.LabelOutOfHome_RebatePercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOutOfHome_RebatePercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOutOfHome_RebatePercent.Location = New System.Drawing.Point(5, 103)
            Me.LabelOutOfHome_RebatePercent.Name = "LabelOutOfHome_RebatePercent"
            Me.LabelOutOfHome_RebatePercent.Size = New System.Drawing.Size(63, 20)
            Me.LabelOutOfHome_RebatePercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOutOfHome_RebatePercent.TabIndex = 6
            Me.LabelOutOfHome_RebatePercent.Text = "Rebate %:"
            '
            'LabelOutOfHome_MarkupPercent
            '
            Me.LabelOutOfHome_MarkupPercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOutOfHome_MarkupPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOutOfHome_MarkupPercent.Location = New System.Drawing.Point(5, 51)
            Me.LabelOutOfHome_MarkupPercent.Name = "LabelOutOfHome_MarkupPercent"
            Me.LabelOutOfHome_MarkupPercent.Size = New System.Drawing.Size(63, 20)
            Me.LabelOutOfHome_MarkupPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOutOfHome_MarkupPercent.TabIndex = 3
            Me.LabelOutOfHome_MarkupPercent.Text = "Markup %:"
            '
            'LabelOutOfHome_VendorPriceGross
            '
            Me.LabelOutOfHome_VendorPriceGross.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOutOfHome_VendorPriceGross.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOutOfHome_VendorPriceGross.Location = New System.Drawing.Point(5, 77)
            Me.LabelOutOfHome_VendorPriceGross.Name = "LabelOutOfHome_VendorPriceGross"
            Me.LabelOutOfHome_VendorPriceGross.Size = New System.Drawing.Size(142, 20)
            Me.LabelOutOfHome_VendorPriceGross.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOutOfHome_VendorPriceGross.TabIndex = 5
            Me.LabelOutOfHome_VendorPriceGross.Text = "If Vendor Prices are Gross:"
            '
            'LabelOutOfHome_VendorPriceNet
            '
            Me.LabelOutOfHome_VendorPriceNet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOutOfHome_VendorPriceNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOutOfHome_VendorPriceNet.Location = New System.Drawing.Point(5, 25)
            Me.LabelOutOfHome_VendorPriceNet.Name = "LabelOutOfHome_VendorPriceNet"
            Me.LabelOutOfHome_VendorPriceNet.Size = New System.Drawing.Size(142, 20)
            Me.LabelOutOfHome_VendorPriceNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOutOfHome_VendorPriceNet.TabIndex = 2
            Me.LabelOutOfHome_VendorPriceNet.Text = "If Vendor Prices are Net:"
            '
            'GroupBoxOutOfHome_NumberOfDaysToBill
            '
            Me.GroupBoxOutOfHome_NumberOfDaysToBill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxOutOfHome_NumberOfDaysToBill.Controls.Add(Me.NumericInputNumberOfDaysToBillOutOfHome_Days)
            Me.GroupBoxOutOfHome_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate)
            Me.GroupBoxOutOfHome_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate)
            Me.GroupBoxOutOfHome_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate)
            Me.GroupBoxOutOfHome_NumberOfDaysToBill.Controls.Add(Me.LabelNumberOfDaysToBillOutOfHome_Days)
            Me.GroupBoxOutOfHome_NumberOfDaysToBill.Location = New System.Drawing.Point(5, 129)
            Me.GroupBoxOutOfHome_NumberOfDaysToBill.Name = "GroupBoxOutOfHome_NumberOfDaysToBill"
            Me.GroupBoxOutOfHome_NumberOfDaysToBill.Size = New System.Drawing.Size(281, 103)
            Me.GroupBoxOutOfHome_NumberOfDaysToBill.TabIndex = 12
            Me.GroupBoxOutOfHome_NumberOfDaysToBill.Text = "# of Days to Bill"
            '
            'NumericInputNumberOfDaysToBillOutOfHome_Days
            '
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.EnterMoveNextControl = True
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Location = New System.Drawing.Point(46, 25)
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Name = "NumericInputNumberOfDaysToBillOutOfHome_Days"
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Properties.IsFloatValue = False
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Properties.Mask.EditMask = "f0"
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Properties.MaxLength = 11
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.SecurityEnabled = True
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Size = New System.Drawing.Size(71, 20)
            Me.NumericInputNumberOfDaysToBillOutOfHome_Days.TabIndex = 1
            '
            'RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate
            '
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate.Location = New System.Drawing.Point(139, 77)
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate.Name = "RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate"
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate.TabIndex = 4
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate.TabStop = False
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate.Text = "Before Close Date"
            '
            'RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate
            '
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.Checked = True
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.CheckValue = "Y"
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.Location = New System.Drawing.Point(139, 51)
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.Name = "RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate"
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.TabIndex = 3
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate.Text = "After Post Date"
            '
            'RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate
            '
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate.Location = New System.Drawing.Point(139, 25)
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate.Name = "RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate"
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate.TabIndex = 2
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate.TabStop = False
            Me.RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate.Text = "Before Post Date"
            '
            'LabelNumberOfDaysToBillOutOfHome_Days
            '
            Me.LabelNumberOfDaysToBillOutOfHome_Days.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNumberOfDaysToBillOutOfHome_Days.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNumberOfDaysToBillOutOfHome_Days.Location = New System.Drawing.Point(5, 25)
            Me.LabelNumberOfDaysToBillOutOfHome_Days.Name = "LabelNumberOfDaysToBillOutOfHome_Days"
            Me.LabelNumberOfDaysToBillOutOfHome_Days.Size = New System.Drawing.Size(35, 20)
            Me.LabelNumberOfDaysToBillOutOfHome_Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNumberOfDaysToBillOutOfHome_Days.TabIndex = 0
            Me.LabelNumberOfDaysToBillOutOfHome_Days.Text = "Days:"
            '
            'PanelInternetOutOfHome_LeftColumn
            '
            Me.PanelInternetOutOfHome_LeftColumn.Controls.Add(Me.GroupBoxOutOfHomeInternetMedia_Internet)
            Me.PanelInternetOutOfHome_LeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelInternetOutOfHome_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelInternetOutOfHome_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelInternetOutOfHome_LeftColumn.Name = "PanelInternetOutOfHome_LeftColumn"
            Me.PanelInternetOutOfHome_LeftColumn.Size = New System.Drawing.Size(301, 438)
            Me.PanelInternetOutOfHome_LeftColumn.TabIndex = 0
            '
            'GroupBoxOutOfHomeInternetMedia_Internet
            '
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Controls.Add(Me.NumericInputInternet_Rebate)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Controls.Add(Me.NumericInputInternet_Markup)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Controls.Add(Me.ComboBoxInternet_TaxCode)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Controls.Add(Me.CheckBoxInternet_BillingSetupComplete)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Controls.Add(Me.CheckBoxInternet_VendorDiscounts)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Controls.Add(Me.LabelInternet_TaxCode)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Controls.Add(Me.GroupBoxInternet_ApplySalesTaxTo)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Controls.Add(Me.RadioButtonControlInternet_PostBill)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Controls.Add(Me.CheckBoxInternet_CommissionOnly)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Controls.Add(Me.RadioButtonControlInternet_Prebill)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Controls.Add(Me.CheckBoxInternet_BillNet)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Controls.Add(Me.LabelInternet_RebatePercent)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Controls.Add(Me.LabelInternet_MarkupPercent)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Controls.Add(Me.LabelInternet_VendorPriceGross)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Controls.Add(Me.LabelInternet_VendorPriceNet)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Controls.Add(Me.GroupBoxInternet_NumberOfDaysToBill)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Location = New System.Drawing.Point(6, 6)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Name = "GroupBoxOutOfHomeInternetMedia_Internet"
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Size = New System.Drawing.Size(292, 424)
            Me.GroupBoxOutOfHomeInternetMedia_Internet.TabIndex = 0
            Me.GroupBoxOutOfHomeInternetMedia_Internet.Text = "Internet"
            '
            'NumericInputInternet_Rebate
            '
            Me.NumericInputInternet_Rebate.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputInternet_Rebate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputInternet_Rebate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputInternet_Rebate.EnterMoveNextControl = True
            Me.NumericInputInternet_Rebate.Location = New System.Drawing.Point(74, 103)
            Me.NumericInputInternet_Rebate.Name = "NumericInputInternet_Rebate"
            Me.NumericInputInternet_Rebate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputInternet_Rebate.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputInternet_Rebate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputInternet_Rebate.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputInternet_Rebate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputInternet_Rebate.Properties.EditFormat.FormatString = "f"
            Me.NumericInputInternet_Rebate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputInternet_Rebate.Properties.Mask.EditMask = "f"
            Me.NumericInputInternet_Rebate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputInternet_Rebate.SecurityEnabled = True
            Me.NumericInputInternet_Rebate.Size = New System.Drawing.Size(73, 20)
            Me.NumericInputInternet_Rebate.TabIndex = 6
            '
            'NumericInputInternet_Markup
            '
            Me.NumericInputInternet_Markup.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputInternet_Markup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputInternet_Markup.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputInternet_Markup.EnterMoveNextControl = True
            Me.NumericInputInternet_Markup.Location = New System.Drawing.Point(74, 51)
            Me.NumericInputInternet_Markup.Name = "NumericInputInternet_Markup"
            Me.NumericInputInternet_Markup.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputInternet_Markup.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputInternet_Markup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputInternet_Markup.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputInternet_Markup.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputInternet_Markup.Properties.EditFormat.FormatString = "f"
            Me.NumericInputInternet_Markup.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputInternet_Markup.Properties.Mask.EditMask = "f"
            Me.NumericInputInternet_Markup.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputInternet_Markup.SecurityEnabled = True
            Me.NumericInputInternet_Markup.Size = New System.Drawing.Size(73, 20)
            Me.NumericInputInternet_Markup.TabIndex = 3
            '
            'ComboBoxInternet_TaxCode
            '
            Me.ComboBoxInternet_TaxCode.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxInternet_TaxCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxInternet_TaxCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxInternet_TaxCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxInternet_TaxCode.AutoFindItemInDataSource = False
            Me.ComboBoxInternet_TaxCode.AutoSelectSingleItemDatasource = False
            Me.ComboBoxInternet_TaxCode.BookmarkingEnabled = False
            Me.ComboBoxInternet_TaxCode.ClientCode = ""
            Me.ComboBoxInternet_TaxCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.TaxCode
            Me.ComboBoxInternet_TaxCode.DisableMouseWheel = False
            Me.ComboBoxInternet_TaxCode.DisplayMember = "Name"
            Me.ComboBoxInternet_TaxCode.DisplayName = ""
            Me.ComboBoxInternet_TaxCode.DivisionCode = ""
            Me.ComboBoxInternet_TaxCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxInternet_TaxCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxInternet_TaxCode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxInternet_TaxCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxInternet_TaxCode.FocusHighlightEnabled = True
            Me.ComboBoxInternet_TaxCode.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxInternet_TaxCode.FormattingEnabled = True
            Me.ComboBoxInternet_TaxCode.ItemHeight = 16
            Me.ComboBoxInternet_TaxCode.Location = New System.Drawing.Point(75, 264)
            Me.ComboBoxInternet_TaxCode.Name = "ComboBoxInternet_TaxCode"
            Me.ComboBoxInternet_TaxCode.ReadOnly = False
            Me.ComboBoxInternet_TaxCode.SecurityEnabled = True
            Me.ComboBoxInternet_TaxCode.Size = New System.Drawing.Size(211, 22)
            Me.ComboBoxInternet_TaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxInternet_TaxCode.TabIndex = 15
            Me.ComboBoxInternet_TaxCode.TabOnEnter = True
            Me.ComboBoxInternet_TaxCode.ValueMember = "ID"
            Me.ComboBoxInternet_TaxCode.WatermarkText = "Select Tax Code"
            '
            'CheckBoxInternet_BillingSetupComplete
            '
            Me.CheckBoxInternet_BillingSetupComplete.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxInternet_BillingSetupComplete.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInternet_BillingSetupComplete.CheckValue = 0
            Me.CheckBoxInternet_BillingSetupComplete.CheckValueChecked = 1
            Me.CheckBoxInternet_BillingSetupComplete.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInternet_BillingSetupComplete.CheckValueUnchecked = 0
            Me.CheckBoxInternet_BillingSetupComplete.ChildControls = CType(resources.GetObject("CheckBoxInternet_BillingSetupComplete.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInternet_BillingSetupComplete.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInternet_BillingSetupComplete.Location = New System.Drawing.Point(149, 238)
            Me.CheckBoxInternet_BillingSetupComplete.Name = "CheckBoxInternet_BillingSetupComplete"
            Me.CheckBoxInternet_BillingSetupComplete.OldestSibling = Nothing
            Me.CheckBoxInternet_BillingSetupComplete.SecurityEnabled = True
            Me.CheckBoxInternet_BillingSetupComplete.SiblingControls = CType(resources.GetObject("CheckBoxInternet_BillingSetupComplete.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInternet_BillingSetupComplete.Size = New System.Drawing.Size(137, 20)
            Me.CheckBoxInternet_BillingSetupComplete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInternet_BillingSetupComplete.TabIndex = 13
            Me.CheckBoxInternet_BillingSetupComplete.TabOnEnter = True
            Me.CheckBoxInternet_BillingSetupComplete.Text = "Billing Setup Complete"
            '
            'CheckBoxInternet_VendorDiscounts
            '
            '
            '
            '
            Me.CheckBoxInternet_VendorDiscounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInternet_VendorDiscounts.CheckValue = 0
            Me.CheckBoxInternet_VendorDiscounts.CheckValueChecked = 1
            Me.CheckBoxInternet_VendorDiscounts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInternet_VendorDiscounts.CheckValueUnchecked = 0
            Me.CheckBoxInternet_VendorDiscounts.ChildControls = CType(resources.GetObject("CheckBoxInternet_VendorDiscounts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInternet_VendorDiscounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInternet_VendorDiscounts.Location = New System.Drawing.Point(5, 238)
            Me.CheckBoxInternet_VendorDiscounts.Name = "CheckBoxInternet_VendorDiscounts"
            Me.CheckBoxInternet_VendorDiscounts.OldestSibling = Nothing
            Me.CheckBoxInternet_VendorDiscounts.SecurityEnabled = True
            Me.CheckBoxInternet_VendorDiscounts.SiblingControls = CType(resources.GetObject("CheckBoxInternet_VendorDiscounts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInternet_VendorDiscounts.Size = New System.Drawing.Size(137, 20)
            Me.CheckBoxInternet_VendorDiscounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInternet_VendorDiscounts.TabIndex = 12
            Me.CheckBoxInternet_VendorDiscounts.TabOnEnter = True
            Me.CheckBoxInternet_VendorDiscounts.Text = "Vendor Discounts"
            '
            'LabelInternet_TaxCode
            '
            Me.LabelInternet_TaxCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInternet_TaxCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInternet_TaxCode.Location = New System.Drawing.Point(5, 264)
            Me.LabelInternet_TaxCode.Name = "LabelInternet_TaxCode"
            Me.LabelInternet_TaxCode.Size = New System.Drawing.Size(63, 20)
            Me.LabelInternet_TaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInternet_TaxCode.TabIndex = 14
            Me.LabelInternet_TaxCode.Text = "Tax Code:"
            '
            'GroupBoxInternet_ApplySalesTaxTo
            '
            Me.GroupBoxInternet_ApplySalesTaxTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxInternet_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToInternet_NetDiscount)
            Me.GroupBoxInternet_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToInternet_Rebate)
            Me.GroupBoxInternet_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToInternet_Commission)
            Me.GroupBoxInternet_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToInternet_AddlCharge)
            Me.GroupBoxInternet_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToInternet_NetCharge)
            Me.GroupBoxInternet_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToInternet_LineNet)
            Me.GroupBoxInternet_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToInternet_UseFlags)
            Me.GroupBoxInternet_ApplySalesTaxTo.Location = New System.Drawing.Point(5, 290)
            Me.GroupBoxInternet_ApplySalesTaxTo.Name = "GroupBoxInternet_ApplySalesTaxTo"
            Me.GroupBoxInternet_ApplySalesTaxTo.Size = New System.Drawing.Size(281, 129)
            Me.GroupBoxInternet_ApplySalesTaxTo.TabIndex = 16
            Me.GroupBoxInternet_ApplySalesTaxTo.Text = "Apply Sales Tax To"
            '
            'CheckBoxApplySalesTaxToInternet_NetDiscount
            '
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.CheckValue = 0
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToInternet_NetDiscount.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.Location = New System.Drawing.Point(158, 103)
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.Name = "CheckBoxApplySalesTaxToInternet_NetDiscount"
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToInternet_NetDiscount.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.TabIndex = 6
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToInternet_NetDiscount.Text = "Net Discount"
            '
            'CheckBoxApplySalesTaxToInternet_Rebate
            '
            Me.CheckBoxApplySalesTaxToInternet_Rebate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToInternet_Rebate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToInternet_Rebate.CheckValue = 0
            Me.CheckBoxApplySalesTaxToInternet_Rebate.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToInternet_Rebate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToInternet_Rebate.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToInternet_Rebate.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToInternet_Rebate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToInternet_Rebate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToInternet_Rebate.Location = New System.Drawing.Point(158, 77)
            Me.CheckBoxApplySalesTaxToInternet_Rebate.Name = "CheckBoxApplySalesTaxToInternet_Rebate"
            Me.CheckBoxApplySalesTaxToInternet_Rebate.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToInternet_Rebate.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToInternet_Rebate.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToInternet_Rebate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToInternet_Rebate.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToInternet_Rebate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToInternet_Rebate.TabIndex = 5
            Me.CheckBoxApplySalesTaxToInternet_Rebate.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToInternet_Rebate.Text = "Rebate"
            '
            'CheckBoxApplySalesTaxToInternet_Commission
            '
            Me.CheckBoxApplySalesTaxToInternet_Commission.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToInternet_Commission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToInternet_Commission.CheckValue = 0
            Me.CheckBoxApplySalesTaxToInternet_Commission.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToInternet_Commission.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToInternet_Commission.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToInternet_Commission.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToInternet_Commission.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToInternet_Commission.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToInternet_Commission.Location = New System.Drawing.Point(158, 51)
            Me.CheckBoxApplySalesTaxToInternet_Commission.Name = "CheckBoxApplySalesTaxToInternet_Commission"
            Me.CheckBoxApplySalesTaxToInternet_Commission.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToInternet_Commission.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToInternet_Commission.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToInternet_Commission.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToInternet_Commission.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToInternet_Commission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToInternet_Commission.TabIndex = 4
            Me.CheckBoxApplySalesTaxToInternet_Commission.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToInternet_Commission.Text = "Commission"
            '
            'CheckBoxApplySalesTaxToInternet_AddlCharge
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.CheckValue = 0
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToInternet_AddlCharge.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.Location = New System.Drawing.Point(24, 103)
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.Name = "CheckBoxApplySalesTaxToInternet_AddlCharge"
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToInternet_AddlCharge.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.TabIndex = 3
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToInternet_AddlCharge.Text = "Addl Charge"
            '
            'CheckBoxApplySalesTaxToInternet_NetCharge
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.CheckValue = 0
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToInternet_NetCharge.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.Location = New System.Drawing.Point(24, 77)
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.Name = "CheckBoxApplySalesTaxToInternet_NetCharge"
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToInternet_NetCharge.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.TabIndex = 2
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToInternet_NetCharge.Text = "Net Charge"
            '
            'CheckBoxApplySalesTaxToInternet_LineNet
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToInternet_LineNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToInternet_LineNet.CheckValue = 0
            Me.CheckBoxApplySalesTaxToInternet_LineNet.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToInternet_LineNet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToInternet_LineNet.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToInternet_LineNet.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToInternet_LineNet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToInternet_LineNet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToInternet_LineNet.Location = New System.Drawing.Point(24, 51)
            Me.CheckBoxApplySalesTaxToInternet_LineNet.Name = "CheckBoxApplySalesTaxToInternet_LineNet"
            Me.CheckBoxApplySalesTaxToInternet_LineNet.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToInternet_LineNet.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToInternet_LineNet.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToInternet_LineNet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToInternet_LineNet.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToInternet_LineNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToInternet_LineNet.TabIndex = 1
            Me.CheckBoxApplySalesTaxToInternet_LineNet.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToInternet_LineNet.Text = "Line Net"
            '
            'CheckBoxApplySalesTaxToInternet_UseFlags
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.CheckValue = 0
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToInternet_UseFlags.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.Name = "CheckBoxApplySalesTaxToInternet_UseFlags"
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToInternet_UseFlags.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.TabIndex = 0
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToInternet_UseFlags.Text = "Use Flags"
            '
            'RadioButtonControlInternet_PostBill
            '
            Me.RadioButtonControlInternet_PostBill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlInternet_PostBill.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlInternet_PostBill.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlInternet_PostBill.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlInternet_PostBill.Location = New System.Drawing.Point(164, 51)
            Me.RadioButtonControlInternet_PostBill.Name = "RadioButtonControlInternet_PostBill"
            Me.RadioButtonControlInternet_PostBill.SecurityEnabled = True
            Me.RadioButtonControlInternet_PostBill.Size = New System.Drawing.Size(122, 20)
            Me.RadioButtonControlInternet_PostBill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlInternet_PostBill.TabIndex = 8
            Me.RadioButtonControlInternet_PostBill.TabOnEnter = True
            Me.RadioButtonControlInternet_PostBill.TabStop = False
            Me.RadioButtonControlInternet_PostBill.Text = "Post Bill"
            '
            'CheckBoxInternet_CommissionOnly
            '
            Me.CheckBoxInternet_CommissionOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxInternet_CommissionOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInternet_CommissionOnly.CheckValue = 0
            Me.CheckBoxInternet_CommissionOnly.CheckValueChecked = 1
            Me.CheckBoxInternet_CommissionOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInternet_CommissionOnly.CheckValueUnchecked = 0
            Me.CheckBoxInternet_CommissionOnly.ChildControls = CType(resources.GetObject("CheckBoxInternet_CommissionOnly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInternet_CommissionOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInternet_CommissionOnly.Location = New System.Drawing.Point(164, 103)
            Me.CheckBoxInternet_CommissionOnly.Name = "CheckBoxInternet_CommissionOnly"
            Me.CheckBoxInternet_CommissionOnly.OldestSibling = Nothing
            Me.CheckBoxInternet_CommissionOnly.SecurityEnabled = True
            Me.CheckBoxInternet_CommissionOnly.SiblingControls = CType(resources.GetObject("CheckBoxInternet_CommissionOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInternet_CommissionOnly.Size = New System.Drawing.Size(122, 20)
            Me.CheckBoxInternet_CommissionOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInternet_CommissionOnly.TabIndex = 10
            Me.CheckBoxInternet_CommissionOnly.TabOnEnter = True
            Me.CheckBoxInternet_CommissionOnly.Text = "Commission Only"
            '
            'RadioButtonControlInternet_Prebill
            '
            Me.RadioButtonControlInternet_Prebill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlInternet_Prebill.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlInternet_Prebill.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlInternet_Prebill.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlInternet_Prebill.Checked = True
            Me.RadioButtonControlInternet_Prebill.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlInternet_Prebill.CheckValue = "Y"
            Me.RadioButtonControlInternet_Prebill.Location = New System.Drawing.Point(164, 25)
            Me.RadioButtonControlInternet_Prebill.Name = "RadioButtonControlInternet_Prebill"
            Me.RadioButtonControlInternet_Prebill.SecurityEnabled = True
            Me.RadioButtonControlInternet_Prebill.Size = New System.Drawing.Size(122, 20)
            Me.RadioButtonControlInternet_Prebill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlInternet_Prebill.TabIndex = 7
            Me.RadioButtonControlInternet_Prebill.TabOnEnter = True
            Me.RadioButtonControlInternet_Prebill.Text = "Prebill"
            '
            'CheckBoxInternet_BillNet
            '
            Me.CheckBoxInternet_BillNet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxInternet_BillNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInternet_BillNet.CheckValue = 0
            Me.CheckBoxInternet_BillNet.CheckValueChecked = 1
            Me.CheckBoxInternet_BillNet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInternet_BillNet.CheckValueUnchecked = 0
            Me.CheckBoxInternet_BillNet.ChildControls = CType(resources.GetObject("CheckBoxInternet_BillNet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInternet_BillNet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInternet_BillNet.Location = New System.Drawing.Point(164, 77)
            Me.CheckBoxInternet_BillNet.Name = "CheckBoxInternet_BillNet"
            Me.CheckBoxInternet_BillNet.OldestSibling = Nothing
            Me.CheckBoxInternet_BillNet.SecurityEnabled = True
            Me.CheckBoxInternet_BillNet.SiblingControls = CType(resources.GetObject("CheckBoxInternet_BillNet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInternet_BillNet.Size = New System.Drawing.Size(122, 20)
            Me.CheckBoxInternet_BillNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInternet_BillNet.TabIndex = 9
            Me.CheckBoxInternet_BillNet.TabOnEnter = True
            Me.CheckBoxInternet_BillNet.Text = "Bill Net"
            '
            'LabelInternet_RebatePercent
            '
            Me.LabelInternet_RebatePercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInternet_RebatePercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInternet_RebatePercent.Location = New System.Drawing.Point(5, 103)
            Me.LabelInternet_RebatePercent.Name = "LabelInternet_RebatePercent"
            Me.LabelInternet_RebatePercent.Size = New System.Drawing.Size(63, 20)
            Me.LabelInternet_RebatePercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInternet_RebatePercent.TabIndex = 5
            Me.LabelInternet_RebatePercent.Text = "Rebate %:"
            '
            'LabelInternet_MarkupPercent
            '
            Me.LabelInternet_MarkupPercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInternet_MarkupPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInternet_MarkupPercent.Location = New System.Drawing.Point(5, 51)
            Me.LabelInternet_MarkupPercent.Name = "LabelInternet_MarkupPercent"
            Me.LabelInternet_MarkupPercent.Size = New System.Drawing.Size(63, 20)
            Me.LabelInternet_MarkupPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInternet_MarkupPercent.TabIndex = 2
            Me.LabelInternet_MarkupPercent.Text = "Markup %:"
            '
            'LabelInternet_VendorPriceGross
            '
            Me.LabelInternet_VendorPriceGross.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInternet_VendorPriceGross.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInternet_VendorPriceGross.Location = New System.Drawing.Point(5, 77)
            Me.LabelInternet_VendorPriceGross.Name = "LabelInternet_VendorPriceGross"
            Me.LabelInternet_VendorPriceGross.Size = New System.Drawing.Size(142, 20)
            Me.LabelInternet_VendorPriceGross.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInternet_VendorPriceGross.TabIndex = 4
            Me.LabelInternet_VendorPriceGross.Text = "If Vendor Prices are Gross:"
            '
            'LabelInternet_VendorPriceNet
            '
            Me.LabelInternet_VendorPriceNet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInternet_VendorPriceNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInternet_VendorPriceNet.Location = New System.Drawing.Point(5, 25)
            Me.LabelInternet_VendorPriceNet.Name = "LabelInternet_VendorPriceNet"
            Me.LabelInternet_VendorPriceNet.Size = New System.Drawing.Size(142, 20)
            Me.LabelInternet_VendorPriceNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInternet_VendorPriceNet.TabIndex = 1
            Me.LabelInternet_VendorPriceNet.Text = "If Vendor Prices are Net:"
            '
            'GroupBoxInternet_NumberOfDaysToBill
            '
            Me.GroupBoxInternet_NumberOfDaysToBill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxInternet_NumberOfDaysToBill.Controls.Add(Me.NumericInputNumberOfDaysToBillInternet_Days)
            Me.GroupBoxInternet_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate)
            Me.GroupBoxInternet_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate)
            Me.GroupBoxInternet_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate)
            Me.GroupBoxInternet_NumberOfDaysToBill.Controls.Add(Me.LabelNumberOfDaysToBillInternet_Days)
            Me.GroupBoxInternet_NumberOfDaysToBill.Location = New System.Drawing.Point(5, 129)
            Me.GroupBoxInternet_NumberOfDaysToBill.Name = "GroupBoxInternet_NumberOfDaysToBill"
            Me.GroupBoxInternet_NumberOfDaysToBill.Size = New System.Drawing.Size(281, 103)
            Me.GroupBoxInternet_NumberOfDaysToBill.TabIndex = 11
            Me.GroupBoxInternet_NumberOfDaysToBill.Text = "# of Days to Bill"
            '
            'NumericInputNumberOfDaysToBillInternet_Days
            '
            Me.NumericInputNumberOfDaysToBillInternet_Days.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputNumberOfDaysToBillInternet_Days.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputNumberOfDaysToBillInternet_Days.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputNumberOfDaysToBillInternet_Days.EnterMoveNextControl = True
            Me.NumericInputNumberOfDaysToBillInternet_Days.Location = New System.Drawing.Point(46, 25)
            Me.NumericInputNumberOfDaysToBillInternet_Days.Name = "NumericInputNumberOfDaysToBillInternet_Days"
            Me.NumericInputNumberOfDaysToBillInternet_Days.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputNumberOfDaysToBillInternet_Days.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputNumberOfDaysToBillInternet_Days.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputNumberOfDaysToBillInternet_Days.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputNumberOfDaysToBillInternet_Days.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNumberOfDaysToBillInternet_Days.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputNumberOfDaysToBillInternet_Days.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNumberOfDaysToBillInternet_Days.Properties.IsFloatValue = False
            Me.NumericInputNumberOfDaysToBillInternet_Days.Properties.Mask.EditMask = "f0"
            Me.NumericInputNumberOfDaysToBillInternet_Days.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputNumberOfDaysToBillInternet_Days.Properties.MaxLength = 11
            Me.NumericInputNumberOfDaysToBillInternet_Days.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputNumberOfDaysToBillInternet_Days.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputNumberOfDaysToBillInternet_Days.SecurityEnabled = True
            Me.NumericInputNumberOfDaysToBillInternet_Days.Size = New System.Drawing.Size(71, 20)
            Me.NumericInputNumberOfDaysToBillInternet_Days.TabIndex = 1
            '
            'RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate
            '
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate.Location = New System.Drawing.Point(139, 77)
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate.Name = "RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate"
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate.TabIndex = 4
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate.TabStop = False
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate.Text = "Before Close Date"
            '
            'RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate
            '
            Me.RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate.Location = New System.Drawing.Point(139, 51)
            Me.RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate.Name = "RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate"
            Me.RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate.TabIndex = 3
            Me.RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate.TabStop = False
            Me.RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate.Text = "After Run Date"
            '
            'RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate
            '
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.Checked = True
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.CheckValue = "Y"
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.Location = New System.Drawing.Point(139, 25)
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.Name = "RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate"
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.TabIndex = 2
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate.Text = "Before Run Date"
            '
            'LabelNumberOfDaysToBillInternet_Days
            '
            Me.LabelNumberOfDaysToBillInternet_Days.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNumberOfDaysToBillInternet_Days.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNumberOfDaysToBillInternet_Days.Location = New System.Drawing.Point(5, 25)
            Me.LabelNumberOfDaysToBillInternet_Days.Name = "LabelNumberOfDaysToBillInternet_Days"
            Me.LabelNumberOfDaysToBillInternet_Days.Size = New System.Drawing.Size(35, 20)
            Me.LabelNumberOfDaysToBillInternet_Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNumberOfDaysToBillInternet_Days.TabIndex = 0
            Me.LabelNumberOfDaysToBillInternet_Days.Text = "Days:"
            '
            'TabItemProductSetup_OutOfHomeInternetMedia
            '
            Me.TabItemProductSetup_OutOfHomeInternetMedia.AttachedControl = Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia
            Me.TabItemProductSetup_OutOfHomeInternetMedia.Name = "TabItemProductSetup_OutOfHomeInternetMedia"
            Me.TabItemProductSetup_OutOfHomeInternetMedia.Text = "Internet / Out of Home Media"
            '
            'TabControlPanelPrintMedia_PrintMedia
            '
            Me.TabControlPanelPrintMedia_PrintMedia.Controls.Add(Me.TableLayoutPanelPrintMedia_PrintMedia)
            Me.TabControlPanelPrintMedia_PrintMedia.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelPrintMedia_PrintMedia.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelPrintMedia_PrintMedia.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelPrintMedia_PrintMedia.Name = "TabControlPanelPrintMedia_PrintMedia"
            Me.TabControlPanelPrintMedia_PrintMedia.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelPrintMedia_PrintMedia.Size = New System.Drawing.Size(602, 546)
            Me.TabControlPanelPrintMedia_PrintMedia.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelPrintMedia_PrintMedia.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelPrintMedia_PrintMedia.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelPrintMedia_PrintMedia.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelPrintMedia_PrintMedia.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelPrintMedia_PrintMedia.Style.GradientAngle = 90
            Me.TabControlPanelPrintMedia_PrintMedia.TabIndex = 4
            Me.TabControlPanelPrintMedia_PrintMedia.TabItem = Me.TabItemProductSetup_PrintMedia
            '
            'TableLayoutPanelPrintMedia_PrintMedia
            '
            Me.TableLayoutPanelPrintMedia_PrintMedia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelPrintMedia_PrintMedia.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelPrintMedia_PrintMedia.ColumnCount = 2
            Me.TableLayoutPanelPrintMedia_PrintMedia.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelPrintMedia_PrintMedia.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelPrintMedia_PrintMedia.Controls.Add(Me.PanelPrintMedia_RightColumn, 1, 0)
            Me.TableLayoutPanelPrintMedia_PrintMedia.Controls.Add(Me.PanelPrintMedia_LeftColumn, 0, 0)
            Me.TableLayoutPanelPrintMedia_PrintMedia.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanelPrintMedia_PrintMedia.Name = "TableLayoutPanelPrintMedia_PrintMedia"
            Me.TableLayoutPanelPrintMedia_PrintMedia.RowCount = 1
            Me.TableLayoutPanelPrintMedia_PrintMedia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelPrintMedia_PrintMedia.Size = New System.Drawing.Size(602, 438)
            Me.TableLayoutPanelPrintMedia_PrintMedia.TabIndex = 32
            '
            'PanelPrintMedia_RightColumn
            '
            Me.PanelPrintMedia_RightColumn.Controls.Add(Me.GroupBoxRightColumn_Newspaper)
            Me.PanelPrintMedia_RightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelPrintMedia_RightColumn.Location = New System.Drawing.Point(301, 0)
            Me.PanelPrintMedia_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelPrintMedia_RightColumn.Name = "PanelPrintMedia_RightColumn"
            Me.PanelPrintMedia_RightColumn.Size = New System.Drawing.Size(301, 438)
            Me.PanelPrintMedia_RightColumn.TabIndex = 1
            '
            'GroupBoxRightColumn_Newspaper
            '
            Me.GroupBoxRightColumn_Newspaper.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxRightColumn_Newspaper.Controls.Add(Me.NumericInputNewspaper_Rebate)
            Me.GroupBoxRightColumn_Newspaper.Controls.Add(Me.NumericInputNewspaper_Markup)
            Me.GroupBoxRightColumn_Newspaper.Controls.Add(Me.ComboBoxNewspaper_TaxCode)
            Me.GroupBoxRightColumn_Newspaper.Controls.Add(Me.CheckBoxNewspaper_BillingSetupComplete)
            Me.GroupBoxRightColumn_Newspaper.Controls.Add(Me.CheckBoxNewspaper_VendorDiscounts)
            Me.GroupBoxRightColumn_Newspaper.Controls.Add(Me.LabelNewspaper_TaxCode)
            Me.GroupBoxRightColumn_Newspaper.Controls.Add(Me.GroupBoxNewspaper_ApplySalesTaxTo)
            Me.GroupBoxRightColumn_Newspaper.Controls.Add(Me.RadioButtonControlNewspaper_PostBill)
            Me.GroupBoxRightColumn_Newspaper.Controls.Add(Me.CheckBoxNewspaper_CommissionOnly)
            Me.GroupBoxRightColumn_Newspaper.Controls.Add(Me.RadioButtonControlNewspaper_Prebill)
            Me.GroupBoxRightColumn_Newspaper.Controls.Add(Me.CheckBoxNewspaper_BillNet)
            Me.GroupBoxRightColumn_Newspaper.Controls.Add(Me.LabelNewspaper_RebatePercent)
            Me.GroupBoxRightColumn_Newspaper.Controls.Add(Me.LabelNewspaper_MarkupPercent)
            Me.GroupBoxRightColumn_Newspaper.Controls.Add(Me.LabelNewspaper_PubPricesGross)
            Me.GroupBoxRightColumn_Newspaper.Controls.Add(Me.LabelNewspaper_PubPricesNet)
            Me.GroupBoxRightColumn_Newspaper.Controls.Add(Me.GroupBoxNewspaper_NumberOfDaysToBill)
            Me.GroupBoxRightColumn_Newspaper.Location = New System.Drawing.Point(3, 6)
            Me.GroupBoxRightColumn_Newspaper.Name = "GroupBoxRightColumn_Newspaper"
            Me.GroupBoxRightColumn_Newspaper.Size = New System.Drawing.Size(291, 424)
            Me.GroupBoxRightColumn_Newspaper.TabIndex = 0
            Me.GroupBoxRightColumn_Newspaper.Text = "Newspaper"
            '
            'NumericInputNewspaper_Rebate
            '
            Me.NumericInputNewspaper_Rebate.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputNewspaper_Rebate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputNewspaper_Rebate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputNewspaper_Rebate.EnterMoveNextControl = True
            Me.NumericInputNewspaper_Rebate.Location = New System.Drawing.Point(74, 103)
            Me.NumericInputNewspaper_Rebate.Name = "NumericInputNewspaper_Rebate"
            Me.NumericInputNewspaper_Rebate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputNewspaper_Rebate.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputNewspaper_Rebate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputNewspaper_Rebate.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputNewspaper_Rebate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNewspaper_Rebate.Properties.EditFormat.FormatString = "f"
            Me.NumericInputNewspaper_Rebate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNewspaper_Rebate.Properties.Mask.EditMask = "f"
            Me.NumericInputNewspaper_Rebate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputNewspaper_Rebate.SecurityEnabled = True
            Me.NumericInputNewspaper_Rebate.Size = New System.Drawing.Size(73, 20)
            Me.NumericInputNewspaper_Rebate.TabIndex = 6
            '
            'NumericInputNewspaper_Markup
            '
            Me.NumericInputNewspaper_Markup.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputNewspaper_Markup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputNewspaper_Markup.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputNewspaper_Markup.EnterMoveNextControl = True
            Me.NumericInputNewspaper_Markup.Location = New System.Drawing.Point(74, 51)
            Me.NumericInputNewspaper_Markup.Name = "NumericInputNewspaper_Markup"
            Me.NumericInputNewspaper_Markup.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputNewspaper_Markup.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputNewspaper_Markup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputNewspaper_Markup.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputNewspaper_Markup.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNewspaper_Markup.Properties.EditFormat.FormatString = "f"
            Me.NumericInputNewspaper_Markup.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNewspaper_Markup.Properties.Mask.EditMask = "f"
            Me.NumericInputNewspaper_Markup.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputNewspaper_Markup.SecurityEnabled = True
            Me.NumericInputNewspaper_Markup.Size = New System.Drawing.Size(73, 20)
            Me.NumericInputNewspaper_Markup.TabIndex = 3
            '
            'ComboBoxNewspaper_TaxCode
            '
            Me.ComboBoxNewspaper_TaxCode.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxNewspaper_TaxCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxNewspaper_TaxCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxNewspaper_TaxCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxNewspaper_TaxCode.AutoFindItemInDataSource = False
            Me.ComboBoxNewspaper_TaxCode.AutoSelectSingleItemDatasource = False
            Me.ComboBoxNewspaper_TaxCode.BookmarkingEnabled = False
            Me.ComboBoxNewspaper_TaxCode.ClientCode = ""
            Me.ComboBoxNewspaper_TaxCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.TaxCode
            Me.ComboBoxNewspaper_TaxCode.DisableMouseWheel = False
            Me.ComboBoxNewspaper_TaxCode.DisplayMember = "Name"
            Me.ComboBoxNewspaper_TaxCode.DisplayName = ""
            Me.ComboBoxNewspaper_TaxCode.DivisionCode = ""
            Me.ComboBoxNewspaper_TaxCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxNewspaper_TaxCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxNewspaper_TaxCode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxNewspaper_TaxCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxNewspaper_TaxCode.FocusHighlightEnabled = True
            Me.ComboBoxNewspaper_TaxCode.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxNewspaper_TaxCode.FormattingEnabled = True
            Me.ComboBoxNewspaper_TaxCode.ItemHeight = 16
            Me.ComboBoxNewspaper_TaxCode.Location = New System.Drawing.Point(75, 264)
            Me.ComboBoxNewspaper_TaxCode.Name = "ComboBoxNewspaper_TaxCode"
            Me.ComboBoxNewspaper_TaxCode.ReadOnly = False
            Me.ComboBoxNewspaper_TaxCode.SecurityEnabled = True
            Me.ComboBoxNewspaper_TaxCode.Size = New System.Drawing.Size(211, 22)
            Me.ComboBoxNewspaper_TaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxNewspaper_TaxCode.TabIndex = 15
            Me.ComboBoxNewspaper_TaxCode.TabOnEnter = True
            Me.ComboBoxNewspaper_TaxCode.ValueMember = "ID"
            Me.ComboBoxNewspaper_TaxCode.WatermarkText = "Select Tax Code"
            '
            'CheckBoxNewspaper_BillingSetupComplete
            '
            Me.CheckBoxNewspaper_BillingSetupComplete.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxNewspaper_BillingSetupComplete.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNewspaper_BillingSetupComplete.CheckValue = 0
            Me.CheckBoxNewspaper_BillingSetupComplete.CheckValueChecked = 1
            Me.CheckBoxNewspaper_BillingSetupComplete.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNewspaper_BillingSetupComplete.CheckValueUnchecked = 0
            Me.CheckBoxNewspaper_BillingSetupComplete.ChildControls = CType(resources.GetObject("CheckBoxNewspaper_BillingSetupComplete.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewspaper_BillingSetupComplete.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNewspaper_BillingSetupComplete.Location = New System.Drawing.Point(149, 238)
            Me.CheckBoxNewspaper_BillingSetupComplete.Name = "CheckBoxNewspaper_BillingSetupComplete"
            Me.CheckBoxNewspaper_BillingSetupComplete.OldestSibling = Nothing
            Me.CheckBoxNewspaper_BillingSetupComplete.SecurityEnabled = True
            Me.CheckBoxNewspaper_BillingSetupComplete.SiblingControls = CType(resources.GetObject("CheckBoxNewspaper_BillingSetupComplete.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewspaper_BillingSetupComplete.Size = New System.Drawing.Size(137, 20)
            Me.CheckBoxNewspaper_BillingSetupComplete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewspaper_BillingSetupComplete.TabIndex = 13
            Me.CheckBoxNewspaper_BillingSetupComplete.TabOnEnter = True
            Me.CheckBoxNewspaper_BillingSetupComplete.Text = "Billing Setup Complete"
            '
            'CheckBoxNewspaper_VendorDiscounts
            '
            '
            '
            '
            Me.CheckBoxNewspaper_VendorDiscounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNewspaper_VendorDiscounts.CheckValue = 0
            Me.CheckBoxNewspaper_VendorDiscounts.CheckValueChecked = 1
            Me.CheckBoxNewspaper_VendorDiscounts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNewspaper_VendorDiscounts.CheckValueUnchecked = 0
            Me.CheckBoxNewspaper_VendorDiscounts.ChildControls = CType(resources.GetObject("CheckBoxNewspaper_VendorDiscounts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewspaper_VendorDiscounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNewspaper_VendorDiscounts.Location = New System.Drawing.Point(5, 238)
            Me.CheckBoxNewspaper_VendorDiscounts.Name = "CheckBoxNewspaper_VendorDiscounts"
            Me.CheckBoxNewspaper_VendorDiscounts.OldestSibling = Nothing
            Me.CheckBoxNewspaper_VendorDiscounts.SecurityEnabled = True
            Me.CheckBoxNewspaper_VendorDiscounts.SiblingControls = CType(resources.GetObject("CheckBoxNewspaper_VendorDiscounts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewspaper_VendorDiscounts.Size = New System.Drawing.Size(137, 20)
            Me.CheckBoxNewspaper_VendorDiscounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewspaper_VendorDiscounts.TabIndex = 12
            Me.CheckBoxNewspaper_VendorDiscounts.TabOnEnter = True
            Me.CheckBoxNewspaper_VendorDiscounts.Text = "Vendor Discounts"
            '
            'LabelNewspaper_TaxCode
            '
            Me.LabelNewspaper_TaxCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNewspaper_TaxCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNewspaper_TaxCode.Location = New System.Drawing.Point(5, 264)
            Me.LabelNewspaper_TaxCode.Name = "LabelNewspaper_TaxCode"
            Me.LabelNewspaper_TaxCode.Size = New System.Drawing.Size(63, 20)
            Me.LabelNewspaper_TaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNewspaper_TaxCode.TabIndex = 14
            Me.LabelNewspaper_TaxCode.Text = "Tax Code:"
            '
            'GroupBoxNewspaper_ApplySalesTaxTo
            '
            Me.GroupBoxNewspaper_ApplySalesTaxTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxNewspaper_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount)
            Me.GroupBoxNewspaper_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToNewspaper_Rebate)
            Me.GroupBoxNewspaper_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToNewspaper_Commission)
            Me.GroupBoxNewspaper_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge)
            Me.GroupBoxNewspaper_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToNewspaper_NetCharge)
            Me.GroupBoxNewspaper_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToNewspaper_LineNet)
            Me.GroupBoxNewspaper_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToNewspaper_UseFlags)
            Me.GroupBoxNewspaper_ApplySalesTaxTo.Location = New System.Drawing.Point(5, 290)
            Me.GroupBoxNewspaper_ApplySalesTaxTo.Name = "GroupBoxNewspaper_ApplySalesTaxTo"
            Me.GroupBoxNewspaper_ApplySalesTaxTo.Size = New System.Drawing.Size(281, 129)
            Me.GroupBoxNewspaper_ApplySalesTaxTo.TabIndex = 16
            Me.GroupBoxNewspaper_ApplySalesTaxTo.Text = "Apply Sales Tax To"
            '
            'CheckBoxApplySalesTaxToNewspaper_NetDiscount
            '
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.CheckValue = 0
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToNewspaper_NetDiscount.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.Location = New System.Drawing.Point(158, 103)
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.Name = "CheckBoxApplySalesTaxToNewspaper_NetDiscount"
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToNewspaper_NetDiscount.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.TabIndex = 6
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToNewspaper_NetDiscount.Text = "Net Discount"
            '
            'CheckBoxApplySalesTaxToNewspaper_Rebate
            '
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.CheckValue = 0
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToNewspaper_Rebate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.Location = New System.Drawing.Point(158, 77)
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.Name = "CheckBoxApplySalesTaxToNewspaper_Rebate"
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToNewspaper_Rebate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.TabIndex = 5
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToNewspaper_Rebate.Text = "Rebate"
            '
            'CheckBoxApplySalesTaxToNewspaper_Commission
            '
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.CheckValue = 0
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToNewspaper_Commission.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.Location = New System.Drawing.Point(158, 51)
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.Name = "CheckBoxApplySalesTaxToNewspaper_Commission"
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToNewspaper_Commission.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.TabIndex = 4
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToNewspaper_Commission.Text = "Commission"
            '
            'CheckBoxApplySalesTaxToNewspaper_AddlCharge
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.CheckValue = 0
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToNewspaper_AddlCharge.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.Location = New System.Drawing.Point(24, 103)
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.Name = "CheckBoxApplySalesTaxToNewspaper_AddlCharge"
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToNewspaper_AddlCharge.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.TabIndex = 3
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToNewspaper_AddlCharge.Text = "Addl Charge"
            '
            'CheckBoxApplySalesTaxToNewspaper_NetCharge
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.CheckValue = 0
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToNewspaper_NetCharge.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.Location = New System.Drawing.Point(24, 77)
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.Name = "CheckBoxApplySalesTaxToNewspaper_NetCharge"
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToNewspaper_NetCharge.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.TabIndex = 2
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToNewspaper_NetCharge.Text = "Net Charge"
            '
            'CheckBoxApplySalesTaxToNewspaper_LineNet
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.CheckValue = 0
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToNewspaper_LineNet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.Location = New System.Drawing.Point(24, 51)
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.Name = "CheckBoxApplySalesTaxToNewspaper_LineNet"
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToNewspaper_LineNet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.TabIndex = 1
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToNewspaper_LineNet.Text = "Line Net"
            '
            'CheckBoxApplySalesTaxToNewspaper_UseFlags
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.CheckValue = 0
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToNewspaper_UseFlags.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.Name = "CheckBoxApplySalesTaxToNewspaper_UseFlags"
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToNewspaper_UseFlags.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.TabIndex = 0
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToNewspaper_UseFlags.Text = "Use Flags"
            '
            'RadioButtonControlNewspaper_PostBill
            '
            Me.RadioButtonControlNewspaper_PostBill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNewspaper_PostBill.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNewspaper_PostBill.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNewspaper_PostBill.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNewspaper_PostBill.Location = New System.Drawing.Point(164, 51)
            Me.RadioButtonControlNewspaper_PostBill.Name = "RadioButtonControlNewspaper_PostBill"
            Me.RadioButtonControlNewspaper_PostBill.SecurityEnabled = True
            Me.RadioButtonControlNewspaper_PostBill.Size = New System.Drawing.Size(122, 20)
            Me.RadioButtonControlNewspaper_PostBill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNewspaper_PostBill.TabIndex = 8
            Me.RadioButtonControlNewspaper_PostBill.TabOnEnter = True
            Me.RadioButtonControlNewspaper_PostBill.TabStop = False
            Me.RadioButtonControlNewspaper_PostBill.Text = "Post Bill"
            '
            'CheckBoxNewspaper_CommissionOnly
            '
            Me.CheckBoxNewspaper_CommissionOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxNewspaper_CommissionOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNewspaper_CommissionOnly.CheckValue = 0
            Me.CheckBoxNewspaper_CommissionOnly.CheckValueChecked = 1
            Me.CheckBoxNewspaper_CommissionOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNewspaper_CommissionOnly.CheckValueUnchecked = 0
            Me.CheckBoxNewspaper_CommissionOnly.ChildControls = CType(resources.GetObject("CheckBoxNewspaper_CommissionOnly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewspaper_CommissionOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNewspaper_CommissionOnly.Location = New System.Drawing.Point(164, 103)
            Me.CheckBoxNewspaper_CommissionOnly.Name = "CheckBoxNewspaper_CommissionOnly"
            Me.CheckBoxNewspaper_CommissionOnly.OldestSibling = Nothing
            Me.CheckBoxNewspaper_CommissionOnly.SecurityEnabled = True
            Me.CheckBoxNewspaper_CommissionOnly.SiblingControls = CType(resources.GetObject("CheckBoxNewspaper_CommissionOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewspaper_CommissionOnly.Size = New System.Drawing.Size(122, 20)
            Me.CheckBoxNewspaper_CommissionOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewspaper_CommissionOnly.TabIndex = 10
            Me.CheckBoxNewspaper_CommissionOnly.TabOnEnter = True
            Me.CheckBoxNewspaper_CommissionOnly.Text = "Commission Only"
            '
            'RadioButtonControlNewspaper_Prebill
            '
            Me.RadioButtonControlNewspaper_Prebill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNewspaper_Prebill.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNewspaper_Prebill.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNewspaper_Prebill.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNewspaper_Prebill.Checked = True
            Me.RadioButtonControlNewspaper_Prebill.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlNewspaper_Prebill.CheckValue = "Y"
            Me.RadioButtonControlNewspaper_Prebill.Location = New System.Drawing.Point(164, 25)
            Me.RadioButtonControlNewspaper_Prebill.Name = "RadioButtonControlNewspaper_Prebill"
            Me.RadioButtonControlNewspaper_Prebill.SecurityEnabled = True
            Me.RadioButtonControlNewspaper_Prebill.Size = New System.Drawing.Size(122, 20)
            Me.RadioButtonControlNewspaper_Prebill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNewspaper_Prebill.TabIndex = 7
            Me.RadioButtonControlNewspaper_Prebill.TabOnEnter = True
            Me.RadioButtonControlNewspaper_Prebill.Text = "Prebill"
            '
            'CheckBoxNewspaper_BillNet
            '
            Me.CheckBoxNewspaper_BillNet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxNewspaper_BillNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxNewspaper_BillNet.CheckValue = 0
            Me.CheckBoxNewspaper_BillNet.CheckValueChecked = 1
            Me.CheckBoxNewspaper_BillNet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxNewspaper_BillNet.CheckValueUnchecked = 0
            Me.CheckBoxNewspaper_BillNet.ChildControls = CType(resources.GetObject("CheckBoxNewspaper_BillNet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewspaper_BillNet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxNewspaper_BillNet.Location = New System.Drawing.Point(164, 77)
            Me.CheckBoxNewspaper_BillNet.Name = "CheckBoxNewspaper_BillNet"
            Me.CheckBoxNewspaper_BillNet.OldestSibling = Nothing
            Me.CheckBoxNewspaper_BillNet.SecurityEnabled = True
            Me.CheckBoxNewspaper_BillNet.SiblingControls = CType(resources.GetObject("CheckBoxNewspaper_BillNet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxNewspaper_BillNet.Size = New System.Drawing.Size(122, 20)
            Me.CheckBoxNewspaper_BillNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxNewspaper_BillNet.TabIndex = 9
            Me.CheckBoxNewspaper_BillNet.TabOnEnter = True
            Me.CheckBoxNewspaper_BillNet.Text = "Bill Net"
            '
            'LabelNewspaper_RebatePercent
            '
            Me.LabelNewspaper_RebatePercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNewspaper_RebatePercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNewspaper_RebatePercent.Location = New System.Drawing.Point(5, 103)
            Me.LabelNewspaper_RebatePercent.Name = "LabelNewspaper_RebatePercent"
            Me.LabelNewspaper_RebatePercent.Size = New System.Drawing.Size(63, 20)
            Me.LabelNewspaper_RebatePercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNewspaper_RebatePercent.TabIndex = 5
            Me.LabelNewspaper_RebatePercent.Text = "Rebate %:"
            '
            'LabelNewspaper_MarkupPercent
            '
            Me.LabelNewspaper_MarkupPercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNewspaper_MarkupPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNewspaper_MarkupPercent.Location = New System.Drawing.Point(5, 51)
            Me.LabelNewspaper_MarkupPercent.Name = "LabelNewspaper_MarkupPercent"
            Me.LabelNewspaper_MarkupPercent.Size = New System.Drawing.Size(63, 20)
            Me.LabelNewspaper_MarkupPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNewspaper_MarkupPercent.TabIndex = 2
            Me.LabelNewspaper_MarkupPercent.Text = "Markup %:"
            '
            'LabelNewspaper_PubPricesGross
            '
            Me.LabelNewspaper_PubPricesGross.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNewspaper_PubPricesGross.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNewspaper_PubPricesGross.Location = New System.Drawing.Point(5, 77)
            Me.LabelNewspaper_PubPricesGross.Name = "LabelNewspaper_PubPricesGross"
            Me.LabelNewspaper_PubPricesGross.Size = New System.Drawing.Size(142, 20)
            Me.LabelNewspaper_PubPricesGross.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNewspaper_PubPricesGross.TabIndex = 4
            Me.LabelNewspaper_PubPricesGross.Text = "If Pub Prices are Gross:"
            '
            'LabelNewspaper_PubPricesNet
            '
            Me.LabelNewspaper_PubPricesNet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNewspaper_PubPricesNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNewspaper_PubPricesNet.Location = New System.Drawing.Point(5, 25)
            Me.LabelNewspaper_PubPricesNet.Name = "LabelNewspaper_PubPricesNet"
            Me.LabelNewspaper_PubPricesNet.Size = New System.Drawing.Size(142, 20)
            Me.LabelNewspaper_PubPricesNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNewspaper_PubPricesNet.TabIndex = 1
            Me.LabelNewspaper_PubPricesNet.Text = "If Pub Prices are Net:"
            '
            'GroupBoxNewspaper_NumberOfDaysToBill
            '
            Me.GroupBoxNewspaper_NumberOfDaysToBill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxNewspaper_NumberOfDaysToBill.Controls.Add(Me.NumericInputNumberOfDaysToBillNewspaper_Days)
            Me.GroupBoxNewspaper_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate)
            Me.GroupBoxNewspaper_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate)
            Me.GroupBoxNewspaper_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate)
            Me.GroupBoxNewspaper_NumberOfDaysToBill.Controls.Add(Me.LabelNumberOfDaysToBillNewspaper_Days)
            Me.GroupBoxNewspaper_NumberOfDaysToBill.Location = New System.Drawing.Point(5, 129)
            Me.GroupBoxNewspaper_NumberOfDaysToBill.Name = "GroupBoxNewspaper_NumberOfDaysToBill"
            Me.GroupBoxNewspaper_NumberOfDaysToBill.Size = New System.Drawing.Size(281, 103)
            Me.GroupBoxNewspaper_NumberOfDaysToBill.TabIndex = 11
            Me.GroupBoxNewspaper_NumberOfDaysToBill.Text = "# of Days to Bill"
            '
            'NumericInputNumberOfDaysToBillNewspaper_Days
            '
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.EnterMoveNextControl = True
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.Location = New System.Drawing.Point(46, 25)
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.Name = "NumericInputNumberOfDaysToBillNewspaper_Days"
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.Properties.IsFloatValue = False
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.Properties.Mask.EditMask = "f0"
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.Properties.MaxLength = 11
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.SecurityEnabled = True
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.Size = New System.Drawing.Size(71, 20)
            Me.NumericInputNumberOfDaysToBillNewspaper_Days.TabIndex = 1
            '
            'RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate
            '
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate.Location = New System.Drawing.Point(139, 77)
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate.Name = "RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate"
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate.TabIndex = 4
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate.TabStop = False
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate.Text = "Before Close Date"
            '
            'RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate
            '
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate.Location = New System.Drawing.Point(139, 51)
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate.Name = "RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate"
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate.TabIndex = 3
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate.TabStop = False
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate.Text = "After Insertion Date"
            '
            'RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate
            '
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.Checked = True
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.CheckValue = "Y"
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.Location = New System.Drawing.Point(139, 25)
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.Name = "RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate"
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.TabIndex = 2
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate.Text = "Before Insertion Date"
            '
            'LabelNumberOfDaysToBillNewspaper_Days
            '
            Me.LabelNumberOfDaysToBillNewspaper_Days.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNumberOfDaysToBillNewspaper_Days.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNumberOfDaysToBillNewspaper_Days.Location = New System.Drawing.Point(5, 25)
            Me.LabelNumberOfDaysToBillNewspaper_Days.Name = "LabelNumberOfDaysToBillNewspaper_Days"
            Me.LabelNumberOfDaysToBillNewspaper_Days.Size = New System.Drawing.Size(35, 20)
            Me.LabelNumberOfDaysToBillNewspaper_Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNumberOfDaysToBillNewspaper_Days.TabIndex = 0
            Me.LabelNumberOfDaysToBillNewspaper_Days.Text = "Days:"
            '
            'PanelPrintMedia_LeftColumn
            '
            Me.PanelPrintMedia_LeftColumn.Controls.Add(Me.GroupBoxLeftColumn_Magazine)
            Me.PanelPrintMedia_LeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelPrintMedia_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelPrintMedia_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelPrintMedia_LeftColumn.Name = "PanelPrintMedia_LeftColumn"
            Me.PanelPrintMedia_LeftColumn.Size = New System.Drawing.Size(301, 438)
            Me.PanelPrintMedia_LeftColumn.TabIndex = 0
            '
            'GroupBoxLeftColumn_Magazine
            '
            Me.GroupBoxLeftColumn_Magazine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxLeftColumn_Magazine.Controls.Add(Me.NumericInputMagazine_Rebate)
            Me.GroupBoxLeftColumn_Magazine.Controls.Add(Me.NumericInputMagazine_Markup)
            Me.GroupBoxLeftColumn_Magazine.Controls.Add(Me.ComboBoxMagazine_TaxCode)
            Me.GroupBoxLeftColumn_Magazine.Controls.Add(Me.CheckBoxMagazine_BillingSetupComplete)
            Me.GroupBoxLeftColumn_Magazine.Controls.Add(Me.CheckBoxMagazine_VendorDiscounts)
            Me.GroupBoxLeftColumn_Magazine.Controls.Add(Me.LabelMagazine_TaxCode)
            Me.GroupBoxLeftColumn_Magazine.Controls.Add(Me.GroupBoxMagazine_ApplySalesTaxTo)
            Me.GroupBoxLeftColumn_Magazine.Controls.Add(Me.RadioButtonControlMagazine_PostBill)
            Me.GroupBoxLeftColumn_Magazine.Controls.Add(Me.CheckBoxMagazine_CommissionOnly)
            Me.GroupBoxLeftColumn_Magazine.Controls.Add(Me.RadioButtonControlMagazine_Prebill)
            Me.GroupBoxLeftColumn_Magazine.Controls.Add(Me.CheckBoxMagazine_BillNet)
            Me.GroupBoxLeftColumn_Magazine.Controls.Add(Me.LabelMagazine_RebatePercent)
            Me.GroupBoxLeftColumn_Magazine.Controls.Add(Me.LabelMagazine_MarkupPercent)
            Me.GroupBoxLeftColumn_Magazine.Controls.Add(Me.LabelMagazine_PubPricesGross)
            Me.GroupBoxLeftColumn_Magazine.Controls.Add(Me.LabelMagazine_PubPricesNet)
            Me.GroupBoxLeftColumn_Magazine.Controls.Add(Me.GroupBoxMagazine_NumberOfDaysToBill)
            Me.GroupBoxLeftColumn_Magazine.Location = New System.Drawing.Point(6, 6)
            Me.GroupBoxLeftColumn_Magazine.Name = "GroupBoxLeftColumn_Magazine"
            Me.GroupBoxLeftColumn_Magazine.Size = New System.Drawing.Size(292, 424)
            Me.GroupBoxLeftColumn_Magazine.TabIndex = 1
            Me.GroupBoxLeftColumn_Magazine.Text = "Magazine"
            '
            'NumericInputMagazine_Rebate
            '
            Me.NumericInputMagazine_Rebate.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputMagazine_Rebate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputMagazine_Rebate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputMagazine_Rebate.EnterMoveNextControl = True
            Me.NumericInputMagazine_Rebate.Location = New System.Drawing.Point(74, 103)
            Me.NumericInputMagazine_Rebate.Name = "NumericInputMagazine_Rebate"
            Me.NumericInputMagazine_Rebate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputMagazine_Rebate.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputMagazine_Rebate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputMagazine_Rebate.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputMagazine_Rebate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMagazine_Rebate.Properties.EditFormat.FormatString = "f"
            Me.NumericInputMagazine_Rebate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMagazine_Rebate.Properties.Mask.EditMask = "f"
            Me.NumericInputMagazine_Rebate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputMagazine_Rebate.SecurityEnabled = True
            Me.NumericInputMagazine_Rebate.Size = New System.Drawing.Size(73, 20)
            Me.NumericInputMagazine_Rebate.TabIndex = 7
            '
            'NumericInputMagazine_Markup
            '
            Me.NumericInputMagazine_Markup.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputMagazine_Markup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputMagazine_Markup.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputMagazine_Markup.EnterMoveNextControl = True
            Me.NumericInputMagazine_Markup.Location = New System.Drawing.Point(74, 51)
            Me.NumericInputMagazine_Markup.Name = "NumericInputMagazine_Markup"
            Me.NumericInputMagazine_Markup.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputMagazine_Markup.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputMagazine_Markup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputMagazine_Markup.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputMagazine_Markup.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMagazine_Markup.Properties.EditFormat.FormatString = "f"
            Me.NumericInputMagazine_Markup.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMagazine_Markup.Properties.Mask.EditMask = "f"
            Me.NumericInputMagazine_Markup.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputMagazine_Markup.SecurityEnabled = True
            Me.NumericInputMagazine_Markup.Size = New System.Drawing.Size(73, 20)
            Me.NumericInputMagazine_Markup.TabIndex = 4
            '
            'ComboBoxMagazine_TaxCode
            '
            Me.ComboBoxMagazine_TaxCode.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMagazine_TaxCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxMagazine_TaxCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxMagazine_TaxCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMagazine_TaxCode.AutoFindItemInDataSource = False
            Me.ComboBoxMagazine_TaxCode.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMagazine_TaxCode.BookmarkingEnabled = False
            Me.ComboBoxMagazine_TaxCode.ClientCode = ""
            Me.ComboBoxMagazine_TaxCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.TaxCode
            Me.ComboBoxMagazine_TaxCode.DisableMouseWheel = False
            Me.ComboBoxMagazine_TaxCode.DisplayMember = "Name"
            Me.ComboBoxMagazine_TaxCode.DisplayName = ""
            Me.ComboBoxMagazine_TaxCode.DivisionCode = ""
            Me.ComboBoxMagazine_TaxCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMagazine_TaxCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxMagazine_TaxCode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxMagazine_TaxCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMagazine_TaxCode.FocusHighlightEnabled = True
            Me.ComboBoxMagazine_TaxCode.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxMagazine_TaxCode.FormattingEnabled = True
            Me.ComboBoxMagazine_TaxCode.ItemHeight = 16
            Me.ComboBoxMagazine_TaxCode.Location = New System.Drawing.Point(75, 264)
            Me.ComboBoxMagazine_TaxCode.Name = "ComboBoxMagazine_TaxCode"
            Me.ComboBoxMagazine_TaxCode.ReadOnly = False
            Me.ComboBoxMagazine_TaxCode.SecurityEnabled = True
            Me.ComboBoxMagazine_TaxCode.Size = New System.Drawing.Size(211, 22)
            Me.ComboBoxMagazine_TaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMagazine_TaxCode.TabIndex = 16
            Me.ComboBoxMagazine_TaxCode.TabOnEnter = True
            Me.ComboBoxMagazine_TaxCode.ValueMember = "ID"
            Me.ComboBoxMagazine_TaxCode.WatermarkText = "Select Tax Code"
            '
            'CheckBoxMagazine_BillingSetupComplete
            '
            Me.CheckBoxMagazine_BillingSetupComplete.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMagazine_BillingSetupComplete.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMagazine_BillingSetupComplete.CheckValue = 0
            Me.CheckBoxMagazine_BillingSetupComplete.CheckValueChecked = 1
            Me.CheckBoxMagazine_BillingSetupComplete.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMagazine_BillingSetupComplete.CheckValueUnchecked = 0
            Me.CheckBoxMagazine_BillingSetupComplete.ChildControls = CType(resources.GetObject("CheckBoxMagazine_BillingSetupComplete.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMagazine_BillingSetupComplete.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMagazine_BillingSetupComplete.Location = New System.Drawing.Point(149, 238)
            Me.CheckBoxMagazine_BillingSetupComplete.Name = "CheckBoxMagazine_BillingSetupComplete"
            Me.CheckBoxMagazine_BillingSetupComplete.OldestSibling = Nothing
            Me.CheckBoxMagazine_BillingSetupComplete.SecurityEnabled = True
            Me.CheckBoxMagazine_BillingSetupComplete.SiblingControls = CType(resources.GetObject("CheckBoxMagazine_BillingSetupComplete.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMagazine_BillingSetupComplete.Size = New System.Drawing.Size(137, 20)
            Me.CheckBoxMagazine_BillingSetupComplete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMagazine_BillingSetupComplete.TabIndex = 14
            Me.CheckBoxMagazine_BillingSetupComplete.TabOnEnter = True
            Me.CheckBoxMagazine_BillingSetupComplete.Text = "Billing Setup Complete"
            '
            'CheckBoxMagazine_VendorDiscounts
            '
            '
            '
            '
            Me.CheckBoxMagazine_VendorDiscounts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMagazine_VendorDiscounts.CheckValue = 0
            Me.CheckBoxMagazine_VendorDiscounts.CheckValueChecked = 1
            Me.CheckBoxMagazine_VendorDiscounts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMagazine_VendorDiscounts.CheckValueUnchecked = 0
            Me.CheckBoxMagazine_VendorDiscounts.ChildControls = CType(resources.GetObject("CheckBoxMagazine_VendorDiscounts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMagazine_VendorDiscounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMagazine_VendorDiscounts.Location = New System.Drawing.Point(5, 238)
            Me.CheckBoxMagazine_VendorDiscounts.Name = "CheckBoxMagazine_VendorDiscounts"
            Me.CheckBoxMagazine_VendorDiscounts.OldestSibling = Nothing
            Me.CheckBoxMagazine_VendorDiscounts.SecurityEnabled = True
            Me.CheckBoxMagazine_VendorDiscounts.SiblingControls = CType(resources.GetObject("CheckBoxMagazine_VendorDiscounts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMagazine_VendorDiscounts.Size = New System.Drawing.Size(137, 20)
            Me.CheckBoxMagazine_VendorDiscounts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMagazine_VendorDiscounts.TabIndex = 13
            Me.CheckBoxMagazine_VendorDiscounts.TabOnEnter = True
            Me.CheckBoxMagazine_VendorDiscounts.Text = "Vendor Discounts"
            '
            'LabelMagazine_TaxCode
            '
            Me.LabelMagazine_TaxCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMagazine_TaxCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMagazine_TaxCode.Location = New System.Drawing.Point(5, 264)
            Me.LabelMagazine_TaxCode.Name = "LabelMagazine_TaxCode"
            Me.LabelMagazine_TaxCode.Size = New System.Drawing.Size(63, 20)
            Me.LabelMagazine_TaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMagazine_TaxCode.TabIndex = 15
            Me.LabelMagazine_TaxCode.Text = "Tax Code:"
            '
            'GroupBoxMagazine_ApplySalesTaxTo
            '
            Me.GroupBoxMagazine_ApplySalesTaxTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMagazine_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToMagazine_NetDiscount)
            Me.GroupBoxMagazine_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToMagazine_Rebate)
            Me.GroupBoxMagazine_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToMagazine_Commission)
            Me.GroupBoxMagazine_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToMagazine_AddlCharge)
            Me.GroupBoxMagazine_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToMagazine_NetCharge)
            Me.GroupBoxMagazine_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToMagazine_LineNet)
            Me.GroupBoxMagazine_ApplySalesTaxTo.Controls.Add(Me.CheckBoxApplySalesTaxToMagazine_UseFlags)
            Me.GroupBoxMagazine_ApplySalesTaxTo.Location = New System.Drawing.Point(5, 290)
            Me.GroupBoxMagazine_ApplySalesTaxTo.Name = "GroupBoxMagazine_ApplySalesTaxTo"
            Me.GroupBoxMagazine_ApplySalesTaxTo.Size = New System.Drawing.Size(281, 129)
            Me.GroupBoxMagazine_ApplySalesTaxTo.TabIndex = 17
            Me.GroupBoxMagazine_ApplySalesTaxTo.Text = "Apply Sales Tax To"
            '
            'CheckBoxApplySalesTaxToMagazine_NetDiscount
            '
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.CheckValue = 0
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToMagazine_NetDiscount.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.Location = New System.Drawing.Point(158, 103)
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.Name = "CheckBoxApplySalesTaxToMagazine_NetDiscount"
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToMagazine_NetDiscount.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.TabIndex = 6
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToMagazine_NetDiscount.Text = "Net Discount"
            '
            'CheckBoxApplySalesTaxToMagazine_Rebate
            '
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.CheckValue = 0
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToMagazine_Rebate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.Location = New System.Drawing.Point(158, 77)
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.Name = "CheckBoxApplySalesTaxToMagazine_Rebate"
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToMagazine_Rebate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.TabIndex = 5
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToMagazine_Rebate.Text = "Rebate"
            '
            'CheckBoxApplySalesTaxToMagazine_Commission
            '
            Me.CheckBoxApplySalesTaxToMagazine_Commission.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxApplySalesTaxToMagazine_Commission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToMagazine_Commission.CheckValue = 0
            Me.CheckBoxApplySalesTaxToMagazine_Commission.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToMagazine_Commission.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToMagazine_Commission.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToMagazine_Commission.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToMagazine_Commission.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToMagazine_Commission.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToMagazine_Commission.Location = New System.Drawing.Point(158, 51)
            Me.CheckBoxApplySalesTaxToMagazine_Commission.Name = "CheckBoxApplySalesTaxToMagazine_Commission"
            Me.CheckBoxApplySalesTaxToMagazine_Commission.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToMagazine_Commission.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToMagazine_Commission.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToMagazine_Commission.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToMagazine_Commission.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToMagazine_Commission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToMagazine_Commission.TabIndex = 4
            Me.CheckBoxApplySalesTaxToMagazine_Commission.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToMagazine_Commission.Text = "Commission"
            '
            'CheckBoxApplySalesTaxToMagazine_AddlCharge
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.CheckValue = 0
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToMagazine_AddlCharge.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.Location = New System.Drawing.Point(24, 103)
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.Name = "CheckBoxApplySalesTaxToMagazine_AddlCharge"
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToMagazine_AddlCharge.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.TabIndex = 3
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToMagazine_AddlCharge.Text = "Addl Charge"
            '
            'CheckBoxApplySalesTaxToMagazine_NetCharge
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.CheckValue = 0
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToMagazine_NetCharge.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.Location = New System.Drawing.Point(24, 77)
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.Name = "CheckBoxApplySalesTaxToMagazine_NetCharge"
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToMagazine_NetCharge.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.TabIndex = 2
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToMagazine_NetCharge.Text = "Net Charge"
            '
            'CheckBoxApplySalesTaxToMagazine_LineNet
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.CheckValue = 0
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToMagazine_LineNet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.Location = New System.Drawing.Point(24, 51)
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.Name = "CheckBoxApplySalesTaxToMagazine_LineNet"
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToMagazine_LineNet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.TabIndex = 1
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToMagazine_LineNet.Text = "Line Net"
            '
            'CheckBoxApplySalesTaxToMagazine_UseFlags
            '
            '
            '
            '
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.CheckValue = 0
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.CheckValueChecked = 1
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.CheckValueUnchecked = 0
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.ChildControls = CType(resources.GetObject("CheckBoxApplySalesTaxToMagazine_UseFlags.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.Name = "CheckBoxApplySalesTaxToMagazine_UseFlags"
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.OldestSibling = Nothing
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.SecurityEnabled = True
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.SiblingControls = CType(resources.GetObject("CheckBoxApplySalesTaxToMagazine_UseFlags.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.Size = New System.Drawing.Size(95, 20)
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.TabIndex = 0
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.TabOnEnter = True
            Me.CheckBoxApplySalesTaxToMagazine_UseFlags.Text = "Use Flags"
            '
            'RadioButtonControlMagazine_PostBill
            '
            Me.RadioButtonControlMagazine_PostBill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlMagazine_PostBill.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlMagazine_PostBill.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlMagazine_PostBill.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlMagazine_PostBill.Location = New System.Drawing.Point(164, 51)
            Me.RadioButtonControlMagazine_PostBill.Name = "RadioButtonControlMagazine_PostBill"
            Me.RadioButtonControlMagazine_PostBill.SecurityEnabled = True
            Me.RadioButtonControlMagazine_PostBill.Size = New System.Drawing.Size(122, 20)
            Me.RadioButtonControlMagazine_PostBill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlMagazine_PostBill.TabIndex = 9
            Me.RadioButtonControlMagazine_PostBill.TabOnEnter = True
            Me.RadioButtonControlMagazine_PostBill.TabStop = False
            Me.RadioButtonControlMagazine_PostBill.Text = "Post Bill"
            '
            'CheckBoxMagazine_CommissionOnly
            '
            Me.CheckBoxMagazine_CommissionOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMagazine_CommissionOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMagazine_CommissionOnly.CheckValue = 0
            Me.CheckBoxMagazine_CommissionOnly.CheckValueChecked = 1
            Me.CheckBoxMagazine_CommissionOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMagazine_CommissionOnly.CheckValueUnchecked = 0
            Me.CheckBoxMagazine_CommissionOnly.ChildControls = CType(resources.GetObject("CheckBoxMagazine_CommissionOnly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMagazine_CommissionOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMagazine_CommissionOnly.Location = New System.Drawing.Point(164, 103)
            Me.CheckBoxMagazine_CommissionOnly.Name = "CheckBoxMagazine_CommissionOnly"
            Me.CheckBoxMagazine_CommissionOnly.OldestSibling = Nothing
            Me.CheckBoxMagazine_CommissionOnly.SecurityEnabled = True
            Me.CheckBoxMagazine_CommissionOnly.SiblingControls = CType(resources.GetObject("CheckBoxMagazine_CommissionOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMagazine_CommissionOnly.Size = New System.Drawing.Size(122, 20)
            Me.CheckBoxMagazine_CommissionOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMagazine_CommissionOnly.TabIndex = 11
            Me.CheckBoxMagazine_CommissionOnly.TabOnEnter = True
            Me.CheckBoxMagazine_CommissionOnly.Text = "Commission Only"
            '
            'RadioButtonControlMagazine_Prebill
            '
            Me.RadioButtonControlMagazine_Prebill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlMagazine_Prebill.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlMagazine_Prebill.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlMagazine_Prebill.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlMagazine_Prebill.Checked = True
            Me.RadioButtonControlMagazine_Prebill.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlMagazine_Prebill.CheckValue = "Y"
            Me.RadioButtonControlMagazine_Prebill.Location = New System.Drawing.Point(164, 25)
            Me.RadioButtonControlMagazine_Prebill.Name = "RadioButtonControlMagazine_Prebill"
            Me.RadioButtonControlMagazine_Prebill.SecurityEnabled = True
            Me.RadioButtonControlMagazine_Prebill.Size = New System.Drawing.Size(122, 20)
            Me.RadioButtonControlMagazine_Prebill.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlMagazine_Prebill.TabIndex = 8
            Me.RadioButtonControlMagazine_Prebill.TabOnEnter = True
            Me.RadioButtonControlMagazine_Prebill.Text = "Prebill"
            '
            'CheckBoxMagazine_BillNet
            '
            Me.CheckBoxMagazine_BillNet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMagazine_BillNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMagazine_BillNet.CheckValue = 0
            Me.CheckBoxMagazine_BillNet.CheckValueChecked = 1
            Me.CheckBoxMagazine_BillNet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMagazine_BillNet.CheckValueUnchecked = 0
            Me.CheckBoxMagazine_BillNet.ChildControls = CType(resources.GetObject("CheckBoxMagazine_BillNet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMagazine_BillNet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMagazine_BillNet.Location = New System.Drawing.Point(164, 77)
            Me.CheckBoxMagazine_BillNet.Name = "CheckBoxMagazine_BillNet"
            Me.CheckBoxMagazine_BillNet.OldestSibling = Nothing
            Me.CheckBoxMagazine_BillNet.SecurityEnabled = True
            Me.CheckBoxMagazine_BillNet.SiblingControls = CType(resources.GetObject("CheckBoxMagazine_BillNet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMagazine_BillNet.Size = New System.Drawing.Size(122, 20)
            Me.CheckBoxMagazine_BillNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMagazine_BillNet.TabIndex = 10
            Me.CheckBoxMagazine_BillNet.TabOnEnter = True
            Me.CheckBoxMagazine_BillNet.Text = "Bill Net"
            '
            'LabelMagazine_RebatePercent
            '
            Me.LabelMagazine_RebatePercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMagazine_RebatePercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMagazine_RebatePercent.Location = New System.Drawing.Point(5, 103)
            Me.LabelMagazine_RebatePercent.Name = "LabelMagazine_RebatePercent"
            Me.LabelMagazine_RebatePercent.Size = New System.Drawing.Size(63, 20)
            Me.LabelMagazine_RebatePercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMagazine_RebatePercent.TabIndex = 6
            Me.LabelMagazine_RebatePercent.Text = "Rebate %:"
            '
            'LabelMagazine_MarkupPercent
            '
            Me.LabelMagazine_MarkupPercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMagazine_MarkupPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMagazine_MarkupPercent.Location = New System.Drawing.Point(5, 51)
            Me.LabelMagazine_MarkupPercent.Name = "LabelMagazine_MarkupPercent"
            Me.LabelMagazine_MarkupPercent.Size = New System.Drawing.Size(63, 20)
            Me.LabelMagazine_MarkupPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMagazine_MarkupPercent.TabIndex = 3
            Me.LabelMagazine_MarkupPercent.Text = "Markup %:"
            '
            'LabelMagazine_PubPricesGross
            '
            Me.LabelMagazine_PubPricesGross.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMagazine_PubPricesGross.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMagazine_PubPricesGross.Location = New System.Drawing.Point(5, 77)
            Me.LabelMagazine_PubPricesGross.Name = "LabelMagazine_PubPricesGross"
            Me.LabelMagazine_PubPricesGross.Size = New System.Drawing.Size(142, 20)
            Me.LabelMagazine_PubPricesGross.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMagazine_PubPricesGross.TabIndex = 5
            Me.LabelMagazine_PubPricesGross.Text = "If Pub Prices are Gross:"
            '
            'LabelMagazine_PubPricesNet
            '
            Me.LabelMagazine_PubPricesNet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMagazine_PubPricesNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMagazine_PubPricesNet.Location = New System.Drawing.Point(5, 25)
            Me.LabelMagazine_PubPricesNet.Name = "LabelMagazine_PubPricesNet"
            Me.LabelMagazine_PubPricesNet.Size = New System.Drawing.Size(142, 20)
            Me.LabelMagazine_PubPricesNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMagazine_PubPricesNet.TabIndex = 2
            Me.LabelMagazine_PubPricesNet.Text = "If Pub Prices are Net:"
            '
            'GroupBoxMagazine_NumberOfDaysToBill
            '
            Me.GroupBoxMagazine_NumberOfDaysToBill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMagazine_NumberOfDaysToBill.Controls.Add(Me.NumericInputNumberOfDaysToBillMagazine_Days)
            Me.GroupBoxMagazine_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate)
            Me.GroupBoxMagazine_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate)
            Me.GroupBoxMagazine_NumberOfDaysToBill.Controls.Add(Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate)
            Me.GroupBoxMagazine_NumberOfDaysToBill.Controls.Add(Me.LabelNumberOfDaysToBillMagazine_Days)
            Me.GroupBoxMagazine_NumberOfDaysToBill.Location = New System.Drawing.Point(5, 129)
            Me.GroupBoxMagazine_NumberOfDaysToBill.Name = "GroupBoxMagazine_NumberOfDaysToBill"
            Me.GroupBoxMagazine_NumberOfDaysToBill.Size = New System.Drawing.Size(281, 103)
            Me.GroupBoxMagazine_NumberOfDaysToBill.TabIndex = 12
            Me.GroupBoxMagazine_NumberOfDaysToBill.Text = "# of Days to Bill"
            '
            'NumericInputNumberOfDaysToBillMagazine_Days
            '
            Me.NumericInputNumberOfDaysToBillMagazine_Days.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputNumberOfDaysToBillMagazine_Days.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputNumberOfDaysToBillMagazine_Days.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputNumberOfDaysToBillMagazine_Days.EnterMoveNextControl = True
            Me.NumericInputNumberOfDaysToBillMagazine_Days.Location = New System.Drawing.Point(46, 25)
            Me.NumericInputNumberOfDaysToBillMagazine_Days.Name = "NumericInputNumberOfDaysToBillMagazine_Days"
            Me.NumericInputNumberOfDaysToBillMagazine_Days.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputNumberOfDaysToBillMagazine_Days.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputNumberOfDaysToBillMagazine_Days.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputNumberOfDaysToBillMagazine_Days.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputNumberOfDaysToBillMagazine_Days.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNumberOfDaysToBillMagazine_Days.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputNumberOfDaysToBillMagazine_Days.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNumberOfDaysToBillMagazine_Days.Properties.IsFloatValue = False
            Me.NumericInputNumberOfDaysToBillMagazine_Days.Properties.Mask.EditMask = "f0"
            Me.NumericInputNumberOfDaysToBillMagazine_Days.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputNumberOfDaysToBillMagazine_Days.Properties.MaxLength = 11
            Me.NumericInputNumberOfDaysToBillMagazine_Days.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputNumberOfDaysToBillMagazine_Days.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputNumberOfDaysToBillMagazine_Days.SecurityEnabled = True
            Me.NumericInputNumberOfDaysToBillMagazine_Days.Size = New System.Drawing.Size(71, 20)
            Me.NumericInputNumberOfDaysToBillMagazine_Days.TabIndex = 1
            '
            'RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate
            '
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate.Location = New System.Drawing.Point(139, 77)
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate.Name = "RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate"
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate.TabIndex = 4
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate.TabStop = False
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate.Text = "Before Close Date"
            '
            'RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate
            '
            Me.RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate.Location = New System.Drawing.Point(139, 51)
            Me.RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate.Name = "RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate"
            Me.RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate.TabIndex = 3
            Me.RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate.TabStop = False
            Me.RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate.Text = "After Insertion Date"
            '
            'RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate
            '
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.Checked = True
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.CheckValue = "Y"
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.Location = New System.Drawing.Point(139, 25)
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.Name = "RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate"
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.SecurityEnabled = True
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.Size = New System.Drawing.Size(137, 20)
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.TabIndex = 2
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.TabOnEnter = True
            Me.RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate.Text = "Before Insertion Date"
            '
            'LabelNumberOfDaysToBillMagazine_Days
            '
            Me.LabelNumberOfDaysToBillMagazine_Days.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNumberOfDaysToBillMagazine_Days.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNumberOfDaysToBillMagazine_Days.Location = New System.Drawing.Point(5, 25)
            Me.LabelNumberOfDaysToBillMagazine_Days.Name = "LabelNumberOfDaysToBillMagazine_Days"
            Me.LabelNumberOfDaysToBillMagazine_Days.Size = New System.Drawing.Size(35, 20)
            Me.LabelNumberOfDaysToBillMagazine_Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNumberOfDaysToBillMagazine_Days.TabIndex = 0
            Me.LabelNumberOfDaysToBillMagazine_Days.Text = "Days:"
            '
            'TabItemProductSetup_PrintMedia
            '
            Me.TabItemProductSetup_PrintMedia.AttachedControl = Me.TabControlPanelPrintMedia_PrintMedia
            Me.TabItemProductSetup_PrintMedia.Name = "TabItemProductSetup_PrintMedia"
            Me.TabItemProductSetup_PrintMedia.Text = "Print Media"
            '
            'TabControlPanelDocumentsTab_Documents
            '
            Me.TabControlPanelDocumentsTab_Documents.Controls.Add(Me.DocumentManagerControlDocuments_ProductDocuments)
            Me.TabControlPanelDocumentsTab_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDocumentsTab_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDocumentsTab_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDocumentsTab_Documents.Name = "TabControlPanelDocumentsTab_Documents"
            Me.TabControlPanelDocumentsTab_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDocumentsTab_Documents.Size = New System.Drawing.Size(602, 546)
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDocumentsTab_Documents.Style.GradientAngle = 90
            Me.TabControlPanelDocumentsTab_Documents.TabIndex = 7
            Me.TabControlPanelDocumentsTab_Documents.TabItem = Me.TabItemProductSetup_DocumentsTab
            '
            'DocumentManagerControlDocuments_ProductDocuments
            '
            Me.DocumentManagerControlDocuments_ProductDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlDocuments_ProductDocuments.Location = New System.Drawing.Point(6, 6)
            Me.DocumentManagerControlDocuments_ProductDocuments.Margin = New System.Windows.Forms.Padding(4)
            Me.DocumentManagerControlDocuments_ProductDocuments.Name = "DocumentManagerControlDocuments_ProductDocuments"
            Me.DocumentManagerControlDocuments_ProductDocuments.Size = New System.Drawing.Size(590, 536)
            Me.DocumentManagerControlDocuments_ProductDocuments.TabIndex = 0
            '
            'TabItemProductSetup_DocumentsTab
            '
            Me.TabItemProductSetup_DocumentsTab.AttachedControl = Me.TabControlPanelDocumentsTab_Documents
            Me.TabItemProductSetup_DocumentsTab.Name = "TabItemProductSetup_DocumentsTab"
            Me.TabItemProductSetup_DocumentsTab.Text = "Documents"
            '
            'ProductControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlControl_ProductSetup)
            Me.Name = "ProductControl"
            Me.Size = New System.Drawing.Size(602, 573)
            CType(Me.TabControlControl_ProductSetup, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_ProductSetup.ResumeLayout(False)
            Me.TabControlPanelGeneral_General.ResumeLayout(False)
            CType(Me.PanelSetup_Setup, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSetup_Setup.ResumeLayout(False)
            CType(Me.TabControlGeneral_General, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlGeneral_General.ResumeLayout(False)
            Me.TabControlPanel1.ResumeLayout(False)
            CType(Me.GroupBoxOptions_LatePaymentFee, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxOptions_LatePaymentFee.ResumeLayout(False)
            CType(Me.NumericInputLatePaymentFee_Percentage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelOptionsTab_Options.ResumeLayout(False)
            Me.TableLayoutPanelOptions_TableLayout.ResumeLayout(False)
            Me.PanelTableLayout_RightColumn.ResumeLayout(False)
            Me.PanelTableLayout_LeftColumn.ResumeLayout(False)
            CType(Me.GroupBoxLeftColumn_UserDefinedFields, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxLeftColumn_UserDefinedFields.ResumeLayout(False)
            Me.TabControlPanelAddressesTab_Addresses.ResumeLayout(False)
            Me.TableLayoutPanelAddresses_Addresses.ResumeLayout(False)
            Me.PanelAddresses_RightColumn.ResumeLayout(False)
            CType(Me.GroupBoxRightColumn_Statement, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxRightColumn_Statement.ResumeLayout(False)
            Me.PanelStatement_ContactInformation.ResumeLayout(False)
            Me.PanelAddresses_LeftColumn.ResumeLayout(False)
            CType(Me.GroupBoxLeftColumn_Billing, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxLeftColumn_Billing.ResumeLayout(False)
            CType(Me.PanelBilling_ContactInformation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBilling_ContactInformation.ResumeLayout(False)
            Me.TabControlPanelContactsTab_Contacts.ResumeLayout(False)
            Me.TabControlPanelBroadcastMedia_BroadcastMedia.ResumeLayout(False)
            Me.TableLayoutPanelBroadcastMedia_BroadcastMedia.ResumeLayout(False)
            Me.PanelBroadcastMedia_RightColumn.ResumeLayout(False)
            CType(Me.GroupBoxRightColumn_Television, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxRightColumn_Television.ResumeLayout(False)
            CType(Me.NumericInputTelevision_Rebate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTelevision_Markup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxTelevision_ApplySalesTaxTo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxTelevision_ApplySalesTaxTo.ResumeLayout(False)
            CType(Me.GroupBoxTelevision_NumberOfDaysToBill, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxTelevision_NumberOfDaysToBill.ResumeLayout(False)
            CType(Me.NumericInputNumberOfDaysToBillTelevision_Days.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelBroadcastMedia_LeftColumn.ResumeLayout(False)
            CType(Me.GroupBoxLeftColumn_Radio, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxLeftColumn_Radio.ResumeLayout(False)
            CType(Me.NumericInputRadio_Rebate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputRadio_Markup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxRadio_ApplySalesTaxTo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxRadio_ApplySalesTaxTo.ResumeLayout(False)
            CType(Me.GroupBoxRadio_NumberOfDaysToBill, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxRadio_NumberOfDaysToBill.ResumeLayout(False)
            CType(Me.NumericInputNumberOfDaysToBillRadio_Days.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelProduction_Production.ResumeLayout(False)
            CType(Me.NumericInputProduction_EmployeeTimeBillingRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxProduction_ProductionEstimateFormat, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxProduction_ProductionEstimateFormat.ResumeLayout(False)
            CType(Me.NumericInputProduction_DefaultMarkupPercent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputProduction_ContingencyPercent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxProduction_BillingOptions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxProduction_BillingOptions.ResumeLayout(False)
            CType(Me.NumericInputBillingOptions_EarlyPayDaysOverride.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelCompanyProfileTab_CompanyProfile.ResumeLayout(False)
            Me.TabControlPanelActivitySummaryTab_ActivitySummary.ResumeLayout(False)
            Me.TabControlPanelContractsTab_ContractsOpportunities.ResumeLayout(False)
            Me.TabControlPanelAccountExecutivesTab_AccountExecutives.ResumeLayout(False)
            CType(Me.PanelAccountExecutives_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelAccountExecutives_RightSection.ResumeLayout(False)
            CType(Me.PanelAccountExecutives_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelAccountExecutives_LeftSection.ResumeLayout(False)
            Me.TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia.ResumeLayout(False)
            Me.TableLayoutPanelInternetOutOfHome_InternetOutOfHome.ResumeLayout(False)
            Me.PanelInternetOutOfHome_RightColumn.ResumeLayout(False)
            CType(Me.GroupBoxOutOfHomeInternetMedia_OutOfHome, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxOutOfHomeInternetMedia_OutOfHome.ResumeLayout(False)
            CType(Me.NumericInputOutOfHome_Rebate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputOutOfHome_Markup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxOutOfHome_ApplySalesTaxTo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxOutOfHome_ApplySalesTaxTo.ResumeLayout(False)
            CType(Me.GroupBoxOutOfHome_NumberOfDaysToBill, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxOutOfHome_NumberOfDaysToBill.ResumeLayout(False)
            CType(Me.NumericInputNumberOfDaysToBillOutOfHome_Days.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelInternetOutOfHome_LeftColumn.ResumeLayout(False)
            CType(Me.GroupBoxOutOfHomeInternetMedia_Internet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxOutOfHomeInternetMedia_Internet.ResumeLayout(False)
            CType(Me.NumericInputInternet_Rebate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputInternet_Markup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxInternet_ApplySalesTaxTo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxInternet_ApplySalesTaxTo.ResumeLayout(False)
            CType(Me.GroupBoxInternet_NumberOfDaysToBill, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxInternet_NumberOfDaysToBill.ResumeLayout(False)
            CType(Me.NumericInputNumberOfDaysToBillInternet_Days.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelPrintMedia_PrintMedia.ResumeLayout(False)
            Me.TableLayoutPanelPrintMedia_PrintMedia.ResumeLayout(False)
            Me.PanelPrintMedia_RightColumn.ResumeLayout(False)
            CType(Me.GroupBoxRightColumn_Newspaper, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxRightColumn_Newspaper.ResumeLayout(False)
            CType(Me.NumericInputNewspaper_Rebate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputNewspaper_Markup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxNewspaper_ApplySalesTaxTo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxNewspaper_ApplySalesTaxTo.ResumeLayout(False)
            CType(Me.GroupBoxNewspaper_NumberOfDaysToBill, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxNewspaper_NumberOfDaysToBill.ResumeLayout(False)
            CType(Me.NumericInputNumberOfDaysToBillNewspaper_Days.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelPrintMedia_LeftColumn.ResumeLayout(False)
            CType(Me.GroupBoxLeftColumn_Magazine, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxLeftColumn_Magazine.ResumeLayout(False)
            CType(Me.NumericInputMagazine_Rebate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputMagazine_Markup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxMagazine_ApplySalesTaxTo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMagazine_ApplySalesTaxTo.ResumeLayout(False)
            CType(Me.GroupBoxMagazine_NumberOfDaysToBill, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMagazine_NumberOfDaysToBill.ResumeLayout(False)
            CType(Me.NumericInputNumberOfDaysToBillMagazine_Days.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelDocumentsTab_Documents.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlControl_ProductSetup As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelGeneral_General As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelSetup_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneral_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelGeneral_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneral_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSetup_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxGeneral_Division As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelSetup_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxGeneral_Client As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TabItemProductSetup_GeneralTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelOutOfHomeInternetMedia_OutOfHomeInternetMedia As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents GroupBoxOutOfHomeInternetMedia_Internet As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents ComboBoxInternet_TaxCode As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxInternet_BillingSetupComplete As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxInternet_VendorDiscounts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelInternet_TaxCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxInternet_ApplySalesTaxTo As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxApplySalesTaxToInternet_NetDiscount As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToInternet_Rebate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToInternet_Commission As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToInternet_AddlCharge As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToInternet_NetCharge As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToInternet_LineNet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToInternet_UseFlags As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlInternet_PostBill As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxInternet_CommissionOnly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlInternet_Prebill As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxInternet_BillNet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelInternet_RebatePercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelInternet_MarkupPercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelInternet_VendorPriceGross As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelInternet_VendorPriceNet As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxInternet_NumberOfDaysToBill As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonControlNumberOfDaysToBillInternet_BeforeCloseDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlNumberOfDaysToBillInternet_AfterRunDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlNumberOfDaysToBillInternet_BeforeRunDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelNumberOfDaysToBillInternet_Days As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxOutOfHomeInternetMedia_OutOfHome As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents ComboBoxOutOfHome_TaxCode As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxOutOfHome_BillingSetupComplete As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxOutOfHome_VendorDiscounts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelOutOfHome_TaxCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxOutOfHome_ApplySalesTaxTo As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxApplySalesTaxToOutOfHome_NetDiscount As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToOutOfHome_Rebate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToOutOfHome_Commission As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToOutOfHome_AddlCharge As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToOutOfHome_NetCharge As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToOutOfHome_LineNet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToOutOfHome_UseFlags As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlOutOfHome_PostBill As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxOutOfHome_CommissionOnly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlOutOfHome_Prebill As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxOutOfHome_BillNet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelOutOfHome_RebatePercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelOutOfHome_MarkupPercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelOutOfHome_VendorPriceGross As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelOutOfHome_VendorPriceNet As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxOutOfHome_NumberOfDaysToBill As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonControlNumberOfDaysToBillOutOfHome_BeforeCloseDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlNumberOfDaysToBillOutOfHome_AfterPostDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlNumberOfDaysToBillOutOfHome_BeforePostDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelNumberOfDaysToBillOutOfHome_Days As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemProductSetup_OutOfHomeInternetMedia As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelPrintMedia_PrintMedia As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents GroupBoxRightColumn_Newspaper As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents ComboBoxNewspaper_TaxCode As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxNewspaper_BillingSetupComplete As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxNewspaper_VendorDiscounts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelNewspaper_TaxCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxNewspaper_ApplySalesTaxTo As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxApplySalesTaxToNewspaper_NetDiscount As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToNewspaper_Rebate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToNewspaper_Commission As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToNewspaper_AddlCharge As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToNewspaper_NetCharge As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToNewspaper_LineNet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToNewspaper_UseFlags As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlNewspaper_PostBill As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxNewspaper_CommissionOnly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlNewspaper_Prebill As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxNewspaper_BillNet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelNewspaper_RebatePercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelNewspaper_MarkupPercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelNewspaper_PubPricesGross As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelNewspaper_PubPricesNet As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxNewspaper_NumberOfDaysToBill As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonControlNumberOfDaysToBillNewspaper_BeforeCloseDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlNumberOfDaysToBillNewspaper_AfterInsertionDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlNumberOfDaysToBillNewspaper_BeforeInsertionDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelNumberOfDaysToBillNewspaper_Days As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxLeftColumn_Magazine As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents ComboBoxMagazine_TaxCode As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxMagazine_BillingSetupComplete As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMagazine_VendorDiscounts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelMagazine_TaxCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxMagazine_ApplySalesTaxTo As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxApplySalesTaxToMagazine_NetDiscount As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToMagazine_Rebate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToMagazine_Commission As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToMagazine_AddlCharge As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToMagazine_NetCharge As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToMagazine_LineNet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToMagazine_UseFlags As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlMagazine_PostBill As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxMagazine_CommissionOnly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlMagazine_Prebill As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxMagazine_BillNet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelMagazine_RebatePercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMagazine_MarkupPercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMagazine_PubPricesGross As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMagazine_PubPricesNet As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxMagazine_NumberOfDaysToBill As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonControlNumberOfDaysToBillMagazine_BeforeCloseDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlNumberOfDaysToBillMagazine_AfterInsertionDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlNumberOfDaysToBillMagazine_BeforeInsertionDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelNumberOfDaysToBillMagazine_Days As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemProductSetup_PrintMedia As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelBroadcastMedia_BroadcastMedia As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents GroupBoxRightColumn_Television As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents ComboBoxTelevision_TaxCode As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxTelevision_BillingSetupComplete As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxTelevision_VendorDiscounts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelTelevision_TaxCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxTelevision_ApplySalesTaxTo As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxApplySalesTaxToTelevision_NetDiscount As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToTelevision_Rebate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToTelevision_Commission As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToTelevision_AddlCharge As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToTelevision_NetCharge As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToTelevision_LineNet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToTelevision_UseFlags As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlTelevision_PostBill As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxTelevision_CommissionOnly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlTelevision_Prebill As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxTelevision_BillNet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelTelevision_RebatePercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTelevision_MarkupPercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTelevision_StationPricesGross As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTelevision_StationPricesNet As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxTelevision_NumberOfDaysToBill As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonControlNumberOfDaysToBillTelevision_BeforeCloseDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlNumberOfDaysToBillTelevision_AfterBroadcastDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlNumberOfDaysToBillTelevision_BeforeBroadcastDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelNumberOfDaysToBillTelevision_Days As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxLeftColumn_Radio As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents ComboBoxRadio_TaxCode As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxRadio_BillingSetupComplete As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRadio_VendorDiscounts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelRadio_TaxCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxRadio_ApplySalesTaxTo As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxApplySalesTaxToRadio_NetDiscount As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToRadio_Rebate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToRadio_Commission As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToRadio_AddlCharge As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToRadio_NetCharge As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToRadio_LineNet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplySalesTaxToRadio_UseFlags As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlRadio_PostBill As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxRadio_CommissionOnly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlRadio_Prebill As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxRadio_BillNet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelRadio_RebatePercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRadio_MarkupPercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRadio_StationPricesGross As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRadio_StationPricesNet As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxRadio_NumberOfDaysToBill As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonControlNumberOfDaysToBillRadio_BeforeCloseDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlNumberOfDaysToBillRadio_AfterBroadcastDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlNumberOfDaysToBillRadio_BeforeBroadcastDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelNumberOfDaysToBillRadio_Days As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemProductSetup_BroadcastMedia As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelProduction_Production As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents ComboBoxProduction_DefaultTaxCode As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxProduction_UseEstimateBillingRate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxProduction_BillingOptions As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxBillingOptions_BillingSetupComplete As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxBillingOptions_ApprovedEstimateRequired As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxBillingOptions_AllowVendorDiscounts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxBillingOptions_BillNet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxBillingOptions_ConsolidateFunctions As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxProduction_DefaultAlertGroup As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelProduction_DefaultAlertGroup As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelProduction_DefaultTaxCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelProduction_EmployeeTimeBillingRate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelProduction_DefaultMarkupPercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelProduction_ContingencyPercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemProductSetup_Production As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelProduction_EmployeeTimeBillableMessage As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TableLayoutPanelAddresses_Addresses As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelAddresses_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents ButtonRightColumn_RefreshStatement As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonItemRefreshStatement_Client As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemRefreshStatement_Division As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemRefreshStatement_BillingAddress As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents GroupBoxLeftColumn_UserDefinedFields As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxUserDefinedFields_Field4 As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxUserDefinedFields_Field3 As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxUserDefinedFields_Field2 As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxUserDefinedFields_Field1 As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxStatementContactInformation_FaxExt As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelStatementContactInformation_FaxExt As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxStatementContactInformation_PhoneExt As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelStatementContactInformation_PhoneExt As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxStatementContactInformation_Fax As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxStatementContactInformation_Phone As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelStatementContactInformation_Fax As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelStatementContactInformation_Phone As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents AddressControlRightColumn_StatementAddress As AdvantageFramework.WinForm.Presentation.Controls.AddressControl
        Friend WithEvents PanelAddresses_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents ComboBoxOptions_Currency As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelOptions_Currency As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxOptions_AttentionLine As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelOptions_AttentionLine As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxBillingContactInformation_FaxExt As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelBillingContactInformation_FaxExt As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxBillingContactInformation_PhoneExt As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelBillingContactInformation_PhoneExt As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxBillingContactInformation_Fax As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxBillingContactInformation_Phone As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelBillingContactInformation_Fax As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelBillingContactInformation_Phone As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents AddressControlLeftColumn_BillingAddress As AdvantageFramework.WinForm.Presentation.Controls.AddressControl
        Friend WithEvents CheckBoxGeneral_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ButtonLeftSection_RefreshBilling As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonItemRefreshBilling_Client As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemRefreshBilling_Division As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TableLayoutPanelBroadcastMedia_BroadcastMedia As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelBroadcastMedia_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelBroadcastMedia_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents TableLayoutPanelPrintMedia_PrintMedia As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelPrintMedia_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelPrintMedia_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents TableLayoutPanelInternetOutOfHome_InternetOutOfHome As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelInternetOutOfHome_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelInternetOutOfHome_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents TabControlPanelAccountExecutivesTab_AccountExecutives As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemProductSetup_AccountExecutivesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelAccountExecutives_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_Employees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControlAccountExecutives_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelAccountExecutives_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_AddAccountExecutive As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_RemoveAccountExecutive As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_AccountExecutives As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabControlPanelDocumentsTab_Documents As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemProductSetup_DocumentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DocumentManagerControlDocuments_ProductDocuments As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents TabControlGeneral_General As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelAddressesTab_Addresses As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemGeneral_AddressesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelOptionsTab_Options As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemGeneral_OptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents GroupBoxLeftColumn_Billing As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents PanelBilling_ContactInformation As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents GroupBoxRightColumn_Statement As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents PanelStatement_ContactInformation As System.Windows.Forms.Panel
        Friend WithEvents PanelSetup_Setup As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewRightColumn_SortOptions As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TableLayoutPanelOptions_TableLayout As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelTableLayout_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelTableLayout_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents TabControlPanelCompanyProfileTab_CompanyProfile As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemProductSetup_CompanyProfileTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents CheckBoxGeneral_NewBusiness As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputNumberOfDaysToBillRadio_Days As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputNumberOfDaysToBillNewspaper_Days As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputNumberOfDaysToBillMagazine_Days As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputNumberOfDaysToBillOutOfHome_Days As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputNumberOfDaysToBillInternet_Days As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputNumberOfDaysToBillTelevision_Days As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputInternet_Markup As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputOutOfHome_Rebate As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputOutOfHome_Markup As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputInternet_Rebate As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputNewspaper_Rebate As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputNewspaper_Markup As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputMagazine_Rebate As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputMagazine_Markup As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTelevision_Rebate As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTelevision_Markup As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputRadio_Rebate As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputRadio_Markup As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputProduction_DefaultMarkupPercent As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputProduction_ContingencyPercent As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents TabControlPanelContactsTab_Contacts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemProductSetup_ContactsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelActivitySummaryTab_ActivitySummary As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemProductSetup_ActivitySummaryTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelContractsTab_ContractsOpportunities As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemProductSetup_ContractsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ContractManagerControlContracts_ProductContracts As AdvantageFramework.WinForm.Presentation.Controls.ContractManagerControl
        Friend WithEvents ClientContactManagerControlContacts_ProductContacts As AdvantageFramework.WinForm.Presentation.Controls.ClientContactManagerControl
        Friend WithEvents ComboBoxOptions_Office As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelOptions_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CompanyProfileControlCompanyProfile_CompanyProfile As AdvantageFramework.WinForm.Presentation.Controls.CompanyProfileControl
        Friend WithEvents ActivitySummaryControlActivitySummary_ActivitySummary As AdvantageFramework.WinForm.Presentation.Controls.ActivitySummaryControl
        Friend WithEvents GroupBoxProduction_ProductionEstimateFormat As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelProductionEstimateFormat_StandardFormat As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelProductionEstimateFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxProductionEstimateFormat_Type As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents NumericInputProduction_EmployeeTimeBillingRate As NumericInput
        Friend WithEvents NumericInputBillingOptions_EarlyPayDaysOverride As NumericInput
        Friend WithEvents LabelBillingOptions_EarlyPayDaysOverride As Label
        Friend WithEvents CheckBoxProduction_AvalaraTaxExemptOverride As CheckBox
        Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents GroupBoxOptions_LatePaymentFee As GroupBox
        Friend WithEvents NumericInputLatePaymentFee_Percentage As NumericInput
        Friend WithEvents LabelLatePaymentFee_Percentage As Label
        Friend WithEvents CheckBoxLatePaymentFee_Calculate As CheckBox
        Friend WithEvents TabItemGeneral_BillingTab As DevComponents.DotNetBar.TabItem
    End Class

End Namespace
