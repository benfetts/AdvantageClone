<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvantageServicesFormOld
    Inherits DevComponents.DotNetBar.Office2007RibbonForm

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvantageServicesFormOld))
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.StyleManager = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.RibbonControlForm_MainRibbon = New DevComponents.DotNetBar.RibbonControl()
        Me.RibbonPanelFile_FilePanel = New DevComponents.DotNetBar.RibbonPanel()
        Me.RibbonBarFilePanel_Log = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
        Me.ButtonItemLog_Refresh = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBarFilePanel_DatabaseProfiles = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
        Me.ButtonItemDatabaseProfiles_DatabaseProfiles = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBarFilePanel_Settings = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
        Me.ButtonItemSettings_Save = New DevComponents.DotNetBar.ButtonItem()
        Me.RibbonBarFilePanel_System = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
        Me.ButtonItemSystem_Exit = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemSystem_Hide = New DevComponents.DotNetBar.ButtonItem()
        Me.Office2007StartButtonMainRibbon_Home = New DevComponents.DotNetBar.Office2007StartButton()
        Me.RibbonTabItemMainRibbon_File = New DevComponents.DotNetBar.RibbonTabItem()
        Me.ButtonItemMainRibbon_Help = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemMainRibbon_ShowAndHide = New DevComponents.DotNetBar.ButtonItem()
        Me.TabControlForm_Services = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
        Me.TabControlPanelEmailListenerTab_EmailListener = New DevComponents.DotNetBar.TabControlPanel()
        Me.CheckBoxEMail_AutoStart = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.TabControlEmailListener_EmailListenerSettings = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
        Me.TabControlPanelSettingsTab_EmailListenerSettings = New DevComponents.DotNetBar.TabControlPanel()
        Me.NumericInputEmailListenerSettings_RunAtEvery = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.TextBoxEmailListenerSettings_StartofSignatureCode = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.LabelEmailListenerSettings_StartofSignatureCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelEmailListenerSettings_RunAtEvery = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TabItemEmailListenerSettings_SettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelLogTab_EmailListenerLog = New DevComponents.DotNetBar.TabControlPanel()
        Me.TextBoxEmailListenerLog_Log = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.TabItemEmailListenerSettings_LogTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles = New DevComponents.DotNetBar.TabControlPanel()
        Me.ButtonEmailListenerDatabaseProfiles_ProcessNow = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonEmailListenerDatabaseProfiles_Select = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonEmailListenerDatabaseProfiles_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonEmailListenerDatabaseProfiles_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
        Me.TabItemEmailListenerSettings_DatabaseProfilesTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.ButtonEmailListener_Stop = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.LabelEmailListener_StatusDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelEmailListener_Status = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ButtonEmailListener_Start = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.TabItemServices_EmailListenerTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelMediaOceanImportTab_Import = New DevComponents.DotNetBar.TabControlPanel()
        Me.CheckBoxMediaOceanImport_AutoStart = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.TabControlMediaOceanImport_MediaOceanImportSettings = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings = New DevComponents.DotNetBar.TabControlPanel()
        Me.LabelMediaOceanImportSettings_RunAt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.DateTimeInputMediaOceanImportSettings_RunAt = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
        Me.GroupBoxMediaOceanImportSettings_Settings = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.LabelMediaOceanImportSettings_Employee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ComboBoxMediaOceanImportSettings_Employee = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.TextBoxMediaOceanImportSettings_LocalFolder = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.LabelMediaOceanImportSettings_LocalFolder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ButtonMediaOceanImportSettings_ValidateFTP = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.TextBoxMediaOceanImportSettings_FTPPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.TextBoxMediaOceanImportSettings_FTPUser = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.LabelMediaOceanImportSettings_FTPPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelMediaOceanImportSettings_FTPUser = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TextBoxMediaOceanImportSettings_FTPAddress = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.LabelMediaOceanImportSettings_FTPAddress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelMediaOceanImportSettings_DatabaseProfile = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.TabItemMediaOceanImportSettings_MediaOceanImportSettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog = New DevComponents.DotNetBar.TabControlPanel()
        Me.TextBoxMediaOceanImportLog_Log = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.TabItemMediaOceanImportSettings_MediaOceanImportLogTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles = New DevComponents.DotNetBar.TabControlPanel()
        Me.ButtonMediaOceanImportDatabaseProfiles_ProcessNow = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonMediaOceanImportDatabaseProfiles_Select = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonMediaOceanImportDatabaseProfiles_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonMediaOceanImportDatabaseProfiles_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
        Me.TabItemMediaOceanImportSettings_MediaOceanImportDatabaseProfilesTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.LabelMediaOceanImport_StatusDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelMediaOceanImport_Status = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ButtonMediaOceanImport_Start = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonMediaOceanImport_Stop = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.TabItemServices_MediaOceanImportTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelMissingTimeTab_MissingTime = New DevComponents.DotNetBar.TabControlPanel()
        Me.TabControlMissingTime_Settings = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
        Me.TabControlPanelSettingsTab_MissingTimeSettings = New DevComponents.DotNetBar.TabControlPanel()
        Me.LabelMissingTimeSettings_DatabaseProfile = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ComboBoxMissingTimeSettings_DatabaseProfile = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.GroupBoxMissingTimeSettings_Interval = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.NumericInputMissingTimeSettings_Interval_StopAfter = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.CheckBoxMissingTimeSettings_Interval_RunAt = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.LabelMissingTimeSettings_Interval_StopAfterHours = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelMissingTimeSettings_Interval_RunEveryHours = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.ComboBoxMissingTimeSettings_Interval_RunDay = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.LabelMissingTimeSettings_Interval_RunDay = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
        Me.TabItemMissingTimeSettings_SettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelAlertsTab_Alerts = New DevComponents.DotNetBar.TabControlPanel()
        Me.GroupBoxMissingTimeAlerts_Other = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.LabelMissingTimeSettings_Path = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TextBoxMissingTimeSettings_LogFilePath = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.LabelMissingTimeAlerts_CustomMessage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TextBoxMissingTimeAlerts_CustomMessage = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.GroupBoxMissingTimeAlerts_Recipient = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.LabelMissingTimeAlerts_Recipient_ITContact_GracePeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.LabelMissingTimeAlerts_Recipient_ITContact_Days = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_GracePeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_Days = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.LabelMissingTimeAlerts_Recipient_Employee_GracePeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelMissingTimeAlerts_Recipient_Employee_Days = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.LabelMissingTimeAlerts_Recipient_ITContact = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.GroupBoxMissingTimeAlerts_Tracking = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.GroupBoxMissingTimeAlerts_Priority = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.RadioButtonMissingTimeSettings_Priority_Low = New System.Windows.Forms.RadioButton()
        Me.RadioButtonMissingTimeSettings_Priority_Medium = New System.Windows.Forms.RadioButton()
        Me.RadioButtonMissingTimeSettings_Priority_High = New System.Windows.Forms.RadioButton()
        Me.GroupBoxMissingTimeAlerts_Range = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod = New System.Windows.Forms.RadioButton()
        Me.RadioButtonMissingTimeSettings_Range_DaysToCheck = New System.Windows.Forms.RadioButton()
        Me.LabelMissingTimeAlerts_DatabaseProfile = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.TabItemMissingTimeSettings_AlertsTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles = New DevComponents.DotNetBar.TabControlPanel()
        Me.ButtonMissingTimeDatabaseProfiles_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonMissingTimeDatabaseProfiles_Select = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonMissingTimeDatabaseProfiles_ProcessNow = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonMissingTimeDatabaseProfiles_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
        Me.TabItemMissingTimeSettings_DatabaseProfilesTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelLogTab_MissingTimeLog = New DevComponents.DotNetBar.TabControlPanel()
        Me.TextBoxMissingTimeLog_Log = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.TabItemMissingTimeSettings_LogTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.CheckBoxMissingTime_AutoStart = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.ButtonMissingTime_Stop = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.LabelMissingTime_StatusDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelMissingTime_Status = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ButtonMissingTime_Start = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.TabItemServices_MissingTimeTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelContractTab_Contract = New DevComponents.DotNetBar.TabControlPanel()
        Me.CheckBoxContract_AutoStart = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.TabControlContract_ContractSettings = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
        Me.TabControlPanelContractSettingsTab_ContractSettings = New DevComponents.DotNetBar.TabControlPanel()
        Me.GroupBoxContractSettings_Notifications = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.NumericInputContractSettings_RenewalDaysPrior = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.CheckBoxContractSettings_ContractReports = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.LabelContractSettings_DaysPrior = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.CheckBoxContractSettings_ContractRenewal = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.LabelContractAlertSettings_RunAt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.DateTimeInputContractAlertSettings_RunAt = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
        Me.TabItemContractSettings_ContractSettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles = New DevComponents.DotNetBar.TabControlPanel()
        Me.ButtonContractDatabaseProfiles_ProcessNow = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonContractDatabaseProfiles_Select = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonContractDatabaseProfiles_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonContractDatabaseProfiles_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.DataGridViewContractDatabaseProfiles_Databases = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
        Me.TabItemContractSettings_ContractDatabaseProfilesTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlContractLogTab_ContractLog = New DevComponents.DotNetBar.TabControlPanel()
        Me.TextBoxContractLog_Log = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.TabItemContractSettings_ContractLogTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.LabelContract_StatusDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelContract_Status = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ButtonContract_Start = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonContract_Stop = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.TabItemServices_ContractTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals = New DevComponents.DotNetBar.TabControlPanel()
        Me.CheckBoxPaidTimeOffAccruals_AutoStart = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings = New DevComponents.DotNetBar.TabControlPanel()
        Me.LabelPaidTimeOffAccrualsSettings_LastRanDetails = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelPaidTimeOffAccrualsSettings_DatabaseProfile = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.LabelPaidTimeOffAccrualsSettings_RunOnDay = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsSettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles = New DevComponents.DotNetBar.TabControlPanel()
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Select = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
        Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsDatabaseProfilesTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog = New DevComponents.DotNetBar.TabControlPanel()
        Me.TextBoxPaidTimeOffAccrualsLog_Log = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsLogTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.LabelPaidTimeOffAccruals_StatusDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelPaidTimeOffAccruals_Status = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ButtonPaidTimeOffAccruals_Start = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonPaidTimeOffAccruals_Stop = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.TabItemServices_PaidTimeOffAccrualsTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelTasks_Tasks = New DevComponents.DotNetBar.TabControlPanel()
        Me.CheckBoxTask_AutoStart = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.TabControlTask_Settings = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
        Me.TabControlPanelSettingsTab_TaskSettings = New DevComponents.DotNetBar.TabControlPanel()
        Me.ComboBoxTaskSettings_RunDay = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.DateTimeInputTaskSettings_RunAt = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
        Me.GroupBoxTaskSettings_Notifications = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.NumericInputTaskSettings_Upcoming_EndDays = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.NumericInputTaskSettings_Upcoming_StartDays = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.LabelTaskSettings_Upcoming_Between = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelTaskSettings_Upcoming_Days = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelTaskSettings_Upcoming_And = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelTaskSettings_Upcoming_CustomMessage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelTaskSettings_PastDue_CustomMessage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TextBoxTaskSettings_Upcoming_CustomMessage = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.TextBoxTaskSettings_PastDue_CustomMessage = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.CheckBoxTaskSettings_Upcoming = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.CheckBoxTaskSettings_PastDue = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.LabelTaskSettings_RunDay = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelTaskSettings_RunAt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TabItemTaskSettings_SettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles = New DevComponents.DotNetBar.TabControlPanel()
        Me.ButtonTaskDatabaseProfiles_ProcessNow = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonTaskDatabaseProfiles_Select = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonTaskDatabaseProfiles_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonTaskDatabaseProfiles_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.DataGridViewTaskDatabaseProfiles_Databases = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
        Me.TabItemTaskSettings_DatabaseProfilesTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelLogTab_TaskLog = New DevComponents.DotNetBar.TabControlPanel()
        Me.TextBoxTaskLog_Log = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.TabItemTaskSettings_LogTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.ButtonTask_Stop = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.LabelTask_StatusDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelTask_Status = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ButtonTask_Start = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.TabItemServices_TasksTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelExport_Export = New DevComponents.DotNetBar.TabControlPanel()
        Me.CheckBoxExport_AutoStart = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.ButtonExport_Stop = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.TabControlExport_Settings = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
        Me.TabControlPanelSettingsTab_ExportSettings = New DevComponents.DotNetBar.TabControlPanel()
        Me.GroupBoxExportSettings_Data = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.LabelExportSettings_DataTo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.RadioButtonExportSettings_DataFrom = New System.Windows.Forms.RadioButton()
        Me.RadioButtonExportSettings_TodaysData = New System.Windows.Forms.RadioButton()
        Me.RadioButtonExportSettings_AllData = New System.Windows.Forms.RadioButton()
        Me.DateTimePickerExportSettings_DataEnd = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
        Me.DateTimePickerExportSettings_DataStart = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
        Me.LabelExportSettings_Path = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelExportSettings_RunAt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.DateTimeInputExportSettings_RunAt = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
        Me.TextBoxExportSettings_ExportPath = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.TabItemExportSettings_SettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelCriteriaTab_ExportCriteria = New DevComponents.DotNetBar.TabControlPanel()
        Me.GroupBoxExportCriteria_SelectedCampaigns = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.ButtonExportCriteriaCampaign_RemoveAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonExportCriteriaCampaign_AddAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonExportCriteriaCampaign_RemoveSelected = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.DataGridViewExportCriteria_SelectedCampaigns = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
        Me.LabelExportCriteria_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ComboBoxExportCriteria_Clients = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.DataGridViewExportCriteria_Campaigns = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
        Me.ButtonExportCriteriaCampaign_AddSelected = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.LabelExportCriteria_DatabaseProfile = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ComboBoxExportCriteria_DatabaseProfiles = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.TabItemExportSettings_CriteriaTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles = New DevComponents.DotNetBar.TabControlPanel()
        Me.ButtonExportDatabaseProfiles_ProcessNow = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonExportDatabaseProfiles_Select = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonExportDatabaseProfiles_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonExportDatabaseProfiles_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.DataGridViewExportDatabaseProfiles_Databases = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
        Me.TabItemExportSettings_DatabaseProfilesTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelLogTab_ExportLog = New DevComponents.DotNetBar.TabControlPanel()
        Me.TextBoxExportLog_Log = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.TabItemExportSettings_LogTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.LabelExport_StatusDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelExport_Status = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ButtonExport_Start = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.TabItemServices_ExportTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelQvAAlertTab_QvAAlert = New DevComponents.DotNetBar.TabControlPanel()
        Me.ButtonQvA_Stop = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.CheckBoxQvA_AutoStart = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.LabelQvAAlert_StatusDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelQvAAlert_Status = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TabControlQvAAlert_Settings = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings = New DevComponents.DotNetBar.TabControlPanel()
        Me.ComboBoxQvAAlertSettings_ShowLevel = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.ComboBoxQvAAlertSettings_SetAlertLevel = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.ComboBoxQvAAlertSettings_SendAlertTo = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
        Me.DateTimeInputQvAAlertSettings_RunAt = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
        Me.LabelQvAAlertSettings_ShowLevel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelQvAAlertSettings_SetAlertLevel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.GroupBoxQvAAlertSettings_CalculationOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.CheckBoxCalculationOptions_IncludeEstimate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.CheckBoxCalculationOptions_VendorCharges = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.CheckBoxCalculationOptions_IncomeOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.CheckBoxCalculationOptions_Time = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.GroupBoxQvAAlertSettings_Thresholds = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.NumericInputThresholds_Level3Start = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.NumericInputThresholds_Level2End = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.NumericInputThresholds_Level2Start = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.NumericInputThresholds_Level1End = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.NumericInputThresholds_Level1Start = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.LabelThresholds_Level3Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TextBoxThresholds_Level3Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.LabelThresholds_Level3And = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.CheckBoxThresholds_Level3 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.LabelThresholds_Level2Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TextBoxThresholds_Level2Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.LabelThresholds_Level2And = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelThresholds_Level2Between = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.CheckBoxThresholds_Level2 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.LabelThresholds_Level1Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TextBoxThresholds_Level1Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.LabelThresholds_Level1And = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelThresholds_Level1Between = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.CheckBoxThresholds_Level1 = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.LabelQvAAlertSettings_SendAlertTo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelQvAAlertSettings_RunAt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TabItemQvAAlertSettings_SettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelQvAAlertLog_QvAAlertLog = New DevComponents.DotNetBar.TabControlPanel()
        Me.TextBoxQvAAlertLog_Log = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.TabItemQvAAlertSettings_LogTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings = New DevComponents.DotNetBar.TabControlPanel()
        Me.ButtonQvAAlertDatabaseProfiles_Select = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonQvAAlertDatabaseProfiles_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonQvAAlertDatabaseProfiles_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonQvAAlertDatabaseProfiles_ProcessNow = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
        Me.TabItemQvAAlertSettings_DatabaseProfilesTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.ButtonQvA_Start = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.TabItemServices_QvAAlertTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar = New DevComponents.DotNetBar.TabControlPanel()
        Me.CheckBoxGoogleCalendar_AutoStart = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.TabControlGoogleCalendar_GoogleCalendarSettings = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings = New DevComponents.DotNetBar.TabControlPanel()
        Me.NumericInputGoogleCalendarSettings_RunAt = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.LabelGoogleCalendarSettings_RunAt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.TabItemGoogleCalendarSettings_GoogleCalendarSettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog = New DevComponents.DotNetBar.TabControlPanel()
        Me.TextBoxGoogleCalendarLog_Log = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.TabItemGoogleCalendarSettings_GoogleCalendarLogTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles = New DevComponents.DotNetBar.TabControlPanel()
        Me.ButtonGoogleCalendarDatabaseProfiles_ProcessNow = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonGoogleCalendarDatabaseProfiles_Select = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonGoogleCalendarDatabaseProfiles_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonGoogleCalendarDatabaseProfiles_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
        Me.TabItemGoogleCalendarSettings_GoogleCalendarDatabaseProfilesTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.LabelGoogleCalendar_StatusDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelGoogleCalendar_Status = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ButtonGoogleCalendar_Stop = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonGoogleCalendar_Start = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.TabItemServices_GoogleCalendarTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport = New DevComponents.DotNetBar.TabControlPanel()
        Me.CheckBoxCoreMediaCheckExport_AutoStart = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings = New DevComponents.DotNetBar.TabControlPanel()
        Me.LabelCoreMediaCheckExportSettings_ExportPath = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelCoreMediaCheckExportSettings_RunAt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportSettingsTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog = New DevComponents.DotNetBar.TabControlPanel()
        Me.TextBoxCoreMediaCheckExportLog_Log = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
        Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportLogTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles = New DevComponents.DotNetBar.TabControlPanel()
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Select = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Edit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Remove = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
        Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportDatabaseProfilesTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.LabelCoreMediaCheckExport_StatusDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelCoreMediaCheckExport_Status = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.ButtonCoreMediaCheckExport_Start = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonCoreMediaCheckExport_Stop = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.TabItemServices_CoreMediaCheckExportTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.DefaultLookAndFeel = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.NotifyIconForm_NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStripForm_Menu = New AdvantageFramework.WinForm.Presentation.Controls.ContextMenuStrip()
        Me.ToolStripMenuItemMenu_ShowLogAndSettings = New AdvantageFramework.WinForm.Presentation.Controls.ToolStripMenuItem()
        Me.ToolStripSeparatorMenu_FirstSeparator = New AdvantageFramework.WinForm.Presentation.Controls.ToolStripSeparator()
        Me.ToolStripMenuItemMenu_ShutDown = New AdvantageFramework.WinForm.Presentation.Controls.ToolStripMenuItem()
        Me.RibbonControlForm_MainRibbon.SuspendLayout()
        Me.RibbonPanelFile_FilePanel.SuspendLayout()
        CType(Me.TabControlForm_Services, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlForm_Services.SuspendLayout()
        Me.TabControlPanelEmailListenerTab_EmailListener.SuspendLayout()
        CType(Me.TabControlEmailListener_EmailListenerSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlEmailListener_EmailListenerSettings.SuspendLayout()
        Me.TabControlPanelSettingsTab_EmailListenerSettings.SuspendLayout()
        CType(Me.NumericInputEmailListenerSettings_RunAtEvery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanelLogTab_EmailListenerLog.SuspendLayout()
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.SuspendLayout()
        Me.TabControlPanelMediaOceanImportTab_Import.SuspendLayout()
        CType(Me.TabControlMediaOceanImport_MediaOceanImportSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.SuspendLayout()
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.SuspendLayout()
        CType(Me.DateTimeInputMediaOceanImportSettings_RunAt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBoxMediaOceanImportSettings_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxMediaOceanImportSettings_Settings.SuspendLayout()
        Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog.SuspendLayout()
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.SuspendLayout()
        Me.TabControlPanelMissingTimeTab_MissingTime.SuspendLayout()
        CType(Me.TabControlMissingTime_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlMissingTime_Settings.SuspendLayout()
        Me.TabControlPanelSettingsTab_MissingTimeSettings.SuspendLayout()
        CType(Me.GroupBoxMissingTimeSettings_Interval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxMissingTimeSettings_Interval.SuspendLayout()
        CType(Me.NumericInputMissingTimeSettings_Interval_StopAfter.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanelAlertsTab_Alerts.SuspendLayout()
        CType(Me.GroupBoxMissingTimeAlerts_Other, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxMissingTimeAlerts_Other.SuspendLayout()
        CType(Me.GroupBoxMissingTimeAlerts_Recipient, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxMissingTimeAlerts_Recipient.SuspendLayout()
        CType(Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBoxMissingTimeAlerts_Tracking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxMissingTimeAlerts_Tracking.SuspendLayout()
        CType(Me.GroupBoxMissingTimeAlerts_Priority, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxMissingTimeAlerts_Priority.SuspendLayout()
        CType(Me.GroupBoxMissingTimeAlerts_Range, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxMissingTimeAlerts_Range.SuspendLayout()
        CType(Me.NumericInputMissingTimeSettings_Range_DaysToCheck.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.SuspendLayout()
        Me.TabControlPanelLogTab_MissingTimeLog.SuspendLayout()
        Me.TabControlPanelContractTab_Contract.SuspendLayout()
        CType(Me.TabControlContract_ContractSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlContract_ContractSettings.SuspendLayout()
        Me.TabControlPanelContractSettingsTab_ContractSettings.SuspendLayout()
        CType(Me.GroupBoxContractSettings_Notifications, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxContractSettings_Notifications.SuspendLayout()
        CType(Me.NumericInputContractSettings_RenewalDaysPrior.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimeInputContractAlertSettings_RunAt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.SuspendLayout()
        Me.TabControlContractLogTab_ContractLog.SuspendLayout()
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.SuspendLayout()
        CType(Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.SuspendLayout()
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.SuspendLayout()
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.SuspendLayout()
        Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog.SuspendLayout()
        Me.TabControlPanelTasks_Tasks.SuspendLayout()
        CType(Me.TabControlTask_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlTask_Settings.SuspendLayout()
        Me.TabControlPanelSettingsTab_TaskSettings.SuspendLayout()
        CType(Me.DateTimeInputTaskSettings_RunAt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBoxTaskSettings_Notifications, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxTaskSettings_Notifications.SuspendLayout()
        CType(Me.NumericInputTaskSettings_Upcoming_EndDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericInputTaskSettings_Upcoming_StartDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.SuspendLayout()
        Me.TabControlPanelLogTab_TaskLog.SuspendLayout()
        Me.TabControlPanelExport_Export.SuspendLayout()
        CType(Me.TabControlExport_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlExport_Settings.SuspendLayout()
        Me.TabControlPanelSettingsTab_ExportSettings.SuspendLayout()
        CType(Me.GroupBoxExportSettings_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxExportSettings_Data.SuspendLayout()
        CType(Me.DateTimePickerExportSettings_DataEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimePickerExportSettings_DataStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimeInputExportSettings_RunAt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanelCriteriaTab_ExportCriteria.SuspendLayout()
        CType(Me.GroupBoxExportCriteria_SelectedCampaigns, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxExportCriteria_SelectedCampaigns.SuspendLayout()
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.SuspendLayout()
        Me.TabControlPanelLogTab_ExportLog.SuspendLayout()
        Me.TabControlPanelQvAAlertTab_QvAAlert.SuspendLayout()
        CType(Me.TabControlQvAAlert_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlQvAAlert_Settings.SuspendLayout()
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.SuspendLayout()
        CType(Me.DateTimeInputQvAAlertSettings_RunAt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBoxQvAAlertSettings_CalculationOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxQvAAlertSettings_CalculationOptions.SuspendLayout()
        CType(Me.GroupBoxQvAAlertSettings_Thresholds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxQvAAlertSettings_Thresholds.SuspendLayout()
        CType(Me.NumericInputThresholds_Level3Start.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericInputThresholds_Level2End.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericInputThresholds_Level2Start.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericInputThresholds_Level1End.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericInputThresholds_Level1Start.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanelQvAAlertLog_QvAAlertLog.SuspendLayout()
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.SuspendLayout()
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.SuspendLayout()
        CType(Me.TabControlGoogleCalendar_GoogleCalendarSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.SuspendLayout()
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings.SuspendLayout()
        CType(Me.NumericInputGoogleCalendarSettings_RunAt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog.SuspendLayout()
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.SuspendLayout()
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.SuspendLayout()
        CType(Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.SuspendLayout()
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.SuspendLayout()
        CType(Me.DateTimeInputCoreMediaCheckExportSettings_RunAt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog.SuspendLayout()
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.SuspendLayout()
        Me.ContextMenuStripForm_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'StyleManager
        '
        Me.StyleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'RibbonControlForm_MainRibbon
        '
        Me.RibbonControlForm_MainRibbon.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonControlForm_MainRibbon.CaptionVisible = True
        Me.RibbonControlForm_MainRibbon.Controls.Add(Me.RibbonPanelFile_FilePanel)
        Me.RibbonControlForm_MainRibbon.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonControlForm_MainRibbon.EnableQatPlacement = False
        Me.RibbonControlForm_MainRibbon.ForeColor = System.Drawing.Color.Black
        Me.RibbonControlForm_MainRibbon.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Office2007StartButtonMainRibbon_Home, Me.RibbonTabItemMainRibbon_File, Me.ButtonItemMainRibbon_Help, Me.ButtonItemMainRibbon_ShowAndHide})
        Me.RibbonControlForm_MainRibbon.KeyTipsFont = New System.Drawing.Font("Tahoma", 7.0!)
        Me.RibbonControlForm_MainRibbon.Location = New System.Drawing.Point(5, 1)
        Me.RibbonControlForm_MainRibbon.MdiSystemItemVisible = False
        Me.RibbonControlForm_MainRibbon.Name = "RibbonControlForm_MainRibbon"
        Me.RibbonControlForm_MainRibbon.Padding = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(850, 154)
        Me.RibbonControlForm_MainRibbon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonControlForm_MainRibbon.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
        Me.RibbonControlForm_MainRibbon.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
        Me.RibbonControlForm_MainRibbon.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
        Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
        Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
        Me.RibbonControlForm_MainRibbon.SystemText.QatDialogAddButton = "&Add >>"
        Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCancelButton = "Cancel"
        Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
        Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
        Me.RibbonControlForm_MainRibbon.SystemText.QatDialogOkButton = "OK"
        Me.RibbonControlForm_MainRibbon.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
        Me.RibbonControlForm_MainRibbon.SystemText.QatDialogRemoveButton = "&Remove"
        Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
        Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
        Me.RibbonControlForm_MainRibbon.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
        Me.RibbonControlForm_MainRibbon.TabGroupHeight = 14
        Me.RibbonControlForm_MainRibbon.TabGroupsVisible = True
        Me.RibbonControlForm_MainRibbon.TabIndex = 1
        '
        'RibbonPanelFile_FilePanel
        '
        Me.RibbonPanelFile_FilePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Log)
        Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_DatabaseProfiles)
        Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Settings)
        Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_System)
        Me.RibbonPanelFile_FilePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 55)
        Me.RibbonPanelFile_FilePanel.Name = "RibbonPanelFile_FilePanel"
        Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(850, 97)
        '
        '
        '
        Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonPanelFile_FilePanel.TabIndex = 1
        '
        'RibbonBarFilePanel_Log
        '
        Me.RibbonBarFilePanel_Log.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBarFilePanel_Log.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_Log.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_Log.ContainerControlProcessDialogKey = True
        Me.RibbonBarFilePanel_Log.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBarFilePanel_Log.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
        Me.RibbonBarFilePanel_Log.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemLog_Refresh})
        Me.RibbonBarFilePanel_Log.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBarFilePanel_Log.Location = New System.Drawing.Point(328, 0)
        Me.RibbonBarFilePanel_Log.Name = "RibbonBarFilePanel_Log"
        Me.RibbonBarFilePanel_Log.Size = New System.Drawing.Size(100, 94)
        Me.RibbonBarFilePanel_Log.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBarFilePanel_Log.TabIndex = 5
        Me.RibbonBarFilePanel_Log.Text = "Log"
        '
        '
        '
        Me.RibbonBarFilePanel_Log.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_Log.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_Log.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItemLog_Refresh
        '
        Me.ButtonItemLog_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemLog_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemLog_Refresh.Name = "ButtonItemLog_Refresh"
        Me.ButtonItemLog_Refresh.SubItemsExpandWidth = 14
        Me.ButtonItemLog_Refresh.Text = "Refresh"
        '
        'RibbonBarFilePanel_DatabaseProfiles
        '
        Me.RibbonBarFilePanel_DatabaseProfiles.AutoOverflowEnabled = False
        '
        '
        '
        Me.RibbonBarFilePanel_DatabaseProfiles.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_DatabaseProfiles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_DatabaseProfiles.ContainerControlProcessDialogKey = True
        Me.RibbonBarFilePanel_DatabaseProfiles.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBarFilePanel_DatabaseProfiles.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
        Me.RibbonBarFilePanel_DatabaseProfiles.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDatabaseProfiles_DatabaseProfiles})
        Me.RibbonBarFilePanel_DatabaseProfiles.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBarFilePanel_DatabaseProfiles.Location = New System.Drawing.Point(203, 0)
        Me.RibbonBarFilePanel_DatabaseProfiles.MinimumSize = New System.Drawing.Size(125, 0)
        Me.RibbonBarFilePanel_DatabaseProfiles.Name = "RibbonBarFilePanel_DatabaseProfiles"
        Me.RibbonBarFilePanel_DatabaseProfiles.Size = New System.Drawing.Size(125, 94)
        Me.RibbonBarFilePanel_DatabaseProfiles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBarFilePanel_DatabaseProfiles.TabIndex = 4
        Me.RibbonBarFilePanel_DatabaseProfiles.Text = "Database Profiles"
        '
        '
        '
        Me.RibbonBarFilePanel_DatabaseProfiles.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_DatabaseProfiles.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_DatabaseProfiles.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItemDatabaseProfiles_DatabaseProfiles
        '
        Me.ButtonItemDatabaseProfiles_DatabaseProfiles.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemDatabaseProfiles_DatabaseProfiles.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemDatabaseProfiles_DatabaseProfiles.Name = "ButtonItemDatabaseProfiles_DatabaseProfiles"
        Me.ButtonItemDatabaseProfiles_DatabaseProfiles.SubItemsExpandWidth = 14
        Me.ButtonItemDatabaseProfiles_DatabaseProfiles.Text = "Database Profiles"
        '
        'RibbonBarFilePanel_Settings
        '
        Me.RibbonBarFilePanel_Settings.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBarFilePanel_Settings.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_Settings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_Settings.ContainerControlProcessDialogKey = True
        Me.RibbonBarFilePanel_Settings.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBarFilePanel_Settings.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
        Me.RibbonBarFilePanel_Settings.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSettings_Save})
        Me.RibbonBarFilePanel_Settings.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBarFilePanel_Settings.Location = New System.Drawing.Point(103, 0)
        Me.RibbonBarFilePanel_Settings.Name = "RibbonBarFilePanel_Settings"
        Me.RibbonBarFilePanel_Settings.Size = New System.Drawing.Size(100, 94)
        Me.RibbonBarFilePanel_Settings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBarFilePanel_Settings.TabIndex = 3
        Me.RibbonBarFilePanel_Settings.Text = "Settings"
        '
        '
        '
        Me.RibbonBarFilePanel_Settings.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_Settings.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_Settings.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItemSettings_Save
        '
        Me.ButtonItemSettings_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemSettings_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItemSettings_Save.Name = "ButtonItemSettings_Save"
        Me.ButtonItemSettings_Save.SubItemsExpandWidth = 14
        Me.ButtonItemSettings_Save.Text = "Save"
        '
        'RibbonBarFilePanel_System
        '
        Me.RibbonBarFilePanel_System.AutoOverflowEnabled = True
        '
        '
        '
        Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_System.ContainerControlProcessDialogKey = True
        Me.RibbonBarFilePanel_System.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonBarFilePanel_System.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSystem_Exit, Me.ButtonItemSystem_Hide})
        Me.RibbonBarFilePanel_System.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.RibbonBarFilePanel_System.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.RibbonBarFilePanel_System.Location = New System.Drawing.Point(3, 0)
        Me.RibbonBarFilePanel_System.Name = "RibbonBarFilePanel_System"
        Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 94)
        Me.RibbonBarFilePanel_System.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.RibbonBarFilePanel_System.TabIndex = 0
        Me.RibbonBarFilePanel_System.Text = "System"
        '
        '
        '
        Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonBarFilePanel_System.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
        '
        'ButtonItemSystem_Exit
        '
        Me.ButtonItemSystem_Exit.BeginGroup = True
        Me.ButtonItemSystem_Exit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemSystem_Exit.FixedSize = New System.Drawing.Size(90, 20)
        Me.ButtonItemSystem_Exit.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonItemSystem_Exit.Name = "ButtonItemSystem_Exit"
        Me.ButtonItemSystem_Exit.Stretch = True
        Me.ButtonItemSystem_Exit.SubItemsExpandWidth = 14
        Me.ButtonItemSystem_Exit.Text = "Exit"
        '
        'ButtonItemSystem_Hide
        '
        Me.ButtonItemSystem_Hide.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemSystem_Hide.Name = "ButtonItemSystem_Hide"
        Me.ButtonItemSystem_Hide.SubItemsExpandWidth = 14
        Me.ButtonItemSystem_Hide.Text = "Hide"
        '
        'Office2007StartButtonMainRibbon_Home
        '
        Me.Office2007StartButtonMainRibbon_Home.AutoExpandOnClick = True
        Me.Office2007StartButtonMainRibbon_Home.CanCustomize = False
        Me.Office2007StartButtonMainRibbon_Home.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image
        Me.Office2007StartButtonMainRibbon_Home.Image = CType(resources.GetObject("Office2007StartButtonMainRibbon_Home.Image"), System.Drawing.Image)
        Me.Office2007StartButtonMainRibbon_Home.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.Office2007StartButtonMainRibbon_Home.ImagePaddingHorizontal = 0
        Me.Office2007StartButtonMainRibbon_Home.ImagePaddingVertical = 1
        Me.Office2007StartButtonMainRibbon_Home.Name = "Office2007StartButtonMainRibbon_Home"
        Me.Office2007StartButtonMainRibbon_Home.ShowSubItems = False
        Me.Office2007StartButtonMainRibbon_Home.Text = "Menu"
        '
        'RibbonTabItemMainRibbon_File
        '
        Me.RibbonTabItemMainRibbon_File.Checked = True
        Me.RibbonTabItemMainRibbon_File.Name = "RibbonTabItemMainRibbon_File"
        Me.RibbonTabItemMainRibbon_File.Panel = Me.RibbonPanelFile_FilePanel
        Me.RibbonTabItemMainRibbon_File.Text = "File"
        '
        'ButtonItemMainRibbon_Help
        '
        Me.ButtonItemMainRibbon_Help.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemMainRibbon_Help.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonItemMainRibbon_Help.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ButtonItemMainRibbon_Help.Name = "ButtonItemMainRibbon_Help"
        '
        'ButtonItemMainRibbon_ShowAndHide
        '
        Me.ButtonItemMainRibbon_ShowAndHide.BeginGroup = True
        Me.ButtonItemMainRibbon_ShowAndHide.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItemMainRibbon_ShowAndHide.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonItemMainRibbon_ShowAndHide.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.ButtonItemMainRibbon_ShowAndHide.Name = "ButtonItemMainRibbon_ShowAndHide"
        '
        'TabControlForm_Services
        '
        Me.TabControlForm_Services.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.TabControlForm_Services.CanReorderTabs = False
        Me.TabControlForm_Services.Controls.Add(Me.TabControlPanelEmailListenerTab_EmailListener)
        Me.TabControlForm_Services.Controls.Add(Me.TabControlPanelMediaOceanImportTab_Import)
        Me.TabControlForm_Services.Controls.Add(Me.TabControlPanelMissingTimeTab_MissingTime)
        Me.TabControlForm_Services.Controls.Add(Me.TabControlPanelContractTab_Contract)
        Me.TabControlForm_Services.Controls.Add(Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals)
        Me.TabControlForm_Services.Controls.Add(Me.TabControlPanelTasks_Tasks)
        Me.TabControlForm_Services.Controls.Add(Me.TabControlPanelExport_Export)
        Me.TabControlForm_Services.Controls.Add(Me.TabControlPanelQvAAlertTab_QvAAlert)
        Me.TabControlForm_Services.Controls.Add(Me.TabControlPanelGoogleCalendarTab_GoogleCalendar)
        Me.TabControlForm_Services.Controls.Add(Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport)
        Me.TabControlForm_Services.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlForm_Services.ForeColor = System.Drawing.Color.Black
        Me.TabControlForm_Services.Location = New System.Drawing.Point(5, 155)
        Me.TabControlForm_Services.Name = "TabControlForm_Services"
        Me.TabControlForm_Services.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControlForm_Services.SelectedTabIndex = 0
        Me.TabControlForm_Services.Size = New System.Drawing.Size(850, 363)
        Me.TabControlForm_Services.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControlForm_Services.TabIndex = 4
        Me.TabControlForm_Services.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControlForm_Services.Tabs.Add(Me.TabItemServices_EmailListenerTab)
        Me.TabControlForm_Services.Tabs.Add(Me.TabItemServices_QvAAlertTab)
        Me.TabControlForm_Services.Tabs.Add(Me.TabItemServices_ExportTab)
        Me.TabControlForm_Services.Tabs.Add(Me.TabItemServices_TasksTab)
        Me.TabControlForm_Services.Tabs.Add(Me.TabItemServices_MissingTimeTab)
        Me.TabControlForm_Services.Tabs.Add(Me.TabItemServices_GoogleCalendarTab)
        Me.TabControlForm_Services.Tabs.Add(Me.TabItemServices_CoreMediaCheckExportTab)
        Me.TabControlForm_Services.Tabs.Add(Me.TabItemServices_PaidTimeOffAccrualsTab)
        Me.TabControlForm_Services.Tabs.Add(Me.TabItemServices_ContractTab)
        Me.TabControlForm_Services.Tabs.Add(Me.TabItemServices_MediaOceanImportTab)
        '
        'TabControlPanelEmailListenerTab_EmailListener
        '
        Me.TabControlPanelEmailListenerTab_EmailListener.Controls.Add(Me.CheckBoxEMail_AutoStart)
        Me.TabControlPanelEmailListenerTab_EmailListener.Controls.Add(Me.TabControlEmailListener_EmailListenerSettings)
        Me.TabControlPanelEmailListenerTab_EmailListener.Controls.Add(Me.ButtonEmailListener_Stop)
        Me.TabControlPanelEmailListenerTab_EmailListener.Controls.Add(Me.LabelEmailListener_StatusDescription)
        Me.TabControlPanelEmailListenerTab_EmailListener.Controls.Add(Me.LabelEmailListener_Status)
        Me.TabControlPanelEmailListenerTab_EmailListener.Controls.Add(Me.ButtonEmailListener_Start)
        Me.TabControlPanelEmailListenerTab_EmailListener.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelEmailListenerTab_EmailListener.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelEmailListenerTab_EmailListener.Name = "TabControlPanelEmailListenerTab_EmailListener"
        Me.TabControlPanelEmailListenerTab_EmailListener.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelEmailListenerTab_EmailListener.Size = New System.Drawing.Size(850, 336)
        Me.TabControlPanelEmailListenerTab_EmailListener.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelEmailListenerTab_EmailListener.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelEmailListenerTab_EmailListener.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelEmailListenerTab_EmailListener.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelEmailListenerTab_EmailListener.Style.GradientAngle = 90
        Me.TabControlPanelEmailListenerTab_EmailListener.TabIndex = 1
        Me.TabControlPanelEmailListenerTab_EmailListener.TabItem = Me.TabItemServices_EmailListenerTab
        '
        'CheckBoxEMail_AutoStart
        '
        Me.CheckBoxEMail_AutoStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxEMail_AutoStart.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.CheckBoxEMail_AutoStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxEMail_AutoStart.CheckValue = 0
        Me.CheckBoxEMail_AutoStart.CheckValueChecked = 1
        Me.CheckBoxEMail_AutoStart.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxEMail_AutoStart.CheckValueUnchecked = 0
        Me.CheckBoxEMail_AutoStart.ChildControls = CType(resources.GetObject("CheckBoxEMail_AutoStart.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxEMail_AutoStart.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxEMail_AutoStart.Location = New System.Drawing.Point(677, 4)
        Me.CheckBoxEMail_AutoStart.Name = "CheckBoxEMail_AutoStart"
        Me.CheckBoxEMail_AutoStart.OldestSibling = Nothing
        Me.CheckBoxEMail_AutoStart.SecurityEnabled = True
        Me.CheckBoxEMail_AutoStart.SiblingControls = CType(resources.GetObject("CheckBoxEMail_AutoStart.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxEMail_AutoStart.Size = New System.Drawing.Size(80, 20)
        Me.CheckBoxEMail_AutoStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxEMail_AutoStart.TabIndex = 11
        Me.CheckBoxEMail_AutoStart.Text = "Auto Start"
        '
        'TabControlEmailListener_EmailListenerSettings
        '
        Me.TabControlEmailListener_EmailListenerSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlEmailListener_EmailListenerSettings.BackColor = System.Drawing.Color.White
        Me.TabControlEmailListener_EmailListenerSettings.CanReorderTabs = False
        Me.TabControlEmailListener_EmailListenerSettings.Controls.Add(Me.TabControlPanelSettingsTab_EmailListenerSettings)
        Me.TabControlEmailListener_EmailListenerSettings.Controls.Add(Me.TabControlPanelLogTab_EmailListenerLog)
        Me.TabControlEmailListener_EmailListenerSettings.Controls.Add(Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles)
        Me.TabControlEmailListener_EmailListenerSettings.ForeColor = System.Drawing.Color.Black
        Me.TabControlEmailListener_EmailListenerSettings.Location = New System.Drawing.Point(12, 30)
        Me.TabControlEmailListener_EmailListenerSettings.Name = "TabControlEmailListener_EmailListenerSettings"
        Me.TabControlEmailListener_EmailListenerSettings.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControlEmailListener_EmailListenerSettings.SelectedTabIndex = 0
        Me.TabControlEmailListener_EmailListenerSettings.Size = New System.Drawing.Size(826, 294)
        Me.TabControlEmailListener_EmailListenerSettings.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControlEmailListener_EmailListenerSettings.TabIndex = 7
        Me.TabControlEmailListener_EmailListenerSettings.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControlEmailListener_EmailListenerSettings.Tabs.Add(Me.TabItemEmailListenerSettings_SettingsTab)
        Me.TabControlEmailListener_EmailListenerSettings.Tabs.Add(Me.TabItemEmailListenerSettings_DatabaseProfilesTab)
        Me.TabControlEmailListener_EmailListenerSettings.Tabs.Add(Me.TabItemEmailListenerSettings_LogTab)
        '
        'TabControlPanelSettingsTab_EmailListenerSettings
        '
        Me.TabControlPanelSettingsTab_EmailListenerSettings.Controls.Add(Me.NumericInputEmailListenerSettings_RunAtEvery)
        Me.TabControlPanelSettingsTab_EmailListenerSettings.Controls.Add(Me.TextBoxEmailListenerSettings_StartofSignatureCode)
        Me.TabControlPanelSettingsTab_EmailListenerSettings.Controls.Add(Me.LabelEmailListenerSettings_StartofSignatureCode)
        Me.TabControlPanelSettingsTab_EmailListenerSettings.Controls.Add(Me.LabelEmailListenerSettings_RunAtEvery)
        Me.TabControlPanelSettingsTab_EmailListenerSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelSettingsTab_EmailListenerSettings.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelSettingsTab_EmailListenerSettings.Name = "TabControlPanelSettingsTab_EmailListenerSettings"
        Me.TabControlPanelSettingsTab_EmailListenerSettings.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelSettingsTab_EmailListenerSettings.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelSettingsTab_EmailListenerSettings.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelSettingsTab_EmailListenerSettings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelSettingsTab_EmailListenerSettings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelSettingsTab_EmailListenerSettings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelSettingsTab_EmailListenerSettings.Style.GradientAngle = 90
        Me.TabControlPanelSettingsTab_EmailListenerSettings.TabIndex = 1
        Me.TabControlPanelSettingsTab_EmailListenerSettings.TabItem = Me.TabItemEmailListenerSettings_SettingsTab
        '
        'NumericInputEmailListenerSettings_RunAtEvery
        '
        Me.NumericInputEmailListenerSettings_RunAtEvery.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
        Me.NumericInputEmailListenerSettings_RunAtEvery.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputEmailListenerSettings_RunAtEvery.Location = New System.Drawing.Point(132, 4)
        Me.NumericInputEmailListenerSettings_RunAtEvery.Name = "NumericInputEmailListenerSettings_RunAtEvery"
        Me.NumericInputEmailListenerSettings_RunAtEvery.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NumericInputEmailListenerSettings_RunAtEvery.Properties.DisplayFormat.FormatString = "f0"
        Me.NumericInputEmailListenerSettings_RunAtEvery.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputEmailListenerSettings_RunAtEvery.Properties.EditFormat.FormatString = "f0"
        Me.NumericInputEmailListenerSettings_RunAtEvery.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputEmailListenerSettings_RunAtEvery.Properties.IsFloatValue = False
        Me.NumericInputEmailListenerSettings_RunAtEvery.Properties.Mask.EditMask = "f0"
        Me.NumericInputEmailListenerSettings_RunAtEvery.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NumericInputEmailListenerSettings_RunAtEvery.Properties.MaxLength = 11
        Me.NumericInputEmailListenerSettings_RunAtEvery.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NumericInputEmailListenerSettings_RunAtEvery.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
        Me.NumericInputEmailListenerSettings_RunAtEvery.Size = New System.Drawing.Size(75, 20)
        Me.NumericInputEmailListenerSettings_RunAtEvery.TabIndex = 1
        '
        'TextBoxEmailListenerSettings_StartofSignatureCode
        '
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.Border.Class = "TextBoxBorder"
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.CheckSpellingOnValidate = False
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.FocusHighlightEnabled = True
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.ForeColor = System.Drawing.Color.Black
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.Location = New System.Drawing.Point(132, 30)
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.MaxFileSize = CType(0, Long)
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.Name = "TextBoxEmailListenerSettings_StartofSignatureCode"
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.ShowSpellCheckCompleteMessage = True
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.Size = New System.Drawing.Size(691, 20)
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.TabIndex = 3
        Me.TextBoxEmailListenerSettings_StartofSignatureCode.TabOnEnter = True
        '
        'LabelEmailListenerSettings_StartofSignatureCode
        '
        Me.LabelEmailListenerSettings_StartofSignatureCode.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelEmailListenerSettings_StartofSignatureCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelEmailListenerSettings_StartofSignatureCode.Location = New System.Drawing.Point(4, 30)
        Me.LabelEmailListenerSettings_StartofSignatureCode.Name = "LabelEmailListenerSettings_StartofSignatureCode"
        Me.LabelEmailListenerSettings_StartofSignatureCode.Size = New System.Drawing.Size(122, 20)
        Me.LabelEmailListenerSettings_StartofSignatureCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelEmailListenerSettings_StartofSignatureCode.TabIndex = 2
        Me.LabelEmailListenerSettings_StartofSignatureCode.Text = "Start of Signature Code:"
        '
        'LabelEmailListenerSettings_RunAtEvery
        '
        Me.LabelEmailListenerSettings_RunAtEvery.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelEmailListenerSettings_RunAtEvery.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelEmailListenerSettings_RunAtEvery.Location = New System.Drawing.Point(4, 4)
        Me.LabelEmailListenerSettings_RunAtEvery.Name = "LabelEmailListenerSettings_RunAtEvery"
        Me.LabelEmailListenerSettings_RunAtEvery.Size = New System.Drawing.Size(122, 20)
        Me.LabelEmailListenerSettings_RunAtEvery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelEmailListenerSettings_RunAtEvery.TabIndex = 0
        Me.LabelEmailListenerSettings_RunAtEvery.Text = "Run at every min(s):"
        '
        'TabItemEmailListenerSettings_SettingsTab
        '
        Me.TabItemEmailListenerSettings_SettingsTab.AttachedControl = Me.TabControlPanelSettingsTab_EmailListenerSettings
        Me.TabItemEmailListenerSettings_SettingsTab.Name = "TabItemEmailListenerSettings_SettingsTab"
        Me.TabItemEmailListenerSettings_SettingsTab.Text = "Settings"
        '
        'TabControlPanelLogTab_EmailListenerLog
        '
        Me.TabControlPanelLogTab_EmailListenerLog.Controls.Add(Me.TextBoxEmailListenerLog_Log)
        Me.TabControlPanelLogTab_EmailListenerLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelLogTab_EmailListenerLog.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelLogTab_EmailListenerLog.Name = "TabControlPanelLogTab_EmailListenerLog"
        Me.TabControlPanelLogTab_EmailListenerLog.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelLogTab_EmailListenerLog.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelLogTab_EmailListenerLog.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelLogTab_EmailListenerLog.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelLogTab_EmailListenerLog.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelLogTab_EmailListenerLog.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelLogTab_EmailListenerLog.Style.GradientAngle = 90
        Me.TabControlPanelLogTab_EmailListenerLog.TabIndex = 3
        Me.TabControlPanelLogTab_EmailListenerLog.TabItem = Me.TabItemEmailListenerSettings_LogTab
        '
        'TextBoxEmailListenerLog_Log
        '
        Me.TextBoxEmailListenerLog_Log.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxEmailListenerLog_Log.Border.Class = "TextBoxBorder"
        Me.TextBoxEmailListenerLog_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxEmailListenerLog_Log.CheckSpellingOnValidate = False
        Me.TextBoxEmailListenerLog_Log.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxEmailListenerLog_Log.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxEmailListenerLog_Log.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxEmailListenerLog_Log.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxEmailListenerLog_Log.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxEmailListenerLog_Log.FocusHighlightEnabled = True
        Me.TextBoxEmailListenerLog_Log.ForeColor = System.Drawing.Color.Black
        Me.TextBoxEmailListenerLog_Log.Location = New System.Drawing.Point(1, 1)
        Me.TextBoxEmailListenerLog_Log.MaxFileSize = CType(0, Long)
        Me.TextBoxEmailListenerLog_Log.Multiline = True
        Me.TextBoxEmailListenerLog_Log.Name = "TextBoxEmailListenerLog_Log"
        Me.TextBoxEmailListenerLog_Log.ReadOnly = True
        Me.TextBoxEmailListenerLog_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxEmailListenerLog_Log.ShowSpellCheckCompleteMessage = True
        Me.TextBoxEmailListenerLog_Log.Size = New System.Drawing.Size(824, 265)
        Me.TextBoxEmailListenerLog_Log.TabIndex = 0
        Me.TextBoxEmailListenerLog_Log.TabOnEnter = True
        '
        'TabItemEmailListenerSettings_LogTab
        '
        Me.TabItemEmailListenerSettings_LogTab.AttachedControl = Me.TabControlPanelLogTab_EmailListenerLog
        Me.TabItemEmailListenerSettings_LogTab.Name = "TabItemEmailListenerSettings_LogTab"
        Me.TabItemEmailListenerSettings_LogTab.Text = "Log"
        '
        'TabControlPanelDatabaseProfilesTab_DatabaseProfiles
        '
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.ButtonEmailListenerDatabaseProfiles_ProcessNow)
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.ButtonEmailListenerDatabaseProfiles_Select)
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.ButtonEmailListenerDatabaseProfiles_Edit)
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.ButtonEmailListenerDatabaseProfiles_Remove)
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.DataGridViewEmailListenerDatabaseProfiles_Databases)
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.Name = "TabControlPanelDatabaseProfilesTab_DatabaseProfiles"
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.Style.GradientAngle = 90
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.TabIndex = 2
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.TabItem = Me.TabItemEmailListenerSettings_DatabaseProfilesTab
        '
        'ButtonEmailListenerDatabaseProfiles_ProcessNow
        '
        Me.ButtonEmailListenerDatabaseProfiles_ProcessNow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonEmailListenerDatabaseProfiles_ProcessNow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonEmailListenerDatabaseProfiles_ProcessNow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonEmailListenerDatabaseProfiles_ProcessNow.Location = New System.Drawing.Point(4, 243)
        Me.ButtonEmailListenerDatabaseProfiles_ProcessNow.Name = "ButtonEmailListenerDatabaseProfiles_ProcessNow"
        Me.ButtonEmailListenerDatabaseProfiles_ProcessNow.SecurityEnabled = True
        Me.ButtonEmailListenerDatabaseProfiles_ProcessNow.Size = New System.Drawing.Size(75, 20)
        Me.ButtonEmailListenerDatabaseProfiles_ProcessNow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonEmailListenerDatabaseProfiles_ProcessNow.TabIndex = 8
        Me.ButtonEmailListenerDatabaseProfiles_ProcessNow.Text = "Process Now"
        Me.ButtonEmailListenerDatabaseProfiles_ProcessNow.Visible = False
        '
        'ButtonEmailListenerDatabaseProfiles_Select
        '
        Me.ButtonEmailListenerDatabaseProfiles_Select.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonEmailListenerDatabaseProfiles_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonEmailListenerDatabaseProfiles_Select.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonEmailListenerDatabaseProfiles_Select.Location = New System.Drawing.Point(585, 243)
        Me.ButtonEmailListenerDatabaseProfiles_Select.Name = "ButtonEmailListenerDatabaseProfiles_Select"
        Me.ButtonEmailListenerDatabaseProfiles_Select.SecurityEnabled = True
        Me.ButtonEmailListenerDatabaseProfiles_Select.Size = New System.Drawing.Size(75, 20)
        Me.ButtonEmailListenerDatabaseProfiles_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonEmailListenerDatabaseProfiles_Select.TabIndex = 5
        Me.ButtonEmailListenerDatabaseProfiles_Select.Text = "Select"
        '
        'ButtonEmailListenerDatabaseProfiles_Edit
        '
        Me.ButtonEmailListenerDatabaseProfiles_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonEmailListenerDatabaseProfiles_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonEmailListenerDatabaseProfiles_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonEmailListenerDatabaseProfiles_Edit.Location = New System.Drawing.Point(666, 243)
        Me.ButtonEmailListenerDatabaseProfiles_Edit.Name = "ButtonEmailListenerDatabaseProfiles_Edit"
        Me.ButtonEmailListenerDatabaseProfiles_Edit.SecurityEnabled = True
        Me.ButtonEmailListenerDatabaseProfiles_Edit.Size = New System.Drawing.Size(75, 20)
        Me.ButtonEmailListenerDatabaseProfiles_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonEmailListenerDatabaseProfiles_Edit.TabIndex = 6
        Me.ButtonEmailListenerDatabaseProfiles_Edit.Text = "Edit"
        '
        'ButtonEmailListenerDatabaseProfiles_Remove
        '
        Me.ButtonEmailListenerDatabaseProfiles_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonEmailListenerDatabaseProfiles_Remove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonEmailListenerDatabaseProfiles_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonEmailListenerDatabaseProfiles_Remove.Location = New System.Drawing.Point(747, 243)
        Me.ButtonEmailListenerDatabaseProfiles_Remove.Name = "ButtonEmailListenerDatabaseProfiles_Remove"
        Me.ButtonEmailListenerDatabaseProfiles_Remove.SecurityEnabled = True
        Me.ButtonEmailListenerDatabaseProfiles_Remove.Size = New System.Drawing.Size(75, 20)
        Me.ButtonEmailListenerDatabaseProfiles_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonEmailListenerDatabaseProfiles_Remove.TabIndex = 7
        Me.ButtonEmailListenerDatabaseProfiles_Remove.Text = "Remove"
        '
        'DataGridViewEmailListenerDatabaseProfiles_Databases
        '
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.AllowSelectGroupHeaderRow = True
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.AlwaysForceShowRowSelectionOnUserInput = True
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.AutoFilterLookupColumns = False
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.AutoloadRepositoryDatasource = True
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.DatabaseProfile
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.ItemDescription = "Item(s)"
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.Location = New System.Drawing.Point(4, 4)
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.MultiSelect = True
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.Name = "DataGridViewEmailListenerDatabaseProfiles_Databases"
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.RunStandardValidation = True
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.ShowSelectDeselectAllButtons = False
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.Size = New System.Drawing.Size(818, 233)
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.TabIndex = 4
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.UseEmbeddedNavigator = False
        Me.DataGridViewEmailListenerDatabaseProfiles_Databases.ViewCaptionHeight = -1
        '
        'TabItemEmailListenerSettings_DatabaseProfilesTab
        '
        Me.TabItemEmailListenerSettings_DatabaseProfilesTab.AttachedControl = Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles
        Me.TabItemEmailListenerSettings_DatabaseProfilesTab.Name = "TabItemEmailListenerSettings_DatabaseProfilesTab"
        Me.TabItemEmailListenerSettings_DatabaseProfilesTab.Text = "Database Profiles"
        '
        'ButtonEmailListener_Stop
        '
        Me.ButtonEmailListener_Stop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonEmailListener_Stop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonEmailListener_Stop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonEmailListener_Stop.Location = New System.Drawing.Point(763, 4)
        Me.ButtonEmailListener_Stop.Name = "ButtonEmailListener_Stop"
        Me.ButtonEmailListener_Stop.SecurityEnabled = True
        Me.ButtonEmailListener_Stop.Size = New System.Drawing.Size(75, 20)
        Me.ButtonEmailListener_Stop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonEmailListener_Stop.TabIndex = 8
        Me.ButtonEmailListener_Stop.Text = "Stop"
        Me.ButtonEmailListener_Stop.Visible = False
        '
        'LabelEmailListener_StatusDescription
        '
        Me.LabelEmailListener_StatusDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelEmailListener_StatusDescription.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelEmailListener_StatusDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelEmailListener_StatusDescription.Location = New System.Drawing.Point(58, 4)
        Me.LabelEmailListener_StatusDescription.Name = "LabelEmailListener_StatusDescription"
        Me.LabelEmailListener_StatusDescription.Size = New System.Drawing.Size(613, 20)
        Me.LabelEmailListener_StatusDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelEmailListener_StatusDescription.TabIndex = 4
        Me.LabelEmailListener_StatusDescription.Text = "Stopped..."
        '
        'LabelEmailListener_Status
        '
        Me.LabelEmailListener_Status.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelEmailListener_Status.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelEmailListener_Status.Location = New System.Drawing.Point(12, 4)
        Me.LabelEmailListener_Status.Name = "LabelEmailListener_Status"
        Me.LabelEmailListener_Status.Size = New System.Drawing.Size(40, 20)
        Me.LabelEmailListener_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelEmailListener_Status.TabIndex = 3
        Me.LabelEmailListener_Status.Text = "Status:"
        '
        'ButtonEmailListener_Start
        '
        Me.ButtonEmailListener_Start.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonEmailListener_Start.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonEmailListener_Start.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonEmailListener_Start.Location = New System.Drawing.Point(763, 4)
        Me.ButtonEmailListener_Start.Name = "ButtonEmailListener_Start"
        Me.ButtonEmailListener_Start.SecurityEnabled = True
        Me.ButtonEmailListener_Start.Size = New System.Drawing.Size(75, 20)
        Me.ButtonEmailListener_Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonEmailListener_Start.TabIndex = 5
        Me.ButtonEmailListener_Start.Text = "Start"
        '
        'TabItemServices_EmailListenerTab
        '
        Me.TabItemServices_EmailListenerTab.AttachedControl = Me.TabControlPanelEmailListenerTab_EmailListener
        Me.TabItemServices_EmailListenerTab.Name = "TabItemServices_EmailListenerTab"
        Me.TabItemServices_EmailListenerTab.Text = "Email Listener"
        '
        'TabControlPanelMediaOceanImportTab_Import
        '
        Me.TabControlPanelMediaOceanImportTab_Import.Controls.Add(Me.CheckBoxMediaOceanImport_AutoStart)
        Me.TabControlPanelMediaOceanImportTab_Import.Controls.Add(Me.TabControlMediaOceanImport_MediaOceanImportSettings)
        Me.TabControlPanelMediaOceanImportTab_Import.Controls.Add(Me.LabelMediaOceanImport_StatusDescription)
        Me.TabControlPanelMediaOceanImportTab_Import.Controls.Add(Me.LabelMediaOceanImport_Status)
        Me.TabControlPanelMediaOceanImportTab_Import.Controls.Add(Me.ButtonMediaOceanImport_Start)
        Me.TabControlPanelMediaOceanImportTab_Import.Controls.Add(Me.ButtonMediaOceanImport_Stop)
        Me.TabControlPanelMediaOceanImportTab_Import.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelMediaOceanImportTab_Import.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelMediaOceanImportTab_Import.Name = "TabControlPanelMediaOceanImportTab_Import"
        Me.TabControlPanelMediaOceanImportTab_Import.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelMediaOceanImportTab_Import.Size = New System.Drawing.Size(850, 336)
        Me.TabControlPanelMediaOceanImportTab_Import.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelMediaOceanImportTab_Import.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelMediaOceanImportTab_Import.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelMediaOceanImportTab_Import.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelMediaOceanImportTab_Import.Style.GradientAngle = 90
        Me.TabControlPanelMediaOceanImportTab_Import.TabIndex = 11
        Me.TabControlPanelMediaOceanImportTab_Import.TabItem = Me.TabItemServices_MediaOceanImportTab
        '
        'CheckBoxMediaOceanImport_AutoStart
        '
        Me.CheckBoxMediaOceanImport_AutoStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxMediaOceanImport_AutoStart.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.CheckBoxMediaOceanImport_AutoStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxMediaOceanImport_AutoStart.CheckValue = 0
        Me.CheckBoxMediaOceanImport_AutoStart.CheckValueChecked = 1
        Me.CheckBoxMediaOceanImport_AutoStart.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxMediaOceanImport_AutoStart.CheckValueUnchecked = 0
        Me.CheckBoxMediaOceanImport_AutoStart.ChildControls = CType(resources.GetObject("CheckBoxMediaOceanImport_AutoStart.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMediaOceanImport_AutoStart.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxMediaOceanImport_AutoStart.Location = New System.Drawing.Point(677, 4)
        Me.CheckBoxMediaOceanImport_AutoStart.Name = "CheckBoxMediaOceanImport_AutoStart"
        Me.CheckBoxMediaOceanImport_AutoStart.OldestSibling = Nothing
        Me.CheckBoxMediaOceanImport_AutoStart.SecurityEnabled = True
        Me.CheckBoxMediaOceanImport_AutoStart.SiblingControls = CType(resources.GetObject("CheckBoxMediaOceanImport_AutoStart.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMediaOceanImport_AutoStart.Size = New System.Drawing.Size(80, 20)
        Me.CheckBoxMediaOceanImport_AutoStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxMediaOceanImport_AutoStart.TabIndex = 2
        Me.CheckBoxMediaOceanImport_AutoStart.Text = "Auto Start"
        '
        'TabControlMediaOceanImport_MediaOceanImportSettings
        '
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.BackColor = System.Drawing.Color.White
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.CanReorderTabs = False
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.Controls.Add(Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings)
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.Controls.Add(Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog)
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.Controls.Add(Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles)
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.ForeColor = System.Drawing.Color.Black
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.Location = New System.Drawing.Point(12, 30)
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.Name = "TabControlMediaOceanImport_MediaOceanImportSettings"
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.SelectedTabIndex = 0
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.Size = New System.Drawing.Size(826, 295)
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.TabIndex = 4
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.Tabs.Add(Me.TabItemMediaOceanImportSettings_MediaOceanImportSettingsTab)
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.Tabs.Add(Me.TabItemMediaOceanImportSettings_MediaOceanImportDatabaseProfilesTab)
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.Tabs.Add(Me.TabItemMediaOceanImportSettings_MediaOceanImportLogTab)
        '
        'TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings
        '
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Controls.Add(Me.LabelMediaOceanImportSettings_RunAt)
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Controls.Add(Me.DateTimeInputMediaOceanImportSettings_RunAt)
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Controls.Add(Me.GroupBoxMediaOceanImportSettings_Settings)
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Controls.Add(Me.LabelMediaOceanImportSettings_DatabaseProfile)
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Controls.Add(Me.ComboBoxMediaOceanImportSettings_DatabaseProfile)
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Name = "TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings"
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Size = New System.Drawing.Size(826, 268)
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.Style.GradientAngle = 90
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.TabIndex = 1
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.TabItem = Me.TabItemMediaOceanImportSettings_MediaOceanImportSettingsTab
        '
        'LabelMediaOceanImportSettings_RunAt
        '
        Me.LabelMediaOceanImportSettings_RunAt.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMediaOceanImportSettings_RunAt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMediaOceanImportSettings_RunAt.Location = New System.Drawing.Point(4, 4)
        Me.LabelMediaOceanImportSettings_RunAt.Name = "LabelMediaOceanImportSettings_RunAt"
        Me.LabelMediaOceanImportSettings_RunAt.Size = New System.Drawing.Size(90, 20)
        Me.LabelMediaOceanImportSettings_RunAt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMediaOceanImportSettings_RunAt.TabIndex = 5
        Me.LabelMediaOceanImportSettings_RunAt.Text = "Run At (Daily):"
        '
        'DateTimeInputMediaOceanImportSettings_RunAt
        '
        Me.DateTimeInputMediaOceanImportSettings_RunAt.AllowEmptyState = False
        Me.DateTimeInputMediaOceanImportSettings_RunAt.AutoResolveFreeTextEntries = False
        '
        '
        '
        Me.DateTimeInputMediaOceanImportSettings_RunAt.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DateTimeInputMediaOceanImportSettings_RunAt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputMediaOceanImportSettings_RunAt.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DateTimeInputMediaOceanImportSettings_RunAt.ButtonDropDown.Visible = True
        Me.DateTimeInputMediaOceanImportSettings_RunAt.ButtonFreeText.Checked = True
        Me.DateTimeInputMediaOceanImportSettings_RunAt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
        Me.DateTimeInputMediaOceanImportSettings_RunAt.CustomFormat = "hh:nn AMPM"
        Me.DateTimeInputMediaOceanImportSettings_RunAt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.DateTimeInputMediaOceanImportSettings_RunAt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.DateTimeInputMediaOceanImportSettings_RunAt.FocusHighlightEnabled = True
        Me.DateTimeInputMediaOceanImportSettings_RunAt.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.DateTimeInputMediaOceanImportSettings_RunAt.FreeTextEntryMode = True
        Me.DateTimeInputMediaOceanImportSettings_RunAt.IsPopupCalendarOpen = False
        Me.DateTimeInputMediaOceanImportSettings_RunAt.Location = New System.Drawing.Point(100, 4)
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.DisplayMonth = New Date(2011, 6, 1, 0, 0, 0, 0)
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.TodayButtonVisible = True
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.Visible = False
        Me.DateTimeInputMediaOceanImportSettings_RunAt.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DateTimeInputMediaOceanImportSettings_RunAt.Name = "DateTimeInputMediaOceanImportSettings_RunAt"
        Me.DateTimeInputMediaOceanImportSettings_RunAt.ReadOnly = False
        Me.DateTimeInputMediaOceanImportSettings_RunAt.Size = New System.Drawing.Size(88, 20)
        Me.DateTimeInputMediaOceanImportSettings_RunAt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DateTimeInputMediaOceanImportSettings_RunAt.TabIndex = 6
        '
        'GroupBoxMediaOceanImportSettings_Settings
        '
        Me.GroupBoxMediaOceanImportSettings_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxMediaOceanImportSettings_Settings.Controls.Add(Me.LabelMediaOceanImportSettings_Employee)
        Me.GroupBoxMediaOceanImportSettings_Settings.Controls.Add(Me.ComboBoxMediaOceanImportSettings_Employee)
        Me.GroupBoxMediaOceanImportSettings_Settings.Controls.Add(Me.TextBoxMediaOceanImportSettings_LocalFolder)
        Me.GroupBoxMediaOceanImportSettings_Settings.Controls.Add(Me.LabelMediaOceanImportSettings_LocalFolder)
        Me.GroupBoxMediaOceanImportSettings_Settings.Controls.Add(Me.ButtonMediaOceanImportSettings_ValidateFTP)
        Me.GroupBoxMediaOceanImportSettings_Settings.Controls.Add(Me.TextBoxMediaOceanImportSettings_FTPPassword)
        Me.GroupBoxMediaOceanImportSettings_Settings.Controls.Add(Me.TextBoxMediaOceanImportSettings_FTPUser)
        Me.GroupBoxMediaOceanImportSettings_Settings.Controls.Add(Me.LabelMediaOceanImportSettings_FTPPassword)
        Me.GroupBoxMediaOceanImportSettings_Settings.Controls.Add(Me.LabelMediaOceanImportSettings_FTPUser)
        Me.GroupBoxMediaOceanImportSettings_Settings.Controls.Add(Me.TextBoxMediaOceanImportSettings_FTPAddress)
        Me.GroupBoxMediaOceanImportSettings_Settings.Controls.Add(Me.LabelMediaOceanImportSettings_FTPAddress)
        Me.GroupBoxMediaOceanImportSettings_Settings.Location = New System.Drawing.Point(4, 57)
        Me.GroupBoxMediaOceanImportSettings_Settings.Name = "GroupBoxMediaOceanImportSettings_Settings"
        Me.GroupBoxMediaOceanImportSettings_Settings.Size = New System.Drawing.Size(818, 187)
        Me.GroupBoxMediaOceanImportSettings_Settings.TabIndex = 2
        Me.GroupBoxMediaOceanImportSettings_Settings.Text = "Settings"
        '
        'LabelMediaOceanImportSettings_Employee
        '
        Me.LabelMediaOceanImportSettings_Employee.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMediaOceanImportSettings_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMediaOceanImportSettings_Employee.Location = New System.Drawing.Point(5, 47)
        Me.LabelMediaOceanImportSettings_Employee.Name = "LabelMediaOceanImportSettings_Employee"
        Me.LabelMediaOceanImportSettings_Employee.Size = New System.Drawing.Size(90, 20)
        Me.LabelMediaOceanImportSettings_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMediaOceanImportSettings_Employee.TabIndex = 7
        Me.LabelMediaOceanImportSettings_Employee.Text = "Employee:"
        '
        'ComboBoxMediaOceanImportSettings_Employee
        '
        Me.ComboBoxMediaOceanImportSettings_Employee.AddInactiveItemsOnSelectedValue = False
        Me.ComboBoxMediaOceanImportSettings_Employee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxMediaOceanImportSettings_Employee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxMediaOceanImportSettings_Employee.AutoFindItemInDataSource = False
        Me.ComboBoxMediaOceanImportSettings_Employee.AutoSelectSingleItemDatasource = False
        Me.ComboBoxMediaOceanImportSettings_Employee.BookmarkingEnabled = False
        Me.ComboBoxMediaOceanImportSettings_Employee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Employee
        Me.ComboBoxMediaOceanImportSettings_Employee.DisableMouseWheel = False
        Me.ComboBoxMediaOceanImportSettings_Employee.DisplayMember = "FullName"
        Me.ComboBoxMediaOceanImportSettings_Employee.DisplayName = ""
        Me.ComboBoxMediaOceanImportSettings_Employee.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxMediaOceanImportSettings_Employee.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.ComboBoxMediaOceanImportSettings_Employee.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
        Me.ComboBoxMediaOceanImportSettings_Employee.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.ComboBoxMediaOceanImportSettings_Employee.FocusHighlightEnabled = True
        Me.ComboBoxMediaOceanImportSettings_Employee.FormattingEnabled = True
        Me.ComboBoxMediaOceanImportSettings_Employee.ItemHeight = 14
        Me.ComboBoxMediaOceanImportSettings_Employee.Location = New System.Drawing.Point(101, 47)
        Me.ComboBoxMediaOceanImportSettings_Employee.Name = "ComboBoxMediaOceanImportSettings_Employee"
        Me.ComboBoxMediaOceanImportSettings_Employee.PreventEnterBeep = False
        Me.ComboBoxMediaOceanImportSettings_Employee.ReadOnly = False
        Me.ComboBoxMediaOceanImportSettings_Employee.SecurityEnabled = True
        Me.ComboBoxMediaOceanImportSettings_Employee.Size = New System.Drawing.Size(180, 20)
        Me.ComboBoxMediaOceanImportSettings_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxMediaOceanImportSettings_Employee.TabIndex = 8
        Me.ComboBoxMediaOceanImportSettings_Employee.ValueMember = "Code"
        Me.ComboBoxMediaOceanImportSettings_Employee.WatermarkText = "Select Employee"
        '
        'TextBoxMediaOceanImportSettings_LocalFolder
        '
        Me.TextBoxMediaOceanImportSettings_LocalFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxMediaOceanImportSettings_LocalFolder.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxMediaOceanImportSettings_LocalFolder.Border.Class = "TextBoxBorder"
        Me.TextBoxMediaOceanImportSettings_LocalFolder.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxMediaOceanImportSettings_LocalFolder.ButtonCustom.Visible = True
        Me.TextBoxMediaOceanImportSettings_LocalFolder.CheckSpellingOnValidate = False
        Me.TextBoxMediaOceanImportSettings_LocalFolder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
        Me.TextBoxMediaOceanImportSettings_LocalFolder.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxMediaOceanImportSettings_LocalFolder.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxMediaOceanImportSettings_LocalFolder.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxMediaOceanImportSettings_LocalFolder.FocusHighlightEnabled = True
        Me.TextBoxMediaOceanImportSettings_LocalFolder.ForeColor = System.Drawing.Color.Black
        Me.TextBoxMediaOceanImportSettings_LocalFolder.Location = New System.Drawing.Point(101, 21)
        Me.TextBoxMediaOceanImportSettings_LocalFolder.MaxFileSize = CType(0, Long)
        Me.TextBoxMediaOceanImportSettings_LocalFolder.Name = "TextBoxMediaOceanImportSettings_LocalFolder"
        Me.TextBoxMediaOceanImportSettings_LocalFolder.ShowSpellCheckCompleteMessage = True
        Me.TextBoxMediaOceanImportSettings_LocalFolder.Size = New System.Drawing.Size(711, 20)
        Me.TextBoxMediaOceanImportSettings_LocalFolder.TabIndex = 6
        Me.TextBoxMediaOceanImportSettings_LocalFolder.TabOnEnter = True
        '
        'LabelMediaOceanImportSettings_LocalFolder
        '
        Me.LabelMediaOceanImportSettings_LocalFolder.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMediaOceanImportSettings_LocalFolder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMediaOceanImportSettings_LocalFolder.Location = New System.Drawing.Point(5, 21)
        Me.LabelMediaOceanImportSettings_LocalFolder.Name = "LabelMediaOceanImportSettings_LocalFolder"
        Me.LabelMediaOceanImportSettings_LocalFolder.Size = New System.Drawing.Size(90, 20)
        Me.LabelMediaOceanImportSettings_LocalFolder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMediaOceanImportSettings_LocalFolder.TabIndex = 5
        Me.LabelMediaOceanImportSettings_LocalFolder.Text = "Local Folder:"
        '
        'ButtonMediaOceanImportSettings_ValidateFTP
        '
        Me.ButtonMediaOceanImportSettings_ValidateFTP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonMediaOceanImportSettings_ValidateFTP.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonMediaOceanImportSettings_ValidateFTP.Location = New System.Drawing.Point(101, 151)
        Me.ButtonMediaOceanImportSettings_ValidateFTP.Name = "ButtonMediaOceanImportSettings_ValidateFTP"
        Me.ButtonMediaOceanImportSettings_ValidateFTP.SecurityEnabled = True
        Me.ButtonMediaOceanImportSettings_ValidateFTP.Size = New System.Drawing.Size(75, 20)
        Me.ButtonMediaOceanImportSettings_ValidateFTP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonMediaOceanImportSettings_ValidateFTP.TabIndex = 15
        Me.ButtonMediaOceanImportSettings_ValidateFTP.Text = "Validate FTP"
        '
        'TextBoxMediaOceanImportSettings_FTPPassword
        '
        Me.TextBoxMediaOceanImportSettings_FTPPassword.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxMediaOceanImportSettings_FTPPassword.Border.Class = "TextBoxBorder"
        Me.TextBoxMediaOceanImportSettings_FTPPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxMediaOceanImportSettings_FTPPassword.CheckSpellingOnValidate = False
        Me.TextBoxMediaOceanImportSettings_FTPPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxMediaOceanImportSettings_FTPPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxMediaOceanImportSettings_FTPPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxMediaOceanImportSettings_FTPPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxMediaOceanImportSettings_FTPPassword.FocusHighlightEnabled = True
        Me.TextBoxMediaOceanImportSettings_FTPPassword.ForeColor = System.Drawing.Color.Black
        Me.TextBoxMediaOceanImportSettings_FTPPassword.Location = New System.Drawing.Point(101, 125)
        Me.TextBoxMediaOceanImportSettings_FTPPassword.MaxFileSize = CType(0, Long)
        Me.TextBoxMediaOceanImportSettings_FTPPassword.Name = "TextBoxMediaOceanImportSettings_FTPPassword"
        Me.TextBoxMediaOceanImportSettings_FTPPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxMediaOceanImportSettings_FTPPassword.ShowSpellCheckCompleteMessage = True
        Me.TextBoxMediaOceanImportSettings_FTPPassword.Size = New System.Drawing.Size(461, 20)
        Me.TextBoxMediaOceanImportSettings_FTPPassword.TabIndex = 14
        Me.TextBoxMediaOceanImportSettings_FTPPassword.TabOnEnter = True
        '
        'TextBoxMediaOceanImportSettings_FTPUser
        '
        Me.TextBoxMediaOceanImportSettings_FTPUser.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxMediaOceanImportSettings_FTPUser.Border.Class = "TextBoxBorder"
        Me.TextBoxMediaOceanImportSettings_FTPUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxMediaOceanImportSettings_FTPUser.CheckSpellingOnValidate = False
        Me.TextBoxMediaOceanImportSettings_FTPUser.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxMediaOceanImportSettings_FTPUser.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxMediaOceanImportSettings_FTPUser.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxMediaOceanImportSettings_FTPUser.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxMediaOceanImportSettings_FTPUser.FocusHighlightEnabled = True
        Me.TextBoxMediaOceanImportSettings_FTPUser.ForeColor = System.Drawing.Color.Black
        Me.TextBoxMediaOceanImportSettings_FTPUser.Location = New System.Drawing.Point(101, 99)
        Me.TextBoxMediaOceanImportSettings_FTPUser.MaxFileSize = CType(0, Long)
        Me.TextBoxMediaOceanImportSettings_FTPUser.Name = "TextBoxMediaOceanImportSettings_FTPUser"
        Me.TextBoxMediaOceanImportSettings_FTPUser.ShowSpellCheckCompleteMessage = True
        Me.TextBoxMediaOceanImportSettings_FTPUser.Size = New System.Drawing.Size(461, 20)
        Me.TextBoxMediaOceanImportSettings_FTPUser.TabIndex = 12
        Me.TextBoxMediaOceanImportSettings_FTPUser.TabOnEnter = True
        '
        'LabelMediaOceanImportSettings_FTPPassword
        '
        Me.LabelMediaOceanImportSettings_FTPPassword.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMediaOceanImportSettings_FTPPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMediaOceanImportSettings_FTPPassword.Location = New System.Drawing.Point(5, 125)
        Me.LabelMediaOceanImportSettings_FTPPassword.Name = "LabelMediaOceanImportSettings_FTPPassword"
        Me.LabelMediaOceanImportSettings_FTPPassword.Size = New System.Drawing.Size(90, 20)
        Me.LabelMediaOceanImportSettings_FTPPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMediaOceanImportSettings_FTPPassword.TabIndex = 13
        Me.LabelMediaOceanImportSettings_FTPPassword.Text = "FTP Password:"
        '
        'LabelMediaOceanImportSettings_FTPUser
        '
        Me.LabelMediaOceanImportSettings_FTPUser.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMediaOceanImportSettings_FTPUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMediaOceanImportSettings_FTPUser.Location = New System.Drawing.Point(5, 99)
        Me.LabelMediaOceanImportSettings_FTPUser.Name = "LabelMediaOceanImportSettings_FTPUser"
        Me.LabelMediaOceanImportSettings_FTPUser.Size = New System.Drawing.Size(90, 20)
        Me.LabelMediaOceanImportSettings_FTPUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMediaOceanImportSettings_FTPUser.TabIndex = 11
        Me.LabelMediaOceanImportSettings_FTPUser.Text = "FTP User:"
        '
        'TextBoxMediaOceanImportSettings_FTPAddress
        '
        Me.TextBoxMediaOceanImportSettings_FTPAddress.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxMediaOceanImportSettings_FTPAddress.Border.Class = "TextBoxBorder"
        Me.TextBoxMediaOceanImportSettings_FTPAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxMediaOceanImportSettings_FTPAddress.CheckSpellingOnValidate = False
        Me.TextBoxMediaOceanImportSettings_FTPAddress.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxMediaOceanImportSettings_FTPAddress.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxMediaOceanImportSettings_FTPAddress.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxMediaOceanImportSettings_FTPAddress.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxMediaOceanImportSettings_FTPAddress.FocusHighlightEnabled = True
        Me.TextBoxMediaOceanImportSettings_FTPAddress.ForeColor = System.Drawing.Color.Black
        Me.TextBoxMediaOceanImportSettings_FTPAddress.Location = New System.Drawing.Point(101, 73)
        Me.TextBoxMediaOceanImportSettings_FTPAddress.MaxFileSize = CType(0, Long)
        Me.TextBoxMediaOceanImportSettings_FTPAddress.Name = "TextBoxMediaOceanImportSettings_FTPAddress"
        Me.TextBoxMediaOceanImportSettings_FTPAddress.ShowSpellCheckCompleteMessage = True
        Me.TextBoxMediaOceanImportSettings_FTPAddress.Size = New System.Drawing.Size(461, 20)
        Me.TextBoxMediaOceanImportSettings_FTPAddress.TabIndex = 10
        Me.TextBoxMediaOceanImportSettings_FTPAddress.TabOnEnter = True
        '
        'LabelMediaOceanImportSettings_FTPAddress
        '
        Me.LabelMediaOceanImportSettings_FTPAddress.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMediaOceanImportSettings_FTPAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMediaOceanImportSettings_FTPAddress.Location = New System.Drawing.Point(5, 73)
        Me.LabelMediaOceanImportSettings_FTPAddress.Name = "LabelMediaOceanImportSettings_FTPAddress"
        Me.LabelMediaOceanImportSettings_FTPAddress.Size = New System.Drawing.Size(90, 20)
        Me.LabelMediaOceanImportSettings_FTPAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMediaOceanImportSettings_FTPAddress.TabIndex = 9
        Me.LabelMediaOceanImportSettings_FTPAddress.Text = "FTP Address:"
        '
        'LabelMediaOceanImportSettings_DatabaseProfile
        '
        Me.LabelMediaOceanImportSettings_DatabaseProfile.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMediaOceanImportSettings_DatabaseProfile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMediaOceanImportSettings_DatabaseProfile.Location = New System.Drawing.Point(4, 30)
        Me.LabelMediaOceanImportSettings_DatabaseProfile.Name = "LabelMediaOceanImportSettings_DatabaseProfile"
        Me.LabelMediaOceanImportSettings_DatabaseProfile.Size = New System.Drawing.Size(90, 20)
        Me.LabelMediaOceanImportSettings_DatabaseProfile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMediaOceanImportSettings_DatabaseProfile.TabIndex = 0
        Me.LabelMediaOceanImportSettings_DatabaseProfile.Text = "Database Profile:"
        '
        'ComboBoxMediaOceanImportSettings_DatabaseProfile
        '
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.AddInactiveItemsOnSelectedValue = False
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.AutoFindItemInDataSource = False
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.AutoSelectSingleItemDatasource = False
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.BookmarkingEnabled = False
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.DatabaseProfile
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.DisableMouseWheel = False
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.DisplayMember = "Name"
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.DisplayName = ""
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.FocusHighlightEnabled = True
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.FormattingEnabled = True
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.ItemHeight = 14
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.Location = New System.Drawing.Point(100, 31)
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.Name = "ComboBoxMediaOceanImportSettings_DatabaseProfile"
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.PreventEnterBeep = False
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.ReadOnly = False
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.SecurityEnabled = True
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.Size = New System.Drawing.Size(180, 20)
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.TabIndex = 1
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.ValueMember = "ConnectionString"
        Me.ComboBoxMediaOceanImportSettings_DatabaseProfile.WatermarkText = "Select Database Profile"
        '
        'TabItemMediaOceanImportSettings_MediaOceanImportSettingsTab
        '
        Me.TabItemMediaOceanImportSettings_MediaOceanImportSettingsTab.AttachedControl = Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings
        Me.TabItemMediaOceanImportSettings_MediaOceanImportSettingsTab.Name = "TabItemMediaOceanImportSettings_MediaOceanImportSettingsTab"
        Me.TabItemMediaOceanImportSettings_MediaOceanImportSettingsTab.Text = "Settings"
        '
        'TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog
        '
        Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog.Controls.Add(Me.TextBoxMediaOceanImportLog_Log)
        Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog.Name = "TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog"
        Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog.Size = New System.Drawing.Size(826, 268)
        Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog.Style.GradientAngle = 90
        Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog.TabIndex = 3
        Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog.TabItem = Me.TabItemMediaOceanImportSettings_MediaOceanImportLogTab
        '
        'TextBoxMediaOceanImportLog_Log
        '
        Me.TextBoxMediaOceanImportLog_Log.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxMediaOceanImportLog_Log.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxMediaOceanImportLog_Log.Border.Class = "TextBoxBorder"
        Me.TextBoxMediaOceanImportLog_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxMediaOceanImportLog_Log.CheckSpellingOnValidate = False
        Me.TextBoxMediaOceanImportLog_Log.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxMediaOceanImportLog_Log.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxMediaOceanImportLog_Log.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxMediaOceanImportLog_Log.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxMediaOceanImportLog_Log.FocusHighlightEnabled = True
        Me.TextBoxMediaOceanImportLog_Log.ForeColor = System.Drawing.Color.Black
        Me.TextBoxMediaOceanImportLog_Log.Location = New System.Drawing.Point(4, 4)
        Me.TextBoxMediaOceanImportLog_Log.MaxFileSize = CType(0, Long)
        Me.TextBoxMediaOceanImportLog_Log.Multiline = True
        Me.TextBoxMediaOceanImportLog_Log.Name = "TextBoxMediaOceanImportLog_Log"
        Me.TextBoxMediaOceanImportLog_Log.ReadOnly = True
        Me.TextBoxMediaOceanImportLog_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxMediaOceanImportLog_Log.ShowSpellCheckCompleteMessage = True
        Me.TextBoxMediaOceanImportLog_Log.Size = New System.Drawing.Size(818, 259)
        Me.TextBoxMediaOceanImportLog_Log.TabIndex = 17
        Me.TextBoxMediaOceanImportLog_Log.TabOnEnter = True
        '
        'TabItemMediaOceanImportSettings_MediaOceanImportLogTab
        '
        Me.TabItemMediaOceanImportSettings_MediaOceanImportLogTab.AttachedControl = Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog
        Me.TabItemMediaOceanImportSettings_MediaOceanImportLogTab.Name = "TabItemMediaOceanImportSettings_MediaOceanImportLogTab"
        Me.TabItemMediaOceanImportSettings_MediaOceanImportLogTab.Text = "Log"
        '
        'TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles
        '
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.Controls.Add(Me.ButtonMediaOceanImportDatabaseProfiles_ProcessNow)
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.Controls.Add(Me.ButtonMediaOceanImportDatabaseProfiles_Select)
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.Controls.Add(Me.ButtonMediaOceanImportDatabaseProfiles_Edit)
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.Controls.Add(Me.ButtonMediaOceanImportDatabaseProfiles_Remove)
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.Controls.Add(Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases)
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.Name = "TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfil" & _
    "es"
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.Size = New System.Drawing.Size(826, 268)
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.Style.GradientAngle = 90
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.TabIndex = 2
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.TabItem = Me.TabItemMediaOceanImportSettings_MediaOceanImportDatabaseProfilesTab
        '
        'ButtonMediaOceanImportDatabaseProfiles_ProcessNow
        '
        Me.ButtonMediaOceanImportDatabaseProfiles_ProcessNow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonMediaOceanImportDatabaseProfiles_ProcessNow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonMediaOceanImportDatabaseProfiles_ProcessNow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonMediaOceanImportDatabaseProfiles_ProcessNow.Location = New System.Drawing.Point(4, 243)
        Me.ButtonMediaOceanImportDatabaseProfiles_ProcessNow.Name = "ButtonMediaOceanImportDatabaseProfiles_ProcessNow"
        Me.ButtonMediaOceanImportDatabaseProfiles_ProcessNow.SecurityEnabled = True
        Me.ButtonMediaOceanImportDatabaseProfiles_ProcessNow.Size = New System.Drawing.Size(75, 20)
        Me.ButtonMediaOceanImportDatabaseProfiles_ProcessNow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonMediaOceanImportDatabaseProfiles_ProcessNow.TabIndex = 13
        Me.ButtonMediaOceanImportDatabaseProfiles_ProcessNow.Text = "Process Now"
        '
        'ButtonMediaOceanImportDatabaseProfiles_Select
        '
        Me.ButtonMediaOceanImportDatabaseProfiles_Select.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonMediaOceanImportDatabaseProfiles_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonMediaOceanImportDatabaseProfiles_Select.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonMediaOceanImportDatabaseProfiles_Select.Location = New System.Drawing.Point(585, 243)
        Me.ButtonMediaOceanImportDatabaseProfiles_Select.Name = "ButtonMediaOceanImportDatabaseProfiles_Select"
        Me.ButtonMediaOceanImportDatabaseProfiles_Select.SecurityEnabled = True
        Me.ButtonMediaOceanImportDatabaseProfiles_Select.Size = New System.Drawing.Size(75, 20)
        Me.ButtonMediaOceanImportDatabaseProfiles_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonMediaOceanImportDatabaseProfiles_Select.TabIndex = 14
        Me.ButtonMediaOceanImportDatabaseProfiles_Select.Text = "Select"
        '
        'ButtonMediaOceanImportDatabaseProfiles_Edit
        '
        Me.ButtonMediaOceanImportDatabaseProfiles_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonMediaOceanImportDatabaseProfiles_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonMediaOceanImportDatabaseProfiles_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonMediaOceanImportDatabaseProfiles_Edit.Location = New System.Drawing.Point(666, 243)
        Me.ButtonMediaOceanImportDatabaseProfiles_Edit.Name = "ButtonMediaOceanImportDatabaseProfiles_Edit"
        Me.ButtonMediaOceanImportDatabaseProfiles_Edit.SecurityEnabled = True
        Me.ButtonMediaOceanImportDatabaseProfiles_Edit.Size = New System.Drawing.Size(75, 20)
        Me.ButtonMediaOceanImportDatabaseProfiles_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonMediaOceanImportDatabaseProfiles_Edit.TabIndex = 15
        Me.ButtonMediaOceanImportDatabaseProfiles_Edit.Text = "Edit"
        '
        'ButtonMediaOceanImportDatabaseProfiles_Remove
        '
        Me.ButtonMediaOceanImportDatabaseProfiles_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonMediaOceanImportDatabaseProfiles_Remove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonMediaOceanImportDatabaseProfiles_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonMediaOceanImportDatabaseProfiles_Remove.Location = New System.Drawing.Point(747, 243)
        Me.ButtonMediaOceanImportDatabaseProfiles_Remove.Name = "ButtonMediaOceanImportDatabaseProfiles_Remove"
        Me.ButtonMediaOceanImportDatabaseProfiles_Remove.SecurityEnabled = True
        Me.ButtonMediaOceanImportDatabaseProfiles_Remove.Size = New System.Drawing.Size(75, 20)
        Me.ButtonMediaOceanImportDatabaseProfiles_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonMediaOceanImportDatabaseProfiles_Remove.TabIndex = 16
        Me.ButtonMediaOceanImportDatabaseProfiles_Remove.Text = "Remove"
        '
        'DataGridViewMediaOceanImportDatabaseProfiles_Databases
        '
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.AllowSelectGroupHeaderRow = True
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.AlwaysForceShowRowSelectionOnUserInput = True
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.AutoFilterLookupColumns = False
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.AutoloadRepositoryDatasource = True
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.BackColor = System.Drawing.SystemColors.Control
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.DatabaseProfile
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.ItemDescription = "Item(s)"
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.Location = New System.Drawing.Point(4, 4)
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.MultiSelect = True
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.Name = "DataGridViewMediaOceanImportDatabaseProfiles_Databases"
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.RunStandardValidation = True
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.ShowSelectDeselectAllButtons = False
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.Size = New System.Drawing.Size(818, 232)
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.TabIndex = 12
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.UseEmbeddedNavigator = False
        Me.DataGridViewMediaOceanImportDatabaseProfiles_Databases.ViewCaptionHeight = -1
        '
        'TabItemMediaOceanImportSettings_MediaOceanImportDatabaseProfilesTab
        '
        Me.TabItemMediaOceanImportSettings_MediaOceanImportDatabaseProfilesTab.AttachedControl = Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles
        Me.TabItemMediaOceanImportSettings_MediaOceanImportDatabaseProfilesTab.Name = "TabItemMediaOceanImportSettings_MediaOceanImportDatabaseProfilesTab"
        Me.TabItemMediaOceanImportSettings_MediaOceanImportDatabaseProfilesTab.Text = "Database Profiles"
        '
        'LabelMediaOceanImport_StatusDescription
        '
        Me.LabelMediaOceanImport_StatusDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelMediaOceanImport_StatusDescription.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMediaOceanImport_StatusDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMediaOceanImport_StatusDescription.Location = New System.Drawing.Point(58, 4)
        Me.LabelMediaOceanImport_StatusDescription.Name = "LabelMediaOceanImport_StatusDescription"
        Me.LabelMediaOceanImport_StatusDescription.Size = New System.Drawing.Size(613, 20)
        Me.LabelMediaOceanImport_StatusDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMediaOceanImport_StatusDescription.TabIndex = 1
        Me.LabelMediaOceanImport_StatusDescription.Text = "Stopped..."
        '
        'LabelMediaOceanImport_Status
        '
        Me.LabelMediaOceanImport_Status.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMediaOceanImport_Status.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMediaOceanImport_Status.Location = New System.Drawing.Point(12, 4)
        Me.LabelMediaOceanImport_Status.Name = "LabelMediaOceanImport_Status"
        Me.LabelMediaOceanImport_Status.Size = New System.Drawing.Size(40, 20)
        Me.LabelMediaOceanImport_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMediaOceanImport_Status.TabIndex = 0
        Me.LabelMediaOceanImport_Status.Text = "Status:"
        '
        'ButtonMediaOceanImport_Start
        '
        Me.ButtonMediaOceanImport_Start.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonMediaOceanImport_Start.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonMediaOceanImport_Start.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonMediaOceanImport_Start.Location = New System.Drawing.Point(763, 4)
        Me.ButtonMediaOceanImport_Start.Name = "ButtonMediaOceanImport_Start"
        Me.ButtonMediaOceanImport_Start.SecurityEnabled = True
        Me.ButtonMediaOceanImport_Start.Size = New System.Drawing.Size(75, 20)
        Me.ButtonMediaOceanImport_Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonMediaOceanImport_Start.TabIndex = 3
        Me.ButtonMediaOceanImport_Start.Text = "Start"
        '
        'ButtonMediaOceanImport_Stop
        '
        Me.ButtonMediaOceanImport_Stop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonMediaOceanImport_Stop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonMediaOceanImport_Stop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonMediaOceanImport_Stop.Location = New System.Drawing.Point(763, 4)
        Me.ButtonMediaOceanImport_Stop.Name = "ButtonMediaOceanImport_Stop"
        Me.ButtonMediaOceanImport_Stop.SecurityEnabled = True
        Me.ButtonMediaOceanImport_Stop.Size = New System.Drawing.Size(75, 20)
        Me.ButtonMediaOceanImport_Stop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonMediaOceanImport_Stop.TabIndex = 3
        Me.ButtonMediaOceanImport_Stop.Text = "Stop"
        Me.ButtonMediaOceanImport_Stop.Visible = False
        '
        'TabItemServices_MediaOceanImportTab
        '
        Me.TabItemServices_MediaOceanImportTab.AttachedControl = Me.TabControlPanelMediaOceanImportTab_Import
        Me.TabItemServices_MediaOceanImportTab.Name = "TabItemServices_MediaOceanImportTab"
        Me.TabItemServices_MediaOceanImportTab.Text = "Media Ocean Import"
        '
        'TabControlPanelMissingTimeTab_MissingTime
        '
        Me.TabControlPanelMissingTimeTab_MissingTime.Controls.Add(Me.TabControlMissingTime_Settings)
        Me.TabControlPanelMissingTimeTab_MissingTime.Controls.Add(Me.CheckBoxMissingTime_AutoStart)
        Me.TabControlPanelMissingTimeTab_MissingTime.Controls.Add(Me.ButtonMissingTime_Stop)
        Me.TabControlPanelMissingTimeTab_MissingTime.Controls.Add(Me.LabelMissingTime_StatusDescription)
        Me.TabControlPanelMissingTimeTab_MissingTime.Controls.Add(Me.LabelMissingTime_Status)
        Me.TabControlPanelMissingTimeTab_MissingTime.Controls.Add(Me.ButtonMissingTime_Start)
        Me.TabControlPanelMissingTimeTab_MissingTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelMissingTimeTab_MissingTime.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelMissingTimeTab_MissingTime.Name = "TabControlPanelMissingTimeTab_MissingTime"
        Me.TabControlPanelMissingTimeTab_MissingTime.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelMissingTimeTab_MissingTime.Size = New System.Drawing.Size(850, 336)
        Me.TabControlPanelMissingTimeTab_MissingTime.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelMissingTimeTab_MissingTime.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelMissingTimeTab_MissingTime.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelMissingTimeTab_MissingTime.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelMissingTimeTab_MissingTime.Style.GradientAngle = 90
        Me.TabControlPanelMissingTimeTab_MissingTime.TabIndex = 5
        Me.TabControlPanelMissingTimeTab_MissingTime.TabItem = Me.TabItemServices_MissingTimeTab
        '
        'TabControlMissingTime_Settings
        '
        Me.TabControlMissingTime_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlMissingTime_Settings.BackColor = System.Drawing.Color.White
        Me.TabControlMissingTime_Settings.CanReorderTabs = False
        Me.TabControlMissingTime_Settings.Controls.Add(Me.TabControlPanelSettingsTab_MissingTimeSettings)
        Me.TabControlMissingTime_Settings.Controls.Add(Me.TabControlPanelAlertsTab_Alerts)
        Me.TabControlMissingTime_Settings.Controls.Add(Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles)
        Me.TabControlMissingTime_Settings.Controls.Add(Me.TabControlPanelLogTab_MissingTimeLog)
        Me.TabControlMissingTime_Settings.ForeColor = System.Drawing.Color.Black
        Me.TabControlMissingTime_Settings.Location = New System.Drawing.Point(12, 30)
        Me.TabControlMissingTime_Settings.Name = "TabControlMissingTime_Settings"
        Me.TabControlMissingTime_Settings.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControlMissingTime_Settings.SelectedTabIndex = 0
        Me.TabControlMissingTime_Settings.Size = New System.Drawing.Size(826, 294)
        Me.TabControlMissingTime_Settings.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControlMissingTime_Settings.TabIndex = 16
        Me.TabControlMissingTime_Settings.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControlMissingTime_Settings.Tabs.Add(Me.TabItemMissingTimeSettings_SettingsTab)
        Me.TabControlMissingTime_Settings.Tabs.Add(Me.TabItemMissingTimeSettings_AlertsTab)
        Me.TabControlMissingTime_Settings.Tabs.Add(Me.TabItemMissingTimeSettings_DatabaseProfilesTab)
        Me.TabControlMissingTime_Settings.Tabs.Add(Me.TabItemMissingTimeSettings_LogTab)
        '
        'TabControlPanelSettingsTab_MissingTimeSettings
        '
        Me.TabControlPanelSettingsTab_MissingTimeSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPanelSettingsTab_MissingTimeSettings.Controls.Add(Me.LabelMissingTimeSettings_DatabaseProfile)
        Me.TabControlPanelSettingsTab_MissingTimeSettings.Controls.Add(Me.ComboBoxMissingTimeSettings_DatabaseProfile)
        Me.TabControlPanelSettingsTab_MissingTimeSettings.Controls.Add(Me.GroupBoxMissingTimeSettings_Interval)
        Me.TabControlPanelSettingsTab_MissingTimeSettings.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanelSettingsTab_MissingTimeSettings.Name = "TabControlPanelSettingsTab_MissingTimeSettings"
        Me.TabControlPanelSettingsTab_MissingTimeSettings.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelSettingsTab_MissingTimeSettings.Size = New System.Drawing.Size(826, 272)
        Me.TabControlPanelSettingsTab_MissingTimeSettings.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelSettingsTab_MissingTimeSettings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelSettingsTab_MissingTimeSettings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelSettingsTab_MissingTimeSettings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelSettingsTab_MissingTimeSettings.Style.GradientAngle = 90
        Me.TabControlPanelSettingsTab_MissingTimeSettings.TabIndex = 1
        Me.TabControlPanelSettingsTab_MissingTimeSettings.TabItem = Me.TabItemMissingTimeSettings_SettingsTab
        '
        'LabelMissingTimeSettings_DatabaseProfile
        '
        Me.LabelMissingTimeSettings_DatabaseProfile.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMissingTimeSettings_DatabaseProfile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMissingTimeSettings_DatabaseProfile.Location = New System.Drawing.Point(4, 4)
        Me.LabelMissingTimeSettings_DatabaseProfile.Name = "LabelMissingTimeSettings_DatabaseProfile"
        Me.LabelMissingTimeSettings_DatabaseProfile.Size = New System.Drawing.Size(90, 20)
        Me.LabelMissingTimeSettings_DatabaseProfile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMissingTimeSettings_DatabaseProfile.TabIndex = 0
        Me.LabelMissingTimeSettings_DatabaseProfile.Text = "Database Profile:"
        '
        'ComboBoxMissingTimeSettings_DatabaseProfile
        '
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.AddInactiveItemsOnSelectedValue = False
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.AutoFindItemInDataSource = False
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.AutoSelectSingleItemDatasource = False
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.BookmarkingEnabled = False
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.DatabaseProfile
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.DisableMouseWheel = False
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.DisplayMember = "Name"
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.DisplayName = ""
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.FocusHighlightEnabled = True
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.FormattingEnabled = True
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.ItemHeight = 14
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.Location = New System.Drawing.Point(100, 4)
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.Name = "ComboBoxMissingTimeSettings_DatabaseProfile"
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.PreventEnterBeep = False
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.ReadOnly = False
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.SecurityEnabled = True
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.Size = New System.Drawing.Size(180, 20)
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.TabIndex = 1
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.ValueMember = "ConnectionString"
        Me.ComboBoxMissingTimeSettings_DatabaseProfile.WatermarkText = "Select Database Profile"
        '
        'GroupBoxMissingTimeSettings_Interval
        '
        Me.GroupBoxMissingTimeSettings_Interval.Controls.Add(Me.NumericInputMissingTimeSettings_Interval_StopAfter)
        Me.GroupBoxMissingTimeSettings_Interval.Controls.Add(Me.NumericInputMissingTimeSettings_Interval_RunEveryHours)
        Me.GroupBoxMissingTimeSettings_Interval.Controls.Add(Me.CheckBoxMissingTimeSettings_Interval_StopAfter)
        Me.GroupBoxMissingTimeSettings_Interval.Controls.Add(Me.CheckBoxMissingTimeSettings_Interval_RunAt)
        Me.GroupBoxMissingTimeSettings_Interval.Controls.Add(Me.LabelMissingTimeSettings_Interval_StopAfterHours)
        Me.GroupBoxMissingTimeSettings_Interval.Controls.Add(Me.LabelMissingTimeSettings_Interval_RunEveryHours)
        Me.GroupBoxMissingTimeSettings_Interval.Controls.Add(Me.CheckBoxMissingTimeSettings_Interval_RunEvery)
        Me.GroupBoxMissingTimeSettings_Interval.Controls.Add(Me.ComboBoxMissingTimeSettings_Interval_RunDay)
        Me.GroupBoxMissingTimeSettings_Interval.Controls.Add(Me.LabelMissingTimeSettings_Interval_RunDay)
        Me.GroupBoxMissingTimeSettings_Interval.Controls.Add(Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime)
        Me.GroupBoxMissingTimeSettings_Interval.Location = New System.Drawing.Point(4, 30)
        Me.GroupBoxMissingTimeSettings_Interval.Name = "GroupBoxMissingTimeSettings_Interval"
        Me.GroupBoxMissingTimeSettings_Interval.Size = New System.Drawing.Size(538, 80)
        Me.GroupBoxMissingTimeSettings_Interval.TabIndex = 2
        Me.GroupBoxMissingTimeSettings_Interval.Text = "Process Interval"
        '
        'NumericInputMissingTimeSettings_Interval_StopAfter
        '
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.Location = New System.Drawing.Point(377, 52)
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.Name = "NumericInputMissingTimeSettings_Interval_StopAfter"
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.Properties.DisplayFormat.FormatString = "f0"
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.Properties.EditFormat.FormatString = "f0"
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.Properties.IsFloatValue = False
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.Properties.Mask.EditMask = "f0"
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.Properties.MaxLength = 11
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.Size = New System.Drawing.Size(100, 20)
        Me.NumericInputMissingTimeSettings_Interval_StopAfter.TabIndex = 8
        '
        'NumericInputMissingTimeSettings_Interval_RunEveryHours
        '
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.Location = New System.Drawing.Point(105, 52)
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.Name = "NumericInputMissingTimeSettings_Interval_RunEveryHours"
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties.DisplayFormat.FormatString = "f0"
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties.EditFormat.FormatString = "f0"
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties.IsFloatValue = False
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties.Mask.EditMask = "f0"
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties.MaxLength = 11
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.Size = New System.Drawing.Size(100, 20)
        Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.TabIndex = 5
        '
        'CheckBoxMissingTimeSettings_Interval_StopAfter
        '
        '
        '
        '
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.CheckValue = 0
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.CheckValueChecked = 1
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.CheckValueUnchecked = 0
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.ChildControls = CType(resources.GetObject("CheckBoxMissingTimeSettings_Interval_StopAfter.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.Location = New System.Drawing.Point(277, 51)
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.Name = "CheckBoxMissingTimeSettings_Interval_StopAfter"
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.OldestSibling = Nothing
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.SecurityEnabled = True
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.SiblingControls = CType(resources.GetObject("CheckBoxMissingTimeSettings_Interval_StopAfter.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.Size = New System.Drawing.Size(70, 20)
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.TabIndex = 7
        Me.CheckBoxMissingTimeSettings_Interval_StopAfter.Text = "Stop After:"
        '
        'CheckBoxMissingTimeSettings_Interval_RunAt
        '
        '
        '
        '
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.CheckValue = 0
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.CheckValueChecked = 1
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.CheckValueUnchecked = 0
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.ChildControls = CType(resources.GetObject("CheckBoxMissingTimeSettings_Interval_RunAt.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.Location = New System.Drawing.Point(5, 25)
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.Name = "CheckBoxMissingTimeSettings_Interval_RunAt"
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.OldestSibling = Nothing
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.SecurityEnabled = True
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.SiblingControls = CType(resources.GetObject("CheckBoxMissingTimeSettings_Interval_RunAt.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.Size = New System.Drawing.Size(80, 20)
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.TabIndex = 0
        Me.CheckBoxMissingTimeSettings_Interval_RunAt.Text = "Run At"
        '
        'LabelMissingTimeSettings_Interval_StopAfterHours
        '
        Me.LabelMissingTimeSettings_Interval_StopAfterHours.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMissingTimeSettings_Interval_StopAfterHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMissingTimeSettings_Interval_StopAfterHours.Location = New System.Drawing.Point(483, 51)
        Me.LabelMissingTimeSettings_Interval_StopAfterHours.Name = "LabelMissingTimeSettings_Interval_StopAfterHours"
        Me.LabelMissingTimeSettings_Interval_StopAfterHours.Size = New System.Drawing.Size(40, 20)
        Me.LabelMissingTimeSettings_Interval_StopAfterHours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMissingTimeSettings_Interval_StopAfterHours.TabIndex = 9
        Me.LabelMissingTimeSettings_Interval_StopAfterHours.Text = "Hours"
        '
        'LabelMissingTimeSettings_Interval_RunEveryHours
        '
        Me.LabelMissingTimeSettings_Interval_RunEveryHours.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMissingTimeSettings_Interval_RunEveryHours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMissingTimeSettings_Interval_RunEveryHours.Location = New System.Drawing.Point(211, 51)
        Me.LabelMissingTimeSettings_Interval_RunEveryHours.Name = "LabelMissingTimeSettings_Interval_RunEveryHours"
        Me.LabelMissingTimeSettings_Interval_RunEveryHours.Size = New System.Drawing.Size(40, 20)
        Me.LabelMissingTimeSettings_Interval_RunEveryHours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMissingTimeSettings_Interval_RunEveryHours.TabIndex = 6
        Me.LabelMissingTimeSettings_Interval_RunEveryHours.Text = "Hours"
        '
        'CheckBoxMissingTimeSettings_Interval_RunEvery
        '
        '
        '
        '
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.CheckValue = 0
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.CheckValueChecked = 1
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.CheckValueUnchecked = 0
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.ChildControls = CType(resources.GetObject("CheckBoxMissingTimeSettings_Interval_RunEvery.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.Location = New System.Drawing.Point(5, 51)
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.Name = "CheckBoxMissingTimeSettings_Interval_RunEvery"
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.OldestSibling = Nothing
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.SecurityEnabled = True
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.SiblingControls = CType(resources.GetObject("CheckBoxMissingTimeSettings_Interval_RunEvery.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.Size = New System.Drawing.Size(80, 20)
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.TabIndex = 4
        Me.CheckBoxMissingTimeSettings_Interval_RunEvery.Text = "Run Every"
        '
        'ComboBoxMissingTimeSettings_Interval_RunDay
        '
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.AddInactiveItemsOnSelectedValue = False
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.AutoFindItemInDataSource = False
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.AutoSelectSingleItemDatasource = False
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.BookmarkingEnabled = False
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Client
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.DisableMouseWheel = False
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.DisplayMember = "Name"
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.DisplayName = ""
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.FocusHighlightEnabled = True
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.FormattingEnabled = True
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.ItemHeight = 14
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.Location = New System.Drawing.Point(377, 26)
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.Name = "ComboBoxMissingTimeSettings_Interval_RunDay"
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.PreventEnterBeep = False
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.ReadOnly = False
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.SecurityEnabled = True
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.Size = New System.Drawing.Size(100, 20)
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.TabIndex = 3
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.ValueMember = "Code"
        Me.ComboBoxMissingTimeSettings_Interval_RunDay.WatermarkText = "Select Client"
        '
        'LabelMissingTimeSettings_Interval_RunDay
        '
        Me.LabelMissingTimeSettings_Interval_RunDay.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMissingTimeSettings_Interval_RunDay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMissingTimeSettings_Interval_RunDay.Location = New System.Drawing.Point(277, 25)
        Me.LabelMissingTimeSettings_Interval_RunDay.Name = "LabelMissingTimeSettings_Interval_RunDay"
        Me.LabelMissingTimeSettings_Interval_RunDay.Size = New System.Drawing.Size(70, 20)
        Me.LabelMissingTimeSettings_Interval_RunDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMissingTimeSettings_Interval_RunDay.TabIndex = 2
        Me.LabelMissingTimeSettings_Interval_RunDay.Text = "Run Day"
        '
        'DateTimeInputMissingTimeSettings_Interval_RunAtTime
        '
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.AllowEmptyState = False
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.AutoResolveFreeTextEntries = False
        '
        '
        '
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.ButtonDropDown.Visible = True
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.ButtonFreeText.Checked = True
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.CustomFormat = ""
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.FocusHighlightEnabled = True
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.FreeTextEntryMode = True
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.IsPopupCalendarOpen = False
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.Location = New System.Drawing.Point(105, 26)
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.DisplayMonth = New Date(2011, 6, 1, 0, 0, 0, 0)
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.TodayButtonVisible = True
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.Visible = False
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.Name = "DateTimeInputMissingTimeSettings_Interval_RunAtTime"
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.ReadOnly = False
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.Size = New System.Drawing.Size(100, 20)
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.TabIndex = 1
        Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime.Value = New Date(2011, 10, 14, 12, 43, 8, 835)
        '
        'TabItemMissingTimeSettings_SettingsTab
        '
        Me.TabItemMissingTimeSettings_SettingsTab.AttachedControl = Me.TabControlPanelSettingsTab_MissingTimeSettings
        Me.TabItemMissingTimeSettings_SettingsTab.Name = "TabItemMissingTimeSettings_SettingsTab"
        Me.TabItemMissingTimeSettings_SettingsTab.Text = "Settings"
        '
        'TabControlPanelAlertsTab_Alerts
        '
        Me.TabControlPanelAlertsTab_Alerts.Controls.Add(Me.GroupBoxMissingTimeAlerts_Other)
        Me.TabControlPanelAlertsTab_Alerts.Controls.Add(Me.GroupBoxMissingTimeAlerts_Recipient)
        Me.TabControlPanelAlertsTab_Alerts.Controls.Add(Me.GroupBoxMissingTimeAlerts_Tracking)
        Me.TabControlPanelAlertsTab_Alerts.Controls.Add(Me.GroupBoxMissingTimeAlerts_Priority)
        Me.TabControlPanelAlertsTab_Alerts.Controls.Add(Me.GroupBoxMissingTimeAlerts_Range)
        Me.TabControlPanelAlertsTab_Alerts.Controls.Add(Me.LabelMissingTimeAlerts_DatabaseProfile)
        Me.TabControlPanelAlertsTab_Alerts.Controls.Add(Me.ComboBoxMissingTimeAlerts_DatabaseProfile)
        Me.TabControlPanelAlertsTab_Alerts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelAlertsTab_Alerts.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelAlertsTab_Alerts.Name = "TabControlPanelAlertsTab_Alerts"
        Me.TabControlPanelAlertsTab_Alerts.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelAlertsTab_Alerts.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelAlertsTab_Alerts.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelAlertsTab_Alerts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelAlertsTab_Alerts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelAlertsTab_Alerts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelAlertsTab_Alerts.Style.GradientAngle = 90
        Me.TabControlPanelAlertsTab_Alerts.TabIndex = 4
        Me.TabControlPanelAlertsTab_Alerts.TabItem = Me.TabItemMissingTimeSettings_AlertsTab
        '
        'GroupBoxMissingTimeAlerts_Other
        '
        Me.GroupBoxMissingTimeAlerts_Other.Controls.Add(Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate)
        Me.GroupBoxMissingTimeAlerts_Other.Controls.Add(Me.LabelMissingTimeSettings_Path)
        Me.GroupBoxMissingTimeAlerts_Other.Controls.Add(Me.TextBoxMissingTimeSettings_LogFilePath)
        Me.GroupBoxMissingTimeAlerts_Other.Controls.Add(Me.LabelMissingTimeAlerts_CustomMessage)
        Me.GroupBoxMissingTimeAlerts_Other.Controls.Add(Me.TextBoxMissingTimeAlerts_CustomMessage)
        Me.GroupBoxMissingTimeAlerts_Other.Location = New System.Drawing.Point(476, 30)
        Me.GroupBoxMissingTimeAlerts_Other.Name = "GroupBoxMissingTimeAlerts_Other"
        Me.GroupBoxMissingTimeAlerts_Other.Size = New System.Drawing.Size(346, 209)
        Me.GroupBoxMissingTimeAlerts_Other.TabIndex = 6
        Me.GroupBoxMissingTimeAlerts_Other.Text = "Other"
        '
        'CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate
        '
        '
        '
        '
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.CheckValue = 0
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.CheckValueChecked = 1
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.CheckValueUnchecked = 0
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.ChildControls = CType(resources.GetObject("CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.Location = New System.Drawing.Point(5, 51)
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.Name = "CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate"
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.OldestSibling = Nothing
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.SecurityEnabled = True
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.SiblingControls = CType(resources.GetObject("CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.Size = New System.Drawing.Size(336, 20)
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.TabIndex = 2
        Me.CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate.Text = "Include Only Days that are Late in the Recipient’s Notification"
        '
        'LabelMissingTimeSettings_Path
        '
        Me.LabelMissingTimeSettings_Path.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMissingTimeSettings_Path.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMissingTimeSettings_Path.Location = New System.Drawing.Point(5, 25)
        Me.LabelMissingTimeSettings_Path.Name = "LabelMissingTimeSettings_Path"
        Me.LabelMissingTimeSettings_Path.Size = New System.Drawing.Size(70, 20)
        Me.LabelMissingTimeSettings_Path.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMissingTimeSettings_Path.TabIndex = 0
        Me.LabelMissingTimeSettings_Path.Text = "Log File Path:"
        '
        'TextBoxMissingTimeSettings_LogFilePath
        '
        Me.TextBoxMissingTimeSettings_LogFilePath.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxMissingTimeSettings_LogFilePath.Border.Class = "TextBoxBorder"
        Me.TextBoxMissingTimeSettings_LogFilePath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxMissingTimeSettings_LogFilePath.ButtonCustom.Visible = True
        Me.TextBoxMissingTimeSettings_LogFilePath.CheckSpellingOnValidate = False
        Me.TextBoxMissingTimeSettings_LogFilePath.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
        Me.TextBoxMissingTimeSettings_LogFilePath.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxMissingTimeSettings_LogFilePath.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxMissingTimeSettings_LogFilePath.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxMissingTimeSettings_LogFilePath.FocusHighlightEnabled = True
        Me.TextBoxMissingTimeSettings_LogFilePath.ForeColor = System.Drawing.Color.Black
        Me.TextBoxMissingTimeSettings_LogFilePath.Location = New System.Drawing.Point(81, 25)
        Me.TextBoxMissingTimeSettings_LogFilePath.MaxFileSize = CType(0, Long)
        Me.TextBoxMissingTimeSettings_LogFilePath.Name = "TextBoxMissingTimeSettings_LogFilePath"
        Me.TextBoxMissingTimeSettings_LogFilePath.ShowSpellCheckCompleteMessage = True
        Me.TextBoxMissingTimeSettings_LogFilePath.Size = New System.Drawing.Size(260, 20)
        Me.TextBoxMissingTimeSettings_LogFilePath.TabIndex = 1
        Me.TextBoxMissingTimeSettings_LogFilePath.TabOnEnter = True
        '
        'LabelMissingTimeAlerts_CustomMessage
        '
        Me.LabelMissingTimeAlerts_CustomMessage.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMissingTimeAlerts_CustomMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMissingTimeAlerts_CustomMessage.Location = New System.Drawing.Point(5, 77)
        Me.LabelMissingTimeAlerts_CustomMessage.Name = "LabelMissingTimeAlerts_CustomMessage"
        Me.LabelMissingTimeAlerts_CustomMessage.Size = New System.Drawing.Size(98, 20)
        Me.LabelMissingTimeAlerts_CustomMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMissingTimeAlerts_CustomMessage.TabIndex = 3
        Me.LabelMissingTimeAlerts_CustomMessage.Text = "Custom Message"
        '
        'TextBoxMissingTimeAlerts_CustomMessage
        '
        Me.TextBoxMissingTimeAlerts_CustomMessage.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxMissingTimeAlerts_CustomMessage.Border.Class = "TextBoxBorder"
        Me.TextBoxMissingTimeAlerts_CustomMessage.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxMissingTimeAlerts_CustomMessage.CheckSpellingOnValidate = False
        Me.TextBoxMissingTimeAlerts_CustomMessage.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxMissingTimeAlerts_CustomMessage.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxMissingTimeAlerts_CustomMessage.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxMissingTimeAlerts_CustomMessage.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxMissingTimeAlerts_CustomMessage.FocusHighlightEnabled = True
        Me.TextBoxMissingTimeAlerts_CustomMessage.ForeColor = System.Drawing.Color.Black
        Me.TextBoxMissingTimeAlerts_CustomMessage.Location = New System.Drawing.Point(5, 103)
        Me.TextBoxMissingTimeAlerts_CustomMessage.MaxFileSize = CType(0, Long)
        Me.TextBoxMissingTimeAlerts_CustomMessage.MaxLength = 250
        Me.TextBoxMissingTimeAlerts_CustomMessage.Multiline = True
        Me.TextBoxMissingTimeAlerts_CustomMessage.Name = "TextBoxMissingTimeAlerts_CustomMessage"
        Me.TextBoxMissingTimeAlerts_CustomMessage.ShowSpellCheckCompleteMessage = True
        Me.TextBoxMissingTimeAlerts_CustomMessage.Size = New System.Drawing.Size(336, 101)
        Me.TextBoxMissingTimeAlerts_CustomMessage.TabIndex = 4
        Me.TextBoxMissingTimeAlerts_CustomMessage.TabOnEnter = True
        '
        'GroupBoxMissingTimeAlerts_Recipient
        '
        Me.GroupBoxMissingTimeAlerts_Recipient.Controls.Add(Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays)
        Me.GroupBoxMissingTimeAlerts_Recipient.Controls.Add(Me.LabelMissingTimeAlerts_Recipient_ITContact_GracePeriod)
        Me.GroupBoxMissingTimeAlerts_Recipient.Controls.Add(Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays)
        Me.GroupBoxMissingTimeAlerts_Recipient.Controls.Add(Me.LabelMissingTimeAlerts_Recipient_ITContact_Days)
        Me.GroupBoxMissingTimeAlerts_Recipient.Controls.Add(Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays)
        Me.GroupBoxMissingTimeAlerts_Recipient.Controls.Add(Me.LabelMissingTimeAlerts_Recipient_Supervisor_GracePeriod)
        Me.GroupBoxMissingTimeAlerts_Recipient.Controls.Add(Me.LabelMissingTimeAlerts_Recipient_Supervisor_Days)
        Me.GroupBoxMissingTimeAlerts_Recipient.Controls.Add(Me.CheckBoxMissingTimeAlerts_Recipient_ITContact)
        Me.GroupBoxMissingTimeAlerts_Recipient.Controls.Add(Me.LabelMissingTimeAlerts_Recipient_Employee_GracePeriod)
        Me.GroupBoxMissingTimeAlerts_Recipient.Controls.Add(Me.LabelMissingTimeAlerts_Recipient_Employee_Days)
        Me.GroupBoxMissingTimeAlerts_Recipient.Controls.Add(Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor)
        Me.GroupBoxMissingTimeAlerts_Recipient.Controls.Add(Me.CheckBoxMissingTimeAlerts_Recipient_Employee)
        Me.GroupBoxMissingTimeAlerts_Recipient.Controls.Add(Me.LabelMissingTimeAlerts_Recipient_ITContact)
        Me.GroupBoxMissingTimeAlerts_Recipient.Location = New System.Drawing.Point(4, 117)
        Me.GroupBoxMissingTimeAlerts_Recipient.Name = "GroupBoxMissingTimeAlerts_Recipient"
        Me.GroupBoxMissingTimeAlerts_Recipient.Size = New System.Drawing.Size(340, 122)
        Me.GroupBoxMissingTimeAlerts_Recipient.TabIndex = 4
        Me.GroupBoxMissingTimeAlerts_Recipient.Text = "Recipient"
        '
        'NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays
        '
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Location = New System.Drawing.Point(189, 77)
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Name = "NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays"
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties.DisplayFormat.FormatString = "f0"
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties.EditFormat.FormatString = "f0"
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties.IsFloatValue = False
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties.Mask.EditMask = "f0"
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties.MaxLength = 11
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Size = New System.Drawing.Size(100, 20)
        Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.TabIndex = 11
        '
        'LabelMissingTimeAlerts_Recipient_ITContact_GracePeriod
        '
        Me.LabelMissingTimeAlerts_Recipient_ITContact_GracePeriod.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMissingTimeAlerts_Recipient_ITContact_GracePeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMissingTimeAlerts_Recipient_ITContact_GracePeriod.Location = New System.Drawing.Point(113, 77)
        Me.LabelMissingTimeAlerts_Recipient_ITContact_GracePeriod.Name = "LabelMissingTimeAlerts_Recipient_ITContact_GracePeriod"
        Me.LabelMissingTimeAlerts_Recipient_ITContact_GracePeriod.Size = New System.Drawing.Size(70, 20)
        Me.LabelMissingTimeAlerts_Recipient_ITContact_GracePeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMissingTimeAlerts_Recipient_ITContact_GracePeriod.TabIndex = 10
        Me.LabelMissingTimeAlerts_Recipient_ITContact_GracePeriod.Text = "Grace Period"
        '
        'NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays
        '
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Location = New System.Drawing.Point(189, 51)
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Name = "NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays"
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties.DisplayFormat.FormatString = "f0"
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties.EditFormat.FormatString = "f0"
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties.IsFloatValue = False
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties.Mask.EditMask = "f0"
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties.MaxLength = 11
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Size = New System.Drawing.Size(100, 20)
        Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.TabIndex = 6
        '
        'LabelMissingTimeAlerts_Recipient_ITContact_Days
        '
        Me.LabelMissingTimeAlerts_Recipient_ITContact_Days.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMissingTimeAlerts_Recipient_ITContact_Days.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMissingTimeAlerts_Recipient_ITContact_Days.Location = New System.Drawing.Point(295, 77)
        Me.LabelMissingTimeAlerts_Recipient_ITContact_Days.Name = "LabelMissingTimeAlerts_Recipient_ITContact_Days"
        Me.LabelMissingTimeAlerts_Recipient_ITContact_Days.Size = New System.Drawing.Size(30, 20)
        Me.LabelMissingTimeAlerts_Recipient_ITContact_Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMissingTimeAlerts_Recipient_ITContact_Days.TabIndex = 12
        Me.LabelMissingTimeAlerts_Recipient_ITContact_Days.Text = "Days"
        '
        'NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays
        '
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Location = New System.Drawing.Point(189, 25)
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Name = "NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays"
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties.DisplayFormat.FormatString = "f0"
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties.EditFormat.FormatString = "f0"
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties.IsFloatValue = False
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties.Mask.EditMask = "f0"
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties.MaxLength = 11
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Size = New System.Drawing.Size(100, 20)
        Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.TabIndex = 2
        '
        'LabelMissingTimeAlerts_Recipient_Supervisor_GracePeriod
        '
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_GracePeriod.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_GracePeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_GracePeriod.Location = New System.Drawing.Point(113, 51)
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_GracePeriod.Name = "LabelMissingTimeAlerts_Recipient_Supervisor_GracePeriod"
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_GracePeriod.Size = New System.Drawing.Size(70, 20)
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_GracePeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_GracePeriod.TabIndex = 5
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_GracePeriod.Text = "Grace Period"
        '
        'LabelMissingTimeAlerts_Recipient_Supervisor_Days
        '
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_Days.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_Days.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_Days.Location = New System.Drawing.Point(295, 51)
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_Days.Name = "LabelMissingTimeAlerts_Recipient_Supervisor_Days"
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_Days.Size = New System.Drawing.Size(30, 20)
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_Days.TabIndex = 7
        Me.LabelMissingTimeAlerts_Recipient_Supervisor_Days.Text = "Days"
        '
        'CheckBoxMissingTimeAlerts_Recipient_ITContact
        '
        '
        '
        '
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact.CheckValue = 0
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact.CheckValueChecked = 1
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact.CheckValueUnchecked = 0
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact.ChildControls = CType(resources.GetObject("CheckBoxMissingTimeAlerts_Recipient_ITContact.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact.Location = New System.Drawing.Point(5, 77)
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact.Name = "CheckBoxMissingTimeAlerts_Recipient_ITContact"
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact.OldestSibling = Nothing
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact.SecurityEnabled = True
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact.SiblingControls = CType(resources.GetObject("CheckBoxMissingTimeAlerts_Recipient_ITContact.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact.Size = New System.Drawing.Size(75, 20)
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact.TabIndex = 8
        Me.CheckBoxMissingTimeAlerts_Recipient_ITContact.Text = "IT Contact"
        '
        'LabelMissingTimeAlerts_Recipient_Employee_GracePeriod
        '
        Me.LabelMissingTimeAlerts_Recipient_Employee_GracePeriod.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMissingTimeAlerts_Recipient_Employee_GracePeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMissingTimeAlerts_Recipient_Employee_GracePeriod.Location = New System.Drawing.Point(113, 25)
        Me.LabelMissingTimeAlerts_Recipient_Employee_GracePeriod.Name = "LabelMissingTimeAlerts_Recipient_Employee_GracePeriod"
        Me.LabelMissingTimeAlerts_Recipient_Employee_GracePeriod.Size = New System.Drawing.Size(70, 20)
        Me.LabelMissingTimeAlerts_Recipient_Employee_GracePeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMissingTimeAlerts_Recipient_Employee_GracePeriod.TabIndex = 1
        Me.LabelMissingTimeAlerts_Recipient_Employee_GracePeriod.Text = "Grace Period"
        '
        'LabelMissingTimeAlerts_Recipient_Employee_Days
        '
        Me.LabelMissingTimeAlerts_Recipient_Employee_Days.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMissingTimeAlerts_Recipient_Employee_Days.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMissingTimeAlerts_Recipient_Employee_Days.Location = New System.Drawing.Point(295, 25)
        Me.LabelMissingTimeAlerts_Recipient_Employee_Days.Name = "LabelMissingTimeAlerts_Recipient_Employee_Days"
        Me.LabelMissingTimeAlerts_Recipient_Employee_Days.Size = New System.Drawing.Size(30, 20)
        Me.LabelMissingTimeAlerts_Recipient_Employee_Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMissingTimeAlerts_Recipient_Employee_Days.TabIndex = 3
        Me.LabelMissingTimeAlerts_Recipient_Employee_Days.Text = "Days"
        '
        'CheckBoxMissingTimeAlerts_Recipient_Supervisor
        '
        '
        '
        '
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor.CheckValue = 0
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor.CheckValueChecked = 1
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor.CheckValueUnchecked = 0
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor.ChildControls = CType(resources.GetObject("CheckBoxMissingTimeAlerts_Recipient_Supervisor.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor.Location = New System.Drawing.Point(5, 51)
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor.Name = "CheckBoxMissingTimeAlerts_Recipient_Supervisor"
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor.OldestSibling = Nothing
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor.SecurityEnabled = True
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor.SiblingControls = CType(resources.GetObject("CheckBoxMissingTimeAlerts_Recipient_Supervisor.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor.Size = New System.Drawing.Size(75, 20)
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor.TabIndex = 4
        Me.CheckBoxMissingTimeAlerts_Recipient_Supervisor.Text = "Supervisor"
        '
        'CheckBoxMissingTimeAlerts_Recipient_Employee
        '
        '
        '
        '
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee.CheckValue = 0
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee.CheckValueChecked = 1
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee.CheckValueUnchecked = 0
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee.ChildControls = CType(resources.GetObject("CheckBoxMissingTimeAlerts_Recipient_Employee.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee.Location = New System.Drawing.Point(5, 25)
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee.Name = "CheckBoxMissingTimeAlerts_Recipient_Employee"
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee.OldestSibling = Nothing
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee.SecurityEnabled = True
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee.SiblingControls = CType(resources.GetObject("CheckBoxMissingTimeAlerts_Recipient_Employee.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee.Size = New System.Drawing.Size(75, 20)
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee.TabIndex = 0
        Me.CheckBoxMissingTimeAlerts_Recipient_Employee.Text = "Employee"
        '
        'LabelMissingTimeAlerts_Recipient_ITContact
        '
        Me.LabelMissingTimeAlerts_Recipient_ITContact.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMissingTimeAlerts_Recipient_ITContact.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMissingTimeAlerts_Recipient_ITContact.Location = New System.Drawing.Point(25, 77)
        Me.LabelMissingTimeAlerts_Recipient_ITContact.Name = "LabelMissingTimeAlerts_Recipient_ITContact"
        Me.LabelMissingTimeAlerts_Recipient_ITContact.Size = New System.Drawing.Size(75, 20)
        Me.LabelMissingTimeAlerts_Recipient_ITContact.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMissingTimeAlerts_Recipient_ITContact.TabIndex = 9
        Me.LabelMissingTimeAlerts_Recipient_ITContact.Text = "IT Contact"
        '
        'GroupBoxMissingTimeAlerts_Tracking
        '
        Me.GroupBoxMissingTimeAlerts_Tracking.Controls.Add(Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends)
        Me.GroupBoxMissingTimeAlerts_Tracking.Controls.Add(Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets)
        Me.GroupBoxMissingTimeAlerts_Tracking.Location = New System.Drawing.Point(240, 30)
        Me.GroupBoxMissingTimeAlerts_Tracking.Name = "GroupBoxMissingTimeAlerts_Tracking"
        Me.GroupBoxMissingTimeAlerts_Tracking.Size = New System.Drawing.Size(230, 81)
        Me.GroupBoxMissingTimeAlerts_Tracking.TabIndex = 3
        Me.GroupBoxMissingTimeAlerts_Tracking.Text = "Tracking"
        '
        'CheckBoxMissingTimeSettings_Tracking_DontCountWeekends
        '
        '
        '
        '
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.CheckValue = 0
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.CheckValueChecked = 1
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.CheckValueUnchecked = 0
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.ChildControls = CType(resources.GetObject("CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.Location = New System.Drawing.Point(5, 25)
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.Name = "CheckBoxMissingTimeSettings_Tracking_DontCountWeekends"
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.OldestSibling = Nothing
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.SecurityEnabled = True
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.SiblingControls = CType(resources.GetObject("CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.Size = New System.Drawing.Size(210, 20)
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.TabIndex = 0
        Me.CheckBoxMissingTimeSettings_Tracking_DontCountWeekends.Text = "Don't Count Weekends and Holidays"
        '
        'CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets
        '
        '
        '
        '
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.CheckValue = 0
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.CheckValueChecked = 1
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.CheckValueUnchecked = 0
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.ChildControls = CType(resources.GetObject("CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.Location = New System.Drawing.Point(5, 51)
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.Name = "CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets"
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.OldestSibling = Nothing
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.SecurityEnabled = True
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.SiblingControls = CType(resources.GetObject("CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.Size = New System.Drawing.Size(190, 20)
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.TabIndex = 1
        Me.CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets.Text = "Missing Timesheets Only"
        '
        'GroupBoxMissingTimeAlerts_Priority
        '
        Me.GroupBoxMissingTimeAlerts_Priority.Controls.Add(Me.RadioButtonMissingTimeSettings_Priority_Low)
        Me.GroupBoxMissingTimeAlerts_Priority.Controls.Add(Me.RadioButtonMissingTimeSettings_Priority_Medium)
        Me.GroupBoxMissingTimeAlerts_Priority.Controls.Add(Me.RadioButtonMissingTimeSettings_Priority_High)
        Me.GroupBoxMissingTimeAlerts_Priority.Location = New System.Drawing.Point(350, 117)
        Me.GroupBoxMissingTimeAlerts_Priority.Name = "GroupBoxMissingTimeAlerts_Priority"
        Me.GroupBoxMissingTimeAlerts_Priority.Size = New System.Drawing.Size(120, 122)
        Me.GroupBoxMissingTimeAlerts_Priority.TabIndex = 5
        Me.GroupBoxMissingTimeAlerts_Priority.Text = "Priority"
        '
        'RadioButtonMissingTimeSettings_Priority_Low
        '
        Me.RadioButtonMissingTimeSettings_Priority_Low.AutoSize = True
        Me.RadioButtonMissingTimeSettings_Priority_Low.Location = New System.Drawing.Point(5, 71)
        Me.RadioButtonMissingTimeSettings_Priority_Low.Name = "RadioButtonMissingTimeSettings_Priority_Low"
        Me.RadioButtonMissingTimeSettings_Priority_Low.Size = New System.Drawing.Size(45, 17)
        Me.RadioButtonMissingTimeSettings_Priority_Low.TabIndex = 2
        Me.RadioButtonMissingTimeSettings_Priority_Low.TabStop = True
        Me.RadioButtonMissingTimeSettings_Priority_Low.Text = "Low"
        Me.RadioButtonMissingTimeSettings_Priority_Low.UseVisualStyleBackColor = True
        '
        'RadioButtonMissingTimeSettings_Priority_Medium
        '
        Me.RadioButtonMissingTimeSettings_Priority_Medium.AutoSize = True
        Me.RadioButtonMissingTimeSettings_Priority_Medium.Location = New System.Drawing.Point(5, 48)
        Me.RadioButtonMissingTimeSettings_Priority_Medium.Name = "RadioButtonMissingTimeSettings_Priority_Medium"
        Me.RadioButtonMissingTimeSettings_Priority_Medium.Size = New System.Drawing.Size(62, 17)
        Me.RadioButtonMissingTimeSettings_Priority_Medium.TabIndex = 1
        Me.RadioButtonMissingTimeSettings_Priority_Medium.TabStop = True
        Me.RadioButtonMissingTimeSettings_Priority_Medium.Text = "Medium"
        Me.RadioButtonMissingTimeSettings_Priority_Medium.UseVisualStyleBackColor = True
        '
        'RadioButtonMissingTimeSettings_Priority_High
        '
        Me.RadioButtonMissingTimeSettings_Priority_High.AutoSize = True
        Me.RadioButtonMissingTimeSettings_Priority_High.Location = New System.Drawing.Point(5, 25)
        Me.RadioButtonMissingTimeSettings_Priority_High.Name = "RadioButtonMissingTimeSettings_Priority_High"
        Me.RadioButtonMissingTimeSettings_Priority_High.Size = New System.Drawing.Size(47, 17)
        Me.RadioButtonMissingTimeSettings_Priority_High.TabIndex = 0
        Me.RadioButtonMissingTimeSettings_Priority_High.TabStop = True
        Me.RadioButtonMissingTimeSettings_Priority_High.Text = "High"
        Me.RadioButtonMissingTimeSettings_Priority_High.UseVisualStyleBackColor = True
        '
        'GroupBoxMissingTimeAlerts_Range
        '
        Me.GroupBoxMissingTimeAlerts_Range.Controls.Add(Me.NumericInputMissingTimeSettings_Range_DaysToCheck)
        Me.GroupBoxMissingTimeAlerts_Range.Controls.Add(Me.RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod)
        Me.GroupBoxMissingTimeAlerts_Range.Controls.Add(Me.RadioButtonMissingTimeSettings_Range_DaysToCheck)
        Me.GroupBoxMissingTimeAlerts_Range.Location = New System.Drawing.Point(4, 30)
        Me.GroupBoxMissingTimeAlerts_Range.Name = "GroupBoxMissingTimeAlerts_Range"
        Me.GroupBoxMissingTimeAlerts_Range.Size = New System.Drawing.Size(230, 81)
        Me.GroupBoxMissingTimeAlerts_Range.TabIndex = 2
        Me.GroupBoxMissingTimeAlerts_Range.Text = "Range"
        '
        'NumericInputMissingTimeSettings_Range_DaysToCheck
        '
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.Location = New System.Drawing.Point(106, 24)
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.Name = "NumericInputMissingTimeSettings_Range_DaysToCheck"
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.Properties.DisplayFormat.FormatString = "f0"
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.Properties.EditFormat.FormatString = "f0"
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.Properties.IsFloatValue = False
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.Properties.Mask.EditMask = "f0"
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.Properties.MaxLength = 11
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.Size = New System.Drawing.Size(100, 20)
        Me.NumericInputMissingTimeSettings_Range_DaysToCheck.TabIndex = 1
        '
        'RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod
        '
        Me.RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod.AutoSize = True
        Me.RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod.Location = New System.Drawing.Point(5, 54)
        Me.RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod.Name = "RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod"
        Me.RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod.Size = New System.Drawing.Size(130, 17)
        Me.RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod.TabIndex = 2
        Me.RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod.TabStop = True
        Me.RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod.Text = "Current Posting Period"
        Me.RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod.UseVisualStyleBackColor = True
        '
        'RadioButtonMissingTimeSettings_Range_DaysToCheck
        '
        Me.RadioButtonMissingTimeSettings_Range_DaysToCheck.AutoSize = True
        Me.RadioButtonMissingTimeSettings_Range_DaysToCheck.Location = New System.Drawing.Point(5, 28)
        Me.RadioButtonMissingTimeSettings_Range_DaysToCheck.Name = "RadioButtonMissingTimeSettings_Range_DaysToCheck"
        Me.RadioButtonMissingTimeSettings_Range_DaysToCheck.Size = New System.Drawing.Size(95, 17)
        Me.RadioButtonMissingTimeSettings_Range_DaysToCheck.TabIndex = 0
        Me.RadioButtonMissingTimeSettings_Range_DaysToCheck.TabStop = True
        Me.RadioButtonMissingTimeSettings_Range_DaysToCheck.Text = "Days to Check"
        Me.RadioButtonMissingTimeSettings_Range_DaysToCheck.UseVisualStyleBackColor = True
        '
        'LabelMissingTimeAlerts_DatabaseProfile
        '
        Me.LabelMissingTimeAlerts_DatabaseProfile.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMissingTimeAlerts_DatabaseProfile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMissingTimeAlerts_DatabaseProfile.Location = New System.Drawing.Point(4, 4)
        Me.LabelMissingTimeAlerts_DatabaseProfile.Name = "LabelMissingTimeAlerts_DatabaseProfile"
        Me.LabelMissingTimeAlerts_DatabaseProfile.Size = New System.Drawing.Size(90, 20)
        Me.LabelMissingTimeAlerts_DatabaseProfile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMissingTimeAlerts_DatabaseProfile.TabIndex = 0
        Me.LabelMissingTimeAlerts_DatabaseProfile.Text = "Database Profile:"
        '
        'ComboBoxMissingTimeAlerts_DatabaseProfile
        '
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.AddInactiveItemsOnSelectedValue = False
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.AutoFindItemInDataSource = False
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.AutoSelectSingleItemDatasource = False
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.BookmarkingEnabled = False
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.DatabaseProfile
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.DisableMouseWheel = False
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.DisplayMember = "Name"
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.DisplayName = ""
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.FocusHighlightEnabled = True
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.FormattingEnabled = True
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.ItemHeight = 14
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.Location = New System.Drawing.Point(100, 4)
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.Name = "ComboBoxMissingTimeAlerts_DatabaseProfile"
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.PreventEnterBeep = False
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.ReadOnly = False
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.SecurityEnabled = True
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.Size = New System.Drawing.Size(180, 20)
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.TabIndex = 1
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.ValueMember = "ConnectionString"
        Me.ComboBoxMissingTimeAlerts_DatabaseProfile.WatermarkText = "Select Database Profile"
        '
        'TabItemMissingTimeSettings_AlertsTab
        '
        Me.TabItemMissingTimeSettings_AlertsTab.AttachedControl = Me.TabControlPanelAlertsTab_Alerts
        Me.TabItemMissingTimeSettings_AlertsTab.Name = "TabItemMissingTimeSettings_AlertsTab"
        Me.TabItemMissingTimeSettings_AlertsTab.Text = "Alerts"
        '
        'TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles
        '
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.ButtonMissingTimeDatabaseProfiles_Remove)
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.ButtonMissingTimeDatabaseProfiles_Select)
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.ButtonMissingTimeDatabaseProfiles_ProcessNow)
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.ButtonMissingTimeDatabaseProfiles_Edit)
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.DataGridViewMissingTimeDatabaseProfiles_Databases)
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.Name = "TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles"
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.Size = New System.Drawing.Size(826, 272)
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.Style.GradientAngle = 90
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.TabIndex = 2
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.TabItem = Me.TabItemMissingTimeSettings_DatabaseProfilesTab
        '
        'ButtonMissingTimeDatabaseProfiles_Remove
        '
        Me.ButtonMissingTimeDatabaseProfiles_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonMissingTimeDatabaseProfiles_Remove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonMissingTimeDatabaseProfiles_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonMissingTimeDatabaseProfiles_Remove.Location = New System.Drawing.Point(747, 248)
        Me.ButtonMissingTimeDatabaseProfiles_Remove.Name = "ButtonMissingTimeDatabaseProfiles_Remove"
        Me.ButtonMissingTimeDatabaseProfiles_Remove.SecurityEnabled = True
        Me.ButtonMissingTimeDatabaseProfiles_Remove.Size = New System.Drawing.Size(75, 20)
        Me.ButtonMissingTimeDatabaseProfiles_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonMissingTimeDatabaseProfiles_Remove.TabIndex = 9
        Me.ButtonMissingTimeDatabaseProfiles_Remove.Text = "Remove"
        '
        'ButtonMissingTimeDatabaseProfiles_Select
        '
        Me.ButtonMissingTimeDatabaseProfiles_Select.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonMissingTimeDatabaseProfiles_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonMissingTimeDatabaseProfiles_Select.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonMissingTimeDatabaseProfiles_Select.Location = New System.Drawing.Point(585, 248)
        Me.ButtonMissingTimeDatabaseProfiles_Select.Name = "ButtonMissingTimeDatabaseProfiles_Select"
        Me.ButtonMissingTimeDatabaseProfiles_Select.SecurityEnabled = True
        Me.ButtonMissingTimeDatabaseProfiles_Select.Size = New System.Drawing.Size(75, 20)
        Me.ButtonMissingTimeDatabaseProfiles_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonMissingTimeDatabaseProfiles_Select.TabIndex = 7
        Me.ButtonMissingTimeDatabaseProfiles_Select.Text = "Select"
        '
        'ButtonMissingTimeDatabaseProfiles_ProcessNow
        '
        Me.ButtonMissingTimeDatabaseProfiles_ProcessNow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonMissingTimeDatabaseProfiles_ProcessNow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonMissingTimeDatabaseProfiles_ProcessNow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonMissingTimeDatabaseProfiles_ProcessNow.Location = New System.Drawing.Point(4, 248)
        Me.ButtonMissingTimeDatabaseProfiles_ProcessNow.Name = "ButtonMissingTimeDatabaseProfiles_ProcessNow"
        Me.ButtonMissingTimeDatabaseProfiles_ProcessNow.SecurityEnabled = True
        Me.ButtonMissingTimeDatabaseProfiles_ProcessNow.Size = New System.Drawing.Size(75, 20)
        Me.ButtonMissingTimeDatabaseProfiles_ProcessNow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonMissingTimeDatabaseProfiles_ProcessNow.TabIndex = 6
        Me.ButtonMissingTimeDatabaseProfiles_ProcessNow.Text = "Process Now"
        '
        'ButtonMissingTimeDatabaseProfiles_Edit
        '
        Me.ButtonMissingTimeDatabaseProfiles_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonMissingTimeDatabaseProfiles_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonMissingTimeDatabaseProfiles_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonMissingTimeDatabaseProfiles_Edit.Location = New System.Drawing.Point(666, 248)
        Me.ButtonMissingTimeDatabaseProfiles_Edit.Name = "ButtonMissingTimeDatabaseProfiles_Edit"
        Me.ButtonMissingTimeDatabaseProfiles_Edit.SecurityEnabled = True
        Me.ButtonMissingTimeDatabaseProfiles_Edit.Size = New System.Drawing.Size(75, 20)
        Me.ButtonMissingTimeDatabaseProfiles_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonMissingTimeDatabaseProfiles_Edit.TabIndex = 9
        Me.ButtonMissingTimeDatabaseProfiles_Edit.Text = "Edit"
        '
        'DataGridViewMissingTimeDatabaseProfiles_Databases
        '
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.AllowSelectGroupHeaderRow = True
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.AlwaysForceShowRowSelectionOnUserInput = True
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.AutoFilterLookupColumns = False
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.AutoloadRepositoryDatasource = True
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.DatabaseProfile
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.ItemDescription = "Item(s)"
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.Location = New System.Drawing.Point(4, 4)
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.MultiSelect = True
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.Name = "DataGridViewMissingTimeDatabaseProfiles_Databases"
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.RunStandardValidation = True
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.ShowSelectDeselectAllButtons = False
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.Size = New System.Drawing.Size(818, 238)
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.TabIndex = 5
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.UseEmbeddedNavigator = False
        Me.DataGridViewMissingTimeDatabaseProfiles_Databases.ViewCaptionHeight = -1
        '
        'TabItemMissingTimeSettings_DatabaseProfilesTab
        '
        Me.TabItemMissingTimeSettings_DatabaseProfilesTab.AttachedControl = Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles
        Me.TabItemMissingTimeSettings_DatabaseProfilesTab.Name = "TabItemMissingTimeSettings_DatabaseProfilesTab"
        Me.TabItemMissingTimeSettings_DatabaseProfilesTab.Text = "Database Profiles"
        '
        'TabControlPanelLogTab_MissingTimeLog
        '
        Me.TabControlPanelLogTab_MissingTimeLog.Controls.Add(Me.TextBoxMissingTimeLog_Log)
        Me.TabControlPanelLogTab_MissingTimeLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelLogTab_MissingTimeLog.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelLogTab_MissingTimeLog.Name = "TabControlPanelLogTab_MissingTimeLog"
        Me.TabControlPanelLogTab_MissingTimeLog.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelLogTab_MissingTimeLog.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelLogTab_MissingTimeLog.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelLogTab_MissingTimeLog.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelLogTab_MissingTimeLog.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelLogTab_MissingTimeLog.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelLogTab_MissingTimeLog.Style.GradientAngle = 90
        Me.TabControlPanelLogTab_MissingTimeLog.TabIndex = 3
        Me.TabControlPanelLogTab_MissingTimeLog.TabItem = Me.TabItemMissingTimeSettings_LogTab
        '
        'TextBoxMissingTimeLog_Log
        '
        Me.TextBoxMissingTimeLog_Log.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxMissingTimeLog_Log.Border.Class = "TextBoxBorder"
        Me.TextBoxMissingTimeLog_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxMissingTimeLog_Log.CheckSpellingOnValidate = False
        Me.TextBoxMissingTimeLog_Log.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxMissingTimeLog_Log.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxMissingTimeLog_Log.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxMissingTimeLog_Log.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxMissingTimeLog_Log.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxMissingTimeLog_Log.FocusHighlightEnabled = True
        Me.TextBoxMissingTimeLog_Log.ForeColor = System.Drawing.Color.Black
        Me.TextBoxMissingTimeLog_Log.Location = New System.Drawing.Point(1, 1)
        Me.TextBoxMissingTimeLog_Log.MaxFileSize = CType(0, Long)
        Me.TextBoxMissingTimeLog_Log.Multiline = True
        Me.TextBoxMissingTimeLog_Log.Name = "TextBoxMissingTimeLog_Log"
        Me.TextBoxMissingTimeLog_Log.ReadOnly = True
        Me.TextBoxMissingTimeLog_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxMissingTimeLog_Log.ShowSpellCheckCompleteMessage = True
        Me.TextBoxMissingTimeLog_Log.Size = New System.Drawing.Size(824, 265)
        Me.TextBoxMissingTimeLog_Log.TabIndex = 7
        Me.TextBoxMissingTimeLog_Log.TabOnEnter = True
        '
        'TabItemMissingTimeSettings_LogTab
        '
        Me.TabItemMissingTimeSettings_LogTab.AttachedControl = Me.TabControlPanelLogTab_MissingTimeLog
        Me.TabItemMissingTimeSettings_LogTab.Name = "TabItemMissingTimeSettings_LogTab"
        Me.TabItemMissingTimeSettings_LogTab.Text = "Log"
        '
        'CheckBoxMissingTime_AutoStart
        '
        Me.CheckBoxMissingTime_AutoStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxMissingTime_AutoStart.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.CheckBoxMissingTime_AutoStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxMissingTime_AutoStart.CheckValue = 0
        Me.CheckBoxMissingTime_AutoStart.CheckValueChecked = 1
        Me.CheckBoxMissingTime_AutoStart.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxMissingTime_AutoStart.CheckValueUnchecked = 0
        Me.CheckBoxMissingTime_AutoStart.ChildControls = CType(resources.GetObject("CheckBoxMissingTime_AutoStart.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTime_AutoStart.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxMissingTime_AutoStart.Location = New System.Drawing.Point(677, 4)
        Me.CheckBoxMissingTime_AutoStart.Name = "CheckBoxMissingTime_AutoStart"
        Me.CheckBoxMissingTime_AutoStart.OldestSibling = Nothing
        Me.CheckBoxMissingTime_AutoStart.SecurityEnabled = True
        Me.CheckBoxMissingTime_AutoStart.SiblingControls = CType(resources.GetObject("CheckBoxMissingTime_AutoStart.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxMissingTime_AutoStart.Size = New System.Drawing.Size(80, 20)
        Me.CheckBoxMissingTime_AutoStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxMissingTime_AutoStart.TabIndex = 15
        Me.CheckBoxMissingTime_AutoStart.Text = "Auto Start"
        '
        'ButtonMissingTime_Stop
        '
        Me.ButtonMissingTime_Stop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonMissingTime_Stop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonMissingTime_Stop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonMissingTime_Stop.Location = New System.Drawing.Point(763, 4)
        Me.ButtonMissingTime_Stop.Name = "ButtonMissingTime_Stop"
        Me.ButtonMissingTime_Stop.SecurityEnabled = True
        Me.ButtonMissingTime_Stop.Size = New System.Drawing.Size(75, 20)
        Me.ButtonMissingTime_Stop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonMissingTime_Stop.TabIndex = 14
        Me.ButtonMissingTime_Stop.Text = "Stop"
        Me.ButtonMissingTime_Stop.Visible = False
        '
        'LabelMissingTime_StatusDescription
        '
        Me.LabelMissingTime_StatusDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelMissingTime_StatusDescription.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMissingTime_StatusDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMissingTime_StatusDescription.Location = New System.Drawing.Point(58, 4)
        Me.LabelMissingTime_StatusDescription.Name = "LabelMissingTime_StatusDescription"
        Me.LabelMissingTime_StatusDescription.Size = New System.Drawing.Size(613, 20)
        Me.LabelMissingTime_StatusDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMissingTime_StatusDescription.TabIndex = 12
        Me.LabelMissingTime_StatusDescription.Text = "Stopped..."
        '
        'LabelMissingTime_Status
        '
        Me.LabelMissingTime_Status.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelMissingTime_Status.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelMissingTime_Status.Location = New System.Drawing.Point(12, 4)
        Me.LabelMissingTime_Status.Name = "LabelMissingTime_Status"
        Me.LabelMissingTime_Status.Size = New System.Drawing.Size(40, 20)
        Me.LabelMissingTime_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelMissingTime_Status.TabIndex = 11
        Me.LabelMissingTime_Status.Text = "Status:"
        '
        'ButtonMissingTime_Start
        '
        Me.ButtonMissingTime_Start.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonMissingTime_Start.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonMissingTime_Start.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonMissingTime_Start.Location = New System.Drawing.Point(763, 4)
        Me.ButtonMissingTime_Start.Name = "ButtonMissingTime_Start"
        Me.ButtonMissingTime_Start.SecurityEnabled = True
        Me.ButtonMissingTime_Start.Size = New System.Drawing.Size(75, 20)
        Me.ButtonMissingTime_Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonMissingTime_Start.TabIndex = 13
        Me.ButtonMissingTime_Start.Text = "Start"
        '
        'TabItemServices_MissingTimeTab
        '
        Me.TabItemServices_MissingTimeTab.AttachedControl = Me.TabControlPanelMissingTimeTab_MissingTime
        Me.TabItemServices_MissingTimeTab.Name = "TabItemServices_MissingTimeTab"
        Me.TabItemServices_MissingTimeTab.Text = "Missing Time"
        '
        'TabControlPanelContractTab_Contract
        '
        Me.TabControlPanelContractTab_Contract.Controls.Add(Me.CheckBoxContract_AutoStart)
        Me.TabControlPanelContractTab_Contract.Controls.Add(Me.TabControlContract_ContractSettings)
        Me.TabControlPanelContractTab_Contract.Controls.Add(Me.LabelContract_StatusDescription)
        Me.TabControlPanelContractTab_Contract.Controls.Add(Me.LabelContract_Status)
        Me.TabControlPanelContractTab_Contract.Controls.Add(Me.ButtonContract_Start)
        Me.TabControlPanelContractTab_Contract.Controls.Add(Me.ButtonContract_Stop)
        Me.TabControlPanelContractTab_Contract.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelContractTab_Contract.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelContractTab_Contract.Name = "TabControlPanelContractTab_Contract"
        Me.TabControlPanelContractTab_Contract.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelContractTab_Contract.Size = New System.Drawing.Size(850, 336)
        Me.TabControlPanelContractTab_Contract.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelContractTab_Contract.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelContractTab_Contract.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelContractTab_Contract.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelContractTab_Contract.Style.GradientAngle = 90
        Me.TabControlPanelContractTab_Contract.TabIndex = 10
        Me.TabControlPanelContractTab_Contract.TabItem = Me.TabItemServices_ContractTab
        '
        'CheckBoxContract_AutoStart
        '
        Me.CheckBoxContract_AutoStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxContract_AutoStart.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.CheckBoxContract_AutoStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxContract_AutoStart.CheckValue = 0
        Me.CheckBoxContract_AutoStart.CheckValueChecked = 1
        Me.CheckBoxContract_AutoStart.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxContract_AutoStart.CheckValueUnchecked = 0
        Me.CheckBoxContract_AutoStart.ChildControls = CType(resources.GetObject("CheckBoxContract_AutoStart.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxContract_AutoStart.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxContract_AutoStart.Location = New System.Drawing.Point(677, 4)
        Me.CheckBoxContract_AutoStart.Name = "CheckBoxContract_AutoStart"
        Me.CheckBoxContract_AutoStart.OldestSibling = Nothing
        Me.CheckBoxContract_AutoStart.SecurityEnabled = True
        Me.CheckBoxContract_AutoStart.SiblingControls = CType(resources.GetObject("CheckBoxContract_AutoStart.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxContract_AutoStart.Size = New System.Drawing.Size(80, 20)
        Me.CheckBoxContract_AutoStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxContract_AutoStart.TabIndex = 2
        Me.CheckBoxContract_AutoStart.Text = "Auto Start"
        '
        'TabControlContract_ContractSettings
        '
        Me.TabControlContract_ContractSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlContract_ContractSettings.BackColor = System.Drawing.Color.White
        Me.TabControlContract_ContractSettings.CanReorderTabs = False
        Me.TabControlContract_ContractSettings.Controls.Add(Me.TabControlPanelContractSettingsTab_ContractSettings)
        Me.TabControlContract_ContractSettings.Controls.Add(Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles)
        Me.TabControlContract_ContractSettings.Controls.Add(Me.TabControlContractLogTab_ContractLog)
        Me.TabControlContract_ContractSettings.ForeColor = System.Drawing.Color.Black
        Me.TabControlContract_ContractSettings.Location = New System.Drawing.Point(12, 30)
        Me.TabControlContract_ContractSettings.Name = "TabControlContract_ContractSettings"
        Me.TabControlContract_ContractSettings.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControlContract_ContractSettings.SelectedTabIndex = 0
        Me.TabControlContract_ContractSettings.Size = New System.Drawing.Size(826, 294)
        Me.TabControlContract_ContractSettings.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControlContract_ContractSettings.TabIndex = 4
        Me.TabControlContract_ContractSettings.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControlContract_ContractSettings.Tabs.Add(Me.TabItemContractSettings_ContractSettingsTab)
        Me.TabControlContract_ContractSettings.Tabs.Add(Me.TabItemContractSettings_ContractDatabaseProfilesTab)
        Me.TabControlContract_ContractSettings.Tabs.Add(Me.TabItemContractSettings_ContractLogTab)
        '
        'TabControlPanelContractSettingsTab_ContractSettings
        '
        Me.TabControlPanelContractSettingsTab_ContractSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPanelContractSettingsTab_ContractSettings.Controls.Add(Me.GroupBoxContractSettings_Notifications)
        Me.TabControlPanelContractSettingsTab_ContractSettings.Controls.Add(Me.LabelContractAlertSettings_RunAt)
        Me.TabControlPanelContractSettingsTab_ContractSettings.Controls.Add(Me.DateTimeInputContractAlertSettings_RunAt)
        Me.TabControlPanelContractSettingsTab_ContractSettings.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelContractSettingsTab_ContractSettings.Name = "TabControlPanelContractSettingsTab_ContractSettings"
        Me.TabControlPanelContractSettingsTab_ContractSettings.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelContractSettingsTab_ContractSettings.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelContractSettingsTab_ContractSettings.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelContractSettingsTab_ContractSettings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelContractSettingsTab_ContractSettings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelContractSettingsTab_ContractSettings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelContractSettingsTab_ContractSettings.Style.GradientAngle = 90
        Me.TabControlPanelContractSettingsTab_ContractSettings.TabIndex = 1
        Me.TabControlPanelContractSettingsTab_ContractSettings.TabItem = Me.TabItemContractSettings_ContractSettingsTab
        '
        'GroupBoxContractSettings_Notifications
        '
        Me.GroupBoxContractSettings_Notifications.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxContractSettings_Notifications.Controls.Add(Me.NumericInputContractSettings_RenewalDaysPrior)
        Me.GroupBoxContractSettings_Notifications.Controls.Add(Me.CheckBoxContractSettings_ContractReports)
        Me.GroupBoxContractSettings_Notifications.Controls.Add(Me.LabelContractSettings_DaysPrior)
        Me.GroupBoxContractSettings_Notifications.Controls.Add(Me.CheckBoxContractSettings_ContractRenewal)
        Me.GroupBoxContractSettings_Notifications.Location = New System.Drawing.Point(4, 51)
        Me.GroupBoxContractSettings_Notifications.Name = "GroupBoxContractSettings_Notifications"
        Me.GroupBoxContractSettings_Notifications.Size = New System.Drawing.Size(818, 212)
        Me.GroupBoxContractSettings_Notifications.TabIndex = 2
        Me.GroupBoxContractSettings_Notifications.Text = "Notifications"
        '
        'NumericInputContractSettings_RenewalDaysPrior
        '
        Me.NumericInputContractSettings_RenewalDaysPrior.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
        Me.NumericInputContractSettings_RenewalDaysPrior.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputContractSettings_RenewalDaysPrior.Location = New System.Drawing.Point(5, 57)
        Me.NumericInputContractSettings_RenewalDaysPrior.Name = "NumericInputContractSettings_RenewalDaysPrior"
        Me.NumericInputContractSettings_RenewalDaysPrior.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NumericInputContractSettings_RenewalDaysPrior.Properties.DisplayFormat.FormatString = "f0"
        Me.NumericInputContractSettings_RenewalDaysPrior.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputContractSettings_RenewalDaysPrior.Properties.EditFormat.FormatString = "f0"
        Me.NumericInputContractSettings_RenewalDaysPrior.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputContractSettings_RenewalDaysPrior.Properties.IsFloatValue = False
        Me.NumericInputContractSettings_RenewalDaysPrior.Properties.Mask.EditMask = "f0"
        Me.NumericInputContractSettings_RenewalDaysPrior.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NumericInputContractSettings_RenewalDaysPrior.Properties.MaxLength = 11
        Me.NumericInputContractSettings_RenewalDaysPrior.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NumericInputContractSettings_RenewalDaysPrior.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
        Me.NumericInputContractSettings_RenewalDaysPrior.Size = New System.Drawing.Size(49, 20)
        Me.NumericInputContractSettings_RenewalDaysPrior.TabIndex = 2
        '
        'CheckBoxContractSettings_ContractReports
        '
        Me.CheckBoxContractSettings_ContractReports.AutoCheck = False
        '
        '
        '
        Me.CheckBoxContractSettings_ContractReports.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxContractSettings_ContractReports.CheckValue = 0
        Me.CheckBoxContractSettings_ContractReports.CheckValueChecked = 1
        Me.CheckBoxContractSettings_ContractReports.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxContractSettings_ContractReports.CheckValueUnchecked = 0
        Me.CheckBoxContractSettings_ContractReports.ChildControls = CType(resources.GetObject("CheckBoxContractSettings_ContractReports.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxContractSettings_ContractReports.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxContractSettings_ContractReports.Location = New System.Drawing.Point(385, 31)
        Me.CheckBoxContractSettings_ContractReports.Name = "CheckBoxContractSettings_ContractReports"
        Me.CheckBoxContractSettings_ContractReports.OldestSibling = Nothing
        Me.CheckBoxContractSettings_ContractReports.SecurityEnabled = True
        Me.CheckBoxContractSettings_ContractReports.SiblingControls = CType(resources.GetObject("CheckBoxContractSettings_ContractReports.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxContractSettings_ContractReports.Size = New System.Drawing.Size(356, 23)
        Me.CheckBoxContractSettings_ContractReports.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxContractSettings_ContractReports.TabIndex = 1
        Me.CheckBoxContractSettings_ContractReports.TabStop = False
        Me.CheckBoxContractSettings_ContractReports.Text = "Reports - Runs automatically based on Contract/Report settings."
        '
        'LabelContractSettings_DaysPrior
        '
        Me.LabelContractSettings_DaysPrior.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelContractSettings_DaysPrior.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelContractSettings_DaysPrior.Location = New System.Drawing.Point(60, 57)
        Me.LabelContractSettings_DaysPrior.Name = "LabelContractSettings_DaysPrior"
        Me.LabelContractSettings_DaysPrior.Size = New System.Drawing.Size(185, 20)
        Me.LabelContractSettings_DaysPrior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelContractSettings_DaysPrior.TabIndex = 3
        Me.LabelContractSettings_DaysPrior.Text = "Days Prior to Contract End Date"
        '
        'CheckBoxContractSettings_ContractRenewal
        '
        '
        '
        '
        Me.CheckBoxContractSettings_ContractRenewal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxContractSettings_ContractRenewal.CheckValue = 0
        Me.CheckBoxContractSettings_ContractRenewal.CheckValueChecked = 1
        Me.CheckBoxContractSettings_ContractRenewal.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxContractSettings_ContractRenewal.CheckValueUnchecked = 0
        Me.CheckBoxContractSettings_ContractRenewal.ChildControls = CType(resources.GetObject("CheckBoxContractSettings_ContractRenewal.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxContractSettings_ContractRenewal.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxContractSettings_ContractRenewal.Location = New System.Drawing.Point(5, 28)
        Me.CheckBoxContractSettings_ContractRenewal.Name = "CheckBoxContractSettings_ContractRenewal"
        Me.CheckBoxContractSettings_ContractRenewal.OldestSibling = Nothing
        Me.CheckBoxContractSettings_ContractRenewal.SecurityEnabled = True
        Me.CheckBoxContractSettings_ContractRenewal.SiblingControls = CType(resources.GetObject("CheckBoxContractSettings_ContractRenewal.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxContractSettings_ContractRenewal.Size = New System.Drawing.Size(131, 23)
        Me.CheckBoxContractSettings_ContractRenewal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxContractSettings_ContractRenewal.TabIndex = 0
        Me.CheckBoxContractSettings_ContractRenewal.Text = "Contract Renewal"
        '
        'LabelContractAlertSettings_RunAt
        '
        Me.LabelContractAlertSettings_RunAt.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelContractAlertSettings_RunAt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelContractAlertSettings_RunAt.Location = New System.Drawing.Point(4, 4)
        Me.LabelContractAlertSettings_RunAt.Name = "LabelContractAlertSettings_RunAt"
        Me.LabelContractAlertSettings_RunAt.Size = New System.Drawing.Size(77, 20)
        Me.LabelContractAlertSettings_RunAt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelContractAlertSettings_RunAt.TabIndex = 0
        Me.LabelContractAlertSettings_RunAt.Text = "Run At (Daily):"
        '
        'DateTimeInputContractAlertSettings_RunAt
        '
        Me.DateTimeInputContractAlertSettings_RunAt.AllowEmptyState = False
        Me.DateTimeInputContractAlertSettings_RunAt.AutoResolveFreeTextEntries = False
        '
        '
        '
        Me.DateTimeInputContractAlertSettings_RunAt.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DateTimeInputContractAlertSettings_RunAt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputContractAlertSettings_RunAt.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DateTimeInputContractAlertSettings_RunAt.ButtonDropDown.Visible = True
        Me.DateTimeInputContractAlertSettings_RunAt.ButtonFreeText.Checked = True
        Me.DateTimeInputContractAlertSettings_RunAt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
        Me.DateTimeInputContractAlertSettings_RunAt.CustomFormat = ""
        Me.DateTimeInputContractAlertSettings_RunAt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.DateTimeInputContractAlertSettings_RunAt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.DateTimeInputContractAlertSettings_RunAt.FocusHighlightEnabled = True
        Me.DateTimeInputContractAlertSettings_RunAt.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.DateTimeInputContractAlertSettings_RunAt.FreeTextEntryMode = True
        Me.DateTimeInputContractAlertSettings_RunAt.IsPopupCalendarOpen = False
        Me.DateTimeInputContractAlertSettings_RunAt.Location = New System.Drawing.Point(87, 4)
        Me.DateTimeInputContractAlertSettings_RunAt.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.DisplayMonth = New Date(2011, 6, 1, 0, 0, 0, 0)
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.TodayButtonVisible = True
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.Visible = False
        Me.DateTimeInputContractAlertSettings_RunAt.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DateTimeInputContractAlertSettings_RunAt.Name = "DateTimeInputContractAlertSettings_RunAt"
        Me.DateTimeInputContractAlertSettings_RunAt.ReadOnly = False
        Me.DateTimeInputContractAlertSettings_RunAt.Size = New System.Drawing.Size(88, 20)
        Me.DateTimeInputContractAlertSettings_RunAt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DateTimeInputContractAlertSettings_RunAt.TabIndex = 1
        Me.DateTimeInputContractAlertSettings_RunAt.Value = New Date(2011, 10, 14, 11, 54, 40, 897)
        '
        'TabItemContractSettings_ContractSettingsTab
        '
        Me.TabItemContractSettings_ContractSettingsTab.AttachedControl = Me.TabControlPanelContractSettingsTab_ContractSettings
        Me.TabItemContractSettings_ContractSettingsTab.Name = "TabItemContractSettings_ContractSettingsTab"
        Me.TabItemContractSettings_ContractSettingsTab.Text = "Settings"
        '
        'TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles
        '
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.Controls.Add(Me.ButtonContractDatabaseProfiles_ProcessNow)
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.Controls.Add(Me.ButtonContractDatabaseProfiles_Select)
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.Controls.Add(Me.ButtonContractDatabaseProfiles_Edit)
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.Controls.Add(Me.ButtonContractDatabaseProfiles_Remove)
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.Controls.Add(Me.DataGridViewContractDatabaseProfiles_Databases)
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.Name = "TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles"
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.Style.GradientAngle = 90
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.TabIndex = 2
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.TabItem = Me.TabItemContractSettings_ContractDatabaseProfilesTab
        '
        'ButtonContractDatabaseProfiles_ProcessNow
        '
        Me.ButtonContractDatabaseProfiles_ProcessNow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonContractDatabaseProfiles_ProcessNow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonContractDatabaseProfiles_ProcessNow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonContractDatabaseProfiles_ProcessNow.Location = New System.Drawing.Point(4, 243)
        Me.ButtonContractDatabaseProfiles_ProcessNow.Name = "ButtonContractDatabaseProfiles_ProcessNow"
        Me.ButtonContractDatabaseProfiles_ProcessNow.SecurityEnabled = True
        Me.ButtonContractDatabaseProfiles_ProcessNow.Size = New System.Drawing.Size(75, 20)
        Me.ButtonContractDatabaseProfiles_ProcessNow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonContractDatabaseProfiles_ProcessNow.TabIndex = 13
        Me.ButtonContractDatabaseProfiles_ProcessNow.Text = "Process Now"
        '
        'ButtonContractDatabaseProfiles_Select
        '
        Me.ButtonContractDatabaseProfiles_Select.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonContractDatabaseProfiles_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonContractDatabaseProfiles_Select.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonContractDatabaseProfiles_Select.Location = New System.Drawing.Point(585, 243)
        Me.ButtonContractDatabaseProfiles_Select.Name = "ButtonContractDatabaseProfiles_Select"
        Me.ButtonContractDatabaseProfiles_Select.SecurityEnabled = True
        Me.ButtonContractDatabaseProfiles_Select.Size = New System.Drawing.Size(75, 20)
        Me.ButtonContractDatabaseProfiles_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonContractDatabaseProfiles_Select.TabIndex = 14
        Me.ButtonContractDatabaseProfiles_Select.Text = "Select"
        '
        'ButtonContractDatabaseProfiles_Edit
        '
        Me.ButtonContractDatabaseProfiles_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonContractDatabaseProfiles_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonContractDatabaseProfiles_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonContractDatabaseProfiles_Edit.Location = New System.Drawing.Point(666, 243)
        Me.ButtonContractDatabaseProfiles_Edit.Name = "ButtonContractDatabaseProfiles_Edit"
        Me.ButtonContractDatabaseProfiles_Edit.SecurityEnabled = True
        Me.ButtonContractDatabaseProfiles_Edit.Size = New System.Drawing.Size(75, 20)
        Me.ButtonContractDatabaseProfiles_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonContractDatabaseProfiles_Edit.TabIndex = 15
        Me.ButtonContractDatabaseProfiles_Edit.Text = "Edit"
        '
        'ButtonContractDatabaseProfiles_Remove
        '
        Me.ButtonContractDatabaseProfiles_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonContractDatabaseProfiles_Remove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonContractDatabaseProfiles_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonContractDatabaseProfiles_Remove.Location = New System.Drawing.Point(747, 243)
        Me.ButtonContractDatabaseProfiles_Remove.Name = "ButtonContractDatabaseProfiles_Remove"
        Me.ButtonContractDatabaseProfiles_Remove.SecurityEnabled = True
        Me.ButtonContractDatabaseProfiles_Remove.Size = New System.Drawing.Size(75, 20)
        Me.ButtonContractDatabaseProfiles_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonContractDatabaseProfiles_Remove.TabIndex = 16
        Me.ButtonContractDatabaseProfiles_Remove.Text = "Remove"
        '
        'DataGridViewContractDatabaseProfiles_Databases
        '
        Me.DataGridViewContractDatabaseProfiles_Databases.AllowSelectGroupHeaderRow = True
        Me.DataGridViewContractDatabaseProfiles_Databases.AlwaysForceShowRowSelectionOnUserInput = True
        Me.DataGridViewContractDatabaseProfiles_Databases.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewContractDatabaseProfiles_Databases.AutoFilterLookupColumns = False
        Me.DataGridViewContractDatabaseProfiles_Databases.AutoloadRepositoryDatasource = True
        Me.DataGridViewContractDatabaseProfiles_Databases.BackColor = System.Drawing.SystemColors.Control
        Me.DataGridViewContractDatabaseProfiles_Databases.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.DatabaseProfile
        Me.DataGridViewContractDatabaseProfiles_Databases.DataSource = Nothing
        Me.DataGridViewContractDatabaseProfiles_Databases.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
        Me.DataGridViewContractDatabaseProfiles_Databases.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.DataGridViewContractDatabaseProfiles_Databases.ItemDescription = "Item(s)"
        Me.DataGridViewContractDatabaseProfiles_Databases.Location = New System.Drawing.Point(4, 4)
        Me.DataGridViewContractDatabaseProfiles_Databases.MultiSelect = True
        Me.DataGridViewContractDatabaseProfiles_Databases.Name = "DataGridViewContractDatabaseProfiles_Databases"
        Me.DataGridViewContractDatabaseProfiles_Databases.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        Me.DataGridViewContractDatabaseProfiles_Databases.RunStandardValidation = True
        Me.DataGridViewContractDatabaseProfiles_Databases.ShowSelectDeselectAllButtons = False
        Me.DataGridViewContractDatabaseProfiles_Databases.Size = New System.Drawing.Size(818, 233)
        Me.DataGridViewContractDatabaseProfiles_Databases.TabIndex = 12
        Me.DataGridViewContractDatabaseProfiles_Databases.UseEmbeddedNavigator = False
        Me.DataGridViewContractDatabaseProfiles_Databases.ViewCaptionHeight = -1
        '
        'TabItemContractSettings_ContractDatabaseProfilesTab
        '
        Me.TabItemContractSettings_ContractDatabaseProfilesTab.AttachedControl = Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles
        Me.TabItemContractSettings_ContractDatabaseProfilesTab.Name = "TabItemContractSettings_ContractDatabaseProfilesTab"
        Me.TabItemContractSettings_ContractDatabaseProfilesTab.Text = "Database Profiles"
        '
        'TabControlContractLogTab_ContractLog
        '
        Me.TabControlContractLogTab_ContractLog.Controls.Add(Me.TextBoxContractLog_Log)
        Me.TabControlContractLogTab_ContractLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlContractLogTab_ContractLog.Location = New System.Drawing.Point(0, 27)
        Me.TabControlContractLogTab_ContractLog.Name = "TabControlContractLogTab_ContractLog"
        Me.TabControlContractLogTab_ContractLog.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlContractLogTab_ContractLog.Size = New System.Drawing.Size(826, 267)
        Me.TabControlContractLogTab_ContractLog.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlContractLogTab_ContractLog.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlContractLogTab_ContractLog.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlContractLogTab_ContractLog.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlContractLogTab_ContractLog.Style.GradientAngle = 90
        Me.TabControlContractLogTab_ContractLog.TabIndex = 3
        Me.TabControlContractLogTab_ContractLog.TabItem = Me.TabItemContractSettings_ContractLogTab
        '
        'TextBoxContractLog_Log
        '
        Me.TextBoxContractLog_Log.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxContractLog_Log.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxContractLog_Log.Border.Class = "TextBoxBorder"
        Me.TextBoxContractLog_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxContractLog_Log.CheckSpellingOnValidate = False
        Me.TextBoxContractLog_Log.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxContractLog_Log.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxContractLog_Log.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxContractLog_Log.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxContractLog_Log.FocusHighlightEnabled = True
        Me.TextBoxContractLog_Log.ForeColor = System.Drawing.Color.Black
        Me.TextBoxContractLog_Log.Location = New System.Drawing.Point(4, 4)
        Me.TextBoxContractLog_Log.MaxFileSize = CType(0, Long)
        Me.TextBoxContractLog_Log.Multiline = True
        Me.TextBoxContractLog_Log.Name = "TextBoxContractLog_Log"
        Me.TextBoxContractLog_Log.ReadOnly = True
        Me.TextBoxContractLog_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxContractLog_Log.ShowSpellCheckCompleteMessage = True
        Me.TextBoxContractLog_Log.Size = New System.Drawing.Size(818, 259)
        Me.TextBoxContractLog_Log.TabIndex = 18
        Me.TextBoxContractLog_Log.TabOnEnter = True
        '
        'TabItemContractSettings_ContractLogTab
        '
        Me.TabItemContractSettings_ContractLogTab.AttachedControl = Me.TabControlContractLogTab_ContractLog
        Me.TabItemContractSettings_ContractLogTab.Name = "TabItemContractSettings_ContractLogTab"
        Me.TabItemContractSettings_ContractLogTab.Text = "Log"
        '
        'LabelContract_StatusDescription
        '
        Me.LabelContract_StatusDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelContract_StatusDescription.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelContract_StatusDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelContract_StatusDescription.Location = New System.Drawing.Point(58, 4)
        Me.LabelContract_StatusDescription.Name = "LabelContract_StatusDescription"
        Me.LabelContract_StatusDescription.Size = New System.Drawing.Size(613, 20)
        Me.LabelContract_StatusDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelContract_StatusDescription.TabIndex = 1
        Me.LabelContract_StatusDescription.Text = "Stopped..."
        '
        'LabelContract_Status
        '
        Me.LabelContract_Status.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelContract_Status.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelContract_Status.Location = New System.Drawing.Point(12, 4)
        Me.LabelContract_Status.Name = "LabelContract_Status"
        Me.LabelContract_Status.Size = New System.Drawing.Size(40, 20)
        Me.LabelContract_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelContract_Status.TabIndex = 0
        Me.LabelContract_Status.Text = "Status:"
        '
        'ButtonContract_Start
        '
        Me.ButtonContract_Start.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonContract_Start.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonContract_Start.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonContract_Start.Location = New System.Drawing.Point(763, 4)
        Me.ButtonContract_Start.Name = "ButtonContract_Start"
        Me.ButtonContract_Start.SecurityEnabled = True
        Me.ButtonContract_Start.Size = New System.Drawing.Size(75, 20)
        Me.ButtonContract_Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonContract_Start.TabIndex = 3
        Me.ButtonContract_Start.Text = "Start"
        '
        'ButtonContract_Stop
        '
        Me.ButtonContract_Stop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonContract_Stop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonContract_Stop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonContract_Stop.Location = New System.Drawing.Point(763, 4)
        Me.ButtonContract_Stop.Name = "ButtonContract_Stop"
        Me.ButtonContract_Stop.SecurityEnabled = True
        Me.ButtonContract_Stop.Size = New System.Drawing.Size(75, 20)
        Me.ButtonContract_Stop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonContract_Stop.TabIndex = 16
        Me.ButtonContract_Stop.Text = "Stop"
        Me.ButtonContract_Stop.Visible = False
        '
        'TabItemServices_ContractTab
        '
        Me.TabItemServices_ContractTab.AttachedControl = Me.TabControlPanelContractTab_Contract
        Me.TabItemServices_ContractTab.Name = "TabItemServices_ContractTab"
        Me.TabItemServices_ContractTab.Text = "Contract"
        '
        'TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals
        '
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.Controls.Add(Me.CheckBoxPaidTimeOffAccruals_AutoStart)
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.Controls.Add(Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings)
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.Controls.Add(Me.LabelPaidTimeOffAccruals_StatusDescription)
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.Controls.Add(Me.LabelPaidTimeOffAccruals_Status)
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.Controls.Add(Me.ButtonPaidTimeOffAccruals_Start)
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.Controls.Add(Me.ButtonPaidTimeOffAccruals_Stop)
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.Name = "TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals"
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.Size = New System.Drawing.Size(850, 336)
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.Style.GradientAngle = 90
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.TabIndex = 9
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.TabItem = Me.TabItemServices_PaidTimeOffAccrualsTab
        '
        'CheckBoxPaidTimeOffAccruals_AutoStart
        '
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.CheckValue = 0
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.CheckValueChecked = 1
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.CheckValueUnchecked = 0
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.ChildControls = CType(resources.GetObject("CheckBoxPaidTimeOffAccruals_AutoStart.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.Location = New System.Drawing.Point(677, 4)
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.Name = "CheckBoxPaidTimeOffAccruals_AutoStart"
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.OldestSibling = Nothing
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.SecurityEnabled = True
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.SiblingControls = CType(resources.GetObject("CheckBoxPaidTimeOffAccruals_AutoStart.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.Size = New System.Drawing.Size(80, 20)
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.TabIndex = 23
        Me.CheckBoxPaidTimeOffAccruals_AutoStart.Text = "Auto Start"
        '
        'TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings
        '
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.BackColor = System.Drawing.Color.White
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.CanReorderTabs = False
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.Controls.Add(Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings)
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.Controls.Add(Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles)
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.Controls.Add(Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog)
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.ForeColor = System.Drawing.Color.Black
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.Location = New System.Drawing.Point(12, 30)
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.Name = "TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings"
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.SelectedTabIndex = 0
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.Size = New System.Drawing.Size(826, 294)
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.TabIndex = 22
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.Tabs.Add(Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsSettingsTab)
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.Tabs.Add(Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsDatabaseProfilesTab)
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.Tabs.Add(Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsLogTab)
        '
        'TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings
        '
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Controls.Add(Me.LabelPaidTimeOffAccrualsSettings_LastRanDetails)
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Controls.Add(Me.LabelPaidTimeOffAccrualsSettings_DatabaseProfile)
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Controls.Add(Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile)
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Controls.Add(Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay)
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Controls.Add(Me.LabelPaidTimeOffAccrualsSettings_RunOnDay)
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Name = "TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings"
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Size = New System.Drawing.Size(826, 272)
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.Style.GradientAngle = 90
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.TabIndex = 1
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.TabItem = Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsSettingsTab
        '
        'LabelPaidTimeOffAccrualsSettings_LastRanDetails
        '
        Me.LabelPaidTimeOffAccrualsSettings_LastRanDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelPaidTimeOffAccrualsSettings_LastRanDetails.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelPaidTimeOffAccrualsSettings_LastRanDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelPaidTimeOffAccrualsSettings_LastRanDetails.Location = New System.Drawing.Point(4, 56)
        Me.LabelPaidTimeOffAccrualsSettings_LastRanDetails.Name = "LabelPaidTimeOffAccrualsSettings_LastRanDetails"
        Me.LabelPaidTimeOffAccrualsSettings_LastRanDetails.Size = New System.Drawing.Size(818, 20)
        Me.LabelPaidTimeOffAccrualsSettings_LastRanDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelPaidTimeOffAccrualsSettings_LastRanDetails.TabIndex = 17
        '
        'LabelPaidTimeOffAccrualsSettings_DatabaseProfile
        '
        Me.LabelPaidTimeOffAccrualsSettings_DatabaseProfile.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelPaidTimeOffAccrualsSettings_DatabaseProfile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelPaidTimeOffAccrualsSettings_DatabaseProfile.Location = New System.Drawing.Point(4, 30)
        Me.LabelPaidTimeOffAccrualsSettings_DatabaseProfile.Name = "LabelPaidTimeOffAccrualsSettings_DatabaseProfile"
        Me.LabelPaidTimeOffAccrualsSettings_DatabaseProfile.Size = New System.Drawing.Size(90, 20)
        Me.LabelPaidTimeOffAccrualsSettings_DatabaseProfile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelPaidTimeOffAccrualsSettings_DatabaseProfile.TabIndex = 2
        Me.LabelPaidTimeOffAccrualsSettings_DatabaseProfile.Text = "Database Profile:"
        '
        'ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile
        '
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.AddInactiveItemsOnSelectedValue = False
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.AutoFindItemInDataSource = False
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.AutoSelectSingleItemDatasource = False
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.BookmarkingEnabled = False
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.DatabaseProfile
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.DisableMouseWheel = False
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.DisplayMember = "Name"
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.DisplayName = ""
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.FocusHighlightEnabled = True
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.FormattingEnabled = True
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.ItemHeight = 14
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.Location = New System.Drawing.Point(100, 30)
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.Name = "ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile"
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.PreventEnterBeep = False
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.ReadOnly = False
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.SecurityEnabled = True
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.Size = New System.Drawing.Size(180, 20)
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.TabIndex = 3
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.ValueMember = "ConnectionString"
        Me.ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile.WatermarkText = "Select Database Profile"
        '
        'ComboBoxPaidTimeOffAccrualsSettings_RunOnDay
        '
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.AddInactiveItemsOnSelectedValue = False
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.AutoFindItemInDataSource = False
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.AutoSelectSingleItemDatasource = False
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.BookmarkingEnabled = False
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.LongNumeric
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.DisableMouseWheel = False
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.DisplayMember = "Number"
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.DisplayName = ""
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.FocusHighlightEnabled = True
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.FormattingEnabled = True
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.ItemHeight = 14
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.Location = New System.Drawing.Point(100, 4)
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.Name = "ComboBoxPaidTimeOffAccrualsSettings_RunOnDay"
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.PreventEnterBeep = False
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.ReadOnly = False
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.SecurityEnabled = True
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.Size = New System.Drawing.Size(180, 20)
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.TabIndex = 1
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.ValueMember = "Number"
        Me.ComboBoxPaidTimeOffAccrualsSettings_RunOnDay.WatermarkText = "Select"
        '
        'LabelPaidTimeOffAccrualsSettings_RunOnDay
        '
        Me.LabelPaidTimeOffAccrualsSettings_RunOnDay.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelPaidTimeOffAccrualsSettings_RunOnDay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelPaidTimeOffAccrualsSettings_RunOnDay.Location = New System.Drawing.Point(4, 4)
        Me.LabelPaidTimeOffAccrualsSettings_RunOnDay.Name = "LabelPaidTimeOffAccrualsSettings_RunOnDay"
        Me.LabelPaidTimeOffAccrualsSettings_RunOnDay.Size = New System.Drawing.Size(75, 20)
        Me.LabelPaidTimeOffAccrualsSettings_RunOnDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelPaidTimeOffAccrualsSettings_RunOnDay.TabIndex = 0
        Me.LabelPaidTimeOffAccrualsSettings_RunOnDay.Text = "Run On Day:"
        '
        'TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsSettingsTab
        '
        Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsSettingsTab.AttachedControl = Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings
        Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsSettingsTab.Name = "TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsSettingsTab"
        Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsSettingsTab.Text = "Settings"
        '
        'TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles
        '
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.Controls.Add(Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow)
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.Controls.Add(Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Select)
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.Controls.Add(Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit)
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.Controls.Add(Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove)
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.Controls.Add(Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases)
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.Name = "TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabase" & _
    "Profiles"
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.Size = New System.Drawing.Size(826, 272)
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.Style.GradientAngle = 90
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.TabIndex = 2
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.TabItem = Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsDatabaseProfilesTab
        '
        'ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow
        '
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow.Location = New System.Drawing.Point(4, 248)
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow.Name = "ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow"
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow.SecurityEnabled = True
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow.Size = New System.Drawing.Size(75, 20)
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow.TabIndex = 6
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow.Text = "Process Now"
        '
        'ButtonPaidTimeOffAccrualsDatabaseProfiles_Select
        '
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Select.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Select.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Select.Location = New System.Drawing.Point(585, 248)
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Select.Name = "ButtonPaidTimeOffAccrualsDatabaseProfiles_Select"
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Select.SecurityEnabled = True
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Select.Size = New System.Drawing.Size(75, 20)
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Select.TabIndex = 7
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Select.Text = "Select"
        '
        'ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit
        '
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit.Location = New System.Drawing.Point(666, 248)
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit.Name = "ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit"
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit.SecurityEnabled = True
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit.Size = New System.Drawing.Size(75, 20)
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit.TabIndex = 9
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit.Text = "Edit"
        '
        'ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove
        '
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove.Location = New System.Drawing.Point(747, 248)
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove.Name = "ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove"
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove.SecurityEnabled = True
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove.Size = New System.Drawing.Size(75, 20)
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove.TabIndex = 9
        Me.ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove.Text = "Remove"
        '
        'DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases
        '
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.AllowSelectGroupHeaderRow = True
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.AlwaysForceShowRowSelectionOnUserInput = True
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.AutoFilterLookupColumns = False
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.AutoloadRepositoryDatasource = True
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.BackColor = System.Drawing.SystemColors.Control
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.DatabaseProfile
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.ItemDescription = "Item(s)"
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.Location = New System.Drawing.Point(4, 4)
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.MultiSelect = True
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.Name = "DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases"
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.RunStandardValidation = True
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.ShowSelectDeselectAllButtons = False
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.Size = New System.Drawing.Size(818, 238)
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.TabIndex = 5
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.UseEmbeddedNavigator = False
        Me.DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases.ViewCaptionHeight = -1
        '
        'TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsDatabaseProfilesTab
        '
        Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsDatabaseProfilesTab.AttachedControl = Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles
        Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsDatabaseProfilesTab.Name = "TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsDatabaseProfilesTab"
        Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsDatabaseProfilesTab.Text = "Database Profiles"
        '
        'TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog
        '
        Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog.Controls.Add(Me.TextBoxPaidTimeOffAccrualsLog_Log)
        Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog.Name = "TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog"
        Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog.Style.GradientAngle = 90
        Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog.TabIndex = 3
        Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog.TabItem = Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsLogTab
        '
        'TextBoxPaidTimeOffAccrualsLog_Log
        '
        Me.TextBoxPaidTimeOffAccrualsLog_Log.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxPaidTimeOffAccrualsLog_Log.Border.Class = "TextBoxBorder"
        Me.TextBoxPaidTimeOffAccrualsLog_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxPaidTimeOffAccrualsLog_Log.CheckSpellingOnValidate = False
        Me.TextBoxPaidTimeOffAccrualsLog_Log.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxPaidTimeOffAccrualsLog_Log.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxPaidTimeOffAccrualsLog_Log.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxPaidTimeOffAccrualsLog_Log.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxPaidTimeOffAccrualsLog_Log.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxPaidTimeOffAccrualsLog_Log.FocusHighlightEnabled = True
        Me.TextBoxPaidTimeOffAccrualsLog_Log.ForeColor = System.Drawing.Color.Black
        Me.TextBoxPaidTimeOffAccrualsLog_Log.Location = New System.Drawing.Point(1, 1)
        Me.TextBoxPaidTimeOffAccrualsLog_Log.MaxFileSize = CType(0, Long)
        Me.TextBoxPaidTimeOffAccrualsLog_Log.Multiline = True
        Me.TextBoxPaidTimeOffAccrualsLog_Log.Name = "TextBoxPaidTimeOffAccrualsLog_Log"
        Me.TextBoxPaidTimeOffAccrualsLog_Log.ReadOnly = True
        Me.TextBoxPaidTimeOffAccrualsLog_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxPaidTimeOffAccrualsLog_Log.ShowSpellCheckCompleteMessage = True
        Me.TextBoxPaidTimeOffAccrualsLog_Log.Size = New System.Drawing.Size(824, 265)
        Me.TextBoxPaidTimeOffAccrualsLog_Log.TabIndex = 5
        Me.TextBoxPaidTimeOffAccrualsLog_Log.TabOnEnter = True
        '
        'TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsLogTab
        '
        Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsLogTab.AttachedControl = Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog
        Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsLogTab.Name = "TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsLogTab"
        Me.TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsLogTab.Text = "Log"
        '
        'LabelPaidTimeOffAccruals_StatusDescription
        '
        Me.LabelPaidTimeOffAccruals_StatusDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelPaidTimeOffAccruals_StatusDescription.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelPaidTimeOffAccruals_StatusDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelPaidTimeOffAccruals_StatusDescription.Location = New System.Drawing.Point(58, 4)
        Me.LabelPaidTimeOffAccruals_StatusDescription.Name = "LabelPaidTimeOffAccruals_StatusDescription"
        Me.LabelPaidTimeOffAccruals_StatusDescription.Size = New System.Drawing.Size(613, 20)
        Me.LabelPaidTimeOffAccruals_StatusDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelPaidTimeOffAccruals_StatusDescription.TabIndex = 19
        Me.LabelPaidTimeOffAccruals_StatusDescription.Text = "Stopped..."
        '
        'LabelPaidTimeOffAccruals_Status
        '
        Me.LabelPaidTimeOffAccruals_Status.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelPaidTimeOffAccruals_Status.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelPaidTimeOffAccruals_Status.Location = New System.Drawing.Point(12, 4)
        Me.LabelPaidTimeOffAccruals_Status.Name = "LabelPaidTimeOffAccruals_Status"
        Me.LabelPaidTimeOffAccruals_Status.Size = New System.Drawing.Size(40, 20)
        Me.LabelPaidTimeOffAccruals_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelPaidTimeOffAccruals_Status.TabIndex = 18
        Me.LabelPaidTimeOffAccruals_Status.Text = "Status:"
        '
        'ButtonPaidTimeOffAccruals_Start
        '
        Me.ButtonPaidTimeOffAccruals_Start.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonPaidTimeOffAccruals_Start.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonPaidTimeOffAccruals_Start.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonPaidTimeOffAccruals_Start.Location = New System.Drawing.Point(763, 4)
        Me.ButtonPaidTimeOffAccruals_Start.Name = "ButtonPaidTimeOffAccruals_Start"
        Me.ButtonPaidTimeOffAccruals_Start.SecurityEnabled = True
        Me.ButtonPaidTimeOffAccruals_Start.Size = New System.Drawing.Size(75, 20)
        Me.ButtonPaidTimeOffAccruals_Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonPaidTimeOffAccruals_Start.TabIndex = 20
        Me.ButtonPaidTimeOffAccruals_Start.Text = "Start"
        '
        'ButtonPaidTimeOffAccruals_Stop
        '
        Me.ButtonPaidTimeOffAccruals_Stop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonPaidTimeOffAccruals_Stop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonPaidTimeOffAccruals_Stop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonPaidTimeOffAccruals_Stop.Location = New System.Drawing.Point(763, 4)
        Me.ButtonPaidTimeOffAccruals_Stop.Name = "ButtonPaidTimeOffAccruals_Stop"
        Me.ButtonPaidTimeOffAccruals_Stop.SecurityEnabled = True
        Me.ButtonPaidTimeOffAccruals_Stop.Size = New System.Drawing.Size(75, 20)
        Me.ButtonPaidTimeOffAccruals_Stop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonPaidTimeOffAccruals_Stop.TabIndex = 21
        Me.ButtonPaidTimeOffAccruals_Stop.Text = "Stop"
        Me.ButtonPaidTimeOffAccruals_Stop.Visible = False
        '
        'TabItemServices_PaidTimeOffAccrualsTab
        '
        Me.TabItemServices_PaidTimeOffAccrualsTab.AttachedControl = Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals
        Me.TabItemServices_PaidTimeOffAccrualsTab.Name = "TabItemServices_PaidTimeOffAccrualsTab"
        Me.TabItemServices_PaidTimeOffAccrualsTab.Text = "Paid Time Off Accruals"
        '
        'TabControlPanelTasks_Tasks
        '
        Me.TabControlPanelTasks_Tasks.Controls.Add(Me.CheckBoxTask_AutoStart)
        Me.TabControlPanelTasks_Tasks.Controls.Add(Me.TabControlTask_Settings)
        Me.TabControlPanelTasks_Tasks.Controls.Add(Me.ButtonTask_Stop)
        Me.TabControlPanelTasks_Tasks.Controls.Add(Me.LabelTask_StatusDescription)
        Me.TabControlPanelTasks_Tasks.Controls.Add(Me.LabelTask_Status)
        Me.TabControlPanelTasks_Tasks.Controls.Add(Me.ButtonTask_Start)
        Me.TabControlPanelTasks_Tasks.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelTasks_Tasks.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelTasks_Tasks.Name = "TabControlPanelTasks_Tasks"
        Me.TabControlPanelTasks_Tasks.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelTasks_Tasks.Size = New System.Drawing.Size(850, 336)
        Me.TabControlPanelTasks_Tasks.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelTasks_Tasks.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelTasks_Tasks.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelTasks_Tasks.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelTasks_Tasks.Style.GradientAngle = 90
        Me.TabControlPanelTasks_Tasks.TabIndex = 4
        Me.TabControlPanelTasks_Tasks.TabItem = Me.TabItemServices_TasksTab
        '
        'CheckBoxTask_AutoStart
        '
        Me.CheckBoxTask_AutoStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxTask_AutoStart.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.CheckBoxTask_AutoStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxTask_AutoStart.CheckValue = 0
        Me.CheckBoxTask_AutoStart.CheckValueChecked = 1
        Me.CheckBoxTask_AutoStart.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxTask_AutoStart.CheckValueUnchecked = 0
        Me.CheckBoxTask_AutoStart.ChildControls = CType(resources.GetObject("CheckBoxTask_AutoStart.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxTask_AutoStart.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxTask_AutoStart.Location = New System.Drawing.Point(677, 4)
        Me.CheckBoxTask_AutoStart.Name = "CheckBoxTask_AutoStart"
        Me.CheckBoxTask_AutoStart.OldestSibling = Nothing
        Me.CheckBoxTask_AutoStart.SecurityEnabled = True
        Me.CheckBoxTask_AutoStart.SiblingControls = CType(resources.GetObject("CheckBoxTask_AutoStart.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxTask_AutoStart.Size = New System.Drawing.Size(80, 20)
        Me.CheckBoxTask_AutoStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxTask_AutoStart.TabIndex = 10
        Me.CheckBoxTask_AutoStart.Text = "Auto Start"
        '
        'TabControlTask_Settings
        '
        Me.TabControlTask_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlTask_Settings.BackColor = System.Drawing.Color.White
        Me.TabControlTask_Settings.CanReorderTabs = False
        Me.TabControlTask_Settings.Controls.Add(Me.TabControlPanelSettingsTab_TaskSettings)
        Me.TabControlTask_Settings.Controls.Add(Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles)
        Me.TabControlTask_Settings.Controls.Add(Me.TabControlPanelLogTab_TaskLog)
        Me.TabControlTask_Settings.ForeColor = System.Drawing.Color.Black
        Me.TabControlTask_Settings.Location = New System.Drawing.Point(12, 30)
        Me.TabControlTask_Settings.Name = "TabControlTask_Settings"
        Me.TabControlTask_Settings.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControlTask_Settings.SelectedTabIndex = 0
        Me.TabControlTask_Settings.Size = New System.Drawing.Size(826, 294)
        Me.TabControlTask_Settings.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControlTask_Settings.TabIndex = 9
        Me.TabControlTask_Settings.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControlTask_Settings.Tabs.Add(Me.TabItemTaskSettings_SettingsTab)
        Me.TabControlTask_Settings.Tabs.Add(Me.TabItemTaskSettings_DatabaseProfilesTab)
        Me.TabControlTask_Settings.Tabs.Add(Me.TabItemTaskSettings_LogTab)
        '
        'TabControlPanelSettingsTab_TaskSettings
        '
        Me.TabControlPanelSettingsTab_TaskSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPanelSettingsTab_TaskSettings.Controls.Add(Me.ComboBoxTaskSettings_RunDay)
        Me.TabControlPanelSettingsTab_TaskSettings.Controls.Add(Me.DateTimeInputTaskSettings_RunAt)
        Me.TabControlPanelSettingsTab_TaskSettings.Controls.Add(Me.GroupBoxTaskSettings_Notifications)
        Me.TabControlPanelSettingsTab_TaskSettings.Controls.Add(Me.LabelTaskSettings_RunDay)
        Me.TabControlPanelSettingsTab_TaskSettings.Controls.Add(Me.LabelTaskSettings_RunAt)
        Me.TabControlPanelSettingsTab_TaskSettings.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanelSettingsTab_TaskSettings.Name = "TabControlPanelSettingsTab_TaskSettings"
        Me.TabControlPanelSettingsTab_TaskSettings.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelSettingsTab_TaskSettings.Size = New System.Drawing.Size(826, 272)
        Me.TabControlPanelSettingsTab_TaskSettings.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelSettingsTab_TaskSettings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelSettingsTab_TaskSettings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelSettingsTab_TaskSettings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelSettingsTab_TaskSettings.Style.GradientAngle = 90
        Me.TabControlPanelSettingsTab_TaskSettings.TabIndex = 0
        Me.TabControlPanelSettingsTab_TaskSettings.TabItem = Me.TabItemTaskSettings_SettingsTab
        '
        'ComboBoxTaskSettings_RunDay
        '
        Me.ComboBoxTaskSettings_RunDay.AddInactiveItemsOnSelectedValue = False
        Me.ComboBoxTaskSettings_RunDay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxTaskSettings_RunDay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxTaskSettings_RunDay.AutoFindItemInDataSource = False
        Me.ComboBoxTaskSettings_RunDay.AutoSelectSingleItemDatasource = False
        Me.ComboBoxTaskSettings_RunDay.BookmarkingEnabled = False
        Me.ComboBoxTaskSettings_RunDay.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Client
        Me.ComboBoxTaskSettings_RunDay.DisableMouseWheel = False
        Me.ComboBoxTaskSettings_RunDay.DisplayMember = "Name"
        Me.ComboBoxTaskSettings_RunDay.DisplayName = ""
        Me.ComboBoxTaskSettings_RunDay.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxTaskSettings_RunDay.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.ComboBoxTaskSettings_RunDay.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
        Me.ComboBoxTaskSettings_RunDay.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.ComboBoxTaskSettings_RunDay.FocusHighlightEnabled = True
        Me.ComboBoxTaskSettings_RunDay.FormattingEnabled = True
        Me.ComboBoxTaskSettings_RunDay.ItemHeight = 14
        Me.ComboBoxTaskSettings_RunDay.Location = New System.Drawing.Point(85, 30)
        Me.ComboBoxTaskSettings_RunDay.Name = "ComboBoxTaskSettings_RunDay"
        Me.ComboBoxTaskSettings_RunDay.PreventEnterBeep = False
        Me.ComboBoxTaskSettings_RunDay.ReadOnly = False
        Me.ComboBoxTaskSettings_RunDay.SecurityEnabled = True
        Me.ComboBoxTaskSettings_RunDay.Size = New System.Drawing.Size(257, 20)
        Me.ComboBoxTaskSettings_RunDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxTaskSettings_RunDay.TabIndex = 3
        Me.ComboBoxTaskSettings_RunDay.ValueMember = "Code"
        Me.ComboBoxTaskSettings_RunDay.WatermarkText = "Select Client"
        '
        'DateTimeInputTaskSettings_RunAt
        '
        Me.DateTimeInputTaskSettings_RunAt.AllowEmptyState = False
        Me.DateTimeInputTaskSettings_RunAt.AutoResolveFreeTextEntries = False
        '
        '
        '
        Me.DateTimeInputTaskSettings_RunAt.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DateTimeInputTaskSettings_RunAt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputTaskSettings_RunAt.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DateTimeInputTaskSettings_RunAt.ButtonDropDown.Visible = True
        Me.DateTimeInputTaskSettings_RunAt.ButtonFreeText.Checked = True
        Me.DateTimeInputTaskSettings_RunAt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
        Me.DateTimeInputTaskSettings_RunAt.CustomFormat = ""
        Me.DateTimeInputTaskSettings_RunAt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.DateTimeInputTaskSettings_RunAt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.DateTimeInputTaskSettings_RunAt.FocusHighlightEnabled = True
        Me.DateTimeInputTaskSettings_RunAt.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.DateTimeInputTaskSettings_RunAt.FreeTextEntryMode = True
        Me.DateTimeInputTaskSettings_RunAt.IsPopupCalendarOpen = False
        Me.DateTimeInputTaskSettings_RunAt.Location = New System.Drawing.Point(85, 4)
        Me.DateTimeInputTaskSettings_RunAt.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.DisplayMonth = New Date(2011, 6, 1, 0, 0, 0, 0)
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.TodayButtonVisible = True
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.Visible = False
        Me.DateTimeInputTaskSettings_RunAt.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DateTimeInputTaskSettings_RunAt.Name = "DateTimeInputTaskSettings_RunAt"
        Me.DateTimeInputTaskSettings_RunAt.ReadOnly = False
        Me.DateTimeInputTaskSettings_RunAt.Size = New System.Drawing.Size(88, 20)
        Me.DateTimeInputTaskSettings_RunAt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DateTimeInputTaskSettings_RunAt.TabIndex = 1
        Me.DateTimeInputTaskSettings_RunAt.Value = New Date(2011, 10, 14, 11, 54, 40, 724)
        '
        'GroupBoxTaskSettings_Notifications
        '
        Me.GroupBoxTaskSettings_Notifications.Controls.Add(Me.NumericInputTaskSettings_Upcoming_EndDays)
        Me.GroupBoxTaskSettings_Notifications.Controls.Add(Me.NumericInputTaskSettings_Upcoming_StartDays)
        Me.GroupBoxTaskSettings_Notifications.Controls.Add(Me.LabelTaskSettings_Upcoming_Between)
        Me.GroupBoxTaskSettings_Notifications.Controls.Add(Me.LabelTaskSettings_Upcoming_Days)
        Me.GroupBoxTaskSettings_Notifications.Controls.Add(Me.LabelTaskSettings_Upcoming_And)
        Me.GroupBoxTaskSettings_Notifications.Controls.Add(Me.LabelTaskSettings_Upcoming_CustomMessage)
        Me.GroupBoxTaskSettings_Notifications.Controls.Add(Me.LabelTaskSettings_PastDue_CustomMessage)
        Me.GroupBoxTaskSettings_Notifications.Controls.Add(Me.TextBoxTaskSettings_Upcoming_CustomMessage)
        Me.GroupBoxTaskSettings_Notifications.Controls.Add(Me.TextBoxTaskSettings_PastDue_CustomMessage)
        Me.GroupBoxTaskSettings_Notifications.Controls.Add(Me.CheckBoxTaskSettings_Upcoming)
        Me.GroupBoxTaskSettings_Notifications.Controls.Add(Me.CheckBoxTaskSettings_PastDue)
        Me.GroupBoxTaskSettings_Notifications.Location = New System.Drawing.Point(4, 56)
        Me.GroupBoxTaskSettings_Notifications.Name = "GroupBoxTaskSettings_Notifications"
        Me.GroupBoxTaskSettings_Notifications.Size = New System.Drawing.Size(778, 217)
        Me.GroupBoxTaskSettings_Notifications.TabIndex = 4
        Me.GroupBoxTaskSettings_Notifications.Text = "Notifications"
        '
        'NumericInputTaskSettings_Upcoming_EndDays
        '
        Me.NumericInputTaskSettings_Upcoming_EndDays.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
        Me.NumericInputTaskSettings_Upcoming_EndDays.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputTaskSettings_Upcoming_EndDays.Location = New System.Drawing.Point(621, 31)
        Me.NumericInputTaskSettings_Upcoming_EndDays.Name = "NumericInputTaskSettings_Upcoming_EndDays"
        Me.NumericInputTaskSettings_Upcoming_EndDays.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NumericInputTaskSettings_Upcoming_EndDays.Properties.DisplayFormat.FormatString = "f0"
        Me.NumericInputTaskSettings_Upcoming_EndDays.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputTaskSettings_Upcoming_EndDays.Properties.EditFormat.FormatString = "f0"
        Me.NumericInputTaskSettings_Upcoming_EndDays.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputTaskSettings_Upcoming_EndDays.Properties.IsFloatValue = False
        Me.NumericInputTaskSettings_Upcoming_EndDays.Properties.Mask.EditMask = "f0"
        Me.NumericInputTaskSettings_Upcoming_EndDays.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NumericInputTaskSettings_Upcoming_EndDays.Properties.MaxLength = 11
        Me.NumericInputTaskSettings_Upcoming_EndDays.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NumericInputTaskSettings_Upcoming_EndDays.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
        Me.NumericInputTaskSettings_Upcoming_EndDays.Size = New System.Drawing.Size(49, 20)
        Me.NumericInputTaskSettings_Upcoming_EndDays.TabIndex = 4
        '
        'NumericInputTaskSettings_Upcoming_StartDays
        '
        Me.NumericInputTaskSettings_Upcoming_StartDays.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
        Me.NumericInputTaskSettings_Upcoming_StartDays.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputTaskSettings_Upcoming_StartDays.Location = New System.Drawing.Point(540, 31)
        Me.NumericInputTaskSettings_Upcoming_StartDays.Name = "NumericInputTaskSettings_Upcoming_StartDays"
        Me.NumericInputTaskSettings_Upcoming_StartDays.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NumericInputTaskSettings_Upcoming_StartDays.Properties.DisplayFormat.FormatString = "f0"
        Me.NumericInputTaskSettings_Upcoming_StartDays.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputTaskSettings_Upcoming_StartDays.Properties.EditFormat.FormatString = "f0"
        Me.NumericInputTaskSettings_Upcoming_StartDays.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputTaskSettings_Upcoming_StartDays.Properties.IsFloatValue = False
        Me.NumericInputTaskSettings_Upcoming_StartDays.Properties.Mask.EditMask = "f0"
        Me.NumericInputTaskSettings_Upcoming_StartDays.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NumericInputTaskSettings_Upcoming_StartDays.Properties.MaxLength = 11
        Me.NumericInputTaskSettings_Upcoming_StartDays.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NumericInputTaskSettings_Upcoming_StartDays.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
        Me.NumericInputTaskSettings_Upcoming_StartDays.Size = New System.Drawing.Size(49, 20)
        Me.NumericInputTaskSettings_Upcoming_StartDays.TabIndex = 3
        '
        'LabelTaskSettings_Upcoming_Between
        '
        Me.LabelTaskSettings_Upcoming_Between.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelTaskSettings_Upcoming_Between.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelTaskSettings_Upcoming_Between.Location = New System.Drawing.Point(488, 31)
        Me.LabelTaskSettings_Upcoming_Between.Name = "LabelTaskSettings_Upcoming_Between"
        Me.LabelTaskSettings_Upcoming_Between.Size = New System.Drawing.Size(46, 20)
        Me.LabelTaskSettings_Upcoming_Between.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelTaskSettings_Upcoming_Between.TabIndex = 2
        Me.LabelTaskSettings_Upcoming_Between.Text = "Between"
        '
        'LabelTaskSettings_Upcoming_Days
        '
        Me.LabelTaskSettings_Upcoming_Days.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelTaskSettings_Upcoming_Days.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelTaskSettings_Upcoming_Days.Location = New System.Drawing.Point(676, 31)
        Me.LabelTaskSettings_Upcoming_Days.Name = "LabelTaskSettings_Upcoming_Days"
        Me.LabelTaskSettings_Upcoming_Days.Size = New System.Drawing.Size(95, 20)
        Me.LabelTaskSettings_Upcoming_Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelTaskSettings_Upcoming_Days.TabIndex = 6
        Me.LabelTaskSettings_Upcoming_Days.Text = "Days From Today"
        '
        'LabelTaskSettings_Upcoming_And
        '
        Me.LabelTaskSettings_Upcoming_And.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelTaskSettings_Upcoming_And.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelTaskSettings_Upcoming_And.Location = New System.Drawing.Point(595, 31)
        Me.LabelTaskSettings_Upcoming_And.Name = "LabelTaskSettings_Upcoming_And"
        Me.LabelTaskSettings_Upcoming_And.Size = New System.Drawing.Size(20, 20)
        Me.LabelTaskSettings_Upcoming_And.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelTaskSettings_Upcoming_And.TabIndex = 5
        Me.LabelTaskSettings_Upcoming_And.Text = "And"
        '
        'LabelTaskSettings_Upcoming_CustomMessage
        '
        Me.LabelTaskSettings_Upcoming_CustomMessage.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelTaskSettings_Upcoming_CustomMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelTaskSettings_Upcoming_CustomMessage.Location = New System.Drawing.Point(391, 54)
        Me.LabelTaskSettings_Upcoming_CustomMessage.Name = "LabelTaskSettings_Upcoming_CustomMessage"
        Me.LabelTaskSettings_Upcoming_CustomMessage.Size = New System.Drawing.Size(98, 20)
        Me.LabelTaskSettings_Upcoming_CustomMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelTaskSettings_Upcoming_CustomMessage.TabIndex = 9
        Me.LabelTaskSettings_Upcoming_CustomMessage.Text = "Custom Message"
        '
        'LabelTaskSettings_PastDue_CustomMessage
        '
        Me.LabelTaskSettings_PastDue_CustomMessage.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelTaskSettings_PastDue_CustomMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelTaskSettings_PastDue_CustomMessage.Location = New System.Drawing.Point(5, 54)
        Me.LabelTaskSettings_PastDue_CustomMessage.Name = "LabelTaskSettings_PastDue_CustomMessage"
        Me.LabelTaskSettings_PastDue_CustomMessage.Size = New System.Drawing.Size(98, 20)
        Me.LabelTaskSettings_PastDue_CustomMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelTaskSettings_PastDue_CustomMessage.TabIndex = 7
        Me.LabelTaskSettings_PastDue_CustomMessage.Text = "Custom Message"
        '
        'TextBoxTaskSettings_Upcoming_CustomMessage
        '
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.Border.Class = "TextBoxBorder"
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.CheckSpellingOnValidate = False
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.FocusHighlightEnabled = True
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.ForeColor = System.Drawing.Color.Black
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.Location = New System.Drawing.Point(391, 80)
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.MaxFileSize = CType(0, Long)
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.MaxLength = 250
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.Multiline = True
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.Name = "TextBoxTaskSettings_Upcoming_CustomMessage"
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.ShowSpellCheckCompleteMessage = True
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.Size = New System.Drawing.Size(380, 132)
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.TabIndex = 10
        Me.TextBoxTaskSettings_Upcoming_CustomMessage.TabOnEnter = True
        '
        'TextBoxTaskSettings_PastDue_CustomMessage
        '
        Me.TextBoxTaskSettings_PastDue_CustomMessage.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxTaskSettings_PastDue_CustomMessage.Border.Class = "TextBoxBorder"
        Me.TextBoxTaskSettings_PastDue_CustomMessage.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxTaskSettings_PastDue_CustomMessage.CheckSpellingOnValidate = False
        Me.TextBoxTaskSettings_PastDue_CustomMessage.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxTaskSettings_PastDue_CustomMessage.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxTaskSettings_PastDue_CustomMessage.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxTaskSettings_PastDue_CustomMessage.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxTaskSettings_PastDue_CustomMessage.FocusHighlightEnabled = True
        Me.TextBoxTaskSettings_PastDue_CustomMessage.ForeColor = System.Drawing.Color.Black
        Me.TextBoxTaskSettings_PastDue_CustomMessage.Location = New System.Drawing.Point(5, 80)
        Me.TextBoxTaskSettings_PastDue_CustomMessage.MaxFileSize = CType(0, Long)
        Me.TextBoxTaskSettings_PastDue_CustomMessage.MaxLength = 250
        Me.TextBoxTaskSettings_PastDue_CustomMessage.Multiline = True
        Me.TextBoxTaskSettings_PastDue_CustomMessage.Name = "TextBoxTaskSettings_PastDue_CustomMessage"
        Me.TextBoxTaskSettings_PastDue_CustomMessage.ShowSpellCheckCompleteMessage = True
        Me.TextBoxTaskSettings_PastDue_CustomMessage.Size = New System.Drawing.Size(380, 132)
        Me.TextBoxTaskSettings_PastDue_CustomMessage.TabIndex = 8
        Me.TextBoxTaskSettings_PastDue_CustomMessage.TabOnEnter = True
        '
        'CheckBoxTaskSettings_Upcoming
        '
        '
        '
        '
        Me.CheckBoxTaskSettings_Upcoming.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxTaskSettings_Upcoming.CheckValue = 0
        Me.CheckBoxTaskSettings_Upcoming.CheckValueChecked = 1
        Me.CheckBoxTaskSettings_Upcoming.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxTaskSettings_Upcoming.CheckValueUnchecked = 0
        Me.CheckBoxTaskSettings_Upcoming.ChildControls = CType(resources.GetObject("CheckBoxTaskSettings_Upcoming.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxTaskSettings_Upcoming.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxTaskSettings_Upcoming.Location = New System.Drawing.Point(391, 28)
        Me.CheckBoxTaskSettings_Upcoming.Name = "CheckBoxTaskSettings_Upcoming"
        Me.CheckBoxTaskSettings_Upcoming.OldestSibling = Nothing
        Me.CheckBoxTaskSettings_Upcoming.SecurityEnabled = True
        Me.CheckBoxTaskSettings_Upcoming.SiblingControls = CType(resources.GetObject("CheckBoxTaskSettings_Upcoming.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxTaskSettings_Upcoming.Size = New System.Drawing.Size(75, 23)
        Me.CheckBoxTaskSettings_Upcoming.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxTaskSettings_Upcoming.TabIndex = 1
        Me.CheckBoxTaskSettings_Upcoming.Text = "Upcoming"
        '
        'CheckBoxTaskSettings_PastDue
        '
        '
        '
        '
        Me.CheckBoxTaskSettings_PastDue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxTaskSettings_PastDue.CheckValue = 0
        Me.CheckBoxTaskSettings_PastDue.CheckValueChecked = 1
        Me.CheckBoxTaskSettings_PastDue.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxTaskSettings_PastDue.CheckValueUnchecked = 0
        Me.CheckBoxTaskSettings_PastDue.ChildControls = CType(resources.GetObject("CheckBoxTaskSettings_PastDue.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxTaskSettings_PastDue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxTaskSettings_PastDue.Location = New System.Drawing.Point(5, 28)
        Me.CheckBoxTaskSettings_PastDue.Name = "CheckBoxTaskSettings_PastDue"
        Me.CheckBoxTaskSettings_PastDue.OldestSibling = Nothing
        Me.CheckBoxTaskSettings_PastDue.SecurityEnabled = True
        Me.CheckBoxTaskSettings_PastDue.SiblingControls = CType(resources.GetObject("CheckBoxTaskSettings_PastDue.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxTaskSettings_PastDue.Size = New System.Drawing.Size(75, 23)
        Me.CheckBoxTaskSettings_PastDue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxTaskSettings_PastDue.TabIndex = 0
        Me.CheckBoxTaskSettings_PastDue.Text = "Past Due"
        '
        'LabelTaskSettings_RunDay
        '
        Me.LabelTaskSettings_RunDay.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelTaskSettings_RunDay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelTaskSettings_RunDay.Location = New System.Drawing.Point(4, 30)
        Me.LabelTaskSettings_RunDay.Name = "LabelTaskSettings_RunDay"
        Me.LabelTaskSettings_RunDay.Size = New System.Drawing.Size(75, 20)
        Me.LabelTaskSettings_RunDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelTaskSettings_RunDay.TabIndex = 2
        Me.LabelTaskSettings_RunDay.Text = "Run Day:"
        '
        'LabelTaskSettings_RunAt
        '
        Me.LabelTaskSettings_RunAt.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelTaskSettings_RunAt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelTaskSettings_RunAt.Location = New System.Drawing.Point(4, 4)
        Me.LabelTaskSettings_RunAt.Name = "LabelTaskSettings_RunAt"
        Me.LabelTaskSettings_RunAt.Size = New System.Drawing.Size(75, 20)
        Me.LabelTaskSettings_RunAt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelTaskSettings_RunAt.TabIndex = 0
        Me.LabelTaskSettings_RunAt.Text = "Run At:"
        '
        'TabItemTaskSettings_SettingsTab
        '
        Me.TabItemTaskSettings_SettingsTab.AttachedControl = Me.TabControlPanelSettingsTab_TaskSettings
        Me.TabItemTaskSettings_SettingsTab.Name = "TabItemTaskSettings_SettingsTab"
        Me.TabItemTaskSettings_SettingsTab.Text = "Settings"
        '
        'TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles
        '
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.ButtonTaskDatabaseProfiles_ProcessNow)
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.ButtonTaskDatabaseProfiles_Select)
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.ButtonTaskDatabaseProfiles_Edit)
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.ButtonTaskDatabaseProfiles_Remove)
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.DataGridViewTaskDatabaseProfiles_Databases)
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.Name = "TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles"
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.Size = New System.Drawing.Size(826, 272)
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.Style.GradientAngle = 90
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.TabIndex = 2
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.TabItem = Me.TabItemTaskSettings_DatabaseProfilesTab
        '
        'ButtonTaskDatabaseProfiles_ProcessNow
        '
        Me.ButtonTaskDatabaseProfiles_ProcessNow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonTaskDatabaseProfiles_ProcessNow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonTaskDatabaseProfiles_ProcessNow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonTaskDatabaseProfiles_ProcessNow.Location = New System.Drawing.Point(4, 248)
        Me.ButtonTaskDatabaseProfiles_ProcessNow.Name = "ButtonTaskDatabaseProfiles_ProcessNow"
        Me.ButtonTaskDatabaseProfiles_ProcessNow.SecurityEnabled = True
        Me.ButtonTaskDatabaseProfiles_ProcessNow.Size = New System.Drawing.Size(75, 20)
        Me.ButtonTaskDatabaseProfiles_ProcessNow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonTaskDatabaseProfiles_ProcessNow.TabIndex = 6
        Me.ButtonTaskDatabaseProfiles_ProcessNow.Text = "Process Now"
        '
        'ButtonTaskDatabaseProfiles_Select
        '
        Me.ButtonTaskDatabaseProfiles_Select.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonTaskDatabaseProfiles_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonTaskDatabaseProfiles_Select.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonTaskDatabaseProfiles_Select.Location = New System.Drawing.Point(585, 248)
        Me.ButtonTaskDatabaseProfiles_Select.Name = "ButtonTaskDatabaseProfiles_Select"
        Me.ButtonTaskDatabaseProfiles_Select.SecurityEnabled = True
        Me.ButtonTaskDatabaseProfiles_Select.Size = New System.Drawing.Size(75, 20)
        Me.ButtonTaskDatabaseProfiles_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonTaskDatabaseProfiles_Select.TabIndex = 7
        Me.ButtonTaskDatabaseProfiles_Select.Text = "Select"
        '
        'ButtonTaskDatabaseProfiles_Edit
        '
        Me.ButtonTaskDatabaseProfiles_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonTaskDatabaseProfiles_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonTaskDatabaseProfiles_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonTaskDatabaseProfiles_Edit.Location = New System.Drawing.Point(666, 248)
        Me.ButtonTaskDatabaseProfiles_Edit.Name = "ButtonTaskDatabaseProfiles_Edit"
        Me.ButtonTaskDatabaseProfiles_Edit.SecurityEnabled = True
        Me.ButtonTaskDatabaseProfiles_Edit.Size = New System.Drawing.Size(75, 20)
        Me.ButtonTaskDatabaseProfiles_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonTaskDatabaseProfiles_Edit.TabIndex = 9
        Me.ButtonTaskDatabaseProfiles_Edit.Text = "Edit"
        '
        'ButtonTaskDatabaseProfiles_Remove
        '
        Me.ButtonTaskDatabaseProfiles_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonTaskDatabaseProfiles_Remove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonTaskDatabaseProfiles_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonTaskDatabaseProfiles_Remove.Location = New System.Drawing.Point(747, 248)
        Me.ButtonTaskDatabaseProfiles_Remove.Name = "ButtonTaskDatabaseProfiles_Remove"
        Me.ButtonTaskDatabaseProfiles_Remove.SecurityEnabled = True
        Me.ButtonTaskDatabaseProfiles_Remove.Size = New System.Drawing.Size(75, 20)
        Me.ButtonTaskDatabaseProfiles_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonTaskDatabaseProfiles_Remove.TabIndex = 9
        Me.ButtonTaskDatabaseProfiles_Remove.Text = "Remove"
        '
        'DataGridViewTaskDatabaseProfiles_Databases
        '
        Me.DataGridViewTaskDatabaseProfiles_Databases.AllowSelectGroupHeaderRow = True
        Me.DataGridViewTaskDatabaseProfiles_Databases.AlwaysForceShowRowSelectionOnUserInput = True
        Me.DataGridViewTaskDatabaseProfiles_Databases.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewTaskDatabaseProfiles_Databases.AutoFilterLookupColumns = False
        Me.DataGridViewTaskDatabaseProfiles_Databases.AutoloadRepositoryDatasource = True
        Me.DataGridViewTaskDatabaseProfiles_Databases.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.DatabaseProfile
        Me.DataGridViewTaskDatabaseProfiles_Databases.DataSource = Nothing
        Me.DataGridViewTaskDatabaseProfiles_Databases.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
        Me.DataGridViewTaskDatabaseProfiles_Databases.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.DataGridViewTaskDatabaseProfiles_Databases.ItemDescription = "Item(s)"
        Me.DataGridViewTaskDatabaseProfiles_Databases.Location = New System.Drawing.Point(4, 4)
        Me.DataGridViewTaskDatabaseProfiles_Databases.MultiSelect = True
        Me.DataGridViewTaskDatabaseProfiles_Databases.Name = "DataGridViewTaskDatabaseProfiles_Databases"
        Me.DataGridViewTaskDatabaseProfiles_Databases.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        Me.DataGridViewTaskDatabaseProfiles_Databases.RunStandardValidation = True
        Me.DataGridViewTaskDatabaseProfiles_Databases.ShowSelectDeselectAllButtons = False
        Me.DataGridViewTaskDatabaseProfiles_Databases.Size = New System.Drawing.Size(818, 238)
        Me.DataGridViewTaskDatabaseProfiles_Databases.TabIndex = 5
        Me.DataGridViewTaskDatabaseProfiles_Databases.UseEmbeddedNavigator = False
        Me.DataGridViewTaskDatabaseProfiles_Databases.ViewCaptionHeight = -1
        '
        'TabItemTaskSettings_DatabaseProfilesTab
        '
        Me.TabItemTaskSettings_DatabaseProfilesTab.AttachedControl = Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles
        Me.TabItemTaskSettings_DatabaseProfilesTab.Name = "TabItemTaskSettings_DatabaseProfilesTab"
        Me.TabItemTaskSettings_DatabaseProfilesTab.Text = "Database Profiles"
        '
        'TabControlPanelLogTab_TaskLog
        '
        Me.TabControlPanelLogTab_TaskLog.Controls.Add(Me.TextBoxTaskLog_Log)
        Me.TabControlPanelLogTab_TaskLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelLogTab_TaskLog.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelLogTab_TaskLog.Name = "TabControlPanelLogTab_TaskLog"
        Me.TabControlPanelLogTab_TaskLog.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelLogTab_TaskLog.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelLogTab_TaskLog.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelLogTab_TaskLog.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelLogTab_TaskLog.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelLogTab_TaskLog.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelLogTab_TaskLog.Style.GradientAngle = 90
        Me.TabControlPanelLogTab_TaskLog.TabIndex = 3
        Me.TabControlPanelLogTab_TaskLog.TabItem = Me.TabItemTaskSettings_LogTab
        '
        'TextBoxTaskLog_Log
        '
        Me.TextBoxTaskLog_Log.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxTaskLog_Log.Border.Class = "TextBoxBorder"
        Me.TextBoxTaskLog_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxTaskLog_Log.CheckSpellingOnValidate = False
        Me.TextBoxTaskLog_Log.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxTaskLog_Log.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxTaskLog_Log.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxTaskLog_Log.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxTaskLog_Log.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxTaskLog_Log.FocusHighlightEnabled = True
        Me.TextBoxTaskLog_Log.ForeColor = System.Drawing.Color.Black
        Me.TextBoxTaskLog_Log.Location = New System.Drawing.Point(1, 1)
        Me.TextBoxTaskLog_Log.MaxFileSize = CType(0, Long)
        Me.TextBoxTaskLog_Log.Multiline = True
        Me.TextBoxTaskLog_Log.Name = "TextBoxTaskLog_Log"
        Me.TextBoxTaskLog_Log.ReadOnly = True
        Me.TextBoxTaskLog_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxTaskLog_Log.ShowSpellCheckCompleteMessage = True
        Me.TextBoxTaskLog_Log.Size = New System.Drawing.Size(824, 265)
        Me.TextBoxTaskLog_Log.TabIndex = 6
        Me.TextBoxTaskLog_Log.TabOnEnter = True
        '
        'TabItemTaskSettings_LogTab
        '
        Me.TabItemTaskSettings_LogTab.AttachedControl = Me.TabControlPanelLogTab_TaskLog
        Me.TabItemTaskSettings_LogTab.Name = "TabItemTaskSettings_LogTab"
        Me.TabItemTaskSettings_LogTab.Text = "Log"
        '
        'ButtonTask_Stop
        '
        Me.ButtonTask_Stop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonTask_Stop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonTask_Stop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonTask_Stop.Location = New System.Drawing.Point(763, 4)
        Me.ButtonTask_Stop.Name = "ButtonTask_Stop"
        Me.ButtonTask_Stop.SecurityEnabled = True
        Me.ButtonTask_Stop.Size = New System.Drawing.Size(75, 20)
        Me.ButtonTask_Stop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonTask_Stop.TabIndex = 8
        Me.ButtonTask_Stop.Text = "Stop"
        Me.ButtonTask_Stop.Visible = False
        '
        'LabelTask_StatusDescription
        '
        Me.LabelTask_StatusDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelTask_StatusDescription.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelTask_StatusDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelTask_StatusDescription.Location = New System.Drawing.Point(58, 4)
        Me.LabelTask_StatusDescription.Name = "LabelTask_StatusDescription"
        Me.LabelTask_StatusDescription.Size = New System.Drawing.Size(613, 20)
        Me.LabelTask_StatusDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelTask_StatusDescription.TabIndex = 6
        Me.LabelTask_StatusDescription.Text = "Stopped..."
        '
        'LabelTask_Status
        '
        Me.LabelTask_Status.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelTask_Status.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelTask_Status.Location = New System.Drawing.Point(12, 4)
        Me.LabelTask_Status.Name = "LabelTask_Status"
        Me.LabelTask_Status.Size = New System.Drawing.Size(40, 20)
        Me.LabelTask_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelTask_Status.TabIndex = 5
        Me.LabelTask_Status.Text = "Status:"
        '
        'ButtonTask_Start
        '
        Me.ButtonTask_Start.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonTask_Start.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonTask_Start.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonTask_Start.Location = New System.Drawing.Point(763, 4)
        Me.ButtonTask_Start.Name = "ButtonTask_Start"
        Me.ButtonTask_Start.SecurityEnabled = True
        Me.ButtonTask_Start.Size = New System.Drawing.Size(75, 20)
        Me.ButtonTask_Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonTask_Start.TabIndex = 7
        Me.ButtonTask_Start.Text = "Start"
        '
        'TabItemServices_TasksTab
        '
        Me.TabItemServices_TasksTab.AttachedControl = Me.TabControlPanelTasks_Tasks
        Me.TabItemServices_TasksTab.Name = "TabItemServices_TasksTab"
        Me.TabItemServices_TasksTab.Text = "Tasks"
        '
        'TabControlPanelExport_Export
        '
        Me.TabControlPanelExport_Export.Controls.Add(Me.CheckBoxExport_AutoStart)
        Me.TabControlPanelExport_Export.Controls.Add(Me.ButtonExport_Stop)
        Me.TabControlPanelExport_Export.Controls.Add(Me.TabControlExport_Settings)
        Me.TabControlPanelExport_Export.Controls.Add(Me.LabelExport_StatusDescription)
        Me.TabControlPanelExport_Export.Controls.Add(Me.LabelExport_Status)
        Me.TabControlPanelExport_Export.Controls.Add(Me.ButtonExport_Start)
        Me.TabControlPanelExport_Export.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelExport_Export.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelExport_Export.Name = "TabControlPanelExport_Export"
        Me.TabControlPanelExport_Export.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelExport_Export.Size = New System.Drawing.Size(850, 336)
        Me.TabControlPanelExport_Export.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelExport_Export.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelExport_Export.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelExport_Export.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelExport_Export.Style.GradientAngle = 90
        Me.TabControlPanelExport_Export.TabIndex = 3
        Me.TabControlPanelExport_Export.TabItem = Me.TabItemServices_ExportTab
        '
        'CheckBoxExport_AutoStart
        '
        Me.CheckBoxExport_AutoStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxExport_AutoStart.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.CheckBoxExport_AutoStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxExport_AutoStart.CheckValue = 0
        Me.CheckBoxExport_AutoStart.CheckValueChecked = 1
        Me.CheckBoxExport_AutoStart.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxExport_AutoStart.CheckValueUnchecked = 0
        Me.CheckBoxExport_AutoStart.ChildControls = CType(resources.GetObject("CheckBoxExport_AutoStart.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxExport_AutoStart.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxExport_AutoStart.Location = New System.Drawing.Point(677, 4)
        Me.CheckBoxExport_AutoStart.Name = "CheckBoxExport_AutoStart"
        Me.CheckBoxExport_AutoStart.OldestSibling = Nothing
        Me.CheckBoxExport_AutoStart.SecurityEnabled = True
        Me.CheckBoxExport_AutoStart.SiblingControls = CType(resources.GetObject("CheckBoxExport_AutoStart.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxExport_AutoStart.Size = New System.Drawing.Size(80, 20)
        Me.CheckBoxExport_AutoStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxExport_AutoStart.TabIndex = 11
        Me.CheckBoxExport_AutoStart.Text = "Auto Start"
        '
        'ButtonExport_Stop
        '
        Me.ButtonExport_Stop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonExport_Stop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonExport_Stop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonExport_Stop.Location = New System.Drawing.Point(763, 4)
        Me.ButtonExport_Stop.Name = "ButtonExport_Stop"
        Me.ButtonExport_Stop.SecurityEnabled = True
        Me.ButtonExport_Stop.Size = New System.Drawing.Size(75, 20)
        Me.ButtonExport_Stop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonExport_Stop.TabIndex = 4
        Me.ButtonExport_Stop.Text = "Stop"
        Me.ButtonExport_Stop.Visible = False
        '
        'TabControlExport_Settings
        '
        Me.TabControlExport_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlExport_Settings.BackColor = System.Drawing.Color.White
        Me.TabControlExport_Settings.CanReorderTabs = False
        Me.TabControlExport_Settings.Controls.Add(Me.TabControlPanelSettingsTab_ExportSettings)
        Me.TabControlExport_Settings.Controls.Add(Me.TabControlPanelCriteriaTab_ExportCriteria)
        Me.TabControlExport_Settings.Controls.Add(Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles)
        Me.TabControlExport_Settings.Controls.Add(Me.TabControlPanelLogTab_ExportLog)
        Me.TabControlExport_Settings.ForeColor = System.Drawing.Color.Black
        Me.TabControlExport_Settings.Location = New System.Drawing.Point(12, 30)
        Me.TabControlExport_Settings.Name = "TabControlExport_Settings"
        Me.TabControlExport_Settings.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControlExport_Settings.SelectedTabIndex = 0
        Me.TabControlExport_Settings.Size = New System.Drawing.Size(826, 294)
        Me.TabControlExport_Settings.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControlExport_Settings.TabIndex = 5
        Me.TabControlExport_Settings.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControlExport_Settings.Tabs.Add(Me.TabItemExportSettings_SettingsTab)
        Me.TabControlExport_Settings.Tabs.Add(Me.TabItemExportSettings_CriteriaTab)
        Me.TabControlExport_Settings.Tabs.Add(Me.TabItemExportSettings_DatabaseProfilesTab)
        Me.TabControlExport_Settings.Tabs.Add(Me.TabItemExportSettings_LogTab)
        '
        'TabControlPanelSettingsTab_ExportSettings
        '
        Me.TabControlPanelSettingsTab_ExportSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPanelSettingsTab_ExportSettings.Controls.Add(Me.GroupBoxExportSettings_Data)
        Me.TabControlPanelSettingsTab_ExportSettings.Controls.Add(Me.LabelExportSettings_Path)
        Me.TabControlPanelSettingsTab_ExportSettings.Controls.Add(Me.LabelExportSettings_RunAt)
        Me.TabControlPanelSettingsTab_ExportSettings.Controls.Add(Me.DateTimeInputExportSettings_RunAt)
        Me.TabControlPanelSettingsTab_ExportSettings.Controls.Add(Me.TextBoxExportSettings_ExportPath)
        Me.TabControlPanelSettingsTab_ExportSettings.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanelSettingsTab_ExportSettings.Name = "TabControlPanelSettingsTab_ExportSettings"
        Me.TabControlPanelSettingsTab_ExportSettings.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelSettingsTab_ExportSettings.Size = New System.Drawing.Size(826, 272)
        Me.TabControlPanelSettingsTab_ExportSettings.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelSettingsTab_ExportSettings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelSettingsTab_ExportSettings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelSettingsTab_ExportSettings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelSettingsTab_ExportSettings.Style.GradientAngle = 90
        Me.TabControlPanelSettingsTab_ExportSettings.TabIndex = 1
        Me.TabControlPanelSettingsTab_ExportSettings.TabItem = Me.TabItemExportSettings_SettingsTab
        '
        'GroupBoxExportSettings_Data
        '
        Me.GroupBoxExportSettings_Data.Controls.Add(Me.LabelExportSettings_DataTo)
        Me.GroupBoxExportSettings_Data.Controls.Add(Me.RadioButtonExportSettings_DataFrom)
        Me.GroupBoxExportSettings_Data.Controls.Add(Me.RadioButtonExportSettings_TodaysData)
        Me.GroupBoxExportSettings_Data.Controls.Add(Me.RadioButtonExportSettings_AllData)
        Me.GroupBoxExportSettings_Data.Controls.Add(Me.DateTimePickerExportSettings_DataEnd)
        Me.GroupBoxExportSettings_Data.Controls.Add(Me.DateTimePickerExportSettings_DataStart)
        Me.GroupBoxExportSettings_Data.Location = New System.Drawing.Point(4, 73)
        Me.GroupBoxExportSettings_Data.Name = "GroupBoxExportSettings_Data"
        Me.GroupBoxExportSettings_Data.Size = New System.Drawing.Size(279, 106)
        Me.GroupBoxExportSettings_Data.TabIndex = 10
        Me.GroupBoxExportSettings_Data.Text = "Selected Data"
        '
        'LabelExportSettings_DataTo
        '
        Me.LabelExportSettings_DataTo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelExportSettings_DataTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelExportSettings_DataTo.Location = New System.Drawing.Point(166, 71)
        Me.LabelExportSettings_DataTo.Name = "LabelExportSettings_DataTo"
        Me.LabelExportSettings_DataTo.Size = New System.Drawing.Size(18, 20)
        Me.LabelExportSettings_DataTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelExportSettings_DataTo.TabIndex = 11
        Me.LabelExportSettings_DataTo.Text = "To"
        '
        'RadioButtonExportSettings_DataFrom
        '
        Me.RadioButtonExportSettings_DataFrom.AutoSize = True
        Me.RadioButtonExportSettings_DataFrom.Location = New System.Drawing.Point(5, 71)
        Me.RadioButtonExportSettings_DataFrom.Name = "RadioButtonExportSettings_DataFrom"
        Me.RadioButtonExportSettings_DataFrom.Size = New System.Drawing.Size(74, 17)
        Me.RadioButtonExportSettings_DataFrom.TabIndex = 13
        Me.RadioButtonExportSettings_DataFrom.TabStop = True
        Me.RadioButtonExportSettings_DataFrom.Text = "Data From"
        Me.RadioButtonExportSettings_DataFrom.UseVisualStyleBackColor = True
        '
        'RadioButtonExportSettings_TodaysData
        '
        Me.RadioButtonExportSettings_TodaysData.AutoSize = True
        Me.RadioButtonExportSettings_TodaysData.Location = New System.Drawing.Point(5, 48)
        Me.RadioButtonExportSettings_TodaysData.Name = "RadioButtonExportSettings_TodaysData"
        Me.RadioButtonExportSettings_TodaysData.Size = New System.Drawing.Size(88, 17)
        Me.RadioButtonExportSettings_TodaysData.TabIndex = 12
        Me.RadioButtonExportSettings_TodaysData.TabStop = True
        Me.RadioButtonExportSettings_TodaysData.Text = "Today's Data"
        Me.RadioButtonExportSettings_TodaysData.UseVisualStyleBackColor = True
        '
        'RadioButtonExportSettings_AllData
        '
        Me.RadioButtonExportSettings_AllData.AutoSize = True
        Me.RadioButtonExportSettings_AllData.Location = New System.Drawing.Point(5, 25)
        Me.RadioButtonExportSettings_AllData.Name = "RadioButtonExportSettings_AllData"
        Me.RadioButtonExportSettings_AllData.Size = New System.Drawing.Size(62, 17)
        Me.RadioButtonExportSettings_AllData.TabIndex = 11
        Me.RadioButtonExportSettings_AllData.TabStop = True
        Me.RadioButtonExportSettings_AllData.Text = "All Data"
        Me.RadioButtonExportSettings_AllData.UseVisualStyleBackColor = True
        '
        'DateTimePickerExportSettings_DataEnd
        '
        Me.DateTimePickerExportSettings_DataEnd.AutoResolveFreeTextEntries = False
        '
        '
        '
        Me.DateTimePickerExportSettings_DataEnd.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DateTimePickerExportSettings_DataEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimePickerExportSettings_DataEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DateTimePickerExportSettings_DataEnd.ButtonFreeText.Checked = True
        Me.DateTimePickerExportSettings_DataEnd.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
        Me.DateTimePickerExportSettings_DataEnd.CustomFormat = ""
        Me.DateTimePickerExportSettings_DataEnd.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
        Me.DateTimePickerExportSettings_DataEnd.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.DateTimePickerExportSettings_DataEnd.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.DateTimePickerExportSettings_DataEnd.FocusHighlightEnabled = True
        Me.DateTimePickerExportSettings_DataEnd.Format = DevComponents.Editors.eDateTimePickerFormat.Short
        Me.DateTimePickerExportSettings_DataEnd.FreeTextEntryMode = True
        Me.DateTimePickerExportSettings_DataEnd.IsPopupCalendarOpen = False
        Me.DateTimePickerExportSettings_DataEnd.Location = New System.Drawing.Point(190, 71)
        Me.DateTimePickerExportSettings_DataEnd.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.DisplayMonth = New Date(2011, 8, 1, 0, 0, 0, 0)
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.TodayButtonVisible = True
        Me.DateTimePickerExportSettings_DataEnd.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DateTimePickerExportSettings_DataEnd.Name = "DateTimePickerExportSettings_DataEnd"
        Me.DateTimePickerExportSettings_DataEnd.ReadOnly = False
        Me.DateTimePickerExportSettings_DataEnd.Size = New System.Drawing.Size(75, 20)
        Me.DateTimePickerExportSettings_DataEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DateTimePickerExportSettings_DataEnd.TabIndex = 15
        Me.DateTimePickerExportSettings_DataEnd.Value = New Date(2011, 8, 12, 10, 30, 8, 738)
        '
        'DateTimePickerExportSettings_DataStart
        '
        Me.DateTimePickerExportSettings_DataStart.AutoResolveFreeTextEntries = False
        '
        '
        '
        Me.DateTimePickerExportSettings_DataStart.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DateTimePickerExportSettings_DataStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimePickerExportSettings_DataStart.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DateTimePickerExportSettings_DataStart.ButtonFreeText.Checked = True
        Me.DateTimePickerExportSettings_DataStart.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
        Me.DateTimePickerExportSettings_DataStart.CustomFormat = ""
        Me.DateTimePickerExportSettings_DataStart.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
        Me.DateTimePickerExportSettings_DataStart.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.DateTimePickerExportSettings_DataStart.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.DateTimePickerExportSettings_DataStart.FocusHighlightEnabled = True
        Me.DateTimePickerExportSettings_DataStart.Format = DevComponents.Editors.eDateTimePickerFormat.Short
        Me.DateTimePickerExportSettings_DataStart.FreeTextEntryMode = True
        Me.DateTimePickerExportSettings_DataStart.IsPopupCalendarOpen = False
        Me.DateTimePickerExportSettings_DataStart.Location = New System.Drawing.Point(85, 71)
        Me.DateTimePickerExportSettings_DataStart.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.DisplayMonth = New Date(2011, 8, 1, 0, 0, 0, 0)
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.TodayButtonVisible = True
        Me.DateTimePickerExportSettings_DataStart.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DateTimePickerExportSettings_DataStart.Name = "DateTimePickerExportSettings_DataStart"
        Me.DateTimePickerExportSettings_DataStart.ReadOnly = False
        Me.DateTimePickerExportSettings_DataStart.Size = New System.Drawing.Size(75, 20)
        Me.DateTimePickerExportSettings_DataStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DateTimePickerExportSettings_DataStart.TabIndex = 14
        Me.DateTimePickerExportSettings_DataStart.Value = New Date(2011, 8, 12, 10, 30, 2, 588)
        '
        'LabelExportSettings_Path
        '
        Me.LabelExportSettings_Path.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelExportSettings_Path.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelExportSettings_Path.Location = New System.Drawing.Point(4, 30)
        Me.LabelExportSettings_Path.Name = "LabelExportSettings_Path"
        Me.LabelExportSettings_Path.Size = New System.Drawing.Size(75, 20)
        Me.LabelExportSettings_Path.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelExportSettings_Path.TabIndex = 7
        Me.LabelExportSettings_Path.Text = "Export Path:"
        '
        'LabelExportSettings_RunAt
        '
        Me.LabelExportSettings_RunAt.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelExportSettings_RunAt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelExportSettings_RunAt.Location = New System.Drawing.Point(4, 4)
        Me.LabelExportSettings_RunAt.Name = "LabelExportSettings_RunAt"
        Me.LabelExportSettings_RunAt.Size = New System.Drawing.Size(75, 20)
        Me.LabelExportSettings_RunAt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelExportSettings_RunAt.TabIndex = 5
        Me.LabelExportSettings_RunAt.Text = "Run At (Daily):"
        '
        'DateTimeInputExportSettings_RunAt
        '
        Me.DateTimeInputExportSettings_RunAt.AllowEmptyState = False
        Me.DateTimeInputExportSettings_RunAt.AutoResolveFreeTextEntries = False
        '
        '
        '
        Me.DateTimeInputExportSettings_RunAt.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DateTimeInputExportSettings_RunAt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputExportSettings_RunAt.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DateTimeInputExportSettings_RunAt.ButtonDropDown.Visible = True
        Me.DateTimeInputExportSettings_RunAt.ButtonFreeText.Checked = True
        Me.DateTimeInputExportSettings_RunAt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
        Me.DateTimeInputExportSettings_RunAt.CustomFormat = ""
        Me.DateTimeInputExportSettings_RunAt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.DateTimeInputExportSettings_RunAt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.DateTimeInputExportSettings_RunAt.FocusHighlightEnabled = True
        Me.DateTimeInputExportSettings_RunAt.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.DateTimeInputExportSettings_RunAt.FreeTextEntryMode = True
        Me.DateTimeInputExportSettings_RunAt.IsPopupCalendarOpen = False
        Me.DateTimeInputExportSettings_RunAt.Location = New System.Drawing.Point(85, 4)
        Me.DateTimeInputExportSettings_RunAt.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.DisplayMonth = New Date(2011, 6, 1, 0, 0, 0, 0)
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.TodayButtonVisible = True
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.Visible = False
        Me.DateTimeInputExportSettings_RunAt.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DateTimeInputExportSettings_RunAt.Name = "DateTimeInputExportSettings_RunAt"
        Me.DateTimeInputExportSettings_RunAt.ReadOnly = False
        Me.DateTimeInputExportSettings_RunAt.Size = New System.Drawing.Size(88, 20)
        Me.DateTimeInputExportSettings_RunAt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DateTimeInputExportSettings_RunAt.TabIndex = 6
        Me.DateTimeInputExportSettings_RunAt.Value = New Date(2011, 10, 14, 11, 54, 41, 2)
        '
        'TextBoxExportSettings_ExportPath
        '
        Me.TextBoxExportSettings_ExportPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxExportSettings_ExportPath.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxExportSettings_ExportPath.Border.Class = "TextBoxBorder"
        Me.TextBoxExportSettings_ExportPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxExportSettings_ExportPath.ButtonCustom.Visible = True
        Me.TextBoxExportSettings_ExportPath.CheckSpellingOnValidate = False
        Me.TextBoxExportSettings_ExportPath.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
        Me.TextBoxExportSettings_ExportPath.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxExportSettings_ExportPath.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxExportSettings_ExportPath.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxExportSettings_ExportPath.FocusHighlightEnabled = True
        Me.TextBoxExportSettings_ExportPath.ForeColor = System.Drawing.Color.Black
        Me.TextBoxExportSettings_ExportPath.Location = New System.Drawing.Point(85, 30)
        Me.TextBoxExportSettings_ExportPath.MaxFileSize = CType(0, Long)
        Me.TextBoxExportSettings_ExportPath.Name = "TextBoxExportSettings_ExportPath"
        Me.TextBoxExportSettings_ExportPath.ShowSpellCheckCompleteMessage = True
        Me.TextBoxExportSettings_ExportPath.Size = New System.Drawing.Size(737, 20)
        Me.TextBoxExportSettings_ExportPath.TabIndex = 8
        Me.TextBoxExportSettings_ExportPath.TabOnEnter = True
        '
        'TabItemExportSettings_SettingsTab
        '
        Me.TabItemExportSettings_SettingsTab.AttachedControl = Me.TabControlPanelSettingsTab_ExportSettings
        Me.TabItemExportSettings_SettingsTab.Name = "TabItemExportSettings_SettingsTab"
        Me.TabItemExportSettings_SettingsTab.Text = "Settings"
        '
        'TabControlPanelCriteriaTab_ExportCriteria
        '
        Me.TabControlPanelCriteriaTab_ExportCriteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPanelCriteriaTab_ExportCriteria.Controls.Add(Me.GroupBoxExportCriteria_SelectedCampaigns)
        Me.TabControlPanelCriteriaTab_ExportCriteria.Controls.Add(Me.LabelExportCriteria_DatabaseProfile)
        Me.TabControlPanelCriteriaTab_ExportCriteria.Controls.Add(Me.ComboBoxExportCriteria_DatabaseProfiles)
        Me.TabControlPanelCriteriaTab_ExportCriteria.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanelCriteriaTab_ExportCriteria.Name = "TabControlPanelCriteriaTab_ExportCriteria"
        Me.TabControlPanelCriteriaTab_ExportCriteria.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelCriteriaTab_ExportCriteria.Size = New System.Drawing.Size(826, 272)
        Me.TabControlPanelCriteriaTab_ExportCriteria.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelCriteriaTab_ExportCriteria.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelCriteriaTab_ExportCriteria.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelCriteriaTab_ExportCriteria.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelCriteriaTab_ExportCriteria.Style.GradientAngle = 90
        Me.TabControlPanelCriteriaTab_ExportCriteria.TabIndex = 4
        Me.TabControlPanelCriteriaTab_ExportCriteria.TabItem = Me.TabItemExportSettings_CriteriaTab
        '
        'GroupBoxExportCriteria_SelectedCampaigns
        '
        Me.GroupBoxExportCriteria_SelectedCampaigns.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxExportCriteria_SelectedCampaigns.Controls.Add(Me.ButtonExportCriteriaCampaign_RemoveAll)
        Me.GroupBoxExportCriteria_SelectedCampaigns.Controls.Add(Me.ButtonExportCriteriaCampaign_AddAll)
        Me.GroupBoxExportCriteria_SelectedCampaigns.Controls.Add(Me.ButtonExportCriteriaCampaign_RemoveSelected)
        Me.GroupBoxExportCriteria_SelectedCampaigns.Controls.Add(Me.DataGridViewExportCriteria_SelectedCampaigns)
        Me.GroupBoxExportCriteria_SelectedCampaigns.Controls.Add(Me.LabelExportCriteria_Client)
        Me.GroupBoxExportCriteria_SelectedCampaigns.Controls.Add(Me.ComboBoxExportCriteria_Clients)
        Me.GroupBoxExportCriteria_SelectedCampaigns.Controls.Add(Me.DataGridViewExportCriteria_Campaigns)
        Me.GroupBoxExportCriteria_SelectedCampaigns.Controls.Add(Me.ButtonExportCriteriaCampaign_AddSelected)
        Me.GroupBoxExportCriteria_SelectedCampaigns.Location = New System.Drawing.Point(9, 30)
        Me.GroupBoxExportCriteria_SelectedCampaigns.Name = "GroupBoxExportCriteria_SelectedCampaigns"
        Me.GroupBoxExportCriteria_SelectedCampaigns.Size = New System.Drawing.Size(808, 233)
        Me.GroupBoxExportCriteria_SelectedCampaigns.TabIndex = 7
        Me.GroupBoxExportCriteria_SelectedCampaigns.Text = "Selected Campaigns"
        '
        'ButtonExportCriteriaCampaign_RemoveAll
        '
        Me.ButtonExportCriteriaCampaign_RemoveAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonExportCriteriaCampaign_RemoveAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonExportCriteriaCampaign_RemoveAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonExportCriteriaCampaign_RemoveAll.Location = New System.Drawing.Point(728, 77)
        Me.ButtonExportCriteriaCampaign_RemoveAll.Name = "ButtonExportCriteriaCampaign_RemoveAll"
        Me.ButtonExportCriteriaCampaign_RemoveAll.SecurityEnabled = True
        Me.ButtonExportCriteriaCampaign_RemoveAll.Size = New System.Drawing.Size(75, 20)
        Me.ButtonExportCriteriaCampaign_RemoveAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonExportCriteriaCampaign_RemoveAll.TabIndex = 18
        Me.ButtonExportCriteriaCampaign_RemoveAll.Text = "Remove All"
        '
        'ButtonExportCriteriaCampaign_AddAll
        '
        Me.ButtonExportCriteriaCampaign_AddAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonExportCriteriaCampaign_AddAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonExportCriteriaCampaign_AddAll.Location = New System.Drawing.Point(311, 78)
        Me.ButtonExportCriteriaCampaign_AddAll.Name = "ButtonExportCriteriaCampaign_AddAll"
        Me.ButtonExportCriteriaCampaign_AddAll.SecurityEnabled = True
        Me.ButtonExportCriteriaCampaign_AddAll.Size = New System.Drawing.Size(75, 20)
        Me.ButtonExportCriteriaCampaign_AddAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonExportCriteriaCampaign_AddAll.TabIndex = 12
        Me.ButtonExportCriteriaCampaign_AddAll.Text = "-->>"
        '
        'ButtonExportCriteriaCampaign_RemoveSelected
        '
        Me.ButtonExportCriteriaCampaign_RemoveSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonExportCriteriaCampaign_RemoveSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonExportCriteriaCampaign_RemoveSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonExportCriteriaCampaign_RemoveSelected.Location = New System.Drawing.Point(728, 51)
        Me.ButtonExportCriteriaCampaign_RemoveSelected.Name = "ButtonExportCriteriaCampaign_RemoveSelected"
        Me.ButtonExportCriteriaCampaign_RemoveSelected.SecurityEnabled = True
        Me.ButtonExportCriteriaCampaign_RemoveSelected.Size = New System.Drawing.Size(75, 20)
        Me.ButtonExportCriteriaCampaign_RemoveSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonExportCriteriaCampaign_RemoveSelected.TabIndex = 14
        Me.ButtonExportCriteriaCampaign_RemoveSelected.Text = "Remove"
        '
        'DataGridViewExportCriteria_SelectedCampaigns
        '
        Me.DataGridViewExportCriteria_SelectedCampaigns.AllowSelectGroupHeaderRow = True
        Me.DataGridViewExportCriteria_SelectedCampaigns.AlwaysForceShowRowSelectionOnUserInput = True
        Me.DataGridViewExportCriteria_SelectedCampaigns.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewExportCriteria_SelectedCampaigns.AutoFilterLookupColumns = False
        Me.DataGridViewExportCriteria_SelectedCampaigns.AutoloadRepositoryDatasource = True
        Me.DataGridViewExportCriteria_SelectedCampaigns.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
        Me.DataGridViewExportCriteria_SelectedCampaigns.DataSource = Nothing
        Me.DataGridViewExportCriteria_SelectedCampaigns.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
        Me.DataGridViewExportCriteria_SelectedCampaigns.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.DataGridViewExportCriteria_SelectedCampaigns.ItemDescription = ""
        Me.DataGridViewExportCriteria_SelectedCampaigns.Location = New System.Drawing.Point(392, 51)
        Me.DataGridViewExportCriteria_SelectedCampaigns.MultiSelect = True
        Me.DataGridViewExportCriteria_SelectedCampaigns.Name = "DataGridViewExportCriteria_SelectedCampaigns"
        Me.DataGridViewExportCriteria_SelectedCampaigns.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        Me.DataGridViewExportCriteria_SelectedCampaigns.RunStandardValidation = True
        Me.DataGridViewExportCriteria_SelectedCampaigns.ShowSelectDeselectAllButtons = False
        Me.DataGridViewExportCriteria_SelectedCampaigns.Size = New System.Drawing.Size(330, 176)
        Me.DataGridViewExportCriteria_SelectedCampaigns.TabIndex = 13
        Me.DataGridViewExportCriteria_SelectedCampaigns.UseEmbeddedNavigator = False
        Me.DataGridViewExportCriteria_SelectedCampaigns.ViewCaptionHeight = -1
        '
        'LabelExportCriteria_Client
        '
        Me.LabelExportCriteria_Client.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelExportCriteria_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelExportCriteria_Client.Location = New System.Drawing.Point(5, 26)
        Me.LabelExportCriteria_Client.Name = "LabelExportCriteria_Client"
        Me.LabelExportCriteria_Client.Size = New System.Drawing.Size(37, 20)
        Me.LabelExportCriteria_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelExportCriteria_Client.TabIndex = 8
        Me.LabelExportCriteria_Client.Text = "Client:"
        '
        'ComboBoxExportCriteria_Clients
        '
        Me.ComboBoxExportCriteria_Clients.AddInactiveItemsOnSelectedValue = False
        Me.ComboBoxExportCriteria_Clients.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxExportCriteria_Clients.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxExportCriteria_Clients.AutoFindItemInDataSource = False
        Me.ComboBoxExportCriteria_Clients.AutoSelectSingleItemDatasource = False
        Me.ComboBoxExportCriteria_Clients.BookmarkingEnabled = False
        Me.ComboBoxExportCriteria_Clients.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Client
        Me.ComboBoxExportCriteria_Clients.DisableMouseWheel = False
        Me.ComboBoxExportCriteria_Clients.DisplayMember = "Name"
        Me.ComboBoxExportCriteria_Clients.DisplayName = ""
        Me.ComboBoxExportCriteria_Clients.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxExportCriteria_Clients.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.ComboBoxExportCriteria_Clients.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
        Me.ComboBoxExportCriteria_Clients.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.ComboBoxExportCriteria_Clients.FocusHighlightEnabled = True
        Me.ComboBoxExportCriteria_Clients.FormattingEnabled = True
        Me.ComboBoxExportCriteria_Clients.ItemHeight = 14
        Me.ComboBoxExportCriteria_Clients.Location = New System.Drawing.Point(48, 26)
        Me.ComboBoxExportCriteria_Clients.Name = "ComboBoxExportCriteria_Clients"
        Me.ComboBoxExportCriteria_Clients.PreventEnterBeep = False
        Me.ComboBoxExportCriteria_Clients.ReadOnly = False
        Me.ComboBoxExportCriteria_Clients.SecurityEnabled = True
        Me.ComboBoxExportCriteria_Clients.Size = New System.Drawing.Size(257, 20)
        Me.ComboBoxExportCriteria_Clients.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxExportCriteria_Clients.TabIndex = 9
        Me.ComboBoxExportCriteria_Clients.ValueMember = "Code"
        Me.ComboBoxExportCriteria_Clients.WatermarkText = "Select Client"
        '
        'DataGridViewExportCriteria_Campaigns
        '
        Me.DataGridViewExportCriteria_Campaigns.AllowSelectGroupHeaderRow = True
        Me.DataGridViewExportCriteria_Campaigns.AlwaysForceShowRowSelectionOnUserInput = True
        Me.DataGridViewExportCriteria_Campaigns.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewExportCriteria_Campaigns.AutoFilterLookupColumns = False
        Me.DataGridViewExportCriteria_Campaigns.AutoloadRepositoryDatasource = True
        Me.DataGridViewExportCriteria_Campaigns.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
        Me.DataGridViewExportCriteria_Campaigns.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
        Me.DataGridViewExportCriteria_Campaigns.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.DataGridViewExportCriteria_Campaigns.ItemDescription = ""
        Me.DataGridViewExportCriteria_Campaigns.Location = New System.Drawing.Point(5, 52)
        Me.DataGridViewExportCriteria_Campaigns.MultiSelect = True
        Me.DataGridViewExportCriteria_Campaigns.Name = "DataGridViewExportCriteria_Campaigns"
        Me.DataGridViewExportCriteria_Campaigns.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        Me.DataGridViewExportCriteria_Campaigns.RunStandardValidation = True
        Me.DataGridViewExportCriteria_Campaigns.ShowSelectDeselectAllButtons = False
        Me.DataGridViewExportCriteria_Campaigns.Size = New System.Drawing.Size(300, 176)
        Me.DataGridViewExportCriteria_Campaigns.TabIndex = 10
        Me.DataGridViewExportCriteria_Campaigns.UseEmbeddedNavigator = False
        Me.DataGridViewExportCriteria_Campaigns.ViewCaptionHeight = -1
        '
        'ButtonExportCriteriaCampaign_AddSelected
        '
        Me.ButtonExportCriteriaCampaign_AddSelected.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonExportCriteriaCampaign_AddSelected.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonExportCriteriaCampaign_AddSelected.Location = New System.Drawing.Point(311, 52)
        Me.ButtonExportCriteriaCampaign_AddSelected.Name = "ButtonExportCriteriaCampaign_AddSelected"
        Me.ButtonExportCriteriaCampaign_AddSelected.SecurityEnabled = True
        Me.ButtonExportCriteriaCampaign_AddSelected.Size = New System.Drawing.Size(75, 20)
        Me.ButtonExportCriteriaCampaign_AddSelected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonExportCriteriaCampaign_AddSelected.TabIndex = 11
        Me.ButtonExportCriteriaCampaign_AddSelected.Text = "-->"
        '
        'LabelExportCriteria_DatabaseProfile
        '
        Me.LabelExportCriteria_DatabaseProfile.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelExportCriteria_DatabaseProfile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelExportCriteria_DatabaseProfile.Location = New System.Drawing.Point(9, 4)
        Me.LabelExportCriteria_DatabaseProfile.Name = "LabelExportCriteria_DatabaseProfile"
        Me.LabelExportCriteria_DatabaseProfile.Size = New System.Drawing.Size(90, 20)
        Me.LabelExportCriteria_DatabaseProfile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelExportCriteria_DatabaseProfile.TabIndex = 5
        Me.LabelExportCriteria_DatabaseProfile.Text = "Database Profile:"
        '
        'ComboBoxExportCriteria_DatabaseProfiles
        '
        Me.ComboBoxExportCriteria_DatabaseProfiles.AddInactiveItemsOnSelectedValue = False
        Me.ComboBoxExportCriteria_DatabaseProfiles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxExportCriteria_DatabaseProfiles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxExportCriteria_DatabaseProfiles.AutoFindItemInDataSource = False
        Me.ComboBoxExportCriteria_DatabaseProfiles.AutoSelectSingleItemDatasource = False
        Me.ComboBoxExportCriteria_DatabaseProfiles.BookmarkingEnabled = False
        Me.ComboBoxExportCriteria_DatabaseProfiles.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.DatabaseProfile
        Me.ComboBoxExportCriteria_DatabaseProfiles.DisableMouseWheel = False
        Me.ComboBoxExportCriteria_DatabaseProfiles.DisplayMember = "Name"
        Me.ComboBoxExportCriteria_DatabaseProfiles.DisplayName = ""
        Me.ComboBoxExportCriteria_DatabaseProfiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxExportCriteria_DatabaseProfiles.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.ComboBoxExportCriteria_DatabaseProfiles.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
        Me.ComboBoxExportCriteria_DatabaseProfiles.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.ComboBoxExportCriteria_DatabaseProfiles.FocusHighlightEnabled = True
        Me.ComboBoxExportCriteria_DatabaseProfiles.FormattingEnabled = True
        Me.ComboBoxExportCriteria_DatabaseProfiles.ItemHeight = 14
        Me.ComboBoxExportCriteria_DatabaseProfiles.Location = New System.Drawing.Point(105, 4)
        Me.ComboBoxExportCriteria_DatabaseProfiles.Name = "ComboBoxExportCriteria_DatabaseProfiles"
        Me.ComboBoxExportCriteria_DatabaseProfiles.PreventEnterBeep = False
        Me.ComboBoxExportCriteria_DatabaseProfiles.ReadOnly = False
        Me.ComboBoxExportCriteria_DatabaseProfiles.SecurityEnabled = True
        Me.ComboBoxExportCriteria_DatabaseProfiles.Size = New System.Drawing.Size(180, 20)
        Me.ComboBoxExportCriteria_DatabaseProfiles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxExportCriteria_DatabaseProfiles.TabIndex = 6
        Me.ComboBoxExportCriteria_DatabaseProfiles.ValueMember = "ConnectionString"
        Me.ComboBoxExportCriteria_DatabaseProfiles.WatermarkText = "Select Database Profile"
        '
        'TabItemExportSettings_CriteriaTab
        '
        Me.TabItemExportSettings_CriteriaTab.AttachedControl = Me.TabControlPanelCriteriaTab_ExportCriteria
        Me.TabItemExportSettings_CriteriaTab.Name = "TabItemExportSettings_CriteriaTab"
        Me.TabItemExportSettings_CriteriaTab.Text = "Criteria"
        '
        'TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles
        '
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.ButtonExportDatabaseProfiles_ProcessNow)
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.ButtonExportDatabaseProfiles_Select)
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.ButtonExportDatabaseProfiles_Edit)
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.ButtonExportDatabaseProfiles_Remove)
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.Controls.Add(Me.DataGridViewExportDatabaseProfiles_Databases)
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.Name = "TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles"
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.Size = New System.Drawing.Size(826, 272)
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.Style.GradientAngle = 90
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.TabIndex = 2
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.TabItem = Me.TabItemExportSettings_DatabaseProfilesTab
        '
        'ButtonExportDatabaseProfiles_ProcessNow
        '
        Me.ButtonExportDatabaseProfiles_ProcessNow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonExportDatabaseProfiles_ProcessNow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonExportDatabaseProfiles_ProcessNow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonExportDatabaseProfiles_ProcessNow.Location = New System.Drawing.Point(4, 248)
        Me.ButtonExportDatabaseProfiles_ProcessNow.Name = "ButtonExportDatabaseProfiles_ProcessNow"
        Me.ButtonExportDatabaseProfiles_ProcessNow.SecurityEnabled = True
        Me.ButtonExportDatabaseProfiles_ProcessNow.Size = New System.Drawing.Size(75, 20)
        Me.ButtonExportDatabaseProfiles_ProcessNow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonExportDatabaseProfiles_ProcessNow.TabIndex = 6
        Me.ButtonExportDatabaseProfiles_ProcessNow.Text = "Process Now"
        '
        'ButtonExportDatabaseProfiles_Select
        '
        Me.ButtonExportDatabaseProfiles_Select.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonExportDatabaseProfiles_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonExportDatabaseProfiles_Select.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonExportDatabaseProfiles_Select.Location = New System.Drawing.Point(585, 248)
        Me.ButtonExportDatabaseProfiles_Select.Name = "ButtonExportDatabaseProfiles_Select"
        Me.ButtonExportDatabaseProfiles_Select.SecurityEnabled = True
        Me.ButtonExportDatabaseProfiles_Select.Size = New System.Drawing.Size(75, 20)
        Me.ButtonExportDatabaseProfiles_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonExportDatabaseProfiles_Select.TabIndex = 7
        Me.ButtonExportDatabaseProfiles_Select.Text = "Select"
        '
        'ButtonExportDatabaseProfiles_Edit
        '
        Me.ButtonExportDatabaseProfiles_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonExportDatabaseProfiles_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonExportDatabaseProfiles_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonExportDatabaseProfiles_Edit.Location = New System.Drawing.Point(666, 248)
        Me.ButtonExportDatabaseProfiles_Edit.Name = "ButtonExportDatabaseProfiles_Edit"
        Me.ButtonExportDatabaseProfiles_Edit.SecurityEnabled = True
        Me.ButtonExportDatabaseProfiles_Edit.Size = New System.Drawing.Size(75, 20)
        Me.ButtonExportDatabaseProfiles_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonExportDatabaseProfiles_Edit.TabIndex = 9
        Me.ButtonExportDatabaseProfiles_Edit.Text = "Edit"
        '
        'ButtonExportDatabaseProfiles_Remove
        '
        Me.ButtonExportDatabaseProfiles_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonExportDatabaseProfiles_Remove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonExportDatabaseProfiles_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonExportDatabaseProfiles_Remove.Location = New System.Drawing.Point(747, 248)
        Me.ButtonExportDatabaseProfiles_Remove.Name = "ButtonExportDatabaseProfiles_Remove"
        Me.ButtonExportDatabaseProfiles_Remove.SecurityEnabled = True
        Me.ButtonExportDatabaseProfiles_Remove.Size = New System.Drawing.Size(75, 20)
        Me.ButtonExportDatabaseProfiles_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonExportDatabaseProfiles_Remove.TabIndex = 9
        Me.ButtonExportDatabaseProfiles_Remove.Text = "Remove"
        '
        'DataGridViewExportDatabaseProfiles_Databases
        '
        Me.DataGridViewExportDatabaseProfiles_Databases.AllowSelectGroupHeaderRow = True
        Me.DataGridViewExportDatabaseProfiles_Databases.AlwaysForceShowRowSelectionOnUserInput = True
        Me.DataGridViewExportDatabaseProfiles_Databases.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewExportDatabaseProfiles_Databases.AutoFilterLookupColumns = False
        Me.DataGridViewExportDatabaseProfiles_Databases.AutoloadRepositoryDatasource = True
        Me.DataGridViewExportDatabaseProfiles_Databases.BackColor = System.Drawing.SystemColors.Control
        Me.DataGridViewExportDatabaseProfiles_Databases.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.DatabaseProfile
        Me.DataGridViewExportDatabaseProfiles_Databases.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
        Me.DataGridViewExportDatabaseProfiles_Databases.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.DataGridViewExportDatabaseProfiles_Databases.ItemDescription = "Item(s)"
        Me.DataGridViewExportDatabaseProfiles_Databases.Location = New System.Drawing.Point(4, 4)
        Me.DataGridViewExportDatabaseProfiles_Databases.MultiSelect = True
        Me.DataGridViewExportDatabaseProfiles_Databases.Name = "DataGridViewExportDatabaseProfiles_Databases"
        Me.DataGridViewExportDatabaseProfiles_Databases.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        Me.DataGridViewExportDatabaseProfiles_Databases.RunStandardValidation = True
        Me.DataGridViewExportDatabaseProfiles_Databases.ShowSelectDeselectAllButtons = False
        Me.DataGridViewExportDatabaseProfiles_Databases.Size = New System.Drawing.Size(818, 238)
        Me.DataGridViewExportDatabaseProfiles_Databases.TabIndex = 5
        Me.DataGridViewExportDatabaseProfiles_Databases.UseEmbeddedNavigator = False
        Me.DataGridViewExportDatabaseProfiles_Databases.ViewCaptionHeight = -1
        '
        'TabItemExportSettings_DatabaseProfilesTab
        '
        Me.TabItemExportSettings_DatabaseProfilesTab.AttachedControl = Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles
        Me.TabItemExportSettings_DatabaseProfilesTab.Name = "TabItemExportSettings_DatabaseProfilesTab"
        Me.TabItemExportSettings_DatabaseProfilesTab.Text = "Database Profiles"
        '
        'TabControlPanelLogTab_ExportLog
        '
        Me.TabControlPanelLogTab_ExportLog.Controls.Add(Me.TextBoxExportLog_Log)
        Me.TabControlPanelLogTab_ExportLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelLogTab_ExportLog.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelLogTab_ExportLog.Name = "TabControlPanelLogTab_ExportLog"
        Me.TabControlPanelLogTab_ExportLog.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelLogTab_ExportLog.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelLogTab_ExportLog.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelLogTab_ExportLog.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelLogTab_ExportLog.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelLogTab_ExportLog.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelLogTab_ExportLog.Style.GradientAngle = 90
        Me.TabControlPanelLogTab_ExportLog.TabIndex = 3
        Me.TabControlPanelLogTab_ExportLog.TabItem = Me.TabItemExportSettings_LogTab
        '
        'TextBoxExportLog_Log
        '
        Me.TextBoxExportLog_Log.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxExportLog_Log.Border.Class = "TextBoxBorder"
        Me.TextBoxExportLog_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxExportLog_Log.CheckSpellingOnValidate = False
        Me.TextBoxExportLog_Log.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxExportLog_Log.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxExportLog_Log.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxExportLog_Log.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxExportLog_Log.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxExportLog_Log.FocusHighlightEnabled = True
        Me.TextBoxExportLog_Log.ForeColor = System.Drawing.Color.Black
        Me.TextBoxExportLog_Log.Location = New System.Drawing.Point(1, 1)
        Me.TextBoxExportLog_Log.MaxFileSize = CType(0, Long)
        Me.TextBoxExportLog_Log.Multiline = True
        Me.TextBoxExportLog_Log.Name = "TextBoxExportLog_Log"
        Me.TextBoxExportLog_Log.ReadOnly = True
        Me.TextBoxExportLog_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxExportLog_Log.ShowSpellCheckCompleteMessage = True
        Me.TextBoxExportLog_Log.Size = New System.Drawing.Size(824, 265)
        Me.TextBoxExportLog_Log.TabIndex = 5
        Me.TextBoxExportLog_Log.TabOnEnter = True
        '
        'TabItemExportSettings_LogTab
        '
        Me.TabItemExportSettings_LogTab.AttachedControl = Me.TabControlPanelLogTab_ExportLog
        Me.TabItemExportSettings_LogTab.Name = "TabItemExportSettings_LogTab"
        Me.TabItemExportSettings_LogTab.Text = "Log"
        '
        'LabelExport_StatusDescription
        '
        Me.LabelExport_StatusDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelExport_StatusDescription.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelExport_StatusDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelExport_StatusDescription.Location = New System.Drawing.Point(58, 4)
        Me.LabelExport_StatusDescription.Name = "LabelExport_StatusDescription"
        Me.LabelExport_StatusDescription.Size = New System.Drawing.Size(613, 20)
        Me.LabelExport_StatusDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelExport_StatusDescription.TabIndex = 2
        Me.LabelExport_StatusDescription.Text = "Stopped..."
        '
        'LabelExport_Status
        '
        Me.LabelExport_Status.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelExport_Status.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelExport_Status.Location = New System.Drawing.Point(12, 4)
        Me.LabelExport_Status.Name = "LabelExport_Status"
        Me.LabelExport_Status.Size = New System.Drawing.Size(40, 20)
        Me.LabelExport_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelExport_Status.TabIndex = 1
        Me.LabelExport_Status.Text = "Status:"
        '
        'ButtonExport_Start
        '
        Me.ButtonExport_Start.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonExport_Start.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonExport_Start.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonExport_Start.Location = New System.Drawing.Point(763, 4)
        Me.ButtonExport_Start.Name = "ButtonExport_Start"
        Me.ButtonExport_Start.SecurityEnabled = True
        Me.ButtonExport_Start.Size = New System.Drawing.Size(75, 20)
        Me.ButtonExport_Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonExport_Start.TabIndex = 3
        Me.ButtonExport_Start.Text = "Start"
        '
        'TabItemServices_ExportTab
        '
        Me.TabItemServices_ExportTab.AttachedControl = Me.TabControlPanelExport_Export
        Me.TabItemServices_ExportTab.Name = "TabItemServices_ExportTab"
        Me.TabItemServices_ExportTab.Text = "Media Export"
        '
        'TabControlPanelQvAAlertTab_QvAAlert
        '
        Me.TabControlPanelQvAAlertTab_QvAAlert.Controls.Add(Me.ButtonQvA_Stop)
        Me.TabControlPanelQvAAlertTab_QvAAlert.Controls.Add(Me.CheckBoxQvA_AutoStart)
        Me.TabControlPanelQvAAlertTab_QvAAlert.Controls.Add(Me.LabelQvAAlert_StatusDescription)
        Me.TabControlPanelQvAAlertTab_QvAAlert.Controls.Add(Me.LabelQvAAlert_Status)
        Me.TabControlPanelQvAAlertTab_QvAAlert.Controls.Add(Me.TabControlQvAAlert_Settings)
        Me.TabControlPanelQvAAlertTab_QvAAlert.Controls.Add(Me.ButtonQvA_Start)
        Me.TabControlPanelQvAAlertTab_QvAAlert.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelQvAAlertTab_QvAAlert.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelQvAAlertTab_QvAAlert.Name = "TabControlPanelQvAAlertTab_QvAAlert"
        Me.TabControlPanelQvAAlertTab_QvAAlert.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelQvAAlertTab_QvAAlert.Size = New System.Drawing.Size(850, 336)
        Me.TabControlPanelQvAAlertTab_QvAAlert.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelQvAAlertTab_QvAAlert.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelQvAAlertTab_QvAAlert.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelQvAAlertTab_QvAAlert.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelQvAAlertTab_QvAAlert.Style.GradientAngle = 90
        Me.TabControlPanelQvAAlertTab_QvAAlert.TabIndex = 2
        Me.TabControlPanelQvAAlertTab_QvAAlert.TabItem = Me.TabItemServices_QvAAlertTab
        '
        'ButtonQvA_Stop
        '
        Me.ButtonQvA_Stop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonQvA_Stop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonQvA_Stop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonQvA_Stop.Location = New System.Drawing.Point(763, 4)
        Me.ButtonQvA_Stop.Name = "ButtonQvA_Stop"
        Me.ButtonQvA_Stop.SecurityEnabled = True
        Me.ButtonQvA_Stop.Size = New System.Drawing.Size(75, 20)
        Me.ButtonQvA_Stop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonQvA_Stop.TabIndex = 13
        Me.ButtonQvA_Stop.Text = "Stop"
        Me.ButtonQvA_Stop.Visible = False
        '
        'CheckBoxQvA_AutoStart
        '
        Me.CheckBoxQvA_AutoStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxQvA_AutoStart.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.CheckBoxQvA_AutoStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxQvA_AutoStart.CheckValue = 0
        Me.CheckBoxQvA_AutoStart.CheckValueChecked = 1
        Me.CheckBoxQvA_AutoStart.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxQvA_AutoStart.CheckValueUnchecked = 0
        Me.CheckBoxQvA_AutoStart.ChildControls = CType(resources.GetObject("CheckBoxQvA_AutoStart.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxQvA_AutoStart.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxQvA_AutoStart.Location = New System.Drawing.Point(677, 4)
        Me.CheckBoxQvA_AutoStart.Name = "CheckBoxQvA_AutoStart"
        Me.CheckBoxQvA_AutoStart.OldestSibling = Nothing
        Me.CheckBoxQvA_AutoStart.SecurityEnabled = True
        Me.CheckBoxQvA_AutoStart.SiblingControls = CType(resources.GetObject("CheckBoxQvA_AutoStart.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxQvA_AutoStart.Size = New System.Drawing.Size(80, 20)
        Me.CheckBoxQvA_AutoStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxQvA_AutoStart.TabIndex = 12
        Me.CheckBoxQvA_AutoStart.Text = "Auto Start"
        '
        'LabelQvAAlert_StatusDescription
        '
        Me.LabelQvAAlert_StatusDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelQvAAlert_StatusDescription.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelQvAAlert_StatusDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelQvAAlert_StatusDescription.Location = New System.Drawing.Point(58, 4)
        Me.LabelQvAAlert_StatusDescription.Name = "LabelQvAAlert_StatusDescription"
        Me.LabelQvAAlert_StatusDescription.Size = New System.Drawing.Size(613, 20)
        Me.LabelQvAAlert_StatusDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelQvAAlert_StatusDescription.TabIndex = 10
        Me.LabelQvAAlert_StatusDescription.Text = "Stopped..."
        '
        'LabelQvAAlert_Status
        '
        Me.LabelQvAAlert_Status.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelQvAAlert_Status.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelQvAAlert_Status.Location = New System.Drawing.Point(12, 4)
        Me.LabelQvAAlert_Status.Name = "LabelQvAAlert_Status"
        Me.LabelQvAAlert_Status.Size = New System.Drawing.Size(40, 20)
        Me.LabelQvAAlert_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelQvAAlert_Status.TabIndex = 9
        Me.LabelQvAAlert_Status.Text = "Status:"
        '
        'TabControlQvAAlert_Settings
        '
        Me.TabControlQvAAlert_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlQvAAlert_Settings.BackColor = System.Drawing.Color.White
        Me.TabControlQvAAlert_Settings.CanReorderTabs = False
        Me.TabControlQvAAlert_Settings.Controls.Add(Me.TabControlPanelQvAAlertSettings_QvAAlertSettings)
        Me.TabControlQvAAlert_Settings.Controls.Add(Me.TabControlPanelQvAAlertLog_QvAAlertLog)
        Me.TabControlQvAAlert_Settings.Controls.Add(Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings)
        Me.TabControlQvAAlert_Settings.ForeColor = System.Drawing.Color.Black
        Me.TabControlQvAAlert_Settings.Location = New System.Drawing.Point(12, 30)
        Me.TabControlQvAAlert_Settings.Name = "TabControlQvAAlert_Settings"
        Me.TabControlQvAAlert_Settings.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControlQvAAlert_Settings.SelectedTabIndex = 0
        Me.TabControlQvAAlert_Settings.Size = New System.Drawing.Size(826, 294)
        Me.TabControlQvAAlert_Settings.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControlQvAAlert_Settings.TabIndex = 8
        Me.TabControlQvAAlert_Settings.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControlQvAAlert_Settings.Tabs.Add(Me.TabItemQvAAlertSettings_SettingsTab)
        Me.TabControlQvAAlert_Settings.Tabs.Add(Me.TabItemQvAAlertSettings_DatabaseProfilesTab)
        Me.TabControlQvAAlert_Settings.Tabs.Add(Me.TabItemQvAAlertSettings_LogTab)
        '
        'TabControlPanelQvAAlertSettings_QvAAlertSettings
        '
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Controls.Add(Me.ComboBoxQvAAlertSettings_ShowLevel)
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Controls.Add(Me.ComboBoxQvAAlertSettings_SetAlertLevel)
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Controls.Add(Me.ComboBoxQvAAlertSettings_SendAlertTo)
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Controls.Add(Me.DateTimeInputQvAAlertSettings_RunAt)
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Controls.Add(Me.LabelQvAAlertSettings_ShowLevel)
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Controls.Add(Me.LabelQvAAlertSettings_SetAlertLevel)
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Controls.Add(Me.GroupBoxQvAAlertSettings_CalculationOptions)
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Controls.Add(Me.GroupBoxQvAAlertSettings_Thresholds)
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Controls.Add(Me.LabelQvAAlertSettings_SendAlertTo)
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Controls.Add(Me.LabelQvAAlertSettings_RunAt)
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Name = "TabControlPanelQvAAlertSettings_QvAAlertSettings"
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.Style.GradientAngle = 90
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.TabIndex = 1
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.TabItem = Me.TabItemQvAAlertSettings_SettingsTab
        '
        'ComboBoxQvAAlertSettings_ShowLevel
        '
        Me.ComboBoxQvAAlertSettings_ShowLevel.AddInactiveItemsOnSelectedValue = False
        Me.ComboBoxQvAAlertSettings_ShowLevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxQvAAlertSettings_ShowLevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxQvAAlertSettings_ShowLevel.AutoFindItemInDataSource = False
        Me.ComboBoxQvAAlertSettings_ShowLevel.AutoSelectSingleItemDatasource = False
        Me.ComboBoxQvAAlertSettings_ShowLevel.BookmarkingEnabled = False
        Me.ComboBoxQvAAlertSettings_ShowLevel.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
        Me.ComboBoxQvAAlertSettings_ShowLevel.DisableMouseWheel = False
        Me.ComboBoxQvAAlertSettings_ShowLevel.DisplayMember = "Value"
        Me.ComboBoxQvAAlertSettings_ShowLevel.DisplayName = ""
        Me.ComboBoxQvAAlertSettings_ShowLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxQvAAlertSettings_ShowLevel.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.ComboBoxQvAAlertSettings_ShowLevel.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
        Me.ComboBoxQvAAlertSettings_ShowLevel.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.ComboBoxQvAAlertSettings_ShowLevel.FocusHighlightEnabled = True
        Me.ComboBoxQvAAlertSettings_ShowLevel.FormattingEnabled = True
        Me.ComboBoxQvAAlertSettings_ShowLevel.ItemHeight = 14
        Me.ComboBoxQvAAlertSettings_ShowLevel.Location = New System.Drawing.Point(544, 4)
        Me.ComboBoxQvAAlertSettings_ShowLevel.Name = "ComboBoxQvAAlertSettings_ShowLevel"
        Me.ComboBoxQvAAlertSettings_ShowLevel.PreventEnterBeep = False
        Me.ComboBoxQvAAlertSettings_ShowLevel.ReadOnly = False
        Me.ComboBoxQvAAlertSettings_ShowLevel.SecurityEnabled = True
        Me.ComboBoxQvAAlertSettings_ShowLevel.Size = New System.Drawing.Size(200, 20)
        Me.ComboBoxQvAAlertSettings_ShowLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxQvAAlertSettings_ShowLevel.TabIndex = 9
        Me.ComboBoxQvAAlertSettings_ShowLevel.ValueMember = "Key"
        Me.ComboBoxQvAAlertSettings_ShowLevel.WatermarkText = "Select Level"
        '
        'ComboBoxQvAAlertSettings_SetAlertLevel
        '
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.AddInactiveItemsOnSelectedValue = False
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.AutoFindItemInDataSource = False
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.AutoSelectSingleItemDatasource = False
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.BookmarkingEnabled = False
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.DisableMouseWheel = False
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.DisplayMember = "Value"
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.DisplayName = ""
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.FocusHighlightEnabled = True
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.FormattingEnabled = True
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.ItemHeight = 14
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.Location = New System.Drawing.Point(263, 30)
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.Name = "ComboBoxQvAAlertSettings_SetAlertLevel"
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.PreventEnterBeep = False
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.ReadOnly = False
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.SecurityEnabled = True
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.Size = New System.Drawing.Size(200, 20)
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.TabIndex = 7
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.ValueMember = "Key"
        Me.ComboBoxQvAAlertSettings_SetAlertLevel.WatermarkText = "Select Set Alert Level"
        '
        'ComboBoxQvAAlertSettings_SendAlertTo
        '
        Me.ComboBoxQvAAlertSettings_SendAlertTo.AddInactiveItemsOnSelectedValue = False
        Me.ComboBoxQvAAlertSettings_SendAlertTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBoxQvAAlertSettings_SendAlertTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxQvAAlertSettings_SendAlertTo.AutoFindItemInDataSource = False
        Me.ComboBoxQvAAlertSettings_SendAlertTo.AutoSelectSingleItemDatasource = False
        Me.ComboBoxQvAAlertSettings_SendAlertTo.BookmarkingEnabled = False
        Me.ComboBoxQvAAlertSettings_SendAlertTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
        Me.ComboBoxQvAAlertSettings_SendAlertTo.DisableMouseWheel = False
        Me.ComboBoxQvAAlertSettings_SendAlertTo.DisplayMember = "Value"
        Me.ComboBoxQvAAlertSettings_SendAlertTo.DisplayName = ""
        Me.ComboBoxQvAAlertSettings_SendAlertTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.ComboBoxQvAAlertSettings_SendAlertTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.ComboBoxQvAAlertSettings_SendAlertTo.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
        Me.ComboBoxQvAAlertSettings_SendAlertTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.ComboBoxQvAAlertSettings_SendAlertTo.FocusHighlightEnabled = True
        Me.ComboBoxQvAAlertSettings_SendAlertTo.FormattingEnabled = True
        Me.ComboBoxQvAAlertSettings_SendAlertTo.ItemHeight = 14
        Me.ComboBoxQvAAlertSettings_SendAlertTo.Location = New System.Drawing.Point(263, 4)
        Me.ComboBoxQvAAlertSettings_SendAlertTo.Name = "ComboBoxQvAAlertSettings_SendAlertTo"
        Me.ComboBoxQvAAlertSettings_SendAlertTo.PreventEnterBeep = False
        Me.ComboBoxQvAAlertSettings_SendAlertTo.ReadOnly = False
        Me.ComboBoxQvAAlertSettings_SendAlertTo.SecurityEnabled = True
        Me.ComboBoxQvAAlertSettings_SendAlertTo.Size = New System.Drawing.Size(200, 20)
        Me.ComboBoxQvAAlertSettings_SendAlertTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboBoxQvAAlertSettings_SendAlertTo.TabIndex = 3
        Me.ComboBoxQvAAlertSettings_SendAlertTo.ValueMember = "Key"
        Me.ComboBoxQvAAlertSettings_SendAlertTo.WatermarkText = "Select Send Alert To"
        '
        'DateTimeInputQvAAlertSettings_RunAt
        '
        Me.DateTimeInputQvAAlertSettings_RunAt.AllowEmptyState = False
        Me.DateTimeInputQvAAlertSettings_RunAt.AutoResolveFreeTextEntries = False
        '
        '
        '
        Me.DateTimeInputQvAAlertSettings_RunAt.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DateTimeInputQvAAlertSettings_RunAt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputQvAAlertSettings_RunAt.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DateTimeInputQvAAlertSettings_RunAt.ButtonDropDown.Visible = True
        Me.DateTimeInputQvAAlertSettings_RunAt.ButtonFreeText.Checked = True
        Me.DateTimeInputQvAAlertSettings_RunAt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
        Me.DateTimeInputQvAAlertSettings_RunAt.CustomFormat = ""
        Me.DateTimeInputQvAAlertSettings_RunAt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.DateTimeInputQvAAlertSettings_RunAt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.DateTimeInputQvAAlertSettings_RunAt.FocusHighlightEnabled = True
        Me.DateTimeInputQvAAlertSettings_RunAt.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.DateTimeInputQvAAlertSettings_RunAt.FreeTextEntryMode = True
        Me.DateTimeInputQvAAlertSettings_RunAt.IsPopupCalendarOpen = False
        Me.DateTimeInputQvAAlertSettings_RunAt.Location = New System.Drawing.Point(87, 4)
        Me.DateTimeInputQvAAlertSettings_RunAt.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.DisplayMonth = New Date(2011, 6, 1, 0, 0, 0, 0)
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.TodayButtonVisible = True
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.Visible = False
        Me.DateTimeInputQvAAlertSettings_RunAt.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DateTimeInputQvAAlertSettings_RunAt.Name = "DateTimeInputQvAAlertSettings_RunAt"
        Me.DateTimeInputQvAAlertSettings_RunAt.ReadOnly = False
        Me.DateTimeInputQvAAlertSettings_RunAt.Size = New System.Drawing.Size(88, 20)
        Me.DateTimeInputQvAAlertSettings_RunAt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DateTimeInputQvAAlertSettings_RunAt.TabIndex = 0
        Me.DateTimeInputQvAAlertSettings_RunAt.Value = New Date(2011, 10, 14, 11, 54, 40, 897)
        '
        'LabelQvAAlertSettings_ShowLevel
        '
        Me.LabelQvAAlertSettings_ShowLevel.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelQvAAlertSettings_ShowLevel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelQvAAlertSettings_ShowLevel.Location = New System.Drawing.Point(474, 4)
        Me.LabelQvAAlertSettings_ShowLevel.Name = "LabelQvAAlertSettings_ShowLevel"
        Me.LabelQvAAlertSettings_ShowLevel.Size = New System.Drawing.Size(64, 20)
        Me.LabelQvAAlertSettings_ShowLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelQvAAlertSettings_ShowLevel.TabIndex = 8
        Me.LabelQvAAlertSettings_ShowLevel.Text = "Show Level:"
        '
        'LabelQvAAlertSettings_SetAlertLevel
        '
        Me.LabelQvAAlertSettings_SetAlertLevel.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelQvAAlertSettings_SetAlertLevel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelQvAAlertSettings_SetAlertLevel.Location = New System.Drawing.Point(181, 30)
        Me.LabelQvAAlertSettings_SetAlertLevel.Name = "LabelQvAAlertSettings_SetAlertLevel"
        Me.LabelQvAAlertSettings_SetAlertLevel.Size = New System.Drawing.Size(76, 20)
        Me.LabelQvAAlertSettings_SetAlertLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelQvAAlertSettings_SetAlertLevel.TabIndex = 6
        Me.LabelQvAAlertSettings_SetAlertLevel.Text = "Set Alert Level:"
        '
        'GroupBoxQvAAlertSettings_CalculationOptions
        '
        Me.GroupBoxQvAAlertSettings_CalculationOptions.Controls.Add(Me.CheckBoxCalculationOptions_IncludeEstimate)
        Me.GroupBoxQvAAlertSettings_CalculationOptions.Controls.Add(Me.CheckBoxCalculationOptions_VendorCharges)
        Me.GroupBoxQvAAlertSettings_CalculationOptions.Controls.Add(Me.CheckBoxCalculationOptions_IncomeOnly)
        Me.GroupBoxQvAAlertSettings_CalculationOptions.Controls.Add(Me.CheckBoxCalculationOptions_Time)
        Me.GroupBoxQvAAlertSettings_CalculationOptions.Location = New System.Drawing.Point(620, 56)
        Me.GroupBoxQvAAlertSettings_CalculationOptions.Name = "GroupBoxQvAAlertSettings_CalculationOptions"
        Me.GroupBoxQvAAlertSettings_CalculationOptions.Size = New System.Drawing.Size(185, 191)
        Me.GroupBoxQvAAlertSettings_CalculationOptions.TabIndex = 5
        Me.GroupBoxQvAAlertSettings_CalculationOptions.Text = "Calculation Options"
        '
        'CheckBoxCalculationOptions_IncludeEstimate
        '
        '
        '
        '
        Me.CheckBoxCalculationOptions_IncludeEstimate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxCalculationOptions_IncludeEstimate.CheckValue = 0
        Me.CheckBoxCalculationOptions_IncludeEstimate.CheckValueChecked = 1
        Me.CheckBoxCalculationOptions_IncludeEstimate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxCalculationOptions_IncludeEstimate.CheckValueUnchecked = 0
        Me.CheckBoxCalculationOptions_IncludeEstimate.ChildControls = CType(resources.GetObject("CheckBoxCalculationOptions_IncludeEstimate.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxCalculationOptions_IncludeEstimate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxCalculationOptions_IncludeEstimate.Location = New System.Drawing.Point(5, 103)
        Me.CheckBoxCalculationOptions_IncludeEstimate.Name = "CheckBoxCalculationOptions_IncludeEstimate"
        Me.CheckBoxCalculationOptions_IncludeEstimate.OldestSibling = Nothing
        Me.CheckBoxCalculationOptions_IncludeEstimate.SecurityEnabled = True
        Me.CheckBoxCalculationOptions_IncludeEstimate.SiblingControls = CType(resources.GetObject("CheckBoxCalculationOptions_IncludeEstimate.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxCalculationOptions_IncludeEstimate.Size = New System.Drawing.Size(167, 20)
        Me.CheckBoxCalculationOptions_IncludeEstimate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxCalculationOptions_IncludeEstimate.TabIndex = 3
        Me.CheckBoxCalculationOptions_IncludeEstimate.Text = "Include Estimate Contingency"
        '
        'CheckBoxCalculationOptions_VendorCharges
        '
        '
        '
        '
        Me.CheckBoxCalculationOptions_VendorCharges.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxCalculationOptions_VendorCharges.CheckValue = 0
        Me.CheckBoxCalculationOptions_VendorCharges.CheckValueChecked = 1
        Me.CheckBoxCalculationOptions_VendorCharges.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxCalculationOptions_VendorCharges.CheckValueUnchecked = 0
        Me.CheckBoxCalculationOptions_VendorCharges.ChildControls = CType(resources.GetObject("CheckBoxCalculationOptions_VendorCharges.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxCalculationOptions_VendorCharges.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxCalculationOptions_VendorCharges.Location = New System.Drawing.Point(5, 77)
        Me.CheckBoxCalculationOptions_VendorCharges.Name = "CheckBoxCalculationOptions_VendorCharges"
        Me.CheckBoxCalculationOptions_VendorCharges.OldestSibling = Nothing
        Me.CheckBoxCalculationOptions_VendorCharges.SecurityEnabled = True
        Me.CheckBoxCalculationOptions_VendorCharges.SiblingControls = CType(resources.GetObject("CheckBoxCalculationOptions_VendorCharges.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxCalculationOptions_VendorCharges.Size = New System.Drawing.Size(167, 20)
        Me.CheckBoxCalculationOptions_VendorCharges.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxCalculationOptions_VendorCharges.TabIndex = 2
        Me.CheckBoxCalculationOptions_VendorCharges.Text = "Vendor Charges"
        '
        'CheckBoxCalculationOptions_IncomeOnly
        '
        '
        '
        '
        Me.CheckBoxCalculationOptions_IncomeOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxCalculationOptions_IncomeOnly.CheckValue = 0
        Me.CheckBoxCalculationOptions_IncomeOnly.CheckValueChecked = 1
        Me.CheckBoxCalculationOptions_IncomeOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxCalculationOptions_IncomeOnly.CheckValueUnchecked = 0
        Me.CheckBoxCalculationOptions_IncomeOnly.ChildControls = CType(resources.GetObject("CheckBoxCalculationOptions_IncomeOnly.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxCalculationOptions_IncomeOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxCalculationOptions_IncomeOnly.Location = New System.Drawing.Point(5, 51)
        Me.CheckBoxCalculationOptions_IncomeOnly.Name = "CheckBoxCalculationOptions_IncomeOnly"
        Me.CheckBoxCalculationOptions_IncomeOnly.OldestSibling = Nothing
        Me.CheckBoxCalculationOptions_IncomeOnly.SecurityEnabled = True
        Me.CheckBoxCalculationOptions_IncomeOnly.SiblingControls = CType(resources.GetObject("CheckBoxCalculationOptions_IncomeOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxCalculationOptions_IncomeOnly.Size = New System.Drawing.Size(167, 20)
        Me.CheckBoxCalculationOptions_IncomeOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxCalculationOptions_IncomeOnly.TabIndex = 1
        Me.CheckBoxCalculationOptions_IncomeOnly.Text = "Income Only"
        '
        'CheckBoxCalculationOptions_Time
        '
        '
        '
        '
        Me.CheckBoxCalculationOptions_Time.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxCalculationOptions_Time.CheckValue = 0
        Me.CheckBoxCalculationOptions_Time.CheckValueChecked = 1
        Me.CheckBoxCalculationOptions_Time.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxCalculationOptions_Time.CheckValueUnchecked = 0
        Me.CheckBoxCalculationOptions_Time.ChildControls = CType(resources.GetObject("CheckBoxCalculationOptions_Time.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxCalculationOptions_Time.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxCalculationOptions_Time.Location = New System.Drawing.Point(5, 25)
        Me.CheckBoxCalculationOptions_Time.Name = "CheckBoxCalculationOptions_Time"
        Me.CheckBoxCalculationOptions_Time.OldestSibling = Nothing
        Me.CheckBoxCalculationOptions_Time.SecurityEnabled = True
        Me.CheckBoxCalculationOptions_Time.SiblingControls = CType(resources.GetObject("CheckBoxCalculationOptions_Time.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxCalculationOptions_Time.Size = New System.Drawing.Size(167, 20)
        Me.CheckBoxCalculationOptions_Time.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxCalculationOptions_Time.TabIndex = 0
        Me.CheckBoxCalculationOptions_Time.Text = "Time"
        '
        'GroupBoxQvAAlertSettings_Thresholds
        '
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.NumericInputThresholds_Level3Start)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.NumericInputThresholds_Level2End)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.NumericInputThresholds_Level2Start)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.NumericInputThresholds_Level1End)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.NumericInputThresholds_Level1Start)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.LabelThresholds_Level3Description)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.TextBoxThresholds_Level3Description)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.LabelThresholds_Level3And)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.CheckBoxThresholds_Level3)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.LabelThresholds_Level2Description)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.TextBoxThresholds_Level2Description)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.LabelThresholds_Level2And)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.LabelThresholds_Level2Between)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.CheckBoxThresholds_Level2)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.LabelThresholds_Level1Description)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.TextBoxThresholds_Level1Description)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.LabelThresholds_Level1And)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.LabelThresholds_Level1Between)
        Me.GroupBoxQvAAlertSettings_Thresholds.Controls.Add(Me.CheckBoxThresholds_Level1)
        Me.GroupBoxQvAAlertSettings_Thresholds.Location = New System.Drawing.Point(4, 56)
        Me.GroupBoxQvAAlertSettings_Thresholds.Name = "GroupBoxQvAAlertSettings_Thresholds"
        Me.GroupBoxQvAAlertSettings_Thresholds.Size = New System.Drawing.Size(610, 191)
        Me.GroupBoxQvAAlertSettings_Thresholds.TabIndex = 4
        Me.GroupBoxQvAAlertSettings_Thresholds.Text = "Thresholds"
        '
        'NumericInputThresholds_Level3Start
        '
        Me.NumericInputThresholds_Level3Start.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Percent
        Me.NumericInputThresholds_Level3Start.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputThresholds_Level3Start.Location = New System.Drawing.Point(144, 129)
        Me.NumericInputThresholds_Level3Start.Name = "NumericInputThresholds_Level3Start"
        Me.NumericInputThresholds_Level3Start.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject6, "", Nothing, Nothing, True)})
        Me.NumericInputThresholds_Level3Start.Properties.DisplayFormat.FormatString = "p2"
        Me.NumericInputThresholds_Level3Start.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputThresholds_Level3Start.Properties.EditFormat.FormatString = "p2"
        Me.NumericInputThresholds_Level3Start.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputThresholds_Level3Start.Properties.IsFloatValue = False
        Me.NumericInputThresholds_Level3Start.Properties.Mask.EditMask = "p0"
        Me.NumericInputThresholds_Level3Start.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NumericInputThresholds_Level3Start.Size = New System.Drawing.Size(62, 20)
        Me.NumericInputThresholds_Level3Start.TabIndex = 15
        '
        'NumericInputThresholds_Level2End
        '
        Me.NumericInputThresholds_Level2End.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Percent
        Me.NumericInputThresholds_Level2End.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputThresholds_Level2End.Location = New System.Drawing.Point(240, 77)
        Me.NumericInputThresholds_Level2End.Name = "NumericInputThresholds_Level2End"
        Me.NumericInputThresholds_Level2End.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.NumericInputThresholds_Level2End.Properties.DisplayFormat.FormatString = "p2"
        Me.NumericInputThresholds_Level2End.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputThresholds_Level2End.Properties.EditFormat.FormatString = "p2"
        Me.NumericInputThresholds_Level2End.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputThresholds_Level2End.Properties.IsFloatValue = False
        Me.NumericInputThresholds_Level2End.Properties.Mask.EditMask = "p0"
        Me.NumericInputThresholds_Level2End.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NumericInputThresholds_Level2End.Size = New System.Drawing.Size(62, 20)
        Me.NumericInputThresholds_Level2End.TabIndex = 11
        '
        'NumericInputThresholds_Level2Start
        '
        Me.NumericInputThresholds_Level2Start.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Percent
        Me.NumericInputThresholds_Level2Start.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputThresholds_Level2Start.Location = New System.Drawing.Point(144, 77)
        Me.NumericInputThresholds_Level2Start.Name = "NumericInputThresholds_Level2Start"
        Me.NumericInputThresholds_Level2Start.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.NumericInputThresholds_Level2Start.Properties.DisplayFormat.FormatString = "p2"
        Me.NumericInputThresholds_Level2Start.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputThresholds_Level2Start.Properties.EditFormat.FormatString = "p2"
        Me.NumericInputThresholds_Level2Start.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputThresholds_Level2Start.Properties.IsFloatValue = False
        Me.NumericInputThresholds_Level2Start.Properties.Mask.EditMask = "p0"
        Me.NumericInputThresholds_Level2Start.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NumericInputThresholds_Level2Start.Size = New System.Drawing.Size(62, 20)
        Me.NumericInputThresholds_Level2Start.TabIndex = 9
        '
        'NumericInputThresholds_Level1End
        '
        Me.NumericInputThresholds_Level1End.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Percent
        Me.NumericInputThresholds_Level1End.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputThresholds_Level1End.Location = New System.Drawing.Point(240, 25)
        Me.NumericInputThresholds_Level1End.Name = "NumericInputThresholds_Level1End"
        Me.NumericInputThresholds_Level1End.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, "", Nothing, Nothing, True)})
        Me.NumericInputThresholds_Level1End.Properties.DisplayFormat.FormatString = "p2"
        Me.NumericInputThresholds_Level1End.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputThresholds_Level1End.Properties.EditFormat.FormatString = "p2"
        Me.NumericInputThresholds_Level1End.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputThresholds_Level1End.Properties.IsFloatValue = False
        Me.NumericInputThresholds_Level1End.Properties.Mask.EditMask = "p0"
        Me.NumericInputThresholds_Level1End.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NumericInputThresholds_Level1End.Size = New System.Drawing.Size(62, 20)
        Me.NumericInputThresholds_Level1End.TabIndex = 4
        '
        'NumericInputThresholds_Level1Start
        '
        Me.NumericInputThresholds_Level1Start.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.Percent
        Me.NumericInputThresholds_Level1Start.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputThresholds_Level1Start.Location = New System.Drawing.Point(144, 25)
        Me.NumericInputThresholds_Level1Start.Name = "NumericInputThresholds_Level1Start"
        Me.NumericInputThresholds_Level1Start.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject4, "", Nothing, Nothing, True)})
        Me.NumericInputThresholds_Level1Start.Properties.DisplayFormat.FormatString = "p2"
        Me.NumericInputThresholds_Level1Start.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputThresholds_Level1Start.Properties.EditFormat.FormatString = "p2"
        Me.NumericInputThresholds_Level1Start.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputThresholds_Level1Start.Properties.IsFloatValue = False
        Me.NumericInputThresholds_Level1Start.Properties.Mask.EditMask = "p0"
        Me.NumericInputThresholds_Level1Start.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NumericInputThresholds_Level1Start.Size = New System.Drawing.Size(62, 20)
        Me.NumericInputThresholds_Level1Start.TabIndex = 2
        '
        'LabelThresholds_Level3Description
        '
        Me.LabelThresholds_Level3Description.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelThresholds_Level3Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelThresholds_Level3Description.Location = New System.Drawing.Point(73, 155)
        Me.LabelThresholds_Level3Description.Name = "LabelThresholds_Level3Description"
        Me.LabelThresholds_Level3Description.Size = New System.Drawing.Size(65, 20)
        Me.LabelThresholds_Level3Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelThresholds_Level3Description.TabIndex = 20
        Me.LabelThresholds_Level3Description.Text = "Description:"
        '
        'TextBoxThresholds_Level3Description
        '
        Me.TextBoxThresholds_Level3Description.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxThresholds_Level3Description.Border.Class = "TextBoxBorder"
        Me.TextBoxThresholds_Level3Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxThresholds_Level3Description.CheckSpellingOnValidate = False
        Me.TextBoxThresholds_Level3Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxThresholds_Level3Description.Enabled = False
        Me.TextBoxThresholds_Level3Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxThresholds_Level3Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxThresholds_Level3Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxThresholds_Level3Description.FocusHighlightEnabled = True
        Me.TextBoxThresholds_Level3Description.ForeColor = System.Drawing.Color.Black
        Me.TextBoxThresholds_Level3Description.Location = New System.Drawing.Point(144, 155)
        Me.TextBoxThresholds_Level3Description.MaxFileSize = CType(0, Long)
        Me.TextBoxThresholds_Level3Description.Name = "TextBoxThresholds_Level3Description"
        Me.TextBoxThresholds_Level3Description.ShowSpellCheckCompleteMessage = True
        Me.TextBoxThresholds_Level3Description.Size = New System.Drawing.Size(461, 20)
        Me.TextBoxThresholds_Level3Description.TabIndex = 19
        Me.TextBoxThresholds_Level3Description.TabOnEnter = True
        '
        'LabelThresholds_Level3And
        '
        Me.LabelThresholds_Level3And.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelThresholds_Level3And.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelThresholds_Level3And.Location = New System.Drawing.Point(212, 129)
        Me.LabelThresholds_Level3And.Name = "LabelThresholds_Level3And"
        Me.LabelThresholds_Level3And.Size = New System.Drawing.Size(90, 20)
        Me.LabelThresholds_Level3And.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelThresholds_Level3And.TabIndex = 17
        Me.LabelThresholds_Level3And.Text = "and over"
        '
        'CheckBoxThresholds_Level3
        '
        '
        '
        '
        Me.CheckBoxThresholds_Level3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxThresholds_Level3.CheckValue = 0
        Me.CheckBoxThresholds_Level3.CheckValueChecked = 1
        Me.CheckBoxThresholds_Level3.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxThresholds_Level3.CheckValueUnchecked = 0
        Me.CheckBoxThresholds_Level3.ChildControls = CType(resources.GetObject("CheckBoxThresholds_Level3.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxThresholds_Level3.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxThresholds_Level3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxThresholds_Level3.Location = New System.Drawing.Point(5, 129)
        Me.CheckBoxThresholds_Level3.Name = "CheckBoxThresholds_Level3"
        Me.CheckBoxThresholds_Level3.OldestSibling = Nothing
        Me.CheckBoxThresholds_Level3.SecurityEnabled = True
        Me.CheckBoxThresholds_Level3.SiblingControls = CType(resources.GetObject("CheckBoxThresholds_Level3.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxThresholds_Level3.Size = New System.Drawing.Size(62, 20)
        Me.CheckBoxThresholds_Level3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxThresholds_Level3.TabIndex = 14
        Me.CheckBoxThresholds_Level3.Text = "Level 3"
        '
        'LabelThresholds_Level2Description
        '
        Me.LabelThresholds_Level2Description.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelThresholds_Level2Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelThresholds_Level2Description.Location = New System.Drawing.Point(73, 103)
        Me.LabelThresholds_Level2Description.Name = "LabelThresholds_Level2Description"
        Me.LabelThresholds_Level2Description.Size = New System.Drawing.Size(65, 20)
        Me.LabelThresholds_Level2Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelThresholds_Level2Description.TabIndex = 13
        Me.LabelThresholds_Level2Description.Text = "Description:"
        '
        'TextBoxThresholds_Level2Description
        '
        Me.TextBoxThresholds_Level2Description.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxThresholds_Level2Description.Border.Class = "TextBoxBorder"
        Me.TextBoxThresholds_Level2Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxThresholds_Level2Description.CheckSpellingOnValidate = False
        Me.TextBoxThresholds_Level2Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxThresholds_Level2Description.Enabled = False
        Me.TextBoxThresholds_Level2Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxThresholds_Level2Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxThresholds_Level2Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxThresholds_Level2Description.FocusHighlightEnabled = True
        Me.TextBoxThresholds_Level2Description.ForeColor = System.Drawing.Color.Black
        Me.TextBoxThresholds_Level2Description.Location = New System.Drawing.Point(144, 103)
        Me.TextBoxThresholds_Level2Description.MaxFileSize = CType(0, Long)
        Me.TextBoxThresholds_Level2Description.Name = "TextBoxThresholds_Level2Description"
        Me.TextBoxThresholds_Level2Description.ShowSpellCheckCompleteMessage = True
        Me.TextBoxThresholds_Level2Description.Size = New System.Drawing.Size(461, 20)
        Me.TextBoxThresholds_Level2Description.TabIndex = 12
        Me.TextBoxThresholds_Level2Description.TabOnEnter = True
        '
        'LabelThresholds_Level2And
        '
        Me.LabelThresholds_Level2And.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelThresholds_Level2And.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelThresholds_Level2And.Location = New System.Drawing.Point(212, 77)
        Me.LabelThresholds_Level2And.Name = "LabelThresholds_Level2And"
        Me.LabelThresholds_Level2And.Size = New System.Drawing.Size(22, 20)
        Me.LabelThresholds_Level2And.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelThresholds_Level2And.TabIndex = 10
        Me.LabelThresholds_Level2And.Text = "And"
        '
        'LabelThresholds_Level2Between
        '
        Me.LabelThresholds_Level2Between.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelThresholds_Level2Between.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelThresholds_Level2Between.Location = New System.Drawing.Point(73, 77)
        Me.LabelThresholds_Level2Between.Name = "LabelThresholds_Level2Between"
        Me.LabelThresholds_Level2Between.Size = New System.Drawing.Size(65, 20)
        Me.LabelThresholds_Level2Between.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelThresholds_Level2Between.TabIndex = 8
        Me.LabelThresholds_Level2Between.Text = "Between"
        '
        'CheckBoxThresholds_Level2
        '
        '
        '
        '
        Me.CheckBoxThresholds_Level2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxThresholds_Level2.CheckValue = 0
        Me.CheckBoxThresholds_Level2.CheckValueChecked = 1
        Me.CheckBoxThresholds_Level2.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxThresholds_Level2.CheckValueUnchecked = 0
        Me.CheckBoxThresholds_Level2.ChildControls = CType(resources.GetObject("CheckBoxThresholds_Level2.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxThresholds_Level2.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxThresholds_Level2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxThresholds_Level2.Location = New System.Drawing.Point(5, 77)
        Me.CheckBoxThresholds_Level2.Name = "CheckBoxThresholds_Level2"
        Me.CheckBoxThresholds_Level2.OldestSibling = Nothing
        Me.CheckBoxThresholds_Level2.SecurityEnabled = True
        Me.CheckBoxThresholds_Level2.SiblingControls = CType(resources.GetObject("CheckBoxThresholds_Level2.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxThresholds_Level2.Size = New System.Drawing.Size(62, 20)
        Me.CheckBoxThresholds_Level2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxThresholds_Level2.TabIndex = 7
        Me.CheckBoxThresholds_Level2.Text = "Level 2"
        '
        'LabelThresholds_Level1Description
        '
        Me.LabelThresholds_Level1Description.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelThresholds_Level1Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelThresholds_Level1Description.Location = New System.Drawing.Point(73, 51)
        Me.LabelThresholds_Level1Description.Name = "LabelThresholds_Level1Description"
        Me.LabelThresholds_Level1Description.Size = New System.Drawing.Size(65, 20)
        Me.LabelThresholds_Level1Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelThresholds_Level1Description.TabIndex = 6
        Me.LabelThresholds_Level1Description.Text = "Description:"
        '
        'TextBoxThresholds_Level1Description
        '
        Me.TextBoxThresholds_Level1Description.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxThresholds_Level1Description.Border.Class = "TextBoxBorder"
        Me.TextBoxThresholds_Level1Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxThresholds_Level1Description.CheckSpellingOnValidate = False
        Me.TextBoxThresholds_Level1Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxThresholds_Level1Description.Enabled = False
        Me.TextBoxThresholds_Level1Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxThresholds_Level1Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxThresholds_Level1Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxThresholds_Level1Description.FocusHighlightEnabled = True
        Me.TextBoxThresholds_Level1Description.ForeColor = System.Drawing.Color.Black
        Me.TextBoxThresholds_Level1Description.Location = New System.Drawing.Point(144, 51)
        Me.TextBoxThresholds_Level1Description.MaxFileSize = CType(0, Long)
        Me.TextBoxThresholds_Level1Description.Name = "TextBoxThresholds_Level1Description"
        Me.TextBoxThresholds_Level1Description.ShowSpellCheckCompleteMessage = True
        Me.TextBoxThresholds_Level1Description.Size = New System.Drawing.Size(461, 20)
        Me.TextBoxThresholds_Level1Description.TabIndex = 5
        Me.TextBoxThresholds_Level1Description.TabOnEnter = True
        '
        'LabelThresholds_Level1And
        '
        Me.LabelThresholds_Level1And.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelThresholds_Level1And.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelThresholds_Level1And.Location = New System.Drawing.Point(212, 25)
        Me.LabelThresholds_Level1And.Name = "LabelThresholds_Level1And"
        Me.LabelThresholds_Level1And.Size = New System.Drawing.Size(22, 20)
        Me.LabelThresholds_Level1And.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelThresholds_Level1And.TabIndex = 3
        Me.LabelThresholds_Level1And.Text = "And"
        '
        'LabelThresholds_Level1Between
        '
        Me.LabelThresholds_Level1Between.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelThresholds_Level1Between.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelThresholds_Level1Between.Location = New System.Drawing.Point(73, 25)
        Me.LabelThresholds_Level1Between.Name = "LabelThresholds_Level1Between"
        Me.LabelThresholds_Level1Between.Size = New System.Drawing.Size(65, 20)
        Me.LabelThresholds_Level1Between.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelThresholds_Level1Between.TabIndex = 1
        Me.LabelThresholds_Level1Between.Text = "Between"
        '
        'CheckBoxThresholds_Level1
        '
        '
        '
        '
        Me.CheckBoxThresholds_Level1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxThresholds_Level1.CheckValue = 0
        Me.CheckBoxThresholds_Level1.CheckValueChecked = 1
        Me.CheckBoxThresholds_Level1.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxThresholds_Level1.CheckValueUnchecked = 0
        Me.CheckBoxThresholds_Level1.ChildControls = CType(resources.GetObject("CheckBoxThresholds_Level1.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxThresholds_Level1.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxThresholds_Level1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxThresholds_Level1.Location = New System.Drawing.Point(5, 25)
        Me.CheckBoxThresholds_Level1.Name = "CheckBoxThresholds_Level1"
        Me.CheckBoxThresholds_Level1.OldestSibling = Nothing
        Me.CheckBoxThresholds_Level1.SecurityEnabled = True
        Me.CheckBoxThresholds_Level1.SiblingControls = CType(resources.GetObject("CheckBoxThresholds_Level1.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxThresholds_Level1.Size = New System.Drawing.Size(62, 20)
        Me.CheckBoxThresholds_Level1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxThresholds_Level1.TabIndex = 0
        Me.CheckBoxThresholds_Level1.Text = "Level 1"
        '
        'LabelQvAAlertSettings_SendAlertTo
        '
        Me.LabelQvAAlertSettings_SendAlertTo.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelQvAAlertSettings_SendAlertTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelQvAAlertSettings_SendAlertTo.Location = New System.Drawing.Point(181, 4)
        Me.LabelQvAAlertSettings_SendAlertTo.Name = "LabelQvAAlertSettings_SendAlertTo"
        Me.LabelQvAAlertSettings_SendAlertTo.Size = New System.Drawing.Size(76, 20)
        Me.LabelQvAAlertSettings_SendAlertTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelQvAAlertSettings_SendAlertTo.TabIndex = 2
        Me.LabelQvAAlertSettings_SendAlertTo.Text = "Send Alert To:"
        '
        'LabelQvAAlertSettings_RunAt
        '
        Me.LabelQvAAlertSettings_RunAt.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelQvAAlertSettings_RunAt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelQvAAlertSettings_RunAt.Location = New System.Drawing.Point(4, 4)
        Me.LabelQvAAlertSettings_RunAt.Name = "LabelQvAAlertSettings_RunAt"
        Me.LabelQvAAlertSettings_RunAt.Size = New System.Drawing.Size(77, 20)
        Me.LabelQvAAlertSettings_RunAt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelQvAAlertSettings_RunAt.TabIndex = 1
        Me.LabelQvAAlertSettings_RunAt.Text = "Run At (Daily):"
        '
        'TabItemQvAAlertSettings_SettingsTab
        '
        Me.TabItemQvAAlertSettings_SettingsTab.AttachedControl = Me.TabControlPanelQvAAlertSettings_QvAAlertSettings
        Me.TabItemQvAAlertSettings_SettingsTab.Name = "TabItemQvAAlertSettings_SettingsTab"
        Me.TabItemQvAAlertSettings_SettingsTab.Text = "Settings"
        '
        'TabControlPanelQvAAlertLog_QvAAlertLog
        '
        Me.TabControlPanelQvAAlertLog_QvAAlertLog.Controls.Add(Me.TextBoxQvAAlertLog_Log)
        Me.TabControlPanelQvAAlertLog_QvAAlertLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelQvAAlertLog_QvAAlertLog.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelQvAAlertLog_QvAAlertLog.Name = "TabControlPanelQvAAlertLog_QvAAlertLog"
        Me.TabControlPanelQvAAlertLog_QvAAlertLog.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelQvAAlertLog_QvAAlertLog.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelQvAAlertLog_QvAAlertLog.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelQvAAlertLog_QvAAlertLog.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelQvAAlertLog_QvAAlertLog.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelQvAAlertLog_QvAAlertLog.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelQvAAlertLog_QvAAlertLog.Style.GradientAngle = 90
        Me.TabControlPanelQvAAlertLog_QvAAlertLog.TabIndex = 3
        Me.TabControlPanelQvAAlertLog_QvAAlertLog.TabItem = Me.TabItemQvAAlertSettings_LogTab
        '
        'TextBoxQvAAlertLog_Log
        '
        Me.TextBoxQvAAlertLog_Log.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxQvAAlertLog_Log.Border.Class = "TextBoxBorder"
        Me.TextBoxQvAAlertLog_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxQvAAlertLog_Log.CheckSpellingOnValidate = False
        Me.TextBoxQvAAlertLog_Log.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxQvAAlertLog_Log.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxQvAAlertLog_Log.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxQvAAlertLog_Log.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxQvAAlertLog_Log.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxQvAAlertLog_Log.FocusHighlightEnabled = True
        Me.TextBoxQvAAlertLog_Log.ForeColor = System.Drawing.Color.Black
        Me.TextBoxQvAAlertLog_Log.Location = New System.Drawing.Point(1, 1)
        Me.TextBoxQvAAlertLog_Log.MaxFileSize = CType(0, Long)
        Me.TextBoxQvAAlertLog_Log.Multiline = True
        Me.TextBoxQvAAlertLog_Log.Name = "TextBoxQvAAlertLog_Log"
        Me.TextBoxQvAAlertLog_Log.ReadOnly = True
        Me.TextBoxQvAAlertLog_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxQvAAlertLog_Log.ShowSpellCheckCompleteMessage = True
        Me.TextBoxQvAAlertLog_Log.Size = New System.Drawing.Size(824, 265)
        Me.TextBoxQvAAlertLog_Log.TabIndex = 0
        Me.TextBoxQvAAlertLog_Log.TabOnEnter = True
        '
        'TabItemQvAAlertSettings_LogTab
        '
        Me.TabItemQvAAlertSettings_LogTab.AttachedControl = Me.TabControlPanelQvAAlertLog_QvAAlertLog
        Me.TabItemQvAAlertSettings_LogTab.Name = "TabItemQvAAlertSettings_LogTab"
        Me.TabItemQvAAlertSettings_LogTab.Text = "Log"
        '
        'TabControlPanelQvAAlertSettings_DatabaseProfielsSettings
        '
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.Controls.Add(Me.ButtonQvAAlertDatabaseProfiles_Select)
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.Controls.Add(Me.ButtonQvAAlertDatabaseProfiles_Edit)
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.Controls.Add(Me.ButtonQvAAlertDatabaseProfiles_Remove)
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.Controls.Add(Me.ButtonQvAAlertDatabaseProfiles_ProcessNow)
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.Controls.Add(Me.DataGridViewQvAAlertDatabaseProfiles_Databases)
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.Name = "TabControlPanelQvAAlertSettings_DatabaseProfielsSettings"
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.Style.GradientAngle = 90
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.TabIndex = 4
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.TabItem = Me.TabItemQvAAlertSettings_DatabaseProfilesTab
        '
        'ButtonQvAAlertDatabaseProfiles_Select
        '
        Me.ButtonQvAAlertDatabaseProfiles_Select.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonQvAAlertDatabaseProfiles_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonQvAAlertDatabaseProfiles_Select.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonQvAAlertDatabaseProfiles_Select.Location = New System.Drawing.Point(585, 243)
        Me.ButtonQvAAlertDatabaseProfiles_Select.Name = "ButtonQvAAlertDatabaseProfiles_Select"
        Me.ButtonQvAAlertDatabaseProfiles_Select.SecurityEnabled = True
        Me.ButtonQvAAlertDatabaseProfiles_Select.Size = New System.Drawing.Size(75, 20)
        Me.ButtonQvAAlertDatabaseProfiles_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonQvAAlertDatabaseProfiles_Select.TabIndex = 11
        Me.ButtonQvAAlertDatabaseProfiles_Select.Text = "Select"
        '
        'ButtonQvAAlertDatabaseProfiles_Edit
        '
        Me.ButtonQvAAlertDatabaseProfiles_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonQvAAlertDatabaseProfiles_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonQvAAlertDatabaseProfiles_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonQvAAlertDatabaseProfiles_Edit.Location = New System.Drawing.Point(666, 243)
        Me.ButtonQvAAlertDatabaseProfiles_Edit.Name = "ButtonQvAAlertDatabaseProfiles_Edit"
        Me.ButtonQvAAlertDatabaseProfiles_Edit.SecurityEnabled = True
        Me.ButtonQvAAlertDatabaseProfiles_Edit.Size = New System.Drawing.Size(75, 20)
        Me.ButtonQvAAlertDatabaseProfiles_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonQvAAlertDatabaseProfiles_Edit.TabIndex = 13
        Me.ButtonQvAAlertDatabaseProfiles_Edit.Text = "Edit"
        '
        'ButtonQvAAlertDatabaseProfiles_Remove
        '
        Me.ButtonQvAAlertDatabaseProfiles_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonQvAAlertDatabaseProfiles_Remove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonQvAAlertDatabaseProfiles_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonQvAAlertDatabaseProfiles_Remove.Location = New System.Drawing.Point(747, 243)
        Me.ButtonQvAAlertDatabaseProfiles_Remove.Name = "ButtonQvAAlertDatabaseProfiles_Remove"
        Me.ButtonQvAAlertDatabaseProfiles_Remove.SecurityEnabled = True
        Me.ButtonQvAAlertDatabaseProfiles_Remove.Size = New System.Drawing.Size(75, 20)
        Me.ButtonQvAAlertDatabaseProfiles_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonQvAAlertDatabaseProfiles_Remove.TabIndex = 12
        Me.ButtonQvAAlertDatabaseProfiles_Remove.Text = "Remove"
        '
        'ButtonQvAAlertDatabaseProfiles_ProcessNow
        '
        Me.ButtonQvAAlertDatabaseProfiles_ProcessNow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonQvAAlertDatabaseProfiles_ProcessNow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonQvAAlertDatabaseProfiles_ProcessNow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonQvAAlertDatabaseProfiles_ProcessNow.Location = New System.Drawing.Point(4, 243)
        Me.ButtonQvAAlertDatabaseProfiles_ProcessNow.Name = "ButtonQvAAlertDatabaseProfiles_ProcessNow"
        Me.ButtonQvAAlertDatabaseProfiles_ProcessNow.SecurityEnabled = True
        Me.ButtonQvAAlertDatabaseProfiles_ProcessNow.Size = New System.Drawing.Size(75, 20)
        Me.ButtonQvAAlertDatabaseProfiles_ProcessNow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonQvAAlertDatabaseProfiles_ProcessNow.TabIndex = 2
        Me.ButtonQvAAlertDatabaseProfiles_ProcessNow.Text = "Process Now"
        '
        'DataGridViewQvAAlertDatabaseProfiles_Databases
        '
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.AllowSelectGroupHeaderRow = True
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.AlwaysForceShowRowSelectionOnUserInput = True
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.AutoFilterLookupColumns = False
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.AutoloadRepositoryDatasource = True
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.DatabaseProfile
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.DataSource = Nothing
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.ItemDescription = "Item(s)"
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.Location = New System.Drawing.Point(4, 4)
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.MultiSelect = True
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.Name = "DataGridViewQvAAlertDatabaseProfiles_Databases"
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.RunStandardValidation = True
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.ShowSelectDeselectAllButtons = False
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.Size = New System.Drawing.Size(818, 233)
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.TabIndex = 6
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.UseEmbeddedNavigator = False
        Me.DataGridViewQvAAlertDatabaseProfiles_Databases.ViewCaptionHeight = -1
        '
        'TabItemQvAAlertSettings_DatabaseProfilesTab
        '
        Me.TabItemQvAAlertSettings_DatabaseProfilesTab.AttachedControl = Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings
        Me.TabItemQvAAlertSettings_DatabaseProfilesTab.Name = "TabItemQvAAlertSettings_DatabaseProfilesTab"
        Me.TabItemQvAAlertSettings_DatabaseProfilesTab.Text = "Database Profiles"
        '
        'ButtonQvA_Start
        '
        Me.ButtonQvA_Start.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonQvA_Start.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonQvA_Start.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonQvA_Start.Location = New System.Drawing.Point(763, 4)
        Me.ButtonQvA_Start.Name = "ButtonQvA_Start"
        Me.ButtonQvA_Start.SecurityEnabled = True
        Me.ButtonQvA_Start.Size = New System.Drawing.Size(75, 20)
        Me.ButtonQvA_Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonQvA_Start.TabIndex = 14
        Me.ButtonQvA_Start.Text = "Start"
        '
        'TabItemServices_QvAAlertTab
        '
        Me.TabItemServices_QvAAlertTab.AttachedControl = Me.TabControlPanelQvAAlertTab_QvAAlert
        Me.TabItemServices_QvAAlertTab.Name = "TabItemServices_QvAAlertTab"
        Me.TabItemServices_QvAAlertTab.Text = "QvA Alert"
        '
        'TabControlPanelGoogleCalendarTab_GoogleCalendar
        '
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.Controls.Add(Me.CheckBoxGoogleCalendar_AutoStart)
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.Controls.Add(Me.TabControlGoogleCalendar_GoogleCalendarSettings)
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.Controls.Add(Me.LabelGoogleCalendar_StatusDescription)
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.Controls.Add(Me.LabelGoogleCalendar_Status)
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.Controls.Add(Me.ButtonGoogleCalendar_Stop)
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.Controls.Add(Me.ButtonGoogleCalendar_Start)
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.Name = "TabControlPanelGoogleCalendarTab_GoogleCalendar"
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.Size = New System.Drawing.Size(850, 336)
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.Style.GradientAngle = 90
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.TabIndex = 7
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.TabItem = Me.TabItemServices_GoogleCalendarTab
        '
        'CheckBoxGoogleCalendar_AutoStart
        '
        Me.CheckBoxGoogleCalendar_AutoStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxGoogleCalendar_AutoStart.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.CheckBoxGoogleCalendar_AutoStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxGoogleCalendar_AutoStart.CheckValue = 0
        Me.CheckBoxGoogleCalendar_AutoStart.CheckValueChecked = 1
        Me.CheckBoxGoogleCalendar_AutoStart.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxGoogleCalendar_AutoStart.CheckValueUnchecked = 0
        Me.CheckBoxGoogleCalendar_AutoStart.ChildControls = CType(resources.GetObject("CheckBoxGoogleCalendar_AutoStart.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxGoogleCalendar_AutoStart.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxGoogleCalendar_AutoStart.Location = New System.Drawing.Point(677, 4)
        Me.CheckBoxGoogleCalendar_AutoStart.Name = "CheckBoxGoogleCalendar_AutoStart"
        Me.CheckBoxGoogleCalendar_AutoStart.OldestSibling = Nothing
        Me.CheckBoxGoogleCalendar_AutoStart.SecurityEnabled = True
        Me.CheckBoxGoogleCalendar_AutoStart.SiblingControls = CType(resources.GetObject("CheckBoxGoogleCalendar_AutoStart.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxGoogleCalendar_AutoStart.Size = New System.Drawing.Size(80, 20)
        Me.CheckBoxGoogleCalendar_AutoStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxGoogleCalendar_AutoStart.TabIndex = 17
        Me.CheckBoxGoogleCalendar_AutoStart.Text = "Auto Start"
        '
        'TabControlGoogleCalendar_GoogleCalendarSettings
        '
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.BackColor = System.Drawing.Color.White
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.CanReorderTabs = False
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.Controls.Add(Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings)
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.Controls.Add(Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog)
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.Controls.Add(Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles)
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.ForeColor = System.Drawing.Color.Black
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.Location = New System.Drawing.Point(12, 30)
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.Name = "TabControlGoogleCalendar_GoogleCalendarSettings"
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.SelectedTabIndex = 0
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.Size = New System.Drawing.Size(826, 294)
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.TabIndex = 15
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.Tabs.Add(Me.TabItemGoogleCalendarSettings_GoogleCalendarSettingsTab)
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.Tabs.Add(Me.TabItemGoogleCalendarSettings_GoogleCalendarDatabaseProfilesTab)
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.Tabs.Add(Me.TabItemGoogleCalendarSettings_GoogleCalendarLogTab)
        '
        'TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings
        '
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings.Controls.Add(Me.NumericInputGoogleCalendarSettings_RunAt)
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings.Controls.Add(Me.LabelGoogleCalendarSettings_RunAt)
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings.Name = "TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings"
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings.Style.GradientAngle = 90
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings.TabIndex = 1
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings.TabItem = Me.TabItemGoogleCalendarSettings_GoogleCalendarSettingsTab
        '
        'NumericInputGoogleCalendarSettings_RunAt
        '
        Me.NumericInputGoogleCalendarSettings_RunAt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
        Me.NumericInputGoogleCalendarSettings_RunAt.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.NumericInputGoogleCalendarSettings_RunAt.Location = New System.Drawing.Point(132, 4)
        Me.NumericInputGoogleCalendarSettings_RunAt.Name = "NumericInputGoogleCalendarSettings_RunAt"
        Me.NumericInputGoogleCalendarSettings_RunAt.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NumericInputGoogleCalendarSettings_RunAt.Properties.DisplayFormat.FormatString = "f0"
        Me.NumericInputGoogleCalendarSettings_RunAt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputGoogleCalendarSettings_RunAt.Properties.EditFormat.FormatString = "f0"
        Me.NumericInputGoogleCalendarSettings_RunAt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.NumericInputGoogleCalendarSettings_RunAt.Properties.IsFloatValue = False
        Me.NumericInputGoogleCalendarSettings_RunAt.Properties.Mask.EditMask = "f0"
        Me.NumericInputGoogleCalendarSettings_RunAt.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NumericInputGoogleCalendarSettings_RunAt.Properties.MaxLength = 11
        Me.NumericInputGoogleCalendarSettings_RunAt.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NumericInputGoogleCalendarSettings_RunAt.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
        Me.NumericInputGoogleCalendarSettings_RunAt.Size = New System.Drawing.Size(75, 20)
        Me.NumericInputGoogleCalendarSettings_RunAt.TabIndex = 1
        '
        'LabelGoogleCalendarSettings_RunAt
        '
        Me.LabelGoogleCalendarSettings_RunAt.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelGoogleCalendarSettings_RunAt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelGoogleCalendarSettings_RunAt.Location = New System.Drawing.Point(4, 4)
        Me.LabelGoogleCalendarSettings_RunAt.Name = "LabelGoogleCalendarSettings_RunAt"
        Me.LabelGoogleCalendarSettings_RunAt.Size = New System.Drawing.Size(122, 20)
        Me.LabelGoogleCalendarSettings_RunAt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelGoogleCalendarSettings_RunAt.TabIndex = 0
        Me.LabelGoogleCalendarSettings_RunAt.Text = "Run at every min(s):"
        '
        'TabItemGoogleCalendarSettings_GoogleCalendarSettingsTab
        '
        Me.TabItemGoogleCalendarSettings_GoogleCalendarSettingsTab.AttachedControl = Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings
        Me.TabItemGoogleCalendarSettings_GoogleCalendarSettingsTab.Name = "TabItemGoogleCalendarSettings_GoogleCalendarSettingsTab"
        Me.TabItemGoogleCalendarSettings_GoogleCalendarSettingsTab.Text = "Settings"
        '
        'TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog
        '
        Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog.Controls.Add(Me.TextBoxGoogleCalendarLog_Log)
        Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog.Name = "TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog"
        Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog.Style.GradientAngle = 90
        Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog.TabIndex = 3
        Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog.TabItem = Me.TabItemGoogleCalendarSettings_GoogleCalendarLogTab
        '
        'TextBoxGoogleCalendarLog_Log
        '
        Me.TextBoxGoogleCalendarLog_Log.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxGoogleCalendarLog_Log.Border.Class = "TextBoxBorder"
        Me.TextBoxGoogleCalendarLog_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxGoogleCalendarLog_Log.CheckSpellingOnValidate = False
        Me.TextBoxGoogleCalendarLog_Log.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxGoogleCalendarLog_Log.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxGoogleCalendarLog_Log.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxGoogleCalendarLog_Log.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxGoogleCalendarLog_Log.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxGoogleCalendarLog_Log.FocusHighlightEnabled = True
        Me.TextBoxGoogleCalendarLog_Log.ForeColor = System.Drawing.Color.Black
        Me.TextBoxGoogleCalendarLog_Log.Location = New System.Drawing.Point(1, 1)
        Me.TextBoxGoogleCalendarLog_Log.MaxFileSize = CType(0, Long)
        Me.TextBoxGoogleCalendarLog_Log.Multiline = True
        Me.TextBoxGoogleCalendarLog_Log.Name = "TextBoxGoogleCalendarLog_Log"
        Me.TextBoxGoogleCalendarLog_Log.ReadOnly = True
        Me.TextBoxGoogleCalendarLog_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxGoogleCalendarLog_Log.ShowSpellCheckCompleteMessage = True
        Me.TextBoxGoogleCalendarLog_Log.Size = New System.Drawing.Size(824, 265)
        Me.TextBoxGoogleCalendarLog_Log.TabIndex = 0
        Me.TextBoxGoogleCalendarLog_Log.TabOnEnter = True
        '
        'TabItemGoogleCalendarSettings_GoogleCalendarLogTab
        '
        Me.TabItemGoogleCalendarSettings_GoogleCalendarLogTab.AttachedControl = Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog
        Me.TabItemGoogleCalendarSettings_GoogleCalendarLogTab.Name = "TabItemGoogleCalendarSettings_GoogleCalendarLogTab"
        Me.TabItemGoogleCalendarSettings_GoogleCalendarLogTab.Text = "Log"
        '
        'TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles
        '
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.Controls.Add(Me.ButtonGoogleCalendarDatabaseProfiles_ProcessNow)
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.Controls.Add(Me.ButtonGoogleCalendarDatabaseProfiles_Select)
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.Controls.Add(Me.ButtonGoogleCalendarDatabaseProfiles_Edit)
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.Controls.Add(Me.ButtonGoogleCalendarDatabaseProfiles_Remove)
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.Controls.Add(Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases)
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.Name = "TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles"
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.Style.GradientAngle = 90
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.TabIndex = 2
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.TabItem = Me.TabItemGoogleCalendarSettings_GoogleCalendarDatabaseProfilesTab
        '
        'ButtonGoogleCalendarDatabaseProfiles_ProcessNow
        '
        Me.ButtonGoogleCalendarDatabaseProfiles_ProcessNow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonGoogleCalendarDatabaseProfiles_ProcessNow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonGoogleCalendarDatabaseProfiles_ProcessNow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonGoogleCalendarDatabaseProfiles_ProcessNow.Location = New System.Drawing.Point(4, 243)
        Me.ButtonGoogleCalendarDatabaseProfiles_ProcessNow.Name = "ButtonGoogleCalendarDatabaseProfiles_ProcessNow"
        Me.ButtonGoogleCalendarDatabaseProfiles_ProcessNow.SecurityEnabled = True
        Me.ButtonGoogleCalendarDatabaseProfiles_ProcessNow.Size = New System.Drawing.Size(75, 20)
        Me.ButtonGoogleCalendarDatabaseProfiles_ProcessNow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonGoogleCalendarDatabaseProfiles_ProcessNow.TabIndex = 8
        Me.ButtonGoogleCalendarDatabaseProfiles_ProcessNow.Text = "Process Now"
        '
        'ButtonGoogleCalendarDatabaseProfiles_Select
        '
        Me.ButtonGoogleCalendarDatabaseProfiles_Select.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonGoogleCalendarDatabaseProfiles_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonGoogleCalendarDatabaseProfiles_Select.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonGoogleCalendarDatabaseProfiles_Select.Location = New System.Drawing.Point(585, 243)
        Me.ButtonGoogleCalendarDatabaseProfiles_Select.Name = "ButtonGoogleCalendarDatabaseProfiles_Select"
        Me.ButtonGoogleCalendarDatabaseProfiles_Select.SecurityEnabled = True
        Me.ButtonGoogleCalendarDatabaseProfiles_Select.Size = New System.Drawing.Size(75, 20)
        Me.ButtonGoogleCalendarDatabaseProfiles_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonGoogleCalendarDatabaseProfiles_Select.TabIndex = 5
        Me.ButtonGoogleCalendarDatabaseProfiles_Select.Text = "Select"
        '
        'ButtonGoogleCalendarDatabaseProfiles_Edit
        '
        Me.ButtonGoogleCalendarDatabaseProfiles_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonGoogleCalendarDatabaseProfiles_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonGoogleCalendarDatabaseProfiles_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonGoogleCalendarDatabaseProfiles_Edit.Location = New System.Drawing.Point(666, 243)
        Me.ButtonGoogleCalendarDatabaseProfiles_Edit.Name = "ButtonGoogleCalendarDatabaseProfiles_Edit"
        Me.ButtonGoogleCalendarDatabaseProfiles_Edit.SecurityEnabled = True
        Me.ButtonGoogleCalendarDatabaseProfiles_Edit.Size = New System.Drawing.Size(75, 20)
        Me.ButtonGoogleCalendarDatabaseProfiles_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonGoogleCalendarDatabaseProfiles_Edit.TabIndex = 6
        Me.ButtonGoogleCalendarDatabaseProfiles_Edit.Text = "Edit"
        '
        'ButtonGoogleCalendarDatabaseProfiles_Remove
        '
        Me.ButtonGoogleCalendarDatabaseProfiles_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonGoogleCalendarDatabaseProfiles_Remove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonGoogleCalendarDatabaseProfiles_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonGoogleCalendarDatabaseProfiles_Remove.Location = New System.Drawing.Point(747, 243)
        Me.ButtonGoogleCalendarDatabaseProfiles_Remove.Name = "ButtonGoogleCalendarDatabaseProfiles_Remove"
        Me.ButtonGoogleCalendarDatabaseProfiles_Remove.SecurityEnabled = True
        Me.ButtonGoogleCalendarDatabaseProfiles_Remove.Size = New System.Drawing.Size(75, 20)
        Me.ButtonGoogleCalendarDatabaseProfiles_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonGoogleCalendarDatabaseProfiles_Remove.TabIndex = 7
        Me.ButtonGoogleCalendarDatabaseProfiles_Remove.Text = "Remove"
        '
        'DataGridViewGoogleCalendarDatabaseProfiles_Databases
        '
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.AllowSelectGroupHeaderRow = True
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.AlwaysForceShowRowSelectionOnUserInput = True
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.AutoFilterLookupColumns = False
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.AutoloadRepositoryDatasource = True
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.DatabaseProfile
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.DataSource = Nothing
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.ItemDescription = "Item(s)"
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.Location = New System.Drawing.Point(4, 4)
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.MultiSelect = True
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.Name = "DataGridViewGoogleCalendarDatabaseProfiles_Databases"
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.RunStandardValidation = True
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.ShowSelectDeselectAllButtons = False
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.Size = New System.Drawing.Size(818, 233)
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.TabIndex = 4
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.UseEmbeddedNavigator = False
        Me.DataGridViewGoogleCalendarDatabaseProfiles_Databases.ViewCaptionHeight = -1
        '
        'TabItemGoogleCalendarSettings_GoogleCalendarDatabaseProfilesTab
        '
        Me.TabItemGoogleCalendarSettings_GoogleCalendarDatabaseProfilesTab.AttachedControl = Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles
        Me.TabItemGoogleCalendarSettings_GoogleCalendarDatabaseProfilesTab.Name = "TabItemGoogleCalendarSettings_GoogleCalendarDatabaseProfilesTab"
        Me.TabItemGoogleCalendarSettings_GoogleCalendarDatabaseProfilesTab.Text = "Database Profiles"
        '
        'LabelGoogleCalendar_StatusDescription
        '
        Me.LabelGoogleCalendar_StatusDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelGoogleCalendar_StatusDescription.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelGoogleCalendar_StatusDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelGoogleCalendar_StatusDescription.Location = New System.Drawing.Point(58, 4)
        Me.LabelGoogleCalendar_StatusDescription.Name = "LabelGoogleCalendar_StatusDescription"
        Me.LabelGoogleCalendar_StatusDescription.Size = New System.Drawing.Size(613, 20)
        Me.LabelGoogleCalendar_StatusDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelGoogleCalendar_StatusDescription.TabIndex = 13
        Me.LabelGoogleCalendar_StatusDescription.Text = "Stopped..."
        '
        'LabelGoogleCalendar_Status
        '
        Me.LabelGoogleCalendar_Status.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelGoogleCalendar_Status.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelGoogleCalendar_Status.Location = New System.Drawing.Point(12, 4)
        Me.LabelGoogleCalendar_Status.Name = "LabelGoogleCalendar_Status"
        Me.LabelGoogleCalendar_Status.Size = New System.Drawing.Size(40, 20)
        Me.LabelGoogleCalendar_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelGoogleCalendar_Status.TabIndex = 12
        Me.LabelGoogleCalendar_Status.Text = "Status:"
        '
        'ButtonGoogleCalendar_Stop
        '
        Me.ButtonGoogleCalendar_Stop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonGoogleCalendar_Stop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonGoogleCalendar_Stop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonGoogleCalendar_Stop.Location = New System.Drawing.Point(763, 4)
        Me.ButtonGoogleCalendar_Stop.Name = "ButtonGoogleCalendar_Stop"
        Me.ButtonGoogleCalendar_Stop.SecurityEnabled = True
        Me.ButtonGoogleCalendar_Stop.Size = New System.Drawing.Size(75, 20)
        Me.ButtonGoogleCalendar_Stop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonGoogleCalendar_Stop.TabIndex = 16
        Me.ButtonGoogleCalendar_Stop.Text = "Stop"
        Me.ButtonGoogleCalendar_Stop.Visible = False
        '
        'ButtonGoogleCalendar_Start
        '
        Me.ButtonGoogleCalendar_Start.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonGoogleCalendar_Start.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonGoogleCalendar_Start.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonGoogleCalendar_Start.Location = New System.Drawing.Point(763, 4)
        Me.ButtonGoogleCalendar_Start.Name = "ButtonGoogleCalendar_Start"
        Me.ButtonGoogleCalendar_Start.SecurityEnabled = True
        Me.ButtonGoogleCalendar_Start.Size = New System.Drawing.Size(75, 20)
        Me.ButtonGoogleCalendar_Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonGoogleCalendar_Start.TabIndex = 14
        Me.ButtonGoogleCalendar_Start.Text = "Start"
        '
        'TabItemServices_GoogleCalendarTab
        '
        Me.TabItemServices_GoogleCalendarTab.AttachedControl = Me.TabControlPanelGoogleCalendarTab_GoogleCalendar
        Me.TabItemServices_GoogleCalendarTab.Name = "TabItemServices_GoogleCalendarTab"
        Me.TabItemServices_GoogleCalendarTab.Text = "Google Calendar"
        '
        'TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport
        '
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.Controls.Add(Me.CheckBoxCoreMediaCheckExport_AutoStart)
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.Controls.Add(Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings)
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.Controls.Add(Me.LabelCoreMediaCheckExport_StatusDescription)
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.Controls.Add(Me.LabelCoreMediaCheckExport_Status)
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.Controls.Add(Me.ButtonCoreMediaCheckExport_Start)
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.Controls.Add(Me.ButtonCoreMediaCheckExport_Stop)
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.Name = "TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport"
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.Size = New System.Drawing.Size(850, 336)
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.Style.GradientAngle = 90
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.TabIndex = 8
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.TabItem = Me.TabItemServices_CoreMediaCheckExportTab
        '
        'CheckBoxCoreMediaCheckExport_AutoStart
        '
        Me.CheckBoxCoreMediaCheckExport_AutoStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxCoreMediaCheckExport_AutoStart.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.CheckBoxCoreMediaCheckExport_AutoStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxCoreMediaCheckExport_AutoStart.CheckValue = 0
        Me.CheckBoxCoreMediaCheckExport_AutoStart.CheckValueChecked = 1
        Me.CheckBoxCoreMediaCheckExport_AutoStart.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
        Me.CheckBoxCoreMediaCheckExport_AutoStart.CheckValueUnchecked = 0
        Me.CheckBoxCoreMediaCheckExport_AutoStart.ChildControls = CType(resources.GetObject("CheckBoxCoreMediaCheckExport_AutoStart.ChildControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxCoreMediaCheckExport_AutoStart.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
        Me.CheckBoxCoreMediaCheckExport_AutoStart.Location = New System.Drawing.Point(677, 4)
        Me.CheckBoxCoreMediaCheckExport_AutoStart.Name = "CheckBoxCoreMediaCheckExport_AutoStart"
        Me.CheckBoxCoreMediaCheckExport_AutoStart.OldestSibling = Nothing
        Me.CheckBoxCoreMediaCheckExport_AutoStart.SecurityEnabled = True
        Me.CheckBoxCoreMediaCheckExport_AutoStart.SiblingControls = CType(resources.GetObject("CheckBoxCoreMediaCheckExport_AutoStart.SiblingControls"), System.Collections.Generic.List(Of Object))
        Me.CheckBoxCoreMediaCheckExport_AutoStart.Size = New System.Drawing.Size(80, 20)
        Me.CheckBoxCoreMediaCheckExport_AutoStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxCoreMediaCheckExport_AutoStart.TabIndex = 17
        Me.CheckBoxCoreMediaCheckExport_AutoStart.Text = "Auto Start"
        '
        'TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings
        '
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.BackColor = System.Drawing.Color.White
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.CanReorderTabs = False
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.Controls.Add(Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings)
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.Controls.Add(Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog)
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.Controls.Add(Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles)
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.ForeColor = System.Drawing.Color.Black
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.Location = New System.Drawing.Point(12, 30)
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.Name = "TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings"
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.SelectedTabIndex = 0
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.Size = New System.Drawing.Size(826, 294)
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.TabIndex = 16
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.Tabs.Add(Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportSettingsTab)
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.Tabs.Add(Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportDatabaseProfilesTab)
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.Tabs.Add(Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportLogTab)
        '
        'TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings
        '
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.Controls.Add(Me.LabelCoreMediaCheckExportSettings_ExportPath)
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.Controls.Add(Me.LabelCoreMediaCheckExportSettings_RunAt)
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.Controls.Add(Me.DateTimeInputCoreMediaCheckExportSettings_RunAt)
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.Controls.Add(Me.TextBoxCoreMediaCheckExportSettings_ExportPath)
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.Name = "TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings"
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.Size = New System.Drawing.Size(826, 272)
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.Style.GradientAngle = 90
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.TabIndex = 1
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.TabItem = Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportSettingsTab
        '
        'LabelCoreMediaCheckExportSettings_ExportPath
        '
        Me.LabelCoreMediaCheckExportSettings_ExportPath.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelCoreMediaCheckExportSettings_ExportPath.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelCoreMediaCheckExportSettings_ExportPath.Location = New System.Drawing.Point(4, 30)
        Me.LabelCoreMediaCheckExportSettings_ExportPath.Name = "LabelCoreMediaCheckExportSettings_ExportPath"
        Me.LabelCoreMediaCheckExportSettings_ExportPath.Size = New System.Drawing.Size(75, 20)
        Me.LabelCoreMediaCheckExportSettings_ExportPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelCoreMediaCheckExportSettings_ExportPath.TabIndex = 2
        Me.LabelCoreMediaCheckExportSettings_ExportPath.Text = "Export Path:"
        '
        'LabelCoreMediaCheckExportSettings_RunAt
        '
        Me.LabelCoreMediaCheckExportSettings_RunAt.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelCoreMediaCheckExportSettings_RunAt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelCoreMediaCheckExportSettings_RunAt.Location = New System.Drawing.Point(4, 4)
        Me.LabelCoreMediaCheckExportSettings_RunAt.Name = "LabelCoreMediaCheckExportSettings_RunAt"
        Me.LabelCoreMediaCheckExportSettings_RunAt.Size = New System.Drawing.Size(75, 20)
        Me.LabelCoreMediaCheckExportSettings_RunAt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelCoreMediaCheckExportSettings_RunAt.TabIndex = 0
        Me.LabelCoreMediaCheckExportSettings_RunAt.Text = "Run At (Daily):"
        '
        'DateTimeInputCoreMediaCheckExportSettings_RunAt
        '
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.AllowEmptyState = False
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.AutoResolveFreeTextEntries = False
        '
        '
        '
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.ButtonDropDown.Visible = True
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.ButtonFreeText.Checked = True
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.CustomFormat = ""
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.FocusHighlightEnabled = True
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.FreeTextEntryMode = True
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.IsPopupCalendarOpen = False
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.Location = New System.Drawing.Point(85, 4)
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.DisplayMonth = New Date(2011, 6, 1, 0, 0, 0, 0)
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.TodayButtonVisible = True
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.Visible = False
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.Name = "DateTimeInputCoreMediaCheckExportSettings_RunAt"
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.ReadOnly = False
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.Size = New System.Drawing.Size(88, 20)
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.TabIndex = 1
        Me.DateTimeInputCoreMediaCheckExportSettings_RunAt.Value = New Date(2011, 10, 14, 11, 54, 41, 2)
        '
        'TextBoxCoreMediaCheckExportSettings_ExportPath
        '
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.Border.Class = "TextBoxBorder"
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.ButtonCustom.Visible = True
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.CheckSpellingOnValidate = False
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.FocusHighlightEnabled = True
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.ForeColor = System.Drawing.Color.Black
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.Location = New System.Drawing.Point(85, 30)
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.MaxFileSize = CType(0, Long)
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.Name = "TextBoxCoreMediaCheckExportSettings_ExportPath"
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.ShowSpellCheckCompleteMessage = True
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.Size = New System.Drawing.Size(737, 20)
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.TabIndex = 3
        Me.TextBoxCoreMediaCheckExportSettings_ExportPath.TabOnEnter = True
        '
        'TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportSettingsTab
        '
        Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportSettingsTab.AttachedControl = Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings
        Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportSettingsTab.Name = "TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportSettingsTab"
        Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportSettingsTab.Text = "Settings"
        '
        'TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog
        '
        Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog.Controls.Add(Me.TextBoxCoreMediaCheckExportLog_Log)
        Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog.Location = New System.Drawing.Point(0, 27)
        Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog.Name = "TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog"
        Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog.Size = New System.Drawing.Size(826, 267)
        Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog.Style.GradientAngle = 90
        Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog.TabIndex = 3
        Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog.TabItem = Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportLogTab
        '
        'TextBoxCoreMediaCheckExportLog_Log
        '
        Me.TextBoxCoreMediaCheckExportLog_Log.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.TextBoxCoreMediaCheckExportLog_Log.Border.Class = "TextBoxBorder"
        Me.TextBoxCoreMediaCheckExportLog_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxCoreMediaCheckExportLog_Log.CheckSpellingOnValidate = False
        Me.TextBoxCoreMediaCheckExportLog_Log.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
        Me.TextBoxCoreMediaCheckExportLog_Log.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCoreMediaCheckExportLog_Log.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Me.TextBoxCoreMediaCheckExportLog_Log.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
        Me.TextBoxCoreMediaCheckExportLog_Log.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.TextBoxCoreMediaCheckExportLog_Log.FocusHighlightEnabled = True
        Me.TextBoxCoreMediaCheckExportLog_Log.ForeColor = System.Drawing.Color.Black
        Me.TextBoxCoreMediaCheckExportLog_Log.Location = New System.Drawing.Point(1, 1)
        Me.TextBoxCoreMediaCheckExportLog_Log.MaxFileSize = CType(0, Long)
        Me.TextBoxCoreMediaCheckExportLog_Log.Multiline = True
        Me.TextBoxCoreMediaCheckExportLog_Log.Name = "TextBoxCoreMediaCheckExportLog_Log"
        Me.TextBoxCoreMediaCheckExportLog_Log.ReadOnly = True
        Me.TextBoxCoreMediaCheckExportLog_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxCoreMediaCheckExportLog_Log.ShowSpellCheckCompleteMessage = True
        Me.TextBoxCoreMediaCheckExportLog_Log.Size = New System.Drawing.Size(824, 265)
        Me.TextBoxCoreMediaCheckExportLog_Log.TabIndex = 5
        Me.TextBoxCoreMediaCheckExportLog_Log.TabOnEnter = True
        '
        'TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportLogTab
        '
        Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportLogTab.AttachedControl = Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog
        Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportLogTab.Name = "TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportLogTab"
        Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportLogTab.Text = "Log"
        '
        'TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles
        '
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.Controls.Add(Me.ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow)
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.Controls.Add(Me.ButtonCoreMediaCheckExportDatabaseProfiles_Select)
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.Controls.Add(Me.ButtonCoreMediaCheckExportDatabaseProfiles_Edit)
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.Controls.Add(Me.ButtonCoreMediaCheckExportDatabaseProfiles_Remove)
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.Controls.Add(Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases)
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.Location = New System.Drawing.Point(0, 22)
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.Name = "TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDataba" & _
    "seProfiles"
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.Size = New System.Drawing.Size(826, 272)
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.Style.BackColor1.Color = System.Drawing.Color.White
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.Style.GradientAngle = 90
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.TabIndex = 2
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.TabItem = Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportDatabaseProfilesTab
        '
        'ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow
        '
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow.Location = New System.Drawing.Point(4, 248)
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow.Name = "ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow"
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow.SecurityEnabled = True
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow.Size = New System.Drawing.Size(75, 20)
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow.TabIndex = 6
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow.Text = "Process Now"
        '
        'ButtonCoreMediaCheckExportDatabaseProfiles_Select
        '
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Select.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Select.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Select.Location = New System.Drawing.Point(585, 248)
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Select.Name = "ButtonCoreMediaCheckExportDatabaseProfiles_Select"
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Select.SecurityEnabled = True
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Select.Size = New System.Drawing.Size(75, 20)
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Select.TabIndex = 7
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Select.Text = "Select"
        '
        'ButtonCoreMediaCheckExportDatabaseProfiles_Edit
        '
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Edit.Location = New System.Drawing.Point(666, 248)
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Edit.Name = "ButtonCoreMediaCheckExportDatabaseProfiles_Edit"
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Edit.SecurityEnabled = True
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Edit.Size = New System.Drawing.Size(75, 20)
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Edit.TabIndex = 9
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Edit.Text = "Edit"
        '
        'ButtonCoreMediaCheckExportDatabaseProfiles_Remove
        '
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Remove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Remove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Remove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Remove.Location = New System.Drawing.Point(747, 248)
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Remove.Name = "ButtonCoreMediaCheckExportDatabaseProfiles_Remove"
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Remove.SecurityEnabled = True
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Remove.Size = New System.Drawing.Size(75, 20)
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Remove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Remove.TabIndex = 9
        Me.ButtonCoreMediaCheckExportDatabaseProfiles_Remove.Text = "Remove"
        '
        'DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases
        '
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.AllowSelectGroupHeaderRow = True
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.AlwaysForceShowRowSelectionOnUserInput = True
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.AutoFilterLookupColumns = False
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.AutoloadRepositoryDatasource = True
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.BackColor = System.Drawing.SystemColors.Control
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.DatabaseProfile
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.DataSource = Nothing
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.ItemDescription = "Item(s)"
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.Location = New System.Drawing.Point(4, 4)
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.MultiSelect = True
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.Name = "DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases"
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.RunStandardValidation = True
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.ShowSelectDeselectAllButtons = False
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.Size = New System.Drawing.Size(818, 238)
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.TabIndex = 5
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.UseEmbeddedNavigator = False
        Me.DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases.ViewCaptionHeight = -1
        '
        'TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportDatabaseProfilesTab
        '
        Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportDatabaseProfilesTab.AttachedControl = Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles
        Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportDatabaseProfilesTab.Name = "TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportDatabaseProfilesTab"
        Me.TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportDatabaseProfilesTab.Text = "Database Profiles"
        '
        'LabelCoreMediaCheckExport_StatusDescription
        '
        Me.LabelCoreMediaCheckExport_StatusDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelCoreMediaCheckExport_StatusDescription.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelCoreMediaCheckExport_StatusDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelCoreMediaCheckExport_StatusDescription.Location = New System.Drawing.Point(58, 4)
        Me.LabelCoreMediaCheckExport_StatusDescription.Name = "LabelCoreMediaCheckExport_StatusDescription"
        Me.LabelCoreMediaCheckExport_StatusDescription.Size = New System.Drawing.Size(613, 20)
        Me.LabelCoreMediaCheckExport_StatusDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelCoreMediaCheckExport_StatusDescription.TabIndex = 13
        Me.LabelCoreMediaCheckExport_StatusDescription.Text = "Stopped..."
        '
        'LabelCoreMediaCheckExport_Status
        '
        Me.LabelCoreMediaCheckExport_Status.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelCoreMediaCheckExport_Status.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelCoreMediaCheckExport_Status.Location = New System.Drawing.Point(12, 4)
        Me.LabelCoreMediaCheckExport_Status.Name = "LabelCoreMediaCheckExport_Status"
        Me.LabelCoreMediaCheckExport_Status.Size = New System.Drawing.Size(40, 20)
        Me.LabelCoreMediaCheckExport_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelCoreMediaCheckExport_Status.TabIndex = 12
        Me.LabelCoreMediaCheckExport_Status.Text = "Status:"
        '
        'ButtonCoreMediaCheckExport_Start
        '
        Me.ButtonCoreMediaCheckExport_Start.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonCoreMediaCheckExport_Start.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCoreMediaCheckExport_Start.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonCoreMediaCheckExport_Start.Location = New System.Drawing.Point(763, 4)
        Me.ButtonCoreMediaCheckExport_Start.Name = "ButtonCoreMediaCheckExport_Start"
        Me.ButtonCoreMediaCheckExport_Start.SecurityEnabled = True
        Me.ButtonCoreMediaCheckExport_Start.Size = New System.Drawing.Size(75, 20)
        Me.ButtonCoreMediaCheckExport_Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonCoreMediaCheckExport_Start.TabIndex = 14
        Me.ButtonCoreMediaCheckExport_Start.Text = "Start"
        '
        'ButtonCoreMediaCheckExport_Stop
        '
        Me.ButtonCoreMediaCheckExport_Stop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonCoreMediaCheckExport_Stop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCoreMediaCheckExport_Stop.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonCoreMediaCheckExport_Stop.Location = New System.Drawing.Point(763, 4)
        Me.ButtonCoreMediaCheckExport_Stop.Name = "ButtonCoreMediaCheckExport_Stop"
        Me.ButtonCoreMediaCheckExport_Stop.SecurityEnabled = True
        Me.ButtonCoreMediaCheckExport_Stop.Size = New System.Drawing.Size(75, 20)
        Me.ButtonCoreMediaCheckExport_Stop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonCoreMediaCheckExport_Stop.TabIndex = 15
        Me.ButtonCoreMediaCheckExport_Stop.Text = "Stop"
        Me.ButtonCoreMediaCheckExport_Stop.Visible = False
        '
        'TabItemServices_CoreMediaCheckExportTab
        '
        Me.TabItemServices_CoreMediaCheckExportTab.AttachedControl = Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport
        Me.TabItemServices_CoreMediaCheckExportTab.Name = "TabItemServices_CoreMediaCheckExportTab"
        Me.TabItemServices_CoreMediaCheckExportTab.Text = "Core Media Check Export"
        '
        'DefaultLookAndFeel
        '
        Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
        '
        'NotifyIconForm_NotifyIcon
        '
        Me.NotifyIconForm_NotifyIcon.ContextMenuStrip = Me.ContextMenuStripForm_Menu
        Me.NotifyIconForm_NotifyIcon.Text = "Advantage Services"
        Me.NotifyIconForm_NotifyIcon.Visible = True
        '
        'ContextMenuStripForm_Menu
        '
        Me.ContextMenuStripForm_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemMenu_ShowLogAndSettings, Me.ToolStripSeparatorMenu_FirstSeparator, Me.ToolStripMenuItemMenu_ShutDown})
        Me.ContextMenuStripForm_Menu.Name = "ContextMenuStripForm_Menu"
        Me.ContextMenuStripForm_Menu.Size = New System.Drawing.Size(184, 54)
        '
        'ToolStripMenuItemMenu_ShowLogAndSettings
        '
        Me.ToolStripMenuItemMenu_ShowLogAndSettings.Name = "ToolStripMenuItemMenu_ShowLogAndSettings"
        Me.ToolStripMenuItemMenu_ShowLogAndSettings.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenuItemMenu_ShowLogAndSettings.Text = "Show Log and Settings"
        '
        'ToolStripSeparatorMenu_FirstSeparator
        '
        Me.ToolStripSeparatorMenu_FirstSeparator.Name = "ToolStripSeparatorMenu_FirstSeparator"
        Me.ToolStripSeparatorMenu_FirstSeparator.Size = New System.Drawing.Size(180, 6)
        '
        'ToolStripMenuItemMenu_ShutDown
        '
        Me.ToolStripMenuItemMenu_ShutDown.Name = "ToolStripMenuItemMenu_ShutDown"
        Me.ToolStripMenuItemMenu_ShutDown.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenuItemMenu_ShutDown.Text = "Shut Down"
        '
        'AdvantageServicesFormOld
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 520)
        Me.Controls.Add(Me.TabControlForm_Services)
        Me.Controls.Add(Me.RibbonControlForm_MainRibbon)
        Me.EnableGlass = False
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AdvantageServicesFormOld"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Advantage Services"
        Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
        Me.RibbonControlForm_MainRibbon.PerformLayout()
        Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
        CType(Me.TabControlForm_Services, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlForm_Services.ResumeLayout(False)
        Me.TabControlPanelEmailListenerTab_EmailListener.ResumeLayout(False)
        CType(Me.TabControlEmailListener_EmailListenerSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlEmailListener_EmailListenerSettings.ResumeLayout(False)
        Me.TabControlPanelSettingsTab_EmailListenerSettings.ResumeLayout(False)
        CType(Me.NumericInputEmailListenerSettings_RunAtEvery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanelLogTab_EmailListenerLog.ResumeLayout(False)
        Me.TabControlPanelDatabaseProfilesTab_DatabaseProfiles.ResumeLayout(False)
        Me.TabControlPanelMediaOceanImportTab_Import.ResumeLayout(False)
        CType(Me.TabControlMediaOceanImport_MediaOceanImportSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlMediaOceanImport_MediaOceanImportSettings.ResumeLayout(False)
        Me.TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings.ResumeLayout(False)
        CType(Me.DateTimeInputMediaOceanImportSettings_RunAt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBoxMediaOceanImportSettings_Settings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxMediaOceanImportSettings_Settings.ResumeLayout(False)
        Me.TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog.ResumeLayout(False)
        Me.TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles.ResumeLayout(False)
        Me.TabControlPanelMissingTimeTab_MissingTime.ResumeLayout(False)
        CType(Me.TabControlMissingTime_Settings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlMissingTime_Settings.ResumeLayout(False)
        Me.TabControlPanelSettingsTab_MissingTimeSettings.ResumeLayout(False)
        CType(Me.GroupBoxMissingTimeSettings_Interval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxMissingTimeSettings_Interval.ResumeLayout(False)
        CType(Me.NumericInputMissingTimeSettings_Interval_StopAfter.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericInputMissingTimeSettings_Interval_RunEveryHours.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimeInputMissingTimeSettings_Interval_RunAtTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanelAlertsTab_Alerts.ResumeLayout(False)
        CType(Me.GroupBoxMissingTimeAlerts_Other, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxMissingTimeAlerts_Other.ResumeLayout(False)
        CType(Me.GroupBoxMissingTimeAlerts_Recipient, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxMissingTimeAlerts_Recipient.ResumeLayout(False)
        CType(Me.NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBoxMissingTimeAlerts_Tracking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxMissingTimeAlerts_Tracking.ResumeLayout(False)
        CType(Me.GroupBoxMissingTimeAlerts_Priority, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxMissingTimeAlerts_Priority.ResumeLayout(False)
        Me.GroupBoxMissingTimeAlerts_Priority.PerformLayout()
        CType(Me.GroupBoxMissingTimeAlerts_Range, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxMissingTimeAlerts_Range.ResumeLayout(False)
        Me.GroupBoxMissingTimeAlerts_Range.PerformLayout()
        CType(Me.NumericInputMissingTimeSettings_Range_DaysToCheck.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles.ResumeLayout(False)
        Me.TabControlPanelLogTab_MissingTimeLog.ResumeLayout(False)
        Me.TabControlPanelContractTab_Contract.ResumeLayout(False)
        CType(Me.TabControlContract_ContractSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlContract_ContractSettings.ResumeLayout(False)
        Me.TabControlPanelContractSettingsTab_ContractSettings.ResumeLayout(False)
        CType(Me.GroupBoxContractSettings_Notifications, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxContractSettings_Notifications.ResumeLayout(False)
        CType(Me.NumericInputContractSettings_RenewalDaysPrior.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimeInputContractAlertSettings_RunAt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles.ResumeLayout(False)
        Me.TabControlContractLogTab_ContractLog.ResumeLayout(False)
        Me.TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals.ResumeLayout(False)
        CType(Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings.ResumeLayout(False)
        Me.TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings.ResumeLayout(False)
        Me.TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles.ResumeLayout(False)
        Me.TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog.ResumeLayout(False)
        Me.TabControlPanelTasks_Tasks.ResumeLayout(False)
        CType(Me.TabControlTask_Settings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlTask_Settings.ResumeLayout(False)
        Me.TabControlPanelSettingsTab_TaskSettings.ResumeLayout(False)
        CType(Me.DateTimeInputTaskSettings_RunAt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBoxTaskSettings_Notifications, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxTaskSettings_Notifications.ResumeLayout(False)
        CType(Me.NumericInputTaskSettings_Upcoming_EndDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericInputTaskSettings_Upcoming_StartDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles.ResumeLayout(False)
        Me.TabControlPanelLogTab_TaskLog.ResumeLayout(False)
        Me.TabControlPanelExport_Export.ResumeLayout(False)
        CType(Me.TabControlExport_Settings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlExport_Settings.ResumeLayout(False)
        Me.TabControlPanelSettingsTab_ExportSettings.ResumeLayout(False)
        CType(Me.GroupBoxExportSettings_Data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxExportSettings_Data.ResumeLayout(False)
        Me.GroupBoxExportSettings_Data.PerformLayout()
        CType(Me.DateTimePickerExportSettings_DataEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimePickerExportSettings_DataStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimeInputExportSettings_RunAt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanelCriteriaTab_ExportCriteria.ResumeLayout(False)
        CType(Me.GroupBoxExportCriteria_SelectedCampaigns, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxExportCriteria_SelectedCampaigns.ResumeLayout(False)
        Me.TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles.ResumeLayout(False)
        Me.TabControlPanelLogTab_ExportLog.ResumeLayout(False)
        Me.TabControlPanelQvAAlertTab_QvAAlert.ResumeLayout(False)
        CType(Me.TabControlQvAAlert_Settings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlQvAAlert_Settings.ResumeLayout(False)
        Me.TabControlPanelQvAAlertSettings_QvAAlertSettings.ResumeLayout(False)
        CType(Me.DateTimeInputQvAAlertSettings_RunAt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBoxQvAAlertSettings_CalculationOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxQvAAlertSettings_CalculationOptions.ResumeLayout(False)
        CType(Me.GroupBoxQvAAlertSettings_Thresholds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxQvAAlertSettings_Thresholds.ResumeLayout(False)
        CType(Me.NumericInputThresholds_Level3Start.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericInputThresholds_Level2End.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericInputThresholds_Level2Start.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericInputThresholds_Level1End.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericInputThresholds_Level1Start.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanelQvAAlertLog_QvAAlertLog.ResumeLayout(False)
        Me.TabControlPanelQvAAlertSettings_DatabaseProfielsSettings.ResumeLayout(False)
        Me.TabControlPanelGoogleCalendarTab_GoogleCalendar.ResumeLayout(False)
        CType(Me.TabControlGoogleCalendar_GoogleCalendarSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlGoogleCalendar_GoogleCalendarSettings.ResumeLayout(False)
        Me.TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings.ResumeLayout(False)
        CType(Me.NumericInputGoogleCalendarSettings_RunAt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog.ResumeLayout(False)
        Me.TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles.ResumeLayout(False)
        Me.TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport.ResumeLayout(False)
        CType(Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings.ResumeLayout(False)
        Me.TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings.ResumeLayout(False)
        CType(Me.DateTimeInputCoreMediaCheckExportSettings_RunAt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog.ResumeLayout(False)
        Me.TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles.ResumeLayout(False)
        Me.ContextMenuStripForm_Menu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StyleManager As DevComponents.DotNetBar.StyleManager
    Protected Friend WithEvents RibbonControlForm_MainRibbon As DevComponents.DotNetBar.RibbonControl
    Protected Friend WithEvents RibbonPanelFile_FilePanel As DevComponents.DotNetBar.RibbonPanel
    Protected Friend WithEvents RibbonBarFilePanel_System As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
    Protected Friend WithEvents ButtonItemSystem_Exit As DevComponents.DotNetBar.ButtonItem
    Protected Friend WithEvents Office2007StartButtonMainRibbon_Home As DevComponents.DotNetBar.Office2007StartButton
    Protected Friend WithEvents RibbonTabItemMainRibbon_File As DevComponents.DotNetBar.RibbonTabItem
    Protected Friend WithEvents ButtonItemMainRibbon_Help As DevComponents.DotNetBar.ButtonItem
    Protected Friend WithEvents ButtonItemMainRibbon_ShowAndHide As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItemSystem_Hide As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBarFilePanel_DatabaseProfiles As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
    Friend WithEvents ButtonItemDatabaseProfiles_DatabaseProfiles As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RibbonBarFilePanel_Settings As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
    Friend WithEvents ButtonItemSettings_Save As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents TabControlForm_Services As AdvantageFramework.WinForm.Presentation.Controls.TabControl
    Friend WithEvents TabItemServices_QvAAlertTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelEmailListenerTab_EmailListener As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabControlEmailListener_EmailListenerSettings As AdvantageFramework.WinForm.Presentation.Controls.TabControl
    Friend WithEvents TabControlPanelLogTab_EmailListenerLog As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TextBoxEmailListenerLog_Log As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents TabItemEmailListenerSettings_LogTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelSettingsTab_EmailListenerSettings As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TextBoxEmailListenerSettings_StartofSignatureCode As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents LabelEmailListenerSettings_StartofSignatureCode As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelEmailListenerSettings_RunAtEvery As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents TabItemEmailListenerSettings_SettingsTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelDatabaseProfilesTab_DatabaseProfiles As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents ButtonEmailListenerDatabaseProfiles_Select As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonEmailListenerDatabaseProfiles_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonEmailListenerDatabaseProfiles_Remove As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents DataGridViewEmailListenerDatabaseProfiles_Databases As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    Friend WithEvents TabItemEmailListenerSettings_DatabaseProfilesTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents LabelEmailListener_StatusDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelEmailListener_Status As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ButtonEmailListener_Start As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonEmailListener_Stop As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TabItemServices_EmailListenerTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents NotifyIconForm_NotifyIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStripForm_Menu As AdvantageFramework.WinForm.Presentation.Controls.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemMenu_ShowLogAndSettings As AdvantageFramework.WinForm.Presentation.Controls.ToolStripMenuItem
    Friend WithEvents ToolStripSeparatorMenu_FirstSeparator As AdvantageFramework.WinForm.Presentation.Controls.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemMenu_ShutDown As AdvantageFramework.WinForm.Presentation.Controls.ToolStripMenuItem
    Friend WithEvents TabControlPanelExport_Export As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabControlExport_Settings As AdvantageFramework.WinForm.Presentation.Controls.TabControl
    Friend WithEvents TabControlPanelExportDatabaseProfilesTab_DatabaseProfiles As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents ButtonExportDatabaseProfiles_Select As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonExportDatabaseProfiles_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonExportDatabaseProfiles_Remove As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents DataGridViewExportDatabaseProfiles_Databases As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    Friend WithEvents TabItemExportSettings_DatabaseProfilesTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelLogTab_ExportLog As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TextBoxExportLog_Log As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents TabItemExportSettings_LogTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelSettingsTab_ExportSettings As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents LabelExportSettings_Path As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelExportSettings_RunAt As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents DateTimeInputExportSettings_RunAt As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
    Friend WithEvents TextBoxExportSettings_ExportPath As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents TabItemExportSettings_SettingsTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents LabelExport_StatusDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelExport_Status As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ButtonExport_Start As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonExport_Stop As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TabItemServices_ExportTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents ButtonExportDatabaseProfiles_ProcessNow As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TabControlPanelCriteriaTab_ExportCriteria As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItemExportSettings_CriteriaTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents DataGridViewExportCriteria_Campaigns As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    Friend WithEvents DefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents TabControlPanelQvAAlertTab_QvAAlert As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents ButtonQvAAlertDatabaseProfiles_ProcessNow As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents LabelQvAAlertSettings_RunAt As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents DateTimeInputQvAAlertSettings_RunAt As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
    Friend WithEvents TabControlQvAAlert_Settings As AdvantageFramework.WinForm.Presentation.Controls.TabControl
    Friend WithEvents TabControlPanelQvAAlertLog_QvAAlertLog As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TextBoxQvAAlertLog_Log As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents TabItemQvAAlertSettings_LogTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelQvAAlertSettings_QvAAlertSettings As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItemQvAAlertSettings_SettingsTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents LabelQvAAlert_StatusDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelQvAAlert_Status As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ComboBoxQvAAlertSettings_SendAlertTo As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    Friend WithEvents LabelQvAAlertSettings_SendAlertTo As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ComboBoxQvAAlertSettings_SetAlertLevel As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    Friend WithEvents LabelQvAAlertSettings_SetAlertLevel As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents GroupBoxQvAAlertSettings_CalculationOptions As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
    Friend WithEvents CheckBoxCalculationOptions_IncludeEstimate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents CheckBoxCalculationOptions_VendorCharges As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents CheckBoxCalculationOptions_IncomeOnly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents CheckBoxCalculationOptions_Time As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents GroupBoxQvAAlertSettings_Thresholds As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
    Friend WithEvents LabelThresholds_Level3Description As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents TextBoxThresholds_Level3Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents LabelThresholds_Level3And As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents CheckBoxThresholds_Level3 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents LabelThresholds_Level2Description As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents TextBoxThresholds_Level2Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents LabelThresholds_Level2And As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelThresholds_Level2Between As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents CheckBoxThresholds_Level2 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents LabelThresholds_Level1Description As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents TextBoxThresholds_Level1Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents LabelThresholds_Level1And As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelThresholds_Level1Between As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents CheckBoxThresholds_Level1 As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents ComboBoxQvAAlertSettings_ShowLevel As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    Friend WithEvents LabelQvAAlertSettings_ShowLevel As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ButtonExportCriteriaCampaign_AddSelected As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents GroupBoxExportCriteria_SelectedCampaigns As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
    Friend WithEvents DataGridViewExportCriteria_SelectedCampaigns As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    Friend WithEvents LabelExportCriteria_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ComboBoxExportCriteria_Clients As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    Friend WithEvents LabelExportCriteria_DatabaseProfile As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ComboBoxExportCriteria_DatabaseProfiles As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    Friend WithEvents GroupBoxExportSettings_Data As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
    Friend WithEvents LabelExportSettings_DataTo As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents RadioButtonExportSettings_DataFrom As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonExportSettings_TodaysData As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonExportSettings_AllData As System.Windows.Forms.RadioButton
    Friend WithEvents DateTimePickerExportSettings_DataEnd As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
    Friend WithEvents DateTimePickerExportSettings_DataStart As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
    Friend WithEvents ButtonExportCriteriaCampaign_RemoveSelected As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonExportCriteriaCampaign_RemoveAll As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonExportCriteriaCampaign_AddAll As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TabControlPanelTasks_Tasks As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabControlTask_Settings As AdvantageFramework.WinForm.Presentation.Controls.TabControl
    Friend WithEvents TabControlPanelSettingsTab_TaskSettings As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents ComboBoxTaskSettings_RunDay As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    Friend WithEvents GroupBoxTaskSettings_Notifications As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
    Friend WithEvents LabelTaskSettings_Upcoming_Between As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelTaskSettings_Upcoming_Days As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelTaskSettings_Upcoming_And As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelTaskSettings_Upcoming_CustomMessage As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelTaskSettings_PastDue_CustomMessage As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents TextBoxTaskSettings_Upcoming_CustomMessage As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents TextBoxTaskSettings_PastDue_CustomMessage As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents CheckBoxTaskSettings_Upcoming As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents CheckBoxTaskSettings_PastDue As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents LabelTaskSettings_RunDay As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelTaskSettings_RunAt As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents DateTimeInputTaskSettings_RunAt As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
    Friend WithEvents TabItemTaskSettings_SettingsTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelTaskDatabaseProfilesTab_DatabaseProfiles As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents ButtonTaskDatabaseProfiles_ProcessNow As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonTaskDatabaseProfiles_Select As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonTaskDatabaseProfiles_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonTaskDatabaseProfiles_Remove As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents DataGridViewTaskDatabaseProfiles_Databases As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    Friend WithEvents TabItemTaskSettings_DatabaseProfilesTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelLogTab_TaskLog As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TextBoxTaskLog_Log As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents TabItemTaskSettings_LogTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents ButtonTask_Stop As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents LabelTask_StatusDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelTask_Status As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ButtonTask_Start As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TabItemServices_TasksTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents CheckBoxTask_AutoStart As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents CheckBoxExport_AutoStart As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents CheckBoxQvA_AutoStart As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents CheckBoxEMail_AutoStart As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents ButtonQvA_Stop As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonQvA_Start As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TabControlPanelQvAAlertSettings_DatabaseProfielsSettings As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItemQvAAlertSettings_DatabaseProfilesTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents ButtonQvAAlertDatabaseProfiles_Select As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonQvAAlertDatabaseProfiles_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonQvAAlertDatabaseProfiles_Remove As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents DataGridViewQvAAlertDatabaseProfiles_Databases As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    Friend WithEvents TabControlPanelMissingTimeTab_MissingTime As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents CheckBoxMissingTime_AutoStart As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents ButtonMissingTime_Stop As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents LabelMissingTime_StatusDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelMissingTime_Status As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ButtonMissingTime_Start As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TabItemServices_MissingTimeTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlMissingTime_Settings As AdvantageFramework.WinForm.Presentation.Controls.TabControl
    Friend WithEvents TabControlPanelAlertsTab_Alerts As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents LabelMissingTimeAlerts_CustomMessage As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents TextBoxMissingTimeAlerts_CustomMessage As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents TabItemMissingTimeSettings_AlertsTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelSettingsTab_MissingTimeSettings As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents GroupBoxMissingTimeAlerts_Range As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
    Friend WithEvents RadioButtonMissingTimeSettings_Range_CurrentPostingPeriod As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonMissingTimeSettings_Range_DaysToCheck As System.Windows.Forms.RadioButton
    Friend WithEvents LabelMissingTimeSettings_Path As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents TextBoxMissingTimeSettings_LogFilePath As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents GroupBoxMissingTimeSettings_Interval As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
    Friend WithEvents CheckBoxMissingTimeSettings_Interval_StopAfter As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents CheckBoxMissingTimeSettings_Interval_RunAt As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents LabelMissingTimeSettings_Interval_StopAfterHours As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelMissingTimeSettings_Interval_RunEveryHours As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents CheckBoxMissingTimeSettings_Interval_RunEvery As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents ComboBoxMissingTimeSettings_Interval_RunDay As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    Friend WithEvents LabelMissingTimeSettings_Interval_RunDay As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents DateTimeInputMissingTimeSettings_Interval_RunAtTime As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
    Friend WithEvents TabItemMissingTimeSettings_SettingsTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelMissingTimeDatabaseProfilesTab_DatabaseProfiles As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents ButtonMissingTimeDatabaseProfiles_ProcessNow As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonMissingTimeDatabaseProfiles_Select As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonMissingTimeDatabaseProfiles_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonMissingTimeDatabaseProfiles_Remove As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents DataGridViewMissingTimeDatabaseProfiles_Databases As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    Friend WithEvents TabItemMissingTimeSettings_DatabaseProfilesTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelLogTab_MissingTimeLog As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TextBoxMissingTimeLog_Log As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents TabItemMissingTimeSettings_LogTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents GroupBoxMissingTimeAlerts_Priority As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
    Friend WithEvents RadioButtonMissingTimeSettings_Priority_Low As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonMissingTimeSettings_Priority_Medium As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonMissingTimeSettings_Priority_High As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBoxMissingTimeAlerts_Tracking As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
    Friend WithEvents CheckBoxMissingTimeSettings_Tracking_DontCountWeekends As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents CheckBoxMissingTimeSettings_Tracking_OnlyMissingTimesheets As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents LabelMissingTimeAlerts_DatabaseProfile As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ComboBoxMissingTimeAlerts_DatabaseProfile As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    Friend WithEvents LabelMissingTimeSettings_DatabaseProfile As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ComboBoxMissingTimeSettings_DatabaseProfile As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    Friend WithEvents GroupBoxMissingTimeAlerts_Other As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
    Friend WithEvents GroupBoxMissingTimeAlerts_Recipient As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
    Friend WithEvents LabelMissingTimeAlerts_Recipient_ITContact_GracePeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelMissingTimeAlerts_Recipient_ITContact_Days As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelMissingTimeAlerts_Recipient_Supervisor_GracePeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelMissingTimeAlerts_Recipient_Supervisor_Days As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents CheckBoxMissingTimeAlerts_Recipient_ITContact As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents LabelMissingTimeAlerts_Recipient_Employee_GracePeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelMissingTimeAlerts_Recipient_Employee_Days As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents CheckBoxMissingTimeAlerts_Recipient_Supervisor As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents CheckBoxMissingTimeAlerts_Recipient_Employee As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents LabelMissingTimeAlerts_Recipient_ITContact As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents TabControlPanelGoogleCalendarTab_GoogleCalendar As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents CheckBoxGoogleCalendar_AutoStart As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents TabControlGoogleCalendar_GoogleCalendarSettings As AdvantageFramework.WinForm.Presentation.Controls.TabControl
    Friend WithEvents TabControlPanelGoogleCalendarLogTab_GoogleCalendarLog As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TextBoxGoogleCalendarLog_Log As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents TabItemGoogleCalendarSettings_GoogleCalendarLogTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelGoogleCalendarDatabaseProfilesTab_GoogleCalendarDatabaseProfiles As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents ButtonGoogleCalendarDatabaseProfiles_Select As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonGoogleCalendarDatabaseProfiles_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonGoogleCalendarDatabaseProfiles_Remove As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents DataGridViewGoogleCalendarDatabaseProfiles_Databases As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    Friend WithEvents TabItemGoogleCalendarSettings_GoogleCalendarDatabaseProfilesTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelGoogleCalendarSettingsTab_GoogleCalendarSettings As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents LabelGoogleCalendarSettings_RunAt As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents TabItemGoogleCalendarSettings_GoogleCalendarSettingsTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents LabelGoogleCalendar_StatusDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelGoogleCalendar_Status As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ButtonGoogleCalendar_Stop As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonGoogleCalendar_Start As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TabItemServices_GoogleCalendarTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents ButtonGoogleCalendarDatabaseProfiles_ProcessNow As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TabControlPanelCoreMediaCheckExportTab_CoreMediaCheckExport As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents CheckBoxCoreMediaCheckExport_AutoStart As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents TabControlCoreMediaCheckExport_CoreMediaCheckExportSettings As AdvantageFramework.WinForm.Presentation.Controls.TabControl
    Friend WithEvents TabControlPanelCoreMediaCheckExportLogTab_CoreMediaCheckExportLog As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TextBoxCoreMediaCheckExportLog_Log As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportLogTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelCoreMediaCheckExportDatabaseProfilesTab_CoreMediaCheckExportDatabaseProfiles As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents ButtonCoreMediaCheckExportDatabaseProfiles_ProcessNow As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonCoreMediaCheckExportDatabaseProfiles_Select As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonCoreMediaCheckExportDatabaseProfiles_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonCoreMediaCheckExportDatabaseProfiles_Remove As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents DataGridViewCoreMediaCheckExportDatabaseProfiles_Databases As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    Friend WithEvents TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportDatabaseProfilesTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelCoreMediaCheckExportSettingsTab_CoreMediaCheckExportSettings As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents LabelCoreMediaCheckExportSettings_ExportPath As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelCoreMediaCheckExportSettings_RunAt As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents DateTimeInputCoreMediaCheckExportSettings_RunAt As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
    Friend WithEvents TextBoxCoreMediaCheckExportSettings_ExportPath As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents TabItemCoreMediaCheckExportSettings_CoreMediaCheckExportSettingsTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents LabelCoreMediaCheckExport_StatusDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelCoreMediaCheckExport_Status As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ButtonCoreMediaCheckExport_Start As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonCoreMediaCheckExport_Stop As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TabItemServices_CoreMediaCheckExportTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents ButtonEmailListenerDatabaseProfiles_ProcessNow As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TabControlPanelPaidTimeOffAccrualsTab_PaidTimeOffAccruals As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents CheckBoxPaidTimeOffAccruals_AutoStart As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents TabControlPaidTimeOffAccruals_PaidTimeOffAccrualsSettings As AdvantageFramework.WinForm.Presentation.Controls.TabControl
    Friend WithEvents TabControlPanelPaidTimeOffAccrualsSettingsTab_PaidTimeOffAccrualsSettings As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents ComboBoxPaidTimeOffAccrualsSettings_RunOnDay As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    Friend WithEvents LabelPaidTimeOffAccrualsSettings_RunOnDay As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsSettingsTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelPaidTimeOffAccrualsDatabaseProfilesTab_PaidTimeOffAccrualsDatabaseProfiles As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents ButtonPaidTimeOffAccrualsDatabaseProfiles_ProcessNow As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonPaidTimeOffAccrualsDatabaseProfiles_Select As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonPaidTimeOffAccrualsDatabaseProfiles_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonPaidTimeOffAccrualsDatabaseProfiles_Remove As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents DataGridViewPaidTimeOffAccrualsDatabaseProfiles_Databases As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    Friend WithEvents TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsDatabaseProfilesTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelPaidTimeOffAccrualsLogTab_PaidTimeOffAccrualsLog As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TextBoxPaidTimeOffAccrualsLog_Log As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents TabItemPaidTimeOffAccrualsSettings_PaidTimeOffAccrualsLogTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents LabelPaidTimeOffAccruals_StatusDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelPaidTimeOffAccruals_Status As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ButtonPaidTimeOffAccruals_Start As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonPaidTimeOffAccruals_Stop As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TabItemServices_PaidTimeOffAccrualsTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents LabelPaidTimeOffAccrualsSettings_LastRanDetails As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelPaidTimeOffAccrualsSettings_DatabaseProfile As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ComboBoxPaidTimeOffAccrualsSettings_DatabaseProfile As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    Friend WithEvents CheckBoxMissingTimeSettings_IncludeOnlyDaysThatAreLate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents TabControlPanelContractTab_Contract As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents CheckBoxContract_AutoStart As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents TabControlContract_ContractSettings As AdvantageFramework.WinForm.Presentation.Controls.TabControl
    Friend WithEvents TabControlPanelContractSettingsTab_ContractSettings As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItemContractSettings_ContractSettingsTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelContractDatabaseProfilesTab_ContractDatabaseProfiles As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents ButtonContractDatabaseProfiles_ProcessNow As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonContractDatabaseProfiles_Select As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonContractDatabaseProfiles_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonContractDatabaseProfiles_Remove As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents DataGridViewContractDatabaseProfiles_Databases As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    Friend WithEvents TabItemContractSettings_ContractDatabaseProfilesTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlContractLogTab_ContractLog As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItemContractSettings_ContractLogTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents LabelContract_StatusDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelContract_Status As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ButtonContract_Start As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TabItemServices_ContractTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents DateTimeInputContractAlertSettings_RunAt As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
    Friend WithEvents LabelContractAlertSettings_RunAt As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents CheckBoxContractSettings_ContractReports As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents GroupBoxContractSettings_Notifications As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
    Friend WithEvents LabelContractSettings_DaysPrior As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents CheckBoxContractSettings_ContractRenewal As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents ButtonContract_Stop As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents NumericInputEmailListenerSettings_RunAtEvery As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    Friend WithEvents NumericInputContractSettings_RenewalDaysPrior As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    Friend WithEvents NumericInputGoogleCalendarSettings_RunAt As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    Friend WithEvents NumericInputMissingTimeSettings_Interval_StopAfter As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    Friend WithEvents NumericInputMissingTimeSettings_Interval_RunEveryHours As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    Friend WithEvents NumericInputMissingTimeAlerts_Recipient_ITContact_GracePeriodDays As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    Friend WithEvents NumericInputMissingTimeAlerts_Recipient_Supervisor_GracePeriodDays As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    Friend WithEvents NumericInputMissingTimeAlerts_Recipient_Employee_GracePeriodDays As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    Friend WithEvents NumericInputMissingTimeSettings_Range_DaysToCheck As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    Friend WithEvents NumericInputTaskSettings_Upcoming_EndDays As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    Friend WithEvents NumericInputTaskSettings_Upcoming_StartDays As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    Friend WithEvents NumericInputThresholds_Level3Start As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    Friend WithEvents NumericInputThresholds_Level2End As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    Friend WithEvents NumericInputThresholds_Level2Start As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    Friend WithEvents NumericInputThresholds_Level1End As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    Friend WithEvents NumericInputThresholds_Level1Start As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    Friend WithEvents TabControlPanelMediaOceanImportTab_Import As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents CheckBoxMediaOceanImport_AutoStart As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    Friend WithEvents TabControlMediaOceanImport_MediaOceanImportSettings As AdvantageFramework.WinForm.Presentation.Controls.TabControl
    Friend WithEvents TabControlPanelMediaOceanImportSettingsTab_MediaOceanImportSettings As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TabItemMediaOceanImportSettings_MediaOceanImportSettingsTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelMediaOceanImportDatabaseProfilesTab_MediaOceanImportDatabaseProfiles As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents ButtonMediaOceanImportDatabaseProfiles_ProcessNow As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonMediaOceanImportDatabaseProfiles_Select As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonMediaOceanImportDatabaseProfiles_Edit As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents ButtonMediaOceanImportDatabaseProfiles_Remove As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents DataGridViewMediaOceanImportDatabaseProfiles_Databases As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    Friend WithEvents TabItemMediaOceanImportSettings_MediaOceanImportDatabaseProfilesTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanelMediaOceanImportLogTab_MediaOceanImportLog As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents TextBoxMediaOceanImportLog_Log As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents TabItemMediaOceanImportSettings_MediaOceanImportLogTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents LabelMediaOceanImport_StatusDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelMediaOceanImport_Status As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ButtonMediaOceanImport_Start As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TabItemServices_MediaOceanImportTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents ButtonMediaOceanImport_Stop As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TextBoxContractLog_Log As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents LabelMediaOceanImportSettings_DatabaseProfile As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ComboBoxMediaOceanImportSettings_DatabaseProfile As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    Friend WithEvents GroupBoxMediaOceanImportSettings_Settings As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
    Friend WithEvents LabelMediaOceanImportSettings_Employee As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ComboBoxMediaOceanImportSettings_Employee As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    Friend WithEvents TextBoxMediaOceanImportSettings_LocalFolder As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents LabelMediaOceanImportSettings_LocalFolder As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents ButtonMediaOceanImportSettings_ValidateFTP As AdvantageFramework.WinForm.Presentation.Controls.Button
    Friend WithEvents TextBoxMediaOceanImportSettings_FTPPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents TextBoxMediaOceanImportSettings_FTPUser As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents LabelMediaOceanImportSettings_FTPPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelMediaOceanImportSettings_FTPUser As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents TextBoxMediaOceanImportSettings_FTPAddress As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    Friend WithEvents LabelMediaOceanImportSettings_FTPAddress As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents LabelMediaOceanImportSettings_RunAt As AdvantageFramework.WinForm.Presentation.Controls.Label
    Friend WithEvents DateTimeInputMediaOceanImportSettings_RunAt As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
    Friend WithEvents RibbonBarFilePanel_Log As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
    Friend WithEvents ButtonItemLog_Refresh As DevComponents.DotNetBar.ButtonItem

End Class
