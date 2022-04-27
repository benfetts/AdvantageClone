Namespace Maintenance.General.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AgencySetupForm
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgencySetupForm))
            Me.TabControlForm_AgencySetup = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelOptionsTab_Options = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxSystemAndAlertOptions_ProofingURL = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxProofingURL_URL = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.RadioButtonControlProofingURL_WorkstationOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlProofingURL_UseGlobal = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxSystemAndAlertOptions_DotNetFolder = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxDotNetFolder_Path = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.RadioButtonControlDotNetFolder_WorkstationOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlDotNetFolder_UseGlobal = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxSystemAndAlertOptions_ClientPortalURL = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxClientPortalURL_URL = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.RadioButtonControlClientPortalURL_WorkstationOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlClientPortalURL_UseGlobal = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxOptions_EmailAttachments = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputEmailAttachments_MaxFileSize = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelEmailAttachments_MaxFileSize = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxAccessReportTemporaryFolder_Path = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAccessReportTemporaryFolder_UseGlobal = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxOptions_AlertOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAlertOptions_EnableAlertNotification = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxSystemAndAlertOptions_WebvantageURL = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxWebvantageURL_URL = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.RadioButtonControlWebvantageURL_WorkstationOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlWebvantageURL_UseGlobal = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxSystemAndAlertOptions_AccessReportSourceFolder = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxAccessReportSourceFolder_Path = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.RadioButtonControlAccessReportSourceFolder_WorkstationOnly = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlAccessReportSourceFolder_UseGlobal = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemSystemAndAlertOptions_OptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelEmailSettingsTab_EmailSettings = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.NumericInputPOP3EmailListenerSettings_PortNumber = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.RadioButtonControlPOP3EmailListenerSettings_UseTLS = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlPOP3EmailListenerSettings_UseSSL = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelPOP3EmailListenerSettings_ServerAddress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPOP3EmailListenerSettings_PortNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPOP3EmailListenerSettings_AuthenticationMethod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxSMTPEmailSetup_DefaultPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSMTPEmailSetup_OAuth2 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.NumericInputSMTPEmailSetup_PortNumber = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxSMTPEmailSetup_ReplyToAddress = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxSMTPEmailSetup_DefaultUserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxSMTPEmailSetup_SenderAddress = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.RadioButtonControlSMTPEmailSetup_NoSecureProtocol = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.RadioButtonControlSMTPEmailSetup_UseTLS = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelSMTPEmailSetup_ReplyToAddress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSMTPEmailSetup_DefaultSenderPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonControlSMTPEmailSetup_UseSSL = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelSMTPEmailSetup_DefaultUserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSMTPEmailSetup_SenderAddress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSMTPEmailSetup_OutgoingServerAddress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSMTPEmailSetup_PortNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSMTPEmailSetup_AuthenticationMethod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemSystemAndAlertOptions_EmailSettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabItemAgencySetup_SystemAndAlertOptions = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelInformationTab_Information = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxInformation_AgencyInformation = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.AddressControlAgencyInformation_Address = New AdvantageFramework.WinForm.Presentation.Controls.AddressControl()
            Me.LabelAgencyInformation_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAgencyInformation_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxAgencyInformation_Phone = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelAgencyInformation_Phone = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemAgencySetup_InformationTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaOptionsTab_MediaOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlMediaOptions_MediaOptions = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelFooterCommentsTab_FooterComments = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlFooterComments_FooterComments = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelNewspaperTab_Newspaper = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxNewspaper_FooterComments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemFooterComments_NewspaperTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelInternetTab_Internet = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxInternet_FooterComments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemFooterComments_InternetTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMagazineTab_Magazine = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxMagazine_FooterComments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemFooterComments_MagazineTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelTelevisionTab_Television = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxTelevision_FooterComments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemFooterComments_TelevisionTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelRadioTab_Radio = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxRadio_FooterComments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemFooterComments_RadioTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOutOfHomeTab_OutOfHome = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxOutOfHome_FooterComments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemFooterComments_OutOfHomeTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabItemMediaOptions_FooterCommentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSettingsTab_Settings = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxMediaOptions_BroadcastWorksheet = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelMediaOrders_Country = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_MediaTrafficStartDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxMediaOrders_Country = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.RadioButtonMediaOrders_Gross = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonMediaOrders_Net = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.DateTimePickerSettings_MediaTrafficStartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelMediaOrders_BroadcastWorksheetDefaultRateType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxSettings_MediaGeneral = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxMediaGeneral_MediaAutoBuyer = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaGeneral_MediaRequireCampaign = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxSettings_MediaOrders = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxMediaOrders_UseVendorsRateType = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxSettings_MediaPlanning = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelMediaPlanning_DefaultGroupingTypeTV = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelMediaPlanning_DefaultGroupingTypeRadio = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelMediaPlanning_DefaultGroupingTypeOutOfHome = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelMediaPlanning_DefaultGroupingTypeNewspaper = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelMediaPlanning_DefaultGroupingTypeMagazine = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelMediaPlanning_DefaultGroupingType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMediaPlanning_DefaultGroupingTypeInternet = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.GroupBoxSettings_ExportMediaOrder = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxExportMediaOrders_MediaPlanPath = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxExportMediaOrders_APPath = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelExportMediaOrders_APPath = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelExportMediaOrders_MediaPlanPath = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxSettings_UseAPAccountOnImport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelSettings_MediaImportDefault = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxSettings_RenameFinanceFile = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxSettings_ImportPath = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxSettings_StrataConnectPath = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ComboBoxSettings_MediaImportDefault = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelSettings_StrataConnectPath = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_ImportPath = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemMediaOptions_SettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAdServingTab_AdServing = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelAdServing_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_AddToAdServingFields = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_RemoveFromAdServingFields = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_AdServingFields = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterAdServingFields_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelAdServing_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AvailableFields = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemMediaOptions_AdServing = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemMediaOptions_SettingsForWebFormTermsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabItemAgencySetup_MediaOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxTimesheetOptions_MissingTimeOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxMissingTimeOptions_NotifySupervisor = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonMissingTimeOptions_ByWeek = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonMissingTimeOptions_ByDay = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TextBoxMissingTimeOptions_ITEMail = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelMissingTimeOptions_ITEMail = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMissingTimeOptions_ReportMissingTime = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxTimesheetOptions_TimesheetOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxTimesheetOptions_AllowCopyHours = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTimesheetOptions_DefaultDisplayDays = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxTimesheetOptions_RequireTimeComments = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxTimesheetOptions_UseBatchMethod = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemAgencySetup_TimesheetOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabControlAccountingOptions_AccountingOptions = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelAccountsPayableTab_AccountsPayable = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView13 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView12 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView11 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxAccountingOptions_AccountsPayableHeader = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemAccountingOptions_AccountsPayableTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxAvatax_AddressOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonAddressOption_JobContactAddress = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonAddressOption_ClientAddress = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxAvaTax_UseJobSalesClass = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxAvaTax_OfficeCompanyCode = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ButtonAvaTax_TestConnection = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TextBoxAvaTax_URL = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelAvaTax_URL = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelAvaTax_AccountNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxAvaTax_AccountNumber = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxAvaTax_LicenseKey = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelAvaTax_LicenseKey = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxAvaTax_AddressValidation = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.DataGridViewAvaTaxAddressValidation_Countries = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.CheckBoxAvaTaxAddressValidation_Enabled = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemAccountingOptions_AvaTaxTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaTab_Media = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxMediaAndProduction_Media = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxMediaAndProduction_MediaApprovalAlert = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlMediaApprovalAlert_AlertAPUser = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxMediaApprovalAlert_AlertAP = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMediaApprovalAlert_AlertBuyer = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxMediaAndProduction_APMediaImportOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelAPMediaImportOptions_AlwaysSetToPendingApproval = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxMedia_APPromptsOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelAPPromptsOptions_Note = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelAPPromptsOptions_RadioMediaPercentOver = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelAPPromptsOptions_OutOfHomeMediaPercentOver = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelAPPromptsOptions_InternetMediaPercentOver = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelAPPromptsOptions_PrintMediaPercentOver = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelAPPromptsOptions_TelevisionMediaPercentOver = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxMedia_ActivateApprovals = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxMediaAndProduction_Production = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxProduction_ValidateClosedArchivedJobs = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemAccountingOptions_MediaTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelImportTab_Import = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxImportSettings_CSIClearedChecksImportPath = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelImportSettings_CSIClearedChecksImportPath = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelImportSettings_DefaultInvoiceDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxImportSettings_DefaultInvoiceDescription = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxImportSettings_CurrencyRateImportFileType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelImportSettings_IncomeOnlyImportFileType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelImportSettings_CurrencyRateImportFileType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemAccountingOptions_ImportTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCheckWritingTab_CheckWriting = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxCheckWriting_CheckFormatSettings = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.GroupBoxCheckFormatSettings_CheckCurrency = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.ComboBoxCheckCurrecny_CurrencySymbols = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelCheckCurrency_Note = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxCheckCurrency_CoinText = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxCheckCurrency_CurrencyText = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelCheckCurrency_CoinText = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCheckCurrency_CurrencyText = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCheckCurrency_Symbol = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCheckFormatSettings_APComputerCheckFormat = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelAccountingOptions_CheckWritingInProgress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemAccountingOptions_CheckWritingTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxBillingAndAccountsReceivable_InvoiceTaxing = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxBillingAndAccountsReceivable_ClientCashReceipts = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView10 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelClientCashReceipts_DefaultWriteoffAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxBillingAndAccountsReceivable_Billing = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxBilling_RequireProductSetupComplete = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxBilling_CustomInvoiceFormats = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxCustomInvoiceFormats_Internet = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView8 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView7 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView6 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView5 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxCustomInvoiceFormats_Radio = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView4 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxCustomInvoiceFormats_Television = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView3 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxCustomInvoiceFormats_Production = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelCustomInvoiceFormats_Internet = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCustomInvoiceFormats_OutOfHome = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCustomInvoiceFormats_Magazine = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCustomInvoiceFormats_Newspaper = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCustomInvoiceFormats_Radio = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCustomInvoiceFormats_Television = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCustomInvoiceFormats_Production = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemAccountingOptions_BillingAndAccountsReceivableTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelGLTab_GL = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxGL_UseFilter = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemAccountingOptions_GLTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCurrencyTab_Currency = New DevComponents.DotNetBar.TabControlPanel()
            Me.ButtonCurrency_TestConnection = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.PictureEditCurrency_Image = New DevExpress.XtraEditors.PictureEdit()
            Me.TextBoxCurrency_APIKey = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelCurrency_APIKey = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxCurrency_HomeCurrency = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView9 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.CheckBoxCurrency_ActivateMultipleCurrencies = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelCurrency_HomeCurrency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemAccountingOptions_CurrencyTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabItemAgencySetup_AccountingOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProductionOptionsTab_ProductionOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBox1 = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxAllowProofHQ = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxProductionOptions_PurchaseOrdersOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBox1View = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxProductionOptions_EstimateOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxEstimateOptions_NewRevisionsRequired = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxProductionOptions_EstimateProcessingExceedOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.DataGridViewEstimateProcessingExceedOptions_Options = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.GroupBoxProductionOptions_EstimateDefaultComments = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxEstimateDefaultComments_Comments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelPurchaseOrderDefaultFooterComments_Notes = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.GroupBoxProductionOptions_JobJacketOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxJobJacketOptions_AllowCDPOverride = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxJobJacketOptions_EnableFileAttachments = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemAgencySetup_ProductionOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelRequiredFieldsTab_RequiredFields = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelUserSelectedRequiredFields_RightColumn = New System.Windows.Forms.Panel()
            Me.CheckBoxRightColumn_JobLogCustom1 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobLogCustom2 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobComponentCustom5 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobLogCustom3 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobComponentCustom4 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobLogCustom4 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobComponentCustom3 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobLogCustom5 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobComponentCustom2 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxRightColumn_JobComponentCustom1 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelUserSelectedRequiredFields_MiddleColumn = New System.Windows.Forms.Panel()
            Me.CheckBoxMiddleColumn_DeptTeam = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMiddleColumn_ServiceFeeType = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMiddleColumn_JobType = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMiddleColumn_Promotion = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMiddleColumn_DueDate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMiddleColumn_SalesClassFormat = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMiddleColumn_Market = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_DateOpened = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMiddleColumn_Format = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelUserSelectedRequiredFields_LeftColumn = New System.Windows.Forms.Panel()
            Me.CheckBoxLeftColumn_AccountNumber = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_Budget = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxMiddleColumn_Contact = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_Complexity = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_AlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_Blackplate2 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_CoopBilling = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_AdNumber = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_ClientReference = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLeftColumn_Blackplate1 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxJobsAndMedia_FiscalPeriod = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxJobsAndMedia_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemAgencySetup_RequiredFieldsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Email = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemEmail_TestSending = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEmail_TestReceiving = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_AutomatedAssignments = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemAutomatedAssignments_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemAutomatedAssignments_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_AdServerFields = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemFields_MoveUp = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemFields_MoveDown = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Refresh = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Text = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemText_CheckSpelling = New DevComponents.DotNetBar.ButtonItem()
            Me.GroupBoxOptions_EmailingDocuments = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            CType(Me.TabControlForm_AgencySetup, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlForm_AgencySetup.SuspendLayout
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.SuspendLayout
            CType(Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.SuspendLayout
            Me.TabControlPanelOptionsTab_Options.SuspendLayout
            CType(Me.GroupBoxSystemAndAlertOptions_ProofingURL, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxSystemAndAlertOptions_ProofingURL.SuspendLayout
            CType(Me.GroupBoxSystemAndAlertOptions_DotNetFolder, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxSystemAndAlertOptions_DotNetFolder.SuspendLayout
            CType(Me.GroupBoxSystemAndAlertOptions_ClientPortalURL, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxSystemAndAlertOptions_ClientPortalURL.SuspendLayout
            CType(Me.GroupBoxOptions_EmailAttachments, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxOptions_EmailAttachments.SuspendLayout
            CType(Me.NumericInputEmailAttachments_MaxFileSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder.SuspendLayout
            CType(Me.GroupBoxOptions_AlertOptions, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxOptions_AlertOptions.SuspendLayout
            CType(Me.GroupBoxSystemAndAlertOptions_WebvantageURL, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxSystemAndAlertOptions_WebvantageURL.SuspendLayout
            CType(Me.GroupBoxSystemAndAlertOptions_AccessReportSourceFolder, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxSystemAndAlertOptions_AccessReportSourceFolder.SuspendLayout
            Me.TabControlPanelEmailSettingsTab_EmailSettings.SuspendLayout
            CType(Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.SuspendLayout
            CType(Me.NumericInputPOP3EmailListenerSettings_PortNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.SuspendLayout
            CType(Me.NumericInputSMTPEmailSetup_PortNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlPanelInformationTab_Information.SuspendLayout
            CType(Me.GroupBoxInformation_AgencyInformation, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxInformation_AgencyInformation.SuspendLayout
            Me.TabControlPanelMediaOptionsTab_MediaOptions.SuspendLayout
            CType(Me.TabControlMediaOptions_MediaOptions, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlMediaOptions_MediaOptions.SuspendLayout
            Me.TabControlPanelFooterCommentsTab_FooterComments.SuspendLayout
            CType(Me.TabControlFooterComments_FooterComments, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlFooterComments_FooterComments.SuspendLayout
            Me.TabControlPanelNewspaperTab_Newspaper.SuspendLayout
            Me.TabControlPanelInternetTab_Internet.SuspendLayout
            Me.TabControlPanelMagazineTab_Magazine.SuspendLayout
            Me.TabControlPanelTelevisionTab_Television.SuspendLayout
            Me.TabControlPanelRadioTab_Radio.SuspendLayout
            Me.TabControlPanelOutOfHomeTab_OutOfHome.SuspendLayout
            Me.TabControlPanelSettingsTab_Settings.SuspendLayout
            CType(Me.GroupBoxMediaOptions_BroadcastWorksheet, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxMediaOptions_BroadcastWorksheet.SuspendLayout
            CType(Me.DateTimePickerSettings_MediaTrafficStartDate, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GroupBoxSettings_MediaGeneral, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxSettings_MediaGeneral.SuspendLayout
            CType(Me.GroupBoxSettings_MediaOrders, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxSettings_MediaOrders.SuspendLayout
            CType(Me.GroupBoxSettings_MediaPlanning, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxSettings_MediaPlanning.SuspendLayout
            CType(Me.GroupBoxSettings_ExportMediaOrder, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxSettings_ExportMediaOrder.SuspendLayout
            Me.TabControlPanelAdServingTab_AdServing.SuspendLayout
            CType(Me.PanelAdServing_RightSection, System.ComponentModel.ISupportInitialize).BeginInit
            Me.PanelAdServing_RightSection.SuspendLayout
            CType(Me.PanelAdServing_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit
            Me.PanelAdServing_LeftSection.SuspendLayout
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.SuspendLayout
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.SuspendLayout
            CType(Me.GroupBoxTimesheetOptions_MissingTimeOptions, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxTimesheetOptions_MissingTimeOptions.SuspendLayout
            CType(Me.GroupBoxTimesheetOptions_TimesheetOptions, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxTimesheetOptions_TimesheetOptions.SuspendLayout
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.SuspendLayout
            CType(Me.TabControlAccountingOptions_AccountingOptions, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlAccountingOptions_AccountingOptions.SuspendLayout
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.SuspendLayout
            CType(Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert.SuspendLayout
            CType(Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView13, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView12, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView11, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GroupBoxAccountingOptions_AccountsPayableHeader, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxAccountingOptions_AccountsPayableHeader.SuspendLayout
            CType(Me.GroupBoxAccountingOptions_AccountsPayableDisbursement, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement.SuspendLayout
            Me.TabControlPanel1.SuspendLayout
            CType(Me.GroupBoxAvatax_AddressOptions, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxAvatax_AddressOptions.SuspendLayout
            CType(Me.GroupBoxAvaTax_OfficeCompanyCode, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxAvaTax_OfficeCompanyCode.SuspendLayout
            CType(Me.GroupBoxAvaTax_AddressValidation, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxAvaTax_AddressValidation.SuspendLayout
            Me.TabControlPanelMediaTab_Media.SuspendLayout
            CType(Me.GroupBoxMediaAndProduction_Media, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxMediaAndProduction_Media.SuspendLayout
            CType(Me.GroupBoxMediaAndProduction_MediaApprovalAlert, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxMediaAndProduction_MediaApprovalAlert.SuspendLayout
            CType(Me.GroupBoxMediaAndProduction_APMediaImportOptions, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxMediaAndProduction_APMediaImportOptions.SuspendLayout
            CType(Me.GroupBoxMedia_APPromptsOptions, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxMedia_APPromptsOptions.SuspendLayout
            CType(Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GroupBoxMediaAndProduction_Production, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxMediaAndProduction_Production.SuspendLayout
            Me.TabControlPanelImportTab_Import.SuspendLayout
            Me.TabControlPanelCheckWritingTab_CheckWriting.SuspendLayout
            CType(Me.GroupBoxCheckWriting_CheckFormatSettings, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxCheckWriting_CheckFormatSettings.SuspendLayout
            CType(Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GroupBoxCheckFormatSettings_CheckCurrency, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxCheckFormatSettings_CheckCurrency.SuspendLayout
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.SuspendLayout
            CType(Me.GroupBoxBillingAndAccountsReceivable_InvoiceTaxing, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxBillingAndAccountsReceivable_InvoiceTaxing.SuspendLayout
            CType(Me.GroupBoxBillingAndAccountsReceivable_ClientCashReceipts, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxBillingAndAccountsReceivable_ClientCashReceipts.SuspendLayout
            CType(Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView10, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GroupBoxBillingAndAccountsReceivable_Billing, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxBillingAndAccountsReceivable_Billing.SuspendLayout
            CType(Me.GroupBoxBilling_CustomInvoiceFormats, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxBilling_CustomInvoiceFormats.SuspendLayout
            CType(Me.SearchableComboBoxCustomInvoiceFormats_Internet.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxCustomInvoiceFormats_Magazine.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxCustomInvoiceFormats_Radio.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxCustomInvoiceFormats_Television.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxCustomInvoiceFormats_Production.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlPanelGLTab_GL.SuspendLayout
            Me.TabControlPanelCurrencyTab_Currency.SuspendLayout
            CType(Me.PictureEditCurrency_Image.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxCurrency_HomeCurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView9, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.SuspendLayout
            CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBox1.SuspendLayout
            CType(Me.GroupBoxProductionOptions_PurchaseOrdersOptions, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxProductionOptions_PurchaseOrdersOptions.SuspendLayout
            CType(Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GroupBoxProductionOptions_EstimateOptions, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxProductionOptions_EstimateOptions.SuspendLayout
            CType(Me.GroupBoxProductionOptions_EstimateProcessingExceedOptions, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxProductionOptions_EstimateProcessingExceedOptions.SuspendLayout
            CType(Me.GroupBoxProductionOptions_EstimateDefaultComments, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxProductionOptions_EstimateDefaultComments.SuspendLayout
            CType(Me.GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments.SuspendLayout
            CType(Me.GroupBoxProductionOptions_JobJacketOptions, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxProductionOptions_JobJacketOptions.SuspendLayout
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.SuspendLayout
            CType(Me.GroupBoxRequiredFields_UserSelectedRequiredFields, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.SuspendLayout
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields.SuspendLayout
            Me.PanelUserSelectedRequiredFields_RightColumn.SuspendLayout
            Me.PanelUserSelectedRequiredFields_MiddleColumn.SuspendLayout
            Me.PanelUserSelectedRequiredFields_LeftColumn.SuspendLayout
            CType(Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.SuspendLayout
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout
            CType(Me.GroupBoxOptions_EmailingDocuments, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxOptions_EmailingDocuments.SuspendLayout
            Me.SuspendLayout
            '
            'TabControlForm_AgencySetup
            '
            Me.TabControlForm_AgencySetup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_AgencySetup.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlForm_AgencySetup.CanReorderTabs = False
            Me.TabControlForm_AgencySetup.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_AgencySetup.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_AgencySetup.Controls.Add(Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions)
            Me.TabControlForm_AgencySetup.Controls.Add(Me.TabControlPanelInformationTab_Information)
            Me.TabControlForm_AgencySetup.Controls.Add(Me.TabControlPanelMediaOptionsTab_MediaOptions)
            Me.TabControlForm_AgencySetup.Controls.Add(Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions)
            Me.TabControlForm_AgencySetup.Controls.Add(Me.TabControlPanelAccountingOptionsTab_AccountingOptions)
            Me.TabControlForm_AgencySetup.Controls.Add(Me.TabControlPanelProductionOptionsTab_ProductionOptions)
            Me.TabControlForm_AgencySetup.Controls.Add(Me.TabControlPanelRequiredFieldsTab_RequiredFields)
            Me.TabControlForm_AgencySetup.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_AgencySetup.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_AgencySetup.Name = "TabControlForm_AgencySetup"
            Me.TabControlForm_AgencySetup.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_AgencySetup.SelectedTabIndex = 0
            Me.TabControlForm_AgencySetup.Size = New System.Drawing.Size(950, 639)
            Me.TabControlForm_AgencySetup.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_AgencySetup.TabIndex = 22
            Me.TabControlForm_AgencySetup.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_AgencySetup.Tabs.Add(Me.TabItemAgencySetup_InformationTab)
            Me.TabControlForm_AgencySetup.Tabs.Add(Me.TabItemAgencySetup_SystemAndAlertOptions)
            Me.TabControlForm_AgencySetup.Tabs.Add(Me.TabItemAgencySetup_ProductionOptionsTab)
            Me.TabControlForm_AgencySetup.Tabs.Add(Me.TabItemAgencySetup_AccountingOptionsTab)
            Me.TabControlForm_AgencySetup.Tabs.Add(Me.TabItemAgencySetup_TimesheetOptionsTab)
            Me.TabControlForm_AgencySetup.Tabs.Add(Me.TabItemAgencySetup_MediaOptionsTab)
            Me.TabControlForm_AgencySetup.Tabs.Add(Me.TabItemAgencySetup_RequiredFieldsTab)
            '
            'TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions
            '
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.AutoScroll = True
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Controls.Add(Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions)
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Name = "TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions"
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Size = New System.Drawing.Size(950, 612)
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.Style.GradientAngle = 90
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.TabIndex = 2
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.TabItem = Me.TabItemAgencySetup_SystemAndAlertOptions
            '
            'TabControlSystemAndAlertOptions_SystemAndAlertOptions
            '
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.BackColor = System.Drawing.Color.White
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.CanReorderTabs = False
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.Controls.Add(Me.TabControlPanelOptionsTab_Options)
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.Controls.Add(Me.TabControlPanelEmailSettingsTab_EmailSettings)
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.ForeColor = System.Drawing.Color.Black
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.Location = New System.Drawing.Point(4, 4)
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.Name = "TabControlSystemAndAlertOptions_SystemAndAlertOptions"
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.SelectedTabIndex = 1
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.Size = New System.Drawing.Size(941, 602)
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.TabIndex = 0
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.Tabs.Add(Me.TabItemSystemAndAlertOptions_OptionsTab)
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.Tabs.Add(Me.TabItemSystemAndAlertOptions_EmailSettingsTab)
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.Text = "TabControl1"
            '
            'TabControlPanelOptionsTab_Options
            '
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.GroupBoxOptions_EmailingDocuments)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.GroupBoxSystemAndAlertOptions_ProofingURL)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.GroupBoxSystemAndAlertOptions_DotNetFolder)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.GroupBoxSystemAndAlertOptions_ClientPortalURL)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.GroupBoxOptions_EmailAttachments)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.GroupBoxOptions_AlertOptions)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.GroupBoxSystemAndAlertOptions_WebvantageURL)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.GroupBoxSystemAndAlertOptions_AccessReportSourceFolder)
            Me.TabControlPanelOptionsTab_Options.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOptionsTab_Options.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOptionsTab_Options.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOptionsTab_Options.Name = "TabControlPanelOptionsTab_Options"
            Me.TabControlPanelOptionsTab_Options.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOptionsTab_Options.Size = New System.Drawing.Size(941, 575)
            Me.TabControlPanelOptionsTab_Options.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelOptionsTab_Options.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOptionsTab_Options.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOptionsTab_Options.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOptionsTab_Options.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOptionsTab_Options.Style.GradientAngle = 90
            Me.TabControlPanelOptionsTab_Options.TabIndex = 2
            Me.TabControlPanelOptionsTab_Options.TabItem = Me.TabItemSystemAndAlertOptions_OptionsTab
            '
            'GroupBoxSystemAndAlertOptions_ProofingURL
            '
            Me.GroupBoxSystemAndAlertOptions_ProofingURL.Controls.Add(Me.TextBoxProofingURL_URL)
            Me.GroupBoxSystemAndAlertOptions_ProofingURL.Controls.Add(Me.RadioButtonControlProofingURL_WorkstationOnly)
            Me.GroupBoxSystemAndAlertOptions_ProofingURL.Controls.Add(Me.RadioButtonControlProofingURL_UseGlobal)
            Me.GroupBoxSystemAndAlertOptions_ProofingURL.Location = New System.Drawing.Point(7, 463)
            Me.GroupBoxSystemAndAlertOptions_ProofingURL.Name = "GroupBoxSystemAndAlertOptions_ProofingURL"
            Me.GroupBoxSystemAndAlertOptions_ProofingURL.Size = New System.Drawing.Size(359, 101)
            Me.GroupBoxSystemAndAlertOptions_ProofingURL.TabIndex = 8
            Me.GroupBoxSystemAndAlertOptions_ProofingURL.Text = "Proofing URL"
            '
            'TextBoxProofingURL_URL
            '
            Me.TextBoxProofingURL_URL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxProofingURL_URL.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxProofingURL_URL.Border.Class = "TextBoxBorder"
            Me.TextBoxProofingURL_URL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxProofingURL_URL.CheckSpellingOnValidate = False
            Me.TextBoxProofingURL_URL.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxProofingURL_URL.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxProofingURL_URL.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxProofingURL_URL.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxProofingURL_URL.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxProofingURL_URL.FocusHighlightEnabled = True
            Me.TextBoxProofingURL_URL.ForeColor = System.Drawing.Color.Black
            Me.TextBoxProofingURL_URL.Location = New System.Drawing.Point(25, 75)
            Me.TextBoxProofingURL_URL.MaxFileSize = CType(0, Long)
            Me.TextBoxProofingURL_URL.Name = "TextBoxProofingURL_URL"
            Me.TextBoxProofingURL_URL.SecurityEnabled = True
            Me.TextBoxProofingURL_URL.ShowSpellCheckCompleteMessage = True
            Me.TextBoxProofingURL_URL.Size = New System.Drawing.Size(329, 21)
            Me.TextBoxProofingURL_URL.StartingFolderName = Nothing
            Me.TextBoxProofingURL_URL.TabIndex = 2
            Me.TextBoxProofingURL_URL.TabOnEnter = True
            '
            'RadioButtonControlProofingURL_WorkstationOnly
            '
            Me.RadioButtonControlProofingURL_WorkstationOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlProofingURL_WorkstationOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlProofingURL_WorkstationOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlProofingURL_WorkstationOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlProofingURL_WorkstationOnly.Location = New System.Drawing.Point(6, 50)
            Me.RadioButtonControlProofingURL_WorkstationOnly.Name = "RadioButtonControlProofingURL_WorkstationOnly"
            Me.RadioButtonControlProofingURL_WorkstationOnly.SecurityEnabled = True
            Me.RadioButtonControlProofingURL_WorkstationOnly.Size = New System.Drawing.Size(348, 20)
            Me.RadioButtonControlProofingURL_WorkstationOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlProofingURL_WorkstationOnly.TabIndex = 1
            Me.RadioButtonControlProofingURL_WorkstationOnly.TabOnEnter = True
            Me.RadioButtonControlProofingURL_WorkstationOnly.TabStop = False
            Me.RadioButtonControlProofingURL_WorkstationOnly.Text = "Use URL for This Workstation Only"
            '
            'RadioButtonControlProofingURL_UseGlobal
            '
            Me.RadioButtonControlProofingURL_UseGlobal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlProofingURL_UseGlobal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlProofingURL_UseGlobal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlProofingURL_UseGlobal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlProofingURL_UseGlobal.Location = New System.Drawing.Point(6, 25)
            Me.RadioButtonControlProofingURL_UseGlobal.Name = "RadioButtonControlProofingURL_UseGlobal"
            Me.RadioButtonControlProofingURL_UseGlobal.SecurityEnabled = True
            Me.RadioButtonControlProofingURL_UseGlobal.Size = New System.Drawing.Size(348, 20)
            Me.RadioButtonControlProofingURL_UseGlobal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlProofingURL_UseGlobal.TabIndex = 0
            Me.RadioButtonControlProofingURL_UseGlobal.TabOnEnter = True
            Me.RadioButtonControlProofingURL_UseGlobal.TabStop = False
            Me.RadioButtonControlProofingURL_UseGlobal.Text = "Use Global Proofing URL"
            '
            'GroupBoxSystemAndAlertOptions_DotNetFolder
            '
            Me.GroupBoxSystemAndAlertOptions_DotNetFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxSystemAndAlertOptions_DotNetFolder.Controls.Add(Me.TextBoxDotNetFolder_Path)
            Me.GroupBoxSystemAndAlertOptions_DotNetFolder.Controls.Add(Me.RadioButtonControlDotNetFolder_WorkstationOnly)
            Me.GroupBoxSystemAndAlertOptions_DotNetFolder.Controls.Add(Me.RadioButtonControlDotNetFolder_UseGlobal)
            Me.GroupBoxSystemAndAlertOptions_DotNetFolder.Location = New System.Drawing.Point(370, 217)
            Me.GroupBoxSystemAndAlertOptions_DotNetFolder.Name = "GroupBoxSystemAndAlertOptions_DotNetFolder"
            Me.GroupBoxSystemAndAlertOptions_DotNetFolder.Size = New System.Drawing.Size(566, 101)
            Me.GroupBoxSystemAndAlertOptions_DotNetFolder.TabIndex = 7
            Me.GroupBoxSystemAndAlertOptions_DotNetFolder.Text = ".NET  Folder"
            '
            'TextBoxDotNetFolder_Path
            '
            Me.TextBoxDotNetFolder_Path.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxDotNetFolder_Path.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxDotNetFolder_Path.Border.Class = "TextBoxBorder"
            Me.TextBoxDotNetFolder_Path.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDotNetFolder_Path.ButtonCustom.Visible = True
            Me.TextBoxDotNetFolder_Path.CheckSpellingOnValidate = False
            Me.TextBoxDotNetFolder_Path.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxDotNetFolder_Path.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxDotNetFolder_Path.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxDotNetFolder_Path.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDotNetFolder_Path.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDotNetFolder_Path.FocusHighlightEnabled = True
            Me.TextBoxDotNetFolder_Path.ForeColor = System.Drawing.Color.Black
            Me.TextBoxDotNetFolder_Path.Location = New System.Drawing.Point(25, 76)
            Me.TextBoxDotNetFolder_Path.MaxFileSize = CType(0, Long)
            Me.TextBoxDotNetFolder_Path.Name = "TextBoxDotNetFolder_Path"
            Me.TextBoxDotNetFolder_Path.SecurityEnabled = True
            Me.TextBoxDotNetFolder_Path.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDotNetFolder_Path.Size = New System.Drawing.Size(536, 21)
            Me.TextBoxDotNetFolder_Path.StartingFolderName = Nothing
            Me.TextBoxDotNetFolder_Path.TabIndex = 2
            Me.TextBoxDotNetFolder_Path.TabOnEnter = True
            '
            'RadioButtonControlDotNetFolder_WorkstationOnly
            '
            Me.RadioButtonControlDotNetFolder_WorkstationOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlDotNetFolder_WorkstationOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlDotNetFolder_WorkstationOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlDotNetFolder_WorkstationOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlDotNetFolder_WorkstationOnly.Location = New System.Drawing.Point(6, 50)
            Me.RadioButtonControlDotNetFolder_WorkstationOnly.Name = "RadioButtonControlDotNetFolder_WorkstationOnly"
            Me.RadioButtonControlDotNetFolder_WorkstationOnly.SecurityEnabled = True
            Me.RadioButtonControlDotNetFolder_WorkstationOnly.Size = New System.Drawing.Size(555, 20)
            Me.RadioButtonControlDotNetFolder_WorkstationOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlDotNetFolder_WorkstationOnly.TabIndex = 1
            Me.RadioButtonControlDotNetFolder_WorkstationOnly.TabOnEnter = True
            Me.RadioButtonControlDotNetFolder_WorkstationOnly.TabStop = False
            Me.RadioButtonControlDotNetFolder_WorkstationOnly.Text = "Use Path for This Workstation Only"
            '
            'RadioButtonControlDotNetFolder_UseGlobal
            '
            Me.RadioButtonControlDotNetFolder_UseGlobal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlDotNetFolder_UseGlobal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlDotNetFolder_UseGlobal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlDotNetFolder_UseGlobal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlDotNetFolder_UseGlobal.Location = New System.Drawing.Point(6, 25)
            Me.RadioButtonControlDotNetFolder_UseGlobal.Name = "RadioButtonControlDotNetFolder_UseGlobal"
            Me.RadioButtonControlDotNetFolder_UseGlobal.SecurityEnabled = True
            Me.RadioButtonControlDotNetFolder_UseGlobal.Size = New System.Drawing.Size(555, 20)
            Me.RadioButtonControlDotNetFolder_UseGlobal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlDotNetFolder_UseGlobal.TabIndex = 0
            Me.RadioButtonControlDotNetFolder_UseGlobal.TabOnEnter = True
            Me.RadioButtonControlDotNetFolder_UseGlobal.TabStop = False
            Me.RadioButtonControlDotNetFolder_UseGlobal.Text = "Use Global Agency Path"
            '
            'GroupBoxSystemAndAlertOptions_ClientPortalURL
            '
            Me.GroupBoxSystemAndAlertOptions_ClientPortalURL.Controls.Add(Me.TextBoxClientPortalURL_URL)
            Me.GroupBoxSystemAndAlertOptions_ClientPortalURL.Controls.Add(Me.RadioButtonControlClientPortalURL_WorkstationOnly)
            Me.GroupBoxSystemAndAlertOptions_ClientPortalURL.Controls.Add(Me.RadioButtonControlClientPortalURL_UseGlobal)
            Me.GroupBoxSystemAndAlertOptions_ClientPortalURL.Location = New System.Drawing.Point(5, 359)
            Me.GroupBoxSystemAndAlertOptions_ClientPortalURL.Name = "GroupBoxSystemAndAlertOptions_ClientPortalURL"
            Me.GroupBoxSystemAndAlertOptions_ClientPortalURL.Size = New System.Drawing.Size(359, 101)
            Me.GroupBoxSystemAndAlertOptions_ClientPortalURL.TabIndex = 6
            Me.GroupBoxSystemAndAlertOptions_ClientPortalURL.Text = "Client Portal URL"
            '
            'TextBoxClientPortalURL_URL
            '
            Me.TextBoxClientPortalURL_URL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxClientPortalURL_URL.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxClientPortalURL_URL.Border.Class = "TextBoxBorder"
            Me.TextBoxClientPortalURL_URL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxClientPortalURL_URL.CheckSpellingOnValidate = False
            Me.TextBoxClientPortalURL_URL.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxClientPortalURL_URL.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxClientPortalURL_URL.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxClientPortalURL_URL.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxClientPortalURL_URL.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxClientPortalURL_URL.FocusHighlightEnabled = True
            Me.TextBoxClientPortalURL_URL.ForeColor = System.Drawing.Color.Black
            Me.TextBoxClientPortalURL_URL.Location = New System.Drawing.Point(25, 75)
            Me.TextBoxClientPortalURL_URL.MaxFileSize = CType(0, Long)
            Me.TextBoxClientPortalURL_URL.Name = "TextBoxClientPortalURL_URL"
            Me.TextBoxClientPortalURL_URL.SecurityEnabled = True
            Me.TextBoxClientPortalURL_URL.ShowSpellCheckCompleteMessage = True
            Me.TextBoxClientPortalURL_URL.Size = New System.Drawing.Size(329, 21)
            Me.TextBoxClientPortalURL_URL.StartingFolderName = Nothing
            Me.TextBoxClientPortalURL_URL.TabIndex = 2
            Me.TextBoxClientPortalURL_URL.TabOnEnter = True
            '
            'RadioButtonControlClientPortalURL_WorkstationOnly
            '
            Me.RadioButtonControlClientPortalURL_WorkstationOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlClientPortalURL_WorkstationOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlClientPortalURL_WorkstationOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlClientPortalURL_WorkstationOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlClientPortalURL_WorkstationOnly.Location = New System.Drawing.Point(6, 50)
            Me.RadioButtonControlClientPortalURL_WorkstationOnly.Name = "RadioButtonControlClientPortalURL_WorkstationOnly"
            Me.RadioButtonControlClientPortalURL_WorkstationOnly.SecurityEnabled = True
            Me.RadioButtonControlClientPortalURL_WorkstationOnly.Size = New System.Drawing.Size(348, 20)
            Me.RadioButtonControlClientPortalURL_WorkstationOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlClientPortalURL_WorkstationOnly.TabIndex = 1
            Me.RadioButtonControlClientPortalURL_WorkstationOnly.TabOnEnter = True
            Me.RadioButtonControlClientPortalURL_WorkstationOnly.TabStop = False
            Me.RadioButtonControlClientPortalURL_WorkstationOnly.Text = "Use URL for This Workstation Only"
            '
            'RadioButtonControlClientPortalURL_UseGlobal
            '
            Me.RadioButtonControlClientPortalURL_UseGlobal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlClientPortalURL_UseGlobal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlClientPortalURL_UseGlobal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlClientPortalURL_UseGlobal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlClientPortalURL_UseGlobal.Location = New System.Drawing.Point(6, 25)
            Me.RadioButtonControlClientPortalURL_UseGlobal.Name = "RadioButtonControlClientPortalURL_UseGlobal"
            Me.RadioButtonControlClientPortalURL_UseGlobal.SecurityEnabled = True
            Me.RadioButtonControlClientPortalURL_UseGlobal.Size = New System.Drawing.Size(348, 20)
            Me.RadioButtonControlClientPortalURL_UseGlobal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlClientPortalURL_UseGlobal.TabIndex = 0
            Me.RadioButtonControlClientPortalURL_UseGlobal.TabOnEnter = True
            Me.RadioButtonControlClientPortalURL_UseGlobal.TabStop = False
            Me.RadioButtonControlClientPortalURL_UseGlobal.Text = "Use Global Client Portal URL"
            '
            'GroupBoxOptions_EmailAttachments
            '
            Me.GroupBoxOptions_EmailAttachments.Controls.Add(Me.NumericInputEmailAttachments_MaxFileSize)
            Me.GroupBoxOptions_EmailAttachments.Controls.Add(Me.LabelEmailAttachments_MaxFileSize)
            Me.GroupBoxOptions_EmailAttachments.Location = New System.Drawing.Point(4, 197)
            Me.GroupBoxOptions_EmailAttachments.Name = "GroupBoxOptions_EmailAttachments"
            Me.GroupBoxOptions_EmailAttachments.Size = New System.Drawing.Size(360, 52)
            Me.GroupBoxOptions_EmailAttachments.TabIndex = 2
            Me.GroupBoxOptions_EmailAttachments.Text = "Email Attachments"
            '
            'NumericInputEmailAttachments_MaxFileSize
            '
            Me.NumericInputEmailAttachments_MaxFileSize.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputEmailAttachments_MaxFileSize.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputEmailAttachments_MaxFileSize.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputEmailAttachments_MaxFileSize.EnterMoveNextControl = True
            Me.NumericInputEmailAttachments_MaxFileSize.Location = New System.Drawing.Point(93, 25)
            Me.NumericInputEmailAttachments_MaxFileSize.Name = "NumericInputEmailAttachments_MaxFileSize"
            Me.NumericInputEmailAttachments_MaxFileSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputEmailAttachments_MaxFileSize.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputEmailAttachments_MaxFileSize.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputEmailAttachments_MaxFileSize.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputEmailAttachments_MaxFileSize.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputEmailAttachments_MaxFileSize.Properties.IsFloatValue = False
            Me.NumericInputEmailAttachments_MaxFileSize.Properties.Mask.EditMask = "f0"
            Me.NumericInputEmailAttachments_MaxFileSize.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputEmailAttachments_MaxFileSize.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputEmailAttachments_MaxFileSize.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputEmailAttachments_MaxFileSize.SecurityEnabled = True
            Me.NumericInputEmailAttachments_MaxFileSize.Size = New System.Drawing.Size(262, 20)
            Me.NumericInputEmailAttachments_MaxFileSize.TabIndex = 1
            '
            'LabelEmailAttachments_MaxFileSize
            '
            Me.LabelEmailAttachments_MaxFileSize.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelEmailAttachments_MaxFileSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelEmailAttachments_MaxFileSize.Location = New System.Drawing.Point(6, 25)
            Me.LabelEmailAttachments_MaxFileSize.Name = "LabelEmailAttachments_MaxFileSize"
            Me.LabelEmailAttachments_MaxFileSize.Size = New System.Drawing.Size(81, 20)
            Me.LabelEmailAttachments_MaxFileSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelEmailAttachments_MaxFileSize.TabIndex = 0
            Me.LabelEmailAttachments_MaxFileSize.Text = "Max File Size:"
            '
            'GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder
            '
            Me.GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder.Controls.Add(Me.TextBoxAccessReportTemporaryFolder_Path)
            Me.GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder.Controls.Add(Me.RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly)
            Me.GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder.Controls.Add(Me.RadioButtonControlAccessReportTemporaryFolder_UseGlobal)
            Me.GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder.Location = New System.Drawing.Point(370, 111)
            Me.GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder.Name = "GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder"
            Me.GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder.Size = New System.Drawing.Size(566, 101)
            Me.GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder.TabIndex = 5
            Me.GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder.Text = "Access Report Temporary Folder"
            '
            'TextBoxAccessReportTemporaryFolder_Path
            '
            Me.TextBoxAccessReportTemporaryFolder_Path.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxAccessReportTemporaryFolder_Path.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxAccessReportTemporaryFolder_Path.Border.Class = "TextBoxBorder"
            Me.TextBoxAccessReportTemporaryFolder_Path.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAccessReportTemporaryFolder_Path.ButtonCustom.Visible = True
            Me.TextBoxAccessReportTemporaryFolder_Path.CheckSpellingOnValidate = False
            Me.TextBoxAccessReportTemporaryFolder_Path.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxAccessReportTemporaryFolder_Path.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxAccessReportTemporaryFolder_Path.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxAccessReportTemporaryFolder_Path.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAccessReportTemporaryFolder_Path.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAccessReportTemporaryFolder_Path.FocusHighlightEnabled = True
            Me.TextBoxAccessReportTemporaryFolder_Path.ForeColor = System.Drawing.Color.Black
            Me.TextBoxAccessReportTemporaryFolder_Path.Location = New System.Drawing.Point(25, 75)
            Me.TextBoxAccessReportTemporaryFolder_Path.MaxFileSize = CType(0, Long)
            Me.TextBoxAccessReportTemporaryFolder_Path.Name = "TextBoxAccessReportTemporaryFolder_Path"
            Me.TextBoxAccessReportTemporaryFolder_Path.SecurityEnabled = True
            Me.TextBoxAccessReportTemporaryFolder_Path.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAccessReportTemporaryFolder_Path.Size = New System.Drawing.Size(536, 21)
            Me.TextBoxAccessReportTemporaryFolder_Path.StartingFolderName = Nothing
            Me.TextBoxAccessReportTemporaryFolder_Path.TabIndex = 2
            Me.TextBoxAccessReportTemporaryFolder_Path.TabOnEnter = True
            '
            'RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly
            '
            Me.RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.Location = New System.Drawing.Point(6, 50)
            Me.RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.Name = "RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly"
            Me.RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.SecurityEnabled = True
            Me.RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.Size = New System.Drawing.Size(555, 20)
            Me.RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.TabIndex = 1
            Me.RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.TabOnEnter = True
            Me.RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.TabStop = False
            Me.RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly.Text = "Use Path for This Workstation Only"
            '
            'RadioButtonControlAccessReportTemporaryFolder_UseGlobal
            '
            Me.RadioButtonControlAccessReportTemporaryFolder_UseGlobal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlAccessReportTemporaryFolder_UseGlobal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAccessReportTemporaryFolder_UseGlobal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAccessReportTemporaryFolder_UseGlobal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAccessReportTemporaryFolder_UseGlobal.Location = New System.Drawing.Point(6, 25)
            Me.RadioButtonControlAccessReportTemporaryFolder_UseGlobal.Name = "RadioButtonControlAccessReportTemporaryFolder_UseGlobal"
            Me.RadioButtonControlAccessReportTemporaryFolder_UseGlobal.SecurityEnabled = True
            Me.RadioButtonControlAccessReportTemporaryFolder_UseGlobal.Size = New System.Drawing.Size(555, 20)
            Me.RadioButtonControlAccessReportTemporaryFolder_UseGlobal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAccessReportTemporaryFolder_UseGlobal.TabIndex = 0
            Me.RadioButtonControlAccessReportTemporaryFolder_UseGlobal.TabOnEnter = True
            Me.RadioButtonControlAccessReportTemporaryFolder_UseGlobal.TabStop = False
            Me.RadioButtonControlAccessReportTemporaryFolder_UseGlobal.Text = "Use Global Agency Path"
            '
            'GroupBoxOptions_AlertOptions
            '
            Me.GroupBoxOptions_AlertOptions.Controls.Add(Me.CheckBoxAlertOptions_CommentsFirstOnEmails)
            Me.GroupBoxOptions_AlertOptions.Controls.Add(Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts)
            Me.GroupBoxOptions_AlertOptions.Controls.Add(Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow)
            Me.GroupBoxOptions_AlertOptions.Controls.Add(Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts)
            Me.GroupBoxOptions_AlertOptions.Controls.Add(Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault)
            Me.GroupBoxOptions_AlertOptions.Controls.Add(Me.CheckBoxAlertOptions_EnableAlertNotification)
            Me.GroupBoxOptions_AlertOptions.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxOptions_AlertOptions.Name = "GroupBoxOptions_AlertOptions"
            Me.GroupBoxOptions_AlertOptions.Size = New System.Drawing.Size(360, 186)
            Me.GroupBoxOptions_AlertOptions.TabIndex = 1
            Me.GroupBoxOptions_AlertOptions.Text = "Alert Options"
            '
            'CheckBoxAlertOptions_CommentsFirstOnEmails
            '
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.CheckValue = CType(0, Short)
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.ChildControls = CType(resources.GetObject("CheckBoxAlertOptions_CommentsFirstOnEmails.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.EnableMnemonicWithAltKeyOnly = True
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.Location = New System.Drawing.Point(6, 151)
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.Name = "CheckBoxAlertOptions_CommentsFirstOnEmails"
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.OldestSibling = Nothing
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.SecurityEnabled = True
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.SiblingControls = CType(resources.GetObject("CheckBoxAlertOptions_CommentsFirstOnEmails.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.Size = New System.Drawing.Size(349, 20)
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.TabIndex = 5
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.TabOnEnter = True
            Me.CheckBoxAlertOptions_CommentsFirstOnEmails.Text = "Put Comments First On Emails"
            '
            'CheckBoxAlertOptions_ActivateSystemGeneratedAlerts
            '
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.CheckValue = CType(0, Short)
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.ChildControls = CType(resources.GetObject("CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.Location = New System.Drawing.Point(6, 25)
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.Name = "CheckBoxAlertOptions_ActivateSystemGeneratedAlerts"
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.OldestSibling = Nothing
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.SecurityEnabled = True
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.SiblingControls = CType(resources.GetObject("CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.Size = New System.Drawing.Size(349, 20)
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.TabIndex = 0
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.TabOnEnter = True
            Me.CheckBoxAlertOptions_ActivateSystemGeneratedAlerts.Text = "Activate System Generated Alerts"
            '
            'CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow
            '
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.CheckValue = CType(0, Short)
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.ChildControls = CType(resources.GetObject("CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.Location = New System.Drawing.Point(6, 50)
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.Name = "CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow"
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.OldestSibling = Nothing
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.SecurityEnabled = True
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.SiblingControls = CType(resources.GetObject("CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.Size = New System.Drawing.Size(349, 20)
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.TabIndex = 1
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.TabOnEnter = True
            Me.CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow.Text = "Include Alert Groups in Prompt Window"
            '
            'CheckBoxAlertOptions_IncludeAttachmentsWithAlerts
            '
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.CheckValue = CType(0, Short)
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.ChildControls = CType(resources.GetObject("CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.Location = New System.Drawing.Point(6, 75)
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.Name = "CheckBoxAlertOptions_IncludeAttachmentsWithAlerts"
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.OldestSibling = Nothing
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.SecurityEnabled = True
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.SiblingControls = CType(resources.GetObject("CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.Size = New System.Drawing.Size(349, 20)
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.TabIndex = 2
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.TabOnEnter = True
            Me.CheckBoxAlertOptions_IncludeAttachmentsWithAlerts.Text = "Include Attachments with Alerts Only (Exclude from E-Mail)"
            '
            'CheckBoxAlertOptions_ExcludeAttachmentByDefault
            '
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.CheckValue = CType(0, Short)
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.ChildControls = CType(resources.GetObject("CheckBoxAlertOptions_ExcludeAttachmentByDefault.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.Location = New System.Drawing.Point(24, 100)
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.Name = "CheckBoxAlertOptions_ExcludeAttachmentByDefault"
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.OldestSibling = Nothing
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.SecurityEnabled = True
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.SiblingControls = CType(resources.GetObject("CheckBoxAlertOptions_ExcludeAttachmentByDefault.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.Size = New System.Drawing.Size(331, 20)
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.TabIndex = 3
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.TabOnEnter = True
            Me.CheckBoxAlertOptions_ExcludeAttachmentByDefault.Text = "Exclude Attachment By Default"
            '
            'CheckBoxAlertOptions_EnableAlertNotification
            '
            Me.CheckBoxAlertOptions_EnableAlertNotification.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxAlertOptions_EnableAlertNotification.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxAlertOptions_EnableAlertNotification.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAlertOptions_EnableAlertNotification.CheckValue = CType(0, Short)
            Me.CheckBoxAlertOptions_EnableAlertNotification.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAlertOptions_EnableAlertNotification.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAlertOptions_EnableAlertNotification.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAlertOptions_EnableAlertNotification.ChildControls = CType(resources.GetObject("CheckBoxAlertOptions_EnableAlertNotification.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAlertOptions_EnableAlertNotification.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAlertOptions_EnableAlertNotification.Location = New System.Drawing.Point(6, 125)
            Me.CheckBoxAlertOptions_EnableAlertNotification.Name = "CheckBoxAlertOptions_EnableAlertNotification"
            Me.CheckBoxAlertOptions_EnableAlertNotification.OldestSibling = Nothing
            Me.CheckBoxAlertOptions_EnableAlertNotification.SecurityEnabled = True
            Me.CheckBoxAlertOptions_EnableAlertNotification.SiblingControls = CType(resources.GetObject("CheckBoxAlertOptions_EnableAlertNotification.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAlertOptions_EnableAlertNotification.Size = New System.Drawing.Size(349, 20)
            Me.CheckBoxAlertOptions_EnableAlertNotification.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAlertOptions_EnableAlertNotification.TabIndex = 4
            Me.CheckBoxAlertOptions_EnableAlertNotification.TabOnEnter = True
            Me.CheckBoxAlertOptions_EnableAlertNotification.Text = "Enable Alert Notification"
            '
            'GroupBoxSystemAndAlertOptions_WebvantageURL
            '
            Me.GroupBoxSystemAndAlertOptions_WebvantageURL.Controls.Add(Me.TextBoxWebvantageURL_URL)
            Me.GroupBoxSystemAndAlertOptions_WebvantageURL.Controls.Add(Me.RadioButtonControlWebvantageURL_WorkstationOnly)
            Me.GroupBoxSystemAndAlertOptions_WebvantageURL.Controls.Add(Me.RadioButtonControlWebvantageURL_UseGlobal)
            Me.GroupBoxSystemAndAlertOptions_WebvantageURL.Location = New System.Drawing.Point(5, 254)
            Me.GroupBoxSystemAndAlertOptions_WebvantageURL.Name = "GroupBoxSystemAndAlertOptions_WebvantageURL"
            Me.GroupBoxSystemAndAlertOptions_WebvantageURL.Size = New System.Drawing.Size(359, 101)
            Me.GroupBoxSystemAndAlertOptions_WebvantageURL.TabIndex = 3
            Me.GroupBoxSystemAndAlertOptions_WebvantageURL.Text = "Webvantage URL"
            '
            'TextBoxWebvantageURL_URL
            '
            Me.TextBoxWebvantageURL_URL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxWebvantageURL_URL.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxWebvantageURL_URL.Border.Class = "TextBoxBorder"
            Me.TextBoxWebvantageURL_URL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxWebvantageURL_URL.CheckSpellingOnValidate = False
            Me.TextBoxWebvantageURL_URL.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxWebvantageURL_URL.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxWebvantageURL_URL.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxWebvantageURL_URL.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxWebvantageURL_URL.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxWebvantageURL_URL.FocusHighlightEnabled = True
            Me.TextBoxWebvantageURL_URL.ForeColor = System.Drawing.Color.Black
            Me.TextBoxWebvantageURL_URL.Location = New System.Drawing.Point(25, 75)
            Me.TextBoxWebvantageURL_URL.MaxFileSize = CType(0, Long)
            Me.TextBoxWebvantageURL_URL.Name = "TextBoxWebvantageURL_URL"
            Me.TextBoxWebvantageURL_URL.SecurityEnabled = True
            Me.TextBoxWebvantageURL_URL.ShowSpellCheckCompleteMessage = True
            Me.TextBoxWebvantageURL_URL.Size = New System.Drawing.Size(329, 21)
            Me.TextBoxWebvantageURL_URL.StartingFolderName = Nothing
            Me.TextBoxWebvantageURL_URL.TabIndex = 2
            Me.TextBoxWebvantageURL_URL.TabOnEnter = True
            '
            'RadioButtonControlWebvantageURL_WorkstationOnly
            '
            Me.RadioButtonControlWebvantageURL_WorkstationOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlWebvantageURL_WorkstationOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlWebvantageURL_WorkstationOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlWebvantageURL_WorkstationOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlWebvantageURL_WorkstationOnly.Location = New System.Drawing.Point(6, 50)
            Me.RadioButtonControlWebvantageURL_WorkstationOnly.Name = "RadioButtonControlWebvantageURL_WorkstationOnly"
            Me.RadioButtonControlWebvantageURL_WorkstationOnly.SecurityEnabled = True
            Me.RadioButtonControlWebvantageURL_WorkstationOnly.Size = New System.Drawing.Size(348, 20)
            Me.RadioButtonControlWebvantageURL_WorkstationOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlWebvantageURL_WorkstationOnly.TabIndex = 1
            Me.RadioButtonControlWebvantageURL_WorkstationOnly.TabOnEnter = True
            Me.RadioButtonControlWebvantageURL_WorkstationOnly.TabStop = False
            Me.RadioButtonControlWebvantageURL_WorkstationOnly.Text = "Use URL for This Workstation Only"
            '
            'RadioButtonControlWebvantageURL_UseGlobal
            '
            Me.RadioButtonControlWebvantageURL_UseGlobal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlWebvantageURL_UseGlobal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlWebvantageURL_UseGlobal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlWebvantageURL_UseGlobal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlWebvantageURL_UseGlobal.Location = New System.Drawing.Point(6, 25)
            Me.RadioButtonControlWebvantageURL_UseGlobal.Name = "RadioButtonControlWebvantageURL_UseGlobal"
            Me.RadioButtonControlWebvantageURL_UseGlobal.SecurityEnabled = True
            Me.RadioButtonControlWebvantageURL_UseGlobal.Size = New System.Drawing.Size(348, 20)
            Me.RadioButtonControlWebvantageURL_UseGlobal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlWebvantageURL_UseGlobal.TabIndex = 0
            Me.RadioButtonControlWebvantageURL_UseGlobal.TabOnEnter = True
            Me.RadioButtonControlWebvantageURL_UseGlobal.TabStop = False
            Me.RadioButtonControlWebvantageURL_UseGlobal.Text = "Use Global Webvantage URL"
            '
            'GroupBoxSystemAndAlertOptions_AccessReportSourceFolder
            '
            Me.GroupBoxSystemAndAlertOptions_AccessReportSourceFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxSystemAndAlertOptions_AccessReportSourceFolder.Controls.Add(Me.TextBoxAccessReportSourceFolder_Path)
            Me.GroupBoxSystemAndAlertOptions_AccessReportSourceFolder.Controls.Add(Me.RadioButtonControlAccessReportSourceFolder_WorkstationOnly)
            Me.GroupBoxSystemAndAlertOptions_AccessReportSourceFolder.Controls.Add(Me.RadioButtonControlAccessReportSourceFolder_UseGlobal)
            Me.GroupBoxSystemAndAlertOptions_AccessReportSourceFolder.Location = New System.Drawing.Point(370, 4)
            Me.GroupBoxSystemAndAlertOptions_AccessReportSourceFolder.Name = "GroupBoxSystemAndAlertOptions_AccessReportSourceFolder"
            Me.GroupBoxSystemAndAlertOptions_AccessReportSourceFolder.Size = New System.Drawing.Size(567, 101)
            Me.GroupBoxSystemAndAlertOptions_AccessReportSourceFolder.TabIndex = 4
            Me.GroupBoxSystemAndAlertOptions_AccessReportSourceFolder.Text = "Access Report Source Folder"
            '
            'TextBoxAccessReportSourceFolder_Path
            '
            Me.TextBoxAccessReportSourceFolder_Path.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxAccessReportSourceFolder_Path.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxAccessReportSourceFolder_Path.Border.Class = "TextBoxBorder"
            Me.TextBoxAccessReportSourceFolder_Path.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAccessReportSourceFolder_Path.ButtonCustom.Visible = True
            Me.TextBoxAccessReportSourceFolder_Path.CheckSpellingOnValidate = False
            Me.TextBoxAccessReportSourceFolder_Path.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxAccessReportSourceFolder_Path.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxAccessReportSourceFolder_Path.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxAccessReportSourceFolder_Path.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAccessReportSourceFolder_Path.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAccessReportSourceFolder_Path.FocusHighlightEnabled = True
            Me.TextBoxAccessReportSourceFolder_Path.ForeColor = System.Drawing.Color.Black
            Me.TextBoxAccessReportSourceFolder_Path.Location = New System.Drawing.Point(25, 76)
            Me.TextBoxAccessReportSourceFolder_Path.MaxFileSize = CType(0, Long)
            Me.TextBoxAccessReportSourceFolder_Path.Name = "TextBoxAccessReportSourceFolder_Path"
            Me.TextBoxAccessReportSourceFolder_Path.SecurityEnabled = True
            Me.TextBoxAccessReportSourceFolder_Path.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAccessReportSourceFolder_Path.Size = New System.Drawing.Size(537, 21)
            Me.TextBoxAccessReportSourceFolder_Path.StartingFolderName = Nothing
            Me.TextBoxAccessReportSourceFolder_Path.TabIndex = 2
            Me.TextBoxAccessReportSourceFolder_Path.TabOnEnter = True
            '
            'RadioButtonControlAccessReportSourceFolder_WorkstationOnly
            '
            Me.RadioButtonControlAccessReportSourceFolder_WorkstationOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlAccessReportSourceFolder_WorkstationOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAccessReportSourceFolder_WorkstationOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAccessReportSourceFolder_WorkstationOnly.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAccessReportSourceFolder_WorkstationOnly.Location = New System.Drawing.Point(6, 50)
            Me.RadioButtonControlAccessReportSourceFolder_WorkstationOnly.Name = "RadioButtonControlAccessReportSourceFolder_WorkstationOnly"
            Me.RadioButtonControlAccessReportSourceFolder_WorkstationOnly.SecurityEnabled = True
            Me.RadioButtonControlAccessReportSourceFolder_WorkstationOnly.Size = New System.Drawing.Size(556, 20)
            Me.RadioButtonControlAccessReportSourceFolder_WorkstationOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAccessReportSourceFolder_WorkstationOnly.TabIndex = 1
            Me.RadioButtonControlAccessReportSourceFolder_WorkstationOnly.TabOnEnter = True
            Me.RadioButtonControlAccessReportSourceFolder_WorkstationOnly.TabStop = False
            Me.RadioButtonControlAccessReportSourceFolder_WorkstationOnly.Text = "Use Path for This Workstation Only"
            '
            'RadioButtonControlAccessReportSourceFolder_UseGlobal
            '
            Me.RadioButtonControlAccessReportSourceFolder_UseGlobal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlAccessReportSourceFolder_UseGlobal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlAccessReportSourceFolder_UseGlobal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlAccessReportSourceFolder_UseGlobal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlAccessReportSourceFolder_UseGlobal.Location = New System.Drawing.Point(6, 25)
            Me.RadioButtonControlAccessReportSourceFolder_UseGlobal.Name = "RadioButtonControlAccessReportSourceFolder_UseGlobal"
            Me.RadioButtonControlAccessReportSourceFolder_UseGlobal.SecurityEnabled = True
            Me.RadioButtonControlAccessReportSourceFolder_UseGlobal.Size = New System.Drawing.Size(556, 20)
            Me.RadioButtonControlAccessReportSourceFolder_UseGlobal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlAccessReportSourceFolder_UseGlobal.TabIndex = 0
            Me.RadioButtonControlAccessReportSourceFolder_UseGlobal.TabOnEnter = True
            Me.RadioButtonControlAccessReportSourceFolder_UseGlobal.TabStop = False
            Me.RadioButtonControlAccessReportSourceFolder_UseGlobal.Text = "Use Global Agency Path"
            '
            'TabItemSystemAndAlertOptions_OptionsTab
            '
            Me.TabItemSystemAndAlertOptions_OptionsTab.AttachedControl = Me.TabControlPanelOptionsTab_Options
            Me.TabItemSystemAndAlertOptions_OptionsTab.Name = "TabItemSystemAndAlertOptions_OptionsTab"
            Me.TabItemSystemAndAlertOptions_OptionsTab.Text = "Options"
            '
            'TabControlPanelEmailSettingsTab_EmailSettings
            '
            Me.TabControlPanelEmailSettingsTab_EmailSettings.AutoScroll = True
            Me.TabControlPanelEmailSettingsTab_EmailSettings.Controls.Add(Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings)
            Me.TabControlPanelEmailSettingsTab_EmailSettings.Controls.Add(Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup)
            Me.TabControlPanelEmailSettingsTab_EmailSettings.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelEmailSettingsTab_EmailSettings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEmailSettingsTab_EmailSettings.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEmailSettingsTab_EmailSettings.Name = "TabControlPanelEmailSettingsTab_EmailSettings"
            Me.TabControlPanelEmailSettingsTab_EmailSettings.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEmailSettingsTab_EmailSettings.Size = New System.Drawing.Size(941, 575)
            Me.TabControlPanelEmailSettingsTab_EmailSettings.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelEmailSettingsTab_EmailSettings.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmailSettingsTab_EmailSettings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEmailSettingsTab_EmailSettings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEmailSettingsTab_EmailSettings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEmailSettingsTab_EmailSettings.Style.GradientAngle = 90
            Me.TabControlPanelEmailSettingsTab_EmailSettings.TabIndex = 3
            Me.TabControlPanelEmailSettingsTab_EmailSettings.TabItem = Me.TabItemSystemAndAlertOptions_EmailSettingsTab
            '
            'GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings
            '
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.Controls.Add(Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts)
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.Controls.Add(Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts)
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.Controls.Add(Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod)
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.Controls.Add(Me.NumericInputPOP3EmailListenerSettings_PortNumber)
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.Controls.Add(Me.RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol)
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.Controls.Add(Me.TextBoxPOP3EmailListenerSettings_ServerAddress)
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.Controls.Add(Me.RadioButtonControlPOP3EmailListenerSettings_UseTLS)
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.Controls.Add(Me.RadioButtonControlPOP3EmailListenerSettings_UseSSL)
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.Controls.Add(Me.LabelPOP3EmailListenerSettings_ServerAddress)
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.Controls.Add(Me.LabelPOP3EmailListenerSettings_PortNumber)
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.Controls.Add(Me.LabelPOP3EmailListenerSettings_AuthenticationMethod)
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.Location = New System.Drawing.Point(6, 237)
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.Name = "GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings"
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.Size = New System.Drawing.Size(931, 335)
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.TabIndex = 1
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.Text = "POP3 / E-Mail Listener Settings"
            '
            'DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts
            '
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.AllowDragAndDrop = False
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.AutoFilterLookupColumns = False
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.AutoloadRepositoryDatasource = True
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.AutoUpdateViewCaption = True
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.ItemDescription = "Automated Assignment Account(s)"
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.Location = New System.Drawing.Point(5, 225)
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.MultiSelect = False
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.Name = "DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts"
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.RunStandardValidation = True
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.Size = New System.Drawing.Size(921, 105)
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.TabIndex = 9
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.UseEmbeddedNavigator = False
            Me.DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts.ViewCaptionHeight = -1
            '
            'DataGridViewSystemAndAlertOptions_POP3EmailAccounts
            '
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.AllowDragAndDrop = False
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.AutoFilterLookupColumns = False
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.AutoloadRepositoryDatasource = True
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.AutoUpdateViewCaption = True
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.DataSource = Nothing
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.ItemDescription = "Item(s)"
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.Location = New System.Drawing.Point(6, 101)
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.MultiSelect = True
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.Name = "DataGridViewSystemAndAlertOptions_POP3EmailAccounts"
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.RunStandardValidation = True
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.Size = New System.Drawing.Size(920, 128)
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.TabIndex = 2
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.UseEmbeddedNavigator = False
            Me.DataGridViewSystemAndAlertOptions_POP3EmailAccounts.ViewCaptionHeight = -1
            '
            'ComboBoxPOP3EmailListenerSettings_AuthenticationMethod
            '
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.AutoFindItemInDataSource = False
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.BookmarkingEnabled = False
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.ClientCode = ""
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.POP3AuthenticationMethod
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.DisableMouseWheel = False
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.DisplayMember = "Description"
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.DisplayName = ""
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.DivisionCode = ""
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.FocusHighlightEnabled = True
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.FormattingEnabled = True
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.Location = New System.Drawing.Point(152, 25)
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.Name = "ComboBoxPOP3EmailListenerSettings_AuthenticationMethod"
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.ReadOnly = False
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.SecurityEnabled = True
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.Size = New System.Drawing.Size(774, 22)
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.TabIndex = 1
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.TabOnEnter = True
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.ValueMember = "Code"
            Me.ComboBoxPOP3EmailListenerSettings_AuthenticationMethod.WatermarkText = "Select Authentication Method"
            '
            'NumericInputPOP3EmailListenerSettings_PortNumber
            '
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.EnterMoveNextControl = True
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.Location = New System.Drawing.Point(152, 50)
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.Name = "NumericInputPOP3EmailListenerSettings_PortNumber"
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.Properties.IsFloatValue = False
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.Properties.Mask.EditMask = "f0"
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.Properties.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.SecurityEnabled = True
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.Size = New System.Drawing.Size(64, 20)
            Me.NumericInputPOP3EmailListenerSettings_PortNumber.TabIndex = 3
            '
            'RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol
            '
            Me.RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol.Location = New System.Drawing.Point(381, 50)
            Me.RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol.Name = "RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol"
            Me.RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol.SecurityEnabled = True
            Me.RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol.Size = New System.Drawing.Size(126, 20)
            Me.RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol.TabIndex = 6
            Me.RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol.TabOnEnter = True
            Me.RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol.TabStop = False
            Me.RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol.Text = "No Secure Protocol"
            '
            'TextBoxPOP3EmailListenerSettings_ServerAddress
            '
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.Border.Class = "TextBoxBorder"
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.CheckSpellingOnValidate = False
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.FocusHighlightEnabled = True
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.ForeColor = System.Drawing.Color.Black
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.Location = New System.Drawing.Point(152, 75)
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.MaxFileSize = CType(0, Long)
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.Name = "TextBoxPOP3EmailListenerSettings_ServerAddress"
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.SecurityEnabled = True
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.Size = New System.Drawing.Size(774, 21)
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.StartingFolderName = Nothing
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.TabIndex = 8
            Me.TextBoxPOP3EmailListenerSettings_ServerAddress.TabOnEnter = True
            '
            'RadioButtonControlPOP3EmailListenerSettings_UseTLS
            '
            Me.RadioButtonControlPOP3EmailListenerSettings_UseTLS.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlPOP3EmailListenerSettings_UseTLS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlPOP3EmailListenerSettings_UseTLS.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlPOP3EmailListenerSettings_UseTLS.Location = New System.Drawing.Point(306, 50)
            Me.RadioButtonControlPOP3EmailListenerSettings_UseTLS.Name = "RadioButtonControlPOP3EmailListenerSettings_UseTLS"
            Me.RadioButtonControlPOP3EmailListenerSettings_UseTLS.SecurityEnabled = True
            Me.RadioButtonControlPOP3EmailListenerSettings_UseTLS.Size = New System.Drawing.Size(69, 20)
            Me.RadioButtonControlPOP3EmailListenerSettings_UseTLS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlPOP3EmailListenerSettings_UseTLS.TabIndex = 5
            Me.RadioButtonControlPOP3EmailListenerSettings_UseTLS.TabOnEnter = True
            Me.RadioButtonControlPOP3EmailListenerSettings_UseTLS.TabStop = False
            Me.RadioButtonControlPOP3EmailListenerSettings_UseTLS.Text = "Use TLS"
            '
            'RadioButtonControlPOP3EmailListenerSettings_UseSSL
            '
            Me.RadioButtonControlPOP3EmailListenerSettings_UseSSL.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlPOP3EmailListenerSettings_UseSSL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlPOP3EmailListenerSettings_UseSSL.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlPOP3EmailListenerSettings_UseSSL.Location = New System.Drawing.Point(230, 50)
            Me.RadioButtonControlPOP3EmailListenerSettings_UseSSL.Name = "RadioButtonControlPOP3EmailListenerSettings_UseSSL"
            Me.RadioButtonControlPOP3EmailListenerSettings_UseSSL.SecurityEnabled = True
            Me.RadioButtonControlPOP3EmailListenerSettings_UseSSL.Size = New System.Drawing.Size(70, 20)
            Me.RadioButtonControlPOP3EmailListenerSettings_UseSSL.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlPOP3EmailListenerSettings_UseSSL.TabIndex = 4
            Me.RadioButtonControlPOP3EmailListenerSettings_UseSSL.TabOnEnter = True
            Me.RadioButtonControlPOP3EmailListenerSettings_UseSSL.TabStop = False
            Me.RadioButtonControlPOP3EmailListenerSettings_UseSSL.Text = "Use SSL"
            '
            'LabelPOP3EmailListenerSettings_ServerAddress
            '
            Me.LabelPOP3EmailListenerSettings_ServerAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPOP3EmailListenerSettings_ServerAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPOP3EmailListenerSettings_ServerAddress.Location = New System.Drawing.Point(6, 75)
            Me.LabelPOP3EmailListenerSettings_ServerAddress.Name = "LabelPOP3EmailListenerSettings_ServerAddress"
            Me.LabelPOP3EmailListenerSettings_ServerAddress.Size = New System.Drawing.Size(140, 17)
            Me.LabelPOP3EmailListenerSettings_ServerAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPOP3EmailListenerSettings_ServerAddress.TabIndex = 7
            Me.LabelPOP3EmailListenerSettings_ServerAddress.Text = "POP3 Server Address:"
            '
            'LabelPOP3EmailListenerSettings_PortNumber
            '
            Me.LabelPOP3EmailListenerSettings_PortNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPOP3EmailListenerSettings_PortNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPOP3EmailListenerSettings_PortNumber.Location = New System.Drawing.Point(6, 50)
            Me.LabelPOP3EmailListenerSettings_PortNumber.Name = "LabelPOP3EmailListenerSettings_PortNumber"
            Me.LabelPOP3EmailListenerSettings_PortNumber.Size = New System.Drawing.Size(140, 20)
            Me.LabelPOP3EmailListenerSettings_PortNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPOP3EmailListenerSettings_PortNumber.TabIndex = 2
            Me.LabelPOP3EmailListenerSettings_PortNumber.Text = "Port Number:"
            '
            'LabelPOP3EmailListenerSettings_AuthenticationMethod
            '
            Me.LabelPOP3EmailListenerSettings_AuthenticationMethod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPOP3EmailListenerSettings_AuthenticationMethod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPOP3EmailListenerSettings_AuthenticationMethod.Location = New System.Drawing.Point(6, 25)
            Me.LabelPOP3EmailListenerSettings_AuthenticationMethod.Name = "LabelPOP3EmailListenerSettings_AuthenticationMethod"
            Me.LabelPOP3EmailListenerSettings_AuthenticationMethod.Size = New System.Drawing.Size(140, 20)
            Me.LabelPOP3EmailListenerSettings_AuthenticationMethod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPOP3EmailListenerSettings_AuthenticationMethod.TabIndex = 0
            Me.LabelPOP3EmailListenerSettings_AuthenticationMethod.Text = "Authentication Method:"
            '
            'GroupBoxSystemAndAlertOptions_SMTPEmailSetup
            '
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.TextBoxSMTPEmailSetup_DefaultPassword)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.LabelSMTPEmailSetup_OAuth2)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.ComboBoxSMTPEmailSetup_AuthenticationMethod)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.NumericInputSMTPEmailSetup_PortNumber)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.TextBoxSMTPEmailSetup_ReplyToAddress)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.TextBoxSMTPEmailSetup_DefaultUserName)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.TextBoxSMTPEmailSetup_SenderAddress)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.RadioButtonControlSMTPEmailSetup_NoSecureProtocol)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.TextBoxSMTPEmailSetup_OutgoingServerAddress)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.RadioButtonControlSMTPEmailSetup_UseTLS)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.LabelSMTPEmailSetup_ReplyToAddress)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.LabelSMTPEmailSetup_DefaultSenderPassword)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.RadioButtonControlSMTPEmailSetup_UseSSL)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.LabelSMTPEmailSetup_DefaultUserName)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.LabelSMTPEmailSetup_SenderAddress)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.LabelSMTPEmailSetup_OutgoingServerAddress)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.LabelSMTPEmailSetup_PortNumber)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Controls.Add(Me.LabelSMTPEmailSetup_AuthenticationMethod)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Location = New System.Drawing.Point(6, 6)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Name = "GroupBoxSystemAndAlertOptions_SMTPEmailSetup"
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Size = New System.Drawing.Size(931, 225)
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.TabIndex = 0
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.Text = "SMTP E-Mail Setup"
            '
            'TextBoxSMTPEmailSetup_DefaultPassword
            '
            Me.TextBoxSMTPEmailSetup_DefaultPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSMTPEmailSetup_DefaultPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSMTPEmailSetup_DefaultPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxSMTPEmailSetup_DefaultPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSMTPEmailSetup_DefaultPassword.CheckSpellingOnValidate = False
            Me.TextBoxSMTPEmailSetup_DefaultPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSMTPEmailSetup_DefaultPassword.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxSMTPEmailSetup_DefaultPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSMTPEmailSetup_DefaultPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSMTPEmailSetup_DefaultPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSMTPEmailSetup_DefaultPassword.FocusHighlightEnabled = True
            Me.TextBoxSMTPEmailSetup_DefaultPassword.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSMTPEmailSetup_DefaultPassword.Location = New System.Drawing.Point(152, 149)
            Me.TextBoxSMTPEmailSetup_DefaultPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxSMTPEmailSetup_DefaultPassword.Name = "TextBoxSMTPEmailSetup_DefaultPassword"
            Me.TextBoxSMTPEmailSetup_DefaultPassword.SecurityEnabled = True
            Me.TextBoxSMTPEmailSetup_DefaultPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSMTPEmailSetup_DefaultPassword.Size = New System.Drawing.Size(774, 21)
            Me.TextBoxSMTPEmailSetup_DefaultPassword.StartingFolderName = Nothing
            Me.TextBoxSMTPEmailSetup_DefaultPassword.TabIndex = 14
            Me.TextBoxSMTPEmailSetup_DefaultPassword.TabOnEnter = True
            Me.TextBoxSMTPEmailSetup_DefaultPassword.UseSystemPasswordChar = True
            '
            'LabelSMTPEmailSetup_OAuth2
            '
            Me.LabelSMTPEmailSetup_OAuth2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSMTPEmailSetup_OAuth2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSMTPEmailSetup_OAuth2.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.LabelSMTPEmailSetup_OAuth2.Location = New System.Drawing.Point(152, 149)
            Me.LabelSMTPEmailSetup_OAuth2.Name = "LabelSMTPEmailSetup_OAuth2"
            Me.LabelSMTPEmailSetup_OAuth2.Size = New System.Drawing.Size(774, 21)
            Me.LabelSMTPEmailSetup_OAuth2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSMTPEmailSetup_OAuth2.TabIndex = 14
            Me.LabelSMTPEmailSetup_OAuth2.Text = "Email Account is {0}. <a name=""{1}"">{2}</a>"
            '
            'ComboBoxSMTPEmailSetup_AuthenticationMethod
            '
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.AutoFindItemInDataSource = False
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.BookmarkingEnabled = False
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.ClientCode = ""
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.POP3AuthenticationMethod
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.DisableMouseWheel = False
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.DisplayMember = "Description"
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.DisplayName = ""
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.DivisionCode = ""
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.FocusHighlightEnabled = True
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.FormattingEnabled = True
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.ItemHeight = 16
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.Location = New System.Drawing.Point(152, 25)
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.Name = "ComboBoxSMTPEmailSetup_AuthenticationMethod"
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.ReadOnly = False
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.SecurityEnabled = True
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.Size = New System.Drawing.Size(774, 22)
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.TabIndex = 1
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.TabOnEnter = True
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.ValueMember = "Code"
            Me.ComboBoxSMTPEmailSetup_AuthenticationMethod.WatermarkText = "Select Authentication Method"
            '
            'NumericInputSMTPEmailSetup_PortNumber
            '
            Me.NumericInputSMTPEmailSetup_PortNumber.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputSMTPEmailSetup_PortNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputSMTPEmailSetup_PortNumber.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputSMTPEmailSetup_PortNumber.EnterMoveNextControl = True
            Me.NumericInputSMTPEmailSetup_PortNumber.Location = New System.Drawing.Point(152, 50)
            Me.NumericInputSMTPEmailSetup_PortNumber.Name = "NumericInputSMTPEmailSetup_PortNumber"
            Me.NumericInputSMTPEmailSetup_PortNumber.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputSMTPEmailSetup_PortNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSMTPEmailSetup_PortNumber.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputSMTPEmailSetup_PortNumber.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSMTPEmailSetup_PortNumber.Properties.IsFloatValue = False
            Me.NumericInputSMTPEmailSetup_PortNumber.Properties.Mask.EditMask = "f0"
            Me.NumericInputSMTPEmailSetup_PortNumber.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputSMTPEmailSetup_PortNumber.Properties.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
            Me.NumericInputSMTPEmailSetup_PortNumber.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputSMTPEmailSetup_PortNumber.SecurityEnabled = True
            Me.NumericInputSMTPEmailSetup_PortNumber.Size = New System.Drawing.Size(64, 20)
            Me.NumericInputSMTPEmailSetup_PortNumber.TabIndex = 3
            '
            'CheckBoxSMTPEmailSetup_EnablePDFAttachments
            '
            '
            '
            '
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.CheckValue = CType(0, Short)
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.CheckValueChecked = CType(1, Short)
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.ChildControls = CType(resources.GetObject("CheckBoxSMTPEmailSetup_EnablePDFAttachments.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.Location = New System.Drawing.Point(276, 200)
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.Name = "CheckBoxSMTPEmailSetup_EnablePDFAttachments"
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.OldestSibling = Nothing
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.SecurityEnabled = True
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.SiblingControls = CType(resources.GetObject("CheckBoxSMTPEmailSetup_EnablePDFAttachments.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.Size = New System.Drawing.Size(269, 20)
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.TabIndex = 18
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.TabOnEnter = True
            Me.CheckBoxSMTPEmailSetup_EnablePDFAttachments.Text = "Enable PDF E-Mail Attachments"
            '
            'TextBoxSMTPEmailSetup_ReplyToAddress
            '
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.Border.Class = "TextBoxBorder"
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.CheckSpellingOnValidate = False
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Email
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.FocusHighlightEnabled = True
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.Location = New System.Drawing.Point(152, 174)
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.MaxFileSize = CType(0, Long)
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.Name = "TextBoxSMTPEmailSetup_ReplyToAddress"
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.SecurityEnabled = True
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.Size = New System.Drawing.Size(774, 21)
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.StartingFolderName = Nothing
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.TabIndex = 16
            Me.TextBoxSMTPEmailSetup_ReplyToAddress.TabOnEnter = True
            '
            'CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin
            '
            '
            '
            '
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.CheckValue = CType(0, Short)
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.CheckValueChecked = CType(1, Short)
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.ChildControls = CType(resources.GetObject("CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.Location = New System.Drawing.Point(6, 200)
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.Name = "CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin"
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.OldestSibling = Nothing
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.SecurityEnabled = True
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.SiblingControls = CType(resources.GetObject("CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.Size = New System.Drawing.Size(269, 20)
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.TabIndex = 17
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.TabOnEnter = True
            Me.CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin.Text = "Use Employee SMTP Login && 'From' Address"
            '
            'TextBoxSMTPEmailSetup_DefaultUserName
            '
            Me.TextBoxSMTPEmailSetup_DefaultUserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSMTPEmailSetup_DefaultUserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSMTPEmailSetup_DefaultUserName.Border.Class = "TextBoxBorder"
            Me.TextBoxSMTPEmailSetup_DefaultUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSMTPEmailSetup_DefaultUserName.CheckSpellingOnValidate = False
            Me.TextBoxSMTPEmailSetup_DefaultUserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSMTPEmailSetup_DefaultUserName.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxSMTPEmailSetup_DefaultUserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSMTPEmailSetup_DefaultUserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSMTPEmailSetup_DefaultUserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSMTPEmailSetup_DefaultUserName.FocusHighlightEnabled = True
            Me.TextBoxSMTPEmailSetup_DefaultUserName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSMTPEmailSetup_DefaultUserName.Location = New System.Drawing.Point(152, 125)
            Me.TextBoxSMTPEmailSetup_DefaultUserName.MaxFileSize = CType(0, Long)
            Me.TextBoxSMTPEmailSetup_DefaultUserName.Name = "TextBoxSMTPEmailSetup_DefaultUserName"
            Me.TextBoxSMTPEmailSetup_DefaultUserName.SecurityEnabled = True
            Me.TextBoxSMTPEmailSetup_DefaultUserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSMTPEmailSetup_DefaultUserName.Size = New System.Drawing.Size(774, 21)
            Me.TextBoxSMTPEmailSetup_DefaultUserName.StartingFolderName = Nothing
            Me.TextBoxSMTPEmailSetup_DefaultUserName.TabIndex = 12
            Me.TextBoxSMTPEmailSetup_DefaultUserName.TabOnEnter = True
            '
            'TextBoxSMTPEmailSetup_SenderAddress
            '
            Me.TextBoxSMTPEmailSetup_SenderAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSMTPEmailSetup_SenderAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSMTPEmailSetup_SenderAddress.Border.Class = "TextBoxBorder"
            Me.TextBoxSMTPEmailSetup_SenderAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSMTPEmailSetup_SenderAddress.CheckSpellingOnValidate = False
            Me.TextBoxSMTPEmailSetup_SenderAddress.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Email
            Me.TextBoxSMTPEmailSetup_SenderAddress.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxSMTPEmailSetup_SenderAddress.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSMTPEmailSetup_SenderAddress.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSMTPEmailSetup_SenderAddress.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSMTPEmailSetup_SenderAddress.FocusHighlightEnabled = True
            Me.TextBoxSMTPEmailSetup_SenderAddress.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSMTPEmailSetup_SenderAddress.Location = New System.Drawing.Point(152, 100)
            Me.TextBoxSMTPEmailSetup_SenderAddress.MaxFileSize = CType(0, Long)
            Me.TextBoxSMTPEmailSetup_SenderAddress.Name = "TextBoxSMTPEmailSetup_SenderAddress"
            Me.TextBoxSMTPEmailSetup_SenderAddress.SecurityEnabled = True
            Me.TextBoxSMTPEmailSetup_SenderAddress.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSMTPEmailSetup_SenderAddress.Size = New System.Drawing.Size(774, 21)
            Me.TextBoxSMTPEmailSetup_SenderAddress.StartingFolderName = Nothing
            Me.TextBoxSMTPEmailSetup_SenderAddress.TabIndex = 10
            Me.TextBoxSMTPEmailSetup_SenderAddress.TabOnEnter = True
            '
            'RadioButtonControlSMTPEmailSetup_NoSecureProtocol
            '
            Me.RadioButtonControlSMTPEmailSetup_NoSecureProtocol.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlSMTPEmailSetup_NoSecureProtocol.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlSMTPEmailSetup_NoSecureProtocol.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlSMTPEmailSetup_NoSecureProtocol.Location = New System.Drawing.Point(381, 50)
            Me.RadioButtonControlSMTPEmailSetup_NoSecureProtocol.Name = "RadioButtonControlSMTPEmailSetup_NoSecureProtocol"
            Me.RadioButtonControlSMTPEmailSetup_NoSecureProtocol.SecurityEnabled = True
            Me.RadioButtonControlSMTPEmailSetup_NoSecureProtocol.Size = New System.Drawing.Size(126, 20)
            Me.RadioButtonControlSMTPEmailSetup_NoSecureProtocol.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlSMTPEmailSetup_NoSecureProtocol.TabIndex = 6
            Me.RadioButtonControlSMTPEmailSetup_NoSecureProtocol.TabOnEnter = True
            Me.RadioButtonControlSMTPEmailSetup_NoSecureProtocol.TabStop = False
            Me.RadioButtonControlSMTPEmailSetup_NoSecureProtocol.Text = "No Secure Protocol"
            '
            'TextBoxSMTPEmailSetup_OutgoingServerAddress
            '
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.Border.Class = "TextBoxBorder"
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.CheckSpellingOnValidate = False
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.FocusHighlightEnabled = True
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.Location = New System.Drawing.Point(152, 75)
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.MaxFileSize = CType(0, Long)
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.Name = "TextBoxSMTPEmailSetup_OutgoingServerAddress"
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.SecurityEnabled = True
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.Size = New System.Drawing.Size(774, 21)
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.StartingFolderName = Nothing
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.TabIndex = 8
            Me.TextBoxSMTPEmailSetup_OutgoingServerAddress.TabOnEnter = True
            '
            'RadioButtonControlSMTPEmailSetup_UseTLS
            '
            Me.RadioButtonControlSMTPEmailSetup_UseTLS.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlSMTPEmailSetup_UseTLS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlSMTPEmailSetup_UseTLS.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlSMTPEmailSetup_UseTLS.Location = New System.Drawing.Point(306, 50)
            Me.RadioButtonControlSMTPEmailSetup_UseTLS.Name = "RadioButtonControlSMTPEmailSetup_UseTLS"
            Me.RadioButtonControlSMTPEmailSetup_UseTLS.SecurityEnabled = True
            Me.RadioButtonControlSMTPEmailSetup_UseTLS.Size = New System.Drawing.Size(69, 20)
            Me.RadioButtonControlSMTPEmailSetup_UseTLS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlSMTPEmailSetup_UseTLS.TabIndex = 5
            Me.RadioButtonControlSMTPEmailSetup_UseTLS.TabOnEnter = True
            Me.RadioButtonControlSMTPEmailSetup_UseTLS.TabStop = False
            Me.RadioButtonControlSMTPEmailSetup_UseTLS.Text = "Use TLS"
            '
            'LabelSMTPEmailSetup_ReplyToAddress
            '
            Me.LabelSMTPEmailSetup_ReplyToAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSMTPEmailSetup_ReplyToAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSMTPEmailSetup_ReplyToAddress.Location = New System.Drawing.Point(6, 175)
            Me.LabelSMTPEmailSetup_ReplyToAddress.Name = "LabelSMTPEmailSetup_ReplyToAddress"
            Me.LabelSMTPEmailSetup_ReplyToAddress.Size = New System.Drawing.Size(140, 20)
            Me.LabelSMTPEmailSetup_ReplyToAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSMTPEmailSetup_ReplyToAddress.TabIndex = 15
            Me.LabelSMTPEmailSetup_ReplyToAddress.Text = "Default Reply To Address:"
            '
            'LabelSMTPEmailSetup_DefaultSenderPassword
            '
            Me.LabelSMTPEmailSetup_DefaultSenderPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSMTPEmailSetup_DefaultSenderPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSMTPEmailSetup_DefaultSenderPassword.Location = New System.Drawing.Point(6, 150)
            Me.LabelSMTPEmailSetup_DefaultSenderPassword.Name = "LabelSMTPEmailSetup_DefaultSenderPassword"
            Me.LabelSMTPEmailSetup_DefaultSenderPassword.Size = New System.Drawing.Size(140, 20)
            Me.LabelSMTPEmailSetup_DefaultSenderPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSMTPEmailSetup_DefaultSenderPassword.TabIndex = 13
            Me.LabelSMTPEmailSetup_DefaultSenderPassword.Text = "Default Sender Password:"
            '
            'RadioButtonControlSMTPEmailSetup_UseSSL
            '
            Me.RadioButtonControlSMTPEmailSetup_UseSSL.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlSMTPEmailSetup_UseSSL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlSMTPEmailSetup_UseSSL.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlSMTPEmailSetup_UseSSL.Location = New System.Drawing.Point(230, 50)
            Me.RadioButtonControlSMTPEmailSetup_UseSSL.Name = "RadioButtonControlSMTPEmailSetup_UseSSL"
            Me.RadioButtonControlSMTPEmailSetup_UseSSL.SecurityEnabled = True
            Me.RadioButtonControlSMTPEmailSetup_UseSSL.Size = New System.Drawing.Size(70, 20)
            Me.RadioButtonControlSMTPEmailSetup_UseSSL.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlSMTPEmailSetup_UseSSL.TabIndex = 4
            Me.RadioButtonControlSMTPEmailSetup_UseSSL.TabOnEnter = True
            Me.RadioButtonControlSMTPEmailSetup_UseSSL.TabStop = False
            Me.RadioButtonControlSMTPEmailSetup_UseSSL.Text = "Use SSL"
            '
            'LabelSMTPEmailSetup_DefaultUserName
            '
            Me.LabelSMTPEmailSetup_DefaultUserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSMTPEmailSetup_DefaultUserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSMTPEmailSetup_DefaultUserName.Location = New System.Drawing.Point(6, 125)
            Me.LabelSMTPEmailSetup_DefaultUserName.Name = "LabelSMTPEmailSetup_DefaultUserName"
            Me.LabelSMTPEmailSetup_DefaultUserName.Size = New System.Drawing.Size(140, 20)
            Me.LabelSMTPEmailSetup_DefaultUserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSMTPEmailSetup_DefaultUserName.TabIndex = 11
            Me.LabelSMTPEmailSetup_DefaultUserName.Text = "Default Sender User Name:"
            '
            'LabelSMTPEmailSetup_SenderAddress
            '
            Me.LabelSMTPEmailSetup_SenderAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSMTPEmailSetup_SenderAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSMTPEmailSetup_SenderAddress.Location = New System.Drawing.Point(6, 100)
            Me.LabelSMTPEmailSetup_SenderAddress.Name = "LabelSMTPEmailSetup_SenderAddress"
            Me.LabelSMTPEmailSetup_SenderAddress.Size = New System.Drawing.Size(140, 20)
            Me.LabelSMTPEmailSetup_SenderAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSMTPEmailSetup_SenderAddress.TabIndex = 9
            Me.LabelSMTPEmailSetup_SenderAddress.Text = "Default Sender Address:"
            '
            'LabelSMTPEmailSetup_OutgoingServerAddress
            '
            Me.LabelSMTPEmailSetup_OutgoingServerAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSMTPEmailSetup_OutgoingServerAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSMTPEmailSetup_OutgoingServerAddress.Location = New System.Drawing.Point(6, 75)
            Me.LabelSMTPEmailSetup_OutgoingServerAddress.Name = "LabelSMTPEmailSetup_OutgoingServerAddress"
            Me.LabelSMTPEmailSetup_OutgoingServerAddress.Size = New System.Drawing.Size(140, 20)
            Me.LabelSMTPEmailSetup_OutgoingServerAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSMTPEmailSetup_OutgoingServerAddress.TabIndex = 7
            Me.LabelSMTPEmailSetup_OutgoingServerAddress.Text = "Outgoing Server Address:"
            '
            'LabelSMTPEmailSetup_PortNumber
            '
            Me.LabelSMTPEmailSetup_PortNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSMTPEmailSetup_PortNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSMTPEmailSetup_PortNumber.Location = New System.Drawing.Point(6, 50)
            Me.LabelSMTPEmailSetup_PortNumber.Name = "LabelSMTPEmailSetup_PortNumber"
            Me.LabelSMTPEmailSetup_PortNumber.Size = New System.Drawing.Size(140, 20)
            Me.LabelSMTPEmailSetup_PortNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSMTPEmailSetup_PortNumber.TabIndex = 2
            Me.LabelSMTPEmailSetup_PortNumber.Text = "Port Number:"
            '
            'LabelSMTPEmailSetup_AuthenticationMethod
            '
            Me.LabelSMTPEmailSetup_AuthenticationMethod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSMTPEmailSetup_AuthenticationMethod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSMTPEmailSetup_AuthenticationMethod.Location = New System.Drawing.Point(6, 25)
            Me.LabelSMTPEmailSetup_AuthenticationMethod.Name = "LabelSMTPEmailSetup_AuthenticationMethod"
            Me.LabelSMTPEmailSetup_AuthenticationMethod.Size = New System.Drawing.Size(140, 20)
            Me.LabelSMTPEmailSetup_AuthenticationMethod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSMTPEmailSetup_AuthenticationMethod.TabIndex = 0
            Me.LabelSMTPEmailSetup_AuthenticationMethod.Text = "Authentication Method:"
            '
            'TabItemSystemAndAlertOptions_EmailSettingsTab
            '
            Me.TabItemSystemAndAlertOptions_EmailSettingsTab.AttachedControl = Me.TabControlPanelEmailSettingsTab_EmailSettings
            Me.TabItemSystemAndAlertOptions_EmailSettingsTab.Name = "TabItemSystemAndAlertOptions_EmailSettingsTab"
            Me.TabItemSystemAndAlertOptions_EmailSettingsTab.Text = "Email Settings"
            '
            'TabItemAgencySetup_SystemAndAlertOptions
            '
            Me.TabItemAgencySetup_SystemAndAlertOptions.AttachedControl = Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions
            Me.TabItemAgencySetup_SystemAndAlertOptions.Name = "TabItemAgencySetup_SystemAndAlertOptions"
            Me.TabItemAgencySetup_SystemAndAlertOptions.Text = "System && Alert Options"
            '
            'TabControlPanelInformationTab_Information
            '
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.GroupBoxInformation_AgencyInformation)
            Me.TabControlPanelInformationTab_Information.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelInformationTab_Information.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInformationTab_Information.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInformationTab_Information.Name = "TabControlPanelInformationTab_Information"
            Me.TabControlPanelInformationTab_Information.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInformationTab_Information.Size = New System.Drawing.Size(950, 627)
            Me.TabControlPanelInformationTab_Information.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelInformationTab_Information.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInformationTab_Information.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInformationTab_Information.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInformationTab_Information.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInformationTab_Information.Style.GradientAngle = 90
            Me.TabControlPanelInformationTab_Information.TabIndex = 1
            Me.TabControlPanelInformationTab_Information.TabItem = Me.TabItemAgencySetup_InformationTab
            '
            'GroupBoxInformation_AgencyInformation
            '
            Me.GroupBoxInformation_AgencyInformation.Controls.Add(Me.AddressControlAgencyInformation_Address)
            Me.GroupBoxInformation_AgencyInformation.Controls.Add(Me.LabelAgencyInformation_Name)
            Me.GroupBoxInformation_AgencyInformation.Controls.Add(Me.TextBoxAgencyInformation_Name)
            Me.GroupBoxInformation_AgencyInformation.Controls.Add(Me.TextBoxAgencyInformation_Phone)
            Me.GroupBoxInformation_AgencyInformation.Controls.Add(Me.LabelAgencyInformation_Phone)
            Me.GroupBoxInformation_AgencyInformation.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxInformation_AgencyInformation.Name = "GroupBoxInformation_AgencyInformation"
            Me.GroupBoxInformation_AgencyInformation.Size = New System.Drawing.Size(366, 264)
            Me.GroupBoxInformation_AgencyInformation.TabIndex = 0
            Me.GroupBoxInformation_AgencyInformation.Text = "Agency Information"
            '
            'AddressControlAgencyInformation_Address
            '
            Me.AddressControlAgencyInformation_Address.Address = Nothing
            Me.AddressControlAgencyInformation_Address.Address2 = Nothing
            Me.AddressControlAgencyInformation_Address.Address3 = Nothing
            Me.AddressControlAgencyInformation_Address.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AddressControlAgencyInformation_Address.City = Nothing
            Me.AddressControlAgencyInformation_Address.Country = Nothing
            Me.AddressControlAgencyInformation_Address.County = Nothing
            Me.AddressControlAgencyInformation_Address.DisableCountry = False
            Me.AddressControlAgencyInformation_Address.DisableCounty = False
            Me.AddressControlAgencyInformation_Address.Location = New System.Drawing.Point(6, 77)
            Me.AddressControlAgencyInformation_Address.Name = "AddressControlAgencyInformation_Address"
            Me.AddressControlAgencyInformation_Address.ReadOnly = False
            Me.AddressControlAgencyInformation_Address.ShowCountry = True
            Me.AddressControlAgencyInformation_Address.ShowCounty = True
            Me.AddressControlAgencyInformation_Address.Size = New System.Drawing.Size(355, 181)
            Me.AddressControlAgencyInformation_Address.State = Nothing
            Me.AddressControlAgencyInformation_Address.TabIndex = 5
            Me.AddressControlAgencyInformation_Address.Title = "Address"
            Me.AddressControlAgencyInformation_Address.Zip = Nothing
            '
            'LabelAgencyInformation_Name
            '
            Me.LabelAgencyInformation_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAgencyInformation_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAgencyInformation_Name.Location = New System.Drawing.Point(6, 25)
            Me.LabelAgencyInformation_Name.Name = "LabelAgencyInformation_Name"
            Me.LabelAgencyInformation_Name.Size = New System.Drawing.Size(51, 20)
            Me.LabelAgencyInformation_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAgencyInformation_Name.TabIndex = 1
            Me.LabelAgencyInformation_Name.Text = "Name:"
            '
            'TextBoxAgencyInformation_Name
            '
            Me.TextBoxAgencyInformation_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxAgencyInformation_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxAgencyInformation_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxAgencyInformation_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAgencyInformation_Name.CheckSpellingOnValidate = False
            Me.TextBoxAgencyInformation_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAgencyInformation_Name.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxAgencyInformation_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAgencyInformation_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAgencyInformation_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAgencyInformation_Name.FocusHighlightEnabled = True
            Me.TextBoxAgencyInformation_Name.ForeColor = System.Drawing.Color.Black
            Me.TextBoxAgencyInformation_Name.Location = New System.Drawing.Point(63, 26)
            Me.TextBoxAgencyInformation_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxAgencyInformation_Name.Name = "TextBoxAgencyInformation_Name"
            Me.TextBoxAgencyInformation_Name.SecurityEnabled = True
            Me.TextBoxAgencyInformation_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAgencyInformation_Name.Size = New System.Drawing.Size(298, 21)
            Me.TextBoxAgencyInformation_Name.StartingFolderName = Nothing
            Me.TextBoxAgencyInformation_Name.TabIndex = 2
            Me.TextBoxAgencyInformation_Name.TabOnEnter = True
            '
            'TextBoxAgencyInformation_Phone
            '
            Me.TextBoxAgencyInformation_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxAgencyInformation_Phone.Border.Class = "TextBoxBorder"
            Me.TextBoxAgencyInformation_Phone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAgencyInformation_Phone.CheckSpellingOnValidate = False
            Me.TextBoxAgencyInformation_Phone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAgencyInformation_Phone.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxAgencyInformation_Phone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAgencyInformation_Phone.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAgencyInformation_Phone.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAgencyInformation_Phone.FocusHighlightEnabled = True
            Me.TextBoxAgencyInformation_Phone.ForeColor = System.Drawing.Color.Black
            Me.TextBoxAgencyInformation_Phone.Location = New System.Drawing.Point(63, 51)
            Me.TextBoxAgencyInformation_Phone.MaxFileSize = CType(0, Long)
            Me.TextBoxAgencyInformation_Phone.Name = "TextBoxAgencyInformation_Phone"
            Me.TextBoxAgencyInformation_Phone.SecurityEnabled = True
            Me.TextBoxAgencyInformation_Phone.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAgencyInformation_Phone.Size = New System.Drawing.Size(188, 21)
            Me.TextBoxAgencyInformation_Phone.StartingFolderName = Nothing
            Me.TextBoxAgencyInformation_Phone.TabIndex = 4
            Me.TextBoxAgencyInformation_Phone.TabOnEnter = True
            '
            'LabelAgencyInformation_Phone
            '
            Me.LabelAgencyInformation_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAgencyInformation_Phone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAgencyInformation_Phone.Location = New System.Drawing.Point(6, 51)
            Me.LabelAgencyInformation_Phone.Name = "LabelAgencyInformation_Phone"
            Me.LabelAgencyInformation_Phone.Size = New System.Drawing.Size(51, 20)
            Me.LabelAgencyInformation_Phone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAgencyInformation_Phone.TabIndex = 3
            Me.LabelAgencyInformation_Phone.Text = "Phone:"
            '
            'TabItemAgencySetup_InformationTab
            '
            Me.TabItemAgencySetup_InformationTab.AttachedControl = Me.TabControlPanelInformationTab_Information
            Me.TabItemAgencySetup_InformationTab.Name = "TabItemAgencySetup_InformationTab"
            Me.TabItemAgencySetup_InformationTab.Text = "Information"
            '
            'TabControlPanelMediaOptionsTab_MediaOptions
            '
            Me.TabControlPanelMediaOptionsTab_MediaOptions.AutoScroll = True
            Me.TabControlPanelMediaOptionsTab_MediaOptions.Controls.Add(Me.TabControlMediaOptions_MediaOptions)
            Me.TabControlPanelMediaOptionsTab_MediaOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMediaOptionsTab_MediaOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaOptionsTab_MediaOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaOptionsTab_MediaOptions.Name = "TabControlPanelMediaOptionsTab_MediaOptions"
            Me.TabControlPanelMediaOptionsTab_MediaOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaOptionsTab_MediaOptions.Size = New System.Drawing.Size(950, 612)
            Me.TabControlPanelMediaOptionsTab_MediaOptions.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMediaOptionsTab_MediaOptions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaOptionsTab_MediaOptions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaOptionsTab_MediaOptions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaOptionsTab_MediaOptions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaOptionsTab_MediaOptions.Style.GradientAngle = 90
            Me.TabControlPanelMediaOptionsTab_MediaOptions.TabIndex = 6
            Me.TabControlPanelMediaOptionsTab_MediaOptions.TabItem = Me.TabItemAgencySetup_MediaOptionsTab
            '
            'TabControlMediaOptions_MediaOptions
            '
            Me.TabControlMediaOptions_MediaOptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlMediaOptions_MediaOptions.BackColor = System.Drawing.Color.White
            Me.TabControlMediaOptions_MediaOptions.CanReorderTabs = False
            Me.TabControlMediaOptions_MediaOptions.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlMediaOptions_MediaOptions.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlMediaOptions_MediaOptions.Controls.Add(Me.TabControlPanelFooterCommentsTab_FooterComments)
            Me.TabControlMediaOptions_MediaOptions.Controls.Add(Me.TabControlPanelSettingsTab_Settings)
            Me.TabControlMediaOptions_MediaOptions.Controls.Add(Me.TabControlPanelAdServingTab_AdServing)
            Me.TabControlMediaOptions_MediaOptions.Controls.Add(Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms)
            Me.TabControlMediaOptions_MediaOptions.ForeColor = System.Drawing.Color.Black
            Me.TabControlMediaOptions_MediaOptions.Location = New System.Drawing.Point(4, 4)
            Me.TabControlMediaOptions_MediaOptions.Name = "TabControlMediaOptions_MediaOptions"
            Me.TabControlMediaOptions_MediaOptions.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlMediaOptions_MediaOptions.SelectedTabIndex = 0
            Me.TabControlMediaOptions_MediaOptions.Size = New System.Drawing.Size(941, 604)
            Me.TabControlMediaOptions_MediaOptions.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlMediaOptions_MediaOptions.TabIndex = 12
            Me.TabControlMediaOptions_MediaOptions.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlMediaOptions_MediaOptions.Tabs.Add(Me.TabItemMediaOptions_FooterCommentsTab)
            Me.TabControlMediaOptions_MediaOptions.Tabs.Add(Me.TabItemMediaOptions_SettingsTab)
            Me.TabControlMediaOptions_MediaOptions.Tabs.Add(Me.TabItemMediaOptions_SettingsForWebFormTermsTab)
            Me.TabControlMediaOptions_MediaOptions.Tabs.Add(Me.TabItemMediaOptions_AdServing)
            '
            'TabControlPanelFooterCommentsTab_FooterComments
            '
            Me.TabControlPanelFooterCommentsTab_FooterComments.Controls.Add(Me.TabControlFooterComments_FooterComments)
            Me.TabControlPanelFooterCommentsTab_FooterComments.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelFooterCommentsTab_FooterComments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelFooterCommentsTab_FooterComments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelFooterCommentsTab_FooterComments.Name = "TabControlPanelFooterCommentsTab_FooterComments"
            Me.TabControlPanelFooterCommentsTab_FooterComments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelFooterCommentsTab_FooterComments.Size = New System.Drawing.Size(941, 577)
            Me.TabControlPanelFooterCommentsTab_FooterComments.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelFooterCommentsTab_FooterComments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelFooterCommentsTab_FooterComments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelFooterCommentsTab_FooterComments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelFooterCommentsTab_FooterComments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelFooterCommentsTab_FooterComments.Style.GradientAngle = 90
            Me.TabControlPanelFooterCommentsTab_FooterComments.TabIndex = 2
            Me.TabControlPanelFooterCommentsTab_FooterComments.TabItem = Me.TabItemMediaOptions_FooterCommentsTab
            '
            'TabControlFooterComments_FooterComments
            '
            Me.TabControlFooterComments_FooterComments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlFooterComments_FooterComments.BackColor = System.Drawing.Color.White
            Me.TabControlFooterComments_FooterComments.CanReorderTabs = False
            Me.TabControlFooterComments_FooterComments.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlFooterComments_FooterComments.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlFooterComments_FooterComments.Controls.Add(Me.TabControlPanelNewspaperTab_Newspaper)
            Me.TabControlFooterComments_FooterComments.Controls.Add(Me.TabControlPanelInternetTab_Internet)
            Me.TabControlFooterComments_FooterComments.Controls.Add(Me.TabControlPanelMagazineTab_Magazine)
            Me.TabControlFooterComments_FooterComments.Controls.Add(Me.TabControlPanelTelevisionTab_Television)
            Me.TabControlFooterComments_FooterComments.Controls.Add(Me.TabControlPanelRadioTab_Radio)
            Me.TabControlFooterComments_FooterComments.Controls.Add(Me.TabControlPanelOutOfHomeTab_OutOfHome)
            Me.TabControlFooterComments_FooterComments.ForeColor = System.Drawing.Color.Black
            Me.TabControlFooterComments_FooterComments.Location = New System.Drawing.Point(4, 4)
            Me.TabControlFooterComments_FooterComments.Name = "TabControlFooterComments_FooterComments"
            Me.TabControlFooterComments_FooterComments.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlFooterComments_FooterComments.SelectedTabIndex = 0
            Me.TabControlFooterComments_FooterComments.Size = New System.Drawing.Size(932, 569)
            Me.TabControlFooterComments_FooterComments.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlFooterComments_FooterComments.TabIndex = 14
            Me.TabControlFooterComments_FooterComments.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlFooterComments_FooterComments.Tabs.Add(Me.TabItemFooterComments_NewspaperTab)
            Me.TabControlFooterComments_FooterComments.Tabs.Add(Me.TabItemFooterComments_MagazineTab)
            Me.TabControlFooterComments_FooterComments.Tabs.Add(Me.TabItemFooterComments_OutOfHomeTab)
            Me.TabControlFooterComments_FooterComments.Tabs.Add(Me.TabItemFooterComments_InternetTab)
            Me.TabControlFooterComments_FooterComments.Tabs.Add(Me.TabItemFooterComments_RadioTab)
            Me.TabControlFooterComments_FooterComments.Tabs.Add(Me.TabItemFooterComments_TelevisionTab)
            Me.TabControlFooterComments_FooterComments.Text = "Internet"
            '
            'TabControlPanelNewspaperTab_Newspaper
            '
            Me.TabControlPanelNewspaperTab_Newspaper.Controls.Add(Me.TextBoxNewspaper_FooterComments)
            Me.TabControlPanelNewspaperTab_Newspaper.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelNewspaperTab_Newspaper.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelNewspaperTab_Newspaper.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelNewspaperTab_Newspaper.Name = "TabControlPanelNewspaperTab_Newspaper"
            Me.TabControlPanelNewspaperTab_Newspaper.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelNewspaperTab_Newspaper.Size = New System.Drawing.Size(932, 542)
            Me.TabControlPanelNewspaperTab_Newspaper.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelNewspaperTab_Newspaper.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelNewspaperTab_Newspaper.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelNewspaperTab_Newspaper.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelNewspaperTab_Newspaper.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelNewspaperTab_Newspaper.Style.GradientAngle = 90
            Me.TabControlPanelNewspaperTab_Newspaper.TabIndex = 1
            Me.TabControlPanelNewspaperTab_Newspaper.TabItem = Me.TabItemFooterComments_NewspaperTab
            '
            'TextBoxNewspaper_FooterComments
            '
            Me.TextBoxNewspaper_FooterComments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxNewspaper_FooterComments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxNewspaper_FooterComments.Border.Class = "TextBoxBorder"
            Me.TextBoxNewspaper_FooterComments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxNewspaper_FooterComments.CheckSpellingOnValidate = False
            Me.TextBoxNewspaper_FooterComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxNewspaper_FooterComments.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxNewspaper_FooterComments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxNewspaper_FooterComments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxNewspaper_FooterComments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxNewspaper_FooterComments.FocusHighlightEnabled = True
            Me.TextBoxNewspaper_FooterComments.ForeColor = System.Drawing.Color.Black
            Me.TextBoxNewspaper_FooterComments.Location = New System.Drawing.Point(4, 4)
            Me.TextBoxNewspaper_FooterComments.MaxFileSize = CType(0, Long)
            Me.TextBoxNewspaper_FooterComments.Multiline = True
            Me.TextBoxNewspaper_FooterComments.Name = "TextBoxNewspaper_FooterComments"
            Me.TextBoxNewspaper_FooterComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxNewspaper_FooterComments.SecurityEnabled = True
            Me.TextBoxNewspaper_FooterComments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxNewspaper_FooterComments.Size = New System.Drawing.Size(924, 534)
            Me.TextBoxNewspaper_FooterComments.StartingFolderName = Nothing
            Me.TextBoxNewspaper_FooterComments.TabIndex = 0
            Me.TextBoxNewspaper_FooterComments.TabOnEnter = False
            '
            'TabItemFooterComments_NewspaperTab
            '
            Me.TabItemFooterComments_NewspaperTab.AttachedControl = Me.TabControlPanelNewspaperTab_Newspaper
            Me.TabItemFooterComments_NewspaperTab.Name = "TabItemFooterComments_NewspaperTab"
            Me.TabItemFooterComments_NewspaperTab.Text = "Newspaper"
            '
            'TabControlPanelInternetTab_Internet
            '
            Me.TabControlPanelInternetTab_Internet.Controls.Add(Me.TextBoxInternet_FooterComments)
            Me.TabControlPanelInternetTab_Internet.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelInternetTab_Internet.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInternetTab_Internet.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInternetTab_Internet.Name = "TabControlPanelInternetTab_Internet"
            Me.TabControlPanelInternetTab_Internet.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInternetTab_Internet.Size = New System.Drawing.Size(932, 542)
            Me.TabControlPanelInternetTab_Internet.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelInternetTab_Internet.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInternetTab_Internet.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInternetTab_Internet.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInternetTab_Internet.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInternetTab_Internet.Style.GradientAngle = 90
            Me.TabControlPanelInternetTab_Internet.TabIndex = 4
            Me.TabControlPanelInternetTab_Internet.TabItem = Me.TabItemFooterComments_InternetTab
            '
            'TextBoxInternet_FooterComments
            '
            Me.TextBoxInternet_FooterComments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxInternet_FooterComments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxInternet_FooterComments.Border.Class = "TextBoxBorder"
            Me.TextBoxInternet_FooterComments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxInternet_FooterComments.CheckSpellingOnValidate = False
            Me.TextBoxInternet_FooterComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxInternet_FooterComments.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxInternet_FooterComments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxInternet_FooterComments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxInternet_FooterComments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxInternet_FooterComments.FocusHighlightEnabled = True
            Me.TextBoxInternet_FooterComments.ForeColor = System.Drawing.Color.Black
            Me.TextBoxInternet_FooterComments.Location = New System.Drawing.Point(4, 4)
            Me.TextBoxInternet_FooterComments.MaxFileSize = CType(0, Long)
            Me.TextBoxInternet_FooterComments.Multiline = True
            Me.TextBoxInternet_FooterComments.Name = "TextBoxInternet_FooterComments"
            Me.TextBoxInternet_FooterComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxInternet_FooterComments.SecurityEnabled = True
            Me.TextBoxInternet_FooterComments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxInternet_FooterComments.Size = New System.Drawing.Size(924, 534)
            Me.TextBoxInternet_FooterComments.StartingFolderName = Nothing
            Me.TextBoxInternet_FooterComments.TabIndex = 0
            Me.TextBoxInternet_FooterComments.TabOnEnter = False
            '
            'TabItemFooterComments_InternetTab
            '
            Me.TabItemFooterComments_InternetTab.AttachedControl = Me.TabControlPanelInternetTab_Internet
            Me.TabItemFooterComments_InternetTab.Name = "TabItemFooterComments_InternetTab"
            Me.TabItemFooterComments_InternetTab.Text = "Internet"
            '
            'TabControlPanelMagazineTab_Magazine
            '
            Me.TabControlPanelMagazineTab_Magazine.Controls.Add(Me.TextBoxMagazine_FooterComments)
            Me.TabControlPanelMagazineTab_Magazine.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMagazineTab_Magazine.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMagazineTab_Magazine.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMagazineTab_Magazine.Name = "TabControlPanelMagazineTab_Magazine"
            Me.TabControlPanelMagazineTab_Magazine.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMagazineTab_Magazine.Size = New System.Drawing.Size(932, 542)
            Me.TabControlPanelMagazineTab_Magazine.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMagazineTab_Magazine.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMagazineTab_Magazine.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMagazineTab_Magazine.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMagazineTab_Magazine.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMagazineTab_Magazine.Style.GradientAngle = 90
            Me.TabControlPanelMagazineTab_Magazine.TabIndex = 2
            Me.TabControlPanelMagazineTab_Magazine.TabItem = Me.TabItemFooterComments_MagazineTab
            '
            'TextBoxMagazine_FooterComments
            '
            Me.TextBoxMagazine_FooterComments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMagazine_FooterComments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMagazine_FooterComments.Border.Class = "TextBoxBorder"
            Me.TextBoxMagazine_FooterComments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMagazine_FooterComments.CheckSpellingOnValidate = False
            Me.TextBoxMagazine_FooterComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxMagazine_FooterComments.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMagazine_FooterComments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxMagazine_FooterComments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMagazine_FooterComments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMagazine_FooterComments.FocusHighlightEnabled = True
            Me.TextBoxMagazine_FooterComments.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMagazine_FooterComments.Location = New System.Drawing.Point(4, 4)
            Me.TextBoxMagazine_FooterComments.MaxFileSize = CType(0, Long)
            Me.TextBoxMagazine_FooterComments.Multiline = True
            Me.TextBoxMagazine_FooterComments.Name = "TextBoxMagazine_FooterComments"
            Me.TextBoxMagazine_FooterComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxMagazine_FooterComments.SecurityEnabled = True
            Me.TextBoxMagazine_FooterComments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMagazine_FooterComments.Size = New System.Drawing.Size(924, 534)
            Me.TextBoxMagazine_FooterComments.StartingFolderName = Nothing
            Me.TextBoxMagazine_FooterComments.TabIndex = 0
            Me.TextBoxMagazine_FooterComments.TabOnEnter = False
            '
            'TabItemFooterComments_MagazineTab
            '
            Me.TabItemFooterComments_MagazineTab.AttachedControl = Me.TabControlPanelMagazineTab_Magazine
            Me.TabItemFooterComments_MagazineTab.Name = "TabItemFooterComments_MagazineTab"
            Me.TabItemFooterComments_MagazineTab.Text = "Magazine"
            '
            'TabControlPanelTelevisionTab_Television
            '
            Me.TabControlPanelTelevisionTab_Television.Controls.Add(Me.TextBoxTelevision_FooterComments)
            Me.TabControlPanelTelevisionTab_Television.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelTelevisionTab_Television.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTelevisionTab_Television.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTelevisionTab_Television.Name = "TabControlPanelTelevisionTab_Television"
            Me.TabControlPanelTelevisionTab_Television.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTelevisionTab_Television.Size = New System.Drawing.Size(932, 542)
            Me.TabControlPanelTelevisionTab_Television.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelTelevisionTab_Television.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTelevisionTab_Television.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTelevisionTab_Television.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTelevisionTab_Television.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTelevisionTab_Television.Style.GradientAngle = 90
            Me.TabControlPanelTelevisionTab_Television.TabIndex = 6
            Me.TabControlPanelTelevisionTab_Television.TabItem = Me.TabItemFooterComments_TelevisionTab
            '
            'TextBoxTelevision_FooterComments
            '
            Me.TextBoxTelevision_FooterComments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxTelevision_FooterComments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxTelevision_FooterComments.Border.Class = "TextBoxBorder"
            Me.TextBoxTelevision_FooterComments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTelevision_FooterComments.CheckSpellingOnValidate = False
            Me.TextBoxTelevision_FooterComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTelevision_FooterComments.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxTelevision_FooterComments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxTelevision_FooterComments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTelevision_FooterComments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTelevision_FooterComments.FocusHighlightEnabled = True
            Me.TextBoxTelevision_FooterComments.ForeColor = System.Drawing.Color.Black
            Me.TextBoxTelevision_FooterComments.Location = New System.Drawing.Point(4, 4)
            Me.TextBoxTelevision_FooterComments.MaxFileSize = CType(0, Long)
            Me.TextBoxTelevision_FooterComments.Multiline = True
            Me.TextBoxTelevision_FooterComments.Name = "TextBoxTelevision_FooterComments"
            Me.TextBoxTelevision_FooterComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxTelevision_FooterComments.SecurityEnabled = True
            Me.TextBoxTelevision_FooterComments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTelevision_FooterComments.Size = New System.Drawing.Size(924, 534)
            Me.TextBoxTelevision_FooterComments.StartingFolderName = Nothing
            Me.TextBoxTelevision_FooterComments.TabIndex = 0
            Me.TextBoxTelevision_FooterComments.TabOnEnter = False
            '
            'TabItemFooterComments_TelevisionTab
            '
            Me.TabItemFooterComments_TelevisionTab.AttachedControl = Me.TabControlPanelTelevisionTab_Television
            Me.TabItemFooterComments_TelevisionTab.Name = "TabItemFooterComments_TelevisionTab"
            Me.TabItemFooterComments_TelevisionTab.Text = "Television"
            '
            'TabControlPanelRadioTab_Radio
            '
            Me.TabControlPanelRadioTab_Radio.Controls.Add(Me.TextBoxRadio_FooterComments)
            Me.TabControlPanelRadioTab_Radio.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelRadioTab_Radio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRadioTab_Radio.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRadioTab_Radio.Name = "TabControlPanelRadioTab_Radio"
            Me.TabControlPanelRadioTab_Radio.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRadioTab_Radio.Size = New System.Drawing.Size(932, 542)
            Me.TabControlPanelRadioTab_Radio.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelRadioTab_Radio.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRadioTab_Radio.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRadioTab_Radio.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRadioTab_Radio.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRadioTab_Radio.Style.GradientAngle = 90
            Me.TabControlPanelRadioTab_Radio.TabIndex = 5
            Me.TabControlPanelRadioTab_Radio.TabItem = Me.TabItemFooterComments_RadioTab
            '
            'TextBoxRadio_FooterComments
            '
            Me.TextBoxRadio_FooterComments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxRadio_FooterComments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxRadio_FooterComments.Border.Class = "TextBoxBorder"
            Me.TextBoxRadio_FooterComments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRadio_FooterComments.CheckSpellingOnValidate = False
            Me.TextBoxRadio_FooterComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRadio_FooterComments.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxRadio_FooterComments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxRadio_FooterComments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRadio_FooterComments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRadio_FooterComments.FocusHighlightEnabled = True
            Me.TextBoxRadio_FooterComments.ForeColor = System.Drawing.Color.Black
            Me.TextBoxRadio_FooterComments.Location = New System.Drawing.Point(4, 4)
            Me.TextBoxRadio_FooterComments.MaxFileSize = CType(0, Long)
            Me.TextBoxRadio_FooterComments.Multiline = True
            Me.TextBoxRadio_FooterComments.Name = "TextBoxRadio_FooterComments"
            Me.TextBoxRadio_FooterComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxRadio_FooterComments.SecurityEnabled = True
            Me.TextBoxRadio_FooterComments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRadio_FooterComments.Size = New System.Drawing.Size(924, 534)
            Me.TextBoxRadio_FooterComments.StartingFolderName = Nothing
            Me.TextBoxRadio_FooterComments.TabIndex = 0
            Me.TextBoxRadio_FooterComments.TabOnEnter = False
            '
            'TabItemFooterComments_RadioTab
            '
            Me.TabItemFooterComments_RadioTab.AttachedControl = Me.TabControlPanelRadioTab_Radio
            Me.TabItemFooterComments_RadioTab.Name = "TabItemFooterComments_RadioTab"
            Me.TabItemFooterComments_RadioTab.Text = "Radio"
            '
            'TabControlPanelOutOfHomeTab_OutOfHome
            '
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Controls.Add(Me.TextBoxOutOfHome_FooterComments)
            Me.TabControlPanelOutOfHomeTab_OutOfHome.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Name = "TabControlPanelOutOfHomeTab_OutOfHome"
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Size = New System.Drawing.Size(932, 542)
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Style.GradientAngle = 90
            Me.TabControlPanelOutOfHomeTab_OutOfHome.TabIndex = 3
            Me.TabControlPanelOutOfHomeTab_OutOfHome.TabItem = Me.TabItemFooterComments_OutOfHomeTab
            '
            'TextBoxOutOfHome_FooterComments
            '
            Me.TextBoxOutOfHome_FooterComments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxOutOfHome_FooterComments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxOutOfHome_FooterComments.Border.Class = "TextBoxBorder"
            Me.TextBoxOutOfHome_FooterComments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxOutOfHome_FooterComments.CheckSpellingOnValidate = False
            Me.TextBoxOutOfHome_FooterComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxOutOfHome_FooterComments.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxOutOfHome_FooterComments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxOutOfHome_FooterComments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxOutOfHome_FooterComments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxOutOfHome_FooterComments.FocusHighlightEnabled = True
            Me.TextBoxOutOfHome_FooterComments.ForeColor = System.Drawing.Color.Black
            Me.TextBoxOutOfHome_FooterComments.Location = New System.Drawing.Point(4, 4)
            Me.TextBoxOutOfHome_FooterComments.MaxFileSize = CType(0, Long)
            Me.TextBoxOutOfHome_FooterComments.Multiline = True
            Me.TextBoxOutOfHome_FooterComments.Name = "TextBoxOutOfHome_FooterComments"
            Me.TextBoxOutOfHome_FooterComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxOutOfHome_FooterComments.SecurityEnabled = True
            Me.TextBoxOutOfHome_FooterComments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxOutOfHome_FooterComments.Size = New System.Drawing.Size(924, 534)
            Me.TextBoxOutOfHome_FooterComments.StartingFolderName = Nothing
            Me.TextBoxOutOfHome_FooterComments.TabIndex = 0
            Me.TextBoxOutOfHome_FooterComments.TabOnEnter = False
            '
            'TabItemFooterComments_OutOfHomeTab
            '
            Me.TabItemFooterComments_OutOfHomeTab.AttachedControl = Me.TabControlPanelOutOfHomeTab_OutOfHome
            Me.TabItemFooterComments_OutOfHomeTab.Name = "TabItemFooterComments_OutOfHomeTab"
            Me.TabItemFooterComments_OutOfHomeTab.Text = "Out of Home"
            '
            'TabItemMediaOptions_FooterCommentsTab
            '
            Me.TabItemMediaOptions_FooterCommentsTab.AttachedControl = Me.TabControlPanelFooterCommentsTab_FooterComments
            Me.TabItemMediaOptions_FooterCommentsTab.Name = "TabItemMediaOptions_FooterCommentsTab"
            Me.TabItemMediaOptions_FooterCommentsTab.Text = "Media Footer Comments"
            '
            'TabControlPanelSettingsTab_Settings
            '
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.GroupBoxMediaOptions_BroadcastWorksheet)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.GroupBoxSettings_MediaGeneral)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.GroupBoxSettings_MediaOrders)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.GroupBoxSettings_MediaPlanning)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.GroupBoxSettings_ExportMediaOrder)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.CheckBoxSettings_UseAPAccountOnImport)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_MediaImportDefault)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.CheckBoxSettings_RenameFinanceFile)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.TextBoxSettings_ImportPath)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.TextBoxSettings_StrataConnectPath)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.ComboBoxSettings_MediaImportDefault)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_StrataConnectPath)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_ImportPath)
            Me.TabControlPanelSettingsTab_Settings.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSettingsTab_Settings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSettingsTab_Settings.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSettingsTab_Settings.Name = "TabControlPanelSettingsTab_Settings"
            Me.TabControlPanelSettingsTab_Settings.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSettingsTab_Settings.Size = New System.Drawing.Size(941, 577)
            Me.TabControlPanelSettingsTab_Settings.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSettingsTab_Settings.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSettingsTab_Settings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSettingsTab_Settings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSettingsTab_Settings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSettingsTab_Settings.Style.GradientAngle = 90
            Me.TabControlPanelSettingsTab_Settings.TabIndex = 12
            Me.TabControlPanelSettingsTab_Settings.TabItem = Me.TabItemMediaOptions_SettingsTab
            '
            'GroupBoxMediaOptions_BroadcastWorksheet
            '
            Me.GroupBoxMediaOptions_BroadcastWorksheet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMediaOptions_BroadcastWorksheet.Controls.Add(Me.LabelMediaOrders_Country)
            Me.GroupBoxMediaOptions_BroadcastWorksheet.Controls.Add(Me.LabelSettings_MediaTrafficStartDate)
            Me.GroupBoxMediaOptions_BroadcastWorksheet.Controls.Add(Me.ComboBoxMediaOrders_Country)
            Me.GroupBoxMediaOptions_BroadcastWorksheet.Controls.Add(Me.RadioButtonMediaOrders_Gross)
            Me.GroupBoxMediaOptions_BroadcastWorksheet.Controls.Add(Me.RadioButtonMediaOrders_Net)
            Me.GroupBoxMediaOptions_BroadcastWorksheet.Controls.Add(Me.DateTimePickerSettings_MediaTrafficStartDate)
            Me.GroupBoxMediaOptions_BroadcastWorksheet.Controls.Add(Me.LabelMediaOrders_BroadcastWorksheetDefaultRateType)
            Me.GroupBoxMediaOptions_BroadcastWorksheet.Location = New System.Drawing.Point(3, 470)
            Me.GroupBoxMediaOptions_BroadcastWorksheet.Name = "GroupBoxMediaOptions_BroadcastWorksheet"
            Me.GroupBoxMediaOptions_BroadcastWorksheet.Size = New System.Drawing.Size(935, 50)
            Me.GroupBoxMediaOptions_BroadcastWorksheet.TabIndex = 0
            Me.GroupBoxMediaOptions_BroadcastWorksheet.Text = "Broadcast Worksheet"
            '
            'LabelMediaOrders_Country
            '
            Me.LabelMediaOrders_Country.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaOrders_Country.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaOrders_Country.Location = New System.Drawing.Point(635, 21)
            Me.LabelMediaOrders_Country.Name = "LabelMediaOrders_Country"
            Me.LabelMediaOrders_Country.Size = New System.Drawing.Size(95, 20)
            Me.LabelMediaOrders_Country.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaOrders_Country.TabIndex = 5
            Me.LabelMediaOrders_Country.Text = "Default Country:"
            '
            'LabelSettings_MediaTrafficStartDate
            '
            Me.LabelSettings_MediaTrafficStartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_MediaTrafficStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_MediaTrafficStartDate.Location = New System.Drawing.Point(3, 21)
            Me.LabelSettings_MediaTrafficStartDate.Name = "LabelSettings_MediaTrafficStartDate"
            Me.LabelSettings_MediaTrafficStartDate.Size = New System.Drawing.Size(127, 20)
            Me.LabelSettings_MediaTrafficStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_MediaTrafficStartDate.TabIndex = 0
            Me.LabelSettings_MediaTrafficStartDate.Text = "Media Traffic Start Date:"
            '
            'ComboBoxMediaOrders_Country
            '
            Me.ComboBoxMediaOrders_Country.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMediaOrders_Country.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxMediaOrders_Country.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMediaOrders_Country.AutoFindItemInDataSource = False
            Me.ComboBoxMediaOrders_Country.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMediaOrders_Country.BookmarkingEnabled = False
            Me.ComboBoxMediaOrders_Country.ClientCode = ""
            Me.ComboBoxMediaOrders_Country.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxMediaOrders_Country.DisableMouseWheel = False
            Me.ComboBoxMediaOrders_Country.DisplayMember = "Name"
            Me.ComboBoxMediaOrders_Country.DisplayName = ""
            Me.ComboBoxMediaOrders_Country.DivisionCode = ""
            Me.ComboBoxMediaOrders_Country.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMediaOrders_Country.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxMediaOrders_Country.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxMediaOrders_Country.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMediaOrders_Country.FocusHighlightEnabled = True
            Me.ComboBoxMediaOrders_Country.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxMediaOrders_Country.FormattingEnabled = True
            Me.ComboBoxMediaOrders_Country.ItemHeight = 16
            Me.ComboBoxMediaOrders_Country.Location = New System.Drawing.Point(736, 21)
            Me.ComboBoxMediaOrders_Country.Name = "ComboBoxMediaOrders_Country"
            Me.ComboBoxMediaOrders_Country.ReadOnly = False
            Me.ComboBoxMediaOrders_Country.SecurityEnabled = True
            Me.ComboBoxMediaOrders_Country.Size = New System.Drawing.Size(194, 22)
            Me.ComboBoxMediaOrders_Country.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMediaOrders_Country.TabIndex = 6
            Me.ComboBoxMediaOrders_Country.TabOnEnter = True
            Me.ComboBoxMediaOrders_Country.ValueMember = "Value"
            Me.ComboBoxMediaOrders_Country.WatermarkText = "Select"
            '
            'RadioButtonMediaOrders_Gross
            '
            Me.RadioButtonMediaOrders_Gross.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMediaOrders_Gross.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMediaOrders_Gross.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMediaOrders_Gross.Checked = True
            Me.RadioButtonMediaOrders_Gross.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonMediaOrders_Gross.CheckValue = "Y"
            Me.RadioButtonMediaOrders_Gross.Location = New System.Drawing.Point(475, 21)
            Me.RadioButtonMediaOrders_Gross.Name = "RadioButtonMediaOrders_Gross"
            Me.RadioButtonMediaOrders_Gross.SecurityEnabled = True
            Me.RadioButtonMediaOrders_Gross.Size = New System.Drawing.Size(74, 20)
            Me.RadioButtonMediaOrders_Gross.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMediaOrders_Gross.TabIndex = 3
            Me.RadioButtonMediaOrders_Gross.TabOnEnter = True
            Me.RadioButtonMediaOrders_Gross.Text = "Gross"
            '
            'RadioButtonMediaOrders_Net
            '
            Me.RadioButtonMediaOrders_Net.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMediaOrders_Net.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMediaOrders_Net.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMediaOrders_Net.Location = New System.Drawing.Point(555, 21)
            Me.RadioButtonMediaOrders_Net.Name = "RadioButtonMediaOrders_Net"
            Me.RadioButtonMediaOrders_Net.SecurityEnabled = True
            Me.RadioButtonMediaOrders_Net.Size = New System.Drawing.Size(75, 20)
            Me.RadioButtonMediaOrders_Net.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMediaOrders_Net.TabIndex = 4
            Me.RadioButtonMediaOrders_Net.TabOnEnter = True
            Me.RadioButtonMediaOrders_Net.TabStop = False
            Me.RadioButtonMediaOrders_Net.Text = "Net"
            '
            'DateTimePickerSettings_MediaTrafficStartDate
            '
            Me.DateTimePickerSettings_MediaTrafficStartDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerSettings_MediaTrafficStartDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerSettings_MediaTrafficStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSettings_MediaTrafficStartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerSettings_MediaTrafficStartDate.ButtonDropDown.Visible = True
            Me.DateTimePickerSettings_MediaTrafficStartDate.ButtonFreeText.Checked = True
            Me.DateTimePickerSettings_MediaTrafficStartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerSettings_MediaTrafficStartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerSettings_MediaTrafficStartDate.DisplayName = ""
            Me.DateTimePickerSettings_MediaTrafficStartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerSettings_MediaTrafficStartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerSettings_MediaTrafficStartDate.FocusHighlightEnabled = True
            Me.DateTimePickerSettings_MediaTrafficStartDate.FreeTextEntryMode = True
            Me.DateTimePickerSettings_MediaTrafficStartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerSettings_MediaTrafficStartDate.Location = New System.Drawing.Point(136, 21)
            Me.DateTimePickerSettings_MediaTrafficStartDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerSettings_MediaTrafficStartDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerSettings_MediaTrafficStartDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerSettings_MediaTrafficStartDate.Name = "DateTimePickerSettings_MediaTrafficStartDate"
            Me.DateTimePickerSettings_MediaTrafficStartDate.ReadOnly = False
            Me.DateTimePickerSettings_MediaTrafficStartDate.Size = New System.Drawing.Size(97, 21)
            Me.DateTimePickerSettings_MediaTrafficStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerSettings_MediaTrafficStartDate.TabIndex = 1
            Me.DateTimePickerSettings_MediaTrafficStartDate.TabOnEnter = True
            Me.DateTimePickerSettings_MediaTrafficStartDate.Value = New Date(2013, 7, 23, 13, 58, 57, 313)
            '
            'LabelMediaOrders_BroadcastWorksheetDefaultRateType
            '
            Me.LabelMediaOrders_BroadcastWorksheetDefaultRateType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaOrders_BroadcastWorksheetDefaultRateType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaOrders_BroadcastWorksheetDefaultRateType.Location = New System.Drawing.Point(239, 21)
            Me.LabelMediaOrders_BroadcastWorksheetDefaultRateType.Name = "LabelMediaOrders_BroadcastWorksheetDefaultRateType"
            Me.LabelMediaOrders_BroadcastWorksheetDefaultRateType.Size = New System.Drawing.Size(229, 20)
            Me.LabelMediaOrders_BroadcastWorksheetDefaultRateType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaOrders_BroadcastWorksheetDefaultRateType.TabIndex = 2
            Me.LabelMediaOrders_BroadcastWorksheetDefaultRateType.Text = "Broadcast Worksheet Default Rate Type:"
            '
            'GroupBoxSettings_MediaGeneral
            '
            Me.GroupBoxSettings_MediaGeneral.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxSettings_MediaGeneral.Controls.Add(Me.CheckBoxMediaGeneral_MediaAutoBuyer)
            Me.GroupBoxSettings_MediaGeneral.Controls.Add(Me.CheckBoxMediaGeneral_MediaRequireCampaign)
            Me.GroupBoxSettings_MediaGeneral.Location = New System.Drawing.Point(3, 384)
            Me.GroupBoxSettings_MediaGeneral.Name = "GroupBoxSettings_MediaGeneral"
            Me.GroupBoxSettings_MediaGeneral.Size = New System.Drawing.Size(935, 80)
            Me.GroupBoxSettings_MediaGeneral.TabIndex = 14
            Me.GroupBoxSettings_MediaGeneral.Text = "General"
            '
            'CheckBoxMediaGeneral_MediaAutoBuyer
            '
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.CheckValue = CType(0, Short)
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.ChildControls = CType(resources.GetObject("CheckBoxMediaGeneral_MediaAutoBuyer.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.Name = "CheckBoxMediaGeneral_MediaAutoBuyer"
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.OldestSibling = Nothing
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.SecurityEnabled = True
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.SiblingControls = CType(resources.GetObject("CheckBoxMediaGeneral_MediaAutoBuyer.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.Size = New System.Drawing.Size(926, 20)
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.TabIndex = 1
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.TabOnEnter = True
            Me.CheckBoxMediaGeneral_MediaAutoBuyer.Text = "Automatically set the user as the buyer on a Media Plan estimate(s) or a Broadcas" &
    "t Worksheet market(s)."
            '
            'CheckBoxMediaGeneral_MediaRequireCampaign
            '
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.CheckValue = CType(0, Short)
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.ChildControls = CType(resources.GetObject("CheckBoxMediaGeneral_MediaRequireCampaign.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.Name = "CheckBoxMediaGeneral_MediaRequireCampaign"
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.OldestSibling = Nothing
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.SecurityEnabled = True
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.SiblingControls = CType(resources.GetObject("CheckBoxMediaGeneral_MediaRequireCampaign.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.Size = New System.Drawing.Size(926, 20)
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.TabIndex = 0
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.TabOnEnter = True
            Me.CheckBoxMediaGeneral_MediaRequireCampaign.Text = "Require Campaign on Plan Estimates, Broadcast Worksheets, and Media Orders (all t" &
    "ypes)"
            '
            'GroupBoxSettings_MediaOrders
            '
            Me.GroupBoxSettings_MediaOrders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxSettings_MediaOrders.Controls.Add(Me.CheckBoxMediaOrders_UseVendorsRateType)
            Me.GroupBoxSettings_MediaOrders.Controls.Add(Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail)
            Me.GroupBoxSettings_MediaOrders.Location = New System.Drawing.Point(2, 327)
            Me.GroupBoxSettings_MediaOrders.LookAndFeel.SkinName = "Office 2013"
            Me.GroupBoxSettings_MediaOrders.LookAndFeel.UseDefaultLookAndFeel = False
            Me.GroupBoxSettings_MediaOrders.Name = "GroupBoxSettings_MediaOrders"
            Me.GroupBoxSettings_MediaOrders.Size = New System.Drawing.Size(935, 51)
            Me.GroupBoxSettings_MediaOrders.TabIndex = 13
            Me.GroupBoxSettings_MediaOrders.Text = "Media Orders"
            '
            'CheckBoxMediaOrders_UseVendorsRateType
            '
            Me.CheckBoxMediaOrders_UseVendorsRateType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxMediaOrders_UseVendorsRateType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaOrders_UseVendorsRateType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaOrders_UseVendorsRateType.CheckValue = CType(0, Short)
            Me.CheckBoxMediaOrders_UseVendorsRateType.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMediaOrders_UseVendorsRateType.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMediaOrders_UseVendorsRateType.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMediaOrders_UseVendorsRateType.ChildControls = CType(resources.GetObject("CheckBoxMediaOrders_UseVendorsRateType.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaOrders_UseVendorsRateType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaOrders_UseVendorsRateType.Location = New System.Drawing.Point(240, 24)
            Me.CheckBoxMediaOrders_UseVendorsRateType.Name = "CheckBoxMediaOrders_UseVendorsRateType"
            Me.CheckBoxMediaOrders_UseVendorsRateType.OldestSibling = Nothing
            Me.CheckBoxMediaOrders_UseVendorsRateType.SecurityEnabled = True
            Me.CheckBoxMediaOrders_UseVendorsRateType.SiblingControls = CType(resources.GetObject("CheckBoxMediaOrders_UseVendorsRateType.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaOrders_UseVendorsRateType.Size = New System.Drawing.Size(690, 20)
            Me.CheckBoxMediaOrders_UseVendorsRateType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaOrders_UseVendorsRateType.TabIndex = 2
            Me.CheckBoxMediaOrders_UseVendorsRateType.TabOnEnter = True
            Me.CheckBoxMediaOrders_UseVendorsRateType.Text = "Use Vendor's Rate Type Setting when Creating Orders from Planning and Worksheet"
            '
            'CheckBoxSettings_MediaExcludeOrderPDFWithEmail
            '
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.CheckValue = CType(0, Short)
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.CheckValueChecked = CType(1, Short)
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.ChildControls = CType(resources.GetObject("CheckBoxSettings_MediaExcludeOrderPDFWithEmail.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.Location = New System.Drawing.Point(4, 24)
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.Name = "CheckBoxSettings_MediaExcludeOrderPDFWithEmail"
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.OldestSibling = Nothing
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.SecurityEnabled = True
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.SiblingControls = CType(resources.GetObject("CheckBoxSettings_MediaExcludeOrderPDFWithEmail.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.Size = New System.Drawing.Size(230, 20)
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.TabIndex = 0
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.TabOnEnter = True
            Me.CheckBoxSettings_MediaExcludeOrderPDFWithEmail.Text = "Exclude Order PDF with Email"
            '
            'GroupBoxSettings_MediaPlanning
            '
            Me.GroupBoxSettings_MediaPlanning.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxSettings_MediaPlanning.Controls.Add(Me.CheckBoxMediaPlanning_AddLinesToExistingOrder)
            Me.GroupBoxSettings_MediaPlanning.Controls.Add(Me.LabelMediaPlanning_DefaultGroupingTypeTV)
            Me.GroupBoxSettings_MediaPlanning.Controls.Add(Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV)
            Me.GroupBoxSettings_MediaPlanning.Controls.Add(Me.LabelMediaPlanning_DefaultGroupingTypeRadio)
            Me.GroupBoxSettings_MediaPlanning.Controls.Add(Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio)
            Me.GroupBoxSettings_MediaPlanning.Controls.Add(Me.LabelMediaPlanning_DefaultGroupingTypeOutOfHome)
            Me.GroupBoxSettings_MediaPlanning.Controls.Add(Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome)
            Me.GroupBoxSettings_MediaPlanning.Controls.Add(Me.LabelMediaPlanning_DefaultGroupingTypeNewspaper)
            Me.GroupBoxSettings_MediaPlanning.Controls.Add(Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper)
            Me.GroupBoxSettings_MediaPlanning.Controls.Add(Me.LabelMediaPlanning_DefaultGroupingTypeMagazine)
            Me.GroupBoxSettings_MediaPlanning.Controls.Add(Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine)
            Me.GroupBoxSettings_MediaPlanning.Controls.Add(Me.LabelMediaPlanning_DefaultGroupingType)
            Me.GroupBoxSettings_MediaPlanning.Controls.Add(Me.LabelMediaPlanning_DefaultGroupingTypeInternet)
            Me.GroupBoxSettings_MediaPlanning.Controls.Add(Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet)
            Me.GroupBoxSettings_MediaPlanning.Location = New System.Drawing.Point(2, 193)
            Me.GroupBoxSettings_MediaPlanning.Name = "GroupBoxSettings_MediaPlanning"
            Me.GroupBoxSettings_MediaPlanning.Size = New System.Drawing.Size(935, 129)
            Me.GroupBoxSettings_MediaPlanning.TabIndex = 12
            Me.GroupBoxSettings_MediaPlanning.Text = "Media Planning"
            '
            'CheckBoxMediaPlanning_AddLinesToExistingOrder
            '
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.CheckValue = CType(0, Short)
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.ChildControls = CType(resources.GetObject("CheckBoxMediaPlanning_AddLinesToExistingOrder.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.Location = New System.Drawing.Point(4, 104)
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.Name = "CheckBoxMediaPlanning_AddLinesToExistingOrder"
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.OldestSibling = Nothing
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.SecurityEnabled = True
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.SiblingControls = CType(resources.GetObject("CheckBoxMediaPlanning_AddLinesToExistingOrder.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.Size = New System.Drawing.Size(926, 20)
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.TabIndex = 14
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.TabOnEnter = True
            Me.CheckBoxMediaPlanning_AddLinesToExistingOrder.Text = "Add new lines to existing order"
            '
            'LabelMediaPlanning_DefaultGroupingTypeTV
            '
            Me.LabelMediaPlanning_DefaultGroupingTypeTV.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaPlanning_DefaultGroupingTypeTV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaPlanning_DefaultGroupingTypeTV.Location = New System.Drawing.Point(477, 76)
            Me.LabelMediaPlanning_DefaultGroupingTypeTV.Name = "LabelMediaPlanning_DefaultGroupingTypeTV"
            Me.LabelMediaPlanning_DefaultGroupingTypeTV.Size = New System.Drawing.Size(74, 20)
            Me.LabelMediaPlanning_DefaultGroupingTypeTV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaPlanning_DefaultGroupingTypeTV.TabIndex = 11
            Me.LabelMediaPlanning_DefaultGroupingTypeTV.Text = "TV:"
            '
            'ComboBoxMediaPlanning_DefaultGroupingTypeTV
            '
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.AutoFindItemInDataSource = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.BookmarkingEnabled = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.ClientCode = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.DisableMouseWheel = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.DisplayMember = "Description"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.DisplayName = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.DivisionCode = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.FocusHighlightEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.FormattingEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.ItemHeight = 16
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.Location = New System.Drawing.Point(557, 76)
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.Name = "ComboBoxMediaPlanning_DefaultGroupingTypeTV"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.ReadOnly = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.SecurityEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.Size = New System.Drawing.Size(150, 22)
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.TabIndex = 12
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.TabOnEnter = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.ValueMember = "Code"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeTV.WatermarkText = "Select"
            '
            'LabelMediaPlanning_DefaultGroupingTypeRadio
            '
            Me.LabelMediaPlanning_DefaultGroupingTypeRadio.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaPlanning_DefaultGroupingTypeRadio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaPlanning_DefaultGroupingTypeRadio.Location = New System.Drawing.Point(241, 76)
            Me.LabelMediaPlanning_DefaultGroupingTypeRadio.Name = "LabelMediaPlanning_DefaultGroupingTypeRadio"
            Me.LabelMediaPlanning_DefaultGroupingTypeRadio.Size = New System.Drawing.Size(74, 20)
            Me.LabelMediaPlanning_DefaultGroupingTypeRadio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaPlanning_DefaultGroupingTypeRadio.TabIndex = 9
            Me.LabelMediaPlanning_DefaultGroupingTypeRadio.Text = "Radio:"
            '
            'ComboBoxMediaPlanning_DefaultGroupingTypeRadio
            '
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.AutoFindItemInDataSource = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.BookmarkingEnabled = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.ClientCode = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.DisableMouseWheel = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.DisplayMember = "Description"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.DisplayName = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.DivisionCode = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.FocusHighlightEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.FormattingEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.ItemHeight = 16
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.Location = New System.Drawing.Point(321, 76)
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.Name = "ComboBoxMediaPlanning_DefaultGroupingTypeRadio"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.ReadOnly = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.SecurityEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.Size = New System.Drawing.Size(150, 22)
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.TabIndex = 10
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.TabOnEnter = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.ValueMember = "Code"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeRadio.WatermarkText = "Select"
            '
            'LabelMediaPlanning_DefaultGroupingTypeOutOfHome
            '
            Me.LabelMediaPlanning_DefaultGroupingTypeOutOfHome.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaPlanning_DefaultGroupingTypeOutOfHome.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaPlanning_DefaultGroupingTypeOutOfHome.Location = New System.Drawing.Point(5, 76)
            Me.LabelMediaPlanning_DefaultGroupingTypeOutOfHome.Name = "LabelMediaPlanning_DefaultGroupingTypeOutOfHome"
            Me.LabelMediaPlanning_DefaultGroupingTypeOutOfHome.Size = New System.Drawing.Size(74, 20)
            Me.LabelMediaPlanning_DefaultGroupingTypeOutOfHome.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaPlanning_DefaultGroupingTypeOutOfHome.TabIndex = 7
            Me.LabelMediaPlanning_DefaultGroupingTypeOutOfHome.Text = "Out of Home:"
            '
            'ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome
            '
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.AutoFindItemInDataSource = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.BookmarkingEnabled = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.ClientCode = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.DisableMouseWheel = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.DisplayMember = "Description"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.DisplayName = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.DivisionCode = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.FocusHighlightEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.FormattingEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.ItemHeight = 16
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.Location = New System.Drawing.Point(85, 76)
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.Name = "ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.ReadOnly = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.SecurityEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.Size = New System.Drawing.Size(150, 22)
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.TabIndex = 8
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.TabOnEnter = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.ValueMember = "Code"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome.WatermarkText = "Select"
            '
            'LabelMediaPlanning_DefaultGroupingTypeNewspaper
            '
            Me.LabelMediaPlanning_DefaultGroupingTypeNewspaper.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaPlanning_DefaultGroupingTypeNewspaper.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaPlanning_DefaultGroupingTypeNewspaper.Location = New System.Drawing.Point(477, 50)
            Me.LabelMediaPlanning_DefaultGroupingTypeNewspaper.Name = "LabelMediaPlanning_DefaultGroupingTypeNewspaper"
            Me.LabelMediaPlanning_DefaultGroupingTypeNewspaper.Size = New System.Drawing.Size(74, 20)
            Me.LabelMediaPlanning_DefaultGroupingTypeNewspaper.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaPlanning_DefaultGroupingTypeNewspaper.TabIndex = 5
            Me.LabelMediaPlanning_DefaultGroupingTypeNewspaper.Text = "Newspaper:"
            '
            'ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper
            '
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.AutoFindItemInDataSource = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.BookmarkingEnabled = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.ClientCode = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.DisableMouseWheel = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.DisplayMember = "Description"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.DisplayName = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.DivisionCode = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.FocusHighlightEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.FormattingEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.ItemHeight = 16
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.Location = New System.Drawing.Point(557, 50)
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.Name = "ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.ReadOnly = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.SecurityEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.Size = New System.Drawing.Size(150, 22)
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.TabIndex = 6
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.TabOnEnter = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.ValueMember = "Code"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper.WatermarkText = "Select"
            '
            'LabelMediaPlanning_DefaultGroupingTypeMagazine
            '
            Me.LabelMediaPlanning_DefaultGroupingTypeMagazine.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaPlanning_DefaultGroupingTypeMagazine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaPlanning_DefaultGroupingTypeMagazine.Location = New System.Drawing.Point(241, 50)
            Me.LabelMediaPlanning_DefaultGroupingTypeMagazine.Name = "LabelMediaPlanning_DefaultGroupingTypeMagazine"
            Me.LabelMediaPlanning_DefaultGroupingTypeMagazine.Size = New System.Drawing.Size(74, 20)
            Me.LabelMediaPlanning_DefaultGroupingTypeMagazine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaPlanning_DefaultGroupingTypeMagazine.TabIndex = 3
            Me.LabelMediaPlanning_DefaultGroupingTypeMagazine.Text = "Magazine:"
            '
            'ComboBoxMediaPlanning_DefaultGroupingTypeMagazine
            '
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.AutoFindItemInDataSource = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.BookmarkingEnabled = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.ClientCode = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.DisableMouseWheel = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.DisplayMember = "Description"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.DisplayName = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.DivisionCode = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.FocusHighlightEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.FormattingEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.ItemHeight = 16
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.Location = New System.Drawing.Point(321, 50)
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.Name = "ComboBoxMediaPlanning_DefaultGroupingTypeMagazine"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.ReadOnly = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.SecurityEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.Size = New System.Drawing.Size(150, 22)
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.TabIndex = 4
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.TabOnEnter = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.ValueMember = "Code"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeMagazine.WatermarkText = "Select"
            '
            'LabelMediaPlanning_DefaultGroupingType
            '
            Me.LabelMediaPlanning_DefaultGroupingType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelMediaPlanning_DefaultGroupingType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaPlanning_DefaultGroupingType.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelMediaPlanning_DefaultGroupingType.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelMediaPlanning_DefaultGroupingType.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelMediaPlanning_DefaultGroupingType.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelMediaPlanning_DefaultGroupingType.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelMediaPlanning_DefaultGroupingType.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelMediaPlanning_DefaultGroupingType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaPlanning_DefaultGroupingType.Location = New System.Drawing.Point(5, 24)
            Me.LabelMediaPlanning_DefaultGroupingType.Name = "LabelMediaPlanning_DefaultGroupingType"
            Me.LabelMediaPlanning_DefaultGroupingType.Size = New System.Drawing.Size(925, 20)
            Me.LabelMediaPlanning_DefaultGroupingType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaPlanning_DefaultGroupingType.TabIndex = 0
            Me.LabelMediaPlanning_DefaultGroupingType.Text = "Default Grouping Type"
            '
            'LabelMediaPlanning_DefaultGroupingTypeInternet
            '
            Me.LabelMediaPlanning_DefaultGroupingTypeInternet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaPlanning_DefaultGroupingTypeInternet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaPlanning_DefaultGroupingTypeInternet.Location = New System.Drawing.Point(5, 50)
            Me.LabelMediaPlanning_DefaultGroupingTypeInternet.Name = "LabelMediaPlanning_DefaultGroupingTypeInternet"
            Me.LabelMediaPlanning_DefaultGroupingTypeInternet.Size = New System.Drawing.Size(74, 20)
            Me.LabelMediaPlanning_DefaultGroupingTypeInternet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaPlanning_DefaultGroupingTypeInternet.TabIndex = 1
            Me.LabelMediaPlanning_DefaultGroupingTypeInternet.Text = "Internet:"
            '
            'ComboBoxMediaPlanning_DefaultGroupingTypeInternet
            '
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.AutoFindItemInDataSource = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.AutoSelectSingleItemDatasource = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.BookmarkingEnabled = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.ClientCode = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.DisableMouseWheel = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.DisplayMember = "Description"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.DisplayName = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.DivisionCode = ""
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.FocusHighlightEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.FormattingEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.ItemHeight = 16
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.Location = New System.Drawing.Point(85, 50)
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.Name = "ComboBoxMediaPlanning_DefaultGroupingTypeInternet"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.ReadOnly = False
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.SecurityEnabled = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.Size = New System.Drawing.Size(150, 22)
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.TabIndex = 2
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.TabOnEnter = True
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.ValueMember = "Code"
            Me.ComboBoxMediaPlanning_DefaultGroupingTypeInternet.WatermarkText = "Select"
            '
            'GroupBoxSettings_ExportMediaOrder
            '
            Me.GroupBoxSettings_ExportMediaOrder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxSettings_ExportMediaOrder.Controls.Add(Me.TextBoxExportMediaOrders_MediaPlanPath)
            Me.GroupBoxSettings_ExportMediaOrder.Controls.Add(Me.TextBoxExportMediaOrders_APPath)
            Me.GroupBoxSettings_ExportMediaOrder.Controls.Add(Me.LabelExportMediaOrders_APPath)
            Me.GroupBoxSettings_ExportMediaOrder.Controls.Add(Me.LabelExportMediaOrders_MediaPlanPath)
            Me.GroupBoxSettings_ExportMediaOrder.Location = New System.Drawing.Point(3, 106)
            Me.GroupBoxSettings_ExportMediaOrder.Name = "GroupBoxSettings_ExportMediaOrder"
            Me.GroupBoxSettings_ExportMediaOrder.Size = New System.Drawing.Size(935, 80)
            Me.GroupBoxSettings_ExportMediaOrder.TabIndex = 10
            Me.GroupBoxSettings_ExportMediaOrder.Text = "Export Media Orders"
            '
            'TextBoxExportMediaOrders_MediaPlanPath
            '
            Me.TextBoxExportMediaOrders_MediaPlanPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxExportMediaOrders_MediaPlanPath.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxExportMediaOrders_MediaPlanPath.Border.Class = "TextBoxBorder"
            Me.TextBoxExportMediaOrders_MediaPlanPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxExportMediaOrders_MediaPlanPath.ButtonCustom.Visible = True
            Me.TextBoxExportMediaOrders_MediaPlanPath.CheckSpellingOnValidate = False
            Me.TextBoxExportMediaOrders_MediaPlanPath.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxExportMediaOrders_MediaPlanPath.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxExportMediaOrders_MediaPlanPath.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxExportMediaOrders_MediaPlanPath.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxExportMediaOrders_MediaPlanPath.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxExportMediaOrders_MediaPlanPath.FocusHighlightEnabled = True
            Me.TextBoxExportMediaOrders_MediaPlanPath.ForeColor = System.Drawing.Color.Black
            Me.TextBoxExportMediaOrders_MediaPlanPath.Location = New System.Drawing.Point(156, 53)
            Me.TextBoxExportMediaOrders_MediaPlanPath.MaxFileSize = CType(0, Long)
            Me.TextBoxExportMediaOrders_MediaPlanPath.Name = "TextBoxExportMediaOrders_MediaPlanPath"
            Me.TextBoxExportMediaOrders_MediaPlanPath.SecurityEnabled = True
            Me.TextBoxExportMediaOrders_MediaPlanPath.ShowSpellCheckCompleteMessage = True
            Me.TextBoxExportMediaOrders_MediaPlanPath.Size = New System.Drawing.Size(774, 21)
            Me.TextBoxExportMediaOrders_MediaPlanPath.StartingFolderName = Nothing
            Me.TextBoxExportMediaOrders_MediaPlanPath.TabIndex = 14
            Me.TextBoxExportMediaOrders_MediaPlanPath.TabOnEnter = True
            '
            'TextBoxExportMediaOrders_APPath
            '
            Me.TextBoxExportMediaOrders_APPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxExportMediaOrders_APPath.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxExportMediaOrders_APPath.Border.Class = "TextBoxBorder"
            Me.TextBoxExportMediaOrders_APPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxExportMediaOrders_APPath.ButtonCustom.Visible = True
            Me.TextBoxExportMediaOrders_APPath.CheckSpellingOnValidate = False
            Me.TextBoxExportMediaOrders_APPath.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxExportMediaOrders_APPath.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxExportMediaOrders_APPath.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxExportMediaOrders_APPath.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxExportMediaOrders_APPath.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxExportMediaOrders_APPath.FocusHighlightEnabled = True
            Me.TextBoxExportMediaOrders_APPath.ForeColor = System.Drawing.Color.Black
            Me.TextBoxExportMediaOrders_APPath.Location = New System.Drawing.Point(156, 25)
            Me.TextBoxExportMediaOrders_APPath.MaxFileSize = CType(0, Long)
            Me.TextBoxExportMediaOrders_APPath.Name = "TextBoxExportMediaOrders_APPath"
            Me.TextBoxExportMediaOrders_APPath.SecurityEnabled = True
            Me.TextBoxExportMediaOrders_APPath.ShowSpellCheckCompleteMessage = True
            Me.TextBoxExportMediaOrders_APPath.Size = New System.Drawing.Size(773, 21)
            Me.TextBoxExportMediaOrders_APPath.StartingFolderName = Nothing
            Me.TextBoxExportMediaOrders_APPath.TabIndex = 12
            Me.TextBoxExportMediaOrders_APPath.TabOnEnter = True
            '
            'LabelExportMediaOrders_APPath
            '
            Me.LabelExportMediaOrders_APPath.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelExportMediaOrders_APPath.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelExportMediaOrders_APPath.Location = New System.Drawing.Point(3, 25)
            Me.LabelExportMediaOrders_APPath.Name = "LabelExportMediaOrders_APPath"
            Me.LabelExportMediaOrders_APPath.Size = New System.Drawing.Size(144, 20)
            Me.LabelExportMediaOrders_APPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelExportMediaOrders_APPath.TabIndex = 11
            Me.LabelExportMediaOrders_APPath.Text = "Export from AP Path:"
            '
            'LabelExportMediaOrders_MediaPlanPath
            '
            Me.LabelExportMediaOrders_MediaPlanPath.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelExportMediaOrders_MediaPlanPath.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelExportMediaOrders_MediaPlanPath.Location = New System.Drawing.Point(3, 53)
            Me.LabelExportMediaOrders_MediaPlanPath.Name = "LabelExportMediaOrders_MediaPlanPath"
            Me.LabelExportMediaOrders_MediaPlanPath.Size = New System.Drawing.Size(144, 20)
            Me.LabelExportMediaOrders_MediaPlanPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelExportMediaOrders_MediaPlanPath.TabIndex = 13
            Me.LabelExportMediaOrders_MediaPlanPath.Text = "Export from Media Plan Path:"
            '
            'CheckBoxSettings_UseAPAccountOnImport
            '
            Me.CheckBoxSettings_UseAPAccountOnImport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxSettings_UseAPAccountOnImport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSettings_UseAPAccountOnImport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSettings_UseAPAccountOnImport.CheckValue = CType(0, Short)
            Me.CheckBoxSettings_UseAPAccountOnImport.CheckValueChecked = CType(1, Short)
            Me.CheckBoxSettings_UseAPAccountOnImport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxSettings_UseAPAccountOnImport.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxSettings_UseAPAccountOnImport.ChildControls = CType(resources.GetObject("CheckBoxSettings_UseAPAccountOnImport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettings_UseAPAccountOnImport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSettings_UseAPAccountOnImport.Location = New System.Drawing.Point(262, 80)
            Me.CheckBoxSettings_UseAPAccountOnImport.Name = "CheckBoxSettings_UseAPAccountOnImport"
            Me.CheckBoxSettings_UseAPAccountOnImport.OldestSibling = Nothing
            Me.CheckBoxSettings_UseAPAccountOnImport.SecurityEnabled = True
            Me.CheckBoxSettings_UseAPAccountOnImport.SiblingControls = CType(resources.GetObject("CheckBoxSettings_UseAPAccountOnImport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettings_UseAPAccountOnImport.Size = New System.Drawing.Size(675, 20)
            Me.CheckBoxSettings_UseAPAccountOnImport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSettings_UseAPAccountOnImport.TabIndex = 9
            Me.CheckBoxSettings_UseAPAccountOnImport.TabOnEnter = True
            Me.CheckBoxSettings_UseAPAccountOnImport.Text = "Use A/P account from office when importing"
            '
            'LabelSettings_MediaImportDefault
            '
            Me.LabelSettings_MediaImportDefault.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_MediaImportDefault.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_MediaImportDefault.Location = New System.Drawing.Point(4, 4)
            Me.LabelSettings_MediaImportDefault.Name = "LabelSettings_MediaImportDefault"
            Me.LabelSettings_MediaImportDefault.Size = New System.Drawing.Size(144, 20)
            Me.LabelSettings_MediaImportDefault.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_MediaImportDefault.TabIndex = 0
            Me.LabelSettings_MediaImportDefault.Text = "Media Import Default:"
            '
            'CheckBoxSettings_RenameFinanceFile
            '
            Me.CheckBoxSettings_RenameFinanceFile.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSettings_RenameFinanceFile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSettings_RenameFinanceFile.CheckValue = CType(0, Short)
            Me.CheckBoxSettings_RenameFinanceFile.CheckValueChecked = CType(1, Short)
            Me.CheckBoxSettings_RenameFinanceFile.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxSettings_RenameFinanceFile.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxSettings_RenameFinanceFile.ChildControls = CType(resources.GetObject("CheckBoxSettings_RenameFinanceFile.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettings_RenameFinanceFile.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSettings_RenameFinanceFile.Location = New System.Drawing.Point(3, 79)
            Me.CheckBoxSettings_RenameFinanceFile.Name = "CheckBoxSettings_RenameFinanceFile"
            Me.CheckBoxSettings_RenameFinanceFile.OldestSibling = Nothing
            Me.CheckBoxSettings_RenameFinanceFile.SecurityEnabled = True
            Me.CheckBoxSettings_RenameFinanceFile.SiblingControls = CType(resources.GetObject("CheckBoxSettings_RenameFinanceFile.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettings_RenameFinanceFile.Size = New System.Drawing.Size(253, 20)
            Me.CheckBoxSettings_RenameFinanceFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSettings_RenameFinanceFile.TabIndex = 8
            Me.CheckBoxSettings_RenameFinanceFile.TabOnEnter = True
            Me.CheckBoxSettings_RenameFinanceFile.Text = "Rename the Finance.dat file after import"
            '
            'TextBoxSettings_ImportPath
            '
            Me.TextBoxSettings_ImportPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSettings_ImportPath.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSettings_ImportPath.Border.Class = "TextBoxBorder"
            Me.TextBoxSettings_ImportPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSettings_ImportPath.ButtonCustom.Visible = True
            Me.TextBoxSettings_ImportPath.CheckSpellingOnValidate = False
            Me.TextBoxSettings_ImportPath.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxSettings_ImportPath.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxSettings_ImportPath.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSettings_ImportPath.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSettings_ImportPath.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSettings_ImportPath.FocusHighlightEnabled = True
            Me.TextBoxSettings_ImportPath.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSettings_ImportPath.Location = New System.Drawing.Point(154, 54)
            Me.TextBoxSettings_ImportPath.MaxFileSize = CType(0, Long)
            Me.TextBoxSettings_ImportPath.Name = "TextBoxSettings_ImportPath"
            Me.TextBoxSettings_ImportPath.SecurityEnabled = True
            Me.TextBoxSettings_ImportPath.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSettings_ImportPath.Size = New System.Drawing.Size(784, 20)
            Me.TextBoxSettings_ImportPath.StartingFolderName = Nothing
            Me.TextBoxSettings_ImportPath.TabIndex = 7
            Me.TextBoxSettings_ImportPath.TabOnEnter = True
            '
            'TextBoxSettings_StrataConnectPath
            '
            Me.TextBoxSettings_StrataConnectPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSettings_StrataConnectPath.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSettings_StrataConnectPath.Border.Class = "TextBoxBorder"
            Me.TextBoxSettings_StrataConnectPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSettings_StrataConnectPath.ButtonCustom.Visible = True
            Me.TextBoxSettings_StrataConnectPath.CheckSpellingOnValidate = False
            Me.TextBoxSettings_StrataConnectPath.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxSettings_StrataConnectPath.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxSettings_StrataConnectPath.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSettings_StrataConnectPath.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSettings_StrataConnectPath.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSettings_StrataConnectPath.FocusHighlightEnabled = True
            Me.TextBoxSettings_StrataConnectPath.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSettings_StrataConnectPath.Location = New System.Drawing.Point(154, 29)
            Me.TextBoxSettings_StrataConnectPath.MaxFileSize = CType(0, Long)
            Me.TextBoxSettings_StrataConnectPath.Name = "TextBoxSettings_StrataConnectPath"
            Me.TextBoxSettings_StrataConnectPath.SecurityEnabled = True
            Me.TextBoxSettings_StrataConnectPath.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSettings_StrataConnectPath.Size = New System.Drawing.Size(784, 20)
            Me.TextBoxSettings_StrataConnectPath.StartingFolderName = Nothing
            Me.TextBoxSettings_StrataConnectPath.TabIndex = 5
            Me.TextBoxSettings_StrataConnectPath.TabOnEnter = True
            '
            'ComboBoxSettings_MediaImportDefault
            '
            Me.ComboBoxSettings_MediaImportDefault.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSettings_MediaImportDefault.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxSettings_MediaImportDefault.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxSettings_MediaImportDefault.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSettings_MediaImportDefault.AutoFindItemInDataSource = False
            Me.ComboBoxSettings_MediaImportDefault.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSettings_MediaImportDefault.BookmarkingEnabled = False
            Me.ComboBoxSettings_MediaImportDefault.ClientCode = ""
            Me.ComboBoxSettings_MediaImportDefault.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.MediaImportOption
            Me.ComboBoxSettings_MediaImportDefault.DisableMouseWheel = False
            Me.ComboBoxSettings_MediaImportDefault.DisplayMember = "Description"
            Me.ComboBoxSettings_MediaImportDefault.DisplayName = ""
            Me.ComboBoxSettings_MediaImportDefault.DivisionCode = ""
            Me.ComboBoxSettings_MediaImportDefault.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSettings_MediaImportDefault.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxSettings_MediaImportDefault.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxSettings_MediaImportDefault.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSettings_MediaImportDefault.FocusHighlightEnabled = True
            Me.ComboBoxSettings_MediaImportDefault.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxSettings_MediaImportDefault.FormattingEnabled = True
            Me.ComboBoxSettings_MediaImportDefault.ItemHeight = 14
            Me.ComboBoxSettings_MediaImportDefault.Location = New System.Drawing.Point(154, 4)
            Me.ComboBoxSettings_MediaImportDefault.Name = "ComboBoxSettings_MediaImportDefault"
            Me.ComboBoxSettings_MediaImportDefault.ReadOnly = False
            Me.ComboBoxSettings_MediaImportDefault.SecurityEnabled = True
            Me.ComboBoxSettings_MediaImportDefault.Size = New System.Drawing.Size(784, 20)
            Me.ComboBoxSettings_MediaImportDefault.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSettings_MediaImportDefault.TabIndex = 1
            Me.ComboBoxSettings_MediaImportDefault.TabOnEnter = True
            Me.ComboBoxSettings_MediaImportDefault.ValueMember = "Code"
            Me.ComboBoxSettings_MediaImportDefault.WatermarkText = "Selected Media Import Option"
            '
            'LabelSettings_StrataConnectPath
            '
            Me.LabelSettings_StrataConnectPath.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_StrataConnectPath.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_StrataConnectPath.Location = New System.Drawing.Point(4, 29)
            Me.LabelSettings_StrataConnectPath.Name = "LabelSettings_StrataConnectPath"
            Me.LabelSettings_StrataConnectPath.Size = New System.Drawing.Size(144, 20)
            Me.LabelSettings_StrataConnectPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_StrataConnectPath.TabIndex = 4
            Me.LabelSettings_StrataConnectPath.Text = "StrataConnect Path:"
            '
            'LabelSettings_ImportPath
            '
            Me.LabelSettings_ImportPath.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_ImportPath.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_ImportPath.Location = New System.Drawing.Point(4, 54)
            Me.LabelSettings_ImportPath.Name = "LabelSettings_ImportPath"
            Me.LabelSettings_ImportPath.Size = New System.Drawing.Size(144, 20)
            Me.LabelSettings_ImportPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_ImportPath.TabIndex = 6
            Me.LabelSettings_ImportPath.Text = "Import Path:"
            '
            'TabItemMediaOptions_SettingsTab
            '
            Me.TabItemMediaOptions_SettingsTab.AttachedControl = Me.TabControlPanelSettingsTab_Settings
            Me.TabItemMediaOptions_SettingsTab.Name = "TabItemMediaOptions_SettingsTab"
            Me.TabItemMediaOptions_SettingsTab.Text = "Settings"
            '
            'TabControlPanelAdServingTab_AdServing
            '
            Me.TabControlPanelAdServingTab_AdServing.Controls.Add(Me.PanelAdServing_RightSection)
            Me.TabControlPanelAdServingTab_AdServing.Controls.Add(Me.ExpandableSplitterAdServingFields_LeftRight)
            Me.TabControlPanelAdServingTab_AdServing.Controls.Add(Me.PanelAdServing_LeftSection)
            Me.TabControlPanelAdServingTab_AdServing.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAdServingTab_AdServing.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAdServingTab_AdServing.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAdServingTab_AdServing.Name = "TabControlPanelAdServingTab_AdServing"
            Me.TabControlPanelAdServingTab_AdServing.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAdServingTab_AdServing.Size = New System.Drawing.Size(941, 577)
            Me.TabControlPanelAdServingTab_AdServing.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAdServingTab_AdServing.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAdServingTab_AdServing.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAdServingTab_AdServing.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAdServingTab_AdServing.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAdServingTab_AdServing.Style.GradientAngle = 90
            Me.TabControlPanelAdServingTab_AdServing.TabIndex = 19
            Me.TabControlPanelAdServingTab_AdServing.TabItem = Me.TabItemMediaOptions_AdServing
            '
            'PanelAdServing_RightSection
            '
            Me.PanelAdServing_RightSection.Controls.Add(Me.ButtonRightSection_AddToAdServingFields)
            Me.PanelAdServing_RightSection.Controls.Add(Me.ButtonRightSection_RemoveFromAdServingFields)
            Me.PanelAdServing_RightSection.Controls.Add(Me.DataGridViewRightSection_AdServingFields)
            Me.PanelAdServing_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelAdServing_RightSection.Location = New System.Drawing.Point(347, 1)
            Me.PanelAdServing_RightSection.Name = "PanelAdServing_RightSection"
            Me.PanelAdServing_RightSection.Size = New System.Drawing.Size(593, 575)
            Me.PanelAdServing_RightSection.TabIndex = 7
            '
            'ButtonRightSection_AddToAdServingFields
            '
            Me.ButtonRightSection_AddToAdServingFields.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddToAdServingFields.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddToAdServingFields.Location = New System.Drawing.Point(5, 5)
            Me.ButtonRightSection_AddToAdServingFields.Name = "ButtonRightSection_AddToAdServingFields"
            Me.ButtonRightSection_AddToAdServingFields.SecurityEnabled = True
            Me.ButtonRightSection_AddToAdServingFields.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddToAdServingFields.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddToAdServingFields.TabIndex = 1
            Me.ButtonRightSection_AddToAdServingFields.Text = ">"
            '
            'ButtonRightSection_RemoveFromAdServingFields
            '
            Me.ButtonRightSection_RemoveFromAdServingFields.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveFromAdServingFields.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveFromAdServingFields.Location = New System.Drawing.Point(5, 31)
            Me.ButtonRightSection_RemoveFromAdServingFields.Name = "ButtonRightSection_RemoveFromAdServingFields"
            Me.ButtonRightSection_RemoveFromAdServingFields.SecurityEnabled = True
            Me.ButtonRightSection_RemoveFromAdServingFields.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveFromAdServingFields.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveFromAdServingFields.TabIndex = 2
            Me.ButtonRightSection_RemoveFromAdServingFields.Text = "<"
            '
            'DataGridViewRightSection_AdServingFields
            '
            Me.DataGridViewRightSection_AdServingFields.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightSection_AdServingFields.AllowDragAndDrop = False
            Me.DataGridViewRightSection_AdServingFields.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_AdServingFields.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_AdServingFields.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_AdServingFields.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_AdServingFields.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_AdServingFields.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_AdServingFields.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_AdServingFields.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewRightSection_AdServingFields.DataSource = Nothing
            Me.DataGridViewRightSection_AdServingFields.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_AdServingFields.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_AdServingFields.ItemDescription = "Selected Field(s)"
            Me.DataGridViewRightSection_AdServingFields.Location = New System.Drawing.Point(86, 5)
            Me.DataGridViewRightSection_AdServingFields.MultiSelect = True
            Me.DataGridViewRightSection_AdServingFields.Name = "DataGridViewRightSection_AdServingFields"
            Me.DataGridViewRightSection_AdServingFields.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_AdServingFields.RunStandardValidation = True
            Me.DataGridViewRightSection_AdServingFields.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightSection_AdServingFields.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_AdServingFields.Size = New System.Drawing.Size(502, 565)
            Me.DataGridViewRightSection_AdServingFields.TabIndex = 3
            Me.DataGridViewRightSection_AdServingFields.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_AdServingFields.ViewCaptionHeight = -1
            '
            'ExpandableSplitterAdServingFields_LeftRight
            '
            Me.ExpandableSplitterAdServingFields_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterAdServingFields_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterAdServingFields_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterAdServingFields_LeftRight.ExpandableControl = Me.PanelAdServing_LeftSection
            Me.ExpandableSplitterAdServingFields_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterAdServingFields_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterAdServingFields_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterAdServingFields_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterAdServingFields_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterAdServingFields_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterAdServingFields_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterAdServingFields_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterAdServingFields_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterAdServingFields_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterAdServingFields_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterAdServingFields_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterAdServingFields_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterAdServingFields_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterAdServingFields_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterAdServingFields_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterAdServingFields_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterAdServingFields_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterAdServingFields_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterAdServingFields_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterAdServingFields_LeftRight.Location = New System.Drawing.Point(341, 1)
            Me.ExpandableSplitterAdServingFields_LeftRight.Name = "ExpandableSplitterAdServingFields_LeftRight"
            Me.ExpandableSplitterAdServingFields_LeftRight.Size = New System.Drawing.Size(6, 575)
            Me.ExpandableSplitterAdServingFields_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterAdServingFields_LeftRight.TabIndex = 6
            Me.ExpandableSplitterAdServingFields_LeftRight.TabStop = False
            '
            'PanelAdServing_LeftSection
            '
            Me.PanelAdServing_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelAdServing_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelAdServing_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableFields)
            Me.PanelAdServing_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelAdServing_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelAdServing_LeftSection.Name = "PanelAdServing_LeftSection"
            Me.PanelAdServing_LeftSection.Size = New System.Drawing.Size(340, 575)
            Me.PanelAdServing_LeftSection.TabIndex = 5
            '
            'DataGridViewLeftSection_AvailableFields
            '
            Me.DataGridViewLeftSection_AvailableFields.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_AvailableFields.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_AvailableFields.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_AvailableFields.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableFields.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableFields.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableFields.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AvailableFields.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AvailableFields.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_AvailableFields.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_AvailableFields.DataSource = Nothing
            Me.DataGridViewLeftSection_AvailableFields.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_AvailableFields.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableFields.ItemDescription = "Available Field(s)"
            Me.DataGridViewLeftSection_AvailableFields.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewLeftSection_AvailableFields.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableFields.Name = "DataGridViewLeftSection_AvailableFields"
            Me.DataGridViewLeftSection_AvailableFields.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableFields.RunStandardValidation = True
            Me.DataGridViewLeftSection_AvailableFields.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_AvailableFields.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableFields.Size = New System.Drawing.Size(329, 565)
            Me.DataGridViewLeftSection_AvailableFields.TabIndex = 0
            Me.DataGridViewLeftSection_AvailableFields.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableFields.ViewCaptionHeight = -1
            '
            'TabItemMediaOptions_AdServing
            '
            Me.TabItemMediaOptions_AdServing.AttachedControl = Me.TabControlPanelAdServingTab_AdServing
            Me.TabItemMediaOptions_AdServing.Name = "TabItemMediaOptions_AdServing"
            Me.TabItemMediaOptions_AdServing.Text = "Ad Serving Placement Name"
            '
            'TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms
            '
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.Controls.Add(Me.TextBoxSettingsForWebFormTerms_WebFormTerms)
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.Name = "TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms"
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.Size = New System.Drawing.Size(941, 577)
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.Style.GradientAngle = 90
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.TabIndex = 3
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.TabItem = Me.TabItemMediaOptions_SettingsForWebFormTermsTab
            '
            'TextBoxSettingsForWebFormTerms_WebFormTerms
            '
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.Border.Class = "TextBoxBorder"
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.CheckSpellingOnValidate = False
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.FocusHighlightEnabled = True
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.Location = New System.Drawing.Point(4, 4)
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.MaxFileSize = CType(0, Long)
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.Multiline = True
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.Name = "TextBoxSettingsForWebFormTerms_WebFormTerms"
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.SecurityEnabled = True
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.Size = New System.Drawing.Size(934, 569)
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.StartingFolderName = Nothing
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.TabIndex = 1
            Me.TextBoxSettingsForWebFormTerms_WebFormTerms.TabOnEnter = False
            '
            'TabItemMediaOptions_SettingsForWebFormTermsTab
            '
            Me.TabItemMediaOptions_SettingsForWebFormTermsTab.AttachedControl = Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms
            Me.TabItemMediaOptions_SettingsForWebFormTermsTab.Name = "TabItemMediaOptions_SettingsForWebFormTermsTab"
            Me.TabItemMediaOptions_SettingsForWebFormTermsTab.Text = "Settings for Web Form Terms"
            '
            'TabItemAgencySetup_MediaOptionsTab
            '
            Me.TabItemAgencySetup_MediaOptionsTab.AttachedControl = Me.TabControlPanelMediaOptionsTab_MediaOptions
            Me.TabItemAgencySetup_MediaOptionsTab.Name = "TabItemAgencySetup_MediaOptionsTab"
            Me.TabItemAgencySetup_MediaOptionsTab.Text = "Media Options"
            '
            'TabControlPanelTimesheetOptionsTab_TimesheetOptions
            '
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.Controls.Add(Me.GroupBoxTimesheetOptions_MissingTimeOptions)
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.Controls.Add(Me.GroupBoxTimesheetOptions_TimesheetOptions)
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.Name = "TabControlPanelTimesheetOptionsTab_TimesheetOptions"
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.Size = New System.Drawing.Size(950, 612)
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.Style.GradientAngle = 90
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.TabIndex = 5
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.TabItem = Me.TabItemAgencySetup_TimesheetOptionsTab
            '
            'GroupBoxTimesheetOptions_MissingTimeOptions
            '
            Me.GroupBoxTimesheetOptions_MissingTimeOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxTimesheetOptions_MissingTimeOptions.Controls.Add(Me.CheckBoxMissingTimeOptions_NotifySupervisor)
            Me.GroupBoxTimesheetOptions_MissingTimeOptions.Controls.Add(Me.RadioButtonMissingTimeOptions_ByWeek)
            Me.GroupBoxTimesheetOptions_MissingTimeOptions.Controls.Add(Me.RadioButtonMissingTimeOptions_ByDay)
            Me.GroupBoxTimesheetOptions_MissingTimeOptions.Controls.Add(Me.TextBoxMissingTimeOptions_ITEMail)
            Me.GroupBoxTimesheetOptions_MissingTimeOptions.Controls.Add(Me.LabelMissingTimeOptions_ITEMail)
            Me.GroupBoxTimesheetOptions_MissingTimeOptions.Controls.Add(Me.LabelMissingTimeOptions_ReportMissingTime)
            Me.GroupBoxTimesheetOptions_MissingTimeOptions.Location = New System.Drawing.Point(314, 4)
            Me.GroupBoxTimesheetOptions_MissingTimeOptions.Name = "GroupBoxTimesheetOptions_MissingTimeOptions"
            Me.GroupBoxTimesheetOptions_MissingTimeOptions.Size = New System.Drawing.Size(632, 103)
            Me.GroupBoxTimesheetOptions_MissingTimeOptions.TabIndex = 12
            Me.GroupBoxTimesheetOptions_MissingTimeOptions.Text = "Missing Time Options"
            '
            'CheckBoxMissingTimeOptions_NotifySupervisor
            '
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.CheckValue = CType(0, Short)
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.ChildControls = CType(resources.GetObject("CheckBoxMissingTimeOptions_NotifySupervisor.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.Name = "CheckBoxMissingTimeOptions_NotifySupervisor"
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.OldestSibling = Nothing
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.SecurityEnabled = True
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.SiblingControls = CType(resources.GetObject("CheckBoxMissingTimeOptions_NotifySupervisor.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.Size = New System.Drawing.Size(622, 20)
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.TabIndex = 13
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.TabOnEnter = True
            Me.CheckBoxMissingTimeOptions_NotifySupervisor.Text = "Notify Supervisor when Severe Offender Enters Time"
            '
            'RadioButtonMissingTimeOptions_ByWeek
            '
            Me.RadioButtonMissingTimeOptions_ByWeek.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMissingTimeOptions_ByWeek.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMissingTimeOptions_ByWeek.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMissingTimeOptions_ByWeek.Location = New System.Drawing.Point(196, 77)
            Me.RadioButtonMissingTimeOptions_ByWeek.Name = "RadioButtonMissingTimeOptions_ByWeek"
            Me.RadioButtonMissingTimeOptions_ByWeek.SecurityEnabled = True
            Me.RadioButtonMissingTimeOptions_ByWeek.Size = New System.Drawing.Size(100, 20)
            Me.RadioButtonMissingTimeOptions_ByWeek.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMissingTimeOptions_ByWeek.TabIndex = 18
            Me.RadioButtonMissingTimeOptions_ByWeek.TabOnEnter = True
            Me.RadioButtonMissingTimeOptions_ByWeek.TabStop = False
            Me.RadioButtonMissingTimeOptions_ByWeek.Text = "By Week"
            '
            'RadioButtonMissingTimeOptions_ByDay
            '
            Me.RadioButtonMissingTimeOptions_ByDay.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonMissingTimeOptions_ByDay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonMissingTimeOptions_ByDay.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonMissingTimeOptions_ByDay.Location = New System.Drawing.Point(127, 77)
            Me.RadioButtonMissingTimeOptions_ByDay.Name = "RadioButtonMissingTimeOptions_ByDay"
            Me.RadioButtonMissingTimeOptions_ByDay.SecurityEnabled = True
            Me.RadioButtonMissingTimeOptions_ByDay.Size = New System.Drawing.Size(63, 20)
            Me.RadioButtonMissingTimeOptions_ByDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonMissingTimeOptions_ByDay.TabIndex = 17
            Me.RadioButtonMissingTimeOptions_ByDay.TabOnEnter = True
            Me.RadioButtonMissingTimeOptions_ByDay.TabStop = False
            Me.RadioButtonMissingTimeOptions_ByDay.Text = "By Day"
            '
            'TextBoxMissingTimeOptions_ITEMail
            '
            Me.TextBoxMissingTimeOptions_ITEMail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxMissingTimeOptions_ITEMail.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxMissingTimeOptions_ITEMail.Border.Class = "TextBoxBorder"
            Me.TextBoxMissingTimeOptions_ITEMail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxMissingTimeOptions_ITEMail.CheckSpellingOnValidate = False
            Me.TextBoxMissingTimeOptions_ITEMail.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Email
            Me.TextBoxMissingTimeOptions_ITEMail.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxMissingTimeOptions_ITEMail.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxMissingTimeOptions_ITEMail.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxMissingTimeOptions_ITEMail.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxMissingTimeOptions_ITEMail.FocusHighlightEnabled = True
            Me.TextBoxMissingTimeOptions_ITEMail.ForeColor = System.Drawing.Color.Black
            Me.TextBoxMissingTimeOptions_ITEMail.Location = New System.Drawing.Point(127, 51)
            Me.TextBoxMissingTimeOptions_ITEMail.MaxFileSize = CType(0, Long)
            Me.TextBoxMissingTimeOptions_ITEMail.Name = "TextBoxMissingTimeOptions_ITEMail"
            Me.TextBoxMissingTimeOptions_ITEMail.SecurityEnabled = True
            Me.TextBoxMissingTimeOptions_ITEMail.ShowSpellCheckCompleteMessage = True
            Me.TextBoxMissingTimeOptions_ITEMail.Size = New System.Drawing.Size(500, 21)
            Me.TextBoxMissingTimeOptions_ITEMail.StartingFolderName = Nothing
            Me.TextBoxMissingTimeOptions_ITEMail.TabIndex = 15
            Me.TextBoxMissingTimeOptions_ITEMail.TabOnEnter = True
            '
            'LabelMissingTimeOptions_ITEMail
            '
            Me.LabelMissingTimeOptions_ITEMail.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMissingTimeOptions_ITEMail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMissingTimeOptions_ITEMail.Location = New System.Drawing.Point(5, 51)
            Me.LabelMissingTimeOptions_ITEMail.Name = "LabelMissingTimeOptions_ITEMail"
            Me.LabelMissingTimeOptions_ITEMail.Size = New System.Drawing.Size(116, 20)
            Me.LabelMissingTimeOptions_ITEMail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMissingTimeOptions_ITEMail.TabIndex = 14
            Me.LabelMissingTimeOptions_ITEMail.Text = "IT E-Mail:"
            '
            'LabelMissingTimeOptions_ReportMissingTime
            '
            Me.LabelMissingTimeOptions_ReportMissingTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMissingTimeOptions_ReportMissingTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMissingTimeOptions_ReportMissingTime.Location = New System.Drawing.Point(5, 77)
            Me.LabelMissingTimeOptions_ReportMissingTime.Name = "LabelMissingTimeOptions_ReportMissingTime"
            Me.LabelMissingTimeOptions_ReportMissingTime.Size = New System.Drawing.Size(116, 20)
            Me.LabelMissingTimeOptions_ReportMissingTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMissingTimeOptions_ReportMissingTime.TabIndex = 16
            Me.LabelMissingTimeOptions_ReportMissingTime.Text = "Report Missing Time:"
            '
            'GroupBoxTimesheetOptions_TimesheetOptions
            '
            Me.GroupBoxTimesheetOptions_TimesheetOptions.Controls.Add(Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded)
            Me.GroupBoxTimesheetOptions_TimesheetOptions.Controls.Add(Me.CheckBoxTimesheetOptions_AllowCopyHours)
            Me.GroupBoxTimesheetOptions_TimesheetOptions.Controls.Add(Me.ComboBoxTimesheetOptions_DefaultDisplayDays)
            Me.GroupBoxTimesheetOptions_TimesheetOptions.Controls.Add(Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet)
            Me.GroupBoxTimesheetOptions_TimesheetOptions.Controls.Add(Me.CheckBoxTimesheetOptions_SupervisorApprovalActive)
            Me.GroupBoxTimesheetOptions_TimesheetOptions.Controls.Add(Me.LabelTimesheetOptions_DefaultDisplayDays)
            Me.GroupBoxTimesheetOptions_TimesheetOptions.Controls.Add(Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime)
            Me.GroupBoxTimesheetOptions_TimesheetOptions.Controls.Add(Me.CheckBoxTimesheetOptions_RequireTimeComments)
            Me.GroupBoxTimesheetOptions_TimesheetOptions.Controls.Add(Me.CheckBoxTimesheetOptions_AutoAlertSupervisor)
            Me.GroupBoxTimesheetOptions_TimesheetOptions.Controls.Add(Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods)
            Me.GroupBoxTimesheetOptions_TimesheetOptions.Controls.Add(Me.CheckBoxTimesheetOptions_UseCopyTimesheet)
            Me.GroupBoxTimesheetOptions_TimesheetOptions.Controls.Add(Me.CheckBoxTimesheetOptions_UseBatchMethod)
            Me.GroupBoxTimesheetOptions_TimesheetOptions.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxTimesheetOptions_TimesheetOptions.Name = "GroupBoxTimesheetOptions_TimesheetOptions"
            Me.GroupBoxTimesheetOptions_TimesheetOptions.Size = New System.Drawing.Size(304, 329)
            Me.GroupBoxTimesheetOptions_TimesheetOptions.TabIndex = 0
            Me.GroupBoxTimesheetOptions_TimesheetOptions.Text = "Timesheet Options"
            '
            'CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded
            '
            '
            '
            '
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.CheckValue = CType(0, Short)
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.CheckValueChecked = CType(1, Short)
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.ChildControls = Nothing
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.Location = New System.Drawing.Point(3, 295)
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.Name = "CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded"
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.OldestSibling = Nothing
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.SecurityEnabled = True
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.SiblingControls = Nothing
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.Size = New System.Drawing.Size(293, 20)
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.TabIndex = 12
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.TabOnEnter = True
            Me.CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded.Text = "Add unique row when comments are included"
            '
            'CheckBoxTimesheetOptions_AllowCopyHours
            '
            '
            '
            '
            Me.CheckBoxTimesheetOptions_AllowCopyHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTimesheetOptions_AllowCopyHours.CheckValue = CType(0, Short)
            Me.CheckBoxTimesheetOptions_AllowCopyHours.CheckValueChecked = CType(1, Short)
            Me.CheckBoxTimesheetOptions_AllowCopyHours.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxTimesheetOptions_AllowCopyHours.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxTimesheetOptions_AllowCopyHours.ChildControls = CType(resources.GetObject("CheckBoxTimesheetOptions_AllowCopyHours.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_AllowCopyHours.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTimesheetOptions_AllowCopyHours.Location = New System.Drawing.Point(6, 77)
            Me.CheckBoxTimesheetOptions_AllowCopyHours.Name = "CheckBoxTimesheetOptions_AllowCopyHours"
            Me.CheckBoxTimesheetOptions_AllowCopyHours.OldestSibling = Nothing
            Me.CheckBoxTimesheetOptions_AllowCopyHours.SecurityEnabled = True
            Me.CheckBoxTimesheetOptions_AllowCopyHours.SiblingControls = CType(resources.GetObject("CheckBoxTimesheetOptions_AllowCopyHours.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_AllowCopyHours.Size = New System.Drawing.Size(293, 20)
            Me.CheckBoxTimesheetOptions_AllowCopyHours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTimesheetOptions_AllowCopyHours.TabIndex = 2
            Me.CheckBoxTimesheetOptions_AllowCopyHours.TabOnEnter = True
            Me.CheckBoxTimesheetOptions_AllowCopyHours.Text = "Allow copy of timesheet hours"
            '
            'ComboBoxTimesheetOptions_DefaultDisplayDays
            '
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.AutoFindItemInDataSource = False
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.AutoSelectSingleItemDatasource = False
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.BookmarkingEnabled = False
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.ClientCode = ""
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.ShortNumeric
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.DisableMouseWheel = False
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.DisplayMember = "Number"
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.DisplayName = ""
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.DivisionCode = ""
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.FocusHighlightEnabled = True
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.FormattingEnabled = True
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.ItemHeight = 16
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.Location = New System.Drawing.Point(121, 261)
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.Name = "ComboBoxTimesheetOptions_DefaultDisplayDays"
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.ReadOnly = False
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.SecurityEnabled = True
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.Size = New System.Drawing.Size(179, 22)
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.TabIndex = 11
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.TabOnEnter = True
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.ValueMember = "Number"
            Me.ComboBoxTimesheetOptions_DefaultDisplayDays.WatermarkText = "Select"
            '
            'CheckBoxTimesheetOptions_AllowDrillDownTimesheet
            '
            '
            '
            '
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.CheckValue = CType(0, Short)
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.CheckValueChecked = CType(1, Short)
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.ChildControls = CType(resources.GetObject("CheckBoxTimesheetOptions_AllowDrillDownTimesheet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.Location = New System.Drawing.Point(6, 156)
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.Name = "CheckBoxTimesheetOptions_AllowDrillDownTimesheet"
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.OldestSibling = Nothing
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.SecurityEnabled = True
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.SiblingControls = CType(resources.GetObject("CheckBoxTimesheetOptions_AllowDrillDownTimesheet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.Size = New System.Drawing.Size(293, 20)
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.TabIndex = 6
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.TabOnEnter = True
            Me.CheckBoxTimesheetOptions_AllowDrillDownTimesheet.Text = "Allow QvA drill-down in Timesheets"
            '
            'CheckBoxTimesheetOptions_SupervisorApprovalActive
            '
            '
            '
            '
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.CheckValue = CType(0, Short)
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.CheckValueChecked = CType(1, Short)
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.ChildControls = CType(resources.GetObject("CheckBoxTimesheetOptions_SupervisorApprovalActive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.Location = New System.Drawing.Point(6, 182)
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.Name = "CheckBoxTimesheetOptions_SupervisorApprovalActive"
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.OldestSibling = Nothing
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.SecurityEnabled = True
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.SiblingControls = CType(resources.GetObject("CheckBoxTimesheetOptions_SupervisorApprovalActive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.Size = New System.Drawing.Size(293, 20)
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.TabIndex = 7
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.TabOnEnter = True
            Me.CheckBoxTimesheetOptions_SupervisorApprovalActive.Text = "Supervisor approval active"
            '
            'LabelTimesheetOptions_DefaultDisplayDays
            '
            Me.LabelTimesheetOptions_DefaultDisplayDays.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTimesheetOptions_DefaultDisplayDays.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTimesheetOptions_DefaultDisplayDays.Location = New System.Drawing.Point(4, 261)
            Me.LabelTimesheetOptions_DefaultDisplayDays.Name = "LabelTimesheetOptions_DefaultDisplayDays"
            Me.LabelTimesheetOptions_DefaultDisplayDays.Size = New System.Drawing.Size(111, 20)
            Me.LabelTimesheetOptions_DefaultDisplayDays.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTimesheetOptions_DefaultDisplayDays.TabIndex = 10
            Me.LabelTimesheetOptions_DefaultDisplayDays.Text = "Default Display Days:"
            '
            'CheckBoxTimesheetOptions_SupervisiorCanEditTime
            '
            '
            '
            '
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.CheckValue = CType(0, Short)
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.CheckValueChecked = CType(1, Short)
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.ChildControls = CType(resources.GetObject("CheckBoxTimesheetOptions_SupervisiorCanEditTime.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.Location = New System.Drawing.Point(22, 209)
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.Name = "CheckBoxTimesheetOptions_SupervisiorCanEditTime"
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.OldestSibling = Nothing
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.SecurityEnabled = True
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.SiblingControls = CType(resources.GetObject("CheckBoxTimesheetOptions_SupervisiorCanEditTime.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.Size = New System.Drawing.Size(278, 20)
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.TabIndex = 8
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.TabOnEnter = True
            Me.CheckBoxTimesheetOptions_SupervisiorCanEditTime.Text = "Supervisor can edit others time (within approvals)"
            '
            'CheckBoxTimesheetOptions_RequireTimeComments
            '
            '
            '
            '
            Me.CheckBoxTimesheetOptions_RequireTimeComments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTimesheetOptions_RequireTimeComments.CheckValue = CType(0, Short)
            Me.CheckBoxTimesheetOptions_RequireTimeComments.CheckValueChecked = CType(1, Short)
            Me.CheckBoxTimesheetOptions_RequireTimeComments.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxTimesheetOptions_RequireTimeComments.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxTimesheetOptions_RequireTimeComments.ChildControls = CType(resources.GetObject("CheckBoxTimesheetOptions_RequireTimeComments.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_RequireTimeComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTimesheetOptions_RequireTimeComments.Location = New System.Drawing.Point(6, 129)
            Me.CheckBoxTimesheetOptions_RequireTimeComments.Name = "CheckBoxTimesheetOptions_RequireTimeComments"
            Me.CheckBoxTimesheetOptions_RequireTimeComments.OldestSibling = Nothing
            Me.CheckBoxTimesheetOptions_RequireTimeComments.SecurityEnabled = True
            Me.CheckBoxTimesheetOptions_RequireTimeComments.SiblingControls = CType(resources.GetObject("CheckBoxTimesheetOptions_RequireTimeComments.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_RequireTimeComments.Size = New System.Drawing.Size(293, 20)
            Me.CheckBoxTimesheetOptions_RequireTimeComments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTimesheetOptions_RequireTimeComments.TabIndex = 4
            Me.CheckBoxTimesheetOptions_RequireTimeComments.TabOnEnter = True
            Me.CheckBoxTimesheetOptions_RequireTimeComments.Text = "Require time comments"
            '
            'CheckBoxTimesheetOptions_AutoAlertSupervisor
            '
            '
            '
            '
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.CheckValue = CType(0, Short)
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.CheckValueChecked = CType(1, Short)
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.ChildControls = CType(resources.GetObject("CheckBoxTimesheetOptions_AutoAlertSupervisor.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.Location = New System.Drawing.Point(22, 235)
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.Name = "CheckBoxTimesheetOptions_AutoAlertSupervisor"
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.OldestSibling = Nothing
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.SecurityEnabled = True
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.SiblingControls = CType(resources.GetObject("CheckBoxTimesheetOptions_AutoAlertSupervisor.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.Size = New System.Drawing.Size(278, 20)
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.TabIndex = 9
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.TabOnEnter = True
            Me.CheckBoxTimesheetOptions_AutoAlertSupervisor.Text = "Auto Alert Supervisor"
            '
            'CheckBoxTimesheetOptions_CheckClosedPostingPeriods
            '
            '
            '
            '
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.CheckValue = CType(0, Short)
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.CheckValueChecked = CType(1, Short)
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.ChildControls = CType(resources.GetObject("CheckBoxTimesheetOptions_CheckClosedPostingPeriods.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.Location = New System.Drawing.Point(6, 103)
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.Name = "CheckBoxTimesheetOptions_CheckClosedPostingPeriods"
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.OldestSibling = Nothing
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.SecurityEnabled = True
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.SiblingControls = CType(resources.GetObject("CheckBoxTimesheetOptions_CheckClosedPostingPeriods.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.Size = New System.Drawing.Size(293, 20)
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.TabIndex = 3
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.TabOnEnter = True
            Me.CheckBoxTimesheetOptions_CheckClosedPostingPeriods.Text = "Check for closed posting periods"
            '
            'CheckBoxTimesheetOptions_UseCopyTimesheet
            '
            '
            '
            '
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.CheckValue = CType(0, Short)
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.CheckValueChecked = CType(1, Short)
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.ChildControls = CType(resources.GetObject("CheckBoxTimesheetOptions_UseCopyTimesheet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.Location = New System.Drawing.Point(6, 51)
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.Name = "CheckBoxTimesheetOptions_UseCopyTimesheet"
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.OldestSibling = Nothing
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.SecurityEnabled = True
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.SiblingControls = CType(resources.GetObject("CheckBoxTimesheetOptions_UseCopyTimesheet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.Size = New System.Drawing.Size(293, 20)
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.TabIndex = 1
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.TabOnEnter = True
            Me.CheckBoxTimesheetOptions_UseCopyTimesheet.Text = "Use copy timesheet feature"
            '
            'CheckBoxTimesheetOptions_UseBatchMethod
            '
            '
            '
            '
            Me.CheckBoxTimesheetOptions_UseBatchMethod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTimesheetOptions_UseBatchMethod.CheckValue = CType(0, Short)
            Me.CheckBoxTimesheetOptions_UseBatchMethod.CheckValueChecked = CType(1, Short)
            Me.CheckBoxTimesheetOptions_UseBatchMethod.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxTimesheetOptions_UseBatchMethod.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxTimesheetOptions_UseBatchMethod.ChildControls = CType(resources.GetObject("CheckBoxTimesheetOptions_UseBatchMethod.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_UseBatchMethod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTimesheetOptions_UseBatchMethod.Location = New System.Drawing.Point(6, 25)
            Me.CheckBoxTimesheetOptions_UseBatchMethod.Name = "CheckBoxTimesheetOptions_UseBatchMethod"
            Me.CheckBoxTimesheetOptions_UseBatchMethod.OldestSibling = Nothing
            Me.CheckBoxTimesheetOptions_UseBatchMethod.SecurityEnabled = True
            Me.CheckBoxTimesheetOptions_UseBatchMethod.SiblingControls = CType(resources.GetObject("CheckBoxTimesheetOptions_UseBatchMethod.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimesheetOptions_UseBatchMethod.Size = New System.Drawing.Size(293, 20)
            Me.CheckBoxTimesheetOptions_UseBatchMethod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTimesheetOptions_UseBatchMethod.TabIndex = 0
            Me.CheckBoxTimesheetOptions_UseBatchMethod.TabOnEnter = True
            Me.CheckBoxTimesheetOptions_UseBatchMethod.Text = "Use batch method to post employee time"
            '
            'TabItemAgencySetup_TimesheetOptionsTab
            '
            Me.TabItemAgencySetup_TimesheetOptionsTab.AttachedControl = Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions
            Me.TabItemAgencySetup_TimesheetOptionsTab.Name = "TabItemAgencySetup_TimesheetOptionsTab"
            Me.TabItemAgencySetup_TimesheetOptionsTab.Text = "Timesheet Options"
            '
            'TabControlPanelAccountingOptionsTab_AccountingOptions
            '
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.Controls.Add(Me.TabControlAccountingOptions_AccountingOptions)
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.Name = "TabControlPanelAccountingOptionsTab_AccountingOptions"
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.Size = New System.Drawing.Size(950, 612)
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.Style.GradientAngle = 90
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.TabIndex = 4
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.TabItem = Me.TabItemAgencySetup_AccountingOptionsTab
            '
            'TabControlAccountingOptions_AccountingOptions
            '
            Me.TabControlAccountingOptions_AccountingOptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlAccountingOptions_AccountingOptions.BackColor = System.Drawing.Color.White
            Me.TabControlAccountingOptions_AccountingOptions.CanReorderTabs = False
            Me.TabControlAccountingOptions_AccountingOptions.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlAccountingOptions_AccountingOptions.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlAccountingOptions_AccountingOptions.Controls.Add(Me.TabControlPanelAccountsPayableTab_AccountsPayable)
            Me.TabControlAccountingOptions_AccountingOptions.Controls.Add(Me.TabControlPanel1)
            Me.TabControlAccountingOptions_AccountingOptions.Controls.Add(Me.TabControlPanelMediaTab_Media)
            Me.TabControlAccountingOptions_AccountingOptions.Controls.Add(Me.TabControlPanelImportTab_Import)
            Me.TabControlAccountingOptions_AccountingOptions.Controls.Add(Me.TabControlPanelCheckWritingTab_CheckWriting)
            Me.TabControlAccountingOptions_AccountingOptions.Controls.Add(Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable)
            Me.TabControlAccountingOptions_AccountingOptions.Controls.Add(Me.TabControlPanelGLTab_GL)
            Me.TabControlAccountingOptions_AccountingOptions.Controls.Add(Me.TabControlPanelCurrencyTab_Currency)
            Me.TabControlAccountingOptions_AccountingOptions.ForeColor = System.Drawing.Color.Black
            Me.TabControlAccountingOptions_AccountingOptions.Location = New System.Drawing.Point(4, 4)
            Me.TabControlAccountingOptions_AccountingOptions.Name = "TabControlAccountingOptions_AccountingOptions"
            Me.TabControlAccountingOptions_AccountingOptions.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlAccountingOptions_AccountingOptions.SelectedTabIndex = 0
            Me.TabControlAccountingOptions_AccountingOptions.Size = New System.Drawing.Size(941, 602)
            Me.TabControlAccountingOptions_AccountingOptions.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlAccountingOptions_AccountingOptions.TabIndex = 0
            Me.TabControlAccountingOptions_AccountingOptions.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlAccountingOptions_AccountingOptions.Tabs.Add(Me.TabItemAccountingOptions_AccountsPayableTab)
            Me.TabControlAccountingOptions_AccountingOptions.Tabs.Add(Me.TabItemAccountingOptions_CheckWritingTab)
            Me.TabControlAccountingOptions_AccountingOptions.Tabs.Add(Me.TabItemAccountingOptions_BillingAndAccountsReceivableTab)
            Me.TabControlAccountingOptions_AccountingOptions.Tabs.Add(Me.TabItemAccountingOptions_GLTab)
            Me.TabControlAccountingOptions_AccountingOptions.Tabs.Add(Me.TabItemAccountingOptions_MediaTab)
            Me.TabControlAccountingOptions_AccountingOptions.Tabs.Add(Me.TabItemAccountingOptions_CurrencyTab)
            Me.TabControlAccountingOptions_AccountingOptions.Tabs.Add(Me.TabItemAccountingOptions_ImportTab)
            Me.TabControlAccountingOptions_AccountingOptions.Tabs.Add(Me.TabItemAccountingOptions_AvaTaxTab)
            Me.TabControlAccountingOptions_AccountingOptions.Text = "TabControl1"
            '
            'TabControlPanelAccountsPayableTab_AccountsPayable
            '
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.Controls.Add(Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert)
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.Controls.Add(Me.GroupBoxAccountingOptions_AccountsPayableHeader)
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.Controls.Add(Me.GroupBoxAccountingOptions_AccountsPayableDisbursement)
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.Name = "TabControlPanelAccountsPayableTab_AccountsPayable"
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.Size = New System.Drawing.Size(941, 575)
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.Style.GradientAngle = 90
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.TabIndex = 1
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.TabItem = Me.TabItemAccountingOptions_AccountsPayableTab
            '
            'GroupBoxAccountingOptions_AccountsPayableApprovalAlert
            '
            Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert.Controls.Add(Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup)
            Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert.Controls.Add(Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup)
            Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert.Controls.Add(Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState)
            Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert.Controls.Add(Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState)
            Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert.Controls.Add(Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate)
            Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert.Controls.Add(Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate)
            Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert.Location = New System.Drawing.Point(4, 438)
            Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert.Name = "GroupBoxAccountingOptions_AccountsPayableApprovalAlert"
            Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert.Size = New System.Drawing.Size(933, 108)
            Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert.TabIndex = 2
            Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert.Text = "Accounts Payable Approval Alert"
            '
            'LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup
            '
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.Location = New System.Drawing.Point(5, 77)
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.Name = "LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup"
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.Size = New System.Drawing.Size(247, 20)
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.TabIndex = 7
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.Text = "Default AP Approval Alert Group:"
            '
            'SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup
            '
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.ActiveFilterString = ""
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.AutoFillMode = False
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.BookmarkingEnabled = False
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.AlertGroup
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.DataSource = Nothing
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.DisableMouseWheel = False
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.DisplayName = ""
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.EnterMoveNextControl = True
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.Location = New System.Drawing.Point(258, 77)
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.Name = "SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup"
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.Properties.NullText = "Select Alert Group"
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.Properties.PopupView = Me.GridView13
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.Properties.ValueMember = "Code"
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.SecurityEnabled = True
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.SelectedValue = Nothing
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.Size = New System.Drawing.Size(279, 20)
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.TabIndex = 6
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
            'SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState
            '
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.ActiveFilterString = ""
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.AutoFillMode = False
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.BookmarkingEnabled = False
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.AlertAssignmentState
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.DataSource = Nothing
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.DisableMouseWheel = False
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.DisplayName = ""
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.EnterMoveNextControl = True
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.Location = New System.Drawing.Point(258, 51)
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.Name = "SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState"
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.Properties.NullText = "Select Alert Assignment State"
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.Properties.PopupView = Me.GridView12
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.Properties.ValueMember = "ID"
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.SecurityEnabled = True
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.SelectedValue = Nothing
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.Size = New System.Drawing.Size(279, 20)
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.TabIndex = 5
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
            'LabelAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState
            '
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.Location = New System.Drawing.Point(5, 51)
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.Name = "LabelAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState"
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.Size = New System.Drawing.Size(247, 20)
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.TabIndex = 4
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.Text = "Default AP Approval Alert Assignment State:"
            '
            'SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate
            '
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.ActiveFilterString = ""
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.AutoFillMode = False
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.BookmarkingEnabled = False
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.AlertAssignmentTemplate
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.DataSource = Nothing
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.DisableMouseWheel = False
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.DisplayName = ""
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.EnterMoveNextControl = True
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.Location = New System.Drawing.Point(258, 25)
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.Name = "SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTe" &
    "mplate"
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.Properties.NullText = "Select Alert Assignment Template"
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.Properties.PopupView = Me.GridView11
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.Properties.ValueMember = "ID"
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.SecurityEnabled = True
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.SelectedValue = Nothing
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.Size = New System.Drawing.Size(279, 20)
            Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.TabIndex = 3
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
            'LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate
            '
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.Location = New System.Drawing.Point(5, 25)
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.Name = "LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate"
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.Size = New System.Drawing.Size(247, 20)
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.TabIndex = 2
            Me.LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.Text = "Default AP Approval Alert Assignment Template:"
            '
            'GroupBoxAccountingOptions_AccountsPayableHeader
            '
            Me.GroupBoxAccountingOptions_AccountsPayableHeader.Controls.Add(Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription)
            Me.GroupBoxAccountingOptions_AccountsPayableHeader.Controls.Add(Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled)
            Me.GroupBoxAccountingOptions_AccountsPayableHeader.Controls.Add(Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP)
            Me.GroupBoxAccountingOptions_AccountsPayableHeader.Controls.Add(Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation)
            Me.GroupBoxAccountingOptions_AccountsPayableHeader.Controls.Add(Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099)
            Me.GroupBoxAccountingOptions_AccountsPayableHeader.Controls.Add(Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified)
            Me.GroupBoxAccountingOptions_AccountsPayableHeader.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxAccountingOptions_AccountsPayableHeader.Name = "GroupBoxAccountingOptions_AccountsPayableHeader"
            Me.GroupBoxAccountingOptions_AccountsPayableHeader.Size = New System.Drawing.Size(933, 186)
            Me.GroupBoxAccountingOptions_AccountsPayableHeader.TabIndex = 0
            Me.GroupBoxAccountingOptions_AccountsPayableHeader.Text = "Accounts Payable Header"
            '
            'CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription
            '
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.CheckValue = CType(0, Short)
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.ChildControls = CType(resources.GetObject("CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.ChildCont" &
        "rols"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.Location = New System.Drawing.Point(6, 157)
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.Name = "CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription"
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.OldestSibling = Nothing
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.SecurityEnabled = True
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.SiblingControls = CType(resources.GetObject("CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.SiblingCo" &
        "ntrols"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.Size = New System.Drawing.Size(922, 20)
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.TabIndex = 5
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.TabOnEnter = True
            Me.CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription.Text = "Default Vendor Account Number in AP Description"
            '
            'CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled
            '
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.CheckValue = CType(0, Short)
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.ChildControls = CType(resources.GetObject("CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.Location = New System.Drawing.Point(6, 130)
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.Name = "CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled"
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.OldestSibling = Nothing
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.SecurityEnabled = True
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.SiblingControls = CType(resources.GetObject("CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.Size = New System.Drawing.Size(922, 20)
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.TabIndex = 4
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.TabOnEnter = True
            Me.CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled.Text = "Vendor Service Tax Enabled"
            '
            'CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP
            '
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.CheckValue = CType(0, Short)
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.ChildControls = CType(resources.GetObject("CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.Location = New System.Drawing.Point(6, 25)
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.Name = "CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP"
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.OldestSibling = Nothing
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.SecurityEnabled = True
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.SiblingControls = CType(resources.GetObject("CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.Size = New System.Drawing.Size(922, 20)
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.TabIndex = 0
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.TabOnEnter = True
            Me.CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP.Text = "View deleted invoices in A/P"
            '
            'CheckBoxAccountsPayableHeader_DisplayPayToInformation
            '
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.CheckValue = CType(0, Short)
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.ChildControls = CType(resources.GetObject("CheckBoxAccountsPayableHeader_DisplayPayToInformation.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.Location = New System.Drawing.Point(6, 51)
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.Name = "CheckBoxAccountsPayableHeader_DisplayPayToInformation"
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.OldestSibling = Nothing
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.SecurityEnabled = True
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.SiblingControls = CType(resources.GetObject("CheckBoxAccountsPayableHeader_DisplayPayToInformation.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.Size = New System.Drawing.Size(922, 20)
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.TabIndex = 1
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.TabOnEnter = True
            Me.CheckBoxAccountsPayableHeader_DisplayPayToInformation.Text = "Display ""Pay To"" information in A/P and PO rather than vendor address"
            '
            'CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099
            '
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.CheckValue = CType(0, Short)
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.ChildControls = CType(resources.GetObject("CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.Location = New System.Drawing.Point(6, 77)
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.Name = "CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099"
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.OldestSibling = Nothing
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.SecurityEnabled = True
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.SiblingControls = CType(resources.GetObject("CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.Size = New System.Drawing.Size(922, 20)
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.TabIndex = 2
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.TabOnEnter = True
            Me.CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099.Text = "Flag individual vendor A/P invoices as 1099"
            '
            'CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified
            '
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.CheckValue = CType(0, Short)
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.ChildControls = CType(resources.GetObject("CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.Location = New System.Drawing.Point(6, 103)
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.Name = "CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified"
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.OldestSibling = Nothing
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.SecurityEnabled = True
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.SiblingControls = CType(resources.GetObject("CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.SiblingControls" &
        ""), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.Size = New System.Drawing.Size(922, 20)
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.TabIndex = 3
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.TabOnEnter = True
            Me.CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified.Text = "Do not allow default A/P GL account code to be modified"
            '
            'GroupBoxAccountingOptions_AccountsPayableDisbursement
            '
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement.Controls.Add(Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor)
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement.Controls.Add(Me.TextBoxAccountsPayableDisbursement_RejectAPEntry)
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement.Controls.Add(Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales)
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement.Controls.Add(Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry)
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement.Controls.Add(Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions)
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement.Controls.Add(Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP)
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement.Controls.Add(Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode)
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement.Controls.Add(Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP)
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement.Location = New System.Drawing.Point(4, 196)
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement.Name = "GroupBoxAccountingOptions_AccountsPayableDisbursement"
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement.Size = New System.Drawing.Size(933, 236)
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement.TabIndex = 1
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement.Text = "Accounts Payable Disbursement"
            '
            'CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor
            '
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.CheckValue = CType(0, Short)
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.ChildControls = CType(resources.GetObject("CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.Location = New System.Drawing.Point(6, 207)
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.Name = "CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor"
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.OldestSibling = Nothing
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.SecurityEnabled = True
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.SiblingControls = CType(resources.GetObject("CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.Size = New System.Drawing.Size(922, 20)
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.TabIndex = 9
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.TabOnEnter = True
            Me.CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor.Text = "Allow order not matching vendor"
            '
            'TextBoxAccountsPayableDisbursement_RejectAPEntry
            '
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.Border.Class = "TextBoxBorder"
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.CheckSpellingOnValidate = False
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.FocusHighlightEnabled = True
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.ForeColor = System.Drawing.Color.Black
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.Location = New System.Drawing.Point(24, 181)
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.MaxFileSize = CType(0, Long)
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.Name = "TextBoxAccountsPayableDisbursement_RejectAPEntry"
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.SecurityEnabled = True
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.Size = New System.Drawing.Size(903, 21)
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.StartingFolderName = Nothing
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.TabIndex = 8
            Me.TextBoxAccountsPayableDisbursement_RejectAPEntry.TabOnEnter = True
            '
            'CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales
            '
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.CheckValue = CType(0, Short)
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.ChildControls = CType(resources.GetObject("CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.Location = New System.Drawing.Point(6, 77)
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.Name = "CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales"
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.OldestSibling = Nothing
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.SecurityEnabled = True
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.SiblingControls = CType(resources.GetObject("CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.Size = New System.Drawing.Size(922, 20)
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.TabIndex = 3
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.TabOnEnter = True
            Me.CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales.Text = "Allow entry to Sales/Cost of Sales"
            '
            'CheckBoxAccountsPayableDisbursement_RejectAPEntry
            '
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.CheckValue = CType(0, Short)
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.ChildControls = CType(resources.GetObject("CheckBoxAccountsPayableDisbursement_RejectAPEntry.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.Location = New System.Drawing.Point(6, 155)
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.Name = "CheckBoxAccountsPayableDisbursement_RejectAPEntry"
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.OldestSibling = Nothing
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.SecurityEnabled = True
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.SiblingControls = CType(resources.GetObject("CheckBoxAccountsPayableDisbursement_RejectAPEntry.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.Size = New System.Drawing.Size(922, 20)
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.TabIndex = 7
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.TabOnEnter = True
            Me.CheckBoxAccountsPayableDisbursement_RejectAPEntry.Text = "Reject A/P entry if amount entered is greater than P.O. amount"
            '
            'CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions
            '
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.CheckValue = CType(0, Short)
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.ChildControls = CType(resources.GetObject("CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.Location = New System.Drawing.Point(6, 25)
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.Name = "CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions"
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.OldestSibling = Nothing
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.SecurityEnabled = True
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.SiblingControls = CType(resources.GetObject("CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.SiblingControl" &
        "s"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.Size = New System.Drawing.Size(922, 20)
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.TabIndex = 0
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.TabOnEnter = True
            Me.CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions.Text = "Create inter-company transactions"
            '
            'TextBoxAccountsPayableDisbursement_PopupMessageInAP
            '
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.Border.Class = "TextBoxBorder"
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.CheckSpellingOnValidate = False
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.FocusHighlightEnabled = True
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.ForeColor = System.Drawing.Color.Black
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.Location = New System.Drawing.Point(24, 129)
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.MaxFileSize = CType(0, Long)
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.Name = "TextBoxAccountsPayableDisbursement_PopupMessageInAP"
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.SecurityEnabled = True
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.Size = New System.Drawing.Size(903, 21)
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.StartingFolderName = Nothing
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.TabIndex = 6
            Me.TextBoxAccountsPayableDisbursement_PopupMessageInAP.TabOnEnter = True
            '
            'CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode
            '
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.CheckValue = CType(0, Short)
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.ChildControls = CType(resources.GetObject("CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.ChildControls" &
        ""), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.Location = New System.Drawing.Point(6, 51)
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.Name = "CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode"
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.OldestSibling = Nothing
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.SecurityEnabled = True
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.SiblingControls = CType(resources.GetObject("CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.SiblingContro" &
        "ls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.Size = New System.Drawing.Size(922, 20)
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.TabIndex = 1
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.TabOnEnter = True
            Me.CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode.Text = "Limit A/P transactions by office code"
            '
            'CheckBoxAccountsPayableDisbursement_PopupMessageInAP
            '
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.CheckValue = CType(0, Short)
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.ChildControls = CType(resources.GetObject("CheckBoxAccountsPayableDisbursement_PopupMessageInAP.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.Location = New System.Drawing.Point(6, 103)
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.Name = "CheckBoxAccountsPayableDisbursement_PopupMessageInAP"
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.OldestSibling = Nothing
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.SecurityEnabled = True
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.SiblingControls = CType(resources.GetObject("CheckBoxAccountsPayableDisbursement_PopupMessageInAP.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.Size = New System.Drawing.Size(922, 20)
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.TabIndex = 5
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.TabOnEnter = True
            Me.CheckBoxAccountsPayableDisbursement_PopupMessageInAP.Text = "Popup message in A/P if amount entered is greater than P.O. amount"
            '
            'TabItemAccountingOptions_AccountsPayableTab
            '
            Me.TabItemAccountingOptions_AccountsPayableTab.AttachedControl = Me.TabControlPanelAccountsPayableTab_AccountsPayable
            Me.TabItemAccountingOptions_AccountsPayableTab.Name = "TabItemAccountingOptions_AccountsPayableTab"
            Me.TabItemAccountingOptions_AccountsPayableTab.Text = "Accounts Payable"
            '
            'TabControlPanel1
            '
            Me.TabControlPanel1.Controls.Add(Me.GroupBoxAvatax_AddressOptions)
            Me.TabControlPanel1.Controls.Add(Me.CheckBoxAvaTax_UseJobSalesClass)
            Me.TabControlPanel1.Controls.Add(Me.GroupBoxAvaTax_OfficeCompanyCode)
            Me.TabControlPanel1.Controls.Add(Me.CheckBoxAvaTax_EnableAvaTaxCalculation)
            Me.TabControlPanel1.Controls.Add(Me.ButtonAvaTax_TestConnection)
            Me.TabControlPanel1.Controls.Add(Me.TextBoxAvaTax_URL)
            Me.TabControlPanel1.Controls.Add(Me.LabelAvaTax_URL)
            Me.TabControlPanel1.Controls.Add(Me.LabelAvaTax_AccountNumber)
            Me.TabControlPanel1.Controls.Add(Me.TextBoxAvaTax_AccountNumber)
            Me.TabControlPanel1.Controls.Add(Me.TextBoxAvaTax_LicenseKey)
            Me.TabControlPanel1.Controls.Add(Me.LabelAvaTax_LicenseKey)
            Me.TabControlPanel1.Controls.Add(Me.GroupBoxAvaTax_AddressValidation)
            Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel1.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel1.Name = "TabControlPanel1"
            Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel1.Size = New System.Drawing.Size(941, 575)
            Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel1.Style.GradientAngle = 90
            Me.TabControlPanel1.TabIndex = 8
            Me.TabControlPanel1.TabItem = Me.TabItemAccountingOptions_AvaTaxTab
            '
            'GroupBoxAvatax_AddressOptions
            '
            Me.GroupBoxAvatax_AddressOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxAvatax_AddressOptions.Controls.Add(Me.RadioButtonAddressOption_JobContactAddress)
            Me.GroupBoxAvatax_AddressOptions.Controls.Add(Me.RadioButtonAddressOption_ClientAddress)
            Me.GroupBoxAvatax_AddressOptions.Location = New System.Drawing.Point(468, 4)
            Me.GroupBoxAvatax_AddressOptions.Name = "GroupBoxAvatax_AddressOptions"
            Me.GroupBoxAvatax_AddressOptions.Size = New System.Drawing.Size(469, 85)
            Me.GroupBoxAvatax_AddressOptions.TabIndex = 44
            Me.GroupBoxAvatax_AddressOptions.Text = "Address Options"
            '
            'RadioButtonAddressOption_JobContactAddress
            '
            Me.RadioButtonAddressOption_JobContactAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonAddressOption_JobContactAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAddressOption_JobContactAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAddressOption_JobContactAddress.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAddressOption_JobContactAddress.Location = New System.Drawing.Point(5, 51)
            Me.RadioButtonAddressOption_JobContactAddress.Name = "RadioButtonAddressOption_JobContactAddress"
            Me.RadioButtonAddressOption_JobContactAddress.SecurityEnabled = True
            Me.RadioButtonAddressOption_JobContactAddress.Size = New System.Drawing.Size(460, 20)
            Me.RadioButtonAddressOption_JobContactAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAddressOption_JobContactAddress.TabIndex = 21
            Me.RadioButtonAddressOption_JobContactAddress.TabOnEnter = True
            Me.RadioButtonAddressOption_JobContactAddress.TabStop = False
            Me.RadioButtonAddressOption_JobContactAddress.Text = "Always use Job contact address for sales tax purposes"
            '
            'RadioButtonAddressOption_ClientAddress
            '
            Me.RadioButtonAddressOption_ClientAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonAddressOption_ClientAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAddressOption_ClientAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAddressOption_ClientAddress.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAddressOption_ClientAddress.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonAddressOption_ClientAddress.Name = "RadioButtonAddressOption_ClientAddress"
            Me.RadioButtonAddressOption_ClientAddress.SecurityEnabled = True
            Me.RadioButtonAddressOption_ClientAddress.Size = New System.Drawing.Size(460, 20)
            Me.RadioButtonAddressOption_ClientAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAddressOption_ClientAddress.TabIndex = 20
            Me.RadioButtonAddressOption_ClientAddress.TabOnEnter = True
            Me.RadioButtonAddressOption_ClientAddress.TabStop = False
            Me.RadioButtonAddressOption_ClientAddress.Text = "Always use Client Street address for sales tax purposes"
            '
            'CheckBoxAvaTax_UseJobSalesClass
            '
            Me.CheckBoxAvaTax_UseJobSalesClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxAvaTax_UseJobSalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxAvaTax_UseJobSalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAvaTax_UseJobSalesClass.CheckValue = CType(0, Short)
            Me.CheckBoxAvaTax_UseJobSalesClass.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAvaTax_UseJobSalesClass.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAvaTax_UseJobSalesClass.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAvaTax_UseJobSalesClass.ChildControls = CType(resources.GetObject("CheckBoxAvaTax_UseJobSalesClass.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAvaTax_UseJobSalesClass.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAvaTax_UseJobSalesClass.Location = New System.Drawing.Point(178, 5)
            Me.CheckBoxAvaTax_UseJobSalesClass.Name = "CheckBoxAvaTax_UseJobSalesClass"
            Me.CheckBoxAvaTax_UseJobSalesClass.OldestSibling = Nothing
            Me.CheckBoxAvaTax_UseJobSalesClass.SecurityEnabled = True
            Me.CheckBoxAvaTax_UseJobSalesClass.SiblingControls = CType(resources.GetObject("CheckBoxAvaTax_UseJobSalesClass.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAvaTax_UseJobSalesClass.Size = New System.Drawing.Size(168, 20)
            Me.CheckBoxAvaTax_UseJobSalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAvaTax_UseJobSalesClass.TabIndex = 43
            Me.CheckBoxAvaTax_UseJobSalesClass.TabOnEnter = True
            Me.CheckBoxAvaTax_UseJobSalesClass.Text = "Use Job Sales Class"
            '
            'GroupBoxAvaTax_OfficeCompanyCode
            '
            Me.GroupBoxAvaTax_OfficeCompanyCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxAvaTax_OfficeCompanyCode.Controls.Add(Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings)
            Me.GroupBoxAvaTax_OfficeCompanyCode.Location = New System.Drawing.Point(3, 279)
            Me.GroupBoxAvaTax_OfficeCompanyCode.Name = "GroupBoxAvaTax_OfficeCompanyCode"
            Me.GroupBoxAvaTax_OfficeCompanyCode.Size = New System.Drawing.Size(933, 141)
            Me.GroupBoxAvaTax_OfficeCompanyCode.TabIndex = 41
            Me.GroupBoxAvaTax_OfficeCompanyCode.Text = "Office Company Code Mapping"
            '
            'DataGridViewAvaTaxOfficeCompanyCode_Mappings
            '
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.AllowDragAndDrop = False
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.AllowSelectGroupHeaderRow = True
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.AutoFilterLookupColumns = False
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.AutoloadRepositoryDatasource = True
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.AutoUpdateViewCaption = True
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.DataSource = Nothing
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.ItemDescription = "Office Company Code Mapping(s)"
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.Location = New System.Drawing.Point(4, 23)
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.MultiSelect = True
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.Name = "DataGridViewAvaTaxOfficeCompanyCode_Mappings"
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.RunStandardValidation = True
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.ShowColumnMenuOnRightClick = False
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.ShowSelectDeselectAllButtons = False
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.Size = New System.Drawing.Size(925, 113)
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.TabIndex = 26
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.UseEmbeddedNavigator = False
            Me.DataGridViewAvaTaxOfficeCompanyCode_Mappings.ViewCaptionHeight = -1
            '
            'CheckBoxAvaTax_EnableAvaTaxCalculation
            '
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.CheckValue = CType(0, Short)
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.ChildControls = CType(resources.GetObject("CheckBoxAvaTax_EnableAvaTaxCalculation.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.Location = New System.Drawing.Point(4, 4)
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.Name = "CheckBoxAvaTax_EnableAvaTaxCalculation"
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.OldestSibling = Nothing
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.SecurityEnabled = True
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.SiblingControls = CType(resources.GetObject("CheckBoxAvaTax_EnableAvaTaxCalculation.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.Size = New System.Drawing.Size(168, 20)
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.TabIndex = 40
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.TabOnEnter = True
            Me.CheckBoxAvaTax_EnableAvaTaxCalculation.Text = "Enable AvaTax Calculation"
            '
            'ButtonAvaTax_TestConnection
            '
            Me.ButtonAvaTax_TestConnection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonAvaTax_TestConnection.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonAvaTax_TestConnection.Location = New System.Drawing.Point(102, 108)
            Me.ButtonAvaTax_TestConnection.Name = "ButtonAvaTax_TestConnection"
            Me.ButtonAvaTax_TestConnection.SecurityEnabled = True
            Me.ButtonAvaTax_TestConnection.Size = New System.Drawing.Size(107, 20)
            Me.ButtonAvaTax_TestConnection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonAvaTax_TestConnection.TabIndex = 39
            Me.ButtonAvaTax_TestConnection.Text = "Test Connection"
            '
            'TextBoxAvaTax_URL
            '
            Me.TextBoxAvaTax_URL.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxAvaTax_URL.Border.Class = "TextBoxBorder"
            Me.TextBoxAvaTax_URL.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAvaTax_URL.CheckSpellingOnValidate = False
            Me.TextBoxAvaTax_URL.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAvaTax_URL.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxAvaTax_URL.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAvaTax_URL.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAvaTax_URL.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAvaTax_URL.FocusHighlightEnabled = True
            Me.TextBoxAvaTax_URL.ForeColor = System.Drawing.Color.Black
            Me.TextBoxAvaTax_URL.Location = New System.Drawing.Point(102, 82)
            Me.TextBoxAvaTax_URL.MaxFileSize = CType(0, Long)
            Me.TextBoxAvaTax_URL.Name = "TextBoxAvaTax_URL"
            Me.TextBoxAvaTax_URL.SecurityEnabled = True
            Me.TextBoxAvaTax_URL.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAvaTax_URL.Size = New System.Drawing.Size(360, 20)
            Me.TextBoxAvaTax_URL.StartingFolderName = Nothing
            Me.TextBoxAvaTax_URL.TabIndex = 38
            Me.TextBoxAvaTax_URL.TabOnEnter = True
            '
            'LabelAvaTax_URL
            '
            Me.LabelAvaTax_URL.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAvaTax_URL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAvaTax_URL.Location = New System.Drawing.Point(4, 82)
            Me.LabelAvaTax_URL.Name = "LabelAvaTax_URL"
            Me.LabelAvaTax_URL.Size = New System.Drawing.Size(93, 20)
            Me.LabelAvaTax_URL.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAvaTax_URL.TabIndex = 37
            Me.LabelAvaTax_URL.Text = "URL:"
            '
            'LabelAvaTax_AccountNumber
            '
            Me.LabelAvaTax_AccountNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAvaTax_AccountNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAvaTax_AccountNumber.Location = New System.Drawing.Point(4, 30)
            Me.LabelAvaTax_AccountNumber.Name = "LabelAvaTax_AccountNumber"
            Me.LabelAvaTax_AccountNumber.Size = New System.Drawing.Size(92, 20)
            Me.LabelAvaTax_AccountNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAvaTax_AccountNumber.TabIndex = 33
            Me.LabelAvaTax_AccountNumber.Text = "Account Number:"
            '
            'TextBoxAvaTax_AccountNumber
            '
            Me.TextBoxAvaTax_AccountNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxAvaTax_AccountNumber.Border.Class = "TextBoxBorder"
            Me.TextBoxAvaTax_AccountNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAvaTax_AccountNumber.CheckSpellingOnValidate = False
            Me.TextBoxAvaTax_AccountNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAvaTax_AccountNumber.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxAvaTax_AccountNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAvaTax_AccountNumber.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAvaTax_AccountNumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAvaTax_AccountNumber.FocusHighlightEnabled = True
            Me.TextBoxAvaTax_AccountNumber.ForeColor = System.Drawing.Color.Black
            Me.TextBoxAvaTax_AccountNumber.Location = New System.Drawing.Point(102, 30)
            Me.TextBoxAvaTax_AccountNumber.MaxFileSize = CType(0, Long)
            Me.TextBoxAvaTax_AccountNumber.Name = "TextBoxAvaTax_AccountNumber"
            Me.TextBoxAvaTax_AccountNumber.SecurityEnabled = True
            Me.TextBoxAvaTax_AccountNumber.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAvaTax_AccountNumber.Size = New System.Drawing.Size(360, 20)
            Me.TextBoxAvaTax_AccountNumber.StartingFolderName = Nothing
            Me.TextBoxAvaTax_AccountNumber.TabIndex = 34
            Me.TextBoxAvaTax_AccountNumber.TabOnEnter = True
            '
            'TextBoxAvaTax_LicenseKey
            '
            Me.TextBoxAvaTax_LicenseKey.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxAvaTax_LicenseKey.Border.Class = "TextBoxBorder"
            Me.TextBoxAvaTax_LicenseKey.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAvaTax_LicenseKey.CheckSpellingOnValidate = False
            Me.TextBoxAvaTax_LicenseKey.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAvaTax_LicenseKey.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxAvaTax_LicenseKey.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAvaTax_LicenseKey.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAvaTax_LicenseKey.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAvaTax_LicenseKey.FocusHighlightEnabled = True
            Me.TextBoxAvaTax_LicenseKey.ForeColor = System.Drawing.Color.Black
            Me.TextBoxAvaTax_LicenseKey.Location = New System.Drawing.Point(102, 56)
            Me.TextBoxAvaTax_LicenseKey.MaxFileSize = CType(0, Long)
            Me.TextBoxAvaTax_LicenseKey.Name = "TextBoxAvaTax_LicenseKey"
            Me.TextBoxAvaTax_LicenseKey.SecurityEnabled = True
            Me.TextBoxAvaTax_LicenseKey.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAvaTax_LicenseKey.Size = New System.Drawing.Size(360, 20)
            Me.TextBoxAvaTax_LicenseKey.StartingFolderName = Nothing
            Me.TextBoxAvaTax_LicenseKey.TabIndex = 36
            Me.TextBoxAvaTax_LicenseKey.TabOnEnter = True
            '
            'LabelAvaTax_LicenseKey
            '
            Me.LabelAvaTax_LicenseKey.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAvaTax_LicenseKey.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAvaTax_LicenseKey.Location = New System.Drawing.Point(3, 56)
            Me.LabelAvaTax_LicenseKey.Name = "LabelAvaTax_LicenseKey"
            Me.LabelAvaTax_LicenseKey.Size = New System.Drawing.Size(93, 20)
            Me.LabelAvaTax_LicenseKey.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAvaTax_LicenseKey.TabIndex = 35
            Me.LabelAvaTax_LicenseKey.Text = "License Key:"
            '
            'GroupBoxAvaTax_AddressValidation
            '
            Me.GroupBoxAvaTax_AddressValidation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxAvaTax_AddressValidation.Controls.Add(Me.DataGridViewAvaTaxAddressValidation_Countries)
            Me.GroupBoxAvaTax_AddressValidation.Controls.Add(Me.CheckBoxAvaTaxAddressValidation_Enabled)
            Me.GroupBoxAvaTax_AddressValidation.Location = New System.Drawing.Point(4, 134)
            Me.GroupBoxAvaTax_AddressValidation.Name = "GroupBoxAvaTax_AddressValidation"
            Me.GroupBoxAvaTax_AddressValidation.Size = New System.Drawing.Size(933, 141)
            Me.GroupBoxAvaTax_AddressValidation.TabIndex = 25
            Me.GroupBoxAvaTax_AddressValidation.Text = "AvaTax Address Validation"
            '
            'DataGridViewAvaTaxAddressValidation_Countries
            '
            Me.DataGridViewAvaTaxAddressValidation_Countries.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewAvaTaxAddressValidation_Countries.AllowDragAndDrop = False
            Me.DataGridViewAvaTaxAddressValidation_Countries.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewAvaTaxAddressValidation_Countries.AllowSelectGroupHeaderRow = True
            Me.DataGridViewAvaTaxAddressValidation_Countries.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewAvaTaxAddressValidation_Countries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewAvaTaxAddressValidation_Countries.AutoFilterLookupColumns = False
            Me.DataGridViewAvaTaxAddressValidation_Countries.AutoloadRepositoryDatasource = True
            Me.DataGridViewAvaTaxAddressValidation_Countries.AutoUpdateViewCaption = True
            Me.DataGridViewAvaTaxAddressValidation_Countries.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewAvaTaxAddressValidation_Countries.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewAvaTaxAddressValidation_Countries.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewAvaTaxAddressValidation_Countries.ItemDescription = "Available Country(ies)"
            Me.DataGridViewAvaTaxAddressValidation_Countries.Location = New System.Drawing.Point(4, 49)
            Me.DataGridViewAvaTaxAddressValidation_Countries.MultiSelect = True
            Me.DataGridViewAvaTaxAddressValidation_Countries.Name = "DataGridViewAvaTaxAddressValidation_Countries"
            Me.DataGridViewAvaTaxAddressValidation_Countries.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewAvaTaxAddressValidation_Countries.RunStandardValidation = True
            Me.DataGridViewAvaTaxAddressValidation_Countries.ShowColumnMenuOnRightClick = False
            Me.DataGridViewAvaTaxAddressValidation_Countries.ShowSelectDeselectAllButtons = False
            Me.DataGridViewAvaTaxAddressValidation_Countries.Size = New System.Drawing.Size(925, 87)
            Me.DataGridViewAvaTaxAddressValidation_Countries.TabIndex = 26
            Me.DataGridViewAvaTaxAddressValidation_Countries.UseEmbeddedNavigator = False
            Me.DataGridViewAvaTaxAddressValidation_Countries.ViewCaptionHeight = -1
            '
            'CheckBoxAvaTaxAddressValidation_Enabled
            '
            Me.CheckBoxAvaTaxAddressValidation_Enabled.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxAvaTaxAddressValidation_Enabled.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxAvaTaxAddressValidation_Enabled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAvaTaxAddressValidation_Enabled.CheckValue = CType(0, Short)
            Me.CheckBoxAvaTaxAddressValidation_Enabled.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAvaTaxAddressValidation_Enabled.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAvaTaxAddressValidation_Enabled.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAvaTaxAddressValidation_Enabled.ChildControls = CType(resources.GetObject("CheckBoxAvaTaxAddressValidation_Enabled.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAvaTaxAddressValidation_Enabled.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAvaTaxAddressValidation_Enabled.Location = New System.Drawing.Point(4, 24)
            Me.CheckBoxAvaTaxAddressValidation_Enabled.Name = "CheckBoxAvaTaxAddressValidation_Enabled"
            Me.CheckBoxAvaTaxAddressValidation_Enabled.OldestSibling = Nothing
            Me.CheckBoxAvaTaxAddressValidation_Enabled.SecurityEnabled = True
            Me.CheckBoxAvaTaxAddressValidation_Enabled.SiblingControls = CType(resources.GetObject("CheckBoxAvaTaxAddressValidation_Enabled.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAvaTaxAddressValidation_Enabled.Size = New System.Drawing.Size(922, 20)
            Me.CheckBoxAvaTaxAddressValidation_Enabled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAvaTaxAddressValidation_Enabled.TabIndex = 25
            Me.CheckBoxAvaTaxAddressValidation_Enabled.TabOnEnter = True
            Me.CheckBoxAvaTaxAddressValidation_Enabled.Text = "Enabled"
            '
            'TabItemAccountingOptions_AvaTaxTab
            '
            Me.TabItemAccountingOptions_AvaTaxTab.AttachedControl = Me.TabControlPanel1
            Me.TabItemAccountingOptions_AvaTaxTab.Name = "TabItemAccountingOptions_AvaTaxTab"
            Me.TabItemAccountingOptions_AvaTaxTab.Text = "AvaTax"
            '
            'TabControlPanelMediaTab_Media
            '
            Me.TabControlPanelMediaTab_Media.Controls.Add(Me.GroupBoxMediaAndProduction_Media)
            Me.TabControlPanelMediaTab_Media.Controls.Add(Me.GroupBoxMediaAndProduction_Production)
            Me.TabControlPanelMediaTab_Media.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMediaTab_Media.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaTab_Media.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaTab_Media.Name = "TabControlPanelMediaTab_Media"
            Me.TabControlPanelMediaTab_Media.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaTab_Media.Size = New System.Drawing.Size(941, 575)
            Me.TabControlPanelMediaTab_Media.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMediaTab_Media.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaTab_Media.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaTab_Media.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaTab_Media.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaTab_Media.Style.GradientAngle = 90
            Me.TabControlPanelMediaTab_Media.TabIndex = 4
            Me.TabControlPanelMediaTab_Media.TabItem = Me.TabItemAccountingOptions_MediaTab
            '
            'GroupBoxMediaAndProduction_Media
            '
            Me.GroupBoxMediaAndProduction_Media.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMediaAndProduction_Media.Controls.Add(Me.CheckBoxMedia_AutomaticallyRemovePaymentHold)
            Me.GroupBoxMediaAndProduction_Media.Controls.Add(Me.GroupBoxMediaAndProduction_MediaApprovalAlert)
            Me.GroupBoxMediaAndProduction_Media.Controls.Add(Me.GroupBoxMediaAndProduction_APMediaImportOptions)
            Me.GroupBoxMediaAndProduction_Media.Controls.Add(Me.GroupBoxMedia_APPromptsOptions)
            Me.GroupBoxMediaAndProduction_Media.Controls.Add(Me.CheckBoxMedia_ActivateApprovals)
            Me.GroupBoxMediaAndProduction_Media.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxMediaAndProduction_Media.Name = "GroupBoxMediaAndProduction_Media"
            Me.GroupBoxMediaAndProduction_Media.Size = New System.Drawing.Size(933, 465)
            Me.GroupBoxMediaAndProduction_Media.TabIndex = 0
            Me.GroupBoxMediaAndProduction_Media.Text = "Media"
            '
            'CheckBoxMedia_AutomaticallyRemovePaymentHold
            '
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.CheckValue = CType(0, Short)
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.ChildControls = CType(resources.GetObject("CheckBoxMedia_AutomaticallyRemovePaymentHold.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.Name = "CheckBoxMedia_AutomaticallyRemovePaymentHold"
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.OldestSibling = Nothing
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.SecurityEnabled = True
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.SiblingControls = CType(resources.GetObject("CheckBoxMedia_AutomaticallyRemovePaymentHold.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.Size = New System.Drawing.Size(923, 20)
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.TabIndex = 1
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.TabOnEnter = True
            Me.CheckBoxMedia_AutomaticallyRemovePaymentHold.Text = "Automatically remove A/P Hold Flag when all order/lines are approved"
            '
            'GroupBoxMediaAndProduction_MediaApprovalAlert
            '
            Me.GroupBoxMediaAndProduction_MediaApprovalAlert.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMediaAndProduction_MediaApprovalAlert.Controls.Add(Me.RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup)
            Me.GroupBoxMediaAndProduction_MediaApprovalAlert.Controls.Add(Me.RadioButtonControlMediaApprovalAlert_AlertAPUser)
            Me.GroupBoxMediaAndProduction_MediaApprovalAlert.Controls.Add(Me.CheckBoxMediaApprovalAlert_AlertAP)
            Me.GroupBoxMediaAndProduction_MediaApprovalAlert.Controls.Add(Me.CheckBoxMediaApprovalAlert_AlertBuyer)
            Me.GroupBoxMediaAndProduction_MediaApprovalAlert.Location = New System.Drawing.Point(5, 356)
            Me.GroupBoxMediaAndProduction_MediaApprovalAlert.Name = "GroupBoxMediaAndProduction_MediaApprovalAlert"
            Me.GroupBoxMediaAndProduction_MediaApprovalAlert.Size = New System.Drawing.Size(923, 104)
            Me.GroupBoxMediaAndProduction_MediaApprovalAlert.TabIndex = 14
            Me.GroupBoxMediaAndProduction_MediaApprovalAlert.Text = "A/P Media Approval Alert"
            '
            'RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup
            '
            Me.RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup.Location = New System.Drawing.Point(119, 77)
            Me.RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup.Name = "RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup"
            Me.RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup.SecurityEnabled = True
            Me.RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup.Size = New System.Drawing.Size(163, 20)
            Me.RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup.TabIndex = 20
            Me.RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup.TabOnEnter = True
            Me.RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup.TabStop = False
            Me.RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup.Text = "Alert Default AP Alert Group"
            '
            'RadioButtonControlMediaApprovalAlert_AlertAPUser
            '
            Me.RadioButtonControlMediaApprovalAlert_AlertAPUser.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlMediaApprovalAlert_AlertAPUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlMediaApprovalAlert_AlertAPUser.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlMediaApprovalAlert_AlertAPUser.Location = New System.Drawing.Point(19, 77)
            Me.RadioButtonControlMediaApprovalAlert_AlertAPUser.Name = "RadioButtonControlMediaApprovalAlert_AlertAPUser"
            Me.RadioButtonControlMediaApprovalAlert_AlertAPUser.SecurityEnabled = True
            Me.RadioButtonControlMediaApprovalAlert_AlertAPUser.Size = New System.Drawing.Size(94, 20)
            Me.RadioButtonControlMediaApprovalAlert_AlertAPUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlMediaApprovalAlert_AlertAPUser.TabIndex = 19
            Me.RadioButtonControlMediaApprovalAlert_AlertAPUser.TabOnEnter = True
            Me.RadioButtonControlMediaApprovalAlert_AlertAPUser.TabStop = False
            Me.RadioButtonControlMediaApprovalAlert_AlertAPUser.Text = "Alert AP User"
            '
            'CheckBoxMediaApprovalAlert_AlertAP
            '
            Me.CheckBoxMediaApprovalAlert_AlertAP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMediaApprovalAlert_AlertAP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaApprovalAlert_AlertAP.CheckValue = CType(0, Short)
            Me.CheckBoxMediaApprovalAlert_AlertAP.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMediaApprovalAlert_AlertAP.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMediaApprovalAlert_AlertAP.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMediaApprovalAlert_AlertAP.ChildControls = CType(resources.GetObject("CheckBoxMediaApprovalAlert_AlertAP.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaApprovalAlert_AlertAP.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaApprovalAlert_AlertAP.Location = New System.Drawing.Point(5, 51)
            Me.CheckBoxMediaApprovalAlert_AlertAP.Name = "CheckBoxMediaApprovalAlert_AlertAP"
            Me.CheckBoxMediaApprovalAlert_AlertAP.OldestSibling = Nothing
            Me.CheckBoxMediaApprovalAlert_AlertAP.SecurityEnabled = True
            Me.CheckBoxMediaApprovalAlert_AlertAP.SiblingControls = CType(resources.GetObject("CheckBoxMediaApprovalAlert_AlertAP.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaApprovalAlert_AlertAP.Size = New System.Drawing.Size(913, 20)
            Me.CheckBoxMediaApprovalAlert_AlertAP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaApprovalAlert_AlertAP.TabIndex = 10
            Me.CheckBoxMediaApprovalAlert_AlertAP.TabOnEnter = True
            Me.CheckBoxMediaApprovalAlert_AlertAP.Text = "Alert AP on Approval of Media Invoices"
            '
            'CheckBoxMediaApprovalAlert_AlertBuyer
            '
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.CheckValue = CType(0, Short)
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.ChildControls = CType(resources.GetObject("CheckBoxMediaApprovalAlert_AlertBuyer.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.Name = "CheckBoxMediaApprovalAlert_AlertBuyer"
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.OldestSibling = Nothing
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.SecurityEnabled = True
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.SiblingControls = CType(resources.GetObject("CheckBoxMediaApprovalAlert_AlertBuyer.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.Size = New System.Drawing.Size(913, 20)
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.TabIndex = 0
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.TabOnEnter = True
            Me.CheckBoxMediaApprovalAlert_AlertBuyer.Text = "Alert Buyer on Import of Media Invoices (Imported Batches Only)"
            '
            'GroupBoxMediaAndProduction_APMediaImportOptions
            '
            Me.GroupBoxMediaAndProduction_APMediaImportOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMediaAndProduction_APMediaImportOptions.Controls.Add(Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval)
            Me.GroupBoxMediaAndProduction_APMediaImportOptions.Controls.Add(Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet)
            Me.GroupBoxMediaAndProduction_APMediaImportOptions.Controls.Add(Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome)
            Me.GroupBoxMediaAndProduction_APMediaImportOptions.Controls.Add(Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia)
            Me.GroupBoxMediaAndProduction_APMediaImportOptions.Controls.Add(Me.LabelAPMediaImportOptions_AlwaysSetToPendingApproval)
            Me.GroupBoxMediaAndProduction_APMediaImportOptions.Controls.Add(Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio)
            Me.GroupBoxMediaAndProduction_APMediaImportOptions.Controls.Add(Me.CheckBoxAPMediaImportOptions_PendingApprovalTV)
            Me.GroupBoxMediaAndProduction_APMediaImportOptions.Location = New System.Drawing.Point(5, 276)
            Me.GroupBoxMediaAndProduction_APMediaImportOptions.Name = "GroupBoxMediaAndProduction_APMediaImportOptions"
            Me.GroupBoxMediaAndProduction_APMediaImportOptions.Size = New System.Drawing.Size(923, 75)
            Me.GroupBoxMediaAndProduction_APMediaImportOptions.TabIndex = 2
            Me.GroupBoxMediaAndProduction_APMediaImportOptions.Text = "A/P Media Import Options"
            '
            'CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval
            '
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.CheckValue = CType(0, Short)
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.ChildControls = CType(resources.GetObject("CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.Location = New System.Drawing.Point(5, 48)
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.Name = "CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval"
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.OldestSibling = Nothing
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.SecurityEnabled = True
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.SiblingControls = CType(resources.GetObject("CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.Size = New System.Drawing.Size(913, 20)
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.TabIndex = 13
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.TabOnEnter = True
            Me.CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval.Text = "Set Payment Hold if Pending Approval"
            '
            'CheckBoxAPMediaImportOptions_PendingApprovalInternet
            '
            '
            '
            '
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.CheckValue = CType(0, Short)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.ChildControls = CType(resources.GetObject("CheckBoxAPMediaImportOptions_PendingApprovalInternet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.Location = New System.Drawing.Point(540, 21)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.Name = "CheckBoxAPMediaImportOptions_PendingApprovalInternet"
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.OldestSibling = Nothing
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.SecurityEnabled = True
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.SiblingControls = CType(resources.GetObject("CheckBoxAPMediaImportOptions_PendingApprovalInternet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.Size = New System.Drawing.Size(82, 20)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.TabIndex = 12
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.TabOnEnter = True
            Me.CheckBoxAPMediaImportOptions_PendingApprovalInternet.Text = "A/P Internet"
            '
            'CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome
            '
            '
            '
            '
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.CheckValue = CType(0, Short)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.ChildControls = CType(resources.GetObject("CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.Location = New System.Drawing.Point(424, 21)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.Name = "CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome"
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.OldestSibling = Nothing
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.SecurityEnabled = True
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.SiblingControls = CType(resources.GetObject("CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.Size = New System.Drawing.Size(110, 20)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.TabIndex = 11
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.TabOnEnter = True
            Me.CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome.Text = "A/P Out of Home"
            '
            'CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia
            '
            '
            '
            '
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.CheckValue = CType(0, Short)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.ChildControls = CType(resources.GetObject("CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.Location = New System.Drawing.Point(320, 21)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.Name = "CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia"
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.OldestSibling = Nothing
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.SecurityEnabled = True
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.SiblingControls = CType(resources.GetObject("CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.Size = New System.Drawing.Size(98, 20)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.TabIndex = 10
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.TabOnEnter = True
            Me.CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia.Text = "A/P Print Media"
            '
            'LabelAPMediaImportOptions_AlwaysSetToPendingApproval
            '
            Me.LabelAPMediaImportOptions_AlwaysSetToPendingApproval.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAPMediaImportOptions_AlwaysSetToPendingApproval.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAPMediaImportOptions_AlwaysSetToPendingApproval.Location = New System.Drawing.Point(5, 21)
            Me.LabelAPMediaImportOptions_AlwaysSetToPendingApproval.Name = "LabelAPMediaImportOptions_AlwaysSetToPendingApproval"
            Me.LabelAPMediaImportOptions_AlwaysSetToPendingApproval.Size = New System.Drawing.Size(168, 20)
            Me.LabelAPMediaImportOptions_AlwaysSetToPendingApproval.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAPMediaImportOptions_AlwaysSetToPendingApproval.TabIndex = 9
            Me.LabelAPMediaImportOptions_AlwaysSetToPendingApproval.Text = "Always set to Pending Approval:"
            '
            'CheckBoxAPMediaImportOptions_PendingApprovalRadio
            '
            '
            '
            '
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.CheckValue = CType(0, Short)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.ChildControls = CType(resources.GetObject("CheckBoxAPMediaImportOptions_PendingApprovalRadio.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.Location = New System.Drawing.Point(242, 21)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.Name = "CheckBoxAPMediaImportOptions_PendingApprovalRadio"
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.OldestSibling = Nothing
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.SecurityEnabled = True
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.SiblingControls = CType(resources.GetObject("CheckBoxAPMediaImportOptions_PendingApprovalRadio.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.Size = New System.Drawing.Size(72, 20)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.TabIndex = 1
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.TabOnEnter = True
            Me.CheckBoxAPMediaImportOptions_PendingApprovalRadio.Text = "A/P Radio"
            '
            'CheckBoxAPMediaImportOptions_PendingApprovalTV
            '
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.CheckValue = CType(0, Short)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.ChildControls = CType(resources.GetObject("CheckBoxAPMediaImportOptions_PendingApprovalTV.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.Location = New System.Drawing.Point(179, 21)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.Name = "CheckBoxAPMediaImportOptions_PendingApprovalTV"
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.OldestSibling = Nothing
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.SecurityEnabled = True
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.SiblingControls = CType(resources.GetObject("CheckBoxAPMediaImportOptions_PendingApprovalTV.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.Size = New System.Drawing.Size(57, 20)
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.TabIndex = 0
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.TabOnEnter = True
            Me.CheckBoxAPMediaImportOptions_PendingApprovalTV.Text = "A/P TV"
            '
            'GroupBoxMedia_APPromptsOptions
            '
            Me.GroupBoxMedia_APPromptsOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMedia_APPromptsOptions.Controls.Add(Me.NumericInputAPPromptsOptions_InternetMediaPercentOver)
            Me.GroupBoxMedia_APPromptsOptions.Controls.Add(Me.LabelAPPromptsOptions_Note)
            Me.GroupBoxMedia_APPromptsOptions.Controls.Add(Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver)
            Me.GroupBoxMedia_APPromptsOptions.Controls.Add(Me.NumericInputAPPromptsOptions_PrintMediaPercentOver)
            Me.GroupBoxMedia_APPromptsOptions.Controls.Add(Me.NumericInputAPPromptsOptions_RadioMediaPercentOver)
            Me.GroupBoxMedia_APPromptsOptions.Controls.Add(Me.LabelAPPromptsOptions_RadioMediaPercentOver)
            Me.GroupBoxMedia_APPromptsOptions.Controls.Add(Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver)
            Me.GroupBoxMedia_APPromptsOptions.Controls.Add(Me.LabelAPPromptsOptions_OutOfHomeMediaPercentOver)
            Me.GroupBoxMedia_APPromptsOptions.Controls.Add(Me.LabelAPPromptsOptions_InternetMediaPercentOver)
            Me.GroupBoxMedia_APPromptsOptions.Controls.Add(Me.LabelAPPromptsOptions_PrintMediaPercentOver)
            Me.GroupBoxMedia_APPromptsOptions.Controls.Add(Me.LabelAPPromptsOptions_TelevisionMediaPercentOver)
            Me.GroupBoxMedia_APPromptsOptions.Location = New System.Drawing.Point(5, 78)
            Me.GroupBoxMedia_APPromptsOptions.Name = "GroupBoxMedia_APPromptsOptions"
            Me.GroupBoxMedia_APPromptsOptions.Size = New System.Drawing.Size(923, 192)
            Me.GroupBoxMedia_APPromptsOptions.TabIndex = 1
            Me.GroupBoxMedia_APPromptsOptions.Text = "A/P Prompts Options"
            '
            'NumericInputAPPromptsOptions_InternetMediaPercentOver
            '
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.EnterMoveNextControl = True
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.Location = New System.Drawing.Point(174, 130)
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.Name = "NumericInputAPPromptsOptions_InternetMediaPercentOver"
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.Properties.EditFormat.FormatString = "f"
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.Properties.Mask.EditMask = "f"
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.SecurityEnabled = True
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.Size = New System.Drawing.Size(156, 20)
            Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.TabIndex = 9
            '
            'LabelAPPromptsOptions_Note
            '
            Me.LabelAPPromptsOptions_Note.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelAPPromptsOptions_Note.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAPPromptsOptions_Note.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAPPromptsOptions_Note.Location = New System.Drawing.Point(6, 156)
            Me.LabelAPPromptsOptions_Note.Name = "LabelAPPromptsOptions_Note"
            Me.LabelAPPromptsOptions_Note.Size = New System.Drawing.Size(912, 20)
            Me.LabelAPPromptsOptions_Note.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAPPromptsOptions_Note.TabIndex = 11
            Me.LabelAPPromptsOptions_Note.Text = "(Blank will deactivate the approval status update, 0.00 will activate the approva" &
    "l status update if the AP Net Invoice amount is over/under the Order Net Amount." &
    ")"
            '
            'NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver
            '
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.EnterMoveNextControl = True
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.Location = New System.Drawing.Point(174, 104)
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.Name = "NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver"
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.Properties.EditFormat.FormatString = "f"
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.Properties.Mask.EditMask = "f"
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.SecurityEnabled = True
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.Size = New System.Drawing.Size(156, 20)
            Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.TabIndex = 7
            '
            'NumericInputAPPromptsOptions_PrintMediaPercentOver
            '
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.EnterMoveNextControl = True
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.Location = New System.Drawing.Point(174, 78)
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.Name = "NumericInputAPPromptsOptions_PrintMediaPercentOver"
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.Properties.EditFormat.FormatString = "f"
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.Properties.Mask.EditMask = "f"
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.SecurityEnabled = True
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.Size = New System.Drawing.Size(156, 20)
            Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.TabIndex = 5
            '
            'NumericInputAPPromptsOptions_RadioMediaPercentOver
            '
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.EnterMoveNextControl = True
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.Location = New System.Drawing.Point(174, 52)
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.Name = "NumericInputAPPromptsOptions_RadioMediaPercentOver"
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.Properties.EditFormat.FormatString = "f"
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.Properties.Mask.EditMask = "f"
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.SecurityEnabled = True
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.Size = New System.Drawing.Size(156, 20)
            Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.TabIndex = 3
            '
            'LabelAPPromptsOptions_RadioMediaPercentOver
            '
            Me.LabelAPPromptsOptions_RadioMediaPercentOver.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAPPromptsOptions_RadioMediaPercentOver.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAPPromptsOptions_RadioMediaPercentOver.Location = New System.Drawing.Point(6, 52)
            Me.LabelAPPromptsOptions_RadioMediaPercentOver.Name = "LabelAPPromptsOptions_RadioMediaPercentOver"
            Me.LabelAPPromptsOptions_RadioMediaPercentOver.Size = New System.Drawing.Size(162, 20)
            Me.LabelAPPromptsOptions_RadioMediaPercentOver.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAPPromptsOptions_RadioMediaPercentOver.TabIndex = 2
            Me.LabelAPPromptsOptions_RadioMediaPercentOver.Text = "A/P Radio Percent Over:"
            '
            'NumericInputAPPromptsOptions_TelevisionMediaPercentOver
            '
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.EnterMoveNextControl = True
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.Location = New System.Drawing.Point(174, 26)
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.Name = "NumericInputAPPromptsOptions_TelevisionMediaPercentOver"
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.Properties.EditFormat.FormatString = "f"
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.Properties.Mask.EditMask = "f"
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.SecurityEnabled = True
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.Size = New System.Drawing.Size(156, 20)
            Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.TabIndex = 1
            '
            'LabelAPPromptsOptions_OutOfHomeMediaPercentOver
            '
            Me.LabelAPPromptsOptions_OutOfHomeMediaPercentOver.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAPPromptsOptions_OutOfHomeMediaPercentOver.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAPPromptsOptions_OutOfHomeMediaPercentOver.Location = New System.Drawing.Point(6, 104)
            Me.LabelAPPromptsOptions_OutOfHomeMediaPercentOver.Name = "LabelAPPromptsOptions_OutOfHomeMediaPercentOver"
            Me.LabelAPPromptsOptions_OutOfHomeMediaPercentOver.Size = New System.Drawing.Size(162, 20)
            Me.LabelAPPromptsOptions_OutOfHomeMediaPercentOver.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAPPromptsOptions_OutOfHomeMediaPercentOver.TabIndex = 6
            Me.LabelAPPromptsOptions_OutOfHomeMediaPercentOver.Text = "A/P Out of Home Percent Over:"
            '
            'LabelAPPromptsOptions_InternetMediaPercentOver
            '
            Me.LabelAPPromptsOptions_InternetMediaPercentOver.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAPPromptsOptions_InternetMediaPercentOver.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAPPromptsOptions_InternetMediaPercentOver.Location = New System.Drawing.Point(6, 130)
            Me.LabelAPPromptsOptions_InternetMediaPercentOver.Name = "LabelAPPromptsOptions_InternetMediaPercentOver"
            Me.LabelAPPromptsOptions_InternetMediaPercentOver.Size = New System.Drawing.Size(162, 20)
            Me.LabelAPPromptsOptions_InternetMediaPercentOver.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAPPromptsOptions_InternetMediaPercentOver.TabIndex = 8
            Me.LabelAPPromptsOptions_InternetMediaPercentOver.Text = "A/P Internet Percent Over:"
            '
            'LabelAPPromptsOptions_PrintMediaPercentOver
            '
            Me.LabelAPPromptsOptions_PrintMediaPercentOver.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAPPromptsOptions_PrintMediaPercentOver.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAPPromptsOptions_PrintMediaPercentOver.Location = New System.Drawing.Point(6, 78)
            Me.LabelAPPromptsOptions_PrintMediaPercentOver.Name = "LabelAPPromptsOptions_PrintMediaPercentOver"
            Me.LabelAPPromptsOptions_PrintMediaPercentOver.Size = New System.Drawing.Size(162, 20)
            Me.LabelAPPromptsOptions_PrintMediaPercentOver.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAPPromptsOptions_PrintMediaPercentOver.TabIndex = 4
            Me.LabelAPPromptsOptions_PrintMediaPercentOver.Text = "A/P Print Media Percent Over:"
            '
            'LabelAPPromptsOptions_TelevisionMediaPercentOver
            '
            Me.LabelAPPromptsOptions_TelevisionMediaPercentOver.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAPPromptsOptions_TelevisionMediaPercentOver.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAPPromptsOptions_TelevisionMediaPercentOver.Location = New System.Drawing.Point(6, 26)
            Me.LabelAPPromptsOptions_TelevisionMediaPercentOver.Name = "LabelAPPromptsOptions_TelevisionMediaPercentOver"
            Me.LabelAPPromptsOptions_TelevisionMediaPercentOver.Size = New System.Drawing.Size(162, 20)
            Me.LabelAPPromptsOptions_TelevisionMediaPercentOver.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAPPromptsOptions_TelevisionMediaPercentOver.TabIndex = 0
            Me.LabelAPPromptsOptions_TelevisionMediaPercentOver.Text = "A/P TV Percent Over:"
            '
            'CheckBoxMedia_ActivateApprovals
            '
            Me.CheckBoxMedia_ActivateApprovals.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxMedia_ActivateApprovals.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxMedia_ActivateApprovals.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMedia_ActivateApprovals.CheckValue = CType(0, Short)
            Me.CheckBoxMedia_ActivateApprovals.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMedia_ActivateApprovals.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMedia_ActivateApprovals.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMedia_ActivateApprovals.ChildControls = CType(resources.GetObject("CheckBoxMedia_ActivateApprovals.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMedia_ActivateApprovals.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMedia_ActivateApprovals.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxMedia_ActivateApprovals.Name = "CheckBoxMedia_ActivateApprovals"
            Me.CheckBoxMedia_ActivateApprovals.OldestSibling = Nothing
            Me.CheckBoxMedia_ActivateApprovals.SecurityEnabled = True
            Me.CheckBoxMedia_ActivateApprovals.SiblingControls = CType(resources.GetObject("CheckBoxMedia_ActivateApprovals.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMedia_ActivateApprovals.Size = New System.Drawing.Size(923, 20)
            Me.CheckBoxMedia_ActivateApprovals.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMedia_ActivateApprovals.TabIndex = 0
            Me.CheckBoxMedia_ActivateApprovals.TabOnEnter = True
            Me.CheckBoxMedia_ActivateApprovals.Text = "Activate Approvals"
            '
            'GroupBoxMediaAndProduction_Production
            '
            Me.GroupBoxMediaAndProduction_Production.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMediaAndProduction_Production.Controls.Add(Me.CheckBoxProduction_ValidateClosedArchivedJobs)
            Me.GroupBoxMediaAndProduction_Production.Location = New System.Drawing.Point(4, 475)
            Me.GroupBoxMediaAndProduction_Production.Name = "GroupBoxMediaAndProduction_Production"
            Me.GroupBoxMediaAndProduction_Production.Size = New System.Drawing.Size(933, 53)
            Me.GroupBoxMediaAndProduction_Production.TabIndex = 1
            Me.GroupBoxMediaAndProduction_Production.Text = "Production"
            '
            'CheckBoxProduction_ValidateClosedArchivedJobs
            '
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.CheckValue = CType(0, Short)
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.CheckValueChecked = CType(1, Short)
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.ChildControls = CType(resources.GetObject("CheckBoxProduction_ValidateClosedArchivedJobs.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.Name = "CheckBoxProduction_ValidateClosedArchivedJobs"
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.OldestSibling = Nothing
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.SecurityEnabled = True
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.SiblingControls = CType(resources.GetObject("CheckBoxProduction_ValidateClosedArchivedJobs.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.Size = New System.Drawing.Size(923, 20)
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.TabIndex = 0
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.TabOnEnter = True
            Me.CheckBoxProduction_ValidateClosedArchivedJobs.Text = "Validate Closed / Archived Jobs in Job Process Control"
            '
            'TabItemAccountingOptions_MediaTab
            '
            Me.TabItemAccountingOptions_MediaTab.AttachedControl = Me.TabControlPanelMediaTab_Media
            Me.TabItemAccountingOptions_MediaTab.Name = "TabItemAccountingOptions_MediaTab"
            Me.TabItemAccountingOptions_MediaTab.Text = "Media && Production"
            '
            'TabControlPanelImportTab_Import
            '
            Me.TabControlPanelImportTab_Import.Controls.Add(Me.TextBoxImportSettings_CSIClearedChecksImportPath)
            Me.TabControlPanelImportTab_Import.Controls.Add(Me.LabelImportSettings_CSIClearedChecksImportPath)
            Me.TabControlPanelImportTab_Import.Controls.Add(Me.LabelImportSettings_DefaultInvoiceDescription)
            Me.TabControlPanelImportTab_Import.Controls.Add(Me.ComboBoxImportSettings_DefaultInvoiceDescription)
            Me.TabControlPanelImportTab_Import.Controls.Add(Me.ComboBoxImportSettings_CurrencyRateImportFileType)
            Me.TabControlPanelImportTab_Import.Controls.Add(Me.ComboBoxImportSettings_IncomeOnlyImportFileType)
            Me.TabControlPanelImportTab_Import.Controls.Add(Me.LabelImportSettings_IncomeOnlyImportFileType)
            Me.TabControlPanelImportTab_Import.Controls.Add(Me.LabelImportSettings_CurrencyRateImportFileType)
            Me.TabControlPanelImportTab_Import.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelImportTab_Import.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelImportTab_Import.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelImportTab_Import.Name = "TabControlPanelImportTab_Import"
            Me.TabControlPanelImportTab_Import.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelImportTab_Import.Size = New System.Drawing.Size(941, 575)
            Me.TabControlPanelImportTab_Import.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelImportTab_Import.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelImportTab_Import.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelImportTab_Import.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelImportTab_Import.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelImportTab_Import.Style.GradientAngle = 90
            Me.TabControlPanelImportTab_Import.TabIndex = 6
            Me.TabControlPanelImportTab_Import.TabItem = Me.TabItemAccountingOptions_ImportTab
            '
            'TextBoxImportSettings_CSIClearedChecksImportPath
            '
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.Border.Class = "TextBoxBorder"
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.ButtonCustom.Visible = True
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.CheckSpellingOnValidate = False
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.FocusHighlightEnabled = True
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.ForeColor = System.Drawing.Color.Black
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.Location = New System.Drawing.Point(187, 82)
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.MaxFileSize = CType(0, Long)
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.Name = "TextBoxImportSettings_CSIClearedChecksImportPath"
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.SecurityEnabled = True
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.ShowSpellCheckCompleteMessage = True
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.Size = New System.Drawing.Size(751, 20)
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.StartingFolderName = Nothing
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.TabIndex = 7
            Me.TextBoxImportSettings_CSIClearedChecksImportPath.TabOnEnter = True
            '
            'LabelImportSettings_CSIClearedChecksImportPath
            '
            Me.LabelImportSettings_CSIClearedChecksImportPath.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelImportSettings_CSIClearedChecksImportPath.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelImportSettings_CSIClearedChecksImportPath.Location = New System.Drawing.Point(6, 82)
            Me.LabelImportSettings_CSIClearedChecksImportPath.Name = "LabelImportSettings_CSIClearedChecksImportPath"
            Me.LabelImportSettings_CSIClearedChecksImportPath.Size = New System.Drawing.Size(175, 20)
            Me.LabelImportSettings_CSIClearedChecksImportPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelImportSettings_CSIClearedChecksImportPath.TabIndex = 6
            Me.LabelImportSettings_CSIClearedChecksImportPath.Text = "CSI Cleared Checks Import Path:"
            '
            'LabelImportSettings_DefaultInvoiceDescription
            '
            Me.LabelImportSettings_DefaultInvoiceDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelImportSettings_DefaultInvoiceDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelImportSettings_DefaultInvoiceDescription.Location = New System.Drawing.Point(6, 56)
            Me.LabelImportSettings_DefaultInvoiceDescription.Name = "LabelImportSettings_DefaultInvoiceDescription"
            Me.LabelImportSettings_DefaultInvoiceDescription.Size = New System.Drawing.Size(175, 20)
            Me.LabelImportSettings_DefaultInvoiceDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelImportSettings_DefaultInvoiceDescription.TabIndex = 4
            Me.LabelImportSettings_DefaultInvoiceDescription.Text = "Default Invoice Description:"
            '
            'ComboBoxImportSettings_DefaultInvoiceDescription
            '
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.AutoFindItemInDataSource = False
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.AutoSelectSingleItemDatasource = False
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.BookmarkingEnabled = False
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.ClientCode = ""
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.DisableMouseWheel = False
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.DisplayMember = "Description"
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.DisplayName = ""
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.DivisionCode = ""
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.FocusHighlightEnabled = True
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.FormattingEnabled = True
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.ItemHeight = 14
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.Location = New System.Drawing.Point(187, 56)
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.Name = "ComboBoxImportSettings_DefaultInvoiceDescription"
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.ReadOnly = False
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.SecurityEnabled = True
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.Size = New System.Drawing.Size(751, 20)
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.TabIndex = 5
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.TabOnEnter = True
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.ValueMember = "Code"
            Me.ComboBoxImportSettings_DefaultInvoiceDescription.WatermarkText = "Select"
            '
            'ComboBoxImportSettings_CurrencyRateImportFileType
            '
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.AutoFindItemInDataSource = False
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.BookmarkingEnabled = False
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.ClientCode = ""
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.ImportFileType
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.DisableMouseWheel = False
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.DisplayMember = "Description"
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.DisplayName = ""
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.DivisionCode = ""
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.FocusHighlightEnabled = True
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.FormattingEnabled = True
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.ItemHeight = 14
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.Location = New System.Drawing.Point(187, 30)
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.Name = "ComboBoxImportSettings_CurrencyRateImportFileType"
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.ReadOnly = False
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.SecurityEnabled = True
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.Size = New System.Drawing.Size(751, 20)
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.TabIndex = 3
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.TabOnEnter = True
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.ValueMember = "Code"
            Me.ComboBoxImportSettings_CurrencyRateImportFileType.WatermarkText = "Selected Import File Type"
            '
            'ComboBoxImportSettings_IncomeOnlyImportFileType
            '
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.AutoFindItemInDataSource = False
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.BookmarkingEnabled = False
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.ClientCode = ""
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.ImportFileType
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.DisableMouseWheel = False
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.DisplayMember = "Description"
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.DisplayName = ""
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.DivisionCode = ""
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.FocusHighlightEnabled = True
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.FormattingEnabled = True
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.ItemHeight = 14
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.Location = New System.Drawing.Point(187, 4)
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.Name = "ComboBoxImportSettings_IncomeOnlyImportFileType"
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.ReadOnly = False
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.SecurityEnabled = True
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.Size = New System.Drawing.Size(751, 20)
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.TabIndex = 1
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.TabOnEnter = True
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.ValueMember = "Code"
            Me.ComboBoxImportSettings_IncomeOnlyImportFileType.WatermarkText = "Selected Import File Type"
            '
            'LabelImportSettings_IncomeOnlyImportFileType
            '
            Me.LabelImportSettings_IncomeOnlyImportFileType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelImportSettings_IncomeOnlyImportFileType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelImportSettings_IncomeOnlyImportFileType.Location = New System.Drawing.Point(6, 4)
            Me.LabelImportSettings_IncomeOnlyImportFileType.Name = "LabelImportSettings_IncomeOnlyImportFileType"
            Me.LabelImportSettings_IncomeOnlyImportFileType.Size = New System.Drawing.Size(175, 20)
            Me.LabelImportSettings_IncomeOnlyImportFileType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelImportSettings_IncomeOnlyImportFileType.TabIndex = 0
            Me.LabelImportSettings_IncomeOnlyImportFileType.Text = "Income Only Import File Type:"
            '
            'LabelImportSettings_CurrencyRateImportFileType
            '
            Me.LabelImportSettings_CurrencyRateImportFileType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelImportSettings_CurrencyRateImportFileType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelImportSettings_CurrencyRateImportFileType.Location = New System.Drawing.Point(6, 30)
            Me.LabelImportSettings_CurrencyRateImportFileType.Name = "LabelImportSettings_CurrencyRateImportFileType"
            Me.LabelImportSettings_CurrencyRateImportFileType.Size = New System.Drawing.Size(175, 20)
            Me.LabelImportSettings_CurrencyRateImportFileType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelImportSettings_CurrencyRateImportFileType.TabIndex = 2
            Me.LabelImportSettings_CurrencyRateImportFileType.Text = "Currency Rate Import File Type:"
            '
            'TabItemAccountingOptions_ImportTab
            '
            Me.TabItemAccountingOptions_ImportTab.AttachedControl = Me.TabControlPanelImportTab_Import
            Me.TabItemAccountingOptions_ImportTab.Name = "TabItemAccountingOptions_ImportTab"
            Me.TabItemAccountingOptions_ImportTab.Text = "Import"
            '
            'TabControlPanelCheckWritingTab_CheckWriting
            '
            Me.TabControlPanelCheckWritingTab_CheckWriting.Controls.Add(Me.GroupBoxCheckWriting_CheckFormatSettings)
            Me.TabControlPanelCheckWritingTab_CheckWriting.Controls.Add(Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks)
            Me.TabControlPanelCheckWritingTab_CheckWriting.Controls.Add(Me.LabelAccountingOptions_CheckWritingInProgress)
            Me.TabControlPanelCheckWritingTab_CheckWriting.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCheckWritingTab_CheckWriting.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCheckWritingTab_CheckWriting.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCheckWritingTab_CheckWriting.Name = "TabControlPanelCheckWritingTab_CheckWriting"
            Me.TabControlPanelCheckWritingTab_CheckWriting.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCheckWritingTab_CheckWriting.Size = New System.Drawing.Size(941, 575)
            Me.TabControlPanelCheckWritingTab_CheckWriting.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCheckWritingTab_CheckWriting.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCheckWritingTab_CheckWriting.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCheckWritingTab_CheckWriting.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCheckWritingTab_CheckWriting.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCheckWritingTab_CheckWriting.Style.GradientAngle = 90
            Me.TabControlPanelCheckWritingTab_CheckWriting.TabIndex = 3
            Me.TabControlPanelCheckWritingTab_CheckWriting.TabItem = Me.TabItemAccountingOptions_CheckWritingTab
            '
            'GroupBoxCheckWriting_CheckFormatSettings
            '
            Me.GroupBoxCheckWriting_CheckFormatSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxCheckWriting_CheckFormatSettings.Controls.Add(Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat)
            Me.GroupBoxCheckWriting_CheckFormatSettings.Controls.Add(Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown)
            Me.GroupBoxCheckWriting_CheckFormatSettings.Controls.Add(Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp)
            Me.GroupBoxCheckWriting_CheckFormatSettings.Controls.Add(Me.GroupBoxCheckFormatSettings_CheckCurrency)
            Me.GroupBoxCheckWriting_CheckFormatSettings.Controls.Add(Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown)
            Me.GroupBoxCheckWriting_CheckFormatSettings.Controls.Add(Me.CheckBoxCheckFormatSettings_CheckAmountInWords)
            Me.GroupBoxCheckWriting_CheckFormatSettings.Controls.Add(Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp)
            Me.GroupBoxCheckWriting_CheckFormatSettings.Controls.Add(Me.LabelCheckFormatSettings_APComputerCheckFormat)
            Me.GroupBoxCheckWriting_CheckFormatSettings.Location = New System.Drawing.Point(4, 30)
            Me.GroupBoxCheckWriting_CheckFormatSettings.Name = "GroupBoxCheckWriting_CheckFormatSettings"
            Me.GroupBoxCheckWriting_CheckFormatSettings.Size = New System.Drawing.Size(933, 254)
            Me.GroupBoxCheckWriting_CheckFormatSettings.TabIndex = 1
            Me.GroupBoxCheckWriting_CheckFormatSettings.Text = "Check Format Settings"
            '
            'SearchableComboBoxCheckFormatSettings_APComputerCheckFormat
            '
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.ActiveFilterString = ""
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.AutoFillMode = False
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.BookmarkingEnabled = False
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CheckFormat
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.DataSource = Nothing
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.DisableMouseWheel = False
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.DisplayName = ""
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.EnterMoveNextControl = True
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.Location = New System.Drawing.Point(174, 25)
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.Name = "SearchableComboBoxCheckFormatSettings_APComputerCheckFormat"
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.Properties.NullText = "Select Check Format"
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.Properties.PopupView = Me.GridView1
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.Properties.ValueMember = "Number"
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.SecurityEnabled = True
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.SelectedValue = Nothing
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.Size = New System.Drawing.Size(754, 20)
            Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.TabIndex = 1
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
            'ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown
            '
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.AutoFindItemInDataSource = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.AutoSelectSingleItemDatasource = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.BookmarkingEnabled = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.ClientCode = ""
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.ShortNumeric
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.DisableMouseWheel = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.DisplayMember = "Number"
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.DisplayName = ""
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.DivisionCode = ""
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.FocusHighlightEnabled = True
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.FormattingEnabled = True
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.ItemHeight = 16
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.Location = New System.Drawing.Point(174, 100)
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.Name = "ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown"
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.ReadOnly = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.SecurityEnabled = True
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.Size = New System.Drawing.Size(90, 22)
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.TabIndex = 6
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.TabOnEnter = True
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.ValueMember = "Number"
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.WatermarkText = "Select"
            '
            'ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp
            '
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.AutoFindItemInDataSource = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.AutoSelectSingleItemDatasource = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.BookmarkingEnabled = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.ClientCode = ""
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.ShortNumeric
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.DisableMouseWheel = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.DisplayMember = "Number"
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.DisplayName = ""
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.DivisionCode = ""
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.FocusHighlightEnabled = True
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.FormattingEnabled = True
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.ItemHeight = 16
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.Location = New System.Drawing.Point(174, 75)
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.Name = "ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp"
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.ReadOnly = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.SecurityEnabled = True
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.Size = New System.Drawing.Size(90, 22)
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.TabIndex = 4
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.TabOnEnter = True
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.ValueMember = "Number"
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.WatermarkText = "Select"
            '
            'GroupBoxCheckFormatSettings_CheckCurrency
            '
            Me.GroupBoxCheckFormatSettings_CheckCurrency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxCheckFormatSettings_CheckCurrency.Controls.Add(Me.ComboBoxCheckCurrecny_CurrencySymbols)
            Me.GroupBoxCheckFormatSettings_CheckCurrency.Controls.Add(Me.LabelCheckCurrency_Note)
            Me.GroupBoxCheckFormatSettings_CheckCurrency.Controls.Add(Me.TextBoxCheckCurrency_CoinText)
            Me.GroupBoxCheckFormatSettings_CheckCurrency.Controls.Add(Me.TextBoxCheckCurrency_CurrencyText)
            Me.GroupBoxCheckFormatSettings_CheckCurrency.Controls.Add(Me.LabelCheckCurrency_CoinText)
            Me.GroupBoxCheckFormatSettings_CheckCurrency.Controls.Add(Me.LabelCheckCurrency_CurrencyText)
            Me.GroupBoxCheckFormatSettings_CheckCurrency.Controls.Add(Me.LabelCheckCurrency_Symbol)
            Me.GroupBoxCheckFormatSettings_CheckCurrency.Location = New System.Drawing.Point(6, 127)
            Me.GroupBoxCheckFormatSettings_CheckCurrency.Name = "GroupBoxCheckFormatSettings_CheckCurrency"
            Me.GroupBoxCheckFormatSettings_CheckCurrency.Size = New System.Drawing.Size(922, 121)
            Me.GroupBoxCheckFormatSettings_CheckCurrency.TabIndex = 7
            Me.GroupBoxCheckFormatSettings_CheckCurrency.Text = "Check Currency "
            '
            'ComboBoxCheckCurrecny_CurrencySymbols
            '
            Me.ComboBoxCheckCurrecny_CurrencySymbols.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxCheckCurrecny_CurrencySymbols.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxCheckCurrecny_CurrencySymbols.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxCheckCurrecny_CurrencySymbols.AutoFindItemInDataSource = False
            Me.ComboBoxCheckCurrecny_CurrencySymbols.AutoSelectSingleItemDatasource = False
            Me.ComboBoxCheckCurrecny_CurrencySymbols.BookmarkingEnabled = False
            Me.ComboBoxCheckCurrecny_CurrencySymbols.ClientCode = ""
            Me.ComboBoxCheckCurrecny_CurrencySymbols.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxCheckCurrecny_CurrencySymbols.DisableMouseWheel = False
            Me.ComboBoxCheckCurrecny_CurrencySymbols.DisplayMember = "Text"
            Me.ComboBoxCheckCurrecny_CurrencySymbols.DisplayName = ""
            Me.ComboBoxCheckCurrecny_CurrencySymbols.DivisionCode = ""
            Me.ComboBoxCheckCurrecny_CurrencySymbols.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxCheckCurrecny_CurrencySymbols.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxCheckCurrecny_CurrencySymbols.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxCheckCurrecny_CurrencySymbols.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxCheckCurrecny_CurrencySymbols.FocusHighlightEnabled = True
            Me.ComboBoxCheckCurrecny_CurrencySymbols.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxCheckCurrecny_CurrencySymbols.FormattingEnabled = True
            Me.ComboBoxCheckCurrecny_CurrencySymbols.ItemHeight = 16
            Me.ComboBoxCheckCurrecny_CurrencySymbols.Location = New System.Drawing.Point(95, 26)
            Me.ComboBoxCheckCurrecny_CurrencySymbols.Name = "ComboBoxCheckCurrecny_CurrencySymbols"
            Me.ComboBoxCheckCurrecny_CurrencySymbols.ReadOnly = False
            Me.ComboBoxCheckCurrecny_CurrencySymbols.SecurityEnabled = True
            Me.ComboBoxCheckCurrecny_CurrencySymbols.Size = New System.Drawing.Size(67, 22)
            Me.ComboBoxCheckCurrecny_CurrencySymbols.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxCheckCurrecny_CurrencySymbols.TabIndex = 1
            Me.ComboBoxCheckCurrecny_CurrencySymbols.TabOnEnter = True
            '
            'LabelCheckCurrency_Note
            '
            Me.LabelCheckCurrency_Note.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheckCurrency_Note.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheckCurrency_Note.Location = New System.Drawing.Point(95, 98)
            Me.LabelCheckCurrency_Note.Name = "LabelCheckCurrency_Note"
            Me.LabelCheckCurrency_Note.Size = New System.Drawing.Size(198, 20)
            Me.LabelCheckCurrency_Note.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheckCurrency_Note.TabIndex = 6
            Me.LabelCheckCurrency_Note.Text = "(leave blank for $ / DOLLARS / CENTS)"
            '
            'TextBoxCheckCurrency_CoinText
            '
            Me.TextBoxCheckCurrency_CoinText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxCheckCurrency_CoinText.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxCheckCurrency_CoinText.Border.Class = "TextBoxBorder"
            Me.TextBoxCheckCurrency_CoinText.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCheckCurrency_CoinText.CheckSpellingOnValidate = False
            Me.TextBoxCheckCurrency_CoinText.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxCheckCurrency_CoinText.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxCheckCurrency_CoinText.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxCheckCurrency_CoinText.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCheckCurrency_CoinText.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCheckCurrency_CoinText.FocusHighlightEnabled = True
            Me.TextBoxCheckCurrency_CoinText.ForeColor = System.Drawing.Color.Black
            Me.TextBoxCheckCurrency_CoinText.Location = New System.Drawing.Point(95, 75)
            Me.TextBoxCheckCurrency_CoinText.MaxFileSize = CType(0, Long)
            Me.TextBoxCheckCurrency_CoinText.Name = "TextBoxCheckCurrency_CoinText"
            Me.TextBoxCheckCurrency_CoinText.SecurityEnabled = True
            Me.TextBoxCheckCurrency_CoinText.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCheckCurrency_CoinText.Size = New System.Drawing.Size(822, 21)
            Me.TextBoxCheckCurrency_CoinText.StartingFolderName = Nothing
            Me.TextBoxCheckCurrency_CoinText.TabIndex = 5
            Me.TextBoxCheckCurrency_CoinText.TabOnEnter = True
            '
            'TextBoxCheckCurrency_CurrencyText
            '
            Me.TextBoxCheckCurrency_CurrencyText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxCheckCurrency_CurrencyText.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxCheckCurrency_CurrencyText.Border.Class = "TextBoxBorder"
            Me.TextBoxCheckCurrency_CurrencyText.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCheckCurrency_CurrencyText.CheckSpellingOnValidate = False
            Me.TextBoxCheckCurrency_CurrencyText.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxCheckCurrency_CurrencyText.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxCheckCurrency_CurrencyText.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxCheckCurrency_CurrencyText.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCheckCurrency_CurrencyText.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCheckCurrency_CurrencyText.FocusHighlightEnabled = True
            Me.TextBoxCheckCurrency_CurrencyText.ForeColor = System.Drawing.Color.Black
            Me.TextBoxCheckCurrency_CurrencyText.Location = New System.Drawing.Point(95, 50)
            Me.TextBoxCheckCurrency_CurrencyText.MaxFileSize = CType(0, Long)
            Me.TextBoxCheckCurrency_CurrencyText.Name = "TextBoxCheckCurrency_CurrencyText"
            Me.TextBoxCheckCurrency_CurrencyText.SecurityEnabled = True
            Me.TextBoxCheckCurrency_CurrencyText.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCheckCurrency_CurrencyText.Size = New System.Drawing.Size(822, 21)
            Me.TextBoxCheckCurrency_CurrencyText.StartingFolderName = Nothing
            Me.TextBoxCheckCurrency_CurrencyText.TabIndex = 3
            Me.TextBoxCheckCurrency_CurrencyText.TabOnEnter = True
            '
            'LabelCheckCurrency_CoinText
            '
            Me.LabelCheckCurrency_CoinText.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheckCurrency_CoinText.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheckCurrency_CoinText.Location = New System.Drawing.Point(6, 75)
            Me.LabelCheckCurrency_CoinText.Name = "LabelCheckCurrency_CoinText"
            Me.LabelCheckCurrency_CoinText.Size = New System.Drawing.Size(83, 20)
            Me.LabelCheckCurrency_CoinText.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheckCurrency_CoinText.TabIndex = 4
            Me.LabelCheckCurrency_CoinText.Text = "Coin Text:"
            '
            'LabelCheckCurrency_CurrencyText
            '
            Me.LabelCheckCurrency_CurrencyText.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheckCurrency_CurrencyText.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheckCurrency_CurrencyText.Location = New System.Drawing.Point(6, 50)
            Me.LabelCheckCurrency_CurrencyText.Name = "LabelCheckCurrency_CurrencyText"
            Me.LabelCheckCurrency_CurrencyText.Size = New System.Drawing.Size(83, 20)
            Me.LabelCheckCurrency_CurrencyText.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheckCurrency_CurrencyText.TabIndex = 2
            Me.LabelCheckCurrency_CurrencyText.Text = "Currency Text:"
            '
            'LabelCheckCurrency_Symbol
            '
            Me.LabelCheckCurrency_Symbol.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheckCurrency_Symbol.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheckCurrency_Symbol.Location = New System.Drawing.Point(6, 25)
            Me.LabelCheckCurrency_Symbol.Name = "LabelCheckCurrency_Symbol"
            Me.LabelCheckCurrency_Symbol.Size = New System.Drawing.Size(83, 20)
            Me.LabelCheckCurrency_Symbol.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheckCurrency_Symbol.TabIndex = 0
            Me.LabelCheckCurrency_Symbol.Text = "Symbol:"
            '
            'LabelCheckFormatSettings_AdjustCheckBodyLinesDown
            '
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.Location = New System.Drawing.Point(6, 101)
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.Name = "LabelCheckFormatSettings_AdjustCheckBodyLinesDown"
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.Size = New System.Drawing.Size(162, 20)
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.TabIndex = 5
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.Text = "Adjust Check Body Lines Down:"
            '
            'CheckBoxCheckFormatSettings_CheckAmountInWords
            '
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.CheckValue = CType(0, Short)
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.CheckValueChecked = CType(1, Short)
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.ChildControls = CType(resources.GetObject("CheckBoxCheckFormatSettings_CheckAmountInWords.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.Location = New System.Drawing.Point(174, 50)
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.Name = "CheckBoxCheckFormatSettings_CheckAmountInWords"
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.OldestSibling = Nothing
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.SecurityEnabled = True
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.SiblingControls = CType(resources.GetObject("CheckBoxCheckFormatSettings_CheckAmountInWords.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.Size = New System.Drawing.Size(754, 20)
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.TabIndex = 2
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.TabOnEnter = True
            Me.CheckBoxCheckFormatSettings_CheckAmountInWords.Text = "Check Amount in Words"
            '
            'LabelCheckFormatSettings_AdjustCheckStubLinesUp
            '
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.Location = New System.Drawing.Point(6, 75)
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.Name = "LabelCheckFormatSettings_AdjustCheckStubLinesUp"
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.Size = New System.Drawing.Size(162, 20)
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.TabIndex = 3
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.Text = "Adjust Check Stub Lines Up:"
            '
            'LabelCheckFormatSettings_APComputerCheckFormat
            '
            Me.LabelCheckFormatSettings_APComputerCheckFormat.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheckFormatSettings_APComputerCheckFormat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheckFormatSettings_APComputerCheckFormat.Location = New System.Drawing.Point(6, 25)
            Me.LabelCheckFormatSettings_APComputerCheckFormat.Name = "LabelCheckFormatSettings_APComputerCheckFormat"
            Me.LabelCheckFormatSettings_APComputerCheckFormat.Size = New System.Drawing.Size(162, 20)
            Me.LabelCheckFormatSettings_APComputerCheckFormat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheckFormatSettings_APComputerCheckFormat.TabIndex = 0
            Me.LabelCheckFormatSettings_APComputerCheckFormat.Text = "A/P Computer Check Format:"
            '
            'CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks
            '
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.CheckValue = CType(0, Short)
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.CheckValueChecked = CType(1, Short)
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.ChildControls = CType(resources.GetObject("CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.Location = New System.Drawing.Point(4, 4)
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.Name = "CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks"
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.OldestSibling = Nothing
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.SecurityEnabled = True
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.SiblingControls = CType(resources.GetObject("CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.Size = New System.Drawing.Size(933, 20)
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.TabIndex = 0
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.TabOnEnter = True
            Me.CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks.Text = "Print Vendor Account Number on checks rather than invoice description"
            '
            'LabelAccountingOptions_CheckWritingInProgress
            '
            Me.LabelAccountingOptions_CheckWritingInProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelAccountingOptions_CheckWritingInProgress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAccountingOptions_CheckWritingInProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAccountingOptions_CheckWritingInProgress.ForeColor = System.Drawing.Color.Red
            Me.LabelAccountingOptions_CheckWritingInProgress.Location = New System.Drawing.Point(4, 291)
            Me.LabelAccountingOptions_CheckWritingInProgress.Name = "LabelAccountingOptions_CheckWritingInProgress"
            Me.LabelAccountingOptions_CheckWritingInProgress.Size = New System.Drawing.Size(933, 20)
            Me.LabelAccountingOptions_CheckWritingInProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAccountingOptions_CheckWritingInProgress.TabIndex = 2
            Me.LabelAccountingOptions_CheckWritingInProgress.Text = "* Note: Check related information is locked during an active Check Run."
            '
            'TabItemAccountingOptions_CheckWritingTab
            '
            Me.TabItemAccountingOptions_CheckWritingTab.AttachedControl = Me.TabControlPanelCheckWritingTab_CheckWriting
            Me.TabItemAccountingOptions_CheckWritingTab.Name = "TabItemAccountingOptions_CheckWritingTab"
            Me.TabItemAccountingOptions_CheckWritingTab.Text = "Check Writing"
            '
            'TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable
            '
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.Controls.Add(Me.GroupBoxBillingAndAccountsReceivable_InvoiceTaxing)
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.Controls.Add(Me.GroupBoxBillingAndAccountsReceivable_ClientCashReceipts)
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.Controls.Add(Me.GroupBoxBillingAndAccountsReceivable_Billing)
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.Name = "TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable"
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.Size = New System.Drawing.Size(941, 575)
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.Style.GradientAngle = 90
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.TabIndex = 2
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.TabItem = Me.TabItemAccountingOptions_BillingAndAccountsReceivableTab
            '
            'GroupBoxBillingAndAccountsReceivable_InvoiceTaxing
            '
            Me.GroupBoxBillingAndAccountsReceivable_InvoiceTaxing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxBillingAndAccountsReceivable_InvoiceTaxing.Controls.Add(Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling)
            Me.GroupBoxBillingAndAccountsReceivable_InvoiceTaxing.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxBillingAndAccountsReceivable_InvoiceTaxing.Name = "GroupBoxBillingAndAccountsReceivable_InvoiceTaxing"
            Me.GroupBoxBillingAndAccountsReceivable_InvoiceTaxing.Size = New System.Drawing.Size(933, 60)
            Me.GroupBoxBillingAndAccountsReceivable_InvoiceTaxing.TabIndex = 0
            Me.GroupBoxBillingAndAccountsReceivable_InvoiceTaxing.Text = "Invoice Taxing"
            '
            'CheckBoxInvoiceTaxing_ApplyTaxUponBilling
            '
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.CheckValue = CType(0, Short)
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.CheckValueChecked = CType(1, Short)
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.ChildControls = CType(resources.GetObject("CheckBoxInvoiceTaxing_ApplyTaxUponBilling.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Location = New System.Drawing.Point(6, 25)
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Name = "CheckBoxInvoiceTaxing_ApplyTaxUponBilling"
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.OldestSibling = Nothing
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.SecurityEnabled = True
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.SiblingControls = CType(resources.GetObject("CheckBoxInvoiceTaxing_ApplyTaxUponBilling.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Size = New System.Drawing.Size(922, 20)
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.TabIndex = 0
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.TabOnEnter = True
            Me.CheckBoxInvoiceTaxing_ApplyTaxUponBilling.Text = "Apply Tax Upon Billing"
            '
            'GroupBoxBillingAndAccountsReceivable_ClientCashReceipts
            '
            Me.GroupBoxBillingAndAccountsReceivable_ClientCashReceipts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxBillingAndAccountsReceivable_ClientCashReceipts.Controls.Add(Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount)
            Me.GroupBoxBillingAndAccountsReceivable_ClientCashReceipts.Controls.Add(Me.LabelClientCashReceipts_DefaultWriteoffAccount)
            Me.GroupBoxBillingAndAccountsReceivable_ClientCashReceipts.Controls.Add(Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired)
            Me.GroupBoxBillingAndAccountsReceivable_ClientCashReceipts.Controls.Add(Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution)
            Me.GroupBoxBillingAndAccountsReceivable_ClientCashReceipts.Location = New System.Drawing.Point(4, 338)
            Me.GroupBoxBillingAndAccountsReceivable_ClientCashReceipts.Name = "GroupBoxBillingAndAccountsReceivable_ClientCashReceipts"
            Me.GroupBoxBillingAndAccountsReceivable_ClientCashReceipts.Size = New System.Drawing.Size(933, 94)
            Me.GroupBoxBillingAndAccountsReceivable_ClientCashReceipts.TabIndex = 2
            Me.GroupBoxBillingAndAccountsReceivable_ClientCashReceipts.Text = "Client Cash Receipts"
            '
            'SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount
            '
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.ActiveFilterString = ""
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.AutoFillMode = False
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.BookmarkingEnabled = False
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.DataSource = Nothing
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.DisableMouseWheel = False
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.DisplayName = ""
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.EnterMoveNextControl = True
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.Location = New System.Drawing.Point(140, 51)
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.Name = "SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount"
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.Properties.NullText = "Select General Ledger Account"
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.Properties.PopupView = Me.GridView10
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.SecurityEnabled = True
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.SelectedValue = Nothing
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.Size = New System.Drawing.Size(787, 20)
            Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.TabIndex = 3
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
            'LabelClientCashReceipts_DefaultWriteoffAccount
            '
            Me.LabelClientCashReceipts_DefaultWriteoffAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelClientCashReceipts_DefaultWriteoffAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelClientCashReceipts_DefaultWriteoffAccount.Location = New System.Drawing.Point(5, 51)
            Me.LabelClientCashReceipts_DefaultWriteoffAccount.Name = "LabelClientCashReceipts_DefaultWriteoffAccount"
            Me.LabelClientCashReceipts_DefaultWriteoffAccount.Size = New System.Drawing.Size(129, 20)
            Me.LabelClientCashReceipts_DefaultWriteoffAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelClientCashReceipts_DefaultWriteoffAccount.TabIndex = 2
            Me.LabelClientCashReceipts_DefaultWriteoffAccount.Text = "Default Writeoff Account:"
            '
            'CheckBoxClientCashReceipts_PartialPaymentDistributionRequired
            '
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.CheckValue = CType(0, Short)
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.CheckValueChecked = CType(1, Short)
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.ChildControls = CType(resources.GetObject("CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.Location = New System.Drawing.Point(211, 25)
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.Name = "CheckBoxClientCashReceipts_PartialPaymentDistributionRequired"
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.OldestSibling = Nothing
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.SecurityEnabled = True
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.SiblingControls = CType(resources.GetObject("CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.Size = New System.Drawing.Size(712, 20)
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.TabIndex = 1
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.TabOnEnter = True
            Me.CheckBoxClientCashReceipts_PartialPaymentDistributionRequired.Text = "Partial Payment Distribution Required"
            '
            'CheckBoxClientCashReceipts_EnablePartialPaymentDistribution
            '
            '
            '
            '
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.CheckValue = CType(0, Short)
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.CheckValueChecked = CType(1, Short)
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.ChildControls = CType(resources.GetObject("CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.Location = New System.Drawing.Point(6, 25)
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.Name = "CheckBoxClientCashReceipts_EnablePartialPaymentDistribution"
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.OldestSibling = Nothing
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.SecurityEnabled = True
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.SiblingControls = CType(resources.GetObject("CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.Size = New System.Drawing.Size(199, 20)
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.TabIndex = 0
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.TabOnEnter = True
            Me.CheckBoxClientCashReceipts_EnablePartialPaymentDistribution.Text = "Enable Partial Payment Distribution"
            '
            'GroupBoxBillingAndAccountsReceivable_Billing
            '
            Me.GroupBoxBillingAndAccountsReceivable_Billing.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxBillingAndAccountsReceivable_Billing.Controls.Add(Me.CheckBoxBilling_RequireProductSetupComplete)
            Me.GroupBoxBillingAndAccountsReceivable_Billing.Controls.Add(Me.GroupBoxBilling_CustomInvoiceFormats)
            Me.GroupBoxBillingAndAccountsReceivable_Billing.Location = New System.Drawing.Point(4, 70)
            Me.GroupBoxBillingAndAccountsReceivable_Billing.Name = "GroupBoxBillingAndAccountsReceivable_Billing"
            Me.GroupBoxBillingAndAccountsReceivable_Billing.Size = New System.Drawing.Size(933, 262)
            Me.GroupBoxBillingAndAccountsReceivable_Billing.TabIndex = 1
            Me.GroupBoxBillingAndAccountsReceivable_Billing.Text = "Billing"
            '
            'CheckBoxBilling_RequireProductSetupComplete
            '
            Me.CheckBoxBilling_RequireProductSetupComplete.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxBilling_RequireProductSetupComplete.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxBilling_RequireProductSetupComplete.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxBilling_RequireProductSetupComplete.CheckValue = CType(0, Short)
            Me.CheckBoxBilling_RequireProductSetupComplete.CheckValueChecked = CType(1, Short)
            Me.CheckBoxBilling_RequireProductSetupComplete.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxBilling_RequireProductSetupComplete.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxBilling_RequireProductSetupComplete.ChildControls = CType(resources.GetObject("CheckBoxBilling_RequireProductSetupComplete.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBilling_RequireProductSetupComplete.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxBilling_RequireProductSetupComplete.Location = New System.Drawing.Point(6, 25)
            Me.CheckBoxBilling_RequireProductSetupComplete.Name = "CheckBoxBilling_RequireProductSetupComplete"
            Me.CheckBoxBilling_RequireProductSetupComplete.OldestSibling = Nothing
            Me.CheckBoxBilling_RequireProductSetupComplete.SecurityEnabled = True
            Me.CheckBoxBilling_RequireProductSetupComplete.SiblingControls = CType(resources.GetObject("CheckBoxBilling_RequireProductSetupComplete.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBilling_RequireProductSetupComplete.Size = New System.Drawing.Size(922, 20)
            Me.CheckBoxBilling_RequireProductSetupComplete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxBilling_RequireProductSetupComplete.TabIndex = 0
            Me.CheckBoxBilling_RequireProductSetupComplete.TabOnEnter = True
            Me.CheckBoxBilling_RequireProductSetupComplete.Text = "Require product setup to be complete before billing"
            '
            'GroupBoxBilling_CustomInvoiceFormats
            '
            Me.GroupBoxBilling_CustomInvoiceFormats.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxBilling_CustomInvoiceFormats.Controls.Add(Me.SearchableComboBoxCustomInvoiceFormats_Internet)
            Me.GroupBoxBilling_CustomInvoiceFormats.Controls.Add(Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome)
            Me.GroupBoxBilling_CustomInvoiceFormats.Controls.Add(Me.SearchableComboBoxCustomInvoiceFormats_Magazine)
            Me.GroupBoxBilling_CustomInvoiceFormats.Controls.Add(Me.SearchableComboBoxCustomInvoiceFormats_Newspaper)
            Me.GroupBoxBilling_CustomInvoiceFormats.Controls.Add(Me.SearchableComboBoxCustomInvoiceFormats_Radio)
            Me.GroupBoxBilling_CustomInvoiceFormats.Controls.Add(Me.SearchableComboBoxCustomInvoiceFormats_Television)
            Me.GroupBoxBilling_CustomInvoiceFormats.Controls.Add(Me.SearchableComboBoxCustomInvoiceFormats_Production)
            Me.GroupBoxBilling_CustomInvoiceFormats.Controls.Add(Me.LabelCustomInvoiceFormats_Internet)
            Me.GroupBoxBilling_CustomInvoiceFormats.Controls.Add(Me.LabelCustomInvoiceFormats_OutOfHome)
            Me.GroupBoxBilling_CustomInvoiceFormats.Controls.Add(Me.LabelCustomInvoiceFormats_Magazine)
            Me.GroupBoxBilling_CustomInvoiceFormats.Controls.Add(Me.LabelCustomInvoiceFormats_Newspaper)
            Me.GroupBoxBilling_CustomInvoiceFormats.Controls.Add(Me.LabelCustomInvoiceFormats_Radio)
            Me.GroupBoxBilling_CustomInvoiceFormats.Controls.Add(Me.LabelCustomInvoiceFormats_Television)
            Me.GroupBoxBilling_CustomInvoiceFormats.Controls.Add(Me.LabelCustomInvoiceFormats_Production)
            Me.GroupBoxBilling_CustomInvoiceFormats.Location = New System.Drawing.Point(6, 51)
            Me.GroupBoxBilling_CustomInvoiceFormats.Name = "GroupBoxBilling_CustomInvoiceFormats"
            Me.GroupBoxBilling_CustomInvoiceFormats.Size = New System.Drawing.Size(922, 204)
            Me.GroupBoxBilling_CustomInvoiceFormats.TabIndex = 1
            Me.GroupBoxBilling_CustomInvoiceFormats.Text = "Custom Invoice Formats"
            '
            'SearchableComboBoxCustomInvoiceFormats_Internet
            '
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.ActiveFilterString = ""
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.AutoFillMode = False
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.BookmarkingEnabled = False
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CustomReport
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.DataSource = Nothing
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.DisableMouseWheel = False
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.DisplayName = ""
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.EnterMoveNextControl = True
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.AgencyDefault
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.Location = New System.Drawing.Point(87, 175)
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.Name = "SearchableComboBoxCustomInvoiceFormats_Internet"
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.Properties.NullText = "Select Report"
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.Properties.PopupView = Me.GridView8
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.Properties.ShowClearButton = False
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.Properties.ValueMember = "Code"
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.SecurityEnabled = True
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.SelectedValue = Nothing
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.Size = New System.Drawing.Size(830, 20)
            Me.SearchableComboBoxCustomInvoiceFormats_Internet.TabIndex = 13
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
            'SearchableComboBoxCustomInvoiceFormats_OutOfHome
            '
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.ActiveFilterString = ""
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.AutoFillMode = False
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.BookmarkingEnabled = False
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CustomReport
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.DataSource = Nothing
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.DisableMouseWheel = False
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.DisplayName = ""
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.EnterMoveNextControl = True
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.AgencyDefault
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.Location = New System.Drawing.Point(87, 150)
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.Name = "SearchableComboBoxCustomInvoiceFormats_OutOfHome"
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.Properties.NullText = "Select Report"
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.Properties.PopupView = Me.GridView7
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.Properties.ShowClearButton = False
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.Properties.ValueMember = "Code"
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.SecurityEnabled = True
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.SelectedValue = Nothing
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.Size = New System.Drawing.Size(830, 20)
            Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.TabIndex = 11
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
            'SearchableComboBoxCustomInvoiceFormats_Magazine
            '
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.ActiveFilterString = ""
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.AutoFillMode = False
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.BookmarkingEnabled = False
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CustomReport
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.DataSource = Nothing
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.DisableMouseWheel = False
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.DisplayName = ""
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.EnterMoveNextControl = True
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.AgencyDefault
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.Location = New System.Drawing.Point(87, 125)
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.Name = "SearchableComboBoxCustomInvoiceFormats_Magazine"
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.Properties.NullText = "Select Report"
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.Properties.PopupView = Me.GridView6
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.Properties.ShowClearButton = False
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.Properties.ValueMember = "Code"
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.SecurityEnabled = True
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.SelectedValue = Nothing
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.Size = New System.Drawing.Size(830, 20)
            Me.SearchableComboBoxCustomInvoiceFormats_Magazine.TabIndex = 9
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
            'SearchableComboBoxCustomInvoiceFormats_Newspaper
            '
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.ActiveFilterString = ""
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.AutoFillMode = False
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.BookmarkingEnabled = False
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CustomReport
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.DataSource = Nothing
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.DisableMouseWheel = False
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.DisplayName = ""
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.EnterMoveNextControl = True
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.AgencyDefault
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.Location = New System.Drawing.Point(87, 100)
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.Name = "SearchableComboBoxCustomInvoiceFormats_Newspaper"
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.Properties.NullText = "Select Report"
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.Properties.PopupView = Me.GridView5
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.Properties.ShowClearButton = False
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.Properties.ValueMember = "Code"
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.SecurityEnabled = True
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.SelectedValue = Nothing
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.Size = New System.Drawing.Size(830, 20)
            Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.TabIndex = 7
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
            'SearchableComboBoxCustomInvoiceFormats_Radio
            '
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.ActiveFilterString = ""
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.AutoFillMode = False
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.BookmarkingEnabled = False
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CustomReport
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.DataSource = Nothing
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.DisableMouseWheel = False
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.DisplayName = ""
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.EnterMoveNextControl = True
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.AgencyDefault
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.Location = New System.Drawing.Point(87, 75)
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.Name = "SearchableComboBoxCustomInvoiceFormats_Radio"
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.Properties.NullText = "Select Report"
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.Properties.PopupView = Me.GridView4
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.Properties.ShowClearButton = False
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.Properties.ValueMember = "Code"
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.SecurityEnabled = True
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.SelectedValue = Nothing
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.Size = New System.Drawing.Size(830, 20)
            Me.SearchableComboBoxCustomInvoiceFormats_Radio.TabIndex = 5
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
            'SearchableComboBoxCustomInvoiceFormats_Television
            '
            Me.SearchableComboBoxCustomInvoiceFormats_Television.ActiveFilterString = ""
            Me.SearchableComboBoxCustomInvoiceFormats_Television.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxCustomInvoiceFormats_Television.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxCustomInvoiceFormats_Television.AutoFillMode = False
            Me.SearchableComboBoxCustomInvoiceFormats_Television.BookmarkingEnabled = False
            Me.SearchableComboBoxCustomInvoiceFormats_Television.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CustomReport
            Me.SearchableComboBoxCustomInvoiceFormats_Television.DataSource = Nothing
            Me.SearchableComboBoxCustomInvoiceFormats_Television.DisableMouseWheel = False
            Me.SearchableComboBoxCustomInvoiceFormats_Television.DisplayName = ""
            Me.SearchableComboBoxCustomInvoiceFormats_Television.EnterMoveNextControl = True
            Me.SearchableComboBoxCustomInvoiceFormats_Television.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.AgencyDefault
            Me.SearchableComboBoxCustomInvoiceFormats_Television.Location = New System.Drawing.Point(87, 50)
            Me.SearchableComboBoxCustomInvoiceFormats_Television.Name = "SearchableComboBoxCustomInvoiceFormats_Television"
            Me.SearchableComboBoxCustomInvoiceFormats_Television.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCustomInvoiceFormats_Television.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCustomInvoiceFormats_Television.Properties.NullText = "Select Report"
            Me.SearchableComboBoxCustomInvoiceFormats_Television.Properties.PopupView = Me.GridView3
            Me.SearchableComboBoxCustomInvoiceFormats_Television.Properties.ShowClearButton = False
            Me.SearchableComboBoxCustomInvoiceFormats_Television.Properties.ValueMember = "Code"
            Me.SearchableComboBoxCustomInvoiceFormats_Television.SecurityEnabled = True
            Me.SearchableComboBoxCustomInvoiceFormats_Television.SelectedValue = Nothing
            Me.SearchableComboBoxCustomInvoiceFormats_Television.Size = New System.Drawing.Size(830, 20)
            Me.SearchableComboBoxCustomInvoiceFormats_Television.TabIndex = 3
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
            'SearchableComboBoxCustomInvoiceFormats_Production
            '
            Me.SearchableComboBoxCustomInvoiceFormats_Production.ActiveFilterString = ""
            Me.SearchableComboBoxCustomInvoiceFormats_Production.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxCustomInvoiceFormats_Production.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxCustomInvoiceFormats_Production.AutoFillMode = False
            Me.SearchableComboBoxCustomInvoiceFormats_Production.BookmarkingEnabled = False
            Me.SearchableComboBoxCustomInvoiceFormats_Production.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CustomReport
            Me.SearchableComboBoxCustomInvoiceFormats_Production.DataSource = Nothing
            Me.SearchableComboBoxCustomInvoiceFormats_Production.DisableMouseWheel = False
            Me.SearchableComboBoxCustomInvoiceFormats_Production.DisplayName = ""
            Me.SearchableComboBoxCustomInvoiceFormats_Production.EnterMoveNextControl = True
            Me.SearchableComboBoxCustomInvoiceFormats_Production.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.AgencyDefault
            Me.SearchableComboBoxCustomInvoiceFormats_Production.Location = New System.Drawing.Point(87, 25)
            Me.SearchableComboBoxCustomInvoiceFormats_Production.Name = "SearchableComboBoxCustomInvoiceFormats_Production"
            Me.SearchableComboBoxCustomInvoiceFormats_Production.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCustomInvoiceFormats_Production.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCustomInvoiceFormats_Production.Properties.NullText = "Select Report"
            Me.SearchableComboBoxCustomInvoiceFormats_Production.Properties.PopupView = Me.GridView2
            Me.SearchableComboBoxCustomInvoiceFormats_Production.Properties.ShowClearButton = False
            Me.SearchableComboBoxCustomInvoiceFormats_Production.Properties.ValueMember = "Code"
            Me.SearchableComboBoxCustomInvoiceFormats_Production.SecurityEnabled = True
            Me.SearchableComboBoxCustomInvoiceFormats_Production.SelectedValue = Nothing
            Me.SearchableComboBoxCustomInvoiceFormats_Production.Size = New System.Drawing.Size(830, 20)
            Me.SearchableComboBoxCustomInvoiceFormats_Production.TabIndex = 1
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
            'LabelCustomInvoiceFormats_Internet
            '
            Me.LabelCustomInvoiceFormats_Internet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCustomInvoiceFormats_Internet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCustomInvoiceFormats_Internet.Location = New System.Drawing.Point(6, 175)
            Me.LabelCustomInvoiceFormats_Internet.Name = "LabelCustomInvoiceFormats_Internet"
            Me.LabelCustomInvoiceFormats_Internet.Size = New System.Drawing.Size(75, 20)
            Me.LabelCustomInvoiceFormats_Internet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCustomInvoiceFormats_Internet.TabIndex = 12
            Me.LabelCustomInvoiceFormats_Internet.Text = "Internet:"
            '
            'LabelCustomInvoiceFormats_OutOfHome
            '
            Me.LabelCustomInvoiceFormats_OutOfHome.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCustomInvoiceFormats_OutOfHome.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCustomInvoiceFormats_OutOfHome.Location = New System.Drawing.Point(6, 150)
            Me.LabelCustomInvoiceFormats_OutOfHome.Name = "LabelCustomInvoiceFormats_OutOfHome"
            Me.LabelCustomInvoiceFormats_OutOfHome.Size = New System.Drawing.Size(75, 20)
            Me.LabelCustomInvoiceFormats_OutOfHome.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCustomInvoiceFormats_OutOfHome.TabIndex = 10
            Me.LabelCustomInvoiceFormats_OutOfHome.Text = "Out of Home:"
            '
            'LabelCustomInvoiceFormats_Magazine
            '
            Me.LabelCustomInvoiceFormats_Magazine.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCustomInvoiceFormats_Magazine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCustomInvoiceFormats_Magazine.Location = New System.Drawing.Point(6, 125)
            Me.LabelCustomInvoiceFormats_Magazine.Name = "LabelCustomInvoiceFormats_Magazine"
            Me.LabelCustomInvoiceFormats_Magazine.Size = New System.Drawing.Size(75, 20)
            Me.LabelCustomInvoiceFormats_Magazine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCustomInvoiceFormats_Magazine.TabIndex = 8
            Me.LabelCustomInvoiceFormats_Magazine.Text = "Magazine:"
            '
            'LabelCustomInvoiceFormats_Newspaper
            '
            Me.LabelCustomInvoiceFormats_Newspaper.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCustomInvoiceFormats_Newspaper.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCustomInvoiceFormats_Newspaper.Location = New System.Drawing.Point(6, 100)
            Me.LabelCustomInvoiceFormats_Newspaper.Name = "LabelCustomInvoiceFormats_Newspaper"
            Me.LabelCustomInvoiceFormats_Newspaper.Size = New System.Drawing.Size(75, 20)
            Me.LabelCustomInvoiceFormats_Newspaper.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCustomInvoiceFormats_Newspaper.TabIndex = 6
            Me.LabelCustomInvoiceFormats_Newspaper.Text = "Newspaper:"
            '
            'LabelCustomInvoiceFormats_Radio
            '
            Me.LabelCustomInvoiceFormats_Radio.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCustomInvoiceFormats_Radio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCustomInvoiceFormats_Radio.Location = New System.Drawing.Point(6, 75)
            Me.LabelCustomInvoiceFormats_Radio.Name = "LabelCustomInvoiceFormats_Radio"
            Me.LabelCustomInvoiceFormats_Radio.Size = New System.Drawing.Size(75, 20)
            Me.LabelCustomInvoiceFormats_Radio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCustomInvoiceFormats_Radio.TabIndex = 4
            Me.LabelCustomInvoiceFormats_Radio.Text = "Radio:"
            '
            'LabelCustomInvoiceFormats_Television
            '
            Me.LabelCustomInvoiceFormats_Television.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCustomInvoiceFormats_Television.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCustomInvoiceFormats_Television.Location = New System.Drawing.Point(6, 50)
            Me.LabelCustomInvoiceFormats_Television.Name = "LabelCustomInvoiceFormats_Television"
            Me.LabelCustomInvoiceFormats_Television.Size = New System.Drawing.Size(75, 20)
            Me.LabelCustomInvoiceFormats_Television.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCustomInvoiceFormats_Television.TabIndex = 2
            Me.LabelCustomInvoiceFormats_Television.Text = "Television:"
            '
            'LabelCustomInvoiceFormats_Production
            '
            Me.LabelCustomInvoiceFormats_Production.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCustomInvoiceFormats_Production.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCustomInvoiceFormats_Production.Location = New System.Drawing.Point(6, 25)
            Me.LabelCustomInvoiceFormats_Production.Name = "LabelCustomInvoiceFormats_Production"
            Me.LabelCustomInvoiceFormats_Production.Size = New System.Drawing.Size(75, 20)
            Me.LabelCustomInvoiceFormats_Production.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCustomInvoiceFormats_Production.TabIndex = 0
            Me.LabelCustomInvoiceFormats_Production.Text = "Production:"
            '
            'TabItemAccountingOptions_BillingAndAccountsReceivableTab
            '
            Me.TabItemAccountingOptions_BillingAndAccountsReceivableTab.AttachedControl = Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable
            Me.TabItemAccountingOptions_BillingAndAccountsReceivableTab.Name = "TabItemAccountingOptions_BillingAndAccountsReceivableTab"
            Me.TabItemAccountingOptions_BillingAndAccountsReceivableTab.Text = "Billing && Accounts Receivable"
            '
            'TabControlPanelGLTab_GL
            '
            Me.TabControlPanelGLTab_GL.Controls.Add(Me.CheckBoxGL_UseFilter)
            Me.TabControlPanelGLTab_GL.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelGLTab_GL.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGLTab_GL.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGLTab_GL.Name = "TabControlPanelGLTab_GL"
            Me.TabControlPanelGLTab_GL.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGLTab_GL.Size = New System.Drawing.Size(941, 575)
            Me.TabControlPanelGLTab_GL.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelGLTab_GL.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGLTab_GL.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGLTab_GL.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGLTab_GL.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGLTab_GL.Style.GradientAngle = 90
            Me.TabControlPanelGLTab_GL.TabIndex = 7
            Me.TabControlPanelGLTab_GL.TabItem = Me.TabItemAccountingOptions_GLTab
            '
            'CheckBoxGL_UseFilter
            '
            Me.CheckBoxGL_UseFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGL_UseFilter.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGL_UseFilter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGL_UseFilter.CheckValue = CType(0, Short)
            Me.CheckBoxGL_UseFilter.CheckValueChecked = CType(1, Short)
            Me.CheckBoxGL_UseFilter.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxGL_UseFilter.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxGL_UseFilter.ChildControls = CType(resources.GetObject("CheckBoxGL_UseFilter.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGL_UseFilter.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGL_UseFilter.Location = New System.Drawing.Point(4, 4)
            Me.CheckBoxGL_UseFilter.Name = "CheckBoxGL_UseFilter"
            Me.CheckBoxGL_UseFilter.OldestSibling = Nothing
            Me.CheckBoxGL_UseFilter.SecurityEnabled = True
            Me.CheckBoxGL_UseFilter.SiblingControls = CType(resources.GetObject("CheckBoxGL_UseFilter.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGL_UseFilter.Size = New System.Drawing.Size(933, 20)
            Me.CheckBoxGL_UseFilter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGL_UseFilter.TabIndex = 2
            Me.CheckBoxGL_UseFilter.TabOnEnter = True
            Me.CheckBoxGL_UseFilter.Text = "Use filter when searching for GL Account codes"
            '
            'TabItemAccountingOptions_GLTab
            '
            Me.TabItemAccountingOptions_GLTab.AttachedControl = Me.TabControlPanelGLTab_GL
            Me.TabItemAccountingOptions_GLTab.Name = "TabItemAccountingOptions_GLTab"
            Me.TabItemAccountingOptions_GLTab.Text = "GL"
            '
            'TabControlPanelCurrencyTab_Currency
            '
            Me.TabControlPanelCurrencyTab_Currency.Controls.Add(Me.ButtonCurrency_TestConnection)
            Me.TabControlPanelCurrencyTab_Currency.Controls.Add(Me.PictureEditCurrency_Image)
            Me.TabControlPanelCurrencyTab_Currency.Controls.Add(Me.TextBoxCurrency_APIKey)
            Me.TabControlPanelCurrencyTab_Currency.Controls.Add(Me.LabelCurrency_APIKey)
            Me.TabControlPanelCurrencyTab_Currency.Controls.Add(Me.SearchableComboBoxCurrency_HomeCurrency)
            Me.TabControlPanelCurrencyTab_Currency.Controls.Add(Me.CheckBoxCurrency_ActivateMultipleCurrencies)
            Me.TabControlPanelCurrencyTab_Currency.Controls.Add(Me.LabelCurrency_HomeCurrency)
            Me.TabControlPanelCurrencyTab_Currency.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCurrencyTab_Currency.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCurrencyTab_Currency.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCurrencyTab_Currency.Name = "TabControlPanelCurrencyTab_Currency"
            Me.TabControlPanelCurrencyTab_Currency.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCurrencyTab_Currency.Size = New System.Drawing.Size(941, 575)
            Me.TabControlPanelCurrencyTab_Currency.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCurrencyTab_Currency.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCurrencyTab_Currency.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCurrencyTab_Currency.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCurrencyTab_Currency.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCurrencyTab_Currency.Style.GradientAngle = 90
            Me.TabControlPanelCurrencyTab_Currency.TabIndex = 5
            Me.TabControlPanelCurrencyTab_Currency.TabItem = Me.TabItemAccountingOptions_CurrencyTab
            '
            'ButtonCurrency_TestConnection
            '
            Me.ButtonCurrency_TestConnection.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonCurrency_TestConnection.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonCurrency_TestConnection.Location = New System.Drawing.Point(104, 81)
            Me.ButtonCurrency_TestConnection.Name = "ButtonCurrency_TestConnection"
            Me.ButtonCurrency_TestConnection.SecurityEnabled = True
            Me.ButtonCurrency_TestConnection.Size = New System.Drawing.Size(107, 20)
            Me.ButtonCurrency_TestConnection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonCurrency_TestConnection.TabIndex = 6
            Me.ButtonCurrency_TestConnection.Text = "Test Connection"
            '
            'PictureEditCurrency_Image
            '
            Me.PictureEditCurrency_Image.Cursor = System.Windows.Forms.Cursors.Help
            Me.PictureEditCurrency_Image.Location = New System.Drawing.Point(78, 56)
            Me.PictureEditCurrency_Image.Name = "PictureEditCurrency_Image"
            Me.PictureEditCurrency_Image.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
            Me.PictureEditCurrency_Image.Size = New System.Drawing.Size(20, 20)
            Me.PictureEditCurrency_Image.TabIndex = 4
            Me.PictureEditCurrency_Image.TabStop = True
            Me.PictureEditCurrency_Image.ToolTip = "Click the image to sign-up for free at:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "https://currencylayer.com/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
            Me.PictureEditCurrency_Image.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
            '
            'TextBoxCurrency_APIKey
            '
            Me.TextBoxCurrency_APIKey.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxCurrency_APIKey.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxCurrency_APIKey.Border.Class = "TextBoxBorder"
            Me.TextBoxCurrency_APIKey.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCurrency_APIKey.CheckSpellingOnValidate = False
            Me.TextBoxCurrency_APIKey.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxCurrency_APIKey.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxCurrency_APIKey.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxCurrency_APIKey.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCurrency_APIKey.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCurrency_APIKey.FocusHighlightEnabled = True
            Me.TextBoxCurrency_APIKey.ForeColor = System.Drawing.Color.Black
            Me.TextBoxCurrency_APIKey.Location = New System.Drawing.Point(104, 56)
            Me.TextBoxCurrency_APIKey.MaxFileSize = CType(0, Long)
            Me.TextBoxCurrency_APIKey.Name = "TextBoxCurrency_APIKey"
            Me.TextBoxCurrency_APIKey.SecurityEnabled = True
            Me.TextBoxCurrency_APIKey.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCurrency_APIKey.Size = New System.Drawing.Size(833, 20)
            Me.TextBoxCurrency_APIKey.StartingFolderName = Nothing
            Me.TextBoxCurrency_APIKey.TabIndex = 5
            Me.TextBoxCurrency_APIKey.TabOnEnter = True
            '
            'LabelCurrency_APIKey
            '
            Me.LabelCurrency_APIKey.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrency_APIKey.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrency_APIKey.Location = New System.Drawing.Point(3, 56)
            Me.LabelCurrency_APIKey.Name = "LabelCurrency_APIKey"
            Me.LabelCurrency_APIKey.Size = New System.Drawing.Size(69, 20)
            Me.LabelCurrency_APIKey.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrency_APIKey.TabIndex = 3
            Me.LabelCurrency_APIKey.Text = "API Key:"
            '
            'SearchableComboBoxCurrency_HomeCurrency
            '
            Me.SearchableComboBoxCurrency_HomeCurrency.ActiveFilterString = ""
            Me.SearchableComboBoxCurrency_HomeCurrency.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxCurrency_HomeCurrency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxCurrency_HomeCurrency.AutoFillMode = False
            Me.SearchableComboBoxCurrency_HomeCurrency.BookmarkingEnabled = False
            Me.SearchableComboBoxCurrency_HomeCurrency.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CurrencyCode
            Me.SearchableComboBoxCurrency_HomeCurrency.DataSource = Nothing
            Me.SearchableComboBoxCurrency_HomeCurrency.DisableMouseWheel = False
            Me.SearchableComboBoxCurrency_HomeCurrency.DisplayName = ""
            Me.SearchableComboBoxCurrency_HomeCurrency.EnterMoveNextControl = True
            Me.SearchableComboBoxCurrency_HomeCurrency.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxCurrency_HomeCurrency.Location = New System.Drawing.Point(104, 30)
            Me.SearchableComboBoxCurrency_HomeCurrency.Name = "SearchableComboBoxCurrency_HomeCurrency"
            Me.SearchableComboBoxCurrency_HomeCurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCurrency_HomeCurrency.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCurrency_HomeCurrency.Properties.NullText = "Select Currency Code"
            Me.SearchableComboBoxCurrency_HomeCurrency.Properties.PopupView = Me.GridView9
            Me.SearchableComboBoxCurrency_HomeCurrency.Properties.ValueMember = "Code"
            Me.SearchableComboBoxCurrency_HomeCurrency.SecurityEnabled = True
            Me.SearchableComboBoxCurrency_HomeCurrency.SelectedValue = Nothing
            Me.SearchableComboBoxCurrency_HomeCurrency.Size = New System.Drawing.Size(833, 20)
            Me.SearchableComboBoxCurrency_HomeCurrency.TabIndex = 2
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
            'CheckBoxCurrency_ActivateMultipleCurrencies
            '
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.CheckValue = CType(0, Short)
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.CheckValueChecked = CType(1, Short)
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.ChildControls = CType(resources.GetObject("CheckBoxCurrency_ActivateMultipleCurrencies.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.Location = New System.Drawing.Point(4, 4)
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.Name = "CheckBoxCurrency_ActivateMultipleCurrencies"
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.OldestSibling = Nothing
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.SecurityEnabled = True
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.SiblingControls = CType(resources.GetObject("CheckBoxCurrency_ActivateMultipleCurrencies.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.Size = New System.Drawing.Size(933, 20)
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.TabIndex = 0
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.TabOnEnter = True
            Me.CheckBoxCurrency_ActivateMultipleCurrencies.Text = "Activate Multiple Currencies"
            '
            'LabelCurrency_HomeCurrency
            '
            Me.LabelCurrency_HomeCurrency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrency_HomeCurrency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrency_HomeCurrency.Location = New System.Drawing.Point(4, 30)
            Me.LabelCurrency_HomeCurrency.Name = "LabelCurrency_HomeCurrency"
            Me.LabelCurrency_HomeCurrency.Size = New System.Drawing.Size(94, 20)
            Me.LabelCurrency_HomeCurrency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrency_HomeCurrency.TabIndex = 1
            Me.LabelCurrency_HomeCurrency.Text = "HOME Currency:"
            '
            'TabItemAccountingOptions_CurrencyTab
            '
            Me.TabItemAccountingOptions_CurrencyTab.AttachedControl = Me.TabControlPanelCurrencyTab_Currency
            Me.TabItemAccountingOptions_CurrencyTab.Name = "TabItemAccountingOptions_CurrencyTab"
            Me.TabItemAccountingOptions_CurrencyTab.Text = "Currency"
            '
            'TabItemAgencySetup_AccountingOptionsTab
            '
            Me.TabItemAgencySetup_AccountingOptionsTab.AttachedControl = Me.TabControlPanelAccountingOptionsTab_AccountingOptions
            Me.TabItemAgencySetup_AccountingOptionsTab.Name = "TabItemAgencySetup_AccountingOptionsTab"
            Me.TabItemAgencySetup_AccountingOptionsTab.Text = "Accounting Options"
            '
            'TabControlPanelProductionOptionsTab_ProductionOptions
            '
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Controls.Add(Me.GroupBox1)
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Controls.Add(Me.GroupBoxProductionOptions_PurchaseOrdersOptions)
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Controls.Add(Me.GroupBoxProductionOptions_EstimateOptions)
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Controls.Add(Me.GroupBoxProductionOptions_EstimateProcessingExceedOptions)
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Controls.Add(Me.GroupBoxProductionOptions_EstimateDefaultComments)
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Controls.Add(Me.GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments)
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Controls.Add(Me.GroupBoxProductionOptions_JobJacketOptions)
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Name = "TabControlPanelProductionOptionsTab_ProductionOptions"
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Size = New System.Drawing.Size(950, 612)
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.Style.GradientAngle = 90
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.TabIndex = 3
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.TabItem = Me.TabItemAgencySetup_ProductionOptionsTab
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.CheckBoxAllowProofHQ)
            Me.GroupBox1.Location = New System.Drawing.Point(4, 440)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(309, 55)
            Me.GroupBox1.TabIndex = 6
            Me.GroupBox1.Text = "Proof HQ Options"
            '
            'CheckBoxAllowProofHQ
            '
            '
            '
            '
            Me.CheckBoxAllowProofHQ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAllowProofHQ.CheckValue = CType(0, Short)
            Me.CheckBoxAllowProofHQ.CheckValueChecked = CType(1, Short)
            Me.CheckBoxAllowProofHQ.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxAllowProofHQ.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxAllowProofHQ.ChildControls = CType(resources.GetObject("CheckBoxAllowProofHQ.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAllowProofHQ.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAllowProofHQ.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxAllowProofHQ.Name = "CheckBoxAllowProofHQ"
            Me.CheckBoxAllowProofHQ.OldestSibling = Nothing
            Me.CheckBoxAllowProofHQ.SecurityEnabled = True
            Me.CheckBoxAllowProofHQ.SiblingControls = CType(resources.GetObject("CheckBoxAllowProofHQ.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAllowProofHQ.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxAllowProofHQ.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAllowProofHQ.TabIndex = 0
            Me.CheckBoxAllowProofHQ.TabOnEnter = True
            Me.CheckBoxAllowProofHQ.Text = "Allow Proof HQ integration"
            '
            'GroupBoxProductionOptions_PurchaseOrdersOptions
            '
            Me.GroupBoxProductionOptions_PurchaseOrdersOptions.Controls.Add(Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup)
            Me.GroupBoxProductionOptions_PurchaseOrdersOptions.Controls.Add(Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired)
            Me.GroupBoxProductionOptions_PurchaseOrdersOptions.Controls.Add(Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup)
            Me.GroupBoxProductionOptions_PurchaseOrdersOptions.Location = New System.Drawing.Point(4, 326)
            Me.GroupBoxProductionOptions_PurchaseOrdersOptions.Name = "GroupBoxProductionOptions_PurchaseOrdersOptions"
            Me.GroupBoxProductionOptions_PurchaseOrdersOptions.Size = New System.Drawing.Size(309, 108)
            Me.GroupBoxProductionOptions_PurchaseOrdersOptions.TabIndex = 2
            Me.GroupBoxProductionOptions_PurchaseOrdersOptions.Text = "Purchase Orders Options"
            '
            'SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup
            '
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.ActiveFilterString = ""
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.AutoFillMode = False
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.BookmarkingEnabled = False
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.AlertGroup
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.DataSource = Nothing
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.DisableMouseWheel = False
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.DisplayName = ""
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.EnterMoveNextControl = True
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.Location = New System.Drawing.Point(25, 76)
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.Name = "SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup"
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.Properties.NullText = "Select Alert Group"
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.Properties.PopupView = Me.SearchableComboBox1View
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.Properties.ValueMember = "Code"
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.SecurityEnabled = True
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.SelectedValue = Nothing
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.Size = New System.Drawing.Size(279, 20)
            Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.TabIndex = 2
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
            'CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired
            '
            '
            '
            '
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.CheckValue = CType(0, Short)
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.CheckValueChecked = CType(1, Short)
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.ChildControls = CType(resources.GetObject("CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.Name = "CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired"
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.OldestSibling = Nothing
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.SecurityEnabled = True
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.SiblingControls = CType(resources.GetObject("CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.TabIndex = 0
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.TabOnEnter = True
            Me.CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired.Text = "Purchase Order amount required"
            '
            'CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup
            '
            '
            '
            '
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.CheckValue = CType(0, Short)
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.CheckValueChecked = CType(1, Short)
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.ChildControls = CType(resources.GetObject("CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.Name = "CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup"
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.OldestSibling = Nothing
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.SecurityEnabled = True
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.SiblingControls = CType(resources.GetObject("CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.TabIndex = 1
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.TabOnEnter = True
            Me.CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup.Text = "Enable Purchase Order Default Alert Group"
            '
            'GroupBoxProductionOptions_EstimateOptions
            '
            Me.GroupBoxProductionOptions_EstimateOptions.Controls.Add(Me.CheckBoxEstimateOptions_ApprovedEstimateRequired)
            Me.GroupBoxProductionOptions_EstimateOptions.Controls.Add(Me.CheckBoxEstimateOptions_NewRevisionsRequired)
            Me.GroupBoxProductionOptions_EstimateOptions.Controls.Add(Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired)
            Me.GroupBoxProductionOptions_EstimateOptions.Controls.Add(Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride)
            Me.GroupBoxProductionOptions_EstimateOptions.Location = New System.Drawing.Point(4, 192)
            Me.GroupBoxProductionOptions_EstimateOptions.Name = "GroupBoxProductionOptions_EstimateOptions"
            Me.GroupBoxProductionOptions_EstimateOptions.Size = New System.Drawing.Size(309, 128)
            Me.GroupBoxProductionOptions_EstimateOptions.TabIndex = 1
            Me.GroupBoxProductionOptions_EstimateOptions.Text = "Estimate Options"
            '
            'CheckBoxEstimateOptions_ApprovedEstimateRequired
            '
            '
            '
            '
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.CheckValue = CType(0, Short)
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.CheckValueChecked = CType(1, Short)
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.ChildControls = CType(resources.GetObject("CheckBoxEstimateOptions_ApprovedEstimateRequired.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.Name = "CheckBoxEstimateOptions_ApprovedEstimateRequired"
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.OldestSibling = Nothing
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.SecurityEnabled = True
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.SiblingControls = CType(resources.GetObject("CheckBoxEstimateOptions_ApprovedEstimateRequired.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.TabIndex = 0
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.TabOnEnter = True
            Me.CheckBoxEstimateOptions_ApprovedEstimateRequired.Text = "Approved estimate required"
            '
            'CheckBoxEstimateOptions_NewRevisionsRequired
            '
            '
            '
            '
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.CheckValue = CType(0, Short)
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.CheckValueChecked = CType(1, Short)
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.ChildControls = CType(resources.GetObject("CheckBoxEstimateOptions_NewRevisionsRequired.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.Location = New System.Drawing.Point(5, 76)
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.Name = "CheckBoxEstimateOptions_NewRevisionsRequired"
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.OldestSibling = Nothing
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.SecurityEnabled = True
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.SiblingControls = CType(resources.GetObject("CheckBoxEstimateOptions_NewRevisionsRequired.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.TabIndex = 2
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.TabOnEnter = True
            Me.CheckBoxEstimateOptions_NewRevisionsRequired.Text = "Require new revisions when editing estimates"
            '
            'CheckBoxEstimateOptions_QuoteApprovalPasswordRequired
            '
            '
            '
            '
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.CheckValue = CType(0, Short)
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.CheckValueChecked = CType(1, Short)
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.ChildControls = CType(resources.GetObject("CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.Location = New System.Drawing.Point(5, 102)
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.Name = "CheckBoxEstimateOptions_QuoteApprovalPasswordRequired"
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.OldestSibling = Nothing
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.SecurityEnabled = True
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.SiblingControls = CType(resources.GetObject("CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.TabIndex = 3
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.TabOnEnter = True
            Me.CheckBoxEstimateOptions_QuoteApprovalPasswordRequired.Text = "Does quote approval require a password"
            '
            'CheckBoxJobJacketOptions_AllowRequiredEstimateOverride
            '
            '
            '
            '
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.CheckValue = CType(0, Short)
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.CheckValueChecked = CType(1, Short)
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.ChildControls = CType(resources.GetObject("CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.Name = "CheckBoxJobJacketOptions_AllowRequiredEstimateOverride"
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.OldestSibling = Nothing
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.SecurityEnabled = True
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.SiblingControls = CType(resources.GetObject("CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.Size = New System.Drawing.Size(300, 20)
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.TabIndex = 1
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.TabOnEnter = True
            Me.CheckBoxJobJacketOptions_AllowRequiredEstimateOverride.Text = "Allow required estimate setting on job to be overridden"
            '
            'GroupBoxProductionOptions_EstimateProcessingExceedOptions
            '
            Me.GroupBoxProductionOptions_EstimateProcessingExceedOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxProductionOptions_EstimateProcessingExceedOptions.Controls.Add(Me.DataGridViewEstimateProcessingExceedOptions_Options)
            Me.GroupBoxProductionOptions_EstimateProcessingExceedOptions.Location = New System.Drawing.Point(319, 4)
            Me.GroupBoxProductionOptions_EstimateProcessingExceedOptions.Name = "GroupBoxProductionOptions_EstimateProcessingExceedOptions"
            Me.GroupBoxProductionOptions_EstimateProcessingExceedOptions.Size = New System.Drawing.Size(627, 135)
            Me.GroupBoxProductionOptions_EstimateProcessingExceedOptions.TabIndex = 3
            Me.GroupBoxProductionOptions_EstimateProcessingExceedOptions.Text = "Estimate Processing / Exceed Options"
            '
            'DataGridViewEstimateProcessingExceedOptions_Options
            '
            Me.DataGridViewEstimateProcessingExceedOptions_Options.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewEstimateProcessingExceedOptions_Options.AllowDragAndDrop = False
            Me.DataGridViewEstimateProcessingExceedOptions_Options.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewEstimateProcessingExceedOptions_Options.AllowSelectGroupHeaderRow = True
            Me.DataGridViewEstimateProcessingExceedOptions_Options.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewEstimateProcessingExceedOptions_Options.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewEstimateProcessingExceedOptions_Options.AutoFilterLookupColumns = False
            Me.DataGridViewEstimateProcessingExceedOptions_Options.AutoloadRepositoryDatasource = True
            Me.DataGridViewEstimateProcessingExceedOptions_Options.AutoUpdateViewCaption = True
            Me.DataGridViewEstimateProcessingExceedOptions_Options.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewEstimateProcessingExceedOptions_Options.DataSource = Nothing
            Me.DataGridViewEstimateProcessingExceedOptions_Options.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewEstimateProcessingExceedOptions_Options.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewEstimateProcessingExceedOptions_Options.ItemDescription = ""
            Me.DataGridViewEstimateProcessingExceedOptions_Options.Location = New System.Drawing.Point(5, 25)
            Me.DataGridViewEstimateProcessingExceedOptions_Options.MultiSelect = True
            Me.DataGridViewEstimateProcessingExceedOptions_Options.Name = "DataGridViewEstimateProcessingExceedOptions_Options"
            Me.DataGridViewEstimateProcessingExceedOptions_Options.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewEstimateProcessingExceedOptions_Options.RunStandardValidation = True
            Me.DataGridViewEstimateProcessingExceedOptions_Options.ShowColumnMenuOnRightClick = False
            Me.DataGridViewEstimateProcessingExceedOptions_Options.ShowSelectDeselectAllButtons = False
            Me.DataGridViewEstimateProcessingExceedOptions_Options.Size = New System.Drawing.Size(617, 105)
            Me.DataGridViewEstimateProcessingExceedOptions_Options.TabIndex = 19
            Me.DataGridViewEstimateProcessingExceedOptions_Options.UseEmbeddedNavigator = False
            Me.DataGridViewEstimateProcessingExceedOptions_Options.ViewCaptionHeight = -1
            '
            'GroupBoxProductionOptions_EstimateDefaultComments
            '
            Me.GroupBoxProductionOptions_EstimateDefaultComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxProductionOptions_EstimateDefaultComments.Controls.Add(Me.TextBoxEstimateDefaultComments_Comments)
            Me.GroupBoxProductionOptions_EstimateDefaultComments.Location = New System.Drawing.Point(319, 145)
            Me.GroupBoxProductionOptions_EstimateDefaultComments.Name = "GroupBoxProductionOptions_EstimateDefaultComments"
            Me.GroupBoxProductionOptions_EstimateDefaultComments.Size = New System.Drawing.Size(627, 149)
            Me.GroupBoxProductionOptions_EstimateDefaultComments.TabIndex = 4
            Me.GroupBoxProductionOptions_EstimateDefaultComments.Text = "Estimate Default Comments"
            '
            'TextBoxEstimateDefaultComments_Comments
            '
            Me.TextBoxEstimateDefaultComments_Comments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxEstimateDefaultComments_Comments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxEstimateDefaultComments_Comments.Border.Class = "TextBoxBorder"
            Me.TextBoxEstimateDefaultComments_Comments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxEstimateDefaultComments_Comments.CheckSpellingOnValidate = False
            Me.TextBoxEstimateDefaultComments_Comments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxEstimateDefaultComments_Comments.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxEstimateDefaultComments_Comments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxEstimateDefaultComments_Comments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxEstimateDefaultComments_Comments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxEstimateDefaultComments_Comments.FocusHighlightEnabled = True
            Me.TextBoxEstimateDefaultComments_Comments.ForeColor = System.Drawing.Color.Black
            Me.TextBoxEstimateDefaultComments_Comments.Location = New System.Drawing.Point(5, 26)
            Me.TextBoxEstimateDefaultComments_Comments.MaxFileSize = CType(0, Long)
            Me.TextBoxEstimateDefaultComments_Comments.Multiline = True
            Me.TextBoxEstimateDefaultComments_Comments.Name = "TextBoxEstimateDefaultComments_Comments"
            Me.TextBoxEstimateDefaultComments_Comments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxEstimateDefaultComments_Comments.SecurityEnabled = True
            Me.TextBoxEstimateDefaultComments_Comments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxEstimateDefaultComments_Comments.Size = New System.Drawing.Size(617, 118)
            Me.TextBoxEstimateDefaultComments_Comments.StartingFolderName = Nothing
            Me.TextBoxEstimateDefaultComments_Comments.TabIndex = 21
            Me.TextBoxEstimateDefaultComments_Comments.TabOnEnter = False
            '
            'GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments
            '
            Me.GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments.Controls.Add(Me.LabelPurchaseOrderDefaultFooterComments_Notes)
            Me.GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments.Controls.Add(Me.TextBoxPurchaseOrderDefaultFooterComments_Comments)
            Me.GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments.Location = New System.Drawing.Point(319, 300)
            Me.GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments.Name = "GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments"
            Me.GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments.Size = New System.Drawing.Size(627, 308)
            Me.GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments.TabIndex = 5
            Me.GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments.Text = "Purchase Order Default Footer Comments"
            '
            'LabelPurchaseOrderDefaultFooterComments_Notes
            '
            Me.LabelPurchaseOrderDefaultFooterComments_Notes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.LabelPurchaseOrderDefaultFooterComments_Notes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPurchaseOrderDefaultFooterComments_Notes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPurchaseOrderDefaultFooterComments_Notes.Location = New System.Drawing.Point(5, 280)
            Me.LabelPurchaseOrderDefaultFooterComments_Notes.Name = "LabelPurchaseOrderDefaultFooterComments_Notes"
            Me.LabelPurchaseOrderDefaultFooterComments_Notes.Size = New System.Drawing.Size(613, 20)
            Me.LabelPurchaseOrderDefaultFooterComments_Notes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPurchaseOrderDefaultFooterComments_Notes.TabIndex = 24
            Me.LabelPurchaseOrderDefaultFooterComments_Notes.Text = "Footer comments are editable for each purchase order. The edited comment will be " &
    "saved with the P.O."
            '
            'TextBoxPurchaseOrderDefaultFooterComments_Comments
            '
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.Border.Class = "TextBoxBorder"
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.CheckSpellingOnValidate = False
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.FocusHighlightEnabled = True
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.ForeColor = System.Drawing.Color.Black
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.Location = New System.Drawing.Point(5, 26)
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.MaxFileSize = CType(0, Long)
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.Multiline = True
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.Name = "TextBoxPurchaseOrderDefaultFooterComments_Comments"
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.SecurityEnabled = True
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.Size = New System.Drawing.Size(617, 248)
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.StartingFolderName = Nothing
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.TabIndex = 23
            Me.TextBoxPurchaseOrderDefaultFooterComments_Comments.TabOnEnter = False
            '
            'GroupBoxProductionOptions_JobJacketOptions
            '
            Me.GroupBoxProductionOptions_JobJacketOptions.Controls.Add(Me.CheckBoxJobJacketOptions_AllowCDPOverride)
            Me.GroupBoxProductionOptions_JobJacketOptions.Controls.Add(Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride)
            Me.GroupBoxProductionOptions_JobJacketOptions.Controls.Add(Me.CheckBoxJobJacketOptions_HideNonBillableFlag)
            Me.GroupBoxProductionOptions_JobJacketOptions.Controls.Add(Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog)
            Me.GroupBoxProductionOptions_JobJacketOptions.Controls.Add(Me.CheckBoxJobJacketOptions_EnableFileAttachments)
            Me.GroupBoxProductionOptions_JobJacketOptions.Controls.Add(Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable)
            Me.GroupBoxProductionOptions_JobJacketOptions.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxProductionOptions_JobJacketOptions.Name = "GroupBoxProductionOptions_JobJacketOptions"
            Me.GroupBoxProductionOptions_JobJacketOptions.Size = New System.Drawing.Size(309, 183)
            Me.GroupBoxProductionOptions_JobJacketOptions.TabIndex = 0
            Me.GroupBoxProductionOptions_JobJacketOptions.Text = "Job Jacket Options"
            '
            'CheckBoxJobJacketOptions_AllowCDPOverride
            '
            '
            '
            '
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.CheckValue = CType(0, Short)
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.CheckValueChecked = CType(1, Short)
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.ChildControls = CType(resources.GetObject("CheckBoxJobJacketOptions_AllowCDPOverride.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.Location = New System.Drawing.Point(5, 49)
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.Name = "CheckBoxJobJacketOptions_AllowCDPOverride"
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.OldestSibling = Nothing
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.SecurityEnabled = True
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.SiblingControls = CType(resources.GetObject("CheckBoxJobJacketOptions_AllowCDPOverride.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.TabIndex = 6
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.TabOnEnter = True
            Me.CheckBoxJobJacketOptions_AllowCDPOverride.Text = "Allow CDP Change on Unbilled Jobs"
            '
            'CheckBoxJobJacketOptions_AllowOfficeCodeOverride
            '
            '
            '
            '
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.CheckValue = CType(0, Short)
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.CheckValueChecked = CType(1, Short)
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.ChildControls = CType(resources.GetObject("CheckBoxJobJacketOptions_AllowOfficeCodeOverride.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.Name = "CheckBoxJobJacketOptions_AllowOfficeCodeOverride"
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.OldestSibling = Nothing
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.SecurityEnabled = True
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.SiblingControls = CType(resources.GetObject("CheckBoxJobJacketOptions_AllowOfficeCodeOverride.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.TabIndex = 0
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.TabOnEnter = True
            Me.CheckBoxJobJacketOptions_AllowOfficeCodeOverride.Text = "Allow Office Code override on Jobs"
            '
            'CheckBoxJobJacketOptions_HideNonBillableFlag
            '
            '
            '
            '
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.CheckValue = CType(0, Short)
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.CheckValueChecked = CType(1, Short)
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.ChildControls = CType(resources.GetObject("CheckBoxJobJacketOptions_HideNonBillableFlag.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.Location = New System.Drawing.Point(5, 153)
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.Name = "CheckBoxJobJacketOptions_HideNonBillableFlag"
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.OldestSibling = Nothing
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.SecurityEnabled = True
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.SiblingControls = CType(resources.GetObject("CheckBoxJobJacketOptions_HideNonBillableFlag.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.TabIndex = 5
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.TabOnEnter = True
            Me.CheckBoxJobJacketOptions_HideNonBillableFlag.Text = "Hide non-billable flag in Job Jacket"
            '
            'CheckBoxJobJacketOptions_EnableFileAttachmentDialog
            '
            '
            '
            '
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.CheckValue = CType(0, Short)
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.CheckValueChecked = CType(1, Short)
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.ChildControls = CType(resources.GetObject("CheckBoxJobJacketOptions_EnableFileAttachmentDialog.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.Location = New System.Drawing.Point(22, 127)
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.Name = "CheckBoxJobJacketOptions_EnableFileAttachmentDialog"
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.OldestSibling = Nothing
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.SecurityEnabled = True
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.SiblingControls = CType(resources.GetObject("CheckBoxJobJacketOptions_EnableFileAttachmentDialog.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.Size = New System.Drawing.Size(282, 20)
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.TabIndex = 4
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.TabOnEnter = True
            Me.CheckBoxJobJacketOptions_EnableFileAttachmentDialog.Text = "Enable attachment file dialog"
            '
            'CheckBoxJobJacketOptions_EnableFileAttachments
            '
            '
            '
            '
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.CheckValue = CType(0, Short)
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.CheckValueChecked = CType(1, Short)
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.ChildControls = CType(resources.GetObject("CheckBoxJobJacketOptions_EnableFileAttachments.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.Location = New System.Drawing.Point(5, 101)
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.Name = "CheckBoxJobJacketOptions_EnableFileAttachments"
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.OldestSibling = Nothing
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.SecurityEnabled = True
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.SiblingControls = CType(resources.GetObject("CheckBoxJobJacketOptions_EnableFileAttachments.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.TabIndex = 3
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.TabOnEnter = True
            Me.CheckBoxJobJacketOptions_EnableFileAttachments.Text = "Enable file attachments in Job Jacket"
            '
            'CheckBoxJobJacketOptions_MarkJobComponentAsTaxable
            '
            '
            '
            '
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.CheckValue = CType(0, Short)
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.CheckValueChecked = CType(1, Short)
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.ChildControls = CType(resources.GetObject("CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Location = New System.Drawing.Point(5, 75)
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Name = "CheckBoxJobJacketOptions_MarkJobComponentAsTaxable"
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.OldestSibling = Nothing
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.SecurityEnabled = True
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.SiblingControls = CType(resources.GetObject("CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.TabIndex = 2
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.TabOnEnter = True
            Me.CheckBoxJobJacketOptions_MarkJobComponentAsTaxable.Text = "Mark Job Component as taxable or non-taxable"
            '
            'TabItemAgencySetup_ProductionOptionsTab
            '
            Me.TabItemAgencySetup_ProductionOptionsTab.AttachedControl = Me.TabControlPanelProductionOptionsTab_ProductionOptions
            Me.TabItemAgencySetup_ProductionOptionsTab.Name = "TabItemAgencySetup_ProductionOptionsTab"
            Me.TabItemAgencySetup_ProductionOptionsTab.Text = "Production Options"
            '
            'TabControlPanelRequiredFieldsTab_RequiredFields
            '
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Controls.Add(Me.GroupBoxRequiredFields_UserSelectedRequiredFields)
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Name = "TabControlPanelRequiredFieldsTab_RequiredFields"
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Size = New System.Drawing.Size(950, 612)
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.Style.GradientAngle = 90
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.TabIndex = 8
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.TabItem = Me.TabItemAgencySetup_RequiredFieldsTab
            '
            'GroupBoxRequiredFields_UserSelectedRequiredFields
            '
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Controls.Add(Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields)
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Controls.Add(Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia)
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Name = "GroupBoxRequiredFields_UserSelectedRequiredFields"
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Size = New System.Drawing.Size(942, 334)
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.TabIndex = 0
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.Text = "User Selected Required Fields"
            '
            'TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields
            '
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields.ColumnCount = 3
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields.Controls.Add(Me.PanelUserSelectedRequiredFields_RightColumn, 2, 0)
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields.Controls.Add(Me.PanelUserSelectedRequiredFields_MiddleColumn, 1, 0)
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields.Controls.Add(Me.PanelUserSelectedRequiredFields_LeftColumn, 0, 0)
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields.Location = New System.Drawing.Point(3, 25)
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields.Name = "TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields"
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields.RowCount = 1
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields.Size = New System.Drawing.Size(935, 250)
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields.TabIndex = 1
            '
            'PanelUserSelectedRequiredFields_RightColumn
            '
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobLogCustom1)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobLogCustom2)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobComponentCustom5)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobLogCustom3)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobComponentCustom4)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobLogCustom4)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobComponentCustom3)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobLogCustom5)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobComponentCustom2)
            Me.PanelUserSelectedRequiredFields_RightColumn.Controls.Add(Me.CheckBoxRightColumn_JobComponentCustom1)
            Me.PanelUserSelectedRequiredFields_RightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelUserSelectedRequiredFields_RightColumn.Location = New System.Drawing.Point(616, 0)
            Me.PanelUserSelectedRequiredFields_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelUserSelectedRequiredFields_RightColumn.Name = "PanelUserSelectedRequiredFields_RightColumn"
            Me.PanelUserSelectedRequiredFields_RightColumn.Size = New System.Drawing.Size(319, 250)
            Me.PanelUserSelectedRequiredFields_RightColumn.TabIndex = 2
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
            Me.CheckBoxRightColumn_JobLogCustom1.Location = New System.Drawing.Point(6, 0)
            Me.CheckBoxRightColumn_JobLogCustom1.Name = "CheckBoxRightColumn_JobLogCustom1"
            Me.CheckBoxRightColumn_JobLogCustom1.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobLogCustom1.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobLogCustom1.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobLogCustom1.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobLogCustom1.Size = New System.Drawing.Size(306, 20)
            Me.CheckBoxRightColumn_JobLogCustom1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobLogCustom1.TabIndex = 21
            Me.CheckBoxRightColumn_JobLogCustom1.TabOnEnter = True
            Me.CheckBoxRightColumn_JobLogCustom1.Text = "Job Log Custom 1"
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
            Me.CheckBoxRightColumn_JobLogCustom2.Location = New System.Drawing.Point(6, 25)
            Me.CheckBoxRightColumn_JobLogCustom2.Name = "CheckBoxRightColumn_JobLogCustom2"
            Me.CheckBoxRightColumn_JobLogCustom2.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobLogCustom2.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobLogCustom2.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobLogCustom2.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobLogCustom2.Size = New System.Drawing.Size(306, 20)
            Me.CheckBoxRightColumn_JobLogCustom2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobLogCustom2.TabIndex = 22
            Me.CheckBoxRightColumn_JobLogCustom2.TabOnEnter = True
            Me.CheckBoxRightColumn_JobLogCustom2.Text = "Job Log Custom 2"
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
            Me.CheckBoxRightColumn_JobComponentCustom5.Location = New System.Drawing.Point(6, 225)
            Me.CheckBoxRightColumn_JobComponentCustom5.Name = "CheckBoxRightColumn_JobComponentCustom5"
            Me.CheckBoxRightColumn_JobComponentCustom5.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobComponentCustom5.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobComponentCustom5.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobComponentCustom5.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobComponentCustom5.Size = New System.Drawing.Size(306, 20)
            Me.CheckBoxRightColumn_JobComponentCustom5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobComponentCustom5.TabIndex = 30
            Me.CheckBoxRightColumn_JobComponentCustom5.TabOnEnter = True
            Me.CheckBoxRightColumn_JobComponentCustom5.Text = "Job Component Custom 5"
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
            Me.CheckBoxRightColumn_JobLogCustom3.Location = New System.Drawing.Point(6, 50)
            Me.CheckBoxRightColumn_JobLogCustom3.Name = "CheckBoxRightColumn_JobLogCustom3"
            Me.CheckBoxRightColumn_JobLogCustom3.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobLogCustom3.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobLogCustom3.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobLogCustom3.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobLogCustom3.Size = New System.Drawing.Size(306, 20)
            Me.CheckBoxRightColumn_JobLogCustom3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobLogCustom3.TabIndex = 23
            Me.CheckBoxRightColumn_JobLogCustom3.TabOnEnter = True
            Me.CheckBoxRightColumn_JobLogCustom3.Text = "Job Log Custom 3"
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
            Me.CheckBoxRightColumn_JobComponentCustom4.Location = New System.Drawing.Point(6, 200)
            Me.CheckBoxRightColumn_JobComponentCustom4.Name = "CheckBoxRightColumn_JobComponentCustom4"
            Me.CheckBoxRightColumn_JobComponentCustom4.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobComponentCustom4.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobComponentCustom4.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobComponentCustom4.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobComponentCustom4.Size = New System.Drawing.Size(306, 20)
            Me.CheckBoxRightColumn_JobComponentCustom4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobComponentCustom4.TabIndex = 29
            Me.CheckBoxRightColumn_JobComponentCustom4.TabOnEnter = True
            Me.CheckBoxRightColumn_JobComponentCustom4.Text = "Job Component Custom 4"
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
            Me.CheckBoxRightColumn_JobLogCustom4.Location = New System.Drawing.Point(6, 75)
            Me.CheckBoxRightColumn_JobLogCustom4.Name = "CheckBoxRightColumn_JobLogCustom4"
            Me.CheckBoxRightColumn_JobLogCustom4.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobLogCustom4.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobLogCustom4.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobLogCustom4.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobLogCustom4.Size = New System.Drawing.Size(306, 20)
            Me.CheckBoxRightColumn_JobLogCustom4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobLogCustom4.TabIndex = 24
            Me.CheckBoxRightColumn_JobLogCustom4.TabOnEnter = True
            Me.CheckBoxRightColumn_JobLogCustom4.Text = "Job Log Custom 4"
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
            Me.CheckBoxRightColumn_JobComponentCustom3.Location = New System.Drawing.Point(6, 175)
            Me.CheckBoxRightColumn_JobComponentCustom3.Name = "CheckBoxRightColumn_JobComponentCustom3"
            Me.CheckBoxRightColumn_JobComponentCustom3.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobComponentCustom3.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobComponentCustom3.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobComponentCustom3.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobComponentCustom3.Size = New System.Drawing.Size(306, 20)
            Me.CheckBoxRightColumn_JobComponentCustom3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobComponentCustom3.TabIndex = 28
            Me.CheckBoxRightColumn_JobComponentCustom3.TabOnEnter = True
            Me.CheckBoxRightColumn_JobComponentCustom3.Text = "Job Component Custom 3"
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
            Me.CheckBoxRightColumn_JobLogCustom5.Location = New System.Drawing.Point(6, 100)
            Me.CheckBoxRightColumn_JobLogCustom5.Name = "CheckBoxRightColumn_JobLogCustom5"
            Me.CheckBoxRightColumn_JobLogCustom5.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobLogCustom5.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobLogCustom5.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobLogCustom5.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobLogCustom5.Size = New System.Drawing.Size(306, 20)
            Me.CheckBoxRightColumn_JobLogCustom5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobLogCustom5.TabIndex = 25
            Me.CheckBoxRightColumn_JobLogCustom5.TabOnEnter = True
            Me.CheckBoxRightColumn_JobLogCustom5.Text = "Job Log Custom 5"
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
            Me.CheckBoxRightColumn_JobComponentCustom2.Location = New System.Drawing.Point(6, 150)
            Me.CheckBoxRightColumn_JobComponentCustom2.Name = "CheckBoxRightColumn_JobComponentCustom2"
            Me.CheckBoxRightColumn_JobComponentCustom2.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobComponentCustom2.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobComponentCustom2.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobComponentCustom2.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobComponentCustom2.Size = New System.Drawing.Size(306, 20)
            Me.CheckBoxRightColumn_JobComponentCustom2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobComponentCustom2.TabIndex = 27
            Me.CheckBoxRightColumn_JobComponentCustom2.TabOnEnter = True
            Me.CheckBoxRightColumn_JobComponentCustom2.Text = "Job Component Custom 2"
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
            Me.CheckBoxRightColumn_JobComponentCustom1.Location = New System.Drawing.Point(6, 125)
            Me.CheckBoxRightColumn_JobComponentCustom1.Name = "CheckBoxRightColumn_JobComponentCustom1"
            Me.CheckBoxRightColumn_JobComponentCustom1.OldestSibling = Nothing
            Me.CheckBoxRightColumn_JobComponentCustom1.SecurityEnabled = True
            Me.CheckBoxRightColumn_JobComponentCustom1.SiblingControls = CType(resources.GetObject("CheckBoxRightColumn_JobComponentCustom1.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxRightColumn_JobComponentCustom1.Size = New System.Drawing.Size(306, 20)
            Me.CheckBoxRightColumn_JobComponentCustom1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxRightColumn_JobComponentCustom1.TabIndex = 26
            Me.CheckBoxRightColumn_JobComponentCustom1.TabOnEnter = True
            Me.CheckBoxRightColumn_JobComponentCustom1.Text = "Job Component Custom 1"
            '
            'PanelUserSelectedRequiredFields_MiddleColumn
            '
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxMiddleColumn_DeptTeam)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxMiddleColumn_ServiceFeeType)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxMiddleColumn_JobType)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxMiddleColumn_Promotion)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxMiddleColumn_DueDate)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxMiddleColumn_SalesClassFormat)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxMiddleColumn_Market)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxLeftColumn_DateOpened)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Controls.Add(Me.CheckBoxMiddleColumn_Format)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Location = New System.Drawing.Point(308, 0)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Name = "PanelUserSelectedRequiredFields_MiddleColumn"
            Me.PanelUserSelectedRequiredFields_MiddleColumn.Size = New System.Drawing.Size(308, 250)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.TabIndex = 1
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
            Me.CheckBoxMiddleColumn_DeptTeam.Location = New System.Drawing.Point(6, 25)
            Me.CheckBoxMiddleColumn_DeptTeam.Name = "CheckBoxMiddleColumn_DeptTeam"
            Me.CheckBoxMiddleColumn_DeptTeam.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_DeptTeam.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_DeptTeam.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_DeptTeam.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_DeptTeam.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxMiddleColumn_DeptTeam.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_DeptTeam.TabIndex = 2
            Me.CheckBoxMiddleColumn_DeptTeam.TabOnEnter = True
            Me.CheckBoxMiddleColumn_DeptTeam.Text = "Dept / Team"
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
            Me.CheckBoxMiddleColumn_ServiceFeeType.Location = New System.Drawing.Point(6, 200)
            Me.CheckBoxMiddleColumn_ServiceFeeType.Name = "CheckBoxMiddleColumn_ServiceFeeType"
            Me.CheckBoxMiddleColumn_ServiceFeeType.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_ServiceFeeType.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_ServiceFeeType.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_ServiceFeeType.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_ServiceFeeType.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxMiddleColumn_ServiceFeeType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_ServiceFeeType.TabIndex = 9
            Me.CheckBoxMiddleColumn_ServiceFeeType.TabOnEnter = True
            Me.CheckBoxMiddleColumn_ServiceFeeType.Text = "Service Fee Type"
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
            Me.CheckBoxMiddleColumn_JobType.Location = New System.Drawing.Point(6, 100)
            Me.CheckBoxMiddleColumn_JobType.Name = "CheckBoxMiddleColumn_JobType"
            Me.CheckBoxMiddleColumn_JobType.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_JobType.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_JobType.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_JobType.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_JobType.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxMiddleColumn_JobType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_JobType.TabIndex = 5
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
            Me.CheckBoxMiddleColumn_Promotion.Location = New System.Drawing.Point(6, 150)
            Me.CheckBoxMiddleColumn_Promotion.Name = "CheckBoxMiddleColumn_Promotion"
            Me.CheckBoxMiddleColumn_Promotion.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_Promotion.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_Promotion.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_Promotion.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_Promotion.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxMiddleColumn_Promotion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_Promotion.TabIndex = 7
            Me.CheckBoxMiddleColumn_Promotion.TabOnEnter = True
            Me.CheckBoxMiddleColumn_Promotion.Text = "Promotion"
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
            Me.CheckBoxMiddleColumn_DueDate.Location = New System.Drawing.Point(6, 50)
            Me.CheckBoxMiddleColumn_DueDate.Name = "CheckBoxMiddleColumn_DueDate"
            Me.CheckBoxMiddleColumn_DueDate.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_DueDate.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_DueDate.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_DueDate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_DueDate.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxMiddleColumn_DueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_DueDate.TabIndex = 3
            Me.CheckBoxMiddleColumn_DueDate.TabOnEnter = True
            Me.CheckBoxMiddleColumn_DueDate.Text = "Due Date"
            '
            'CheckBoxMiddleColumn_SalesClassFormat
            '
            Me.CheckBoxMiddleColumn_SalesClassFormat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMiddleColumn_SalesClassFormat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMiddleColumn_SalesClassFormat.CheckValue = CType(0, Short)
            Me.CheckBoxMiddleColumn_SalesClassFormat.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMiddleColumn_SalesClassFormat.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMiddleColumn_SalesClassFormat.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMiddleColumn_SalesClassFormat.ChildControls = CType(resources.GetObject("CheckBoxMiddleColumn_SalesClassFormat.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_SalesClassFormat.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMiddleColumn_SalesClassFormat.Location = New System.Drawing.Point(6, 175)
            Me.CheckBoxMiddleColumn_SalesClassFormat.Name = "CheckBoxMiddleColumn_SalesClassFormat"
            Me.CheckBoxMiddleColumn_SalesClassFormat.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_SalesClassFormat.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_SalesClassFormat.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_SalesClassFormat.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_SalesClassFormat.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxMiddleColumn_SalesClassFormat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_SalesClassFormat.TabIndex = 8
            Me.CheckBoxMiddleColumn_SalesClassFormat.TabOnEnter = True
            Me.CheckBoxMiddleColumn_SalesClassFormat.Text = "Sales Class Format"
            '
            'CheckBoxMiddleColumn_Market
            '
            Me.CheckBoxMiddleColumn_Market.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMiddleColumn_Market.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMiddleColumn_Market.CheckValue = CType(0, Short)
            Me.CheckBoxMiddleColumn_Market.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMiddleColumn_Market.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMiddleColumn_Market.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMiddleColumn_Market.ChildControls = CType(resources.GetObject("CheckBoxMiddleColumn_Market.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_Market.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMiddleColumn_Market.Location = New System.Drawing.Point(6, 125)
            Me.CheckBoxMiddleColumn_Market.Name = "CheckBoxMiddleColumn_Market"
            Me.CheckBoxMiddleColumn_Market.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_Market.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_Market.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_Market.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_Market.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxMiddleColumn_Market.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_Market.TabIndex = 6
            Me.CheckBoxMiddleColumn_Market.TabOnEnter = True
            Me.CheckBoxMiddleColumn_Market.Text = "Market"
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
            Me.CheckBoxLeftColumn_DateOpened.Location = New System.Drawing.Point(6, 0)
            Me.CheckBoxLeftColumn_DateOpened.Name = "CheckBoxLeftColumn_DateOpened"
            Me.CheckBoxLeftColumn_DateOpened.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_DateOpened.SecurityEnabled = True
            Me.CheckBoxLeftColumn_DateOpened.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_DateOpened.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_DateOpened.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxLeftColumn_DateOpened.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_DateOpened.TabIndex = 1
            Me.CheckBoxLeftColumn_DateOpened.TabOnEnter = True
            Me.CheckBoxLeftColumn_DateOpened.Text = "Date Opened"
            '
            'CheckBoxMiddleColumn_Format
            '
            Me.CheckBoxMiddleColumn_Format.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMiddleColumn_Format.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMiddleColumn_Format.CheckValue = CType(0, Short)
            Me.CheckBoxMiddleColumn_Format.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMiddleColumn_Format.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMiddleColumn_Format.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMiddleColumn_Format.ChildControls = CType(resources.GetObject("CheckBoxMiddleColumn_Format.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_Format.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMiddleColumn_Format.Location = New System.Drawing.Point(6, 75)
            Me.CheckBoxMiddleColumn_Format.Name = "CheckBoxMiddleColumn_Format"
            Me.CheckBoxMiddleColumn_Format.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_Format.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_Format.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_Format.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_Format.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxMiddleColumn_Format.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_Format.TabIndex = 4
            Me.CheckBoxMiddleColumn_Format.TabOnEnter = True
            Me.CheckBoxMiddleColumn_Format.Text = "Format"
            '
            'PanelUserSelectedRequiredFields_LeftColumn
            '
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_AccountNumber)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_Budget)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxMiddleColumn_Contact)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_Complexity)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_AlertGroup)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_Blackplate2)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_CoopBilling)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_AdNumber)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_ClientReference)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Controls.Add(Me.CheckBoxLeftColumn_Blackplate1)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelUserSelectedRequiredFields_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelUserSelectedRequiredFields_LeftColumn.Name = "PanelUserSelectedRequiredFields_LeftColumn"
            Me.PanelUserSelectedRequiredFields_LeftColumn.Size = New System.Drawing.Size(308, 250)
            Me.PanelUserSelectedRequiredFields_LeftColumn.TabIndex = 0
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
            Me.CheckBoxLeftColumn_AccountNumber.Location = New System.Drawing.Point(6, 0)
            Me.CheckBoxLeftColumn_AccountNumber.Name = "CheckBoxLeftColumn_AccountNumber"
            Me.CheckBoxLeftColumn_AccountNumber.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_AccountNumber.SecurityEnabled = True
            Me.CheckBoxLeftColumn_AccountNumber.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_AccountNumber.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_AccountNumber.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxLeftColumn_AccountNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_AccountNumber.TabIndex = 1
            Me.CheckBoxLeftColumn_AccountNumber.TabOnEnter = True
            Me.CheckBoxLeftColumn_AccountNumber.Text = "Account Number"
            '
            'CheckBoxLeftColumn_Budget
            '
            Me.CheckBoxLeftColumn_Budget.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLeftColumn_Budget.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftColumn_Budget.CheckValue = CType(0, Short)
            Me.CheckBoxLeftColumn_Budget.CheckValueChecked = CType(1, Short)
            Me.CheckBoxLeftColumn_Budget.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxLeftColumn_Budget.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxLeftColumn_Budget.ChildControls = CType(resources.GetObject("CheckBoxLeftColumn_Budget.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_Budget.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftColumn_Budget.Location = New System.Drawing.Point(6, 125)
            Me.CheckBoxLeftColumn_Budget.Name = "CheckBoxLeftColumn_Budget"
            Me.CheckBoxLeftColumn_Budget.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_Budget.SecurityEnabled = True
            Me.CheckBoxLeftColumn_Budget.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_Budget.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_Budget.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxLeftColumn_Budget.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_Budget.TabIndex = 6
            Me.CheckBoxLeftColumn_Budget.TabOnEnter = True
            Me.CheckBoxLeftColumn_Budget.Text = "Budget"
            '
            'CheckBoxMiddleColumn_Contact
            '
            Me.CheckBoxMiddleColumn_Contact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxMiddleColumn_Contact.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxMiddleColumn_Contact.CheckValue = CType(0, Short)
            Me.CheckBoxMiddleColumn_Contact.CheckValueChecked = CType(1, Short)
            Me.CheckBoxMiddleColumn_Contact.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxMiddleColumn_Contact.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxMiddleColumn_Contact.ChildControls = CType(resources.GetObject("CheckBoxMiddleColumn_Contact.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_Contact.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxMiddleColumn_Contact.Location = New System.Drawing.Point(6, 200)
            Me.CheckBoxMiddleColumn_Contact.Name = "CheckBoxMiddleColumn_Contact"
            Me.CheckBoxMiddleColumn_Contact.OldestSibling = Nothing
            Me.CheckBoxMiddleColumn_Contact.SecurityEnabled = True
            Me.CheckBoxMiddleColumn_Contact.SiblingControls = CType(resources.GetObject("CheckBoxMiddleColumn_Contact.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxMiddleColumn_Contact.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxMiddleColumn_Contact.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxMiddleColumn_Contact.TabIndex = 9
            Me.CheckBoxMiddleColumn_Contact.TabOnEnter = True
            Me.CheckBoxMiddleColumn_Contact.Text = "Contact"
            '
            'CheckBoxLeftColumn_Complexity
            '
            Me.CheckBoxLeftColumn_Complexity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLeftColumn_Complexity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftColumn_Complexity.CheckValue = CType(0, Short)
            Me.CheckBoxLeftColumn_Complexity.CheckValueChecked = CType(1, Short)
            Me.CheckBoxLeftColumn_Complexity.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxLeftColumn_Complexity.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxLeftColumn_Complexity.ChildControls = CType(resources.GetObject("CheckBoxLeftColumn_Complexity.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_Complexity.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftColumn_Complexity.Location = New System.Drawing.Point(6, 175)
            Me.CheckBoxLeftColumn_Complexity.Name = "CheckBoxLeftColumn_Complexity"
            Me.CheckBoxLeftColumn_Complexity.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_Complexity.SecurityEnabled = True
            Me.CheckBoxLeftColumn_Complexity.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_Complexity.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_Complexity.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxLeftColumn_Complexity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_Complexity.TabIndex = 8
            Me.CheckBoxLeftColumn_Complexity.TabOnEnter = True
            Me.CheckBoxLeftColumn_Complexity.Text = "Complexity"
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
            Me.CheckBoxLeftColumn_AlertGroup.Location = New System.Drawing.Point(6, 50)
            Me.CheckBoxLeftColumn_AlertGroup.Name = "CheckBoxLeftColumn_AlertGroup"
            Me.CheckBoxLeftColumn_AlertGroup.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_AlertGroup.SecurityEnabled = True
            Me.CheckBoxLeftColumn_AlertGroup.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_AlertGroup.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_AlertGroup.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxLeftColumn_AlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_AlertGroup.TabIndex = 3
            Me.CheckBoxLeftColumn_AlertGroup.TabOnEnter = True
            Me.CheckBoxLeftColumn_AlertGroup.Text = "Alert Group"
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
            Me.CheckBoxLeftColumn_Blackplate2.Location = New System.Drawing.Point(6, 100)
            Me.CheckBoxLeftColumn_Blackplate2.Name = "CheckBoxLeftColumn_Blackplate2"
            Me.CheckBoxLeftColumn_Blackplate2.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_Blackplate2.SecurityEnabled = True
            Me.CheckBoxLeftColumn_Blackplate2.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_Blackplate2.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_Blackplate2.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxLeftColumn_Blackplate2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_Blackplate2.TabIndex = 5
            Me.CheckBoxLeftColumn_Blackplate2.TabOnEnter = True
            Me.CheckBoxLeftColumn_Blackplate2.Text = "Blackplate 2"
            '
            'CheckBoxLeftColumn_CoopBilling
            '
            Me.CheckBoxLeftColumn_CoopBilling.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxLeftColumn_CoopBilling.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLeftColumn_CoopBilling.CheckValue = CType(0, Short)
            Me.CheckBoxLeftColumn_CoopBilling.CheckValueChecked = CType(1, Short)
            Me.CheckBoxLeftColumn_CoopBilling.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxLeftColumn_CoopBilling.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxLeftColumn_CoopBilling.ChildControls = CType(resources.GetObject("CheckBoxLeftColumn_CoopBilling.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_CoopBilling.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLeftColumn_CoopBilling.Location = New System.Drawing.Point(6, 225)
            Me.CheckBoxLeftColumn_CoopBilling.Name = "CheckBoxLeftColumn_CoopBilling"
            Me.CheckBoxLeftColumn_CoopBilling.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_CoopBilling.SecurityEnabled = True
            Me.CheckBoxLeftColumn_CoopBilling.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_CoopBilling.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_CoopBilling.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxLeftColumn_CoopBilling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_CoopBilling.TabIndex = 10
            Me.CheckBoxLeftColumn_CoopBilling.TabOnEnter = True
            Me.CheckBoxLeftColumn_CoopBilling.Text = "Coop Billing"
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
            Me.CheckBoxLeftColumn_AdNumber.Location = New System.Drawing.Point(6, 25)
            Me.CheckBoxLeftColumn_AdNumber.Name = "CheckBoxLeftColumn_AdNumber"
            Me.CheckBoxLeftColumn_AdNumber.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_AdNumber.SecurityEnabled = True
            Me.CheckBoxLeftColumn_AdNumber.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_AdNumber.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_AdNumber.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxLeftColumn_AdNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_AdNumber.TabIndex = 2
            Me.CheckBoxLeftColumn_AdNumber.TabOnEnter = True
            Me.CheckBoxLeftColumn_AdNumber.Text = "Ad Number"
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
            Me.CheckBoxLeftColumn_ClientReference.Location = New System.Drawing.Point(6, 150)
            Me.CheckBoxLeftColumn_ClientReference.Name = "CheckBoxLeftColumn_ClientReference"
            Me.CheckBoxLeftColumn_ClientReference.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_ClientReference.SecurityEnabled = True
            Me.CheckBoxLeftColumn_ClientReference.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_ClientReference.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_ClientReference.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxLeftColumn_ClientReference.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_ClientReference.TabIndex = 7
            Me.CheckBoxLeftColumn_ClientReference.TabOnEnter = True
            Me.CheckBoxLeftColumn_ClientReference.Text = "Client Reference"
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
            Me.CheckBoxLeftColumn_Blackplate1.Location = New System.Drawing.Point(6, 75)
            Me.CheckBoxLeftColumn_Blackplate1.Name = "CheckBoxLeftColumn_Blackplate1"
            Me.CheckBoxLeftColumn_Blackplate1.OldestSibling = Nothing
            Me.CheckBoxLeftColumn_Blackplate1.SecurityEnabled = True
            Me.CheckBoxLeftColumn_Blackplate1.SiblingControls = CType(resources.GetObject("CheckBoxLeftColumn_Blackplate1.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLeftColumn_Blackplate1.Size = New System.Drawing.Size(299, 20)
            Me.CheckBoxLeftColumn_Blackplate1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLeftColumn_Blackplate1.TabIndex = 4
            Me.CheckBoxLeftColumn_Blackplate1.TabOnEnter = True
            Me.CheckBoxLeftColumn_Blackplate1.Text = "Blackplate 1"
            '
            'GroupBoxUserSelectedRequiredFields_JobsAndMedia
            '
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.Controls.Add(Me.CheckBoxJobsAndMedia_FiscalPeriod)
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.Controls.Add(Me.CheckBoxJobsAndMedia_Campaign)
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.Location = New System.Drawing.Point(6, 278)
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.Name = "GroupBoxUserSelectedRequiredFields_JobsAndMedia"
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.Size = New System.Drawing.Size(929, 48)
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.TabIndex = 31
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
            Me.CheckBoxJobsAndMedia_FiscalPeriod.Size = New System.Drawing.Size(115, 20)
            Me.CheckBoxJobsAndMedia_FiscalPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxJobsAndMedia_FiscalPeriod.TabIndex = 33
            Me.CheckBoxJobsAndMedia_FiscalPeriod.TabOnEnter = True
            Me.CheckBoxJobsAndMedia_FiscalPeriod.Text = "Fiscal Period"
            '
            'CheckBoxJobsAndMedia_Campaign
            '
            '
            '
            '
            Me.CheckBoxJobsAndMedia_Campaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxJobsAndMedia_Campaign.CheckValue = CType(0, Short)
            Me.CheckBoxJobsAndMedia_Campaign.CheckValueChecked = CType(1, Short)
            Me.CheckBoxJobsAndMedia_Campaign.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxJobsAndMedia_Campaign.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxJobsAndMedia_Campaign.ChildControls = CType(resources.GetObject("CheckBoxJobsAndMedia_Campaign.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobsAndMedia_Campaign.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxJobsAndMedia_Campaign.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxJobsAndMedia_Campaign.Name = "CheckBoxJobsAndMedia_Campaign"
            Me.CheckBoxJobsAndMedia_Campaign.OldestSibling = Nothing
            Me.CheckBoxJobsAndMedia_Campaign.SecurityEnabled = True
            Me.CheckBoxJobsAndMedia_Campaign.SiblingControls = CType(resources.GetObject("CheckBoxJobsAndMedia_Campaign.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxJobsAndMedia_Campaign.Size = New System.Drawing.Size(104, 20)
            Me.CheckBoxJobsAndMedia_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxJobsAndMedia_Campaign.TabIndex = 32
            Me.CheckBoxJobsAndMedia_Campaign.TabOnEnter = True
            Me.CheckBoxJobsAndMedia_Campaign.Text = "Campaign"
            '
            'TabItemAgencySetup_RequiredFieldsTab
            '
            Me.TabItemAgencySetup_RequiredFieldsTab.AttachedControl = Me.TabControlPanelRequiredFieldsTab_RequiredFields
            Me.TabItemAgencySetup_RequiredFieldsTab.Name = "TabItemAgencySetup_RequiredFieldsTab"
            Me.TabItemAgencySetup_RequiredFieldsTab.Text = "Required Fields"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Email)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_AutomatedAssignments)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_AdServerFields)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Text)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(-3, 1)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(653, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 23
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_Email
            '
            Me.RibbonBarOptions_Email.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Email.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Email.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Email.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Email.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Email.DragDropSupport = True
            Me.RibbonBarOptions_Email.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemEmail_TestSending, Me.ButtonItemEmail_TestReceiving})
            Me.RibbonBarOptions_Email.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Email.Location = New System.Drawing.Point(419, 0)
            Me.RibbonBarOptions_Email.Name = "RibbonBarOptions_Email"
            Me.RibbonBarOptions_Email.SecurityEnabled = True
            Me.RibbonBarOptions_Email.Size = New System.Drawing.Size(162, 98)
            Me.RibbonBarOptions_Email.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Email.TabIndex = 5
            Me.RibbonBarOptions_Email.Text = "Email"
            '
            '
            '
            Me.RibbonBarOptions_Email.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Email.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Email.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Email.Visible = False
            '
            'ButtonItemEmail_TestSending
            '
            Me.ButtonItemEmail_TestSending.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmail_TestSending.Name = "ButtonItemEmail_TestSending"
            Me.ButtonItemEmail_TestSending.RibbonWordWrap = False
            Me.ButtonItemEmail_TestSending.SecurityEnabled = True
            Me.ButtonItemEmail_TestSending.SubItemsExpandWidth = 14
            Me.ButtonItemEmail_TestSending.Text = "Test Sending"
            '
            'ButtonItemEmail_TestReceiving
            '
            Me.ButtonItemEmail_TestReceiving.BeginGroup = True
            Me.ButtonItemEmail_TestReceiving.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmail_TestReceiving.Name = "ButtonItemEmail_TestReceiving"
            Me.ButtonItemEmail_TestReceiving.RibbonWordWrap = False
            Me.ButtonItemEmail_TestReceiving.SecurityEnabled = True
            Me.ButtonItemEmail_TestReceiving.SubItemsExpandWidth = 14
            Me.ButtonItemEmail_TestReceiving.Text = "Test Receiving"
            '
            'RibbonBarOptions_AutomatedAssignments
            '
            Me.RibbonBarOptions_AutomatedAssignments.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_AutomatedAssignments.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_AutomatedAssignments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_AutomatedAssignments.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_AutomatedAssignments.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_AutomatedAssignments.DragDropSupport = True
            Me.RibbonBarOptions_AutomatedAssignments.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemAutomatedAssignments_Delete, Me.ButtonItemAutomatedAssignments_Cancel})
            Me.RibbonBarOptions_AutomatedAssignments.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_AutomatedAssignments.Location = New System.Drawing.Point(291, 0)
            Me.RibbonBarOptions_AutomatedAssignments.Name = "RibbonBarOptions_AutomatedAssignments"
            Me.RibbonBarOptions_AutomatedAssignments.SecurityEnabled = True
            Me.RibbonBarOptions_AutomatedAssignments.Size = New System.Drawing.Size(128, 98)
            Me.RibbonBarOptions_AutomatedAssignments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_AutomatedAssignments.TabIndex = 4
            Me.RibbonBarOptions_AutomatedAssignments.Text = "Automated Assignments"
            '
            '
            '
            Me.RibbonBarOptions_AutomatedAssignments.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_AutomatedAssignments.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_AutomatedAssignments.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_AutomatedAssignments.Visible = False
            '
            'ButtonItemAutomatedAssignments_Delete
            '
            Me.ButtonItemAutomatedAssignments_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAutomatedAssignments_Delete.Name = "ButtonItemAutomatedAssignments_Delete"
            Me.ButtonItemAutomatedAssignments_Delete.RibbonWordWrap = False
            Me.ButtonItemAutomatedAssignments_Delete.SecurityEnabled = True
            Me.ButtonItemAutomatedAssignments_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemAutomatedAssignments_Delete.Text = "Delete"
            '
            'ButtonItemAutomatedAssignments_Cancel
            '
            Me.ButtonItemAutomatedAssignments_Cancel.BeginGroup = True
            Me.ButtonItemAutomatedAssignments_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAutomatedAssignments_Cancel.Name = "ButtonItemAutomatedAssignments_Cancel"
            Me.ButtonItemAutomatedAssignments_Cancel.RibbonWordWrap = False
            Me.ButtonItemAutomatedAssignments_Cancel.SecurityEnabled = True
            Me.ButtonItemAutomatedAssignments_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemAutomatedAssignments_Cancel.Text = "Cancel"
            '
            'RibbonBarOptions_AdServerFields
            '
            Me.RibbonBarOptions_AdServerFields.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_AdServerFields.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_AdServerFields.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_AdServerFields.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_AdServerFields.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_AdServerFields.DragDropSupport = True
            Me.RibbonBarOptions_AdServerFields.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFields_MoveUp, Me.ButtonItemFields_MoveDown})
            Me.RibbonBarOptions_AdServerFields.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_AdServerFields.Location = New System.Drawing.Point(195, 0)
            Me.RibbonBarOptions_AdServerFields.Name = "RibbonBarOptions_AdServerFields"
            Me.RibbonBarOptions_AdServerFields.SecurityEnabled = True
            Me.RibbonBarOptions_AdServerFields.Size = New System.Drawing.Size(96, 98)
            Me.RibbonBarOptions_AdServerFields.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_AdServerFields.TabIndex = 3
            Me.RibbonBarOptions_AdServerFields.Text = "Ad Server Fields"
            '
            '
            '
            Me.RibbonBarOptions_AdServerFields.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_AdServerFields.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_AdServerFields.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemFields_MoveUp
            '
            Me.ButtonItemFields_MoveUp.BeginGroup = True
            Me.ButtonItemFields_MoveUp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFields_MoveUp.Name = "ButtonItemFields_MoveUp"
            Me.ButtonItemFields_MoveUp.RibbonWordWrap = False
            Me.ButtonItemFields_MoveUp.SubItemsExpandWidth = 14
            Me.ButtonItemFields_MoveUp.Text = "Up"
            '
            'ButtonItemFields_MoveDown
            '
            Me.ButtonItemFields_MoveDown.BeginGroup = True
            Me.ButtonItemFields_MoveDown.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFields_MoveDown.Name = "ButtonItemFields_MoveDown"
            Me.ButtonItemFields_MoveDown.RibbonWordWrap = False
            Me.ButtonItemFields_MoveDown.SubItemsExpandWidth = 14
            Me.ButtonItemFields_MoveDown.Text = "Down"
            '
            'RibbonBarOptions_Actions
            '
            Me.RibbonBarOptions_Actions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(99, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(96, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 0
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'RibbonBarOptions_Text
            '
            Me.RibbonBarOptions_Text.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Text.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Text.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Text.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Text.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Text.DragDropSupport = True
            Me.RibbonBarOptions_Text.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemText_CheckSpelling})
            Me.RibbonBarOptions_Text.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Text.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Text.Name = "RibbonBarOptions_Text"
            Me.RibbonBarOptions_Text.SecurityEnabled = True
            Me.RibbonBarOptions_Text.Size = New System.Drawing.Size(99, 98)
            Me.RibbonBarOptions_Text.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Text.TabIndex = 2
            Me.RibbonBarOptions_Text.Text = "Text"
            '
            '
            '
            Me.RibbonBarOptions_Text.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Text.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Text.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Text.Visible = False
            '
            'ButtonItemText_CheckSpelling
            '
            Me.ButtonItemText_CheckSpelling.BeginGroup = True
            Me.ButtonItemText_CheckSpelling.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemText_CheckSpelling.Name = "ButtonItemText_CheckSpelling"
            Me.ButtonItemText_CheckSpelling.RibbonWordWrap = False
            Me.ButtonItemText_CheckSpelling.SubItemsExpandWidth = 14
            Me.ButtonItemText_CheckSpelling.Text = "Check Spelling"
            '
            'GroupBoxOptions_EmailingDocuments
            '
            Me.GroupBoxOptions_EmailingDocuments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxOptions_EmailingDocuments.Controls.Add(Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink)
            Me.GroupBoxOptions_EmailingDocuments.Location = New System.Drawing.Point(370, 324)
            Me.GroupBoxOptions_EmailingDocuments.Name = "GroupBoxOptions_EmailingDocuments"
            Me.GroupBoxOptions_EmailingDocuments.Size = New System.Drawing.Size(567, 52)
            Me.GroupBoxOptions_EmailingDocuments.TabIndex = 9
            Me.GroupBoxOptions_EmailingDocuments.Text = "Emailing Documents"
            '
            'CheckBoxEmailingDocuments_SendFilesAsOneTimeLink
            '
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.CheckValue = CType(0, Short)
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.CheckValueChecked = CType(1, Short)
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Short]
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.CheckValueUnchecked = CType(0, Short)
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.ChildControls = CType(resources.GetObject("CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.EnableMnemonicWithAltKeyOnly = True
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.Location = New System.Drawing.Point(6, 21)
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.Name = "CheckBoxEmailingDocuments_SendFilesAsOneTimeLink"
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.OldestSibling = Nothing
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.SecurityEnabled = True
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.SiblingControls = CType(resources.GetObject("CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.Size = New System.Drawing.Size(557, 20)
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.TabIndex = 0
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.TabOnEnter = True
            Me.CheckBoxEmailingDocuments_SendFilesAsOneTimeLink.Text = "Send Files as One Time Link"
            '
            'AgencySetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(974, 663)
            Me.Controls.Add(Me.TabControlForm_AgencySetup)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AgencySetupForm"
            Me.Text = "Agency Setup"
            CType(Me.TabControlForm_AgencySetup, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlForm_AgencySetup.ResumeLayout(False)
            Me.TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions.ResumeLayout(False)
            CType(Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlSystemAndAlertOptions_SystemAndAlertOptions.ResumeLayout(False)
            Me.TabControlPanelOptionsTab_Options.ResumeLayout(False)
            CType(Me.GroupBoxSystemAndAlertOptions_ProofingURL, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxSystemAndAlertOptions_ProofingURL.ResumeLayout(False)
            CType(Me.GroupBoxSystemAndAlertOptions_DotNetFolder, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxSystemAndAlertOptions_DotNetFolder.ResumeLayout(False)
            CType(Me.GroupBoxSystemAndAlertOptions_ClientPortalURL, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxSystemAndAlertOptions_ClientPortalURL.ResumeLayout(False)
            CType(Me.GroupBoxOptions_EmailAttachments, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxOptions_EmailAttachments.ResumeLayout(False)
            CType(Me.NumericInputEmailAttachments_MaxFileSize.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder.ResumeLayout(False)
            CType(Me.GroupBoxOptions_AlertOptions, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxOptions_AlertOptions.ResumeLayout(False)
            CType(Me.GroupBoxSystemAndAlertOptions_WebvantageURL, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxSystemAndAlertOptions_WebvantageURL.ResumeLayout(False)
            CType(Me.GroupBoxSystemAndAlertOptions_AccessReportSourceFolder, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxSystemAndAlertOptions_AccessReportSourceFolder.ResumeLayout(False)
            Me.TabControlPanelEmailSettingsTab_EmailSettings.ResumeLayout(False)
            CType(Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings.ResumeLayout(False)
            CType(Me.NumericInputPOP3EmailListenerSettings_PortNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxSystemAndAlertOptions_SMTPEmailSetup.ResumeLayout(False)
            CType(Me.NumericInputSMTPEmailSetup_PortNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlPanelInformationTab_Information.ResumeLayout(False)
            CType(Me.GroupBoxInformation_AgencyInformation, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxInformation_AgencyInformation.ResumeLayout(False)
            Me.TabControlPanelMediaOptionsTab_MediaOptions.ResumeLayout(False)
            CType(Me.TabControlMediaOptions_MediaOptions, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlMediaOptions_MediaOptions.ResumeLayout(False)
            Me.TabControlPanelFooterCommentsTab_FooterComments.ResumeLayout(False)
            CType(Me.TabControlFooterComments_FooterComments, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlFooterComments_FooterComments.ResumeLayout(False)
            Me.TabControlPanelNewspaperTab_Newspaper.ResumeLayout(False)
            Me.TabControlPanelInternetTab_Internet.ResumeLayout(False)
            Me.TabControlPanelMagazineTab_Magazine.ResumeLayout(False)
            Me.TabControlPanelTelevisionTab_Television.ResumeLayout(False)
            Me.TabControlPanelRadioTab_Radio.ResumeLayout(False)
            Me.TabControlPanelOutOfHomeTab_OutOfHome.ResumeLayout(False)
            Me.TabControlPanelSettingsTab_Settings.ResumeLayout(False)
            CType(Me.GroupBoxMediaOptions_BroadcastWorksheet, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxMediaOptions_BroadcastWorksheet.ResumeLayout(False)
            CType(Me.DateTimePickerSettings_MediaTrafficStartDate, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GroupBoxSettings_MediaGeneral, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxSettings_MediaGeneral.ResumeLayout(False)
            CType(Me.GroupBoxSettings_MediaOrders, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxSettings_MediaOrders.ResumeLayout(False)
            CType(Me.GroupBoxSettings_MediaPlanning, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxSettings_MediaPlanning.ResumeLayout(False)
            CType(Me.GroupBoxSettings_ExportMediaOrder, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxSettings_ExportMediaOrder.ResumeLayout(False)
            Me.TabControlPanelAdServingTab_AdServing.ResumeLayout(False)
            CType(Me.PanelAdServing_RightSection, System.ComponentModel.ISupportInitialize).EndInit
            Me.PanelAdServing_RightSection.ResumeLayout(False)
            CType(Me.PanelAdServing_LeftSection, System.ComponentModel.ISupportInitialize).EndInit
            Me.PanelAdServing_LeftSection.ResumeLayout(False)
            Me.TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms.ResumeLayout(False)
            Me.TabControlPanelTimesheetOptionsTab_TimesheetOptions.ResumeLayout(False)
            CType(Me.GroupBoxTimesheetOptions_MissingTimeOptions, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxTimesheetOptions_MissingTimeOptions.ResumeLayout(False)
            CType(Me.GroupBoxTimesheetOptions_TimesheetOptions, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxTimesheetOptions_TimesheetOptions.ResumeLayout(False)
            Me.TabControlPanelAccountingOptionsTab_AccountingOptions.ResumeLayout(False)
            CType(Me.TabControlAccountingOptions_AccountingOptions, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlAccountingOptions_AccountingOptions.ResumeLayout(False)
            Me.TabControlPanelAccountsPayableTab_AccountsPayable.ResumeLayout(False)
            CType(Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxAccountingOptions_AccountsPayableApprovalAlert.ResumeLayout(False)
            CType(Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView13, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView12, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView11, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GroupBoxAccountingOptions_AccountsPayableHeader, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxAccountingOptions_AccountsPayableHeader.ResumeLayout(False)
            CType(Me.GroupBoxAccountingOptions_AccountsPayableDisbursement, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxAccountingOptions_AccountsPayableDisbursement.ResumeLayout(False)
            Me.TabControlPanel1.ResumeLayout(False)
            CType(Me.GroupBoxAvatax_AddressOptions, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxAvatax_AddressOptions.ResumeLayout(False)
            CType(Me.GroupBoxAvaTax_OfficeCompanyCode, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxAvaTax_OfficeCompanyCode.ResumeLayout(False)
            CType(Me.GroupBoxAvaTax_AddressValidation, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxAvaTax_AddressValidation.ResumeLayout(False)
            Me.TabControlPanelMediaTab_Media.ResumeLayout(False)
            CType(Me.GroupBoxMediaAndProduction_Media, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxMediaAndProduction_Media.ResumeLayout(False)
            CType(Me.GroupBoxMediaAndProduction_MediaApprovalAlert, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxMediaAndProduction_MediaApprovalAlert.ResumeLayout(False)
            CType(Me.GroupBoxMediaAndProduction_APMediaImportOptions, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxMediaAndProduction_APMediaImportOptions.ResumeLayout(False)
            CType(Me.GroupBoxMedia_APPromptsOptions, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxMedia_APPromptsOptions.ResumeLayout(False)
            CType(Me.NumericInputAPPromptsOptions_InternetMediaPercentOver.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputAPPromptsOptions_PrintMediaPercentOver.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputAPPromptsOptions_RadioMediaPercentOver.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputAPPromptsOptions_TelevisionMediaPercentOver.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GroupBoxMediaAndProduction_Production, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxMediaAndProduction_Production.ResumeLayout(False)
            Me.TabControlPanelImportTab_Import.ResumeLayout(False)
            Me.TabControlPanelCheckWritingTab_CheckWriting.ResumeLayout(False)
            CType(Me.GroupBoxCheckWriting_CheckFormatSettings, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxCheckWriting_CheckFormatSettings.ResumeLayout(False)
            CType(Me.SearchableComboBoxCheckFormatSettings_APComputerCheckFormat.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GroupBoxCheckFormatSettings_CheckCurrency, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxCheckFormatSettings_CheckCurrency.ResumeLayout(False)
            Me.TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable.ResumeLayout(False)
            CType(Me.GroupBoxBillingAndAccountsReceivable_InvoiceTaxing, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxBillingAndAccountsReceivable_InvoiceTaxing.ResumeLayout(False)
            CType(Me.GroupBoxBillingAndAccountsReceivable_ClientCashReceipts, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxBillingAndAccountsReceivable_ClientCashReceipts.ResumeLayout(False)
            CType(Me.SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView10, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GroupBoxBillingAndAccountsReceivable_Billing, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxBillingAndAccountsReceivable_Billing.ResumeLayout(False)
            CType(Me.GroupBoxBilling_CustomInvoiceFormats, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxBilling_CustomInvoiceFormats.ResumeLayout(False)
            CType(Me.SearchableComboBoxCustomInvoiceFormats_Internet.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxCustomInvoiceFormats_OutOfHome.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxCustomInvoiceFormats_Magazine.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxCustomInvoiceFormats_Newspaper.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxCustomInvoiceFormats_Radio.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxCustomInvoiceFormats_Television.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxCustomInvoiceFormats_Production.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlPanelGLTab_GL.ResumeLayout(False)
            Me.TabControlPanelCurrencyTab_Currency.ResumeLayout(False)
            CType(Me.PictureEditCurrency_Image.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxCurrency_HomeCurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView9, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlPanelProductionOptionsTab_ProductionOptions.ResumeLayout(False)
            CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.GroupBoxProductionOptions_PurchaseOrdersOptions, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxProductionOptions_PurchaseOrdersOptions.ResumeLayout(False)
            CType(Me.SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GroupBoxProductionOptions_EstimateOptions, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxProductionOptions_EstimateOptions.ResumeLayout(False)
            CType(Me.GroupBoxProductionOptions_EstimateProcessingExceedOptions, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxProductionOptions_EstimateProcessingExceedOptions.ResumeLayout(False)
            CType(Me.GroupBoxProductionOptions_EstimateDefaultComments, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxProductionOptions_EstimateDefaultComments.ResumeLayout(False)
            CType(Me.GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments.ResumeLayout(False)
            CType(Me.GroupBoxProductionOptions_JobJacketOptions, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxProductionOptions_JobJacketOptions.ResumeLayout(False)
            Me.TabControlPanelRequiredFieldsTab_RequiredFields.ResumeLayout(False)
            CType(Me.GroupBoxRequiredFields_UserSelectedRequiredFields, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxRequiredFields_UserSelectedRequiredFields.ResumeLayout(False)
            Me.TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields.ResumeLayout(False)
            Me.PanelUserSelectedRequiredFields_RightColumn.ResumeLayout(False)
            Me.PanelUserSelectedRequiredFields_MiddleColumn.ResumeLayout(False)
            Me.PanelUserSelectedRequiredFields_LeftColumn.ResumeLayout(False)
            CType(Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxUserSelectedRequiredFields_JobsAndMedia.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.GroupBoxOptions_EmailingDocuments, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxOptions_EmailingDocuments.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlForm_AgencySetup As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelSystemAndAlertOptionsTab_SystemAndAlertOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents GroupBoxSystemAndAlertOptions_POP3EmailListenerSettings As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonControlPOP3EmailListenerSettings_NoSecureProtocol As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TextBoxPOP3EmailListenerSettings_ServerAddress As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents RadioButtonControlPOP3EmailListenerSettings_UseTLS As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlPOP3EmailListenerSettings_UseSSL As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelPOP3EmailListenerSettings_ServerAddress As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPOP3EmailListenerSettings_PortNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPOP3EmailListenerSettings_AuthenticationMethod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxSystemAndAlertOptions_SMTPEmailSetup As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxSMTPEmailSetup_ReplyToAddress As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxSMTPEmailSetup_DefaultPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxSMTPEmailSetup_DefaultUserName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxSMTPEmailSetup_SenderAddress As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents RadioButtonControlSMTPEmailSetup_NoSecureProtocol As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TextBoxSMTPEmailSetup_OutgoingServerAddress As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents RadioButtonControlSMTPEmailSetup_UseTLS As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelSMTPEmailSetup_ReplyToAddress As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSMTPEmailSetup_DefaultSenderPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonControlSMTPEmailSetup_UseSSL As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelSMTPEmailSetup_DefaultUserName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSMTPEmailSetup_SenderAddress As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSMTPEmailSetup_OutgoingServerAddress As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSMTPEmailSetup_PortNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSMTPEmailSetup_AuthenticationMethod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxSystemAndAlertOptions_AccessReportTemporaryFolder As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxAccessReportTemporaryFolder_Path As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents RadioButtonControlAccessReportTemporaryFolder_WorkstationOnly As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAccessReportTemporaryFolder_UseGlobal As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxSystemAndAlertOptions_AccessReportSourceFolder As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxAccessReportSourceFolder_Path As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents RadioButtonControlAccessReportSourceFolder_WorkstationOnly As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlAccessReportSourceFolder_UseGlobal As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxSystemAndAlertOptions_WebvantageURL As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxWebvantageURL_URL As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents RadioButtonControlWebvantageURL_WorkstationOnly As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlWebvantageURL_UseGlobal As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxAlertOptions_EnableAlertNotification As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAlertOptions_ExcludeAttachmentByDefault As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAlertOptions_IncludeAttachmentsWithAlerts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAlertOptions_IncludeAlertGroupsInPromptWindow As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAlertOptions_ActivateSystemGeneratedAlerts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabItemAgencySetup_SystemAndAlertOptions As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelInformationTab_Information As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAgencySetup_InformationTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents CheckBoxSMTPEmailSetup_EnablePDFAttachments As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSMTPEmailSetup_UseEmployeeSMTPLogin As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlPanelProductionOptionsTab_ProductionOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAgencySetup_ProductionOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TextBoxAgencyInformation_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelAgencyInformation_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxProductionOptions_EstimateProcessingExceedOptions As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents DataGridViewEstimateProcessingExceedOptions_Options As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents GroupBoxProductionOptions_EstimateDefaultComments As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxEstimateDefaultComments_Comments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents GroupBoxProductionOptions_PurchaseOrderDefaultFooterComments As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelPurchaseOrderDefaultFooterComments_Notes As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxPurchaseOrderDefaultFooterComments_Comments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents GroupBoxProductionOptions_JobJacketOptions As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxPurchaseOrdersOptions_EnablePurchaseOrderAlertGroup As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxPurchaseOrdersOptions_PurchaseOrderAmountRequired As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxTimesheetOptions_AllowDrillDownTimesheet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxEstimateOptions_QuoteApprovalPasswordRequired As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxEstimateOptions_NewRevisionsRequired As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxJobJacketOptions_HideNonBillableFlag As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxJobJacketOptions_AllowRequiredEstimateOverride As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxEstimateOptions_ApprovedEstimateRequired As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxJobJacketOptions_EnableFileAttachmentDialog As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxJobJacketOptions_EnableFileAttachments As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxJobJacketOptions_MarkJobComponentAsTaxable As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlPanelAccountingOptionsTab_AccountingOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents GroupBoxCheckWriting_CheckFormatSettings As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelCheckFormatSettings_AdjustCheckBodyLinesDown As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxCheckFormatSettings_CheckCurrency As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxCheckCurrency_CoinText As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxCheckCurrency_CurrencyText As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelCheckCurrency_CoinText As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCheckCurrency_CurrencyText As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCheckCurrency_Symbol As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxCheckFormatSettings_CheckAmountInWords As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelCheckFormatSettings_AdjustCheckStubLinesUp As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCheckFormatSettings_APComputerCheckFormat As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxBilling_CustomInvoiceFormats As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelCustomInvoiceFormats_Internet As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCustomInvoiceFormats_OutOfHome As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCustomInvoiceFormats_Magazine As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCustomInvoiceFormats_Newspaper As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCustomInvoiceFormats_Radio As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCustomInvoiceFormats_Television As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCustomInvoiceFormats_Production As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrency_HomeCurrency As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxCurrency_ActivateMultipleCurrencies As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMedia_ActivateApprovals As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxBilling_RequireProductSetupComplete As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxClientCashReceipts_EnablePartialPaymentDistribution As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsPayableHeader_DisplayPayToInformation As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxCheckWriting_PrintVendorAccountNumberOnChecks As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsPayableHeader_AllowDefaultAPGLAccountToBeModified As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsPayableHeader_FlagIndividualVendorAPAs1099 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsPayableDisbursement_CreateInterCompanyTransactions As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsPayableDisbursement_LimitAPTransactionsByOfficeCode As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxProduction_ValidateClosedArchivedJobs As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsPayableHeader_ViewDeletedInvoicesInAP As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabItemAgencySetup_AccountingOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TextBoxAccountsPayableDisbursement_RejectAPEntry As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxAccountsPayableDisbursement_RejectAPEntry As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxAccountsPayableDisbursement_PopupMessageInAP As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxAccountsPayableDisbursement_PopupMessageInAP As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlPanelTimesheetOptionsTab_TimesheetOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAgencySetup_TimesheetOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents GroupBoxTimesheetOptions_MissingTimeOptions As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxMissingTimeOptions_ITEMail As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelMissingTimeOptions_ITEMail As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMissingTimeOptions_ReportMissingTime As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxTimesheetOptions_TimesheetOptions As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxTimesheetOptions_AutoAlertSupervisor As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxTimesheetOptions_SupervisiorCanEditTime As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxTimesheetOptions_SupervisorApprovalActive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxTimesheetOptions_RequireTimeComments As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxTimesheetOptions_CheckClosedPostingPeriods As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxTimesheetOptions_UseCopyTimesheet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxTimesheetOptions_UseBatchMethod As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlPanelMediaOptionsTab_MediaOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAgencySetup_MediaOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelRequiredFieldsTab_RequiredFields As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAgencySetup_RequiredFieldsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TextBoxInternet_FooterComments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxOutOfHome_FooterComments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxTelevision_FooterComments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxRadio_FooterComments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxMagazine_FooterComments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents GroupBoxRequiredFields_UserSelectedRequiredFields As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxMiddleColumn_ServiceFeeType As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxUserSelectedRequiredFields_JobsAndMedia As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxJobsAndMedia_FiscalPeriod As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxJobsAndMedia_Campaign As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_Blackplate2 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobComponentCustom5 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobComponentCustom4 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobComponentCustom3 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobComponentCustom2 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobComponentCustom1 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobLogCustom5 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobLogCustom4 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobLogCustom3 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobLogCustom2 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxRightColumn_JobLogCustom1 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_Blackplate1 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_Budget As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMiddleColumn_Contact As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMiddleColumn_Format As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_DateOpened As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_ClientReference As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_AdNumber As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_CoopBilling As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_AlertGroup As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMiddleColumn_Market As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMiddleColumn_DeptTeam As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMiddleColumn_SalesClassFormat As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_Complexity As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMiddleColumn_DueDate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMiddleColumn_Promotion As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxMiddleColumn_JobType As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLeftColumn_AccountNumber As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSettings_UseAPAccountOnImport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSettings_RenameFinanceFile As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxSettings_ImportPath As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxSettings_StrataConnectPath As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSettings_MediaImportDefault As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_ImportPath As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_StrataConnectPath As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxSettings_MediaImportDefault As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TextBoxNewspaper_FooterComments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputSMTPEmailSetup_PortNumber As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputPOP3EmailListenerSettings_PortNumber As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelImportSettings_CurrencyRateImportFileType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelImportSettings_IncomeOnlyImportFileType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxAgencyInformation_Phone As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelAgencyInformation_Phone As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxImportSettings_CurrencyRateImportFileType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxImportSettings_IncomeOnlyImportFileType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxTimesheetOptions_DefaultDisplayDays As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelTimesheetOptions_DefaultDisplayDays As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelCheckCurrency_Note As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxInformation_AgencyInformation As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents AddressControlAgencyInformation_Address As AdvantageFramework.WinForm.Presentation.Controls.AddressControl
        Friend WithEvents ComboBoxPOP3EmailListenerSettings_AuthenticationMethod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxSMTPEmailSetup_AuthenticationMethod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TableLayoutPanelUserSelectedRequiredFields_UserSelectedRequiredFields As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelUserSelectedRequiredFields_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelUserSelectedRequiredFields_MiddleColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelUserSelectedRequiredFields_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents ComboBoxCheckCurrecny_CurrencySymbols As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents RadioButtonMissingTimeOptions_ByWeek As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonMissingTimeOptions_ByDay As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxMissingTimeOptions_NotifySupervisor As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelAccountingOptions_CheckWritingInProgress As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RibbonBarOptions_Text As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemText_CheckSpelling As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents GroupBoxAccountingOptions_AccountsPayableDisbursement As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxAccountsPayableDisbursement_AllowEntryCostOfSales As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxAccountingOptions_AccountsPayableHeader As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TabControlAccountingOptions_AccountingOptions As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelAccountsPayableTab_AccountsPayable As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAccountingOptions_AccountsPayableTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelBillingAndAccountsReceivableTab_BillingAndAccountsReceivable As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAccountingOptions_BillingAndAccountsReceivableTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlMediaOptions_MediaOptions As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelSettingsTab_Settings As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemMediaOptions_SettingsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelFooterCommentsTab_FooterComments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabControlFooterComments_FooterComments As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelNewspaperTab_Newspaper As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemFooterComments_NewspaperTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMagazineTab_Magazine As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemFooterComments_MagazineTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelOutOfHomeTab_OutOfHome As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemFooterComments_OutOfHomeTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelInternetTab_Internet As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemFooterComments_InternetTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelRadioTab_Radio As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemFooterComments_RadioTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelTelevisionTab_Television As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemFooterComments_TelevisionTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabItemMediaOptions_FooterCommentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCheckWritingTab_CheckWriting As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAccountingOptions_CheckWritingTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMediaTab_Media As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAccountingOptions_MediaTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCurrencyTab_Currency As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAccountingOptions_CurrencyTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents GroupBoxMediaAndProduction_Media As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxMediaAndProduction_Production As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxBillingAndAccountsReceivable_Billing As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxBillingAndAccountsReceivable_ClientCashReceipts As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TabControlPanelImportTab_Import As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAccountingOptions_ImportTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlSystemAndAlertOptions_SystemAndAlertOptions As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelOptionsTab_Options As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemSystemAndAlertOptions_OptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelEmailSettingsTab_EmailSettings As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemSystemAndAlertOptions_EmailSettingsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents GroupBoxOptions_AlertOptions As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TabControlPanelGLTab_GL As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CheckBoxGL_UseFilter As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabItemAccountingOptions_GLTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents CheckBoxJobJacketOptions_AllowOfficeCodeOverride As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxMedia_APPromptsOptions As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents NumericInputAPPromptsOptions_InternetMediaPercentOver As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelAPPromptsOptions_Note As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputAPPromptsOptions_OutOfHomeMediaPercentOver As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputAPPromptsOptions_PrintMediaPercentOver As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputAPPromptsOptions_RadioMediaPercentOver As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelAPPromptsOptions_RadioMediaPercentOver As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputAPPromptsOptions_TelevisionMediaPercentOver As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelAPPromptsOptions_OutOfHomeMediaPercentOver As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelAPPromptsOptions_InternetMediaPercentOver As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelAPPromptsOptions_PrintMediaPercentOver As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelAPPromptsOptions_TelevisionMediaPercentOver As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxBillingAndAccountsReceivable_InvoiceTaxing As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxInvoiceTaxing_ApplyTaxUponBilling As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxOptions_EmailAttachments As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents NumericInputEmailAttachments_MaxFileSize As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelEmailAttachments_MaxFileSize As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxProductionOptions_EstimateOptions As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxProductionOptions_PurchaseOrdersOptions As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxAccountsPayableDisbursement_AllowOrderNotMatchingVendor As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelImportSettings_DefaultInvoiceDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxImportSettings_DefaultInvoiceDescription As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents GroupBoxSettings_ExportMediaOrder As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxExportMediaOrders_MediaPlanPath As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxExportMediaOrders_APPath As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelExportMediaOrders_APPath As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelExportMediaOrders_MediaPlanPath As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxClientCashReceipts_PartialPaymentDistributionRequired As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsPayableHeader_VendorServiceTaxEnabled As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAccountingOptions_AvaTaxTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents GroupBoxAvaTax_AddressValidation As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxAvaTaxAddressValidation_Enabled As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAvaTax_EnableAvaTaxCalculation As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ButtonAvaTax_TestConnection As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TextBoxAvaTax_URL As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelAvaTax_URL As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelAvaTax_AccountNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxAvaTax_AccountNumber As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxAvaTax_LicenseKey As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelAvaTax_LicenseKey As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewAvaTaxAddressValidation_Countries As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TextBoxImportSettings_CSIClearedChecksImportPath As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelImportSettings_CSIClearedChecksImportPath As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxAvaTax_OfficeCompanyCode As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents DataGridViewAvaTaxOfficeCompanyCode_Mappings As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents CheckBoxJobJacketOptions_AllowCDPOverride As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsPayableHeader_DefaultVendorAccountNumberInAPDescription As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents SearchableComboBoxPurchaseOrdersOptions_DefaultAlertGroup As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBox1View As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxCheckFormatSettings_APComputerCheckFormat As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxCustomInvoiceFormats_Production As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxCustomInvoiceFormats_Television As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView3 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxCustomInvoiceFormats_Radio As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView4 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxCustomInvoiceFormats_Newspaper As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView5 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxCustomInvoiceFormats_Magazine As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView6 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxCustomInvoiceFormats_OutOfHome As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView7 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxCustomInvoiceFormats_Internet As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView8 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxCurrency_HomeCurrency As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView9 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents ButtonItemActions_Refresh As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents SearchableComboBoxClientCashReceipts_DefaultWriteoffAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView10 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelClientCashReceipts_DefaultWriteoffAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSMTPEmailSetup_OAuth2 As WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlPanelSettingsForWebFormTermsTab_SettingsForWebFormTerms As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TextBoxSettingsForWebFormTerms_WebFormTerms As WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemMediaOptions_SettingsForWebFormTermsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TextBoxCurrency_APIKey As WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelCurrency_APIKey As WinForm.Presentation.Controls.Label
        Friend WithEvents PictureEditCurrency_Image As DevExpress.XtraEditors.PictureEdit
        Friend WithEvents ButtonCurrency_TestConnection As WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxTimesheetOptions_AllowCopyHours As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxMediaPlanning_DefaultGroupingTypeInternet As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelMediaPlanning_DefaultGroupingTypeInternet As WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxSettings_MediaPlanning As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelMediaPlanning_DefaultGroupingType As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaPlanning_DefaultGroupingTypeTV As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxMediaPlanning_DefaultGroupingTypeTV As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelMediaPlanning_DefaultGroupingTypeRadio As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxMediaPlanning_DefaultGroupingTypeRadio As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelMediaPlanning_DefaultGroupingTypeOutOfHome As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxMediaPlanning_DefaultGroupingTypeOutOfHome As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelMediaPlanning_DefaultGroupingTypeNewspaper As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxMediaPlanning_DefaultGroupingTypeNewspaper As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelMediaPlanning_DefaultGroupingTypeMagazine As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxMediaPlanning_DefaultGroupingTypeMagazine As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents GroupBoxSystemAndAlertOptions_ClientPortalURL As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxClientPortalURL_URL As WinForm.Presentation.Controls.TextBox
        Friend WithEvents RadioButtonControlClientPortalURL_WorkstationOnly As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlClientPortalURL_UseGlobal As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabControlPanelAdServingTab_AdServing As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemMediaOptions_AdServing As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelAdServing_LeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableFields As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterAdServingFields_LeftRight As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelAdServing_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_AddToAdServingFields As WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_RemoveFromAdServingFields As WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_AdServingFields As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_AdServerFields As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemFields_MoveUp As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemFields_MoveDown As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewSystemAndAlertOptions_POP3EmailAccounts As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents GroupBoxMediaAndProduction_APMediaImportOptions As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxAPMediaImportOptions_PendingApprovalRadio As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAPMediaImportOptions_PendingApprovalTV As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAPMediaImportOptions_SetPaymentHoldIfPendingApproval As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAPMediaImportOptions_PendingApprovalInternet As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAPMediaImportOptions_PendingApprovalOutOfHome As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAPMediaImportOptions_PendingApprovalPrintMedia As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelAPMediaImportOptions_AlwaysSetToPendingApproval As WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxAccountingOptions_AccountsPayableApprovalAlert As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState As WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView12 As WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelAccountsPayableApprovalAlert_DefaultAPApprovalAssignmentState As WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate As WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView11 As WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertAssignmentTemplate As WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxMediaAndProduction_MediaApprovalAlert As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxMediaApprovalAlert_AlertBuyer As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlMediaApprovalAlert_AlertDefaultAPAlertGroup As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlMediaApprovalAlert_AlertAPUser As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxMediaApprovalAlert_AlertAP As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup As WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxAccountsPayableApprovalAlert_DefaultAPApprovalAlertGroup As WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView13 As WinForm.Presentation.Controls.GridView
        Friend WithEvents CheckBoxMedia_AutomaticallyRemovePaymentHold As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAvaTax_UseJobSalesClass As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxAvatax_AddressOptions As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonAddressOption_JobContactAddress As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonAddressOption_ClientAddress As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxTimesheetOptions_UniqueRowWhenCommentsIncluded As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DataGridViewSystemAndAlertOptions_POP3AutomatedAssignmentAccounts As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_AutomatedAssignments As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemAutomatedAssignments_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAutomatedAssignments_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents CheckBoxMediaPlanning_AddLinesToExistingOrder As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSettings_MediaExcludeOrderPDFWithEmail As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBox1 As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxAllowProofHQ As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxSettings_MediaOrders As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxMediaGeneral_MediaRequireCampaign As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxSettings_MediaGeneral As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelMediaOrders_BroadcastWorksheetDefaultRateType As WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonMediaOrders_Net As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonMediaOrders_Gross As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxMediaOrders_UseVendorsRateType As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DateTimePickerSettings_MediaTrafficStartDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelSettings_MediaTrafficStartDate As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaOrders_Country As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxMediaOrders_Country As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents GroupBoxMediaOptions_BroadcastWorksheet As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxSystemAndAlertOptions_DotNetFolder As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxDotNetFolder_Path As WinForm.Presentation.Controls.TextBox
        Friend WithEvents RadioButtonControlDotNetFolder_WorkstationOnly As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlDotNetFolder_UseGlobal As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RibbonBarOptions_Email As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemEmail_TestSending As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEmail_TestReceiving As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents GroupBoxSystemAndAlertOptions_ProofingURL As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxProofingURL_URL As WinForm.Presentation.Controls.TextBox
        Friend WithEvents RadioButtonControlProofingURL_WorkstationOnly As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlProofingURL_UseGlobal As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxMediaGeneral_MediaAutoBuyer As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAlertOptions_CommentsFirstOnEmails As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxOptions_EmailingDocuments As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxEmailingDocuments_SendFilesAsOneTimeLink As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace

