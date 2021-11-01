Namespace WinForm.Presentation.Controls

	Public Class EmployeeControl

		Public Event SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs)
		Public Event DepartmentTeamInitNewRowEvent(ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
		Public Event DepartmentTeamAddNewRowEvent(ByVal RowObject As Object)
		Public Event AlertGroupInitNewRowEvent(ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
		Public Event AlertGroupAddNewRowEvent(ByVal RowObject As Object)
		Public Event RoleInitNewRowEvent(ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
		Public Event RoleAddNewRowEvent(ByVal RowObject As Object)
		Public Event SelectedBillingRateDetailChanged()
		Public Event SelectedBillingRateLevelChanged()
		Public Event EmployeeOfficesChangedEvent()
		Public Event TimesheetFunctionsChangedEvent()
		Public Event CDPsChangedEvent()
		Public Event EmployeesChangedEvent()
		Public Event SelectedDocumentChanged()
        Public Event BillingRateDetailInitNewRowEvent()
        Public Event AdditionalEmailsSelectionChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _EmployeeCode As String = Nothing
        Private _UseEmployeeSMTPLogin As Boolean = Nothing
        Private _AllowDepartmentTeamToBeEmpty As Boolean = False
        Private _ShowDescriptions As Boolean = False
        Private _HasAccessToDocuments As Boolean = False
        Private _HasAccessToUserSecurity As Boolean = False
        Private _CanUserPrint As Boolean = False
        Private _CanUserUpdate As Boolean = False
        Private _CanUserAdd As Boolean = False
        Private _CanUserCustom1 As Boolean = False
        Private _DefaultFunctions As Generic.List(Of AdvantageFramework.Database.Core.Function) = Nothing
        Private _APIUsersQuantity As Integer = 0
        Private _AvailableAPIUsers As Integer = 0
        Private _AdditionalEmails As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeAdditionalEmail) = Nothing
        Private _RemovedAdditionalEmails As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeAdditionalEmail) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property CanUserCustom1 As Boolean
            Get
                CanUserCustom1 = _CanUserCustom1
            End Get
        End Property
        Public ReadOnly Property CanUserPrint As Boolean
            Get
                CanUserPrint = _CanUserPrint
            End Get
        End Property
        Public ReadOnly Property CanUserUpdate As Boolean
            Get
                CanUserUpdate = _CanUserUpdate
            End Get
        End Property
        Public ReadOnly Property CanUserAdd As Boolean
            Get
                CanUserAdd = _CanUserAdd
            End Get
        End Property
        Public ReadOnly Property IsAssignedToADepartmentTeam As Boolean
            Get

                Try

                    IsAssignedToADepartmentTeam = DataGridViewRightSection_EmployeeDepartmentTeams.HasRows AndAlso
                                                  DataGridViewRightSection_EmployeeDepartmentTeams.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeDepartmentTeam) _
                                                  .Where(Function(EmpDepTeam) EmpDepTeam.Default = True).Any

                Catch ex As Exception
                    IsAssignedToADepartmentTeam = DataGridViewRightSection_EmployeeDepartmentTeams.HasRows
                End Try

            End Get
        End Property
        Public ReadOnly Property IsSecurityAndPasswordsTabSelected As Boolean
            Get
                IsSecurityAndPasswordsTabSelected = If(TabControlControl_EmployeeDetails.SelectedTab Is TabItemEmployeeDetails_SecurityAndPasswords, True, False)
            End Get
        End Property
        Public ReadOnly Property IsSecurityAndPasswordsTabSelectedAndAlsoEmployeeLimits As Boolean
            Get
                IsSecurityAndPasswordsTabSelectedAndAlsoEmployeeLimits = If(TabControlControl_EmployeeDetails.SelectedTab Is TabItemEmployeeDetails_SecurityAndPasswords AndAlso TabControlSecurityAndPasswords_SecurityAndPasswords.SelectedTab Is TabItemSecurityAndPasswords_EmployeeLimitsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsSecurityAndPasswordsTabSelectedAndAlsoCDPLimits As Boolean
            Get
                IsSecurityAndPasswordsTabSelectedAndAlsoCDPLimits = If(TabControlControl_EmployeeDetails.SelectedTab Is TabItemEmployeeDetails_SecurityAndPasswords AndAlso TabControlSecurityAndPasswords_SecurityAndPasswords.SelectedTab Is TabItemSecurityAndPasswords_CDPLimitsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsSecurityAndPasswordsTabSelectedAndAlsoEmployeeTSFunctionLimits As Boolean
            Get
                IsSecurityAndPasswordsTabSelectedAndAlsoEmployeeTSFunctionLimits = If(TabControlControl_EmployeeDetails.SelectedTab Is TabItemEmployeeDetails_SecurityAndPasswords AndAlso TabControlSecurityAndPasswords_SecurityAndPasswords.SelectedTab Is TabItemSecurityAndPasswords_EmployeeTSFunctionLimitsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsSecurityAndPasswordsTabSelectedAndAlsoEmployeeOfficeLimits As Boolean
            Get
                IsSecurityAndPasswordsTabSelectedAndAlsoEmployeeOfficeLimits = If(TabControlControl_EmployeeDetails.SelectedTab Is TabItemEmployeeDetails_SecurityAndPasswords AndAlso TabControlSecurityAndPasswords_SecurityAndPasswords.SelectedTab Is TabItemSecurityAndPasswords_EmployeeOfficeLimitsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsNotesTabSelected As Boolean
            Get
                IsNotesTabSelected = If(TabControlControl_EmployeeDetails.SelectedTab Is TabItemEmployeeDetails_NotesTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsHRAndRateInformationTabSelected As Boolean
            Get
                IsHRAndRateInformationTabSelected = If(TabControlControl_EmployeeDetails.SelectedTab Is TabItemEmployeeDetails_HRAndRateInformationTab, True, False)
            End Get
        End Property
        Public ReadOnly Property HasOnlyOneSelectedBillingRateDetail As Boolean
            Get
                HasOnlyOneSelectedBillingRateDetail = RateFlagEntryControlHRAndRateInformation_BillingRateDetails.HasOnlyOneSelectedBillingRateDetail
            End Get
        End Property
        Public ReadOnly Property HasASelectedBillingRateDetail As Boolean
            Get
                HasASelectedBillingRateDetail = RateFlagEntryControlHRAndRateInformation_BillingRateDetails.HasASelectedBillingRateDetail
            End Get
        End Property
        Public ReadOnly Property EmployeeDepartmentTeams As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeDepartmentTeam)
            Get
                EmployeeDepartmentTeams = DataGridViewRightSection_EmployeeDepartmentTeams.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeDepartmentTeam).ToList
            End Get
        End Property
        Public ReadOnly Property EmployeeAlertGroups As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeAlertGroup)
            Get
                EmployeeAlertGroups = DataGridViewRightSection_EmployeeAlertGroups.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeAlertGroup).ToList
            End Get
        End Property
        Public ReadOnly Property EmployeeRoles As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeRole)
            Get
                EmployeeRoles = DataGridViewRightSection_EmployeeRoles.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeRole).ToList
            End Get
        End Property
        Public ReadOnly Property RateFlagEntryControl As AdvantageFramework.WinForm.Presentation.Controls.RateFlagEntryControl
            Get
                RateFlagEntryControl = RateFlagEntryControlHRAndRateInformation_BillingRateDetails
            End Get
        End Property
        Public ReadOnly Property EmployeeOfficeLimitControl As AdvantageFramework.WinForm.Presentation.Controls.EmployeeOfficeLimitControl
            Get
                EmployeeOfficeLimitControl = EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits
            End Get
        End Property
        Public ReadOnly Property UserEmployeeLimitControl As AdvantageFramework.WinForm.Presentation.Controls.UserEmployeeLimitControl
            Get
                UserEmployeeLimitControl = UserEmployeeLimitControlEmployeeLimits_EmployeeLimits
            End Get
        End Property
        Public ReadOnly Property UserCDPLimitControl As AdvantageFramework.WinForm.Presentation.Controls.UserCDPLimitControl
            Get
                UserCDPLimitControl = UserCDPLimitControlCDPLimits_CDPLimits
            End Get
        End Property
        Public ReadOnly Property EmployeeTimesheetFunctionLimitsControl As AdvantageFramework.WinForm.Presentation.Controls.EmployeeTimesheetFunctionLimitsControl
            Get
                EmployeeTimesheetFunctionLimitsControl = EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunctionLimits
            End Get
        End Property
        Public ReadOnly Property IsDocumentsTabSelected As Boolean
            Get
                IsDocumentsTabSelected = If(TabControlControl_EmployeeDetails.SelectedTab Is TabItemEmployeeDetails_DocumentsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property DocumentManager As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
            Get
                DocumentManager = DocumentManagerControlDocuments_EmployeeDocuments
            End Get
        End Property
        Public ReadOnly Property SelectedUserID As Integer
            Get

                Try

                    SelectedUserID = SearchableComboBoxSecurityAndPasswords_User.GetSelectedValue

                Catch ex As Exception
                    SelectedUserID = 0
                End Try

            End Get
        End Property
        Public ReadOnly Property HasAccessToDocuments As Boolean
            Get
                HasAccessToDocuments = _HasAccessToDocuments
            End Get
        End Property
        Public ReadOnly Property HasAccessToUserSecurity As Boolean
            Get
                HasAccessToUserSecurity = _HasAccessToUserSecurity
            End Get
        End Property
        Public ReadOnly Property HasASelectedAdditionalEmail As Boolean
            Get
                HasASelectedAdditionalEmail = DataGridViewAdditionalEmails_AdditionalEmails.HasASelectedRow
            End Get
        End Property
        Public ReadOnly Property IsAlertsAndSettingsTabSelectedAndAlsoAdditionalEmailsTab As Boolean
            Get
                IsAlertsAndSettingsTabSelectedAndAlsoAdditionalEmailsTab = If(TabControlControl_EmployeeDetails.SelectedTab Is TabItemEmployeeDetails_AlertsTab _
                                                                              AndAlso TabControlAlerts_Alerts.SelectedTab Is TabItemAlerts_AdditionalEmailsTab, True, False)
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            'objects
            Dim Node As DevComponents.AdvTree.Node = Nothing
            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim LicenseKey As String = ""
            Dim AgencyLicenseKey As String = ""
            Dim LicenseKeyDate As Date = Nothing
            Dim DaysUntilFileExpires As Integer = 0
            Dim DaysUntilKeyExpires As Integer = 0
            Dim PowerUsersQuantity As Integer = 0
            Dim WVOnlyUsersQuantity As Integer = 0
            Dim ClientPortalUsersQuantity As Integer = 0
            Dim MediaToolsUsersQuantity As Integer = 0
            Dim APIUsersQuantity As Integer = 0
            Dim EnableProofingTool As Boolean = False
            Dim AgencyName As String = ""
            Dim DatabaseID As Integer = 0
            Dim Roles As Dictionary(Of Integer, String) = Nothing
            Dim ProjectRoles As Dictionary(Of Integer, String) = Nothing
            Dim ErrorMessage As String = String.Empty

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        _ShowDescriptions = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, Security.UserSettings.ShowDescriptionsInRateFlagEntry)
                        _HasAccessToDocuments = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Employee)
                        _HasAccessToUserSecurity = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Security_Setup_User)

                        _CanUserPrint = AdvantageFramework.Security.CanUserPrintInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Employee)
                        _CanUserUpdate = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Employee)
                        _CanUserAdd = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Employee)
                        _CanUserCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_Employee)

                        ChangeSecurityControlSettings(False)

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Views.Employee)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                                TextBoxRightSection_DefaultDepartmentTeam.ByPassUserEntryChanged = True
                                RateFlagEntryControlHRAndRateInformation_BillingRateDetails.LimitToEmployeeLevels = True
                                RateFlagEntryControlHRAndRateInformation_BillingRateDetails.ViewInactiveBillingRateDetails = True
                                RateFlagEntryControlHRAndRateInformation_BillingRateDetails.DisableInactiveFilter = True
                                TextBoxInformation_EmployeeSignature.Visible = False

                                '
                                ' PROPERTY SETTINGS
                                '

                                ' GENERAL INFORMATION TAB
                                TextBoxGeneralInformation_Code.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.Code)
                                TextBoxGeneralInformation_FirstName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.FirstName)
                                TextBoxGeneralInformation_MiddleInitial.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.MiddleInitial)
                                TextBoxGeneralInformation_LastName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.LastName)
                                SearchableComboBoxGeneralInformation_Title.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.EmployeeTitleID)
                                SearchableComboBoxGeneralInformation_AssignedOffice.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.OfficeCode)
                                TextBoxGeneralInformation_AccountNumber.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.AccountNumber)

                                TextBoxInformationTopLeftColumn_AlternatePhone.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.AlternatePhoneNumber)
                                TextBoxInformationTopLeftColumn_CellPhone.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.CellPhoneNumber)
                                TextBoxInformationTopLeftColumn_HomePhone.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.PhoneNumber)
                                TextBoxInformationTopLeftColumn_WorkPhone.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.WorkPhoneNumber)
                                TextBoxInformationTopLeftColumn_WorkPhoneExt.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.WorkPhoneNumberExtension)

                                AddressControlInformationBottomLeftColumn_HomeAddress.SetStreetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.Address)
                                AddressControlInformationBottomLeftColumn_HomeAddress.SetAddress2PropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.Address2)
                                AddressControlInformationBottomLeftColumn_HomeAddress.SetCityPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.City)
                                AddressControlInformationBottomLeftColumn_HomeAddress.SetCountyPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.County)
                                AddressControlInformationBottomLeftColumn_HomeAddress.SetStatePropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.State)
                                AddressControlInformationBottomLeftColumn_HomeAddress.SetZipPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.Zip)
                                AddressControlInformationBottomLeftColumn_HomeAddress.SetCountryPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.Country)

                                AddressControlInformationBottomRightColumn_MailingAddress.SetStreetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.PayToAddress)
                                AddressControlInformationBottomRightColumn_MailingAddress.SetAddress2PropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.PayToAddress2)
                                AddressControlInformationBottomRightColumn_MailingAddress.SetCityPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.PayToCity)
                                AddressControlInformationBottomRightColumn_MailingAddress.SetCountyPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.PayToCounty)
                                AddressControlInformationBottomRightColumn_MailingAddress.SetStatePropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.PayToState)
                                AddressControlInformationBottomRightColumn_MailingAddress.SetZipPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.PayToZip)
                                AddressControlInformationBottomRightColumn_MailingAddress.SetCountryPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.PayToCountry)

                                TextBoxRightSection_DefaultRole.ByPassUserEntryChanged = True
                                TextBoxRightSection_DefaultDepartmentTeam.ByPassUserEntryChanged = True

                                ' TIME TRACKING TAB
                                SearchableComboBoxTimeTracking_Supervisor.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.SupervisorEmployeeCode)
                                SearchableComboBoxTimeTracking_DefaultFunction.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.FunctionCode)
                                ComboBoxTimeTracking_ReportMissingTime.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.WeeklyTimeType)
                                NumericInputTimeTracking_SeniorityPriority.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.Seniority)
                                NumericInputTimeTracking_StandardAnnualHours.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.StandardWorkHours)
                                NumericInputTimeTracking_DirectHoursGoal.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.DirectHours)
                                NumericInputTimeTracking_MonthlyBillableHoursGoal.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.MonthHoursGoal)

                                ' POs AND EXPENSE REPORTS TAB
                                NumericInputPOsAndExpenseReports_POAmountLimit.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.PurchaseOrderLimit)
                                SearchableComboBoxPOsAndExpenseReports_POApprovalRule.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.PurchaseOrderApprovalRuleCode)
                                SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.EmployeeVendorCode)
                                SearchableComboBoxPOsAndExpenseReports_AlternateApprover.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.AlternateApproverCode)
                                SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.CreditCardGLAccount)
                                TextBoxPOsAndExpenseReports_CreditCardNumber.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.CreditCardNumber)
                                TextBoxPOsAndExpenseReports_CreditCardDescription.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.CreditCardDescription)


                                ' HR AND RATE INFORMATION TAB
                                DateTimePickerHRAndRateInformation_BirthDate.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.BirthDate)
                                DateTimePickerHRAndRateInformation_DateOfLastIncrease.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.LastIncrease)
                                DateTimePickerHRAndRateInformation_EmploymentDate.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.StartDate)
                                DateTimePickerHRAndRateInformation_NextReviewDate.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.NextReview)
                                DateTimePickerHRAndRateInformation_TerminationDate.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.TerminationDate)

                                NumericInputHRAndRateInformation_AnnualSalary.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.AnnualSalary)
                                NumericInputHRAndRateInformation_MonthlySalary.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.MonthlySalary)

                                NumericInputHRAndRateInformation_BillRate.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.BillRate)
                                NumericInputHRAndRateInformation_CostRate.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.CostRate)

                                TextBoxHRAndRateInformation_OtherInfo.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.OtherInfo)

                                ' SECURITY AND PASSWORDS TAB
                                SearchableComboBoxSecurityAndPasswords_User.SetPropertySettings(AdvantageFramework.Security.Database.Entities.User.Properties.ID)
                                SearchableComboBoxSecurityAndPasswords_User.Properties.NullText = ""

                                ' ALERTS TAB
                                TextBoxSettingsRightColumn_EmailAddress.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.Email)
                                TextBoxSettingsRightColumn_ReplyToAddress.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.ReplyToEmail)
                                TextBoxSettingsRightColumn_EmailUserName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.EmailUserName)
                                TextBoxSettingsRightColumn_EmailPassword.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.EmailPassword)

                                TextBoxSettings_SugarCRMUserName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.SugarCRMUserName)
                                TextBoxSettings_SugarCRMPassword.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.SugarCRMPassword)

                                TextBoxSettings_ProofHQUserName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.ProofHQUserName)
                                TextBoxSettings_ProofHQPassword.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.ProofHQPassword)

                                TextBoxSettings_AdobeSignatureFilePassword.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.AdobeSignatureFilePassword)

                                TextBoxSettings_VCCUserName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.VCCUserName)
                                TextBoxSettings_VCCPassword.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.VCCPassword)

                                ComboBoxCalendarTime_Type.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.CalendarTimeType)
                                TextBoxCalendarTime_EmailAddress.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.CalendarTimeEmailAddress)
                                TextBoxCalendarTime_EmailUserName.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.CalendarTimeUserName)
                                TextBoxCalendarTime_EmailPassword.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.CalendarTimePassword)
                                TextBoxCalendarTime_Host.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.CalendarTimeHost)
                                TextBoxCalendarTime_Port.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.CalendarTimePort)

                                TextBoxConceptShare_Password.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.ConceptSharePassword)

                                TextBoxConceptShare_Password.ByPassUserEntryChanged = True
                                CheckBoxConceptShare_IsActive.ByPassUserEntryChanged = True
                                CheckBoxConceptShare_ShowPassword.ByPassUserEntryChanged = True

                                DataGridViewAdditionalEmails_AdditionalEmails.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.EmployeeAdditionalEmail)

                                DataGridViewAdditionalEmails_AdditionalEmails.OptionsView.ColumnAutoWidth = True
                                DataGridViewAdditionalEmails_AdditionalEmails.OptionsView.ShowColumnHeaders = False

                                ' NOTES TAB
                                TextBoxNotes_Notes.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Views.Employee.Properties.Comments)


                                '
                                ' DATASOURCES
                                '
                                LoadDropDownDataSources()

                                DbContext.Database.Connection.Open()

                                ComboBoxTimeTracking_ReportMissingTime.DataSource = From KeyValuePair In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.ReportMissingTime)).ToList
                                                                                    Select [Key] = KeyValuePair.Code,
                                                                                           [Value] = KeyValuePair.Description

                                ' H/R Information Tab
                                DateTimePickerHRAndRateInformation_TerminationDate.Enabled = False

                                NumericInputHRAndRateInformation_AnnualSalary.EditValue = Nothing
                                NumericInputHRAndRateInformation_MonthlySalary.EditValue = Nothing
                                NumericInputTimeTracking_DirectHoursGoal.EditValue = Nothing
                                NumericInputTimeTracking_MonthlyBillableHoursGoal.EditValue = Nothing
                                NumericInputTimeTracking_SeniorityPriority.EditValue = Nothing
                                NumericInputTimeTracking_StandardAnnualHours.EditValue = Nothing

                                TabItemEmployeeDetails_HRAndRateInformationTab.Visible = Not Me.CanUserCustom1

                                SearchableComboBoxSecurityAndPasswords_User.ByPassUserEntryChanged = True

                                Try

                                    _UseEmployeeSMTPLogin = CBool(AdvantageFramework.Database.Procedures.Agency.Load(DbContext).UseEmployeeEmail.GetValueOrDefault(0))

                                Catch ex As Exception
                                    _UseEmployeeSMTPLogin = False
                                End Try

                                AgencyLicenseKey = AdvantageFramework.Database.Procedures.Agency.LoadLicenseKey(DbContext)

                                If AgencyLicenseKey <> "" Then

                                    LicenseKey = AdvantageFramework.Security.LicenseKey.Read(AgencyLicenseKey, LicenseKeyDate, DaysUntilFileExpires,
                                                                                             DaysUntilKeyExpires, PowerUsersQuantity, WVOnlyUsersQuantity,
                                                                                             ClientPortalUsersQuantity, AgencyName, DatabaseID,
                                                                                             MediaToolsUsersQuantity, APIUsersQuantity, EnableProofingTool, ErrorMessage)

                                    _APIUsersQuantity = APIUsersQuantity
                                    CheckAPIUserSettingAvailability()

                                Else

                                    _AvailableAPIUsers = 0
                                    CheckBoxSettings_IsAPIUser.SecurityEnabled = False

                                End If

                                DbContext.Database.Connection.Close()

                            End Using

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub CheckAPIUserSettingAvailability()

            'objects
            Dim APIUsersAmount As Integer = 0
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If _APIUsersQuantity > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each Employee In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList

                        If AdvantageFramework.Security.IsAPIUser(Employee.Code, Employee.IsAPIUser) Then

                            APIUsersAmount += 1

                        End If

                    Next

                End Using

                If APIUsersAmount = _APIUsersQuantity Then

                    _AvailableAPIUsers = 0

                Else

                    _AvailableAPIUsers = _APIUsersQuantity - APIUsersAmount

                End If

            ElseIf _APIUsersQuantity = 0 Then

                _AvailableAPIUsers = 0

            Else

                _AvailableAPIUsers = Integer.MaxValue

            End If

        End Sub
        Private Sub LoadEmployeeDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If _EmployeeCode IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                    If Employee IsNot Nothing Then

                        If TabItem Is Nothing Then

                            For Each TabItem In TabControlControl_EmployeeDetails.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                                TabItem.Tag = False

                            Next

                            TabItem = TabControlControl_EmployeeDetails.SelectedTab

                        End If

                        If TabItem.Tag = False Then

                            If TabItem Is TabItemEmployeeDetails_GeneralInformation Then

                                LoadGeneralInformationTab(Employee)

                            ElseIf TabItem Is TabItemEmployeeDetails_AlertsTab Then

                                LoadAlertsTab(Employee)

                            ElseIf TabItem Is TabItemEmployeeDetails_DocumentsTab Then

                                LoadDocumentsTab(Employee)

                            ElseIf TabItem Is TabItemEmployeeDetails_HRAndRateInformationTab Then

                                LoadHRAndRateInformationTab(Employee)

                            ElseIf TabItem Is TabItemEmployeeDetails_NotesTab Then

                                LoadNotesTab(Employee)

                            ElseIf TabItem Is TabItemEmployeeDetails_POsAndExpenseReportsTab Then

                                LoadPOsAndExpenseReportsTab(Employee)

                            ElseIf TabItem Is TabItemEmployeeDetails_SecurityAndPasswords Then

                                LoadSecurityAndPasswordsTab(Employee)

                            ElseIf TabItem Is TabItemEmployeeDetails_TimeTrackingTab Then

                                LoadTimeTrackingTab(Employee)

                            End If

                            If TabItemEmployeeDetails_GeneralInformation.Tag = False Then

                                LoadGeneralInformationTab(Employee)

                            End If

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonRightSection_AddAlertGroup.Enabled = DataGridViewLeftSection_AvailableAlertGroups.HasOnlyOneSelectedRow
            ButtonRightSection_RemoveAlertGroup.Enabled = DataGridViewRightSection_EmployeeAlertGroups.HasOnlyOneSelectedRow
            ButtonRightSection_AddDepartmentTeam.Enabled = DataGridViewLeftSection_AvailableDepartmentTeam.HasASelectedRow
            ButtonRightSection_RemoveDepartmentTeam.Enabled = DataGridViewRightSection_EmployeeDepartmentTeams.HasASelectedRow
            ButtonRightSection_AddRole.Enabled = DataGridViewLeftSection_AvailableRoles.HasASelectedRow
            ButtonRightSection_RemoveRole.Enabled = DataGridViewRightSection_EmployeeRoles.HasASelectedRow
            ButtonRightSection_AddSecurityGroup.Enabled = DataGridViewLeftSection_AvailableSecurityGroups.HasOnlyOneSelectedRow
            ButtonRightSection_RemoveSecurityGroup.Enabled = DataGridViewRightSection_EmployeeSecurityGroups.HasOnlyOneSelectedRow

            LabelSettingsRightColumn_EmailUsername.Visible = _UseEmployeeSMTPLogin
            TextBoxSettingsRightColumn_EmailUserName.Visible = _UseEmployeeSMTPLogin
            LabelSettingsRightColumn_EmailPassword.Visible = _UseEmployeeSMTPLogin
            TextBoxSettingsRightColumn_EmailPassword.Visible = _UseEmployeeSMTPLogin

            If TextBoxSettings_AdobeSignatureFile.Tag IsNot Nothing Then

                ButtonSettings_AdobeSignatureFileDelete.Enabled = True

            Else

                ButtonSettings_AdobeSignatureFileDelete.Enabled = False

            End If

        End Sub
        Private Sub EnableOrDisableConceptShareCreateUser()

            'objects
            Dim Enable As Boolean = True

            If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm AndAlso
                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.None Then

                If ButtonConceptShare_UpdateUser.Enabled = False Then

                    Enable = (String.IsNullOrWhiteSpace(TextBoxSettingsRightColumn_EmailAddress.Text) = False)

                    If Enable Then

                        Enable = (String.IsNullOrWhiteSpace(TextBoxConceptShare_Password.Text) = False)

                    End If

                    ButtonConceptShare_CreateUser.Enabled = Enable

                Else

                    ButtonConceptShare_CreateUser.Enabled = False

                End If

            End If

        End Sub
        Private Sub LoadGeneralInformationTab(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            If Employee IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    TextBoxGeneralInformation_Code.Text = Employee.Code
                    TextBoxGeneralInformation_FirstName.Text = Employee.FirstName
                    TextBoxGeneralInformation_MiddleInitial.Text = Employee.MiddleInitial
                    TextBoxGeneralInformation_LastName.Text = Employee.LastName

                    TextBoxGeneralInformation_AccountNumber.Text = Employee.AccountNumber
                    CheckBoxGeneralInformation_Freelance.Checked = CBool(Employee.Freelance.GetValueOrDefault(0))
                    CheckBoxGeneralInformation_ActiveFreelance.Checked = Employee.IsActiveFreelance
                    CheckBoxGeneralInformation_ActiveFreelance.Enabled = CheckBoxGeneralInformation_Freelance.Checked

                    Try

                        SearchableComboBoxGeneralInformation_AssignedOffice.SelectedValue = Employee.OfficeCode

                    Catch ex As Exception
                        SearchableComboBoxGeneralInformation_AssignedOffice.SelectedValue = Nothing
                    End Try

                    Try

                        SearchableComboBoxGeneralInformation_Title.SelectedValue = Employee.EmployeeTitleID

                    Catch ex As Exception
                        SearchableComboBoxGeneralInformation_Title.SelectedValue = Nothing
                    End Try

                    ' Information Tab
                    TextBoxInformationTopLeftColumn_AlternatePhone.Text = Employee.AlternatePhoneNumber
                    TextBoxInformationTopLeftColumn_CellPhone.Text = Employee.CellPhoneNumber
                    TextBoxInformationTopLeftColumn_HomePhone.Text = Employee.PhoneNumber
                    TextBoxInformationTopLeftColumn_WorkPhone.Text = Employee.WorkPhoneNumber
                    TextBoxInformationTopLeftColumn_WorkPhoneExt.Text = Employee.WorkPhoneNumberExtension

                    AddressControlInformationBottomLeftColumn_HomeAddress.Address = Employee.Address
                    AddressControlInformationBottomLeftColumn_HomeAddress.Address2 = Employee.Address2
                    AddressControlInformationBottomLeftColumn_HomeAddress.City = Employee.City
                    AddressControlInformationBottomLeftColumn_HomeAddress.State = Employee.State
                    AddressControlInformationBottomLeftColumn_HomeAddress.Zip = Employee.Zip
                    AddressControlInformationBottomLeftColumn_HomeAddress.County = Employee.County
                    AddressControlInformationBottomLeftColumn_HomeAddress.Country = Employee.Country

                    AddressControlInformationBottomRightColumn_MailingAddress.Address = Employee.PayToAddress
                    AddressControlInformationBottomRightColumn_MailingAddress.Address2 = Employee.PayToAddress2
                    AddressControlInformationBottomRightColumn_MailingAddress.City = Employee.PayToCity
                    AddressControlInformationBottomRightColumn_MailingAddress.State = Employee.PayToState
                    AddressControlInformationBottomRightColumn_MailingAddress.Zip = Employee.PayToZip
                    AddressControlInformationBottomRightColumn_MailingAddress.County = Employee.PayToCounty
                    AddressControlInformationBottomRightColumn_MailingAddress.Country = Employee.PayToCountry

                    If Employee.SignatureImage IsNot Nothing AndAlso Employee.SignatureImage.Length > 0 Then

                        PictureBoxInformationTopRightColumn_EmployeeSignature.Tag = Employee.SignatureImage

                    Else

                        PictureBoxInformationTopRightColumn_EmployeeSignature.Tag = Nothing

                    End If

                    ' Department Team Tab
                    TextBoxRightSection_DefaultDepartmentTeam.Text = Employee.DepartmentTeamCode

                    ' Role Tab
                    TextBoxRightSection_DefaultRole.Text = Employee.RoleCode

                    ShowSignaturePreview()

                    LoadDepartmentTeams()
                    LoadEmployeeRoles()

                End Using

                TabItemEmployeeDetails_GeneralInformation.Tag = True

            End If

        End Sub
        Private Sub LoadTimeTrackingTab(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            Dim EmployeeSetting As AdvantageFramework.Database.Classes.EmployeeSetting = Nothing
            Dim FunctionCodes() As String = Nothing

            If Employee IsNot Nothing Then

                EmployeeSetting = New AdvantageFramework.Database.Classes.EmployeeSetting(Employee)

                Try

                    SearchableComboBoxTimeTracking_Supervisor.SelectedValue = Employee.SupervisorEmployeeCode

                Catch ex As Exception
                    SearchableComboBoxTimeTracking_Supervisor.SelectedValue = Nothing
                End Try

                CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.CheckValue = Employee.TimesheetApprovalFlag.GetValueOrDefault(0)

                Select Case Employee.Status

                    Case 0

                        RadioButtonControlTimeTracking_EmployeeStatusNA.Checked = True

                    Case 1

                        RadioButtonControlTimeTracking_EmployeeStatusExempt.Checked = True

                    Case 2

                        RadioButtonControlTimeTracking_EmployeeStatusNonExempt.Checked = True

                    Case Else

                        RadioButtonControlTimeTracking_EmployeeStatusNA.Checked = True

                End Select

                Try

                    If EmployeeSetting.WeeklyTimeType IsNot Nothing Then

                        ComboBoxTimeTracking_ReportMissingTime.SelectedValue = EmployeeSetting.WeeklyTimeType.ToString

                    End If

                Catch ex As Exception
                    ComboBoxTimeTracking_ReportMissingTime.SelectedIndex = 0
                End Try

                CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.Checked = Convert.ToBoolean(EmployeeSetting.TimeAlert.GetValueOrDefault(0))
                CheckBoxTimeTracking_OmitFromMissingTimeTracking.Checked = Convert.ToBoolean(EmployeeSetting.OmitFromMissingTimeTracking.GetValueOrDefault(0))

                LoadEmployeeUsers()

                LoadDefaultFunctions()

                Try

                    SearchableComboBoxTimeTracking_DefaultFunction.SelectedValue = Employee.FunctionCode

                Catch ex As Exception
                    SearchableComboBoxTimeTracking_DefaultFunction.SelectedValue = Nothing
                End Try

                If Employee.Seniority.HasValue Then

                    NumericInputTimeTracking_SeniorityPriority.EditValue = Employee.Seniority

                End If

                NumericInputTimeTracking_StandardAnnualHours.EditValue = Employee.AnnualHours
                NumericInputTimeTracking_MonthlyBillableHoursGoal.EditValue = Employee.MonthHoursGoal
                NumericInputTimeTracking_DirectHoursGoal.EditValue = Employee.DirectHours

                LoadStandardWorkDaysGrid()
                LoadVacationSickAndPersonalTimeOffGrid()

                TabItemEmployeeDetails_TimeTrackingTab.Tag = True

            End If

        End Sub
        Private Sub LoadDefaultFunctions()

            'objects
            Dim FunctionCodes() As String = Nothing

            If SearchableComboBoxSecurityAndPasswords_User.Enabled AndAlso SearchableComboBoxSecurityAndPasswords_User.HasASelectedValue Then

                If AdvantageFramework.Security.LoadUserSetting(_Session, SearchableComboBoxSecurityAndPasswords_User.GetSelectedValue, Security.UserSettings.EMP_TS_FNC) = True Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        FunctionCodes = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.LoadByEmployeeCode(DbContext, _EmployeeCode)
                                         Select Entity.FunctionCode).ToArray

                    End Using

                    SearchableComboBoxTimeTracking_DefaultFunction.DataSource = _DefaultFunctions.Where(Function(Entity) FunctionCodes.Contains(Entity.Code)).ToList

                Else

                    SearchableComboBoxTimeTracking_DefaultFunction.DataSource = _DefaultFunctions

                End If

            Else

                SearchableComboBoxTimeTracking_DefaultFunction.DataSource = _DefaultFunctions

            End If

        End Sub
        Private Sub LoadPOsAndExpenseReportsTab(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            If Employee IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ' POs
                    NumericInputPOsAndExpenseReports_POAmountLimit.EditValue = Employee.PurchaseOrderLimit

                    Try

                        SearchableComboBoxPOsAndExpenseReports_POApprovalRule.SelectedValue = Employee.PurchaseOrderApprovalRuleCode

                    Catch ex As Exception
                        SearchableComboBoxPOsAndExpenseReports_POApprovalRule.SelectedValue = Nothing
                    End Try

                    CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.Checked = Convert.ToBoolean(Employee.AllowPOGLSelection.GetValueOrDefault(0))
                    CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.Checked = Convert.ToBoolean(Employee.LimitPOGLSelectionOffice.GetValueOrDefault(0))

                    ' Expense Report Information
                    CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.Checked = CBool(Employee.SupervisorApprovalRequired.GetValueOrDefault(0))

                    Try

                        SearchableComboBoxPOsAndExpenseReports_AlternateApprover.SelectedValue = Employee.AlternateApproverCode

                    Catch ex As Exception
                        SearchableComboBoxPOsAndExpenseReports_AlternateApprover.SelectedValue = Nothing
                    End Try

                    Try

                        SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.RemoveAddedItemsFromDataSource()

                    Catch ex As Exception

                    End Try

                    Try

                        SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.SelectedValue = Employee.EmployeeVendorCode

                    Catch ex As Exception
                        SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.SelectedValue = Nothing
                    End Try

                    Try

                        If SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.HasASelectedValue = False AndAlso
                                String.IsNullOrEmpty(Employee.EmployeeVendorCode) = False Then

                            Try

                                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, Employee.EmployeeVendorCode)

                            Catch ex As Exception
                                Vendor = Nothing
                            End Try

                            If Vendor IsNot Nothing Then

                                SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.AddComboItemToExistingDataSource(Vendor.ToString, Vendor.Code, False)
                                SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.SelectedValue = Employee.EmployeeVendorCode

                                If SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.HasASelectedValue = False Then

                                    SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.SelectedValue = Nothing

                                End If

                            End If

                        End If

                    Catch ex As Exception

                    End Try

                    TextBoxPOsAndExpenseReports_CreditCardNumber.Text = Employee.CreditCardNumber

                    Try

                        SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.SelectedValue = Employee.CreditCardGLAccount

                    Catch ex As Exception
                        SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.SelectedValue = Nothing
                    End Try

                    TextBoxPOsAndExpenseReports_CreditCardDescription.Text = Employee.CreditCardDescription

                End Using

                TabItemEmployeeDetails_POsAndExpenseReportsTab.Tag = True

            End If

        End Sub
        Private Sub LoadHRAndRateInformationTab(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            If Employee IsNot Nothing Then

                DateTimePickerHRAndRateInformation_BirthDate.ValueObject = Employee.BirthDate
                DateTimePickerHRAndRateInformation_DateOfLastIncrease.ValueObject = Employee.LastIncrease
                DateTimePickerHRAndRateInformation_EmploymentDate.ValueObject = Employee.StartDate
                DateTimePickerHRAndRateInformation_NextReviewDate.ValueObject = Employee.NextReview
                DateTimePickerHRAndRateInformation_TerminationDate.ValueObject = Employee.TerminationDate

                NumericInputHRAndRateInformation_AnnualSalary.EditValue = Employee.AnnualSalary
                NumericInputHRAndRateInformation_MonthlySalary.EditValue = Employee.MonthlySalary

                NumericInputHRAndRateInformation_BillRate.EditValue = Employee.BillRate
                NumericInputHRAndRateInformation_CostRate.EditValue = Employee.CostRate

                TextBoxHRAndRateInformation_OtherInfo.Text = Employee.OtherInfo

                RateFlagEntryControlHRAndRateInformation_BillingRateDetails.ClearControl()

                RateFlagEntryControlHRAndRateInformation_BillingRateDetails.Enabled = RateFlagEntryControlHRAndRateInformation_BillingRateDetails.LoadControl(EmployeeCode:=Employee.Code, ShowDescriptions:=_ShowDescriptions)

                TabItemEmployeeDetails_HRAndRateInformationTab.Tag = True

            End If

        End Sub
        Private Sub LoadSecurityAndPasswordsTab(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            If Employee IsNot Nothing Then

                LoadEmployeeUsers()

                LoadSecurityGroups()

                LoadEmployeeOfficeLimits(Employee.Code)

                LoadEmployeeTSFunctionLimits(Employee.Code)

                TabItemEmployeeDetails_SecurityAndPasswords.Tag = True

            End If

        End Sub
        Private Sub LoadAlertsTab(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            Dim EmployeeSetting As AdvantageFramework.Database.Classes.EmployeeSetting = Nothing
            Dim ConceptShareUser As ConceptShareAPI.User = Nothing
            Dim ConceptShareAccountUser As ConceptShareAPI.AccountUser = Nothing

            If Employee IsNot Nothing Then

                EmployeeSetting = New AdvantageFramework.Database.Classes.EmployeeSetting(Employee)

                TextBoxSettingsRightColumn_EmailAddress.Text = Employee.Email
                TextBoxSettingsRightColumn_ReplyToAddress.Text = Employee.ReplyToEmail
                TextBoxSettingsRightColumn_EmailUserName.Text = Employee.EmailUserName

                If String.IsNullOrWhiteSpace(Employee.EmailPassword) = False Then

                    TextBoxSettingsRightColumn_EmailPassword.Text = AdvantageFramework.Security.Encryption.Decrypt(Employee.EmailPassword)

                Else

                    TextBoxSettingsRightColumn_EmailPassword.Text = Employee.EmailPassword

                End If

                CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.Checked = EmployeeSetting.ReceivesEmail

                If CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.Checked Then

                    CheckBoxSettingsRightColumn_ReceivesAlerts.Checked = True

                Else

                    CheckBoxSettingsRightColumn_ReceivesAlerts.Checked = EmployeeSetting.ReceivesAlerts

                End If

                CheckBoxSettings_IsAPIUser.Checked = AdvantageFramework.Security.IsAPIUser(Employee.Code, Employee.IsAPIUser)
                CheckBoxSettings_IgnoreCalendarSync.Checked = Employee.IgnoreCalendarSync

                TextBoxSettings_SugarCRMUserName.Text = Employee.SugarCRMUserName
                TextBoxSettings_SugarCRMPassword.Text = Employee.SugarCRMPassword

                TextBoxSettings_ProofHQUserName.Text = Employee.ProofHQUserName
                TextBoxSettings_ProofHQPassword.Text = Employee.ProofHQPassword

                TextBoxSettings_AdobeSignatureFile.Tag = Employee.AdobeSignatureFile
                TextBoxSettings_AdobeSignatureFilePassword.Text = Employee.AdobeSignatureFilePassword

                TextBoxSettings_VCCUserName.Text = Employee.VCCUserName
                TextBoxSettings_VCCPassword.Text = Employee.VCCPassword

                ComboBoxCalendarTime_Type.SelectedValue = Employee.CalendarTimeType.ToString
                TextBoxCalendarTime_EmailAddress.Text = Employee.CalendarTimeEmailAddress
                TextBoxCalendarTime_EmailUserName.Text = Employee.CalendarTimeUserName
                TextBoxCalendarTime_EmailPassword.Text = Employee.CalendarTimePassword
                TextBoxCalendarTime_Host.Text = Employee.CalendarTimeHost
                TextBoxCalendarTime_Port.Text = Employee.CalendarTimePort.ToString
                If Employee.CalendarTimeSSL = True Then
                    CheckBoxForm_SSL.Checked = True
                End If

                If ComboBoxCalendarTime_Type.SelectedValue = 1 Or ComboBoxCalendarTime_Type.SelectedValue = 2 Then
                    If ComboBoxCalendarTime_Type.SelectedValue = 1 Then
                        TextBoxCalendarTime_EmailUserName.Visible = False
                        TextBoxCalendarTime_EmailPassword.Visible = False
                        Me.Label13.Visible = False
                        Me.Label14.Visible = False
                    Else
                        TextBoxCalendarTime_EmailUserName.Visible = True
                        TextBoxCalendarTime_EmailPassword.Visible = True
                        Me.Label13.Visible = True
                        Me.Label14.Visible = True
                    End If
                    TextBoxCalendarTime_Host.Visible = False
                    Me.Label2.Visible = False
                    TextBoxCalendarTime_Port.Visible = False
                    Me.Label3.Visible = False
                    Me.CheckBoxForm_SSL.Visible = False
                Else
                    TextBoxCalendarTime_Host.Visible = True
                    Me.Label2.Visible = True
                    TextBoxCalendarTime_Port.Visible = True
                    Me.Label3.Visible = True
                    Me.CheckBoxForm_SSL.Visible = True
                    TextBoxCalendarTime_EmailUserName.Visible = True
                    TextBoxCalendarTime_EmailPassword.Visible = True
                    Me.Label13.Visible = True
                    Me.Label14.Visible = True
                End If

                If String.IsNullOrWhiteSpace(Employee.ConceptSharePassword) = False Then

                    TextBoxConceptShare_Password.Text = AdvantageFramework.Security.Encryption.Decrypt(Employee.ConceptSharePassword)

                End If

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.ConceptShare.IsConceptShareEnabled(DataContext) = False Then

                        TextBoxConceptShare_Password.Text = ""
                        CheckBoxConceptShare_IsActive.Checked = True

                        ButtonConceptShare_CreateUser.SecurityEnabled = False
                        ButtonConceptShare_UpdateUser.SecurityEnabled = False
                        ButtonConceptShare_RemoveUser.SecurityEnabled = False
                        TextBoxConceptShare_Password.SecurityEnabled = False
                        CheckBoxConceptShare_IsActive.SecurityEnabled = False

                    Else

                        ButtonConceptShare_CreateUser.Enabled = False
                        ButtonConceptShare_UpdateUser.Enabled = (Employee.ConceptShareUserID.GetValueOrDefault(0) > 0)
                        ButtonConceptShare_RemoveUser.Enabled = (Employee.ConceptShareUserID.GetValueOrDefault(0) > 0)

                        If Employee.ConceptShareUserID.GetValueOrDefault(0) > 0 Then

                            Try

                                ConceptShareAccountUser = AdvantageFramework.ConceptShare.LoadUser(DataContext, Employee, ConceptShareUser)

                            Catch ex As Exception

                            End Try

                            If ConceptShareUser IsNot Nothing AndAlso ConceptShareAccountUser IsNot Nothing Then

                                CheckBoxConceptShare_IsActive.Checked = ConceptShareUser.IsActive

                            Else

                                CheckBoxConceptShare_IsActive.Checked = False

                            End If

                        Else

                            TextBoxConceptShare_Password.Text = ""
                            CheckBoxConceptShare_IsActive.Checked = True

                        End If

                    End If

                End Using

                LoadEmployeeAlertGroups()

                _RemovedAdditionalEmails = New Generic.List(Of AdvantageFramework.Database.Entities.EmployeeAdditionalEmail)

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        _AdditionalEmails = DbContext.EmployeeAdditionalEmails.Where(Function(Entity) Entity.EmployeeCode = Employee.Code).ToList

                    End Using

                Catch ex As Exception
                    _AdditionalEmails = New Generic.List(Of AdvantageFramework.Database.Entities.EmployeeAdditionalEmail)
                End Try

                DataGridViewAdditionalEmails_AdditionalEmails.DataSource = _AdditionalEmails

                TabItemEmployeeDetails_AlertsTab.Tag = True

            End If

        End Sub
        Private Sub LoadNotesTab(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            If Employee IsNot Nothing Then

                TextBoxNotes_Notes.Text = Employee.Comments

                TabItemEmployeeDetails_NotesTab.Tag = True

            End If

        End Sub
        Private Sub LoadDepartmentTeams()

            Dim EmployeeDepartmentTeams As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeDepartmentTeam) = Nothing
            Dim DepartmentTeams As Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam) = Nothing
            Dim AvailableDepartmentTeams As Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam) = Nothing
            Dim DefaultDepartmentTeamCode As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DepartmentTeams = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext).ToList

                DefaultDepartmentTeamCode = TextBoxRightSection_DefaultDepartmentTeam.Text

                If _EmployeeCode IsNot Nothing Then

                    Try

                        EmployeeDepartmentTeams = AdvantageFramework.Database.Procedures.EmployeeDepartment.LoadByEmployeeCode(DbContext, _EmployeeCode).ToList.Select(Function(EmpDept) New AdvantageFramework.Database.Classes.EmployeeDepartmentTeam(EmpDept, If(EmpDept.DepartmentTeamCode = DefaultDepartmentTeamCode, True, False))).ToList

                    Catch ex As Exception
                        EmployeeDepartmentTeams = Nothing
                    End Try

                Else

                    Try

                        EmployeeDepartmentTeams = DataGridViewRightSection_EmployeeDepartmentTeams.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeDepartmentTeam).ToList

                        For Each EmployeeDepartmentTeam In EmployeeDepartmentTeams

                            EmployeeDepartmentTeam.Default = If(EmployeeDepartmentTeam.DepartmentTeamCode = DefaultDepartmentTeamCode, True, False)

                        Next

                    Catch ex As Exception
                        EmployeeDepartmentTeams = New Generic.List(Of AdvantageFramework.Database.Classes.EmployeeDepartmentTeam)
                    End Try

                End If

                If EmployeeDepartmentTeams IsNot Nothing AndAlso EmployeeDepartmentTeams.Count > 0 Then

                    For Each EmployeeDepartmentTeam In EmployeeDepartmentTeams

                        Try

                            EmployeeDepartmentTeam.DepartmentTeamName = DepartmentTeams.Single(Function(item) item.Code = EmployeeDepartmentTeam.DepartmentTeamCode).Description

                        Catch ex As Exception

                        End Try

                    Next

                    AvailableDepartmentTeams = DepartmentTeams.Where(Function(DeptTeam) EmployeeDepartmentTeams.Where(Function(EmpDeptTeam) EmpDeptTeam.DepartmentTeamCode = DeptTeam.Code).Any = False).ToList

                Else

                    AvailableDepartmentTeams = DepartmentTeams

                End If

                DataGridViewLeftSection_AvailableDepartmentTeam.DataSource = AvailableDepartmentTeams
                DataGridViewLeftSection_AvailableDepartmentTeam.CurrentView.BestFitColumns()

                DataGridViewLeftSection_AvailableDepartmentTeam.MakeIsInactiveColumnNotVisible()

                DataGridViewRightSection_EmployeeDepartmentTeams.DataSource = EmployeeDepartmentTeams
                DataGridViewRightSection_EmployeeDepartmentTeams.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadEmployeeAlertGroups()

            Dim EmployeeAlertGroups As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeAlertGroup) = Nothing
            Dim AlertGroups As Generic.List(Of AdvantageFramework.Database.Entities.AlertGroup) = Nothing
            Dim AvailableAlertGroups As Generic.List(Of AdvantageFramework.Database.Entities.AlertGroup) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                AlertGroups = AdvantageFramework.Database.Procedures.AlertGroup.LoadAllActiveDistinctAlertGroups(DbContext).ToList

                If _EmployeeCode IsNot Nothing Then

                    Try

                        EmployeeAlertGroups = AdvantageFramework.Database.Procedures.AlertGroup.LoadByEmployeeCode(DbContext, _EmployeeCode).ToList.Select(Function(EmpAlertGroup) New AdvantageFramework.Database.Classes.EmployeeAlertGroup(EmpAlertGroup)).ToList

                    Catch ex As Exception
                        EmployeeAlertGroups = Nothing
                    End Try

                Else

                    Try

                        EmployeeAlertGroups = DataGridViewRightSection_EmployeeAlertGroups.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeAlertGroup)().ToList

                    Catch ex As Exception
                        EmployeeAlertGroups = New Generic.List(Of AdvantageFramework.Database.Classes.EmployeeAlertGroup)
                    End Try

                End If

                If EmployeeAlertGroups IsNot Nothing AndAlso EmployeeAlertGroups.Count > 0 Then

                    AvailableAlertGroups = AlertGroups.Where(Function(AlertGroup) EmployeeAlertGroups.Where(Function(EmpAlertGroup) EmpAlertGroup.AlertGroupCode = AlertGroup.Code).Any = False).ToList

                Else

                    AvailableAlertGroups = AlertGroups

                End If

                DataGridViewRightSection_EmployeeAlertGroups.DataSource = EmployeeAlertGroups
                DataGridViewRightSection_EmployeeAlertGroups.CurrentView.BestFitColumns()

                DataGridViewRightSection_EmployeeAlertGroups.MakeIsInactiveColumnNotVisible()

                DataGridViewLeftSection_AvailableAlertGroups.DataSource = AvailableAlertGroups
                DataGridViewLeftSection_AvailableAlertGroups.CurrentView.BestFitColumns()

                DataGridViewLeftSection_AvailableAlertGroups.MakeIsInactiveColumnNotVisible()

            End Using

        End Sub
        Private Sub LoadEmployeeRoles()

            Dim Roles As Generic.List(Of AdvantageFramework.Database.Entities.Role) = Nothing
            Dim AvailableRoles As Generic.List(Of AdvantageFramework.Database.Entities.Role) = Nothing
            Dim EmployeeRoles As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeRole) = Nothing
            Dim EmployeeRole As AdvantageFramework.Database.Classes.EmployeeRole = Nothing
            Dim DefaultRoleCode As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Roles = AdvantageFramework.Database.Procedures.Role.LoadAllActive(DbContext).ToList

                DefaultRoleCode = TextBoxRightSection_DefaultRole.Text

                If _EmployeeCode IsNot Nothing Then

                    Try

                        EmployeeRoles = New Generic.List(Of AdvantageFramework.Database.Classes.EmployeeRole)

                        For Each EmpRole In AdvantageFramework.Database.Procedures.EmployeeRole.LoadByEmployeeCode(DbContext, _EmployeeCode).ToList

                            EmployeeRole = New AdvantageFramework.Database.Classes.EmployeeRole

                            EmployeeRole.EmployeeCode = _EmployeeCode
                            EmployeeRole.RoleCode = EmpRole.RoleCode
                            EmployeeRole.RoleDescription = EmpRole.Role.Description

                            If EmployeeRole.RoleCode = DefaultRoleCode Then

                                EmployeeRole.Default = True

                            End If

                            EmployeeRoles.Add(EmployeeRole)

                        Next

                    Catch ex As Exception
                        EmployeeRoles = Nothing
                    End Try

                Else

                    Try

                        EmployeeRoles = DataGridViewRightSection_EmployeeRoles.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeRole).ToList

                        For Each EmployeeRole In EmployeeRoles

                            EmployeeRole.Default = If(EmployeeRole.RoleCode = DefaultRoleCode, True, False)

                        Next

                    Catch ex As Exception
                        EmployeeRoles = New Generic.List(Of AdvantageFramework.Database.Classes.EmployeeRole)
                    End Try

                End If

                If EmployeeRoles IsNot Nothing AndAlso EmployeeRoles.Count > 0 Then

                    AvailableRoles = Roles.Where(Function(Role) EmployeeRoles.Where(Function(EmpRole) EmpRole.RoleCode = Role.Code).Any = False).ToList

                Else

                    AvailableRoles = Roles

                End If

                DataGridViewLeftSection_AvailableRoles.DataSource = AvailableRoles
                DataGridViewLeftSection_AvailableRoles.CurrentView.BestFitColumns()

                DataGridViewLeftSection_AvailableRoles.MakeIsInactiveColumnNotVisible()

                DataGridViewRightSection_EmployeeRoles.DataSource = EmployeeRoles
                DataGridViewRightSection_EmployeeRoles.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadStandardWorkDaysGrid()

            ' objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeStandardTime As AdvantageFramework.Database.Classes.EmployeeStandardTime = Nothing
            Dim EmployeeStandardTimeList As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeStandardTime) = Nothing
            Dim WorkDays As String() = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _EmployeeCode IsNot Nothing Then

                    Try

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                    Catch ex As Exception
                        Employee = Nothing
                    End Try

                End If

                EmployeeStandardTimeList = New Generic.List(Of AdvantageFramework.Database.Classes.EmployeeStandardTime)

                Try

                    If Employee IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Employee.WorkDays) = False AndAlso
                            Employee.WorkDays.Contains(",") Then

                        WorkDays = Employee.WorkDays.Split(",")

                    End If

                Catch ex As Exception
                    WorkDays = Nothing
                End Try

                For Each DayOfWeek In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Days))

                    Select Case DayOfWeek.Value

                        Case AdvantageFramework.DateUtilities.Days.Monday.ToString

                            EmployeeStandardTime = New AdvantageFramework.Database.Classes.EmployeeStandardTime(AdvantageFramework.DateUtilities.Days.Monday)

                            If Employee IsNot Nothing Then

                                EmployeeStandardTime.StartTime = Employee.MondayStartTime
                                EmployeeStandardTime.EndTime = Employee.MondayEndTime
                                EmployeeStandardTime.Hours = Employee.MondayHours

                            End If

                        Case AdvantageFramework.DateUtilities.Days.Tuesday.ToString

                            EmployeeStandardTime = New AdvantageFramework.Database.Classes.EmployeeStandardTime(AdvantageFramework.DateUtilities.Days.Tuesday)

                            If Employee IsNot Nothing Then

                                EmployeeStandardTime.StartTime = Employee.TuesdayStartTime
                                EmployeeStandardTime.EndTime = Employee.TuesdayEndTime
                                EmployeeStandardTime.Hours = Employee.TuesdayHours

                            End If

                        Case AdvantageFramework.DateUtilities.Days.Wednesday.ToString

                            EmployeeStandardTime = New AdvantageFramework.Database.Classes.EmployeeStandardTime(AdvantageFramework.DateUtilities.Days.Wednesday)

                            If Employee IsNot Nothing Then

                                EmployeeStandardTime.StartTime = Employee.WednesdayStartTime
                                EmployeeStandardTime.EndTime = Employee.WednesdayEndTime
                                EmployeeStandardTime.Hours = Employee.WednesdayHours

                            End If

                        Case AdvantageFramework.DateUtilities.Days.Thursday.ToString

                            EmployeeStandardTime = New AdvantageFramework.Database.Classes.EmployeeStandardTime(AdvantageFramework.DateUtilities.Days.Thursday)

                            If Employee IsNot Nothing Then

                                EmployeeStandardTime.StartTime = Employee.ThursdayStartTime
                                EmployeeStandardTime.EndTime = Employee.ThursdayEndTime
                                EmployeeStandardTime.Hours = Employee.ThursdayHours

                            End If

                        Case AdvantageFramework.DateUtilities.Days.Friday.ToString

                            EmployeeStandardTime = New AdvantageFramework.Database.Classes.EmployeeStandardTime(AdvantageFramework.DateUtilities.Days.Friday)

                            If Employee IsNot Nothing Then

                                EmployeeStandardTime.StartTime = Employee.FridayStartTime
                                EmployeeStandardTime.EndTime = Employee.FridayEndTime
                                EmployeeStandardTime.Hours = Employee.FridayHours

                            End If

                        Case AdvantageFramework.DateUtilities.Days.Saturday.ToString

                            EmployeeStandardTime = New AdvantageFramework.Database.Classes.EmployeeStandardTime(AdvantageFramework.DateUtilities.Days.Saturday)

                            If Employee IsNot Nothing Then

                                EmployeeStandardTime.StartTime = Employee.SaturdayStartTime
                                EmployeeStandardTime.EndTime = Employee.SaturdayEndTime
                                EmployeeStandardTime.Hours = Employee.SaturdayHours

                            End If

                        Case AdvantageFramework.DateUtilities.Days.Sunday.ToString

                            EmployeeStandardTime = New AdvantageFramework.Database.Classes.EmployeeStandardTime(AdvantageFramework.DateUtilities.Days.Sunday)

                            If Employee IsNot Nothing Then

                                EmployeeStandardTime.StartTime = Employee.SundayStartTime
                                EmployeeStandardTime.EndTime = Employee.SundayEndTime
                                EmployeeStandardTime.Hours = Employee.SundayHours

                            End If

                    End Select

                    If WorkDays IsNot Nothing Then

                        EmployeeStandardTime.DoesWork = WorkDays.Where(Function(WorkDay) WorkDay = EmployeeStandardTime.DayOfWeek.ToString.Substring(0, 3)).Any

                    End If

                    EmployeeStandardTimeList.Add(EmployeeStandardTime)

                Next

                DataGridViewTimeTracking_WorkDays.DataSource = EmployeeStandardTimeList
                DataGridViewTimeTracking_WorkDays.CurrentView.BestFitColumns()

                SetGridDisplaySettings()

            End Using

        End Sub
        Private Sub LoadVacationSickAndPersonalTimeOffGrid()

            ' objects
            Dim EmployeeTimeOff As AdvantageFramework.Database.Classes.EmployeeTimeOff = Nothing
            Dim EmployeeTimeOffList As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeTimeOff) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _EmployeeCode IsNot Nothing Then

                    Try

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                    Catch ex As Exception
                        Employee = Nothing
                    End Try

                End If

                EmployeeTimeOffList = New Generic.List(Of AdvantageFramework.Database.Classes.EmployeeTimeOff)

                For Each PTOType In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.PTOTypes))

                    Select Case PTOType.Value

                        Case AdvantageFramework.Database.Entities.PTOTypes.Vacation.ToString

                            EmployeeTimeOff = New AdvantageFramework.Database.Classes.EmployeeTimeOff(AdvantageFramework.Database.Entities.PTOTypes.Vacation)

                            If Employee IsNot Nothing Then

                                EmployeeTimeOff.DateFrom = Employee.VacationDateFrom
                                EmployeeTimeOff.DateTo = Employee.VacationDateTo
                                EmployeeTimeOff.HoursAllowed = Employee.VacationHours

                                If Employee.VacationTimeRule.HasValue Then

                                    EmployeeTimeOff.TimeRule = CInt(Employee.VacationTimeRule.Value)

                                End If

                            End If

                        Case AdvantageFramework.Database.Entities.PTOTypes.Sick.ToString

                            EmployeeTimeOff = New AdvantageFramework.Database.Classes.EmployeeTimeOff(AdvantageFramework.Database.Entities.PTOTypes.Sick)

                            If Employee IsNot Nothing Then

                                EmployeeTimeOff.DateFrom = Employee.SickDateFrom
                                EmployeeTimeOff.DateTo = Employee.SickDateTo
                                EmployeeTimeOff.HoursAllowed = Employee.SickHours

                                If Employee.SickTimeRule.HasValue Then

                                    EmployeeTimeOff.TimeRule = CInt(Employee.SickTimeRule.Value)

                                End If

                            End If

                        Case AdvantageFramework.Database.Entities.PTOTypes.Personal.ToString

                            EmployeeTimeOff = New AdvantageFramework.Database.Classes.EmployeeTimeOff(AdvantageFramework.Database.Entities.PTOTypes.Personal)

                            If Employee IsNot Nothing Then

                                EmployeeTimeOff.DateFrom = Employee.PersonalHoursDateFrom
                                EmployeeTimeOff.DateTo = Employee.PersonalHoursDateTo
                                EmployeeTimeOff.HoursAllowed = Employee.PersonalHours

                                If Employee.PersonalTimeRule.HasValue Then

                                    EmployeeTimeOff.TimeRule = CInt(Employee.PersonalTimeRule.Value)

                                End If

                            End If

                    End Select

                    EmployeeTimeOffList.Add(EmployeeTimeOff)

                Next

                DataGridViewTimeTracking_EmployeeTimeOff.DataSource = EmployeeTimeOffList
                DataGridViewTimeTracking_EmployeeTimeOff.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadEmployeeOfficeLimits(ByVal EmployeeCode As String)

            EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.ClearControl()

            If EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.LoadControl(New Generic.List(Of String)({EmployeeCode})) = False Then

                EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.Enabled = False

            Else

                EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.Enabled = True

            End If

        End Sub
        Private Sub LoadEmployeeTSFunctionLimits(ByVal EmployeeCode As String)

            EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunctionLimits.ClearControl()

            If EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunctionLimits.LoadControl(New Generic.List(Of String)({EmployeeCode})) = False Then

                EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunctionLimits.Enabled = False

            Else

                EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunctionLimits.Enabled = True

            End If

        End Sub
        Private Sub LoadEmployeeLimits()

            UserEmployeeLimitControlEmployeeLimits_EmployeeLimits.ClearControl()

            If SearchableComboBoxSecurityAndPasswords_User.HasASelectedValue Then

                If UserEmployeeLimitControlEmployeeLimits_EmployeeLimits.LoadControl(New Generic.List(Of String)({SearchableComboBoxSecurityAndPasswords_User.Text})) = False Then

                    UserEmployeeLimitControlEmployeeLimits_EmployeeLimits.Enabled = False

                Else

                    UserEmployeeLimitControlEmployeeLimits_EmployeeLimits.Enabled = True

                End If

            Else

                UserEmployeeLimitControlEmployeeLimits_EmployeeLimits.Enabled = False

            End If

        End Sub
        Private Sub LoadCDPsLimits()

            UserCDPLimitControlCDPLimits_CDPLimits.ClearControl()

            If SearchableComboBoxSecurityAndPasswords_User.HasASelectedValue Then

                If UserCDPLimitControlCDPLimits_CDPLimits.LoadControl(New Generic.List(Of String)({SearchableComboBoxSecurityAndPasswords_User.Text})) = False Then

                    UserCDPLimitControlCDPLimits_CDPLimits.Enabled = False

                Else

                    UserCDPLimitControlCDPLimits_CDPLimits.Enabled = True

                End If

            Else

                UserCDPLimitControlCDPLimits_CDPLimits.Enabled = False

            End If

        End Sub
        Private Sub LoadSecurityGroups()

            Dim UserID As String = Nothing
            Dim GroupUsers As Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupUser) = Nothing
            Dim AvailableGroups As Generic.List(Of AdvantageFramework.Security.Database.Entities.Group) = Nothing
            Dim SelectedGroups As Generic.List(Of AdvantageFramework.Security.Database.Entities.Group) = Nothing
            Dim Groups As Generic.List(Of AdvantageFramework.Security.Database.Entities.Group) = Nothing

            If SearchableComboBoxSecurityAndPasswords_User.HasASelectedValue Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    UserID = SearchableComboBoxSecurityAndPasswords_User.GetSelectedValue

                    GroupUsers = AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, UserID).ToList

                    Groups = AdvantageFramework.Security.Database.Procedures.Group.Load(SecurityDbContext).ToList

                    Try

                        SelectedGroups = (From Entity In Groups
                                          Where GroupUsers.Where(Function(GroupUser) GroupUser.GroupID = Entity.ID).Any = True
                                          Select Entity).ToList

                    Catch ex As Exception
                        SelectedGroups = New Generic.List(Of AdvantageFramework.Security.Database.Entities.Group)
                    End Try

                    Try

                        AvailableGroups = (From Entity In Groups
                                           Where GroupUsers.Where(Function(GroupUser) GroupUser.GroupID = Entity.ID).Any = False
                                           Select Entity).ToList

                    Catch ex As Exception
                        AvailableGroups = New Generic.List(Of AdvantageFramework.Security.Database.Entities.Group)
                    End Try

                End Using

            Else

                SelectedGroups = New Generic.List(Of AdvantageFramework.Security.Database.Entities.Group)

                AvailableGroups = New Generic.List(Of AdvantageFramework.Security.Database.Entities.Group)

            End If

            DataGridViewLeftSection_AvailableSecurityGroups.DataSource = AvailableGroups
            DataGridViewLeftSection_AvailableSecurityGroups.CurrentView.BestFitColumns()
            DataGridViewLeftSection_AvailableSecurityGroups.CurrentView.ViewCaption = DataGridViewLeftSection_AvailableSecurityGroups.CurrentView.RowCount & " Available Group(s)"

            DataGridViewRightSection_EmployeeSecurityGroups.DataSource = SelectedGroups
            DataGridViewRightSection_EmployeeSecurityGroups.CurrentView.BestFitColumns()
            DataGridViewRightSection_EmployeeSecurityGroups.CurrentView.ViewCaption = DataGridViewRightSection_EmployeeSecurityGroups.CurrentView.RowCount & " User Group(s)"

        End Sub
        Private Sub SaveGeneralInformationTab(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            If Employee IsNot Nothing Then

                Employee.Code = TextBoxGeneralInformation_Code.Text
                Employee.FirstName = TextBoxGeneralInformation_FirstName.Text
                Employee.MiddleInitial = TextBoxGeneralInformation_MiddleInitial.Text
                Employee.LastName = TextBoxGeneralInformation_LastName.Text

                Employee.AccountNumber = TextBoxGeneralInformation_AccountNumber.Text

                Employee.Freelance = Convert.ToInt16(CheckBoxGeneralInformation_Freelance.Checked)
                Employee.IsActiveFreelance = CheckBoxGeneralInformation_ActiveFreelance.Checked

                Employee.OfficeCode = SearchableComboBoxGeneralInformation_AssignedOffice.GetSelectedValue
                Employee.EmployeeTitleID = SearchableComboBoxGeneralInformation_Title.GetSelectedValue

                ' Information Tab
                Employee.AlternatePhoneNumber = TextBoxInformationTopLeftColumn_AlternatePhone.Text
                Employee.CellPhoneNumber = TextBoxInformationTopLeftColumn_CellPhone.Text
                Employee.PhoneNumber = TextBoxInformationTopLeftColumn_HomePhone.Text
                Employee.WorkPhoneNumber = TextBoxInformationTopLeftColumn_WorkPhone.Text
                Employee.WorkPhoneNumberExtension = TextBoxInformationTopLeftColumn_WorkPhoneExt.Text

                Employee.Address = AddressControlInformationBottomLeftColumn_HomeAddress.Address
                Employee.Address2 = AddressControlInformationBottomLeftColumn_HomeAddress.Address2
                Employee.City = AddressControlInformationBottomLeftColumn_HomeAddress.City
                Employee.State = AddressControlInformationBottomLeftColumn_HomeAddress.State
                Employee.Zip = AddressControlInformationBottomLeftColumn_HomeAddress.Zip
                Employee.County = AddressControlInformationBottomLeftColumn_HomeAddress.County
                Employee.Country = AddressControlInformationBottomLeftColumn_HomeAddress.Country

                Employee.PayToAddress = AddressControlInformationBottomRightColumn_MailingAddress.Address
                Employee.PayToAddress2 = AddressControlInformationBottomRightColumn_MailingAddress.Address2
                Employee.PayToCity = AddressControlInformationBottomRightColumn_MailingAddress.City
                Employee.PayToState = AddressControlInformationBottomRightColumn_MailingAddress.State
                Employee.PayToZip = AddressControlInformationBottomRightColumn_MailingAddress.Zip
                Employee.PayToCounty = AddressControlInformationBottomRightColumn_MailingAddress.County
                Employee.PayToCountry = AddressControlInformationBottomRightColumn_MailingAddress.Country

                ' Department Team Tab
                Employee.DepartmentTeamCode = TextBoxRightSection_DefaultDepartmentTeam.Text

                ' Role Tab
                Employee.RoleCode = TextBoxRightSection_DefaultRole.Text

                If TypeOf PictureBoxInformationTopRightColumn_EmployeeSignature.Tag Is System.Byte() Then

                    Employee.SignatureImage = PictureBoxInformationTopRightColumn_EmployeeSignature.Tag

                End If

            End If

        End Sub
        Private Sub SaveTimeTrackingTab(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            Dim EmployeeSetting As AdvantageFramework.Database.Classes.EmployeeSetting = Nothing

            If Employee IsNot Nothing Then

                DataGridViewTimeTracking_WorkDays.CurrentView.CloseEditorForUpdating()

                EmployeeSetting = New AdvantageFramework.Database.Classes.EmployeeSetting(Employee)

                Employee.SupervisorEmployeeCode = SearchableComboBoxTimeTracking_Supervisor.GetSelectedValue

                Employee.TimesheetApprovalFlag = CheckBoxTimeTracking_ExemptFromTimeEntrySupervisorApproval.Checked

                If RadioButtonControlTimeTracking_EmployeeStatusNA.Checked Then

                    Employee.Status = 0

                ElseIf RadioButtonControlTimeTracking_EmployeeStatusExempt.Checked Then

                    Employee.Status = 1

                ElseIf RadioButtonControlTimeTracking_EmployeeStatusNonExempt.Checked Then

                    Employee.Status = 2

                Else

                    Employee.Status = 0

                End If

                If ComboBoxTimeTracking_ReportMissingTime.HasASelectedValue Then

                    EmployeeSetting.WeeklyTimeType = Convert.ToInt16(ComboBoxTimeTracking_ReportMissingTime.GetSelectedValue)

                Else

                    EmployeeSetting.WeeklyTimeType = Nothing

                End If

                EmployeeSetting.TimeAlert = Convert.ToInt16(CheckBoxTimeTracking_ActivateMissingTimeAlertOnTimesheet.Checked)
                EmployeeSetting.OmitFromMissingTimeTracking = Convert.ToInt16(CheckBoxTimeTracking_OmitFromMissingTimeTracking.Checked)
                Employee.FunctionCode = SearchableComboBoxTimeTracking_DefaultFunction.GetSelectedValue

                Employee.Seniority = NumericInputTimeTracking_SeniorityPriority.GetValue

                Employee.AnnualHours = NumericInputTimeTracking_StandardAnnualHours.GetValue
                Employee.MonthHoursGoal = NumericInputTimeTracking_MonthlyBillableHoursGoal.GetValue
                Employee.DirectHours = NumericInputTimeTracking_DirectHoursGoal.GetValue

                SaveStandardWorkDays(Employee)
                SaveVacationSickAndPersonalTime(Employee)

            End If

        End Sub
        Private Sub SavePOsAndExpenseReportsTab(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            If Employee IsNot Nothing Then

                ' POs
                Employee.PurchaseOrderLimit = NumericInputPOsAndExpenseReports_POAmountLimit.GetValue
                Employee.PurchaseOrderApprovalRuleCode = SearchableComboBoxPOsAndExpenseReports_POApprovalRule.GetSelectedValue
                Employee.AllowPOGLSelection = Convert.ToInt16(CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.Checked)
                Employee.LimitPOGLSelectionOffice = Convert.ToInt16(CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.Checked)

                ' Expense Report Information
                Employee.SupervisorApprovalRequired = Convert.ToInt16(CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.Checked)
                Employee.AlternateApproverCode = SearchableComboBoxPOsAndExpenseReports_AlternateApprover.GetSelectedValue
                Employee.EmployeeVendorCode = SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.GetSelectedValue
                Employee.CreditCardNumber = TextBoxPOsAndExpenseReports_CreditCardNumber.Text
                Employee.CreditCardGLAccount = SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.GetSelectedValue
                Employee.CreditCardDescription = TextBoxPOsAndExpenseReports_CreditCardDescription.Text

            End If

        End Sub
        Private Sub SaveHRAndRateInformationTab(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            If Employee IsNot Nothing Then

                Employee.BirthDate = DateTimePickerHRAndRateInformation_BirthDate.ValueObject
                Employee.LastIncrease = DateTimePickerHRAndRateInformation_DateOfLastIncrease.ValueObject
                Employee.StartDate = DateTimePickerHRAndRateInformation_EmploymentDate.ValueObject
                Employee.NextReview = DateTimePickerHRAndRateInformation_NextReviewDate.ValueObject
                Employee.TerminationDate = DateTimePickerHRAndRateInformation_TerminationDate.ValueObject

                Employee.AnnualSalary = NumericInputHRAndRateInformation_AnnualSalary.GetValue
                Employee.MonthlySalary = NumericInputHRAndRateInformation_MonthlySalary.GetValue

                Employee.BillRate = NumericInputHRAndRateInformation_BillRate.GetValue
                Employee.CostRate = NumericInputHRAndRateInformation_CostRate.GetValue

                Employee.OtherInfo = TextBoxHRAndRateInformation_OtherInfo.Text

                ' Billing Rates???

            End If

        End Sub
        Private Sub SaveSecurityAndPasswordsTab(ByVal Employee As AdvantageFramework.Database.Views.Employee)


        End Sub
        Private Sub SaveAlertsTab(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            Dim EmployeeSetting As AdvantageFramework.Database.Classes.EmployeeSetting = Nothing

            If Employee IsNot Nothing Then

                EmployeeSetting = New AdvantageFramework.Database.Classes.EmployeeSetting(Employee)

                Employee.Email = TextBoxSettingsRightColumn_EmailAddress.Text
                Employee.ReplyToEmail = TextBoxSettingsRightColumn_ReplyToAddress.Text
                Employee.EmailUserName = TextBoxSettingsRightColumn_EmailUserName.Text
                Employee.EmailPassword = TextBoxSettingsRightColumn_EmailPassword.Text

                If String.IsNullOrWhiteSpace(Employee.EmailPassword) = False Then

                    Employee.EmailPassword = AdvantageFramework.Security.Encryption.Encrypt(Employee.EmailPassword)

                End If

                EmployeeSetting.ReceivesAlerts = Convert.ToInt16(CheckBoxSettingsRightColumn_ReceivesAlerts.Checked)
                EmployeeSetting.ReceivesEmail = Convert.ToInt16(CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.Checked)

                If CheckBoxSettings_IsAPIUser.Checked Then

                    Employee.IsAPIUser = AdvantageFramework.Security.Encryption.Encrypt(Employee.Code)

                Else

                    Employee.IsAPIUser = Nothing

                End If

                Employee.IgnoreCalendarSync = CheckBoxSettings_IgnoreCalendarSync.Checked

                Employee.SugarCRMUserName = TextBoxSettings_SugarCRMUserName.Text
                Employee.SugarCRMPassword = TextBoxSettings_SugarCRMPassword.Text

                Employee.ProofHQUserName = TextBoxSettings_ProofHQUserName.Text
                Employee.ProofHQPassword = TextBoxSettings_ProofHQPassword.Text

                Employee.VCCUserName = TextBoxSettings_VCCUserName.Text
                Employee.VCCPassword = TextBoxSettings_VCCPassword.Text

                Employee.AdobeSignatureFile = TextBoxSettings_AdobeSignatureFile.Tag
                Employee.AdobeSignatureFilePassword = TextBoxSettings_AdobeSignatureFilePassword.Text

                Employee.CalendarTimeType = CInt(ComboBoxCalendarTime_Type.SelectedValue)
                Employee.CalendarTimeEmailAddress = TextBoxCalendarTime_EmailAddress.Text
                Employee.CalendarTimeUserName = TextBoxCalendarTime_EmailUserName.Text
                Employee.CalendarTimePassword = TextBoxCalendarTime_EmailPassword.Text
                Employee.CalendarTimeHost = TextBoxCalendarTime_Host.Text
                If TextBoxCalendarTime_Port.Text = "" Then
                    Employee.CalendarTimePort = Nothing
                Else
                    Employee.CalendarTimePort = TextBoxCalendarTime_Port.Text
                End If
                If CheckBoxForm_SSL.Checked = True Then
                    Employee.CalendarTimeSSL = True
                Else
                    Employee.CalendarTimeSSL = False
                End If
            End If

        End Sub
        Private Sub SaveNotesTab(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            If Employee IsNot Nothing Then

                Employee.Comments = TextBoxNotes_Notes.Text

            End If

        End Sub
        Private Sub SaveStandardWorkDays(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            ' objects
            Dim EmployeeStandardTime As AdvantageFramework.Database.Classes.EmployeeStandardTime = Nothing
            Dim EmployeeStandardTimeList As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeStandardTime) = Nothing

            If Employee IsNot Nothing Then

                EmployeeStandardTimeList = DataGridViewTimeTracking_WorkDays.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeStandardTime).ToList

                For Each EmployeeStandardTime In EmployeeStandardTimeList

                    Select Case EmployeeStandardTime.DayOfWeek

                        Case DateUtilities.Days.Monday

                            Employee.MondayStartTime = EmployeeStandardTime.StartTime
                            Employee.MondayEndTime = EmployeeStandardTime.EndTime
                            Employee.MondayHours = EmployeeStandardTime.Hours

                        Case DateUtilities.Days.Tuesday

                            Employee.TuesdayStartTime = EmployeeStandardTime.StartTime
                            Employee.TuesdayEndTime = EmployeeStandardTime.EndTime
                            Employee.TuesdayHours = EmployeeStandardTime.Hours

                        Case DateUtilities.Days.Wednesday

                            Employee.WednesdayStartTime = EmployeeStandardTime.StartTime
                            Employee.WednesdayEndTime = EmployeeStandardTime.EndTime
                            Employee.WednesdayHours = EmployeeStandardTime.Hours

                        Case DateUtilities.Days.Thursday

                            Employee.ThursdayStartTime = EmployeeStandardTime.StartTime
                            Employee.ThursdayEndTime = EmployeeStandardTime.EndTime
                            Employee.ThursdayHours = EmployeeStandardTime.Hours

                        Case DateUtilities.Days.Friday

                            Employee.FridayStartTime = EmployeeStandardTime.StartTime
                            Employee.FridayEndTime = EmployeeStandardTime.EndTime
                            Employee.FridayHours = EmployeeStandardTime.Hours

                        Case DateUtilities.Days.Saturday

                            Employee.SaturdayStartTime = EmployeeStandardTime.StartTime
                            Employee.SaturdayEndTime = EmployeeStandardTime.EndTime
                            Employee.SaturdayHours = EmployeeStandardTime.Hours

                        Case DateUtilities.Days.Sunday

                            Employee.SundayStartTime = EmployeeStandardTime.StartTime
                            Employee.SundayEndTime = EmployeeStandardTime.EndTime
                            Employee.SundayHours = EmployeeStandardTime.Hours

                    End Select

                Next

                Try
                    Employee.WorkDays = String.Join(",", EmployeeStandardTimeList.Where(Function(EmpStandardTime) EmpStandardTime.DoesWork = True).Select(Function(EmpStandardTime) EmpStandardTime.DayOfWeek.ToString.Substring(0, 3)))
                Catch ex As Exception
                    Employee.WorkDays = Nothing
                End Try

            End If

        End Sub
        Private Sub SaveVacationSickAndPersonalTime(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            ' objects
            Dim EmployeeTimeOff As AdvantageFramework.Database.Classes.EmployeeTimeOff = Nothing
            Dim EmployeeTimeOffList As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeTimeOff) = Nothing

            If Employee IsNot Nothing Then

                EmployeeTimeOffList = DataGridViewTimeTracking_EmployeeTimeOff.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeTimeOff).ToList

                For Each EmployeeTimeOff In EmployeeTimeOffList

                    Select Case EmployeeTimeOff.PTOType

                        Case Database.Entities.PTOTypes.Vacation

                            Employee.VacationDateFrom = EmployeeTimeOff.DateFrom
                            Employee.VacationDateTo = EmployeeTimeOff.DateTo
                            Employee.VacationHours = EmployeeTimeOff.HoursAllowed

                            If EmployeeTimeOff.TimeRule.HasValue Then

                                Employee.VacationTimeRule = CShort(EmployeeTimeOff.TimeRule)

                            Else

                                Employee.VacationTimeRule = Nothing

                            End If

                        Case Database.Entities.PTOTypes.Sick

                            Employee.SickDateFrom = EmployeeTimeOff.DateFrom
                            Employee.SickDateTo = EmployeeTimeOff.DateTo
                            Employee.SickHours = EmployeeTimeOff.HoursAllowed

                            If EmployeeTimeOff.TimeRule.HasValue Then

                                Employee.SickTimeRule = CShort(EmployeeTimeOff.TimeRule)

                            Else

                                Employee.SickTimeRule = Nothing

                            End If

                        Case Database.Entities.PTOTypes.Personal

                            Employee.PersonalHoursDateFrom = EmployeeTimeOff.DateFrom
                            Employee.PersonalHoursDateTo = EmployeeTimeOff.DateTo
                            Employee.PersonalHours = EmployeeTimeOff.HoursAllowed

                            If EmployeeTimeOff.TimeRule.HasValue Then

                                Employee.PersonalTimeRule = CShort(EmployeeTimeOff.TimeRule)

                            Else

                                Employee.PersonalTimeRule = Nothing

                            End If

                    End Select

                Next

            End If

        End Sub
        Private Sub DeleteDepartmentTeam()

            'objects
            'Dim EmployeeDepartmentTeams As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeDepartmentTeam) = Nothing
            'Dim EmployeeDepartment As AdvantageFramework.Database.Entities.EmployeeDepartment = Nothing

            'If DataGridViewGeneralInformationRightColumn_DepartmentTeam.HasASelectedRow Then

            '    DataGridViewGeneralInformationRightColumn_DepartmentTeam.CurrentView.CloseEditorForUpdating()

            '    If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

            '        Me.ShowWaitForm("Processing...") 

            '        If _EmployeeCode IsNot Nothing Then

            '            EmployeeDepartmentTeams = DataGridViewGeneralInformationRightColumn_DepartmentTeam.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeDepartmentTeam)().ToList

            '            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            '                For Each EmployeeDepartmentTeam In EmployeeDepartmentTeams

            '                    EmployeeDepartment = EmployeeDepartmentTeam.GetEmployeeDepartment

            '                    If AdvantageFramework.Database.Procedures.EmployeeDepartment.Delete(DbContext, EmployeeDepartment) Then

            '                        If EmployeeDepartmentTeam.Default Then

            '                            TextBoxGeneralInformationRightColumn_DefaultDepartmentTeam.Text = ""

            '                        End If

            '                    End If

            '                Next

            '            End Using

            '        Else

            '            DataGridViewGeneralInformationRightColumn_DepartmentTeam.CurrentView.DeleteSelectedRows()

            '        End If

            '        Me.CloseWaitForm()

            '        LoadDepartmentTeams()

            '    End If

            'End If

        End Sub
        Private Sub ShowSignaturePreview()

            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim EmployeeSignature As Byte() = Nothing

            If PictureBoxInformationTopRightColumn_EmployeeSignature.Tag IsNot Nothing Then

                If TypeOf PictureBoxInformationTopRightColumn_EmployeeSignature.Tag Is System.Byte() Then

                    EmployeeSignature = PictureBoxInformationTopRightColumn_EmployeeSignature.Tag

                    MemoryStream = New System.IO.MemoryStream(EmployeeSignature)

                    PictureBoxInformationTopRightColumn_EmployeeSignature.Image = System.Drawing.Image.FromStream(MemoryStream)

                Else

                    PictureBoxInformationTopRightColumn_EmployeeSignature.Image = Nothing

                End If

            Else

                PictureBoxInformationTopRightColumn_EmployeeSignature.Image = Nothing

            End If

        End Sub
        Private Sub LoadSizeOptions()

            Dim NotesTextBoxSize As System.Drawing.Size = Nothing

            If Me.FindForm.Modal Then

                ButtonNotes_CheckSpelling.Visible = True

            Else

                NotesTextBoxSize = New System.Drawing.Size
                NotesTextBoxSize = TextBoxNotes_Notes.Size

                NotesTextBoxSize.Height = TextBoxNotes_Notes.Height + 26

                TextBoxNotes_Notes.Size = NotesTextBoxSize

                ButtonNotes_CheckSpelling.Visible = False

            End If

        End Sub
        Private Sub LoadDocumentsTab(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

            If Employee IsNot Nothing Then

                DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Employee) With {.EmployeeCode = Employee.Code}

                DocumentManagerControlDocuments_EmployeeDocuments.ClearControl()

                DocumentManagerControlDocuments_EmployeeDocuments.Enabled = DocumentManagerControlDocuments_EmployeeDocuments.LoadControl(Database.Entities.DocumentLevel.Employee, DocumentLevelSetting, DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default)

                TabItemEmployeeDetails_DocumentsTab.Tag = True

            End If

        End Sub
        Private Sub SetGridDisplaySettings()

            If DataGridViewTimeTracking_WorkDays.Columns("DayOfWeek") IsNot Nothing Then

                DataGridViewTimeTracking_WorkDays.Columns("DayOfWeek").OptionsColumn.FixedWidth = True

            End If

            If DataGridViewTimeTracking_WorkDays.Columns("Hours") IsNot Nothing Then

                DataGridViewTimeTracking_WorkDays.Columns("Hours").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom
                DataGridViewTimeTracking_WorkDays.Columns("Hours").SummaryItem.DisplayFormat = "Weekly: {0}"
                DataGridViewTimeTracking_WorkDays.Columns("Hours").AllowSummaryMenu = False

            End If

            DataGridViewTimeTracking_WorkDays.OptionsView.ShowViewCaption = False
            DataGridViewTimeTracking_WorkDays.CurrentView.BestFitColumns()

            If DataGridViewTimeTracking_EmployeeTimeOff.Columns("TimeOffType") IsNot Nothing Then

                DataGridViewTimeTracking_EmployeeTimeOff.Columns("TimeOffType").OptionsColumn.FixedWidth = True

            End If

            DataGridViewTimeTracking_EmployeeTimeOff.OptionsView.ShowFooter = False
            DataGridViewTimeTracking_EmployeeTimeOff.OptionsView.ShowViewCaption = False

        End Sub
        Private Sub ChangeSecurityControlSettings(ByVal IsAdding As Boolean)

            'objects
            Dim SecurityEnabled As Boolean = False

            If IsAdding Then

                SecurityEnabled = Me.CanUserAdd

            Else

                SecurityEnabled = Me.CanUserUpdate

            End If

            ButtonInformationTopRightColumn_SelectSignatureImage.SecurityEnabled = SecurityEnabled
            ButtonInformationTopRightColumn_DeleteSignatureImage.SecurityEnabled = SecurityEnabled
            ButtonPayToNameAndAddress_Refresh.SecurityEnabled = SecurityEnabled

            ButtonRightSection_AddDepartmentTeam.SecurityEnabled = SecurityEnabled
            ButtonRightSection_RemoveDepartmentTeam.SecurityEnabled = SecurityEnabled
            DataGridViewRightSection_EmployeeDepartmentTeams.CurrentView.OptionsBehavior.Editable = SecurityEnabled
            ButtonRightSection_AddRole.SecurityEnabled = SecurityEnabled
            ButtonRightSection_RemoveRole.SecurityEnabled = SecurityEnabled
            DataGridViewRightSection_EmployeeRoles.CurrentView.OptionsBehavior.Editable = SecurityEnabled

            ButtonRightSection_AddAlertGroup.SecurityEnabled = SecurityEnabled
            ButtonRightSection_RemoveAlertGroup.SecurityEnabled = SecurityEnabled
            DataGridViewRightSection_EmployeeAlertGroups.CurrentView.OptionsBehavior.Editable = SecurityEnabled

            DataGridViewTimeTracking_WorkDays.CurrentView.OptionsBehavior.Editable = SecurityEnabled
            DataGridViewTimeTracking_EmployeeTimeOff.CurrentView.OptionsBehavior.Editable = SecurityEnabled

            ButtonRightSection_AddSecurityGroup.SecurityEnabled = SecurityEnabled
            ButtonRightSection_RemoveSecurityGroup.SecurityEnabled = SecurityEnabled

            RateFlagEntryControlHRAndRateInformation_BillingRateDetails.DataGridViewForm_BillingRateFlags.CurrentView.OptionsBehavior.Editable = SecurityEnabled

            UserEmployeeLimitControlEmployeeLimits_EmployeeLimits.ButtonRightSection_AddEmployee.SecurityEnabled = SecurityEnabled
            UserEmployeeLimitControlEmployeeLimits_EmployeeLimits.ButtonRightSection_RemoveEmployee.SecurityEnabled = SecurityEnabled
            UserCDPLimitControlCDPLimits_CDPLimits.ButtonRightSection_AddCDP.SecurityEnabled = SecurityEnabled
            UserCDPLimitControlCDPLimits_CDPLimits.ButtonRightSection_RemoveCDP.SecurityEnabled = SecurityEnabled
            EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.ButtonRightSection_AddOffice.SecurityEnabled = SecurityEnabled
            EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.ButtonRightSection_RemoveOffice.SecurityEnabled = SecurityEnabled
            EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunctionLimits.ButtonRightSection_AddFunction.SecurityEnabled = SecurityEnabled
            EmployeeTimesheetFunctionLimitsControlEmployeeTSFunctionLimits_EmployeeTSFunctionLimits.ButtonRightSection_RemoveFunction.SecurityEnabled = SecurityEnabled

            ButtonSettings_AdobeSignatureFileSelect.SecurityEnabled = SecurityEnabled
            ButtonSettings_AdobeSignatureFileDelete.SecurityEnabled = SecurityEnabled

        End Sub
        Private Sub LoadDropDownDataSources()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DbContext.Database.Connection.Open()

                SearchableComboBoxGeneralInformation_AssignedOffice.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, _Session)

                _DefaultFunctions = AdvantageFramework.Database.Procedures.Function.LoadCore(AdvantageFramework.Database.Procedures.Function.LoadAllActiveEmployeeFunctions(DbContext)).ToList

                SearchableComboBoxTimeTracking_DefaultFunction.DataSource = _DefaultFunctions

                SearchableComboBoxTimeTracking_Supervisor.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadCore(AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveWithOfficeLimits(_Session, DbContext))
                SearchableComboBoxGeneralInformation_Title.DataSource = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadAllActive(DbContext)

                SearchableComboBoxPOsAndExpenseReports_POApprovalRule.DataSource = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.LoadAllActive(DbContext)
                SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadAllActiveEmployeeVendorsWithOfficeLimits(_Session, DbContext).ToList
                SearchableComboBoxPOsAndExpenseReports_AlternateApprover.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadCore(AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveWithOfficeLimits(_Session, DbContext))
                SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, _Session)

                ComboBoxCalendarTime_Type.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Calendar.CalendarTypes))

                LoadEmployeeUsers()

                DbContext.Database.Connection.Close()

            End Using

        End Sub
        Private Sub CalculateCostRate()

            'objects
            Dim AnnualHours As Decimal = 0

            Try

                If _EmployeeCode <> "" Then

                    If TabItemEmployeeDetails_TimeTrackingTab.Tag = True Then

                        AnnualHours = NumericInputTimeTracking_StandardAnnualHours.EditValue

                    Else

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            AnnualHours = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode).AnnualHours.GetValueOrDefault(0)

                        End Using

                    End If

                Else

                    AnnualHours = NumericInputTimeTracking_StandardAnnualHours.EditValue

                End If

            Catch ex As Exception

            End Try

            If NumericInputHRAndRateInformation_AnnualSalary.EditValue IsNot Nothing AndAlso AnnualHours <> 0 Then

                Try

                    NumericInputHRAndRateInformation_CostRate.EditValue = Math.Round(NumericInputHRAndRateInformation_AnnualSalary.EditValue / AnnualHours, 2)

                Catch ex As Exception
                    NumericInputHRAndRateInformation_CostRate.EditValue = Nothing
                End Try

            Else

                NumericInputHRAndRateInformation_CostRate.EditValue = Nothing

            End If

        End Sub

