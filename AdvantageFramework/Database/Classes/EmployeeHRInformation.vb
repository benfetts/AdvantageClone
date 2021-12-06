Namespace Database.Classes

    <Serializable()>
    Public Class EmployeeHRInformation
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
            StartDate
            BirthDate
            LastIncrease
            NextReview
            TerminationDate
            AnnualSalary
            MonthlySalary
            AnnualHours
            MonthHoursGoal
            DirectHours
            Status
            BillRate
            CostRate
            EmployeeVendorCode
            CreditCardNumber
            CreditCardDescription
            CreditCardGLAccount
            OtherInfo
            VacationHours
            VacationDateFrom
            VacationDateTo
            SickHours
            SickDateFrom
            SickDateTo
            PersonalHours
            PersonalHoursDateFrom
            PersonalHoursDateTo
            PurchaseOrderLimit
            PurchaseOrderApprovalRuleCode
            SupervisorApprovalRequired
            AlternateApproverCode
            BillableHoursGoal
        End Enum

#End Region

#Region " Variables "

        Private _Employee As AdvantageFramework.Database.Views.Employee = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Overrides ReadOnly Property AttachedEntityType As System.Type
            Get
                AttachedEntityType = GetType(AdvantageFramework.Database.Views.Employee)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property Code() As String
            Get
                Code = _Employee.Code
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property Name() As String
            Get
                Name = _Employee.ToString
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Employment Date")>
        Public Property StartDate As Nullable(Of Date)
            Get
                StartDate = _Employee.StartDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _Employee.StartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property BirthDate As Nullable(Of Date)
            Get
                BirthDate = _Employee.BirthDate
            End Get
            Set(value As Nullable(Of Date))
                _Employee.BirthDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Date of Last Increase")>
        Public Property LastIncrease As Nullable(Of Date)
            Get
                LastIncrease = _Employee.LastIncrease
            End Get
            Set(value As Nullable(Of Date))
                _Employee.LastIncrease = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Next Review Date")>
        Public Property NextReview As Nullable(Of Date)
            Get
                NextReview = _Employee.NextReview
            End Get
            Set(value As Nullable(Of Date))
                _Employee.NextReview = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TerminationDate As Nullable(Of Date)
            Get
                TerminationDate = _Employee.TerminationDate
            End Get
            Set(value As Nullable(Of Date))
                _Employee.TerminationDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property AnnualSalary As Nullable(Of Decimal)
            Get
                AnnualSalary = _Employee.AnnualSalary
            End Get
            Set(value As Nullable(Of Decimal))
                _Employee.AnnualSalary = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property MonthlySalary As Nullable(Of Decimal)
            Get
                MonthlySalary = _Employee.MonthlySalary
            End Get
            Set(value As Nullable(Of Decimal))
                _Employee.MonthlySalary = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Standard Annual Hours")>
        Public Property AnnualHours As Nullable(Of Decimal)
            Get
                AnnualHours = _Employee.AnnualHours
            End Get
            Set(value As Nullable(Of Decimal))
                _Employee.AnnualHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Monthly Billable Hours Goal")>
        Public Property MonthHoursGoal As Nullable(Of Decimal)
            Get
                MonthHoursGoal = _Employee.MonthHoursGoal
            End Get
            Set(value As Nullable(Of Decimal))
                _Employee.MonthHoursGoal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Direct Hours Percent Goal")>
        Public Property DirectHours As Nullable(Of Decimal)
            Get
                DirectHours = _Employee.DirectHours
            End Get
            Set(value As Nullable(Of Decimal))
                _Employee.DirectHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property Status As Nullable(Of Short)
            Get
                Status = _Employee.Status
            End Get
            Set(value As Nullable(Of Short))
                _Employee.Status = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Hourly Bill Rate")>
        Public ReadOnly Property BillRate As Nullable(Of Decimal)
            Get
                BillRate = _Employee.BillRate
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Hourly Cost Rate")>
        Public Property CostRate As Nullable(Of Decimal)
            Get
                CostRate = _Employee.CostRate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Employee.CostRate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Vendor Code Cross Reference")>
        Public Property EmployeeVendorCode As String
            Get
                EmployeeVendorCode = _Employee.EmployeeVendorCode
            End Get
            Set(ByVal value As String)
                _Employee.EmployeeVendorCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property CreditCardNumber As String
            Get
                CreditCardNumber = _Employee.CreditCardNumber
            End Get
            Set(ByVal value As String)
                _Employee.CreditCardNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property CreditCardDescription As String
            Get
                CreditCardDescription = _Employee.CreditCardDescription
            End Get
            Set(ByVal value As String)
                _Employee.CreditCardDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Credit Card GL Account Default", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property CreditCardGLAccount As String
            Get
                CreditCardGLAccount = _Employee.CreditCardGLAccount
            End Get
            Set(ByVal value As String)
                _Employee.CreditCardGLAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property OtherInfo As String
            Get
                OtherInfo = _Employee.OtherInfo
            End Get
            Set(ByVal value As String)
                _Employee.OtherInfo = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Vacation Hours Allowed")>
        Public Property VacationHours As Nullable(Of Decimal)
            Get
                VacationHours = _Employee.VacationHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Employee.VacationHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Vacation From Date")>
        Public Property VacationDateFrom As Nullable(Of Date)
            Get
                VacationDateFrom = _Employee.VacationDateFrom
            End Get
            Set(ByVal value As Nullable(Of Date))
                _Employee.VacationDateFrom = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Vacation To Date")>
        Public Property VacationDateTo As Nullable(Of Date)
            Get
                VacationDateTo = _Employee.VacationDateTo
            End Get
            Set(ByVal value As Nullable(Of Date))
                _Employee.VacationDateTo = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Sick Hours Allowed")>
        Public Property SickHours As Nullable(Of Decimal)
            Get
                SickHours = _Employee.SickHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Employee.SickHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Sick From Date")>
        Public Property SickDateFrom As Nullable(Of Date)
            Get
                SickDateFrom = _Employee.SickDateFrom
            End Get
            Set(ByVal value As Nullable(Of Date))
                _Employee.SickDateFrom = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Sick To Date")>
        Public Property SickDateTo As Nullable(Of Date)
            Get
                SickDateTo = _Employee.SickDateTo
            End Get
            Set(ByVal value As Nullable(Of Date))
                _Employee.SickDateTo = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property PersonalHours As Nullable(Of Decimal)
            Get
                PersonalHours = _Employee.PersonalHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Employee.PersonalHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Personal From Date")>
        Public Property PersonalHoursDateFrom As Nullable(Of Date)
            Get
                PersonalHoursDateFrom = _Employee.PersonalHoursDateFrom
            End Get
            Set(ByVal value As Nullable(Of Date))
                _Employee.PersonalHoursDateFrom = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Personal To Date")>
        Public Property PersonalHoursDateTo As Nullable(Of Date)
            Get
                PersonalHoursDateTo = _Employee.PersonalHoursDateTo
            End Get
            Set(ByVal value As Nullable(Of Date))
                _Employee.PersonalHoursDateTo = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="PO Amount Limit")>
        Public Property PurchaseOrderLimit As Nullable(Of Decimal)
            Get
                PurchaseOrderLimit = _Employee.PurchaseOrderLimit
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Employee.PurchaseOrderLimit = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="PO Approval Rule", PropertyType:=BaseClasses.PropertyTypes.PurchaseOrderApprovalRuleCode)>
        Public Property PurchaseOrderApprovalRuleCode As String
            Get
                PurchaseOrderApprovalRuleCode = _Employee.PurchaseOrderApprovalRuleCode
            End Get
            Set(ByVal value As String)
                _Employee.PurchaseOrderApprovalRuleCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property SupervisorApprovalRequired As Nullable(Of Short)
            Get
                SupervisorApprovalRequired = _Employee.SupervisorApprovalRequired
            End Get
            Set(ByVal value As Nullable(Of Short))
                _Employee.SupervisorApprovalRequired = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, PropertyType:=BaseClasses.PropertyTypes.EmployeeCode, CustomColumnCaption:="Alternate Approver")>
        Public Property AlternateApproverCode As String
            Get
                AlternateApproverCode = _Employee.AlternateApproverCode
            End Get
            Set(ByVal value As String)
                _Employee.AlternateApproverCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Billable Hours Percent Goal")>
        Public Property BillableHoursGoal As Nullable(Of Decimal)
            Get
                BillableHoursGoal = _Employee.BillableHoursGoal
            End Get
            Set(value As Nullable(Of Decimal))
                _Employee.BillableHoursGoal = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            _Employee = Employee

        End Sub
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""

            ErrorText = _Employee.ValidateEntityProperty(PropertyName, IsValid, Value)

            _ErrorHashtable(PropertyName) = ErrorText

            ValidateEntityProperty = ErrorText

        End Function

#End Region

    End Class

End Namespace
