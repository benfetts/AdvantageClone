Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class VendorControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VendorControl))
            Me.TabControlControl_VendorDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlMediaDefaults_MediaDefaultsTab = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation = New DevComponents.DotNetBar.TabControlPanel()
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelTableLayout_RightColumn = New System.Windows.Forms.Panel()
            Me.PanelRates_Rates = New System.Windows.Forms.Panel()
            Me.RadioButtonControlRates_Net = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlRates_Gross = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.PanelUnits_Units = New System.Windows.Forms.Panel()
            Me.RadioButtonControlUnits_MontlyOrBroadcastMonth = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlUnits_WeeklyOrCalendarMonth = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlUnits_Daily = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelDeadlines_MaterialCloseDays = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDeadlines_SpaceCloseDays = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputDeadlines_SpaceCloseDays = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDeadlines_MaterialCloseDays = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelGeneralDefaultInformation_Rates = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralDefaultInformation_Deadlines = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralDefaultInformation_Units = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelTableLayout_LeftColumn = New System.Windows.Forms.Panel()
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelGeneralDefaultInformation_CanadianVendorType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMediaDefaults_Financial = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxGeneralDefaultInformation_Band = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelGeneralDefaultInformation_Band = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneralDefaultInformation_CallLetters = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelGeneralDefaultInformation_CallLetters = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxIsComscoreSubscriber = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxIsNielsenSubscriber = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelRatingsSubscriber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView14 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelMediaDefaults_CrossReference = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralDefaultInformation_ComscoreStation = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView15 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelGeneralDefaultInformation_EastlanStation = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView13 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelGeneralDefaultInformation_CableSyscode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView12 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView11 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelGeneralDefaultInformation_Station = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelGeneralDefaultInformation_IsCableSystem = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralDefaultInformation_MarkupPercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputGeneralDefaultInformation_MarkupPercent = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView9 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGeneralDefaultInformation_Market = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView8 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelGeneralDefaultInformation_Market = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralDefaultInformation_CommissionPercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralDefaultInformation_ApplyTo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxApplyTo_NetDiscount = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelGeneralDefaultInformation_OveragePercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxApplyTo_AddlCharge = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelGeneralDefaultInformation_TaxCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxApplyTo_Rebate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelGeneralDefaultInformation_ColumnWidth = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxApplyTo_NetCharge = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplyTo_Commission = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxApplyTo_LineNet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputGeneralDefaultInformation_ColumnWidth = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxApplyTo_UseFlags = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputGeneralDefaultInformation_OveragePercent = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputGeneralDefaultInformation_CommissionPercent = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.TabItemMediaDefaults_GeneralDefaultInformationTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments = New DevComponents.DotNetBar.TabControlPanel()
            Me.ButtonDefaultComments_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxDefaultComments_UseFooterComment = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxDefaultComments_Instructions = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxDefaultComments_FooterComment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxDefaultComments_RateInfo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxDefaultComments_MaterialNotes = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxDefaultComments_PositionInfo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxDefaultComments_MiscInfo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxDefaultComments_CloseInfo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelDefaultComments_FooterComment = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefaultComments_RateInfo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefaultComments_MaterialNotes = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefaultComments_PositionInfo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefaultComments_MiscInfo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefaultComments_CloseInfo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefaultComments_Instructions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemMediaDefaults_DefaultCommentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabItemVendorDetails_MediaDefaultsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelContactsTab_Contacts = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxContacts_DefaultVendorContactCode = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.DataGridViewContacts_Contacts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemVendorDetails_ContactsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelRepresentativesTab_Representatives = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxRepresentatives_DefaultRep2 = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxRepresentatives_DefaultRep1 = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.DataGridViewRepresentatives_VendorReps = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemVendorDetails_RepresentativesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMainTab_Main = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelMain_VATNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxMain_VATNumber = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.CheckBoxMain_Television = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMain_Radio = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMain_OutOfHome = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMain_Newspaper = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMain_Magazine = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMain_Internet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelMain_MediaCategoriesAllowed = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxMain_DefaultCategory = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TableLayoutPanelMain_TableLayout = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelTableLayout_RightSection = New System.Windows.Forms.Panel()
            Me.GroupBoxMain_PayToNameAndAddress = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxPayToNameAndAddress_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ButtonPayToNameAndAddress_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemRefresh_Vendor = New DevComponents.DotNetBar.ButtonItem()
            Me.TextBoxPayToNameAndAddress_FaxExt = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPayToNameAndAddress_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPayToNameAndAddress_PhoneExt = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPayToNameAndAddress_FaxExt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPayToNameAndAddress_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPayToNameAndAddress_PhoneExt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPayToNameAndAddress_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPayToNameAndAddress_Fax = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.Address3LineControlPayToNameAndAddress_PayToAddress = New AdvantageFramework.WinForm.Presentation.Controls.Address3LineControl()
            Me.LabelPayToNameAndAddress_Fax = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPayToNameAndAddress_Phone = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPayToNameAndAddress_Phone = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.PanelTableLayout_LeftSection = New System.Windows.Forms.Panel()
            Me.GroupBoxMain_NameAndAddress = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelLeftSection_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxNameAndAddress_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.Address3LineControlNameAndAddress_Address = New AdvantageFramework.WinForm.Presentation.Controls.Address3LineControl()
            Me.LabelNameAndAddress_Phone = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxNameAndAddress_Phone = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelNameAndAddress_Fax = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxNameAndAddress_Fax = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelNameAndAddress_PhoneExt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelNameAndAddress_FaxExt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxNameAndAddress_FaxExt = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxNameAndAddress_PhoneExt = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.CheckBoxMain_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelMain_DefaultCategory = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxMain_FederalTaxID = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelMain_FederalTaxID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxMain_Website = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxMain_Email = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxMain_PaymentManagerEmail = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelMain_PaymentManagerEmail = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMain_Email = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMain_Website = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxMain_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelMain_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemVendorDetails_MainTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelEEOC2Tab_EEOC2 = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxEEOC2_WomensBusinessDetails = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.CheckBoxWBD_IsWBENC = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelWBD_WBENCCertificationExpirationDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelWBD_WBENCCertificationNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelWBD_WomensBusinessEnterpriseNationalCouncil = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxWBD_WBENCCertificationNumber = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelMOBD_NationalMinoritySupplierDevelopmentCouncil = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxMODB_IsNMSDC = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelMOBD_MinorityCertifcateNumberExpirationDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxMOBD_Ethnicity = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView16 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelMOBD_Ethnicity = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMOBD_MinorityCertifcateNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxMOBD_MinorityCertifcateNumber = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemVendorDetails_EEOC2Tab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelEEOCStatusTab_EEOCStatus = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelControl_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_RemoveEEOCStatus = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddEEOCStatus = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_SelectedEEOCStatuses = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControl_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelControl_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AvailableEEOCStatuses = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemVendorDetails_EEOCStatusTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes = New DevComponents.DotNetBar.TabControlPanel()
            Me.TableLayoutPanelDefaultsNotes_TableLayout = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelRightColumn_DefaultsNotes = New System.Windows.Forms.Panel()
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputDefaultNotes_VCCLimit = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelDefaultNotes_VCCLimit = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxDefaultNotes_Terms = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView7 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxDefaultNotes_DefaultBank = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView6 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxDefaultNotes_DefaultFunction = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView5 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.CheckBoxDefaultNotes_SpecialTerms = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxDefaultNotes_VCCStatus = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelDefaultNotes_VCCStatus = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefaultNotes_DefaultFunction = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefaultNotes_Terms = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefaultNotes_DefaultBank = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxDefaultNotes_ACHType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxDefaultNotes_ACH = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxDefaultNotes_EmployeeVendor = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelLeftColumn_DefaultsNotes = New System.Windows.Forms.Panel()
            Me.ComboBoxDefaultNotes_InvoiceCategory = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelDefaultNotes_InvoiceCategory = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxDefaultNotes_Office = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView4 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxDefaultNotes_Currency = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView3 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.TextBoxDefaultNotes_VendorAccount = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxDefaultNotes_SortName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelDefaultNotes_Currency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonOptions_SortActions = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemSortActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemSortActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelDefaultNotes_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefaultNotes_DefaultAPAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxDefaultNotes_SortOptions = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelDefaultNotes_DefaultExpenseAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefaultNotes_VendorAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefaultNotes_SortName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefaultNotes_SortOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefaultNotes_Notes = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxDefaultNotes_Notes = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemVendorDetails_DefaultsNotesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelContractsTab_Contracts = New DevComponents.DotNetBar.TabControlPanel()
            Me.VendorContractManagerControlContracts_Contracts = New AdvantageFramework.WinForm.Presentation.Controls.VendorContractManagerControl()
            Me.TabItemVendorDetails_ContractsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxServiceTax_Waiver = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxServiceTax_Enabled = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputServiceTax_Rate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.DateTimePickerServiceTax_WaiverExpirationDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.SearchableComboBoxServiceTax_Type = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelServiceTax_WaiverExpirationDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelServiceTax_TaxRate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelServiceTax_TaxType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxServiceTax_Code = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelServiceTax_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemVendorDetails_VendorServiceTaxTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel1099InfoTab_1099Info = New DevComponents.DotNetBar.TabControlPanel()
            Me.TableLayoutPanel1099Info_TableLayout = New System.Windows.Forms.TableLayoutPanel()
            Me.Panel1099Info_RightColumn = New System.Windows.Forms.Panel()
            Me.RadioButtonControl1099Info_MedicalHealthcare = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl1099Info_GrossProceedsToAttorney = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl1099Info_Royalties = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl1099Info_Rent = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl1099Info_OtherIncome = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl1099Info_NonEmployeeCompensation = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.Label1099Info_Category = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Panel1099Info_LeftColumn = New System.Windows.Forms.Panel()
            Me.Address3LineControl1099Info_Address = New AdvantageFramework.WinForm.Presentation.Controls.Address3LineControl()
            Me.CheckBox1099Info_Use1099Address = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.Label1099Info_AlternateAddressFor1099 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBox1099Info_Is1099Vendor = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemVendorDetails_1099InfoTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaInfoTab_MediaInfo = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelMediaInfo_Magazine = New System.Windows.Forms.Panel()
            Me.NumericInputMagazine_Issues = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputMagazine_Circulation = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.TextBoxMagazine_Cycles = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxMagazine_Editions = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelMagazine_Editions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxMagazine_PublishingFrequency = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelMagazine_PublishingFrequency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMagazine_Issues = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMagazine_Cycles = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelNewspaper_Circulation = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelMediaInfo_Newspaper = New System.Windows.Forms.Panel()
            Me.NumericInputNewspaper_DailyCirculation = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputNewspaper_SundayCirculation = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.TextBoxNewspaper_Editions = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelNewspaper_Editions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxNewspaper_PublishingFrequency = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelNewspaper_PublishingFrequency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelNewspaper_DailyCirculation = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMagazine_SundayCirculation = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemVendorDetails_MediaInfoTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery = New DevComponents.DotNetBar.TabControlPanel()
            Me.TableLayoutPanelMediaDelivery_TableLayout = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelMediaDelivery_RightColumn = New System.Windows.Forms.Panel()
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelMediaDelivery_DefaultCorrespondenceMethod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMediaDelivery_ = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonMediaDelivery_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelMediaDelivery_AcceptedMedia = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMediaDelivery_GeneralInfo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMediaDelivery_EFileInfo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxMediaDelivery_FTPDirectory = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelMediaDelivery_PreferredMaterial = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxMediaDelivery_FTPPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelMediaDelivery_FTPUserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxMediaDelivery_FTPUserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelMediaDelivery_FTPPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxMediaDelivery_PreferredMaterial = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelMediaDelivery_FTPDirectory = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxMediaDelivery_EFileInfo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxMediaDelivery_GeneralInfo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxMediaDelivery_AcceptedMedia = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.PanelMediaDelivery_LeftColumn = New System.Windows.Forms.Panel()
            Me.GroupBoxMediaDelivery_MediaShipping = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelMediaShipping_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxMediaShipping_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxMediaShipping_PhoneExt = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelMediaShipping_PhoneExt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMediaShipping_Phone = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxMediaShipping_Phone = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.Address3LineControlMediaDelivery_MediaShippingAddress = New AdvantageFramework.WinForm.Presentation.Controls.Address3LineControl()
            Me.TabItemVendorDetails_MediaDeliveryTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDocumentsTab_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlDocuments_VendorDocuments = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemVendorDetails_DocumentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaSpecsTab_MediaSpecs = New DevComponents.DotNetBar.TabControlPanel()
            Me.SearchableComboBoxMediaSpecs_DefaultSize = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView10 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.TreeListControlMediaSpecs_MediaSpecs = New AdvantageFramework.WinForm.Presentation.Controls.TreeListControl()
            Me.LabelMediaSpecs_DefaultSize = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemVendorDetails_MediaSpecsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelPricingsTab_Pricings = New DevComponents.DotNetBar.TabControlPanel()
            Me.VendorPricingControlPricings_VendorPricings = New AdvantageFramework.WinForm.Presentation.Controls.VendorPricingControl()
            Me.TabItemVendorDetails_PricingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.LabelDefaultNotes_ACHType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMain_QuickbooksVendor = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxMain_QuickBooksVendor = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView17 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            CType(Me.TabControlControl_VendorDetails, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlControl_VendorDetails.SuspendLayout
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.SuspendLayout
            CType(Me.TabControlMediaDefaults_MediaDefaultsTab, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlMediaDefaults_MediaDefaultsTab.SuspendLayout
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.SuspendLayout
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout.SuspendLayout
            Me.PanelTableLayout_RightColumn.SuspendLayout
            Me.PanelRates_Rates.SuspendLayout
            Me.PanelUnits_Units.SuspendLayout
            CType(Me.NumericInputDeadlines_SpaceCloseDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDeadlines_MaterialCloseDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            Me.PanelTableLayout_LeftColumn.SuspendLayout
            CType(Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView14, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView15, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView13, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView12, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxGeneralDefaultInformation_TVStation.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView11, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputGeneralDefaultInformation_MarkupPercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView9, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxGeneralDefaultInformation_Market.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputGeneralDefaultInformation_ColumnWidth.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputGeneralDefaultInformation_OveragePercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputGeneralDefaultInformation_CommissionPercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.SuspendLayout
            Me.TabControlPanelContactsTab_Contacts.SuspendLayout
            Me.TabControlPanelRepresentativesTab_Representatives.SuspendLayout
            Me.TabControlPanelMainTab_Main.SuspendLayout
            Me.TableLayoutPanelMain_TableLayout.SuspendLayout
            Me.PanelTableLayout_RightSection.SuspendLayout
            CType(Me.GroupBoxMain_PayToNameAndAddress, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxMain_PayToNameAndAddress.SuspendLayout
            Me.PanelTableLayout_LeftSection.SuspendLayout
            CType(Me.GroupBoxMain_NameAndAddress, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxMain_NameAndAddress.SuspendLayout
            Me.TabControlPanelEEOC2Tab_EEOC2.SuspendLayout
            CType(Me.GroupBoxEEOC2_WomensBusinessDetails, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxEEOC2_WomensBusinessDetails.SuspendLayout
            CType(Me.DateTimePickerWBD_WBENCCertificationExpirationDate, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails.SuspendLayout
            CType(Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxMOBD_Ethnicity.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView16, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.SuspendLayout
            CType(Me.PanelControl_RightSection, System.ComponentModel.ISupportInitialize).BeginInit
            Me.PanelControl_RightSection.SuspendLayout
            CType(Me.PanelControl_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit
            Me.PanelControl_LeftSection.SuspendLayout
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.SuspendLayout
            Me.TableLayoutPanelDefaultsNotes_TableLayout.SuspendLayout
            Me.PanelRightColumn_DefaultsNotes.SuspendLayout
            CType(Me.NumericInputDefaultNotes_VCCLimit.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxDefaultNotes_Terms.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxDefaultNotes_DefaultBank.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxDefaultNotes_DefaultFunction.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit
            Me.PanelLeftColumn_DefaultsNotes.SuspendLayout
            CType(Me.SearchableComboBoxDefaultNotes_Office.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxDefaultNotes_Currency.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlPanelContractsTab_Contracts.SuspendLayout
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.SuspendLayout
            CType(Me.NumericInputServiceTax_Rate.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.DateTimePickerServiceTax_WaiverExpirationDate, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxServiceTax_Type.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxServiceTax_Code.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlPanel1099InfoTab_1099Info.SuspendLayout
            Me.TableLayoutPanel1099Info_TableLayout.SuspendLayout
            Me.Panel1099Info_RightColumn.SuspendLayout
            Me.Panel1099Info_LeftColumn.SuspendLayout
            Me.TabControlPanelMediaInfoTab_MediaInfo.SuspendLayout
            Me.PanelMediaInfo_Magazine.SuspendLayout
            CType(Me.NumericInputMagazine_Issues.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputMagazine_Circulation.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            Me.PanelMediaInfo_Newspaper.SuspendLayout
            CType(Me.NumericInputNewspaper_DailyCirculation.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputNewspaper_SundayCirculation.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.SuspendLayout
            Me.TableLayoutPanelMediaDelivery_TableLayout.SuspendLayout
            Me.PanelMediaDelivery_RightColumn.SuspendLayout
            Me.PanelMediaDelivery_LeftColumn.SuspendLayout
            CType(Me.GroupBoxMediaDelivery_MediaShipping, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxMediaDelivery_MediaShipping.SuspendLayout
            Me.TabControlPanelDocumentsTab_Documents.SuspendLayout
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.SuspendLayout
            CType(Me.SearchableComboBoxMediaSpecs_DefaultSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView10, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.TreeListControlMediaSpecs_MediaSpecs, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlPanelPricingsTab_Pricings.SuspendLayout
            CType(Me.SearchableComboBoxMain_QuickBooksVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView17, System.ComponentModel.ISupportInitialize).BeginInit
            Me.SuspendLayout
            '
            'TabControlControl_VendorDetails
            '
            Me.TabControlControl_VendorDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlControl_VendorDetails.CanReorderTabs = False
            Me.TabControlControl_VendorDetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlControl_VendorDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlControl_VendorDetails.Controls.Add(Me.TabControlPanelMainTab_Main)
            Me.TabControlControl_VendorDetails.Controls.Add(Me.TabControlPanelMediaDefaultsTab_MediaDefaults)
            Me.TabControlControl_VendorDetails.Controls.Add(Me.TabControlPanelContactsTab_Contacts)
            Me.TabControlControl_VendorDetails.Controls.Add(Me.TabControlPanelRepresentativesTab_Representatives)
            Me.TabControlControl_VendorDetails.Controls.Add(Me.TabControlPanelEEOC2Tab_EEOC2)
            Me.TabControlControl_VendorDetails.Controls.Add(Me.TabControlPanelEEOCStatusTab_EEOCStatus)
            Me.TabControlControl_VendorDetails.Controls.Add(Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes)
            Me.TabControlControl_VendorDetails.Controls.Add(Me.TabControlPanelContractsTab_Contracts)
            Me.TabControlControl_VendorDetails.Controls.Add(Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax)
            Me.TabControlControl_VendorDetails.Controls.Add(Me.TabControlPanel1099InfoTab_1099Info)
            Me.TabControlControl_VendorDetails.Controls.Add(Me.TabControlPanelMediaInfoTab_MediaInfo)
            Me.TabControlControl_VendorDetails.Controls.Add(Me.TabControlPanelMediaDeliveryTab_MediaDelivery)
            Me.TabControlControl_VendorDetails.Controls.Add(Me.TabControlPanelDocumentsTab_Documents)
            Me.TabControlControl_VendorDetails.Controls.Add(Me.TabControlPanelMediaSpecsTab_MediaSpecs)
            Me.TabControlControl_VendorDetails.Controls.Add(Me.TabControlPanelPricingsTab_Pricings)
            Me.TabControlControl_VendorDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_VendorDetails.ForeColor = System.Drawing.Color.Black
            Me.TabControlControl_VendorDetails.Location = New System.Drawing.Point(0, 0)
            Me.TabControlControl_VendorDetails.Name = "TabControlControl_VendorDetails"
            Me.TabControlControl_VendorDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_VendorDetails.SelectedTabIndex = 0
            Me.TabControlControl_VendorDetails.Size = New System.Drawing.Size(815, 540)
            Me.TabControlControl_VendorDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_VendorDetails.TabIndex = 14
            Me.TabControlControl_VendorDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_VendorDetails.Tabs.Add(Me.TabItemVendorDetails_MainTab)
            Me.TabControlControl_VendorDetails.Tabs.Add(Me.TabItemVendorDetails_DefaultsNotesTab)
            Me.TabControlControl_VendorDetails.Tabs.Add(Me.TabItemVendorDetails_EEOCStatusTab)
            Me.TabControlControl_VendorDetails.Tabs.Add(Me.TabItemVendorDetails_EEOC2Tab)
            Me.TabControlControl_VendorDetails.Tabs.Add(Me.TabItemVendorDetails_1099InfoTab)
            Me.TabControlControl_VendorDetails.Tabs.Add(Me.TabItemVendorDetails_ContactsTab)
            Me.TabControlControl_VendorDetails.Tabs.Add(Me.TabItemVendorDetails_RepresentativesTab)
            Me.TabControlControl_VendorDetails.Tabs.Add(Me.TabItemVendorDetails_MediaDefaultsTab)
            Me.TabControlControl_VendorDetails.Tabs.Add(Me.TabItemVendorDetails_MediaInfoTab)
            Me.TabControlControl_VendorDetails.Tabs.Add(Me.TabItemVendorDetails_MediaDeliveryTab)
            Me.TabControlControl_VendorDetails.Tabs.Add(Me.TabItemVendorDetails_MediaSpecsTab)
            Me.TabControlControl_VendorDetails.Tabs.Add(Me.TabItemVendorDetails_PricingsTab)
            Me.TabControlControl_VendorDetails.Tabs.Add(Me.TabItemVendorDetails_VendorServiceTaxTab)
            Me.TabControlControl_VendorDetails.Tabs.Add(Me.TabItemVendorDetails_DocumentsTab)
            Me.TabControlControl_VendorDetails.Tabs.Add(Me.TabItemVendorDetails_ContractsTab)
            Me.TabControlControl_VendorDetails.Text = "TabControl1"
            '
            'TabControlPanelMediaDefaultsTab_MediaDefaults
            '
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Controls.Add(Me.TabControlMediaDefaults_MediaDefaultsTab)
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Name = "TabControlPanelMediaDefaultsTab_MediaDefaults"
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Size = New System.Drawing.Size(815, 513)
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Style.GradientAngle = 90
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.TabIndex = 5
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.TabItem = Me.TabItemVendorDetails_MediaDefaultsTab
            '
            'TabControlMediaDefaults_MediaDefaultsTab
            '
            Me.TabControlMediaDefaults_MediaDefaultsTab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlMediaDefaults_MediaDefaultsTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlMediaDefaults_MediaDefaultsTab.CanReorderTabs = False
            Me.TabControlMediaDefaults_MediaDefaultsTab.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlMediaDefaults_MediaDefaultsTab.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlMediaDefaults_MediaDefaultsTab.Controls.Add(Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation)
            Me.TabControlMediaDefaults_MediaDefaultsTab.Controls.Add(Me.TabControlPanelDefaultCommentsTab_DefaultComments)
            Me.TabControlMediaDefaults_MediaDefaultsTab.ForeColor = System.Drawing.Color.Black
            Me.TabControlMediaDefaults_MediaDefaultsTab.Location = New System.Drawing.Point(6, 6)
            Me.TabControlMediaDefaults_MediaDefaultsTab.Name = "TabControlMediaDefaults_MediaDefaultsTab"
            Me.TabControlMediaDefaults_MediaDefaultsTab.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlMediaDefaults_MediaDefaultsTab.SelectedTabIndex = 0
            Me.TabControlMediaDefaults_MediaDefaultsTab.Size = New System.Drawing.Size(803, 501)
            Me.TabControlMediaDefaults_MediaDefaultsTab.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlMediaDefaults_MediaDefaultsTab.TabIndex = 0
            Me.TabControlMediaDefaults_MediaDefaultsTab.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlMediaDefaults_MediaDefaultsTab.Tabs.Add(Me.TabItemMediaDefaults_GeneralDefaultInformationTab)
            Me.TabControlMediaDefaults_MediaDefaultsTab.Tabs.Add(Me.TabItemMediaDefaults_DefaultCommentsTab)
            Me.TabControlMediaDefaults_MediaDefaultsTab.Text = "TabControl1"
            '
            'TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation
            '
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.Controls.Add(Me.TableLayoutPanelGeneralDefaultInformation_TableLayout)
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.Name = "TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation"
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.Size = New System.Drawing.Size(803, 474)
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.Style.GradientAngle = 90
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.TabIndex = 1
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.TabItem = Me.TabItemMediaDefaults_GeneralDefaultInformationTab
            '
            'TableLayoutPanelGeneralDefaultInformation_TableLayout
            '
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout.ColumnCount = 2
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.11347!))
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.88652!))
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout.Controls.Add(Me.PanelTableLayout_RightColumn, 1, 0)
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout.Controls.Add(Me.PanelTableLayout_LeftColumn, 0, 0)
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout.Location = New System.Drawing.Point(4, 4)
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout.Name = "TableLayoutPanelGeneralDefaultInformation_TableLayout"
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout.RowCount = 1
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout.Size = New System.Drawing.Size(794, 450)
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout.TabIndex = 0
            '
            'PanelTableLayout_RightColumn
            '
            Me.PanelTableLayout_RightColumn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.PanelRates_Rates)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.PanelUnits_Units)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelDeadlines_MaterialCloseDays)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelDeadlines_SpaceCloseDays)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.NumericInputDeadlines_SpaceCloseDays)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.NumericInputDeadlines_MaterialCloseDays)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelGeneralDefaultInformation_Rates)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelGeneralDefaultInformation_Deadlines)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelGeneralDefaultInformation_Units)
            Me.PanelTableLayout_RightColumn.Location = New System.Drawing.Point(509, 0)
            Me.PanelTableLayout_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTableLayout_RightColumn.Name = "PanelTableLayout_RightColumn"
            Me.PanelTableLayout_RightColumn.Size = New System.Drawing.Size(285, 450)
            Me.PanelTableLayout_RightColumn.TabIndex = 1
            '
            'PanelRates_Rates
            '
            Me.PanelRates_Rates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelRates_Rates.BackColor = System.Drawing.Color.White
            Me.PanelRates_Rates.Controls.Add(Me.RadioButtonControlRates_Net)
            Me.PanelRates_Rates.Controls.Add(Me.RadioButtonControlRates_Gross)
            Me.PanelRates_Rates.Location = New System.Drawing.Point(3, 214)
            Me.PanelRates_Rates.Name = "PanelRates_Rates"
            Me.PanelRates_Rates.Size = New System.Drawing.Size(276, 80)
            Me.PanelRates_Rates.TabIndex = 43
            '
            'RadioButtonControlRates_Net
            '
            Me.RadioButtonControlRates_Net.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlRates_Net.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlRates_Net.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlRates_Net.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlRates_Net.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonControlRates_Net.Name = "RadioButtonControlRates_Net"
            Me.RadioButtonControlRates_Net.SecurityEnabled = True
            Me.RadioButtonControlRates_Net.Size = New System.Drawing.Size(273, 20)
            Me.RadioButtonControlRates_Net.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlRates_Net.TabIndex = 10
            Me.RadioButtonControlRates_Net.TabOnEnter = True
            Me.RadioButtonControlRates_Net.TabStop = False
            Me.RadioButtonControlRates_Net.Text = "Net"
            '
            'RadioButtonControlRates_Gross
            '
            Me.RadioButtonControlRates_Gross.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlRates_Gross.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlRates_Gross.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlRates_Gross.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlRates_Gross.Location = New System.Drawing.Point(0, 26)
            Me.RadioButtonControlRates_Gross.Name = "RadioButtonControlRates_Gross"
            Me.RadioButtonControlRates_Gross.SecurityEnabled = True
            Me.RadioButtonControlRates_Gross.Size = New System.Drawing.Size(273, 20)
            Me.RadioButtonControlRates_Gross.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlRates_Gross.TabIndex = 11
            Me.RadioButtonControlRates_Gross.TabOnEnter = True
            Me.RadioButtonControlRates_Gross.TabStop = False
            Me.RadioButtonControlRates_Gross.Text = "Gross"
            '
            'PanelUnits_Units
            '
            Me.PanelUnits_Units.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelUnits_Units.BackColor = System.Drawing.Color.White
            Me.PanelUnits_Units.Controls.Add(Me.RadioButtonControlUnits_MontlyOrBroadcastMonth)
            Me.PanelUnits_Units.Controls.Add(Me.RadioButtonControlUnits_WeeklyOrCalendarMonth)
            Me.PanelUnits_Units.Controls.Add(Me.RadioButtonControlUnits_Daily)
            Me.PanelUnits_Units.Location = New System.Drawing.Point(3, 26)
            Me.PanelUnits_Units.Name = "PanelUnits_Units"
            Me.PanelUnits_Units.Size = New System.Drawing.Size(276, 72)
            Me.PanelUnits_Units.TabIndex = 38
            '
            'RadioButtonControlUnits_MontlyOrBroadcastMonth
            '
            Me.RadioButtonControlUnits_MontlyOrBroadcastMonth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlUnits_MontlyOrBroadcastMonth.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlUnits_MontlyOrBroadcastMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlUnits_MontlyOrBroadcastMonth.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlUnits_MontlyOrBroadcastMonth.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonControlUnits_MontlyOrBroadcastMonth.Name = "RadioButtonControlUnits_MontlyOrBroadcastMonth"
            Me.RadioButtonControlUnits_MontlyOrBroadcastMonth.SecurityEnabled = True
            Me.RadioButtonControlUnits_MontlyOrBroadcastMonth.Size = New System.Drawing.Size(257, 20)
            Me.RadioButtonControlUnits_MontlyOrBroadcastMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlUnits_MontlyOrBroadcastMonth.TabIndex = 1
            Me.RadioButtonControlUnits_MontlyOrBroadcastMonth.TabOnEnter = True
            Me.RadioButtonControlUnits_MontlyOrBroadcastMonth.TabStop = False
            Me.RadioButtonControlUnits_MontlyOrBroadcastMonth.Text = "Monthly Or Broadcast Month"
            '
            'RadioButtonControlUnits_WeeklyOrCalendarMonth
            '
            Me.RadioButtonControlUnits_WeeklyOrCalendarMonth.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlUnits_WeeklyOrCalendarMonth.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlUnits_WeeklyOrCalendarMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlUnits_WeeklyOrCalendarMonth.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlUnits_WeeklyOrCalendarMonth.Location = New System.Drawing.Point(0, 26)
            Me.RadioButtonControlUnits_WeeklyOrCalendarMonth.Name = "RadioButtonControlUnits_WeeklyOrCalendarMonth"
            Me.RadioButtonControlUnits_WeeklyOrCalendarMonth.SecurityEnabled = True
            Me.RadioButtonControlUnits_WeeklyOrCalendarMonth.Size = New System.Drawing.Size(257, 20)
            Me.RadioButtonControlUnits_WeeklyOrCalendarMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlUnits_WeeklyOrCalendarMonth.TabIndex = 2
            Me.RadioButtonControlUnits_WeeklyOrCalendarMonth.TabOnEnter = True
            Me.RadioButtonControlUnits_WeeklyOrCalendarMonth.TabStop = False
            Me.RadioButtonControlUnits_WeeklyOrCalendarMonth.Text = "Weekly Or Calendar Month"
            '
            'RadioButtonControlUnits_Daily
            '
            Me.RadioButtonControlUnits_Daily.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlUnits_Daily.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlUnits_Daily.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlUnits_Daily.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlUnits_Daily.Location = New System.Drawing.Point(0, 52)
            Me.RadioButtonControlUnits_Daily.Name = "RadioButtonControlUnits_Daily"
            Me.RadioButtonControlUnits_Daily.SecurityEnabled = True
            Me.RadioButtonControlUnits_Daily.Size = New System.Drawing.Size(257, 20)
            Me.RadioButtonControlUnits_Daily.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlUnits_Daily.TabIndex = 3
            Me.RadioButtonControlUnits_Daily.TabOnEnter = True
            Me.RadioButtonControlUnits_Daily.TabStop = False
            Me.RadioButtonControlUnits_Daily.Text = "Daily Or 4 Week"
            '
            'LabelDeadlines_MaterialCloseDays
            '
            Me.LabelDeadlines_MaterialCloseDays.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDeadlines_MaterialCloseDays.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelDeadlines_MaterialCloseDays.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDeadlines_MaterialCloseDays.Location = New System.Drawing.Point(3, 136)
            Me.LabelDeadlines_MaterialCloseDays.Name = "LabelDeadlines_MaterialCloseDays"
            Me.LabelDeadlines_MaterialCloseDays.Size = New System.Drawing.Size(118, 20)
            Me.LabelDeadlines_MaterialCloseDays.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDeadlines_MaterialCloseDays.TabIndex = 39
            Me.LabelDeadlines_MaterialCloseDays.Text = "Material Close Days:"
            '
            'LabelDeadlines_SpaceCloseDays
            '
            Me.LabelDeadlines_SpaceCloseDays.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDeadlines_SpaceCloseDays.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelDeadlines_SpaceCloseDays.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDeadlines_SpaceCloseDays.Location = New System.Drawing.Point(3, 162)
            Me.LabelDeadlines_SpaceCloseDays.Name = "LabelDeadlines_SpaceCloseDays"
            Me.LabelDeadlines_SpaceCloseDays.Size = New System.Drawing.Size(118, 20)
            Me.LabelDeadlines_SpaceCloseDays.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDeadlines_SpaceCloseDays.TabIndex = 41
            Me.LabelDeadlines_SpaceCloseDays.Text = "Space Close Days:"
            '
            'NumericInputDeadlines_SpaceCloseDays
            '
            Me.NumericInputDeadlines_SpaceCloseDays.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDeadlines_SpaceCloseDays.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputDeadlines_SpaceCloseDays.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputDeadlines_SpaceCloseDays.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDeadlines_SpaceCloseDays.EnterMoveNextControl = True
            Me.NumericInputDeadlines_SpaceCloseDays.Location = New System.Drawing.Point(130, 162)
            Me.NumericInputDeadlines_SpaceCloseDays.Name = "NumericInputDeadlines_SpaceCloseDays"
            Me.NumericInputDeadlines_SpaceCloseDays.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputDeadlines_SpaceCloseDays.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDeadlines_SpaceCloseDays.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputDeadlines_SpaceCloseDays.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDeadlines_SpaceCloseDays.Properties.IsFloatValue = False
            Me.NumericInputDeadlines_SpaceCloseDays.Properties.Mask.EditMask = "f0"
            Me.NumericInputDeadlines_SpaceCloseDays.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDeadlines_SpaceCloseDays.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputDeadlines_SpaceCloseDays.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputDeadlines_SpaceCloseDays.SecurityEnabled = True
            Me.NumericInputDeadlines_SpaceCloseDays.Size = New System.Drawing.Size(155, 20)
            Me.NumericInputDeadlines_SpaceCloseDays.TabIndex = 42
            '
            'NumericInputDeadlines_MaterialCloseDays
            '
            Me.NumericInputDeadlines_MaterialCloseDays.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDeadlines_MaterialCloseDays.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputDeadlines_MaterialCloseDays.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputDeadlines_MaterialCloseDays.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDeadlines_MaterialCloseDays.EnterMoveNextControl = True
            Me.NumericInputDeadlines_MaterialCloseDays.Location = New System.Drawing.Point(130, 136)
            Me.NumericInputDeadlines_MaterialCloseDays.Name = "NumericInputDeadlines_MaterialCloseDays"
            Me.NumericInputDeadlines_MaterialCloseDays.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputDeadlines_MaterialCloseDays.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDeadlines_MaterialCloseDays.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputDeadlines_MaterialCloseDays.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDeadlines_MaterialCloseDays.Properties.IsFloatValue = False
            Me.NumericInputDeadlines_MaterialCloseDays.Properties.Mask.EditMask = "f0"
            Me.NumericInputDeadlines_MaterialCloseDays.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDeadlines_MaterialCloseDays.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputDeadlines_MaterialCloseDays.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputDeadlines_MaterialCloseDays.SecurityEnabled = True
            Me.NumericInputDeadlines_MaterialCloseDays.Size = New System.Drawing.Size(155, 20)
            Me.NumericInputDeadlines_MaterialCloseDays.TabIndex = 40
            '
            'LabelGeneralDefaultInformation_Rates
            '
            Me.LabelGeneralDefaultInformation_Rates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneralDefaultInformation_Rates.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_Rates.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGeneralDefaultInformation_Rates.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
            Me.LabelGeneralDefaultInformation_Rates.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelGeneralDefaultInformation_Rates.BackgroundStyle.BorderColor = System.Drawing.Color.Black
            Me.LabelGeneralDefaultInformation_Rates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_Rates.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGeneralDefaultInformation_Rates.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelGeneralDefaultInformation_Rates.Location = New System.Drawing.Point(3, 188)
            Me.LabelGeneralDefaultInformation_Rates.Name = "LabelGeneralDefaultInformation_Rates"
            Me.LabelGeneralDefaultInformation_Rates.Size = New System.Drawing.Size(282, 20)
            Me.LabelGeneralDefaultInformation_Rates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_Rates.TabIndex = 9
            Me.LabelGeneralDefaultInformation_Rates.Text = "Rates"
            '
            'LabelGeneralDefaultInformation_Deadlines
            '
            Me.LabelGeneralDefaultInformation_Deadlines.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneralDefaultInformation_Deadlines.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_Deadlines.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGeneralDefaultInformation_Deadlines.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
            Me.LabelGeneralDefaultInformation_Deadlines.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelGeneralDefaultInformation_Deadlines.BackgroundStyle.BorderColor = System.Drawing.Color.Black
            Me.LabelGeneralDefaultInformation_Deadlines.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_Deadlines.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGeneralDefaultInformation_Deadlines.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelGeneralDefaultInformation_Deadlines.Location = New System.Drawing.Point(3, 110)
            Me.LabelGeneralDefaultInformation_Deadlines.Name = "LabelGeneralDefaultInformation_Deadlines"
            Me.LabelGeneralDefaultInformation_Deadlines.Size = New System.Drawing.Size(282, 20)
            Me.LabelGeneralDefaultInformation_Deadlines.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_Deadlines.TabIndex = 4
            Me.LabelGeneralDefaultInformation_Deadlines.Text = "Deadlines"
            '
            'LabelGeneralDefaultInformation_Units
            '
            Me.LabelGeneralDefaultInformation_Units.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneralDefaultInformation_Units.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_Units.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGeneralDefaultInformation_Units.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
            Me.LabelGeneralDefaultInformation_Units.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelGeneralDefaultInformation_Units.BackgroundStyle.BorderColor = System.Drawing.Color.Black
            Me.LabelGeneralDefaultInformation_Units.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_Units.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGeneralDefaultInformation_Units.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelGeneralDefaultInformation_Units.Location = New System.Drawing.Point(3, 0)
            Me.LabelGeneralDefaultInformation_Units.Name = "LabelGeneralDefaultInformation_Units"
            Me.LabelGeneralDefaultInformation_Units.Size = New System.Drawing.Size(282, 20)
            Me.LabelGeneralDefaultInformation_Units.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_Units.TabIndex = 0
            Me.LabelGeneralDefaultInformation_Units.Text = "Units"
            '
            'PanelTableLayout_LeftColumn
            '
            Me.PanelTableLayout_LeftColumn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.ComboBoxGeneralDefaultInformation_CanadianVendorType)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelGeneralDefaultInformation_CanadianVendorType)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelMediaDefaults_Financial)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.ComboBoxGeneralDefaultInformation_Band)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelGeneralDefaultInformation_Band)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.TextBoxGeneralDefaultInformation_CallLetters)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelGeneralDefaultInformation_CallLetters)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.CheckBoxIsComscoreSubscriber)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.CheckBoxIsNielsenSubscriber)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelRatingsSubscriber)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelMediaDefaults_CrossReference)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelGeneralDefaultInformation_ComscoreStation)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelGeneralDefaultInformation_EastlanStation)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelGeneralDefaultInformation_CableSyscode)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.SearchableComboBoxGeneralDefaultInformation_RadioStation)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.SearchableComboBoxGeneralDefaultInformation_TVStation)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelGeneralDefaultInformation_Station)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.CheckBoxGeneralDefaultInformation_IsCableSystem)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelGeneralDefaultInformation_IsCableSystem)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelGeneralDefaultInformation_MarkupPercent)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.NumericInputGeneralDefaultInformation_MarkupPercent)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.SearchableComboBoxGeneralDefaultInformation_TaxCode)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.SearchableComboBoxGeneralDefaultInformation_Market)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelGeneralDefaultInformation_Market)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelGeneralDefaultInformation_CommissionPercent)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelGeneralDefaultInformation_ApplyTo)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.CheckBoxApplyTo_NetDiscount)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelGeneralDefaultInformation_OveragePercent)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.CheckBoxApplyTo_AddlCharge)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelGeneralDefaultInformation_TaxCode)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.CheckBoxApplyTo_Rebate)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelGeneralDefaultInformation_ColumnWidth)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.CheckBoxApplyTo_NetCharge)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.CheckBoxApplyTo_Commission)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.CheckBoxApplyTo_LineNet)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.NumericInputGeneralDefaultInformation_ColumnWidth)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.CheckBoxApplyTo_UseFlags)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.NumericInputGeneralDefaultInformation_OveragePercent)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.NumericInputGeneralDefaultInformation_CommissionPercent)
            Me.PanelTableLayout_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelTableLayout_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTableLayout_LeftColumn.Name = "PanelTableLayout_LeftColumn"
            Me.PanelTableLayout_LeftColumn.Size = New System.Drawing.Size(509, 450)
            Me.PanelTableLayout_LeftColumn.TabIndex = 0
            '
            'ComboBoxGeneralDefaultInformation_CanadianVendorType
            '
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.AutoFindItemInDataSource = False
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.BookmarkingEnabled = False
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.ClientCode = ""
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.DisableMouseWheel = False
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.DisplayMember = "Description"
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.DisplayName = ""
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.DivisionCode = ""
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.FocusHighlightEnabled = True
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.FormattingEnabled = True
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.ItemHeight = 15
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.Location = New System.Drawing.Point(348, 52)
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.Name = "ComboBoxGeneralDefaultInformation_CanadianVendorType"
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.ReadOnly = False
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.SecurityEnabled = True
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.Size = New System.Drawing.Size(158, 21)
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.TabIndex = 11
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.TabOnEnter = True
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.ValueMember = "Code"
            Me.ComboBoxGeneralDefaultInformation_CanadianVendorType.WatermarkText = "Select"
            '
            'LabelGeneralDefaultInformation_CanadianVendorType
            '
            Me.LabelGeneralDefaultInformation_CanadianVendorType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_CanadianVendorType.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelGeneralDefaultInformation_CanadianVendorType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_CanadianVendorType.Location = New System.Drawing.Point(199, 52)
            Me.LabelGeneralDefaultInformation_CanadianVendorType.Name = "LabelGeneralDefaultInformation_CanadianVendorType"
            Me.LabelGeneralDefaultInformation_CanadianVendorType.Size = New System.Drawing.Size(141, 20)
            Me.LabelGeneralDefaultInformation_CanadianVendorType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_CanadianVendorType.TabIndex = 10
            Me.LabelGeneralDefaultInformation_CanadianVendorType.Text = "Canadian Vendor Type:"
            '
            'LabelMediaDefaults_Financial
            '
            Me.LabelMediaDefaults_Financial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelMediaDefaults_Financial.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDefaults_Financial.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelMediaDefaults_Financial.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
            Me.LabelMediaDefaults_Financial.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelMediaDefaults_Financial.BackgroundStyle.BorderColor = System.Drawing.Color.Black
            Me.LabelMediaDefaults_Financial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDefaults_Financial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelMediaDefaults_Financial.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelMediaDefaults_Financial.Location = New System.Drawing.Point(0, 208)
            Me.LabelMediaDefaults_Financial.Name = "LabelMediaDefaults_Financial"
            Me.LabelMediaDefaults_Financial.Size = New System.Drawing.Size(506, 20)
            Me.LabelMediaDefaults_Financial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDefaults_Financial.TabIndex = 23
            Me.LabelMediaDefaults_Financial.Text = "Financial:"
            '
            'ComboBoxGeneralDefaultInformation_Band
            '
            Me.ComboBoxGeneralDefaultInformation_Band.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneralDefaultInformation_Band.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneralDefaultInformation_Band.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneralDefaultInformation_Band.AutoFindItemInDataSource = False
            Me.ComboBoxGeneralDefaultInformation_Band.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneralDefaultInformation_Band.BookmarkingEnabled = False
            Me.ComboBoxGeneralDefaultInformation_Band.ClientCode = ""
            Me.ComboBoxGeneralDefaultInformation_Band.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxGeneralDefaultInformation_Band.DisableMouseWheel = False
            Me.ComboBoxGeneralDefaultInformation_Band.DisplayMember = "Name"
            Me.ComboBoxGeneralDefaultInformation_Band.DisplayName = ""
            Me.ComboBoxGeneralDefaultInformation_Band.DivisionCode = ""
            Me.ComboBoxGeneralDefaultInformation_Band.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneralDefaultInformation_Band.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxGeneralDefaultInformation_Band.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxGeneralDefaultInformation_Band.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneralDefaultInformation_Band.FocusHighlightEnabled = True
            Me.ComboBoxGeneralDefaultInformation_Band.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxGeneralDefaultInformation_Band.FormattingEnabled = True
            Me.ComboBoxGeneralDefaultInformation_Band.ItemHeight = 15
            Me.ComboBoxGeneralDefaultInformation_Band.Location = New System.Drawing.Point(450, 26)
            Me.ComboBoxGeneralDefaultInformation_Band.Name = "ComboBoxGeneralDefaultInformation_Band"
            Me.ComboBoxGeneralDefaultInformation_Band.ReadOnly = False
            Me.ComboBoxGeneralDefaultInformation_Band.SecurityEnabled = True
            Me.ComboBoxGeneralDefaultInformation_Band.Size = New System.Drawing.Size(56, 21)
            Me.ComboBoxGeneralDefaultInformation_Band.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneralDefaultInformation_Band.TabIndex = 7
            Me.ComboBoxGeneralDefaultInformation_Band.TabOnEnter = True
            Me.ComboBoxGeneralDefaultInformation_Band.ValueMember = "Value"
            Me.ComboBoxGeneralDefaultInformation_Band.WatermarkText = "Select"
            '
            'LabelGeneralDefaultInformation_Band
            '
            Me.LabelGeneralDefaultInformation_Band.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_Band.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelGeneralDefaultInformation_Band.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_Band.Location = New System.Drawing.Point(410, 26)
            Me.LabelGeneralDefaultInformation_Band.Name = "LabelGeneralDefaultInformation_Band"
            Me.LabelGeneralDefaultInformation_Band.Size = New System.Drawing.Size(34, 20)
            Me.LabelGeneralDefaultInformation_Band.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_Band.TabIndex = 6
            Me.LabelGeneralDefaultInformation_Band.Text = "Band:"
            '
            'TextBoxGeneralDefaultInformation_CallLetters
            '
            Me.TextBoxGeneralDefaultInformation_CallLetters.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxGeneralDefaultInformation_CallLetters.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneralDefaultInformation_CallLetters.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneralDefaultInformation_CallLetters.CheckSpellingOnValidate = False
            Me.TextBoxGeneralDefaultInformation_CallLetters.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneralDefaultInformation_CallLetters.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxGeneralDefaultInformation_CallLetters.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneralDefaultInformation_CallLetters.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneralDefaultInformation_CallLetters.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneralDefaultInformation_CallLetters.FocusHighlightEnabled = True
            Me.TextBoxGeneralDefaultInformation_CallLetters.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneralDefaultInformation_CallLetters.Location = New System.Drawing.Point(347, 26)
            Me.TextBoxGeneralDefaultInformation_CallLetters.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneralDefaultInformation_CallLetters.Name = "TextBoxGeneralDefaultInformation_CallLetters"
            Me.TextBoxGeneralDefaultInformation_CallLetters.SecurityEnabled = True
            Me.TextBoxGeneralDefaultInformation_CallLetters.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneralDefaultInformation_CallLetters.Size = New System.Drawing.Size(57, 20)
            Me.TextBoxGeneralDefaultInformation_CallLetters.StartingFolderName = Nothing
            Me.TextBoxGeneralDefaultInformation_CallLetters.TabIndex = 5
            Me.TextBoxGeneralDefaultInformation_CallLetters.TabOnEnter = True
            '
            'LabelGeneralDefaultInformation_CallLetters
            '
            Me.LabelGeneralDefaultInformation_CallLetters.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_CallLetters.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelGeneralDefaultInformation_CallLetters.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_CallLetters.Location = New System.Drawing.Point(274, 26)
            Me.LabelGeneralDefaultInformation_CallLetters.Name = "LabelGeneralDefaultInformation_CallLetters"
            Me.LabelGeneralDefaultInformation_CallLetters.Size = New System.Drawing.Size(66, 20)
            Me.LabelGeneralDefaultInformation_CallLetters.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_CallLetters.TabIndex = 4
            Me.LabelGeneralDefaultInformation_CallLetters.Text = "Call Letters:"
            '
            'CheckBoxIsComscoreSubscriber
            '
            Me.CheckBoxIsComscoreSubscriber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxIsComscoreSubscriber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxIsComscoreSubscriber.CheckValue = 0
            Me.CheckBoxIsComscoreSubscriber.CheckValueChecked = 1
            Me.CheckBoxIsComscoreSubscriber.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxIsComscoreSubscriber.CheckValueUnchecked = 0
            Me.CheckBoxIsComscoreSubscriber.ChildControls = CType(resources.GetObject("CheckBoxIsComscoreSubscriber.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxIsComscoreSubscriber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxIsComscoreSubscriber.Location = New System.Drawing.Point(267, 104)
            Me.CheckBoxIsComscoreSubscriber.Name = "CheckBoxIsComscoreSubscriber"
            Me.CheckBoxIsComscoreSubscriber.OldestSibling = Nothing
            Me.CheckBoxIsComscoreSubscriber.SecurityEnabled = True
            Me.CheckBoxIsComscoreSubscriber.SiblingControls = CType(resources.GetObject("CheckBoxIsComscoreSubscriber.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxIsComscoreSubscriber.Size = New System.Drawing.Size(94, 20)
            Me.CheckBoxIsComscoreSubscriber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxIsComscoreSubscriber.TabIndex = 16
            Me.CheckBoxIsComscoreSubscriber.TabOnEnter = True
            Me.CheckBoxIsComscoreSubscriber.Text = "Comscore"
            '
            'CheckBoxIsNielsenSubscriber
            '
            Me.CheckBoxIsNielsenSubscriber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxIsNielsenSubscriber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxIsNielsenSubscriber.CheckValue = 0
            Me.CheckBoxIsNielsenSubscriber.CheckValueChecked = 1
            Me.CheckBoxIsNielsenSubscriber.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxIsNielsenSubscriber.CheckValueUnchecked = 0
            Me.CheckBoxIsNielsenSubscriber.ChildControls = CType(resources.GetObject("CheckBoxIsNielsenSubscriber.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxIsNielsenSubscriber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxIsNielsenSubscriber.Location = New System.Drawing.Point(167, 104)
            Me.CheckBoxIsNielsenSubscriber.Name = "CheckBoxIsNielsenSubscriber"
            Me.CheckBoxIsNielsenSubscriber.OldestSibling = Nothing
            Me.CheckBoxIsNielsenSubscriber.SecurityEnabled = True
            Me.CheckBoxIsNielsenSubscriber.SiblingControls = CType(resources.GetObject("CheckBoxIsNielsenSubscriber.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxIsNielsenSubscriber.Size = New System.Drawing.Size(94, 20)
            Me.CheckBoxIsNielsenSubscriber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxIsNielsenSubscriber.TabIndex = 15
            Me.CheckBoxIsNielsenSubscriber.TabOnEnter = True
            Me.CheckBoxIsNielsenSubscriber.Text = "Nielsen"
            '
            'LabelRatingsSubscriber
            '
            Me.LabelRatingsSubscriber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRatingsSubscriber.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelRatingsSubscriber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRatingsSubscriber.Location = New System.Drawing.Point(0, 104)
            Me.LabelRatingsSubscriber.Name = "LabelRatingsSubscriber"
            Me.LabelRatingsSubscriber.Size = New System.Drawing.Size(161, 20)
            Me.LabelRatingsSubscriber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRatingsSubscriber.TabIndex = 14
            Me.LabelRatingsSubscriber.Text = "Ratings Subscriber:"
            '
            'TextBoxGeneralDefaultInformation_VendorCodeCrossReference
            '
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.CheckSpellingOnValidate = False
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.FocusHighlightEnabled = True
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.Location = New System.Drawing.Point(167, 26)
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.Name = "TextBoxGeneralDefaultInformation_VendorCodeCrossReference"
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.SecurityEnabled = True
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.Size = New System.Drawing.Size(94, 20)
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.StartingFolderName = Nothing
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.TabIndex = 3
            Me.TextBoxGeneralDefaultInformation_VendorCodeCrossReference.TabOnEnter = True
            '
            'SearchableComboBoxGeneralDefaultInformation_ComscoreStation
            '
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.AutoFillMode = False
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.ComscoreTVStation
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.DataSource = Nothing
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.DisplayName = "Comscore Station"
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Location = New System.Drawing.Point(167, 156)
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Name = "SearchableComboBoxGeneralDefaultInformation_ComscoreStation"
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Properties.NullText = "Select TV Station"
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Properties.PopupView = Me.GridView14
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Properties.ValueMember = "ID"
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.SecurityEnabled = True
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Size = New System.Drawing.Size(339, 20)
            Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.TabIndex = 20
            '
            'GridView14
            '
            Me.GridView14.AFActiveFilterString = ""
            Me.GridView14.AllowExtraItemsInGridLookupEdits = True
            Me.GridView14.AutoFilterLookupColumns = False
            Me.GridView14.AutoloadRepositoryDatasource = True
            Me.GridView14.DataSourceClearing = False
            Me.GridView14.EnableDisabledRows = False
            Me.GridView14.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView14.Name = "GridView14"
            Me.GridView14.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView14.OptionsView.ShowGroupPanel = False
            Me.GridView14.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView14.RunStandardValidation = True
            Me.GridView14.SkipAddingControlsOnModifyColumn = False
            Me.GridView14.SkipSettingFontOnModifyColumn = False
            '
            'LabelMediaDefaults_CrossReference
            '
            Me.LabelMediaDefaults_CrossReference.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDefaults_CrossReference.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelMediaDefaults_CrossReference.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDefaults_CrossReference.Location = New System.Drawing.Point(0, 26)
            Me.LabelMediaDefaults_CrossReference.Name = "LabelMediaDefaults_CrossReference"
            Me.LabelMediaDefaults_CrossReference.Size = New System.Drawing.Size(161, 20)
            Me.LabelMediaDefaults_CrossReference.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDefaults_CrossReference.TabIndex = 2
            Me.LabelMediaDefaults_CrossReference.Text = "Vendor Code Cross Reference:"
            '
            'LabelGeneralDefaultInformation_ComscoreStation
            '
            Me.LabelGeneralDefaultInformation_ComscoreStation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_ComscoreStation.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelGeneralDefaultInformation_ComscoreStation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_ComscoreStation.Location = New System.Drawing.Point(0, 156)
            Me.LabelGeneralDefaultInformation_ComscoreStation.Name = "LabelGeneralDefaultInformation_ComscoreStation"
            Me.LabelGeneralDefaultInformation_ComscoreStation.Size = New System.Drawing.Size(91, 20)
            Me.LabelGeneralDefaultInformation_ComscoreStation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_ComscoreStation.TabIndex = 19
            Me.LabelGeneralDefaultInformation_ComscoreStation.Text = "Comscore Station:"
            '
            'SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation
            '
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.AutoFillMode = False
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.NielsenRadioStation
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.DataSource = Nothing
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.DisplayName = ""
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Location = New System.Drawing.Point(167, 182)
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Name = "SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation"
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Properties.NullText = "Select Radio Station"
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Properties.PopupView = Me.GridView15
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Properties.ValueMember = "ComboID"
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.SecurityEnabled = True
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Size = New System.Drawing.Size(339, 20)
            Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.TabIndex = 22
            '
            'GridView15
            '
            Me.GridView15.AFActiveFilterString = ""
            Me.GridView15.AllowExtraItemsInGridLookupEdits = True
            Me.GridView15.AutoFilterLookupColumns = False
            Me.GridView15.AutoloadRepositoryDatasource = True
            Me.GridView15.DataSourceClearing = False
            Me.GridView15.EnableDisabledRows = False
            Me.GridView15.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView15.Name = "GridView15"
            Me.GridView15.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView15.OptionsView.ShowGroupPanel = False
            Me.GridView15.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView15.RunStandardValidation = True
            Me.GridView15.SkipAddingControlsOnModifyColumn = False
            Me.GridView15.SkipSettingFontOnModifyColumn = False
            '
            'LabelGeneralDefaultInformation_EastlanStation
            '
            Me.LabelGeneralDefaultInformation_EastlanStation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_EastlanStation.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelGeneralDefaultInformation_EastlanStation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_EastlanStation.Location = New System.Drawing.Point(0, 182)
            Me.LabelGeneralDefaultInformation_EastlanStation.Name = "LabelGeneralDefaultInformation_EastlanStation"
            Me.LabelGeneralDefaultInformation_EastlanStation.Size = New System.Drawing.Size(91, 20)
            Me.LabelGeneralDefaultInformation_EastlanStation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_EastlanStation.TabIndex = 21
            Me.LabelGeneralDefaultInformation_EastlanStation.Text = "Eastlan Station:"
            '
            'SearchableComboBoxGeneralDefaultInformation_CableSyscode
            '
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.AutoFillMode = False
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.NCCTVSyscode
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.DataSource = Nothing
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.DisplayName = ""
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.EditValue = "11"
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.Location = New System.Drawing.Point(167, 78)
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.Name = "SearchableComboBoxGeneralDefaultInformation_CableSyscode"
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.Properties.NullText = "Select Syscode"
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.Properties.PopupView = Me.GridView13
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.Properties.ValueMember = "ID"
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.SecurityEnabled = True
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.SelectedValue = "11"
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.Size = New System.Drawing.Size(339, 20)
            Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.TabIndex = 13
            '
            'GridView13
            '
            Me.GridView13.AFActiveFilterString = ""
            Me.GridView13.AllowExtraItemsInGridLookupEdits = True
            Me.GridView13.AutoFilterLookupColumns = False
            Me.GridView13.AutoloadRepositoryDatasource = True
            Me.GridView13.DataSourceClearing = False
            Me.GridView13.EnableDisabledRows = False
            Me.GridView13.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView13.Name = "GridView13"
            Me.GridView13.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView13.OptionsView.ShowGroupPanel = False
            Me.GridView13.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView13.RunStandardValidation = True
            Me.GridView13.SkipAddingControlsOnModifyColumn = False
            Me.GridView13.SkipSettingFontOnModifyColumn = False
            '
            'LabelGeneralDefaultInformation_CableSyscode
            '
            Me.LabelGeneralDefaultInformation_CableSyscode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_CableSyscode.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelGeneralDefaultInformation_CableSyscode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_CableSyscode.Location = New System.Drawing.Point(1, 81)
            Me.LabelGeneralDefaultInformation_CableSyscode.Name = "LabelGeneralDefaultInformation_CableSyscode"
            Me.LabelGeneralDefaultInformation_CableSyscode.Size = New System.Drawing.Size(91, 20)
            Me.LabelGeneralDefaultInformation_CableSyscode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_CableSyscode.TabIndex = 12
            Me.LabelGeneralDefaultInformation_CableSyscode.Text = "Cable Syscode:"
            '
            'SearchableComboBoxGeneralDefaultInformation_RadioStation
            '
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.AutoFillMode = False
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.NielsenRadioStation
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.DataSource = Nothing
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.DisplayName = ""
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.Location = New System.Drawing.Point(167, 130)
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.Name = "SearchableComboBoxGeneralDefaultInformation_RadioStation"
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.Properties.NullText = "Select Radio Station"
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.Properties.PopupView = Me.GridView12
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.Properties.ValueMember = "ComboID"
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.SecurityEnabled = True
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.Size = New System.Drawing.Size(339, 20)
            Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.TabIndex = 18
            '
            'GridView12
            '
            Me.GridView12.AFActiveFilterString = ""
            Me.GridView12.AllowExtraItemsInGridLookupEdits = True
            Me.GridView12.AutoFilterLookupColumns = False
            Me.GridView12.AutoloadRepositoryDatasource = True
            Me.GridView12.DataSourceClearing = False
            Me.GridView12.EnableDisabledRows = False
            Me.GridView12.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView12.Name = "GridView12"
            Me.GridView12.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView12.OptionsView.ShowGroupPanel = False
            Me.GridView12.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView12.RunStandardValidation = True
            Me.GridView12.SkipAddingControlsOnModifyColumn = False
            Me.GridView12.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxGeneralDefaultInformation_TVStation
            '
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.AutoFillMode = False
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.NielsenTVStation
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.DataSource = Nothing
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.DisplayName = ""
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.Location = New System.Drawing.Point(167, 130)
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.Name = "SearchableComboBoxGeneralDefaultInformation_TVStation"
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.Properties.NullText = "Select TV Station"
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.Properties.PopupView = Me.GridView11
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.SecurityEnabled = True
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.Size = New System.Drawing.Size(339, 20)
            Me.SearchableComboBoxGeneralDefaultInformation_TVStation.TabIndex = 16
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
            'LabelGeneralDefaultInformation_Station
            '
            Me.LabelGeneralDefaultInformation_Station.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_Station.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelGeneralDefaultInformation_Station.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_Station.Location = New System.Drawing.Point(0, 130)
            Me.LabelGeneralDefaultInformation_Station.Name = "LabelGeneralDefaultInformation_Station"
            Me.LabelGeneralDefaultInformation_Station.Size = New System.Drawing.Size(91, 20)
            Me.LabelGeneralDefaultInformation_Station.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_Station.TabIndex = 17
            Me.LabelGeneralDefaultInformation_Station.Text = "Nielsen Station:"
            '
            'CheckBoxGeneralDefaultInformation_IsCableSystem
            '
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.CheckValue = 0
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.CheckValueChecked = 1
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.CheckValueUnchecked = 0
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.ChildControls = CType(resources.GetObject("CheckBoxGeneralDefaultInformation_IsCableSystem.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.Location = New System.Drawing.Point(167, 52)
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.Name = "CheckBoxGeneralDefaultInformation_IsCableSystem"
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.OldestSibling = Nothing
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.SecurityEnabled = True
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.SiblingControls = CType(resources.GetObject("CheckBoxGeneralDefaultInformation_IsCableSystem.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.Size = New System.Drawing.Size(26, 20)
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.TabIndex = 9
            Me.CheckBoxGeneralDefaultInformation_IsCableSystem.TabOnEnter = True
            '
            'LabelGeneralDefaultInformation_IsCableSystem
            '
            Me.LabelGeneralDefaultInformation_IsCableSystem.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_IsCableSystem.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelGeneralDefaultInformation_IsCableSystem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_IsCableSystem.Location = New System.Drawing.Point(0, 52)
            Me.LabelGeneralDefaultInformation_IsCableSystem.Name = "LabelGeneralDefaultInformation_IsCableSystem"
            Me.LabelGeneralDefaultInformation_IsCableSystem.Size = New System.Drawing.Size(161, 20)
            Me.LabelGeneralDefaultInformation_IsCableSystem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_IsCableSystem.TabIndex = 8
            Me.LabelGeneralDefaultInformation_IsCableSystem.Text = "Is Cable System:"
            '
            'LabelGeneralDefaultInformation_MarkupPercent
            '
            Me.LabelGeneralDefaultInformation_MarkupPercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_MarkupPercent.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelGeneralDefaultInformation_MarkupPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_MarkupPercent.Location = New System.Drawing.Point(0, 260)
            Me.LabelGeneralDefaultInformation_MarkupPercent.Name = "LabelGeneralDefaultInformation_MarkupPercent"
            Me.LabelGeneralDefaultInformation_MarkupPercent.Size = New System.Drawing.Size(99, 20)
            Me.LabelGeneralDefaultInformation_MarkupPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_MarkupPercent.TabIndex = 28
            Me.LabelGeneralDefaultInformation_MarkupPercent.Text = "Markup %:"
            '
            'NumericInputGeneralDefaultInformation_MarkupPercent
            '
            Me.NumericInputGeneralDefaultInformation_MarkupPercent.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputGeneralDefaultInformation_MarkupPercent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputGeneralDefaultInformation_MarkupPercent.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputGeneralDefaultInformation_MarkupPercent.EnterMoveNextControl = True
            Me.NumericInputGeneralDefaultInformation_MarkupPercent.Location = New System.Drawing.Point(166, 260)
            Me.NumericInputGeneralDefaultInformation_MarkupPercent.Name = "NumericInputGeneralDefaultInformation_MarkupPercent"
            Me.NumericInputGeneralDefaultInformation_MarkupPercent.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputGeneralDefaultInformation_MarkupPercent.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputGeneralDefaultInformation_MarkupPercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputGeneralDefaultInformation_MarkupPercent.Properties.EditFormat.FormatString = "f"
            Me.NumericInputGeneralDefaultInformation_MarkupPercent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputGeneralDefaultInformation_MarkupPercent.Properties.Mask.EditMask = "f"
            Me.NumericInputGeneralDefaultInformation_MarkupPercent.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputGeneralDefaultInformation_MarkupPercent.SecurityEnabled = True
            Me.NumericInputGeneralDefaultInformation_MarkupPercent.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputGeneralDefaultInformation_MarkupPercent.TabIndex = 29
            '
            'SearchableComboBoxGeneralDefaultInformation_TaxCode
            '
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.AutoFillMode = False
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.TaxCode
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.DataSource = Nothing
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.DisplayName = ""
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.Location = New System.Drawing.Point(166, 286)
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.Name = "SearchableComboBoxGeneralDefaultInformation_TaxCode"
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.Properties.NullText = "Select Tax Code"
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.Properties.PopupView = Me.GridView9
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.Properties.ValueMember = "TaxCode"
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.SecurityEnabled = True
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.Size = New System.Drawing.Size(339, 20)
            Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.TabIndex = 33
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
            'SearchableComboBoxGeneralDefaultInformation_Market
            '
            Me.SearchableComboBoxGeneralDefaultInformation_Market.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralDefaultInformation_Market.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxGeneralDefaultInformation_Market.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneralDefaultInformation_Market.AutoFillMode = False
            Me.SearchableComboBoxGeneralDefaultInformation_Market.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralDefaultInformation_Market.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Market
            Me.SearchableComboBoxGeneralDefaultInformation_Market.DataSource = Nothing
            Me.SearchableComboBoxGeneralDefaultInformation_Market.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralDefaultInformation_Market.DisplayName = ""
            Me.SearchableComboBoxGeneralDefaultInformation_Market.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneralDefaultInformation_Market.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneralDefaultInformation_Market.Location = New System.Drawing.Point(167, 0)
            Me.SearchableComboBoxGeneralDefaultInformation_Market.Name = "SearchableComboBoxGeneralDefaultInformation_Market"
            Me.SearchableComboBoxGeneralDefaultInformation_Market.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralDefaultInformation_Market.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGeneralDefaultInformation_Market.Properties.NullText = "Select Market"
            Me.SearchableComboBoxGeneralDefaultInformation_Market.Properties.PopupView = Me.GridView8
            Me.SearchableComboBoxGeneralDefaultInformation_Market.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneralDefaultInformation_Market.SecurityEnabled = True
            Me.SearchableComboBoxGeneralDefaultInformation_Market.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralDefaultInformation_Market.Size = New System.Drawing.Size(339, 20)
            Me.SearchableComboBoxGeneralDefaultInformation_Market.TabIndex = 1
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
            'LabelGeneralDefaultInformation_Market
            '
            Me.LabelGeneralDefaultInformation_Market.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_Market.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelGeneralDefaultInformation_Market.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_Market.Location = New System.Drawing.Point(0, 0)
            Me.LabelGeneralDefaultInformation_Market.Name = "LabelGeneralDefaultInformation_Market"
            Me.LabelGeneralDefaultInformation_Market.Size = New System.Drawing.Size(91, 20)
            Me.LabelGeneralDefaultInformation_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_Market.TabIndex = 0
            Me.LabelGeneralDefaultInformation_Market.Text = "Market:"
            '
            'LabelGeneralDefaultInformation_CommissionPercent
            '
            Me.LabelGeneralDefaultInformation_CommissionPercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_CommissionPercent.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelGeneralDefaultInformation_CommissionPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_CommissionPercent.Location = New System.Drawing.Point(0, 234)
            Me.LabelGeneralDefaultInformation_CommissionPercent.Name = "LabelGeneralDefaultInformation_CommissionPercent"
            Me.LabelGeneralDefaultInformation_CommissionPercent.Size = New System.Drawing.Size(92, 20)
            Me.LabelGeneralDefaultInformation_CommissionPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_CommissionPercent.TabIndex = 24
            Me.LabelGeneralDefaultInformation_CommissionPercent.Text = "Commission %:"
            '
            'LabelGeneralDefaultInformation_ApplyTo
            '
            Me.LabelGeneralDefaultInformation_ApplyTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneralDefaultInformation_ApplyTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_ApplyTo.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelGeneralDefaultInformation_ApplyTo.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
            Me.LabelGeneralDefaultInformation_ApplyTo.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelGeneralDefaultInformation_ApplyTo.BackgroundStyle.BorderColor = System.Drawing.Color.Black
            Me.LabelGeneralDefaultInformation_ApplyTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_ApplyTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGeneralDefaultInformation_ApplyTo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelGeneralDefaultInformation_ApplyTo.Location = New System.Drawing.Point(0, 338)
            Me.LabelGeneralDefaultInformation_ApplyTo.Name = "LabelGeneralDefaultInformation_ApplyTo"
            Me.LabelGeneralDefaultInformation_ApplyTo.Size = New System.Drawing.Size(506, 20)
            Me.LabelGeneralDefaultInformation_ApplyTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_ApplyTo.TabIndex = 34
            Me.LabelGeneralDefaultInformation_ApplyTo.Text = "Apply Tax To:"
            '
            'CheckBoxApplyTo_NetDiscount
            '
            Me.CheckBoxApplyTo_NetDiscount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxApplyTo_NetDiscount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplyTo_NetDiscount.CheckValue = 0
            Me.CheckBoxApplyTo_NetDiscount.CheckValueChecked = 1
            Me.CheckBoxApplyTo_NetDiscount.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplyTo_NetDiscount.CheckValueUnchecked = 0
            Me.CheckBoxApplyTo_NetDiscount.ChildControls = CType(resources.GetObject("CheckBoxApplyTo_NetDiscount.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplyTo_NetDiscount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplyTo_NetDiscount.Location = New System.Drawing.Point(213, 416)
            Me.CheckBoxApplyTo_NetDiscount.Name = "CheckBoxApplyTo_NetDiscount"
            Me.CheckBoxApplyTo_NetDiscount.OldestSibling = Nothing
            Me.CheckBoxApplyTo_NetDiscount.SecurityEnabled = True
            Me.CheckBoxApplyTo_NetDiscount.SiblingControls = CType(resources.GetObject("CheckBoxApplyTo_NetDiscount.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplyTo_NetDiscount.Size = New System.Drawing.Size(198, 20)
            Me.CheckBoxApplyTo_NetDiscount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplyTo_NetDiscount.TabIndex = 41
            Me.CheckBoxApplyTo_NetDiscount.TabOnEnter = True
            Me.CheckBoxApplyTo_NetDiscount.Text = "Net Discount"
            '
            'LabelGeneralDefaultInformation_OveragePercent
            '
            Me.LabelGeneralDefaultInformation_OveragePercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_OveragePercent.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelGeneralDefaultInformation_OveragePercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_OveragePercent.Location = New System.Drawing.Point(274, 234)
            Me.LabelGeneralDefaultInformation_OveragePercent.Name = "LabelGeneralDefaultInformation_OveragePercent"
            Me.LabelGeneralDefaultInformation_OveragePercent.Size = New System.Drawing.Size(91, 20)
            Me.LabelGeneralDefaultInformation_OveragePercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_OveragePercent.TabIndex = 26
            Me.LabelGeneralDefaultInformation_OveragePercent.Text = "Overage %:"
            '
            'CheckBoxApplyTo_AddlCharge
            '
            Me.CheckBoxApplyTo_AddlCharge.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxApplyTo_AddlCharge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplyTo_AddlCharge.CheckValue = 0
            Me.CheckBoxApplyTo_AddlCharge.CheckValueChecked = 1
            Me.CheckBoxApplyTo_AddlCharge.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplyTo_AddlCharge.CheckValueUnchecked = 0
            Me.CheckBoxApplyTo_AddlCharge.ChildControls = CType(resources.GetObject("CheckBoxApplyTo_AddlCharge.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplyTo_AddlCharge.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplyTo_AddlCharge.Location = New System.Drawing.Point(107, 416)
            Me.CheckBoxApplyTo_AddlCharge.Name = "CheckBoxApplyTo_AddlCharge"
            Me.CheckBoxApplyTo_AddlCharge.OldestSibling = Nothing
            Me.CheckBoxApplyTo_AddlCharge.SecurityEnabled = True
            Me.CheckBoxApplyTo_AddlCharge.SiblingControls = CType(resources.GetObject("CheckBoxApplyTo_AddlCharge.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplyTo_AddlCharge.Size = New System.Drawing.Size(100, 20)
            Me.CheckBoxApplyTo_AddlCharge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplyTo_AddlCharge.TabIndex = 40
            Me.CheckBoxApplyTo_AddlCharge.TabOnEnter = True
            Me.CheckBoxApplyTo_AddlCharge.Text = "Addl Charge"
            '
            'LabelGeneralDefaultInformation_TaxCode
            '
            Me.LabelGeneralDefaultInformation_TaxCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_TaxCode.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelGeneralDefaultInformation_TaxCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_TaxCode.Location = New System.Drawing.Point(0, 286)
            Me.LabelGeneralDefaultInformation_TaxCode.Name = "LabelGeneralDefaultInformation_TaxCode"
            Me.LabelGeneralDefaultInformation_TaxCode.Size = New System.Drawing.Size(91, 20)
            Me.LabelGeneralDefaultInformation_TaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_TaxCode.TabIndex = 32
            Me.LabelGeneralDefaultInformation_TaxCode.Text = "Tax Code:"
            '
            'CheckBoxApplyTo_Rebate
            '
            Me.CheckBoxApplyTo_Rebate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxApplyTo_Rebate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplyTo_Rebate.CheckValue = 0
            Me.CheckBoxApplyTo_Rebate.CheckValueChecked = 1
            Me.CheckBoxApplyTo_Rebate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplyTo_Rebate.CheckValueUnchecked = 0
            Me.CheckBoxApplyTo_Rebate.ChildControls = CType(resources.GetObject("CheckBoxApplyTo_Rebate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplyTo_Rebate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplyTo_Rebate.Location = New System.Drawing.Point(213, 390)
            Me.CheckBoxApplyTo_Rebate.Name = "CheckBoxApplyTo_Rebate"
            Me.CheckBoxApplyTo_Rebate.OldestSibling = Nothing
            Me.CheckBoxApplyTo_Rebate.SecurityEnabled = True
            Me.CheckBoxApplyTo_Rebate.SiblingControls = CType(resources.GetObject("CheckBoxApplyTo_Rebate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplyTo_Rebate.Size = New System.Drawing.Size(198, 20)
            Me.CheckBoxApplyTo_Rebate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplyTo_Rebate.TabIndex = 39
            Me.CheckBoxApplyTo_Rebate.TabOnEnter = True
            Me.CheckBoxApplyTo_Rebate.Text = "Rebate"
            '
            'LabelGeneralDefaultInformation_ColumnWidth
            '
            Me.LabelGeneralDefaultInformation_ColumnWidth.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralDefaultInformation_ColumnWidth.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelGeneralDefaultInformation_ColumnWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralDefaultInformation_ColumnWidth.Location = New System.Drawing.Point(274, 260)
            Me.LabelGeneralDefaultInformation_ColumnWidth.Name = "LabelGeneralDefaultInformation_ColumnWidth"
            Me.LabelGeneralDefaultInformation_ColumnWidth.Size = New System.Drawing.Size(91, 20)
            Me.LabelGeneralDefaultInformation_ColumnWidth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralDefaultInformation_ColumnWidth.TabIndex = 30
            Me.LabelGeneralDefaultInformation_ColumnWidth.Text = "Column Width:"
            '
            'CheckBoxApplyTo_NetCharge
            '
            Me.CheckBoxApplyTo_NetCharge.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxApplyTo_NetCharge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplyTo_NetCharge.CheckValue = 0
            Me.CheckBoxApplyTo_NetCharge.CheckValueChecked = 1
            Me.CheckBoxApplyTo_NetCharge.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplyTo_NetCharge.CheckValueUnchecked = 0
            Me.CheckBoxApplyTo_NetCharge.ChildControls = CType(resources.GetObject("CheckBoxApplyTo_NetCharge.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplyTo_NetCharge.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplyTo_NetCharge.Location = New System.Drawing.Point(107, 390)
            Me.CheckBoxApplyTo_NetCharge.Name = "CheckBoxApplyTo_NetCharge"
            Me.CheckBoxApplyTo_NetCharge.OldestSibling = Nothing
            Me.CheckBoxApplyTo_NetCharge.SecurityEnabled = True
            Me.CheckBoxApplyTo_NetCharge.SiblingControls = CType(resources.GetObject("CheckBoxApplyTo_NetCharge.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplyTo_NetCharge.Size = New System.Drawing.Size(100, 20)
            Me.CheckBoxApplyTo_NetCharge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplyTo_NetCharge.TabIndex = 38
            Me.CheckBoxApplyTo_NetCharge.TabOnEnter = True
            Me.CheckBoxApplyTo_NetCharge.Text = "Net Charge"
            '
            'CheckBoxApplyTo_Commission
            '
            Me.CheckBoxApplyTo_Commission.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxApplyTo_Commission.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplyTo_Commission.CheckValue = 0
            Me.CheckBoxApplyTo_Commission.CheckValueChecked = 1
            Me.CheckBoxApplyTo_Commission.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplyTo_Commission.CheckValueUnchecked = 0
            Me.CheckBoxApplyTo_Commission.ChildControls = CType(resources.GetObject("CheckBoxApplyTo_Commission.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplyTo_Commission.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplyTo_Commission.Location = New System.Drawing.Point(213, 364)
            Me.CheckBoxApplyTo_Commission.Name = "CheckBoxApplyTo_Commission"
            Me.CheckBoxApplyTo_Commission.OldestSibling = Nothing
            Me.CheckBoxApplyTo_Commission.SecurityEnabled = True
            Me.CheckBoxApplyTo_Commission.SiblingControls = CType(resources.GetObject("CheckBoxApplyTo_Commission.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplyTo_Commission.Size = New System.Drawing.Size(198, 20)
            Me.CheckBoxApplyTo_Commission.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplyTo_Commission.TabIndex = 37
            Me.CheckBoxApplyTo_Commission.TabOnEnter = True
            Me.CheckBoxApplyTo_Commission.Text = "Commission"
            '
            'CheckBoxApplyTo_LineNet
            '
            Me.CheckBoxApplyTo_LineNet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxApplyTo_LineNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplyTo_LineNet.CheckValue = 0
            Me.CheckBoxApplyTo_LineNet.CheckValueChecked = 1
            Me.CheckBoxApplyTo_LineNet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplyTo_LineNet.CheckValueUnchecked = 0
            Me.CheckBoxApplyTo_LineNet.ChildControls = CType(resources.GetObject("CheckBoxApplyTo_LineNet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplyTo_LineNet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplyTo_LineNet.Location = New System.Drawing.Point(107, 364)
            Me.CheckBoxApplyTo_LineNet.Name = "CheckBoxApplyTo_LineNet"
            Me.CheckBoxApplyTo_LineNet.OldestSibling = Nothing
            Me.CheckBoxApplyTo_LineNet.SecurityEnabled = True
            Me.CheckBoxApplyTo_LineNet.SiblingControls = CType(resources.GetObject("CheckBoxApplyTo_LineNet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplyTo_LineNet.Size = New System.Drawing.Size(100, 20)
            Me.CheckBoxApplyTo_LineNet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplyTo_LineNet.TabIndex = 36
            Me.CheckBoxApplyTo_LineNet.TabOnEnter = True
            Me.CheckBoxApplyTo_LineNet.Text = "Line Net"
            '
            'NumericInputGeneralDefaultInformation_ColumnWidth
            '
            Me.NumericInputGeneralDefaultInformation_ColumnWidth.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputGeneralDefaultInformation_ColumnWidth.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputGeneralDefaultInformation_ColumnWidth.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputGeneralDefaultInformation_ColumnWidth.EnterMoveNextControl = True
            Me.NumericInputGeneralDefaultInformation_ColumnWidth.Location = New System.Drawing.Point(409, 260)
            Me.NumericInputGeneralDefaultInformation_ColumnWidth.Name = "NumericInputGeneralDefaultInformation_ColumnWidth"
            Me.NumericInputGeneralDefaultInformation_ColumnWidth.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputGeneralDefaultInformation_ColumnWidth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputGeneralDefaultInformation_ColumnWidth.Properties.EditFormat.FormatString = "f"
            Me.NumericInputGeneralDefaultInformation_ColumnWidth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputGeneralDefaultInformation_ColumnWidth.Properties.Mask.EditMask = "f"
            Me.NumericInputGeneralDefaultInformation_ColumnWidth.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputGeneralDefaultInformation_ColumnWidth.SecurityEnabled = True
            Me.NumericInputGeneralDefaultInformation_ColumnWidth.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputGeneralDefaultInformation_ColumnWidth.TabIndex = 31
            '
            'CheckBoxApplyTo_UseFlags
            '
            Me.CheckBoxApplyTo_UseFlags.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxApplyTo_UseFlags.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxApplyTo_UseFlags.CheckValue = 0
            Me.CheckBoxApplyTo_UseFlags.CheckValueChecked = 1
            Me.CheckBoxApplyTo_UseFlags.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxApplyTo_UseFlags.CheckValueUnchecked = 0
            Me.CheckBoxApplyTo_UseFlags.ChildControls = CType(resources.GetObject("CheckBoxApplyTo_UseFlags.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplyTo_UseFlags.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxApplyTo_UseFlags.Location = New System.Drawing.Point(0, 364)
            Me.CheckBoxApplyTo_UseFlags.Name = "CheckBoxApplyTo_UseFlags"
            Me.CheckBoxApplyTo_UseFlags.OldestSibling = Nothing
            Me.CheckBoxApplyTo_UseFlags.SecurityEnabled = True
            Me.CheckBoxApplyTo_UseFlags.SiblingControls = CType(resources.GetObject("CheckBoxApplyTo_UseFlags.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxApplyTo_UseFlags.Size = New System.Drawing.Size(100, 20)
            Me.CheckBoxApplyTo_UseFlags.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxApplyTo_UseFlags.TabIndex = 35
            Me.CheckBoxApplyTo_UseFlags.TabOnEnter = True
            Me.CheckBoxApplyTo_UseFlags.Text = "Use Flags"
            '
            'NumericInputGeneralDefaultInformation_OveragePercent
            '
            Me.NumericInputGeneralDefaultInformation_OveragePercent.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputGeneralDefaultInformation_OveragePercent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputGeneralDefaultInformation_OveragePercent.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputGeneralDefaultInformation_OveragePercent.EnterMoveNextControl = True
            Me.NumericInputGeneralDefaultInformation_OveragePercent.Location = New System.Drawing.Point(409, 234)
            Me.NumericInputGeneralDefaultInformation_OveragePercent.Name = "NumericInputGeneralDefaultInformation_OveragePercent"
            Me.NumericInputGeneralDefaultInformation_OveragePercent.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputGeneralDefaultInformation_OveragePercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputGeneralDefaultInformation_OveragePercent.Properties.EditFormat.FormatString = "f"
            Me.NumericInputGeneralDefaultInformation_OveragePercent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputGeneralDefaultInformation_OveragePercent.Properties.Mask.EditMask = "f"
            Me.NumericInputGeneralDefaultInformation_OveragePercent.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputGeneralDefaultInformation_OveragePercent.SecurityEnabled = True
            Me.NumericInputGeneralDefaultInformation_OveragePercent.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputGeneralDefaultInformation_OveragePercent.TabIndex = 27
            '
            'NumericInputGeneralDefaultInformation_CommissionPercent
            '
            Me.NumericInputGeneralDefaultInformation_CommissionPercent.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputGeneralDefaultInformation_CommissionPercent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputGeneralDefaultInformation_CommissionPercent.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputGeneralDefaultInformation_CommissionPercent.EnterMoveNextControl = True
            Me.NumericInputGeneralDefaultInformation_CommissionPercent.Location = New System.Drawing.Point(166, 234)
            Me.NumericInputGeneralDefaultInformation_CommissionPercent.Name = "NumericInputGeneralDefaultInformation_CommissionPercent"
            Me.NumericInputGeneralDefaultInformation_CommissionPercent.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputGeneralDefaultInformation_CommissionPercent.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputGeneralDefaultInformation_CommissionPercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputGeneralDefaultInformation_CommissionPercent.Properties.EditFormat.FormatString = "f"
            Me.NumericInputGeneralDefaultInformation_CommissionPercent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputGeneralDefaultInformation_CommissionPercent.Properties.Mask.EditMask = "f"
            Me.NumericInputGeneralDefaultInformation_CommissionPercent.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputGeneralDefaultInformation_CommissionPercent.SecurityEnabled = True
            Me.NumericInputGeneralDefaultInformation_CommissionPercent.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputGeneralDefaultInformation_CommissionPercent.TabIndex = 25
            '
            'TabItemMediaDefaults_GeneralDefaultInformationTab
            '
            Me.TabItemMediaDefaults_GeneralDefaultInformationTab.AttachedControl = Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation
            Me.TabItemMediaDefaults_GeneralDefaultInformationTab.Name = "TabItemMediaDefaults_GeneralDefaultInformationTab"
            Me.TabItemMediaDefaults_GeneralDefaultInformationTab.Text = "General Default Information"
            '
            'TabControlPanelDefaultCommentsTab_DefaultComments
            '
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Controls.Add(Me.ButtonDefaultComments_CheckSpelling)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Controls.Add(Me.CheckBoxDefaultComments_UseFooterComment)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Controls.Add(Me.TextBoxDefaultComments_Instructions)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Controls.Add(Me.TextBoxDefaultComments_FooterComment)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Controls.Add(Me.TextBoxDefaultComments_RateInfo)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Controls.Add(Me.TextBoxDefaultComments_MaterialNotes)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Controls.Add(Me.TextBoxDefaultComments_PositionInfo)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Controls.Add(Me.TextBoxDefaultComments_MiscInfo)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Controls.Add(Me.TextBoxDefaultComments_CloseInfo)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Controls.Add(Me.LabelDefaultComments_FooterComment)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Controls.Add(Me.LabelDefaultComments_RateInfo)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Controls.Add(Me.LabelDefaultComments_MaterialNotes)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Controls.Add(Me.LabelDefaultComments_PositionInfo)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Controls.Add(Me.LabelDefaultComments_MiscInfo)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Controls.Add(Me.LabelDefaultComments_CloseInfo)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Controls.Add(Me.LabelDefaultComments_Instructions)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Name = "TabControlPanelDefaultCommentsTab_DefaultComments"
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Size = New System.Drawing.Size(803, 474)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.Style.GradientAngle = 90
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.TabIndex = 2
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.TabItem = Me.TabItemMediaDefaults_DefaultCommentsTab
            '
            'ButtonDefaultComments_CheckSpelling
            '
            Me.ButtonDefaultComments_CheckSpelling.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonDefaultComments_CheckSpelling.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonDefaultComments_CheckSpelling.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonDefaultComments_CheckSpelling.Location = New System.Drawing.Point(703, 450)
            Me.ButtonDefaultComments_CheckSpelling.Name = "ButtonDefaultComments_CheckSpelling"
            Me.ButtonDefaultComments_CheckSpelling.SecurityEnabled = True
            Me.ButtonDefaultComments_CheckSpelling.Size = New System.Drawing.Size(96, 20)
            Me.ButtonDefaultComments_CheckSpelling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonDefaultComments_CheckSpelling.TabIndex = 15
            Me.ButtonDefaultComments_CheckSpelling.Text = "Check Spelling"
            '
            'CheckBoxDefaultComments_UseFooterComment
            '
            Me.CheckBoxDefaultComments_UseFooterComment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDefaultComments_UseFooterComment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDefaultComments_UseFooterComment.CheckValue = 0
            Me.CheckBoxDefaultComments_UseFooterComment.CheckValueChecked = 1
            Me.CheckBoxDefaultComments_UseFooterComment.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDefaultComments_UseFooterComment.CheckValueUnchecked = 0
            Me.CheckBoxDefaultComments_UseFooterComment.ChildControls = CType(resources.GetObject("CheckBoxDefaultComments_UseFooterComment.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDefaultComments_UseFooterComment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDefaultComments_UseFooterComment.Location = New System.Drawing.Point(4, 336)
            Me.CheckBoxDefaultComments_UseFooterComment.Name = "CheckBoxDefaultComments_UseFooterComment"
            Me.CheckBoxDefaultComments_UseFooterComment.OldestSibling = Nothing
            Me.CheckBoxDefaultComments_UseFooterComment.SecurityEnabled = True
            Me.CheckBoxDefaultComments_UseFooterComment.SiblingControls = CType(resources.GetObject("CheckBoxDefaultComments_UseFooterComment.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDefaultComments_UseFooterComment.Size = New System.Drawing.Size(91, 20)
            Me.CheckBoxDefaultComments_UseFooterComment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDefaultComments_UseFooterComment.TabIndex = 14
            Me.CheckBoxDefaultComments_UseFooterComment.TabOnEnter = True
            Me.CheckBoxDefaultComments_UseFooterComment.Text = "Use"
            '
            'TextBoxDefaultComments_Instructions
            '
            Me.TextBoxDefaultComments_Instructions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxDefaultComments_Instructions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxDefaultComments_Instructions.Border.Class = "TextBoxBorder"
            Me.TextBoxDefaultComments_Instructions.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDefaultComments_Instructions.CheckSpellingOnValidate = False
            Me.TextBoxDefaultComments_Instructions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDefaultComments_Instructions.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxDefaultComments_Instructions.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDefaultComments_Instructions.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDefaultComments_Instructions.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDefaultComments_Instructions.FocusHighlightEnabled = True
            Me.TextBoxDefaultComments_Instructions.ForeColor = System.Drawing.Color.Black
            Me.TextBoxDefaultComments_Instructions.Location = New System.Drawing.Point(101, 4)
            Me.TextBoxDefaultComments_Instructions.MaxFileSize = CType(0, Long)
            Me.TextBoxDefaultComments_Instructions.Multiline = True
            Me.TextBoxDefaultComments_Instructions.Name = "TextBoxDefaultComments_Instructions"
            Me.TextBoxDefaultComments_Instructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxDefaultComments_Instructions.SecurityEnabled = True
            Me.TextBoxDefaultComments_Instructions.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDefaultComments_Instructions.Size = New System.Drawing.Size(698, 45)
            Me.TextBoxDefaultComments_Instructions.StartingFolderName = Nothing
            Me.TextBoxDefaultComments_Instructions.TabIndex = 1
            Me.TextBoxDefaultComments_Instructions.TabOnEnter = False
            '
            'TextBoxDefaultComments_FooterComment
            '
            Me.TextBoxDefaultComments_FooterComment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxDefaultComments_FooterComment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxDefaultComments_FooterComment.Border.Class = "TextBoxBorder"
            Me.TextBoxDefaultComments_FooterComment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDefaultComments_FooterComment.CheckSpellingOnValidate = False
            Me.TextBoxDefaultComments_FooterComment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDefaultComments_FooterComment.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxDefaultComments_FooterComment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDefaultComments_FooterComment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDefaultComments_FooterComment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDefaultComments_FooterComment.FocusHighlightEnabled = True
            Me.TextBoxDefaultComments_FooterComment.ForeColor = System.Drawing.Color.Black
            Me.TextBoxDefaultComments_FooterComment.Location = New System.Drawing.Point(101, 310)
            Me.TextBoxDefaultComments_FooterComment.MaxFileSize = CType(0, Long)
            Me.TextBoxDefaultComments_FooterComment.Multiline = True
            Me.TextBoxDefaultComments_FooterComment.Name = "TextBoxDefaultComments_FooterComment"
            Me.TextBoxDefaultComments_FooterComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxDefaultComments_FooterComment.SecurityEnabled = True
            Me.TextBoxDefaultComments_FooterComment.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDefaultComments_FooterComment.Size = New System.Drawing.Size(698, 134)
            Me.TextBoxDefaultComments_FooterComment.StartingFolderName = Nothing
            Me.TextBoxDefaultComments_FooterComment.TabIndex = 13
            Me.TextBoxDefaultComments_FooterComment.TabOnEnter = False
            '
            'TextBoxDefaultComments_RateInfo
            '
            Me.TextBoxDefaultComments_RateInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxDefaultComments_RateInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxDefaultComments_RateInfo.Border.Class = "TextBoxBorder"
            Me.TextBoxDefaultComments_RateInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDefaultComments_RateInfo.CheckSpellingOnValidate = False
            Me.TextBoxDefaultComments_RateInfo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDefaultComments_RateInfo.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxDefaultComments_RateInfo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDefaultComments_RateInfo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDefaultComments_RateInfo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDefaultComments_RateInfo.FocusHighlightEnabled = True
            Me.TextBoxDefaultComments_RateInfo.ForeColor = System.Drawing.Color.Black
            Me.TextBoxDefaultComments_RateInfo.Location = New System.Drawing.Point(101, 259)
            Me.TextBoxDefaultComments_RateInfo.MaxFileSize = CType(0, Long)
            Me.TextBoxDefaultComments_RateInfo.Multiline = True
            Me.TextBoxDefaultComments_RateInfo.Name = "TextBoxDefaultComments_RateInfo"
            Me.TextBoxDefaultComments_RateInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxDefaultComments_RateInfo.SecurityEnabled = True
            Me.TextBoxDefaultComments_RateInfo.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDefaultComments_RateInfo.Size = New System.Drawing.Size(698, 45)
            Me.TextBoxDefaultComments_RateInfo.StartingFolderName = Nothing
            Me.TextBoxDefaultComments_RateInfo.TabIndex = 11
            Me.TextBoxDefaultComments_RateInfo.TabOnEnter = False
            '
            'TextBoxDefaultComments_MaterialNotes
            '
            Me.TextBoxDefaultComments_MaterialNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxDefaultComments_MaterialNotes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxDefaultComments_MaterialNotes.Border.Class = "TextBoxBorder"
            Me.TextBoxDefaultComments_MaterialNotes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDefaultComments_MaterialNotes.CheckSpellingOnValidate = False
            Me.TextBoxDefaultComments_MaterialNotes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDefaultComments_MaterialNotes.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxDefaultComments_MaterialNotes.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDefaultComments_MaterialNotes.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDefaultComments_MaterialNotes.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDefaultComments_MaterialNotes.FocusHighlightEnabled = True
            Me.TextBoxDefaultComments_MaterialNotes.ForeColor = System.Drawing.Color.Black
            Me.TextBoxDefaultComments_MaterialNotes.Location = New System.Drawing.Point(101, 208)
            Me.TextBoxDefaultComments_MaterialNotes.MaxFileSize = CType(0, Long)
            Me.TextBoxDefaultComments_MaterialNotes.Multiline = True
            Me.TextBoxDefaultComments_MaterialNotes.Name = "TextBoxDefaultComments_MaterialNotes"
            Me.TextBoxDefaultComments_MaterialNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxDefaultComments_MaterialNotes.SecurityEnabled = True
            Me.TextBoxDefaultComments_MaterialNotes.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDefaultComments_MaterialNotes.Size = New System.Drawing.Size(698, 45)
            Me.TextBoxDefaultComments_MaterialNotes.StartingFolderName = Nothing
            Me.TextBoxDefaultComments_MaterialNotes.TabIndex = 9
            Me.TextBoxDefaultComments_MaterialNotes.TabOnEnter = False
            '
            'TextBoxDefaultComments_PositionInfo
            '
            Me.TextBoxDefaultComments_PositionInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxDefaultComments_PositionInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxDefaultComments_PositionInfo.Border.Class = "TextBoxBorder"
            Me.TextBoxDefaultComments_PositionInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDefaultComments_PositionInfo.CheckSpellingOnValidate = False
            Me.TextBoxDefaultComments_PositionInfo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDefaultComments_PositionInfo.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxDefaultComments_PositionInfo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDefaultComments_PositionInfo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDefaultComments_PositionInfo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDefaultComments_PositionInfo.FocusHighlightEnabled = True
            Me.TextBoxDefaultComments_PositionInfo.ForeColor = System.Drawing.Color.Black
            Me.TextBoxDefaultComments_PositionInfo.Location = New System.Drawing.Point(101, 157)
            Me.TextBoxDefaultComments_PositionInfo.MaxFileSize = CType(0, Long)
            Me.TextBoxDefaultComments_PositionInfo.Multiline = True
            Me.TextBoxDefaultComments_PositionInfo.Name = "TextBoxDefaultComments_PositionInfo"
            Me.TextBoxDefaultComments_PositionInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxDefaultComments_PositionInfo.SecurityEnabled = True
            Me.TextBoxDefaultComments_PositionInfo.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDefaultComments_PositionInfo.Size = New System.Drawing.Size(698, 45)
            Me.TextBoxDefaultComments_PositionInfo.StartingFolderName = Nothing
            Me.TextBoxDefaultComments_PositionInfo.TabIndex = 7
            Me.TextBoxDefaultComments_PositionInfo.TabOnEnter = False
            '
            'TextBoxDefaultComments_MiscInfo
            '
            Me.TextBoxDefaultComments_MiscInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxDefaultComments_MiscInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxDefaultComments_MiscInfo.Border.Class = "TextBoxBorder"
            Me.TextBoxDefaultComments_MiscInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDefaultComments_MiscInfo.CheckSpellingOnValidate = False
            Me.TextBoxDefaultComments_MiscInfo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDefaultComments_MiscInfo.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxDefaultComments_MiscInfo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDefaultComments_MiscInfo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDefaultComments_MiscInfo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDefaultComments_MiscInfo.FocusHighlightEnabled = True
            Me.TextBoxDefaultComments_MiscInfo.ForeColor = System.Drawing.Color.Black
            Me.TextBoxDefaultComments_MiscInfo.Location = New System.Drawing.Point(101, 106)
            Me.TextBoxDefaultComments_MiscInfo.MaxFileSize = CType(0, Long)
            Me.TextBoxDefaultComments_MiscInfo.Multiline = True
            Me.TextBoxDefaultComments_MiscInfo.Name = "TextBoxDefaultComments_MiscInfo"
            Me.TextBoxDefaultComments_MiscInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxDefaultComments_MiscInfo.SecurityEnabled = True
            Me.TextBoxDefaultComments_MiscInfo.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDefaultComments_MiscInfo.Size = New System.Drawing.Size(698, 45)
            Me.TextBoxDefaultComments_MiscInfo.StartingFolderName = Nothing
            Me.TextBoxDefaultComments_MiscInfo.TabIndex = 5
            Me.TextBoxDefaultComments_MiscInfo.TabOnEnter = False
            '
            'TextBoxDefaultComments_CloseInfo
            '
            Me.TextBoxDefaultComments_CloseInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxDefaultComments_CloseInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxDefaultComments_CloseInfo.Border.Class = "TextBoxBorder"
            Me.TextBoxDefaultComments_CloseInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDefaultComments_CloseInfo.CheckSpellingOnValidate = False
            Me.TextBoxDefaultComments_CloseInfo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDefaultComments_CloseInfo.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxDefaultComments_CloseInfo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDefaultComments_CloseInfo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDefaultComments_CloseInfo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDefaultComments_CloseInfo.FocusHighlightEnabled = True
            Me.TextBoxDefaultComments_CloseInfo.ForeColor = System.Drawing.Color.Black
            Me.TextBoxDefaultComments_CloseInfo.Location = New System.Drawing.Point(101, 55)
            Me.TextBoxDefaultComments_CloseInfo.MaxFileSize = CType(0, Long)
            Me.TextBoxDefaultComments_CloseInfo.Multiline = True
            Me.TextBoxDefaultComments_CloseInfo.Name = "TextBoxDefaultComments_CloseInfo"
            Me.TextBoxDefaultComments_CloseInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxDefaultComments_CloseInfo.SecurityEnabled = True
            Me.TextBoxDefaultComments_CloseInfo.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDefaultComments_CloseInfo.Size = New System.Drawing.Size(698, 45)
            Me.TextBoxDefaultComments_CloseInfo.StartingFolderName = Nothing
            Me.TextBoxDefaultComments_CloseInfo.TabIndex = 3
            Me.TextBoxDefaultComments_CloseInfo.TabOnEnter = False
            '
            'LabelDefaultComments_FooterComment
            '
            Me.LabelDefaultComments_FooterComment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultComments_FooterComment.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelDefaultComments_FooterComment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultComments_FooterComment.Location = New System.Drawing.Point(4, 310)
            Me.LabelDefaultComments_FooterComment.Name = "LabelDefaultComments_FooterComment"
            Me.LabelDefaultComments_FooterComment.Size = New System.Drawing.Size(91, 20)
            Me.LabelDefaultComments_FooterComment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultComments_FooterComment.TabIndex = 12
            Me.LabelDefaultComments_FooterComment.Text = "Footer Comment:"
            '
            'LabelDefaultComments_RateInfo
            '
            Me.LabelDefaultComments_RateInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultComments_RateInfo.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelDefaultComments_RateInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultComments_RateInfo.Location = New System.Drawing.Point(4, 259)
            Me.LabelDefaultComments_RateInfo.Name = "LabelDefaultComments_RateInfo"
            Me.LabelDefaultComments_RateInfo.Size = New System.Drawing.Size(91, 20)
            Me.LabelDefaultComments_RateInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultComments_RateInfo.TabIndex = 10
            Me.LabelDefaultComments_RateInfo.Text = "Rate Info:"
            '
            'LabelDefaultComments_MaterialNotes
            '
            Me.LabelDefaultComments_MaterialNotes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultComments_MaterialNotes.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelDefaultComments_MaterialNotes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultComments_MaterialNotes.Location = New System.Drawing.Point(4, 208)
            Me.LabelDefaultComments_MaterialNotes.Name = "LabelDefaultComments_MaterialNotes"
            Me.LabelDefaultComments_MaterialNotes.Size = New System.Drawing.Size(91, 20)
            Me.LabelDefaultComments_MaterialNotes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultComments_MaterialNotes.TabIndex = 8
            Me.LabelDefaultComments_MaterialNotes.Text = "Material Notes:"
            '
            'LabelDefaultComments_PositionInfo
            '
            Me.LabelDefaultComments_PositionInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultComments_PositionInfo.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelDefaultComments_PositionInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultComments_PositionInfo.Location = New System.Drawing.Point(4, 157)
            Me.LabelDefaultComments_PositionInfo.Name = "LabelDefaultComments_PositionInfo"
            Me.LabelDefaultComments_PositionInfo.Size = New System.Drawing.Size(91, 20)
            Me.LabelDefaultComments_PositionInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultComments_PositionInfo.TabIndex = 6
            Me.LabelDefaultComments_PositionInfo.Text = "Position Info:"
            '
            'LabelDefaultComments_MiscInfo
            '
            Me.LabelDefaultComments_MiscInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultComments_MiscInfo.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelDefaultComments_MiscInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultComments_MiscInfo.Location = New System.Drawing.Point(4, 106)
            Me.LabelDefaultComments_MiscInfo.Name = "LabelDefaultComments_MiscInfo"
            Me.LabelDefaultComments_MiscInfo.Size = New System.Drawing.Size(91, 20)
            Me.LabelDefaultComments_MiscInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultComments_MiscInfo.TabIndex = 4
            Me.LabelDefaultComments_MiscInfo.Text = "Misc Info:"
            '
            'LabelDefaultComments_CloseInfo
            '
            Me.LabelDefaultComments_CloseInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultComments_CloseInfo.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelDefaultComments_CloseInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultComments_CloseInfo.Location = New System.Drawing.Point(4, 55)
            Me.LabelDefaultComments_CloseInfo.Name = "LabelDefaultComments_CloseInfo"
            Me.LabelDefaultComments_CloseInfo.Size = New System.Drawing.Size(91, 20)
            Me.LabelDefaultComments_CloseInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultComments_CloseInfo.TabIndex = 2
            Me.LabelDefaultComments_CloseInfo.Text = "Close Info:"
            '
            'LabelDefaultComments_Instructions
            '
            Me.LabelDefaultComments_Instructions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultComments_Instructions.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelDefaultComments_Instructions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultComments_Instructions.Location = New System.Drawing.Point(4, 4)
            Me.LabelDefaultComments_Instructions.Name = "LabelDefaultComments_Instructions"
            Me.LabelDefaultComments_Instructions.Size = New System.Drawing.Size(91, 20)
            Me.LabelDefaultComments_Instructions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultComments_Instructions.TabIndex = 0
            Me.LabelDefaultComments_Instructions.Text = "Instructions:"
            '
            'TabItemMediaDefaults_DefaultCommentsTab
            '
            Me.TabItemMediaDefaults_DefaultCommentsTab.AttachedControl = Me.TabControlPanelDefaultCommentsTab_DefaultComments
            Me.TabItemMediaDefaults_DefaultCommentsTab.Name = "TabItemMediaDefaults_DefaultCommentsTab"
            Me.TabItemMediaDefaults_DefaultCommentsTab.Text = "Default Comments"
            '
            'TabItemVendorDetails_MediaDefaultsTab
            '
            Me.TabItemVendorDetails_MediaDefaultsTab.AttachedControl = Me.TabControlPanelMediaDefaultsTab_MediaDefaults
            Me.TabItemVendorDetails_MediaDefaultsTab.Name = "TabItemVendorDetails_MediaDefaultsTab"
            Me.TabItemVendorDetails_MediaDefaultsTab.Text = "Media Defaults"
            '
            'TabControlPanelContactsTab_Contacts
            '
            Me.TabControlPanelContactsTab_Contacts.Controls.Add(Me.TextBoxContacts_DefaultVendorContactCode)
            Me.TabControlPanelContactsTab_Contacts.Controls.Add(Me.DataGridViewContacts_Contacts)
            Me.TabControlPanelContactsTab_Contacts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelContactsTab_Contacts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelContactsTab_Contacts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelContactsTab_Contacts.Name = "TabControlPanelContactsTab_Contacts"
            Me.TabControlPanelContactsTab_Contacts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelContactsTab_Contacts.Size = New System.Drawing.Size(815, 513)
            Me.TabControlPanelContactsTab_Contacts.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelContactsTab_Contacts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelContactsTab_Contacts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelContactsTab_Contacts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelContactsTab_Contacts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelContactsTab_Contacts.Style.GradientAngle = 90
            Me.TabControlPanelContactsTab_Contacts.TabIndex = 3
            Me.TabControlPanelContactsTab_Contacts.TabItem = Me.TabItemVendorDetails_ContactsTab
            '
            'TextBoxContacts_DefaultVendorContactCode
            '
            Me.TextBoxContacts_DefaultVendorContactCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxContacts_DefaultVendorContactCode.Border.Class = "TextBoxBorder"
            Me.TextBoxContacts_DefaultVendorContactCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxContacts_DefaultVendorContactCode.CheckSpellingOnValidate = False
            Me.TextBoxContacts_DefaultVendorContactCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxContacts_DefaultVendorContactCode.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxContacts_DefaultVendorContactCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxContacts_DefaultVendorContactCode.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxContacts_DefaultVendorContactCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxContacts_DefaultVendorContactCode.FocusHighlightEnabled = True
            Me.TextBoxContacts_DefaultVendorContactCode.ForeColor = System.Drawing.Color.Black
            Me.TextBoxContacts_DefaultVendorContactCode.Location = New System.Drawing.Point(566, 363)
            Me.TextBoxContacts_DefaultVendorContactCode.MaxFileSize = CType(0, Long)
            Me.TextBoxContacts_DefaultVendorContactCode.Name = "TextBoxContacts_DefaultVendorContactCode"
            Me.TextBoxContacts_DefaultVendorContactCode.ReadOnly = True
            Me.TextBoxContacts_DefaultVendorContactCode.SecurityEnabled = True
            Me.TextBoxContacts_DefaultVendorContactCode.ShowSpellCheckCompleteMessage = True
            Me.TextBoxContacts_DefaultVendorContactCode.Size = New System.Drawing.Size(82, 20)
            Me.TextBoxContacts_DefaultVendorContactCode.StartingFolderName = Nothing
            Me.TextBoxContacts_DefaultVendorContactCode.TabIndex = 1
            Me.TextBoxContacts_DefaultVendorContactCode.TabOnEnter = True
            Me.TextBoxContacts_DefaultVendorContactCode.Visible = False
            '
            'DataGridViewContacts_Contacts
            '
            Me.DataGridViewContacts_Contacts.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewContacts_Contacts.AllowDragAndDrop = False
            Me.DataGridViewContacts_Contacts.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewContacts_Contacts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewContacts_Contacts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewContacts_Contacts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewContacts_Contacts.AutoFilterLookupColumns = False
            Me.DataGridViewContacts_Contacts.AutoloadRepositoryDatasource = True
            Me.DataGridViewContacts_Contacts.AutoUpdateViewCaption = True
            Me.DataGridViewContacts_Contacts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewContacts_Contacts.DataSource = Nothing
            Me.DataGridViewContacts_Contacts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewContacts_Contacts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewContacts_Contacts.ItemDescription = ""
            Me.DataGridViewContacts_Contacts.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewContacts_Contacts.MultiSelect = True
            Me.DataGridViewContacts_Contacts.Name = "DataGridViewContacts_Contacts"
            Me.DataGridViewContacts_Contacts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewContacts_Contacts.RunStandardValidation = True
            Me.DataGridViewContacts_Contacts.ShowColumnMenuOnRightClick = False
            Me.DataGridViewContacts_Contacts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewContacts_Contacts.Size = New System.Drawing.Size(803, 501)
            Me.DataGridViewContacts_Contacts.TabIndex = 0
            Me.DataGridViewContacts_Contacts.UseEmbeddedNavigator = False
            Me.DataGridViewContacts_Contacts.ViewCaptionHeight = -1
            '
            'TabItemVendorDetails_ContactsTab
            '
            Me.TabItemVendorDetails_ContactsTab.AttachedControl = Me.TabControlPanelContactsTab_Contacts
            Me.TabItemVendorDetails_ContactsTab.Name = "TabItemVendorDetails_ContactsTab"
            Me.TabItemVendorDetails_ContactsTab.Text = "Contacts"
            '
            'TabControlPanelRepresentativesTab_Representatives
            '
            Me.TabControlPanelRepresentativesTab_Representatives.Controls.Add(Me.TextBoxRepresentatives_DefaultRep2)
            Me.TabControlPanelRepresentativesTab_Representatives.Controls.Add(Me.TextBoxRepresentatives_DefaultRep1)
            Me.TabControlPanelRepresentativesTab_Representatives.Controls.Add(Me.DataGridViewRepresentatives_VendorReps)
            Me.TabControlPanelRepresentativesTab_Representatives.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelRepresentativesTab_Representatives.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRepresentativesTab_Representatives.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRepresentativesTab_Representatives.Name = "TabControlPanelRepresentativesTab_Representatives"
            Me.TabControlPanelRepresentativesTab_Representatives.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRepresentativesTab_Representatives.Size = New System.Drawing.Size(815, 513)
            Me.TabControlPanelRepresentativesTab_Representatives.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelRepresentativesTab_Representatives.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRepresentativesTab_Representatives.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRepresentativesTab_Representatives.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRepresentativesTab_Representatives.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRepresentativesTab_Representatives.Style.GradientAngle = 90
            Me.TabControlPanelRepresentativesTab_Representatives.TabIndex = 4
            Me.TabControlPanelRepresentativesTab_Representatives.TabItem = Me.TabItemVendorDetails_RepresentativesTab
            '
            'TextBoxRepresentatives_DefaultRep2
            '
            Me.TextBoxRepresentatives_DefaultRep2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxRepresentatives_DefaultRep2.Border.Class = "TextBoxBorder"
            Me.TextBoxRepresentatives_DefaultRep2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRepresentatives_DefaultRep2.CheckSpellingOnValidate = False
            Me.TextBoxRepresentatives_DefaultRep2.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRepresentatives_DefaultRep2.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxRepresentatives_DefaultRep2.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxRepresentatives_DefaultRep2.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRepresentatives_DefaultRep2.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRepresentatives_DefaultRep2.FocusHighlightEnabled = True
            Me.TextBoxRepresentatives_DefaultRep2.ForeColor = System.Drawing.Color.Black
            Me.TextBoxRepresentatives_DefaultRep2.Location = New System.Drawing.Point(566, 368)
            Me.TextBoxRepresentatives_DefaultRep2.MaxFileSize = CType(0, Long)
            Me.TextBoxRepresentatives_DefaultRep2.Name = "TextBoxRepresentatives_DefaultRep2"
            Me.TextBoxRepresentatives_DefaultRep2.ReadOnly = True
            Me.TextBoxRepresentatives_DefaultRep2.SecurityEnabled = True
            Me.TextBoxRepresentatives_DefaultRep2.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRepresentatives_DefaultRep2.Size = New System.Drawing.Size(82, 20)
            Me.TextBoxRepresentatives_DefaultRep2.StartingFolderName = Nothing
            Me.TextBoxRepresentatives_DefaultRep2.TabIndex = 3
            Me.TextBoxRepresentatives_DefaultRep2.TabOnEnter = True
            Me.TextBoxRepresentatives_DefaultRep2.Visible = False
            '
            'TextBoxRepresentatives_DefaultRep1
            '
            Me.TextBoxRepresentatives_DefaultRep1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxRepresentatives_DefaultRep1.Border.Class = "TextBoxBorder"
            Me.TextBoxRepresentatives_DefaultRep1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRepresentatives_DefaultRep1.CheckSpellingOnValidate = False
            Me.TextBoxRepresentatives_DefaultRep1.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRepresentatives_DefaultRep1.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxRepresentatives_DefaultRep1.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxRepresentatives_DefaultRep1.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRepresentatives_DefaultRep1.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRepresentatives_DefaultRep1.FocusHighlightEnabled = True
            Me.TextBoxRepresentatives_DefaultRep1.ForeColor = System.Drawing.Color.Black
            Me.TextBoxRepresentatives_DefaultRep1.Location = New System.Drawing.Point(566, 342)
            Me.TextBoxRepresentatives_DefaultRep1.MaxFileSize = CType(0, Long)
            Me.TextBoxRepresentatives_DefaultRep1.Name = "TextBoxRepresentatives_DefaultRep1"
            Me.TextBoxRepresentatives_DefaultRep1.ReadOnly = True
            Me.TextBoxRepresentatives_DefaultRep1.SecurityEnabled = True
            Me.TextBoxRepresentatives_DefaultRep1.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRepresentatives_DefaultRep1.Size = New System.Drawing.Size(82, 20)
            Me.TextBoxRepresentatives_DefaultRep1.StartingFolderName = Nothing
            Me.TextBoxRepresentatives_DefaultRep1.TabIndex = 2
            Me.TextBoxRepresentatives_DefaultRep1.TabOnEnter = True
            Me.TextBoxRepresentatives_DefaultRep1.Visible = False
            '
            'DataGridViewRepresentatives_VendorReps
            '
            Me.DataGridViewRepresentatives_VendorReps.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRepresentatives_VendorReps.AllowDragAndDrop = False
            Me.DataGridViewRepresentatives_VendorReps.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRepresentatives_VendorReps.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRepresentatives_VendorReps.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRepresentatives_VendorReps.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRepresentatives_VendorReps.AutoFilterLookupColumns = False
            Me.DataGridViewRepresentatives_VendorReps.AutoloadRepositoryDatasource = True
            Me.DataGridViewRepresentatives_VendorReps.AutoUpdateViewCaption = True
            Me.DataGridViewRepresentatives_VendorReps.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRepresentatives_VendorReps.DataSource = Nothing
            Me.DataGridViewRepresentatives_VendorReps.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRepresentatives_VendorReps.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRepresentatives_VendorReps.ItemDescription = ""
            Me.DataGridViewRepresentatives_VendorReps.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewRepresentatives_VendorReps.MultiSelect = True
            Me.DataGridViewRepresentatives_VendorReps.Name = "DataGridViewRepresentatives_VendorReps"
            Me.DataGridViewRepresentatives_VendorReps.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRepresentatives_VendorReps.RunStandardValidation = True
            Me.DataGridViewRepresentatives_VendorReps.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRepresentatives_VendorReps.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRepresentatives_VendorReps.Size = New System.Drawing.Size(803, 501)
            Me.DataGridViewRepresentatives_VendorReps.TabIndex = 0
            Me.DataGridViewRepresentatives_VendorReps.UseEmbeddedNavigator = False
            Me.DataGridViewRepresentatives_VendorReps.ViewCaptionHeight = -1
            '
            'TabItemVendorDetails_RepresentativesTab
            '
            Me.TabItemVendorDetails_RepresentativesTab.AttachedControl = Me.TabControlPanelRepresentativesTab_Representatives
            Me.TabItemVendorDetails_RepresentativesTab.Name = "TabItemVendorDetails_RepresentativesTab"
            Me.TabItemVendorDetails_RepresentativesTab.Text = "Representatives"
            '
            'TabControlPanelMainTab_Main
            '
            Me.TabControlPanelMainTab_Main.AutoScroll = True
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.LabelMain_QuickbooksVendor)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.SearchableComboBoxMain_QuickBooksVendor)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.LabelMain_VATNumber)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.TextBoxMain_VATNumber)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.CheckBoxMain_Television)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.CheckBoxMain_Radio)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.CheckBoxMain_OutOfHome)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.CheckBoxMain_Newspaper)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.CheckBoxMain_Magazine)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.CheckBoxMain_Internet)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.LabelMain_MediaCategoriesAllowed)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.ComboBoxMain_DefaultCategory)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.TableLayoutPanelMain_TableLayout)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.CheckBoxMain_Inactive)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.LabelMain_DefaultCategory)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.TextBoxMain_FederalTaxID)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.LabelMain_FederalTaxID)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.TextBoxMain_Website)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.TextBoxMain_Email)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.TextBoxMain_PaymentManagerEmail)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.LabelMain_PaymentManagerEmail)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.LabelMain_Email)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.LabelMain_Website)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.TextBoxMain_Code)
            Me.TabControlPanelMainTab_Main.Controls.Add(Me.LabelMain_Code)
            Me.TabControlPanelMainTab_Main.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMainTab_Main.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMainTab_Main.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMainTab_Main.Name = "TabControlPanelMainTab_Main"
            Me.TabControlPanelMainTab_Main.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMainTab_Main.Size = New System.Drawing.Size(815, 513)
            Me.TabControlPanelMainTab_Main.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMainTab_Main.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMainTab_Main.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMainTab_Main.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMainTab_Main.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMainTab_Main.Style.GradientAngle = 90
            Me.TabControlPanelMainTab_Main.TabIndex = 0
            Me.TabControlPanelMainTab_Main.TabItem = Me.TabItemVendorDetails_MainTab
            '
            'LabelMain_VATNumber
            '
            Me.LabelMain_VATNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMain_VATNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMain_VATNumber.Location = New System.Drawing.Point(419, 403)
            Me.LabelMain_VATNumber.Name = "LabelMain_VATNumber"
            Me.LabelMain_VATNumber.Size = New System.Drawing.Size(127, 20)
            Me.LabelMain_VATNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMain_VATNumber.TabIndex = 26
            Me.LabelMain_VATNumber.Text = "VAT Number:"
            '
            'TextBoxMain_VATNumber
            '
            Me.TextBoxMain_VATNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMain_VATNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMain_VATNumber.Border.Class = "TextBoxBorder"
            Me.TextBoxMain_VATNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMain_VATNumber.CheckSpellingOnValidate = False
            Me.TextBoxMain_VATNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMain_VATNumber.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMain_VATNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxMain_VATNumber.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMain_VATNumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMain_VATNumber.FocusHighlightEnabled = True
            Me.TextBoxMain_VATNumber.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMain_VATNumber.Location = New System.Drawing.Point(552, 403)
            Me.TextBoxMain_VATNumber.MaxFileSize = CType(0, Long)
            Me.TextBoxMain_VATNumber.Name = "TextBoxMain_VATNumber"
            Me.TextBoxMain_VATNumber.SecurityEnabled = True
            Me.TextBoxMain_VATNumber.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMain_VATNumber.Size = New System.Drawing.Size(259, 20)
            Me.TextBoxMain_VATNumber.StartingFolderName = Nothing
            Me.TextBoxMain_VATNumber.TabIndex = 27
            Me.TextBoxMain_VATNumber.TabOnEnter = True
            '
            'CheckBoxMain_Television
            '
            Me.CheckBoxMain_Television.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMain_Television.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMain_Television.CheckValue = 0
            Me.CheckBoxMain_Television.CheckValueChecked = 1
            Me.CheckBoxMain_Television.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMain_Television.CheckValueUnchecked = 0
            Me.CheckBoxMain_Television.ChildControls = CType(resources.GetObject("CheckBoxMain_Television.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMain_Television.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMain_Television.Location = New System.Drawing.Point(288, 455)
            Me.CheckBoxMain_Television.Name = "CheckBoxMain_Television"
            Me.CheckBoxMain_Television.OldestSibling = Nothing
            Me.CheckBoxMain_Television.SecurityEnabled = True
            Me.CheckBoxMain_Television.SiblingControls = CType(resources.GetObject("CheckBoxMain_Television.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMain_Television.Size = New System.Drawing.Size(125, 20)
            Me.CheckBoxMain_Television.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMain_Television.TabIndex = 22
            Me.CheckBoxMain_Television.TabOnEnter = True
            Me.CheckBoxMain_Television.Text = "Television"
            '
            'CheckBoxMain_Radio
            '
            Me.CheckBoxMain_Radio.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMain_Radio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMain_Radio.CheckValue = 0
            Me.CheckBoxMain_Radio.CheckValueChecked = 1
            Me.CheckBoxMain_Radio.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMain_Radio.CheckValueUnchecked = 0
            Me.CheckBoxMain_Radio.ChildControls = CType(resources.GetObject("CheckBoxMain_Radio.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMain_Radio.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMain_Radio.Location = New System.Drawing.Point(146, 455)
            Me.CheckBoxMain_Radio.Name = "CheckBoxMain_Radio"
            Me.CheckBoxMain_Radio.OldestSibling = Nothing
            Me.CheckBoxMain_Radio.SecurityEnabled = True
            Me.CheckBoxMain_Radio.SiblingControls = CType(resources.GetObject("CheckBoxMain_Radio.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMain_Radio.Size = New System.Drawing.Size(136, 20)
            Me.CheckBoxMain_Radio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMain_Radio.TabIndex = 21
            Me.CheckBoxMain_Radio.TabOnEnter = True
            Me.CheckBoxMain_Radio.Text = "Radio"
            '
            'CheckBoxMain_OutOfHome
            '
            Me.CheckBoxMain_OutOfHome.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMain_OutOfHome.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMain_OutOfHome.CheckValue = 0
            Me.CheckBoxMain_OutOfHome.CheckValueChecked = 1
            Me.CheckBoxMain_OutOfHome.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMain_OutOfHome.CheckValueUnchecked = 0
            Me.CheckBoxMain_OutOfHome.ChildControls = CType(resources.GetObject("CheckBoxMain_OutOfHome.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMain_OutOfHome.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMain_OutOfHome.Location = New System.Drawing.Point(4, 455)
            Me.CheckBoxMain_OutOfHome.Name = "CheckBoxMain_OutOfHome"
            Me.CheckBoxMain_OutOfHome.OldestSibling = Nothing
            Me.CheckBoxMain_OutOfHome.SecurityEnabled = True
            Me.CheckBoxMain_OutOfHome.SiblingControls = CType(resources.GetObject("CheckBoxMain_OutOfHome.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMain_OutOfHome.Size = New System.Drawing.Size(136, 20)
            Me.CheckBoxMain_OutOfHome.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMain_OutOfHome.TabIndex = 20
            Me.CheckBoxMain_OutOfHome.TabOnEnter = True
            Me.CheckBoxMain_OutOfHome.Text = "Out of Home"
            '
            'CheckBoxMain_Newspaper
            '
            Me.CheckBoxMain_Newspaper.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMain_Newspaper.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMain_Newspaper.CheckValue = 0
            Me.CheckBoxMain_Newspaper.CheckValueChecked = 1
            Me.CheckBoxMain_Newspaper.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMain_Newspaper.CheckValueUnchecked = 0
            Me.CheckBoxMain_Newspaper.ChildControls = CType(resources.GetObject("CheckBoxMain_Newspaper.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMain_Newspaper.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMain_Newspaper.Location = New System.Drawing.Point(288, 429)
            Me.CheckBoxMain_Newspaper.Name = "CheckBoxMain_Newspaper"
            Me.CheckBoxMain_Newspaper.OldestSibling = Nothing
            Me.CheckBoxMain_Newspaper.SecurityEnabled = True
            Me.CheckBoxMain_Newspaper.SiblingControls = CType(resources.GetObject("CheckBoxMain_Newspaper.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMain_Newspaper.Size = New System.Drawing.Size(125, 20)
            Me.CheckBoxMain_Newspaper.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMain_Newspaper.TabIndex = 19
            Me.CheckBoxMain_Newspaper.TabOnEnter = True
            Me.CheckBoxMain_Newspaper.Text = "Newspaper"
            '
            'CheckBoxMain_Magazine
            '
            Me.CheckBoxMain_Magazine.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMain_Magazine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMain_Magazine.CheckValue = 0
            Me.CheckBoxMain_Magazine.CheckValueChecked = 1
            Me.CheckBoxMain_Magazine.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMain_Magazine.CheckValueUnchecked = 0
            Me.CheckBoxMain_Magazine.ChildControls = CType(resources.GetObject("CheckBoxMain_Magazine.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMain_Magazine.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMain_Magazine.Location = New System.Drawing.Point(146, 429)
            Me.CheckBoxMain_Magazine.Name = "CheckBoxMain_Magazine"
            Me.CheckBoxMain_Magazine.OldestSibling = Nothing
            Me.CheckBoxMain_Magazine.SecurityEnabled = True
            Me.CheckBoxMain_Magazine.SiblingControls = CType(resources.GetObject("CheckBoxMain_Magazine.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMain_Magazine.Size = New System.Drawing.Size(136, 20)
            Me.CheckBoxMain_Magazine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMain_Magazine.TabIndex = 18
            Me.CheckBoxMain_Magazine.TabOnEnter = True
            Me.CheckBoxMain_Magazine.Text = "Magazine"
            '
            'CheckBoxMain_Internet
            '
            Me.CheckBoxMain_Internet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMain_Internet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMain_Internet.CheckValue = 0
            Me.CheckBoxMain_Internet.CheckValueChecked = 1
            Me.CheckBoxMain_Internet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMain_Internet.CheckValueUnchecked = 0
            Me.CheckBoxMain_Internet.ChildControls = CType(resources.GetObject("CheckBoxMain_Internet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMain_Internet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMain_Internet.Location = New System.Drawing.Point(4, 429)
            Me.CheckBoxMain_Internet.Name = "CheckBoxMain_Internet"
            Me.CheckBoxMain_Internet.OldestSibling = Nothing
            Me.CheckBoxMain_Internet.SecurityEnabled = True
            Me.CheckBoxMain_Internet.SiblingControls = CType(resources.GetObject("CheckBoxMain_Internet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMain_Internet.Size = New System.Drawing.Size(136, 20)
            Me.CheckBoxMain_Internet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMain_Internet.TabIndex = 17
            Me.CheckBoxMain_Internet.TabOnEnter = True
            Me.CheckBoxMain_Internet.Text = "Internet"
            '
            'LabelMain_MediaCategoriesAllowed
            '
            Me.LabelMain_MediaCategoriesAllowed.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMain_MediaCategoriesAllowed.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelMain_MediaCategoriesAllowed.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
            Me.LabelMain_MediaCategoriesAllowed.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelMain_MediaCategoriesAllowed.BackgroundStyle.BorderColor = System.Drawing.Color.Black
            Me.LabelMain_MediaCategoriesAllowed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMain_MediaCategoriesAllowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelMain_MediaCategoriesAllowed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelMain_MediaCategoriesAllowed.Location = New System.Drawing.Point(4, 403)
            Me.LabelMain_MediaCategoriesAllowed.Name = "LabelMain_MediaCategoriesAllowed"
            Me.LabelMain_MediaCategoriesAllowed.Size = New System.Drawing.Size(409, 20)
            Me.LabelMain_MediaCategoriesAllowed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMain_MediaCategoriesAllowed.TabIndex = 16
            Me.LabelMain_MediaCategoriesAllowed.Text = "Media Categories Allowed"
            '
            'ComboBoxMain_DefaultCategory
            '
            Me.ComboBoxMain_DefaultCategory.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMain_DefaultCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxMain_DefaultCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMain_DefaultCategory.AutoFindItemInDataSource = False
            Me.ComboBoxMain_DefaultCategory.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMain_DefaultCategory.BookmarkingEnabled = False
            Me.ComboBoxMain_DefaultCategory.ClientCode = ""
            Me.ComboBoxMain_DefaultCategory.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxMain_DefaultCategory.DisableMouseWheel = False
            Me.ComboBoxMain_DefaultCategory.DisplayMember = "Name"
            Me.ComboBoxMain_DefaultCategory.DisplayName = ""
            Me.ComboBoxMain_DefaultCategory.DivisionCode = ""
            Me.ComboBoxMain_DefaultCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMain_DefaultCategory.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMain_DefaultCategory.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxMain_DefaultCategory.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMain_DefaultCategory.FocusHighlightEnabled = True
            Me.ComboBoxMain_DefaultCategory.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxMain_DefaultCategory.FormattingEnabled = True
            Me.ComboBoxMain_DefaultCategory.ItemHeight = 14
            Me.ComboBoxMain_DefaultCategory.Location = New System.Drawing.Point(147, 377)
            Me.ComboBoxMain_DefaultCategory.Name = "ComboBoxMain_DefaultCategory"
            Me.ComboBoxMain_DefaultCategory.ReadOnly = False
            Me.ComboBoxMain_DefaultCategory.SecurityEnabled = True
            Me.ComboBoxMain_DefaultCategory.Size = New System.Drawing.Size(266, 20)
            Me.ComboBoxMain_DefaultCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMain_DefaultCategory.TabIndex = 15
            Me.ComboBoxMain_DefaultCategory.TabOnEnter = True
            Me.ComboBoxMain_DefaultCategory.ValueMember = "Value"
            Me.ComboBoxMain_DefaultCategory.WatermarkText = "Select"
            '
            'TableLayoutPanelMain_TableLayout
            '
            Me.TableLayoutPanelMain_TableLayout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelMain_TableLayout.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelMain_TableLayout.ColumnCount = 2
            Me.TableLayoutPanelMain_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelMain_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelMain_TableLayout.Controls.Add(Me.PanelTableLayout_RightSection, 1, 0)
            Me.TableLayoutPanelMain_TableLayout.Controls.Add(Me.PanelTableLayout_LeftSection, 0, 0)
            Me.TableLayoutPanelMain_TableLayout.Location = New System.Drawing.Point(4, 29)
            Me.TableLayoutPanelMain_TableLayout.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanelMain_TableLayout.Name = "TableLayoutPanelMain_TableLayout"
            Me.TableLayoutPanelMain_TableLayout.RowCount = 1
            Me.TableLayoutPanelMain_TableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelMain_TableLayout.Size = New System.Drawing.Size(807, 342)
            Me.TableLayoutPanelMain_TableLayout.TabIndex = 4
            '
            'PanelTableLayout_RightSection
            '
            Me.PanelTableLayout_RightSection.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelTableLayout_RightSection.Controls.Add(Me.GroupBoxMain_PayToNameAndAddress)
            Me.PanelTableLayout_RightSection.Location = New System.Drawing.Point(403, 0)
            Me.PanelTableLayout_RightSection.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTableLayout_RightSection.Name = "PanelTableLayout_RightSection"
            Me.PanelTableLayout_RightSection.Size = New System.Drawing.Size(404, 342)
            Me.PanelTableLayout_RightSection.TabIndex = 1
            '
            'GroupBoxMain_PayToNameAndAddress
            '
            Me.GroupBoxMain_PayToNameAndAddress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMain_PayToNameAndAddress.Controls.Add(Me.TextBoxPayToNameAndAddress_Vendor)
            Me.GroupBoxMain_PayToNameAndAddress.Controls.Add(Me.ButtonPayToNameAndAddress_Refresh)
            Me.GroupBoxMain_PayToNameAndAddress.Controls.Add(Me.TextBoxPayToNameAndAddress_FaxExt)
            Me.GroupBoxMain_PayToNameAndAddress.Controls.Add(Me.LabelPayToNameAndAddress_Vendor)
            Me.GroupBoxMain_PayToNameAndAddress.Controls.Add(Me.TextBoxPayToNameAndAddress_PhoneExt)
            Me.GroupBoxMain_PayToNameAndAddress.Controls.Add(Me.LabelPayToNameAndAddress_FaxExt)
            Me.GroupBoxMain_PayToNameAndAddress.Controls.Add(Me.TextBoxPayToNameAndAddress_Name)
            Me.GroupBoxMain_PayToNameAndAddress.Controls.Add(Me.LabelPayToNameAndAddress_PhoneExt)
            Me.GroupBoxMain_PayToNameAndAddress.Controls.Add(Me.LabelPayToNameAndAddress_Name)
            Me.GroupBoxMain_PayToNameAndAddress.Controls.Add(Me.TextBoxPayToNameAndAddress_Fax)
            Me.GroupBoxMain_PayToNameAndAddress.Controls.Add(Me.Address3LineControlPayToNameAndAddress_PayToAddress)
            Me.GroupBoxMain_PayToNameAndAddress.Controls.Add(Me.LabelPayToNameAndAddress_Fax)
            Me.GroupBoxMain_PayToNameAndAddress.Controls.Add(Me.LabelPayToNameAndAddress_Phone)
            Me.GroupBoxMain_PayToNameAndAddress.Controls.Add(Me.TextBoxPayToNameAndAddress_Phone)
            Me.GroupBoxMain_PayToNameAndAddress.Location = New System.Drawing.Point(3, 0)
            Me.GroupBoxMain_PayToNameAndAddress.Name = "GroupBoxMain_PayToNameAndAddress"
            Me.GroupBoxMain_PayToNameAndAddress.Size = New System.Drawing.Size(401, 342)
            Me.GroupBoxMain_PayToNameAndAddress.TabIndex = 0
            Me.GroupBoxMain_PayToNameAndAddress.Text = "Pay To Name and Address"
            '
            'TextBoxPayToNameAndAddress_Vendor
            '
            Me.TextBoxPayToNameAndAddress_Vendor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxPayToNameAndAddress_Vendor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxPayToNameAndAddress_Vendor.Border.Class = "TextBoxBorder"
            Me.TextBoxPayToNameAndAddress_Vendor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPayToNameAndAddress_Vendor.ButtonCustom.Visible = True
            Me.TextBoxPayToNameAndAddress_Vendor.CheckSpellingOnValidate = False
            Me.TextBoxPayToNameAndAddress_Vendor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Vendor
            Me.TextBoxPayToNameAndAddress_Vendor.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxPayToNameAndAddress_Vendor.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPayToNameAndAddress_Vendor.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPayToNameAndAddress_Vendor.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPayToNameAndAddress_Vendor.FocusHighlightEnabled = True
            Me.TextBoxPayToNameAndAddress_Vendor.ForeColor = System.Drawing.Color.Black
            Me.TextBoxPayToNameAndAddress_Vendor.Location = New System.Drawing.Point(51, 25)
            Me.TextBoxPayToNameAndAddress_Vendor.MaxFileSize = CType(0, Long)
            Me.TextBoxPayToNameAndAddress_Vendor.Name = "TextBoxPayToNameAndAddress_Vendor"
            Me.TextBoxPayToNameAndAddress_Vendor.SecurityEnabled = True
            Me.TextBoxPayToNameAndAddress_Vendor.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPayToNameAndAddress_Vendor.Size = New System.Drawing.Size(264, 21)
            Me.TextBoxPayToNameAndAddress_Vendor.StartingFolderName = Nothing
            Me.TextBoxPayToNameAndAddress_Vendor.TabIndex = 1
            Me.TextBoxPayToNameAndAddress_Vendor.TabOnEnter = True
            '
            'ButtonPayToNameAndAddress_Refresh
            '
            Me.ButtonPayToNameAndAddress_Refresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPayToNameAndAddress_Refresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonPayToNameAndAddress_Refresh.AutoExpandOnClick = True
            Me.ButtonPayToNameAndAddress_Refresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPayToNameAndAddress_Refresh.Location = New System.Drawing.Point(321, 25)
            Me.ButtonPayToNameAndAddress_Refresh.Name = "ButtonPayToNameAndAddress_Refresh"
            Me.ButtonPayToNameAndAddress_Refresh.SecurityEnabled = True
            Me.ButtonPayToNameAndAddress_Refresh.Size = New System.Drawing.Size(75, 20)
            Me.ButtonPayToNameAndAddress_Refresh.SplitButton = True
            Me.ButtonPayToNameAndAddress_Refresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPayToNameAndAddress_Refresh.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRefresh_Vendor})
            Me.ButtonPayToNameAndAddress_Refresh.TabIndex = 2
            Me.ButtonPayToNameAndAddress_Refresh.Text = "Refresh"
            '
            'ButtonItemRefresh_Vendor
            '
            Me.ButtonItemRefresh_Vendor.Name = "ButtonItemRefresh_Vendor"
            Me.ButtonItemRefresh_Vendor.Text = "Vendor"
            '
            'TextBoxPayToNameAndAddress_FaxExt
            '
            Me.TextBoxPayToNameAndAddress_FaxExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxPayToNameAndAddress_FaxExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxPayToNameAndAddress_FaxExt.Border.Class = "TextBoxBorder"
            Me.TextBoxPayToNameAndAddress_FaxExt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPayToNameAndAddress_FaxExt.CheckSpellingOnValidate = False
            Me.TextBoxPayToNameAndAddress_FaxExt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPayToNameAndAddress_FaxExt.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxPayToNameAndAddress_FaxExt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPayToNameAndAddress_FaxExt.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPayToNameAndAddress_FaxExt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPayToNameAndAddress_FaxExt.FocusHighlightEnabled = True
            Me.TextBoxPayToNameAndAddress_FaxExt.ForeColor = System.Drawing.Color.Black
            Me.TextBoxPayToNameAndAddress_FaxExt.Location = New System.Drawing.Point(337, 316)
            Me.TextBoxPayToNameAndAddress_FaxExt.MaxFileSize = CType(0, Long)
            Me.TextBoxPayToNameAndAddress_FaxExt.Name = "TextBoxPayToNameAndAddress_FaxExt"
            Me.TextBoxPayToNameAndAddress_FaxExt.SecurityEnabled = True
            Me.TextBoxPayToNameAndAddress_FaxExt.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPayToNameAndAddress_FaxExt.Size = New System.Drawing.Size(59, 21)
            Me.TextBoxPayToNameAndAddress_FaxExt.StartingFolderName = Nothing
            Me.TextBoxPayToNameAndAddress_FaxExt.TabIndex = 13
            Me.TextBoxPayToNameAndAddress_FaxExt.TabOnEnter = True
            '
            'LabelPayToNameAndAddress_Vendor
            '
            Me.LabelPayToNameAndAddress_Vendor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPayToNameAndAddress_Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPayToNameAndAddress_Vendor.Location = New System.Drawing.Point(5, 25)
            Me.LabelPayToNameAndAddress_Vendor.Name = "LabelPayToNameAndAddress_Vendor"
            Me.LabelPayToNameAndAddress_Vendor.Size = New System.Drawing.Size(40, 20)
            Me.LabelPayToNameAndAddress_Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPayToNameAndAddress_Vendor.TabIndex = 0
            Me.LabelPayToNameAndAddress_Vendor.Text = "Vendor:"
            '
            'TextBoxPayToNameAndAddress_PhoneExt
            '
            Me.TextBoxPayToNameAndAddress_PhoneExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxPayToNameAndAddress_PhoneExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxPayToNameAndAddress_PhoneExt.Border.Class = "TextBoxBorder"
            Me.TextBoxPayToNameAndAddress_PhoneExt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPayToNameAndAddress_PhoneExt.CheckSpellingOnValidate = False
            Me.TextBoxPayToNameAndAddress_PhoneExt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPayToNameAndAddress_PhoneExt.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxPayToNameAndAddress_PhoneExt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPayToNameAndAddress_PhoneExt.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPayToNameAndAddress_PhoneExt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPayToNameAndAddress_PhoneExt.FocusHighlightEnabled = True
            Me.TextBoxPayToNameAndAddress_PhoneExt.ForeColor = System.Drawing.Color.Black
            Me.TextBoxPayToNameAndAddress_PhoneExt.Location = New System.Drawing.Point(337, 290)
            Me.TextBoxPayToNameAndAddress_PhoneExt.MaxFileSize = CType(0, Long)
            Me.TextBoxPayToNameAndAddress_PhoneExt.Name = "TextBoxPayToNameAndAddress_PhoneExt"
            Me.TextBoxPayToNameAndAddress_PhoneExt.SecurityEnabled = True
            Me.TextBoxPayToNameAndAddress_PhoneExt.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPayToNameAndAddress_PhoneExt.Size = New System.Drawing.Size(59, 21)
            Me.TextBoxPayToNameAndAddress_PhoneExt.StartingFolderName = Nothing
            Me.TextBoxPayToNameAndAddress_PhoneExt.TabIndex = 9
            Me.TextBoxPayToNameAndAddress_PhoneExt.TabOnEnter = True
            '
            'LabelPayToNameAndAddress_FaxExt
            '
            Me.LabelPayToNameAndAddress_FaxExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelPayToNameAndAddress_FaxExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPayToNameAndAddress_FaxExt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPayToNameAndAddress_FaxExt.Location = New System.Drawing.Point(307, 316)
            Me.LabelPayToNameAndAddress_FaxExt.Name = "LabelPayToNameAndAddress_FaxExt"
            Me.LabelPayToNameAndAddress_FaxExt.Size = New System.Drawing.Size(24, 20)
            Me.LabelPayToNameAndAddress_FaxExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPayToNameAndAddress_FaxExt.TabIndex = 12
            Me.LabelPayToNameAndAddress_FaxExt.Text = "Ext:"
            '
            'TextBoxPayToNameAndAddress_Name
            '
            Me.TextBoxPayToNameAndAddress_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxPayToNameAndAddress_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxPayToNameAndAddress_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxPayToNameAndAddress_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPayToNameAndAddress_Name.CheckSpellingOnValidate = False
            Me.TextBoxPayToNameAndAddress_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPayToNameAndAddress_Name.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxPayToNameAndAddress_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPayToNameAndAddress_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPayToNameAndAddress_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPayToNameAndAddress_Name.FocusHighlightEnabled = True
            Me.TextBoxPayToNameAndAddress_Name.ForeColor = System.Drawing.Color.Black
            Me.TextBoxPayToNameAndAddress_Name.Location = New System.Drawing.Point(51, 51)
            Me.TextBoxPayToNameAndAddress_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxPayToNameAndAddress_Name.Name = "TextBoxPayToNameAndAddress_Name"
            Me.TextBoxPayToNameAndAddress_Name.SecurityEnabled = True
            Me.TextBoxPayToNameAndAddress_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPayToNameAndAddress_Name.Size = New System.Drawing.Size(345, 21)
            Me.TextBoxPayToNameAndAddress_Name.StartingFolderName = Nothing
            Me.TextBoxPayToNameAndAddress_Name.TabIndex = 4
            Me.TextBoxPayToNameAndAddress_Name.TabOnEnter = True
            '
            'LabelPayToNameAndAddress_PhoneExt
            '
            Me.LabelPayToNameAndAddress_PhoneExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelPayToNameAndAddress_PhoneExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPayToNameAndAddress_PhoneExt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPayToNameAndAddress_PhoneExt.Location = New System.Drawing.Point(307, 290)
            Me.LabelPayToNameAndAddress_PhoneExt.Name = "LabelPayToNameAndAddress_PhoneExt"
            Me.LabelPayToNameAndAddress_PhoneExt.Size = New System.Drawing.Size(24, 20)
            Me.LabelPayToNameAndAddress_PhoneExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPayToNameAndAddress_PhoneExt.TabIndex = 8
            Me.LabelPayToNameAndAddress_PhoneExt.Text = "Ext:"
            '
            'LabelPayToNameAndAddress_Name
            '
            Me.LabelPayToNameAndAddress_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPayToNameAndAddress_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPayToNameAndAddress_Name.Location = New System.Drawing.Point(5, 51)
            Me.LabelPayToNameAndAddress_Name.Name = "LabelPayToNameAndAddress_Name"
            Me.LabelPayToNameAndAddress_Name.Size = New System.Drawing.Size(40, 20)
            Me.LabelPayToNameAndAddress_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPayToNameAndAddress_Name.TabIndex = 3
            Me.LabelPayToNameAndAddress_Name.Text = "Name:"
            '
            'TextBoxPayToNameAndAddress_Fax
            '
            Me.TextBoxPayToNameAndAddress_Fax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxPayToNameAndAddress_Fax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxPayToNameAndAddress_Fax.Border.Class = "TextBoxBorder"
            Me.TextBoxPayToNameAndAddress_Fax.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPayToNameAndAddress_Fax.CheckSpellingOnValidate = False
            Me.TextBoxPayToNameAndAddress_Fax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPayToNameAndAddress_Fax.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxPayToNameAndAddress_Fax.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPayToNameAndAddress_Fax.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPayToNameAndAddress_Fax.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPayToNameAndAddress_Fax.FocusHighlightEnabled = True
            Me.TextBoxPayToNameAndAddress_Fax.ForeColor = System.Drawing.Color.Black
            Me.TextBoxPayToNameAndAddress_Fax.Location = New System.Drawing.Point(51, 316)
            Me.TextBoxPayToNameAndAddress_Fax.MaxFileSize = CType(0, Long)
            Me.TextBoxPayToNameAndAddress_Fax.Name = "TextBoxPayToNameAndAddress_Fax"
            Me.TextBoxPayToNameAndAddress_Fax.SecurityEnabled = True
            Me.TextBoxPayToNameAndAddress_Fax.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPayToNameAndAddress_Fax.Size = New System.Drawing.Size(250, 21)
            Me.TextBoxPayToNameAndAddress_Fax.StartingFolderName = Nothing
            Me.TextBoxPayToNameAndAddress_Fax.TabIndex = 11
            Me.TextBoxPayToNameAndAddress_Fax.TabOnEnter = True
            '
            'Address3LineControlPayToNameAndAddress_PayToAddress
            '
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.Address = Nothing
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.Address2 = Nothing
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.Address3 = Nothing
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.City = Nothing
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.Country = Nothing
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.County = Nothing
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.DisableCountry = False
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.DisableCounty = False
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.Location = New System.Drawing.Point(5, 77)
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.Name = "Address3LineControlPayToNameAndAddress_PayToAddress"
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.ReadOnly = False
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.ShowCountry = True
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.ShowCounty = True
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.Size = New System.Drawing.Size(391, 207)
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.State = Nothing
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.TabIndex = 5
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.Title = "Pay To Address"
            Me.Address3LineControlPayToNameAndAddress_PayToAddress.Zip = Nothing
            '
            'LabelPayToNameAndAddress_Fax
            '
            Me.LabelPayToNameAndAddress_Fax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPayToNameAndAddress_Fax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPayToNameAndAddress_Fax.Location = New System.Drawing.Point(5, 316)
            Me.LabelPayToNameAndAddress_Fax.Name = "LabelPayToNameAndAddress_Fax"
            Me.LabelPayToNameAndAddress_Fax.Size = New System.Drawing.Size(40, 20)
            Me.LabelPayToNameAndAddress_Fax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPayToNameAndAddress_Fax.TabIndex = 10
            Me.LabelPayToNameAndAddress_Fax.Text = "Fax:"
            '
            'LabelPayToNameAndAddress_Phone
            '
            Me.LabelPayToNameAndAddress_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPayToNameAndAddress_Phone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPayToNameAndAddress_Phone.Location = New System.Drawing.Point(5, 290)
            Me.LabelPayToNameAndAddress_Phone.Name = "LabelPayToNameAndAddress_Phone"
            Me.LabelPayToNameAndAddress_Phone.Size = New System.Drawing.Size(40, 20)
            Me.LabelPayToNameAndAddress_Phone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPayToNameAndAddress_Phone.TabIndex = 6
            Me.LabelPayToNameAndAddress_Phone.Text = "Phone:"
            '
            'TextBoxPayToNameAndAddress_Phone
            '
            Me.TextBoxPayToNameAndAddress_Phone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxPayToNameAndAddress_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxPayToNameAndAddress_Phone.Border.Class = "TextBoxBorder"
            Me.TextBoxPayToNameAndAddress_Phone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPayToNameAndAddress_Phone.CheckSpellingOnValidate = False
            Me.TextBoxPayToNameAndAddress_Phone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPayToNameAndAddress_Phone.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxPayToNameAndAddress_Phone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPayToNameAndAddress_Phone.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPayToNameAndAddress_Phone.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPayToNameAndAddress_Phone.FocusHighlightEnabled = True
            Me.TextBoxPayToNameAndAddress_Phone.ForeColor = System.Drawing.Color.Black
            Me.TextBoxPayToNameAndAddress_Phone.Location = New System.Drawing.Point(51, 290)
            Me.TextBoxPayToNameAndAddress_Phone.MaxFileSize = CType(0, Long)
            Me.TextBoxPayToNameAndAddress_Phone.Name = "TextBoxPayToNameAndAddress_Phone"
            Me.TextBoxPayToNameAndAddress_Phone.SecurityEnabled = True
            Me.TextBoxPayToNameAndAddress_Phone.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPayToNameAndAddress_Phone.Size = New System.Drawing.Size(250, 21)
            Me.TextBoxPayToNameAndAddress_Phone.StartingFolderName = Nothing
            Me.TextBoxPayToNameAndAddress_Phone.TabIndex = 7
            Me.TextBoxPayToNameAndAddress_Phone.TabOnEnter = True
            '
            'PanelTableLayout_LeftSection
            '
            Me.PanelTableLayout_LeftSection.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelTableLayout_LeftSection.Controls.Add(Me.GroupBoxMain_NameAndAddress)
            Me.PanelTableLayout_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelTableLayout_LeftSection.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTableLayout_LeftSection.Name = "PanelTableLayout_LeftSection"
            Me.PanelTableLayout_LeftSection.Size = New System.Drawing.Size(403, 342)
            Me.PanelTableLayout_LeftSection.TabIndex = 0
            '
            'GroupBoxMain_NameAndAddress
            '
            Me.GroupBoxMain_NameAndAddress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMain_NameAndAddress.Controls.Add(Me.LabelLeftSection_Name)
            Me.GroupBoxMain_NameAndAddress.Controls.Add(Me.TextBoxNameAndAddress_Name)
            Me.GroupBoxMain_NameAndAddress.Controls.Add(Me.Address3LineControlNameAndAddress_Address)
            Me.GroupBoxMain_NameAndAddress.Controls.Add(Me.LabelNameAndAddress_Phone)
            Me.GroupBoxMain_NameAndAddress.Controls.Add(Me.TextBoxNameAndAddress_Phone)
            Me.GroupBoxMain_NameAndAddress.Controls.Add(Me.LabelNameAndAddress_Fax)
            Me.GroupBoxMain_NameAndAddress.Controls.Add(Me.TextBoxNameAndAddress_Fax)
            Me.GroupBoxMain_NameAndAddress.Controls.Add(Me.LabelNameAndAddress_PhoneExt)
            Me.GroupBoxMain_NameAndAddress.Controls.Add(Me.LabelNameAndAddress_FaxExt)
            Me.GroupBoxMain_NameAndAddress.Controls.Add(Me.TextBoxNameAndAddress_FaxExt)
            Me.GroupBoxMain_NameAndAddress.Controls.Add(Me.TextBoxNameAndAddress_PhoneExt)
            Me.GroupBoxMain_NameAndAddress.Location = New System.Drawing.Point(0, 0)
            Me.GroupBoxMain_NameAndAddress.Name = "GroupBoxMain_NameAndAddress"
            Me.GroupBoxMain_NameAndAddress.Size = New System.Drawing.Size(400, 342)
            Me.GroupBoxMain_NameAndAddress.TabIndex = 0
            Me.GroupBoxMain_NameAndAddress.Text = "Name and Address"
            '
            'LabelLeftSection_Name
            '
            Me.LabelLeftSection_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftSection_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftSection_Name.Location = New System.Drawing.Point(5, 51)
            Me.LabelLeftSection_Name.Name = "LabelLeftSection_Name"
            Me.LabelLeftSection_Name.Size = New System.Drawing.Size(40, 20)
            Me.LabelLeftSection_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftSection_Name.TabIndex = 0
            Me.LabelLeftSection_Name.Text = "Name:"
            '
            'TextBoxNameAndAddress_Name
            '
            Me.TextBoxNameAndAddress_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxNameAndAddress_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxNameAndAddress_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxNameAndAddress_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxNameAndAddress_Name.CheckSpellingOnValidate = False
            Me.TextBoxNameAndAddress_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxNameAndAddress_Name.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxNameAndAddress_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxNameAndAddress_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxNameAndAddress_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxNameAndAddress_Name.FocusHighlightEnabled = True
            Me.TextBoxNameAndAddress_Name.ForeColor = System.Drawing.Color.Black
            Me.TextBoxNameAndAddress_Name.Location = New System.Drawing.Point(51, 51)
            Me.TextBoxNameAndAddress_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxNameAndAddress_Name.Name = "TextBoxNameAndAddress_Name"
            Me.TextBoxNameAndAddress_Name.SecurityEnabled = True
            Me.TextBoxNameAndAddress_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxNameAndAddress_Name.Size = New System.Drawing.Size(344, 21)
            Me.TextBoxNameAndAddress_Name.StartingFolderName = Nothing
            Me.TextBoxNameAndAddress_Name.TabIndex = 1
            Me.TextBoxNameAndAddress_Name.TabOnEnter = True
            '
            'Address3LineControlNameAndAddress_Address
            '
            Me.Address3LineControlNameAndAddress_Address.Address = Nothing
            Me.Address3LineControlNameAndAddress_Address.Address2 = Nothing
            Me.Address3LineControlNameAndAddress_Address.Address3 = Nothing
            Me.Address3LineControlNameAndAddress_Address.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Address3LineControlNameAndAddress_Address.City = Nothing
            Me.Address3LineControlNameAndAddress_Address.Country = Nothing
            Me.Address3LineControlNameAndAddress_Address.County = Nothing
            Me.Address3LineControlNameAndAddress_Address.DisableCountry = False
            Me.Address3LineControlNameAndAddress_Address.DisableCounty = False
            Me.Address3LineControlNameAndAddress_Address.Location = New System.Drawing.Point(5, 77)
            Me.Address3LineControlNameAndAddress_Address.Name = "Address3LineControlNameAndAddress_Address"
            Me.Address3LineControlNameAndAddress_Address.ReadOnly = False
            Me.Address3LineControlNameAndAddress_Address.ShowCountry = True
            Me.Address3LineControlNameAndAddress_Address.ShowCounty = True
            Me.Address3LineControlNameAndAddress_Address.Size = New System.Drawing.Size(390, 207)
            Me.Address3LineControlNameAndAddress_Address.State = Nothing
            Me.Address3LineControlNameAndAddress_Address.TabIndex = 2
            Me.Address3LineControlNameAndAddress_Address.Title = "Address"
            Me.Address3LineControlNameAndAddress_Address.Zip = Nothing
            '
            'LabelNameAndAddress_Phone
            '
            Me.LabelNameAndAddress_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNameAndAddress_Phone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNameAndAddress_Phone.Location = New System.Drawing.Point(5, 290)
            Me.LabelNameAndAddress_Phone.Name = "LabelNameAndAddress_Phone"
            Me.LabelNameAndAddress_Phone.Size = New System.Drawing.Size(40, 20)
            Me.LabelNameAndAddress_Phone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNameAndAddress_Phone.TabIndex = 3
            Me.LabelNameAndAddress_Phone.Text = "Phone:"
            '
            'TextBoxNameAndAddress_Phone
            '
            Me.TextBoxNameAndAddress_Phone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxNameAndAddress_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxNameAndAddress_Phone.Border.Class = "TextBoxBorder"
            Me.TextBoxNameAndAddress_Phone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxNameAndAddress_Phone.CheckSpellingOnValidate = False
            Me.TextBoxNameAndAddress_Phone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxNameAndAddress_Phone.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxNameAndAddress_Phone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxNameAndAddress_Phone.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxNameAndAddress_Phone.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxNameAndAddress_Phone.FocusHighlightEnabled = True
            Me.TextBoxNameAndAddress_Phone.ForeColor = System.Drawing.Color.Black
            Me.TextBoxNameAndAddress_Phone.Location = New System.Drawing.Point(51, 290)
            Me.TextBoxNameAndAddress_Phone.MaxFileSize = CType(0, Long)
            Me.TextBoxNameAndAddress_Phone.Name = "TextBoxNameAndAddress_Phone"
            Me.TextBoxNameAndAddress_Phone.SecurityEnabled = True
            Me.TextBoxNameAndAddress_Phone.ShowSpellCheckCompleteMessage = True
            Me.TextBoxNameAndAddress_Phone.Size = New System.Drawing.Size(249, 21)
            Me.TextBoxNameAndAddress_Phone.StartingFolderName = Nothing
            Me.TextBoxNameAndAddress_Phone.TabIndex = 4
            Me.TextBoxNameAndAddress_Phone.TabOnEnter = True
            '
            'LabelNameAndAddress_Fax
            '
            Me.LabelNameAndAddress_Fax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNameAndAddress_Fax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNameAndAddress_Fax.Location = New System.Drawing.Point(5, 316)
            Me.LabelNameAndAddress_Fax.Name = "LabelNameAndAddress_Fax"
            Me.LabelNameAndAddress_Fax.Size = New System.Drawing.Size(40, 20)
            Me.LabelNameAndAddress_Fax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNameAndAddress_Fax.TabIndex = 7
            Me.LabelNameAndAddress_Fax.Text = "Fax:"
            '
            'TextBoxNameAndAddress_Fax
            '
            Me.TextBoxNameAndAddress_Fax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxNameAndAddress_Fax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxNameAndAddress_Fax.Border.Class = "TextBoxBorder"
            Me.TextBoxNameAndAddress_Fax.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxNameAndAddress_Fax.CheckSpellingOnValidate = False
            Me.TextBoxNameAndAddress_Fax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxNameAndAddress_Fax.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxNameAndAddress_Fax.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxNameAndAddress_Fax.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxNameAndAddress_Fax.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxNameAndAddress_Fax.FocusHighlightEnabled = True
            Me.TextBoxNameAndAddress_Fax.ForeColor = System.Drawing.Color.Black
            Me.TextBoxNameAndAddress_Fax.Location = New System.Drawing.Point(51, 316)
            Me.TextBoxNameAndAddress_Fax.MaxFileSize = CType(0, Long)
            Me.TextBoxNameAndAddress_Fax.Name = "TextBoxNameAndAddress_Fax"
            Me.TextBoxNameAndAddress_Fax.SecurityEnabled = True
            Me.TextBoxNameAndAddress_Fax.ShowSpellCheckCompleteMessage = True
            Me.TextBoxNameAndAddress_Fax.Size = New System.Drawing.Size(249, 21)
            Me.TextBoxNameAndAddress_Fax.StartingFolderName = Nothing
            Me.TextBoxNameAndAddress_Fax.TabIndex = 8
            Me.TextBoxNameAndAddress_Fax.TabOnEnter = True
            '
            'LabelNameAndAddress_PhoneExt
            '
            Me.LabelNameAndAddress_PhoneExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelNameAndAddress_PhoneExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNameAndAddress_PhoneExt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNameAndAddress_PhoneExt.Location = New System.Drawing.Point(306, 290)
            Me.LabelNameAndAddress_PhoneExt.Name = "LabelNameAndAddress_PhoneExt"
            Me.LabelNameAndAddress_PhoneExt.Size = New System.Drawing.Size(24, 20)
            Me.LabelNameAndAddress_PhoneExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNameAndAddress_PhoneExt.TabIndex = 5
            Me.LabelNameAndAddress_PhoneExt.Text = "Ext:"
            '
            'LabelNameAndAddress_FaxExt
            '
            Me.LabelNameAndAddress_FaxExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelNameAndAddress_FaxExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNameAndAddress_FaxExt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNameAndAddress_FaxExt.Location = New System.Drawing.Point(306, 316)
            Me.LabelNameAndAddress_FaxExt.Name = "LabelNameAndAddress_FaxExt"
            Me.LabelNameAndAddress_FaxExt.Size = New System.Drawing.Size(24, 20)
            Me.LabelNameAndAddress_FaxExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNameAndAddress_FaxExt.TabIndex = 9
            Me.LabelNameAndAddress_FaxExt.Text = "Ext:"
            '
            'TextBoxNameAndAddress_FaxExt
            '
            Me.TextBoxNameAndAddress_FaxExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxNameAndAddress_FaxExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxNameAndAddress_FaxExt.Border.Class = "TextBoxBorder"
            Me.TextBoxNameAndAddress_FaxExt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxNameAndAddress_FaxExt.CheckSpellingOnValidate = False
            Me.TextBoxNameAndAddress_FaxExt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxNameAndAddress_FaxExt.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxNameAndAddress_FaxExt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxNameAndAddress_FaxExt.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxNameAndAddress_FaxExt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxNameAndAddress_FaxExt.FocusHighlightEnabled = True
            Me.TextBoxNameAndAddress_FaxExt.ForeColor = System.Drawing.Color.Black
            Me.TextBoxNameAndAddress_FaxExt.Location = New System.Drawing.Point(336, 316)
            Me.TextBoxNameAndAddress_FaxExt.MaxFileSize = CType(0, Long)
            Me.TextBoxNameAndAddress_FaxExt.Name = "TextBoxNameAndAddress_FaxExt"
            Me.TextBoxNameAndAddress_FaxExt.SecurityEnabled = True
            Me.TextBoxNameAndAddress_FaxExt.ShowSpellCheckCompleteMessage = True
            Me.TextBoxNameAndAddress_FaxExt.Size = New System.Drawing.Size(59, 21)
            Me.TextBoxNameAndAddress_FaxExt.StartingFolderName = Nothing
            Me.TextBoxNameAndAddress_FaxExt.TabIndex = 10
            Me.TextBoxNameAndAddress_FaxExt.TabOnEnter = True
            '
            'TextBoxNameAndAddress_PhoneExt
            '
            Me.TextBoxNameAndAddress_PhoneExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxNameAndAddress_PhoneExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxNameAndAddress_PhoneExt.Border.Class = "TextBoxBorder"
            Me.TextBoxNameAndAddress_PhoneExt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxNameAndAddress_PhoneExt.CheckSpellingOnValidate = False
            Me.TextBoxNameAndAddress_PhoneExt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxNameAndAddress_PhoneExt.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxNameAndAddress_PhoneExt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxNameAndAddress_PhoneExt.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxNameAndAddress_PhoneExt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxNameAndAddress_PhoneExt.FocusHighlightEnabled = True
            Me.TextBoxNameAndAddress_PhoneExt.ForeColor = System.Drawing.Color.Black
            Me.TextBoxNameAndAddress_PhoneExt.Location = New System.Drawing.Point(336, 290)
            Me.TextBoxNameAndAddress_PhoneExt.MaxFileSize = CType(0, Long)
            Me.TextBoxNameAndAddress_PhoneExt.Name = "TextBoxNameAndAddress_PhoneExt"
            Me.TextBoxNameAndAddress_PhoneExt.SecurityEnabled = True
            Me.TextBoxNameAndAddress_PhoneExt.ShowSpellCheckCompleteMessage = True
            Me.TextBoxNameAndAddress_PhoneExt.Size = New System.Drawing.Size(59, 21)
            Me.TextBoxNameAndAddress_PhoneExt.StartingFolderName = Nothing
            Me.TextBoxNameAndAddress_PhoneExt.TabIndex = 6
            Me.TextBoxNameAndAddress_PhoneExt.TabOnEnter = True
            '
            'CheckBoxMain_Inactive
            '
            Me.CheckBoxMain_Inactive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMain_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMain_Inactive.CheckValue = 0
            Me.CheckBoxMain_Inactive.CheckValueChecked = 1
            Me.CheckBoxMain_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMain_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxMain_Inactive.ChildControls = CType(resources.GetObject("CheckBoxMain_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMain_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMain_Inactive.Location = New System.Drawing.Point(123, 4)
            Me.CheckBoxMain_Inactive.Name = "CheckBoxMain_Inactive"
            Me.CheckBoxMain_Inactive.OldestSibling = Nothing
            Me.CheckBoxMain_Inactive.SecurityEnabled = True
            Me.CheckBoxMain_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxMain_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMain_Inactive.Size = New System.Drawing.Size(68, 20)
            Me.CheckBoxMain_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMain_Inactive.TabIndex = 3
            Me.CheckBoxMain_Inactive.TabOnEnter = True
            Me.CheckBoxMain_Inactive.Text = "Inactive"
            '
            'LabelMain_DefaultCategory
            '
            Me.LabelMain_DefaultCategory.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMain_DefaultCategory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMain_DefaultCategory.Location = New System.Drawing.Point(6, 377)
            Me.LabelMain_DefaultCategory.Name = "LabelMain_DefaultCategory"
            Me.LabelMain_DefaultCategory.Size = New System.Drawing.Size(135, 20)
            Me.LabelMain_DefaultCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMain_DefaultCategory.TabIndex = 14
            Me.LabelMain_DefaultCategory.Text = "Default Category:"
            '
            'TextBoxMain_FederalTaxID
            '
            Me.TextBoxMain_FederalTaxID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMain_FederalTaxID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMain_FederalTaxID.Border.Class = "TextBoxBorder"
            Me.TextBoxMain_FederalTaxID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMain_FederalTaxID.CheckSpellingOnValidate = False
            Me.TextBoxMain_FederalTaxID.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMain_FederalTaxID.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMain_FederalTaxID.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxMain_FederalTaxID.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMain_FederalTaxID.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMain_FederalTaxID.FocusHighlightEnabled = True
            Me.TextBoxMain_FederalTaxID.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMain_FederalTaxID.Location = New System.Drawing.Point(552, 377)
            Me.TextBoxMain_FederalTaxID.MaxFileSize = CType(0, Long)
            Me.TextBoxMain_FederalTaxID.Name = "TextBoxMain_FederalTaxID"
            Me.TextBoxMain_FederalTaxID.SecurityEnabled = True
            Me.TextBoxMain_FederalTaxID.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMain_FederalTaxID.Size = New System.Drawing.Size(259, 20)
            Me.TextBoxMain_FederalTaxID.StartingFolderName = Nothing
            Me.TextBoxMain_FederalTaxID.TabIndex = 25
            Me.TextBoxMain_FederalTaxID.TabOnEnter = True
            '
            'LabelMain_FederalTaxID
            '
            Me.LabelMain_FederalTaxID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMain_FederalTaxID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMain_FederalTaxID.Location = New System.Drawing.Point(419, 377)
            Me.LabelMain_FederalTaxID.Name = "LabelMain_FederalTaxID"
            Me.LabelMain_FederalTaxID.Size = New System.Drawing.Size(127, 20)
            Me.LabelMain_FederalTaxID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMain_FederalTaxID.TabIndex = 24
            Me.LabelMain_FederalTaxID.Text = "Federal Tax ID:"
            '
            'TextBoxMain_Website
            '
            Me.TextBoxMain_Website.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMain_Website.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMain_Website.Border.Class = "TextBoxBorder"
            Me.TextBoxMain_Website.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMain_Website.CheckSpellingOnValidate = False
            Me.TextBoxMain_Website.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMain_Website.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMain_Website.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxMain_Website.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMain_Website.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMain_Website.FocusHighlightEnabled = True
            Me.TextBoxMain_Website.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMain_Website.Location = New System.Drawing.Point(552, 429)
            Me.TextBoxMain_Website.MaxFileSize = CType(0, Long)
            Me.TextBoxMain_Website.Name = "TextBoxMain_Website"
            Me.TextBoxMain_Website.SecurityEnabled = True
            Me.TextBoxMain_Website.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMain_Website.Size = New System.Drawing.Size(259, 20)
            Me.TextBoxMain_Website.StartingFolderName = Nothing
            Me.TextBoxMain_Website.TabIndex = 29
            Me.TextBoxMain_Website.TabOnEnter = True
            '
            'TextBoxMain_Email
            '
            Me.TextBoxMain_Email.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMain_Email.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMain_Email.Border.Class = "TextBoxBorder"
            Me.TextBoxMain_Email.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMain_Email.CheckSpellingOnValidate = False
            Me.TextBoxMain_Email.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Email
            Me.TextBoxMain_Email.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMain_Email.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxMain_Email.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMain_Email.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMain_Email.FocusHighlightEnabled = True
            Me.TextBoxMain_Email.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMain_Email.Location = New System.Drawing.Point(552, 455)
            Me.TextBoxMain_Email.MaxFileSize = CType(0, Long)
            Me.TextBoxMain_Email.Name = "TextBoxMain_Email"
            Me.TextBoxMain_Email.SecurityEnabled = True
            Me.TextBoxMain_Email.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMain_Email.Size = New System.Drawing.Size(259, 20)
            Me.TextBoxMain_Email.StartingFolderName = Nothing
            Me.TextBoxMain_Email.TabIndex = 31
            Me.TextBoxMain_Email.TabOnEnter = True
            '
            'TextBoxMain_PaymentManagerEmail
            '
            Me.TextBoxMain_PaymentManagerEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMain_PaymentManagerEmail.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMain_PaymentManagerEmail.Border.Class = "TextBoxBorder"
            Me.TextBoxMain_PaymentManagerEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMain_PaymentManagerEmail.CheckSpellingOnValidate = False
            Me.TextBoxMain_PaymentManagerEmail.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Email
            Me.TextBoxMain_PaymentManagerEmail.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMain_PaymentManagerEmail.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxMain_PaymentManagerEmail.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMain_PaymentManagerEmail.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMain_PaymentManagerEmail.FocusHighlightEnabled = True
            Me.TextBoxMain_PaymentManagerEmail.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMain_PaymentManagerEmail.Location = New System.Drawing.Point(552, 481)
            Me.TextBoxMain_PaymentManagerEmail.MaxFileSize = CType(0, Long)
            Me.TextBoxMain_PaymentManagerEmail.Name = "TextBoxMain_PaymentManagerEmail"
            Me.TextBoxMain_PaymentManagerEmail.SecurityEnabled = True
            Me.TextBoxMain_PaymentManagerEmail.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMain_PaymentManagerEmail.Size = New System.Drawing.Size(259, 20)
            Me.TextBoxMain_PaymentManagerEmail.StartingFolderName = Nothing
            Me.TextBoxMain_PaymentManagerEmail.TabIndex = 33
            Me.TextBoxMain_PaymentManagerEmail.TabOnEnter = True
            '
            'LabelMain_PaymentManagerEmail
            '
            Me.LabelMain_PaymentManagerEmail.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMain_PaymentManagerEmail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMain_PaymentManagerEmail.Location = New System.Drawing.Point(419, 481)
            Me.LabelMain_PaymentManagerEmail.Name = "LabelMain_PaymentManagerEmail"
            Me.LabelMain_PaymentManagerEmail.Size = New System.Drawing.Size(127, 20)
            Me.LabelMain_PaymentManagerEmail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMain_PaymentManagerEmail.TabIndex = 32
            Me.LabelMain_PaymentManagerEmail.Text = "Payment Manager Email:"
            '
            'LabelMain_Email
            '
            Me.LabelMain_Email.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMain_Email.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMain_Email.Location = New System.Drawing.Point(419, 455)
            Me.LabelMain_Email.Name = "LabelMain_Email"
            Me.LabelMain_Email.Size = New System.Drawing.Size(127, 20)
            Me.LabelMain_Email.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMain_Email.TabIndex = 30
            Me.LabelMain_Email.Text = "Email:"
            '
            'LabelMain_Website
            '
            Me.LabelMain_Website.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMain_Website.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMain_Website.Location = New System.Drawing.Point(419, 429)
            Me.LabelMain_Website.Name = "LabelMain_Website"
            Me.LabelMain_Website.Size = New System.Drawing.Size(127, 20)
            Me.LabelMain_Website.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMain_Website.TabIndex = 28
            Me.LabelMain_Website.Text = "Website:"
            '
            'TextBoxMain_Code
            '
            Me.TextBoxMain_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMain_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxMain_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMain_Code.CheckSpellingOnValidate = False
            Me.TextBoxMain_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMain_Code.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMain_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxMain_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMain_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMain_Code.FocusHighlightEnabled = True
            Me.TextBoxMain_Code.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMain_Code.Location = New System.Drawing.Point(50, 4)
            Me.TextBoxMain_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxMain_Code.Name = "TextBoxMain_Code"
            Me.TextBoxMain_Code.SecurityEnabled = True
            Me.TextBoxMain_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMain_Code.Size = New System.Drawing.Size(67, 20)
            Me.TextBoxMain_Code.StartingFolderName = Nothing
            Me.TextBoxMain_Code.TabIndex = 2
            Me.TextBoxMain_Code.TabOnEnter = True
            '
            'LabelMain_Code
            '
            Me.LabelMain_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMain_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMain_Code.Location = New System.Drawing.Point(4, 4)
            Me.LabelMain_Code.Name = "LabelMain_Code"
            Me.LabelMain_Code.Size = New System.Drawing.Size(40, 20)
            Me.LabelMain_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMain_Code.TabIndex = 1
            Me.LabelMain_Code.Text = "Code:"
            '
            'TabItemVendorDetails_MainTab
            '
            Me.TabItemVendorDetails_MainTab.AttachedControl = Me.TabControlPanelMainTab_Main
            Me.TabItemVendorDetails_MainTab.Name = "TabItemVendorDetails_MainTab"
            Me.TabItemVendorDetails_MainTab.Text = "Main"
            '
            'TabControlPanelEEOC2Tab_EEOC2
            '
            Me.TabControlPanelEEOC2Tab_EEOC2.Controls.Add(Me.GroupBoxEEOC2_WomensBusinessDetails)
            Me.TabControlPanelEEOC2Tab_EEOC2.Controls.Add(Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails)
            Me.TabControlPanelEEOC2Tab_EEOC2.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelEEOC2Tab_EEOC2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEEOC2Tab_EEOC2.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEEOC2Tab_EEOC2.Name = "TabControlPanelEEOC2Tab_EEOC2"
            Me.TabControlPanelEEOC2Tab_EEOC2.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEEOC2Tab_EEOC2.Size = New System.Drawing.Size(815, 513)
            Me.TabControlPanelEEOC2Tab_EEOC2.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelEEOC2Tab_EEOC2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEEOC2Tab_EEOC2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEEOC2Tab_EEOC2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEEOC2Tab_EEOC2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEEOC2Tab_EEOC2.Style.GradientAngle = 90
            Me.TabControlPanelEEOC2Tab_EEOC2.TabIndex = 48
            Me.TabControlPanelEEOC2Tab_EEOC2.TabItem = Me.TabItemVendorDetails_EEOC2Tab
            '
            'GroupBoxEEOC2_WomensBusinessDetails
            '
            Me.GroupBoxEEOC2_WomensBusinessDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxEEOC2_WomensBusinessDetails.Controls.Add(Me.DateTimePickerWBD_WBENCCertificationExpirationDate)
            Me.GroupBoxEEOC2_WomensBusinessDetails.Controls.Add(Me.CheckBoxWBD_IsWBENC)
            Me.GroupBoxEEOC2_WomensBusinessDetails.Controls.Add(Me.LabelWBD_WBENCCertificationExpirationDate)
            Me.GroupBoxEEOC2_WomensBusinessDetails.Controls.Add(Me.LabelWBD_WBENCCertificationNumber)
            Me.GroupBoxEEOC2_WomensBusinessDetails.Controls.Add(Me.LabelWBD_WomensBusinessEnterpriseNationalCouncil)
            Me.GroupBoxEEOC2_WomensBusinessDetails.Controls.Add(Me.TextBoxWBD_WBENCCertificationNumber)
            Me.GroupBoxEEOC2_WomensBusinessDetails.Location = New System.Drawing.Point(4, 141)
            Me.GroupBoxEEOC2_WomensBusinessDetails.Name = "GroupBoxEEOC2_WomensBusinessDetails"
            Me.GroupBoxEEOC2_WomensBusinessDetails.Size = New System.Drawing.Size(807, 104)
            Me.GroupBoxEEOC2_WomensBusinessDetails.TabIndex = 2
            Me.GroupBoxEEOC2_WomensBusinessDetails.Text = "Women's Business Details"
            '
            'DateTimePickerWBD_WBENCCertificationExpirationDate
            '
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.ButtonDropDown.Visible = True
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.ButtonFreeText.Checked = True
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.DisplayName = ""
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.FocusHighlightEnabled = True
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.FreeTextEntryMode = True
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.IsPopupCalendarOpen = False
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.Location = New System.Drawing.Point(304, 76)
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.Name = "DateTimePickerWBD_WBENCCertificationExpirationDate"
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.ReadOnly = False
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.Size = New System.Drawing.Size(97, 21)
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.TabIndex = 5
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.TabOnEnter = True
            Me.DateTimePickerWBD_WBENCCertificationExpirationDate.Value = New Date(2013, 7, 23, 13, 58, 57, 313)
            '
            'CheckBoxWBD_IsWBENC
            '
            Me.CheckBoxWBD_IsWBENC.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxWBD_IsWBENC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxWBD_IsWBENC.CheckValue = 0
            Me.CheckBoxWBD_IsWBENC.CheckValueChecked = 1
            Me.CheckBoxWBD_IsWBENC.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxWBD_IsWBENC.CheckValueUnchecked = 0
            Me.CheckBoxWBD_IsWBENC.ChildControls = Nothing
            Me.CheckBoxWBD_IsWBENC.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxWBD_IsWBENC.Location = New System.Drawing.Point(304, 23)
            Me.CheckBoxWBD_IsWBENC.Name = "CheckBoxWBD_IsWBENC"
            Me.CheckBoxWBD_IsWBENC.OldestSibling = Nothing
            Me.CheckBoxWBD_IsWBENC.SecurityEnabled = True
            Me.CheckBoxWBD_IsWBENC.SiblingControls = Nothing
            Me.CheckBoxWBD_IsWBENC.Size = New System.Drawing.Size(24, 20)
            Me.CheckBoxWBD_IsWBENC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxWBD_IsWBENC.TabIndex = 1
            Me.CheckBoxWBD_IsWBENC.TabOnEnter = True
            '
            'LabelWBD_WBENCCertificationExpirationDate
            '
            Me.LabelWBD_WBENCCertificationExpirationDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelWBD_WBENCCertificationExpirationDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelWBD_WBENCCertificationExpirationDate.Location = New System.Drawing.Point(5, 75)
            Me.LabelWBD_WBENCCertificationExpirationDate.Name = "LabelWBD_WBENCCertificationExpirationDate"
            Me.LabelWBD_WBENCCertificationExpirationDate.Size = New System.Drawing.Size(293, 20)
            Me.LabelWBD_WBENCCertificationExpirationDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelWBD_WBENCCertificationExpirationDate.TabIndex = 4
            Me.LabelWBD_WBENCCertificationExpirationDate.Text = "WBENC Certification Expiration Date:"
            '
            'LabelWBD_WBENCCertificationNumber
            '
            Me.LabelWBD_WBENCCertificationNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelWBD_WBENCCertificationNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelWBD_WBENCCertificationNumber.Location = New System.Drawing.Point(5, 49)
            Me.LabelWBD_WBENCCertificationNumber.Name = "LabelWBD_WBENCCertificationNumber"
            Me.LabelWBD_WBENCCertificationNumber.Size = New System.Drawing.Size(293, 20)
            Me.LabelWBD_WBENCCertificationNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelWBD_WBENCCertificationNumber.TabIndex = 2
            Me.LabelWBD_WBENCCertificationNumber.Text = "WBENC Certification Number:"
            '
            'LabelWBD_WomensBusinessEnterpriseNationalCouncil
            '
            Me.LabelWBD_WomensBusinessEnterpriseNationalCouncil.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelWBD_WomensBusinessEnterpriseNationalCouncil.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelWBD_WomensBusinessEnterpriseNationalCouncil.Location = New System.Drawing.Point(5, 23)
            Me.LabelWBD_WomensBusinessEnterpriseNationalCouncil.Name = "LabelWBD_WomensBusinessEnterpriseNationalCouncil"
            Me.LabelWBD_WomensBusinessEnterpriseNationalCouncil.Size = New System.Drawing.Size(293, 20)
            Me.LabelWBD_WomensBusinessEnterpriseNationalCouncil.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelWBD_WomensBusinessEnterpriseNationalCouncil.TabIndex = 0
            Me.LabelWBD_WomensBusinessEnterpriseNationalCouncil.Text = "Women's Business Enterprise National Council (WBENC):"
            '
            'TextBoxWBD_WBENCCertificationNumber
            '
            Me.TextBoxWBD_WBENCCertificationNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxWBD_WBENCCertificationNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxWBD_WBENCCertificationNumber.Border.Class = "TextBoxBorder"
            Me.TextBoxWBD_WBENCCertificationNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxWBD_WBENCCertificationNumber.CheckSpellingOnValidate = False
            Me.TextBoxWBD_WBENCCertificationNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxWBD_WBENCCertificationNumber.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxWBD_WBENCCertificationNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxWBD_WBENCCertificationNumber.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxWBD_WBENCCertificationNumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxWBD_WBENCCertificationNumber.FocusHighlightEnabled = True
            Me.TextBoxWBD_WBENCCertificationNumber.ForeColor = System.Drawing.Color.Black
            Me.TextBoxWBD_WBENCCertificationNumber.Location = New System.Drawing.Point(304, 49)
            Me.TextBoxWBD_WBENCCertificationNumber.MaxFileSize = CType(0, Long)
            Me.TextBoxWBD_WBENCCertificationNumber.Name = "TextBoxWBD_WBENCCertificationNumber"
            Me.TextBoxWBD_WBENCCertificationNumber.SecurityEnabled = True
            Me.TextBoxWBD_WBENCCertificationNumber.ShowSpellCheckCompleteMessage = True
            Me.TextBoxWBD_WBENCCertificationNumber.Size = New System.Drawing.Size(498, 21)
            Me.TextBoxWBD_WBENCCertificationNumber.StartingFolderName = Nothing
            Me.TextBoxWBD_WBENCCertificationNumber.TabIndex = 3
            Me.TextBoxWBD_WBENCCertificationNumber.TabOnEnter = True
            '
            'GroupBoxEEOC2_MinorityOwnedBusinessDetails
            '
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails.Controls.Add(Me.LabelMOBD_NationalMinoritySupplierDevelopmentCouncil)
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails.Controls.Add(Me.CheckBoxMODB_IsNMSDC)
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails.Controls.Add(Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate)
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails.Controls.Add(Me.LabelMOBD_MinorityCertifcateNumberExpirationDate)
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails.Controls.Add(Me.SearchableComboBoxMOBD_Ethnicity)
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails.Controls.Add(Me.LabelMOBD_Ethnicity)
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails.Controls.Add(Me.LabelMOBD_MinorityCertifcateNumber)
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails.Controls.Add(Me.TextBoxMOBD_MinorityCertifcateNumber)
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails.Name = "GroupBoxEEOC2_MinorityOwnedBusinessDetails"
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails.Size = New System.Drawing.Size(808, 131)
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails.TabIndex = 1
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails.Text = "Minority Owned Business Details"
            '
            'LabelMOBD_NationalMinoritySupplierDevelopmentCouncil
            '
            Me.LabelMOBD_NationalMinoritySupplierDevelopmentCouncil.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMOBD_NationalMinoritySupplierDevelopmentCouncil.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMOBD_NationalMinoritySupplierDevelopmentCouncil.Location = New System.Drawing.Point(5, 101)
            Me.LabelMOBD_NationalMinoritySupplierDevelopmentCouncil.Name = "LabelMOBD_NationalMinoritySupplierDevelopmentCouncil"
            Me.LabelMOBD_NationalMinoritySupplierDevelopmentCouncil.Size = New System.Drawing.Size(293, 20)
            Me.LabelMOBD_NationalMinoritySupplierDevelopmentCouncil.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMOBD_NationalMinoritySupplierDevelopmentCouncil.TabIndex = 6
            Me.LabelMOBD_NationalMinoritySupplierDevelopmentCouncil.Text = "National Minority Supplier Development Council (NMSDC):"
            '
            'CheckBoxMODB_IsNMSDC
            '
            Me.CheckBoxMODB_IsNMSDC.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMODB_IsNMSDC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMODB_IsNMSDC.CheckValue = 0
            Me.CheckBoxMODB_IsNMSDC.CheckValueChecked = 1
            Me.CheckBoxMODB_IsNMSDC.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxMODB_IsNMSDC.CheckValueUnchecked = 0
            Me.CheckBoxMODB_IsNMSDC.ChildControls = Nothing
            Me.CheckBoxMODB_IsNMSDC.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMODB_IsNMSDC.Location = New System.Drawing.Point(304, 101)
            Me.CheckBoxMODB_IsNMSDC.Name = "CheckBoxMODB_IsNMSDC"
            Me.CheckBoxMODB_IsNMSDC.OldestSibling = Nothing
            Me.CheckBoxMODB_IsNMSDC.SecurityEnabled = True
            Me.CheckBoxMODB_IsNMSDC.SiblingControls = Nothing
            Me.CheckBoxMODB_IsNMSDC.Size = New System.Drawing.Size(24, 20)
            Me.CheckBoxMODB_IsNMSDC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMODB_IsNMSDC.TabIndex = 7
            Me.CheckBoxMODB_IsNMSDC.TabOnEnter = True
            '
            'DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate
            '
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.ButtonDropDown.Visible = True
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.ButtonFreeText.Checked = True
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.DisplayName = ""
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.FocusHighlightEnabled = True
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.FreeTextEntryMode = True
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.IsPopupCalendarOpen = False
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.Location = New System.Drawing.Point(304, 75)
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.Name = "DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate"
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.ReadOnly = False
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.Size = New System.Drawing.Size(97, 21)
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.TabIndex = 5
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.TabOnEnter = True
            Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate.Value = New Date(2013, 7, 23, 13, 58, 57, 313)
            '
            'LabelMOBD_MinorityCertifcateNumberExpirationDate
            '
            Me.LabelMOBD_MinorityCertifcateNumberExpirationDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMOBD_MinorityCertifcateNumberExpirationDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMOBD_MinorityCertifcateNumberExpirationDate.Location = New System.Drawing.Point(5, 75)
            Me.LabelMOBD_MinorityCertifcateNumberExpirationDate.Name = "LabelMOBD_MinorityCertifcateNumberExpirationDate"
            Me.LabelMOBD_MinorityCertifcateNumberExpirationDate.Size = New System.Drawing.Size(293, 20)
            Me.LabelMOBD_MinorityCertifcateNumberExpirationDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMOBD_MinorityCertifcateNumberExpirationDate.TabIndex = 4
            Me.LabelMOBD_MinorityCertifcateNumberExpirationDate.Text = "Minority Certifcate Number Expiration Date:"
            '
            'SearchableComboBoxMOBD_Ethnicity
            '
            Me.SearchableComboBoxMOBD_Ethnicity.ActiveFilterString = ""
            Me.SearchableComboBoxMOBD_Ethnicity.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxMOBD_Ethnicity.AutoFillMode = False
            Me.SearchableComboBoxMOBD_Ethnicity.BookmarkingEnabled = False
            Me.SearchableComboBoxMOBD_Ethnicity.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.EnumObjects
            Me.SearchableComboBoxMOBD_Ethnicity.DataSource = Nothing
            Me.SearchableComboBoxMOBD_Ethnicity.DisableMouseWheel = False
            Me.SearchableComboBoxMOBD_Ethnicity.DisplayName = ""
            Me.SearchableComboBoxMOBD_Ethnicity.EnterMoveNextControl = True
            Me.SearchableComboBoxMOBD_Ethnicity.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxMOBD_Ethnicity.Location = New System.Drawing.Point(304, 23)
            Me.SearchableComboBoxMOBD_Ethnicity.Name = "SearchableComboBoxMOBD_Ethnicity"
            Me.SearchableComboBoxMOBD_Ethnicity.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxMOBD_Ethnicity.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxMOBD_Ethnicity.Properties.NullText = "Select"
            Me.SearchableComboBoxMOBD_Ethnicity.Properties.PopupView = Me.GridView16
            Me.SearchableComboBoxMOBD_Ethnicity.Properties.ShowClearButton = False
            Me.SearchableComboBoxMOBD_Ethnicity.Properties.ValueMember = "Code"
            Me.SearchableComboBoxMOBD_Ethnicity.SecurityEnabled = True
            Me.SearchableComboBoxMOBD_Ethnicity.SelectedValue = Nothing
            Me.SearchableComboBoxMOBD_Ethnicity.Size = New System.Drawing.Size(219, 20)
            Me.SearchableComboBoxMOBD_Ethnicity.TabIndex = 1
            '
            'GridView16
            '
            Me.GridView16.AFActiveFilterString = ""
            Me.GridView16.AllowExtraItemsInGridLookupEdits = True
            Me.GridView16.AutoFilterLookupColumns = False
            Me.GridView16.AutoloadRepositoryDatasource = True
            Me.GridView16.DataSourceClearing = False
            Me.GridView16.EnableDisabledRows = False
            Me.GridView16.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView16.Name = "GridView16"
            Me.GridView16.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView16.OptionsView.ShowGroupPanel = False
            Me.GridView16.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView16.RunStandardValidation = True
            Me.GridView16.SkipAddingControlsOnModifyColumn = False
            Me.GridView16.SkipSettingFontOnModifyColumn = False
            '
            'LabelMOBD_Ethnicity
            '
            Me.LabelMOBD_Ethnicity.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMOBD_Ethnicity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMOBD_Ethnicity.Location = New System.Drawing.Point(5, 23)
            Me.LabelMOBD_Ethnicity.Name = "LabelMOBD_Ethnicity"
            Me.LabelMOBD_Ethnicity.Size = New System.Drawing.Size(293, 20)
            Me.LabelMOBD_Ethnicity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMOBD_Ethnicity.TabIndex = 0
            Me.LabelMOBD_Ethnicity.Text = "Ethnicity:"
            '
            'LabelMOBD_MinorityCertifcateNumber
            '
            Me.LabelMOBD_MinorityCertifcateNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMOBD_MinorityCertifcateNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMOBD_MinorityCertifcateNumber.Location = New System.Drawing.Point(5, 49)
            Me.LabelMOBD_MinorityCertifcateNumber.Name = "LabelMOBD_MinorityCertifcateNumber"
            Me.LabelMOBD_MinorityCertifcateNumber.Size = New System.Drawing.Size(293, 20)
            Me.LabelMOBD_MinorityCertifcateNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMOBD_MinorityCertifcateNumber.TabIndex = 2
            Me.LabelMOBD_MinorityCertifcateNumber.Text = "Minority Certifcate Number:"
            '
            'TextBoxMOBD_MinorityCertifcateNumber
            '
            Me.TextBoxMOBD_MinorityCertifcateNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMOBD_MinorityCertifcateNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMOBD_MinorityCertifcateNumber.Border.Class = "TextBoxBorder"
            Me.TextBoxMOBD_MinorityCertifcateNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMOBD_MinorityCertifcateNumber.CheckSpellingOnValidate = False
            Me.TextBoxMOBD_MinorityCertifcateNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMOBD_MinorityCertifcateNumber.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMOBD_MinorityCertifcateNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxMOBD_MinorityCertifcateNumber.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMOBD_MinorityCertifcateNumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMOBD_MinorityCertifcateNumber.FocusHighlightEnabled = True
            Me.TextBoxMOBD_MinorityCertifcateNumber.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMOBD_MinorityCertifcateNumber.Location = New System.Drawing.Point(304, 49)
            Me.TextBoxMOBD_MinorityCertifcateNumber.MaxFileSize = CType(0, Long)
            Me.TextBoxMOBD_MinorityCertifcateNumber.Name = "TextBoxMOBD_MinorityCertifcateNumber"
            Me.TextBoxMOBD_MinorityCertifcateNumber.SecurityEnabled = True
            Me.TextBoxMOBD_MinorityCertifcateNumber.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMOBD_MinorityCertifcateNumber.Size = New System.Drawing.Size(499, 21)
            Me.TextBoxMOBD_MinorityCertifcateNumber.StartingFolderName = Nothing
            Me.TextBoxMOBD_MinorityCertifcateNumber.TabIndex = 3
            Me.TextBoxMOBD_MinorityCertifcateNumber.TabOnEnter = True
            '
            'TabItemVendorDetails_EEOC2Tab
            '
            Me.TabItemVendorDetails_EEOC2Tab.AttachedControl = Me.TabControlPanelEEOC2Tab_EEOC2
            Me.TabItemVendorDetails_EEOC2Tab.Name = "TabItemVendorDetails_EEOC2Tab"
            Me.TabItemVendorDetails_EEOC2Tab.Text = "EEOC 2"
            '
            'TabControlPanelEEOCStatusTab_EEOCStatus
            '
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.Controls.Add(Me.PanelControl_RightSection)
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.Controls.Add(Me.ExpandableSplitterControl_LeftRight)
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.Controls.Add(Me.PanelControl_LeftSection)
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.Name = "TabControlPanelEEOCStatusTab_EEOCStatus"
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.Size = New System.Drawing.Size(815, 513)
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.Style.GradientAngle = 90
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.TabIndex = 9
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.TabItem = Me.TabItemVendorDetails_EEOCStatusTab
            '
            'PanelControl_RightSection
            '
            Me.PanelControl_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelControl_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelControl_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_RightSection.Controls.Add(Me.ButtonRightSection_RemoveEEOCStatus)
            Me.PanelControl_RightSection.Controls.Add(Me.ButtonRightSection_AddEEOCStatus)
            Me.PanelControl_RightSection.Controls.Add(Me.DataGridViewRightSection_SelectedEEOCStatuses)
            Me.PanelControl_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_RightSection.Location = New System.Drawing.Point(254, 1)
            Me.PanelControl_RightSection.Name = "PanelControl_RightSection"
            Me.PanelControl_RightSection.Size = New System.Drawing.Size(560, 511)
            Me.PanelControl_RightSection.TabIndex = 34
            '
            'ButtonRightSection_RemoveEEOCStatus
            '
            Me.ButtonRightSection_RemoveEEOCStatus.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveEEOCStatus.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveEEOCStatus.Location = New System.Drawing.Point(6, 30)
            Me.ButtonRightSection_RemoveEEOCStatus.Name = "ButtonRightSection_RemoveEEOCStatus"
            Me.ButtonRightSection_RemoveEEOCStatus.SecurityEnabled = True
            Me.ButtonRightSection_RemoveEEOCStatus.Size = New System.Drawing.Size(73, 20)
            Me.ButtonRightSection_RemoveEEOCStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveEEOCStatus.TabIndex = 1
            Me.ButtonRightSection_RemoveEEOCStatus.Text = "<"
            '
            'ButtonRightSection_AddEEOCStatus
            '
            Me.ButtonRightSection_AddEEOCStatus.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddEEOCStatus.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddEEOCStatus.Location = New System.Drawing.Point(6, 4)
            Me.ButtonRightSection_AddEEOCStatus.Name = "ButtonRightSection_AddEEOCStatus"
            Me.ButtonRightSection_AddEEOCStatus.SecurityEnabled = True
            Me.ButtonRightSection_AddEEOCStatus.Size = New System.Drawing.Size(73, 20)
            Me.ButtonRightSection_AddEEOCStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddEEOCStatus.TabIndex = 0
            Me.ButtonRightSection_AddEEOCStatus.Text = ">"
            '
            'DataGridViewRightSection_SelectedEEOCStatuses
            '
            Me.DataGridViewRightSection_SelectedEEOCStatuses.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightSection_SelectedEEOCStatuses.AllowDragAndDrop = False
            Me.DataGridViewRightSection_SelectedEEOCStatuses.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_SelectedEEOCStatuses.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_SelectedEEOCStatuses.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_SelectedEEOCStatuses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_SelectedEEOCStatuses.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_SelectedEEOCStatuses.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_SelectedEEOCStatuses.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_SelectedEEOCStatuses.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewRightSection_SelectedEEOCStatuses.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_SelectedEEOCStatuses.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_SelectedEEOCStatuses.ItemDescription = "Selected EEOC Status(es)"
            Me.DataGridViewRightSection_SelectedEEOCStatuses.Location = New System.Drawing.Point(85, 4)
            Me.DataGridViewRightSection_SelectedEEOCStatuses.MultiSelect = True
            Me.DataGridViewRightSection_SelectedEEOCStatuses.Name = "DataGridViewRightSection_SelectedEEOCStatuses"
            Me.DataGridViewRightSection_SelectedEEOCStatuses.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_SelectedEEOCStatuses.RunStandardValidation = True
            Me.DataGridViewRightSection_SelectedEEOCStatuses.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightSection_SelectedEEOCStatuses.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_SelectedEEOCStatuses.Size = New System.Drawing.Size(472, 504)
            Me.DataGridViewRightSection_SelectedEEOCStatuses.TabIndex = 2
            Me.DataGridViewRightSection_SelectedEEOCStatuses.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_SelectedEEOCStatuses.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControl_LeftRight
            '
            Me.ExpandableSplitterControl_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControl_LeftRight.ExpandableControl = Me.PanelControl_LeftSection
            Me.ExpandableSplitterControl_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControl_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControl_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControl_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl_LeftRight.Location = New System.Drawing.Point(248, 1)
            Me.ExpandableSplitterControl_LeftRight.Name = "ExpandableSplitterControl_LeftRight"
            Me.ExpandableSplitterControl_LeftRight.Size = New System.Drawing.Size(6, 511)
            Me.ExpandableSplitterControl_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControl_LeftRight.TabIndex = 35
            Me.ExpandableSplitterControl_LeftRight.TabStop = False
            '
            'PanelControl_LeftSection
            '
            Me.PanelControl_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelControl_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelControl_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableEEOCStatuses)
            Me.PanelControl_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelControl_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelControl_LeftSection.Name = "PanelControl_LeftSection"
            Me.PanelControl_LeftSection.Size = New System.Drawing.Size(247, 511)
            Me.PanelControl_LeftSection.TabIndex = 33
            '
            'DataGridViewLeftSection_AvailableEEOCStatuses
            '
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.ItemDescription = "Available EEOC Status(es)"
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.Name = "DataGridViewLeftSection_AvailableEEOCStatuses"
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.RunStandardValidation = True
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.Size = New System.Drawing.Size(237, 504)
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.TabIndex = 0
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableEEOCStatuses.ViewCaptionHeight = -1
            '
            'TabItemVendorDetails_EEOCStatusTab
            '
            Me.TabItemVendorDetails_EEOCStatusTab.AttachedControl = Me.TabControlPanelEEOCStatusTab_EEOCStatus
            Me.TabItemVendorDetails_EEOCStatusTab.Name = "TabItemVendorDetails_EEOCStatusTab"
            Me.TabItemVendorDetails_EEOCStatusTab.Text = "EEOC Status"
            '
            'TabControlPanelLineDefaultsNotesTab_DefaultsNotes
            '
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.Controls.Add(Me.TableLayoutPanelDefaultsNotes_TableLayout)
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.Controls.Add(Me.LabelDefaultNotes_Notes)
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.Controls.Add(Me.TextBoxDefaultNotes_Notes)
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.Name = "TabControlPanelLineDefaultsNotesTab_DefaultsNotes"
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.Size = New System.Drawing.Size(815, 513)
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.Style.GradientAngle = 90
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.TabIndex = 1
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.TabItem = Me.TabItemVendorDetails_DefaultsNotesTab
            '
            'TableLayoutPanelDefaultsNotes_TableLayout
            '
            Me.TableLayoutPanelDefaultsNotes_TableLayout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelDefaultsNotes_TableLayout.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelDefaultsNotes_TableLayout.ColumnCount = 2
            Me.TableLayoutPanelDefaultsNotes_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelDefaultsNotes_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelDefaultsNotes_TableLayout.Controls.Add(Me.PanelRightColumn_DefaultsNotes, 1, 0)
            Me.TableLayoutPanelDefaultsNotes_TableLayout.Controls.Add(Me.PanelLeftColumn_DefaultsNotes, 0, 0)
            Me.TableLayoutPanelDefaultsNotes_TableLayout.Location = New System.Drawing.Point(4, 4)
            Me.TableLayoutPanelDefaultsNotes_TableLayout.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanelDefaultsNotes_TableLayout.Name = "TableLayoutPanelDefaultsNotes_TableLayout"
            Me.TableLayoutPanelDefaultsNotes_TableLayout.RowCount = 1
            Me.TableLayoutPanelDefaultsNotes_TableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelDefaultsNotes_TableLayout.Size = New System.Drawing.Size(806, 207)
            Me.TableLayoutPanelDefaultsNotes_TableLayout.TabIndex = 0
            '
            'PanelRightColumn_DefaultsNotes
            '
            Me.PanelRightColumn_DefaultsNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelRightColumn_DefaultsNotes.Controls.Add(Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder)
            Me.PanelRightColumn_DefaultsNotes.Controls.Add(Me.NumericInputDefaultNotes_VCCLimit)
            Me.PanelRightColumn_DefaultsNotes.Controls.Add(Me.LabelDefaultNotes_VCCLimit)
            Me.PanelRightColumn_DefaultsNotes.Controls.Add(Me.SearchableComboBoxDefaultNotes_Terms)
            Me.PanelRightColumn_DefaultsNotes.Controls.Add(Me.SearchableComboBoxDefaultNotes_DefaultBank)
            Me.PanelRightColumn_DefaultsNotes.Controls.Add(Me.SearchableComboBoxDefaultNotes_DefaultFunction)
            Me.PanelRightColumn_DefaultsNotes.Controls.Add(Me.CheckBoxDefaultNotes_SpecialTerms)
            Me.PanelRightColumn_DefaultsNotes.Controls.Add(Me.ComboBoxDefaultNotes_VCCStatus)
            Me.PanelRightColumn_DefaultsNotes.Controls.Add(Me.LabelDefaultNotes_VCCStatus)
            Me.PanelRightColumn_DefaultsNotes.Controls.Add(Me.LabelDefaultNotes_DefaultFunction)
            Me.PanelRightColumn_DefaultsNotes.Controls.Add(Me.LabelDefaultNotes_Terms)
            Me.PanelRightColumn_DefaultsNotes.Controls.Add(Me.LabelDefaultNotes_DefaultBank)
            Me.PanelRightColumn_DefaultsNotes.Controls.Add(Me.ComboBoxDefaultNotes_ACHType)
            Me.PanelRightColumn_DefaultsNotes.Controls.Add(Me.CheckBoxDefaultNotes_ACH)
            Me.PanelRightColumn_DefaultsNotes.Controls.Add(Me.CheckBoxDefaultNotes_EmployeeVendor)
            Me.PanelRightColumn_DefaultsNotes.Controls.Add(Me.CheckBoxDefaultNotes_OneCheckPerInvoice)
            Me.PanelRightColumn_DefaultsNotes.Location = New System.Drawing.Point(403, 0)
            Me.PanelRightColumn_DefaultsNotes.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelRightColumn_DefaultsNotes.Name = "PanelRightColumn_DefaultsNotes"
            Me.PanelRightColumn_DefaultsNotes.Size = New System.Drawing.Size(403, 207)
            Me.PanelRightColumn_DefaultsNotes.TabIndex = 1
            '
            'CheckBoxDefaultNotes_SendVCCWithMediaOrder
            '
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.CheckValue = 0
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.CheckValueChecked = 1
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.CheckValueUnchecked = 0
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.ChildControls = Nothing
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.Location = New System.Drawing.Point(103, 182)
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.Name = "CheckBoxDefaultNotes_SendVCCWithMediaOrder"
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.OldestSibling = Nothing
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.SecurityEnabled = True
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.SiblingControls = CType(resources.GetObject("CheckBoxDefaultNotes_SendVCCWithMediaOrder.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.Size = New System.Drawing.Size(301, 20)
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.TabIndex = 15
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.TabOnEnter = True
            Me.CheckBoxDefaultNotes_SendVCCWithMediaOrder.Text = "Send VCC with Order"
            '
            'NumericInputDefaultNotes_VCCLimit
            '
            Me.NumericInputDefaultNotes_VCCLimit.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDefaultNotes_VCCLimit.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Currency
            Me.NumericInputDefaultNotes_VCCLimit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDefaultNotes_VCCLimit.EnterMoveNextControl = True
            Me.NumericInputDefaultNotes_VCCLimit.Location = New System.Drawing.Point(103, 156)
            Me.NumericInputDefaultNotes_VCCLimit.Name = "NumericInputDefaultNotes_VCCLimit"
            Me.NumericInputDefaultNotes_VCCLimit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputDefaultNotes_VCCLimit.Properties.DisplayFormat.FormatString = "c2"
            Me.NumericInputDefaultNotes_VCCLimit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDefaultNotes_VCCLimit.Properties.EditFormat.FormatString = "c2"
            Me.NumericInputDefaultNotes_VCCLimit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDefaultNotes_VCCLimit.Properties.Mask.EditMask = "c2"
            Me.NumericInputDefaultNotes_VCCLimit.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDefaultNotes_VCCLimit.SecurityEnabled = True
            Me.NumericInputDefaultNotes_VCCLimit.Size = New System.Drawing.Size(151, 20)
            Me.NumericInputDefaultNotes_VCCLimit.TabIndex = 13
            '
            'LabelDefaultNotes_VCCLimit
            '
            Me.LabelDefaultNotes_VCCLimit.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultNotes_VCCLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultNotes_VCCLimit.Location = New System.Drawing.Point(4, 156)
            Me.LabelDefaultNotes_VCCLimit.Name = "LabelDefaultNotes_VCCLimit"
            Me.LabelDefaultNotes_VCCLimit.Size = New System.Drawing.Size(91, 20)
            Me.LabelDefaultNotes_VCCLimit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultNotes_VCCLimit.TabIndex = 12
            Me.LabelDefaultNotes_VCCLimit.Text = "VCC Limit:"
            '
            'SearchableComboBoxDefaultNotes_Terms
            '
            Me.SearchableComboBoxDefaultNotes_Terms.ActiveFilterString = ""
            Me.SearchableComboBoxDefaultNotes_Terms.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDefaultNotes_Terms.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxDefaultNotes_Terms.AutoFillMode = False
            Me.SearchableComboBoxDefaultNotes_Terms.BookmarkingEnabled = False
            Me.SearchableComboBoxDefaultNotes_Terms.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.VendorTerm
            Me.SearchableComboBoxDefaultNotes_Terms.DataSource = Nothing
            Me.SearchableComboBoxDefaultNotes_Terms.DisableMouseWheel = False
            Me.SearchableComboBoxDefaultNotes_Terms.DisplayName = ""
            Me.SearchableComboBoxDefaultNotes_Terms.EnterMoveNextControl = True
            Me.SearchableComboBoxDefaultNotes_Terms.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxDefaultNotes_Terms.Location = New System.Drawing.Point(103, 26)
            Me.SearchableComboBoxDefaultNotes_Terms.Name = "SearchableComboBoxDefaultNotes_Terms"
            Me.SearchableComboBoxDefaultNotes_Terms.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDefaultNotes_Terms.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDefaultNotes_Terms.Properties.NullText = "Select Term"
            Me.SearchableComboBoxDefaultNotes_Terms.Properties.PopupView = Me.GridView7
            Me.SearchableComboBoxDefaultNotes_Terms.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDefaultNotes_Terms.SecurityEnabled = True
            Me.SearchableComboBoxDefaultNotes_Terms.SelectedValue = Nothing
            Me.SearchableComboBoxDefaultNotes_Terms.Size = New System.Drawing.Size(300, 20)
            Me.SearchableComboBoxDefaultNotes_Terms.TabIndex = 3
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
            'SearchableComboBoxDefaultNotes_DefaultBank
            '
            Me.SearchableComboBoxDefaultNotes_DefaultBank.ActiveFilterString = ""
            Me.SearchableComboBoxDefaultNotes_DefaultBank.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDefaultNotes_DefaultBank.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxDefaultNotes_DefaultBank.AutoFillMode = False
            Me.SearchableComboBoxDefaultNotes_DefaultBank.BookmarkingEnabled = False
            Me.SearchableComboBoxDefaultNotes_DefaultBank.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Bank
            Me.SearchableComboBoxDefaultNotes_DefaultBank.DataSource = Nothing
            Me.SearchableComboBoxDefaultNotes_DefaultBank.DisableMouseWheel = False
            Me.SearchableComboBoxDefaultNotes_DefaultBank.DisplayName = ""
            Me.SearchableComboBoxDefaultNotes_DefaultBank.EnterMoveNextControl = True
            Me.SearchableComboBoxDefaultNotes_DefaultBank.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxDefaultNotes_DefaultBank.Location = New System.Drawing.Point(103, 104)
            Me.SearchableComboBoxDefaultNotes_DefaultBank.Name = "SearchableComboBoxDefaultNotes_DefaultBank"
            Me.SearchableComboBoxDefaultNotes_DefaultBank.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDefaultNotes_DefaultBank.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDefaultNotes_DefaultBank.Properties.NullText = "Select Bank"
            Me.SearchableComboBoxDefaultNotes_DefaultBank.Properties.PopupView = Me.GridView6
            Me.SearchableComboBoxDefaultNotes_DefaultBank.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDefaultNotes_DefaultBank.SecurityEnabled = True
            Me.SearchableComboBoxDefaultNotes_DefaultBank.SelectedValue = Nothing
            Me.SearchableComboBoxDefaultNotes_DefaultBank.Size = New System.Drawing.Size(300, 20)
            Me.SearchableComboBoxDefaultNotes_DefaultBank.TabIndex = 9
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
            'SearchableComboBoxDefaultNotes_DefaultFunction
            '
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.ActiveFilterString = ""
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.AutoFillMode = False
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.BookmarkingEnabled = False
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.[Function]
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.DataSource = Nothing
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.DisableMouseWheel = False
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.DisplayName = ""
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.EnterMoveNextControl = True
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.Location = New System.Drawing.Point(103, 0)
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.Name = "SearchableComboBoxDefaultNotes_DefaultFunction"
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.Properties.NullText = "Select Function"
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.Properties.PopupView = Me.GridView5
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.SecurityEnabled = True
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.SelectedValue = Nothing
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.Size = New System.Drawing.Size(300, 20)
            Me.SearchableComboBoxDefaultNotes_DefaultFunction.TabIndex = 1
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
            'CheckBoxDefaultNotes_SpecialTerms
            '
            Me.CheckBoxDefaultNotes_SpecialTerms.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxDefaultNotes_SpecialTerms.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDefaultNotes_SpecialTerms.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDefaultNotes_SpecialTerms.CheckValue = 0
            Me.CheckBoxDefaultNotes_SpecialTerms.CheckValueChecked = 1
            Me.CheckBoxDefaultNotes_SpecialTerms.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDefaultNotes_SpecialTerms.CheckValueUnchecked = 0
            Me.CheckBoxDefaultNotes_SpecialTerms.ChildControls = Nothing
            Me.CheckBoxDefaultNotes_SpecialTerms.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDefaultNotes_SpecialTerms.Location = New System.Drawing.Point(260, 156)
            Me.CheckBoxDefaultNotes_SpecialTerms.Name = "CheckBoxDefaultNotes_SpecialTerms"
            Me.CheckBoxDefaultNotes_SpecialTerms.OldestSibling = Nothing
            Me.CheckBoxDefaultNotes_SpecialTerms.SecurityEnabled = True
            Me.CheckBoxDefaultNotes_SpecialTerms.SiblingControls = CType(resources.GetObject("CheckBoxDefaultNotes_SpecialTerms.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDefaultNotes_SpecialTerms.Size = New System.Drawing.Size(142, 20)
            Me.CheckBoxDefaultNotes_SpecialTerms.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDefaultNotes_SpecialTerms.TabIndex = 14
            Me.CheckBoxDefaultNotes_SpecialTerms.TabOnEnter = True
            Me.CheckBoxDefaultNotes_SpecialTerms.Text = "Special Terms"
            '
            'ComboBoxDefaultNotes_VCCStatus
            '
            Me.ComboBoxDefaultNotes_VCCStatus.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxDefaultNotes_VCCStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxDefaultNotes_VCCStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxDefaultNotes_VCCStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxDefaultNotes_VCCStatus.AutoFindItemInDataSource = False
            Me.ComboBoxDefaultNotes_VCCStatus.AutoSelectSingleItemDatasource = False
            Me.ComboBoxDefaultNotes_VCCStatus.BookmarkingEnabled = False
            Me.ComboBoxDefaultNotes_VCCStatus.ClientCode = ""
            Me.ComboBoxDefaultNotes_VCCStatus.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxDefaultNotes_VCCStatus.DisableMouseWheel = False
            Me.ComboBoxDefaultNotes_VCCStatus.DisplayMember = "Name"
            Me.ComboBoxDefaultNotes_VCCStatus.DisplayName = ""
            Me.ComboBoxDefaultNotes_VCCStatus.DivisionCode = ""
            Me.ComboBoxDefaultNotes_VCCStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxDefaultNotes_VCCStatus.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxDefaultNotes_VCCStatus.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.Open
            Me.ComboBoxDefaultNotes_VCCStatus.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxDefaultNotes_VCCStatus.FocusHighlightEnabled = True
            Me.ComboBoxDefaultNotes_VCCStatus.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxDefaultNotes_VCCStatus.FormattingEnabled = True
            Me.ComboBoxDefaultNotes_VCCStatus.ItemHeight = 14
            Me.ComboBoxDefaultNotes_VCCStatus.Location = New System.Drawing.Point(103, 130)
            Me.ComboBoxDefaultNotes_VCCStatus.Name = "ComboBoxDefaultNotes_VCCStatus"
            Me.ComboBoxDefaultNotes_VCCStatus.ReadOnly = False
            Me.ComboBoxDefaultNotes_VCCStatus.SecurityEnabled = True
            Me.ComboBoxDefaultNotes_VCCStatus.Size = New System.Drawing.Size(299, 20)
            Me.ComboBoxDefaultNotes_VCCStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxDefaultNotes_VCCStatus.TabIndex = 11
            Me.ComboBoxDefaultNotes_VCCStatus.TabOnEnter = True
            Me.ComboBoxDefaultNotes_VCCStatus.ValueMember = "Value"
            Me.ComboBoxDefaultNotes_VCCStatus.WatermarkText = "Select"
            '
            'LabelDefaultNotes_VCCStatus
            '
            Me.LabelDefaultNotes_VCCStatus.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultNotes_VCCStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultNotes_VCCStatus.Location = New System.Drawing.Point(4, 130)
            Me.LabelDefaultNotes_VCCStatus.Name = "LabelDefaultNotes_VCCStatus"
            Me.LabelDefaultNotes_VCCStatus.Size = New System.Drawing.Size(91, 20)
            Me.LabelDefaultNotes_VCCStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultNotes_VCCStatus.TabIndex = 10
            Me.LabelDefaultNotes_VCCStatus.Text = "VCC Status:"
            '
            'LabelDefaultNotes_DefaultFunction
            '
            Me.LabelDefaultNotes_DefaultFunction.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultNotes_DefaultFunction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultNotes_DefaultFunction.Location = New System.Drawing.Point(6, 0)
            Me.LabelDefaultNotes_DefaultFunction.Name = "LabelDefaultNotes_DefaultFunction"
            Me.LabelDefaultNotes_DefaultFunction.Size = New System.Drawing.Size(91, 20)
            Me.LabelDefaultNotes_DefaultFunction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultNotes_DefaultFunction.TabIndex = 0
            Me.LabelDefaultNotes_DefaultFunction.Text = "Default Function:"
            '
            'LabelDefaultNotes_Terms
            '
            Me.LabelDefaultNotes_Terms.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultNotes_Terms.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultNotes_Terms.Location = New System.Drawing.Point(6, 26)
            Me.LabelDefaultNotes_Terms.Name = "LabelDefaultNotes_Terms"
            Me.LabelDefaultNotes_Terms.Size = New System.Drawing.Size(91, 20)
            Me.LabelDefaultNotes_Terms.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultNotes_Terms.TabIndex = 2
            Me.LabelDefaultNotes_Terms.Text = "Terms:"
            '
            'LabelDefaultNotes_DefaultBank
            '
            Me.LabelDefaultNotes_DefaultBank.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultNotes_DefaultBank.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultNotes_DefaultBank.Location = New System.Drawing.Point(5, 104)
            Me.LabelDefaultNotes_DefaultBank.Name = "LabelDefaultNotes_DefaultBank"
            Me.LabelDefaultNotes_DefaultBank.Size = New System.Drawing.Size(91, 20)
            Me.LabelDefaultNotes_DefaultBank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultNotes_DefaultBank.TabIndex = 8
            Me.LabelDefaultNotes_DefaultBank.Text = "Default Bank:"
            '
            'ComboBoxDefaultNotes_ACHType
            '
            Me.ComboBoxDefaultNotes_ACHType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxDefaultNotes_ACHType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxDefaultNotes_ACHType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxDefaultNotes_ACHType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxDefaultNotes_ACHType.AutoFindItemInDataSource = False
            Me.ComboBoxDefaultNotes_ACHType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxDefaultNotes_ACHType.BookmarkingEnabled = False
            Me.ComboBoxDefaultNotes_ACHType.ClientCode = ""
            Me.ComboBoxDefaultNotes_ACHType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxDefaultNotes_ACHType.DisableMouseWheel = False
            Me.ComboBoxDefaultNotes_ACHType.DisplayMember = "Name"
            Me.ComboBoxDefaultNotes_ACHType.DisplayName = ""
            Me.ComboBoxDefaultNotes_ACHType.DivisionCode = ""
            Me.ComboBoxDefaultNotes_ACHType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxDefaultNotes_ACHType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxDefaultNotes_ACHType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxDefaultNotes_ACHType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxDefaultNotes_ACHType.FocusHighlightEnabled = True
            Me.ComboBoxDefaultNotes_ACHType.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxDefaultNotes_ACHType.FormattingEnabled = True
            Me.ComboBoxDefaultNotes_ACHType.ItemHeight = 14
            Me.ComboBoxDefaultNotes_ACHType.Location = New System.Drawing.Point(157, 78)
            Me.ComboBoxDefaultNotes_ACHType.Name = "ComboBoxDefaultNotes_ACHType"
            Me.ComboBoxDefaultNotes_ACHType.ReadOnly = False
            Me.ComboBoxDefaultNotes_ACHType.SecurityEnabled = True
            Me.ComboBoxDefaultNotes_ACHType.Size = New System.Drawing.Size(245, 20)
            Me.ComboBoxDefaultNotes_ACHType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxDefaultNotes_ACHType.TabIndex = 7
            Me.ComboBoxDefaultNotes_ACHType.TabOnEnter = True
            Me.ComboBoxDefaultNotes_ACHType.ValueMember = "Value"
            Me.ComboBoxDefaultNotes_ACHType.WatermarkText = "Select"
            '
            'CheckBoxDefaultNotes_ACH
            '
            Me.CheckBoxDefaultNotes_ACH.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDefaultNotes_ACH.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDefaultNotes_ACH.CheckValue = 0
            Me.CheckBoxDefaultNotes_ACH.CheckValueChecked = 1
            Me.CheckBoxDefaultNotes_ACH.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDefaultNotes_ACH.CheckValueUnchecked = 0
            Me.CheckBoxDefaultNotes_ACH.ChildControls = CType(resources.GetObject("CheckBoxDefaultNotes_ACH.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDefaultNotes_ACH.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDefaultNotes_ACH.Location = New System.Drawing.Point(103, 78)
            Me.CheckBoxDefaultNotes_ACH.Name = "CheckBoxDefaultNotes_ACH"
            Me.CheckBoxDefaultNotes_ACH.OldestSibling = Nothing
            Me.CheckBoxDefaultNotes_ACH.SecurityEnabled = True
            Me.CheckBoxDefaultNotes_ACH.SiblingControls = CType(resources.GetObject("CheckBoxDefaultNotes_ACH.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDefaultNotes_ACH.Size = New System.Drawing.Size(48, 20)
            Me.CheckBoxDefaultNotes_ACH.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDefaultNotes_ACH.TabIndex = 6
            Me.CheckBoxDefaultNotes_ACH.TabOnEnter = True
            Me.CheckBoxDefaultNotes_ACH.Text = "ACH"
            '
            'CheckBoxDefaultNotes_EmployeeVendor
            '
            Me.CheckBoxDefaultNotes_EmployeeVendor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxDefaultNotes_EmployeeVendor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDefaultNotes_EmployeeVendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDefaultNotes_EmployeeVendor.CheckValue = 0
            Me.CheckBoxDefaultNotes_EmployeeVendor.CheckValueChecked = 1
            Me.CheckBoxDefaultNotes_EmployeeVendor.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDefaultNotes_EmployeeVendor.CheckValueUnchecked = 0
            Me.CheckBoxDefaultNotes_EmployeeVendor.ChildControls = CType(resources.GetObject("CheckBoxDefaultNotes_EmployeeVendor.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDefaultNotes_EmployeeVendor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDefaultNotes_EmployeeVendor.Location = New System.Drawing.Point(260, 52)
            Me.CheckBoxDefaultNotes_EmployeeVendor.Name = "CheckBoxDefaultNotes_EmployeeVendor"
            Me.CheckBoxDefaultNotes_EmployeeVendor.OldestSibling = Nothing
            Me.CheckBoxDefaultNotes_EmployeeVendor.SecurityEnabled = True
            Me.CheckBoxDefaultNotes_EmployeeVendor.SiblingControls = CType(resources.GetObject("CheckBoxDefaultNotes_EmployeeVendor.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDefaultNotes_EmployeeVendor.Size = New System.Drawing.Size(142, 20)
            Me.CheckBoxDefaultNotes_EmployeeVendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDefaultNotes_EmployeeVendor.TabIndex = 5
            Me.CheckBoxDefaultNotes_EmployeeVendor.TabOnEnter = True
            Me.CheckBoxDefaultNotes_EmployeeVendor.Text = "Employee Vendor"
            '
            'CheckBoxDefaultNotes_OneCheckPerInvoice
            '
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.CheckValue = 0
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.CheckValueChecked = 1
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.CheckValueUnchecked = 0
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.ChildControls = CType(resources.GetObject("CheckBoxDefaultNotes_OneCheckPerInvoice.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.Location = New System.Drawing.Point(103, 52)
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.Name = "CheckBoxDefaultNotes_OneCheckPerInvoice"
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.OldestSibling = Nothing
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.SecurityEnabled = True
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.SiblingControls = CType(resources.GetObject("CheckBoxDefaultNotes_OneCheckPerInvoice.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.Size = New System.Drawing.Size(151, 20)
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.TabIndex = 4
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.TabOnEnter = True
            Me.CheckBoxDefaultNotes_OneCheckPerInvoice.Text = "One Check Per Invoice"
            '
            'PanelLeftColumn_DefaultsNotes
            '
            Me.PanelLeftColumn_DefaultsNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.ComboBoxDefaultNotes_InvoiceCategory)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.LabelDefaultNotes_InvoiceCategory)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.SearchableComboBoxDefaultNotes_Office)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.SearchableComboBoxDefaultNotes_Currency)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.SearchableComboBoxDefaultNotes_DefaultAPAccount)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.TextBoxDefaultNotes_VendorAccount)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.TextBoxDefaultNotes_SortName)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.LabelDefaultNotes_Currency)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.ButtonOptions_SortActions)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.LabelDefaultNotes_Office)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.LabelDefaultNotes_DefaultAPAccount)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.ComboBoxDefaultNotes_SortOptions)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.LabelDefaultNotes_DefaultExpenseAccount)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.LabelDefaultNotes_VendorAccount)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.LabelDefaultNotes_SortName)
            Me.PanelLeftColumn_DefaultsNotes.Controls.Add(Me.LabelDefaultNotes_SortOptions)
            Me.PanelLeftColumn_DefaultsNotes.Location = New System.Drawing.Point(0, 0)
            Me.PanelLeftColumn_DefaultsNotes.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelLeftColumn_DefaultsNotes.Name = "PanelLeftColumn_DefaultsNotes"
            Me.PanelLeftColumn_DefaultsNotes.Size = New System.Drawing.Size(403, 207)
            Me.PanelLeftColumn_DefaultsNotes.TabIndex = 0
            '
            'ComboBoxDefaultNotes_InvoiceCategory
            '
            Me.ComboBoxDefaultNotes_InvoiceCategory.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxDefaultNotes_InvoiceCategory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxDefaultNotes_InvoiceCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxDefaultNotes_InvoiceCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxDefaultNotes_InvoiceCategory.AutoFindItemInDataSource = False
            Me.ComboBoxDefaultNotes_InvoiceCategory.AutoSelectSingleItemDatasource = False
            Me.ComboBoxDefaultNotes_InvoiceCategory.BookmarkingEnabled = False
            Me.ComboBoxDefaultNotes_InvoiceCategory.ClientCode = ""
            Me.ComboBoxDefaultNotes_InvoiceCategory.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.VendorInvoiceCategory
            Me.ComboBoxDefaultNotes_InvoiceCategory.DisableMouseWheel = False
            Me.ComboBoxDefaultNotes_InvoiceCategory.DisplayMember = "Name"
            Me.ComboBoxDefaultNotes_InvoiceCategory.DisplayName = ""
            Me.ComboBoxDefaultNotes_InvoiceCategory.DivisionCode = ""
            Me.ComboBoxDefaultNotes_InvoiceCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxDefaultNotes_InvoiceCategory.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxDefaultNotes_InvoiceCategory.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxDefaultNotes_InvoiceCategory.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxDefaultNotes_InvoiceCategory.FocusHighlightEnabled = True
            Me.ComboBoxDefaultNotes_InvoiceCategory.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxDefaultNotes_InvoiceCategory.FormattingEnabled = True
            Me.ComboBoxDefaultNotes_InvoiceCategory.ItemHeight = 14
            Me.ComboBoxDefaultNotes_InvoiceCategory.Location = New System.Drawing.Point(138, 182)
            Me.ComboBoxDefaultNotes_InvoiceCategory.Name = "ComboBoxDefaultNotes_InvoiceCategory"
            Me.ComboBoxDefaultNotes_InvoiceCategory.ReadOnly = False
            Me.ComboBoxDefaultNotes_InvoiceCategory.SecurityEnabled = True
            Me.ComboBoxDefaultNotes_InvoiceCategory.Size = New System.Drawing.Size(262, 20)
            Me.ComboBoxDefaultNotes_InvoiceCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxDefaultNotes_InvoiceCategory.TabIndex = 16
            Me.ComboBoxDefaultNotes_InvoiceCategory.TabOnEnter = True
            Me.ComboBoxDefaultNotes_InvoiceCategory.ValueMember = "ID"
            Me.ComboBoxDefaultNotes_InvoiceCategory.WatermarkText = "Select Vendor Invoice Category"
            '
            'LabelDefaultNotes_InvoiceCategory
            '
            Me.LabelDefaultNotes_InvoiceCategory.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultNotes_InvoiceCategory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultNotes_InvoiceCategory.Location = New System.Drawing.Point(2, 182)
            Me.LabelDefaultNotes_InvoiceCategory.Name = "LabelDefaultNotes_InvoiceCategory"
            Me.LabelDefaultNotes_InvoiceCategory.Size = New System.Drawing.Size(130, 20)
            Me.LabelDefaultNotes_InvoiceCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultNotes_InvoiceCategory.TabIndex = 15
            Me.LabelDefaultNotes_InvoiceCategory.Text = "Invoice Category:"
            '
            'SearchableComboBoxDefaultNotes_Office
            '
            Me.SearchableComboBoxDefaultNotes_Office.ActiveFilterString = ""
            Me.SearchableComboBoxDefaultNotes_Office.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDefaultNotes_Office.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxDefaultNotes_Office.AutoFillMode = False
            Me.SearchableComboBoxDefaultNotes_Office.BookmarkingEnabled = False
            Me.SearchableComboBoxDefaultNotes_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Office
            Me.SearchableComboBoxDefaultNotes_Office.DataSource = Nothing
            Me.SearchableComboBoxDefaultNotes_Office.DisableMouseWheel = False
            Me.SearchableComboBoxDefaultNotes_Office.DisplayName = ""
            Me.SearchableComboBoxDefaultNotes_Office.EnterMoveNextControl = True
            Me.SearchableComboBoxDefaultNotes_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxDefaultNotes_Office.Location = New System.Drawing.Point(138, 26)
            Me.SearchableComboBoxDefaultNotes_Office.Name = "SearchableComboBoxDefaultNotes_Office"
            Me.SearchableComboBoxDefaultNotes_Office.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDefaultNotes_Office.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxDefaultNotes_Office.Properties.NullText = "Select Office"
            Me.SearchableComboBoxDefaultNotes_Office.Properties.PopupView = Me.GridView4
            Me.SearchableComboBoxDefaultNotes_Office.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDefaultNotes_Office.SecurityEnabled = True
            Me.SearchableComboBoxDefaultNotes_Office.SelectedValue = Nothing
            Me.SearchableComboBoxDefaultNotes_Office.Size = New System.Drawing.Size(262, 20)
            Me.SearchableComboBoxDefaultNotes_Office.TabIndex = 3
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
            'SearchableComboBoxDefaultNotes_Currency
            '
            Me.SearchableComboBoxDefaultNotes_Currency.ActiveFilterString = ""
            Me.SearchableComboBoxDefaultNotes_Currency.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDefaultNotes_Currency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxDefaultNotes_Currency.AutoFillMode = False
            Me.SearchableComboBoxDefaultNotes_Currency.BookmarkingEnabled = False
            Me.SearchableComboBoxDefaultNotes_Currency.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CurrencyCode
            Me.SearchableComboBoxDefaultNotes_Currency.DataSource = Nothing
            Me.SearchableComboBoxDefaultNotes_Currency.DisableMouseWheel = False
            Me.SearchableComboBoxDefaultNotes_Currency.DisplayName = ""
            Me.SearchableComboBoxDefaultNotes_Currency.EnterMoveNextControl = True
            Me.SearchableComboBoxDefaultNotes_Currency.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxDefaultNotes_Currency.Location = New System.Drawing.Point(138, 0)
            Me.SearchableComboBoxDefaultNotes_Currency.Name = "SearchableComboBoxDefaultNotes_Currency"
            Me.SearchableComboBoxDefaultNotes_Currency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDefaultNotes_Currency.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDefaultNotes_Currency.Properties.NullText = "Select Currency Code"
            Me.SearchableComboBoxDefaultNotes_Currency.Properties.PopupView = Me.GridView3
            Me.SearchableComboBoxDefaultNotes_Currency.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDefaultNotes_Currency.SecurityEnabled = True
            Me.SearchableComboBoxDefaultNotes_Currency.SelectedValue = Nothing
            Me.SearchableComboBoxDefaultNotes_Currency.Size = New System.Drawing.Size(262, 20)
            Me.SearchableComboBoxDefaultNotes_Currency.TabIndex = 1
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
            'SearchableComboBoxDefaultNotes_DefaultExpenseAccount
            '
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.ActiveFilterString = ""
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.AutoFillMode = False
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.BookmarkingEnabled = False
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.DataSource = Nothing
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.DisableMouseWheel = False
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.DisplayName = ""
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.EnterMoveNextControl = True
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.Location = New System.Drawing.Point(138, 78)
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.Name = "SearchableComboBoxDefaultNotes_DefaultExpenseAccount"
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.Properties.NullText = "Select General Ledger Account"
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.Properties.PopupView = Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.SecurityEnabled = True
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.SelectedValue = Nothing
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.Size = New System.Drawing.Size(262, 20)
            Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.TabIndex = 7
            '
            'SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount
            '
            Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount.AFActiveFilterString = ""
            Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount.DataSourceClearing = False
            Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount.EnableDisabledRows = False
            Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount.Name = "SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount"
            Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount.RunStandardValidation = True
            Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxDefaultNotes_DefaultAPAccount
            '
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.ActiveFilterString = ""
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.AutoFillMode = False
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.BookmarkingEnabled = False
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.DataSource = Nothing
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.DisableMouseWheel = False
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.DisplayName = ""
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.EnterMoveNextControl = True
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.Location = New System.Drawing.Point(138, 52)
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.Name = "SearchableComboBoxDefaultNotes_DefaultAPAccount"
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.Properties.NullText = "Select General Ledger Account"
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.Properties.PopupView = Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.Properties.ShowClearButton = False
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.SecurityEnabled = True
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.SelectedValue = Nothing
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.Size = New System.Drawing.Size(262, 20)
            Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.TabIndex = 5
            '
            'SearchableComboBoxViewDefaultNotes_DefaultAPAccount
            '
            Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount.AFActiveFilterString = ""
            Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount.DataSourceClearing = False
            Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount.EnableDisabledRows = False
            Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount.Name = "SearchableComboBoxViewDefaultNotes_DefaultAPAccount"
            Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount.RunStandardValidation = True
            Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount.SkipSettingFontOnModifyColumn = False
            '
            'TextBoxDefaultNotes_VendorAccount
            '
            Me.TextBoxDefaultNotes_VendorAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxDefaultNotes_VendorAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxDefaultNotes_VendorAccount.Border.Class = "TextBoxBorder"
            Me.TextBoxDefaultNotes_VendorAccount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDefaultNotes_VendorAccount.CheckSpellingOnValidate = False
            Me.TextBoxDefaultNotes_VendorAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDefaultNotes_VendorAccount.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxDefaultNotes_VendorAccount.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDefaultNotes_VendorAccount.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDefaultNotes_VendorAccount.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDefaultNotes_VendorAccount.FocusHighlightEnabled = True
            Me.TextBoxDefaultNotes_VendorAccount.ForeColor = System.Drawing.Color.Black
            Me.TextBoxDefaultNotes_VendorAccount.Location = New System.Drawing.Point(138, 104)
            Me.TextBoxDefaultNotes_VendorAccount.MaxFileSize = CType(0, Long)
            Me.TextBoxDefaultNotes_VendorAccount.Name = "TextBoxDefaultNotes_VendorAccount"
            Me.TextBoxDefaultNotes_VendorAccount.SecurityEnabled = True
            Me.TextBoxDefaultNotes_VendorAccount.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDefaultNotes_VendorAccount.Size = New System.Drawing.Size(262, 20)
            Me.TextBoxDefaultNotes_VendorAccount.StartingFolderName = Nothing
            Me.TextBoxDefaultNotes_VendorAccount.TabIndex = 9
            Me.TextBoxDefaultNotes_VendorAccount.TabOnEnter = True
            '
            'TextBoxDefaultNotes_SortName
            '
            Me.TextBoxDefaultNotes_SortName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxDefaultNotes_SortName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxDefaultNotes_SortName.Border.Class = "TextBoxBorder"
            Me.TextBoxDefaultNotes_SortName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDefaultNotes_SortName.CheckSpellingOnValidate = False
            Me.TextBoxDefaultNotes_SortName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDefaultNotes_SortName.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxDefaultNotes_SortName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDefaultNotes_SortName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDefaultNotes_SortName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDefaultNotes_SortName.FocusHighlightEnabled = True
            Me.TextBoxDefaultNotes_SortName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxDefaultNotes_SortName.Location = New System.Drawing.Point(138, 130)
            Me.TextBoxDefaultNotes_SortName.MaxFileSize = CType(0, Long)
            Me.TextBoxDefaultNotes_SortName.Name = "TextBoxDefaultNotes_SortName"
            Me.TextBoxDefaultNotes_SortName.SecurityEnabled = True
            Me.TextBoxDefaultNotes_SortName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDefaultNotes_SortName.Size = New System.Drawing.Size(262, 20)
            Me.TextBoxDefaultNotes_SortName.StartingFolderName = Nothing
            Me.TextBoxDefaultNotes_SortName.TabIndex = 11
            Me.TextBoxDefaultNotes_SortName.TabOnEnter = True
            '
            'LabelDefaultNotes_Currency
            '
            Me.LabelDefaultNotes_Currency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultNotes_Currency.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelDefaultNotes_Currency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultNotes_Currency.Location = New System.Drawing.Point(0, 0)
            Me.LabelDefaultNotes_Currency.Name = "LabelDefaultNotes_Currency"
            Me.LabelDefaultNotes_Currency.Size = New System.Drawing.Size(132, 20)
            Me.LabelDefaultNotes_Currency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultNotes_Currency.TabIndex = 0
            Me.LabelDefaultNotes_Currency.Text = "Currency:"
            '
            'ButtonOptions_SortActions
            '
            Me.ButtonOptions_SortActions.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonOptions_SortActions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonOptions_SortActions.AutoExpandOnClick = True
            Me.ButtonOptions_SortActions.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonOptions_SortActions.Location = New System.Drawing.Point(325, 156)
            Me.ButtonOptions_SortActions.Name = "ButtonOptions_SortActions"
            Me.ButtonOptions_SortActions.SecurityEnabled = True
            Me.ButtonOptions_SortActions.Size = New System.Drawing.Size(75, 20)
            Me.ButtonOptions_SortActions.SplitButton = True
            Me.ButtonOptions_SortActions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonOptions_SortActions.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSortActions_Add, Me.ButtonItemSortActions_Delete})
            Me.ButtonOptions_SortActions.TabIndex = 14
            Me.ButtonOptions_SortActions.Text = "Actions"
            '
            'ButtonItemSortActions_Add
            '
            Me.ButtonItemSortActions_Add.Name = "ButtonItemSortActions_Add"
            Me.ButtonItemSortActions_Add.Text = "Add"
            '
            'ButtonItemSortActions_Delete
            '
            Me.ButtonItemSortActions_Delete.Name = "ButtonItemSortActions_Delete"
            Me.ButtonItemSortActions_Delete.Text = "Delete"
            '
            'LabelDefaultNotes_Office
            '
            Me.LabelDefaultNotes_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultNotes_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultNotes_Office.Location = New System.Drawing.Point(0, 26)
            Me.LabelDefaultNotes_Office.Name = "LabelDefaultNotes_Office"
            Me.LabelDefaultNotes_Office.Size = New System.Drawing.Size(132, 20)
            Me.LabelDefaultNotes_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultNotes_Office.TabIndex = 2
            Me.LabelDefaultNotes_Office.Text = "Office:"
            '
            'LabelDefaultNotes_DefaultAPAccount
            '
            Me.LabelDefaultNotes_DefaultAPAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultNotes_DefaultAPAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultNotes_DefaultAPAccount.Location = New System.Drawing.Point(0, 52)
            Me.LabelDefaultNotes_DefaultAPAccount.Name = "LabelDefaultNotes_DefaultAPAccount"
            Me.LabelDefaultNotes_DefaultAPAccount.Size = New System.Drawing.Size(132, 20)
            Me.LabelDefaultNotes_DefaultAPAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultNotes_DefaultAPAccount.TabIndex = 4
            Me.LabelDefaultNotes_DefaultAPAccount.Text = "Default AP Account:"
            '
            'ComboBoxDefaultNotes_SortOptions
            '
            Me.ComboBoxDefaultNotes_SortOptions.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxDefaultNotes_SortOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxDefaultNotes_SortOptions.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxDefaultNotes_SortOptions.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxDefaultNotes_SortOptions.AutoFindItemInDataSource = False
            Me.ComboBoxDefaultNotes_SortOptions.AutoSelectSingleItemDatasource = False
            Me.ComboBoxDefaultNotes_SortOptions.BookmarkingEnabled = False
            Me.ComboBoxDefaultNotes_SortOptions.ClientCode = ""
            Me.ComboBoxDefaultNotes_SortOptions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.SortKey
            Me.ComboBoxDefaultNotes_SortOptions.DisableMouseWheel = False
            Me.ComboBoxDefaultNotes_SortOptions.DisplayMember = "SortKey"
            Me.ComboBoxDefaultNotes_SortOptions.DisplayName = ""
            Me.ComboBoxDefaultNotes_SortOptions.DivisionCode = ""
            Me.ComboBoxDefaultNotes_SortOptions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxDefaultNotes_SortOptions.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxDefaultNotes_SortOptions.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxDefaultNotes_SortOptions.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxDefaultNotes_SortOptions.FocusHighlightEnabled = True
            Me.ComboBoxDefaultNotes_SortOptions.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxDefaultNotes_SortOptions.FormattingEnabled = True
            Me.ComboBoxDefaultNotes_SortOptions.ItemHeight = 14
            Me.ComboBoxDefaultNotes_SortOptions.Location = New System.Drawing.Point(138, 156)
            Me.ComboBoxDefaultNotes_SortOptions.Name = "ComboBoxDefaultNotes_SortOptions"
            Me.ComboBoxDefaultNotes_SortOptions.ReadOnly = False
            Me.ComboBoxDefaultNotes_SortOptions.SecurityEnabled = True
            Me.ComboBoxDefaultNotes_SortOptions.Size = New System.Drawing.Size(181, 20)
            Me.ComboBoxDefaultNotes_SortOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxDefaultNotes_SortOptions.TabIndex = 13
            Me.ComboBoxDefaultNotes_SortOptions.TabOnEnter = True
            Me.ComboBoxDefaultNotes_SortOptions.ValueMember = "SortKey"
            Me.ComboBoxDefaultNotes_SortOptions.WatermarkText = "Select Sort Key"
            '
            'LabelDefaultNotes_DefaultExpenseAccount
            '
            Me.LabelDefaultNotes_DefaultExpenseAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultNotes_DefaultExpenseAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultNotes_DefaultExpenseAccount.Location = New System.Drawing.Point(0, 78)
            Me.LabelDefaultNotes_DefaultExpenseAccount.Name = "LabelDefaultNotes_DefaultExpenseAccount"
            Me.LabelDefaultNotes_DefaultExpenseAccount.Size = New System.Drawing.Size(132, 20)
            Me.LabelDefaultNotes_DefaultExpenseAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultNotes_DefaultExpenseAccount.TabIndex = 6
            Me.LabelDefaultNotes_DefaultExpenseAccount.Text = "Default Expense Account:"
            '
            'LabelDefaultNotes_VendorAccount
            '
            Me.LabelDefaultNotes_VendorAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultNotes_VendorAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultNotes_VendorAccount.Location = New System.Drawing.Point(0, 104)
            Me.LabelDefaultNotes_VendorAccount.Name = "LabelDefaultNotes_VendorAccount"
            Me.LabelDefaultNotes_VendorAccount.Size = New System.Drawing.Size(132, 20)
            Me.LabelDefaultNotes_VendorAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultNotes_VendorAccount.TabIndex = 8
            Me.LabelDefaultNotes_VendorAccount.Text = "Vendor Account:"
            '
            'LabelDefaultNotes_SortName
            '
            Me.LabelDefaultNotes_SortName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultNotes_SortName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultNotes_SortName.Location = New System.Drawing.Point(0, 130)
            Me.LabelDefaultNotes_SortName.Name = "LabelDefaultNotes_SortName"
            Me.LabelDefaultNotes_SortName.Size = New System.Drawing.Size(132, 20)
            Me.LabelDefaultNotes_SortName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultNotes_SortName.TabIndex = 10
            Me.LabelDefaultNotes_SortName.Text = "Sort Name:"
            '
            'LabelDefaultNotes_SortOptions
            '
            Me.LabelDefaultNotes_SortOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultNotes_SortOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultNotes_SortOptions.Location = New System.Drawing.Point(0, 156)
            Me.LabelDefaultNotes_SortOptions.Name = "LabelDefaultNotes_SortOptions"
            Me.LabelDefaultNotes_SortOptions.Size = New System.Drawing.Size(132, 20)
            Me.LabelDefaultNotes_SortOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultNotes_SortOptions.TabIndex = 12
            Me.LabelDefaultNotes_SortOptions.Text = "Sort Options:"
            '
            'LabelDefaultNotes_Notes
            '
            Me.LabelDefaultNotes_Notes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelDefaultNotes_Notes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultNotes_Notes.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDefaultNotes_Notes.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black
            Me.LabelDefaultNotes_Notes.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelDefaultNotes_Notes.BackgroundStyle.BorderColor = System.Drawing.Color.Black
            Me.LabelDefaultNotes_Notes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultNotes_Notes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDefaultNotes_Notes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelDefaultNotes_Notes.Location = New System.Drawing.Point(4, 216)
            Me.LabelDefaultNotes_Notes.Name = "LabelDefaultNotes_Notes"
            Me.LabelDefaultNotes_Notes.Size = New System.Drawing.Size(806, 20)
            Me.LabelDefaultNotes_Notes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultNotes_Notes.TabIndex = 9
            Me.LabelDefaultNotes_Notes.Text = "Notes"
            '
            'TextBoxDefaultNotes_Notes
            '
            Me.TextBoxDefaultNotes_Notes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxDefaultNotes_Notes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxDefaultNotes_Notes.Border.Class = "TextBoxBorder"
            Me.TextBoxDefaultNotes_Notes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDefaultNotes_Notes.CheckSpellingOnValidate = False
            Me.TextBoxDefaultNotes_Notes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDefaultNotes_Notes.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxDefaultNotes_Notes.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDefaultNotes_Notes.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDefaultNotes_Notes.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDefaultNotes_Notes.FocusHighlightEnabled = True
            Me.TextBoxDefaultNotes_Notes.ForeColor = System.Drawing.Color.Black
            Me.TextBoxDefaultNotes_Notes.Location = New System.Drawing.Point(4, 240)
            Me.TextBoxDefaultNotes_Notes.MaxFileSize = CType(0, Long)
            Me.TextBoxDefaultNotes_Notes.Multiline = True
            Me.TextBoxDefaultNotes_Notes.Name = "TextBoxDefaultNotes_Notes"
            Me.TextBoxDefaultNotes_Notes.SecurityEnabled = True
            Me.TextBoxDefaultNotes_Notes.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDefaultNotes_Notes.Size = New System.Drawing.Size(806, 267)
            Me.TextBoxDefaultNotes_Notes.StartingFolderName = Nothing
            Me.TextBoxDefaultNotes_Notes.TabIndex = 10
            Me.TextBoxDefaultNotes_Notes.TabOnEnter = False
            '
            'TabItemVendorDetails_DefaultsNotesTab
            '
            Me.TabItemVendorDetails_DefaultsNotesTab.AttachedControl = Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes
            Me.TabItemVendorDetails_DefaultsNotesTab.Name = "TabItemVendorDetails_DefaultsNotesTab"
            Me.TabItemVendorDetails_DefaultsNotesTab.Text = "Defaults / Notes"
            '
            'TabControlPanelContractsTab_Contracts
            '
            Me.TabControlPanelContractsTab_Contracts.Controls.Add(Me.VendorContractManagerControlContracts_Contracts)
            Me.TabControlPanelContractsTab_Contracts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelContractsTab_Contracts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelContractsTab_Contracts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelContractsTab_Contracts.Name = "TabControlPanelContractsTab_Contracts"
            Me.TabControlPanelContractsTab_Contracts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelContractsTab_Contracts.Size = New System.Drawing.Size(815, 513)
            Me.TabControlPanelContractsTab_Contracts.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelContractsTab_Contracts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelContractsTab_Contracts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelContractsTab_Contracts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelContractsTab_Contracts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelContractsTab_Contracts.Style.GradientAngle = 90
            Me.TabControlPanelContractsTab_Contracts.TabIndex = 13
            Me.TabControlPanelContractsTab_Contracts.TabItem = Me.TabItemVendorDetails_ContractsTab
            '
            'VendorContractManagerControlContracts_Contracts
            '
            Me.VendorContractManagerControlContracts_Contracts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VendorContractManagerControlContracts_Contracts.Location = New System.Drawing.Point(6, 6)
            Me.VendorContractManagerControlContracts_Contracts.Name = "VendorContractManagerControlContracts_Contracts"
            Me.VendorContractManagerControlContracts_Contracts.Size = New System.Drawing.Size(803, 501)
            Me.VendorContractManagerControlContracts_Contracts.TabIndex = 1
            '
            'TabItemVendorDetails_ContractsTab
            '
            Me.TabItemVendorDetails_ContractsTab.AttachedControl = Me.TabControlPanelContractsTab_Contracts
            Me.TabItemVendorDetails_ContractsTab.Name = "TabItemVendorDetails_ContractsTab"
            Me.TabItemVendorDetails_ContractsTab.Text = "Contracts"
            '
            'TabControlPanelVendorServiceTaxTab_VendorServiceTax
            '
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Controls.Add(Me.CheckBoxServiceTax_Waiver)
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Controls.Add(Me.CheckBoxServiceTax_Enabled)
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Controls.Add(Me.NumericInputServiceTax_Rate)
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Controls.Add(Me.DateTimePickerServiceTax_WaiverExpirationDate)
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Controls.Add(Me.SearchableComboBoxServiceTax_Type)
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Controls.Add(Me.LabelServiceTax_WaiverExpirationDate)
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Controls.Add(Me.LabelServiceTax_TaxRate)
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Controls.Add(Me.LabelServiceTax_TaxType)
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Controls.Add(Me.SearchableComboBoxServiceTax_Code)
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Controls.Add(Me.LabelServiceTax_Code)
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Name = "TabControlPanelVendorServiceTaxTab_VendorServiceTax"
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Size = New System.Drawing.Size(815, 513)
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.Style.GradientAngle = 90
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.TabIndex = 12
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.TabItem = Me.TabItemVendorDetails_VendorServiceTaxTab
            '
            'CheckBoxServiceTax_Waiver
            '
            Me.CheckBoxServiceTax_Waiver.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxServiceTax_Waiver.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxServiceTax_Waiver.CheckValue = 0
            Me.CheckBoxServiceTax_Waiver.CheckValueChecked = 1
            Me.CheckBoxServiceTax_Waiver.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxServiceTax_Waiver.CheckValueUnchecked = 0
            Me.CheckBoxServiceTax_Waiver.ChildControls = Nothing
            Me.CheckBoxServiceTax_Waiver.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxServiceTax_Waiver.Location = New System.Drawing.Point(139, 108)
            Me.CheckBoxServiceTax_Waiver.Name = "CheckBoxServiceTax_Waiver"
            Me.CheckBoxServiceTax_Waiver.OldestSibling = Nothing
            Me.CheckBoxServiceTax_Waiver.SecurityEnabled = True
            Me.CheckBoxServiceTax_Waiver.SiblingControls = Nothing
            Me.CheckBoxServiceTax_Waiver.Size = New System.Drawing.Size(129, 20)
            Me.CheckBoxServiceTax_Waiver.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxServiceTax_Waiver.TabIndex = 7
            Me.CheckBoxServiceTax_Waiver.TabOnEnter = True
            Me.CheckBoxServiceTax_Waiver.Text = "Tax Waiver"
            '
            'CheckBoxServiceTax_Enabled
            '
            Me.CheckBoxServiceTax_Enabled.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxServiceTax_Enabled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxServiceTax_Enabled.CheckValue = 0
            Me.CheckBoxServiceTax_Enabled.CheckValueChecked = 1
            Me.CheckBoxServiceTax_Enabled.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxServiceTax_Enabled.CheckValueUnchecked = 0
            Me.CheckBoxServiceTax_Enabled.ChildControls = Nothing
            Me.CheckBoxServiceTax_Enabled.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxServiceTax_Enabled.Location = New System.Drawing.Point(139, 56)
            Me.CheckBoxServiceTax_Enabled.Name = "CheckBoxServiceTax_Enabled"
            Me.CheckBoxServiceTax_Enabled.OldestSibling = Nothing
            Me.CheckBoxServiceTax_Enabled.SecurityEnabled = True
            Me.CheckBoxServiceTax_Enabled.SiblingControls = Nothing
            Me.CheckBoxServiceTax_Enabled.Size = New System.Drawing.Size(129, 20)
            Me.CheckBoxServiceTax_Enabled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxServiceTax_Enabled.TabIndex = 4
            Me.CheckBoxServiceTax_Enabled.TabOnEnter = True
            Me.CheckBoxServiceTax_Enabled.Text = "Tax Enabled"
            '
            'NumericInputServiceTax_Rate
            '
            Me.NumericInputServiceTax_Rate.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputServiceTax_Rate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputServiceTax_Rate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputServiceTax_Rate.EnterMoveNextControl = True
            Me.NumericInputServiceTax_Rate.Location = New System.Drawing.Point(139, 82)
            Me.NumericInputServiceTax_Rate.Name = "NumericInputServiceTax_Rate"
            Me.NumericInputServiceTax_Rate.Properties.AllowMouseWheel = False
            Me.NumericInputServiceTax_Rate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputServiceTax_Rate.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputServiceTax_Rate.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputServiceTax_Rate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputServiceTax_Rate.Properties.EditFormat.FormatString = "f"
            Me.NumericInputServiceTax_Rate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputServiceTax_Rate.Properties.Mask.EditMask = "f"
            Me.NumericInputServiceTax_Rate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputServiceTax_Rate.SecurityEnabled = True
            Me.NumericInputServiceTax_Rate.Size = New System.Drawing.Size(129, 20)
            Me.NumericInputServiceTax_Rate.TabIndex = 6
            '
            'DateTimePickerServiceTax_WaiverExpirationDate
            '
            Me.DateTimePickerServiceTax_WaiverExpirationDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerServiceTax_WaiverExpirationDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerServiceTax_WaiverExpirationDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerServiceTax_WaiverExpirationDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerServiceTax_WaiverExpirationDate.ButtonDropDown.Visible = True
            Me.DateTimePickerServiceTax_WaiverExpirationDate.ButtonFreeText.Checked = True
            Me.DateTimePickerServiceTax_WaiverExpirationDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerServiceTax_WaiverExpirationDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerServiceTax_WaiverExpirationDate.DisplayName = ""
            Me.DateTimePickerServiceTax_WaiverExpirationDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerServiceTax_WaiverExpirationDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerServiceTax_WaiverExpirationDate.FocusHighlightEnabled = True
            Me.DateTimePickerServiceTax_WaiverExpirationDate.FreeTextEntryMode = True
            Me.DateTimePickerServiceTax_WaiverExpirationDate.IsPopupCalendarOpen = False
            Me.DateTimePickerServiceTax_WaiverExpirationDate.Location = New System.Drawing.Point(139, 134)
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerServiceTax_WaiverExpirationDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerServiceTax_WaiverExpirationDate.Name = "DateTimePickerServiceTax_WaiverExpirationDate"
            Me.DateTimePickerServiceTax_WaiverExpirationDate.ReadOnly = False
            Me.DateTimePickerServiceTax_WaiverExpirationDate.Size = New System.Drawing.Size(129, 20)
            Me.DateTimePickerServiceTax_WaiverExpirationDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerServiceTax_WaiverExpirationDate.TabIndex = 9
            Me.DateTimePickerServiceTax_WaiverExpirationDate.TabOnEnter = True
            Me.DateTimePickerServiceTax_WaiverExpirationDate.Value = New Date(2014, 12, 10, 16, 0, 48, 713)
            '
            'SearchableComboBoxServiceTax_Type
            '
            Me.SearchableComboBoxServiceTax_Type.ActiveFilterString = ""
            Me.SearchableComboBoxServiceTax_Type.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxServiceTax_Type.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxServiceTax_Type.AutoFillMode = False
            Me.SearchableComboBoxServiceTax_Type.BookmarkingEnabled = False
            Me.SearchableComboBoxServiceTax_Type.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.EnumObjects
            Me.SearchableComboBoxServiceTax_Type.DataSource = Nothing
            Me.SearchableComboBoxServiceTax_Type.DisableMouseWheel = False
            Me.SearchableComboBoxServiceTax_Type.DisplayName = ""
            Me.SearchableComboBoxServiceTax_Type.EnterMoveNextControl = True
            Me.SearchableComboBoxServiceTax_Type.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxServiceTax_Type.Location = New System.Drawing.Point(139, 30)
            Me.SearchableComboBoxServiceTax_Type.Name = "SearchableComboBoxServiceTax_Type"
            Me.SearchableComboBoxServiceTax_Type.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxServiceTax_Type.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxServiceTax_Type.Properties.NullText = "Select"
            Me.SearchableComboBoxServiceTax_Type.Properties.PopupView = Me.GridView2
            Me.SearchableComboBoxServiceTax_Type.Properties.ValueMember = "Code"
            Me.SearchableComboBoxServiceTax_Type.SecurityEnabled = True
            Me.SearchableComboBoxServiceTax_Type.SelectedValue = Nothing
            Me.SearchableComboBoxServiceTax_Type.Size = New System.Drawing.Size(672, 20)
            Me.SearchableComboBoxServiceTax_Type.TabIndex = 3
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
            'LabelServiceTax_WaiverExpirationDate
            '
            Me.LabelServiceTax_WaiverExpirationDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelServiceTax_WaiverExpirationDate.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelServiceTax_WaiverExpirationDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelServiceTax_WaiverExpirationDate.Location = New System.Drawing.Point(4, 134)
            Me.LabelServiceTax_WaiverExpirationDate.Name = "LabelServiceTax_WaiverExpirationDate"
            Me.LabelServiceTax_WaiverExpirationDate.Size = New System.Drawing.Size(129, 20)
            Me.LabelServiceTax_WaiverExpirationDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelServiceTax_WaiverExpirationDate.TabIndex = 8
            Me.LabelServiceTax_WaiverExpirationDate.Text = "Waiver Expiration Date:"
            '
            'LabelServiceTax_TaxRate
            '
            Me.LabelServiceTax_TaxRate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelServiceTax_TaxRate.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelServiceTax_TaxRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelServiceTax_TaxRate.Location = New System.Drawing.Point(4, 82)
            Me.LabelServiceTax_TaxRate.Name = "LabelServiceTax_TaxRate"
            Me.LabelServiceTax_TaxRate.Size = New System.Drawing.Size(129, 20)
            Me.LabelServiceTax_TaxRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelServiceTax_TaxRate.TabIndex = 5
            Me.LabelServiceTax_TaxRate.Text = "Rate:"
            '
            'LabelServiceTax_TaxType
            '
            Me.LabelServiceTax_TaxType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelServiceTax_TaxType.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelServiceTax_TaxType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelServiceTax_TaxType.Location = New System.Drawing.Point(4, 30)
            Me.LabelServiceTax_TaxType.Name = "LabelServiceTax_TaxType"
            Me.LabelServiceTax_TaxType.Size = New System.Drawing.Size(129, 20)
            Me.LabelServiceTax_TaxType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelServiceTax_TaxType.TabIndex = 2
            Me.LabelServiceTax_TaxType.Text = "Type:"
            '
            'SearchableComboBoxServiceTax_Code
            '
            Me.SearchableComboBoxServiceTax_Code.ActiveFilterString = ""
            Me.SearchableComboBoxServiceTax_Code.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxServiceTax_Code.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxServiceTax_Code.AutoFillMode = False
            Me.SearchableComboBoxServiceTax_Code.BookmarkingEnabled = False
            Me.SearchableComboBoxServiceTax_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.VendorServiceTax
            Me.SearchableComboBoxServiceTax_Code.DataSource = Nothing
            Me.SearchableComboBoxServiceTax_Code.DisableMouseWheel = False
            Me.SearchableComboBoxServiceTax_Code.DisplayName = ""
            Me.SearchableComboBoxServiceTax_Code.EnterMoveNextControl = True
            Me.SearchableComboBoxServiceTax_Code.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxServiceTax_Code.Location = New System.Drawing.Point(139, 4)
            Me.SearchableComboBoxServiceTax_Code.Name = "SearchableComboBoxServiceTax_Code"
            Me.SearchableComboBoxServiceTax_Code.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxServiceTax_Code.Properties.DisplayMember = "CodeAndDescription"
            Me.SearchableComboBoxServiceTax_Code.Properties.NullText = "Select Vendor Service Tax"
            Me.SearchableComboBoxServiceTax_Code.Properties.PopupView = Me.GridView1
            Me.SearchableComboBoxServiceTax_Code.Properties.ShowClearButton = False
            Me.SearchableComboBoxServiceTax_Code.Properties.ValueMember = "ID"
            Me.SearchableComboBoxServiceTax_Code.SecurityEnabled = True
            Me.SearchableComboBoxServiceTax_Code.SelectedValue = Nothing
            Me.SearchableComboBoxServiceTax_Code.Size = New System.Drawing.Size(672, 20)
            Me.SearchableComboBoxServiceTax_Code.TabIndex = 1
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
            'LabelServiceTax_Code
            '
            Me.LabelServiceTax_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelServiceTax_Code.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelServiceTax_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelServiceTax_Code.Location = New System.Drawing.Point(4, 4)
            Me.LabelServiceTax_Code.Name = "LabelServiceTax_Code"
            Me.LabelServiceTax_Code.Size = New System.Drawing.Size(129, 20)
            Me.LabelServiceTax_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelServiceTax_Code.TabIndex = 0
            Me.LabelServiceTax_Code.Text = "Code:"
            '
            'TabItemVendorDetails_VendorServiceTaxTab
            '
            Me.TabItemVendorDetails_VendorServiceTaxTab.AttachedControl = Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax
            Me.TabItemVendorDetails_VendorServiceTaxTab.Name = "TabItemVendorDetails_VendorServiceTaxTab"
            Me.TabItemVendorDetails_VendorServiceTaxTab.Text = "Vendor Service Tax"
            '
            'TabControlPanel1099InfoTab_1099Info
            '
            Me.TabControlPanel1099InfoTab_1099Info.Controls.Add(Me.TableLayoutPanel1099Info_TableLayout)
            Me.TabControlPanel1099InfoTab_1099Info.Controls.Add(Me.CheckBox1099Info_Is1099Vendor)
            Me.TabControlPanel1099InfoTab_1099Info.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel1099InfoTab_1099Info.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel1099InfoTab_1099Info.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel1099InfoTab_1099Info.Name = "TabControlPanel1099InfoTab_1099Info"
            Me.TabControlPanel1099InfoTab_1099Info.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel1099InfoTab_1099Info.Size = New System.Drawing.Size(815, 513)
            Me.TabControlPanel1099InfoTab_1099Info.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel1099InfoTab_1099Info.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel1099InfoTab_1099Info.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel1099InfoTab_1099Info.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel1099InfoTab_1099Info.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel1099InfoTab_1099Info.Style.GradientAngle = 90
            Me.TabControlPanel1099InfoTab_1099Info.TabIndex = 2
            Me.TabControlPanel1099InfoTab_1099Info.TabItem = Me.TabItemVendorDetails_1099InfoTab
            '
            'TableLayoutPanel1099Info_TableLayout
            '
            Me.TableLayoutPanel1099Info_TableLayout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanel1099Info_TableLayout.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanel1099Info_TableLayout.ColumnCount = 2
            Me.TableLayoutPanel1099Info_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1099Info_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1099Info_TableLayout.Controls.Add(Me.Panel1099Info_RightColumn, 1, 0)
            Me.TableLayoutPanel1099Info_TableLayout.Controls.Add(Me.Panel1099Info_LeftColumn, 0, 0)
            Me.TableLayoutPanel1099Info_TableLayout.Location = New System.Drawing.Point(4, 27)
            Me.TableLayoutPanel1099Info_TableLayout.Margin = New System.Windows.Forms.Padding(0)
            Me.TableLayoutPanel1099Info_TableLayout.Name = "TableLayoutPanel1099Info_TableLayout"
            Me.TableLayoutPanel1099Info_TableLayout.RowCount = 1
            Me.TableLayoutPanel1099Info_TableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1099Info_TableLayout.Size = New System.Drawing.Size(806, 262)
            Me.TableLayoutPanel1099Info_TableLayout.TabIndex = 1
            '
            'Panel1099Info_RightColumn
            '
            Me.Panel1099Info_RightColumn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1099Info_RightColumn.Controls.Add(Me.RadioButtonControl1099Info_MedicalHealthcare)
            Me.Panel1099Info_RightColumn.Controls.Add(Me.RadioButtonControl1099Info_GrossProceedsToAttorney)
            Me.Panel1099Info_RightColumn.Controls.Add(Me.RadioButtonControl1099Info_Royalties)
            Me.Panel1099Info_RightColumn.Controls.Add(Me.RadioButtonControl1099Info_Rent)
            Me.Panel1099Info_RightColumn.Controls.Add(Me.RadioButtonControl1099Info_OtherIncome)
            Me.Panel1099Info_RightColumn.Controls.Add(Me.RadioButtonControl1099Info_NonEmployeeCompensation)
            Me.Panel1099Info_RightColumn.Controls.Add(Me.Label1099Info_Category)
            Me.Panel1099Info_RightColumn.Location = New System.Drawing.Point(403, 0)
            Me.Panel1099Info_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.Panel1099Info_RightColumn.Name = "Panel1099Info_RightColumn"
            Me.Panel1099Info_RightColumn.Size = New System.Drawing.Size(403, 262)
            Me.Panel1099Info_RightColumn.TabIndex = 1
            '
            'RadioButtonControl1099Info_MedicalHealthcare
            '
            Me.RadioButtonControl1099Info_MedicalHealthcare.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControl1099Info_MedicalHealthcare.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl1099Info_MedicalHealthcare.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl1099Info_MedicalHealthcare.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl1099Info_MedicalHealthcare.Location = New System.Drawing.Point(4, 156)
            Me.RadioButtonControl1099Info_MedicalHealthcare.Name = "RadioButtonControl1099Info_MedicalHealthcare"
            Me.RadioButtonControl1099Info_MedicalHealthcare.SecurityEnabled = True
            Me.RadioButtonControl1099Info_MedicalHealthcare.Size = New System.Drawing.Size(399, 20)
            Me.RadioButtonControl1099Info_MedicalHealthcare.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl1099Info_MedicalHealthcare.TabIndex = 6
            Me.RadioButtonControl1099Info_MedicalHealthcare.TabOnEnter = True
            Me.RadioButtonControl1099Info_MedicalHealthcare.TabStop = False
            Me.RadioButtonControl1099Info_MedicalHealthcare.Text = "Medical and Health Care"
            '
            'RadioButtonControl1099Info_GrossProceedsToAttorney
            '
            Me.RadioButtonControl1099Info_GrossProceedsToAttorney.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControl1099Info_GrossProceedsToAttorney.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl1099Info_GrossProceedsToAttorney.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl1099Info_GrossProceedsToAttorney.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl1099Info_GrossProceedsToAttorney.Location = New System.Drawing.Point(4, 130)
            Me.RadioButtonControl1099Info_GrossProceedsToAttorney.Name = "RadioButtonControl1099Info_GrossProceedsToAttorney"
            Me.RadioButtonControl1099Info_GrossProceedsToAttorney.SecurityEnabled = True
            Me.RadioButtonControl1099Info_GrossProceedsToAttorney.Size = New System.Drawing.Size(399, 20)
            Me.RadioButtonControl1099Info_GrossProceedsToAttorney.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl1099Info_GrossProceedsToAttorney.TabIndex = 5
            Me.RadioButtonControl1099Info_GrossProceedsToAttorney.TabOnEnter = True
            Me.RadioButtonControl1099Info_GrossProceedsToAttorney.TabStop = False
            Me.RadioButtonControl1099Info_GrossProceedsToAttorney.Text = "Gross Proceeds to Attorney"
            '
            'RadioButtonControl1099Info_Royalties
            '
            Me.RadioButtonControl1099Info_Royalties.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControl1099Info_Royalties.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl1099Info_Royalties.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl1099Info_Royalties.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl1099Info_Royalties.Location = New System.Drawing.Point(4, 104)
            Me.RadioButtonControl1099Info_Royalties.Name = "RadioButtonControl1099Info_Royalties"
            Me.RadioButtonControl1099Info_Royalties.SecurityEnabled = True
            Me.RadioButtonControl1099Info_Royalties.Size = New System.Drawing.Size(399, 20)
            Me.RadioButtonControl1099Info_Royalties.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl1099Info_Royalties.TabIndex = 4
            Me.RadioButtonControl1099Info_Royalties.TabOnEnter = True
            Me.RadioButtonControl1099Info_Royalties.TabStop = False
            Me.RadioButtonControl1099Info_Royalties.Text = "Royalties"
            '
            'RadioButtonControl1099Info_Rent
            '
            Me.RadioButtonControl1099Info_Rent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControl1099Info_Rent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl1099Info_Rent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl1099Info_Rent.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl1099Info_Rent.Location = New System.Drawing.Point(4, 78)
            Me.RadioButtonControl1099Info_Rent.Name = "RadioButtonControl1099Info_Rent"
            Me.RadioButtonControl1099Info_Rent.SecurityEnabled = True
            Me.RadioButtonControl1099Info_Rent.Size = New System.Drawing.Size(399, 20)
            Me.RadioButtonControl1099Info_Rent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl1099Info_Rent.TabIndex = 3
            Me.RadioButtonControl1099Info_Rent.TabOnEnter = True
            Me.RadioButtonControl1099Info_Rent.TabStop = False
            Me.RadioButtonControl1099Info_Rent.Text = "Rent"
            '
            'RadioButtonControl1099Info_OtherIncome
            '
            Me.RadioButtonControl1099Info_OtherIncome.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControl1099Info_OtherIncome.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl1099Info_OtherIncome.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl1099Info_OtherIncome.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl1099Info_OtherIncome.Location = New System.Drawing.Point(4, 52)
            Me.RadioButtonControl1099Info_OtherIncome.Name = "RadioButtonControl1099Info_OtherIncome"
            Me.RadioButtonControl1099Info_OtherIncome.SecurityEnabled = True
            Me.RadioButtonControl1099Info_OtherIncome.Size = New System.Drawing.Size(399, 20)
            Me.RadioButtonControl1099Info_OtherIncome.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl1099Info_OtherIncome.TabIndex = 2
            Me.RadioButtonControl1099Info_OtherIncome.TabOnEnter = True
            Me.RadioButtonControl1099Info_OtherIncome.TabStop = False
            Me.RadioButtonControl1099Info_OtherIncome.Text = "Other Income"
            '
            'RadioButtonControl1099Info_NonEmployeeCompensation
            '
            Me.RadioButtonControl1099Info_NonEmployeeCompensation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControl1099Info_NonEmployeeCompensation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl1099Info_NonEmployeeCompensation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl1099Info_NonEmployeeCompensation.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl1099Info_NonEmployeeCompensation.Location = New System.Drawing.Point(4, 26)
            Me.RadioButtonControl1099Info_NonEmployeeCompensation.Name = "RadioButtonControl1099Info_NonEmployeeCompensation"
            Me.RadioButtonControl1099Info_NonEmployeeCompensation.SecurityEnabled = True
            Me.RadioButtonControl1099Info_NonEmployeeCompensation.Size = New System.Drawing.Size(399, 20)
            Me.RadioButtonControl1099Info_NonEmployeeCompensation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl1099Info_NonEmployeeCompensation.TabIndex = 1
            Me.RadioButtonControl1099Info_NonEmployeeCompensation.TabOnEnter = True
            Me.RadioButtonControl1099Info_NonEmployeeCompensation.TabStop = False
            Me.RadioButtonControl1099Info_NonEmployeeCompensation.Text = "Non Employee Compensation"
            '
            'Label1099Info_Category
            '
            Me.Label1099Info_Category.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label1099Info_Category.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1099Info_Category.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1099Info_Category.BackgroundStyle.BorderBottomWidth = 1
            Me.Label1099Info_Category.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.Label1099Info_Category.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1099Info_Category.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1099Info_Category.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1099Info_Category.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1099Info_Category.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1099Info_Category.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.Label1099Info_Category.Location = New System.Drawing.Point(4, 0)
            Me.Label1099Info_Category.Name = "Label1099Info_Category"
            Me.Label1099Info_Category.Size = New System.Drawing.Size(399, 20)
            Me.Label1099Info_Category.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1099Info_Category.TabIndex = 0
            Me.Label1099Info_Category.Text = "Category"
            '
            'Panel1099Info_LeftColumn
            '
            Me.Panel1099Info_LeftColumn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel1099Info_LeftColumn.Controls.Add(Me.Address3LineControl1099Info_Address)
            Me.Panel1099Info_LeftColumn.Controls.Add(Me.CheckBox1099Info_Use1099Address)
            Me.Panel1099Info_LeftColumn.Controls.Add(Me.Label1099Info_AlternateAddressFor1099)
            Me.Panel1099Info_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.Panel1099Info_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.Panel1099Info_LeftColumn.Name = "Panel1099Info_LeftColumn"
            Me.Panel1099Info_LeftColumn.Size = New System.Drawing.Size(403, 262)
            Me.Panel1099Info_LeftColumn.TabIndex = 0
            '
            'Address3LineControl1099Info_Address
            '
            Me.Address3LineControl1099Info_Address.Address = Nothing
            Me.Address3LineControl1099Info_Address.Address2 = Nothing
            Me.Address3LineControl1099Info_Address.Address3 = Nothing
            Me.Address3LineControl1099Info_Address.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Address3LineControl1099Info_Address.City = Nothing
            Me.Address3LineControl1099Info_Address.Country = Nothing
            Me.Address3LineControl1099Info_Address.County = Nothing
            Me.Address3LineControl1099Info_Address.DisableCountry = False
            Me.Address3LineControl1099Info_Address.DisableCounty = False
            Me.Address3LineControl1099Info_Address.Location = New System.Drawing.Point(3, 52)
            Me.Address3LineControl1099Info_Address.Name = "Address3LineControl1099Info_Address"
            Me.Address3LineControl1099Info_Address.ReadOnly = False
            Me.Address3LineControl1099Info_Address.ShowCountry = True
            Me.Address3LineControl1099Info_Address.ShowCounty = True
            Me.Address3LineControl1099Info_Address.Size = New System.Drawing.Size(397, 207)
            Me.Address3LineControl1099Info_Address.State = Nothing
            Me.Address3LineControl1099Info_Address.TabIndex = 2
            Me.Address3LineControl1099Info_Address.Title = "Address"
            Me.Address3LineControl1099Info_Address.Zip = Nothing
            '
            'CheckBox1099Info_Use1099Address
            '
            Me.CheckBox1099Info_Use1099Address.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBox1099Info_Use1099Address.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBox1099Info_Use1099Address.CheckValue = 0
            Me.CheckBox1099Info_Use1099Address.CheckValueChecked = 1
            Me.CheckBox1099Info_Use1099Address.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBox1099Info_Use1099Address.CheckValueUnchecked = 0
            Me.CheckBox1099Info_Use1099Address.ChildControls = CType(resources.GetObject("CheckBox1099Info_Use1099Address.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBox1099Info_Use1099Address.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBox1099Info_Use1099Address.Location = New System.Drawing.Point(0, 26)
            Me.CheckBox1099Info_Use1099Address.Name = "CheckBox1099Info_Use1099Address"
            Me.CheckBox1099Info_Use1099Address.OldestSibling = Nothing
            Me.CheckBox1099Info_Use1099Address.SecurityEnabled = True
            Me.CheckBox1099Info_Use1099Address.SiblingControls = CType(resources.GetObject("CheckBox1099Info_Use1099Address.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBox1099Info_Use1099Address.Size = New System.Drawing.Size(400, 20)
            Me.CheckBox1099Info_Use1099Address.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBox1099Info_Use1099Address.TabIndex = 1
            Me.CheckBox1099Info_Use1099Address.TabOnEnter = True
            Me.CheckBox1099Info_Use1099Address.Text = "Use"
            '
            'Label1099Info_AlternateAddressFor1099
            '
            Me.Label1099Info_AlternateAddressFor1099.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label1099Info_AlternateAddressFor1099.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1099Info_AlternateAddressFor1099.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1099Info_AlternateAddressFor1099.BackgroundStyle.BorderBottomWidth = 1
            Me.Label1099Info_AlternateAddressFor1099.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.Label1099Info_AlternateAddressFor1099.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1099Info_AlternateAddressFor1099.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1099Info_AlternateAddressFor1099.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.Label1099Info_AlternateAddressFor1099.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1099Info_AlternateAddressFor1099.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1099Info_AlternateAddressFor1099.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.Label1099Info_AlternateAddressFor1099.Location = New System.Drawing.Point(0, 0)
            Me.Label1099Info_AlternateAddressFor1099.Name = "Label1099Info_AlternateAddressFor1099"
            Me.Label1099Info_AlternateAddressFor1099.Size = New System.Drawing.Size(400, 20)
            Me.Label1099Info_AlternateAddressFor1099.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1099Info_AlternateAddressFor1099.TabIndex = 0
            Me.Label1099Info_AlternateAddressFor1099.Text = "Alternate Address for 1099"
            '
            'CheckBox1099Info_Is1099Vendor
            '
            Me.CheckBox1099Info_Is1099Vendor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBox1099Info_Is1099Vendor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBox1099Info_Is1099Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBox1099Info_Is1099Vendor.CheckValue = 0
            Me.CheckBox1099Info_Is1099Vendor.CheckValueChecked = 1
            Me.CheckBox1099Info_Is1099Vendor.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBox1099Info_Is1099Vendor.CheckValueUnchecked = 0
            Me.CheckBox1099Info_Is1099Vendor.ChildControls = CType(resources.GetObject("CheckBox1099Info_Is1099Vendor.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBox1099Info_Is1099Vendor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBox1099Info_Is1099Vendor.Location = New System.Drawing.Point(4, 4)
            Me.CheckBox1099Info_Is1099Vendor.Name = "CheckBox1099Info_Is1099Vendor"
            Me.CheckBox1099Info_Is1099Vendor.OldestSibling = Nothing
            Me.CheckBox1099Info_Is1099Vendor.SecurityEnabled = True
            Me.CheckBox1099Info_Is1099Vendor.SiblingControls = CType(resources.GetObject("CheckBox1099Info_Is1099Vendor.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBox1099Info_Is1099Vendor.Size = New System.Drawing.Size(806, 20)
            Me.CheckBox1099Info_Is1099Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBox1099Info_Is1099Vendor.TabIndex = 0
            Me.CheckBox1099Info_Is1099Vendor.TabOnEnter = True
            Me.CheckBox1099Info_Is1099Vendor.Text = "1099 Vendor"
            '
            'TabItemVendorDetails_1099InfoTab
            '
            Me.TabItemVendorDetails_1099InfoTab.AttachedControl = Me.TabControlPanel1099InfoTab_1099Info
            Me.TabItemVendorDetails_1099InfoTab.Name = "TabItemVendorDetails_1099InfoTab"
            Me.TabItemVendorDetails_1099InfoTab.Text = "1099 Info"
            '
            'TabControlPanelMediaInfoTab_MediaInfo
            '
            Me.TabControlPanelMediaInfoTab_MediaInfo.Controls.Add(Me.PanelMediaInfo_Magazine)
            Me.TabControlPanelMediaInfoTab_MediaInfo.Controls.Add(Me.PanelMediaInfo_Newspaper)
            Me.TabControlPanelMediaInfoTab_MediaInfo.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMediaInfoTab_MediaInfo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaInfoTab_MediaInfo.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaInfoTab_MediaInfo.Name = "TabControlPanelMediaInfoTab_MediaInfo"
            Me.TabControlPanelMediaInfoTab_MediaInfo.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaInfoTab_MediaInfo.Size = New System.Drawing.Size(815, 513)
            Me.TabControlPanelMediaInfoTab_MediaInfo.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMediaInfoTab_MediaInfo.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaInfoTab_MediaInfo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaInfoTab_MediaInfo.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaInfoTab_MediaInfo.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaInfoTab_MediaInfo.Style.GradientAngle = 90
            Me.TabControlPanelMediaInfoTab_MediaInfo.TabIndex = 6
            Me.TabControlPanelMediaInfoTab_MediaInfo.TabItem = Me.TabItemVendorDetails_MediaInfoTab
            '
            'PanelMediaInfo_Magazine
            '
            Me.PanelMediaInfo_Magazine.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelMediaInfo_Magazine.BackColor = System.Drawing.Color.White
            Me.PanelMediaInfo_Magazine.Controls.Add(Me.NumericInputMagazine_Issues)
            Me.PanelMediaInfo_Magazine.Controls.Add(Me.NumericInputMagazine_Circulation)
            Me.PanelMediaInfo_Magazine.Controls.Add(Me.TextBoxMagazine_Cycles)
            Me.PanelMediaInfo_Magazine.Controls.Add(Me.TextBoxMagazine_Editions)
            Me.PanelMediaInfo_Magazine.Controls.Add(Me.LabelMagazine_Editions)
            Me.PanelMediaInfo_Magazine.Controls.Add(Me.TextBoxMagazine_PublishingFrequency)
            Me.PanelMediaInfo_Magazine.Controls.Add(Me.LabelMagazine_PublishingFrequency)
            Me.PanelMediaInfo_Magazine.Controls.Add(Me.LabelMagazine_Issues)
            Me.PanelMediaInfo_Magazine.Controls.Add(Me.LabelMagazine_Cycles)
            Me.PanelMediaInfo_Magazine.Controls.Add(Me.LabelNewspaper_Circulation)
            Me.PanelMediaInfo_Magazine.Location = New System.Drawing.Point(6, 6)
            Me.PanelMediaInfo_Magazine.Name = "PanelMediaInfo_Magazine"
            Me.PanelMediaInfo_Magazine.Size = New System.Drawing.Size(803, 501)
            Me.PanelMediaInfo_Magazine.TabIndex = 7
            '
            'NumericInputMagazine_Issues
            '
            Me.NumericInputMagazine_Issues.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputMagazine_Issues.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputMagazine_Issues.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputMagazine_Issues.EnterMoveNextControl = True
            Me.NumericInputMagazine_Issues.Location = New System.Drawing.Point(133, 52)
            Me.NumericInputMagazine_Issues.Name = "NumericInputMagazine_Issues"
            Me.NumericInputMagazine_Issues.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputMagazine_Issues.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMagazine_Issues.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputMagazine_Issues.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMagazine_Issues.Properties.IsFloatValue = False
            Me.NumericInputMagazine_Issues.Properties.Mask.EditMask = "f0"
            Me.NumericInputMagazine_Issues.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputMagazine_Issues.Properties.MaxLength = 11
            Me.NumericInputMagazine_Issues.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputMagazine_Issues.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputMagazine_Issues.SecurityEnabled = True
            Me.NumericInputMagazine_Issues.Size = New System.Drawing.Size(100, 20)
            Me.NumericInputMagazine_Issues.TabIndex = 5
            '
            'NumericInputMagazine_Circulation
            '
            Me.NumericInputMagazine_Circulation.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputMagazine_Circulation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputMagazine_Circulation.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputMagazine_Circulation.EnterMoveNextControl = True
            Me.NumericInputMagazine_Circulation.Location = New System.Drawing.Point(133, 0)
            Me.NumericInputMagazine_Circulation.Name = "NumericInputMagazine_Circulation"
            Me.NumericInputMagazine_Circulation.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputMagazine_Circulation.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMagazine_Circulation.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputMagazine_Circulation.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputMagazine_Circulation.Properties.IsFloatValue = False
            Me.NumericInputMagazine_Circulation.Properties.Mask.EditMask = "f0"
            Me.NumericInputMagazine_Circulation.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputMagazine_Circulation.Properties.MaxLength = 11
            Me.NumericInputMagazine_Circulation.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputMagazine_Circulation.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputMagazine_Circulation.SecurityEnabled = True
            Me.NumericInputMagazine_Circulation.Size = New System.Drawing.Size(100, 20)
            Me.NumericInputMagazine_Circulation.TabIndex = 1
            '
            'TextBoxMagazine_Cycles
            '
            Me.TextBoxMagazine_Cycles.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMagazine_Cycles.Border.Class = "TextBoxBorder"
            Me.TextBoxMagazine_Cycles.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMagazine_Cycles.CheckSpellingOnValidate = False
            Me.TextBoxMagazine_Cycles.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMagazine_Cycles.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMagazine_Cycles.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxMagazine_Cycles.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMagazine_Cycles.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMagazine_Cycles.FocusHighlightEnabled = True
            Me.TextBoxMagazine_Cycles.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMagazine_Cycles.Location = New System.Drawing.Point(133, 26)
            Me.TextBoxMagazine_Cycles.MaxFileSize = CType(0, Long)
            Me.TextBoxMagazine_Cycles.Name = "TextBoxMagazine_Cycles"
            Me.TextBoxMagazine_Cycles.SecurityEnabled = True
            Me.TextBoxMagazine_Cycles.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMagazine_Cycles.Size = New System.Drawing.Size(100, 20)
            Me.TextBoxMagazine_Cycles.StartingFolderName = Nothing
            Me.TextBoxMagazine_Cycles.TabIndex = 3
            Me.TextBoxMagazine_Cycles.TabOnEnter = True
            '
            'TextBoxMagazine_Editions
            '
            Me.TextBoxMagazine_Editions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMagazine_Editions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMagazine_Editions.Border.Class = "TextBoxBorder"
            Me.TextBoxMagazine_Editions.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMagazine_Editions.CheckSpellingOnValidate = False
            Me.TextBoxMagazine_Editions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMagazine_Editions.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMagazine_Editions.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxMagazine_Editions.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMagazine_Editions.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMagazine_Editions.FocusHighlightEnabled = True
            Me.TextBoxMagazine_Editions.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMagazine_Editions.Location = New System.Drawing.Point(133, 156)
            Me.TextBoxMagazine_Editions.MaxFileSize = CType(0, Long)
            Me.TextBoxMagazine_Editions.Multiline = True
            Me.TextBoxMagazine_Editions.Name = "TextBoxMagazine_Editions"
            Me.TextBoxMagazine_Editions.SecurityEnabled = True
            Me.TextBoxMagazine_Editions.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMagazine_Editions.Size = New System.Drawing.Size(670, 345)
            Me.TextBoxMagazine_Editions.StartingFolderName = Nothing
            Me.TextBoxMagazine_Editions.TabIndex = 9
            Me.TextBoxMagazine_Editions.TabOnEnter = False
            '
            'LabelMagazine_Editions
            '
            Me.LabelMagazine_Editions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMagazine_Editions.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelMagazine_Editions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMagazine_Editions.Location = New System.Drawing.Point(0, 156)
            Me.LabelMagazine_Editions.Name = "LabelMagazine_Editions"
            Me.LabelMagazine_Editions.Size = New System.Drawing.Size(116, 20)
            Me.LabelMagazine_Editions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMagazine_Editions.TabIndex = 8
            Me.LabelMagazine_Editions.Text = "Editions:"
            '
            'TextBoxMagazine_PublishingFrequency
            '
            Me.TextBoxMagazine_PublishingFrequency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMagazine_PublishingFrequency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMagazine_PublishingFrequency.Border.Class = "TextBoxBorder"
            Me.TextBoxMagazine_PublishingFrequency.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMagazine_PublishingFrequency.CheckSpellingOnValidate = False
            Me.TextBoxMagazine_PublishingFrequency.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMagazine_PublishingFrequency.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMagazine_PublishingFrequency.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxMagazine_PublishingFrequency.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMagazine_PublishingFrequency.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMagazine_PublishingFrequency.FocusHighlightEnabled = True
            Me.TextBoxMagazine_PublishingFrequency.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMagazine_PublishingFrequency.Location = New System.Drawing.Point(133, 78)
            Me.TextBoxMagazine_PublishingFrequency.MaxFileSize = CType(0, Long)
            Me.TextBoxMagazine_PublishingFrequency.Multiline = True
            Me.TextBoxMagazine_PublishingFrequency.Name = "TextBoxMagazine_PublishingFrequency"
            Me.TextBoxMagazine_PublishingFrequency.SecurityEnabled = True
            Me.TextBoxMagazine_PublishingFrequency.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMagazine_PublishingFrequency.Size = New System.Drawing.Size(670, 72)
            Me.TextBoxMagazine_PublishingFrequency.StartingFolderName = Nothing
            Me.TextBoxMagazine_PublishingFrequency.TabIndex = 7
            Me.TextBoxMagazine_PublishingFrequency.TabOnEnter = False
            '
            'LabelMagazine_PublishingFrequency
            '
            Me.LabelMagazine_PublishingFrequency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMagazine_PublishingFrequency.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelMagazine_PublishingFrequency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMagazine_PublishingFrequency.Location = New System.Drawing.Point(0, 78)
            Me.LabelMagazine_PublishingFrequency.Name = "LabelMagazine_PublishingFrequency"
            Me.LabelMagazine_PublishingFrequency.Size = New System.Drawing.Size(116, 20)
            Me.LabelMagazine_PublishingFrequency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMagazine_PublishingFrequency.TabIndex = 6
            Me.LabelMagazine_PublishingFrequency.Text = "Publishing Frequency:"
            '
            'LabelMagazine_Issues
            '
            Me.LabelMagazine_Issues.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMagazine_Issues.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelMagazine_Issues.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMagazine_Issues.Location = New System.Drawing.Point(0, 52)
            Me.LabelMagazine_Issues.Name = "LabelMagazine_Issues"
            Me.LabelMagazine_Issues.Size = New System.Drawing.Size(116, 20)
            Me.LabelMagazine_Issues.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMagazine_Issues.TabIndex = 4
            Me.LabelMagazine_Issues.Text = "Issues:"
            '
            'LabelMagazine_Cycles
            '
            Me.LabelMagazine_Cycles.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMagazine_Cycles.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelMagazine_Cycles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMagazine_Cycles.Location = New System.Drawing.Point(0, 26)
            Me.LabelMagazine_Cycles.Name = "LabelMagazine_Cycles"
            Me.LabelMagazine_Cycles.Size = New System.Drawing.Size(116, 20)
            Me.LabelMagazine_Cycles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMagazine_Cycles.TabIndex = 2
            Me.LabelMagazine_Cycles.Text = "Cycles:"
            '
            'LabelNewspaper_Circulation
            '
            Me.LabelNewspaper_Circulation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNewspaper_Circulation.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelNewspaper_Circulation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNewspaper_Circulation.Location = New System.Drawing.Point(0, 0)
            Me.LabelNewspaper_Circulation.Name = "LabelNewspaper_Circulation"
            Me.LabelNewspaper_Circulation.Size = New System.Drawing.Size(116, 20)
            Me.LabelNewspaper_Circulation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNewspaper_Circulation.TabIndex = 0
            Me.LabelNewspaper_Circulation.Text = "Circulation:"
            '
            'PanelMediaInfo_Newspaper
            '
            Me.PanelMediaInfo_Newspaper.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelMediaInfo_Newspaper.BackColor = System.Drawing.Color.White
            Me.PanelMediaInfo_Newspaper.Controls.Add(Me.NumericInputNewspaper_DailyCirculation)
            Me.PanelMediaInfo_Newspaper.Controls.Add(Me.NumericInputNewspaper_SundayCirculation)
            Me.PanelMediaInfo_Newspaper.Controls.Add(Me.TextBoxNewspaper_Editions)
            Me.PanelMediaInfo_Newspaper.Controls.Add(Me.LabelNewspaper_Editions)
            Me.PanelMediaInfo_Newspaper.Controls.Add(Me.TextBoxNewspaper_PublishingFrequency)
            Me.PanelMediaInfo_Newspaper.Controls.Add(Me.LabelNewspaper_PublishingFrequency)
            Me.PanelMediaInfo_Newspaper.Controls.Add(Me.LabelNewspaper_DailyCirculation)
            Me.PanelMediaInfo_Newspaper.Controls.Add(Me.LabelMagazine_SundayCirculation)
            Me.PanelMediaInfo_Newspaper.Location = New System.Drawing.Point(6, 6)
            Me.PanelMediaInfo_Newspaper.Name = "PanelMediaInfo_Newspaper"
            Me.PanelMediaInfo_Newspaper.Size = New System.Drawing.Size(803, 501)
            Me.PanelMediaInfo_Newspaper.TabIndex = 8
            '
            'NumericInputNewspaper_DailyCirculation
            '
            Me.NumericInputNewspaper_DailyCirculation.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputNewspaper_DailyCirculation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputNewspaper_DailyCirculation.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputNewspaper_DailyCirculation.EnterMoveNextControl = True
            Me.NumericInputNewspaper_DailyCirculation.Location = New System.Drawing.Point(133, 26)
            Me.NumericInputNewspaper_DailyCirculation.Name = "NumericInputNewspaper_DailyCirculation"
            Me.NumericInputNewspaper_DailyCirculation.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputNewspaper_DailyCirculation.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNewspaper_DailyCirculation.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputNewspaper_DailyCirculation.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNewspaper_DailyCirculation.Properties.IsFloatValue = False
            Me.NumericInputNewspaper_DailyCirculation.Properties.Mask.EditMask = "f0"
            Me.NumericInputNewspaper_DailyCirculation.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputNewspaper_DailyCirculation.Properties.MaxLength = 11
            Me.NumericInputNewspaper_DailyCirculation.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputNewspaper_DailyCirculation.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputNewspaper_DailyCirculation.SecurityEnabled = True
            Me.NumericInputNewspaper_DailyCirculation.Size = New System.Drawing.Size(100, 20)
            Me.NumericInputNewspaper_DailyCirculation.TabIndex = 3
            '
            'NumericInputNewspaper_SundayCirculation
            '
            Me.NumericInputNewspaper_SundayCirculation.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputNewspaper_SundayCirculation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputNewspaper_SundayCirculation.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputNewspaper_SundayCirculation.EnterMoveNextControl = True
            Me.NumericInputNewspaper_SundayCirculation.Location = New System.Drawing.Point(133, 0)
            Me.NumericInputNewspaper_SundayCirculation.Name = "NumericInputNewspaper_SundayCirculation"
            Me.NumericInputNewspaper_SundayCirculation.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputNewspaper_SundayCirculation.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNewspaper_SundayCirculation.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputNewspaper_SundayCirculation.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputNewspaper_SundayCirculation.Properties.IsFloatValue = False
            Me.NumericInputNewspaper_SundayCirculation.Properties.Mask.EditMask = "f0"
            Me.NumericInputNewspaper_SundayCirculation.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputNewspaper_SundayCirculation.Properties.MaxLength = 11
            Me.NumericInputNewspaper_SundayCirculation.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputNewspaper_SundayCirculation.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputNewspaper_SundayCirculation.SecurityEnabled = True
            Me.NumericInputNewspaper_SundayCirculation.Size = New System.Drawing.Size(100, 20)
            Me.NumericInputNewspaper_SundayCirculation.TabIndex = 1
            '
            'TextBoxNewspaper_Editions
            '
            Me.TextBoxNewspaper_Editions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxNewspaper_Editions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxNewspaper_Editions.Border.Class = "TextBoxBorder"
            Me.TextBoxNewspaper_Editions.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxNewspaper_Editions.CheckSpellingOnValidate = False
            Me.TextBoxNewspaper_Editions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxNewspaper_Editions.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxNewspaper_Editions.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxNewspaper_Editions.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxNewspaper_Editions.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxNewspaper_Editions.FocusHighlightEnabled = True
            Me.TextBoxNewspaper_Editions.ForeColor = System.Drawing.Color.Black
            Me.TextBoxNewspaper_Editions.Location = New System.Drawing.Point(133, 130)
            Me.TextBoxNewspaper_Editions.MaxFileSize = CType(0, Long)
            Me.TextBoxNewspaper_Editions.Multiline = True
            Me.TextBoxNewspaper_Editions.Name = "TextBoxNewspaper_Editions"
            Me.TextBoxNewspaper_Editions.SecurityEnabled = True
            Me.TextBoxNewspaper_Editions.ShowSpellCheckCompleteMessage = True
            Me.TextBoxNewspaper_Editions.Size = New System.Drawing.Size(670, 371)
            Me.TextBoxNewspaper_Editions.StartingFolderName = Nothing
            Me.TextBoxNewspaper_Editions.TabIndex = 7
            Me.TextBoxNewspaper_Editions.TabOnEnter = False
            '
            'LabelNewspaper_Editions
            '
            Me.LabelNewspaper_Editions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNewspaper_Editions.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelNewspaper_Editions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNewspaper_Editions.Location = New System.Drawing.Point(0, 130)
            Me.LabelNewspaper_Editions.Name = "LabelNewspaper_Editions"
            Me.LabelNewspaper_Editions.Size = New System.Drawing.Size(116, 20)
            Me.LabelNewspaper_Editions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNewspaper_Editions.TabIndex = 6
            Me.LabelNewspaper_Editions.Text = "Editions:"
            '
            'TextBoxNewspaper_PublishingFrequency
            '
            Me.TextBoxNewspaper_PublishingFrequency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxNewspaper_PublishingFrequency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxNewspaper_PublishingFrequency.Border.Class = "TextBoxBorder"
            Me.TextBoxNewspaper_PublishingFrequency.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxNewspaper_PublishingFrequency.CheckSpellingOnValidate = False
            Me.TextBoxNewspaper_PublishingFrequency.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxNewspaper_PublishingFrequency.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxNewspaper_PublishingFrequency.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxNewspaper_PublishingFrequency.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxNewspaper_PublishingFrequency.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxNewspaper_PublishingFrequency.FocusHighlightEnabled = True
            Me.TextBoxNewspaper_PublishingFrequency.ForeColor = System.Drawing.Color.Black
            Me.TextBoxNewspaper_PublishingFrequency.Location = New System.Drawing.Point(133, 52)
            Me.TextBoxNewspaper_PublishingFrequency.MaxFileSize = CType(0, Long)
            Me.TextBoxNewspaper_PublishingFrequency.Multiline = True
            Me.TextBoxNewspaper_PublishingFrequency.Name = "TextBoxNewspaper_PublishingFrequency"
            Me.TextBoxNewspaper_PublishingFrequency.SecurityEnabled = True
            Me.TextBoxNewspaper_PublishingFrequency.ShowSpellCheckCompleteMessage = True
            Me.TextBoxNewspaper_PublishingFrequency.Size = New System.Drawing.Size(670, 72)
            Me.TextBoxNewspaper_PublishingFrequency.StartingFolderName = Nothing
            Me.TextBoxNewspaper_PublishingFrequency.TabIndex = 5
            Me.TextBoxNewspaper_PublishingFrequency.TabOnEnter = False
            '
            'LabelNewspaper_PublishingFrequency
            '
            Me.LabelNewspaper_PublishingFrequency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNewspaper_PublishingFrequency.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelNewspaper_PublishingFrequency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNewspaper_PublishingFrequency.Location = New System.Drawing.Point(0, 52)
            Me.LabelNewspaper_PublishingFrequency.Name = "LabelNewspaper_PublishingFrequency"
            Me.LabelNewspaper_PublishingFrequency.Size = New System.Drawing.Size(116, 20)
            Me.LabelNewspaper_PublishingFrequency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNewspaper_PublishingFrequency.TabIndex = 4
            Me.LabelNewspaper_PublishingFrequency.Text = "Publishing Frequency:"
            '
            'LabelNewspaper_DailyCirculation
            '
            Me.LabelNewspaper_DailyCirculation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelNewspaper_DailyCirculation.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelNewspaper_DailyCirculation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelNewspaper_DailyCirculation.Location = New System.Drawing.Point(0, 26)
            Me.LabelNewspaper_DailyCirculation.Name = "LabelNewspaper_DailyCirculation"
            Me.LabelNewspaper_DailyCirculation.Size = New System.Drawing.Size(116, 20)
            Me.LabelNewspaper_DailyCirculation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelNewspaper_DailyCirculation.TabIndex = 2
            Me.LabelNewspaper_DailyCirculation.Text = "Daily Circulation:"
            '
            'LabelMagazine_SundayCirculation
            '
            Me.LabelMagazine_SundayCirculation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMagazine_SundayCirculation.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelMagazine_SundayCirculation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMagazine_SundayCirculation.Location = New System.Drawing.Point(0, 0)
            Me.LabelMagazine_SundayCirculation.Name = "LabelMagazine_SundayCirculation"
            Me.LabelMagazine_SundayCirculation.Size = New System.Drawing.Size(116, 20)
            Me.LabelMagazine_SundayCirculation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMagazine_SundayCirculation.TabIndex = 0
            Me.LabelMagazine_SundayCirculation.Text = "Sunday Circulation:"
            '
            'TabItemVendorDetails_MediaInfoTab
            '
            Me.TabItemVendorDetails_MediaInfoTab.AttachedControl = Me.TabControlPanelMediaInfoTab_MediaInfo
            Me.TabItemVendorDetails_MediaInfoTab.Name = "TabItemVendorDetails_MediaInfoTab"
            Me.TabItemVendorDetails_MediaInfoTab.Text = "Media Info"
            '
            'TabControlPanelMediaDeliveryTab_MediaDelivery
            '
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.Controls.Add(Me.TableLayoutPanelMediaDelivery_TableLayout)
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.Name = "TabControlPanelMediaDeliveryTab_MediaDelivery"
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.Size = New System.Drawing.Size(815, 513)
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.Style.GradientAngle = 90
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.TabIndex = 7
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.TabItem = Me.TabItemVendorDetails_MediaDeliveryTab
            '
            'TableLayoutPanelMediaDelivery_TableLayout
            '
            Me.TableLayoutPanelMediaDelivery_TableLayout.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelMediaDelivery_TableLayout.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelMediaDelivery_TableLayout.ColumnCount = 2
            Me.TableLayoutPanelMediaDelivery_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelMediaDelivery_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelMediaDelivery_TableLayout.Controls.Add(Me.PanelMediaDelivery_RightColumn, 1, 0)
            Me.TableLayoutPanelMediaDelivery_TableLayout.Controls.Add(Me.PanelMediaDelivery_LeftColumn, 0, 0)
            Me.TableLayoutPanelMediaDelivery_TableLayout.Location = New System.Drawing.Point(6, 6)
            Me.TableLayoutPanelMediaDelivery_TableLayout.Name = "TableLayoutPanelMediaDelivery_TableLayout"
            Me.TableLayoutPanelMediaDelivery_TableLayout.RowCount = 1
            Me.TableLayoutPanelMediaDelivery_TableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelMediaDelivery_TableLayout.Size = New System.Drawing.Size(803, 501)
            Me.TableLayoutPanelMediaDelivery_TableLayout.TabIndex = 0
            '
            'PanelMediaDelivery_RightColumn
            '
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.LabelMediaDelivery_DefaultCorrespondenceMethod)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.LabelMediaDelivery_)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.ButtonMediaDelivery_CheckSpelling)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.LabelMediaDelivery_AcceptedMedia)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.LabelMediaDelivery_GeneralInfo)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.LabelMediaDelivery_EFileInfo)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.TextBoxMediaDelivery_FTPDirectory)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.LabelMediaDelivery_PreferredMaterial)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.TextBoxMediaDelivery_FTPPassword)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.LabelMediaDelivery_FTPUserName)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.TextBoxMediaDelivery_FTPUserName)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.LabelMediaDelivery_FTPPassword)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.TextBoxMediaDelivery_PreferredMaterial)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.LabelMediaDelivery_FTPDirectory)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.TextBoxMediaDelivery_EFileInfo)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.TextBoxMediaDelivery_GeneralInfo)
            Me.PanelMediaDelivery_RightColumn.Controls.Add(Me.TextBoxMediaDelivery_AcceptedMedia)
            Me.PanelMediaDelivery_RightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelMediaDelivery_RightColumn.Location = New System.Drawing.Point(401, 0)
            Me.PanelMediaDelivery_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelMediaDelivery_RightColumn.Name = "PanelMediaDelivery_RightColumn"
            Me.PanelMediaDelivery_RightColumn.Size = New System.Drawing.Size(402, 501)
            Me.PanelMediaDelivery_RightColumn.TabIndex = 1
            '
            'ComboBoxMediaDelivery_DefaultCorrespondenceMethod
            '
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.AutoFindItemInDataSource = False
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.BookmarkingEnabled = False
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.ClientCode = ""
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.DisableMouseWheel = False
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.DisplayMember = "Name"
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.DisplayName = ""
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.DivisionCode = ""
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.FocusHighlightEnabled = True
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.FormattingEnabled = True
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.ItemHeight = 14
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.Location = New System.Drawing.Point(181, 338)
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.Name = "ComboBoxMediaDelivery_DefaultCorrespondenceMethod"
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.ReadOnly = False
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.SecurityEnabled = True
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.Size = New System.Drawing.Size(217, 20)
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.TabIndex = 18
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.TabOnEnter = True
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.ValueMember = "Value"
            Me.ComboBoxMediaDelivery_DefaultCorrespondenceMethod.WatermarkText = "Select"
            '
            'LabelMediaDelivery_DefaultCorrespondenceMethod
            '
            Me.LabelMediaDelivery_DefaultCorrespondenceMethod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDelivery_DefaultCorrespondenceMethod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDelivery_DefaultCorrespondenceMethod.Location = New System.Drawing.Point(3, 338)
            Me.LabelMediaDelivery_DefaultCorrespondenceMethod.Name = "LabelMediaDelivery_DefaultCorrespondenceMethod"
            Me.LabelMediaDelivery_DefaultCorrespondenceMethod.Size = New System.Drawing.Size(172, 20)
            Me.LabelMediaDelivery_DefaultCorrespondenceMethod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDelivery_DefaultCorrespondenceMethod.TabIndex = 17
            Me.LabelMediaDelivery_DefaultCorrespondenceMethod.Text = "Default Correspondence Method:"
            '
            'LabelMediaDelivery_
            '
            Me.LabelMediaDelivery_.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelMediaDelivery_.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDelivery_.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelMediaDelivery_.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelMediaDelivery_.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelMediaDelivery_.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelMediaDelivery_.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelMediaDelivery_.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelMediaDelivery_.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDelivery_.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelMediaDelivery_.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelMediaDelivery_.Location = New System.Drawing.Point(4, 0)
            Me.LabelMediaDelivery_.Name = "LabelMediaDelivery_"
            Me.LabelMediaDelivery_.Size = New System.Drawing.Size(394, 20)
            Me.LabelMediaDelivery_.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDelivery_.TabIndex = 1
            Me.LabelMediaDelivery_.Text = "General"
            '
            'ButtonMediaDelivery_CheckSpelling
            '
            Me.ButtonMediaDelivery_CheckSpelling.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonMediaDelivery_CheckSpelling.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonMediaDelivery_CheckSpelling.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonMediaDelivery_CheckSpelling.Location = New System.Drawing.Point(276, 156)
            Me.ButtonMediaDelivery_CheckSpelling.Name = "ButtonMediaDelivery_CheckSpelling"
            Me.ButtonMediaDelivery_CheckSpelling.SecurityEnabled = True
            Me.ButtonMediaDelivery_CheckSpelling.Size = New System.Drawing.Size(122, 20)
            Me.ButtonMediaDelivery_CheckSpelling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonMediaDelivery_CheckSpelling.TabIndex = 4
            Me.ButtonMediaDelivery_CheckSpelling.Text = "Check Spelling"
            '
            'LabelMediaDelivery_AcceptedMedia
            '
            Me.LabelMediaDelivery_AcceptedMedia.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDelivery_AcceptedMedia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDelivery_AcceptedMedia.Location = New System.Drawing.Point(4, 182)
            Me.LabelMediaDelivery_AcceptedMedia.Name = "LabelMediaDelivery_AcceptedMedia"
            Me.LabelMediaDelivery_AcceptedMedia.Size = New System.Drawing.Size(95, 20)
            Me.LabelMediaDelivery_AcceptedMedia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDelivery_AcceptedMedia.TabIndex = 5
            Me.LabelMediaDelivery_AcceptedMedia.Text = "Accepted Media:"
            '
            'LabelMediaDelivery_GeneralInfo
            '
            Me.LabelMediaDelivery_GeneralInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDelivery_GeneralInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDelivery_GeneralInfo.Location = New System.Drawing.Point(4, 26)
            Me.LabelMediaDelivery_GeneralInfo.Name = "LabelMediaDelivery_GeneralInfo"
            Me.LabelMediaDelivery_GeneralInfo.Size = New System.Drawing.Size(95, 20)
            Me.LabelMediaDelivery_GeneralInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDelivery_GeneralInfo.TabIndex = 2
            Me.LabelMediaDelivery_GeneralInfo.Text = "General Info:"
            '
            'LabelMediaDelivery_EFileInfo
            '
            Me.LabelMediaDelivery_EFileInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDelivery_EFileInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDelivery_EFileInfo.Location = New System.Drawing.Point(4, 208)
            Me.LabelMediaDelivery_EFileInfo.Name = "LabelMediaDelivery_EFileInfo"
            Me.LabelMediaDelivery_EFileInfo.Size = New System.Drawing.Size(95, 20)
            Me.LabelMediaDelivery_EFileInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDelivery_EFileInfo.TabIndex = 7
            Me.LabelMediaDelivery_EFileInfo.Text = "E-File Info:"
            '
            'TextBoxMediaDelivery_FTPDirectory
            '
            Me.TextBoxMediaDelivery_FTPDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMediaDelivery_FTPDirectory.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMediaDelivery_FTPDirectory.Border.Class = "TextBoxBorder"
            Me.TextBoxMediaDelivery_FTPDirectory.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMediaDelivery_FTPDirectory.CheckSpellingOnValidate = False
            Me.TextBoxMediaDelivery_FTPDirectory.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMediaDelivery_FTPDirectory.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMediaDelivery_FTPDirectory.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxMediaDelivery_FTPDirectory.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMediaDelivery_FTPDirectory.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMediaDelivery_FTPDirectory.FocusHighlightEnabled = True
            Me.TextBoxMediaDelivery_FTPDirectory.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMediaDelivery_FTPDirectory.Location = New System.Drawing.Point(105, 312)
            Me.TextBoxMediaDelivery_FTPDirectory.MaxFileSize = CType(0, Long)
            Me.TextBoxMediaDelivery_FTPDirectory.Name = "TextBoxMediaDelivery_FTPDirectory"
            Me.TextBoxMediaDelivery_FTPDirectory.SecurityEnabled = True
            Me.TextBoxMediaDelivery_FTPDirectory.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMediaDelivery_FTPDirectory.Size = New System.Drawing.Size(293, 20)
            Me.TextBoxMediaDelivery_FTPDirectory.StartingFolderName = Nothing
            Me.TextBoxMediaDelivery_FTPDirectory.TabIndex = 16
            Me.TextBoxMediaDelivery_FTPDirectory.TabOnEnter = True
            '
            'LabelMediaDelivery_PreferredMaterial
            '
            Me.LabelMediaDelivery_PreferredMaterial.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDelivery_PreferredMaterial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDelivery_PreferredMaterial.Location = New System.Drawing.Point(4, 234)
            Me.LabelMediaDelivery_PreferredMaterial.Name = "LabelMediaDelivery_PreferredMaterial"
            Me.LabelMediaDelivery_PreferredMaterial.Size = New System.Drawing.Size(95, 20)
            Me.LabelMediaDelivery_PreferredMaterial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDelivery_PreferredMaterial.TabIndex = 9
            Me.LabelMediaDelivery_PreferredMaterial.Text = "Preferred Material:"
            '
            'TextBoxMediaDelivery_FTPPassword
            '
            Me.TextBoxMediaDelivery_FTPPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMediaDelivery_FTPPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMediaDelivery_FTPPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxMediaDelivery_FTPPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMediaDelivery_FTPPassword.CheckSpellingOnValidate = False
            Me.TextBoxMediaDelivery_FTPPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMediaDelivery_FTPPassword.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMediaDelivery_FTPPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxMediaDelivery_FTPPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMediaDelivery_FTPPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMediaDelivery_FTPPassword.FocusHighlightEnabled = True
            Me.TextBoxMediaDelivery_FTPPassword.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMediaDelivery_FTPPassword.Location = New System.Drawing.Point(105, 286)
            Me.TextBoxMediaDelivery_FTPPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxMediaDelivery_FTPPassword.Name = "TextBoxMediaDelivery_FTPPassword"
            Me.TextBoxMediaDelivery_FTPPassword.SecurityEnabled = True
            Me.TextBoxMediaDelivery_FTPPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMediaDelivery_FTPPassword.Size = New System.Drawing.Size(293, 20)
            Me.TextBoxMediaDelivery_FTPPassword.StartingFolderName = Nothing
            Me.TextBoxMediaDelivery_FTPPassword.TabIndex = 14
            Me.TextBoxMediaDelivery_FTPPassword.TabOnEnter = True
            '
            'LabelMediaDelivery_FTPUserName
            '
            Me.LabelMediaDelivery_FTPUserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDelivery_FTPUserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDelivery_FTPUserName.Location = New System.Drawing.Point(4, 260)
            Me.LabelMediaDelivery_FTPUserName.Name = "LabelMediaDelivery_FTPUserName"
            Me.LabelMediaDelivery_FTPUserName.Size = New System.Drawing.Size(95, 20)
            Me.LabelMediaDelivery_FTPUserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDelivery_FTPUserName.TabIndex = 11
            Me.LabelMediaDelivery_FTPUserName.Text = "FTP User Name:"
            '
            'TextBoxMediaDelivery_FTPUserName
            '
            Me.TextBoxMediaDelivery_FTPUserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMediaDelivery_FTPUserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMediaDelivery_FTPUserName.Border.Class = "TextBoxBorder"
            Me.TextBoxMediaDelivery_FTPUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMediaDelivery_FTPUserName.CheckSpellingOnValidate = False
            Me.TextBoxMediaDelivery_FTPUserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMediaDelivery_FTPUserName.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMediaDelivery_FTPUserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxMediaDelivery_FTPUserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMediaDelivery_FTPUserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMediaDelivery_FTPUserName.FocusHighlightEnabled = True
            Me.TextBoxMediaDelivery_FTPUserName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMediaDelivery_FTPUserName.Location = New System.Drawing.Point(105, 260)
            Me.TextBoxMediaDelivery_FTPUserName.MaxFileSize = CType(0, Long)
            Me.TextBoxMediaDelivery_FTPUserName.Name = "TextBoxMediaDelivery_FTPUserName"
            Me.TextBoxMediaDelivery_FTPUserName.SecurityEnabled = True
            Me.TextBoxMediaDelivery_FTPUserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMediaDelivery_FTPUserName.Size = New System.Drawing.Size(293, 20)
            Me.TextBoxMediaDelivery_FTPUserName.StartingFolderName = Nothing
            Me.TextBoxMediaDelivery_FTPUserName.TabIndex = 12
            Me.TextBoxMediaDelivery_FTPUserName.TabOnEnter = True
            '
            'LabelMediaDelivery_FTPPassword
            '
            Me.LabelMediaDelivery_FTPPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDelivery_FTPPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDelivery_FTPPassword.Location = New System.Drawing.Point(4, 286)
            Me.LabelMediaDelivery_FTPPassword.Name = "LabelMediaDelivery_FTPPassword"
            Me.LabelMediaDelivery_FTPPassword.Size = New System.Drawing.Size(95, 20)
            Me.LabelMediaDelivery_FTPPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDelivery_FTPPassword.TabIndex = 13
            Me.LabelMediaDelivery_FTPPassword.Text = "FTP Password:"
            '
            'TextBoxMediaDelivery_PreferredMaterial
            '
            Me.TextBoxMediaDelivery_PreferredMaterial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMediaDelivery_PreferredMaterial.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMediaDelivery_PreferredMaterial.Border.Class = "TextBoxBorder"
            Me.TextBoxMediaDelivery_PreferredMaterial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMediaDelivery_PreferredMaterial.CheckSpellingOnValidate = False
            Me.TextBoxMediaDelivery_PreferredMaterial.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMediaDelivery_PreferredMaterial.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMediaDelivery_PreferredMaterial.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxMediaDelivery_PreferredMaterial.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMediaDelivery_PreferredMaterial.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMediaDelivery_PreferredMaterial.FocusHighlightEnabled = True
            Me.TextBoxMediaDelivery_PreferredMaterial.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMediaDelivery_PreferredMaterial.Location = New System.Drawing.Point(105, 234)
            Me.TextBoxMediaDelivery_PreferredMaterial.MaxFileSize = CType(0, Long)
            Me.TextBoxMediaDelivery_PreferredMaterial.Name = "TextBoxMediaDelivery_PreferredMaterial"
            Me.TextBoxMediaDelivery_PreferredMaterial.SecurityEnabled = True
            Me.TextBoxMediaDelivery_PreferredMaterial.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMediaDelivery_PreferredMaterial.Size = New System.Drawing.Size(293, 20)
            Me.TextBoxMediaDelivery_PreferredMaterial.StartingFolderName = Nothing
            Me.TextBoxMediaDelivery_PreferredMaterial.TabIndex = 10
            Me.TextBoxMediaDelivery_PreferredMaterial.TabOnEnter = True
            '
            'LabelMediaDelivery_FTPDirectory
            '
            Me.LabelMediaDelivery_FTPDirectory.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDelivery_FTPDirectory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDelivery_FTPDirectory.Location = New System.Drawing.Point(4, 312)
            Me.LabelMediaDelivery_FTPDirectory.Name = "LabelMediaDelivery_FTPDirectory"
            Me.LabelMediaDelivery_FTPDirectory.Size = New System.Drawing.Size(95, 20)
            Me.LabelMediaDelivery_FTPDirectory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDelivery_FTPDirectory.TabIndex = 15
            Me.LabelMediaDelivery_FTPDirectory.Text = "FTP Directory:"
            '
            'TextBoxMediaDelivery_EFileInfo
            '
            Me.TextBoxMediaDelivery_EFileInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMediaDelivery_EFileInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMediaDelivery_EFileInfo.Border.Class = "TextBoxBorder"
            Me.TextBoxMediaDelivery_EFileInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMediaDelivery_EFileInfo.CheckSpellingOnValidate = False
            Me.TextBoxMediaDelivery_EFileInfo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMediaDelivery_EFileInfo.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMediaDelivery_EFileInfo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxMediaDelivery_EFileInfo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMediaDelivery_EFileInfo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMediaDelivery_EFileInfo.FocusHighlightEnabled = True
            Me.TextBoxMediaDelivery_EFileInfo.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMediaDelivery_EFileInfo.Location = New System.Drawing.Point(105, 208)
            Me.TextBoxMediaDelivery_EFileInfo.MaxFileSize = CType(0, Long)
            Me.TextBoxMediaDelivery_EFileInfo.Name = "TextBoxMediaDelivery_EFileInfo"
            Me.TextBoxMediaDelivery_EFileInfo.SecurityEnabled = True
            Me.TextBoxMediaDelivery_EFileInfo.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMediaDelivery_EFileInfo.Size = New System.Drawing.Size(293, 20)
            Me.TextBoxMediaDelivery_EFileInfo.StartingFolderName = Nothing
            Me.TextBoxMediaDelivery_EFileInfo.TabIndex = 8
            Me.TextBoxMediaDelivery_EFileInfo.TabOnEnter = True
            '
            'TextBoxMediaDelivery_GeneralInfo
            '
            Me.TextBoxMediaDelivery_GeneralInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMediaDelivery_GeneralInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMediaDelivery_GeneralInfo.Border.Class = "TextBoxBorder"
            Me.TextBoxMediaDelivery_GeneralInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMediaDelivery_GeneralInfo.CheckSpellingOnValidate = False
            Me.TextBoxMediaDelivery_GeneralInfo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMediaDelivery_GeneralInfo.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMediaDelivery_GeneralInfo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxMediaDelivery_GeneralInfo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMediaDelivery_GeneralInfo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMediaDelivery_GeneralInfo.FocusHighlightEnabled = True
            Me.TextBoxMediaDelivery_GeneralInfo.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMediaDelivery_GeneralInfo.Location = New System.Drawing.Point(105, 26)
            Me.TextBoxMediaDelivery_GeneralInfo.MaxFileSize = CType(0, Long)
            Me.TextBoxMediaDelivery_GeneralInfo.Multiline = True
            Me.TextBoxMediaDelivery_GeneralInfo.Name = "TextBoxMediaDelivery_GeneralInfo"
            Me.TextBoxMediaDelivery_GeneralInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxMediaDelivery_GeneralInfo.SecurityEnabled = True
            Me.TextBoxMediaDelivery_GeneralInfo.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMediaDelivery_GeneralInfo.Size = New System.Drawing.Size(293, 124)
            Me.TextBoxMediaDelivery_GeneralInfo.StartingFolderName = Nothing
            Me.TextBoxMediaDelivery_GeneralInfo.TabIndex = 3
            Me.TextBoxMediaDelivery_GeneralInfo.TabOnEnter = True
            '
            'TextBoxMediaDelivery_AcceptedMedia
            '
            Me.TextBoxMediaDelivery_AcceptedMedia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMediaDelivery_AcceptedMedia.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMediaDelivery_AcceptedMedia.Border.Class = "TextBoxBorder"
            Me.TextBoxMediaDelivery_AcceptedMedia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMediaDelivery_AcceptedMedia.CheckSpellingOnValidate = False
            Me.TextBoxMediaDelivery_AcceptedMedia.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMediaDelivery_AcceptedMedia.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMediaDelivery_AcceptedMedia.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxMediaDelivery_AcceptedMedia.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMediaDelivery_AcceptedMedia.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMediaDelivery_AcceptedMedia.FocusHighlightEnabled = True
            Me.TextBoxMediaDelivery_AcceptedMedia.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMediaDelivery_AcceptedMedia.Location = New System.Drawing.Point(105, 182)
            Me.TextBoxMediaDelivery_AcceptedMedia.MaxFileSize = CType(0, Long)
            Me.TextBoxMediaDelivery_AcceptedMedia.Name = "TextBoxMediaDelivery_AcceptedMedia"
            Me.TextBoxMediaDelivery_AcceptedMedia.SecurityEnabled = True
            Me.TextBoxMediaDelivery_AcceptedMedia.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMediaDelivery_AcceptedMedia.Size = New System.Drawing.Size(293, 20)
            Me.TextBoxMediaDelivery_AcceptedMedia.StartingFolderName = Nothing
            Me.TextBoxMediaDelivery_AcceptedMedia.TabIndex = 6
            Me.TextBoxMediaDelivery_AcceptedMedia.TabOnEnter = True
            '
            'PanelMediaDelivery_LeftColumn
            '
            Me.PanelMediaDelivery_LeftColumn.Controls.Add(Me.GroupBoxMediaDelivery_MediaShipping)
            Me.PanelMediaDelivery_LeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelMediaDelivery_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelMediaDelivery_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelMediaDelivery_LeftColumn.Name = "PanelMediaDelivery_LeftColumn"
            Me.PanelMediaDelivery_LeftColumn.Size = New System.Drawing.Size(401, 501)
            Me.PanelMediaDelivery_LeftColumn.TabIndex = 0
            '
            'GroupBoxMediaDelivery_MediaShipping
            '
            Me.GroupBoxMediaDelivery_MediaShipping.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMediaDelivery_MediaShipping.Controls.Add(Me.LabelMediaShipping_Name)
            Me.GroupBoxMediaDelivery_MediaShipping.Controls.Add(Me.TextBoxMediaShipping_Name)
            Me.GroupBoxMediaDelivery_MediaShipping.Controls.Add(Me.TextBoxMediaShipping_PhoneExt)
            Me.GroupBoxMediaDelivery_MediaShipping.Controls.Add(Me.LabelMediaShipping_PhoneExt)
            Me.GroupBoxMediaDelivery_MediaShipping.Controls.Add(Me.LabelMediaShipping_Phone)
            Me.GroupBoxMediaDelivery_MediaShipping.Controls.Add(Me.TextBoxMediaShipping_Phone)
            Me.GroupBoxMediaDelivery_MediaShipping.Controls.Add(Me.Address3LineControlMediaDelivery_MediaShippingAddress)
            Me.GroupBoxMediaDelivery_MediaShipping.Location = New System.Drawing.Point(0, 0)
            Me.GroupBoxMediaDelivery_MediaShipping.Name = "GroupBoxMediaDelivery_MediaShipping"
            Me.GroupBoxMediaDelivery_MediaShipping.Size = New System.Drawing.Size(398, 294)
            Me.GroupBoxMediaDelivery_MediaShipping.TabIndex = 0
            Me.GroupBoxMediaDelivery_MediaShipping.Text = "Media Shipping"
            '
            'LabelMediaShipping_Name
            '
            Me.LabelMediaShipping_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaShipping_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaShipping_Name.Location = New System.Drawing.Point(5, 24)
            Me.LabelMediaShipping_Name.Name = "LabelMediaShipping_Name"
            Me.LabelMediaShipping_Name.Size = New System.Drawing.Size(40, 20)
            Me.LabelMediaShipping_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaShipping_Name.TabIndex = 5
            Me.LabelMediaShipping_Name.Text = "Name:"
            '
            'TextBoxMediaShipping_Name
            '
            Me.TextBoxMediaShipping_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMediaShipping_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMediaShipping_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxMediaShipping_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMediaShipping_Name.CheckSpellingOnValidate = False
            Me.TextBoxMediaShipping_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMediaShipping_Name.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMediaShipping_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxMediaShipping_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMediaShipping_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMediaShipping_Name.FocusHighlightEnabled = True
            Me.TextBoxMediaShipping_Name.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMediaShipping_Name.Location = New System.Drawing.Point(51, 24)
            Me.TextBoxMediaShipping_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxMediaShipping_Name.Name = "TextBoxMediaShipping_Name"
            Me.TextBoxMediaShipping_Name.SecurityEnabled = True
            Me.TextBoxMediaShipping_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMediaShipping_Name.Size = New System.Drawing.Size(342, 21)
            Me.TextBoxMediaShipping_Name.StartingFolderName = Nothing
            Me.TextBoxMediaShipping_Name.TabIndex = 6
            Me.TextBoxMediaShipping_Name.TabOnEnter = True
            '
            'TextBoxMediaShipping_PhoneExt
            '
            Me.TextBoxMediaShipping_PhoneExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMediaShipping_PhoneExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMediaShipping_PhoneExt.Border.Class = "TextBoxBorder"
            Me.TextBoxMediaShipping_PhoneExt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMediaShipping_PhoneExt.CheckSpellingOnValidate = False
            Me.TextBoxMediaShipping_PhoneExt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMediaShipping_PhoneExt.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMediaShipping_PhoneExt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxMediaShipping_PhoneExt.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMediaShipping_PhoneExt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMediaShipping_PhoneExt.FocusHighlightEnabled = True
            Me.TextBoxMediaShipping_PhoneExt.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMediaShipping_PhoneExt.Location = New System.Drawing.Point(332, 265)
            Me.TextBoxMediaShipping_PhoneExt.MaxFileSize = CType(0, Long)
            Me.TextBoxMediaShipping_PhoneExt.Name = "TextBoxMediaShipping_PhoneExt"
            Me.TextBoxMediaShipping_PhoneExt.SecurityEnabled = True
            Me.TextBoxMediaShipping_PhoneExt.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMediaShipping_PhoneExt.Size = New System.Drawing.Size(61, 21)
            Me.TextBoxMediaShipping_PhoneExt.StartingFolderName = Nothing
            Me.TextBoxMediaShipping_PhoneExt.TabIndex = 4
            Me.TextBoxMediaShipping_PhoneExt.TabOnEnter = True
            '
            'LabelMediaShipping_PhoneExt
            '
            Me.LabelMediaShipping_PhoneExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelMediaShipping_PhoneExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaShipping_PhoneExt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaShipping_PhoneExt.Location = New System.Drawing.Point(302, 265)
            Me.LabelMediaShipping_PhoneExt.Name = "LabelMediaShipping_PhoneExt"
            Me.LabelMediaShipping_PhoneExt.Size = New System.Drawing.Size(24, 20)
            Me.LabelMediaShipping_PhoneExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaShipping_PhoneExt.TabIndex = 3
            Me.LabelMediaShipping_PhoneExt.Text = "Ext:"
            '
            'LabelMediaShipping_Phone
            '
            Me.LabelMediaShipping_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaShipping_Phone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaShipping_Phone.Location = New System.Drawing.Point(5, 265)
            Me.LabelMediaShipping_Phone.Name = "LabelMediaShipping_Phone"
            Me.LabelMediaShipping_Phone.Size = New System.Drawing.Size(40, 20)
            Me.LabelMediaShipping_Phone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaShipping_Phone.TabIndex = 1
            Me.LabelMediaShipping_Phone.Text = "Phone:"
            '
            'TextBoxMediaShipping_Phone
            '
            Me.TextBoxMediaShipping_Phone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMediaShipping_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMediaShipping_Phone.Border.Class = "TextBoxBorder"
            Me.TextBoxMediaShipping_Phone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMediaShipping_Phone.CheckSpellingOnValidate = False
            Me.TextBoxMediaShipping_Phone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMediaShipping_Phone.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMediaShipping_Phone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxMediaShipping_Phone.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMediaShipping_Phone.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMediaShipping_Phone.FocusHighlightEnabled = True
            Me.TextBoxMediaShipping_Phone.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMediaShipping_Phone.Location = New System.Drawing.Point(51, 265)
            Me.TextBoxMediaShipping_Phone.MaxFileSize = CType(0, Long)
            Me.TextBoxMediaShipping_Phone.Name = "TextBoxMediaShipping_Phone"
            Me.TextBoxMediaShipping_Phone.SecurityEnabled = True
            Me.TextBoxMediaShipping_Phone.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMediaShipping_Phone.Size = New System.Drawing.Size(245, 21)
            Me.TextBoxMediaShipping_Phone.StartingFolderName = Nothing
            Me.TextBoxMediaShipping_Phone.TabIndex = 2
            Me.TextBoxMediaShipping_Phone.TabOnEnter = True
            '
            'Address3LineControlMediaDelivery_MediaShippingAddress
            '
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.Address = Nothing
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.Address2 = Nothing
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.Address3 = Nothing
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.City = Nothing
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.Country = Nothing
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.County = Nothing
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.DisableCountry = False
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.DisableCounty = False
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.Location = New System.Drawing.Point(5, 52)
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.Name = "Address3LineControlMediaDelivery_MediaShippingAddress"
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.ReadOnly = False
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.ShowCountry = True
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.ShowCounty = True
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.Size = New System.Drawing.Size(388, 207)
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.State = Nothing
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.TabIndex = 0
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.Title = "Address"
            Me.Address3LineControlMediaDelivery_MediaShippingAddress.Zip = Nothing
            '
            'TabItemVendorDetails_MediaDeliveryTab
            '
            Me.TabItemVendorDetails_MediaDeliveryTab.AttachedControl = Me.TabControlPanelMediaDeliveryTab_MediaDelivery
            Me.TabItemVendorDetails_MediaDeliveryTab.Name = "TabItemVendorDetails_MediaDeliveryTab"
            Me.TabItemVendorDetails_MediaDeliveryTab.Text = "Media Delivery"
            '
            'TabControlPanelDocumentsTab_Documents
            '
            Me.TabControlPanelDocumentsTab_Documents.Controls.Add(Me.DocumentManagerControlDocuments_VendorDocuments)
            Me.TabControlPanelDocumentsTab_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDocumentsTab_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDocumentsTab_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDocumentsTab_Documents.Name = "TabControlPanelDocumentsTab_Documents"
            Me.TabControlPanelDocumentsTab_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDocumentsTab_Documents.Size = New System.Drawing.Size(815, 513)
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDocumentsTab_Documents.Style.GradientAngle = 90
            Me.TabControlPanelDocumentsTab_Documents.TabIndex = 11
            Me.TabControlPanelDocumentsTab_Documents.TabItem = Me.TabItemVendorDetails_DocumentsTab
            '
            'DocumentManagerControlDocuments_VendorDocuments
            '
            Me.DocumentManagerControlDocuments_VendorDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlDocuments_VendorDocuments.Location = New System.Drawing.Point(6, 6)
            Me.DocumentManagerControlDocuments_VendorDocuments.Name = "DocumentManagerControlDocuments_VendorDocuments"
            Me.DocumentManagerControlDocuments_VendorDocuments.Size = New System.Drawing.Size(803, 501)
            Me.DocumentManagerControlDocuments_VendorDocuments.TabIndex = 0
            '
            'TabItemVendorDetails_DocumentsTab
            '
            Me.TabItemVendorDetails_DocumentsTab.AttachedControl = Me.TabControlPanelDocumentsTab_Documents
            Me.TabItemVendorDetails_DocumentsTab.Name = "TabItemVendorDetails_DocumentsTab"
            Me.TabItemVendorDetails_DocumentsTab.Text = "Documents"
            '
            'TabControlPanelMediaSpecsTab_MediaSpecs
            '
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.Controls.Add(Me.SearchableComboBoxMediaSpecs_DefaultSize)
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.Controls.Add(Me.TreeListControlMediaSpecs_MediaSpecs)
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.Controls.Add(Me.LabelMediaSpecs_DefaultSize)
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.Name = "TabControlPanelMediaSpecsTab_MediaSpecs"
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.Size = New System.Drawing.Size(815, 513)
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.Style.GradientAngle = 90
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.TabIndex = 8
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.TabItem = Me.TabItemVendorDetails_MediaSpecsTab
            '
            'SearchableComboBoxMediaSpecs_DefaultSize
            '
            Me.SearchableComboBoxMediaSpecs_DefaultSize.ActiveFilterString = ""
            Me.SearchableComboBoxMediaSpecs_DefaultSize.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxMediaSpecs_DefaultSize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxMediaSpecs_DefaultSize.AutoFillMode = False
            Me.SearchableComboBoxMediaSpecs_DefaultSize.BookmarkingEnabled = False
            Me.SearchableComboBoxMediaSpecs_DefaultSize.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.AdSize
            Me.SearchableComboBoxMediaSpecs_DefaultSize.DataSource = Nothing
            Me.SearchableComboBoxMediaSpecs_DefaultSize.DisableMouseWheel = False
            Me.SearchableComboBoxMediaSpecs_DefaultSize.DisplayName = ""
            Me.SearchableComboBoxMediaSpecs_DefaultSize.EnterMoveNextControl = True
            Me.SearchableComboBoxMediaSpecs_DefaultSize.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxMediaSpecs_DefaultSize.Location = New System.Drawing.Point(81, 4)
            Me.SearchableComboBoxMediaSpecs_DefaultSize.Name = "SearchableComboBoxMediaSpecs_DefaultSize"
            Me.SearchableComboBoxMediaSpecs_DefaultSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxMediaSpecs_DefaultSize.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxMediaSpecs_DefaultSize.Properties.NullText = "Select Ad Size"
            Me.SearchableComboBoxMediaSpecs_DefaultSize.Properties.PopupView = Me.GridView10
            Me.SearchableComboBoxMediaSpecs_DefaultSize.Properties.ValueMember = "Code"
            Me.SearchableComboBoxMediaSpecs_DefaultSize.SecurityEnabled = True
            Me.SearchableComboBoxMediaSpecs_DefaultSize.SelectedValue = Nothing
            Me.SearchableComboBoxMediaSpecs_DefaultSize.Size = New System.Drawing.Size(729, 20)
            Me.SearchableComboBoxMediaSpecs_DefaultSize.TabIndex = 3
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
            'TreeListControlMediaSpecs_MediaSpecs
            '
            Me.TreeListControlMediaSpecs_MediaSpecs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TreeListControlMediaSpecs_MediaSpecs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TreeListControl.Type.Editable
            Me.TreeListControlMediaSpecs_MediaSpecs.Location = New System.Drawing.Point(7, 30)
            Me.TreeListControlMediaSpecs_MediaSpecs.Name = "TreeListControlMediaSpecs_MediaSpecs"
            Me.TreeListControlMediaSpecs_MediaSpecs.Size = New System.Drawing.Size(803, 479)
            Me.TreeListControlMediaSpecs_MediaSpecs.TabIndex = 2
            '
            'LabelMediaSpecs_DefaultSize
            '
            Me.LabelMediaSpecs_DefaultSize.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaSpecs_DefaultSize.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelMediaSpecs_DefaultSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaSpecs_DefaultSize.Location = New System.Drawing.Point(4, 4)
            Me.LabelMediaSpecs_DefaultSize.Name = "LabelMediaSpecs_DefaultSize"
            Me.LabelMediaSpecs_DefaultSize.Size = New System.Drawing.Size(71, 20)
            Me.LabelMediaSpecs_DefaultSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaSpecs_DefaultSize.TabIndex = 0
            Me.LabelMediaSpecs_DefaultSize.Text = "Default Size:"
            '
            'TabItemVendorDetails_MediaSpecsTab
            '
            Me.TabItemVendorDetails_MediaSpecsTab.AttachedControl = Me.TabControlPanelMediaSpecsTab_MediaSpecs
            Me.TabItemVendorDetails_MediaSpecsTab.Name = "TabItemVendorDetails_MediaSpecsTab"
            Me.TabItemVendorDetails_MediaSpecsTab.Text = "Media Specs"
            '
            'TabControlPanelPricingsTab_Pricings
            '
            Me.TabControlPanelPricingsTab_Pricings.Controls.Add(Me.VendorPricingControlPricings_VendorPricings)
            Me.TabControlPanelPricingsTab_Pricings.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelPricingsTab_Pricings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelPricingsTab_Pricings.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelPricingsTab_Pricings.Name = "TabControlPanelPricingsTab_Pricings"
            Me.TabControlPanelPricingsTab_Pricings.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelPricingsTab_Pricings.Size = New System.Drawing.Size(815, 513)
            Me.TabControlPanelPricingsTab_Pricings.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelPricingsTab_Pricings.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelPricingsTab_Pricings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelPricingsTab_Pricings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelPricingsTab_Pricings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelPricingsTab_Pricings.Style.GradientAngle = 90
            Me.TabControlPanelPricingsTab_Pricings.TabIndex = 10
            Me.TabControlPanelPricingsTab_Pricings.TabItem = Me.TabItemVendorDetails_PricingsTab
            '
            'VendorPricingControlPricings_VendorPricings
            '
            Me.VendorPricingControlPricings_VendorPricings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VendorPricingControlPricings_VendorPricings.Location = New System.Drawing.Point(6, 6)
            Me.VendorPricingControlPricings_VendorPricings.Name = "VendorPricingControlPricings_VendorPricings"
            Me.VendorPricingControlPricings_VendorPricings.Size = New System.Drawing.Size(803, 501)
            Me.VendorPricingControlPricings_VendorPricings.TabIndex = 0
            '
            'TabItemVendorDetails_PricingsTab
            '
            Me.TabItemVendorDetails_PricingsTab.AttachedControl = Me.TabControlPanelPricingsTab_Pricings
            Me.TabItemVendorDetails_PricingsTab.Name = "TabItemVendorDetails_PricingsTab"
            Me.TabItemVendorDetails_PricingsTab.Text = "Pricings"
            '
            'LabelDefaultNotes_ACHType
            '
            Me.LabelDefaultNotes_ACHType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaultNotes_ACHType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaultNotes_ACHType.Location = New System.Drawing.Point(6, 130)
            Me.LabelDefaultNotes_ACHType.Name = "LabelDefaultNotes_ACHType"
            Me.LabelDefaultNotes_ACHType.Size = New System.Drawing.Size(91, 20)
            Me.LabelDefaultNotes_ACHType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaultNotes_ACHType.TabIndex = 7
            Me.LabelDefaultNotes_ACHType.Text = "ACH Type:"
            '
            'LabelMain_QuickbooksVendor
            '
            Me.LabelMain_QuickbooksVendor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMain_QuickbooksVendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMain_QuickbooksVendor.Location = New System.Drawing.Point(197, 4)
            Me.LabelMain_QuickbooksVendor.Name = "LabelMain_QuickbooksVendor"
            Me.LabelMain_QuickbooksVendor.Size = New System.Drawing.Size(107, 20)
            Me.LabelMain_QuickbooksVendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMain_QuickbooksVendor.TabIndex = 35
            Me.LabelMain_QuickbooksVendor.Text = "QuickBooks Vendor:"
            '
            'SearchableComboBoxMain_QuickBooksVendor
            '
            Me.SearchableComboBoxMain_QuickBooksVendor.ActiveFilterString = ""
            Me.SearchableComboBoxMain_QuickBooksVendor.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxMain_QuickBooksVendor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxMain_QuickBooksVendor.AutoFillMode = False
            Me.SearchableComboBoxMain_QuickBooksVendor.BookmarkingEnabled = False
            Me.SearchableComboBoxMain_QuickBooksVendor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.QuickbookCustomer
            Me.SearchableComboBoxMain_QuickBooksVendor.DataSource = Nothing
            Me.SearchableComboBoxMain_QuickBooksVendor.DisableMouseWheel = False
            Me.SearchableComboBoxMain_QuickBooksVendor.DisplayName = ""
            Me.SearchableComboBoxMain_QuickBooksVendor.EnterMoveNextControl = True
            Me.SearchableComboBoxMain_QuickBooksVendor.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxMain_QuickBooksVendor.Location = New System.Drawing.Point(310, 4)
            Me.SearchableComboBoxMain_QuickBooksVendor.Name = "SearchableComboBoxMain_QuickBooksVendor"
            Me.SearchableComboBoxMain_QuickBooksVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxMain_QuickBooksVendor.Properties.DisplayMember = "DisplayName"
            Me.SearchableComboBoxMain_QuickBooksVendor.Properties.NullText = "Select Customer"
            Me.SearchableComboBoxMain_QuickBooksVendor.Properties.PopupView = Me.GridView17
            Me.SearchableComboBoxMain_QuickBooksVendor.Properties.ValueMember = "ID"
            Me.SearchableComboBoxMain_QuickBooksVendor.SecurityEnabled = True
            Me.SearchableComboBoxMain_QuickBooksVendor.SelectedValue = Nothing
            Me.SearchableComboBoxMain_QuickBooksVendor.Size = New System.Drawing.Size(497, 20)
            Me.SearchableComboBoxMain_QuickBooksVendor.TabIndex = 34
            '
            'GridView17
            '
            Me.GridView17.AFActiveFilterString = ""
            Me.GridView17.AllowExtraItemsInGridLookupEdits = True
            Me.GridView17.AutoFilterLookupColumns = False
            Me.GridView17.AutoloadRepositoryDatasource = True
            Me.GridView17.DataSourceClearing = False
            Me.GridView17.EnableDisabledRows = False
            Me.GridView17.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView17.Name = "GridView17"
            Me.GridView17.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView17.OptionsView.ShowGroupPanel = False
            Me.GridView17.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView17.RunStandardValidation = True
            Me.GridView17.SkipAddingControlsOnModifyColumn = False
            Me.GridView17.SkipSettingFontOnModifyColumn = False
            '
            'VendorControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoScroll = True
            Me.Controls.Add(Me.TabControlControl_VendorDetails)
            Me.Name = "VendorControl"
            Me.Size = New System.Drawing.Size(815, 540)
            CType(Me.TabControlControl_VendorDetails, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlControl_VendorDetails.ResumeLayout(False)
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.ResumeLayout(False)
            CType(Me.TabControlMediaDefaults_MediaDefaultsTab, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlMediaDefaults_MediaDefaultsTab.ResumeLayout(False)
            Me.TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation.ResumeLayout(False)
            Me.TableLayoutPanelGeneralDefaultInformation_TableLayout.ResumeLayout(False)
            Me.PanelTableLayout_RightColumn.ResumeLayout(False)
            Me.PanelRates_Rates.ResumeLayout(False)
            Me.PanelUnits_Units.ResumeLayout(False)
            CType(Me.NumericInputDeadlines_SpaceCloseDays.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDeadlines_MaterialCloseDays.Properties, System.ComponentModel.ISupportInitialize).EndInit
            Me.PanelTableLayout_LeftColumn.ResumeLayout(False)
            CType(Me.SearchableComboBoxGeneralDefaultInformation_ComscoreStation.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView14, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView15, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxGeneralDefaultInformation_CableSyscode.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView13, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxGeneralDefaultInformation_RadioStation.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView12, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxGeneralDefaultInformation_TVStation.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView11, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputGeneralDefaultInformation_MarkupPercent.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxGeneralDefaultInformation_TaxCode.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView9, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxGeneralDefaultInformation_Market.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputGeneralDefaultInformation_ColumnWidth.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputGeneralDefaultInformation_OveragePercent.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputGeneralDefaultInformation_CommissionPercent.Properties, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlPanelDefaultCommentsTab_DefaultComments.ResumeLayout(False)
            Me.TabControlPanelContactsTab_Contacts.ResumeLayout(False)
            Me.TabControlPanelRepresentativesTab_Representatives.ResumeLayout(False)
            Me.TabControlPanelMainTab_Main.ResumeLayout(False)
            Me.TableLayoutPanelMain_TableLayout.ResumeLayout(False)
            Me.PanelTableLayout_RightSection.ResumeLayout(False)
            CType(Me.GroupBoxMain_PayToNameAndAddress, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxMain_PayToNameAndAddress.ResumeLayout(False)
            Me.PanelTableLayout_LeftSection.ResumeLayout(False)
            CType(Me.GroupBoxMain_NameAndAddress, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxMain_NameAndAddress.ResumeLayout(False)
            Me.TabControlPanelEEOC2Tab_EEOC2.ResumeLayout(False)
            CType(Me.GroupBoxEEOC2_WomensBusinessDetails, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxEEOC2_WomensBusinessDetails.ResumeLayout(False)
            CType(Me.DateTimePickerWBD_WBENCCertificationExpirationDate, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxEEOC2_MinorityOwnedBusinessDetails.ResumeLayout(False)
            CType(Me.DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxMOBD_Ethnicity.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView16, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlPanelEEOCStatusTab_EEOCStatus.ResumeLayout(False)
            CType(Me.PanelControl_RightSection, System.ComponentModel.ISupportInitialize).EndInit
            Me.PanelControl_RightSection.ResumeLayout(False)
            CType(Me.PanelControl_LeftSection, System.ComponentModel.ISupportInitialize).EndInit
            Me.PanelControl_LeftSection.ResumeLayout(False)
            Me.TabControlPanelLineDefaultsNotesTab_DefaultsNotes.ResumeLayout(False)
            Me.TableLayoutPanelDefaultsNotes_TableLayout.ResumeLayout(False)
            Me.PanelRightColumn_DefaultsNotes.ResumeLayout(False)
            CType(Me.NumericInputDefaultNotes_VCCLimit.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxDefaultNotes_Terms.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxDefaultNotes_DefaultBank.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxDefaultNotes_DefaultFunction.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit
            Me.PanelLeftColumn_DefaultsNotes.ResumeLayout(False)
            CType(Me.SearchableComboBoxDefaultNotes_Office.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxDefaultNotes_Currency.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxDefaultNotes_DefaultExpenseAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxDefaultNotes_DefaultAPAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxViewDefaultNotes_DefaultAPAccount, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlPanelContractsTab_Contracts.ResumeLayout(False)
            Me.TabControlPanelVendorServiceTaxTab_VendorServiceTax.ResumeLayout(False)
            CType(Me.NumericInputServiceTax_Rate.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.DateTimePickerServiceTax_WaiverExpirationDate, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxServiceTax_Type.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxServiceTax_Code.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlPanel1099InfoTab_1099Info.ResumeLayout(False)
            Me.TableLayoutPanel1099Info_TableLayout.ResumeLayout(False)
            Me.Panel1099Info_RightColumn.ResumeLayout(False)
            Me.Panel1099Info_LeftColumn.ResumeLayout(False)
            Me.TabControlPanelMediaInfoTab_MediaInfo.ResumeLayout(False)
            Me.PanelMediaInfo_Magazine.ResumeLayout(False)
            CType(Me.NumericInputMagazine_Issues.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputMagazine_Circulation.Properties, System.ComponentModel.ISupportInitialize).EndInit
            Me.PanelMediaInfo_Newspaper.ResumeLayout(False)
            CType(Me.NumericInputNewspaper_DailyCirculation.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputNewspaper_SundayCirculation.Properties, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlPanelMediaDeliveryTab_MediaDelivery.ResumeLayout(False)
            Me.TableLayoutPanelMediaDelivery_TableLayout.ResumeLayout(False)
            Me.PanelMediaDelivery_RightColumn.ResumeLayout(False)
            Me.PanelMediaDelivery_LeftColumn.ResumeLayout(False)
            CType(Me.GroupBoxMediaDelivery_MediaShipping, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxMediaDelivery_MediaShipping.ResumeLayout(False)
            Me.TabControlPanelDocumentsTab_Documents.ResumeLayout(False)
            Me.TabControlPanelMediaSpecsTab_MediaSpecs.ResumeLayout(False)
            CType(Me.SearchableComboBoxMediaSpecs_DefaultSize.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView10, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.TreeListControlMediaSpecs_MediaSpecs, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlPanelPricingsTab_Pricings.ResumeLayout(False)
            CType(Me.SearchableComboBoxMain_QuickBooksVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView17, System.ComponentModel.ISupportInitialize).EndInit
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlControl_VendorDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabItemVendorDetails_MainTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelLineDefaultsNotesTab_DefaultsNotes As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVendorDetails_DefaultsNotesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanel1099InfoTab_1099Info As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVendorDetails_1099InfoTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelRepresentativesTab_Representatives As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVendorDetails_RepresentativesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMediaDefaultsTab_MediaDefaults As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVendorDetails_MediaDefaultsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMediaInfoTab_MediaInfo As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVendorDetails_MediaInfoTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMediaDeliveryTab_MediaDelivery As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVendorDetails_MediaDeliveryTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMediaSpecsTab_MediaSpecs As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVendorDetails_MediaSpecsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelContactsTab_Contacts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVendorDetails_ContactsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewContacts_Contacts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TextBoxContacts_DefaultVendorContactCode As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxMain_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelMain_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TableLayoutPanelMain_TableLayout As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelTableLayout_RightSection As System.Windows.Forms.Panel
        Friend WithEvents PanelTableLayout_LeftSection As System.Windows.Forms.Panel
        Friend WithEvents CheckBoxMain_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxMain_FederalTaxID As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelMain_FederalTaxID As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxMain_Website As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxMain_Email As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxMain_PaymentManagerEmail As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelMain_PaymentManagerEmail As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMain_Email As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMain_Website As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxMain_DefaultCategory As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelMain_DefaultCategory As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultNotes_SortOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultNotes_DefaultBank As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxDefaultNotes_ACHType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxDefaultNotes_ACH As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxDefaultNotes_EmployeeVendor As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxDefaultNotes_OneCheckPerInvoice As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelDefaultNotes_Terms As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultNotes_DefaultFunction As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultNotes_SortName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultNotes_VendorAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultNotes_DefaultExpenseAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultNotes_DefaultAPAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultNotes_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultNotes_Currency As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonOptions_SortActions As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonItemSortActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemSortActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewRepresentatives_VendorReps As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TableLayoutPanel1099Info_TableLayout As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents Panel1099Info_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents RadioButtonControl1099Info_GrossProceedsToAttorney As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControl1099Info_Royalties As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControl1099Info_Rent As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControl1099Info_OtherIncome As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControl1099Info_NonEmployeeCompensation As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents Label1099Info_Category As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents Panel1099Info_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents CheckBox1099Info_Use1099Address As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents Label1099Info_AlternateAddressFor1099 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBox1099Info_Is1099Vendor As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxRepresentatives_DefaultRep2 As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxRepresentatives_DefaultRep1 As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelDefaultNotes_Notes As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxDefaultNotes_Notes As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabControlPanelEEOCStatusTab_EEOCStatus As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVendorDetails_EEOCStatusTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelControl_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_RemoveEEOCStatus As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddEEOCStatus As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_SelectedEEOCStatuses As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControl_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelControl_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableEEOCStatuses As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TableLayoutPanelDefaultsNotes_TableLayout As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelRightColumn_DefaultsNotes As System.Windows.Forms.Panel
        Friend WithEvents PanelLeftColumn_DefaultsNotes As System.Windows.Forms.Panel
        Friend WithEvents TextBoxDefaultNotes_SortName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ComboBoxDefaultNotes_SortOptions As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TextBoxDefaultNotes_VendorAccount As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents GroupBoxMain_PayToNameAndAddress As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents ButtonPayToNameAndAddress_Refresh As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonItemRefresh_Vendor As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TextBoxPayToNameAndAddress_FaxExt As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelPayToNameAndAddress_Vendor As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxPayToNameAndAddress_PhoneExt As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelPayToNameAndAddress_FaxExt As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxPayToNameAndAddress_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelPayToNameAndAddress_PhoneExt As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPayToNameAndAddress_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxPayToNameAndAddress_Fax As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents Address3LineControlPayToNameAndAddress_PayToAddress As AdvantageFramework.WinForm.Presentation.Controls.Address3LineControl
        Friend WithEvents LabelPayToNameAndAddress_Fax As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPayToNameAndAddress_Phone As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxPayToNameAndAddress_Phone As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents GroupBoxMain_NameAndAddress As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelLeftSection_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxNameAndAddress_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents Address3LineControlNameAndAddress_Address As AdvantageFramework.WinForm.Presentation.Controls.Address3LineControl
        Friend WithEvents LabelNameAndAddress_Phone As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxNameAndAddress_Phone As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelNameAndAddress_Fax As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxNameAndAddress_Fax As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelNameAndAddress_PhoneExt As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelNameAndAddress_FaxExt As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxNameAndAddress_FaxExt As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxNameAndAddress_PhoneExt As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelMediaDelivery_GeneralInfo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents Address3LineControlMediaDelivery_MediaShippingAddress As AdvantageFramework.WinForm.Presentation.Controls.Address3LineControl
        Friend WithEvents TextBoxMediaDelivery_FTPDirectory As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxMediaDelivery_FTPPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxMediaDelivery_FTPUserName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxMediaDelivery_PreferredMaterial As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxMediaDelivery_EFileInfo As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxMediaDelivery_AcceptedMedia As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxMediaDelivery_GeneralInfo As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelMediaDelivery_FTPDirectory As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaDelivery_FTPPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaDelivery_FTPUserName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaDelivery_PreferredMaterial As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaDelivery_EFileInfo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaDelivery_AcceptedMedia As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaDelivery_ As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaSpecs_DefaultSize As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlMediaDefaults_MediaDefaultsTab As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelDefaultCommentsTab_DefaultComments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CheckBoxDefaultComments_UseFooterComment As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxDefaultComments_Instructions As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxDefaultComments_FooterComment As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxDefaultComments_RateInfo As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxDefaultComments_MaterialNotes As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxDefaultComments_PositionInfo As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxDefaultComments_MiscInfo As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxDefaultComments_CloseInfo As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelDefaultComments_FooterComment As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultComments_RateInfo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultComments_MaterialNotes As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultComments_PositionInfo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultComments_MiscInfo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultComments_CloseInfo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultComments_Instructions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemMediaDefaults_DefaultCommentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelGeneralDefaultInformationTab_GeneralDefaultInformation As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemMediaDefaults_GeneralDefaultInformationTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelGeneralDefaultInformation_ColumnWidth As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralDefaultInformation_OveragePercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralDefaultInformation_CommissionPercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralDefaultInformation_Market As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TableLayoutPanelGeneralDefaultInformation_TableLayout As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelTableLayout_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents RadioButtonControlRates_Gross As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlRates_Net As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelDeadlines_MaterialCloseDays As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDeadlines_SpaceCloseDays As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputDeadlines_SpaceCloseDays As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDeadlines_MaterialCloseDays As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelGeneralDefaultInformation_Rates As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralDefaultInformation_Deadlines As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonControlUnits_Daily As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlUnits_WeeklyOrCalendarMonth As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlUnits_MontlyOrBroadcastMonth As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelGeneralDefaultInformation_Units As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralDefaultInformation_ApplyTo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelTableLayout_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents TextBoxGeneralDefaultInformation_VendorCodeCrossReference As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelMediaDefaults_CrossReference As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxApplyTo_NetDiscount As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplyTo_AddlCharge As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelGeneralDefaultInformation_TaxCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxApplyTo_Rebate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplyTo_NetCharge As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplyTo_Commission As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxApplyTo_LineNet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputGeneralDefaultInformation_ColumnWidth As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxApplyTo_UseFlags As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputGeneralDefaultInformation_OveragePercent As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputGeneralDefaultInformation_CommissionPercent As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents PanelUnits_Units As System.Windows.Forms.Panel
        Friend WithEvents PanelRates_Rates As System.Windows.Forms.Panel
        Friend WithEvents PanelMediaInfo_Newspaper As System.Windows.Forms.Panel
        Friend WithEvents NumericInputNewspaper_DailyCirculation As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputNewspaper_SundayCirculation As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents TextBoxNewspaper_Editions As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelNewspaper_Editions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxNewspaper_PublishingFrequency As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelNewspaper_PublishingFrequency As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelNewspaper_DailyCirculation As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMagazine_SundayCirculation As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelMediaInfo_Magazine As System.Windows.Forms.Panel
        Friend WithEvents NumericInputMagazine_Issues As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputMagazine_Circulation As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents TextBoxMagazine_Cycles As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxMagazine_Editions As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelMagazine_Editions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxMagazine_PublishingFrequency As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelMagazine_PublishingFrequency As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMagazine_Issues As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMagazine_Cycles As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelNewspaper_Circulation As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TreeListControlMediaSpecs_MediaSpecs As AdvantageFramework.WinForm.Presentation.Controls.TreeListControl
        Friend WithEvents ButtonDefaultComments_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonMediaDelivery_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TableLayoutPanelMediaDelivery_TableLayout As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelMediaDelivery_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelMediaDelivery_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents GroupBoxMediaDelivery_MediaShipping As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxMediaShipping_PhoneExt As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelMediaShipping_PhoneExt As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaShipping_Phone As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxMediaShipping_Phone As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPayToNameAndAddress_Vendor As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabControlPanelPricingsTab_Pricings As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVendorDetails_PricingsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents VendorPricingControlPricings_VendorPricings As AdvantageFramework.WinForm.Presentation.Controls.VendorPricingControl
        Friend WithEvents Address3LineControl1099Info_Address As AdvantageFramework.WinForm.Presentation.Controls.Address3LineControl
        Private WithEvents TabControlPanelMainTab_Main As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabControlPanelDocumentsTab_Documents As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DocumentManagerControlDocuments_VendorDocuments As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents TabItemVendorDetails_DocumentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelDefaultNotes_VCCStatus As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefaultNotes_ACHType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxDefaultNotes_VCCStatus As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxMain_Television As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMain_Radio As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMain_OutOfHome As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMain_Newspaper As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMain_Magazine As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMain_Internet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelMain_MediaCategoriesAllowed As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxDefaultNotes_DefaultExpenseAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewDefaultNotes_DefaultExpenseAccount As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxDefaultNotes_DefaultAPAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewDefaultNotes_DefaultAPAccount As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents CheckBoxDefaultNotes_SpecialTerms As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlPanelVendorServiceTaxTab_VendorServiceTax As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVendorDetails_VendorServiceTaxTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents SearchableComboBoxServiceTax_Code As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelServiceTax_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelServiceTax_WaiverExpirationDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelServiceTax_TaxRate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelServiceTax_TaxType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxServiceTax_Type As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents DateTimePickerServiceTax_WaiverExpirationDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents NumericInputServiceTax_Rate As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxServiceTax_Waiver As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxServiceTax_Enabled As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxMediaDelivery_DefaultCorrespondenceMethod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelMediaDelivery_DefaultCorrespondenceMethod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxDefaultNotes_Currency As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView3 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxDefaultNotes_Office As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView4 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxDefaultNotes_DefaultFunction As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView5 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxDefaultNotes_DefaultBank As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView6 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxDefaultNotes_Terms As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView7 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGeneralDefaultInformation_Market As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView8 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGeneralDefaultInformation_TaxCode As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView9 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxMediaSpecs_DefaultSize As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView10 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents NumericInputDefaultNotes_VCCLimit As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelDefaultNotes_VCCLimit As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxDefaultNotes_SendVCCWithMediaOrder As CheckBox
        Friend WithEvents RadioButtonControl1099Info_MedicalHealthcare As RadioButtonControl
        Friend WithEvents TabControlPanelContractsTab_Contracts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVendorDetails_ContractsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents VendorContractManagerControlContracts_Contracts As VendorContractManagerControl
        Friend WithEvents LabelGeneralDefaultInformation_MarkupPercent As Label
        Friend WithEvents NumericInputGeneralDefaultInformation_MarkupPercent As NumericInput
        Friend WithEvents ComboBoxDefaultNotes_InvoiceCategory As ComboBox
        Friend WithEvents LabelDefaultNotes_InvoiceCategory As Label
        Friend WithEvents SearchableComboBoxGeneralDefaultInformation_RadioStation As SearchableComboBox
        Friend WithEvents GridView12 As GridView
        Friend WithEvents SearchableComboBoxGeneralDefaultInformation_TVStation As SearchableComboBox
        Friend WithEvents GridView11 As GridView
        Friend WithEvents LabelGeneralDefaultInformation_Station As Label
        Friend WithEvents CheckBoxGeneralDefaultInformation_IsCableSystem As CheckBox
        Friend WithEvents LabelGeneralDefaultInformation_IsCableSystem As Label
        Friend WithEvents SearchableComboBoxGeneralDefaultInformation_CableSyscode As SearchableComboBox
        Friend WithEvents GridView13 As GridView
        Friend WithEvents LabelGeneralDefaultInformation_CableSyscode As Label
        Friend WithEvents LabelMediaShipping_Name As Label
        Friend WithEvents TextBoxMediaShipping_Name As TextBox
        Friend WithEvents LabelGeneralDefaultInformation_EastlanStation As Label
        Friend WithEvents SearchableComboBoxGeneralDefaultInformation_EastlanRadioStation As SearchableComboBox
        Friend WithEvents GridView15 As GridView
        Friend WithEvents SearchableComboBoxGeneralDefaultInformation_ComscoreStation As SearchableComboBox
        Friend WithEvents GridView14 As GridView
        Friend WithEvents LabelGeneralDefaultInformation_ComscoreStation As Label
        Friend WithEvents CheckBoxIsComscoreSubscriber As CheckBox
        Friend WithEvents CheckBoxIsNielsenSubscriber As CheckBox
        Friend WithEvents LabelRatingsSubscriber As Label
        Friend WithEvents LabelMain_VATNumber As Label
        Friend WithEvents TextBoxMain_VATNumber As TextBox
        Friend WithEvents TextBoxGeneralDefaultInformation_CallLetters As TextBox
        Friend WithEvents LabelGeneralDefaultInformation_CallLetters As Label
        Friend WithEvents ComboBoxGeneralDefaultInformation_Band As ComboBox
        Friend WithEvents LabelGeneralDefaultInformation_Band As Label
        Friend WithEvents LabelMediaDefaults_Financial As Label
        Friend WithEvents TabControlPanelEEOC2Tab_EEOC2 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVendorDetails_EEOC2Tab As DevComponents.DotNetBar.TabItem
        Friend WithEvents GroupBoxEEOC2_MinorityOwnedBusinessDetails As GroupBox
        Friend WithEvents LabelMOBD_Ethnicity As Label
        Friend WithEvents LabelMOBD_MinorityCertifcateNumber As Label
        Friend WithEvents TextBoxMOBD_MinorityCertifcateNumber As TextBox
        Friend WithEvents SearchableComboBoxMOBD_Ethnicity As SearchableComboBox
        Friend WithEvents GridView16 As GridView
        Friend WithEvents LabelMOBD_MinorityCertifcateNumberExpirationDate As Label
        Friend WithEvents DateTimePickerMOBD_MinorityCertifcateNumberExpirationDate As DateTimePicker
        Friend WithEvents GroupBoxEEOC2_WomensBusinessDetails As GroupBox
        Friend WithEvents DateTimePickerWBD_WBENCCertificationExpirationDate As DateTimePicker
        Friend WithEvents CheckBoxWBD_IsWBENC As CheckBox
        Friend WithEvents LabelWBD_WBENCCertificationExpirationDate As Label
        Friend WithEvents LabelWBD_WBENCCertificationNumber As Label
        Friend WithEvents LabelWBD_WomensBusinessEnterpriseNationalCouncil As Label
        Friend WithEvents TextBoxWBD_WBENCCertificationNumber As TextBox
        Friend WithEvents LabelMOBD_NationalMinoritySupplierDevelopmentCouncil As Label
        Friend WithEvents CheckBoxMODB_IsNMSDC As CheckBox
        Friend WithEvents ComboBoxGeneralDefaultInformation_CanadianVendorType As ComboBox
        Friend WithEvents LabelGeneralDefaultInformation_CanadianVendorType As Label
        Friend WithEvents LabelMain_QuickbooksVendor As Label
        Friend WithEvents SearchableComboBoxMain_QuickBooksVendor As SearchableComboBox
        Friend WithEvents GridView17 As GridView
    End Class

End Namespace
