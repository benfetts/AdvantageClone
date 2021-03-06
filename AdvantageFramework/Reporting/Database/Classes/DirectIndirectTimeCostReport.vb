Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class DirectIndirectTimeCostReport

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
            EmployeeCurrentTitle
            EmployeeAccountNumber
            EmployeeCategory
            IsEmployeeFreelance
            IsActiveFreelance
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
            CampaignCode
            CampaignName
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            JobComponent
            AccountExecutiveCode
            JobTypeCode
            JobTypeDescription
            FunctionCode
            FunctionDescription
            Type
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
            TotalAmountWithTax
            NonBillable
            Billed
            CostAmount
            AlternateCostAmount
            FunctionHeadingDescription
            Comments
            EmployeeOfficeCode
            JobOfficeCode
            DefaultRoleCode
            DefaultRole
            IsFeeTime
            Status
            EmployeeRateFrom
            AdjustmentComments
            UserID
            FunctionConsolidationCode
            FunctionConsolidationDescription
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
        Private _EmployeeCurrentTitle As String = Nothing
        Private _EmployeeAccountNumber As String = Nothing
        Private _EmployeeCategory As String = Nothing
        Private _IsEmployeeFreelance As String = Nothing
        Private _IsActiveFreelance As String = Nothing
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
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _JobComponent As String = Nothing
        Private _AccountExecutiveCode As String = Nothing
        Private _JobTypeCode As String = Nothing
        Private _JobTypeDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _Type As String = Nothing
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
        Private _TotalAmountWithTax As Nullable(Of Decimal) = Nothing
        Private _NonBillable As String = Nothing
        Private _Billed As String = Nothing
        Private _CostAmount As Nullable(Of Decimal) = Nothing
        Private _AlternateCostAmount As Nullable(Of Decimal) = Nothing
        Private _FunctionHeadingDescription As String = Nothing
        Private _Comments As String = Nothing
        Private _EmployeeOfficeCode As String = Nothing
        Private _JobOfficeCode As String = Nothing
        Private _DefaultRoleCode As String = Nothing
        Private _DefaultRole As String = Nothing
        Private _IsFeeTime As String = Nothing
        Private _Status As String = Nothing
        Private _EmployeeRateFrom As String = Nothing
        Private _AdjustmentComments As String = Nothing
        Private _UserID As String = Nothing
        Private _CmpBeginDate As Nullable(Of Date) = Nothing
        Private _CmpEndDate As Nullable(Of Date) = Nothing
        Private _FunctionConsolidationCode As String = Nothing
        Private _FunctionConsolidationDescription As String = Nothing
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
            Set(value As String)
                _EmployeeTitle = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeCurrentTitle() As String
            Get
                EmployeeCurrentTitle = _EmployeeCurrentTitle
            End Get
            Set(ByVal value As String)
                _EmployeeCurrentTitle = value
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
        Public Property EmployeeCategory() As String
            Get
                EmployeeCategory = _EmployeeCategory
            End Get
            Set(value As String)
                _EmployeeCategory = value
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
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
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
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
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
        Public Property TotalAmountWithTax() As Nullable(Of Decimal)
            Get
                TotalAmountWithTax = _TotalAmountWithTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalAmountWithTax = value
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
        Public Property CostAmount() As Nullable(Of Decimal)
            Get
                CostAmount = _CostAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CostAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlternateCostAmount() As Nullable(Of Decimal)
            Get
                AlternateCostAmount = _AlternateCostAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AlternateCostAmount = value
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