#Region "  Public "

        Public Function LoadControl(ByVal EmployeeCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            _EmployeeCode = EmployeeCode

            SearchableComboBoxGeneralInformation_AssignedOffice.RemoveAddedItemsFromDataSource()
            SearchableComboBoxTimeTracking_DefaultFunction.RemoveAddedItemsFromDataSource()
            SearchableComboBoxTimeTracking_Supervisor.RemoveAddedItemsFromDataSource()
            SearchableComboBoxGeneralInformation_Title.RemoveAddedItemsFromDataSource()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _EmployeeCode <> "" Then

                    ChangeSecurityControlSettings(False)

                    TextBoxGeneralInformation_Code.Enabled = False

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                    If Employee IsNot Nothing Then

                        _AllowDepartmentTeamToBeEmpty = String.IsNullOrEmpty(Employee.DepartmentTeamCode)

                        If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuspendedForLoading = True
                            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.Loading

                        End If

                        Try

                            LoadEmployeeDetails(Nothing)

                        Catch ex As Exception

                        End Try

                        If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuspendedForLoading = False
                            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.None

                        End If

                        TabItemEmployeeDetails_DocumentsTab.Visible = _HasAccessToDocuments
                        TabItemEmployeeDetails_SecurityAndPasswords.Visible = _HasAccessToUserSecurity

                    Else

                        Loaded = False

                        TabItemEmployeeDetails_DocumentsTab.Visible = False
                        TabItemEmployeeDetails_SecurityAndPasswords.Visible = False

                    End If

                Else

                    ' New employee
                    ChangeSecurityControlSettings(True)

                    TextBoxGeneralInformation_Code.Enabled = True
                    TabItemEmployeeDetails_SecurityAndPasswords.Visible = False
                    TabItemEmployeeDetails_DocumentsTab.Visible = False
                    RateFlagEntryControlHRAndRateInformation_BillingRateDetails.Visible = False
                    LabelHRAndRateInformation_BillingRates.Visible = False

                    LoadDepartmentTeams()
                    LoadEmployeeRoles()
                    LoadEmployeeAlertGroups()
                    LoadStandardWorkDaysGrid()
                    LoadVacationSickAndPersonalTimeOffGrid()

                    DateTimePickerHRAndRateInformation_BirthDate.ValueObject = Nothing
                    DateTimePickerHRAndRateInformation_DateOfLastIncrease.ValueObject = Nothing
                    DateTimePickerHRAndRateInformation_EmploymentDate.ValueObject = Nothing
                    DateTimePickerHRAndRateInformation_NextReviewDate.ValueObject = Nothing
                    DateTimePickerHRAndRateInformation_TerminationDate.ValueObject = Nothing

                    NumericInputPOsAndExpenseReports_POAmountLimit.EditValue = Nothing

                End If

            End Using

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Views.Employee

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Try

                If IsNew Then

                    Employee = New AdvantageFramework.Database.Views.Employee

                    SaveGeneralInformationTab(Employee)
                    SaveTimeTrackingTab(Employee)
                    SavePOsAndExpenseReportsTab(Employee)
                    SaveHRAndRateInformationTab(Employee)
                    SaveSecurityAndPasswordsTab(Employee)
                    SaveAlertsTab(Employee)
                    SaveNotesTab(Employee)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                        If Employee IsNot Nothing Then

                            If TabItemEmployeeDetails_GeneralInformation.Tag = True Then

                                SaveGeneralInformationTab(Employee)

                            End If

                            If TabItemEmployeeDetails_TimeTrackingTab.Tag = True Then

                                SaveTimeTrackingTab(Employee)

                            End If

                            If TabItemEmployeeDetails_POsAndExpenseReportsTab.Tag = True Then

                                SavePOsAndExpenseReportsTab(Employee)

                            End If

                            If TabItemEmployeeDetails_HRAndRateInformationTab.Tag = True Then

                                SaveHRAndRateInformationTab(Employee)

                            End If

                            If TabItemEmployeeDetails_SecurityAndPasswords.Tag = True Then

                                SaveSecurityAndPasswordsTab(Employee)

                            End If

                            If TabItemEmployeeDetails_AlertsTab.Tag = True Then

                                SaveAlertsTab(Employee)

                            End If

                            If TabItemEmployeeDetails_NotesTab.Tag = True Then

                                SaveNotesTab(Employee)

                            End If

                        End If

                    End Using

                End If

            Catch ex As Exception
                Employee = Nothing
            End Try

            FillObject = Employee

        End Function
        Public Function Save() As Boolean

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim OldEmployee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False
            Dim IsValid As Boolean = True

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        OldEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                        DataGridViewRightSection_EmployeeDepartmentTeams.CurrentView.CloseEditorForUpdating()

                        If _AllowDepartmentTeamToBeEmpty = False AndAlso Me.IsAssignedToADepartmentTeam = False Then

                            ErrorMessage = "Please assign employee to a Department."

                        Else

                            Employee = Me.FillObject(False)

                            If Employee IsNot Nothing Then

                                If _AllowDepartmentTeamToBeEmpty Then

                                    Employee.AllowEmptyDepartmentTeam()

                                End If

                                ErrorMessage = Employee.ValidateEntity(IsValid)

                                If IsValid Then

                                    If AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee) Then

                                        DbContext.Database.Connection.Open()
                                        DbContext.Configuration.AutoDetectChangesEnabled = False

                                        Try

                                            For Each EmployeeAdditionalEmail In _RemovedAdditionalEmails.ToList

                                                If EmployeeAdditionalEmail.ID > 0 Then

                                                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.EMPLOYEE_ADDL_EMAIL WHERE EMPLOYEE_ADDL_EMAIL_ID = {0}", EmployeeAdditionalEmail.ID))

                                                End If

                                                _RemovedAdditionalEmails.Remove(EmployeeAdditionalEmail)

                                            Next

                                            For Each EmployeeAdditionalEmail In _AdditionalEmails

                                                If EmployeeAdditionalEmail.ID > 0 Then

                                                    DbContext.EmployeeAdditionalEmails.Attach(EmployeeAdditionalEmail)

                                                    DbContext.Entry(EmployeeAdditionalEmail).Property("Email").IsModified = True

                                                Else

                                                    DbContext.EmployeeAdditionalEmails.Add(EmployeeAdditionalEmail)

                                                End If

                                            Next

                                            DbContext.Configuration.AutoDetectChangesEnabled = True

                                            DbContext.SaveChanges()

                                        Catch ex As Exception

                                        End Try

                                        If TabItemEmployeeDetails_HRAndRateInformationTab.Tag AndAlso RateFlagEntryControlHRAndRateInformation_BillingRateDetails.Visible Then

                                            Saved = RateFlagEntryControlHRAndRateInformation_BillingRateDetails.Save()

                                        Else

                                            Saved = True

                                        End If

                                        If Saved AndAlso (NumericInputHRAndRateInformation_AnnualSalary.UserEntryChanged OrElse NumericInputHRAndRateInformation_MonthlySalary.UserEntryChanged OrElse
                                                          NumericInputHRAndRateInformation_CostRate.UserEntryChanged OrElse SearchableComboBoxGeneralInformation_Title.UserEntryChanged) Then

                                            If AdvantageFramework.WinForm.MessageBox.Show("Would you like to create a rate history record for this employee?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.Yes Then

                                                AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeHRHistoryDialog.ShowFormDialog(0, _EmployeeCode, OldEmployee)

                                            End If

                                        End If

                                        CheckAPIUserSettingAvailability()

                                    End If

                                End If

                            End If

                        End If

                    End Using

                End Using

                If Saved = False And String.IsNullOrEmpty(ErrorMessage) = True Then

                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        Employee = Me.FillObject(False)

                        If Employee IsNot Nothing Then

                            Deleted = AdvantageFramework.Database.Procedures.EmployeeView.Delete(DbContext, DataContext, Employee.Code)

                            If Deleted = False Then

                                ErrorMessage = "The employee is in use and cannot be deleted."

                            End If

                        End If

                    End Using

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef EmployeeCode As String) As Boolean

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing
            Dim EmpRole As AdvantageFramework.Database.Entities.EmployeeRole = Nothing
            Dim EmployeeDepartment As AdvantageFramework.Database.Entities.EmployeeDepartment = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        If Me.IsAssignedToADepartmentTeam = False Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please assign employee to a Department.", WinForm.MessageBox.MessageBoxButtons.OK)

                        Else

                            Employee = Me.FillObject(True)

                            If Employee IsNot Nothing Then

                                Employee.DbContext = DbContext

                                If AdvantageFramework.Database.Procedures.EmployeeView.Insert(DbContext, DataContext, Employee) Then

                                    Inserted = True

                                End If

                            End If

                        End If

                    End Using

                End Using

                If Inserted Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Employee.Code)

                        If Employee IsNot Nothing Then

                            For Each EmployeeRole In Me.EmployeeRoles

                                EmpRole = New AdvantageFramework.Database.Entities.EmployeeRole

                                EmpRole.DbContext = DbContext
                                EmpRole.EmployeeCode = Employee.Code
                                EmpRole.RoleCode = EmployeeRole.RoleCode

                                AdvantageFramework.Database.Procedures.EmployeeRole.Insert(DbContext, EmpRole)

                            Next

                            For Each EmployeeDepartmentTeam In Me.EmployeeDepartmentTeams

                                EmployeeDepartment = New AdvantageFramework.Database.Entities.EmployeeDepartment

                                EmployeeDepartment.DbContext = DbContext
                                EmployeeDepartment.EmployeeCode = Employee.Code
                                EmployeeDepartment.DepartmentTeamCode = EmployeeDepartmentTeam.DepartmentTeamCode
                                EmployeeDepartment.DepartmentName = EmployeeDepartmentTeam.DepartmentTeamName

                                AdvantageFramework.Database.Procedures.EmployeeDepartment.Insert(DbContext, EmployeeDepartment)

                            Next

                            For Each EmployeeAlertGroup In Me.EmployeeAlertGroups

                                AlertGroup = New AdvantageFramework.Database.Entities.AlertGroup

                                AlertGroup.DbContext = DbContext
                                AlertGroup.EmployeeCode = Employee.Code
                                AlertGroup.Code = EmployeeAlertGroup.AlertGroupCode
                                AlertGroup.IncludeOnSchedule = EmployeeAlertGroup.IncludeOnSchedule

                                AdvantageFramework.Database.Procedures.AlertGroup.Insert(DbContext, AlertGroup)

                            Next

                            EmployeeCode = Employee.Code

                        End If

                    End Using

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Function Terminate() As Boolean

            'objects
            Dim Terminated As Boolean = False
            Dim ErrorMessage As String = ""

            Try

                If String.IsNullOrEmpty(_EmployeeCode) = False Then

                    If AdvantageFramework.Maintenance.Accounting.Presentation.TerminateEmployeeDialog.ShowFormDialog(_EmployeeCode) = Windows.Forms.DialogResult.OK Then

                        Terminated = True

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Terminate = Terminated

        End Function
        Public Sub DeleteDocument()

            DocumentManagerControlDocuments_EmployeeDocuments.DeleteSelectedDocument()

        End Sub
        Public Sub DownloadDocument()

            DocumentManagerControlDocuments_EmployeeDocuments.DownloadSelectedDocument()

        End Sub
        Public Sub UploadDocument()

            DocumentManagerControlDocuments_EmployeeDocuments.UploadNewDocument()

        End Sub
        Public Sub CancelAddBillingRateDetail()

            RateFlagEntryControlHRAndRateInformation_BillingRateDetails.CancelNewItemRow()

        End Sub
        Public Sub DeleteBillingRateDetail()

            RateFlagEntryControlHRAndRateInformation_BillingRateDetails.Delete()

        End Sub
        Public Sub CheckNotesSpelling()

            TextBoxNotes_Notes.CheckSpelling()

        End Sub
        Public Sub LoadEmployeeUsers()

            Dim Users As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing

            If _EmployeeCode IsNot Nothing Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        Users = AdvantageFramework.Security.Database.Procedures.User.LoadByEmployeeCode(SecurityDbContext, _EmployeeCode).ToList

                    Catch ex As Exception
                        Users = Nothing
                    End Try

                    SearchableComboBoxSecurityAndPasswords_User.DataSource = Users

                    If Users IsNot Nothing AndAlso Users.Count > 0 Then

                        SearchableComboBoxSecurityAndPasswords_User.Enabled = True
                        SearchableComboBoxSecurityAndPasswords_User.SelectedValue = Users.First.ID

                    Else

                        SearchableComboBoxSecurityAndPasswords_User.SelectedValue = Nothing
                        SearchableComboBoxSecurityAndPasswords_User.Enabled = False

                    End If

                End Using

            End If

        End Sub
        Public Sub ClearControl()

            ' GENERAL INFORMATION TAB
            TextBoxGeneralInformation_Code.Text = ""
            TextBoxGeneralInformation_FirstName.Text = ""
            TextBoxGeneralInformation_MiddleInitial.Text = ""
            TextBoxGeneralInformation_LastName.Text = ""
            SearchableComboBoxGeneralInformation_Title.SelectedValue = Nothing
            SearchableComboBoxGeneralInformation_AssignedOffice.SelectedValue = Nothing
            TextBoxGeneralInformation_AccountNumber.Text = ""

            TextBoxInformationTopLeftColumn_AlternatePhone.Text = ""
            TextBoxInformationTopLeftColumn_CellPhone.Text = ""
            TextBoxInformationTopLeftColumn_HomePhone.Text = ""
            TextBoxInformationTopLeftColumn_WorkPhone.Text = ""
            TextBoxInformationTopLeftColumn_WorkPhoneExt.Text = ""

            AddressControlInformationBottomLeftColumn_HomeAddress.Address = ""
            AddressControlInformationBottomLeftColumn_HomeAddress.Address2 = ""
            AddressControlInformationBottomLeftColumn_HomeAddress.City = ""
            AddressControlInformationBottomLeftColumn_HomeAddress.County = ""
            AddressControlInformationBottomLeftColumn_HomeAddress.State = ""
            AddressControlInformationBottomLeftColumn_HomeAddress.Zip = ""
            AddressControlInformationBottomLeftColumn_HomeAddress.Country = ""

            AddressControlInformationBottomRightColumn_MailingAddress.Address = ""
            AddressControlInformationBottomRightColumn_MailingAddress.Address2 = ""
            AddressControlInformationBottomRightColumn_MailingAddress.City = ""
            AddressControlInformationBottomRightColumn_MailingAddress.County = ""
            AddressControlInformationBottomRightColumn_MailingAddress.State = ""
            AddressControlInformationBottomRightColumn_MailingAddress.Zip = ""
            AddressControlInformationBottomRightColumn_MailingAddress.Country = ""

            TextBoxInformation_EmployeeSignature.Text = ""

            DataGridViewLeftSection_AvailableDepartmentTeam.DataSource = Nothing
            DataGridViewRightSection_EmployeeDepartmentTeams.DataSource = Nothing

            DataGridViewLeftSection_AvailableRoles.DataSource = Nothing
            DataGridViewRightSection_EmployeeRoles.DataSource = Nothing

            ' TIME TRACKING TAB
            SearchableComboBoxTimeTracking_Supervisor.SelectedValue = Nothing
            SearchableComboBoxTimeTracking_DefaultFunction.SelectedValue = Nothing
            ComboBoxTimeTracking_ReportMissingTime.SelectedIndex = 0
            NumericInputTimeTracking_SeniorityPriority.EditValue = Nothing
            NumericInputTimeTracking_DirectHoursGoal.EditValue = Nothing
            NumericInputTimeTracking_MonthlyBillableHoursGoal.EditValue = Nothing
            NumericInputTimeTracking_StandardAnnualHours.EditValue = Nothing

            DataGridViewTimeTracking_EmployeeTimeOff.DataSource = Nothing
            DataGridViewTimeTracking_WorkDays.DataSource = Nothing

            ' POs AND EXPENSE REPORTS TAB
            NumericInputPOsAndExpenseReports_POAmountLimit.EditValue = Nothing
            SearchableComboBoxPOsAndExpenseReports_POApprovalRule.SelectedValue = Nothing
            SearchableComboBoxPOsAndExpenseReports_VendorCodeCrossRef.SelectedValue = Nothing
            SearchableComboBoxPOsAndExpenseReports_AlternateApprover.SelectedValue = Nothing
            SearchableComboBoxPOsAndExpenseReports_CreditCardGLAccount.SelectedValue = Nothing
            TextBoxPOsAndExpenseReports_CreditCardNumber.Text = ""
            TextBoxPOsAndExpenseReports_CreditCardDescription.Text = ""

            ' HR AND RATE INFORMATION TAB
            DateTimePickerHRAndRateInformation_BirthDate.ValueObject = Nothing
            DateTimePickerHRAndRateInformation_DateOfLastIncrease.ValueObject = Nothing
            DateTimePickerHRAndRateInformation_EmploymentDate.ValueObject = Nothing
            DateTimePickerHRAndRateInformation_NextReviewDate.ValueObject = Nothing
            DateTimePickerHRAndRateInformation_TerminationDate.ValueObject = Nothing

            NumericInputHRAndRateInformation_AnnualSalary.EditValue = Nothing
            NumericInputHRAndRateInformation_MonthlySalary.EditValue = Nothing

            NumericInputHRAndRateInformation_BillRate.EditValue = Nothing
            NumericInputHRAndRateInformation_CostRate.EditValue = Nothing

            TextBoxHRAndRateInformation_OtherInfo.Text = ""

            If TabItemEmployeeDetails_HRAndRateInformationTab.Visible Then

                RateFlagEntryControlHRAndRateInformation_BillingRateDetails.ClearControl()

            End If

            ' SECURITY AND PASSWORDS TAB
            'ComboBoxTopSection_User.DataSource = Nothing

            DataGridViewLeftSection_AvailableSecurityGroups.DataSource = Nothing
            DataGridViewRightSection_EmployeeSecurityGroups.DataSource = Nothing

            ' ALERTS TAB
            TextBoxSettingsRightColumn_EmailAddress.Text = ""
            TextBoxSettingsRightColumn_ReplyToAddress.Text = ""
            TextBoxSettingsRightColumn_EmailUserName.Text = ""
            TextBoxSettingsRightColumn_EmailPassword.Text = ""

            TextBoxSettings_SugarCRMUserName.Text = ""
            TextBoxSettings_SugarCRMPassword.Text = ""
            TextBoxSettings_ProofHQUserName.Text = ""
            TextBoxSettings_ProofHQPassword.Text = ""

            TextBoxSettings_AdobeSignatureFilePassword.Text = ""
            TextBoxSettings_AdobeSignatureFile.Text = ""
            TextBoxSettings_AdobeSignatureFile.Tag = Nothing

            TextBoxSettings_VCCUserName.Text = ""
            TextBoxSettings_VCCPassword.Text = ""

            TextBoxCalendarTime_EmailAddress.Text = ""
            TextBoxCalendarTime_EmailUserName.Text = ""
            TextBoxCalendarTime_EmailPassword.Text = ""
            TextBoxCalendarTime_Host.Text = ""
            TextBoxCalendarTime_Port.Text = ""

            TextBoxConceptShare_Password.Text = ""
            CheckBoxConceptShare_IsActive.Checked = True


            DataGridViewLeftSection_AvailableAlertGroups.DataSource = Nothing
            DataGridViewRightSection_EmployeeAlertGroups.DataSource = Nothing

            DataGridViewAdditionalEmails_AdditionalEmails.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.EmployeeAdditionalEmail)

            ' NOTES TAB
            TextBoxNotes_Notes.Text = ""

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub LoadRequiredNonGridControlsForValidation()

            If _EmployeeCode <> "" Then

                If TabItemEmployeeDetails_GeneralInformation IsNot TabControlControl_EmployeeDetails.SelectedTab Then

                    If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                        DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuspendedForLoading = True
                        DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.Loading

                    End If

                    Try

                        LoadEmployeeDetails(TabItemEmployeeDetails_GeneralInformation)

                    Catch ex As Exception

                    End Try

                    If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                        DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuspendedForLoading = False
                        DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.None

                    End If

                End If

            End If

        End Sub
        Public Sub RefreshEmployeeOfficeLimits()

            LoadEmployeeOfficeLimits(_EmployeeCode)

        End Sub
        Public Sub RefreshEmployeeTSFunctionLimits()

            LoadEmployeeOfficeLimits(_EmployeeCode)

        End Sub
        Public Sub RefreshCDPLimits()

            LoadCDPsLimits()

        End Sub
        Public Sub RefreshEmployeeLimits()

            LoadEmployeeLimits()

        End Sub
        Public Sub RefreshControl()

            LoadDropDownDataSources()

        End Sub
        Public Sub AddAdditionalEmail()

            Dim EmailAddress As String = String.Empty
            Dim EmployeeAdditionalEmail As AdvantageFramework.Database.Entities.EmployeeAdditionalEmail = Nothing

            If DataGridViewAdditionalEmails_AdditionalEmails.CurrentView.PostEditor() Then

                DataGridViewAdditionalEmails_AdditionalEmails.CurrentView.UpdateCurrentRow()

            End If

            If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("New Email", "Email Address", "", EmailAddress, AdvantageFramework.Database.Entities.EmployeeAdditionalEmail.Properties.Email, TextBox.Type.Email) = Windows.Forms.DialogResult.OK Then

                EmployeeAdditionalEmail = New AdvantageFramework.Database.Entities.EmployeeAdditionalEmail

                EmployeeAdditionalEmail.EmployeeCode = _EmployeeCode
                EmployeeAdditionalEmail.Email = EmailAddress

                _AdditionalEmails.Add(EmployeeAdditionalEmail)

                DataGridViewAdditionalEmails_AdditionalEmails.CurrentView.RefreshData()

                DataGridViewAdditionalEmails_AdditionalEmails.SetUserEntryChanged()

            End If

        End Sub
        Public Sub DeleteAdditionalEmail()

            Dim EmployeeAdditionalEmails As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeAdditionalEmail) = Nothing

            If DataGridViewAdditionalEmails_AdditionalEmails.CurrentView.PostEditor() Then

                DataGridViewAdditionalEmails_AdditionalEmails.CurrentView.UpdateCurrentRow()

            End If

            Try

                EmployeeAdditionalEmails = DataGridViewAdditionalEmails_AdditionalEmails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.EmployeeAdditionalEmail).ToList

            Catch ex As Exception
                EmployeeAdditionalEmails = New Generic.List(Of AdvantageFramework.Database.Entities.EmployeeAdditionalEmail)
            End Try

            For Each EmployeeAdditionalEmail In EmployeeAdditionalEmails

                _AdditionalEmails.Remove(EmployeeAdditionalEmail)
                _RemovedAdditionalEmails.Add(EmployeeAdditionalEmail)

            Next

            DataGridViewAdditionalEmails_AdditionalEmails.CurrentView.RefreshData()

            DataGridViewAdditionalEmails_AdditionalEmails.SetUserEntryChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub EmployeeControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            LoadSizeOptions()

            DataGridViewTimeTracking_WorkDays.OptionsView.ShowFooter = True

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub TabControlControl_EmployeeDetails_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlControl_EmployeeDetails.SelectedTabChanging

            If Me.FindForm IsNot Nothing Then

                If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuspendedForLoading = True
                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.Loading

                End If

                Try

                    LoadEmployeeDetails(e.NewTab)

                Catch ex As Exception

                End Try

                If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuspendedForLoading = False
                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.None

                End If

            End If

        End Sub
        Private Sub TabControlControl_EmployeeDetails_SelectedTabChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlControl_EmployeeDetails.SelectedTabChanged

            RaiseEvent SelectedTabChanged(sender, e)

        End Sub

#Region "  General Information Tab Controls "

        Private Sub DataGridViewRightSection_EmployeeDepartmentTeams_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRightSection_EmployeeDepartmentTeams.CellValueChangingEvent

            'objects
            Dim DefaultEmployeeDepartment As AdvantageFramework.Database.Classes.EmployeeDepartmentTeam = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim OldEmployee As AdvantageFramework.Database.Views.Employee = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.EmployeeDepartmentTeam.Properties.Default.ToString Then

                If e.Value Then

                    Try

                        DefaultEmployeeDepartment = DataGridViewRightSection_EmployeeDepartmentTeams.CurrentView.GetRow(e.RowHandle)

                    Catch ex As Exception
                        DefaultEmployeeDepartment = Nothing
                    End Try

                    If DefaultEmployeeDepartment IsNot Nothing Then

                        TextBoxRightSection_DefaultDepartmentTeam.Text = DefaultEmployeeDepartment.DepartmentTeamCode

                        If _EmployeeCode IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)
                                    OldEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                                    Employee.DepartmentTeamCode = If(e.Value, DefaultEmployeeDepartment.DepartmentTeamCode, Nothing)

                                    Saved = AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee)

                                End Using

                            End Using

                            If Saved Then

                                If AdvantageFramework.WinForm.MessageBox.Show("Would you like to create a rate history record for this employee?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.Yes Then

                                    AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeHRHistoryDialog.ShowFormDialog(0, _EmployeeCode, OldEmployee)

                                End If

                            End If

                        Else

                            Saved = True

                        End If

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Please select at least one default dept\team.")

                End If

                LoadDepartmentTeams()

            End If

        End Sub
        Private Sub DataGridViewRightSection_EmployeeRoles_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRightSection_EmployeeRoles.CellValueChangingEvent

            'objects
            Dim DefaultEmployeeRole As AdvantageFramework.Database.Classes.EmployeeRole = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.EmployeeRole.Properties.Default.ToString Then

                If e.Value Then

                    Try

                        DefaultEmployeeRole = DataGridViewRightSection_EmployeeRoles.CurrentView.GetRow(e.RowHandle)

                    Catch ex As Exception
                        DefaultEmployeeRole = Nothing
                    End Try

                    If DefaultEmployeeRole IsNot Nothing Then

                        TextBoxRightSection_DefaultRole.Text = DefaultEmployeeRole.RoleCode

                        If String.IsNullOrEmpty(_EmployeeCode) = False Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                                    Employee.RoleCode = DefaultEmployeeRole.RoleCode

                                    Saved = AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee)

                                End Using

                            End Using

                        Else

                            Saved = True

                        End If

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Please select at least one default role.")

                End If

                LoadEmployeeRoles()

            End If

        End Sub
        Private Sub ButtonInformationTopRightColumn_SelectSignatureImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonInformationTopRightColumn_SelectSignatureImage.Click

            'objects
            Dim EmployeeSignatureLocation As String = Nothing
            Dim EmployeeSignature As Byte() = Nothing
            Dim FileStream As System.IO.FileStream = Nothing
            Dim BinaryReader As System.IO.BinaryReader = Nothing
            Dim ImportFolder As String = String.Empty
            Dim Files() As String = Nothing
            Dim ValidContentType As Boolean = False
            Dim ValidFileLength As Boolean = False
            Dim ValidFileDimensions As Boolean = False
            Dim BitMapFile = Nothing
            Dim ErrorMessage As String = Nothing
            Dim FileType As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                    ImportFolder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext), "\")

                    If AdvantageFramework.WinForm.Presentation.FolderBrowserDialog.ShowFormDialog(ImportFolder, New Generic.List(Of AdvantageFramework.FileSystem.FileFilters)({FileSystem.FileFilters.GIF}), False, Files) = Windows.Forms.DialogResult.OK Then

                        If Files IsNot Nothing AndAlso Files.Count > 0 Then

                            EmployeeSignatureLocation = Files(0)

                        End If

                    End If

                Else

                    'EmployeeSignatureLocation = AdvantageFramework.WinForm.Presentation.SelectFileToOpen("", "GIF files (*.gif)|*.gif", "")
                    EmployeeSignatureLocation = AdvantageFramework.WinForm.Presentation.SelectFileToOpen("", "Image files (*.gif;*.jpg;*.jpeg;*.png;*.bmp)|*.gif;*.jpg;*.jpeg;*.png;*.bmp", "")

                End If

            End Using

            If EmployeeSignatureLocation IsNot Nothing AndAlso EmployeeSignatureLocation <> "" Then
                FileType = EmployeeSignatureLocation.Substring(Len(EmployeeSignatureLocation) - 4, 4).ToLower

                FileStream = New System.IO.FileStream(EmployeeSignatureLocation, System.IO.FileMode.Open, System.IO.FileAccess.Read)

                If FileType = ".gif" OrElse FileType = ".jpg" OrElse FileType = "jpeg" OrElse FileType = ".png" OrElse FileType = ".bmp" Then

                    ValidContentType = True

                Else

                    ErrorMessage = ("The selected file must be one of the following types: .jpg, .jpeg, .gif, .png or .bmp.")

                End If

                If FileStream.Length <= 32765 Then

                    ValidFileLength = True

                Else

                    ErrorMessage = "The selected file exceeds the file size limit."

                End If

                BitMapFile = New System.Drawing.Bitmap(FileStream)

                If BitMapFile.Width = 264 OrElse BitMapFile.Height = 72 Then

                    ValidFileDimensions = True

                Else

                    ErrorMessage = "The selected file has the incorrect dimensions."

                End If

                If ValidContentType AndAlso ValidFileLength AndAlso ValidFileDimensions Then

                    If FileStream.Position > 0 Then

                        FileStream.Position = 0

                    End If

                    BinaryReader = New System.IO.BinaryReader(FileStream)

                    EmployeeSignature = BinaryReader.ReadBytes(CInt(New System.IO.FileInfo(EmployeeSignatureLocation).Length))

                    PictureBoxInformationTopRightColumn_EmployeeSignature.Tag = EmployeeSignature

                    Try

                        TextBoxInformation_EmployeeSignature.Text = EmployeeSignature.ToString

                    Catch ex As Exception

                    End Try

                    ShowSignaturePreview()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonInformationTopRightColumn_DeleteSignatureImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonInformationTopRightColumn_DeleteSignatureImage.Click

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                Me.ShowWaitForm("Processing...")

                Try
                    If _EmployeeCode IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                                Employee.SignatureImage = Nothing

                                If AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee) Then

                                    PictureBoxInformationTopRightColumn_EmployeeSignature.Tag = Nothing

                                End If

                            End Using

                        End Using

                    Else

                        PictureBoxInformationTopRightColumn_EmployeeSignature.Tag = Nothing

                    End If

                Catch ex As Exception

                End Try

                ShowSignaturePreview()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_AddDepartmentTeam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_AddDepartmentTeam.Click

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeDepartmentTeams As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeDepartmentTeam) = Nothing
            Dim EmployeeDepartmentTeam As AdvantageFramework.Database.Classes.EmployeeDepartmentTeam = Nothing
            Dim NewEmployeeDepartment As AdvantageFramework.Database.Entities.EmployeeDepartment = Nothing
            Dim IsDefault As Boolean = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewLeftSection_AvailableDepartmentTeam.HasASelectedRow Then

                RowHandlesAndDataBoundItems = DataGridViewLeftSection_AvailableDepartmentTeam.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                            NewEmployeeDepartment = New AdvantageFramework.Database.Entities.EmployeeDepartment

                            NewEmployeeDepartment.DepartmentTeamCode = RowHandleAndDataBoundItem.Value.Code
                            NewEmployeeDepartment.DepartmentName = RowHandleAndDataBoundItem.Value.Description

                            If DataGridViewRightSection_EmployeeDepartmentTeams.HasRows = False AndAlso TextBoxRightSection_DefaultDepartmentTeam.Text = "" Then

                                IsDefault = True
                                TextBoxRightSection_DefaultDepartmentTeam.Text = NewEmployeeDepartment.DepartmentTeamCode

                            End If

                            If String.IsNullOrEmpty(_EmployeeCode) = False Then

                                NewEmployeeDepartment.EmployeeCode = _EmployeeCode
                                NewEmployeeDepartment.DbContext = DbContext

                                If AdvantageFramework.Database.Procedures.EmployeeDepartment.Insert(DbContext, NewEmployeeDepartment) Then

                                    If IsDefault Then

                                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                                        Employee.DepartmentTeamCode = NewEmployeeDepartment.DepartmentTeamCode

                                        AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee)

                                    End If

                                End If

                            Else

                                Try

                                    EmployeeDepartmentTeams = DataGridViewRightSection_EmployeeDepartmentTeams.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeDepartmentTeam).ToList

                                Catch ex As Exception
                                    EmployeeDepartmentTeams = Nothing
                                End Try

                                If EmployeeDepartmentTeams IsNot Nothing Then

                                    EmployeeDepartmentTeam = New AdvantageFramework.Database.Classes.EmployeeDepartmentTeam
                                    EmployeeDepartmentTeam.DepartmentTeamCode = NewEmployeeDepartment.DepartmentTeamCode
                                    EmployeeDepartmentTeam.DepartmentTeamName = NewEmployeeDepartment.DepartmentName
                                    EmployeeDepartmentTeam.Default = IsDefault

                                    EmployeeDepartmentTeams.Add(EmployeeDepartmentTeam)

                                    DataGridViewRightSection_EmployeeDepartmentTeams.DataSource = EmployeeDepartmentTeams

                                End If

                            End If

                        Next

                    End Using

                End Using

                LoadDepartmentTeams()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveDepartmentTeam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_RemoveDepartmentTeam.Click

            'objects
            Dim EmployeeDepartmentTeam As AdvantageFramework.Database.Classes.EmployeeDepartmentTeam = Nothing
            Dim EmployeeDepartment As AdvantageFramework.Database.Entities.EmployeeDepartment = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewRightSection_EmployeeDepartmentTeams.HasASelectedRow Then

                RowHandlesAndDataBoundItems = DataGridViewRightSection_EmployeeDepartmentTeams.GetAllSelectedRowsRowHandlesAndDataBoundItems()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                        Try

                            EmployeeDepartmentTeam = RowHandleAndDataBoundItem.Value

                        Catch ex As Exception
                            EmployeeDepartmentTeam = Nothing
                        End Try

                        If EmployeeDepartmentTeam IsNot Nothing Then

                            If EmployeeDepartmentTeam.Default = False Then

                                If String.IsNullOrEmpty(_EmployeeCode) = False Then

                                    EmployeeDepartment = AdvantageFramework.Database.Procedures.EmployeeDepartment.LoadByEmployeeCodeAndDepartmentTeamCode(DbContext, _EmployeeCode, EmployeeDepartmentTeam.DepartmentTeamCode)

                                    If EmployeeDepartment IsNot Nothing Then

                                        AdvantageFramework.Database.Procedures.EmployeeDepartment.Delete(DbContext, EmployeeDepartment)

                                    End If

                                Else

                                    DataGridViewRightSection_EmployeeDepartmentTeams.CurrentView.DeleteRow(RowHandleAndDataBoundItem.Key)

                                End If

                            Else

                                AdvantageFramework.Navigation.ShowMessageBox("You cannot remove the default dept\team.")

                            End If

                        End If

                    Next

                End Using

                LoadDepartmentTeams()

            End If

        End Sub
        Private Sub ButtonRightSection_AddRole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_AddRole.Click

            'objects
            Dim EmployeeRoles As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeRole) = Nothing
            Dim EmployeeRole As AdvantageFramework.Database.Classes.EmployeeRole = Nothing
            Dim NewEmployeeRole As AdvantageFramework.Database.Entities.EmployeeRole = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim IsDefault As Boolean = False

            If DataGridViewLeftSection_AvailableRoles.HasASelectedRow Then

                RowHandlesAndDataBoundItems = DataGridViewLeftSection_AvailableRoles.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                            If DataGridViewRightSection_EmployeeRoles.HasRows = False AndAlso TextBoxRightSection_DefaultRole.Text = "" Then

                                IsDefault = True
                                TextBoxRightSection_DefaultRole.Text = RowHandleAndDataBoundItem.Value.Code

                            End If

                            If String.IsNullOrEmpty(_EmployeeCode) = False Then

                                NewEmployeeRole = New AdvantageFramework.Database.Entities.EmployeeRole

                                NewEmployeeRole.DbContext = DbContext
                                NewEmployeeRole.RoleCode = RowHandleAndDataBoundItem.Value.Code
                                NewEmployeeRole.EmployeeCode = _EmployeeCode

                                If AdvantageFramework.Database.Procedures.EmployeeRole.Insert(DbContext, NewEmployeeRole) Then

                                    If IsDefault Then

                                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                                        Employee.RoleCode = NewEmployeeRole.RoleCode

                                        AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee)

                                    End If

                                End If

                            Else

                                EmployeeRoles = DataGridViewRightSection_EmployeeRoles.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeRole).ToList

                                EmployeeRole = New AdvantageFramework.Database.Classes.EmployeeRole

                                EmployeeRole.RoleCode = RowHandleAndDataBoundItem.Value.Code
                                EmployeeRole.RoleDescription = RowHandleAndDataBoundItem.Value.Description
                                EmployeeRole.Default = False

                                EmployeeRoles.Add(EmployeeRole)

                                DataGridViewRightSection_EmployeeRoles.DataSource = EmployeeRoles

                            End If

                        Next

                    End Using

                End Using

                LoadEmployeeRoles()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveRole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_RemoveRole.Click

            'objects
            Dim EmployeeRole As AdvantageFramework.Database.Classes.EmployeeRole = Nothing
            Dim EmployeeRoleToDelete As AdvantageFramework.Database.Entities.EmployeeRole = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing

            If DataGridViewRightSection_EmployeeRoles.HasASelectedRow Then

                RowHandlesAndDataBoundItems = DataGridViewRightSection_EmployeeRoles.GetAllSelectedRowsRowHandlesAndDataBoundItems

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems

                            Try

                                EmployeeRole = RowHandleAndDataBoundItem.Value

                            Catch ex As Exception
                                EmployeeRole = Nothing
                            End Try

                            If EmployeeRole IsNot Nothing Then

                                If String.IsNullOrEmpty(_EmployeeCode) = False Then

                                    EmployeeRoleToDelete = AdvantageFramework.Database.Procedures.EmployeeRole.LoadByEmployeeCodeAndRoleCode(DbContext, _EmployeeCode, EmployeeRole.RoleCode)

                                    If EmployeeRoleToDelete IsNot Nothing Then

                                        If AdvantageFramework.Database.Procedures.EmployeeRole.Delete(DbContext, EmployeeRoleToDelete) Then

                                            If EmployeeRole.Default Then

                                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                                                Employee.RoleCode = Nothing

                                                AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee)

                                                TextBoxRightSection_DefaultRole.Text = ""

                                            End If

                                        End If

                                    End If

                                Else

                                    If EmployeeRole.Default Then

                                        TextBoxRightSection_DefaultRole.Text = ""

                                    End If

                                    DataGridViewRightSection_EmployeeRoles.CurrentView.DeleteRow(RowHandleAndDataBoundItem.Key)

                                End If

                            End If

                        Next

                    End Using

                End Using

                LoadEmployeeRoles()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_AvailableDepartmentTeam_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_AvailableDepartmentTeam.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewLeftSection_AvailableRoles_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_AvailableRoles.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_EmployeeDepartmentTeams_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRightSection_EmployeeDepartmentTeams.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_EmployeeRoles_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRightSection_EmployeeRoles.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemRefresh_Home_Click(sender As Object, e As EventArgs) Handles ButtonItemRefresh_Home.Click

            AddressControlInformationBottomRightColumn_MailingAddress.Address = AddressControlInformationBottomLeftColumn_HomeAddress.Address
            AddressControlInformationBottomRightColumn_MailingAddress.Address2 = AddressControlInformationBottomLeftColumn_HomeAddress.Address2
            AddressControlInformationBottomRightColumn_MailingAddress.City = AddressControlInformationBottomLeftColumn_HomeAddress.City
            AddressControlInformationBottomRightColumn_MailingAddress.State = AddressControlInformationBottomLeftColumn_HomeAddress.State
            AddressControlInformationBottomRightColumn_MailingAddress.County = AddressControlInformationBottomLeftColumn_HomeAddress.County
            AddressControlInformationBottomRightColumn_MailingAddress.Country = AddressControlInformationBottomLeftColumn_HomeAddress.Country
            AddressControlInformationBottomRightColumn_MailingAddress.Zip = AddressControlInformationBottomLeftColumn_HomeAddress.Zip

        End Sub
        Private Sub CheckBoxGeneralInformation_Freelance_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxGeneralInformation_Freelance.CheckedChanged

            CheckBoxGeneralInformation_ActiveFreelance.Enabled = CheckBoxGeneralInformation_Freelance.Checked

            If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm AndAlso
                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.None Then

                CheckBoxGeneralInformation_ActiveFreelance.Checked = CheckBoxGeneralInformation_Freelance.Checked

            End If

        End Sub

#End Region

#Region "  Time Tracking Tab Controls "

        Private Sub DataGridViewTimeTracking_WorkDays_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewTimeTracking_WorkDays.CellValueChangingEvent

            Dim WeeklyHours As Decimal = Nothing

            If e.Column IsNot Nothing AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.EmployeeStandardTime.Properties.DoesWork.ToString Then

                Try

                    If Convert.ToBoolean(e.Value) = False Then

                        DataGridViewTimeTracking_WorkDays.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.EmployeeStandardTime.Properties.Hours.ToString, 0)

                    End If

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub DataGridViewTimeTracking_WorkDays_CustomSummaryCalculateEvent(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles DataGridViewTimeTracking_WorkDays.CustomSummaryCalculateEvent

            Dim WeeklyHours As Decimal = Nothing
            Dim BestWidth As Integer = Nothing

            Try

                WeeklyHours = DataGridViewTimeTracking_WorkDays.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeStandardTime)().Where(Function(EmpStdTime) EmpStdTime.DoesWork).Select(Function(EmpStdTime) EmpStdTime.Hours).Sum

            Catch ex As Exception
                WeeklyHours = Nothing
            End Try

            e.TotalValue = WeeklyHours

            If DataGridViewTimeTracking_WorkDays.CurrentView.Columns("Hours") IsNot Nothing Then

                DataGridViewTimeTracking_WorkDays.CurrentView.Columns("Hours").BestFit()

            End If

        End Sub
        Private Sub DataGridViewTimeTracking_WorkDays_ShownEditorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewTimeTracking_WorkDays.ShownEditorEvent

            'objects
            Dim EmployeeStandardTime As AdvantageFramework.Database.Classes.EmployeeStandardTime = Nothing
            Dim DateEdit As DevExpress.XtraEditors.DateEdit = Nothing

            If DataGridViewTimeTracking_WorkDays.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Classes.EmployeeStandardTime.Properties.DoesWork.ToString AndAlso
                DataGridViewTimeTracking_WorkDays.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Classes.EmployeeStandardTime.Properties.DayOfWeek.ToString Then

                If TypeOf DataGridViewTimeTracking_WorkDays.CurrentView.ActiveEditor Is DevExpress.XtraEditors.DateEdit Then

                    Try

                        DateEdit = DirectCast(DataGridViewTimeTracking_WorkDays.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit)

                    Catch ex As Exception
                        DateEdit = Nothing
                    End Try

                    If DateEdit IsNot Nothing Then



                    End If

                End If

                Try

                    EmployeeStandardTime = DataGridViewTimeTracking_WorkDays.CurrentView.GetFocusedRow

                Catch ex As Exception
                    EmployeeStandardTime = Nothing
                End Try

                If EmployeeStandardTime IsNot Nothing Then

                    If EmployeeStandardTime.DoesWork = False Then

                        DataGridViewTimeTracking_WorkDays.CurrentView.CloseEditor()

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewTimeTracking_EmployeeTimeOff_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewTimeTracking_EmployeeTimeOff.QueryPopupNeedDatasourceEvent

            'objects 
            Dim PTOType As AdvantageFramework.Database.Entities.PTOTypes = AdvantageFramework.Database.Entities.PTOTypes.Personal

            If FieldName = AdvantageFramework.Database.Classes.EmployeeTimeOff.Properties.TimeRule.ToString Then

                OverrideDefaultDatasource = True

                Try

                    PTOType = DataGridViewTimeTracking_EmployeeTimeOff.CurrentView.GetRowCellValue(DataGridViewTimeTracking_EmployeeTimeOff.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.EmployeeTimeOff.Properties.PTOType.ToString)

                Catch ex As Exception

                End Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Datasource = (From Entity In AdvantageFramework.Database.Procedures.PTORule.LoadAllActive(DbContext).ToList
                                  Where Entity.Type = CByte(PTOType)
                                  Select Entity).ToList

                End Using

            End If

        End Sub
        Private Sub DataGridViewTimeTracking_EmployeeTimeOff_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewTimeTracking_EmployeeTimeOff.ShownEditorEvent

            ''objects
            'Dim PTOType As AdvantageFramework.Database.Entities.PTOTypes = AdvantageFramework.Database.Entities.PTOTypes.Personal
            'Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            'Dim DataSource As Object = Nothing
            'Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            'Dim FoundPTOType As Boolean = False

            'If DataGridViewTimeTracking_EmployeeTimeOff.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.EmployeeTimeOff.Properties.TimeRule.ToString Then

            '    If TypeOf DataGridViewTimeTracking_EmployeeTimeOff.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

            '        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            '            Try

            '                PTOType = DataGridViewTimeTracking_EmployeeTimeOff.CurrentView.GetRowCellValue(DataGridViewTimeTracking_EmployeeTimeOff.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.EmployeeTimeOff.Properties.PTOType.ToString)

            '                FoundPTOType = True

            '            Catch ex As Exception
            '                FoundPTOType = False
            '            End Try

            '            If FoundPTOType Then

            '                Try

            '                    GridLookUpEdit = DataGridViewTimeTracking_EmployeeTimeOff.CurrentView.ActiveEditor

            '                    BindingSource = New System.Windows.Forms.BindingSource

            '                    DataSource = (From Entity In AdvantageFramework.Database.Procedures.PTORule.LoadAllActive(DbContext) _
            '                                  Where Entity.Type = PTOType
            '                                  Select Entity)

            '                    BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(DataSource)

            '                    GridLookUpEdit.Properties.DataSource = BindingSource

            '                    AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, GridLookUpEdit.Properties.DisplayMember, GridLookUpEdit.Properties.ValueMember, "[None]", -3, True, True, Nothing)

            '                    GridLookUpEdit.Properties.View.BestFitColumns()

            '                Catch ex As Exception

            '                End Try

            '            End If

            '        End Using

            '    End If

            'End If

        End Sub
        Private Sub NumericInputTimeTracking_DirectHoursGoal_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles NumericInputTimeTracking_DirectHoursGoal.EditValueChanging

            Try

                If e.NewValue IsNot Nothing AndAlso IsNumeric(e.NewValue) AndAlso Convert.ToDecimal(e.NewValue, System.Globalization.NumberFormatInfo.InvariantInfo) > 100 Then

                    e.Cancel = True

                    AdvantageFramework.WinForm.MessageBox.Show("The Direct Hours Percent Goal is outside the allowable range. Please enter a percent up to 100%.")

                End If

            Catch ex As Exception

            End Try

        End Sub

#End Region

#Region "  POs And Expense Reports Tab Controls "

        Private Sub CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.CheckedChanged

            SearchableComboBoxPOsAndExpenseReports_AlternateApprover.Enabled = CheckBoxPOsAndExpenseReports_SupervisorApprovalRequired.Checked

        End Sub
        Private Sub CheckBoxPOsAndExpenseReports_AllowGLAccountSelection_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.CheckedChanged

            CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.Enabled = CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.Checked

            If CheckBoxPOsAndExpenseReports_AllowGLAccountSelection.Checked = False Then

                CheckBoxPOsAndExpenseReports_LimitAccountSelectionToOffice.Checked = False

            End If

        End Sub

#End Region

#Region "  HR and Rate Information Tab Controls "

        Private Sub RateFlagEntryControlHRAndRateInformation_BillingRateDetails_BillingRateDetailInitNewRow() Handles RateFlagEntryControlHRAndRateInformation_BillingRateDetails.BillingRateDetailInitNewRow

            RaiseEvent BillingRateDetailInitNewRowEvent()

        End Sub
        Private Sub RateFlagEntryControlHRAndRateInformation_BillingRateDetails_SelectedBillingRateDetailChanged() Handles RateFlagEntryControlHRAndRateInformation_BillingRateDetails.SelectedBillingRateDetailChanged

            RaiseEvent SelectedBillingRateDetailChanged()

        End Sub
        Private Sub RateFlagEntryControlHRAndRateInformation_BillingRateDetails_SelectedBillingRateLevelChanged() Handles RateFlagEntryControlHRAndRateInformation_BillingRateDetails.SelectedBillingRateLevelChanged

            RaiseEvent SelectedBillingRateLevelChanged()

        End Sub
        Private Sub RateFlagEntryControlHRAndRateInformation_BillingRateDetails_SelectedBillingRateLevelChanging() Handles RateFlagEntryControlHRAndRateInformation_BillingRateDetails.SelectedBillingRateLevelChanging

            'objects
            Dim BaseForm As AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm = Nothing

            If Me.FindForm IsNot Nothing AndAlso TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                BaseForm = DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm)

                If AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(RateFlagEntryControlHRAndRateInformation_BillingRateDetails) Then

                    If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        If BaseForm.ValidateControl(RateFlagEntryControlHRAndRateInformation_BillingRateDetails) Then

                            BaseForm.Cursor = Windows.Forms.Cursors.WaitCursor

                            BaseForm.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                            Try

                                RateFlagEntryControlHRAndRateInformation_BillingRateDetails.Save()

                                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(RateFlagEntryControlHRAndRateInformation_BillingRateDetails)

                            Catch ex As Exception
                                AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            End Try

                            BaseForm.Cursor = Windows.Forms.Cursors.Default

                            BaseForm.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                            'BaseForm.ClearValidations()

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub NumericInputHRAndRateInformation_AnnualSalary_ValueChanged(sender As Object, e As EventArgs) Handles NumericInputHRAndRateInformation_AnnualSalary.ValueChanged

            If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                If DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.None Then

                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.Modifying

                    If NumericInputHRAndRateInformation_AnnualSalary.EditValue IsNot Nothing Then

                        Try

                            NumericInputHRAndRateInformation_MonthlySalary.EditValue = Math.Round(NumericInputHRAndRateInformation_AnnualSalary.EditValue / 12, 2)

                        Catch ex As Exception
                            NumericInputHRAndRateInformation_MonthlySalary.EditValue = Nothing
                        End Try

                    Else

                        NumericInputHRAndRateInformation_MonthlySalary.EditValue = Nothing

                    End If

                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.None

                    CalculateCostRate()

                End If

            End If

        End Sub
        Private Sub NumericInputHRAndRateInformation_MonthlySalary_ValueChanged(sender As Object, e As EventArgs) Handles NumericInputHRAndRateInformation_MonthlySalary.ValueChanged

            'objects
            Dim AnnualHours As Decimal = 0

            If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                If DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.None Then

                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.Modifying

                    If NumericInputHRAndRateInformation_MonthlySalary.EditValue IsNot Nothing Then

                        Try

                            NumericInputHRAndRateInformation_AnnualSalary.EditValue = Math.Round(NumericInputHRAndRateInformation_MonthlySalary.EditValue * 12, 2)

                        Catch ex As Exception
                            NumericInputHRAndRateInformation_AnnualSalary.EditValue = Nothing
                        End Try

                    Else

                        NumericInputHRAndRateInformation_AnnualSalary.EditValue = Nothing

                    End If

                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.None

                    CalculateCostRate()

                End If

            End If

        End Sub

