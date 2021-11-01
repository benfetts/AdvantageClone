Namespace Database.Views

    <Table("EMPLOYEE")>
    Public Class Employee
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            LastName
            FirstName
            MiddleInitial
            TerminationDate
            Email
            EmailPassword
            MondayHours
            TuesdayHours
            WednesdayHours
            ThursdayHours
            FridayHours
            SaturdayHours
            SundayHours
            AlertNotificationType
            FunctionCode
            IsMissingTime
            WeeklyTimeType
            RoleCode
            EmailUserName
            ReplyToEmail
            SignatureImage
            OfficeCode
            BillRate
            SupervisorEmployeeCode
            CostRate
            DepartmentTeamCode
            Address
            Address2
            AccountNumber
            City
            County
            State
            Zip
            OtherInfo
            PhoneNumber
            WorkPhoneNumber
            WorkPhoneNumberExtension
            CellPhoneNumber
            AlternatePhoneNumber
            Title
            StartDate
            BirthDate
            LastIncrease
            NextReview
            AnnualSalary
            MonthlySalary
            AnnualHours
            MonthHoursGoal
            PurchaseOrderLimit
            PurchaseOrderApprovalRuleCode
            EmployeeTitleID
            DirectHours
            PayToAddress
            PayToAddress2
            PayToCity
            PayToCounty
            PayToState
            PayToZip
            LastModifiedByUserCode
            LastModifiedDate
            Country
            PayToCountry
            VacationHours
            VacationDateFrom
            VacationDateTo
            SickHours
            SickDateFrom
            SickDateTo
            PersonalHours
            PersonalHoursDateFrom
            PersonalHoursDateTo
            StandardWorkHours
            WorkDays
            TimeAlert
            SMTPServer
            Freelance
            CreditCardNumber
            CreditCardDescription
            CreditCardGLAccount
            SupervisorApprovalRequired
            Comments
            AllowPOGLSelection
            LimitPOGLSelectionOffice
            Seniority
            StartTime
            EndTime
            EmployeeVendorCode
            Status
            AlternateCostRate
            AlternateDateFrom
            AlternateDateTo
            MondayStartTime
            MondayEndTime
            TuesdayStartTime
            TuesdayEndTime
            WednesdayStartTime
            WednesdayEndTime
            ThursdayStartTime
            ThursdayEndTime
            FridayStartTime
            FridayEndTime
            SaturdayStartTime
            SaturdayEndTime
            SundayStartTime
            SundayEndTime
            SignaturePath
            AlternateApproverCode
            VacationTimeRule
            PersonalTimeRule
            SickTimeRule
            TimesheetApprovalFlag
            IsActiveFreelance
            SugarCRMUserName
            SugarCRMPassword
            ProofHQUserName
            ProofHQPassword
            IsAPIUser
            GoogleToken
            AdobeSignatureFile
            AdobeSignatureFilePassword
            VCCUserName
            VCCPassword
			OmitFromMissingTimeTracking
            IgnoreCalendarSync
            TimeZoneID
            ConceptShareUserID
            ConceptSharePassword
            CalendarTimeType
            CalendarTimeEmailAddress
            CalendarTimeUserName
            CalendarTimePassword
            CalendarTimeHost
            CalendarTimePort
            CalendarTimeSSL
            BillingRateDetails
            EmployeeTimeForecastOfficeDetailEmployees
            EmployeeDepartments
            DepartmentTeam
            Office
            JobComponentTasks
            EmployeeOffices
            ApprovedEmployeeTimeForecastOfficeDetails
            AssignedEmployeeTimeForecastOfficeDetails
            AccountExecutives
            EmployeePictures
            Role
            [Function]
            EmployeeRateHistories
            EmployeeTitle
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <MaxLength(6)>
        <Column("EMP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
        Public Property Code() As String
        <MaxLength(30)>
        <Column("EMP_LNAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LastName() As String
        <MaxLength(30)>
        <Column("EMP_FNAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property FirstName() As String
        <MaxLength(1)>
        <Column("EMP_MI", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MiddleInitial() As String
        <Column("EMP_TERM_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TerminationDate() As Nullable(Of Date)
        <MaxLength(50)>
        <Column("EMP_EMAIL", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Email)>
        Public Property Email() As String
        <Column("EMAIL_PWD", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmailPassword() As String
        <Column("MON_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MondayHours() As Nullable(Of Decimal)
        <Column("TUE_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TuesdayHours() As Nullable(Of Decimal)
        <Column("WED_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WednesdayHours() As Nullable(Of Decimal)
        <Column("THU_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ThursdayHours() As Nullable(Of Decimal)
        <Column("FRI_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FridayHours() As Nullable(Of Decimal)
        <Column("SAT_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SaturdayHours() As Nullable(Of Decimal)
        <Column("SUN_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SundayHours() As Nullable(Of Decimal)
        <Column("ALERT_EMAIL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertNotificationType() As Nullable(Of Short)
        <MaxLength(6)>
        <Column("DEF_FNC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
        <Column("MISSING_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsMissingTime() As Nullable(Of Short)
        <Column("WEEKLY_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WeeklyTimeType() As Nullable(Of Short)
        <MaxLength(6)>
        <Column("DEF_TRF_ROLE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RoleCode() As String
        <MaxLength(50)>
        <Column("EMAIL_USERNAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmailUserName() As String
        <MaxLength(50)>
        <Column("EMAIL_REPLY_TO", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReplyToEmail() As String
        <Column("EMP_SIG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SignatureImage() As Byte()
        <MaxLength(4)>
        <Column("OFFICE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <Column("EMP_BILL_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillRate() As Nullable(Of Decimal)
        <MaxLength(6)>
        <Column("SUPERVISOR_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SupervisorEmployeeCode() As String
        <Column("EMP_COST_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CostRate() As Nullable(Of Decimal)
        <MaxLength(4)>
        <Column("DP_TM_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DepartmentTeamCode() As String
        <MaxLength(30)>
        <Column("EMP_ADDRESS1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Address() As String
        <MaxLength(30)>
        <Column("EMP_ADDRESS2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Address2() As String
        <MaxLength(30)>
        <Column("EMP_ACCOUNT_NBR", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountNumber() As String
        <MaxLength(20)>
        <Column("EMP_CITY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property City() As String
        <MaxLength(20)>
        <Column("EMP_COUNTY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property County() As String
        <MaxLength(10)>
        <Column("EMP_STATE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property State() As String
        <MaxLength(10)>
        <Column("EMP_ZIP", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Zip() As String
        <MaxLength(20)>
        <Column("EMP_OTHER_INFO", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SocialSecurityNumber)>
        Public Property OtherInfo() As String
        <MaxLength(13)>
        <Column("EMP_PHONE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PhoneNumber() As String
        <MaxLength(13)>
        <Column("EMP_PHONE_WORK", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WorkPhoneNumber() As String
        <MaxLength(10)>
        <Column("EMP_PHONE_WORK_EXT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WorkPhoneNumberExtension() As String
        <MaxLength(13)>
        <Column("EMP_PHONE_CELL", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CellPhoneNumber() As String
        <MaxLength(13)>
        <Column("EMP_PHONE_ALT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlternatePhoneNumber() As String
        <MaxLength(50)>
        <Column("EMP_TITLE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Title() As String
        <Column("EMP_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartDate() As Nullable(Of Date)
        <Column("EMP_BIRTH_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BirthDate() As Nullable(Of Date)
        <Column("EMP_LAST_INCREASE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastIncrease() As Nullable(Of Date)
        <Column("EMP_NEXT_REVIEW")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NextReview() As Nullable(Of Date)
        <Column("EMP_ANNUAL_SALARY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AnnualSalary() As Nullable(Of Decimal)
        <Column("EMP_MONTHLY_SALARY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MonthlySalary() As Nullable(Of Decimal)
        <Column("STD_ANNUAL_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AnnualHours() As Nullable(Of Decimal)
        <Column("MTH_HRS_GOAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MonthHoursGoal() As Nullable(Of Decimal)
        <Column("PO_LIMIT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PurchaseOrderLimit() As Nullable(Of Decimal)
        <MaxLength(6)>
        <Column("PO_APPR_RULE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PurchaseOrderApprovalRuleCode() As String
        <Column("EMPLOYEE_TITLE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTitleID() As Nullable(Of Integer)
        <Column("DIRECT_HRS_PER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=100)>
        Public Property DirectHours() As Nullable(Of Decimal)
        <MaxLength(30)>
        <Column("EMP_PAY_TO_ADDR1", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToAddress() As String
        <MaxLength(30)>
        <Column("EMP_PAY_TO_ADDR2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToAddress2() As String
        <MaxLength(20)>
        <Column("EMP_PAY_TO_CITY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToCity() As String
        <MaxLength(20)>
        <Column("EMP_PAY_TO_COUNTY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToCounty() As String
        <MaxLength(10)>
        <Column("EMP_PAY_TO_STATE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToState() As String
        <MaxLength(10)>
        <Column("EMP_PAY_TO_ZIP", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToZip() As String
        <MaxLength(100)>
        <Column("LAST_MODIFIED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastModifiedByUserCode() As String
        <Column("LAST_MODIFIED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastModifiedDate() As Nullable(Of Date)
        <MaxLength(20)>
        <Column("EMP_COUNTRY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Country() As String
        <MaxLength(20)>
        <Column("EMP_PAY_TO_COUNTRY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayToCountry() As String
        <Column("VAC_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VacationHours() As Nullable(Of Decimal)
        <Column("VAC_FROM_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VacationDateFrom() As Nullable(Of Date)
        <Column("VAC_TO_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VacationDateTo() As Nullable(Of Date)
        <Column("SICK_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SickHours() As Nullable(Of Decimal)
        <Column("SICK_FROM_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SickDateFrom() As Nullable(Of Date)
        <Column("SICK_TO_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SickDateTo() As Nullable(Of Date)
        <Column("PERS_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PersonalHours() As Nullable(Of Decimal)
        <Column("PERS_FROM_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PersonalHoursDateFrom() As Nullable(Of Date)
        <Column("PERS_TO_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PersonalHoursDateTo() As Nullable(Of Date)
        <Column("STD_WORK_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StandardWorkHours() As Nullable(Of Decimal)
        <MaxLength(30)>
        <Column("EMP_WORK_DAYS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WorkDays() As String
        <Column("EMP_TIME_ALERT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TimeAlert() As Nullable(Of Short)
        <MaxLength(40)>
        <Column("SMTP_SERVER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SMTPServer() As String
        <Column("FREELANCE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Freelance() As Nullable(Of Short)
        <MaxLength(30)>
        <Column("CC_NUMBER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreditCardNumber() As String
        <MaxLength(40)>
        <Column("CC_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreditCardDescription() As String
        <MaxLength(30)>
        <Column("CC_GL_ACCOUNT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreditCardGLAccount() As String
        <Column("EXP_APPR_REQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SupervisorApprovalRequired() As Nullable(Of Short)
		<Column("EMP_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Comments() As String
		<Column("PO_GL_SELECTION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AllowPOGLSelection() As Nullable(Of Short)
		<Column("PO_GL_LIMIT_BY_OFFICE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LimitPOGLSelectionOffice() As Nullable(Of Short)
		<Column("SENIORITY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=9999)>
		Public Property Seniority() As Nullable(Of Short)
		<Column("EMP_START_TIME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StartTime() As Nullable(Of Date)
		<Column("EMP_END_TIME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EndTime() As Nullable(Of Date)
		<MaxLength(6)>
		<Column("VN_CODE_EXP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeVendorCode() As String
		<Column("STATUS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Status() As Nullable(Of Short)
		<Column("ALT_COST_RATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlternateCostRate() As Nullable(Of Decimal)
		<Column("ALT_DATE_FRM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlternateDateFrom() As Nullable(Of Date)
		<Column("ALT_DATE_TO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlternateDateTo() As Nullable(Of Date)
		<Column("EMP_START_TIME_MON")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MondayStartTime() As Nullable(Of Date)
		<Column("EMP_END_TIME_MON")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MondayEndTime() As Nullable(Of Date)
		<Column("EMP_START_TIME_TUE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TuesdayStartTime() As Nullable(Of Date)
		<Column("EMP_END_TIME_TUE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TuesdayEndTime() As Nullable(Of Date)
		<Column("EMP_START_TIME_WED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property WednesdayStartTime() As Nullable(Of Date)
		<Column("EMP_END_TIME_WED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property WednesdayEndTime() As Nullable(Of Date)
		<Column("EMP_START_TIME_THU")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ThursdayStartTime() As Nullable(Of Date)
		<Column("EMP_END_TIME_THU")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ThursdayEndTime() As Nullable(Of Date)
		<Column("EMP_START_TIME_FRI")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FridayStartTime() As Nullable(Of Date)
		<Column("EMP_END_TIME_FRI")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FridayEndTime() As Nullable(Of Date)
		<Column("EMP_START_TIME_SAT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SaturdayStartTime() As Nullable(Of Date)
		<Column("EMP_END_TIME_SAT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SaturdayEndTime() As Nullable(Of Date)
		<Column("EMP_START_TIME_SUN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SundayStartTime() As Nullable(Of Date)
		<Column("EMP_END_TIME_SUN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SundayEndTime() As Nullable(Of Date)
		<MaxLength(256)>
		<Column("SIGNATURE_PATH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SignaturePath() As String
		<MaxLength(6)>
		<Column("EXP_RPT_APPROVER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlternateApproverCode() As String
		<Column("VAC_TIME_RULE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VacationTimeRule() As Nullable(Of Integer)
		<Column("PERS_TIME_RULE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PersonalTimeRule() As Nullable(Of Integer)
		<Column("SICK_TIME_RULE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SickTimeRule() As Nullable(Of Integer)
		<Column("TS_APPR_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TimesheetApprovalFlag() As Nullable(Of Boolean)
		<Required>
		<Column("IS_ACTIVE_FREELANCE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsActiveFreelance() As Boolean
		<MaxLength(100)>
		<Column("SUGAR_USERNAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SugarCRMUserName() As String
		<MaxLength(100)>
		<Column("SUGAR_PASSWORD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SugarCRMPassword() As String
		<MaxLength(100)>
		<Column("PROOFHQ_USERNAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProofHQUserName() As String
		<MaxLength(100)>
		<Column("PROOFHQ_PASSWORD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProofHQPassword() As String
		<Column("IS_API_USER", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsAPIUser() As String
		<Column("GOOGLE_TOKEN", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GoogleToken() As String
        <Column("ADOBE_SIGNATURE_FILE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdobeSignatureFile() As Byte()
        <MaxLength(100)>
        <Column("ADOBE_SIGNATURE_FILE_PASSWORD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdobeSignatureFilePassword() As String
        <MaxLength(100)>
        <Column("VCC_USERNAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VCCUserName() As String
        <MaxLength(100)>
        <Column("VCC_PASSWORD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VCCPassword() As String
        <Column("EMP_OMIT_MISSING")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OmitFromMissingTimeTracking() As Nullable(Of Short)
		<Required>
		<Column("IGNORE_CALENDAR_SYNC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IgnoreCalendarSync() As Boolean
        <Column("TIME_ZONE_ID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TimeZoneID() As String
        <Column("CS_USERID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareUserID() As Nullable(Of Integer)
        <Column("CS_PASSWORD", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptSharePassword() As String
        <Column("CAL_TIME_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CalendarTimeType() As Nullable(Of Short)
        <Column("CAL_TIME_EMAIL", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CalendarTimeEmailAddress() As String
        <Column("CAL_TIME_USERNAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CalendarTimeUserName() As String
        <Column("CAL_TIME_PASSWORD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CalendarTimePassword() As String
        <Column("CAL_TIME_HOST", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CalendarTimeHost() As String
        <Column("CAL_TIME_PORT", TypeName:="int")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CalendarTimePort() As Nullable(Of Integer)
        <Column("CAL_TIME_SSL", TypeName:="bit")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CalendarTimeSSL() As Nullable(Of Boolean)

        Public Overridable Property BillingRateDetails As ICollection(Of Database.Entities.BillingRateDetail)
        Public Overridable Property EmployeeTimeForecastOfficeDetailEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailEmployee)
        Public Overridable Property EmployeeDepartments As ICollection(Of Database.Entities.EmployeeDepartment)
        Public Overridable Property DepartmentTeam As Database.Entities.DepartmentTeam
        Public Overridable Property Office As Database.Entities.Office
        Public Overridable Property JobComponentTasks As ICollection(Of Database.Entities.JobComponentTask)
        Public Overridable Property EmployeeOffices As ICollection(Of Database.Entities.EmployeeOffice)
        Public Overridable Property AccountExecutives As ICollection(Of Database.Entities.AccountExecutive)
        Public Overridable Property EmployeePictures As ICollection(Of Database.Entities.EmployeePicture)
        Public Overridable Property Role As Database.Entities.Role
        Public Overridable Property [Function] As Database.Entities.Function
        Public Overridable Property EmployeeRateHistories As ICollection(Of Database.Entities.EmployeeRateHistory)
        Public Overridable Property EmployeeTitle As Database.Entities.EmployeeTitle

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            If Me.MiddleInitial IsNot Nothing AndAlso Me.MiddleInitial.Trim <> "" Then

                ToString = Me.FirstName & " " & Me.MiddleInitial & ". " & Me.LastName

            Else

                ToString = Me.FirstName & " " & Me.LastName

            End If

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim PropertyValue As Object = Nothing
            Dim ErrorText As String = Nothing

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Views.Employee.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Employees
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique employee code."

                        End If

                    End If

                Case AdvantageFramework.Database.Views.Employee.Properties.BillRate.ToString

                    If Value IsNot Nothing Then

                        Me.BillRate = Value

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Sub AllowEmptyDepartmentTeam()

            SetRequired(AdvantageFramework.Database.Views.Employee.Properties.DepartmentTeamCode.ToString, False)

        End Sub

#End Region

    End Class

End Namespace
