Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class EmployeeControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeControl))
            Me.TabControlControl_EmployeeDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelAlertsTab_Alerts = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelAlerts_Alerts = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabControlAlerts_Alerts = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelConceptShareTab_ConceptShare = New DevComponents.DotNetBar.TabControlPanel()
            Me.ButtonConceptShare_RemoveUser = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxConceptShare_ShowPassword = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxConceptShare_IsActive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ButtonConceptShare_UpdateUser = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonConceptShare_CreateUser = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TextBoxConceptShare_Password = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelConceptShare_Password = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemAlerts_ConceptShareTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSettingsTab_Settings = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxSettings_IgnoreCalendarSync = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxSettings_VCCPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxSettings_VCCUserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSettings_VCCPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_VCCUserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_VCC = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxSettings_AdobeSignatureFile = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSettings_AdobeSignature = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonSettings_AdobeSignatureFileDelete = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonSettings_AdobeSignatureFileSelect = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TextBoxSettings_AdobeSignatureFilePassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSettings_AdobeSignatureFilePassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_AdobeSignatureFile = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxSettings_IsAPIUser = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxSettings_ProofHQPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxSettings_ProofHQUserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSettings_ProofHQPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_ProofHQUserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_ProofHQ = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxSettings_SugarCRMPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxSettings_SugarCRMUserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSettings_SugarCRMPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_SugarCRMUserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_SugarCRM = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxSettingsRightColumn_EmailPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxSettingsRightColumn_EmailUserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxSettingsRightColumn_ReplyToAddress = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxSettingsRightColumn_EmailAddress = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSettingsRightColumn_EmailPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettingsRightColumn_EmailUsername = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettingsRightColumn_ReplyToAddress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelSettingsRightColumn_EmailAddress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemAlerts_SettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAdditionalEmails_AdditionalEmails = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewAdditionalEmails_AdditionalEmails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemAlerts_AdditionalEmailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAlertGroupsTab_AlertGroups = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelAlertGroups_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_RemoveAlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddAlertGroup = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_EmployeeAlertGroups = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlAlertGroups_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelAlertGroups_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AvailableAlertGroups = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemAlerts_AlertGroupsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel_CalendarTime = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxForm_SSL = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxCalendarTime_Port = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.Label3 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxCalendarTime_Host = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.Label2 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxCalendarTime_Type = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.Label1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxCalendarTime_EmailPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxCalendarTime_EmailUserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxCalendarTime_EmailAddress = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.Label13 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Label14 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Label16 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemAlerts_CalendarTimeTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemEmployeeDetails_AlertsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelGeneralInformation_GeneralInformation = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelGeneralInformation_GeneralInformation = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.SearchableComboBoxGeneralInformation_AssignedOffice = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGeneralInformation_Title = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView4 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.CheckBoxGeneralInformation_ActiveFreelance = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelGeneralInformation_AssignedOffice = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInformation_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabControlGeneralInformation_EmployeeGeneralInformation = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelInformationTab_Information = New DevComponents.DotNetBar.TabControlPanel()
            Me.TableLayoutPanelInformation_Information = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelInformation_BottomColumn = New System.Windows.Forms.Panel()
            Me.TableLayoutPanelBottomColumn_Information = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelInformation_BottomRightColumn = New System.Windows.Forms.Panel()
            Me.ButtonPayToNameAndAddress_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemRefresh_Home = New DevComponents.DotNetBar.ButtonItem()
            Me.AddressControlInformationBottomRightColumn_MailingAddress = New AdvantageFramework.WinForm.Presentation.Controls.AddressControl()
            Me.PanelInformation_BottomLeftColumn = New System.Windows.Forms.Panel()
            Me.AddressControlInformationBottomLeftColumn_HomeAddress = New AdvantageFramework.WinForm.Presentation.Controls.AddressControl()
            Me.PanelInformation_TopRightColumn = New System.Windows.Forms.Panel()
            Me.PictureBoxInformationTopRightColumn_EmployeeSignature = New System.Windows.Forms.PictureBox()
            Me.TextBoxInformation_EmployeeSignature = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelInformationTopRightColumn_MaxSize = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelInformationTopRightColumn_ImageDimensions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelInformationTopRightColumn_EmployeeSignature = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonInformationTopRightColumn_DeleteSignatureImage = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonInformationTopRightColumn_SelectSignatureImage = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelInformationTopRightColumn_SignatureNotes = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelInformation_TopLeftColumn = New System.Windows.Forms.Panel()
            Me.LabelInformationTopLeftColumn_PhoneNumbers = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelInformationTopLeftColumn_Home = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxInformationTopLeftColumn_AlternatePhone = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelInformationTopLeftColumn_WorkExt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxInformationTopLeftColumn_CellPhone = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxInformationTopLeftColumn_WorkPhone = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxInformationTopLeftColumn_HomePhone = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelInformationTopLeftColumn_AlternatePhone = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelInformationTopLeftColumn_Cell = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelInformationTopLeftColumn_Work = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemEmployeeGeneralInformation_InformationTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlDepartmentTeamTab_DepartmentTeam = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelDepartmentTeam_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_RemoveDepartmentTeam = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddDepartmentTeam = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TextBoxRightSection_DefaultDepartmentTeam = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.DataGridViewRightSection_EmployeeDepartmentTeams = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelDepartmentTeam_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AvailableDepartmentTeam = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemEmployeeGeneralInformation_DepartmentTeamTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelRolesTab_Roles = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelRoles_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TextBoxRightSection_DefaultRole = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ButtonRightSection_RemoveRole = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddRole = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_EmployeeRoles = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlRoles_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelRoles_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AvailableRoles = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemEmployeeGeneralInformation_RolesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TextBoxGeneralInformation_AccountNumber = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxGeneralInformation_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxGeneralInformation_LastName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelGeneralInformation_FirstName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInformation_AccountNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInformation_MiddleInitial = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInformation_LastName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneralInformation_Title = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxGeneralInformation_Freelance = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxGeneralInformation_FirstName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxGeneralInformation_MiddleInitial = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemEmployeeDetails_GeneralInformation = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelTimeTrackingTab_TimeTracking = New DevComponents.DotNetBar.TabControlPanel()
            Me.NumericInputTimeTracking_BillableHoursGoal = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelTimeTracking_BillableHoursGoal = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SearchableComboBoxTimeTracking_DefaultFunction = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView3 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxTimeTracking_Supervisor = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.NumericInputTimeTracking_SeniorityPriority = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTimeTracking_DirectHoursGoal = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTimeTracking_StandardAnnualHours = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelTimeTracking_StandardAnnualHours = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTimeTracking_DirectHoursGoal = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTimeTracking_MonthlyBillableHoursGoal = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTimeTracking_HoursGoals = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxTimeTracking_ReportMissingTime = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.RadioButtonControlTimeTracking_EmployeeStatusNonExempt = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlTimeTracking_EmployeeStatusExempt = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlTimeTracking_EmployeeStatusNA = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTimeTracking_DefaultFunction = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTimeTracking_ReportMissingTimeLbl = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTimeTracking_SeniorityPriority = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTimeTracking_VacationSickPersonalTime = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewTimeTracking_EmployeeTimeOff = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelTimeTracking_EmployeeStatus = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTimeTracking_StandardWorkDays = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewTimeTracking_WorkDays = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelTimeTracking_Supervisor = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemEmployeeDetails_TimeTrackingTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports = New DevComponents.DotNetBar.TabControlPanel()
            Me.NumericInputPOsAndExpenseReports_POAmountLimit = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView8 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView7 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView6 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView5 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelPOsAndExpenseReports_POApprovalRule = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPOsAndExpenseReports_POAmountLimit = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPOsAndExpenseReports_PurchaseOrders = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPOsAndExpenseReports_CreditCardDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPOsAndExpenseReports_CreditCardGLAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPOsAndExpenseReports_AlternateApprover = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPOsAndExpenseReports_VendorCodeCrossRef = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPOsAndExpenseReports_CreditCardNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemEmployeeDetails_POsAndExpenseReportsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation = New DevComponents.DotNetBar.TabControlPanel()
            Me.NumericInputHRAndRateInformation_CostRate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputHRAndRateInformation_BillRate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputHRAndRateInformation_MonthlySalary = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputHRAndRateInformation_AnnualSalary = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelHRAndRateInformation_BillRate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHRAndRateInformation_CostRate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHRAndRateInformation_HourlyBillCostData = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxHRAndRateInformation_OtherInfo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelHRAndRateInformation_OtherInfo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHRAndRateInformation_OtherInfoHeader = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHRAndRateInformation_BillingRates = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHRAndRateInformation_SalaryInformation = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RateFlagEntryControlHRAndRateInformation_BillingRateDetails = New AdvantageFramework.WinForm.Presentation.Controls.RateFlagEntryControl()
            Me.LabelHRAndRateInformation_AnnualSalary = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHRAndRateInformation_MonthlySalary = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerHRAndRateInformation_TerminationDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerHRAndRateInformation_NextReviewDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerHRAndRateInformation_BirthDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerHRAndRateInformation_EmploymentDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelHRAndRateInformation_TerminationDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHRAndRateInformation_NextReviewDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHRAndRateInformation_DateOfLastIncrease = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHRAndRateInformation_BirthDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHRAndRateInformation_EmploymentDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHRAndRateInformation_EmployeeDates = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemEmployeeDetails_HRAndRateInformationTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords = New DevComponents.DotNetBar.TabControlPanel()
            Me.SearchableComboBoxSecurityAndPasswords_User = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView9 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelSecurityAndPasswords_User = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelSecurityGroupTab_SecurityGroup = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelSecurityGroup_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_RemoveSecurityGroup = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddSecurityGroup = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_EmployeeSecurityGroups = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlSecurityGroup_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelSecurityGroup_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AvailableSecurityGroups = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemSecurityAndPasswords_SecurityGroupTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits = New DevComponents.DotNetBar.TabControlPanel()
            Me.UserEmployeeLimitControlEmployeeLimits_EmployeeLimits = New AdvantageFramework.WinForm.Presentation.Controls.UserEmployeeLimitControl()
            Me.TabItemSecurityAndPasswords_EmployeeLimitsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits = New DevComponents.DotNetBar.TabControlPanel()
            Me.EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits = New AdvantageFramework.WinForm.Presentation.Controls.EmployeeOfficeLimitControl()
            Me.TabItemSecurityAndPasswords_EmployeeOfficeLimitsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCDPLimitsTab_CDPLimits = New DevComponents.DotNetBar.TabControlPanel()
            Me.UserCDPLimitControlCDPLimits_CDPLimits = New AdvantageFramework.WinForm.Presentation.Controls.UserCDPLimitControl()
            Me.TabItemSecurityAndPasswords_CDPLimitsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits = New DevComponents.DotNetBar.TabControlPanel()
            Me.EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunctionLimits = New AdvantageFramework.WinForm.Presentation.Controls.EmployeeTimesheetFunctionLimitsControl()
            Me.TabItemSecurityAndPasswords_EmployeeTSFunctionLimitsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabItemEmployeeDetails_SecurityAndPasswords = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelNotesTab_Notes = New DevComponents.DotNetBar.TabControlPanel()
            Me.ButtonNotes_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TextBoxNotes_Notes = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemEmployeeDetails_NotesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDocumentsTab_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlDocuments_EmployeeDocuments = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemEmployeeDetails_DocumentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlControl_EmployeeDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_EmployeeDetails.SuspendLayout()
            Me.TabControlPanelAlertsTab_Alerts.SuspendLayout()
            CType(Me.PanelAlerts_Alerts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelAlerts_Alerts.SuspendLayout()
            CType(Me.TabControlAlerts_Alerts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlAlerts_Alerts.SuspendLayout()
            Me.TabControlPanelConceptShareTab_ConceptShare.SuspendLayout()
            Me.TabControlPanelSettingsTab_Settings.SuspendLayout()
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.SuspendLayout()
            Me.TabControlPanelAlertGroupsTab_AlertGroups.SuspendLayout()
            CType(Me.PanelAlertGroups_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelAlertGroups_RightSection.SuspendLayout()
            CType(Me.PanelAlertGroups_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelAlertGroups_LeftSection.SuspendLayout()
            Me.TabControlPanel_CalendarTime.SuspendLayout()
            Me.TabControlPanelGeneralInformation_GeneralInformation.SuspendLayout()
            CType(Me.PanelGeneralInformation_GeneralInformation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelGeneralInformation_GeneralInformation.SuspendLayout()
            CType(Me.SearchableComboBoxGeneralInformation_AssignedOffice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneralInformation_Title.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlGeneralInformation_EmployeeGeneralInformation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.SuspendLayout()
            Me.TabControlPanelInformationTab_Information.SuspendLayout()
            Me.TableLayoutPanelInformation_Information.SuspendLayout()
            Me.PanelInformation_BottomColumn.SuspendLayout()
            Me.TableLayoutPanelBottomColumn_Information.SuspendLayout()
            Me.PanelInformation_BottomRightColumn.SuspendLayout()
            Me.PanelInformation_BottomLeftColumn.SuspendLayout()
            Me.PanelInformation_TopRightColumn.SuspendLayout()
            CType(Me.PictureBoxInformationTopRightColumn_EmployeeSignature, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelInformation_TopLeftColumn.SuspendLayout()
            Me.TabControlDepartmentTeamTab_DepartmentTeam.SuspendLayout()
            CType(Me.PanelDepartmentTeam_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelDepartmentTeam_RightSection.SuspendLayout()
            CType(Me.PanelDepartmentTeam_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelDepartmentTeam_LeftSection.SuspendLayout()
            Me.TabControlPanelRolesTab_Roles.SuspendLayout()
            CType(Me.PanelRoles_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelRoles_RightSection.SuspendLayout()
            CType(Me.PanelRoles_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelRoles_LeftSection.SuspendLayout()
            Me.TabControlPanelTimeTrackingTab_TimeTracking.SuspendLayout()
            CType(Me.NumericInputTimeTracking_BillableHoursGoal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTimeTracking_DefaultFunction.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxTimeTracking_Supervisor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTimeTracking_SeniorityPriority.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTimeTracking_DirectHoursGoal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputTimeTracking_StandardAnnualHours.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.SuspendLayout()
            CType(Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.SuspendLayout()
            CType(Me.NumericInputHRAndRateInformation_CostRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputHRAndRateInformation_BillRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputHRAndRateInformation_MonthlySalary.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputHRAndRateInformation_AnnualSalary.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerHRAndRateInformation_TerminationDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerHRAndRateInformation_NextReviewDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerHRAndRateInformation_BirthDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerHRAndRateInformation_EmploymentDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.SuspendLayout()
            CType(Me.SearchableComboBoxSecurityAndPasswords_User.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView9, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlSecurityAndPasswords_SecurityAndPasswords, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.SuspendLayout()
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.SuspendLayout()
            CType(Me.PanelSecurityGroup_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSecurityGroup_RightSection.SuspendLayout()
            CType(Me.PanelSecurityGroup_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelSecurityGroup_LeftSection.SuspendLayout()
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.SuspendLayout()
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.SuspendLayout()
            Me.TabControlPanelCDPLimitsTab_CDPLimits.SuspendLayout()
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.SuspendLayout()
            Me.TabControlPanelNotesTab_Notes.SuspendLayout()
            Me.TabControlPanelDocumentsTab_Documents.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControlControl_EmployeeDetails
            '
            Me.TabControlControl_EmployeeDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlControl_EmployeeDetails.CanReorderTabs = False
            Me.TabControlControl_EmployeeDetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlControl_EmployeeDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlControl_EmployeeDetails.Controls.Add(Me.TabControlPanelTimeTrackingTab_TimeTracking)
            Me.TabControlControl_EmployeeDetails.Controls.Add(Me.TabControlPanelGeneralInformation_GeneralInformation)
            Me.TabControlControl_EmployeeDetails.Controls.Add(Me.TabControlPanelAlertsTab_Alerts)
            Me.TabControlControl_EmployeeDetails.Controls.Add(Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports)
            Me.TabControlControl_EmployeeDetails.Controls.Add(Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation)
            Me.TabControlControl_EmployeeDetails.Controls.Add(Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords)
            Me.TabControlControl_EmployeeDetails.Controls.Add(Me.TabControlPanelNotesTab_Notes)
            Me.TabControlControl_EmployeeDetails.Controls.Add(Me.TabControlPanelDocumentsTab_Documents)
            Me.TabControlControl_EmployeeDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_EmployeeDetails.ForeColor = System.Drawing.Color.Black
            Me.TabControlControl_EmployeeDetails.Location = New System.Drawing.Point(0, 0)
            Me.TabControlControl_EmployeeDetails.Name = "TabControlControl_EmployeeDetails"
            Me.TabControlControl_EmployeeDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_EmployeeDetails.SelectedTabIndex = 0
            Me.TabControlControl_EmployeeDetails.Size = New System.Drawing.Size(738, 550)
            Me.TabControlControl_EmployeeDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_EmployeeDetails.TabIndex = 1
            Me.TabControlControl_EmployeeDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_EmployeeDetails.Tabs.Add(Me.TabItemEmployeeDetails_GeneralInformation)
            Me.TabControlControl_EmployeeDetails.Tabs.Add(Me.TabItemEmployeeDetails_TimeTrackingTab)
            Me.TabControlControl_EmployeeDetails.Tabs.Add(Me.TabItemEmployeeDetails_POsAndExpenseReportsTab)
            Me.TabControlControl_EmployeeDetails.Tabs.Add(Me.TabItemEmployeeDetails_HRAndRateInformationTab)
            Me.TabControlControl_EmployeeDetails.Tabs.Add(Me.TabItemEmployeeDetails_SecurityAndPasswords)
            Me.TabControlControl_EmployeeDetails.Tabs.Add(Me.TabItemEmployeeDetails_AlertsTab)
            Me.TabControlControl_EmployeeDetails.Tabs.Add(Me.TabItemEmployeeDetails_NotesTab)
            Me.TabControlControl_EmployeeDetails.Tabs.Add(Me.TabItemEmployeeDetails_DocumentsTab)
            Me.TabControlControl_EmployeeDetails.Text = "TabControl1"
            '
            'TabControlPanelAlertsTab_Alerts
            '
            Me.TabControlPanelAlertsTab_Alerts.Controls.Add(Me.PanelAlerts_Alerts)
            Me.TabControlPanelAlertsTab_Alerts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAlertsTab_Alerts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAlertsTab_Alerts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAlertsTab_Alerts.Name = "TabControlPanelAlertsTab_Alerts"
            Me.TabControlPanelAlertsTab_Alerts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAlertsTab_Alerts.Size = New System.Drawing.Size(738, 523)
            Me.TabControlPanelAlertsTab_Alerts.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAlertsTab_Alerts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAlertsTab_Alerts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAlertsTab_Alerts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAlertsTab_Alerts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAlertsTab_Alerts.Style.GradientAngle = 90
            Me.TabControlPanelAlertsTab_Alerts.TabIndex = 5
            Me.TabControlPanelAlertsTab_Alerts.TabItem = Me.TabItemEmployeeDetails_AlertsTab
            '
            'PanelAlerts_Alerts
            '
            Me.PanelAlerts_Alerts.Controls.Add(Me.TabControlAlerts_Alerts)
            Me.PanelAlerts_Alerts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelAlerts_Alerts.Location = New System.Drawing.Point(1, 1)
            Me.PanelAlerts_Alerts.Name = "PanelAlerts_Alerts"
            Me.PanelAlerts_Alerts.Size = New System.Drawing.Size(736, 521)
            Me.PanelAlerts_Alerts.TabIndex = 0
            '
            'TabControlAlerts_Alerts
            '
            Me.TabControlAlerts_Alerts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlAlerts_Alerts.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlAlerts_Alerts.CanReorderTabs = False
            Me.TabControlAlerts_Alerts.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlAlerts_Alerts.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlAlerts_Alerts.Controls.Add(Me.TabControlPanelSettingsTab_Settings)
            Me.TabControlAlerts_Alerts.Controls.Add(Me.TabControlPanelConceptShareTab_ConceptShare)
            Me.TabControlAlerts_Alerts.Controls.Add(Me.TabControlPanelAdditionalEmails_AdditionalEmails)
            Me.TabControlAlerts_Alerts.Controls.Add(Me.TabControlPanelAlertGroupsTab_AlertGroups)
            Me.TabControlAlerts_Alerts.Controls.Add(Me.TabControlPanel_CalendarTime)
            Me.TabControlAlerts_Alerts.Controls.Add(Me.TabControlPanel1)
            Me.TabControlAlerts_Alerts.ForeColor = System.Drawing.Color.Black
            Me.TabControlAlerts_Alerts.Location = New System.Drawing.Point(6, 6)
            Me.TabControlAlerts_Alerts.Name = "TabControlAlerts_Alerts"
            Me.TabControlAlerts_Alerts.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlAlerts_Alerts.SelectedTabIndex = 0
            Me.TabControlAlerts_Alerts.Size = New System.Drawing.Size(724, 510)
            Me.TabControlAlerts_Alerts.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlAlerts_Alerts.TabIndex = 0
            Me.TabControlAlerts_Alerts.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlAlerts_Alerts.Tabs.Add(Me.TabItemAlerts_SettingsTab)
            Me.TabControlAlerts_Alerts.Tabs.Add(Me.TabItemAlerts_AlertGroupsTab)
            Me.TabControlAlerts_Alerts.Tabs.Add(Me.TabItemAlerts_ConceptShareTab)
            Me.TabControlAlerts_Alerts.Tabs.Add(Me.TabItemAlerts_CalendarTimeTab)
            Me.TabControlAlerts_Alerts.Tabs.Add(Me.TabItemAlerts_AdditionalEmailsTab)
            Me.TabControlAlerts_Alerts.Text = "Tabcontrol"
            '
            'TabControlPanelConceptShareTab_ConceptShare
            '
            Me.TabControlPanelConceptShareTab_ConceptShare.Controls.Add(Me.ButtonConceptShare_RemoveUser)
            Me.TabControlPanelConceptShareTab_ConceptShare.Controls.Add(Me.CheckBoxConceptShare_ShowPassword)
            Me.TabControlPanelConceptShareTab_ConceptShare.Controls.Add(Me.CheckBoxConceptShare_IsActive)
            Me.TabControlPanelConceptShareTab_ConceptShare.Controls.Add(Me.ButtonConceptShare_UpdateUser)
            Me.TabControlPanelConceptShareTab_ConceptShare.Controls.Add(Me.ButtonConceptShare_CreateUser)
            Me.TabControlPanelConceptShareTab_ConceptShare.Controls.Add(Me.TextBoxConceptShare_Password)
            Me.TabControlPanelConceptShareTab_ConceptShare.Controls.Add(Me.LabelConceptShare_Password)
            Me.TabControlPanelConceptShareTab_ConceptShare.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelConceptShareTab_ConceptShare.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelConceptShareTab_ConceptShare.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelConceptShareTab_ConceptShare.Name = "TabControlPanelConceptShareTab_ConceptShare"
            Me.TabControlPanelConceptShareTab_ConceptShare.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelConceptShareTab_ConceptShare.Size = New System.Drawing.Size(724, 483)
            Me.TabControlPanelConceptShareTab_ConceptShare.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelConceptShareTab_ConceptShare.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelConceptShareTab_ConceptShare.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelConceptShareTab_ConceptShare.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelConceptShareTab_ConceptShare.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelConceptShareTab_ConceptShare.Style.GradientAngle = 90
            Me.TabControlPanelConceptShareTab_ConceptShare.TabIndex = 0
            Me.TabControlPanelConceptShareTab_ConceptShare.TabItem = Me.TabItemAlerts_ConceptShareTab
            '
            'ButtonConceptShare_RemoveUser
            '
            Me.ButtonConceptShare_RemoveUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonConceptShare_RemoveUser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonConceptShare_RemoveUser.Location = New System.Drawing.Point(166, 4)
            Me.ButtonConceptShare_RemoveUser.Name = "ButtonConceptShare_RemoveUser"
            Me.ButtonConceptShare_RemoveUser.SecurityEnabled = True
            Me.ButtonConceptShare_RemoveUser.Size = New System.Drawing.Size(75, 20)
            Me.ButtonConceptShare_RemoveUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonConceptShare_RemoveUser.TabIndex = 2
            Me.ButtonConceptShare_RemoveUser.Text = "Remove User"
            '
            'CheckBoxConceptShare_ShowPassword
            '
            Me.CheckBoxConceptShare_ShowPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxConceptShare_ShowPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxConceptShare_ShowPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxConceptShare_ShowPassword.CheckValue = 0
            Me.CheckBoxConceptShare_ShowPassword.CheckValueChecked = 1
            Me.CheckBoxConceptShare_ShowPassword.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxConceptShare_ShowPassword.CheckValueUnchecked = 0
            Me.CheckBoxConceptShare_ShowPassword.ChildControls = CType(resources.GetObject("CheckBoxConceptShare_ShowPassword.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxConceptShare_ShowPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxConceptShare_ShowPassword.Location = New System.Drawing.Point(620, 30)
            Me.CheckBoxConceptShare_ShowPassword.Name = "CheckBoxConceptShare_ShowPassword"
            Me.CheckBoxConceptShare_ShowPassword.OldestSibling = Nothing
            Me.CheckBoxConceptShare_ShowPassword.SecurityEnabled = True
            Me.CheckBoxConceptShare_ShowPassword.SiblingControls = CType(resources.GetObject("CheckBoxConceptShare_ShowPassword.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxConceptShare_ShowPassword.Size = New System.Drawing.Size(100, 21)
            Me.CheckBoxConceptShare_ShowPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxConceptShare_ShowPassword.TabIndex = 5
            Me.CheckBoxConceptShare_ShowPassword.TabOnEnter = True
            Me.CheckBoxConceptShare_ShowPassword.Text = "Show Password"
            '
            'CheckBoxConceptShare_IsActive
            '
            Me.CheckBoxConceptShare_IsActive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxConceptShare_IsActive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxConceptShare_IsActive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxConceptShare_IsActive.CheckValue = 0
            Me.CheckBoxConceptShare_IsActive.CheckValueChecked = 1
            Me.CheckBoxConceptShare_IsActive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxConceptShare_IsActive.CheckValueUnchecked = 0
            Me.CheckBoxConceptShare_IsActive.ChildControls = CType(resources.GetObject("CheckBoxConceptShare_IsActive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxConceptShare_IsActive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxConceptShare_IsActive.Location = New System.Drawing.Point(85, 57)
            Me.CheckBoxConceptShare_IsActive.Name = "CheckBoxConceptShare_IsActive"
            Me.CheckBoxConceptShare_IsActive.OldestSibling = Nothing
            Me.CheckBoxConceptShare_IsActive.SecurityEnabled = True
            Me.CheckBoxConceptShare_IsActive.SiblingControls = CType(resources.GetObject("CheckBoxConceptShare_IsActive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxConceptShare_IsActive.Size = New System.Drawing.Size(635, 21)
            Me.CheckBoxConceptShare_IsActive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxConceptShare_IsActive.TabIndex = 6
            Me.CheckBoxConceptShare_IsActive.TabOnEnter = True
            Me.CheckBoxConceptShare_IsActive.Text = "Is Active"
            '
            'ButtonConceptShare_UpdateUser
            '
            Me.ButtonConceptShare_UpdateUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonConceptShare_UpdateUser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonConceptShare_UpdateUser.Location = New System.Drawing.Point(85, 4)
            Me.ButtonConceptShare_UpdateUser.Name = "ButtonConceptShare_UpdateUser"
            Me.ButtonConceptShare_UpdateUser.SecurityEnabled = True
            Me.ButtonConceptShare_UpdateUser.Size = New System.Drawing.Size(75, 20)
            Me.ButtonConceptShare_UpdateUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonConceptShare_UpdateUser.TabIndex = 1
            Me.ButtonConceptShare_UpdateUser.Text = "Update User"
            '
            'ButtonConceptShare_CreateUser
            '
            Me.ButtonConceptShare_CreateUser.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonConceptShare_CreateUser.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonConceptShare_CreateUser.Location = New System.Drawing.Point(4, 4)
            Me.ButtonConceptShare_CreateUser.Name = "ButtonConceptShare_CreateUser"
            Me.ButtonConceptShare_CreateUser.SecurityEnabled = True
            Me.ButtonConceptShare_CreateUser.Size = New System.Drawing.Size(75, 20)
            Me.ButtonConceptShare_CreateUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonConceptShare_CreateUser.TabIndex = 0
            Me.ButtonConceptShare_CreateUser.Text = "Create User"
            '
            'TextBoxConceptShare_Password
            '
            Me.TextBoxConceptShare_Password.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxConceptShare_Password.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxConceptShare_Password.Border.Class = "TextBoxBorder"
            Me.TextBoxConceptShare_Password.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxConceptShare_Password.CheckSpellingOnValidate = False
            Me.TextBoxConceptShare_Password.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxConceptShare_Password.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxConceptShare_Password.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxConceptShare_Password.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxConceptShare_Password.FocusHighlightEnabled = True
            Me.TextBoxConceptShare_Password.ForeColor = System.Drawing.Color.Black
            Me.TextBoxConceptShare_Password.Location = New System.Drawing.Point(85, 30)
            Me.TextBoxConceptShare_Password.MaxFileSize = CType(0, Long)
            Me.TextBoxConceptShare_Password.Name = "TextBoxConceptShare_Password"
            Me.TextBoxConceptShare_Password.SecurityEnabled = True
            Me.TextBoxConceptShare_Password.ShowSpellCheckCompleteMessage = True
            Me.TextBoxConceptShare_Password.Size = New System.Drawing.Size(529, 21)
            Me.TextBoxConceptShare_Password.StartingFolderName = Nothing
            Me.TextBoxConceptShare_Password.TabIndex = 4
            Me.TextBoxConceptShare_Password.TabOnEnter = True
            Me.TextBoxConceptShare_Password.UseSystemPasswordChar = True
            '
            'LabelConceptShare_Password
            '
            Me.LabelConceptShare_Password.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelConceptShare_Password.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelConceptShare_Password.Location = New System.Drawing.Point(4, 30)
            Me.LabelConceptShare_Password.Name = "LabelConceptShare_Password"
            Me.LabelConceptShare_Password.Size = New System.Drawing.Size(75, 21)
            Me.LabelConceptShare_Password.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelConceptShare_Password.TabIndex = 3
            Me.LabelConceptShare_Password.Text = "Password:"
            '
            'TabItemAlerts_ConceptShareTab
            '
            Me.TabItemAlerts_ConceptShareTab.AttachedControl = Me.TabControlPanelConceptShareTab_ConceptShare
            Me.TabItemAlerts_ConceptShareTab.Name = "TabItemAlerts_ConceptShareTab"
            Me.TabItemAlerts_ConceptShareTab.Text = "ConceptShare"
            Me.TabItemAlerts_ConceptShareTab.Visible = False
            '
            'TabControlPanelSettingsTab_Settings
            '
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.CheckBoxSettings_IgnoreCalendarSync)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.TextBoxSettings_VCCPassword)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.TextBoxSettings_VCCUserName)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_VCCPassword)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_VCCUserName)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_VCC)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.TextBoxSettings_AdobeSignatureFile)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_AdobeSignature)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.ButtonSettings_AdobeSignatureFileDelete)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.ButtonSettings_AdobeSignatureFileSelect)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.TextBoxSettings_AdobeSignatureFilePassword)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_AdobeSignatureFilePassword)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_AdobeSignatureFile)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.CheckBoxSettings_IsAPIUser)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.TextBoxSettings_ProofHQPassword)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.TextBoxSettings_ProofHQUserName)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_ProofHQPassword)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_ProofHQUserName)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_ProofHQ)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.TextBoxSettings_SugarCRMPassword)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.TextBoxSettings_SugarCRMUserName)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_SugarCRMPassword)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_SugarCRMUserName)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettings_SugarCRM)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.TextBoxSettingsRightColumn_EmailPassword)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.TextBoxSettingsRightColumn_EmailUserName)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.TextBoxSettingsRightColumn_ReplyToAddress)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.TextBoxSettingsRightColumn_EmailAddress)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettingsRightColumn_EmailPassword)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettingsRightColumn_EmailUsername)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettingsRightColumn_ReplyToAddress)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.CheckBoxSettingsRightColumn_ReceivesAlerts)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail)
            Me.TabControlPanelSettingsTab_Settings.Controls.Add(Me.LabelSettingsRightColumn_EmailAddress)
            Me.TabControlPanelSettingsTab_Settings.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSettingsTab_Settings.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSettingsTab_Settings.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSettingsTab_Settings.Name = "TabControlPanelSettingsTab_Settings"
            Me.TabControlPanelSettingsTab_Settings.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSettingsTab_Settings.Size = New System.Drawing.Size(724, 483)
            Me.TabControlPanelSettingsTab_Settings.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSettingsTab_Settings.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSettingsTab_Settings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSettingsTab_Settings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSettingsTab_Settings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSettingsTab_Settings.Style.GradientAngle = 90
            Me.TabControlPanelSettingsTab_Settings.TabIndex = 0
            Me.TabControlPanelSettingsTab_Settings.TabItem = Me.TabItemAlerts_SettingsTab
            '
            'CheckBoxSettings_IgnoreCalendarSync
            '
            Me.CheckBoxSettings_IgnoreCalendarSync.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxSettings_IgnoreCalendarSync.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSettings_IgnoreCalendarSync.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSettings_IgnoreCalendarSync.CheckValue = 0
            Me.CheckBoxSettings_IgnoreCalendarSync.CheckValueChecked = 1
            Me.CheckBoxSettings_IgnoreCalendarSync.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSettings_IgnoreCalendarSync.CheckValueUnchecked = 0
            Me.CheckBoxSettings_IgnoreCalendarSync.ChildControls = CType(resources.GetObject("CheckBoxSettings_IgnoreCalendarSync.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettings_IgnoreCalendarSync.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSettings_IgnoreCalendarSync.Location = New System.Drawing.Point(432, 7)
            Me.CheckBoxSettings_IgnoreCalendarSync.Name = "CheckBoxSettings_IgnoreCalendarSync"
            Me.CheckBoxSettings_IgnoreCalendarSync.OldestSibling = Nothing
            Me.CheckBoxSettings_IgnoreCalendarSync.SecurityEnabled = True
            Me.CheckBoxSettings_IgnoreCalendarSync.SiblingControls = CType(resources.GetObject("CheckBoxSettings_IgnoreCalendarSync.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettings_IgnoreCalendarSync.Size = New System.Drawing.Size(286, 20)
            Me.CheckBoxSettings_IgnoreCalendarSync.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSettings_IgnoreCalendarSync.TabIndex = 3
            Me.CheckBoxSettings_IgnoreCalendarSync.TabOnEnter = True
            Me.CheckBoxSettings_IgnoreCalendarSync.Text = "Ignore Calendar Sync"
            '
            'TextBoxSettings_VCCPassword
            '
            Me.TextBoxSettings_VCCPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSettings_VCCPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSettings_VCCPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxSettings_VCCPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSettings_VCCPassword.CheckSpellingOnValidate = False
            Me.TextBoxSettings_VCCPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSettings_VCCPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSettings_VCCPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSettings_VCCPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSettings_VCCPassword.FocusHighlightEnabled = True
            Me.TextBoxSettings_VCCPassword.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSettings_VCCPassword.Location = New System.Drawing.Point(115, 427)
            Me.TextBoxSettings_VCCPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxSettings_VCCPassword.Name = "TextBoxSettings_VCCPassword"
            Me.TextBoxSettings_VCCPassword.SecurityEnabled = True
            Me.TextBoxSettings_VCCPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSettings_VCCPassword.Size = New System.Drawing.Size(603, 21)
            Me.TextBoxSettings_VCCPassword.StartingFolderName = Nothing
            Me.TextBoxSettings_VCCPassword.TabIndex = 33
            Me.TextBoxSettings_VCCPassword.TabOnEnter = True
            Me.TextBoxSettings_VCCPassword.UseSystemPasswordChar = True
            '
            'TextBoxSettings_VCCUserName
            '
            Me.TextBoxSettings_VCCUserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSettings_VCCUserName.Border.Class = "TextBoxBorder"
            Me.TextBoxSettings_VCCUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSettings_VCCUserName.CheckSpellingOnValidate = False
            Me.TextBoxSettings_VCCUserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSettings_VCCUserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSettings_VCCUserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSettings_VCCUserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSettings_VCCUserName.FocusHighlightEnabled = True
            Me.TextBoxSettings_VCCUserName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSettings_VCCUserName.Location = New System.Drawing.Point(115, 400)
            Me.TextBoxSettings_VCCUserName.MaxFileSize = CType(0, Long)
            Me.TextBoxSettings_VCCUserName.Name = "TextBoxSettings_VCCUserName"
            Me.TextBoxSettings_VCCUserName.SecurityEnabled = True
            Me.TextBoxSettings_VCCUserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSettings_VCCUserName.Size = New System.Drawing.Size(603, 21)
            Me.TextBoxSettings_VCCUserName.StartingFolderName = Nothing
            Me.TextBoxSettings_VCCUserName.TabIndex = 31
            Me.TextBoxSettings_VCCUserName.TabOnEnter = True
            '
            'LabelSettings_VCCPassword
            '
            Me.LabelSettings_VCCPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_VCCPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_VCCPassword.Location = New System.Drawing.Point(7, 427)
            Me.LabelSettings_VCCPassword.Name = "LabelSettings_VCCPassword"
            Me.LabelSettings_VCCPassword.Size = New System.Drawing.Size(102, 20)
            Me.LabelSettings_VCCPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_VCCPassword.TabIndex = 32
            Me.LabelSettings_VCCPassword.Text = "Password:"
            '
            'LabelSettings_VCCUserName
            '
            Me.LabelSettings_VCCUserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_VCCUserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_VCCUserName.Location = New System.Drawing.Point(7, 401)
            Me.LabelSettings_VCCUserName.Name = "LabelSettings_VCCUserName"
            Me.LabelSettings_VCCUserName.Size = New System.Drawing.Size(102, 20)
            Me.LabelSettings_VCCUserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_VCCUserName.TabIndex = 30
            Me.LabelSettings_VCCUserName.Text = "User Name:"
            '
            'LabelSettings_VCC
            '
            Me.LabelSettings_VCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSettings_VCC.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_VCC.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_VCC.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelSettings_VCC.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelSettings_VCC.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_VCC.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_VCC.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_VCC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_VCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelSettings_VCC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelSettings_VCC.Location = New System.Drawing.Point(7, 374)
            Me.LabelSettings_VCC.Name = "LabelSettings_VCC"
            Me.LabelSettings_VCC.Size = New System.Drawing.Size(711, 20)
            Me.LabelSettings_VCC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_VCC.TabIndex = 29
            Me.LabelSettings_VCC.Text = "VCC"
            '
            'TextBoxSettings_AdobeSignatureFile
            '
            Me.TextBoxSettings_AdobeSignatureFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSettings_AdobeSignatureFile.BackColor = System.Drawing.Color.White
            '
            Me.SearchableComboBoxTimeTracking_Supervisor.ActiveFilterString = ""
            Me.SearchableComboBoxTimeTracking_Supervisor.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxTimeTracking_Supervisor.AutoFillMode = False
            Me.SearchableComboBoxTimeTracking_Supervisor.BookmarkingEnabled = False
            Me.SearchableComboBoxTimeTracking_Supervisor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxTimeTracking_Supervisor.DataSource = Nothing
            Me.SearchableComboBoxTimeTracking_Supervisor.DisableMouseWheel = False
            Me.SearchableComboBoxTimeTracking_Supervisor.DisplayName = ""
            Me.SearchableComboBoxTimeTracking_Supervisor.EnterMoveNextControl = True
            Me.SearchableComboBoxTimeTracking_Supervisor.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxTimeTracking_Supervisor.Location = New System.Drawing.Point(109, 6)
            Me.SearchableComboBoxTimeTracking_Supervisor.Name = "SearchableComboBoxTimeTracking_Supervisor"
            Me.SearchableComboBoxTimeTracking_Supervisor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTimeTracking_Supervisor.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxTimeTracking_Supervisor.Properties.NullText = "Select Employee"
            Me.SearchableComboBoxTimeTracking_Supervisor.Properties.PopupView = Me.GridView2
            Me.SearchableComboBoxTimeTracking_Supervisor.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTimeTracking_Supervisor.SecurityEnabled = True
            Me.SearchableComboBoxTimeTracking_Supervisor.SelectedValue = Nothing
            Me.SearchableComboBoxTimeTracking_Supervisor.Size = New System.Drawing.Size(255, 20)
            Me.SearchableComboBoxTimeTracking_Supervisor.TabIndex = 1
            '
            'GridView2
            '
            Me.TextBoxSettings_AdobeSignatureFile.Border.Class = "TextBoxBorder"
            Me.TextBoxSettings_AdobeSignatureFile.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSettings_AdobeSignatureFile.CheckSpellingOnValidate = False
            Me.TextBoxSettings_AdobeSignatureFile.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSettings_AdobeSignatureFile.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSettings_AdobeSignatureFile.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSettings_AdobeSignatureFile.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSettings_AdobeSignatureFile.FocusHighlightEnabled = True
            Me.TextBoxSettings_AdobeSignatureFile.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSettings_AdobeSignatureFile.Location = New System.Drawing.Point(277, 322)
            Me.TextBoxSettings_AdobeSignatureFile.MaxFileSize = CType(0, Long)
            Me.TextBoxSettings_AdobeSignatureFile.Name = "TextBoxSettings_AdobeSignatureFile"
            Me.TextBoxSettings_AdobeSignatureFile.SecurityEnabled = True
            Me.TextBoxSettings_AdobeSignatureFile.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSettings_AdobeSignatureFile.Size = New System.Drawing.Size(441, 21)
            Me.TextBoxSettings_AdobeSignatureFile.StartingFolderName = Nothing
            Me.TextBoxSettings_AdobeSignatureFile.TabIndex = 26
            Me.TextBoxSettings_AdobeSignatureFile.TabOnEnter = True
            Me.TextBoxSettings_AdobeSignatureFile.Visible = False
            '
            'LabelSettings_AdobeSignature
            '
            Me.LabelSettings_AdobeSignature.BackColor = System.Drawing.Color.White
            '
            'NumericInputTimeTracking_DirectHoursGoal
            '
            Me.NumericInputTimeTracking_DirectHoursGoal.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTimeTracking_DirectHoursGoal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputTimeTracking_DirectHoursGoal.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTimeTracking_DirectHoursGoal.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTimeTracking_DirectHoursGoal.EnterMoveNextControl = True
            Me.NumericInputTimeTracking_DirectHoursGoal.Location = New System.Drawing.Point(640, 215)
            Me.NumericInputTimeTracking_DirectHoursGoal.Name = "NumericInputTimeTracking_DirectHoursGoal"
            Me.NumericInputTimeTracking_DirectHoursGoal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputTimeTracking_DirectHoursGoal.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputTimeTracking_DirectHoursGoal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTimeTracking_DirectHoursGoal.Properties.EditFormat.FormatString = "f"
            Me.NumericInputTimeTracking_DirectHoursGoal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTimeTracking_DirectHoursGoal.Properties.Mask.EditMask = "f"
            Me.NumericInputTimeTracking_DirectHoursGoal.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTimeTracking_DirectHoursGoal.SecurityEnabled = True
            Me.NumericInputTimeTracking_DirectHoursGoal.Size = New System.Drawing.Size(92, 20)
            Me.NumericInputTimeTracking_DirectHoursGoal.TabIndex = 25
            '
            Me.LabelSettings_AdobeSignature.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_AdobeSignature.Location = New System.Drawing.Point(6, 322)
            Me.LabelSettings_AdobeSignature.Name = "LabelSettings_AdobeSignature"
            Me.LabelSettings_AdobeSignature.Size = New System.Drawing.Size(102, 20)
            Me.LabelSettings_AdobeSignature.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_AdobeSignature.TabIndex = 23
            Me.LabelSettings_AdobeSignature.Text = "File:"
            '
            'ButtonSettings_AdobeSignatureFileDelete
            '
            Me.ButtonSettings_AdobeSignatureFileDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSettings_AdobeSignatureFileDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSettings_AdobeSignatureFileDelete.Location = New System.Drawing.Point(196, 322)
            Me.ButtonSettings_AdobeSignatureFileDelete.Name = "ButtonSettings_AdobeSignatureFileDelete"
            Me.ButtonSettings_AdobeSignatureFileDelete.SecurityEnabled = True
            Me.ButtonSettings_AdobeSignatureFileDelete.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSettings_AdobeSignatureFileDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSettings_AdobeSignatureFileDelete.TabIndex = 25
            Me.ButtonSettings_AdobeSignatureFileDelete.Text = "Delete"
            '
            'ButtonSettings_AdobeSignatureFileSelect
            '
            Me.ButtonSettings_AdobeSignatureFileSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSettings_AdobeSignatureFileSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSettings_AdobeSignatureFileSelect.Location = New System.Drawing.Point(115, 322)
            Me.ButtonSettings_AdobeSignatureFileSelect.Name = "ButtonSettings_AdobeSignatureFileSelect"
            Me.ButtonSettings_AdobeSignatureFileSelect.SecurityEnabled = True
            Me.ButtonSettings_AdobeSignatureFileSelect.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSettings_AdobeSignatureFileSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSettings_AdobeSignatureFileSelect.TabIndex = 24
            Me.ButtonSettings_AdobeSignatureFileSelect.Text = "Select"
            '
            'TextBoxSettings_AdobeSignatureFilePassword
            '
            Me.TextBoxSettings_AdobeSignatureFilePassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSettings_AdobeSignatureFilePassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSettings_AdobeSignatureFilePassword.Border.Class = "TextBoxBorder"
            Me.TextBoxSettings_AdobeSignatureFilePassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSettings_AdobeSignatureFilePassword.CheckSpellingOnValidate = False
            Me.TextBoxSettings_AdobeSignatureFilePassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSettings_AdobeSignatureFilePassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSettings_AdobeSignatureFilePassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSettings_AdobeSignatureFilePassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSettings_AdobeSignatureFilePassword.FocusHighlightEnabled = True
            Me.TextBoxSettings_AdobeSignatureFilePassword.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSettings_AdobeSignatureFilePassword.Location = New System.Drawing.Point(114, 348)
            Me.TextBoxSettings_AdobeSignatureFilePassword.MaxFileSize = CType(0, Long)
            Me.TextBoxSettings_AdobeSignatureFilePassword.Name = "TextBoxSettings_AdobeSignatureFilePassword"
            Me.TextBoxSettings_AdobeSignatureFilePassword.SecurityEnabled = True
            Me.TextBoxSettings_AdobeSignatureFilePassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSettings_AdobeSignatureFilePassword.Size = New System.Drawing.Size(604, 21)
            Me.TextBoxSettings_AdobeSignatureFilePassword.StartingFolderName = Nothing
            Me.TextBoxSettings_AdobeSignatureFilePassword.TabIndex = 28
            Me.TextBoxSettings_AdobeSignatureFilePassword.TabOnEnter = True
            Me.TextBoxSettings_AdobeSignatureFilePassword.UseSystemPasswordChar = True
            '
            'LabelSettings_AdobeSignatureFilePassword
            '
            Me.LabelSettings_AdobeSignatureFilePassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_AdobeSignatureFilePassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_AdobeSignatureFilePassword.Location = New System.Drawing.Point(6, 348)
            Me.LabelSettings_AdobeSignatureFilePassword.Name = "LabelSettings_AdobeSignatureFilePassword"
            Me.LabelSettings_AdobeSignatureFilePassword.Size = New System.Drawing.Size(102, 20)
            Me.LabelSettings_AdobeSignatureFilePassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_AdobeSignatureFilePassword.TabIndex = 27
            Me.LabelSettings_AdobeSignatureFilePassword.Text = "Password:"
            '
            'LabelSettings_AdobeSignatureFile
            '
            Me.LabelSettings_AdobeSignatureFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSettings_AdobeSignatureFile.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_AdobeSignatureFile.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_AdobeSignatureFile.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelSettings_AdobeSignatureFile.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelSettings_AdobeSignatureFile.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_AdobeSignatureFile.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_AdobeSignatureFile.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_AdobeSignatureFile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_AdobeSignatureFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelSettings_AdobeSignatureFile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelSettings_AdobeSignatureFile.Location = New System.Drawing.Point(7, 296)
            Me.LabelSettings_AdobeSignatureFile.Name = "LabelSettings_AdobeSignatureFile"
            Me.LabelSettings_AdobeSignatureFile.Size = New System.Drawing.Size(711, 20)
            Me.LabelSettings_AdobeSignatureFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_AdobeSignatureFile.TabIndex = 22
            Me.LabelSettings_AdobeSignatureFile.Text = "Adobe Signature File"
            '
            'CheckBoxSettings_IsAPIUser
            '
            Me.CheckBoxSettings_IsAPIUser.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSettings_IsAPIUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSettings_IsAPIUser.CheckValue = 0
            Me.CheckBoxSettings_IsAPIUser.CheckValueChecked = 1
            Me.CheckBoxSettings_IsAPIUser.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSettings_IsAPIUser.CheckValueUnchecked = 0
            Me.CheckBoxSettings_IsAPIUser.ChildControls = CType(resources.GetObject("CheckBoxSettings_IsAPIUser.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettings_IsAPIUser.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSettings_IsAPIUser.Location = New System.Drawing.Point(326, 7)
            Me.CheckBoxSettings_IsAPIUser.Name = "CheckBoxSettings_IsAPIUser"
            Me.CheckBoxSettings_IsAPIUser.OldestSibling = Nothing
            Me.CheckBoxSettings_IsAPIUser.SecurityEnabled = True
            Me.CheckBoxSettings_IsAPIUser.SiblingControls = CType(resources.GetObject("CheckBoxSettings_IsAPIUser.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettings_IsAPIUser.Size = New System.Drawing.Size(100, 20)
            Me.CheckBoxSettings_IsAPIUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSettings_IsAPIUser.TabIndex = 2
            Me.CheckBoxSettings_IsAPIUser.TabOnEnter = True
            Me.CheckBoxSettings_IsAPIUser.Text = "Is API User"
            '
            'TextBoxSettings_ProofHQPassword
            '
            Me.TextBoxSettings_ProofHQPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSettings_ProofHQPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSettings_ProofHQPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxSettings_ProofHQPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSettings_ProofHQPassword.CheckSpellingOnValidate = False
            Me.TextBoxSettings_ProofHQPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSettings_ProofHQPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSettings_ProofHQPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSettings_ProofHQPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSettings_ProofHQPassword.FocusHighlightEnabled = True
            Me.TextBoxSettings_ProofHQPassword.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSettings_ProofHQPassword.Location = New System.Drawing.Point(115, 269)
            Me.TextBoxSettings_ProofHQPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxSettings_ProofHQPassword.Name = "TextBoxSettings_ProofHQPassword"
            Me.TextBoxSettings_ProofHQPassword.SecurityEnabled = True
            Me.TextBoxSettings_ProofHQPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSettings_ProofHQPassword.Size = New System.Drawing.Size(603, 21)
            Me.TextBoxSettings_ProofHQPassword.StartingFolderName = Nothing
            Me.TextBoxSettings_ProofHQPassword.TabIndex = 21
            Me.TextBoxSettings_ProofHQPassword.TabOnEnter = True
            Me.TextBoxSettings_ProofHQPassword.UseSystemPasswordChar = True
            '
            'TextBoxSettings_ProofHQUserName
            '
            Me.TextBoxSettings_ProofHQUserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSettings_ProofHQUserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSettings_ProofHQUserName.Border.Class = "TextBoxBorder"
            Me.TextBoxSettings_ProofHQUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSettings_ProofHQUserName.CheckSpellingOnValidate = False
            Me.TextBoxSettings_ProofHQUserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSettings_ProofHQUserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSettings_ProofHQUserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSettings_ProofHQUserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSettings_ProofHQUserName.FocusHighlightEnabled = True
            Me.TextBoxSettings_ProofHQUserName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSettings_ProofHQUserName.Location = New System.Drawing.Point(115, 243)
            Me.TextBoxSettings_ProofHQUserName.MaxFileSize = CType(0, Long)
            Me.TextBoxSettings_ProofHQUserName.Name = "TextBoxSettings_ProofHQUserName"
            Me.TextBoxSettings_ProofHQUserName.SecurityEnabled = True
            Me.TextBoxSettings_ProofHQUserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSettings_ProofHQUserName.Size = New System.Drawing.Size(603, 21)
            Me.TextBoxSettings_ProofHQUserName.StartingFolderName = Nothing
            Me.TextBoxSettings_ProofHQUserName.TabIndex = 19
            Me.TextBoxSettings_ProofHQUserName.TabOnEnter = True
            '
            'LabelSettings_ProofHQPassword
            '
            Me.LabelSettings_ProofHQPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_ProofHQPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_ProofHQPassword.Location = New System.Drawing.Point(7, 268)
            Me.LabelSettings_ProofHQPassword.Name = "LabelSettings_ProofHQPassword"
            Me.LabelSettings_ProofHQPassword.Size = New System.Drawing.Size(102, 20)
            Me.LabelSettings_ProofHQPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_ProofHQPassword.TabIndex = 20
            Me.LabelSettings_ProofHQPassword.Text = "Password:"
            '
            'LabelSettings_ProofHQUserName
            '
            Me.LabelSettings_ProofHQUserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_ProofHQUserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_ProofHQUserName.Location = New System.Drawing.Point(7, 242)
            Me.LabelSettings_ProofHQUserName.Name = "LabelSettings_ProofHQUserName"
            Me.LabelSettings_ProofHQUserName.Size = New System.Drawing.Size(102, 20)
            Me.LabelSettings_ProofHQUserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_ProofHQUserName.TabIndex = 18
            Me.LabelSettings_ProofHQUserName.Text = "User Name:"
            '
            'LabelSettings_ProofHQ
            '
            Me.LabelSettings_ProofHQ.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSettings_ProofHQ.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_ProofHQ.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_ProofHQ.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelSettings_ProofHQ.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelSettings_ProofHQ.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_ProofHQ.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_ProofHQ.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_ProofHQ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_ProofHQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelSettings_ProofHQ.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelSettings_ProofHQ.Location = New System.Drawing.Point(7, 216)
            Me.LabelSettings_ProofHQ.Name = "LabelSettings_ProofHQ"
            Me.LabelSettings_ProofHQ.Size = New System.Drawing.Size(711, 20)
            Me.LabelSettings_ProofHQ.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_ProofHQ.TabIndex = 17
            Me.LabelSettings_ProofHQ.Text = "Proof HQ"
            '
            'TextBoxSettings_SugarCRMPassword
            '
            Me.TextBoxSettings_SugarCRMPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSettings_SugarCRMPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSettings_SugarCRMPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxSettings_SugarCRMPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSettings_SugarCRMPassword.CheckSpellingOnValidate = False
            Me.TextBoxSettings_SugarCRMPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSettings_SugarCRMPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSettings_SugarCRMPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSettings_SugarCRMPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSettings_SugarCRMPassword.FocusHighlightEnabled = True
            Me.TextBoxSettings_SugarCRMPassword.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSettings_SugarCRMPassword.Location = New System.Drawing.Point(114, 190)
            Me.TextBoxSettings_SugarCRMPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxSettings_SugarCRMPassword.Name = "TextBoxSettings_SugarCRMPassword"
            Me.TextBoxSettings_SugarCRMPassword.SecurityEnabled = True
            Me.TextBoxSettings_SugarCRMPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSettings_SugarCRMPassword.Size = New System.Drawing.Size(604, 21)
            Me.TextBoxSettings_SugarCRMPassword.StartingFolderName = Nothing
            Me.TextBoxSettings_SugarCRMPassword.TabIndex = 16
            Me.TextBoxSettings_SugarCRMPassword.TabOnEnter = True
            Me.TextBoxSettings_SugarCRMPassword.UseSystemPasswordChar = True
            '
            'TextBoxSettings_SugarCRMUserName
            '
            Me.TextBoxSettings_SugarCRMUserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSettings_SugarCRMUserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSettings_SugarCRMUserName.Border.Class = "TextBoxBorder"
            Me.TextBoxSettings_SugarCRMUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSettings_SugarCRMUserName.CheckSpellingOnValidate = False
            Me.TextBoxSettings_SugarCRMUserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSettings_SugarCRMUserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSettings_SugarCRMUserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSettings_SugarCRMUserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSettings_SugarCRMUserName.FocusHighlightEnabled = True
            Me.TextBoxSettings_SugarCRMUserName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSettings_SugarCRMUserName.Location = New System.Drawing.Point(114, 164)
            Me.TextBoxSettings_SugarCRMUserName.MaxFileSize = CType(0, Long)
            Me.TextBoxSettings_SugarCRMUserName.Name = "TextBoxSettings_SugarCRMUserName"
            Me.TextBoxSettings_SugarCRMUserName.SecurityEnabled = True
            Me.TextBoxSettings_SugarCRMUserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSettings_SugarCRMUserName.Size = New System.Drawing.Size(604, 21)
            Me.TextBoxSettings_SugarCRMUserName.StartingFolderName = Nothing
            Me.TextBoxSettings_SugarCRMUserName.TabIndex = 14
            Me.TextBoxSettings_SugarCRMUserName.TabOnEnter = True
            '
            'LabelSettings_SugarCRMPassword
            '
            Me.LabelSettings_SugarCRMPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_SugarCRMPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_SugarCRMPassword.Location = New System.Drawing.Point(6, 189)
            Me.LabelSettings_SugarCRMPassword.Name = "LabelSettings_SugarCRMPassword"
            Me.LabelSettings_SugarCRMPassword.Size = New System.Drawing.Size(102, 20)
            Me.LabelSettings_SugarCRMPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_SugarCRMPassword.TabIndex = 15
            Me.LabelSettings_SugarCRMPassword.Text = "Password:"
            '
            'LabelSettings_SugarCRMUserName
            '
            Me.LabelSettings_SugarCRMUserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_SugarCRMUserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_SugarCRMUserName.Location = New System.Drawing.Point(6, 163)
            Me.LabelSettings_SugarCRMUserName.Name = "LabelSettings_SugarCRMUserName"
            Me.LabelSettings_SugarCRMUserName.Size = New System.Drawing.Size(102, 20)
            Me.LabelSettings_SugarCRMUserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_SugarCRMUserName.TabIndex = 13
            Me.LabelSettings_SugarCRMUserName.Text = "User Name:"
            '
            'LabelSettings_SugarCRM
            '
            Me.LabelSettings_SugarCRM.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSettings_SugarCRM.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_SugarCRM.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_SugarCRM.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelSettings_SugarCRM.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelSettings_SugarCRM.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_SugarCRM.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_SugarCRM.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSettings_SugarCRM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_SugarCRM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelSettings_SugarCRM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelSettings_SugarCRM.Location = New System.Drawing.Point(6, 137)
            Me.LabelSettings_SugarCRM.Name = "LabelSettings_SugarCRM"
            Me.LabelSettings_SugarCRM.Size = New System.Drawing.Size(712, 20)
            Me.LabelSettings_SugarCRM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_SugarCRM.TabIndex = 12
            Me.LabelSettings_SugarCRM.Text = "SugarCRM"
            '
            'TextBoxSettingsRightColumn_EmailPassword
            '
            Me.TextBoxSettingsRightColumn_EmailPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSettingsRightColumn_EmailPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSettingsRightColumn_EmailPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxSettingsRightColumn_EmailPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSettingsRightColumn_EmailPassword.CheckSpellingOnValidate = False
            Me.TextBoxSettingsRightColumn_EmailPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSettingsRightColumn_EmailPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSettingsRightColumn_EmailPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSettingsRightColumn_EmailPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSettingsRightColumn_EmailPassword.FocusHighlightEnabled = True
            Me.TextBoxSettingsRightColumn_EmailPassword.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSettingsRightColumn_EmailPassword.Location = New System.Drawing.Point(114, 111)
            Me.TextBoxSettingsRightColumn_EmailPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxSettingsRightColumn_EmailPassword.Name = "TextBoxSettingsRightColumn_EmailPassword"
            Me.TextBoxSettingsRightColumn_EmailPassword.SecurityEnabled = True
            Me.TextBoxSettingsRightColumn_EmailPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSettingsRightColumn_EmailPassword.Size = New System.Drawing.Size(604, 21)
            Me.TextBoxSettingsRightColumn_EmailPassword.StartingFolderName = Nothing
            Me.TextBoxSettingsRightColumn_EmailPassword.TabIndex = 11
            Me.TextBoxSettingsRightColumn_EmailPassword.TabOnEnter = True
            Me.TextBoxSettingsRightColumn_EmailPassword.UseSystemPasswordChar = True
            '
            'TextBoxSettingsRightColumn_EmailUserName
            '
            Me.TextBoxSettingsRightColumn_EmailUserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSettingsRightColumn_EmailUserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSettingsRightColumn_EmailUserName.Border.Class = "TextBoxBorder"
            Me.TextBoxSettingsRightColumn_EmailUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSettingsRightColumn_EmailUserName.CheckSpellingOnValidate = False
            Me.TextBoxSettingsRightColumn_EmailUserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSettingsRightColumn_EmailUserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSettingsRightColumn_EmailUserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSettingsRightColumn_EmailUserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSettingsRightColumn_EmailUserName.FocusHighlightEnabled = True
            Me.TextBoxSettingsRightColumn_EmailUserName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSettingsRightColumn_EmailUserName.Location = New System.Drawing.Point(114, 85)
            Me.TextBoxSettingsRightColumn_EmailUserName.MaxFileSize = CType(0, Long)
            Me.TextBoxSettingsRightColumn_EmailUserName.Name = "TextBoxSettingsRightColumn_EmailUserName"
            Me.TextBoxSettingsRightColumn_EmailUserName.SecurityEnabled = True
            Me.TextBoxSettingsRightColumn_EmailUserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSettingsRightColumn_EmailUserName.Size = New System.Drawing.Size(604, 21)
            Me.TextBoxSettingsRightColumn_EmailUserName.StartingFolderName = Nothing
            Me.TextBoxSettingsRightColumn_EmailUserName.TabIndex = 9
            Me.TextBoxSettingsRightColumn_EmailUserName.TabOnEnter = True
            '
            'TextBoxSettingsRightColumn_ReplyToAddress
            '
            Me.TextBoxSettingsRightColumn_ReplyToAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSettingsRightColumn_ReplyToAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSettingsRightColumn_ReplyToAddress.Border.Class = "TextBoxBorder"
            Me.TextBoxSettingsRightColumn_ReplyToAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSettingsRightColumn_ReplyToAddress.CheckSpellingOnValidate = False
            Me.TextBoxSettingsRightColumn_ReplyToAddress.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Email
            Me.TextBoxSettingsRightColumn_ReplyToAddress.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSettingsRightColumn_ReplyToAddress.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSettingsRightColumn_ReplyToAddress.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSettingsRightColumn_ReplyToAddress.FocusHighlightEnabled = True
            Me.TextBoxSettingsRightColumn_ReplyToAddress.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSettingsRightColumn_ReplyToAddress.Location = New System.Drawing.Point(114, 59)
            Me.TextBoxSettingsRightColumn_ReplyToAddress.MaxFileSize = CType(0, Long)
            Me.TextBoxSettingsRightColumn_ReplyToAddress.Name = "TextBoxSettingsRightColumn_ReplyToAddress"
            Me.TextBoxSettingsRightColumn_ReplyToAddress.SecurityEnabled = True
            Me.TextBoxSettingsRightColumn_ReplyToAddress.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSettingsRightColumn_ReplyToAddress.Size = New System.Drawing.Size(604, 21)
            Me.TextBoxSettingsRightColumn_ReplyToAddress.StartingFolderName = Nothing
            Me.TextBoxSettingsRightColumn_ReplyToAddress.TabIndex = 7
            Me.TextBoxSettingsRightColumn_ReplyToAddress.TabOnEnter = True
            '
            'TextBoxSettingsRightColumn_EmailAddress
            '
            Me.TextBoxSettingsRightColumn_EmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxSettingsRightColumn_EmailAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxSettingsRightColumn_EmailAddress.Border.Class = "TextBoxBorder"
            Me.TextBoxSettingsRightColumn_EmailAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSettingsRightColumn_EmailAddress.CheckSpellingOnValidate = False
            Me.TextBoxSettingsRightColumn_EmailAddress.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Email
            Me.TextBoxSettingsRightColumn_EmailAddress.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSettingsRightColumn_EmailAddress.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSettingsRightColumn_EmailAddress.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSettingsRightColumn_EmailAddress.FocusHighlightEnabled = True
            Me.TextBoxSettingsRightColumn_EmailAddress.ForeColor = System.Drawing.Color.Black
            Me.TextBoxSettingsRightColumn_EmailAddress.Location = New System.Drawing.Point(114, 32)
            Me.TextBoxSettingsRightColumn_EmailAddress.MaxFileSize = CType(0, Long)
            Me.TextBoxSettingsRightColumn_EmailAddress.Name = "TextBoxSettingsRightColumn_EmailAddress"
            Me.TextBoxSettingsRightColumn_EmailAddress.SecurityEnabled = True
            Me.TextBoxSettingsRightColumn_EmailAddress.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSettingsRightColumn_EmailAddress.Size = New System.Drawing.Size(604, 21)
            Me.TextBoxSettingsRightColumn_EmailAddress.StartingFolderName = Nothing
            Me.TextBoxSettingsRightColumn_EmailAddress.TabIndex = 5
            Me.TextBoxSettingsRightColumn_EmailAddress.TabOnEnter = True
            '
            'LabelSettingsRightColumn_EmailPassword
            '
            Me.LabelSettingsRightColumn_EmailPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettingsRightColumn_EmailPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettingsRightColumn_EmailPassword.Location = New System.Drawing.Point(6, 110)
            Me.LabelSettingsRightColumn_EmailPassword.Name = "LabelSettingsRightColumn_EmailPassword"
            Me.LabelSettingsRightColumn_EmailPassword.Size = New System.Drawing.Size(102, 20)
            Me.LabelSettingsRightColumn_EmailPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettingsRightColumn_EmailPassword.TabIndex = 10
            Me.LabelSettingsRightColumn_EmailPassword.Text = "Email Password:"
            '
            'LabelSettingsRightColumn_EmailUsername
            '
            Me.LabelSettingsRightColumn_EmailUsername.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettingsRightColumn_EmailUsername.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettingsRightColumn_EmailUsername.Location = New System.Drawing.Point(6, 84)
            Me.LabelSettingsRightColumn_EmailUsername.Name = "LabelSettingsRightColumn_EmailUsername"
            Me.LabelSettingsRightColumn_EmailUsername.Size = New System.Drawing.Size(102, 20)
            Me.LabelSettingsRightColumn_EmailUsername.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettingsRightColumn_EmailUsername.TabIndex = 8
            Me.LabelSettingsRightColumn_EmailUsername.Text = "Email User Name:"
            '
            'LabelSettingsRightColumn_ReplyToAddress
            '
            Me.LabelSettingsRightColumn_ReplyToAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettingsRightColumn_ReplyToAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettingsRightColumn_ReplyToAddress.Location = New System.Drawing.Point(6, 58)
            Me.LabelSettingsRightColumn_ReplyToAddress.Name = "LabelSettingsRightColumn_ReplyToAddress"
            Me.LabelSettingsRightColumn_ReplyToAddress.Size = New System.Drawing.Size(102, 20)
            Me.LabelSettingsRightColumn_ReplyToAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettingsRightColumn_ReplyToAddress.TabIndex = 6
            Me.LabelSettingsRightColumn_ReplyToAddress.Text = "Reply To Address:"
            '
            'CheckBoxSettingsRightColumn_ReceivesAlerts
            '
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.CheckValue = 0
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.CheckValueChecked = 1
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.CheckValueUnchecked = 0
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.ChildControls = CType(resources.GetObject("CheckBoxSettingsRightColumn_ReceivesAlerts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.Location = New System.Drawing.Point(220, 7)
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.Name = "CheckBoxSettingsRightColumn_ReceivesAlerts"
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.OldestSibling = Nothing
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.SecurityEnabled = True
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.SiblingControls = CType(resources.GetObject("CheckBoxSettingsRightColumn_ReceivesAlerts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.Size = New System.Drawing.Size(100, 20)
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.TabIndex = 1
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.TabOnEnter = True
            Me.CheckBoxSettingsRightColumn_ReceivesAlerts.Text = "Receives Alerts"
            '
            'CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail
            '
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.CheckValue = 0
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.CheckValueChecked = 1
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.CheckValueUnchecked = 0
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.ChildControls = CType(resources.GetObject("CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.Location = New System.Drawing.Point(114, 7)
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.Name = "CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail"
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.OldestSibling = Nothing
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.SecurityEnabled = True
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.SiblingControls = CType(resources.GetObject("CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.Size = New System.Drawing.Size(100, 20)
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.TabIndex = 0
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.TabOnEnter = True
            Me.CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.Text = "Receives Email"
            '
            'LabelSettingsRightColumn_EmailAddress
            '
            Me.LabelSettingsRightColumn_EmailAddress.BackColor = System.Drawing.Color.White
            '
            '
            Me.RadioButtonControlTimeTracking_EmployeeStatusNonExempt.BackColor = System.Drawing.Color.White
            '
            Me.LabelSettingsRightColumn_EmailAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettingsRightColumn_EmailAddress.Location = New System.Drawing.Point(6, 32)
            Me.LabelSettingsRightColumn_EmailAddress.Name = "LabelSettingsRightColumn_EmailAddress"
            Me.LabelSettingsRightColumn_EmailAddress.Size = New System.Drawing.Size(102, 20)
            Me.LabelSettingsRightColumn_EmailAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettingsRightColumn_EmailAddress.TabIndex = 4
            Me.LabelSettingsRightColumn_EmailAddress.Text = "Email Address:"
            '
            'TabItemAlerts_SettingsTab
            '
            Me.TabItemAlerts_SettingsTab.AttachedControl = Me.TabControlPanelSettingsTab_Settings
            Me.TabItemAlerts_SettingsTab.Name = "TabItemAlerts_SettingsTab"
            Me.TabItemAlerts_SettingsTab.Text = "Settings"
            '
            'TabControlPanelAdditionalEmails_AdditionalEmails
            '
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.Controls.Add(Me.DataGridViewAdditionalEmails_AdditionalEmails)
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.Name = "TabControlPanelAdditionalEmails_AdditionalEmails"
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.Size = New System.Drawing.Size(724, 483)
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.Style.GradientAngle = 90
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.TabIndex = 27
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.TabItem = Me.TabItemAlerts_AdditionalEmailsTab
            '
            'DataGridViewAdditionalEmails_AdditionalEmails
            '
            Me.DataGridViewAdditionalEmails_AdditionalEmails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewAdditionalEmails_AdditionalEmails.AllowDragAndDrop = False
            Me.DataGridViewAdditionalEmails_AdditionalEmails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewAdditionalEmails_AdditionalEmails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewAdditionalEmails_AdditionalEmails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewAdditionalEmails_AdditionalEmails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewAdditionalEmails_AdditionalEmails.AutoFilterLookupColumns = False
            Me.DataGridViewAdditionalEmails_AdditionalEmails.AutoloadRepositoryDatasource = True
            Me.DataGridViewAdditionalEmails_AdditionalEmails.AutoUpdateViewCaption = True
            Me.DataGridViewAdditionalEmails_AdditionalEmails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewAdditionalEmails_AdditionalEmails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewAdditionalEmails_AdditionalEmails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewAdditionalEmails_AdditionalEmails.ItemDescription = "Email(s)"
            Me.DataGridViewAdditionalEmails_AdditionalEmails.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewAdditionalEmails_AdditionalEmails.MultiSelect = True
            Me.DataGridViewAdditionalEmails_AdditionalEmails.Name = "DataGridViewAdditionalEmails_AdditionalEmails"
            Me.DataGridViewAdditionalEmails_AdditionalEmails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewAdditionalEmails_AdditionalEmails.RunStandardValidation = True
            Me.DataGridViewAdditionalEmails_AdditionalEmails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewAdditionalEmails_AdditionalEmails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewAdditionalEmails_AdditionalEmails.Size = New System.Drawing.Size(716, 475)
            Me.DataGridViewAdditionalEmails_AdditionalEmails.TabIndex = 2
            Me.DataGridViewAdditionalEmails_AdditionalEmails.UseEmbeddedNavigator = False
            Me.DataGridViewAdditionalEmails_AdditionalEmails.ViewCaptionHeight = -1
            '
            'TabItemAlerts_AdditionalEmailsTab
            '
            Me.TabItemAlerts_AdditionalEmailsTab.AttachedControl = Me.TabControlPanelAdditionalEmails_AdditionalEmails
            Me.TabItemAlerts_AdditionalEmailsTab.Name = "TabItemAlerts_AdditionalEmailsTab"
            Me.TabItemAlerts_AdditionalEmailsTab.Text = "Additional Emails"
            '
            'TabControlPanelAlertGroupsTab_AlertGroups
            '
            Me.TabControlPanelAlertGroupsTab_AlertGroups.Controls.Add(Me.PanelAlertGroups_RightSection)
            Me.TabControlPanelAlertGroupsTab_AlertGroups.Controls.Add(Me.ExpandableSplitterControlAlertGroups_LeftRight)
            Me.TabControlPanelAlertGroupsTab_AlertGroups.Controls.Add(Me.PanelAlertGroups_LeftSection)
            Me.TabControlPanelAlertGroupsTab_AlertGroups.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAlertGroupsTab_AlertGroups.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAlertGroupsTab_AlertGroups.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAlertGroupsTab_AlertGroups.Name = "TabControlPanelAlertGroupsTab_AlertGroups"
            Me.TabControlPanelAlertGroupsTab_AlertGroups.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAlertGroupsTab_AlertGroups.Size = New System.Drawing.Size(724, 483)
            Me.TabControlPanelAlertGroupsTab_AlertGroups.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAlertGroupsTab_AlertGroups.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAlertGroupsTab_AlertGroups.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAlertGroupsTab_AlertGroups.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAlertGroupsTab_AlertGroups.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAlertGroupsTab_AlertGroups.Style.GradientAngle = 90
            Me.TabControlPanelAlertGroupsTab_AlertGroups.TabIndex = 1
            Me.TabControlPanelAlertGroupsTab_AlertGroups.TabItem = Me.TabItemAlerts_AlertGroupsTab
            '
            'PanelAlertGroups_RightSection
            '
            Me.PanelAlertGroups_RightSection.Controls.Add(Me.ButtonRightSection_RemoveAlertGroup)
            Me.PanelAlertGroups_RightSection.Controls.Add(Me.ButtonRightSection_AddAlertGroup)
            Me.PanelAlertGroups_RightSection.Controls.Add(Me.DataGridViewRightSection_EmployeeAlertGroups)
            Me.PanelAlertGroups_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelAlertGroups_RightSection.Location = New System.Drawing.Point(313, 1)
            Me.PanelAlertGroups_RightSection.Name = "PanelAlertGroups_RightSection"
            Me.PanelAlertGroups_RightSection.Size = New System.Drawing.Size(410, 481)
            Me.PanelAlertGroups_RightSection.TabIndex = 2
            '
            'ButtonRightSection_RemoveAlertGroup
            '
            Me.ButtonRightSection_RemoveAlertGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveAlertGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveAlertGroup.Location = New System.Drawing.Point(6, 32)
            Me.ButtonRightSection_RemoveAlertGroup.Name = "ButtonRightSection_RemoveAlertGroup"
            Me.ButtonRightSection_RemoveAlertGroup.SecurityEnabled = True
            Me.ButtonRightSection_RemoveAlertGroup.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveAlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveAlertGroup.TabIndex = 1
            Me.ButtonRightSection_RemoveAlertGroup.Text = "<"
            '
            'ButtonRightSection_AddAlertGroup
            '
            Me.ButtonRightSection_AddAlertGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddAlertGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddAlertGroup.Location = New System.Drawing.Point(6, 6)
            Me.ButtonRightSection_AddAlertGroup.Name = "ButtonRightSection_AddAlertGroup"
            Me.ButtonRightSection_AddAlertGroup.SecurityEnabled = True
            Me.ButtonRightSection_AddAlertGroup.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddAlertGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddAlertGroup.TabIndex = 0
            Me.ButtonRightSection_AddAlertGroup.Text = ">"
            '
            'DataGridViewRightSection_EmployeeAlertGroups
            '
            Me.DataGridViewRightSection_EmployeeAlertGroups.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightSection_EmployeeAlertGroups.AllowDragAndDrop = False
            Me.DataGridViewRightSection_EmployeeAlertGroups.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_EmployeeAlertGroups.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_EmployeeAlertGroups.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_EmployeeAlertGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_EmployeeAlertGroups.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_EmployeeAlertGroups.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_EmployeeAlertGroups.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_EmployeeAlertGroups.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_EmployeeAlertGroups.DataSource = Nothing
            Me.DataGridViewRightSection_EmployeeAlertGroups.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_EmployeeAlertGroups.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_EmployeeAlertGroups.ItemDescription = ""
            Me.DataGridViewRightSection_EmployeeAlertGroups.Location = New System.Drawing.Point(87, 6)
            Me.DataGridViewRightSection_EmployeeAlertGroups.MultiSelect = True
            Me.DataGridViewRightSection_EmployeeAlertGroups.Name = "DataGridViewRightSection_EmployeeAlertGroups"
            Me.DataGridViewRightSection_EmployeeAlertGroups.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_EmployeeAlertGroups.RunStandardValidation = True
            Me.DataGridViewRightSection_EmployeeAlertGroups.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightSection_EmployeeAlertGroups.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_EmployeeAlertGroups.Size = New System.Drawing.Size(316, 469)
            Me.DataGridViewRightSection_EmployeeAlertGroups.TabIndex = 2
            Me.DataGridViewRightSection_EmployeeAlertGroups.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_EmployeeAlertGroups.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlAlertGroups_LeftRight
            '
            Me.ExpandableSplitterControlAlertGroups_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlAlertGroups_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlAlertGroups_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlAlertGroups_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlAlertGroups_LeftRight.ExpandableControl = Me.PanelAlertGroups_LeftSection
            Me.ExpandableSplitterControlAlertGroups_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlAlertGroups_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlAlertGroups_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlAlertGroups_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlAlertGroups_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlAlertGroups_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlAlertGroups_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlAlertGroups_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlAlertGroups_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlAlertGroups_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlAlertGroups_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlAlertGroups_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlAlertGroups_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlAlertGroups_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlAlertGroups_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlAlertGroups_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlAlertGroups_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlAlertGroups_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlAlertGroups_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlAlertGroups_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlAlertGroups_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlAlertGroups_LeftRight.Location = New System.Drawing.Point(307, 1)
            Me.ExpandableSplitterControlAlertGroups_LeftRight.Name = "ExpandableSplitterControlAlertGroups_LeftRight"
            Me.ExpandableSplitterControlAlertGroups_LeftRight.Size = New System.Drawing.Size(6, 481)
            Me.ExpandableSplitterControlAlertGroups_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlAlertGroups_LeftRight.TabIndex = 4
            Me.ExpandableSplitterControlAlertGroups_LeftRight.TabStop = False
            '
            'PanelAlertGroups_LeftSection
            '
            Me.PanelAlertGroups_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableAlertGroups)
            Me.PanelAlertGroups_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelAlertGroups_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelAlertGroups_LeftSection.Name = "PanelAlertGroups_LeftSection"
            Me.PanelAlertGroups_LeftSection.Size = New System.Drawing.Size(306, 481)
            Me.PanelAlertGroups_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_AvailableAlertGroups
            '
            Me.DataGridViewLeftSection_AvailableAlertGroups.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_AvailableAlertGroups.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_AvailableAlertGroups.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_AvailableAlertGroups.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableAlertGroups.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableAlertGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableAlertGroups.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AvailableAlertGroups.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AvailableAlertGroups.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_AvailableAlertGroups.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_AvailableAlertGroups.DataSource = Nothing
            Me.DataGridViewLeftSection_AvailableAlertGroups.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_AvailableAlertGroups.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableAlertGroups.ItemDescription = ""
            Me.DataGridViewLeftSection_AvailableAlertGroups.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewLeftSection_AvailableAlertGroups.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableAlertGroups.Name = "DataGridViewLeftSection_AvailableAlertGroups"
            Me.DataGridViewLeftSection_AvailableAlertGroups.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableAlertGroups.RunStandardValidation = True
            Me.DataGridViewLeftSection_AvailableAlertGroups.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_AvailableAlertGroups.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableAlertGroups.Size = New System.Drawing.Size(294, 469)
            Me.DataGridViewLeftSection_AvailableAlertGroups.TabIndex = 1
            Me.DataGridViewLeftSection_AvailableAlertGroups.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableAlertGroups.ViewCaptionHeight = -1
            '
            'TabItemAlerts_AlertGroupsTab
            '
            Me.TabItemAlerts_AlertGroupsTab.AttachedControl = Me.TabControlPanelAlertGroupsTab_AlertGroups
            Me.TabItemAlerts_AlertGroupsTab.Name = "TabItemAlerts_AlertGroupsTab"
            Me.TabItemAlerts_AlertGroupsTab.Text = "Alert Groups"
            '
            'TabControlPanel_CalendarTime
            '
            Me.TabControlPanel_CalendarTime.Controls.Add(Me.CheckBoxForm_SSL)
            Me.TabControlPanel_CalendarTime.Controls.Add(Me.TextBoxCalendarTime_Port)
            Me.TabControlPanel_CalendarTime.Controls.Add(Me.Label3)
            Me.TabControlPanel_CalendarTime.Controls.Add(Me.TextBoxCalendarTime_Host)
            Me.TabControlPanel_CalendarTime.Controls.Add(Me.Label2)
            Me.TabControlPanel_CalendarTime.Controls.Add(Me.ComboBoxCalendarTime_Type)
            Me.TabControlPanel_CalendarTime.Controls.Add(Me.Label1)
            Me.TabControlPanel_CalendarTime.Controls.Add(Me.TextBoxCalendarTime_EmailPassword)
            Me.TabControlPanel_CalendarTime.Controls.Add(Me.TextBoxCalendarTime_EmailUserName)
            Me.TabControlPanel_CalendarTime.Controls.Add(Me.TextBoxCalendarTime_EmailAddress)
            Me.TabControlPanel_CalendarTime.Controls.Add(Me.Label13)
            Me.TabControlPanel_CalendarTime.Controls.Add(Me.Label14)
            Me.TabControlPanel_CalendarTime.Controls.Add(Me.Label16)
            Me.TabControlPanel_CalendarTime.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel_CalendarTime.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel_CalendarTime.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel_CalendarTime.Name = "TabControlPanel_CalendarTime"
            Me.TabControlPanel_CalendarTime.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel_CalendarTime.Size = New System.Drawing.Size(724, 483)
            Me.TabControlPanel_CalendarTime.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel_CalendarTime.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel_CalendarTime.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel_CalendarTime.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel_CalendarTime.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel_CalendarTime.Style.GradientAngle = 90
            Me.TabControlPanel_CalendarTime.TabIndex = 14
            Me.TabControlPanel_CalendarTime.TabItem = Me.TabItemAlerts_CalendarTimeTab
            '
            'CheckBoxForm_SSL
            '
            Me.CheckBoxForm_SSL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_SSL.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_SSL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_SSL.CheckValue = 0
            Me.CheckBoxForm_SSL.CheckValueChecked = 1
            Me.CheckBoxForm_SSL.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_SSL.CheckValueUnchecked = 0
            Me.CheckBoxForm_SSL.ChildControls = CType(resources.GetObject("CheckBoxForm_SSL.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_SSL.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_SSL.Location = New System.Drawing.Point(114, 161)
            Me.CheckBoxForm_SSL.Name = "CheckBoxForm_SSL"
            Me.CheckBoxForm_SSL.OldestSibling = Nothing
            Me.CheckBoxForm_SSL.SecurityEnabled = True
            Me.CheckBoxForm_SSL.SiblingControls = CType(resources.GetObject("CheckBoxForm_SSL.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_SSL.Size = New System.Drawing.Size(602, 21)
            Me.CheckBoxForm_SSL.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_SSL.TabIndex = 28
            Me.CheckBoxForm_SSL.TabOnEnter = True
            Me.CheckBoxForm_SSL.Text = "Use SSL"
            '
            'TextBoxCalendarTime_Port
            '
            Me.TextBoxCalendarTime_Port.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxCalendarTime_Port.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxCalendarTime_Port.Border.Class = "TextBoxBorder"
            Me.TextBoxCalendarTime_Port.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCalendarTime_Port.CheckSpellingOnValidate = False
            Me.TextBoxCalendarTime_Port.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxCalendarTime_Port.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxCalendarTime_Port.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCalendarTime_Port.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCalendarTime_Port.FocusHighlightEnabled = True
            Me.TextBoxCalendarTime_Port.ForeColor = System.Drawing.Color.Black
            Me.TextBoxCalendarTime_Port.Location = New System.Drawing.Point(114, 134)
            Me.TextBoxCalendarTime_Port.MaxFileSize = CType(0, Long)
            Me.TextBoxCalendarTime_Port.Name = "TextBoxCalendarTime_Port"
            Me.TextBoxCalendarTime_Port.SecurityEnabled = True
            Me.TextBoxCalendarTime_Port.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCalendarTime_Port.Size = New System.Drawing.Size(65, 21)
            Me.TextBoxCalendarTime_Port.StartingFolderName = Nothing
            Me.TextBoxCalendarTime_Port.TabIndex = 27
            Me.TextBoxCalendarTime_Port.TabOnEnter = True
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.White
            '
            '
            Me.LabelTimeTracking_EmployeeStatus.BackColor = System.Drawing.Color.White
            '
            Me.Label3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label3.Location = New System.Drawing.Point(7, 135)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(102, 20)
            Me.Label3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label3.TabIndex = 26
            Me.Label3.Text = "Port Number:"
            '
            'TextBoxCalendarTime_Host
            '
            Me.TextBoxCalendarTime_Host.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxCalendarTime_Host.BackColor = System.Drawing.Color.White
            '
            'LabelTimeTracking_StandardWorkDays
            '
            '
            Me.TextBoxCalendarTime_Host.Border.Class = "TextBoxBorder"
            Me.TextBoxCalendarTime_Host.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCalendarTime_Host.CheckSpellingOnValidate = False
            Me.TextBoxCalendarTime_Host.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxCalendarTime_Host.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxCalendarTime_Host.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCalendarTime_Host.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCalendarTime_Host.FocusHighlightEnabled = True
            Me.TextBoxCalendarTime_Host.ForeColor = System.Drawing.Color.Black
            Me.TextBoxCalendarTime_Host.Location = New System.Drawing.Point(114, 108)
            Me.TextBoxCalendarTime_Host.MaxFileSize = CType(0, Long)
            Me.TextBoxCalendarTime_Host.Name = "TextBoxCalendarTime_Host"
            Me.TextBoxCalendarTime_Host.SecurityEnabled = True
            Me.TextBoxCalendarTime_Host.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCalendarTime_Host.Size = New System.Drawing.Size(602, 21)
            Me.TextBoxCalendarTime_Host.StartingFolderName = Nothing
            Me.TextBoxCalendarTime_Host.TabIndex = 25
            Me.TextBoxCalendarTime_Host.TabOnEnter = True
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.White
            '
            'DataGridViewTimeTracking_WorkDays
            '
            '
            Me.Label2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label2.Location = New System.Drawing.Point(7, 109)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(102, 20)
            Me.Label2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label2.TabIndex = 24
            Me.Label2.Text = "Host:"
            '
            'ComboBoxCalendarTime_Type
            '
            Me.ComboBoxCalendarTime_Type.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxCalendarTime_Type.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxCalendarTime_Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxCalendarTime_Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxCalendarTime_Type.AutoFindItemInDataSource = False
            Me.ComboBoxCalendarTime_Type.AutoSelectSingleItemDatasource = False
            Me.ComboBoxCalendarTime_Type.BookmarkingEnabled = False
            Me.ComboBoxCalendarTime_Type.ClientCode = ""
            Me.ComboBoxCalendarTime_Type.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxCalendarTime_Type.DisableMouseWheel = False
            Me.ComboBoxCalendarTime_Type.DisplayMember = "Description"
            Me.ComboBoxCalendarTime_Type.DisplayName = ""
            Me.ComboBoxCalendarTime_Type.DivisionCode = ""
            Me.ComboBoxCalendarTime_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxCalendarTime_Type.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxCalendarTime_Type.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxCalendarTime_Type.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxCalendarTime_Type.FocusHighlightEnabled = True
            Me.ComboBoxCalendarTime_Type.FormattingEnabled = True
            Me.ComboBoxCalendarTime_Type.ItemHeight = 16
            Me.ComboBoxCalendarTime_Type.Location = New System.Drawing.Point(114, 4)
            Me.ComboBoxCalendarTime_Type.Name = "ComboBoxCalendarTime_Type"
            Me.ComboBoxCalendarTime_Type.ReadOnly = False
            Me.ComboBoxCalendarTime_Type.SecurityEnabled = True
            Me.ComboBoxCalendarTime_Type.Size = New System.Drawing.Size(356, 22)
            Me.ComboBoxCalendarTime_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxCalendarTime_Type.TabIndex = 23
            Me.ComboBoxCalendarTime_Type.TabOnEnter = True
            Me.ComboBoxCalendarTime_Type.ValueMember = "Code"
            Me.ComboBoxCalendarTime_Type.WatermarkText = "Select"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(6, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(102, 20)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 21
            Me.Label1.Text = "Calendar Type:"
            '
            'TextBoxCalendarTime_EmailPassword
            '
            Me.TextBoxCalendarTime_EmailPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxCalendarTime_EmailPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxCalendarTime_EmailPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxCalendarTime_EmailPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCalendarTime_EmailPassword.CheckSpellingOnValidate = False
            Me.TextBoxCalendarTime_EmailPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxCalendarTime_EmailPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxCalendarTime_EmailPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCalendarTime_EmailPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCalendarTime_EmailPassword.FocusHighlightEnabled = True
            Me.TextBoxCalendarTime_EmailPassword.ForeColor = System.Drawing.Color.Black
            Me.TextBoxCalendarTime_EmailPassword.Location = New System.Drawing.Point(114, 83)
            Me.TextBoxCalendarTime_EmailPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxCalendarTime_EmailPassword.Name = "TextBoxCalendarTime_EmailPassword"
            Me.TextBoxCalendarTime_EmailPassword.SecurityEnabled = True
            Me.TextBoxCalendarTime_EmailPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCalendarTime_EmailPassword.Size = New System.Drawing.Size(602, 21)
            Me.TextBoxCalendarTime_EmailPassword.StartingFolderName = Nothing
            Me.TextBoxCalendarTime_EmailPassword.TabIndex = 20
            Me.TextBoxCalendarTime_EmailPassword.TabOnEnter = True
            Me.TextBoxCalendarTime_EmailPassword.UseSystemPasswordChar = True
            '
            'TextBoxCalendarTime_EmailUserName
            '
            Me.TextBoxCalendarTime_EmailUserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxCalendarTime_EmailUserName.BackColor = System.Drawing.Color.White
            '
            'LabelTimeTracking_Supervisor
            '
            Me.LabelHRAndRateInformation_TerminationDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHRAndRateInformation_TerminationDate.Location = New System.Drawing.Point(6, 136)
            Me.LabelHRAndRateInformation_TerminationDate.Name = "LabelHRAndRateInformation_TerminationDate"
            Me.LabelHRAndRateInformation_TerminationDate.Size = New System.Drawing.Size(124, 20)
            Me.LabelHRAndRateInformation_TerminationDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHRAndRateInformation_TerminationDate.TabIndex = 9
            Me.LabelHRAndRateInformation_TerminationDate.Text = "Termination Date:"
            '
            Me.TextBoxCalendarTime_EmailUserName.Border.Class = "TextBoxBorder"
            Me.TextBoxCalendarTime_EmailUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCalendarTime_EmailUserName.CheckSpellingOnValidate = False
            Me.TextBoxCalendarTime_EmailUserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxCalendarTime_EmailUserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxCalendarTime_EmailUserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCalendarTime_EmailUserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCalendarTime_EmailUserName.FocusHighlightEnabled = True
            Me.TextBoxCalendarTime_EmailUserName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxCalendarTime_EmailUserName.Location = New System.Drawing.Point(114, 58)
            Me.TextBoxCalendarTime_EmailUserName.MaxFileSize = CType(0, Long)
            Me.TextBoxCalendarTime_EmailUserName.Name = "TextBoxCalendarTime_EmailUserName"
            Me.TextBoxCalendarTime_EmailUserName.SecurityEnabled = True
            Me.TextBoxCalendarTime_EmailUserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCalendarTime_EmailUserName.Size = New System.Drawing.Size(602, 21)
            Me.TextBoxCalendarTime_EmailUserName.StartingFolderName = Nothing
            Me.TextBoxCalendarTime_EmailUserName.TabIndex = 18
            Me.TextBoxCalendarTime_EmailUserName.TabOnEnter = True
            '
            'TextBoxCalendarTime_EmailAddress
            '
            Me.TextBoxCalendarTime_EmailAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxCalendarTime_EmailAddress.BackColor = System.Drawing.Color.White
            '
            'TabItemEmployeeDetails_TimeTrackingTab
            '
            '
            Me.TextBoxCalendarTime_EmailAddress.Border.Class = "TextBoxBorder"
            Me.TextBoxCalendarTime_EmailAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCalendarTime_EmailAddress.CheckSpellingOnValidate = False
            Me.TextBoxCalendarTime_EmailAddress.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Email
            Me.TextBoxCalendarTime_EmailAddress.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxCalendarTime_EmailAddress.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCalendarTime_EmailAddress.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCalendarTime_EmailAddress.FocusHighlightEnabled = True
            Me.TextBoxCalendarTime_EmailAddress.ForeColor = System.Drawing.Color.Black
            Me.TextBoxCalendarTime_EmailAddress.Location = New System.Drawing.Point(114, 31)
            Me.TextBoxCalendarTime_EmailAddress.MaxFileSize = CType(0, Long)
            Me.TextBoxCalendarTime_EmailAddress.Name = "TextBoxCalendarTime_EmailAddress"
            Me.TextBoxCalendarTime_EmailAddress.SecurityEnabled = True
            Me.TextBoxCalendarTime_EmailAddress.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCalendarTime_EmailAddress.Size = New System.Drawing.Size(602, 21)
            Me.TextBoxCalendarTime_EmailAddress.StartingFolderName = Nothing
            Me.TextBoxCalendarTime_EmailAddress.TabIndex = 16
            Me.TextBoxCalendarTime_EmailAddress.TabOnEnter = True
            '
            'Label13
            '
            Me.Label13.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label13.Location = New System.Drawing.Point(6, 83)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(102, 20)
            Me.Label13.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label13.TabIndex = 19
            Me.Label13.Text = "Email Password:"
            '
            'Label14
            '
            Me.Label14.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label14.Location = New System.Drawing.Point(6, 57)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(102, 20)
            Me.Label14.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label14.TabIndex = 17
            Me.Label14.Text = "Email User Name:"
            '
            'Label16
            '
            Me.Label16.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.Label16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label16.Location = New System.Drawing.Point(6, 31)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(102, 20)
            Me.Label16.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label16.TabIndex = 15
            Me.Label16.Text = "Email Address:"
            '
            'TabItemAlerts_CalendarTimeTab
            '
            Me.TabItemAlerts_CalendarTimeTab.AttachedControl = Me.TabControlPanel_CalendarTime
            Me.TabItemAlerts_CalendarTimeTab.Name = "TabItemAlerts_CalendarTimeTab"
            Me.TabItemAlerts_CalendarTimeTab.Text = "Calendar Time"
            '
            'TabControlPanel1
            '
            Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel1.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel1.Name = "TabControlPanel1"
            Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel1.Size = New System.Drawing.Size(724, 483)
            Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel1.Style.GradientAngle = 90
            Me.TabControlPanel1.TabIndex = 10
            '
            'TabItemEmployeeDetails_AlertsTab
            '
            Me.TabItemEmployeeDetails_AlertsTab.AttachedControl = Me.TabControlPanelAlertsTab_Alerts
            Me.TabItemEmployeeDetails_AlertsTab.Name = "TabItemEmployeeDetails_AlertsTab"
            Me.TabItemEmployeeDetails_AlertsTab.Text = "Alerts && Settings"
            '
            'TabControlPanelGeneralInformation_GeneralInformation
            '
            Me.TabControlPanelGeneralInformation_GeneralInformation.Controls.Add(Me.PanelGeneralInformation_GeneralInformation)
            Me.TabControlPanelGeneralInformation_GeneralInformation.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelGeneralInformation_GeneralInformation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGeneralInformation_GeneralInformation.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGeneralInformation_GeneralInformation.Name = "TabControlPanelGeneralInformation_GeneralInformation"
            Me.TabControlPanelGeneralInformation_GeneralInformation.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGeneralInformation_GeneralInformation.Size = New System.Drawing.Size(738, 523)
            Me.TabControlPanelGeneralInformation_GeneralInformation.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelGeneralInformation_GeneralInformation.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneralInformation_GeneralInformation.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGeneralInformation_GeneralInformation.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGeneralInformation_GeneralInformation.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGeneralInformation_GeneralInformation.Style.GradientAngle = 90
            Me.TabControlPanelGeneralInformation_GeneralInformation.TabIndex = 0
            Me.TabControlPanelGeneralInformation_GeneralInformation.TabItem = Me.TabItemEmployeeDetails_GeneralInformation
            '
            'PanelGeneralInformation_GeneralInformation
            '
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.SearchableComboBoxGeneralInformation_AssignedOffice)
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.SearchableComboBoxGeneralInformation_Title)
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.CheckBoxGeneralInformation_ActiveFreelance)
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.LabelGeneralInformation_AssignedOffice)
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.LabelGeneralInformation_Code)
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.TabControlGeneralInformation_EmployeeGeneralInformation)
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.TextBoxGeneralInformation_AccountNumber)
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.TextBoxGeneralInformation_Code)
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.TextBoxGeneralInformation_LastName)
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.LabelGeneralInformation_FirstName)
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.LabelGeneralInformation_AccountNumber)
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.LabelGeneralInformation_MiddleInitial)
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.LabelGeneralInformation_LastName)
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.LabelGeneralInformation_Title)
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.CheckBoxGeneralInformation_Freelance)
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.TextBoxGeneralInformation_FirstName)
            Me.PanelGeneralInformation_GeneralInformation.Controls.Add(Me.TextBoxGeneralInformation_MiddleInitial)
            Me.PanelGeneralInformation_GeneralInformation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelGeneralInformation_GeneralInformation.Location = New System.Drawing.Point(1, 1)
            Me.PanelGeneralInformation_GeneralInformation.Name = "PanelGeneralInformation_GeneralInformation"
            Me.PanelGeneralInformation_GeneralInformation.Size = New System.Drawing.Size(736, 521)
            Me.PanelGeneralInformation_GeneralInformation.TabIndex = 0
            '
            'SearchableComboBoxGeneralInformation_AssignedOffice
            '
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.AutoFillMode = False
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Office
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.DataSource = Nothing
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.DisplayName = ""
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.Location = New System.Drawing.Point(48, 58)
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.Name = "SearchableComboBoxGeneralInformation_AssignedOffice"
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.Properties.NullText = "Select Office"
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.Properties.PopupView = Me.GridView1
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.SecurityEnabled = True
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.Size = New System.Drawing.Size(241, 20)
            Me.SearchableComboBoxGeneralInformation_AssignedOffice.TabIndex = 13
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
            'SearchableComboBoxGeneralInformation_Title
            '
            Me.SearchableComboBoxGeneralInformation_Title.ActiveFilterString = ""
            Me.SearchableComboBoxGeneralInformation_Title.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxGeneralInformation_Title.AutoFillMode = False
            Me.SearchableComboBoxGeneralInformation_Title.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneralInformation_Title.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.EmployeeTitle
            Me.SearchableComboBoxGeneralInformation_Title.DataSource = Nothing
            Me.SearchableComboBoxGeneralInformation_Title.DisableMouseWheel = False
            Me.SearchableComboBoxGeneralInformation_Title.DisplayName = ""
            Me.SearchableComboBoxGeneralInformation_Title.EnterMoveNextControl = True
            Me.SearchableComboBoxGeneralInformation_Title.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneralInformation_Title.Location = New System.Drawing.Point(48, 32)
            Me.SearchableComboBoxGeneralInformation_Title.Name = "SearchableComboBoxGeneralInformation_Title"
            Me.SearchableComboBoxGeneralInformation_Title.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneralInformation_Title.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGeneralInformation_Title.Properties.NullText = "Select Employee Title"
            Me.SearchableComboBoxGeneralInformation_Title.Properties.PopupView = Me.GridView4
            Me.SearchableComboBoxGeneralInformation_Title.Properties.ValueMember = "ID"
            Me.SearchableComboBoxGeneralInformation_Title.SecurityEnabled = True
            Me.SearchableComboBoxGeneralInformation_Title.SelectedValue = Nothing
            Me.SearchableComboBoxGeneralInformation_Title.Size = New System.Drawing.Size(241, 20)
            Me.SearchableComboBoxGeneralInformation_Title.TabIndex = 9
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
            'CheckBoxGeneralInformation_ActiveFreelance
            '
            Me.CheckBoxGeneralInformation_ActiveFreelance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxGeneralInformation_ActiveFreelance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGeneralInformation_ActiveFreelance.CheckValue = 0
            Me.CheckBoxGeneralInformation_ActiveFreelance.CheckValueChecked = 1
            Me.CheckBoxGeneralInformation_ActiveFreelance.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGeneralInformation_ActiveFreelance.CheckValueUnchecked = 0
            Me.CheckBoxGeneralInformation_ActiveFreelance.ChildControls = CType(resources.GetObject("CheckBoxGeneralInformation_ActiveFreelance.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneralInformation_ActiveFreelance.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGeneralInformation_ActiveFreelance.Location = New System.Drawing.Point(390, 32)
            Me.CheckBoxGeneralInformation_ActiveFreelance.Name = "CheckBoxGeneralInformation_ActiveFreelance"
            Me.CheckBoxGeneralInformation_ActiveFreelance.OldestSibling = Nothing
            Me.CheckBoxGeneralInformation_ActiveFreelance.SecurityEnabled = True
            Me.CheckBoxGeneralInformation_ActiveFreelance.SiblingControls = CType(resources.GetObject("CheckBoxGeneralInformation_ActiveFreelance.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneralInformation_ActiveFreelance.Size = New System.Drawing.Size(341, 20)
            Me.CheckBoxGeneralInformation_ActiveFreelance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGeneralInformation_ActiveFreelance.TabIndex = 11
            Me.CheckBoxGeneralInformation_ActiveFreelance.TabOnEnter = True
            Me.CheckBoxGeneralInformation_ActiveFreelance.Text = "Active Freelance"
            '
            'LabelGeneralInformation_AssignedOffice
            '
            Me.LabelGeneralInformation_AssignedOffice.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInformation_AssignedOffice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInformation_AssignedOffice.Location = New System.Drawing.Point(6, 58)
            Me.LabelGeneralInformation_AssignedOffice.Name = "LabelGeneralInformation_AssignedOffice"
            Me.LabelGeneralInformation_AssignedOffice.Size = New System.Drawing.Size(36, 20)
            Me.LabelGeneralInformation_AssignedOffice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInformation_AssignedOffice.TabIndex = 12
            Me.LabelGeneralInformation_AssignedOffice.Text = "Office:"
            '
            'LabelGeneralInformation_Code
            '
            Me.LabelGeneralInformation_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInformation_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInformation_Code.Location = New System.Drawing.Point(6, 6)
            Me.LabelGeneralInformation_Code.Name = "LabelGeneralInformation_Code"
            Me.LabelGeneralInformation_Code.Size = New System.Drawing.Size(36, 20)
            Me.LabelGeneralInformation_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInformation_Code.TabIndex = 0
            Me.LabelGeneralInformation_Code.Text = "Code:"
            '
            'TabControlGeneralInformation_EmployeeGeneralInformation
            '
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.CanReorderTabs = False
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.Controls.Add(Me.TabControlPanelInformationTab_Information)
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.Controls.Add(Me.TabControlDepartmentTeamTab_DepartmentTeam)
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.Controls.Add(Me.TabControlPanelRolesTab_Roles)
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.ForeColor = System.Drawing.Color.Black
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.Location = New System.Drawing.Point(6, 84)
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.Name = "TabControlGeneralInformation_EmployeeGeneralInformation"
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.SelectedTabIndex = 0
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.Size = New System.Drawing.Size(725, 432)
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.TabIndex = 16
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.Tabs.Add(Me.TabItemEmployeeGeneralInformation_InformationTab)
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.Tabs.Add(Me.TabItemEmployeeGeneralInformation_DepartmentTeamTab)
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.Tabs.Add(Me.TabItemEmployeeGeneralInformation_RolesTab)
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.Text = "TabControl1"
            '
            'TabControlPanelInformationTab_Information
            '
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.TableLayoutPanelInformation_Information)
            Me.TabControlPanelInformationTab_Information.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelInformationTab_Information.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInformationTab_Information.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInformationTab_Information.Name = "TabControlPanelInformationTab_Information"
            Me.TabControlPanelInformationTab_Information.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInformationTab_Information.Size = New System.Drawing.Size(725, 405)
            Me.TabControlPanelInformationTab_Information.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelInformationTab_Information.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInformationTab_Information.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInformationTab_Information.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInformationTab_Information.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInformationTab_Information.Style.GradientAngle = 90
            Me.TabControlPanelInformationTab_Information.TabIndex = 0
            Me.TabControlPanelInformationTab_Information.TabItem = Me.TabItemEmployeeGeneralInformation_InformationTab
            '
            'TableLayoutPanelInformation_Information
            '
            Me.TableLayoutPanelInformation_Information.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelInformation_Information.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelInformation_Information.ColumnCount = 2
            Me.TableLayoutPanelInformation_Information.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.80599!))
            Me.TableLayoutPanelInformation_Information.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.19401!))
            Me.TableLayoutPanelInformation_Information.Controls.Add(Me.PanelInformation_BottomColumn, 0, 1)
            Me.TableLayoutPanelInformation_Information.Controls.Add(Me.PanelInformation_TopRightColumn, 1, 0)
            Me.TableLayoutPanelInformation_Information.Controls.Add(Me.PanelInformation_TopLeftColumn, 0, 0)
            Me.TableLayoutPanelInformation_Information.Location = New System.Drawing.Point(1, 6)
            Me.TableLayoutPanelInformation_Information.Name = "TableLayoutPanelInformation_Information"
            Me.TableLayoutPanelInformation_Information.RowCount = 2
            Me.TableLayoutPanelInformation_Information.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.41457!))
            Me.TableLayoutPanelInformation_Information.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 63.58543!))
            Me.TableLayoutPanelInformation_Information.Size = New System.Drawing.Size(723, 357)
            Me.TableLayoutPanelInformation_Information.TabIndex = 0
            '
            'PanelInformation_BottomColumn
            '
            Me.TableLayoutPanelInformation_Information.SetColumnSpan(Me.PanelInformation_BottomColumn, 2)
            Me.PanelInformation_BottomColumn.Controls.Add(Me.TableLayoutPanelBottomColumn_Information)
            Me.PanelInformation_BottomColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelInformation_BottomColumn.Location = New System.Drawing.Point(0, 130)
            Me.PanelInformation_BottomColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelInformation_BottomColumn.Name = "PanelInformation_BottomColumn"
            Me.PanelInformation_BottomColumn.Size = New System.Drawing.Size(723, 227)
            Me.PanelInformation_BottomColumn.TabIndex = 2
            '
            'TableLayoutPanelBottomColumn_Information
            '
            Me.TableLayoutPanelBottomColumn_Information.ColumnCount = 2
            Me.TableLayoutPanelBottomColumn_Information.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelBottomColumn_Information.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelBottomColumn_Information.Controls.Add(Me.PanelInformation_BottomRightColumn, 1, 0)
            Me.TableLayoutPanelBottomColumn_Information.Controls.Add(Me.PanelInformation_BottomLeftColumn, 0, 0)
            Me.TableLayoutPanelBottomColumn_Information.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanelBottomColumn_Information.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanelBottomColumn_Information.Name = "TableLayoutPanelBottomColumn_Information"
            Me.TableLayoutPanelBottomColumn_Information.RowCount = 1
            Me.TableLayoutPanelBottomColumn_Information.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelBottomColumn_Information.Size = New System.Drawing.Size(723, 227)
            Me.TableLayoutPanelBottomColumn_Information.TabIndex = 0
            '
            'PanelInformation_BottomRightColumn
            '
            Me.PanelInformation_BottomRightColumn.Controls.Add(Me.ButtonPayToNameAndAddress_Refresh)
            Me.PanelInformation_BottomRightColumn.Controls.Add(Me.AddressControlInformationBottomRightColumn_MailingAddress)
            Me.PanelInformation_BottomRightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelInformation_BottomRightColumn.Location = New System.Drawing.Point(361, 0)
            Me.PanelInformation_BottomRightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelInformation_BottomRightColumn.Name = "PanelInformation_BottomRightColumn"
            Me.PanelInformation_BottomRightColumn.Size = New System.Drawing.Size(362, 227)
            Me.PanelInformation_BottomRightColumn.TabIndex = 3
            '
            'ButtonPayToNameAndAddress_Refresh
            '
            Me.ButtonPayToNameAndAddress_Refresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPayToNameAndAddress_Refresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonPayToNameAndAddress_Refresh.AutoExpandOnClick = True
            Me.ButtonPayToNameAndAddress_Refresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPayToNameAndAddress_Refresh.Location = New System.Drawing.Point(281, 0)
            Me.ButtonPayToNameAndAddress_Refresh.Name = "ButtonPayToNameAndAddress_Refresh"
            Me.ButtonPayToNameAndAddress_Refresh.SecurityEnabled = True
            Me.ButtonPayToNameAndAddress_Refresh.Size = New System.Drawing.Size(75, 20)
            Me.ButtonPayToNameAndAddress_Refresh.SplitButton = True
            Me.ButtonPayToNameAndAddress_Refresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPayToNameAndAddress_Refresh.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRefresh_Home})
            Me.ButtonPayToNameAndAddress_Refresh.TabIndex = 0
            Me.ButtonPayToNameAndAddress_Refresh.Text = "Refresh"
            '
            'ButtonItemRefresh_Home
            '
            Me.ButtonItemRefresh_Home.Name = "ButtonItemRefresh_Home"
            Me.ButtonItemRefresh_Home.Text = "Home"
            '
            'AddressControlInformationBottomRightColumn_MailingAddress
            '
            Me.AddressControlInformationBottomRightColumn_MailingAddress.Address = Nothing
            Me.AddressControlInformationBottomRightColumn_MailingAddress.Address2 = Nothing
            Me.AddressControlInformationBottomRightColumn_MailingAddress.Address3 = Nothing
            Me.AddressControlInformationBottomRightColumn_MailingAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AddressControlInformationBottomRightColumn_MailingAddress.City = Nothing
            Me.AddressControlInformationBottomRightColumn_MailingAddress.Country = Nothing
            Me.AddressControlInformationBottomRightColumn_MailingAddress.County = Nothing
            Me.AddressControlInformationBottomRightColumn_MailingAddress.DisableCountry = False
            Me.AddressControlInformationBottomRightColumn_MailingAddress.DisableCounty = False
            Me.AddressControlInformationBottomRightColumn_MailingAddress.Location = New System.Drawing.Point(4, 26)
            Me.AddressControlInformationBottomRightColumn_MailingAddress.Name = "AddressControlInformationBottomRightColumn_MailingAddress"
            Me.AddressControlInformationBottomRightColumn_MailingAddress.ReadOnly = False
            Me.AddressControlInformationBottomRightColumn_MailingAddress.ShowCountry = True
            Me.AddressControlInformationBottomRightColumn_MailingAddress.ShowCounty = True
            Me.AddressControlInformationBottomRightColumn_MailingAddress.Size = New System.Drawing.Size(352, 181)
            Me.AddressControlInformationBottomRightColumn_MailingAddress.State = Nothing
            Me.AddressControlInformationBottomRightColumn_MailingAddress.TabIndex = 1
            Me.AddressControlInformationBottomRightColumn_MailingAddress.Title = "Mailing Address"
            Me.AddressControlInformationBottomRightColumn_MailingAddress.Zip = Nothing
            '
            'PanelInformation_BottomLeftColumn
            '
            Me.PanelInformation_BottomLeftColumn.Controls.Add(Me.AddressControlInformationBottomLeftColumn_HomeAddress)
            Me.PanelInformation_BottomLeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelInformation_BottomLeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelInformation_BottomLeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelInformation_BottomLeftColumn.Name = "PanelInformation_BottomLeftColumn"
            Me.PanelInformation_BottomLeftColumn.Size = New System.Drawing.Size(361, 227)
            Me.PanelInformation_BottomLeftColumn.TabIndex = 2
            '
            'AddressControlInformationBottomLeftColumn_HomeAddress
            '
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.Address = Nothing
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.Address2 = Nothing
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.Address3 = Nothing
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.City = Nothing
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.Country = Nothing
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.County = Nothing
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.DisableCountry = False
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.DisableCounty = False
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.Location = New System.Drawing.Point(6, 26)
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.Name = "AddressControlInformationBottomLeftColumn_HomeAddress"
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.ReadOnly = False
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.ShowCountry = True
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.ShowCounty = True
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.Size = New System.Drawing.Size(352, 181)
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.State = Nothing
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.TabIndex = 0
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.Title = "Home Address"
            Me.AddressControlInformationBottomLeftColumn_HomeAddress.Zip = Nothing
            '
            'PanelInformation_TopRightColumn
            '
            Me.PanelInformation_TopRightColumn.Controls.Add(Me.PictureBoxInformationTopRightColumn_EmployeeSignature)
            Me.PanelInformation_TopRightColumn.Controls.Add(Me.TextBoxInformation_EmployeeSignature)
            Me.PanelInformation_TopRightColumn.Controls.Add(Me.LabelInformationTopRightColumn_MaxSize)
            Me.PanelInformation_TopRightColumn.Controls.Add(Me.LabelInformationTopRightColumn_ImageDimensions)
            Me.PanelInformation_TopRightColumn.Controls.Add(Me.LabelInformationTopRightColumn_EmployeeSignature)
            Me.PanelInformation_TopRightColumn.Controls.Add(Me.ButtonInformationTopRightColumn_DeleteSignatureImage)
            Me.PanelInformation_TopRightColumn.Controls.Add(Me.ButtonInformationTopRightColumn_SelectSignatureImage)
            Me.PanelInformation_TopRightColumn.Controls.Add(Me.LabelInformationTopRightColumn_SignatureNotes)
            Me.PanelInformation_TopRightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelInformation_TopRightColumn.Location = New System.Drawing.Point(258, 0)
            Me.PanelInformation_TopRightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelInformation_TopRightColumn.Name = "PanelInformation_TopRightColumn"
            Me.PanelInformation_TopRightColumn.Size = New System.Drawing.Size(465, 130)
            Me.PanelInformation_TopRightColumn.TabIndex = 1
            '
            'PictureBoxInformationTopRightColumn_EmployeeSignature
            '
            Me.PictureBoxInformationTopRightColumn_EmployeeSignature.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PictureBoxInformationTopRightColumn_EmployeeSignature.Location = New System.Drawing.Point(3, 26)
            Me.PictureBoxInformationTopRightColumn_EmployeeSignature.Name = "PictureBoxInformationTopRightColumn_EmployeeSignature"
            Me.PictureBoxInformationTopRightColumn_EmployeeSignature.Size = New System.Drawing.Size(247, 98)
            Me.PictureBoxInformationTopRightColumn_EmployeeSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.PictureBoxInformationTopRightColumn_EmployeeSignature.TabIndex = 114
            Me.PictureBoxInformationTopRightColumn_EmployeeSignature.TabStop = False
            '
            'TextBoxInformation_EmployeeSignature
            '
            Me.TextBoxInformation_EmployeeSignature.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxInformation_EmployeeSignature.Border.Class = "TextBoxBorder"
            Me.TextBoxInformation_EmployeeSignature.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxInformation_EmployeeSignature.CheckSpellingOnValidate = False
            Me.TextBoxInformation_EmployeeSignature.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxInformation_EmployeeSignature.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxInformation_EmployeeSignature.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxInformation_EmployeeSignature.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxInformation_EmployeeSignature.FocusHighlightEnabled = True
            Me.TextBoxInformation_EmployeeSignature.ForeColor = System.Drawing.Color.Black
            Me.TextBoxInformation_EmployeeSignature.Location = New System.Drawing.Point(82, 75)
            Me.TextBoxInformation_EmployeeSignature.MaxFileSize = CType(0, Long)
            Me.TextBoxInformation_EmployeeSignature.Name = "TextBoxInformation_EmployeeSignature"
            Me.TextBoxInformation_EmployeeSignature.SecurityEnabled = True
            Me.TextBoxInformation_EmployeeSignature.ShowSpellCheckCompleteMessage = True
            Me.TextBoxInformation_EmployeeSignature.Size = New System.Drawing.Size(100, 21)
            Me.TextBoxInformation_EmployeeSignature.StartingFolderName = Nothing
            Me.TextBoxInformation_EmployeeSignature.TabIndex = 115
            Me.TextBoxInformation_EmployeeSignature.TabOnEnter = True
            '
            'LabelInformationTopRightColumn_MaxSize
            '
            Me.LabelInformationTopRightColumn_MaxSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelInformationTopRightColumn_MaxSize.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformationTopRightColumn_MaxSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformationTopRightColumn_MaxSize.Location = New System.Drawing.Point(256, 78)
            Me.LabelInformationTopRightColumn_MaxSize.Name = "LabelInformationTopRightColumn_MaxSize"
            Me.LabelInformationTopRightColumn_MaxSize.Size = New System.Drawing.Size(201, 20)
            Me.LabelInformationTopRightColumn_MaxSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformationTopRightColumn_MaxSize.TabIndex = 3
            Me.LabelInformationTopRightColumn_MaxSize.Text = "Maximum size is 32765 Bytes (32.7K)"
            '
            'LabelInformationTopRightColumn_ImageDimensions
            '
            Me.LabelInformationTopRightColumn_ImageDimensions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelInformationTopRightColumn_ImageDimensions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformationTopRightColumn_ImageDimensions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformationTopRightColumn_ImageDimensions.Location = New System.Drawing.Point(256, 52)
            Me.LabelInformationTopRightColumn_ImageDimensions.Name = "LabelInformationTopRightColumn_ImageDimensions"
            Me.LabelInformationTopRightColumn_ImageDimensions.Size = New System.Drawing.Size(201, 20)
            Me.LabelInformationTopRightColumn_ImageDimensions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformationTopRightColumn_ImageDimensions.TabIndex = 2
            Me.LabelInformationTopRightColumn_ImageDimensions.Text = "Image dimensions must be 2 3/4 x 3/4."
            '
            'LabelInformationTopRightColumn_EmployeeSignature
            '
            Me.LabelInformationTopRightColumn_EmployeeSignature.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelInformationTopRightColumn_EmployeeSignature.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformationTopRightColumn_EmployeeSignature.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelInformationTopRightColumn_EmployeeSignature.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelInformationTopRightColumn_EmployeeSignature.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelInformationTopRightColumn_EmployeeSignature.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelInformationTopRightColumn_EmployeeSignature.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelInformationTopRightColumn_EmployeeSignature.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelInformationTopRightColumn_EmployeeSignature.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformationTopRightColumn_EmployeeSignature.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelInformationTopRightColumn_EmployeeSignature.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelInformationTopRightColumn_EmployeeSignature.Location = New System.Drawing.Point(3, 0)
            Me.LabelInformationTopRightColumn_EmployeeSignature.Name = "LabelInformationTopRightColumn_EmployeeSignature"
            Me.LabelInformationTopRightColumn_EmployeeSignature.Size = New System.Drawing.Size(456, 20)
            Me.LabelInformationTopRightColumn_EmployeeSignature.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformationTopRightColumn_EmployeeSignature.TabIndex = 0
            Me.LabelInformationTopRightColumn_EmployeeSignature.Text = "Employee Signature"
            '
            'ButtonInformationTopRightColumn_DeleteSignatureImage
            '
            Me.ButtonInformationTopRightColumn_DeleteSignatureImage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonInformationTopRightColumn_DeleteSignatureImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonInformationTopRightColumn_DeleteSignatureImage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonInformationTopRightColumn_DeleteSignatureImage.Location = New System.Drawing.Point(337, 104)
            Me.ButtonInformationTopRightColumn_DeleteSignatureImage.Name = "ButtonInformationTopRightColumn_DeleteSignatureImage"
            Me.ButtonInformationTopRightColumn_DeleteSignatureImage.SecurityEnabled = True
            Me.ButtonInformationTopRightColumn_DeleteSignatureImage.Size = New System.Drawing.Size(75, 20)
            Me.ButtonInformationTopRightColumn_DeleteSignatureImage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonInformationTopRightColumn_DeleteSignatureImage.TabIndex = 5
            Me.ButtonInformationTopRightColumn_DeleteSignatureImage.Text = "Delete"
            '
            'ButtonInformationTopRightColumn_SelectSignatureImage
            '
            Me.ButtonInformationTopRightColumn_SelectSignatureImage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonInformationTopRightColumn_SelectSignatureImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonInformationTopRightColumn_SelectSignatureImage.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonInformationTopRightColumn_SelectSignatureImage.Location = New System.Drawing.Point(256, 104)
            Me.ButtonInformationTopRightColumn_SelectSignatureImage.Name = "ButtonInformationTopRightColumn_SelectSignatureImage"
            Me.ButtonInformationTopRightColumn_SelectSignatureImage.SecurityEnabled = True
            Me.ButtonInformationTopRightColumn_SelectSignatureImage.Size = New System.Drawing.Size(75, 20)
            Me.ButtonInformationTopRightColumn_SelectSignatureImage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonInformationTopRightColumn_SelectSignatureImage.TabIndex = 4
            Me.ButtonInformationTopRightColumn_SelectSignatureImage.Text = "Select"
            '
            'LabelInformationTopRightColumn_SignatureNotes
            '
            Me.LabelInformationTopRightColumn_SignatureNotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelInformationTopRightColumn_SignatureNotes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformationTopRightColumn_SignatureNotes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformationTopRightColumn_SignatureNotes.Location = New System.Drawing.Point(256, 26)
            Me.LabelInformationTopRightColumn_SignatureNotes.Name = "LabelInformationTopRightColumn_SignatureNotes"
            Me.LabelInformationTopRightColumn_SignatureNotes.Size = New System.Drawing.Size(201, 20)
            Me.LabelInformationTopRightColumn_SignatureNotes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformationTopRightColumn_SignatureNotes.TabIndex = 1
            Me.LabelInformationTopRightColumn_SignatureNotes.Text = "Types: .gif, .jpg, .jpeg, .png or .bmp."
            '
            'PanelInformation_TopLeftColumn
            '
            Me.PanelInformation_TopLeftColumn.Controls.Add(Me.LabelInformationTopLeftColumn_PhoneNumbers)
            Me.PanelInformation_TopLeftColumn.Controls.Add(Me.LabelInformationTopLeftColumn_Home)
            Me.PanelInformation_TopLeftColumn.Controls.Add(Me.TextBoxInformationTopLeftColumn_AlternatePhone)
            Me.PanelInformation_TopLeftColumn.Controls.Add(Me.LabelInformationTopLeftColumn_WorkExt)
            Me.PanelInformation_TopLeftColumn.Controls.Add(Me.TextBoxInformationTopLeftColumn_CellPhone)
            Me.PanelInformation_TopLeftColumn.Controls.Add(Me.TextBoxInformationTopLeftColumn_WorkPhone)
            Me.PanelInformation_TopLeftColumn.Controls.Add(Me.TextBoxInformationTopLeftColumn_HomePhone)
            Me.PanelInformation_TopLeftColumn.Controls.Add(Me.LabelInformationTopLeftColumn_AlternatePhone)
            Me.PanelInformation_TopLeftColumn.Controls.Add(Me.TextBoxInformationTopLeftColumn_WorkPhoneExt)
            Me.PanelInformation_TopLeftColumn.Controls.Add(Me.LabelInformationTopLeftColumn_Cell)
            Me.PanelInformation_TopLeftColumn.Controls.Add(Me.LabelInformationTopLeftColumn_Work)
            Me.PanelInformation_TopLeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelInformation_TopLeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelInformation_TopLeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelInformation_TopLeftColumn.Name = "PanelInformation_TopLeftColumn"
            Me.PanelInformation_TopLeftColumn.Size = New System.Drawing.Size(258, 130)
            Me.PanelInformation_TopLeftColumn.TabIndex = 0
            '
            'LabelInformationTopLeftColumn_PhoneNumbers
            '
            Me.LabelInformationTopLeftColumn_PhoneNumbers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelInformationTopLeftColumn_PhoneNumbers.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformationTopLeftColumn_PhoneNumbers.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelInformationTopLeftColumn_PhoneNumbers.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelInformationTopLeftColumn_PhoneNumbers.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelInformationTopLeftColumn_PhoneNumbers.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelInformationTopLeftColumn_PhoneNumbers.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelInformationTopLeftColumn_PhoneNumbers.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelInformationTopLeftColumn_PhoneNumbers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformationTopLeftColumn_PhoneNumbers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelInformationTopLeftColumn_PhoneNumbers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelInformationTopLeftColumn_PhoneNumbers.Location = New System.Drawing.Point(6, 0)
            Me.LabelInformationTopLeftColumn_PhoneNumbers.Name = "LabelInformationTopLeftColumn_PhoneNumbers"
            Me.LabelInformationTopLeftColumn_PhoneNumbers.Size = New System.Drawing.Size(250, 20)
            Me.LabelInformationTopLeftColumn_PhoneNumbers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformationTopLeftColumn_PhoneNumbers.TabIndex = 0
            Me.LabelInformationTopLeftColumn_PhoneNumbers.Text = "Phone Numbers"
            '
            'LabelInformationTopLeftColumn_Home
            '
            Me.LabelInformationTopLeftColumn_Home.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformationTopLeftColumn_Home.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformationTopLeftColumn_Home.Location = New System.Drawing.Point(6, 26)
            Me.LabelInformationTopLeftColumn_Home.Name = "LabelInformationTopLeftColumn_Home"
            Me.LabelInformationTopLeftColumn_Home.Size = New System.Drawing.Size(59, 20)
            Me.LabelInformationTopLeftColumn_Home.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformationTopLeftColumn_Home.TabIndex = 1
            Me.LabelInformationTopLeftColumn_Home.Text = "Home:"
            '
            'TextBoxInformationTopLeftColumn_AlternatePhone
            '
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.Border.Class = "TextBoxBorder"
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.CheckSpellingOnValidate = False
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.FocusHighlightEnabled = True
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.ForeColor = System.Drawing.Color.Black
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.Location = New System.Drawing.Point(71, 104)
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.MaxFileSize = CType(0, Long)
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.Name = "TextBoxInformationTopLeftColumn_AlternatePhone"
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.SecurityEnabled = True
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.ShowSpellCheckCompleteMessage = True
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.Size = New System.Drawing.Size(99, 21)
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.StartingFolderName = Nothing
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.TabIndex = 10
            Me.TextBoxInformationTopLeftColumn_AlternatePhone.TabOnEnter = True
            '
            'LabelInformationTopLeftColumn_WorkExt
            '
            Me.LabelInformationTopLeftColumn_WorkExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelInformationTopLeftColumn_WorkExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformationTopLeftColumn_WorkExt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformationTopLeftColumn_WorkExt.Location = New System.Drawing.Point(176, 52)
            Me.LabelInformationTopLeftColumn_WorkExt.Name = "LabelInformationTopLeftColumn_WorkExt"
            Me.LabelInformationTopLeftColumn_WorkExt.Size = New System.Drawing.Size(28, 20)
            Me.LabelInformationTopLeftColumn_WorkExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformationTopLeftColumn_WorkExt.TabIndex = 5
            Me.LabelInformationTopLeftColumn_WorkExt.Text = "Ext:"
            '
            'TextBoxInformationTopLeftColumn_CellPhone
            '
            Me.TextBoxInformationTopLeftColumn_CellPhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxInformationTopLeftColumn_CellPhone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxInformationTopLeftColumn_CellPhone.Border.Class = "TextBoxBorder"
            Me.TextBoxInformationTopLeftColumn_CellPhone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxInformationTopLeftColumn_CellPhone.CheckSpellingOnValidate = False
            Me.TextBoxInformationTopLeftColumn_CellPhone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxInformationTopLeftColumn_CellPhone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxInformationTopLeftColumn_CellPhone.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxInformationTopLeftColumn_CellPhone.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxInformationTopLeftColumn_CellPhone.FocusHighlightEnabled = True
            Me.TextBoxInformationTopLeftColumn_CellPhone.ForeColor = System.Drawing.Color.Black
            Me.TextBoxInformationTopLeftColumn_CellPhone.Location = New System.Drawing.Point(71, 78)
            Me.TextBoxInformationTopLeftColumn_CellPhone.MaxFileSize = CType(0, Long)
            Me.TextBoxInformationTopLeftColumn_CellPhone.Name = "TextBoxInformationTopLeftColumn_CellPhone"
            Me.TextBoxInformationTopLeftColumn_CellPhone.SecurityEnabled = True
            Me.TextBoxInformationTopLeftColumn_CellPhone.ShowSpellCheckCompleteMessage = True
            Me.TextBoxInformationTopLeftColumn_CellPhone.Size = New System.Drawing.Size(99, 21)
            Me.TextBoxInformationTopLeftColumn_CellPhone.StartingFolderName = Nothing
            Me.TextBoxInformationTopLeftColumn_CellPhone.TabIndex = 8
            Me.TextBoxInformationTopLeftColumn_CellPhone.TabOnEnter = True
            '
            'TextBoxInformationTopLeftColumn_WorkPhone
            '
            Me.TextBoxInformationTopLeftColumn_WorkPhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxInformationTopLeftColumn_WorkPhone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxInformationTopLeftColumn_WorkPhone.Border.Class = "TextBoxBorder"
            Me.TextBoxInformationTopLeftColumn_WorkPhone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxInformationTopLeftColumn_WorkPhone.CheckSpellingOnValidate = False
            Me.TextBoxInformationTopLeftColumn_WorkPhone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxInformationTopLeftColumn_WorkPhone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxInformationTopLeftColumn_WorkPhone.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxInformationTopLeftColumn_WorkPhone.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxInformationTopLeftColumn_WorkPhone.FocusHighlightEnabled = True
            Me.TextBoxInformationTopLeftColumn_WorkPhone.ForeColor = System.Drawing.Color.Black
            Me.TextBoxInformationTopLeftColumn_WorkPhone.Location = New System.Drawing.Point(71, 52)
            Me.TextBoxInformationTopLeftColumn_WorkPhone.MaxFileSize = CType(0, Long)
            Me.TextBoxInformationTopLeftColumn_WorkPhone.Name = "TextBoxInformationTopLeftColumn_WorkPhone"
            Me.TextBoxInformationTopLeftColumn_WorkPhone.SecurityEnabled = True
            Me.TextBoxInformationTopLeftColumn_WorkPhone.ShowSpellCheckCompleteMessage = True
            Me.TextBoxInformationTopLeftColumn_WorkPhone.Size = New System.Drawing.Size(99, 21)
            Me.TextBoxInformationTopLeftColumn_WorkPhone.StartingFolderName = Nothing
            Me.TextBoxInformationTopLeftColumn_WorkPhone.TabIndex = 4
            Me.TextBoxInformationTopLeftColumn_WorkPhone.TabOnEnter = True
            '
            'TextBoxInformationTopLeftColumn_HomePhone
            '
            Me.TextBoxInformationTopLeftColumn_HomePhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxInformationTopLeftColumn_HomePhone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxInformationTopLeftColumn_HomePhone.Border.Class = "TextBoxBorder"
            Me.TextBoxInformationTopLeftColumn_HomePhone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxInformationTopLeftColumn_HomePhone.CheckSpellingOnValidate = False
            Me.TextBoxInformationTopLeftColumn_HomePhone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxInformationTopLeftColumn_HomePhone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxInformationTopLeftColumn_HomePhone.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxInformationTopLeftColumn_HomePhone.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxInformationTopLeftColumn_HomePhone.FocusHighlightEnabled = True
            Me.TextBoxInformationTopLeftColumn_HomePhone.ForeColor = System.Drawing.Color.Black
            Me.TextBoxInformationTopLeftColumn_HomePhone.Location = New System.Drawing.Point(71, 26)
            Me.TextBoxInformationTopLeftColumn_HomePhone.MaxFileSize = CType(0, Long)
            Me.TextBoxInformationTopLeftColumn_HomePhone.Name = "TextBoxInformationTopLeftColumn_HomePhone"
            Me.TextBoxInformationTopLeftColumn_HomePhone.SecurityEnabled = True
            Me.TextBoxInformationTopLeftColumn_HomePhone.ShowSpellCheckCompleteMessage = True
            Me.TextBoxInformationTopLeftColumn_HomePhone.Size = New System.Drawing.Size(99, 21)
            Me.TextBoxInformationTopLeftColumn_HomePhone.StartingFolderName = Nothing
            Me.TextBoxInformationTopLeftColumn_HomePhone.TabIndex = 2
            Me.TextBoxInformationTopLeftColumn_HomePhone.TabOnEnter = True
            '
            'LabelInformationTopLeftColumn_AlternatePhone
            '
            Me.LabelInformationTopLeftColumn_AlternatePhone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformationTopLeftColumn_AlternatePhone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformationTopLeftColumn_AlternatePhone.Location = New System.Drawing.Point(6, 104)
            Me.LabelInformationTopLeftColumn_AlternatePhone.Name = "LabelInformationTopLeftColumn_AlternatePhone"
            Me.LabelInformationTopLeftColumn_AlternatePhone.Size = New System.Drawing.Size(59, 20)
            Me.LabelInformationTopLeftColumn_AlternatePhone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformationTopLeftColumn_AlternatePhone.TabIndex = 9
            Me.LabelInformationTopLeftColumn_AlternatePhone.Text = "Alternate:"
            '
            'TextBoxInformationTopLeftColumn_WorkPhoneExt
            '
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.Border.Class = "TextBoxBorder"
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.CheckSpellingOnValidate = False
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.FocusHighlightEnabled = True
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.ForeColor = System.Drawing.Color.Black
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.Location = New System.Drawing.Point(210, 52)
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.MaxFileSize = CType(0, Long)
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.Name = "TextBoxInformationTopLeftColumn_WorkPhoneExt"
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.SecurityEnabled = True
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.ShowSpellCheckCompleteMessage = True
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.Size = New System.Drawing.Size(45, 21)
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.StartingFolderName = Nothing
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.TabIndex = 6
            Me.TextBoxInformationTopLeftColumn_WorkPhoneExt.TabOnEnter = True
            '
            'LabelInformationTopLeftColumn_Cell
            '
            Me.LabelInformationTopLeftColumn_Cell.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformationTopLeftColumn_Cell.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformationTopLeftColumn_Cell.Location = New System.Drawing.Point(6, 78)
            Me.LabelInformationTopLeftColumn_Cell.Name = "LabelInformationTopLeftColumn_Cell"
            Me.LabelInformationTopLeftColumn_Cell.Size = New System.Drawing.Size(59, 20)
            Me.LabelInformationTopLeftColumn_Cell.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformationTopLeftColumn_Cell.TabIndex = 7
            Me.LabelInformationTopLeftColumn_Cell.Text = "Cell:"
            '
            'LabelInformationTopLeftColumn_Work
            '
            Me.LabelInformationTopLeftColumn_Work.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformationTopLeftColumn_Work.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformationTopLeftColumn_Work.Location = New System.Drawing.Point(6, 52)
            Me.LabelInformationTopLeftColumn_Work.Name = "LabelInformationTopLeftColumn_Work"
            Me.LabelInformationTopLeftColumn_Work.Size = New System.Drawing.Size(59, 20)
            Me.LabelInformationTopLeftColumn_Work.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformationTopLeftColumn_Work.TabIndex = 3
            Me.LabelInformationTopLeftColumn_Work.Text = "Work:"
            '
            'TabItemEmployeeGeneralInformation_InformationTab
            '
            Me.TabItemEmployeeGeneralInformation_InformationTab.AttachedControl = Me.TabControlPanelInformationTab_Information
            Me.TabItemEmployeeGeneralInformation_InformationTab.Name = "TabItemEmployeeGeneralInformation_InformationTab"
            Me.TabItemEmployeeGeneralInformation_InformationTab.Text = "Information"
            '
            'TabControlDepartmentTeamTab_DepartmentTeam
            '
            Me.TabControlDepartmentTeamTab_DepartmentTeam.Controls.Add(Me.PanelDepartmentTeam_RightSection)
            Me.TabControlDepartmentTeamTab_DepartmentTeam.Controls.Add(Me.ExpandableSplitterControlDepartmentTeam_LeftRight)
            Me.TabControlDepartmentTeamTab_DepartmentTeam.Controls.Add(Me.PanelDepartmentTeam_LeftSection)
            Me.TabControlDepartmentTeamTab_DepartmentTeam.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlDepartmentTeamTab_DepartmentTeam.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlDepartmentTeamTab_DepartmentTeam.Location = New System.Drawing.Point(0, 27)
            Me.TabControlDepartmentTeamTab_DepartmentTeam.Name = "TabControlDepartmentTeamTab_DepartmentTeam"
            Me.TabControlDepartmentTeamTab_DepartmentTeam.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlDepartmentTeamTab_DepartmentTeam.Size = New System.Drawing.Size(725, 405)
            Me.TabControlDepartmentTeamTab_DepartmentTeam.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlDepartmentTeamTab_DepartmentTeam.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlDepartmentTeamTab_DepartmentTeam.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlDepartmentTeamTab_DepartmentTeam.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlDepartmentTeamTab_DepartmentTeam.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlDepartmentTeamTab_DepartmentTeam.Style.GradientAngle = 90
            Me.TabControlDepartmentTeamTab_DepartmentTeam.TabIndex = 1
            Me.TabControlDepartmentTeamTab_DepartmentTeam.TabItem = Me.TabItemEmployeeGeneralInformation_DepartmentTeamTab
            '
            'PanelDepartmentTeam_RightSection
            '
            Me.PanelDepartmentTeam_RightSection.Controls.Add(Me.ButtonRightSection_RemoveDepartmentTeam)
            Me.PanelDepartmentTeam_RightSection.Controls.Add(Me.ButtonRightSection_AddDepartmentTeam)
            Me.PanelDepartmentTeam_RightSection.Controls.Add(Me.TextBoxRightSection_DefaultDepartmentTeam)
            Me.PanelDepartmentTeam_RightSection.Controls.Add(Me.DataGridViewRightSection_EmployeeDepartmentTeams)
            Me.PanelDepartmentTeam_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelDepartmentTeam_RightSection.Location = New System.Drawing.Point(313, 1)
            Me.PanelDepartmentTeam_RightSection.Name = "PanelDepartmentTeam_RightSection"
            Me.PanelDepartmentTeam_RightSection.Size = New System.Drawing.Size(411, 403)
            Me.PanelDepartmentTeam_RightSection.TabIndex = 1
            '
            'ButtonRightSection_RemoveDepartmentTeam
            '
            Me.ButtonRightSection_RemoveDepartmentTeam.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveDepartmentTeam.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveDepartmentTeam.Location = New System.Drawing.Point(6, 32)
            Me.ButtonRightSection_RemoveDepartmentTeam.Name = "ButtonRightSection_RemoveDepartmentTeam"
            Me.ButtonRightSection_RemoveDepartmentTeam.SecurityEnabled = True
            Me.ButtonRightSection_RemoveDepartmentTeam.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveDepartmentTeam.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveDepartmentTeam.TabIndex = 1
            Me.ButtonRightSection_RemoveDepartmentTeam.Text = "<"
            '
            'ButtonRightSection_AddDepartmentTeam
            '
            Me.ButtonRightSection_AddDepartmentTeam.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddDepartmentTeam.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddDepartmentTeam.Location = New System.Drawing.Point(6, 6)
            Me.ButtonRightSection_AddDepartmentTeam.Name = "ButtonRightSection_AddDepartmentTeam"
            Me.ButtonRightSection_AddDepartmentTeam.SecurityEnabled = True
            Me.ButtonRightSection_AddDepartmentTeam.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddDepartmentTeam.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddDepartmentTeam.TabIndex = 0
            Me.ButtonRightSection_AddDepartmentTeam.Text = ">"
            '
            'TextBoxRightSection_DefaultDepartmentTeam
            '
            Me.TextBoxRightSection_DefaultDepartmentTeam.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxRightSection_DefaultDepartmentTeam.Border.Class = "TextBoxBorder"
            Me.TextBoxRightSection_DefaultDepartmentTeam.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRightSection_DefaultDepartmentTeam.CheckSpellingOnValidate = False
            Me.TextBoxRightSection_DefaultDepartmentTeam.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRightSection_DefaultDepartmentTeam.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxRightSection_DefaultDepartmentTeam.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRightSection_DefaultDepartmentTeam.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRightSection_DefaultDepartmentTeam.FocusHighlightEnabled = True
            Me.TextBoxRightSection_DefaultDepartmentTeam.ForeColor = System.Drawing.Color.Black
            Me.TextBoxRightSection_DefaultDepartmentTeam.Location = New System.Drawing.Point(6, 59)
            Me.TextBoxRightSection_DefaultDepartmentTeam.MaxFileSize = CType(0, Long)
            Me.TextBoxRightSection_DefaultDepartmentTeam.Name = "TextBoxRightSection_DefaultDepartmentTeam"
            Me.TextBoxRightSection_DefaultDepartmentTeam.ReadOnly = True
            Me.TextBoxRightSection_DefaultDepartmentTeam.SecurityEnabled = True
            Me.TextBoxRightSection_DefaultDepartmentTeam.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRightSection_DefaultDepartmentTeam.Size = New System.Drawing.Size(75, 21)
            Me.TextBoxRightSection_DefaultDepartmentTeam.StartingFolderName = Nothing
            Me.TextBoxRightSection_DefaultDepartmentTeam.TabIndex = 112
            Me.TextBoxRightSection_DefaultDepartmentTeam.TabOnEnter = True
            Me.TextBoxRightSection_DefaultDepartmentTeam.Visible = False
            '
            'DataGridViewRightSection_EmployeeDepartmentTeams
            '
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.AllowDragAndDrop = False
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.ItemDescription = ""
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.Location = New System.Drawing.Point(87, 6)
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.MultiSelect = True
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.Name = "DataGridViewRightSection_EmployeeDepartmentTeams"
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.RunStandardValidation = True
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.Size = New System.Drawing.Size(317, 391)
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.TabIndex = 2
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_EmployeeDepartmentTeams.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlDepartmentTeam_LeftRight
            '
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.ExpandableControl = Me.PanelDepartmentTeam_LeftSection
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.Location = New System.Drawing.Point(307, 1)
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.Name = "ExpandableSplitterControlDepartmentTeam_LeftRight"
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.Size = New System.Drawing.Size(6, 403)
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.TabIndex = 1
            Me.ExpandableSplitterControlDepartmentTeam_LeftRight.TabStop = False
            '
            'PanelDepartmentTeam_LeftSection
            '
            Me.PanelDepartmentTeam_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableDepartmentTeam)
            Me.PanelDepartmentTeam_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelDepartmentTeam_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelDepartmentTeam_LeftSection.Name = "PanelDepartmentTeam_LeftSection"
            Me.PanelDepartmentTeam_LeftSection.Size = New System.Drawing.Size(306, 403)
            Me.PanelDepartmentTeam_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_AvailableDepartmentTeam
            '
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.ItemDescription = ""
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.Name = "DataGridViewLeftSection_AvailableDepartmentTeam"
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.RunStandardValidation = True
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.Size = New System.Drawing.Size(294, 391)
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.TabIndex = 1
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableDepartmentTeam.ViewCaptionHeight = -1
            '
            'TabItemEmployeeGeneralInformation_DepartmentTeamTab
            '
            Me.TabItemEmployeeGeneralInformation_DepartmentTeamTab.AttachedControl = Me.TabControlDepartmentTeamTab_DepartmentTeam
            Me.TabItemEmployeeGeneralInformation_DepartmentTeamTab.Name = "TabItemEmployeeGeneralInformation_DepartmentTeamTab"
            Me.TabItemEmployeeGeneralInformation_DepartmentTeamTab.Text = "Department / Team"
            '
            'TabControlPanelRolesTab_Roles
            '
            Me.TabControlPanelRolesTab_Roles.Controls.Add(Me.PanelRoles_RightSection)
            Me.TabControlPanelRolesTab_Roles.Controls.Add(Me.ExpandableSplitterControlRoles_LeftRight)
            Me.TabControlPanelRolesTab_Roles.Controls.Add(Me.PanelRoles_LeftSection)
            Me.TabControlPanelRolesTab_Roles.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelRolesTab_Roles.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRolesTab_Roles.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRolesTab_Roles.Name = "TabControlPanelRolesTab_Roles"
            Me.TabControlPanelRolesTab_Roles.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRolesTab_Roles.Size = New System.Drawing.Size(725, 405)
            Me.TabControlPanelRolesTab_Roles.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelRolesTab_Roles.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRolesTab_Roles.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRolesTab_Roles.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRolesTab_Roles.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRolesTab_Roles.Style.GradientAngle = 90
            Me.TabControlPanelRolesTab_Roles.TabIndex = 2
            Me.TabControlPanelRolesTab_Roles.TabItem = Me.TabItemEmployeeGeneralInformation_RolesTab
            '
            'PanelRoles_RightSection
            '
            Me.PanelRoles_RightSection.Controls.Add(Me.TextBoxRightSection_DefaultRole)
            Me.PanelRoles_RightSection.Controls.Add(Me.ButtonRightSection_RemoveRole)
            Me.PanelRoles_RightSection.Controls.Add(Me.ButtonRightSection_AddRole)
            Me.PanelRoles_RightSection.Controls.Add(Me.DataGridViewRightSection_EmployeeRoles)
            Me.PanelRoles_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelRoles_RightSection.Location = New System.Drawing.Point(313, 1)
            Me.PanelRoles_RightSection.Name = "PanelRoles_RightSection"
            Me.PanelRoles_RightSection.Size = New System.Drawing.Size(411, 403)
            Me.PanelRoles_RightSection.TabIndex = 1
            '
            'TextBoxRightSection_DefaultRole
            '
            Me.TextBoxRightSection_DefaultRole.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxRightSection_DefaultRole.Border.Class = "TextBoxBorder"
            Me.TextBoxRightSection_DefaultRole.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRightSection_DefaultRole.CheckSpellingOnValidate = False
            Me.TextBoxRightSection_DefaultRole.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRightSection_DefaultRole.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxRightSection_DefaultRole.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRightSection_DefaultRole.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRightSection_DefaultRole.FocusHighlightEnabled = True
            Me.TextBoxRightSection_DefaultRole.ForeColor = System.Drawing.Color.Black
            Me.TextBoxRightSection_DefaultRole.Location = New System.Drawing.Point(6, 59)
            Me.TextBoxRightSection_DefaultRole.MaxFileSize = CType(0, Long)
            Me.TextBoxRightSection_DefaultRole.Name = "TextBoxRightSection_DefaultRole"
            Me.TextBoxRightSection_DefaultRole.ReadOnly = True
            Me.TextBoxRightSection_DefaultRole.SecurityEnabled = True
            Me.TextBoxRightSection_DefaultRole.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRightSection_DefaultRole.Size = New System.Drawing.Size(75, 21)
            Me.TextBoxRightSection_DefaultRole.StartingFolderName = Nothing
            Me.TextBoxRightSection_DefaultRole.TabIndex = 117
            Me.TextBoxRightSection_DefaultRole.TabOnEnter = True
            Me.TextBoxRightSection_DefaultRole.Visible = False
            '
            'ButtonRightSection_RemoveRole
            '
            Me.ButtonRightSection_RemoveRole.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveRole.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveRole.Location = New System.Drawing.Point(6, 32)
            Me.ButtonRightSection_RemoveRole.Name = "ButtonRightSection_RemoveRole"
            Me.ButtonRightSection_RemoveRole.SecurityEnabled = True
            Me.ButtonRightSection_RemoveRole.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveRole.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveRole.TabIndex = 1
            Me.ButtonRightSection_RemoveRole.Text = "<"
            '
            'ButtonRightSection_AddRole
            '
            Me.ButtonRightSection_AddRole.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddRole.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddRole.Location = New System.Drawing.Point(6, 6)
            Me.ButtonRightSection_AddRole.Name = "ButtonRightSection_AddRole"
            Me.ButtonRightSection_AddRole.SecurityEnabled = True
            Me.ButtonRightSection_AddRole.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddRole.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddRole.TabIndex = 0
            Me.ButtonRightSection_AddRole.Text = ">"
            '
            'DataGridViewRightSection_EmployeeRoles
            '
            Me.DataGridViewRightSection_EmployeeRoles.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightSection_EmployeeRoles.AllowDragAndDrop = False
            Me.DataGridViewRightSection_EmployeeRoles.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_EmployeeRoles.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_EmployeeRoles.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_EmployeeRoles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_EmployeeRoles.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_EmployeeRoles.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_EmployeeRoles.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_EmployeeRoles.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_EmployeeRoles.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_EmployeeRoles.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_EmployeeRoles.ItemDescription = ""
            Me.DataGridViewRightSection_EmployeeRoles.Location = New System.Drawing.Point(87, 6)
            Me.DataGridViewRightSection_EmployeeRoles.MultiSelect = True
            Me.DataGridViewRightSection_EmployeeRoles.Name = "DataGridViewRightSection_EmployeeRoles"
            Me.DataGridViewRightSection_EmployeeRoles.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_EmployeeRoles.RunStandardValidation = True
            Me.DataGridViewRightSection_EmployeeRoles.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightSection_EmployeeRoles.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_EmployeeRoles.Size = New System.Drawing.Size(317, 391)
            Me.DataGridViewRightSection_EmployeeRoles.TabIndex = 2
            Me.DataGridViewRightSection_EmployeeRoles.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_EmployeeRoles.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlRoles_LeftRight
            '
            Me.ExpandableSplitterControlRoles_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlRoles_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRoles_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRoles_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlRoles_LeftRight.ExpandableControl = Me.PanelRoles_LeftSection
            Me.ExpandableSplitterControlRoles_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRoles_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRoles_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlRoles_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlRoles_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlRoles_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlRoles_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlRoles_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlRoles_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlRoles_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlRoles_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlRoles_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlRoles_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlRoles_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRoles_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRoles_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlRoles_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlRoles_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRoles_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRoles_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlRoles_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlRoles_LeftRight.Location = New System.Drawing.Point(307, 1)
            Me.ExpandableSplitterControlRoles_LeftRight.Name = "ExpandableSplitterControlRoles_LeftRight"
            Me.ExpandableSplitterControlRoles_LeftRight.Size = New System.Drawing.Size(6, 403)
            Me.ExpandableSplitterControlRoles_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlRoles_LeftRight.TabIndex = 1
            Me.ExpandableSplitterControlRoles_LeftRight.TabStop = False
            '
            'PanelRoles_LeftSection
            '
            Me.PanelRoles_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableRoles)
            Me.PanelRoles_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelRoles_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelRoles_LeftSection.Name = "PanelRoles_LeftSection"
            Me.PanelRoles_LeftSection.Size = New System.Drawing.Size(306, 403)
            Me.PanelRoles_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_AvailableRoles
            '
            Me.DataGridViewLeftSection_AvailableRoles.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_AvailableRoles.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_AvailableRoles.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_AvailableRoles.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableRoles.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableRoles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableRoles.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AvailableRoles.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AvailableRoles.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_AvailableRoles.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_AvailableRoles.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_AvailableRoles.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableRoles.ItemDescription = ""
            Me.DataGridViewLeftSection_AvailableRoles.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewLeftSection_AvailableRoles.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableRoles.Name = "DataGridViewLeftSection_AvailableRoles"
            Me.DataGridViewLeftSection_AvailableRoles.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableRoles.RunStandardValidation = True
            Me.DataGridViewLeftSection_AvailableRoles.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_AvailableRoles.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableRoles.Size = New System.Drawing.Size(294, 391)
            Me.DataGridViewLeftSection_AvailableRoles.TabIndex = 0
            Me.DataGridViewLeftSection_AvailableRoles.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableRoles.ViewCaptionHeight = -1
            '
            'TabItemEmployeeGeneralInformation_RolesTab
            '
            Me.TabItemEmployeeGeneralInformation_RolesTab.AttachedControl = Me.TabControlPanelRolesTab_Roles
            Me.TabItemEmployeeGeneralInformation_RolesTab.Name = "TabItemEmployeeGeneralInformation_RolesTab"
            Me.TabItemEmployeeGeneralInformation_RolesTab.Text = "Roles"
            '
            'TextBoxGeneralInformation_AccountNumber
            '
            Me.TextBoxGeneralInformation_AccountNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxGeneralInformation_AccountNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxGeneralInformation_AccountNumber.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneralInformation_AccountNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneralInformation_AccountNumber.CheckSpellingOnValidate = False
            Me.TextBoxGeneralInformation_AccountNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneralInformation_AccountNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxGeneralInformation_AccountNumber.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneralInformation_AccountNumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneralInformation_AccountNumber.FocusHighlightEnabled = True
            Me.TextBoxGeneralInformation_AccountNumber.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneralInformation_AccountNumber.Location = New System.Drawing.Point(446, 58)
            Me.TextBoxGeneralInformation_AccountNumber.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneralInformation_AccountNumber.Name = "TextBoxGeneralInformation_AccountNumber"
            Me.TextBoxGeneralInformation_AccountNumber.SecurityEnabled = True
            Me.TextBoxGeneralInformation_AccountNumber.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneralInformation_AccountNumber.Size = New System.Drawing.Size(285, 21)
            Me.TextBoxGeneralInformation_AccountNumber.StartingFolderName = Nothing
            Me.TextBoxGeneralInformation_AccountNumber.TabIndex = 15
            Me.TextBoxGeneralInformation_AccountNumber.TabOnEnter = True
            '
            'TextBoxGeneralInformation_Code
            '
            Me.TextBoxGeneralInformation_Code.BackColor = System.Drawing.Color.White
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
            Me.TextBoxGeneralInformation_Code.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneralInformation_Code.Location = New System.Drawing.Point(48, 6)
            Me.TextBoxGeneralInformation_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneralInformation_Code.Name = "TextBoxGeneralInformation_Code"
            Me.TextBoxGeneralInformation_Code.SecurityEnabled = True
            Me.TextBoxGeneralInformation_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneralInformation_Code.Size = New System.Drawing.Size(69, 21)
            Me.TextBoxGeneralInformation_Code.StartingFolderName = Nothing
            Me.TextBoxGeneralInformation_Code.TabIndex = 1
            Me.TextBoxGeneralInformation_Code.TabOnEnter = True
            '
            'TextBoxGeneralInformation_LastName
            '
            Me.TextBoxGeneralInformation_LastName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxGeneralInformation_LastName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxGeneralInformation_LastName.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneralInformation_LastName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneralInformation_LastName.CheckSpellingOnValidate = False
            Me.TextBoxGeneralInformation_LastName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneralInformation_LastName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxGeneralInformation_LastName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneralInformation_LastName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneralInformation_LastName.FocusHighlightEnabled = True
            Me.TextBoxGeneralInformation_LastName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneralInformation_LastName.Location = New System.Drawing.Point(514, 6)
            Me.TextBoxGeneralInformation_LastName.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneralInformation_LastName.Name = "TextBoxGeneralInformation_LastName"
            Me.TextBoxGeneralInformation_LastName.SecurityEnabled = True
            Me.TextBoxGeneralInformation_LastName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneralInformation_LastName.Size = New System.Drawing.Size(217, 21)
            Me.TextBoxGeneralInformation_LastName.StartingFolderName = Nothing
            Me.TextBoxGeneralInformation_LastName.TabIndex = 7
            Me.TextBoxGeneralInformation_LastName.TabOnEnter = True
            '
            'LabelGeneralInformation_FirstName
            '
            Me.LabelGeneralInformation_FirstName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInformation_FirstName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInformation_FirstName.Location = New System.Drawing.Point(123, 6)
            Me.LabelGeneralInformation_FirstName.Name = "LabelGeneralInformation_FirstName"
            Me.LabelGeneralInformation_FirstName.Size = New System.Drawing.Size(62, 20)
            Me.LabelGeneralInformation_FirstName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInformation_FirstName.TabIndex = 2
            Me.LabelGeneralInformation_FirstName.Text = "First Name:"
            '
            'LabelGeneralInformation_AccountNumber
            '
            Me.LabelGeneralInformation_AccountNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInformation_AccountNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInformation_AccountNumber.Location = New System.Drawing.Point(295, 58)
            Me.LabelGeneralInformation_AccountNumber.Name = "LabelGeneralInformation_AccountNumber"
            Me.LabelGeneralInformation_AccountNumber.Size = New System.Drawing.Size(145, 20)
            Me.LabelGeneralInformation_AccountNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInformation_AccountNumber.TabIndex = 14
            Me.LabelGeneralInformation_AccountNumber.Text = "Account Number/Reference:"
            '
            'LabelGeneralInformation_MiddleInitial
            '
            Me.LabelGeneralInformation_MiddleInitial.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInformation_MiddleInitial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInformation_MiddleInitial.Location = New System.Drawing.Point(390, 6)
            Me.LabelGeneralInformation_MiddleInitial.Name = "LabelGeneralInformation_MiddleInitial"
            Me.LabelGeneralInformation_MiddleInitial.Size = New System.Drawing.Size(23, 20)
            Me.LabelGeneralInformation_MiddleInitial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInformation_MiddleInitial.TabIndex = 4
            Me.LabelGeneralInformation_MiddleInitial.Text = "MI:"
            '
            'LabelGeneralInformation_LastName
            '
            Me.LabelGeneralInformation_LastName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInformation_LastName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInformation_LastName.Location = New System.Drawing.Point(446, 6)
            Me.LabelGeneralInformation_LastName.Name = "LabelGeneralInformation_LastName"
            Me.LabelGeneralInformation_LastName.Size = New System.Drawing.Size(62, 20)
            Me.LabelGeneralInformation_LastName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInformation_LastName.TabIndex = 6
            Me.LabelGeneralInformation_LastName.Text = "Last Name:"
            '
            'LabelGeneralInformation_Title
            '
            Me.LabelGeneralInformation_Title.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneralInformation_Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneralInformation_Title.Location = New System.Drawing.Point(6, 32)
            Me.LabelGeneralInformation_Title.Name = "LabelGeneralInformation_Title"
            Me.LabelGeneralInformation_Title.Size = New System.Drawing.Size(36, 20)
            Me.LabelGeneralInformation_Title.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneralInformation_Title.TabIndex = 8
            Me.LabelGeneralInformation_Title.Text = "Title:"
            '
            'CheckBoxGeneralInformation_Freelance
            '
            '
            '
            '
            Me.CheckBoxGeneralInformation_Freelance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGeneralInformation_Freelance.CheckValue = 0
            Me.CheckBoxGeneralInformation_Freelance.CheckValueChecked = 1
            Me.CheckBoxGeneralInformation_Freelance.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGeneralInformation_Freelance.CheckValueUnchecked = 0
            Me.CheckBoxGeneralInformation_Freelance.ChildControls = CType(resources.GetObject("CheckBoxGeneralInformation_Freelance.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneralInformation_Freelance.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGeneralInformation_Freelance.Location = New System.Drawing.Point(294, 32)
            Me.CheckBoxGeneralInformation_Freelance.Name = "CheckBoxGeneralInformation_Freelance"
            Me.CheckBoxGeneralInformation_Freelance.OldestSibling = Nothing
            Me.CheckBoxGeneralInformation_Freelance.SecurityEnabled = True
            Me.CheckBoxGeneralInformation_Freelance.SiblingControls = CType(resources.GetObject("CheckBoxGeneralInformation_Freelance.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneralInformation_Freelance.Size = New System.Drawing.Size(90, 20)
            Me.CheckBoxGeneralInformation_Freelance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGeneralInformation_Freelance.TabIndex = 10
            Me.CheckBoxGeneralInformation_Freelance.TabOnEnter = True
            Me.CheckBoxGeneralInformation_Freelance.Text = "Freelance"
            '
            'TextBoxGeneralInformation_FirstName
            '
            Me.TextBoxGeneralInformation_FirstName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxGeneralInformation_FirstName.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneralInformation_FirstName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneralInformation_FirstName.CheckSpellingOnValidate = False
            Me.TextBoxGeneralInformation_FirstName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneralInformation_FirstName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxGeneralInformation_FirstName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneralInformation_FirstName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneralInformation_FirstName.FocusHighlightEnabled = True
            Me.TextBoxGeneralInformation_FirstName.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneralInformation_FirstName.Location = New System.Drawing.Point(191, 6)
            Me.TextBoxGeneralInformation_FirstName.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneralInformation_FirstName.Name = "TextBoxGeneralInformation_FirstName"
            Me.TextBoxGeneralInformation_FirstName.SecurityEnabled = True
            Me.TextBoxGeneralInformation_FirstName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneralInformation_FirstName.Size = New System.Drawing.Size(193, 21)
            Me.TextBoxGeneralInformation_FirstName.StartingFolderName = Nothing
            Me.TextBoxGeneralInformation_FirstName.TabIndex = 3
            Me.TextBoxGeneralInformation_FirstName.TabOnEnter = True
            '
            'TextBoxGeneralInformation_MiddleInitial
            '
            Me.TextBoxGeneralInformation_MiddleInitial.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxGeneralInformation_MiddleInitial.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneralInformation_MiddleInitial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneralInformation_MiddleInitial.CheckSpellingOnValidate = False
            Me.TextBoxGeneralInformation_MiddleInitial.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneralInformation_MiddleInitial.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxGeneralInformation_MiddleInitial.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneralInformation_MiddleInitial.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneralInformation_MiddleInitial.FocusHighlightEnabled = True
            Me.TextBoxGeneralInformation_MiddleInitial.ForeColor = System.Drawing.Color.Black
            Me.TextBoxGeneralInformation_MiddleInitial.Location = New System.Drawing.Point(419, 6)
            Me.TextBoxGeneralInformation_MiddleInitial.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneralInformation_MiddleInitial.Name = "TextBoxGeneralInformation_MiddleInitial"
            Me.TextBoxGeneralInformation_MiddleInitial.SecurityEnabled = True
            Me.TextBoxGeneralInformation_MiddleInitial.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneralInformation_MiddleInitial.Size = New System.Drawing.Size(21, 21)
            Me.TextBoxGeneralInformation_MiddleInitial.StartingFolderName = Nothing
            Me.TextBoxGeneralInformation_MiddleInitial.TabIndex = 5
            Me.TextBoxGeneralInformation_MiddleInitial.TabOnEnter = True
            '
            'TabItemEmployeeDetails_GeneralInformation
            '
            Me.TabItemEmployeeDetails_GeneralInformation.AttachedControl = Me.TabControlPanelGeneralInformation_GeneralInformation
            Me.TabItemEmployeeDetails_GeneralInformation.Name = "TabItemEmployeeDetails_GeneralInformation"
            Me.TabItemEmployeeDetails_GeneralInformation.Text = "General Information"
            '
            'TabControlPanelTimeTrackingTab_TimeTracking
            '
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.NumericInputTimeTracking_BillableHoursGoal)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.LabelTimeTracking_BillableHoursGoal)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.SearchableComboBoxTimeTracking_DefaultFunction)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.SearchableComboBoxTimeTracking_Supervisor)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.NumericInputTimeTracking_SeniorityPriority)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.NumericInputTimeTracking_DirectHoursGoal)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.NumericInputTimeTracking_MonthlyBillableHoursGoal)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.NumericInputTimeTracking_StandardAnnualHours)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.LabelTimeTracking_StandardAnnualHours)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.LabelTimeTracking_DirectHoursGoal)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.LabelTimeTracking_MonthlyBillableHoursGoal)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.LabelTimeTracking_HoursGoals)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.ComboBoxTimeTracking_ReportMissingTime)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.RadioButtonControlTimeTracking_EmployeeStatusNonExempt)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.RadioButtonControlTimeTracking_EmployeeStatusExempt)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.RadioButtonControlTimeTracking_EmployeeStatusNA)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.LabelTimeTracking_DefaultFunction)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.LabelTimeTracking_ReportMissingTimeLbl)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.LabelTimeTracking_SeniorityPriority)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.LabelTimeTracking_VacationSickPersonalTime)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.DataGridViewTimeTracking_EmployeeTimeOff)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.LabelTimeTracking_EmployeeStatus)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.LabelTimeTracking_StandardWorkDays)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.DataGridViewTimeTracking_WorkDays)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Controls.Add(Me.LabelTimeTracking_Supervisor)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Name = "TabControlPanelTimeTrackingTab_TimeTracking"
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Size = New System.Drawing.Size(738, 523)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.Style.GradientAngle = 90
            Me.TabControlPanelTimeTrackingTab_TimeTracking.TabIndex = 9
            Me.TabControlPanelTimeTrackingTab_TimeTracking.TabItem = Me.TabItemEmployeeDetails_TimeTrackingTab
            '
            'NumericInputTimeTracking_BillableHoursGoal
            '
            Me.NumericInputTimeTracking_BillableHoursGoal.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTimeTracking_BillableHoursGoal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputTimeTracking_BillableHoursGoal.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTimeTracking_BillableHoursGoal.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTimeTracking_BillableHoursGoal.EnterMoveNextControl = True
            Me.NumericInputTimeTracking_BillableHoursGoal.Location = New System.Drawing.Point(640, 189)
            Me.NumericInputTimeTracking_BillableHoursGoal.Name = "NumericInputTimeTracking_BillableHoursGoal"
            Me.NumericInputTimeTracking_BillableHoursGoal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputTimeTracking_BillableHoursGoal.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputTimeTracking_BillableHoursGoal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTimeTracking_BillableHoursGoal.Properties.EditFormat.FormatString = "f"
            Me.NumericInputTimeTracking_BillableHoursGoal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTimeTracking_BillableHoursGoal.Properties.Mask.EditMask = "f"
            Me.NumericInputTimeTracking_BillableHoursGoal.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTimeTracking_BillableHoursGoal.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
            Me.NumericInputTimeTracking_BillableHoursGoal.SecurityEnabled = True
            Me.NumericInputTimeTracking_BillableHoursGoal.Size = New System.Drawing.Size(92, 20)
            Me.NumericInputTimeTracking_BillableHoursGoal.TabIndex = 23
            '
            'LabelTimeTracking_BillableHoursGoal
            '
            Me.LabelTimeTracking_BillableHoursGoal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTimeTracking_BillableHoursGoal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTimeTracking_BillableHoursGoal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTimeTracking_BillableHoursGoal.Location = New System.Drawing.Point(487, 188)
            Me.LabelTimeTracking_BillableHoursGoal.Name = "LabelTimeTracking_BillableHoursGoal"
            Me.LabelTimeTracking_BillableHoursGoal.Size = New System.Drawing.Size(147, 20)
            Me.LabelTimeTracking_BillableHoursGoal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTimeTracking_BillableHoursGoal.TabIndex = 22
            Me.LabelTimeTracking_BillableHoursGoal.Text = "Billable Hours Percent Goal:"
            '
            'CheckBoxTimeTracking_OmitFromMissingTimeTracking
            '
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.CheckValue = 0
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.CheckValueChecked = 1
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.CheckValueUnchecked = 0
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.ChildControls = CType(resources.GetObject("CheckBoxTimeTracking_OmitFromMissingTimeTracking.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.Location = New System.Drawing.Point(487, 57)
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.Name = "CheckBoxTimeTracking_OmitFromMissingTimeTracking"
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.OldestSibling = Nothing
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.SecurityEnabled = True
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.SiblingControls = CType(resources.GetObject("CheckBoxTimeTracking_OmitFromMissingTimeTracking.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.Size = New System.Drawing.Size(245, 20)
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.TabIndex = 12
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.TabOnEnter = True
            Me.CheckBoxTimeTracking_OmitFromMissingTimeTracking.Text = "Omit from Missing Time Tracking"
            '
            'SearchableComboBoxTimeTracking_DefaultFunction
            '
            Me.SearchableComboBoxTimeTracking_DefaultFunction.ActiveFilterString = ""
            Me.SearchableComboBoxTimeTracking_DefaultFunction.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxTimeTracking_DefaultFunction.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxTimeTracking_DefaultFunction.AutoFillMode = False
            Me.SearchableComboBoxTimeTracking_DefaultFunction.BookmarkingEnabled = False
            Me.SearchableComboBoxTimeTracking_DefaultFunction.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.[Function]
            Me.SearchableComboBoxTimeTracking_DefaultFunction.DataSource = Nothing
            Me.SearchableComboBoxTimeTracking_DefaultFunction.DisableMouseWheel = False
            Me.SearchableComboBoxTimeTracking_DefaultFunction.DisplayName = ""
            Me.SearchableComboBoxTimeTracking_DefaultFunction.EnterMoveNextControl = True
            Me.SearchableComboBoxTimeTracking_DefaultFunction.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxTimeTracking_DefaultFunction.Location = New System.Drawing.Point(487, 83)
            Me.SearchableComboBoxTimeTracking_DefaultFunction.Name = "SearchableComboBoxTimeTracking_DefaultFunction"
            Me.SearchableComboBoxTimeTracking_DefaultFunction.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTimeTracking_DefaultFunction.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxTimeTracking_DefaultFunction.Properties.NullText = "Select Function"
            Me.SearchableComboBoxTimeTracking_DefaultFunction.Properties.PopupView = Me.GridView3
            Me.SearchableComboBoxTimeTracking_DefaultFunction.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTimeTracking_DefaultFunction.SecurityEnabled = True
            Me.SearchableComboBoxTimeTracking_DefaultFunction.SelectedValue = Nothing
            Me.SearchableComboBoxTimeTracking_DefaultFunction.Size = New System.Drawing.Size(245, 20)
            Me.SearchableComboBoxTimeTracking_DefaultFunction.TabIndex = 14
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
            'SearchableComboBoxTimeTracking_Supervisor
            '
            Me.SearchableComboBoxTimeTracking_Supervisor.ActiveFilterString = ""
            Me.SearchableComboBoxTimeTracking_Supervisor.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxTimeTracking_Supervisor.AutoFillMode = False
            Me.SearchableComboBoxTimeTracking_Supervisor.BookmarkingEnabled = False
            Me.SearchableComboBoxTimeTracking_Supervisor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxTimeTracking_Supervisor.DataSource = Nothing
            Me.SearchableComboBoxTimeTracking_Supervisor.DisableMouseWheel = False
            Me.SearchableComboBoxTimeTracking_Supervisor.DisplayName = ""
            Me.SearchableComboBoxTimeTracking_Supervisor.EnterMoveNextControl = True
            Me.SearchableComboBoxTimeTracking_Supervisor.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxTimeTracking_Supervisor.Location = New System.Drawing.Point(109, 6)
            Me.SearchableComboBoxTimeTracking_Supervisor.Name = "SearchableComboBoxTimeTracking_Supervisor"
            Me.SearchableComboBoxTimeTracking_Supervisor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxTimeTracking_Supervisor.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxTimeTracking_Supervisor.Properties.NullText = "Select Employee"
            Me.SearchableComboBoxTimeTracking_Supervisor.Properties.PopupView = Me.GridView2
            Me.SearchableComboBoxTimeTracking_Supervisor.Properties.ValueMember = "Code"
            Me.SearchableComboBoxTimeTracking_Supervisor.SecurityEnabled = True
            Me.SearchableComboBoxTimeTracking_Supervisor.SelectedValue = Nothing
            Me.SearchableComboBoxTimeTracking_Supervisor.Size = New System.Drawing.Size(255, 20)
            Me.SearchableComboBoxTimeTracking_Supervisor.TabIndex = 1
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
            'NumericInputTimeTracking_SeniorityPriority
            '
            Me.NumericInputTimeTracking_SeniorityPriority.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTimeTracking_SeniorityPriority.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTimeTracking_SeniorityPriority.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTimeTracking_SeniorityPriority.EnterMoveNextControl = True
            Me.NumericInputTimeTracking_SeniorityPriority.Location = New System.Drawing.Point(109, 83)
            Me.NumericInputTimeTracking_SeniorityPriority.Name = "NumericInputTimeTracking_SeniorityPriority"
            Me.NumericInputTimeTracking_SeniorityPriority.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputTimeTracking_SeniorityPriority.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputTimeTracking_SeniorityPriority.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTimeTracking_SeniorityPriority.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputTimeTracking_SeniorityPriority.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTimeTracking_SeniorityPriority.Properties.IsFloatValue = False
            Me.NumericInputTimeTracking_SeniorityPriority.Properties.Mask.EditMask = "f0"
            Me.NumericInputTimeTracking_SeniorityPriority.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTimeTracking_SeniorityPriority.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTimeTracking_SeniorityPriority.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTimeTracking_SeniorityPriority.SecurityEnabled = True
            Me.NumericInputTimeTracking_SeniorityPriority.Size = New System.Drawing.Size(255, 20)
            Me.NumericInputTimeTracking_SeniorityPriority.TabIndex = 8
            '
            'NumericInputTimeTracking_DirectHoursGoal
            '
            Me.NumericInputTimeTracking_DirectHoursGoal.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTimeTracking_DirectHoursGoal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputTimeTracking_DirectHoursGoal.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTimeTracking_DirectHoursGoal.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTimeTracking_DirectHoursGoal.EnterMoveNextControl = True
            Me.NumericInputTimeTracking_DirectHoursGoal.Location = New System.Drawing.Point(640, 215)
            Me.NumericInputTimeTracking_DirectHoursGoal.Name = "NumericInputTimeTracking_DirectHoursGoal"
            Me.NumericInputTimeTracking_DirectHoursGoal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputTimeTracking_DirectHoursGoal.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputTimeTracking_DirectHoursGoal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTimeTracking_DirectHoursGoal.Properties.EditFormat.FormatString = "f"
            Me.NumericInputTimeTracking_DirectHoursGoal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTimeTracking_DirectHoursGoal.Properties.Mask.EditMask = "f"
            Me.NumericInputTimeTracking_DirectHoursGoal.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTimeTracking_DirectHoursGoal.SecurityEnabled = True
            Me.NumericInputTimeTracking_DirectHoursGoal.Size = New System.Drawing.Size(92, 20)
            Me.NumericInputTimeTracking_DirectHoursGoal.TabIndex = 25
            '
            'NumericInputTimeTracking_MonthlyBillableHoursGoal
            '
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.EnterMoveNextControl = True
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.Location = New System.Drawing.Point(640, 162)
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.Name = "NumericInputTimeTracking_MonthlyBillableHoursGoal"
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.Properties.EditFormat.FormatString = "f"
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.Properties.Mask.EditMask = "f"
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.SecurityEnabled = True
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.Size = New System.Drawing.Size(92, 20)
            Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.TabIndex = 21
            '
            'NumericInputTimeTracking_StandardAnnualHours
            '
            Me.NumericInputTimeTracking_StandardAnnualHours.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTimeTracking_StandardAnnualHours.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputTimeTracking_StandardAnnualHours.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputTimeTracking_StandardAnnualHours.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTimeTracking_StandardAnnualHours.EnterMoveNextControl = True
            Me.NumericInputTimeTracking_StandardAnnualHours.Location = New System.Drawing.Point(640, 136)
            Me.NumericInputTimeTracking_StandardAnnualHours.Name = "NumericInputTimeTracking_StandardAnnualHours"
            Me.NumericInputTimeTracking_StandardAnnualHours.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputTimeTracking_StandardAnnualHours.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputTimeTracking_StandardAnnualHours.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTimeTracking_StandardAnnualHours.Properties.EditFormat.FormatString = "f"
            Me.NumericInputTimeTracking_StandardAnnualHours.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTimeTracking_StandardAnnualHours.Properties.Mask.EditMask = "f"
            Me.NumericInputTimeTracking_StandardAnnualHours.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTimeTracking_StandardAnnualHours.SecurityEnabled = True
            Me.NumericInputTimeTracking_StandardAnnualHours.Size = New System.Drawing.Size(92, 20)
            Me.NumericInputTimeTracking_StandardAnnualHours.TabIndex = 19
            '
            'LabelTimeTracking_StandardAnnualHours
            '
            Me.LabelTimeTracking_StandardAnnualHours.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTimeTracking_StandardAnnualHours.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTimeTracking_StandardAnnualHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTimeTracking_StandardAnnualHours.Location = New System.Drawing.Point(487, 136)
            Me.LabelTimeTracking_StandardAnnualHours.Name = "LabelTimeTracking_StandardAnnualHours"
            Me.LabelTimeTracking_StandardAnnualHours.Size = New System.Drawing.Size(147, 20)
            Me.LabelTimeTracking_StandardAnnualHours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTimeTracking_StandardAnnualHours.TabIndex = 18
            Me.LabelTimeTracking_StandardAnnualHours.Text = "Standard Annual Hours:"
            '
            'LabelTimeTracking_DirectHoursGoal
            '
            Me.LabelTimeTracking_DirectHoursGoal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTimeTracking_DirectHoursGoal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTimeTracking_DirectHoursGoal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTimeTracking_DirectHoursGoal.Location = New System.Drawing.Point(487, 214)
            Me.LabelTimeTracking_DirectHoursGoal.Name = "LabelTimeTracking_DirectHoursGoal"
            Me.LabelTimeTracking_DirectHoursGoal.Size = New System.Drawing.Size(147, 20)
            Me.LabelTimeTracking_DirectHoursGoal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTimeTracking_DirectHoursGoal.TabIndex = 24
            Me.LabelTimeTracking_DirectHoursGoal.Text = "Direct Hours Percent Goal:"
            '
            'LabelTimeTracking_MonthlyBillableHoursGoal
            '
            Me.LabelTimeTracking_MonthlyBillableHoursGoal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTimeTracking_MonthlyBillableHoursGoal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTimeTracking_MonthlyBillableHoursGoal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTimeTracking_MonthlyBillableHoursGoal.Location = New System.Drawing.Point(487, 162)
            Me.LabelTimeTracking_MonthlyBillableHoursGoal.Name = "LabelTimeTracking_MonthlyBillableHoursGoal"
            Me.LabelTimeTracking_MonthlyBillableHoursGoal.Size = New System.Drawing.Size(147, 20)
            Me.LabelTimeTracking_MonthlyBillableHoursGoal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTimeTracking_MonthlyBillableHoursGoal.TabIndex = 20
            Me.LabelTimeTracking_MonthlyBillableHoursGoal.Text = "Monthly Billable Hours Goal:"
            '
            'LabelTimeTracking_HoursGoals
            '
            Me.LabelTimeTracking_HoursGoals.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTimeTracking_HoursGoals.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTimeTracking_HoursGoals.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTimeTracking_HoursGoals.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelTimeTracking_HoursGoals.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelTimeTracking_HoursGoals.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTimeTracking_HoursGoals.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTimeTracking_HoursGoals.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTimeTracking_HoursGoals.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTimeTracking_HoursGoals.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelTimeTracking_HoursGoals.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelTimeTracking_HoursGoals.Location = New System.Drawing.Point(487, 110)
            Me.LabelTimeTracking_HoursGoals.Name = "LabelTimeTracking_HoursGoals"
            Me.LabelTimeTracking_HoursGoals.Size = New System.Drawing.Size(245, 20)
            Me.LabelTimeTracking_HoursGoals.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTimeTracking_HoursGoals.TabIndex = 17
            Me.LabelTimeTracking_HoursGoals.Text = "Hours Goals"
            '
            'CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet
            '
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.CheckValue = 0
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.CheckValueChecked = 1
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.CheckValueUnchecked = 0
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.ChildControls = CType(resources.GetObject("CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.Location = New System.Drawing.Point(487, 31)
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.Name = "CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet"
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.OldestSibling = Nothing
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.SecurityEnabled = True
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.SiblingControls = CType(resources.GetObject("CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.Size = New System.Drawing.Size(245, 20)
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.TabIndex = 11
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.TabOnEnter = True
            Me.CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.Text = "Activate Missing Time Alert on Timesheet"
            '
            'ComboBoxTimeTracking_ReportMissingTime
            '
            Me.ComboBoxTimeTracking_ReportMissingTime.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxTimeTracking_ReportMissingTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxTimeTracking_ReportMissingTime.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxTimeTracking_ReportMissingTime.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxTimeTracking_ReportMissingTime.AutoFindItemInDataSource = False
            Me.ComboBoxTimeTracking_ReportMissingTime.AutoSelectSingleItemDatasource = False
            Me.ComboBoxTimeTracking_ReportMissingTime.BookmarkingEnabled = False
            Me.ComboBoxTimeTracking_ReportMissingTime.ClientCode = ""
            Me.ComboBoxTimeTracking_ReportMissingTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.ReportMissingTime
            Me.ComboBoxTimeTracking_ReportMissingTime.DisableMouseWheel = False
            Me.ComboBoxTimeTracking_ReportMissingTime.DisplayMember = "Value"
            Me.ComboBoxTimeTracking_ReportMissingTime.DisplayName = ""
            Me.ComboBoxTimeTracking_ReportMissingTime.DivisionCode = ""
            Me.ComboBoxTimeTracking_ReportMissingTime.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxTimeTracking_ReportMissingTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxTimeTracking_ReportMissingTime.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.AgencyDefault
            Me.ComboBoxTimeTracking_ReportMissingTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxTimeTracking_ReportMissingTime.FocusHighlightEnabled = True
            Me.ComboBoxTimeTracking_ReportMissingTime.FormattingEnabled = True
            Me.ComboBoxTimeTracking_ReportMissingTime.ItemHeight = 15
            Me.ComboBoxTimeTracking_ReportMissingTime.Location = New System.Drawing.Point(487, 5)
            Me.ComboBoxTimeTracking_ReportMissingTime.Name = "ComboBoxTimeTracking_ReportMissingTime"
            Me.ComboBoxTimeTracking_ReportMissingTime.ReadOnly = False
            Me.ComboBoxTimeTracking_ReportMissingTime.SecurityEnabled = True
            Me.ComboBoxTimeTracking_ReportMissingTime.Size = New System.Drawing.Size(245, 21)
            Me.ComboBoxTimeTracking_ReportMissingTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxTimeTracking_ReportMissingTime.TabIndex = 10
            Me.ComboBoxTimeTracking_ReportMissingTime.TabOnEnter = True
            Me.ComboBoxTimeTracking_ReportMissingTime.ValueMember = "Key"
            Me.ComboBoxTimeTracking_ReportMissingTime.WatermarkText = "Select Report Missing Time"
            '
            'RadioButtonControlTimeTracking_EmployeeStatusNonExempt
            '
            Me.RadioButtonControlTimeTracking_EmployeeStatusNonExempt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlTimeTracking_EmployeeStatusNonExempt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlTimeTracking_EmployeeStatusNonExempt.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlTimeTracking_EmployeeStatusNonExempt.Location = New System.Drawing.Point(275, 57)
            Me.RadioButtonControlTimeTracking_EmployeeStatusNonExempt.Name = "RadioButtonControlTimeTracking_EmployeeStatusNonExempt"
            Me.RadioButtonControlTimeTracking_EmployeeStatusNonExempt.SecurityEnabled = True
            Me.RadioButtonControlTimeTracking_EmployeeStatusNonExempt.Size = New System.Drawing.Size(89, 20)
            Me.RadioButtonControlTimeTracking_EmployeeStatusNonExempt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlTimeTracking_EmployeeStatusNonExempt.TabIndex = 6
            Me.RadioButtonControlTimeTracking_EmployeeStatusNonExempt.TabOnEnter = True
            Me.RadioButtonControlTimeTracking_EmployeeStatusNonExempt.TabStop = False
            Me.RadioButtonControlTimeTracking_EmployeeStatusNonExempt.Text = "Non-Exempt"
            '
            'RadioButtonControlTimeTracking_EmployeeStatusExempt
            '
            Me.RadioButtonControlTimeTracking_EmployeeStatusExempt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlTimeTracking_EmployeeStatusExempt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlTimeTracking_EmployeeStatusExempt.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlTimeTracking_EmployeeStatusExempt.Location = New System.Drawing.Point(192, 57)
            Me.RadioButtonControlTimeTracking_EmployeeStatusExempt.Name = "RadioButtonControlTimeTracking_EmployeeStatusExempt"
            Me.RadioButtonControlTimeTracking_EmployeeStatusExempt.SecurityEnabled = True
            Me.RadioButtonControlTimeTracking_EmployeeStatusExempt.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonControlTimeTracking_EmployeeStatusExempt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlTimeTracking_EmployeeStatusExempt.TabIndex = 5
            Me.RadioButtonControlTimeTracking_EmployeeStatusExempt.TabOnEnter = True
            Me.RadioButtonControlTimeTracking_EmployeeStatusExempt.TabStop = False
            Me.RadioButtonControlTimeTracking_EmployeeStatusExempt.Text = "Exempt"
            '
            'RadioButtonControlTimeTracking_EmployeeStatusNA
            '
            Me.RadioButtonControlTimeTracking_EmployeeStatusNA.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlTimeTracking_EmployeeStatusNA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlTimeTracking_EmployeeStatusNA.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlTimeTracking_EmployeeStatusNA.Location = New System.Drawing.Point(109, 57)
            Me.RadioButtonControlTimeTracking_EmployeeStatusNA.Name = "RadioButtonControlTimeTracking_EmployeeStatusNA"
            Me.RadioButtonControlTimeTracking_EmployeeStatusNA.SecurityEnabled = True
            Me.RadioButtonControlTimeTracking_EmployeeStatusNA.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonControlTimeTracking_EmployeeStatusNA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlTimeTracking_EmployeeStatusNA.TabIndex = 4
            Me.RadioButtonControlTimeTracking_EmployeeStatusNA.TabOnEnter = True
            Me.RadioButtonControlTimeTracking_EmployeeStatusNA.TabStop = False
            Me.RadioButtonControlTimeTracking_EmployeeStatusNA.Text = "N/A"
            '
            'CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval
            '
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.CheckValue = 0
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.CheckValueChecked = 1
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.CheckValueUnchecked = 0
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.ChildControls = CType(resources.GetObject("CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.Location = New System.Drawing.Point(109, 31)
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.Name = "CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval"
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.OldestSibling = Nothing
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.SecurityEnabled = True
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.SiblingControls = CType(resources.GetObject("CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.Size = New System.Drawing.Size(255, 20)
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.TabIndex = 2
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.TabOnEnter = True
            Me.CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.Text = "Exempt from Time Entry Supervisor Approval"
            '
            'LabelTimeTracking_DefaultFunction
            '
            Me.LabelTimeTracking_DefaultFunction.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTimeTracking_DefaultFunction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTimeTracking_DefaultFunction.Location = New System.Drawing.Point(370, 83)
            Me.LabelTimeTracking_DefaultFunction.Name = "LabelTimeTracking_DefaultFunction"
            Me.LabelTimeTracking_DefaultFunction.Size = New System.Drawing.Size(111, 20)
            Me.LabelTimeTracking_DefaultFunction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTimeTracking_DefaultFunction.TabIndex = 13
            Me.LabelTimeTracking_DefaultFunction.Text = "Default Function:"
            '
            'LabelTimeTracking_ReportMissingTimeLbl
            '
            Me.LabelTimeTracking_ReportMissingTimeLbl.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTimeTracking_ReportMissingTimeLbl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTimeTracking_ReportMissingTimeLbl.Location = New System.Drawing.Point(370, 6)
            Me.LabelTimeTracking_ReportMissingTimeLbl.Name = "LabelTimeTracking_ReportMissingTimeLbl"
            Me.LabelTimeTracking_ReportMissingTimeLbl.Size = New System.Drawing.Size(111, 20)
            Me.LabelTimeTracking_ReportMissingTimeLbl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTimeTracking_ReportMissingTimeLbl.TabIndex = 9
            Me.LabelTimeTracking_ReportMissingTimeLbl.Text = "Report Missing Time:"
            '
            'LabelTimeTracking_SeniorityPriority
            '
            Me.LabelTimeTracking_SeniorityPriority.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTimeTracking_SeniorityPriority.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTimeTracking_SeniorityPriority.Location = New System.Drawing.Point(6, 83)
            Me.LabelTimeTracking_SeniorityPriority.Name = "LabelTimeTracking_SeniorityPriority"
            Me.LabelTimeTracking_SeniorityPriority.Size = New System.Drawing.Size(97, 20)
            Me.LabelTimeTracking_SeniorityPriority.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTimeTracking_SeniorityPriority.TabIndex = 7
            Me.LabelTimeTracking_SeniorityPriority.Text = "Seniority / Priority:"
            '
            'LabelTimeTracking_VacationSickPersonalTime
            '
            Me.LabelTimeTracking_VacationSickPersonalTime.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTimeTracking_VacationSickPersonalTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTimeTracking_VacationSickPersonalTime.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTimeTracking_VacationSickPersonalTime.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelTimeTracking_VacationSickPersonalTime.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelTimeTracking_VacationSickPersonalTime.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTimeTracking_VacationSickPersonalTime.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTimeTracking_VacationSickPersonalTime.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTimeTracking_VacationSickPersonalTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTimeTracking_VacationSickPersonalTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelTimeTracking_VacationSickPersonalTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelTimeTracking_VacationSickPersonalTime.Location = New System.Drawing.Point(6, 345)
            Me.LabelTimeTracking_VacationSickPersonalTime.Name = "LabelTimeTracking_VacationSickPersonalTime"
            Me.LabelTimeTracking_VacationSickPersonalTime.Size = New System.Drawing.Size(726, 20)
            Me.LabelTimeTracking_VacationSickPersonalTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTimeTracking_VacationSickPersonalTime.TabIndex = 26
            Me.LabelTimeTracking_VacationSickPersonalTime.Text = "Vacation/Sick/Personal Time "
            '
            'DataGridViewTimeTracking_EmployeeTimeOff
            '
            Me.DataGridViewTimeTracking_EmployeeTimeOff.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewTimeTracking_EmployeeTimeOff.AllowDragAndDrop = False
            Me.DataGridViewTimeTracking_EmployeeTimeOff.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewTimeTracking_EmployeeTimeOff.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTimeTracking_EmployeeTimeOff.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewTimeTracking_EmployeeTimeOff.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTimeTracking_EmployeeTimeOff.AutoFilterLookupColumns = False
            Me.DataGridViewTimeTracking_EmployeeTimeOff.AutoloadRepositoryDatasource = True
            Me.DataGridViewTimeTracking_EmployeeTimeOff.AutoUpdateViewCaption = True
            Me.DataGridViewTimeTracking_EmployeeTimeOff.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewTimeTracking_EmployeeTimeOff.DataSource = Nothing
            Me.DataGridViewTimeTracking_EmployeeTimeOff.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTimeTracking_EmployeeTimeOff.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTimeTracking_EmployeeTimeOff.ItemDescription = ""
            Me.DataGridViewTimeTracking_EmployeeTimeOff.Location = New System.Drawing.Point(6, 371)
            Me.DataGridViewTimeTracking_EmployeeTimeOff.MultiSelect = True
            Me.DataGridViewTimeTracking_EmployeeTimeOff.Name = "DataGridViewTimeTracking_EmployeeTimeOff"
            Me.DataGridViewTimeTracking_EmployeeTimeOff.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewTimeTracking_EmployeeTimeOff.RunStandardValidation = True
            Me.DataGridViewTimeTracking_EmployeeTimeOff.ShowColumnMenuOnRightClick = False
            Me.DataGridViewTimeTracking_EmployeeTimeOff.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTimeTracking_EmployeeTimeOff.Size = New System.Drawing.Size(726, 111)
            Me.DataGridViewTimeTracking_EmployeeTimeOff.TabIndex = 27
            Me.DataGridViewTimeTracking_EmployeeTimeOff.UseEmbeddedNavigator = False
            Me.DataGridViewTimeTracking_EmployeeTimeOff.ViewCaptionHeight = -1
            '
            'LabelTimeTracking_EmployeeStatus
            '
            Me.LabelTimeTracking_EmployeeStatus.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTimeTracking_EmployeeStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTimeTracking_EmployeeStatus.Location = New System.Drawing.Point(6, 57)
            Me.LabelTimeTracking_EmployeeStatus.Name = "LabelTimeTracking_EmployeeStatus"
            Me.LabelTimeTracking_EmployeeStatus.Size = New System.Drawing.Size(97, 20)
            Me.LabelTimeTracking_EmployeeStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTimeTracking_EmployeeStatus.TabIndex = 3
            Me.LabelTimeTracking_EmployeeStatus.Text = "Status:"
            '
            'LabelTimeTracking_StandardWorkDays
            '
            Me.LabelTimeTracking_StandardWorkDays.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelTimeTracking_StandardWorkDays.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTimeTracking_StandardWorkDays.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTimeTracking_StandardWorkDays.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelTimeTracking_StandardWorkDays.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelTimeTracking_StandardWorkDays.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTimeTracking_StandardWorkDays.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTimeTracking_StandardWorkDays.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTimeTracking_StandardWorkDays.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTimeTracking_StandardWorkDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelTimeTracking_StandardWorkDays.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelTimeTracking_StandardWorkDays.Location = New System.Drawing.Point(6, 110)
            Me.LabelTimeTracking_StandardWorkDays.Name = "LabelTimeTracking_StandardWorkDays"
            Me.LabelTimeTracking_StandardWorkDays.Size = New System.Drawing.Size(475, 20)
            Me.LabelTimeTracking_StandardWorkDays.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTimeTracking_StandardWorkDays.TabIndex = 15
            Me.LabelTimeTracking_StandardWorkDays.Text = "Standard Work Days"
            '
            'DataGridViewTimeTracking_WorkDays
            '
            Me.DataGridViewTimeTracking_WorkDays.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewTimeTracking_WorkDays.AllowDragAndDrop = False
            Me.DataGridViewTimeTracking_WorkDays.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewTimeTracking_WorkDays.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTimeTracking_WorkDays.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewTimeTracking_WorkDays.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTimeTracking_WorkDays.AutoFilterLookupColumns = False
            Me.DataGridViewTimeTracking_WorkDays.AutoloadRepositoryDatasource = True
            Me.DataGridViewTimeTracking_WorkDays.AutoUpdateViewCaption = True
            Me.DataGridViewTimeTracking_WorkDays.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewTimeTracking_WorkDays.DataSource = Nothing
            Me.DataGridViewTimeTracking_WorkDays.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTimeTracking_WorkDays.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTimeTracking_WorkDays.ItemDescription = ""
            Me.DataGridViewTimeTracking_WorkDays.Location = New System.Drawing.Point(6, 136)
            Me.DataGridViewTimeTracking_WorkDays.MultiSelect = True
            Me.DataGridViewTimeTracking_WorkDays.Name = "DataGridViewTimeTracking_WorkDays"
            Me.DataGridViewTimeTracking_WorkDays.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewTimeTracking_WorkDays.RunStandardValidation = True
            Me.DataGridViewTimeTracking_WorkDays.ShowColumnMenuOnRightClick = False
            Me.DataGridViewTimeTracking_WorkDays.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTimeTracking_WorkDays.Size = New System.Drawing.Size(475, 203)
            Me.DataGridViewTimeTracking_WorkDays.TabIndex = 16
            Me.DataGridViewTimeTracking_WorkDays.UseEmbeddedNavigator = False
            Me.DataGridViewTimeTracking_WorkDays.ViewCaptionHeight = -1
            '
            'LabelTimeTracking_Supervisor
            '
            Me.LabelTimeTracking_Supervisor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTimeTracking_Supervisor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTimeTracking_Supervisor.Location = New System.Drawing.Point(6, 6)
            Me.LabelTimeTracking_Supervisor.Name = "LabelTimeTracking_Supervisor"
            Me.LabelTimeTracking_Supervisor.Size = New System.Drawing.Size(97, 20)
            Me.LabelTimeTracking_Supervisor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTimeTracking_Supervisor.TabIndex = 0
            Me.LabelTimeTracking_Supervisor.Text = "Supervisor:"
            '
            'TabItemEmployeeDetails_TimeTrackingTab
            '
            Me.TabItemEmployeeDetails_TimeTrackingTab.AttachedControl = Me.TabControlPanelTimeTrackingTab_TimeTracking
            Me.TabItemEmployeeDetails_TimeTrackingTab.Name = "TabItemEmployeeDetails_TimeTrackingTab"
            Me.TabItemEmployeeDetails_TimeTrackingTab.Text = "Time Tracking"
            '
            'TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports
            '
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.NumericInputPOsAndExpenseReports_POAmountLimit)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.LabelPOsAndExpenseReports_POApprovalRule)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.LabelPOsAndExpenseReports_POAmountLimit)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.LabelPOsAndExpenseReports_PurchaseOrders)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.LabelPOsAndExpenseReports_ExpenseReportInformation)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.TextBoxPOsAndExpenseReports_CreditCardDescription)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.LabelPOsAndExpenseReports_CreditCardDescription)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.TextBoxPOsAndExpenseReports_CreditCardNumber)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.LabelPOsAndExpenseReports_CreditCardGLAccount)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.LabelPOsAndExpenseReports_AlternateApprover)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.LabelPOsAndExpenseReports_VendorCodeCrossRef)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Controls.Add(Me.LabelPOsAndExpenseReports_CreditCardNumber)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Name = "TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports"
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Size = New System.Drawing.Size(738, 523)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.Style.GradientAngle = 90
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.TabIndex = 10
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.TabItem = Me.TabItemEmployeeDetails_POsAndExpenseReportsTab
            '
            'NumericInputPOsAndExpenseReports_POAmountLimit
            '
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.EnterMoveNextControl = True
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Location = New System.Drawing.Point(109, 32)
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Name = "NumericInputPOsAndExpenseReports_POAmountLimit"
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.Appearance.Options.UseTextOptions = True
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.AppearanceDisabled.Options.UseTextOptions = True
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.AppearanceFocused.Options.UseTextOptions = True
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.AppearanceReadOnly.Options.UseTextOptions = True
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.EditFormat.FormatString = "f"
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.Mask.EditMask = "f"
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.SecurityEnabled = True
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.Size = New System.Drawing.Size(623, 20)
            Me.NumericInputPOsAndExpenseReports_POAmountLimit.TabIndex = 1
            '
            'SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount
            '
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.ActiveFilterString = ""
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.AutoFillMode = False
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.BookmarkingEnabled = False
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.DataSource = Nothing
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.DisableMouseWheel = False
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.DisplayName = ""
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.EnterMoveNextControl = True
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.Location = New System.Drawing.Point(176, 241)
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.Name = "SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount"
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.Properties.NullText = "Select General Ledger Account"
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.Properties.PopupView = Me.GridView8
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.SecurityEnabled = True
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.SelectedValue = Nothing
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.Size = New System.Drawing.Size(556, 20)
            Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.TabIndex = 16
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
            'SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef
            '
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.ActiveFilterString = ""
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.AutoFillMode = False
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.BookmarkingEnabled = False
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Vendor
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.DataSource = Nothing
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.DisableMouseWheel = False
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.DisplayName = ""
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.EnterMoveNextControl = True
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.Location = New System.Drawing.Point(176, 189)
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.Name = "SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef"
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.Properties.NullText = "Select Vendor"
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.Properties.PopupView = Me.GridView7
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.Properties.ValueMember = "Code"
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.SecurityEnabled = True
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.SelectedValue = Nothing
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.Size = New System.Drawing.Size(556, 20)
            Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.TabIndex = 12
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
            'SearchableComboBoxPOsAndExpenseReports_AlternateApprover
            '
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.ActiveFilterString = ""
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.AutoFillMode = False
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.BookmarkingEnabled = False
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.DataSource = Nothing
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.DisableMouseWheel = False
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.DisplayName = ""
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.EnterMoveNextControl = True
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.Location = New System.Drawing.Point(176, 163)
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.Name = "SearchableComboBoxPOsAndExpenseReports_AlternateApprover"
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.Properties.NullText = "Select Employee"
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.Properties.PopupView = Me.GridView6
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.Properties.ValueMember = "Code"
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.SecurityEnabled = True
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.SelectedValue = Nothing
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.Size = New System.Drawing.Size(556, 20)
            Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.TabIndex = 10
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
            'SearchableComboBoxPOsAndExpenseReports_POApprovalRule
            '
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.ActiveFilterString = ""
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.AutoFillMode = False
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.BookmarkingEnabled = False
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.POApprovalRule
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.DataSource = Nothing
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.DisableMouseWheel = False
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.DisplayName = ""
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.EnterMoveNextControl = True
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.Location = New System.Drawing.Point(109, 58)
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.Name = "SearchableComboBoxPOsAndExpenseReports_POApprovalRule"
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.Properties.NullText = "Select PO Approval Rule"
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.Properties.PopupView = Me.GridView5
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.Properties.ValueMember = "Code"
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.SecurityEnabled = True
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.SelectedValue = Nothing
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.Size = New System.Drawing.Size(623, 20)
            Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.TabIndex = 4
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
            'CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice
            '
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.CheckValue = 0
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.CheckValueChecked = 1
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.CheckValueUnchecked = 0
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.ChildControls = CType(resources.GetObject("CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.Location = New System.Drawing.Point(281, 84)
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.Name = "CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice"
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.OldestSibling = Nothing
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.SecurityEnabled = True
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.SiblingControls = CType(resources.GetObject("CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.Size = New System.Drawing.Size(451, 20)
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.TabIndex = 6
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.TabOnEnter = True
            Me.CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.Text = "Limit Account Selection to Office"
            '
            'CheckBoxPOsAndExpenseReports_AllowGLAccountSelection
            '
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.CheckValue = 0
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.CheckValueChecked = 1
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.CheckValueUnchecked = 0
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.ChildControls = CType(resources.GetObject("CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.Location = New System.Drawing.Point(109, 85)
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.Name = "CheckBoxPOsAndExpenseReports_AllowGLAccountSelection"
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.OldestSibling = Nothing
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.SecurityEnabled = True
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.SiblingControls = CType(resources.GetObject("CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.Size = New System.Drawing.Size(166, 20)
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.TabIndex = 5
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.TabOnEnter = True
            Me.CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.Text = "Allow GL Account Selection"
            '
            'CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired
            '
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.CheckValue = 0
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.CheckValueChecked = 1
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.CheckValueUnchecked = 0
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.ChildControls = CType(resources.GetObject("CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.Location = New System.Drawing.Point(176, 137)
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.Name = "CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired"
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.OldestSibling = Nothing
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.SecurityEnabled = True
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.SiblingControls = CType(resources.GetObject("CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.Size = New System.Drawing.Size(556, 20)
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.TabIndex = 8
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.TabOnEnter = True
            Me.CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.Text = "Supervisor Approval Required"
            '
            'LabelPOsAndExpenseReports_POApprovalRule
            '
            Me.LabelPOsAndExpenseReports_POApprovalRule.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPOsAndExpenseReports_POApprovalRule.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPOsAndExpenseReports_POApprovalRule.Location = New System.Drawing.Point(6, 58)
            Me.LabelPOsAndExpenseReports_POApprovalRule.Name = "LabelPOsAndExpenseReports_POApprovalRule"
            Me.LabelPOsAndExpenseReports_POApprovalRule.Size = New System.Drawing.Size(97, 20)
            Me.LabelPOsAndExpenseReports_POApprovalRule.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPOsAndExpenseReports_POApprovalRule.TabIndex = 3
            Me.LabelPOsAndExpenseReports_POApprovalRule.Text = "PO Approval Rule:"
            '
            'LabelPOsAndExpenseReports_POAmountLimit
            '
            Me.LabelPOsAndExpenseReports_POAmountLimit.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPOsAndExpenseReports_POAmountLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPOsAndExpenseReports_POAmountLimit.Location = New System.Drawing.Point(6, 32)
            Me.LabelPOsAndExpenseReports_POAmountLimit.Name = "LabelPOsAndExpenseReports_POAmountLimit"
            Me.LabelPOsAndExpenseReports_POAmountLimit.Size = New System.Drawing.Size(97, 20)
            Me.LabelPOsAndExpenseReports_POAmountLimit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPOsAndExpenseReports_POAmountLimit.TabIndex = 1
            Me.LabelPOsAndExpenseReports_POAmountLimit.Text = "PO Amount Limit:"
            '
            'LabelPOsAndExpenseReports_PurchaseOrders
            '
            Me.LabelPOsAndExpenseReports_PurchaseOrders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelPOsAndExpenseReports_PurchaseOrders.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPOsAndExpenseReports_PurchaseOrders.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPOsAndExpenseReports_PurchaseOrders.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelPOsAndExpenseReports_PurchaseOrders.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelPOsAndExpenseReports_PurchaseOrders.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPOsAndExpenseReports_PurchaseOrders.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPOsAndExpenseReports_PurchaseOrders.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPOsAndExpenseReports_PurchaseOrders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPOsAndExpenseReports_PurchaseOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPOsAndExpenseReports_PurchaseOrders.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelPOsAndExpenseReports_PurchaseOrders.Location = New System.Drawing.Point(6, 6)
            Me.LabelPOsAndExpenseReports_PurchaseOrders.Name = "LabelPOsAndExpenseReports_PurchaseOrders"
            Me.LabelPOsAndExpenseReports_PurchaseOrders.Size = New System.Drawing.Size(726, 20)
            Me.LabelPOsAndExpenseReports_PurchaseOrders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPOsAndExpenseReports_PurchaseOrders.TabIndex = 0
            Me.LabelPOsAndExpenseReports_PurchaseOrders.Text = "Purchase Orders"
            '
            'LabelPOsAndExpenseReports_ExpenseReportInformation
            '
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.Location = New System.Drawing.Point(6, 111)
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.Name = "LabelPOsAndExpenseReports_ExpenseReportInformation"
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.Size = New System.Drawing.Size(726, 20)
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.TabIndex = 7
            Me.LabelPOsAndExpenseReports_ExpenseReportInformation.Text = "Expense Report Information"
            '
            'TextBoxPOsAndExpenseReports_CreditCardDescription
            '
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.Border.Class = "TextBoxBorder"
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.CheckSpellingOnValidate = False
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.FocusHighlightEnabled = True
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.ForeColor = System.Drawing.Color.Black
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.Location = New System.Drawing.Point(176, 267)
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.MaxFileSize = CType(0, Long)
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.Name = "TextBoxPOsAndExpenseReports_CreditCardDescription"
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.SecurityEnabled = True
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.Size = New System.Drawing.Size(556, 20)
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.StartingFolderName = Nothing
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.TabIndex = 18
            Me.TextBoxPOsAndExpenseReports_CreditCardDescription.TabOnEnter = True
            '
            'LabelPOsAndExpenseReports_CreditCardDescription
            '
            Me.LabelPOsAndExpenseReports_CreditCardDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPOsAndExpenseReports_CreditCardDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPOsAndExpenseReports_CreditCardDescription.Location = New System.Drawing.Point(6, 267)
            Me.LabelPOsAndExpenseReports_CreditCardDescription.Name = "LabelPOsAndExpenseReports_CreditCardDescription"
            Me.LabelPOsAndExpenseReports_CreditCardDescription.Size = New System.Drawing.Size(164, 20)
            Me.LabelPOsAndExpenseReports_CreditCardDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPOsAndExpenseReports_CreditCardDescription.TabIndex = 17
            Me.LabelPOsAndExpenseReports_CreditCardDescription.Text = "Credit Card Description:"
            '
            'TextBoxPOsAndExpenseReports_CreditCardNumber
            '
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.Border.Class = "TextBoxBorder"
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.CheckSpellingOnValidate = False
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.FocusHighlightEnabled = True
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.ForeColor = System.Drawing.Color.Black
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.Location = New System.Drawing.Point(176, 215)
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.MaxFileSize = CType(0, Long)
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.Name = "TextBoxPOsAndExpenseReports_CreditCardNumber"
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.SecurityEnabled = True
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.Size = New System.Drawing.Size(556, 20)
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.StartingFolderName = Nothing
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.TabIndex = 14
            Me.TextBoxPOsAndExpenseReports_CreditCardNumber.TabOnEnter = True
            '
            'LabelPOsAndExpenseReports_CreditCardGLAccount
            '
            Me.LabelPOsAndExpenseReports_CreditCardGLAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPOsAndExpenseReports_CreditCardGLAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPOsAndExpenseReports_CreditCardGLAccount.Location = New System.Drawing.Point(6, 241)
            Me.LabelPOsAndExpenseReports_CreditCardGLAccount.Name = "LabelPOsAndExpenseReports_CreditCardGLAccount"
            Me.LabelPOsAndExpenseReports_CreditCardGLAccount.Size = New System.Drawing.Size(164, 20)
            Me.LabelPOsAndExpenseReports_CreditCardGLAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPOsAndExpenseReports_CreditCardGLAccount.TabIndex = 15
            Me.LabelPOsAndExpenseReports_CreditCardGLAccount.Text = "Credit Card GL Account Default:"
            '
            'LabelPOsAndExpenseReports_AlternateApprover
            '
            Me.LabelPOsAndExpenseReports_AlternateApprover.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPOsAndExpenseReports_AlternateApprover.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPOsAndExpenseReports_AlternateApprover.Location = New System.Drawing.Point(6, 163)
            Me.LabelPOsAndExpenseReports_AlternateApprover.Name = "LabelPOsAndExpenseReports_AlternateApprover"
            Me.LabelPOsAndExpenseReports_AlternateApprover.Size = New System.Drawing.Size(164, 20)
            Me.LabelPOsAndExpenseReports_AlternateApprover.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPOsAndExpenseReports_AlternateApprover.TabIndex = 9
            Me.LabelPOsAndExpenseReports_AlternateApprover.Text = "Alternate Approver:"
            '
            'LabelPOsAndExpenseReports_VendorCodeCrossRef
            '
            Me.LabelPOsAndExpenseReports_VendorCodeCrossRef.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPOsAndExpenseReports_VendorCodeCrossRef.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPOsAndExpenseReports_VendorCodeCrossRef.Location = New System.Drawing.Point(6, 189)
            Me.LabelPOsAndExpenseReports_VendorCodeCrossRef.Name = "LabelPOsAndExpenseReports_VendorCodeCrossRef"
            Me.LabelPOsAndExpenseReports_VendorCodeCrossRef.Size = New System.Drawing.Size(164, 20)
            Me.LabelPOsAndExpenseReports_VendorCodeCrossRef.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPOsAndExpenseReports_VendorCodeCrossRef.TabIndex = 11
            Me.LabelPOsAndExpenseReports_VendorCodeCrossRef.Text = "Vendor Code Cross Ref:"
            '
            'LabelPOsAndExpenseReports_CreditCardNumber
            '
            Me.LabelPOsAndExpenseReports_CreditCardNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPOsAndExpenseReports_CreditCardNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPOsAndExpenseReports_CreditCardNumber.Location = New System.Drawing.Point(6, 215)
            Me.LabelPOsAndExpenseReports_CreditCardNumber.Name = "LabelPOsAndExpenseReports_CreditCardNumber"
            Me.LabelPOsAndExpenseReports_CreditCardNumber.Size = New System.Drawing.Size(164, 20)
            Me.LabelPOsAndExpenseReports_CreditCardNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPOsAndExpenseReports_CreditCardNumber.TabIndex = 13
            Me.LabelPOsAndExpenseReports_CreditCardNumber.Text = "Credit Card Number:"
            '
            'TabItemEmployeeDetails_POsAndExpenseReportsTab
            '
            Me.TabItemEmployeeDetails_POsAndExpenseReportsTab.AttachedControl = Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports
            Me.TabItemEmployeeDetails_POsAndExpenseReportsTab.Name = "TabItemEmployeeDetails_POsAndExpenseReportsTab"
            Me.TabItemEmployeeDetails_POsAndExpenseReportsTab.Text = "POs && Expense Reports"
            '
            'TabControlPanelHRAndRateInformationTab_HRAndRateInformation
            '
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.NumericInputHRAndRateInformation_CostRate)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.NumericInputHRAndRateInformation_BillRate)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.NumericInputHRAndRateInformation_MonthlySalary)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.NumericInputHRAndRateInformation_AnnualSalary)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.LabelHRAndRateInformation_BillRate)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.LabelHRAndRateInformation_CostRate)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.LabelHRAndRateInformation_HourlyBillCostData)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.TextBoxHRAndRateInformation_OtherInfo)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.LabelHRAndRateInformation_OtherInfo)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.LabelHRAndRateInformation_OtherInfoHeader)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.LabelHRAndRateInformation_BillingRates)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.LabelHRAndRateInformation_SalaryInformation)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.RateFlagEntryControlHRAndRateInformation_BillingRateDetails)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.LabelHRAndRateInformation_AnnualSalary)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.LabelHRAndRateInformation_MonthlySalary)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.DateTimePickerHRAndRateInformation_TerminationDate)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.DateTimePickerHRAndRateInformation_NextReviewDate)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.DateTimePickerHRAndRateInformation_BirthDate)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.DateTimePickerHRAndRateInformation_EmploymentDate)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.LabelHRAndRateInformation_TerminationDate)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.LabelHRAndRateInformation_NextReviewDate)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.LabelHRAndRateInformation_DateOfLastIncrease)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.LabelHRAndRateInformation_BirthDate)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.LabelHRAndRateInformation_EmploymentDate)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Controls.Add(Me.LabelHRAndRateInformation_EmployeeDates)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Name = "TabControlPanelHRAndRateInformationTab_HRAndRateInformation"
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Size = New System.Drawing.Size(738, 523)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.Style.GradientAngle = 90
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.TabIndex = 11
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.TabItem = Me.TabItemEmployeeDetails_HRAndRateInformationTab
            '
            'NumericInputHRAndRateInformation_CostRate
            '
            Me.NumericInputHRAndRateInformation_CostRate.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputHRAndRateInformation_CostRate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputHRAndRateInformation_CostRate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputHRAndRateInformation_CostRate.Enabled = False
            Me.NumericInputHRAndRateInformation_CostRate.EnterMoveNextControl = True
            Me.NumericInputHRAndRateInformation_CostRate.Location = New System.Drawing.Point(348, 136)
            Me.NumericInputHRAndRateInformation_CostRate.Name = "NumericInputHRAndRateInformation_CostRate"
            Me.NumericInputHRAndRateInformation_CostRate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputHRAndRateInformation_CostRate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputHRAndRateInformation_CostRate.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputHRAndRateInformation_CostRate.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputHRAndRateInformation_CostRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHRAndRateInformation_CostRate.Properties.EditFormat.FormatString = "f"
            Me.NumericInputHRAndRateInformation_CostRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHRAndRateInformation_CostRate.Properties.Mask.EditMask = "f"
            Me.NumericInputHRAndRateInformation_CostRate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputHRAndRateInformation_CostRate.SecurityEnabled = True
            Me.NumericInputHRAndRateInformation_CostRate.Size = New System.Drawing.Size(103, 20)
            Me.NumericInputHRAndRateInformation_CostRate.TabIndex = 20
            '
            'NumericInputHRAndRateInformation_BillRate
            '
            Me.NumericInputHRAndRateInformation_BillRate.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputHRAndRateInformation_BillRate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputHRAndRateInformation_BillRate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputHRAndRateInformation_BillRate.EnterMoveNextControl = True
            Me.NumericInputHRAndRateInformation_BillRate.Location = New System.Drawing.Point(348, 110)
            Me.NumericInputHRAndRateInformation_BillRate.Name = "NumericInputHRAndRateInformation_BillRate"
            Me.NumericInputHRAndRateInformation_BillRate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputHRAndRateInformation_BillRate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputHRAndRateInformation_BillRate.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputHRAndRateInformation_BillRate.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputHRAndRateInformation_BillRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHRAndRateInformation_BillRate.Properties.EditFormat.FormatString = "f"
            Me.NumericInputHRAndRateInformation_BillRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHRAndRateInformation_BillRate.Properties.Mask.EditMask = "f"
            Me.NumericInputHRAndRateInformation_BillRate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputHRAndRateInformation_BillRate.SecurityEnabled = True
            Me.NumericInputHRAndRateInformation_BillRate.Size = New System.Drawing.Size(103, 20)
            Me.NumericInputHRAndRateInformation_BillRate.TabIndex = 18
            '
            'NumericInputHRAndRateInformation_MonthlySalary
            '
            Me.NumericInputHRAndRateInformation_MonthlySalary.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputHRAndRateInformation_MonthlySalary.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputHRAndRateInformation_MonthlySalary.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputHRAndRateInformation_MonthlySalary.EnterMoveNextControl = True
            Me.NumericInputHRAndRateInformation_MonthlySalary.Location = New System.Drawing.Point(348, 58)
            Me.NumericInputHRAndRateInformation_MonthlySalary.Name = "NumericInputHRAndRateInformation_MonthlySalary"
            Me.NumericInputHRAndRateInformation_MonthlySalary.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputHRAndRateInformation_MonthlySalary.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputHRAndRateInformation_MonthlySalary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHRAndRateInformation_MonthlySalary.Properties.EditFormat.FormatString = "f"
            Me.NumericInputHRAndRateInformation_MonthlySalary.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHRAndRateInformation_MonthlySalary.Properties.Mask.EditMask = "f"
            Me.NumericInputHRAndRateInformation_MonthlySalary.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputHRAndRateInformation_MonthlySalary.SecurityEnabled = True
            Me.NumericInputHRAndRateInformation_MonthlySalary.Size = New System.Drawing.Size(103, 20)
            Me.NumericInputHRAndRateInformation_MonthlySalary.TabIndex = 15
            '
            'NumericInputHRAndRateInformation_AnnualSalary
            '
            Me.NumericInputHRAndRateInformation_AnnualSalary.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputHRAndRateInformation_AnnualSalary.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Default]
            Me.NumericInputHRAndRateInformation_AnnualSalary.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputHRAndRateInformation_AnnualSalary.EnterMoveNextControl = True
            Me.NumericInputHRAndRateInformation_AnnualSalary.Location = New System.Drawing.Point(348, 32)
            Me.NumericInputHRAndRateInformation_AnnualSalary.Name = "NumericInputHRAndRateInformation_AnnualSalary"
            Me.NumericInputHRAndRateInformation_AnnualSalary.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputHRAndRateInformation_AnnualSalary.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputHRAndRateInformation_AnnualSalary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHRAndRateInformation_AnnualSalary.Properties.EditFormat.FormatString = "f"
            Me.NumericInputHRAndRateInformation_AnnualSalary.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHRAndRateInformation_AnnualSalary.Properties.Mask.EditMask = "f"
            Me.NumericInputHRAndRateInformation_AnnualSalary.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputHRAndRateInformation_AnnualSalary.SecurityEnabled = True
            Me.NumericInputHRAndRateInformation_AnnualSalary.Size = New System.Drawing.Size(103, 20)
            Me.NumericInputHRAndRateInformation_AnnualSalary.TabIndex = 13
            '
            'LabelHRAndRateInformation_BillRate
            '
            Me.LabelHRAndRateInformation_BillRate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHRAndRateInformation_BillRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHRAndRateInformation_BillRate.Location = New System.Drawing.Point(258, 110)
            Me.LabelHRAndRateInformation_BillRate.Name = "LabelHRAndRateInformation_BillRate"
            Me.LabelHRAndRateInformation_BillRate.Size = New System.Drawing.Size(84, 20)
            Me.LabelHRAndRateInformation_BillRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHRAndRateInformation_BillRate.TabIndex = 17
            Me.LabelHRAndRateInformation_BillRate.Text = "Bill Rate:"
            '
            'LabelHRAndRateInformation_CostRate
            '
            Me.LabelHRAndRateInformation_CostRate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHRAndRateInformation_CostRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHRAndRateInformation_CostRate.Location = New System.Drawing.Point(258, 136)
            Me.LabelHRAndRateInformation_CostRate.Name = "LabelHRAndRateInformation_CostRate"
            Me.LabelHRAndRateInformation_CostRate.Size = New System.Drawing.Size(84, 20)
            Me.LabelHRAndRateInformation_CostRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHRAndRateInformation_CostRate.TabIndex = 19
            Me.LabelHRAndRateInformation_CostRate.Text = "Cost Rate:"
            '
            'LabelHRAndRateInformation_HourlyBillCostData
            '
            Me.LabelHRAndRateInformation_HourlyBillCostData.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHRAndRateInformation_HourlyBillCostData.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_HourlyBillCostData.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelHRAndRateInformation_HourlyBillCostData.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelHRAndRateInformation_HourlyBillCostData.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_HourlyBillCostData.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_HourlyBillCostData.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_HourlyBillCostData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHRAndRateInformation_HourlyBillCostData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHRAndRateInformation_HourlyBillCostData.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelHRAndRateInformation_HourlyBillCostData.Location = New System.Drawing.Point(258, 84)
            Me.LabelHRAndRateInformation_HourlyBillCostData.Name = "LabelHRAndRateInformation_HourlyBillCostData"
            Me.LabelHRAndRateInformation_HourlyBillCostData.Size = New System.Drawing.Size(193, 20)
            Me.LabelHRAndRateInformation_HourlyBillCostData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHRAndRateInformation_HourlyBillCostData.TabIndex = 16
            Me.LabelHRAndRateInformation_HourlyBillCostData.Text = "Hourly Bill / Cost Data"
            '
            'TextBoxHRAndRateInformation_OtherInfo
            '
            Me.TextBoxHRAndRateInformation_OtherInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxHRAndRateInformation_OtherInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxHRAndRateInformation_OtherInfo.Border.Class = "TextBoxBorder"
            Me.TextBoxHRAndRateInformation_OtherInfo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxHRAndRateInformation_OtherInfo.CheckSpellingOnValidate = False
            Me.TextBoxHRAndRateInformation_OtherInfo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.SocialSecurityNumber
            Me.TextBoxHRAndRateInformation_OtherInfo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxHRAndRateInformation_OtherInfo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxHRAndRateInformation_OtherInfo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxHRAndRateInformation_OtherInfo.FocusHighlightEnabled = True
            Me.TextBoxHRAndRateInformation_OtherInfo.ForeColor = System.Drawing.Color.Black
            Me.TextBoxHRAndRateInformation_OtherInfo.Location = New System.Drawing.Point(587, 32)
            Me.TextBoxHRAndRateInformation_OtherInfo.MaxFileSize = CType(0, Long)
            Me.TextBoxHRAndRateInformation_OtherInfo.Name = "TextBoxHRAndRateInformation_OtherInfo"
            Me.TextBoxHRAndRateInformation_OtherInfo.SecurityEnabled = True
            Me.TextBoxHRAndRateInformation_OtherInfo.ShowSpellCheckCompleteMessage = True
            Me.TextBoxHRAndRateInformation_OtherInfo.Size = New System.Drawing.Size(145, 20)
            Me.TextBoxHRAndRateInformation_OtherInfo.StartingFolderName = Nothing
            Me.TextBoxHRAndRateInformation_OtherInfo.TabIndex = 23
            Me.TextBoxHRAndRateInformation_OtherInfo.TabOnEnter = True
            '
            'LabelHRAndRateInformation_OtherInfo
            '
            Me.LabelHRAndRateInformation_OtherInfo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHRAndRateInformation_OtherInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHRAndRateInformation_OtherInfo.Location = New System.Drawing.Point(457, 32)
            Me.LabelHRAndRateInformation_OtherInfo.Name = "LabelHRAndRateInformation_OtherInfo"
            Me.LabelHRAndRateInformation_OtherInfo.Size = New System.Drawing.Size(124, 20)
            Me.LabelHRAndRateInformation_OtherInfo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHRAndRateInformation_OtherInfo.TabIndex = 22
            Me.LabelHRAndRateInformation_OtherInfo.Text = "Other Info:"
            '
            'LabelHRAndRateInformation_OtherInfoHeader
            '
            Me.LabelHRAndRateInformation_OtherInfoHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelHRAndRateInformation_OtherInfoHeader.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHRAndRateInformation_OtherInfoHeader.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_OtherInfoHeader.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelHRAndRateInformation_OtherInfoHeader.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelHRAndRateInformation_OtherInfoHeader.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_OtherInfoHeader.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_OtherInfoHeader.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_OtherInfoHeader.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHRAndRateInformation_OtherInfoHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHRAndRateInformation_OtherInfoHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelHRAndRateInformation_OtherInfoHeader.Location = New System.Drawing.Point(457, 6)
            Me.LabelHRAndRateInformation_OtherInfoHeader.Name = "LabelHRAndRateInformation_OtherInfoHeader"
            Me.LabelHRAndRateInformation_OtherInfoHeader.Size = New System.Drawing.Size(275, 20)
            Me.LabelHRAndRateInformation_OtherInfoHeader.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHRAndRateInformation_OtherInfoHeader.TabIndex = 21
            Me.LabelHRAndRateInformation_OtherInfoHeader.Text = "Other Info"
            '
            'LabelHRAndRateInformation_BillingRates
            '
            Me.LabelHRAndRateInformation_BillingRates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelHRAndRateInformation_BillingRates.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHRAndRateInformation_BillingRates.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_BillingRates.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelHRAndRateInformation_BillingRates.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelHRAndRateInformation_BillingRates.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_BillingRates.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_BillingRates.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_BillingRates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHRAndRateInformation_BillingRates.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHRAndRateInformation_BillingRates.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelHRAndRateInformation_BillingRates.Location = New System.Drawing.Point(6, 162)
            Me.LabelHRAndRateInformation_BillingRates.Name = "LabelHRAndRateInformation_BillingRates"
            Me.LabelHRAndRateInformation_BillingRates.Size = New System.Drawing.Size(726, 20)
            Me.LabelHRAndRateInformation_BillingRates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHRAndRateInformation_BillingRates.TabIndex = 24
            Me.LabelHRAndRateInformation_BillingRates.Text = "Billing Rates"
            '
            'LabelHRAndRateInformation_SalaryInformation
            '
            Me.LabelHRAndRateInformation_SalaryInformation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHRAndRateInformation_SalaryInformation.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_SalaryInformation.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelHRAndRateInformation_SalaryInformation.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelHRAndRateInformation_SalaryInformation.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_SalaryInformation.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_SalaryInformation.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_SalaryInformation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHRAndRateInformation_SalaryInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHRAndRateInformation_SalaryInformation.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelHRAndRateInformation_SalaryInformation.Location = New System.Drawing.Point(258, 6)
            Me.LabelHRAndRateInformation_SalaryInformation.Name = "LabelHRAndRateInformation_SalaryInformation"
            Me.LabelHRAndRateInformation_SalaryInformation.Size = New System.Drawing.Size(193, 20)
            Me.LabelHRAndRateInformation_SalaryInformation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHRAndRateInformation_SalaryInformation.TabIndex = 11
            Me.LabelHRAndRateInformation_SalaryInformation.Text = "Salary Information"
            '
            'RateFlagEntryControlHRAndRateInformation_BillingRateDetails
            '
            Me.RateFlagEntryControlHRAndRateInformation_BillingRateDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RateFlagEntryControlHRAndRateInformation_BillingRateDetails.BackColor = System.Drawing.Color.White
            Me.RateFlagEntryControlHRAndRateInformation_BillingRateDetails.DisableInactiveFilter = False
            Me.RateFlagEntryControlHRAndRateInformation_BillingRateDetails.HideStructureLevelSelection = False
            Me.RateFlagEntryControlHRAndRateInformation_BillingRateDetails.LimitToEmployeeLevels = False
            Me.RateFlagEntryControlHRAndRateInformation_BillingRateDetails.Location = New System.Drawing.Point(6, 189)
            Me.RateFlagEntryControlHRAndRateInformation_BillingRateDetails.Name = "RateFlagEntryControlHRAndRateInformation_BillingRateDetails"
            Me.RateFlagEntryControlHRAndRateInformation_BillingRateDetails.SelectedBillingRateLevel = CType(0, Short)
            Me.RateFlagEntryControlHRAndRateInformation_BillingRateDetails.ShowDescriptions = False
            Me.RateFlagEntryControlHRAndRateInformation_BillingRateDetails.Size = New System.Drawing.Size(726, 328)
            Me.RateFlagEntryControlHRAndRateInformation_BillingRateDetails.TabIndex = 25
            Me.RateFlagEntryControlHRAndRateInformation_BillingRateDetails.ViewInactiveBillingRateDetails = False
            '
            'LabelHRAndRateInformation_AnnualSalary
            '
            Me.LabelHRAndRateInformation_AnnualSalary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHRAndRateInformation_AnnualSalary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHRAndRateInformation_AnnualSalary.Location = New System.Drawing.Point(258, 32)
            Me.LabelHRAndRateInformation_AnnualSalary.Name = "LabelHRAndRateInformation_AnnualSalary"
            Me.LabelHRAndRateInformation_AnnualSalary.Size = New System.Drawing.Size(84, 20)
            Me.LabelHRAndRateInformation_AnnualSalary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHRAndRateInformation_AnnualSalary.TabIndex = 12
            Me.LabelHRAndRateInformation_AnnualSalary.Text = "Annual Salary:"
            '
            'LabelHRAndRateInformation_MonthlySalary
            '
            Me.LabelHRAndRateInformation_MonthlySalary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHRAndRateInformation_MonthlySalary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHRAndRateInformation_MonthlySalary.Location = New System.Drawing.Point(258, 58)
            Me.LabelHRAndRateInformation_MonthlySalary.Name = "LabelHRAndRateInformation_MonthlySalary"
            Me.LabelHRAndRateInformation_MonthlySalary.Size = New System.Drawing.Size(84, 20)
            Me.LabelHRAndRateInformation_MonthlySalary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHRAndRateInformation_MonthlySalary.TabIndex = 14
            Me.LabelHRAndRateInformation_MonthlySalary.Text = "Monthly Salary:"
            '
            'DateTimePickerHRAndRateInformation_TerminationDate
            '
            Me.DateTimePickerHRAndRateInformation_TerminationDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_TerminationDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerHRAndRateInformation_TerminationDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_TerminationDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerHRAndRateInformation_TerminationDate.ButtonDropDown.Visible = True
            Me.DateTimePickerHRAndRateInformation_TerminationDate.ButtonFreeText.Checked = True
            Me.DateTimePickerHRAndRateInformation_TerminationDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerHRAndRateInformation_TerminationDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerHRAndRateInformation_TerminationDate.DisplayName = ""
            Me.DateTimePickerHRAndRateInformation_TerminationDate.Enabled = False
            Me.DateTimePickerHRAndRateInformation_TerminationDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerHRAndRateInformation_TerminationDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerHRAndRateInformation_TerminationDate.FocusHighlightEnabled = True
            Me.DateTimePickerHRAndRateInformation_TerminationDate.FreeTextEntryMode = True
            Me.DateTimePickerHRAndRateInformation_TerminationDate.IsPopupCalendarOpen = False
            Me.DateTimePickerHRAndRateInformation_TerminationDate.Location = New System.Drawing.Point(136, 136)
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.DisplayMonth = New Date(2012, 5, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_TerminationDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerHRAndRateInformation_TerminationDate.Name = "DateTimePickerHRAndRateInformation_TerminationDate"
            Me.DateTimePickerHRAndRateInformation_TerminationDate.ReadOnly = False
            Me.DateTimePickerHRAndRateInformation_TerminationDate.Size = New System.Drawing.Size(116, 20)
            Me.DateTimePickerHRAndRateInformation_TerminationDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerHRAndRateInformation_TerminationDate.TabIndex = 10
            Me.DateTimePickerHRAndRateInformation_TerminationDate.TabOnEnter = True
            Me.DateTimePickerHRAndRateInformation_TerminationDate.Value = New Date(2013, 5, 6, 10, 53, 48, 193)
            '
            'DateTimePickerHRAndRateInformation_NextReviewDate
            '
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.ButtonDropDown.Visible = True
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.ButtonFreeText.Checked = True
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.DisplayName = ""
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.FocusHighlightEnabled = True
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.FreeTextEntryMode = True
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.IsPopupCalendarOpen = False
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.Location = New System.Drawing.Point(136, 110)
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.DisplayMonth = New Date(2012, 5, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.Name = "DateTimePickerHRAndRateInformation_NextReviewDate"
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.ReadOnly = False
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.Size = New System.Drawing.Size(116, 20)
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.TabIndex = 8
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.TabOnEnter = True
            Me.DateTimePickerHRAndRateInformation_NextReviewDate.Value = New Date(2013, 5, 6, 10, 53, 48, 223)
            '
            'DateTimePickerHRAndRateInformation_DateOfLastIncrease
            '
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.ButtonDropDown.Visible = True
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.ButtonFreeText.Checked = True
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.DisplayName = ""
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.FocusHighlightEnabled = True
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.FreeTextEntryMode = True
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.IsPopupCalendarOpen = False
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.Location = New System.Drawing.Point(136, 84)
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.DisplayMonth = New Date(2012, 5, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.Name = "DateTimePickerHRAndRateInformation_DateOfLastIncrease"
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.ReadOnly = False
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.Size = New System.Drawing.Size(116, 20)
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.TabIndex = 6
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.TabOnEnter = True
            Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease.Value = New Date(2013, 5, 6, 10, 53, 48, 240)
            '
            'DateTimePickerHRAndRateInformation_BirthDate
            '
            Me.DateTimePickerHRAndRateInformation_BirthDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_BirthDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerHRAndRateInformation_BirthDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_BirthDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerHRAndRateInformation_BirthDate.ButtonDropDown.Visible = True
            Me.DateTimePickerHRAndRateInformation_BirthDate.ButtonFreeText.Checked = True
            Me.DateTimePickerHRAndRateInformation_BirthDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerHRAndRateInformation_BirthDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerHRAndRateInformation_BirthDate.DisplayName = ""
            Me.DateTimePickerHRAndRateInformation_BirthDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerHRAndRateInformation_BirthDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerHRAndRateInformation_BirthDate.FocusHighlightEnabled = True
            Me.DateTimePickerHRAndRateInformation_BirthDate.FreeTextEntryMode = True
            Me.DateTimePickerHRAndRateInformation_BirthDate.IsPopupCalendarOpen = False
            Me.DateTimePickerHRAndRateInformation_BirthDate.Location = New System.Drawing.Point(136, 58)
            Me.DateTimePickerHRAndRateInformation_BirthDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerHRAndRateInformation_BirthDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.DisplayMonth = New Date(2012, 5, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_BirthDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerHRAndRateInformation_BirthDate.Name = "DateTimePickerHRAndRateInformation_BirthDate"
            Me.DateTimePickerHRAndRateInformation_BirthDate.ReadOnly = False
            Me.DateTimePickerHRAndRateInformation_BirthDate.Size = New System.Drawing.Size(116, 20)
            Me.DateTimePickerHRAndRateInformation_BirthDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerHRAndRateInformation_BirthDate.TabIndex = 4
            Me.DateTimePickerHRAndRateInformation_BirthDate.TabOnEnter = True
            Me.DateTimePickerHRAndRateInformation_BirthDate.Value = New Date(2013, 5, 6, 10, 53, 48, 261)
            '
            'DateTimePickerHRAndRateInformation_EmploymentDate
            '
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.ButtonDropDown.Visible = True
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.ButtonFreeText.Checked = True
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.DisplayName = ""
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.FocusHighlightEnabled = True
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.FreeTextEntryMode = True
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.IsPopupCalendarOpen = False
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.Location = New System.Drawing.Point(136, 32)
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.DisplayMonth = New Date(2012, 5, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.Name = "DateTimePickerHRAndRateInformation_EmploymentDate"
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.ReadOnly = False
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.Size = New System.Drawing.Size(116, 20)
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.TabIndex = 2
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.TabOnEnter = True
            Me.DateTimePickerHRAndRateInformation_EmploymentDate.Value = New Date(2013, 5, 6, 10, 53, 48, 278)
            '
            'LabelHRAndRateInformation_TerminationDate
            '
            Me.LabelHRAndRateInformation_TerminationDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHRAndRateInformation_TerminationDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHRAndRateInformation_TerminationDate.Location = New System.Drawing.Point(6, 136)
            Me.LabelHRAndRateInformation_TerminationDate.Name = "LabelHRAndRateInformation_TerminationDate"
            Me.LabelHRAndRateInformation_TerminationDate.Size = New System.Drawing.Size(124, 20)
            Me.LabelHRAndRateInformation_TerminationDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHRAndRateInformation_TerminationDate.TabIndex = 9
            Me.LabelHRAndRateInformation_TerminationDate.Text = "Termination Date:"
            '
            'LabelHRAndRateInformation_NextReviewDate
            '
            Me.LabelHRAndRateInformation_NextReviewDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHRAndRateInformation_NextReviewDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHRAndRateInformation_NextReviewDate.Location = New System.Drawing.Point(6, 110)
            Me.LabelHRAndRateInformation_NextReviewDate.Name = "LabelHRAndRateInformation_NextReviewDate"
            Me.LabelHRAndRateInformation_NextReviewDate.Size = New System.Drawing.Size(124, 20)
            Me.LabelHRAndRateInformation_NextReviewDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHRAndRateInformation_NextReviewDate.TabIndex = 7
            Me.LabelHRAndRateInformation_NextReviewDate.Text = "Next Review Date:"
            '
            'LabelHRAndRateInformation_DateOfLastIncrease
            '
            Me.LabelHRAndRateInformation_DateOfLastIncrease.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHRAndRateInformation_DateOfLastIncrease.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHRAndRateInformation_DateOfLastIncrease.Location = New System.Drawing.Point(6, 84)
            Me.LabelHRAndRateInformation_DateOfLastIncrease.Name = "LabelHRAndRateInformation_DateOfLastIncrease"
            Me.LabelHRAndRateInformation_DateOfLastIncrease.Size = New System.Drawing.Size(124, 20)
            Me.LabelHRAndRateInformation_DateOfLastIncrease.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHRAndRateInformation_DateOfLastIncrease.TabIndex = 5
            Me.LabelHRAndRateInformation_DateOfLastIncrease.Text = "Date of Last Increase:"
            '
            'LabelHRAndRateInformation_BirthDate
            '
            Me.LabelHRAndRateInformation_BirthDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHRAndRateInformation_BirthDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHRAndRateInformation_BirthDate.Location = New System.Drawing.Point(6, 58)
            Me.LabelHRAndRateInformation_BirthDate.Name = "LabelHRAndRateInformation_BirthDate"
            Me.LabelHRAndRateInformation_BirthDate.Size = New System.Drawing.Size(124, 20)
            Me.LabelHRAndRateInformation_BirthDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHRAndRateInformation_BirthDate.TabIndex = 3
            Me.LabelHRAndRateInformation_BirthDate.Text = "Birth Date:"
            '
            'LabelHRAndRateInformation_EmploymentDate
            '
            Me.LabelHRAndRateInformation_EmploymentDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHRAndRateInformation_EmploymentDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHRAndRateInformation_EmploymentDate.Location = New System.Drawing.Point(6, 32)
            Me.LabelHRAndRateInformation_EmploymentDate.Name = "LabelHRAndRateInformation_EmploymentDate"
            Me.LabelHRAndRateInformation_EmploymentDate.Size = New System.Drawing.Size(124, 20)
            Me.LabelHRAndRateInformation_EmploymentDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHRAndRateInformation_EmploymentDate.TabIndex = 1
            Me.LabelHRAndRateInformation_EmploymentDate.Text = "Employment Date:"
            '
            'LabelHRAndRateInformation_EmployeeDates
            '
            Me.LabelHRAndRateInformation_EmployeeDates.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHRAndRateInformation_EmployeeDates.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_EmployeeDates.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelHRAndRateInformation_EmployeeDates.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelHRAndRateInformation_EmployeeDates.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_EmployeeDates.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_EmployeeDates.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHRAndRateInformation_EmployeeDates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHRAndRateInformation_EmployeeDates.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHRAndRateInformation_EmployeeDates.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelHRAndRateInformation_EmployeeDates.Location = New System.Drawing.Point(6, 6)
            Me.LabelHRAndRateInformation_EmployeeDates.Name = "LabelHRAndRateInformation_EmployeeDates"
            Me.LabelHRAndRateInformation_EmployeeDates.Size = New System.Drawing.Size(246, 20)
            Me.LabelHRAndRateInformation_EmployeeDates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHRAndRateInformation_EmployeeDates.TabIndex = 0
            Me.LabelHRAndRateInformation_EmployeeDates.Text = "Employee Dates"
            '
            'TabItemEmployeeDetails_HRAndRateInformationTab
            '
            Me.TabItemEmployeeDetails_HRAndRateInformationTab.AttachedControl = Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation
            Me.TabItemEmployeeDetails_HRAndRateInformationTab.Name = "TabItemEmployeeDetails_HRAndRateInformationTab"
            Me.TabItemEmployeeDetails_HRAndRateInformationTab.Text = "H/R && Rate Information"
            '
            'TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords
            '
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.Controls.Add(Me.SearchableComboBoxSecurityAndPasswords_User)
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.Controls.Add(Me.LabelSecurityAndPasswords_User)
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.Controls.Add(Me.TabControlSecurityAndPasswords_SecurityAndPasswords)
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.Name = "TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords"
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.Size = New System.Drawing.Size(738, 523)
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.Style.GradientAngle = 90
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.TabIndex = 13
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.TabItem = Me.TabItemEmployeeDetails_SecurityAndPasswords
            '
            'SearchableComboBoxSecurityAndPasswords_User
            '
            Me.SearchableComboBoxSecurityAndPasswords_User.ActiveFilterString = ""
            Me.SearchableComboBoxSecurityAndPasswords_User.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSecurityAndPasswords_User.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSecurityAndPasswords_User.AutoFillMode = False
            Me.SearchableComboBoxSecurityAndPasswords_User.BookmarkingEnabled = False
            Me.SearchableComboBoxSecurityAndPasswords_User.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.User
            Me.SearchableComboBoxSecurityAndPasswords_User.DataSource = Nothing
            Me.SearchableComboBoxSecurityAndPasswords_User.DisableMouseWheel = False
            Me.SearchableComboBoxSecurityAndPasswords_User.DisplayName = ""
            Me.SearchableComboBoxSecurityAndPasswords_User.EnterMoveNextControl = True
            Me.SearchableComboBoxSecurityAndPasswords_User.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxSecurityAndPasswords_User.Location = New System.Drawing.Point(46, 5)
            Me.SearchableComboBoxSecurityAndPasswords_User.Name = "SearchableComboBoxSecurityAndPasswords_User"
            Me.SearchableComboBoxSecurityAndPasswords_User.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSecurityAndPasswords_User.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxSecurityAndPasswords_User.Properties.NullText = "Select User"
            Me.SearchableComboBoxSecurityAndPasswords_User.Properties.PopupView = Me.GridView9
            Me.SearchableComboBoxSecurityAndPasswords_User.Properties.ShowClearButton = False
            Me.SearchableComboBoxSecurityAndPasswords_User.Properties.ValueMember = "ID"
            Me.SearchableComboBoxSecurityAndPasswords_User.SecurityEnabled = True
            Me.SearchableComboBoxSecurityAndPasswords_User.SelectedValue = Nothing
            Me.SearchableComboBoxSecurityAndPasswords_User.Size = New System.Drawing.Size(682, 20)
            Me.SearchableComboBoxSecurityAndPasswords_User.TabIndex = 1
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
            'LabelSecurityAndPasswords_User
            '
            Me.LabelSecurityAndPasswords_User.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSecurityAndPasswords_User.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSecurityAndPasswords_User.Location = New System.Drawing.Point(6, 5)
            Me.LabelSecurityAndPasswords_User.Name = "LabelSecurityAndPasswords_User"
            Me.LabelSecurityAndPasswords_User.Size = New System.Drawing.Size(34, 20)
            Me.LabelSecurityAndPasswords_User.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSecurityAndPasswords_User.TabIndex = 0
            Me.LabelSecurityAndPasswords_User.Text = "User:"
            '
            'TabControlSecurityAndPasswords_SecurityAndPasswords
            '
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.CanReorderTabs = True
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.Controls.Add(Me.TabControlPanelSecurityGroupTab_SecurityGroup)
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.Controls.Add(Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits)
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.Controls.Add(Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits)
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.Controls.Add(Me.TabControlPanelCDPLimitsTab_CDPLimits)
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.Controls.Add(Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits)
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.ForeColor = System.Drawing.Color.Black
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.Location = New System.Drawing.Point(7, 31)
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.Name = "TabControlSecurityAndPasswords_SecurityAndPasswords"
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.SelectedTabIndex = 0
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.Size = New System.Drawing.Size(724, 485)
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.TabIndex = 2
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.Tabs.Add(Me.TabItemSecurityAndPasswords_SecurityGroupTab)
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.Tabs.Add(Me.TabItemSecurityAndPasswords_EmployeeOfficeLimitsTab)
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.Tabs.Add(Me.TabItemSecurityAndPasswords_CDPLimitsTab)
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.Tabs.Add(Me.TabItemSecurityAndPasswords_EmployeeLimitsTab)
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.Tabs.Add(Me.TabItemSecurityAndPasswords_EmployeeTSFunctionLimitsTab)
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.Text = "Tabcontrol"
            '
            'TabControlPanelSecurityGroupTab_SecurityGroup
            '
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.Controls.Add(Me.PanelSecurityGroup_RightSection)
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.Controls.Add(Me.ExpandableSplitterControlSecurityGroup_LeftRight)
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.Controls.Add(Me.PanelSecurityGroup_LeftSection)
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.Name = "TabControlPanelSecurityGroupTab_SecurityGroup"
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.Size = New System.Drawing.Size(724, 458)
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.Style.GradientAngle = 90
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.TabIndex = 0
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.TabItem = Me.TabItemSecurityAndPasswords_SecurityGroupTab
            '
            'PanelSecurityGroup_RightSection
            '
            Me.PanelSecurityGroup_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSecurityGroup_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelSecurityGroup_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelSecurityGroup_RightSection.Controls.Add(Me.ButtonRightSection_RemoveSecurityGroup)
            Me.PanelSecurityGroup_RightSection.Controls.Add(Me.ButtonRightSection_AddSecurityGroup)
            Me.PanelSecurityGroup_RightSection.Controls.Add(Me.DataGridViewRightSection_EmployeeSecurityGroups)
            Me.PanelSecurityGroup_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelSecurityGroup_RightSection.Location = New System.Drawing.Point(243, 1)
            Me.PanelSecurityGroup_RightSection.Name = "PanelSecurityGroup_RightSection"
            Me.PanelSecurityGroup_RightSection.Size = New System.Drawing.Size(480, 456)
            Me.PanelSecurityGroup_RightSection.TabIndex = 3
            '
            'ButtonRightSection_RemoveSecurityGroup
            '
            Me.ButtonRightSection_RemoveSecurityGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveSecurityGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveSecurityGroup.Location = New System.Drawing.Point(6, 32)
            Me.ButtonRightSection_RemoveSecurityGroup.Name = "ButtonRightSection_RemoveSecurityGroup"
            Me.ButtonRightSection_RemoveSecurityGroup.SecurityEnabled = True
            Me.ButtonRightSection_RemoveSecurityGroup.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveSecurityGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveSecurityGroup.TabIndex = 117
            Me.ButtonRightSection_RemoveSecurityGroup.Text = "<"
            '
            'ButtonRightSection_AddSecurityGroup
            '
            Me.ButtonRightSection_AddSecurityGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddSecurityGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddSecurityGroup.Location = New System.Drawing.Point(6, 6)
            Me.ButtonRightSection_AddSecurityGroup.Name = "ButtonRightSection_AddSecurityGroup"
            Me.ButtonRightSection_AddSecurityGroup.SecurityEnabled = True
            Me.ButtonRightSection_AddSecurityGroup.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddSecurityGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddSecurityGroup.TabIndex = 116
            Me.ButtonRightSection_AddSecurityGroup.Text = ">"
            '
            'DataGridViewRightSection_EmployeeSecurityGroups
            '
            Me.DataGridViewRightSection_EmployeeSecurityGroups.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightSection_EmployeeSecurityGroups.AllowDragAndDrop = False
            Me.DataGridViewRightSection_EmployeeSecurityGroups.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_EmployeeSecurityGroups.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_EmployeeSecurityGroups.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_EmployeeSecurityGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_EmployeeSecurityGroups.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_EmployeeSecurityGroups.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_EmployeeSecurityGroups.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_EmployeeSecurityGroups.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewRightSection_EmployeeSecurityGroups.DataSource = Nothing
            Me.DataGridViewRightSection_EmployeeSecurityGroups.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_EmployeeSecurityGroups.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_EmployeeSecurityGroups.ItemDescription = ""
            Me.DataGridViewRightSection_EmployeeSecurityGroups.Location = New System.Drawing.Point(87, 6)
            Me.DataGridViewRightSection_EmployeeSecurityGroups.MultiSelect = True
            Me.DataGridViewRightSection_EmployeeSecurityGroups.Name = "DataGridViewRightSection_EmployeeSecurityGroups"
            Me.DataGridViewRightSection_EmployeeSecurityGroups.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_EmployeeSecurityGroups.RunStandardValidation = True
            Me.DataGridViewRightSection_EmployeeSecurityGroups.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightSection_EmployeeSecurityGroups.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_EmployeeSecurityGroups.Size = New System.Drawing.Size(388, 445)
            Me.DataGridViewRightSection_EmployeeSecurityGroups.TabIndex = 1
            Me.DataGridViewRightSection_EmployeeSecurityGroups.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_EmployeeSecurityGroups.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlSecurityGroup_LeftRight
            '
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.ExpandableControl = Me.PanelSecurityGroup_LeftSection
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.Location = New System.Drawing.Point(237, 1)
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.Name = "ExpandableSplitterControlSecurityGroup_LeftRight"
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.Size = New System.Drawing.Size(6, 456)
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.TabIndex = 2
            Me.ExpandableSplitterControlSecurityGroup_LeftRight.TabStop = False
            '
            'PanelSecurityGroup_LeftSection
            '
            Me.PanelSecurityGroup_LeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelSecurityGroup_LeftSection.Appearance.Options.UseBackColor = True
            Me.PanelSecurityGroup_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelSecurityGroup_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableSecurityGroups)
            Me.PanelSecurityGroup_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelSecurityGroup_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelSecurityGroup_LeftSection.Name = "PanelSecurityGroup_LeftSection"
            Me.PanelSecurityGroup_LeftSection.Size = New System.Drawing.Size(236, 456)
            Me.PanelSecurityGroup_LeftSection.TabIndex = 1
            '
            'DataGridViewLeftSection_AvailableSecurityGroups
            '
            Me.DataGridViewLeftSection_AvailableSecurityGroups.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_AvailableSecurityGroups.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_AvailableSecurityGroups.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_AvailableSecurityGroups.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableSecurityGroups.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableSecurityGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableSecurityGroups.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AvailableSecurityGroups.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AvailableSecurityGroups.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_AvailableSecurityGroups.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewLeftSection_AvailableSecurityGroups.DataSource = Nothing
            Me.DataGridViewLeftSection_AvailableSecurityGroups.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_AvailableSecurityGroups.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableSecurityGroups.ItemDescription = ""
            Me.DataGridViewLeftSection_AvailableSecurityGroups.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewLeftSection_AvailableSecurityGroups.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableSecurityGroups.Name = "DataGridViewLeftSection_AvailableSecurityGroups"
            Me.DataGridViewLeftSection_AvailableSecurityGroups.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableSecurityGroups.RunStandardValidation = True
            Me.DataGridViewLeftSection_AvailableSecurityGroups.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_AvailableSecurityGroups.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableSecurityGroups.Size = New System.Drawing.Size(224, 445)
            Me.DataGridViewLeftSection_AvailableSecurityGroups.TabIndex = 0
            Me.DataGridViewLeftSection_AvailableSecurityGroups.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableSecurityGroups.ViewCaptionHeight = -1
            '
            'TabItemSecurityAndPasswords_SecurityGroupTab
            '
            Me.TabItemSecurityAndPasswords_SecurityGroupTab.AttachedControl = Me.TabControlPanelSecurityGroupTab_SecurityGroup
            Me.TabItemSecurityAndPasswords_SecurityGroupTab.Name = "TabItemSecurityAndPasswords_SecurityGroupTab"
            Me.TabItemSecurityAndPasswords_SecurityGroupTab.Text = "Security Group"
            '
            'TabControlPanelEmployeeLimitsTab_EmployeeLimits
            '
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.Controls.Add(Me.UserEmployeeLimitControlEmployeeLimits_EmployeeLimits)
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.Name = "TabControlPanelEmployeeLimitsTab_EmployeeLimits"
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.Size = New System.Drawing.Size(724, 458)
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.Style.GradientAngle = 90
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.TabIndex = 3
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.TabItem = Me.TabItemSecurityAndPasswords_EmployeeLimitsTab
            '
            'UserEmployeeLimitControlEmployeeLimits_EmployeeLimits
            '
            Me.UserEmployeeLimitControlEmployeeLimits_EmployeeLimits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.UserEmployeeLimitControlEmployeeLimits_EmployeeLimits.Location = New System.Drawing.Point(6, 4)
            Me.UserEmployeeLimitControlEmployeeLimits_EmployeeLimits.Name = "UserEmployeeLimitControlEmployeeLimits_EmployeeLimits"
            Me.UserEmployeeLimitControlEmployeeLimits_EmployeeLimits.Size = New System.Drawing.Size(712, 448)
            Me.UserEmployeeLimitControlEmployeeLimits_EmployeeLimits.TabIndex = 0
            '
            'TabItemSecurityAndPasswords_EmployeeLimitsTab
            '
            Me.TabItemSecurityAndPasswords_EmployeeLimitsTab.AttachedControl = Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits
            Me.TabItemSecurityAndPasswords_EmployeeLimitsTab.Name = "TabItemSecurityAndPasswords_EmployeeLimitsTab"
            Me.TabItemSecurityAndPasswords_EmployeeLimitsTab.Text = "Employees"
            '
            'TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits
            '
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Controls.Add(Me.EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits)
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Name = "TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits"
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Size = New System.Drawing.Size(724, 458)
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.Style.GradientAngle = 90
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.TabIndex = 2
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.TabItem = Me.TabItemSecurityAndPasswords_EmployeeOfficeLimitsTab
            '
            'EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits
            '
            Me.EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.Location = New System.Drawing.Point(6, 4)
            Me.EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.Name = "EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits"
            Me.EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.Size = New System.Drawing.Size(712, 448)
            Me.EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.TabIndex = 0
            '
            'TabItemSecurityAndPasswords_EmployeeOfficeLimitsTab
            '
            Me.TabItemSecurityAndPasswords_EmployeeOfficeLimitsTab.AttachedControl = Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits
            Me.TabItemSecurityAndPasswords_EmployeeOfficeLimitsTab.Name = "TabItemSecurityAndPasswords_EmployeeOfficeLimitsTab"
            Me.TabItemSecurityAndPasswords_EmployeeOfficeLimitsTab.Text = "Offices"
            '
            'TabControlPanelCDPLimitsTab_CDPLimits
            '
            Me.TabControlPanelCDPLimitsTab_CDPLimits.Controls.Add(Me.UserCDPLimitControlCDPLimits_CDPLimits)
            Me.TabControlPanelCDPLimitsTab_CDPLimits.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCDPLimitsTab_CDPLimits.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCDPLimitsTab_CDPLimits.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCDPLimitsTab_CDPLimits.Name = "TabControlPanelCDPLimitsTab_CDPLimits"
            Me.TabControlPanelCDPLimitsTab_CDPLimits.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCDPLimitsTab_CDPLimits.Size = New System.Drawing.Size(724, 458)
            Me.TabControlPanelCDPLimitsTab_CDPLimits.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCDPLimitsTab_CDPLimits.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCDPLimitsTab_CDPLimits.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCDPLimitsTab_CDPLimits.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCDPLimitsTab_CDPLimits.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCDPLimitsTab_CDPLimits.Style.GradientAngle = 90
            Me.TabControlPanelCDPLimitsTab_CDPLimits.TabIndex = 4
            Me.TabControlPanelCDPLimitsTab_CDPLimits.TabItem = Me.TabItemSecurityAndPasswords_CDPLimitsTab
            '
            'UserCDPLimitControlCDPLimits_CDPLimits
            '
            Me.UserCDPLimitControlCDPLimits_CDPLimits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.UserCDPLimitControlCDPLimits_CDPLimits.Location = New System.Drawing.Point(6, 4)
            Me.UserCDPLimitControlCDPLimits_CDPLimits.Name = "UserCDPLimitControlCDPLimits_CDPLimits"
            Me.UserCDPLimitControlCDPLimits_CDPLimits.Size = New System.Drawing.Size(712, 449)
            Me.UserCDPLimitControlCDPLimits_CDPLimits.TabIndex = 0
            '
            'TabItemSecurityAndPasswords_CDPLimitsTab
            '
            Me.TabItemSecurityAndPasswords_CDPLimitsTab.AttachedControl = Me.TabControlPanelCDPLimitsTab_CDPLimits
            Me.TabItemSecurityAndPasswords_CDPLimitsTab.Name = "TabItemSecurityAndPasswords_CDPLimitsTab"
            Me.TabItemSecurityAndPasswords_CDPLimitsTab.Text = "Client Division Product"
            '
            'TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits
            '
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.Controls.Add(Me.EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunctionLimits)
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.Name = "TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits"
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.Size = New System.Drawing.Size(724, 458)
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.Style.GradientAngle = 90
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.TabIndex = 5
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.TabItem = Me.TabItemSecurityAndPasswords_EmployeeTSFunctionLimitsTab
            '
            'EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunctionLimits
            '
            Me.EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunctionLimits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunctionLimits.Location = New System.Drawing.Point(6, 4)
            Me.EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunctionLimits.Name = "EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunction" &
    "Limits"
            Me.EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunctionLimits.Size = New System.Drawing.Size(712, 448)
            Me.EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunctionLimits.TabIndex = 0
            '
            'TabItemSecurityAndPasswords_EmployeeTSFunctionLimitsTab
            '
            Me.TabItemSecurityAndPasswords_EmployeeTSFunctionLimitsTab.AttachedControl = Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits
            Me.TabItemSecurityAndPasswords_EmployeeTSFunctionLimitsTab.Name = "TabItemSecurityAndPasswords_EmployeeTSFunctionLimitsTab"
            Me.TabItemSecurityAndPasswords_EmployeeTSFunctionLimitsTab.Text = "Timesheet Functions"
            '
            'TabItemEmployeeDetails_SecurityAndPasswords
            '
            Me.TabItemEmployeeDetails_SecurityAndPasswords.AttachedControl = Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords
            Me.TabItemEmployeeDetails_SecurityAndPasswords.Name = "TabItemEmployeeDetails_SecurityAndPasswords"
            Me.TabItemEmployeeDetails_SecurityAndPasswords.Text = "Security && Passwords"
            '
            'TabControlPanelNotesTab_Notes
            '
            Me.TabControlPanelNotesTab_Notes.Controls.Add(Me.ButtonNotes_CheckSpelling)
            Me.TabControlPanelNotesTab_Notes.Controls.Add(Me.TextBoxNotes_Notes)
            Me.TabControlPanelNotesTab_Notes.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelNotesTab_Notes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelNotesTab_Notes.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelNotesTab_Notes.Name = "TabControlPanelNotesTab_Notes"
            Me.TabControlPanelNotesTab_Notes.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelNotesTab_Notes.Size = New System.Drawing.Size(738, 523)
            Me.TabControlPanelNotesTab_Notes.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelNotesTab_Notes.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelNotesTab_Notes.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelNotesTab_Notes.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelNotesTab_Notes.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelNotesTab_Notes.Style.GradientAngle = 90
            Me.TabControlPanelNotesTab_Notes.TabIndex = 12
            Me.TabControlPanelNotesTab_Notes.TabItem = Me.TabItemEmployeeDetails_NotesTab
            '
            'ButtonNotes_CheckSpelling
            '
            Me.ButtonNotes_CheckSpelling.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonNotes_CheckSpelling.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonNotes_CheckSpelling.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonNotes_CheckSpelling.Location = New System.Drawing.Point(632, 497)
            Me.ButtonNotes_CheckSpelling.Name = "ButtonNotes_CheckSpelling"
            Me.ButtonNotes_CheckSpelling.SecurityEnabled = True
            Me.ButtonNotes_CheckSpelling.Size = New System.Drawing.Size(100, 20)
            Me.ButtonNotes_CheckSpelling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonNotes_CheckSpelling.TabIndex = 45
            Me.ButtonNotes_CheckSpelling.Text = "Check Spelling"
            '
            'TextBoxNotes_Notes
            '
            Me.TextBoxNotes_Notes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxNotes_Notes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxNotes_Notes.Border.Class = "TextBoxBorder"
            Me.TextBoxNotes_Notes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxNotes_Notes.CheckSpellingOnValidate = False
            Me.TextBoxNotes_Notes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxNotes_Notes.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxNotes_Notes.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxNotes_Notes.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxNotes_Notes.FocusHighlightEnabled = True
            Me.TextBoxNotes_Notes.ForeColor = System.Drawing.Color.Black
            Me.TextBoxNotes_Notes.Location = New System.Drawing.Point(6, 6)
            Me.TextBoxNotes_Notes.MaxFileSize = CType(0, Long)
            Me.TextBoxNotes_Notes.Multiline = True
            Me.TextBoxNotes_Notes.Name = "TextBoxNotes_Notes"
            Me.TextBoxNotes_Notes.SecurityEnabled = True
            Me.TextBoxNotes_Notes.ShowSpellCheckCompleteMessage = True
            Me.TextBoxNotes_Notes.Size = New System.Drawing.Size(726, 485)
            Me.TextBoxNotes_Notes.StartingFolderName = Nothing
            Me.TextBoxNotes_Notes.TabIndex = 44
            Me.TextBoxNotes_Notes.TabOnEnter = False
            '
            'TabItemEmployeeDetails_NotesTab
            '
            Me.TabItemEmployeeDetails_NotesTab.AttachedControl = Me.TabControlPanelNotesTab_Notes
            Me.TabItemEmployeeDetails_NotesTab.Name = "TabItemEmployeeDetails_NotesTab"
            Me.TabItemEmployeeDetails_NotesTab.Text = "Notes"
            '
            'TabControlPanelDocumentsTab_Documents
            '
            Me.TabControlPanelDocumentsTab_Documents.Controls.Add(Me.DocumentManagerControlDocuments_EmployeeDocuments)
            Me.TabControlPanelDocumentsTab_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDocumentsTab_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDocumentsTab_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDocumentsTab_Documents.Name = "TabControlPanelDocumentsTab_Documents"
            Me.TabControlPanelDocumentsTab_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDocumentsTab_Documents.Size = New System.Drawing.Size(738, 523)
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDocumentsTab_Documents.Style.GradientAngle = 90
            Me.TabControlPanelDocumentsTab_Documents.TabIndex = 14
            Me.TabControlPanelDocumentsTab_Documents.TabItem = Me.TabItemEmployeeDetails_DocumentsTab
            '
            'DocumentManagerControlDocuments_EmployeeDocuments
            '
            Me.DocumentManagerControlDocuments_EmployeeDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlDocuments_EmployeeDocuments.Location = New System.Drawing.Point(6, 6)
            Me.DocumentManagerControlDocuments_EmployeeDocuments.Name = "DocumentManagerControlDocuments_EmployeeDocuments"
            Me.DocumentManagerControlDocuments_EmployeeDocuments.Size = New System.Drawing.Size(726, 511)
            Me.DocumentManagerControlDocuments_EmployeeDocuments.TabIndex = 0
            '
            'TabItemEmployeeDetails_DocumentsTab
            '
            Me.TabItemEmployeeDetails_DocumentsTab.AttachedControl = Me.TabControlPanelDocumentsTab_Documents
            Me.TabItemEmployeeDetails_DocumentsTab.Name = "TabItemEmployeeDetails_DocumentsTab"
            Me.TabItemEmployeeDetails_DocumentsTab.Text = "Documents"
            '
            'EmployeeControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlControl_EmployeeDetails)
            Me.Name = "EmployeeControl"
            Me.Size = New System.Drawing.Size(738, 550)
            CType(Me.TabControlControl_EmployeeDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_EmployeeDetails.ResumeLayout(False)
            Me.TabControlPanelAlertsTab_Alerts.ResumeLayout(False)
            CType(Me.PanelAlerts_Alerts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelAlerts_Alerts.ResumeLayout(False)
            CType(Me.TabControlAlerts_Alerts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlAlerts_Alerts.ResumeLayout(False)
            Me.TabControlPanelConceptShareTab_ConceptShare.ResumeLayout(False)
            Me.TabControlPanelSettingsTab_Settings.ResumeLayout(False)
            Me.TabControlPanelAdditionalEmails_AdditionalEmails.ResumeLayout(False)
            Me.TabControlPanelAlertGroupsTab_AlertGroups.ResumeLayout(False)
            CType(Me.PanelAlertGroups_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelAlertGroups_RightSection.ResumeLayout(False)
            CType(Me.PanelAlertGroups_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelAlertGroups_LeftSection.ResumeLayout(False)
            Me.TabControlPanel_CalendarTime.ResumeLayout(False)
            Me.TabControlPanelGeneralInformation_GeneralInformation.ResumeLayout(False)
            CType(Me.PanelGeneralInformation_GeneralInformation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelGeneralInformation_GeneralInformation.ResumeLayout(False)
            CType(Me.SearchableComboBoxGeneralInformation_AssignedOffice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneralInformation_Title.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlGeneralInformation_EmployeeGeneralInformation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlGeneralInformation_EmployeeGeneralInformation.ResumeLayout(False)
            Me.TabControlPanelInformationTab_Information.ResumeLayout(False)
            Me.TableLayoutPanelInformation_Information.ResumeLayout(False)
            Me.PanelInformation_BottomColumn.ResumeLayout(False)
            Me.TableLayoutPanelBottomColumn_Information.ResumeLayout(False)
            Me.PanelInformation_BottomRightColumn.ResumeLayout(False)
            Me.PanelInformation_BottomLeftColumn.ResumeLayout(False)
            Me.PanelInformation_TopRightColumn.ResumeLayout(False)
            CType(Me.PictureBoxInformationTopRightColumn_EmployeeSignature, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelInformation_TopLeftColumn.ResumeLayout(False)
            Me.TabControlDepartmentTeamTab_DepartmentTeam.ResumeLayout(False)
            CType(Me.PanelDepartmentTeam_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelDepartmentTeam_RightSection.ResumeLayout(False)
            CType(Me.PanelDepartmentTeam_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelDepartmentTeam_LeftSection.ResumeLayout(False)
            Me.TabControlPanelRolesTab_Roles.ResumeLayout(False)
            CType(Me.PanelRoles_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelRoles_RightSection.ResumeLayout(False)
            CType(Me.PanelRoles_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelRoles_LeftSection.ResumeLayout(False)
            Me.TabControlPanelTimeTrackingTab_TimeTracking.ResumeLayout(False)
            CType(Me.NumericInputTimeTracking_BillableHoursGoal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTimeTracking_DefaultFunction.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxTimeTracking_Supervisor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTimeTracking_SeniorityPriority.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTimeTracking_DirectHoursGoal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTimeTracking_MonthlyBillableHoursGoal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputTimeTracking_StandardAnnualHours.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports.ResumeLayout(False)
            CType(Me.NumericInputPOsAndExpenseReports_POAmountLimit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxPOsAndExpenseReports_AlternateApprover.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxPOsAndExpenseReports_POApprovalRule.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelHRAndRateInformationTab_HRAndRateInformation.ResumeLayout(False)
            CType(Me.NumericInputHRAndRateInformation_CostRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputHRAndRateInformation_BillRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputHRAndRateInformation_MonthlySalary.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputHRAndRateInformation_AnnualSalary.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerHRAndRateInformation_TerminationDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerHRAndRateInformation_NextReviewDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerHRAndRateInformation_DateOfLastIncrease, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerHRAndRateInformation_BirthDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerHRAndRateInformation_EmploymentDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords.ResumeLayout(False)
            CType(Me.SearchableComboBoxSecurityAndPasswords_User.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView9, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlSecurityAndPasswords_SecurityAndPasswords, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlSecurityAndPasswords_SecurityAndPasswords.ResumeLayout(False)
            Me.TabControlPanelSecurityGroupTab_SecurityGroup.ResumeLayout(False)
            CType(Me.PanelSecurityGroup_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSecurityGroup_RightSection.ResumeLayout(False)
            CType(Me.PanelSecurityGroup_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelSecurityGroup_LeftSection.ResumeLayout(False)
            Me.TabControlPanelEmployeeLimitsTab_EmployeeLimits.ResumeLayout(False)
            Me.TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits.ResumeLayout(False)
            Me.TabControlPanelCDPLimitsTab_CDPLimits.ResumeLayout(False)
            Me.TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits.ResumeLayout(False)
            Me.TabControlPanelNotesTab_Notes.ResumeLayout(False)
            Me.TabControlPanelDocumentsTab_Documents.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlControl_EmployeeDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelGeneralInformation_GeneralInformation As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemEmployeeDetails_GeneralInformation As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelAlertsTab_Alerts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemEmployeeDetails_AlertsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelTimeTrackingTab_TimeTracking As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxTimeTracking_ReportMissingTime As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelTimeTracking_ReportMissingTimeLbl As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTimeTracking_SeniorityPriority As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTimeTracking_VacationSickPersonalTime As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewTimeTracking_EmployeeTimeOff As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelTimeTracking_EmployeeStatus As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTimeTracking_StandardWorkDays As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewTimeTracking_WorkDays As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonControlTimeTracking_EmployeeStatusNonExempt As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlTimeTracking_EmployeeStatusExempt As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlTimeTracking_EmployeeStatusNA As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelTimeTracking_Supervisor As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemEmployeeDetails_TimeTrackingTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelTimeTracking_DefaultFunction As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneralInformation_AccountNumber As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxGeneralInformation_LastName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelGeneralInformation_AccountNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralInformation_LastName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxGeneralInformation_Freelance As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxGeneralInformation_MiddleInitial As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxGeneralInformation_FirstName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelGeneralInformation_Title As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralInformation_MiddleInitial As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneralInformation_FirstName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneralInformation_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelGeneralInformation_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlGeneralInformation_EmployeeGeneralInformation As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelInformationTab_Information As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents ButtonInformationTopRightColumn_DeleteSignatureImage As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonInformationTopRightColumn_SelectSignatureImage As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelInformationTopRightColumn_SignatureNotes As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PictureBoxInformationTopRightColumn_EmployeeSignature As System.Windows.Forms.PictureBox
        Friend WithEvents LabelInformationTopRightColumn_EmployeeSignature As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents AddressControlInformationBottomRightColumn_MailingAddress As AdvantageFramework.WinForm.Presentation.Controls.AddressControl
        Friend WithEvents AddressControlInformationBottomLeftColumn_HomeAddress As AdvantageFramework.WinForm.Presentation.Controls.AddressControl
        Friend WithEvents TextBoxInformationTopLeftColumn_WorkPhoneExt As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelInformationTopLeftColumn_PhoneNumbers As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelInformationTopLeftColumn_Home As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelInformationTopLeftColumn_Work As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelInformationTopLeftColumn_Cell As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelInformationTopLeftColumn_AlternatePhone As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxInformationTopLeftColumn_HomePhone As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxInformationTopLeftColumn_WorkPhone As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxInformationTopLeftColumn_CellPhone As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelInformationTopLeftColumn_WorkExt As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxInformationTopLeftColumn_AlternatePhone As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemEmployeeGeneralInformation_InformationTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelRolesTab_Roles As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelRoles_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_RemoveRole As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddRole As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_EmployeeRoles As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControlRoles_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelRoles_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableRoles As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemEmployeeGeneralInformation_RolesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlDepartmentTeamTab_DepartmentTeam As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelDepartmentTeam_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_RemoveDepartmentTeam As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddDepartmentTeam As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TextBoxRightSection_DefaultDepartmentTeam As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents DataGridViewRightSection_EmployeeDepartmentTeams As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControlDepartmentTeam_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelDepartmentTeam_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableDepartmentTeam As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemEmployeeGeneralInformation_DepartmentTeamTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelGeneralInformation_GeneralInformation As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents TableLayoutPanelInformation_Information As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelInformation_BottomColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelInformation_TopRightColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelInformation_TopLeftColumn As System.Windows.Forms.Panel
        Friend WithEvents TableLayoutPanelBottomColumn_Information As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelInformation_BottomRightColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelInformation_BottomLeftColumn As System.Windows.Forms.Panel
        Friend WithEvents TextBoxRightSection_DefaultRole As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabControlPanelPOsAndExpenseReportsTab_POsAndExpenseReports As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxPOsAndExpenseReports_AllowGLAccountSelection As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelPOsAndExpenseReports_POApprovalRule As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPOsAndExpenseReports_POAmountLimit As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPOsAndExpenseReports_PurchaseOrders As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPOsAndExpenseReports_ExpenseReportInformation As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxPOsAndExpenseReports_CreditCardDescription As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelPOsAndExpenseReports_CreditCardDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxPOsAndExpenseReports_CreditCardNumber As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelPOsAndExpenseReports_CreditCardGLAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPOsAndExpenseReports_AlternateApprover As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelPOsAndExpenseReports_VendorCodeCrossRef As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPOsAndExpenseReports_CreditCardNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemEmployeeDetails_POsAndExpenseReportsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelHRAndRateInformationTab_HRAndRateInformation As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemEmployeeDetails_HRAndRateInformationTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelHRAndRateInformation_BillingRates As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHRAndRateInformation_SalaryInformation As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHRAndRateInformation_AnnualSalary As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHRAndRateInformation_MonthlySalary As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerHRAndRateInformation_TerminationDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerHRAndRateInformation_NextReviewDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerHRAndRateInformation_DateOfLastIncrease As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerHRAndRateInformation_BirthDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerHRAndRateInformation_EmploymentDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelHRAndRateInformation_TerminationDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHRAndRateInformation_NextReviewDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHRAndRateInformation_DateOfLastIncrease As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHRAndRateInformation_BirthDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHRAndRateInformation_EmploymentDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHRAndRateInformation_EmployeeDates As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlPanelNotesTab_Notes As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents ButtonNotes_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TextBoxNotes_Notes As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemEmployeeDetails_NotesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSecurityAndPasswordsTab_SecurityAndPasswords As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemEmployeeDetails_SecurityAndPasswords As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlAlerts_Alerts As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelSettingsTab_Settings As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAlerts_SettingsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelAlertGroupsTab_AlertGroups As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAlerts_AlertGroupsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlSecurityAndPasswords_SecurityAndPasswords As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelSecurityGroupTab_SecurityGroup As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemSecurityAndPasswords_SecurityGroupTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelEmployeeOfficeLimitsTab_EmployeeOfficeLimits As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemSecurityAndPasswords_EmployeeOfficeLimitsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TextBoxHRAndRateInformation_OtherInfo As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelHRAndRateInformation_OtherInfo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHRAndRateInformation_OtherInfoHeader As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxSettingsRightColumn_EmailPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxSettingsRightColumn_EmailUserName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxSettingsRightColumn_ReplyToAddress As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxSettingsRightColumn_EmailAddress As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSettingsRightColumn_EmailPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettingsRightColumn_EmailUsername As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettingsRightColumn_ReplyToAddress As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxSettingsRightColumn_ReceivesAlerts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelSettingsRightColumn_EmailAddress As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents PanelAlertGroups_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_RemoveAlertGroup As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddAlertGroup As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_EmployeeAlertGroups As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControlAlertGroups_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelAlertGroups_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableAlertGroups As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelGeneralInformation_AssignedOffice As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTimeTracking_StandardAnnualHours As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTimeTracking_DirectHoursGoal As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTimeTracking_MonthlyBillableHoursGoal As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTimeTracking_HoursGoals As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHRAndRateInformation_BillRate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHRAndRateInformation_CostRate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHRAndRateInformation_HourlyBillCostData As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelSecurityGroup_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_RemoveSecurityGroup As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddSecurityGroup As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_EmployeeSecurityGroups As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControlSecurityGroup_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelSecurityGroup_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableSecurityGroups As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelSecurityAndPasswords_User As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelAlerts_Alerts As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents LabelInformationTopRightColumn_MaxSize As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelInformationTopRightColumn_ImageDimensions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits As AdvantageFramework.WinForm.Presentation.Controls.EmployeeOfficeLimitControl
        Friend WithEvents TabControlPanelDocumentsTab_Documents As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemEmployeeDetails_DocumentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DocumentManagerControlDocuments_EmployeeDocuments As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents RateFlagEntryControlHRAndRateInformation_BillingRateDetails As AdvantageFramework.WinForm.Presentation.Controls.RateFlagEntryControl
        Friend WithEvents ButtonPayToNameAndAddress_Refresh As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonItemRefresh_Home As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents NumericInputTimeTracking_DirectHoursGoal As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTimeTracking_MonthlyBillableHoursGoal As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTimeTracking_StandardAnnualHours As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTimeTracking_SeniorityPriority As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputHRAndRateInformation_MonthlySalary As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputHRAndRateInformation_AnnualSalary As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents TextBoxInformation_EmployeeSignature As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxGeneralInformation_ActiveFreelance As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlPanelEmployeeLimitsTab_EmployeeLimits As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemSecurityAndPasswords_EmployeeLimitsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCDPLimitsTab_CDPLimits As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemSecurityAndPasswords_CDPLimitsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelEmployeeTSFunctionLimitsTab_EmployeeTSFunctionLimits As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemSecurityAndPasswords_EmployeeTSFunctionLimitsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunctionLimits As AdvantageFramework.WinForm.Presentation.Controls.EmployeeTimesheetFunctionLimitsControl
        Friend WithEvents UserCDPLimitControlCDPLimits_CDPLimits As AdvantageFramework.WinForm.Presentation.Controls.UserCDPLimitControl
        Friend WithEvents UserEmployeeLimitControlEmployeeLimits_EmployeeLimits As AdvantageFramework.WinForm.Presentation.Controls.UserEmployeeLimitControl
        Friend WithEvents TextBoxSettings_SugarCRMPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxSettings_SugarCRMUserName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSettings_SugarCRMPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_SugarCRMUserName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_SugarCRM As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxSettings_ProofHQPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxSettings_ProofHQUserName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSettings_ProofHQPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_ProofHQUserName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_ProofHQ As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxSettings_IsAPIUser As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents SearchableComboBoxGeneralInformation_Title As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView4 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGeneralInformation_AssignedOffice As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxTimeTracking_Supervisor As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxTimeTracking_DefaultFunction As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView3 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxPOsAndExpenseReports_POApprovalRule As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView5 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView8 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView7 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxPOsAndExpenseReports_AlternateApprover As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView6 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSecurityAndPasswords_User As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView9 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelSettings_AdobeSignature As Label
        Friend WithEvents ButtonSettings_AdobeSignatureFileDelete As Button
        Friend WithEvents ButtonSettings_AdobeSignatureFileSelect As Button
        Friend WithEvents TextBoxSettings_AdobeSignatureFilePassword As TextBox
        Friend WithEvents LabelSettings_AdobeSignatureFilePassword As Label
        Friend WithEvents LabelSettings_AdobeSignatureFile As Label
        Friend WithEvents TextBoxSettings_AdobeSignatureFile As TextBox
        Friend WithEvents TextBoxSettings_VCCPassword As TextBox
        Friend WithEvents TextBoxSettings_VCCUserName As TextBox
        Friend WithEvents LabelSettings_VCCPassword As Label
        Friend WithEvents LabelSettings_VCCUserName As Label
        Friend WithEvents LabelSettings_VCC As Label
        Friend WithEvents NumericInputPOsAndExpenseReports_POAmountLimit As NumericInput
        Friend WithEvents NumericInputHRAndRateInformation_CostRate As NumericInput
        Friend WithEvents NumericInputHRAndRateInformation_BillRate As NumericInput
        Friend WithEvents CheckBoxTimeTracking_OmitFromMissingTimeTracking As CheckBox
        Friend WithEvents CheckBoxSettings_IgnoreCalendarSync As CheckBox
        Friend WithEvents TabControlPanelConceptShareTab_ConceptShare As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents ButtonConceptShare_UpdateUser As Button
        Friend WithEvents ButtonConceptShare_CreateUser As Button
        Friend WithEvents TextBoxConceptShare_Password As TextBox
        Friend WithEvents LabelConceptShare_Password As Label
        Friend WithEvents TabItemAlerts_ConceptShareTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents CheckBoxConceptShare_IsActive As CheckBox
        Friend WithEvents ButtonConceptShare_RemoveUser As Button
        Friend WithEvents CheckBoxConceptShare_ShowPassword As CheckBox
        Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabControlPanel_CalendarTime As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents Label1 As Label
        Friend WithEvents TextBoxCalendarTime_EmailPassword As TextBox
        Friend WithEvents TextBoxCalendarTime_EmailUserName As TextBox
        Friend WithEvents TextBoxCalendarTime_EmailAddress As TextBox
        Friend WithEvents Label13 As Label
        Friend WithEvents Label14 As Label
        Friend WithEvents Label16 As Label
        Friend WithEvents TabItemAlerts_CalendarTimeTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ComboBoxCalendarTime_Type As ComboBox
        Friend WithEvents Label2 As Label
        Friend WithEvents TextBoxCalendarTime_Host As TextBox
        Friend WithEvents CheckBoxForm_SSL As CheckBox
        Friend WithEvents TextBoxCalendarTime_Port As TextBox
        Friend WithEvents Label3 As Label
        Friend WithEvents TabControlPanelAdditionalEmails_AdditionalEmails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewAdditionalEmails_AdditionalEmails As DataGridView
        Friend WithEvents TabItemAlerts_AdditionalEmailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents NumericInputTimeTracking_BillableHoursGoal As NumericInput
        Friend WithEvents LabelTimeTracking_BillableHoursGoal As Label
    End Class

End Namespace