#End Region

#Region "  Security and Passwords Tab Controls "

        Private Sub DataGridViewLeftSection_AvailableSecurityGroups_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_AvailableSecurityGroups.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_EmployeeSecurityGroups_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRightSection_EmployeeSecurityGroups.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub SearchableComboBoxSecurityAndPasswords_User_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxSecurityAndPasswords_User.EditValueChanged

            LoadSecurityGroups()
            LoadEmployeeLimits()
            LoadCDPsLimits()
            LoadDefaultFunctions()

        End Sub
        Private Sub ButtonRightSection_AddSecurityGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_AddSecurityGroup.Click

            Dim GroupUser As AdvantageFramework.Security.Database.Entities.GroupUser = Nothing
            Dim GroupID As String = Nothing
            Dim UserID As String = Nothing
            Dim NewEmployeeRole As AdvantageFramework.Database.Entities.EmployeeRole = Nothing

            If DataGridViewLeftSection_AvailableSecurityGroups.HasASelectedRow Then

                GroupID = DataGridViewLeftSection_AvailableSecurityGroups.GetFirstSelectedRowBookmarkValue
                UserID = SearchableComboBoxSecurityAndPasswords_User.GetSelectedValue

                If _EmployeeCode IsNot Nothing Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        AdvantageFramework.Security.Database.Procedures.GroupUser.Insert(SecurityDbContext, GroupID, UserID, Nothing)

                    End Using

                End If

                LoadSecurityGroups()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveSecurityGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_RemoveSecurityGroup.Click

            Dim GroupUser As AdvantageFramework.Security.Database.Entities.GroupUser = Nothing
            Dim GroupID As String = Nothing
            Dim UserID As String = Nothing
            Dim NewEmployeeRole As AdvantageFramework.Database.Entities.EmployeeRole = Nothing

            If DataGridViewRightSection_EmployeeSecurityGroups.HasASelectedRow Then

                GroupID = DataGridViewRightSection_EmployeeSecurityGroups.GetFirstSelectedRowBookmarkValue
                UserID = SearchableComboBoxSecurityAndPasswords_User.GetSelectedValue

                If _EmployeeCode IsNot Nothing Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        GroupUser = AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByGroupIDAndUserID(SecurityDbContext, GroupID, UserID)

                        AdvantageFramework.Security.Database.Procedures.GroupUser.Delete(SecurityDbContext, GroupUser)

                    End Using

                End If

                LoadSecurityGroups()

            End If

        End Sub
        Private Sub EmployeeOfficeLimitControlOfficeLimits_EmployeeOfficeLimits_OfficesChangedEvent() Handles EmployeeOfficeLimitControlEmployeeOfficeLimits_EmployeeOfficeLimits.OfficesChangedEvent

            RaiseEvent EmployeeOfficesChangedEvent()

        End Sub
        Private Sub TabControlSecurityAndPasswords_SecurityAndPasswords_SelectedTabChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlSecurityAndPasswords_SecurityAndPasswords.SelectedTabChanged

            RaiseEvent SelectedTabChanged(sender, e)

        End Sub

