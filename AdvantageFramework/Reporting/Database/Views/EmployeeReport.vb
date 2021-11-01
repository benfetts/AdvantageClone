Namespace Reporting.Database.Views

    <Serializable>
    <Table("V_DRPT_EMPLOYEES")>
    Public Class EmployeeReport
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            FirstName
            MiddleInitial
            LastName
            Title
            Freelance
            ActiveFreelance
            OfficeCode
            OfficeName
            AccountNumber
            HomePhone
            WorkPhone
            WorkPhoneExtension
            CellPhone
            AlternatePhone
            Address
            Address2
            City
            County
            State
            Zip
            Country
            PayToAddress
            PayToAddress2
            PayToCity
            PayToCounty
            PayToState
            PayToZip
            PayToCountry
            SupervisorEmployeeCode
            Supervisor
            WeeklyTimeType
            TimeAlert
            Status
            FunctionCode
            Seniority
            WorkDays
            StandardWorkHours
            MondayHours
            MondayStartTime
            MondayEndTime
            TuesdayHours
            TuesdayStartTime
            TuesdayEndTime
            WednesdayHours
            WednesdayStartTime
            WednesdayEndTime
            ThursdayHours
            ThursdayStartTime
            ThursdayEndTime
            FridayHours
            FridayStartTime
            FridayEndTime
            SaturdayHours
            SaturdayStartTime
            SaturdayEndTime
            SundayHours
            SundayStartTime
            SundayEndTime
            AnnualHours
            MonthHoursGoal
            DirectHours
            VacationDateFrom
            VacationDateTo
            VacationHours
            VacationTimeRule
            SickDateFrom
            SickDateTo
            SickHours
            SickTimeRule
            PersonalHoursDateFrom
            PersonalHoursDateTo
            PersonalHours
            PersonalTimeRule
            PurchaseOrderLimit
            PurchaseOrderApprovalRuleCode
            AllowPOGLSelection
            LimitPOGLSelectionOffice
            SupervisorApprovalRequired
            AlternateApproverCode
            AlternateApprover
            EmployeeVendorCode
            CreditCardNumber
            CreditCardGLAccount
            CreditCardDescription
            EmploymentDate
            BirthDate
            LastIncrease
            NextReview
            TerminationDate
            AnnualSalary
            MonthlySalary
            BillRate
            CostRate
            OtherInfo
            ReceivesAlerts
            ReceivesEmail
            Email
            ReplyToEmail
            EmailUserName
            'EmailPassword
            Notes
            DepartmentTeamCode
            RoleCode
            Role
            IsAPIUser
            IsWVOnlyUser
            IsMediaToolsUser
            IsActiveForConceptShare
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Guid
        <Required>
        <MaxLength(6)>
        <Column("Code", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Code() As String
        <MaxLength(30)>
        <Column("FirstName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FirstName() As String
        <MaxLength(1)>
        <Column("MiddleInitial", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MiddleInitial() As String
        <MaxLength(30)>
        <Column("LastName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastName() As String
        <MaxLength(50)>
        <Column("Title", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Title() As String
        <Required>
        <MaxLength(1)>
        <Column("Freelance", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Freelance() As String
        <Required>
        <MaxLength(1)>
        <Column("ActiveFreelance", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ActiveFreelance() As String
        <MaxLength(4)>
        <Column("OfficeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        <Column("OfficeName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeName() As String
        <MaxLength(30)>
        <Column("AccountNumber", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountNumber() As String
        <MaxLength(13)>
        <Column("HomePhone", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property HomePhone() As String
        <MaxLength(13)>
        <Column("WorkPhone", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WorkPhone() As String
        <MaxLength(10)>
        <Column("WorkPhoneExtension", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WorkPhoneExtension() As String
        <MaxLength(13)>
        <Column("CellPhone", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CellPhone() As String
        <MaxLength(13)>
        <Column("AlternatePhone", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlternatePhone() As String
        <MaxLength(30)>
        <Column("Address", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Home Address")>
        Public Property Address() As String
        <MaxLength(30)>
        <Column("Address2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Home Address2")>
        Public Property Address2() As String
        <MaxLength(20)>
        <Column("City", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Home City")>
        Public Property City() As String
        <MaxLength(20)>
        <Column("County", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Home County")>
        Public Property County() As String
        <MaxLength(10)>
        <Column("State", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Home State")>
        Public Property State() As String
        <MaxLength(10)>
        <Column("Zip", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Home Zip")>
        Public Property Zip() As String
        <MaxLength(20)>
        <Column("Country", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Home Country")>
        Public Property Country() As String
        <MaxLength(30)>
        <Column("PayToAddress", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Mailing Address")>
        Public Property PayToAddress() As String
        <MaxLength(30)>
        <Column("PayToAddress2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Mailing Address2")>
        Public Property PayToAddress2() As String
        <MaxLength(20)>
        <Column("PayToCity", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Mailing City")>
        Public Property PayToCity() As String
        <MaxLength(20)>
        <Column("PayToCounty", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Mailing County")>
        Public Property PayToCounty() As String
        <MaxLength(10)>
        <Column("PayToState", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Mailing State")>
        Public Property PayToState() As String
        <MaxLength(10)>
        <Column("PayToZip", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Mailing Zip")>
        Public Property PayToZip() As String
        <MaxLength(20)>
        <Column("PayToCountry", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Mailing Country")>
        Public Property PayToCountry() As String
        <MaxLength(6)>
        <Column("SupervisorEmployeeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SupervisorEmployeeCode() As String
        <MaxLength(64)>
        <Column("Supervisor", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Supervisor() As String
        <Required>
        <MaxLength(16)>
        <Column("WeeklyTimeType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WeeklyTimeType() As String
        <Required>
        <MaxLength(1)>
        <Column("TimeAlert", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TimeAlert() As String
        <Required>
        <MaxLength(10)>
        <Column("Status", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Status() As String
        <MaxLength(6)>
        <Column("FunctionCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
        <Column("Seniority")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Seniority() As Nullable(Of Short)
        <MaxLength(30)>
        <Column("WorkDays", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WorkDays() As String
        <Column("StandardWorkHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StandardWorkHours() As Nullable(Of Decimal)
        <Column("MondayHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MondayHours() As Nullable(Of Decimal)
        <MaxLength(7)>
        <Column("MondayStartTime", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MondayStartTime() As String
        <MaxLength(7)>
        <Column("MondayEndTime", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MondayEndTime() As String
        <Column("TuesdayHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TuesdayHours() As Nullable(Of Decimal)
        <MaxLength(7)>
        <Column("TuesdayStartTime", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TuesdayStartTime() As String
        <MaxLength(7)>
        <Column("TuesdayEndTime", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TuesdayEndTime() As String
        <Column("WednesdayHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WednesdayHours() As Nullable(Of Decimal)
        <MaxLength(7)>
        <Column("WednesdayStartTime", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WednesdayStartTime() As String
        <MaxLength(7)>
        <Column("WednesdayEndTime", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WednesdayEndTime() As String
        <Column("ThursdayHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ThursdayHours() As Nullable(Of Decimal)
        <MaxLength(7)>
        <Column("ThursdayStartTime", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ThursdayStartTime() As String
        <MaxLength(7)>
        <Column("ThursdayEndTime", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ThursdayEndTime() As String
        <Column("FridayHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FridayHours() As Nullable(Of Decimal)
        <MaxLength(7)>
        <Column("FridayStartTime", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FridayStartTime() As String
        <MaxLength(7)>
        <Column("FridayEndTime", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FridayEndTime() As String
        <Column("SaturdayHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SaturdayHours() As Nullable(Of Decimal)
        <MaxLength(7)>
        <Column("SaturdayStartTime", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SaturdayStartTime() As String
        <MaxLength(7)>
        <Column("SaturdayEndTime", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SaturdayEndTime() As String
        <Column("SundayHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SundayHours() As Nullable(Of Decimal)
        <MaxLength(7)>
        <Column("SundayStartTime", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SundayStartTime() As String
        <MaxLength(7)>
        <Column("SundayEndTime", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SundayEndTime() As String
        <Column("AnnualHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AnnualHours() As Nullable(Of Decimal)
        <Column("MonthHoursGoal")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MonthHoursGoal() As Nullable(Of Decimal)
        <Column("DirectHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DirectHours() As Nullable(Of Decimal)
        <Column("VacationDateFrom")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VacationDateFrom() As Nullable(Of Date)
        <Column("VacationDateTo")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VacationDateTo() As Nullable(Of Date)
        <Column("VacationHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VacationHours() As Nullable(Of Decimal)
        <MaxLength(40)>
        <Column("VacationTimeRule", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VacationTimeRule() As String
        <Column("SickDateFrom")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SickDateFrom() As Nullable(Of Date)
        <Column("SickDateTo")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SickDateTo() As Nullable(Of Date)
        <Column("SickHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SickHours() As Nullable(Of Decimal)
        <MaxLength(40)>
        <Column("SickTimeRule", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SickTimeRule() As String
        <Column("PersonalHoursDateFrom")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PersonalHoursDateFrom() As Nullable(Of Date)
        <Column("PersonalHoursDateTo")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PersonalHoursDateTo() As Nullable(Of Date)
        <Column("PersonalHours")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PersonalHours() As Nullable(Of Decimal)
        <MaxLength(40)>
        <Column("PersonalTimeRule", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PersonalTimeRule() As String
        <Column("PurchaseOrderLimit")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PurchaseOrderLimit() As Nullable(Of Decimal)
        <MaxLength(6)>
        <Column("PurchaseOrderApprovalRuleCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PurchaseOrderApprovalRuleCode() As String
        <Required>
        <MaxLength(1)>
        <Column("AllowPOGLSelection", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AllowPOGLSelection() As String
        <Required>
        <MaxLength(1)>
        <Column("LimitPOGLSelectionOffice", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LimitPOGLSelectionOffice() As String
        <Required>
        <MaxLength(1)>
        <Column("SupervisorApprovalRequired", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SupervisorApprovalRequired() As String
        <MaxLength(6)>
        <Column("AlternateApproverCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlternateApproverCode() As String
        <MaxLength(64)>
        <Column("AlternateApprover", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlternateApprover() As String
        <MaxLength(6)>
        <Column("EmployeeVendorCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeVendorCode() As String
        <MaxLength(30)>
        <Column("CreditCardNumber", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreditCardNumber() As String
        <MaxLength(30)>
        <Column("CreditCardGLAccount", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreditCardGLAccount() As String
        <MaxLength(40)>
        <Column("CreditCardDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreditCardDescription() As String
        <Column("EmploymentDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmploymentDate() As Nullable(Of Date)
        <Column("BirthDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BirthDate() As Nullable(Of Date)
        <Column("LastIncrease")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastIncrease() As Nullable(Of Date)
        <Column("NextReview")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NextReview() As Nullable(Of Date)
        <Column("TerminationDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TerminationDate() As Nullable(Of Date)
        <Column("AnnualSalary")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AnnualSalary() As Nullable(Of Decimal)
        <Column("MonthlySalary")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MonthlySalary() As Nullable(Of Decimal)
        <Column("BillRate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillRate() As Nullable(Of Decimal)
        <Column("CostRate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CostRate() As Nullable(Of Decimal)
        <MaxLength(20)>
        <Column("OtherInfo", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OtherInfo() As String
        <Required>
        <MaxLength(1)>
        <Column("ReceivesAlerts", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReceivesAlerts() As String
        <Required>
        <MaxLength(1)>
        <Column("ReceivesEmail", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReceivesEmail() As String
        <MaxLength(50)>
        <Column("Email", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Email() As String
        <MaxLength(50)>
        <Column("ReplyToEmail", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReplyToEmail() As String
        <MaxLength(50)>
        <Column("EmailUserName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmailUserName() As String
        '      <MaxLength(50)>
        '      <Column("EmailPassword", TypeName:="varchar")>
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        'Public Property EmailPassword() As String
        <Column("Notes")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Notes() As String
        <MaxLength(4)>
        <Column("DepartmentTeamCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DepartmentTeamCode() As String
        <MaxLength(6)>
        <Column("RoleCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RoleCode() As String
        <MaxLength(40)>
        <Column("Role", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Role() As String
        <MaxLength(1)>
        <Column("IsAPIUser", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsAPIUser() As String
        <MaxLength(1)>
        <Column("IsWVOnlyUser", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsWVOnlyUser() As String
        <MaxLength(1)>
        <Column("IsMediaToolsUser", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsMediaToolsUser() As String
        <MaxLength(1)>
        <Column("IsActiveForConceptShare", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsActiveForConceptShare() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
