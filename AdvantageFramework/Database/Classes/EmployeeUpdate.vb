Namespace Database.Classes

    <Serializable()>
    Public Class EmployeeUpdate

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            FirstName
            MiddleInitial
            LastName
            EmailAddress
            HomeAddress1
            HomeAddress2
            HomeCity
            HomeCountry
            HomeCounty
            HomeState
            HomeZip
            HomePhone
            WorkPhone
            Ext
            CellPhone
            AlternatePhone
            Title
            BirthDate
            EmployeeTitle
            Freelance
            DefaultFunction
            AssignedOffice
            DefaultDepartmentTeam
            Supervisor
            DefaultRole
            AccountNumber
            MailingAddress1
            MailingAddress2
            MailingCity
            MailingCountry
            MailingCounty
            MailingState
            MailingZip
            EmploymentDate
            DateOfLastIncrease
            DateOfNextReview
            TerminationDate
            AnnualSalary
            MonthlySalary
            StandardAnnualHours
            MonthlyBillableHoursGoal
            DirectHoursPercentGoal
            Status
            HourlyBillRate
            HourlyCostRate
            VendorCodeCrossReference
            CreditCardNumber
            CreditCardDescription
            CreditCardGLAccountDefault
            OtherInfo
            VacationHoursAllowed
            VacationFromDate
            VacationToDate
            SickHoursAllowed
            SickFromDate
            SickToDate
            PersonalHours
            PersonalFromDate
            PersonalToDate
            POAmountLimit
            POApprovalRule
            SupervisorApprovedRequired
            AlternateApproverCode
            MissingTimeAlert
            ReportMissingTime
            ReceivesEmail
            ReceivesAlerts
            Seniority
            AllowPOGLSelection
            LimitPOGLSelectionToOffice
            Notes
            BillableHoursGoal
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = Nothing
        Private _FirstName As String = Nothing
        Private _MiddleInitial As String = Nothing
        Private _LastName As String = Nothing
        Private _EmailAddress As String = Nothing
        Private _HomeAddress1 As String = Nothing
        Private _HomeAddress2 As String = Nothing
        Private _HomeCity As String = Nothing
        Private _HomeCountry As String = Nothing
        Private _HomeCounty As String = Nothing
        Private _HomeState As String = Nothing
        Private _HomeZip As String = Nothing
        Private _HomePhone As String = Nothing
        Private _WorkPhone As String = Nothing
        Private _Ext As String = Nothing
        Private _CellPhone As String = Nothing
        Private _AlternatePhone As String = Nothing
        Private _Title As String = Nothing
        Private _BirthDate As Nullable(Of Date) = Nothing
        Private _EmployeeTitle As Nullable(Of Integer) = Nothing
        Private _Freelance As Nullable(Of Short) = Nothing
        Private _DefaultFunction As String = Nothing
        Private _AssignedOffice As String = Nothing
        Private _DefaultDepartmentTeam As String = Nothing
        Private _Supervisor As String = Nothing
        Private _DefaultRole As String = Nothing
        Private _AccountNumber As String = Nothing
        Private _MailingAddress1 As String = Nothing
        Private _MailingAddress2 As String = Nothing
        Private _MailingCity As String = Nothing
        Private _MailingCountry As String = Nothing
        Private _MailingCounty As String = Nothing
        Private _MailingState As String = Nothing
        Private _MailingZip As String = Nothing
        Private _EmploymentDate As Nullable(Of Date) = Nothing
        Private _DateOfLastIncrease As Nullable(Of Date) = Nothing
        Private _DateOfNextReview As Nullable(Of Date) = Nothing
        Private _TerminationDate As Nullable(Of Date) = Nothing
        Private _AnnualSalary As Nullable(Of Decimal) = Nothing
        Private _CreditCardNumber As String = Nothing
        Private _CreditCardDescription As String = Nothing
        Private _CreditCardGLAccountDefault As String = Nothing
        Private _OtherInfo As String = Nothing
        Private _VacationHoursAllowed As Nullable(Of Decimal) = Nothing
        Private _VacationFromDate As Nullable(Of Date) = Nothing
        Private _VacationToDate As Nullable(Of Date) = Nothing
        Private _SickHoursAllowed As Nullable(Of Decimal) = Nothing
        Private _SickFromDate As Nullable(Of Date) = Nothing
        Private _SickToDate As Nullable(Of Date) = Nothing
        Private _PersonalHours As Nullable(Of Decimal) = Nothing
        Private _PersonalFromDate As Nullable(Of Date) = Nothing
        Private _PersonalToDate As Nullable(Of Date) = Nothing
        Private _POAmountLimit As Nullable(Of Decimal) = Nothing
        Private _POApprovalRule As String = Nothing
        Private _SupervisorApprovedRequired As Nullable(Of Short) = Nothing
        Private _AlternateApproverCode As String = Nothing
        Private _HourlyBillRate As Nullable(Of Decimal) = Nothing
        Private _HourlyCostRate As Nullable(Of Decimal) = Nothing
        Private _DirectHoursPercentGoal As Nullable(Of Decimal) = Nothing
        Private _MonthlySalary As Nullable(Of Decimal) = Nothing
        Private _StandardAnnualHours As Nullable(Of Decimal) = Nothing
        Private _MonthlyBillableHoursGoal As Nullable(Of Decimal) = Nothing
        Private _Status As Nullable(Of Short) = Nothing
        Private _VendorCodeCrossReference As String = Nothing
        Private _MissingTimeAlert As Nullable(Of Short) = Nothing
        Private _ReportMissingTime As Nullable(Of Short) = Nothing
        Private _ReceivesEmail As Short = Nothing
        Private _ReceivesAlerts As Short = Nothing
        Private _Seniority As Nullable(Of Short) = Nothing
        Private _AllowPOGLSelection As Nullable(Of Short) = Nothing
        Private _LimitPOGLSelectionToOffice As Nullable(Of Short) = Nothing
        Private _Notes As String = Nothing
        Private _BillableHoursPercentGoal As Nullable(Of Decimal) = Nothing
        Private _Employee As AdvantageFramework.Database.Views.Employee = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Employee() As AdvantageFramework.Database.Views.Employee
            Get
                Employee = _Employee
            End Get
            Set(ByVal value As AdvantageFramework.Database.Views.Employee)
                _Employee = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property Code() As String
            Get
                Code = _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property FirstName() As String
            Get
                FirstName = _FirstName
            End Get
            Set(ByVal value As String)
                _FirstName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property MiddleInitial() As String
            Get
                MiddleInitial = _MiddleInitial
            End Get
            Set(ByVal value As String)
                _MiddleInitial = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property LastName() As String
            Get
                LastName = _LastName
            End Get
            Set(ByVal value As String)
                _LastName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property EmailAddress As String
            Get
                EmailAddress = _EmailAddress
            End Get
            Set(value As String)
                _EmailAddress = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property HomeAddress1 As String
            Get
                HomeAddress1 = _HomeAddress1
            End Get
            Set(value As String)
                _HomeAddress1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property HomeAddress2 As String
            Get
                HomeAddress2 = _HomeAddress2
            End Get
            Set(value As String)
                _HomeAddress2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property HomeCity As String
            Get
                HomeCity = _HomeCity
            End Get
            Set(value As String)
                _HomeCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property HomeCountry As String
            Get
                HomeCountry = _HomeCountry
            End Get
            Set(value As String)
                _HomeCountry = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property HomeCounty As String
            Get
                HomeCounty = _HomeCounty
            End Get
            Set(value As String)
                _HomeCounty = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property HomeState As String
            Get
                HomeState = _HomeState
            End Get
            Set(value As String)
                _HomeState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property HomeZip As String
            Get
                HomeZip = _HomeZip
            End Get
            Set(value As String)
                _HomeZip = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property HomePhone As String
            Get
                HomePhone = _HomePhone
            End Get
            Set(value As String)
                _HomePhone = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property WorkPhone As String
            Get
                WorkPhone = _WorkPhone
            End Get
            Set(value As String)
                _WorkPhone = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property Ext As String
            Get
                Ext = _Ext
            End Get
            Set(value As String)
                _Ext = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property CellPhone As String
            Get
                CellPhone = _CellPhone
            End Get
            Set(value As String)
                _CellPhone = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property AlternatePhone As String
            Get
                AlternatePhone = _AlternatePhone
            End Get
            Set(value As String)
                _AlternatePhone = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property Title As String
            Get
                Title = _Title
            End Get
            Set(value As String)
                _Title = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True)>
        Public Property BirthDate As Nullable(Of Date)
            Get
                BirthDate = _BirthDate
            End Get
            Set(value As Nullable(Of Date))
                _BirthDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeTitle As Nullable(Of Integer)
            Get
                EmployeeTitle = _EmployeeTitle
            End Get
            Set(value As Nullable(Of Integer))
                _EmployeeTitle = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Freelance As Nullable(Of Short)
            Get
                Freelance = _Freelance
            End Get
            Set(value As Nullable(Of Short))
                _Freelance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DefaultFunction As String
            Get
                DefaultFunction = _DefaultFunction
            End Get
            Set(value As String)
                _DefaultFunction = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AssignedOffice As String
            Get
                AssignedOffice = _AssignedOffice
            End Get
            Set(value As String)
                _AssignedOffice = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DefaultDepartmentTeam As String
            Get
                DefaultDepartmentTeam = _DefaultDepartmentTeam
            End Get
            Set(value As String)
                _DefaultDepartmentTeam = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Supervisor As String
            Get
                Supervisor = _Supervisor
            End Get
            Set(value As String)
                _Supervisor = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DefaultRole As String
            Get
                DefaultRole = _DefaultRole
            End Get
            Set(value As String)
                _DefaultRole = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AccountNumber As String
            Get
                AccountNumber = _AccountNumber
            End Get
            Set(value As String)
                _AccountNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MailingAddress1 As String
            Get
                MailingAddress1 = _MailingAddress1
            End Get
            Set(value As String)
                _MailingAddress1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MailingAddress2 As String
            Get
                MailingAddress2 = _MailingAddress2
            End Get
            Set(value As String)
                _MailingAddress2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MailingCity As String
            Get
                MailingCity = _MailingCity
            End Get
            Set(value As String)
                _MailingCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MailingCountry As String
            Get
                MailingCountry = _MailingCountry
            End Get
            Set(value As String)
                _MailingCountry = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MailingCounty As String
            Get
                MailingCounty = _MailingCounty
            End Get
            Set(value As String)
                _MailingCounty = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MailingState As String
            Get
                MailingState = _MailingState
            End Get
            Set(value As String)
                _MailingState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MailingZip As String
            Get
                MailingZip = _MailingZip
            End Get
            Set(value As String)
                _MailingZip = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmploymentDate As Nullable(Of Date)
            Get
                EmploymentDate = _EmploymentDate
            End Get
            Set(value As Nullable(Of Date))
                _EmploymentDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DateOfLastIncrease As Nullable(Of Date)
            Get
                DateOfLastIncrease = _DateOfLastIncrease
            End Get
            Set(value As Nullable(Of Date))
                _DateOfLastIncrease = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DateOfNextReview As Nullable(Of Date)
            Get
                DateOfNextReview = _DateOfNextReview
            End Get
            Set(value As Nullable(Of Date))
                _DateOfNextReview = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TerminationDate As Nullable(Of Date)
            Get
                TerminationDate = _TerminationDate
            End Get
            Set(value As Nullable(Of Date))
                _TerminationDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AnnualSalary As Nullable(Of Decimal)
            Get
                AnnualSalary = _AnnualSalary
            End Get
            Set(value As Nullable(Of Decimal))
                _AnnualSalary = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MonthlySalary As Nullable(Of Decimal)
            Get
                MonthlySalary = _MonthlySalary
            End Get
            Set(value As Nullable(Of Decimal))
                _MonthlySalary = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property StandardAnnualHours As Nullable(Of Decimal)
            Get
                StandardAnnualHours = _StandardAnnualHours
            End Get
            Set(value As Nullable(Of Decimal))
                _StandardAnnualHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MonthlyBillableHoursGoal As Nullable(Of Decimal)
            Get
                MonthlyBillableHoursGoal = _MonthlyBillableHoursGoal
            End Get
            Set(value As Nullable(Of Decimal))
                _MonthlyBillableHoursGoal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DirectHoursPercentGoal As Nullable(Of Decimal)
            Get
                DirectHoursPercentGoal = _DirectHoursPercentGoal
            End Get
            Set(value As Nullable(Of Decimal))
                _DirectHoursPercentGoal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Status As Nullable(Of Short)
            Get
                Status = _Status
            End Get
            Set(value As Nullable(Of Short))
                _Status = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HourlyBillRate As Nullable(Of Decimal)
            Get
                HourlyBillRate = _HourlyBillRate
            End Get
            Set(value As Nullable(Of Decimal))
                _HourlyBillRate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HourlyCostRate As Nullable(Of Decimal)
            Get
                HourlyCostRate = _HourlyCostRate
            End Get
            Set(value As Nullable(Of Decimal))
                _HourlyCostRate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorCodeCrossReference As String
            Get
                VendorCodeCrossReference = _VendorCodeCrossReference
            End Get
            Set(value As String)
                _VendorCodeCrossReference = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CreditCardNumber As String
            Get
                CreditCardNumber = _CreditCardNumber
            End Get
            Set(value As String)
                _CreditCardNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CreditCardDescription As String
            Get
                CreditCardDescription = _CreditCardDescription
            End Get
            Set(value As String)
                _CreditCardDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CreditCardGLAccountDefault As String
            Get
                CreditCardGLAccountDefault = _CreditCardGLAccountDefault
            End Get
            Set(value As String)
                _CreditCardGLAccountDefault = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property OtherInfo As String
            Get
                OtherInfo = _OtherInfo
            End Get
            Set(value As String)
                _OtherInfo = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VacationHoursAllowed As Nullable(Of Decimal)
            Get
                VacationHoursAllowed = _VacationHoursAllowed
            End Get
            Set(value As Nullable(Of Decimal))
                _VacationHoursAllowed = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VacationFromDate As Nullable(Of Date)
            Get
                VacationFromDate = _VacationFromDate
            End Get
            Set(value As Nullable(Of Date))
                _VacationFromDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VacationToDate As Nullable(Of Date)
            Get
                VacationToDate = _VacationToDate
            End Get
            Set(value As Nullable(Of Date))
                _VacationToDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SickHoursAllowed As Nullable(Of Decimal)
            Get
                SickHoursAllowed = _SickHoursAllowed
            End Get
            Set(value As Nullable(Of Decimal))
                _SickHoursAllowed = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SickFromDate As Nullable(Of Date)
            Get
                SickFromDate = _SickFromDate
            End Get
            Set(value As Nullable(Of Date))
                _SickFromDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SickToDate As Nullable(Of Date)
            Get
                SickToDate = _SickToDate
            End Get
            Set(value As Nullable(Of Date))
                _SickToDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property PersonalHours As Nullable(Of Decimal)
            Get
                PersonalHours = _PersonalHours
            End Get
            Set(value As Nullable(Of Decimal))
                _PersonalHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property PersonalFromDate As Nullable(Of Date)
            Get
                PersonalFromDate = _PersonalFromDate
            End Get
            Set(value As Nullable(Of Date))
                _PersonalFromDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property PersonalToDate As Nullable(Of Date)
            Get
                PersonalToDate = _PersonalToDate
            End Get
            Set(value As Nullable(Of Date))
                _PersonalToDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property POAmountLimit As Nullable(Of Decimal)
            Get
                POAmountLimit = _POAmountLimit
            End Get
            Set(value As Nullable(Of Decimal))
                _POAmountLimit = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property POApprovalRule As String
            Get
                POApprovalRule = _POApprovalRule
            End Get
            Set(value As String)
                _POApprovalRule = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SupervisorApprovedRequired As Nullable(Of Short)
            Get
                SupervisorApprovedRequired = _SupervisorApprovedRequired
            End Get
            Set(value As Nullable(Of Short))
                _SupervisorApprovedRequired = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AlternateApproverCode As String
            Get
                AlternateApproverCode = _AlternateApproverCode
            End Get
            Set(value As String)
                _AlternateApproverCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MissingTimeAlert As Nullable(Of Short)
            Get
                MissingTimeAlert = _MissingTimeAlert
            End Get
            Set(value As Nullable(Of Short))
                _MissingTimeAlert = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ReportMissingTime As Nullable(Of Short)
            Get
                ReportMissingTime = _ReportMissingTime
            End Get
            Set(value As Nullable(Of Short))
                _ReportMissingTime = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ReceivesEmail As Short
            Get
                ReceivesEmail = _ReceivesEmail
            End Get
            Set(value As Short)
                _ReceivesEmail = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ReceivesAlerts As Short
            Get
                ReceivesAlerts = _ReceivesAlerts
            End Get
            Set(value As Short)
                _ReceivesAlerts = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Seniority As Nullable(Of Short)
            Get
                Seniority = _Seniority
            End Get
            Set(value As Nullable(Of Short))
                _Seniority = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AllowPOGLSelection As Nullable(Of Short)
            Get
                AllowPOGLSelection = _AllowPOGLSelection
            End Get
            Set(value As Nullable(Of Short))
                _AllowPOGLSelection = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property LimitPOGLSelectionToOffice As Nullable(Of Short)
            Get
                LimitPOGLSelectionToOffice = _LimitPOGLSelectionToOffice
            End Get
            Set(value As Nullable(Of Short))
                _LimitPOGLSelectionToOffice = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Notes As String
            Get
                Notes = _Notes
            End Get
            Set(value As String)
                _Notes = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BillableHoursPercentGoal As Nullable(Of Decimal)
            Get
                BillableHoursPercentGoal = _BillableHoursPercentGoal
            End Get
            Set(value As Nullable(Of Decimal))
                _BillableHoursPercentGoal = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            _Employee = Employee

            _Code = Employee.Code
            _FirstName = Employee.FirstName
            _MiddleInitial = Employee.MiddleInitial
            _LastName = Employee.LastName
            _Title = Employee.Title

            _EmployeeTitle = Employee.EmployeeTitleID
            _Freelance = Employee.Freelance
            _DefaultFunction = Employee.FunctionCode
            _AssignedOffice = Employee.OfficeCode
            _DefaultDepartmentTeam = Employee.DepartmentTeamCode
            _Supervisor = Employee.SupervisorEmployeeCode
            _DefaultRole = Employee.RoleCode
            _AccountNumber = Employee.AccountNumber
            _HomePhone = Employee.PhoneNumber
            _WorkPhone = Employee.WorkPhoneNumber
            _Ext = Employee.WorkPhoneNumberExtension
            _CellPhone = Employee.CellPhoneNumber
            _AlternatePhone = Employee.AlternatePhoneNumber
            _HomeAddress1 = Employee.Address
            _HomeAddress2 = Employee.Address2
            _HomeCity = Employee.City
            _HomeCountry = Employee.Country
            _HomeCounty = Employee.County
            _HomeState = Employee.State
            _HomeZip = Employee.Zip
            _MailingAddress1 = Employee.PayToAddress
            _MailingAddress2 = Employee.PayToAddress2
            _MailingCity = Employee.PayToCity
            _MailingCountry = Employee.PayToCountry
            _MailingCounty = Employee.PayToCounty
            _MailingState = Employee.PayToState
            _MailingZip = Employee.PayToZip
            '----------------------------------
            _EmploymentDate = Employee.StartDate
            _BirthDate = Employee.BirthDate
            _DateOfLastIncrease = Employee.LastIncrease
            _DateOfNextReview = Employee.NextReview
            _TerminationDate = Employee.TerminationDate
            _AnnualSalary = Employee.AnnualSalary
            _MonthlySalary = Employee.MonthlySalary
            _StandardAnnualHours = Employee.AnnualHours
            _MonthlyBillableHoursGoal = Employee.MonthHoursGoal
            _DirectHoursPercentGoal = Employee.DirectHours
            _BillableHoursPercentGoal = Employee.BillableHoursGoal
            _Status = Employee.Status
            _HourlyBillRate = Employee.BillRate
            _HourlyCostRate = Employee.CostRate
            _VendorCodeCrossReference = Employee.EmployeeVendorCode
            _CreditCardNumber = Employee.CreditCardNumber
            _CreditCardDescription = Employee.CreditCardGLAccount
            _CreditCardGLAccountDefault = Employee.CreditCardGLAccount
            _OtherInfo = Employee.OtherInfo
            _VacationHoursAllowed = Employee.VacationHours
            _VacationFromDate = Employee.VacationDateFrom
            _VacationToDate = Employee.VacationDateTo
            _SickHoursAllowed = Employee.SickHours
            _SickFromDate = Employee.SickDateFrom
            _SickToDate = Employee.SickDateTo
            _PersonalHours = Employee.PersonalHours
            _PersonalFromDate = Employee.PersonalHoursDateFrom
            _PersonalToDate = Employee.PersonalHoursDateTo
            _POAmountLimit = Employee.PurchaseOrderLimit
            _POApprovalRule = Employee.PurchaseOrderApprovalRuleCode
            _SupervisorApprovedRequired = Employee.SupervisorApprovalRequired
            _AlternateApproverCode = Employee.SupervisorEmployeeCode
            '-----------------------------------------
            _EmailAddress = Employee.Email
            _MissingTimeAlert = Convert.ToBoolean(Employee.IsMissingTime.GetValueOrDefault(0))
            _ReportMissingTime = Employee.WeeklyTimeType

            Select Case Employee.AlertNotificationType

                Case 1, 3

                    _ReceivesEmail = 1
                    _ReceivesAlerts = 1

                Case 2

                    _ReceivesEmail = 0
                    _ReceivesAlerts = 1

                Case Else

                    _ReceivesEmail = 0
                    _ReceivesAlerts = 0

            End Select

            _Seniority = Employee.Seniority
            _AllowPOGLSelection = Employee.AllowPOGLSelection
            _LimitPOGLSelectionToOffice = Employee.LimitPOGLSelectionOffice
            '-----------------------------------------
            _Notes = Employee.Comments

        End Sub

#End Region

    End Class

End Namespace