#End Region

#Region "  Alerts Tab Controls "

        Private Sub ButtonRightSection_AddAlertGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_AddAlertGroup.Click

            Dim EmployeeAlertGroups As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeAlertGroup) = Nothing
            Dim EmployeeAlertGroup As AdvantageFramework.Database.Classes.EmployeeAlertGroup = Nothing
            Dim AlertGroupCode As String = Nothing
            Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing

            If DataGridViewLeftSection_AvailableAlertGroups.HasASelectedRow Then

                AlertGroupCode = DataGridViewLeftSection_AvailableAlertGroups.GetFirstSelectedRowBookmarkValue

                If _EmployeeCode IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        AlertGroup = New AdvantageFramework.Database.Entities.AlertGroup

                        AlertGroup.DbContext = DbContext
                        AlertGroup.EmployeeCode = _EmployeeCode
                        AlertGroup.Code = AlertGroupCode
                        AlertGroup.IsInactive = Convert.ToInt16(DataGridViewLeftSection_AvailableAlertGroups.CurrentView.GetRowCellValue(DataGridViewLeftSection_AvailableAlertGroups.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.AlertGroup.Properties.IsInactive.ToString))

                        AdvantageFramework.Database.Procedures.AlertGroup.Insert(DbContext, AlertGroup)

                    End Using

                Else

                    EmployeeAlertGroups = DataGridViewRightSection_EmployeeAlertGroups.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeAlertGroup).ToList

                    EmployeeAlertGroup = New AdvantageFramework.Database.Classes.EmployeeAlertGroup

                    EmployeeAlertGroup.AlertGroupCode = AlertGroupCode

                    EmployeeAlertGroups.Add(EmployeeAlertGroup)

                    DataGridViewRightSection_EmployeeAlertGroups.DataSource = EmployeeAlertGroups

                End If

                LoadEmployeeAlertGroups()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveAlertGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_RemoveAlertGroup.Click

            Dim EmployeeAlertGroups As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeAlertGroup) = Nothing
            Dim EmployeeAlertGroup As AdvantageFramework.Database.Classes.EmployeeAlertGroup = Nothing
            Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing
            Dim AlertGroupCode As String = Nothing
            Dim Deleted As Boolean = False

            If DataGridViewRightSection_EmployeeAlertGroups.HasASelectedRow Then

                AlertGroupCode = DataGridViewRightSection_EmployeeAlertGroups.CurrentView.GetRowCellValue(DataGridViewRightSection_EmployeeAlertGroups.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.EmployeeAlertGroup.Properties.AlertGroupCode.ToString)

                EmployeeAlertGroup = DataGridViewRightSection_EmployeeAlertGroups.GetFirstSelectedRowDataBoundItem

                If _EmployeeCode IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        AlertGroup = AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCodeAndEmployeeCode(DbContext, AlertGroupCode, _EmployeeCode)

                        If AlertGroup IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.AlertGroup.Delete(DbContext, AlertGroup) Then

                                Deleted = True

                            End If

                        End If

                    End Using

                Else

                    EmployeeAlertGroups = DataGridViewRightSection_EmployeeAlertGroups.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeAlertGroup).ToList

                    DataGridViewRightSection_EmployeeAlertGroups.CurrentView.DeleteRow(DataGridViewRightSection_EmployeeAlertGroups.CurrentView.FocusedRowHandle)

                    Deleted = True

                End If

                If Deleted Then

                    LoadEmployeeAlertGroups()

                End If

            End If

        End Sub
        Private Sub CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.CheckedChangedEx

            CheckBoxSettingsRightColumn_ReceivesAlerts.Enabled = Not CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.Checked

            CheckBoxSettingsRightColumn_ReceivesAlerts.Checked = CheckBoxSettingsRightColumn_ReceivesAlertsAndEmail.Checked

        End Sub
        Private Sub CheckBoxSettings_IsAPIUser_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSettings_IsAPIUser.CheckedChanged

            If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                If DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormShown AndAlso
                        DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.None Then

                    If CheckBoxSettings_IsAPIUser.Checked AndAlso _AvailableAPIUsers <= 0 Then

                        CheckBoxSettings_IsAPIUser.Checked = False

                        AdvantageFramework.WinForm.MessageBox.Show("You do not have enough API licenses. Please contact Software Support.")

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_EmployeeAlertGroups_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRightSection_EmployeeAlertGroups.CellValueChangingEvent

            Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing
            Dim EmployeeAlertGroup As AdvantageFramework.Database.Classes.EmployeeAlertGroup = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Classes.EmployeeAlertGroup.Properties.IncludeOnSchedule.ToString Then

                Try

                    EmployeeAlertGroup = DataGridViewRightSection_EmployeeAlertGroups.CurrentView.GetRow(e.RowHandle)

                Catch ex As Exception
                    EmployeeAlertGroup = Nothing
                End Try

                If EmployeeAlertGroup IsNot Nothing Then

                    EmployeeAlertGroup.IncludeOnSchedule = e.Value

                    If _EmployeeCode IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            AlertGroup = AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCodeAndEmployeeCode(DbContext, EmployeeAlertGroup.AlertGroupCode, _EmployeeCode)

                            AlertGroup.IncludeOnSchedule = e.Value

                            Saved = AdvantageFramework.Database.Procedures.AlertGroup.Update(DbContext, AlertGroup)

                        End Using

                    End If

                End If

                LoadEmployeeAlertGroups()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_AvailableAlertGroups_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_AvailableAlertGroups.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_EmployeeAlertGroups_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRightSection_EmployeeAlertGroups.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonSettings_AdobeSignatureFileSelect_Click(sender As Object, e As EventArgs) Handles ButtonSettings_AdobeSignatureFileSelect.Click

            Dim AdobeSignatureLocation As String = Nothing
            Dim AdobeSignature As Byte() = Nothing
            Dim FileStream As System.IO.FileStream = Nothing
            Dim BinaryReader As System.IO.BinaryReader = Nothing
            Dim Files() As String = Nothing
            Dim ImportFolder As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                    ImportFolder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext), "\") & "Signature\"

                    If AdvantageFramework.WinForm.Presentation.FolderBrowserDialog.ShowFormDialog(ImportFolder, New Generic.List(Of AdvantageFramework.FileSystem.FileFilters)({FileSystem.FileFilters.PFX, FileSystem.FileFilters.P12}), False, Files) = Windows.Forms.DialogResult.OK Then

                        If Files IsNot Nothing AndAlso Files.Count > 0 Then

                            AdobeSignatureLocation = Files(0)

                        End If

                    End If

                Else

                    AdobeSignatureLocation = AdvantageFramework.WinForm.Presentation.SelectFileToOpen("", "PFX files (*.pfx)|*.pfx|P12 files (*.p12)|*.p12", "")

                End If

            End Using

            If String.IsNullOrWhiteSpace(AdobeSignatureLocation) = False Then

                FileStream = New System.IO.FileStream(AdobeSignatureLocation, System.IO.FileMode.Open, System.IO.FileAccess.Read)

                BinaryReader = New System.IO.BinaryReader(FileStream)

                AdobeSignature = BinaryReader.ReadBytes(CInt(New System.IO.FileInfo(AdobeSignatureLocation).Length))

                TextBoxSettings_AdobeSignatureFile.Tag = AdobeSignature

                Try

                    TextBoxSettings_AdobeSignatureFile.Text = AdobeSignatureLocation

                Catch ex As Exception

                End Try

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonSettings_AdobeSignatureFileDelete_Click(sender As Object, e As EventArgs) Handles ButtonSettings_AdobeSignatureFileDelete.Click

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                Try

                    TextBoxSettings_AdobeSignatureFile.Tag = Nothing
                    TextBoxSettings_AdobeSignatureFilePassword.Text = ""

                    Try

                        TextBoxSettings_AdobeSignatureFile.Text = "Deleted"

                    Catch ex As Exception

                    End Try

                Catch ex As Exception

                End Try

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub TextBoxSettingsRightColumn_EmailAddress_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSettingsRightColumn_EmailAddress.TextChanged

            EnableOrDisableConceptShareCreateUser()

        End Sub
        Private Sub TextBoxSettingsRightColumn_EmailAddress_FinalizeValidationEvent(ByRef IsValid As Boolean, ByRef ErrorText As String) Handles TextBoxSettingsRightColumn_EmailAddress.FinalizeValidationEvent

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing

            If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm AndAlso
                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.None AndAlso
                    TabItemEmployeeDetails_AlertsTab.Tag = True Then

                If IsValid Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            If AdvantageFramework.ConceptShare.IsConceptShareEnabled(DataContext) Then

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                                If Employee IsNot Nothing AndAlso Employee.ConceptShareUserID.GetValueOrDefault(0) > 0 Then

                                    If String.IsNullOrWhiteSpace(TextBoxSettingsRightColumn_EmailAddress.Text) AndAlso String.IsNullOrWhiteSpace(Employee.Email) = False Then

                                        If AdvantageFramework.WinForm.MessageBox.Show("Removing the email address from this employee will remove the employee from ConceptShare." &
                                                                                      System.Environment.NewLine & System.Environment.NewLine & "Are you sure you want to continue?",
                                                                                      AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "ConceptShare") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                                            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.Deleting, "Removing User...")

                                            APIReponse = AdvantageFramework.ConceptShare.RemoveConceptShareUser(DataContext, Employee)

                                            If APIReponse.CompletedSuccessfully Then

                                                AdvantageFramework.WinForm.MessageBox.Show("ConceptShare user removed!")

                                                ButtonConceptShare_CreateUser.Enabled = False
                                                ButtonConceptShare_UpdateUser.Enabled = False
                                                ButtonConceptShare_RemoveUser.Enabled = False

                                                TextBoxConceptShare_Password.Text = ""
                                                CheckBoxConceptShare_IsActive.Checked = True

                                                EnableOrDisableConceptShareCreateUser()

                                            Else

                                                AdvantageFramework.WinForm.MessageBox.Show(APIReponse.ErrorMessage)

                                                TextBoxSettingsRightColumn_EmailAddress.Text = Employee.Email

                                            End If

                                            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.None)

                                        Else

                                            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.Refreshing, "Refeshing...")

                                            TextBoxSettingsRightColumn_EmailAddress.Text = Employee.Email

                                            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.None)

                                        End If

                                    ElseIf TextBoxSettingsRightColumn_EmailAddress.Text <> Employee.Email Then

                                        If AdvantageFramework.WinForm.MessageBox.Show("Changing the email address for this employee will remove the employee from ConceptShare." &
                                                                                      System.Environment.NewLine & System.Environment.NewLine & "Are you sure you want to continue?",
                                                                                      AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "ConceptShare") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                                            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.Deleting, "Removing User...")

                                            APIReponse = AdvantageFramework.ConceptShare.RemoveConceptShareUser(DataContext, Employee)

                                            If APIReponse.CompletedSuccessfully Then

                                                AdvantageFramework.WinForm.MessageBox.Show("ConceptShare user removed!")

                                                ButtonConceptShare_CreateUser.Enabled = False
                                                ButtonConceptShare_UpdateUser.Enabled = False
                                                ButtonConceptShare_RemoveUser.Enabled = False

                                                TextBoxConceptShare_Password.Text = ""
                                                CheckBoxConceptShare_IsActive.Checked = True

                                                EnableOrDisableConceptShareCreateUser()

                                            Else

                                                AdvantageFramework.WinForm.MessageBox.Show(APIReponse.ErrorMessage)

                                                TextBoxSettingsRightColumn_EmailAddress.Text = Employee.Email

                                            End If

                                            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.None)

                                        Else

                                            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.Refreshing, "Refeshing...")

                                            TextBoxSettingsRightColumn_EmailAddress.Text = Employee.Email

                                            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.None)

                                        End If

                                    End If

                                End If

                            End If

                        End Using

                    End Using

                End If

            End If

        End Sub
        Private Sub TextBoxConceptShare_Password_TextChanged(sender As Object, e As EventArgs) Handles TextBoxConceptShare_Password.TextChanged

            EnableOrDisableConceptShareCreateUser()

        End Sub
        Private Sub ButtonConceptShare_CreateUser_Click(sender As Object, e As EventArgs) Handles ButtonConceptShare_CreateUser.Click

            'objects
            Dim ValidDataEntered As Boolean = True
            Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing
            Dim UserName As String = ""

            If String.IsNullOrWhiteSpace(TextBoxSettingsRightColumn_EmailAddress.Text) OrElse
                    AdvantageFramework.StringUtilities.IsValidEmailAddress(TextBoxSettingsRightColumn_EmailAddress.Text) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("Please enter a valid email address.")
                ValidDataEntered = False

            End If

            If ValidDataEntered Then

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.ConceptShare.LoadSystemAccountUserNameAndPassword(DataContext, UserName, "") AndAlso
                            TextBoxSettingsRightColumn_EmailAddress.Text = UserName Then

                        AdvantageFramework.WinForm.MessageBox.Show("Please enter an email address different from the system account email address.")
                        ValidDataEntered = False

                    End If

                End Using

            End If

            If ValidDataEntered Then

                If String.IsNullOrWhiteSpace(TextBoxConceptShare_Password.Text) Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please enter a password.")
                    TextBoxConceptShare_Password.Focus()
                    ValidDataEntered = False

                End If

            End If

            If ValidDataEntered Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.Saving, "Creating User...")

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    APIReponse = AdvantageFramework.ConceptShare.CreateConceptShareUser(DataContext, _EmployeeCode, TextBoxGeneralInformation_FirstName.Text,
                                                                                        TextBoxGeneralInformation_LastName.Text, TextBoxSettingsRightColumn_EmailAddress.Text,
                                                                                        TextBoxConceptShare_Password.Text, CheckBoxConceptShare_IsActive.Checked)

                    If APIReponse.CompletedSuccessfully Then

                        AdvantageFramework.WinForm.MessageBox.Show("ConceptShare user created!")

                        ButtonConceptShare_CreateUser.Enabled = False
                        ButtonConceptShare_UpdateUser.Enabled = True
                        ButtonConceptShare_RemoveUser.Enabled = True

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(APIReponse.ErrorMessage)

                    End If

                End Using

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.None)

            End If

        End Sub
        Private Sub ButtonConceptShare_UpdateUser_Click(sender As Object, e As EventArgs) Handles ButtonConceptShare_UpdateUser.Click

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing

            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.Saving, "Saving...")

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                If Employee IsNot Nothing Then

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        APIReponse = AdvantageFramework.ConceptShare.UpdateConceptShareUser(DataContext, Employee, Employee.ConceptShareUserID,
                                                                                            TextBoxGeneralInformation_FirstName.Text, TextBoxGeneralInformation_LastName.Text,
                                                                                            TextBoxSettingsRightColumn_EmailAddress.Text, TextBoxConceptShare_Password.Text,
                                                                                            CheckBoxConceptShare_IsActive.Checked)

                        If APIReponse.CompletedSuccessfully Then

                            AdvantageFramework.WinForm.MessageBox.Show("ConceptShare user updated!")

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show(APIReponse.ErrorMessage)

                        End If

                    End Using

                End If

            End Using

            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.None)

        End Sub
        Private Sub ButtonConceptShare_RemoveUser_Click(sender As Object, e As EventArgs) Handles ButtonConceptShare_RemoveUser.Click

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing

            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.Deleting, "Removing User...")

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                If Employee IsNot Nothing Then

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        APIReponse = AdvantageFramework.ConceptShare.RemoveConceptShareUser(DataContext, Employee)

                        If APIReponse.CompletedSuccessfully Then

                            AdvantageFramework.WinForm.MessageBox.Show("ConceptShare user removed!")

                            ButtonConceptShare_CreateUser.Enabled = False
                            ButtonConceptShare_UpdateUser.Enabled = False
                            ButtonConceptShare_RemoveUser.Enabled = False

                            TextBoxConceptShare_Password.Text = ""
                            CheckBoxConceptShare_IsActive.Checked = True

                            EnableOrDisableConceptShareCreateUser()

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show(APIReponse.ErrorMessage)

                        End If

                    End Using

                End If

            End Using

            DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.None)

        End Sub
        Private Sub CheckBoxConceptShare_IsActive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxConceptShare_IsActive.CheckedChanged

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing

            If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm AndAlso
                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.None Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.Saving, "Saving...")

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                    If Employee IsNot Nothing AndAlso Employee.ConceptShareUserID.GetValueOrDefault(0) > 0 Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            APIReponse = AdvantageFramework.ConceptShare.UpdateConceptShareUser(DataContext, Employee.ConceptShareUserID, CheckBoxConceptShare_IsActive.Checked)

                            If APIReponse IsNot Nothing AndAlso APIReponse.CompletedSuccessfully = False Then

                                AdvantageFramework.WinForm.MessageBox.Show(APIReponse.ErrorMessage)

                            End If

                        End Using

                    End If

                End Using

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.None)

            End If

        End Sub
        Private Sub CheckBoxConceptShare_ShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxConceptShare_ShowPassword.CheckedChanged

            TextBoxConceptShare_Password.UseSystemPasswordChar = (CheckBoxConceptShare_ShowPassword.Checked = False)

        End Sub
        Private Sub ComboBoxCalendarTime_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCalendarTime_Type.SelectedIndexChanged
            If ComboBoxCalendarTime_Type.SelectedValue = 1 Or ComboBoxCalendarTime_Type.SelectedValue = 2 Then
                If ComboBoxCalendarTime_Type.SelectedValue = 1 Then
                    TextBoxCalendarTime_EmailUserName.Visible = False
                    TextBoxCalendarTime_EmailPassword.Visible = False
                    Me.Label13.Visible = False
                    Me.Label14.Visible = False
                Else
                    TextBoxCalendarTime_EmailUserName.Visible = True
                    TextBoxCalendarTime_EmailPassword.Visible = True
                    Me.Label13.Visible = True
                    Me.Label14.Visible = True
                End If
                TextBoxCalendarTime_Host.Visible = False
                Me.Label2.Visible = False
                TextBoxCalendarTime_Port.Visible = False
                Me.Label3.Visible = False
                Me.CheckBoxForm_SSL.Visible = False
            Else
                TextBoxCalendarTime_Host.Visible = True
                Me.Label2.Visible = True
                TextBoxCalendarTime_Port.Visible = True
                Me.Label3.Visible = True
                Me.CheckBoxForm_SSL.Visible = True
                TextBoxCalendarTime_EmailUserName.Visible = True
                TextBoxCalendarTime_EmailPassword.Visible = True
                Me.Label13.Visible = True
                Me.Label14.Visible = True
            End If

        End Sub
        Private Sub DataGridViewAdditionalEmails_AdditionalEmails_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewAdditionalEmails_AdditionalEmails.SelectionChangedEvent

            RaiseEvent AdditionalEmailsSelectionChangedEvent()

        End Sub
        Private Sub TabControlAlerts_Alerts_SelectedTabChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlAlerts_Alerts.SelectedTabChanged

            RaiseEvent SelectedTabChanged(sender, e)

        End Sub

#End Region

#Region "  Notes Tab Controls "

        Private Sub ButtonNotes_CheckSpelling_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonNotes_CheckSpelling.Click

            CheckNotesSpelling()

        End Sub

#End Region

#Region "  Documents Tab Controls "

        Private Sub DocumentManagerControlDocuments_EmployeeDocuments_SelectedDocumentChanged() Handles DocumentManagerControlDocuments_EmployeeDocuments.SelectedDocumentChanged

            RaiseEvent SelectedDocumentChanged()

        End Sub


#End Region

#End Region

#End Region

    End Class

End Namespace
