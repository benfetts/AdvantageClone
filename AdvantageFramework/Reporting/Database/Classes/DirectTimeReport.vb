Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class DirectTimeReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EmployeeCode
            Employee
            EmployeeFirstName
            EmployeeLastName
            EmployeeLastFirst
            EmployeeTitle
            EmployeeAccountNumber
            IsEmployeeFreelance
            IsActiveFreelance
            DirectHoursGoalPercent
            BillableHoursGoal
            DepartmentTeamCode
            DepartmentTeam
            SupervisorCode
            Supervisor
            ClientCode
            ClientDescription
            DivisionCode
            DivisionDescription
            ProductCode
            ProductDescription
            ProductCategoryCode
            ProductCategoryDescription
            SalesClassCode
            SalesClassDescription
            CampaignID
            CampaignCode
            CampaignName
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            JobComponent
            AccountExecutiveCode
            AccountExecutive
            JobTypeCode
            JobTypeDescription
            LabelFromUDFTable1
            LabelFromUDFTable2
            LabelFromUDFTable3
            LabelFromUDFTable4
            LabelFromUDFTable5
            FunctionCode
            FunctionDescription
            [Date]
            DateEntered
            StandardHours
            TotalHoursWorked
            ApprovalUserCode
            ApprovalDate
            PendingApproval
            Approved
            Hours
            Amount
            MarkupAmount
            ResaleTax
            TotalAmount
            TotalBilled
            TotalAmountWithTax
            TotalBilledWithTax
            NonBillable
            Billed
            FunctionHeadingDescription
            Comments
            EmployeeOfficeCode
            JobOfficeCode
            IsFeeTime
            DefaultRoleCode
            DefaultRole
            Type
            Status
            EmployeeRateFrom
            AdjustmentComments
            ARPostPeriod
            ARInvoiceNumber
            UserID
            AssignmentType
            TaskCode
            Assignment
            CmpBeginDate
            CmpEndDate
            FunctionConsolidationCode
            FunctionConsolidationDescription
            ClientPO
            Terminated
            TerminatedDate
        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of Integer) = Nothing
        Private _EmployeeCode As String = Nothing
        Private _Employee As String = Nothing
        Private _EmployeeFirstName As String = Nothing
        Private _EmployeeLastName As String = Nothing
        Private _EmployeeLastFirst As String = Nothing
        Private _EmployeeTitle As String = Nothing
        Private _EmployeeAccountNumber As String = Nothing
        Private _IsEmployeeFreelance As String = Nothing
        Private _IsActiveFreelance As String = Nothing
        Private _DirectHoursGoalPercent As Nullable(Of Decimal) = Nothing
        Private _BillableHoursGoal As Nullable(Of Decimal) = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _DepartmentTeam As String = Nothing
        Private _SupervisorCode As String = Nothing
        Private _Supervisor As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientDescription As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionDescription As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _ProductCategoryCode As String = Nothing
        Private _ProductCategoryDescription As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _JobComponent As String = Nothing
        Private _LabelFromUDFTable1 As String = Nothing
        Private _LabelFromUDFTable2 As String = Nothing
        Private _LabelFromUDFTable3 As String = Nothing
        Private _LabelFromUDFTable4 As String = Nothing
        Private _LabelFromUDFTable5 As String = Nothing
        Private _AccountExecutiveCode As String = Nothing
        Private _AccountExecutive As String = Nothing
        Private _JobTypeCode As String = Nothing
        Private _JobTypeDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _Date As Date = Nothing
        Private _DateEntered As Nullable(Of Date) = Nothing
        Private _StandardHours As Nullable(Of Decimal) = Nothing
        Private _TotalHoursWorked As Nullable(Of Decimal) = Nothing
        Private _ApprovalUserCode As String = Nothing
        Private _ApprovalDate As Nullable(Of Date) = Nothing
        Private _PendingApproval As String = Nothing
        Private _Approved As String = Nothing
        Private _Hours As Nullable(Of Decimal) = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing
        Private _MarkupAmount As Nullable(Of Decimal) = Nothing
        Private _ResaleTax As Nullable(Of Decimal) = Nothing
        Private _TotalAmount As Nullable(Of Decimal) = Nothing
        Private _TotalBilled As Nullable(Of Decimal) = Nothing
        Private _TotalAmountWithTax As Nullable(Of Decimal) = Nothing
        Private _TotalBilledWithTax As Nullable(Of Decimal) = Nothing
        Private _NonBillable As String = Nothing
        Private _Billed As String = Nothing
        Private _FunctionHeadingDescription As String = Nothing
        Private _Comments As String = Nothing
        Private _EmployeeOfficeCode As String = Nothing
        Private _JobOfficeCode As String = Nothing
        Private _IsFeeTime As String = Nothing
        Private _DefaultRoleCode As String = Nothing
        Private _DefaultRole As String = Nothing
        Private _Type As String = Nothing
        Private _Status As String = Nothing
        Private _EmployeeRateFrom As String = Nothing
        Private _AdjustmentComments As String = Nothing
        Private _ARPostPeriod As String = Nothing
        Private _ARInvoiceNumber As Nullable(Of Integer) = Nothing
        Private _UserID As String = Nothing
        Private _AssignmentType As String = Nothing
        Private _TaskCode As String = Nothing
        Private _Assignment As String = Nothing
        Private _CmpBeginDate As Nullable(Of Date) = Nothing
        Private _CmpEndDate As Nullable(Of Date) = Nothing
        Private _FunctionConsolidationCode As String = Nothing
        Private _FunctionConsolidationDescription As String = Nothing
        Private _ClientPO As String = Nothing
        Private _Terminated As String = Nothing
        Private _TerminatedDate As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of Integer)
            Get
                ID = _ID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(ByVal value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserID() As String
            Get
                UserID = _UserID
            End Get
            Set(value As String)
                _UserID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Employee() As String
            Get
                Employee = _Employee
            End Get
            Set(ByVal value As String)
                _Employee = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeFirstName() As String
            Get
                EmployeeFirstName = _EmployeeFirstName
            End Get
            Set(value As String)
                _EmployeeFirstName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeLastName() As String
            Get
                EmployeeLastName = _EmployeeLastName
            End Get
            Set(value As String)
                _EmployeeLastName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeLastFirst() As String
            Get
                EmployeeLastFirst = _EmployeeLastFirst
            End Get
            Set(value As String)
                _EmployeeLastFirst = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTitle() As String
            Get
                EmployeeTitle = _EmployeeTitle
            End Get
            Set(ByVal value As String)
                _EmployeeTitle = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeAccountNumber() As String
            Get
                EmployeeAccountNumber = _EmployeeAccountNumber
            End Get
            Set(value As String)
                _EmployeeAccountNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsEmployeeFreelance() As String
            Get
                IsEmployeeFreelance = _IsEmployeeFreelance
            End Get
            Set(ByVal value As String)
                _IsEmployeeFreelance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsActiveFreelance() As String
            Get
                IsActiveFreelance = _IsActiveFreelance
            End Get
            Set(value As String)
                _IsActiveFreelance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DirectHoursGoalPercent() As Nullable(Of Decimal)
            Get
                DirectHoursGoalPercent = _DirectHoursGoalPercent
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _DirectHoursGoalPercent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillableHoursGoal() As Nullable(Of Decimal)
            Get
                BillableHoursGoal = _BillableHoursGoal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BillableHoursGoal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DepartmentTeamCode() As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(ByVal value As String)
                _DepartmentTeamCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DepartmentTeam() As String
            Get
                DepartmentTeam = _DepartmentTeam
            End Get
            Set(ByVal value As String)
                _DepartmentTeam = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultRoleCode() As String
            Get
                DefaultRoleCode = _DefaultRoleCode
            End Get
            Set(ByVal value As String)
                _DefaultRoleCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DefaultRole() As String
            Get
                DefaultRole = _DefaultRole
            End Get
            Set(ByVal value As String)
                _DefaultRole = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SupervisorCode() As String
            Get
                SupervisorCode = _SupervisorCode
            End Get
            Set(ByVal value As String)
                _SupervisorCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Supervisor() As String
            Get
                Supervisor = _Supervisor
            End Get
            Set(ByVal value As String)
                _Supervisor = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientDescription() As String
            Get
                ClientDescription = _ClientDescription
            End Get
            Set(ByVal value As String)
                _ClientDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionDescription() As String
            Get
                DivisionDescription = _DivisionDescription
            End Get
            Set(ByVal value As String)
                _DivisionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(ByVal value As String)
                _ProductDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCategoryCode() As String
            Get
                ProductCategoryCode = _ProductCategoryCode
            End Get
            Set(ByVal value As String)
                _ProductCategoryCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCategoryDescription() As String
            Get
                ProductCategoryDescription = _ProductCategoryDescription
            End Get
            Set(ByVal value As String)
                _ProductCategoryDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(ByVal value As String)
                _SalesClassCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(ByVal value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(ByVal value As String)
                _CampaignCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(ByVal value As String)
                _CampaignName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Integer)
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Short)
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(ByVal value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
            Set(ByVal value As String)
                _JobComponent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutiveCode() As String
            Get
                AccountExecutiveCode = _AccountExecutiveCode
            End Get
            Set(ByVal value As String)
                _AccountExecutiveCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutive() As String
            Get
                AccountExecutive = _AccountExecutive
            End Get
            Set(ByVal value As String)
                _AccountExecutive = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobTypeCode() As String
            Get
                JobTypeCode = _JobTypeCode
            End Get
            Set(ByVal value As String)
                _JobTypeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobTypeDescription() As String
            Get
                JobTypeDescription = _JobTypeDescription
            End Get
            Set(ByVal value As String)
                _JobTypeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelFromUDFTable1() As String
            Get
                LabelFromUDFTable1 = _LabelFromUDFTable1
            End Get
            Set(value As String)
                _LabelFromUDFTable1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelFromUDFTable2() As String
            Get
                LabelFromUDFTable2 = _LabelFromUDFTable2
            End Get
            Set(value As String)
                _LabelFromUDFTable2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelFromUDFTable3() As String
            Get
                LabelFromUDFTable3 = _LabelFromUDFTable3
            End Get
            Set(value As String)
                _LabelFromUDFTable3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelFromUDFTable4() As String
            Get
                LabelFromUDFTable4 = _LabelFromUDFTable4
            End Get
            Set(value As String)
                _LabelFromUDFTable4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelFromUDFTable5() As String
            Get
                LabelFromUDFTable5 = _LabelFromUDFTable5
            End Get
            Set(value As String)
                _LabelFromUDFTable5 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AssignmentType() As String
            Get
                AssignmentType = _AssignmentType
            End Get
            Set(ByVal value As String)
                _AssignmentType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskCode() As String
            Get
                TaskCode = _TaskCode
            End Get
            Set(ByVal value As String)
                _TaskCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Assignment() As String
            Get
                Assignment = _Assignment
            End Get
            Set(ByVal value As String)
                _Assignment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Type() As String
            Get
                Type = _Type
            End Get
            Set(value As String)
                _Type = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property [Date]() As Date
            Get
                [Date] = _Date
            End Get
            Set(ByVal value As Date)
                _Date = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DateEntered() As Nullable(Of Date)
            Get
                DateEntered = _DateEntered
            End Get
            Set(ByVal value As Nullable(Of Date))
                _DateEntered = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StandardHours() As Nullable(Of Decimal)
            Get
                StandardHours = _StandardHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _StandardHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalHoursWorked() As Nullable(Of Decimal)
            Get
                TotalHoursWorked = _TotalHoursWorked
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalHoursWorked = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovalUserCode() As String
            Get
                ApprovalUserCode = _ApprovalUserCode
            End Get
            Set(ByVal value As String)
                _ApprovalUserCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovalDate() As Nullable(Of Date)
            Get
                ApprovalDate = _ApprovalDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ApprovalDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PendingApproval() As String
            Get
                PendingApproval = _PendingApproval
            End Get
            Set(ByVal value As String)
                _PendingApproval = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Approved() As String
            Get
                Approved = _Approved
            End Get
            Set(ByVal value As String)
                _Approved = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Hours() As Nullable(Of Decimal)
            Get
                Hours = _Hours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Hours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarkupAmount() As Nullable(Of Decimal)
            Get
                MarkupAmount = _MarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _MarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ResaleTax() As Nullable(Of Decimal)
            Get
                ResaleTax = _ResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalAmount() As Nullable(Of Decimal)
            Get
                TotalAmount = _TotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalBilled() As Nullable(Of Decimal)
            Get
                TotalBilled = _TotalBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalBilled = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalAmountWithTax() As Nullable(Of Decimal)
            Get
                TotalAmountWithTax = _TotalAmountWithTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalAmountWithTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalBilledWithTax() As Nullable(Of Decimal)
            Get
                TotalBilledWithTax = _TotalBilledWithTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalBilledWithTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NonBillable() As String
            Get
                NonBillable = _NonBillable
            End Get
            Set(ByVal value As String)
                _NonBillable = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Billed() As String
            Get
                Billed = _Billed
            End Get
            Set(ByVal value As String)
                _Billed = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionHeadingDescription() As String
            Get
                FunctionHeadingDescription = _FunctionHeadingDescription
            End Get
            Set(ByVal value As String)
                _FunctionHeadingDescription = value
            End Set
        End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
		Public Property Comments() As String
            Get
                Comments = _Comments
            End Get
            Set(ByVal value As String)
                _Comments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeOfficeCode() As String
            Get
                EmployeeOfficeCode = _EmployeeOfficeCode
            End Get
            Set(ByVal value As String)
                _EmployeeOfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobOfficeCode() As String
            Get
                JobOfficeCode = _JobOfficeCode
            End Get
            Set(ByVal value As String)
                _JobOfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsFeeTime() As String
            Get
                IsFeeTime = _IsFeeTime
            End Get
            Set(ByVal value As String)
                _IsFeeTime = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Exemption Status")>
        Public Property Status() As String
            Get
                Status = _Status
            End Get
            Set(value As String)
                _Status = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeRateFrom() As String
            Get
                EmployeeRateFrom = _EmployeeRateFrom
            End Get
            Set(value As String)
                _EmployeeRateFrom = value
            End Set
        End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
		Public Property AdjustmentComments() As String
            Get
                AdjustmentComments = _AdjustmentComments
            End Get
            Set(value As String)
                _AdjustmentComments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARPostPeriod() As String
            Get
                ARPostPeriod = _ARPostPeriod
            End Get
            Set(value As String)
                _ARPostPeriod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property ARInvoiceNumber() As Nullable(Of Integer)
            Get
                ARInvoiceNumber = _ARInvoiceNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ARInvoiceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CmpBeginDate() As Nullable(Of Date)
            Get
                CmpBeginDate = _CmpBeginDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _CmpBeginDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CmpEndDate() As Nullable(Of Date)
            Get
                CmpEndDate = _CmpEndDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _CmpEndDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionConsolidationCode() As String
            Get
                FunctionConsolidationCode = _FunctionConsolidationCode
            End Get
            Set(value As String)
                _FunctionConsolidationCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionConsolidationDescription() As String
            Get
                FunctionConsolidationDescription = _FunctionConsolidationDescription
            End Get
            Set(value As String)
                _FunctionConsolidationDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(value As String)
                _ClientPO = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Terminated() As String
            Get
                Terminated = _Terminated
            End Get
            Set(value As String)
                _Terminated = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TerminatedDate() As Nullable(Of Date)
            Get
                TerminatedDate = _TerminatedDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _TerminatedDate = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
