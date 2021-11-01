Namespace Reporting.Database.Classes

    <Serializable>
    Public Class EstimatedAndActualIncome

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            JobNumber
            JobComponentNumber
            OfficeCode
            OfficeDescription
            ClientCode
            ClientDescription
            DivisionCode
            DivisionDescription
            ProductCode
            ProductDescription
            IsNewBusiness
            Agency
            ProductUDF1
            ProductUDF2
            ProductUDF3
            ProductUDF4
            CampaignID
            CampaignCode
            CampaignDescription
            SalesClassCode
            SalesClassDescription
            UserCode
            JobCreateDate
            JobDescription
            JobDateOpened
            RushChargesApproved
            ApprovedEstimateRequired
            Comment
            ClientReference
            BillingCoopCode
            SalesClassFormatCode
            ComplexityCode
            ComplexityDescription
            PromotionCode
            BillingComment
            LabelFromUDFTable1
            LabelFromUDFTable2
            LabelFromUDFTable3
            LabelFromUDFTable4
            LabelFromUDFTable5
            JobOpen
            ComponentNumber
            JobComponent
            BillHold
            AccountExecutiveCode
            AccountExecutive
            ComponentDateOpened
            DueDate
            StartDate
            AdSize
            DepartmentTeamCode
            DepartmentTeam
            MarkupPercent
            CreativeInstructions
            JobProcessControl
            ComponentDescription
            ComponentComments
            ComponentBudget
            EstimateNumber
            EstimateComponentNumber
            BillingUser
            AdvanceBillFlag
            DeliveryInstructions
            JobTypeCode
            JobTypeDescription
            Taxable
            TaxCode
            TaxCodeDescription
            NonBillable
            AlertGroup
            AdNumber
            AccountNumber
            IncomeRecognitionMethod
            MarketCode
            MarketDescription
            ServiceFeeJob
            ServiceFeeTypeCode
            ServiceFeeTypeDescription
            Archived
            TrafficScheduleRequired
            ClientPO
            CompLabelFromUDFTable1
            CompLabelFromUDFTable2
            CompLabelFromUDFTable3
            CompLabelFromUDFTable4
            CompLabelFromUDFTable5
            JobTemplateCode
            FiscalPeriodCode
            FiscalPeriodDescription
            JobQuantity
            BlackplateVersionCode
            BlackplateVersionDesc
            ClientContactCode
            ClientContactID
            BABatchID
            ClientContact
            SelectedBABatchID
            BillingCommandCenterID
            AlertAssignmentTemplate
            FunctionType
            FunctionConsolidationCode
            FunctionConsolidation
            FunctionHeading
            FunctionCode
            FunctionDescription
            Hours
            Quantity
            NetAmount
            CostAmount
            ExtMarkupAmount
            Total
            BillableAmount
            NonBillableAmount
            BilledHours
            BilledQuantity
            BilledAmount
            EstimatedHours
            EstimatedQuantity
            EstimatedNetAmount
            EstimatedCostAmount
            EstimatedMarkupAmount
            EstimatedTotalAmount
            EstimatedGrossIncome
            EstimatedGrossIncomePercent
            EstimatedIncome
            EstimatedIncomePercent
            EstimatedIncomeHist
            EstimatedIncomePercentHist
            PlannedHours
            PlannedAmount
            PlannedCostAmount
            PlannedIncome
            PlannedIncomePercent
            ActualGrossIncome
            ActualGrossIncomePercent
            ActualIncome
            ActualIncomePercent
            EmployeeCode
            EmployeeName
            EstimatedCostAmountHist
            ClientApproved
            ClientApprovalDate
            InternallyApproved
            InternalApprovalDate
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeDescription As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientDescription As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionDescription As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _IsNewBusiness As Nullable(Of Short) = Nothing
        Private _Agency As Nullable(Of Short) = Nothing
        Private _ProductUDF1 As String = Nothing
        Private _ProductUDF2 As String = Nothing
        Private _ProductUDF3 As String = Nothing
        Private _ProductUDF4 As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignDescription As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _UserCode As String = Nothing
        Private _JobCreateDate As Nullable(Of Date) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobDateOpened As Nullable(Of Date) = Nothing
        Private _RushChargesApproved As String = Nothing
        Private _ApprovedEstimateRequired As String = Nothing
        Private _Comment As String = Nothing
        Private _ClientReference As String = Nothing
        Private _BillingCoopCode As String = Nothing
        Private _SalesClassFormatCode As String = Nothing
        Private _ComplexityCode As String = Nothing
        Private _ComplexityDescription As String = Nothing
        Private _PromotionCode As String = Nothing
        Private _BillingComment As String = Nothing
        Private _LabelFromUDFTable1 As String = Nothing
        Private _LabelFromUDFTable2 As String = Nothing
        Private _LabelFromUDFTable3 As String = Nothing
        Private _LabelFromUDFTable4 As String = Nothing
        Private _LabelFromUDFTable5 As String = Nothing
        Private _JobOpen As String = Nothing
        Private _ComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponent As String = Nothing
        Private _BillHold As String = Nothing
        Private _AccountExecutiveCode As String = Nothing
        Private _AccountExecutive As String = Nothing
        Private _ComponentDateOpened As Nullable(Of Date) = Nothing
        Private _DueDate As Nullable(Of Date) = Nothing
        Private _StartDate As Nullable(Of Date) = Nothing
        Private _AdSize As String = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _DepartmentTeam As String = Nothing
        Private _MarkupPercent As Nullable(Of Decimal) = Nothing
        Private _CreativeInstructions As String = Nothing
        Private _JobProcessControl As String = Nothing
        Private _ComponentDescription As String = Nothing
        Private _ComponentComments As String = Nothing
        Private _ComponentBudget As Nullable(Of Decimal) = Nothing
        Private _EstimateNumber As Nullable(Of Integer) = Nothing
        Private _EstimateComponentNumber As Nullable(Of Short) = Nothing
        Private _BillingUser As String = Nothing
        Private _AdvanceBillFlag As String = Nothing
        Private _DeliveryInstructions As String = Nothing
        Private _JobTypeCode As String = Nothing
        Private _JobTypeDescription As String = Nothing
        Private _Taxable As String = Nothing
        Private _TaxCode As String = Nothing
        Private _TaxCodeDescription As String = Nothing
        Private _NonBillable As Nullable(Of Short) = Nothing
        Private _AlertGroup As String = Nothing
        Private _AdNumber As String = Nothing
        Private _AccountNumber As String = Nothing
        Private _IncomeRecognitionMethod As String = Nothing
        Private _MarketCode As String = Nothing
        Private _MarketDescription As String = Nothing
        Private _ServiceFeeJob As String = Nothing
        Private _ServiceFeeTypeCode As String = Nothing
        Private _ServiceFeeTypeDescription As String = Nothing
        Private _Archived As String = Nothing
        Private _TrafficScheduleRequired As String = Nothing
        Private _ClientPO As String = Nothing
        Private _CompLabelFromUDFTable1 As String = Nothing
        Private _CompLabelFromUDFTable2 As String = Nothing
        Private _CompLabelFromUDFTable3 As String = Nothing
        Private _CompLabelFromUDFTable4 As String = Nothing
        Private _CompLabelFromUDFTable5 As String = Nothing
        Private _JobTemplateCode As String = Nothing
        Private _FiscalPeriodCode As String = Nothing
        Private _FiscalPeriodDescription As String = Nothing
        Private _JobQuantity As Nullable(Of Integer) = Nothing
        Private _BlackplateVersionCode As String = Nothing
        Private _BlackplateVersionDesc As String = Nothing
		Private _ClientContactCode As String = Nothing
		Private _ClientContactID As Nullable(Of Integer) = Nothing
		Private _BABatchID As Nullable(Of Integer) = Nothing
        Private _ClientContact As String = Nothing
        Private _SelectedBABatchID As Nullable(Of Integer) = Nothing
        Private _BillingCommandCenterID As Nullable(Of Integer) = Nothing
        Private _AlertAssignmentTemplate As String = Nothing
        Private _FunctionType As String = Nothing
        Private _FunctionConsolidationCode As String = Nothing
        Private _FunctionConsolidation As String = Nothing
        Private _FunctionHeading As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _Hours As Nullable(Of Decimal) = Nothing
        Private _Quantity As Nullable(Of Decimal) = Nothing
        Private _NetAmount As Nullable(Of Decimal) = Nothing
        Private _CostAmount As Nullable(Of Decimal) = Nothing
        Private _ExtMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _Total As Nullable(Of Decimal) = Nothing
        Private _BillableAmount As Nullable(Of Decimal) = Nothing
        Private _NonBillableAmount As Nullable(Of Decimal) = Nothing
        Private _BilledHours As Nullable(Of Decimal) = Nothing
        Private _BilledQuantity As Nullable(Of Decimal) = Nothing
        Private _BilledAmount As Nullable(Of Decimal) = Nothing
        Private _EstimatedHours As Nullable(Of Decimal) = Nothing
        Private _EstimatedQuantity As Nullable(Of Decimal) = Nothing
        Private _EstimatedNetAmount As Nullable(Of Decimal) = Nothing
        Private _EstimatedCostAmount As Nullable(Of Decimal) = Nothing
        Private _EstimatedMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _EstimatedTotalAmount As Nullable(Of Decimal) = Nothing
        Private _EstimatedGrossIncome As Nullable(Of Decimal) = Nothing
        Private _EstimatedGrossIncomePercent As Nullable(Of Decimal) = Nothing
        Private _EstimatedIncome As Nullable(Of Decimal) = Nothing
        Private _EstimatedIncomePercent As Nullable(Of Decimal) = Nothing
        Private _EstimatedIncomeHist As Nullable(Of Decimal) = Nothing
        Private _EstimatedIncomePercentHist As Nullable(Of Decimal) = Nothing
        Private _PlannedHours As Nullable(Of Decimal) = Nothing
        Private _PlannedAmount As Nullable(Of Decimal) = Nothing
        Private _PlannedCostAmount As Nullable(Of Decimal) = Nothing
        Private _PlannedIncome As Nullable(Of Decimal) = Nothing
        Private _PlannedIncomePercent As Nullable(Of Decimal) = Nothing
        Private _ActualGrossIncome As Nullable(Of Decimal) = Nothing
        Private _ActualGrossIncomePercent As Nullable(Of Decimal) = Nothing
        Private _ActualIncome As Nullable(Of Decimal) = Nothing
        Private _ActualIncomePercent As Nullable(Of Decimal) = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _EstimatedCostAmountHist As Nullable(Of Decimal) = Nothing
        Private _ClientApproved As String = Nothing
        Private _ClientApprovalDate As Nullable(Of Date) = Nothing
        Private _InternallyApproved As String = Nothing
        Private _InternalApprovalDate As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        Public Property OfficeDescription() As String
            Get
                OfficeDescription = _OfficeDescription
            End Get
            Set(value As String)
                _OfficeDescription = value
            End Set
        End Property
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property ClientDescription() As String
            Get
                ClientDescription = _ClientDescription
            End Get
            Set(value As String)
                _ClientDescription = value
            End Set
        End Property
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        Public Property DivisionDescription() As String
            Get
                DivisionDescription = _DivisionDescription
            End Get
            Set(value As String)
                _DivisionDescription = value
            End Set
        End Property
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsNewBusiness() As Nullable(Of Short)
            Get
                IsNewBusiness = _IsNewBusiness
            End Get
            Set(value As Nullable(Of Short))
                _IsNewBusiness = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property Agency() As Nullable(Of Short)
            Get
                Agency = _Agency
            End Get
            Set(value As Nullable(Of Short))
                _Agency = value
            End Set
        End Property
        Public Property ProductUDF1() As String
            Get
                ProductUDF1 = _ProductUDF1
            End Get
            Set(value As String)
                _ProductUDF1 = value
            End Set
        End Property
        Public Property ProductUDF2() As String
            Get
                ProductUDF2 = _ProductUDF2
            End Get
            Set(value As String)
                _ProductUDF2 = value
            End Set
        End Property
        Public Property ProductUDF3() As String
            Get
                ProductUDF3 = _ProductUDF3
            End Get
            Set(value As String)
                _ProductUDF3 = value
            End Set
        End Property
        Public Property ProductUDF4() As String
            Get
                ProductUDF4 = _ProductUDF4
            End Get
            Set(value As String)
                _ProductUDF4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        Public Property CampaignDescription() As String
            Get
                CampaignDescription = _CampaignDescription
            End Get
            Set(value As String)
                _CampaignDescription = value
            End Set
        End Property
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(value As String)
                _SalesClassDescription = value
            End Set
        End Property
        Public Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
            Set(value As String)
                _UserCode = value
            End Set
        End Property
        Public Property JobCreateDate() As Nullable(Of Date)
            Get
                JobCreateDate = _JobCreateDate
            End Get
            Set(value As Nullable(Of Date))
                _JobCreateDate = value
            End Set
        End Property
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        Public Property JobDateOpened() As Nullable(Of Date)
            Get
                JobDateOpened = _JobDateOpened
            End Get
            Set(value As Nullable(Of Date))
                _JobDateOpened = value
            End Set
        End Property
        Public Property RushChargesApproved() As String
            Get
                RushChargesApproved = _RushChargesApproved
            End Get
            Set(value As String)
                _RushChargesApproved = value
            End Set
        End Property
        Public Property ApprovedEstimateRequired() As String
            Get
                ApprovedEstimateRequired = _ApprovedEstimateRequired
            End Get
            Set(value As String)
                _ApprovedEstimateRequired = value
            End Set
        End Property
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(value As String)
                _Comment = value
            End Set
        End Property
        Public Property ClientReference() As String
            Get
                ClientReference = _ClientReference
            End Get
            Set(value As String)
                _ClientReference = value
            End Set
        End Property
        Public Property BillingCoopCode() As String
            Get
                BillingCoopCode = _BillingCoopCode
            End Get
            Set(value As String)
                _BillingCoopCode = value
            End Set
        End Property
        Public Property SalesClassFormatCode() As String
            Get
                SalesClassFormatCode = _SalesClassFormatCode
            End Get
            Set(value As String)
                _SalesClassFormatCode = value
            End Set
        End Property
        Public Property ComplexityCode() As String
            Get
                ComplexityCode = _ComplexityCode
            End Get
            Set(value As String)
                _ComplexityCode = value
            End Set
        End Property
        Public Property ComplexityDescription() As String
            Get
                ComplexityDescription = _ComplexityDescription
            End Get
            Set(value As String)
                _ComplexityDescription = value
            End Set
        End Property
        Public Property PromotionCode() As String
            Get
                PromotionCode = _PromotionCode
            End Get
            Set(value As String)
                _PromotionCode = value
            End Set
        End Property
        Public Property BillingComment() As String
            Get
                BillingComment = _BillingComment
            End Get
            Set(value As String)
                _BillingComment = value
            End Set
        End Property
        Public Property LabelFromUDFTable1() As String
            Get
                LabelFromUDFTable1 = _LabelFromUDFTable1
            End Get
            Set(value As String)
                _LabelFromUDFTable1 = value
            End Set
        End Property
        Public Property LabelFromUDFTable2() As String
            Get
                LabelFromUDFTable2 = _LabelFromUDFTable2
            End Get
            Set(value As String)
                _LabelFromUDFTable2 = value
            End Set
        End Property
        Public Property LabelFromUDFTable3() As String
            Get
                LabelFromUDFTable3 = _LabelFromUDFTable3
            End Get
            Set(value As String)
                _LabelFromUDFTable3 = value
            End Set
        End Property
        Public Property LabelFromUDFTable4() As String
            Get
                LabelFromUDFTable4 = _LabelFromUDFTable4
            End Get
            Set(value As String)
                _LabelFromUDFTable4 = value
            End Set
        End Property
        Public Property LabelFromUDFTable5() As String
            Get
                LabelFromUDFTable5 = _LabelFromUDFTable5
            End Get
            Set(value As String)
                _LabelFromUDFTable5 = value
            End Set
        End Property
        Public Property JobOpen() As String
            Get
                JobOpen = _JobOpen
            End Get
            Set(value As String)
                _JobOpen = value
            End Set
        End Property
        Public Property ComponentNumber() As Nullable(Of Short)
            Get
                ComponentNumber = _ComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _ComponentNumber = value
            End Set
        End Property
        Public Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
            Set(value As String)
                _JobComponent = value
            End Set
        End Property
        Public Property BillHold() As String
            Get
                BillHold = _BillHold
            End Get
            Set(value As String)
                _BillHold = value
            End Set
        End Property
        Public Property AccountExecutiveCode() As String
            Get
                AccountExecutiveCode = _AccountExecutiveCode
            End Get
            Set(value As String)
                _AccountExecutiveCode = value
            End Set
        End Property
        Public Property AccountExecutive() As String
            Get
                AccountExecutive = _AccountExecutive
            End Get
            Set(value As String)
                _AccountExecutive = value
            End Set
        End Property
        Public Property ComponentDateOpened() As Nullable(Of Date)
            Get
                ComponentDateOpened = _ComponentDateOpened
            End Get
            Set(value As Nullable(Of Date))
                _ComponentDateOpened = value
            End Set
        End Property
        Public Property DueDate() As Nullable(Of Date)
            Get
                DueDate = _DueDate
            End Get
            Set(value As Nullable(Of Date))
                _DueDate = value
            End Set
        End Property
        Public Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
            Set(value As Nullable(Of Date))
                _StartDate = value
            End Set
        End Property
        Public Property AdSize() As String
            Get
                AdSize = _AdSize
            End Get
            Set(value As String)
                _AdSize = value
            End Set
        End Property
        Public Property DepartmentTeamCode() As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(value As String)
                _DepartmentTeamCode = value
            End Set
        End Property
        Public Property DepartmentTeam() As String
            Get
                DepartmentTeam = _DepartmentTeam
            End Get
            Set(value As String)
                _DepartmentTeam = value
            End Set
        End Property
        Public Property MarkupPercent() As Nullable(Of Decimal)
            Get
                MarkupPercent = _MarkupPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _MarkupPercent = value
            End Set
        End Property
        Public Property CreativeInstructions() As String
            Get
                CreativeInstructions = _CreativeInstructions
            End Get
            Set(value As String)
                _CreativeInstructions = value
            End Set
        End Property
        Public Property JobProcessControl() As String
            Get
                JobProcessControl = _JobProcessControl
            End Get
            Set(value As String)
                _JobProcessControl = value
            End Set
        End Property
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(value As String)
                _ComponentDescription = value
            End Set
        End Property
        Public Property ComponentComments() As String
            Get
                ComponentComments = _ComponentComments
            End Get
            Set(value As String)
                _ComponentComments = value
            End Set
        End Property
        Public Property ComponentBudget() As Nullable(Of Decimal)
            Get
                ComponentBudget = _ComponentBudget
            End Get
            Set(value As Nullable(Of Decimal))
                _ComponentBudget = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property EstimateNumber() As Nullable(Of Integer)
            Get
                EstimateNumber = _EstimateNumber
            End Get
            Set(value As Nullable(Of Integer))
                _EstimateNumber = value
            End Set
        End Property
        Public Property EstimateComponentNumber() As Nullable(Of Short)
            Get
                EstimateComponentNumber = _EstimateComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _EstimateComponentNumber = value
            End Set
        End Property
        Public Property ClientApproved() As String
            Get
                ClientApproved = _ClientApproved
            End Get
            Set(value As String)
                _ClientApproved = value
            End Set
        End Property
        Public Property ClientApprovalDate() As Nullable(Of Date)
            Get
                ClientApprovalDate = _ClientApprovalDate
            End Get
            Set(value As Nullable(Of Date))
                _ClientApprovalDate = value
            End Set
        End Property
        Public Property InternallyApproved() As String
            Get
                InternallyApproved = _InternallyApproved
            End Get
            Set(value As String)
                _InternallyApproved = value
            End Set
        End Property
        Public Property InternalApprovalDate() As Nullable(Of Date)
            Get
                InternalApprovalDate = _InternalApprovalDate
            End Get
            Set(value As Nullable(Of Date))
                _InternalApprovalDate = value
            End Set
        End Property
        Public Property BillingUser() As String
            Get
                BillingUser = _BillingUser
            End Get
            Set(value As String)
                _BillingUser = value
            End Set
        End Property
        Public Property AdvanceBillFlag() As String
            Get
                AdvanceBillFlag = _AdvanceBillFlag
            End Get
            Set(value As String)
                _AdvanceBillFlag = value
            End Set
        End Property
        Public Property DeliveryInstructions() As String
            Get
                DeliveryInstructions = _DeliveryInstructions
            End Get
            Set(value As String)
                _DeliveryInstructions = value
            End Set
        End Property
        Public Property JobTypeCode() As String
            Get
                JobTypeCode = _JobTypeCode
            End Get
            Set(value As String)
                _JobTypeCode = value
            End Set
        End Property
        Public Property JobTypeDescription() As String
            Get
                JobTypeDescription = _JobTypeDescription
            End Get
            Set(value As String)
                _JobTypeDescription = value
            End Set
        End Property
        Public Property Taxable() As String
            Get
                Taxable = _Taxable
            End Get
            Set(value As String)
                _Taxable = value
            End Set
        End Property
        Public Property TaxCode() As String
            Get
                TaxCode = _TaxCode
            End Get
            Set(value As String)
                _TaxCode = value
            End Set
        End Property
        Public Property TaxCodeDescription() As String
            Get
                TaxCodeDescription = _TaxCodeDescription
            End Get
            Set(value As String)
                _TaxCodeDescription = value
            End Set
        End Property
        Public Property NonBillable() As Nullable(Of Short)
            Get
                NonBillable = _NonBillable
            End Get
            Set(value As Nullable(Of Short))
                _NonBillable = value
            End Set
        End Property
        Public Property AlertGroup() As String
            Get
                AlertGroup = _AlertGroup
            End Get
            Set(value As String)
                _AlertGroup = value
            End Set
        End Property
        Public Property AdNumber() As String
            Get
                AdNumber = _AdNumber
            End Get
            Set(value As String)
                _AdNumber = value
            End Set
        End Property
        Public Property AccountNumber() As String
            Get
                AccountNumber = _AccountNumber
            End Get
            Set(value As String)
                _AccountNumber = value
            End Set
        End Property
        Public Property IncomeRecognitionMethod() As String
            Get
                IncomeRecognitionMethod = _IncomeRecognitionMethod
            End Get
            Set(value As String)
                _IncomeRecognitionMethod = value
            End Set
        End Property
        Public Property MarketCode() As String
            Get
                MarketCode = _MarketCode
            End Get
            Set(value As String)
                _MarketCode = value
            End Set
        End Property
        Public Property MarketDescription() As String
            Get
                MarketDescription = _MarketDescription
            End Get
            Set(value As String)
                _MarketDescription = value
            End Set
        End Property
        Public Property ServiceFeeJob() As String
            Get
                ServiceFeeJob = _ServiceFeeJob
            End Get
            Set(value As String)
                _ServiceFeeJob = value
            End Set
        End Property
        Public Property ServiceFeeTypeCode() As String
            Get
                ServiceFeeTypeCode = _ServiceFeeTypeCode
            End Get
            Set(value As String)
                _ServiceFeeTypeCode = value
            End Set
        End Property
        Public Property ServiceFeeTypeDescription() As String
            Get
                ServiceFeeTypeDescription = _ServiceFeeTypeDescription
            End Get
            Set(value As String)
                _ServiceFeeTypeDescription = value
            End Set
        End Property
        Public Property Archived() As String
            Get
                Archived = _Archived
            End Get
            Set(value As String)
                _Archived = value
            End Set
        End Property
        Public Property TrafficScheduleRequired() As String
            Get
                TrafficScheduleRequired = _TrafficScheduleRequired
            End Get
            Set(value As String)
                _TrafficScheduleRequired = value
            End Set
        End Property
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(value As String)
                _ClientPO = value
            End Set
        End Property
        Public Property CompLabelFromUDFTable1() As String
            Get
                CompLabelFromUDFTable1 = _CompLabelFromUDFTable1
            End Get
            Set(value As String)
                _CompLabelFromUDFTable1 = value
            End Set
        End Property
        Public Property CompLabelFromUDFTable2() As String
            Get
                CompLabelFromUDFTable2 = _CompLabelFromUDFTable2
            End Get
            Set(value As String)
                _CompLabelFromUDFTable2 = value
            End Set
        End Property
        Public Property CompLabelFromUDFTable3() As String
            Get
                CompLabelFromUDFTable3 = _CompLabelFromUDFTable3
            End Get
            Set(value As String)
                _CompLabelFromUDFTable3 = value
            End Set
        End Property
        Public Property CompLabelFromUDFTable4() As String
            Get
                CompLabelFromUDFTable4 = _CompLabelFromUDFTable4
            End Get
            Set(value As String)
                _CompLabelFromUDFTable4 = value
            End Set
        End Property
        Public Property CompLabelFromUDFTable5() As String
            Get
                CompLabelFromUDFTable5 = _CompLabelFromUDFTable5
            End Get
            Set(value As String)
                _CompLabelFromUDFTable5 = value
            End Set
        End Property
        Public Property JobTemplateCode() As String
            Get
                JobTemplateCode = _JobTemplateCode
            End Get
            Set(value As String)
                _JobTemplateCode = value
            End Set
        End Property
        Public Property FiscalPeriodCode() As String
            Get
                FiscalPeriodCode = _FiscalPeriodCode
            End Get
            Set(value As String)
                _FiscalPeriodCode = value
            End Set
        End Property
        Public Property FiscalPeriodDescription() As String
            Get
                FiscalPeriodDescription = _FiscalPeriodDescription
            End Get
            Set(value As String)
                _FiscalPeriodDescription = value
            End Set
        End Property
        Public Property JobQuantity() As Nullable(Of Integer)
            Get
                JobQuantity = _JobQuantity
            End Get
            Set(value As Nullable(Of Integer))
                _JobQuantity = value
            End Set
        End Property
        Public Property BlackplateVersionCode() As String
            Get
                BlackplateVersionCode = _BlackplateVersionCode
            End Get
            Set(value As String)
                _BlackplateVersionCode = value
            End Set
        End Property
        Public Property BlackplateVersionDesc() As String
            Get
                BlackplateVersionDesc = _BlackplateVersionDesc
            End Get
            Set(value As String)
                _BlackplateVersionDesc = value
            End Set
        End Property
		Public Property ClientContactCode() As String
			Get
				ClientContactCode = _ClientContactCode
			End Get
			Set(value As String)
				_ClientContactCode = value
			End Set
		End Property
		Public Property ClientContactID() As Nullable(Of Integer)
			Get
				ClientContactID = _ClientContactID
			End Get
			Set(value As Nullable(Of Integer))
				_ClientContactID = value
			End Set
		End Property
		Public Property BABatchID() As Nullable(Of Integer)
            Get
                BABatchID = _BABatchID
            End Get
            Set(value As Nullable(Of Integer))
                _BABatchID = value
            End Set
        End Property
        Public Property ClientContact() As String
            Get
                ClientContact = _ClientContact
            End Get
            Set(value As String)
                _ClientContact = value
            End Set
        End Property
        Public Property SelectedBABatchID() As Nullable(Of Integer)
            Get
                SelectedBABatchID = _SelectedBABatchID
            End Get
            Set(value As Nullable(Of Integer))
                _SelectedBABatchID = value
            End Set
        End Property
        Public Property BillingCommandCenterID() As Nullable(Of Integer)
            Get
                BillingCommandCenterID = _BillingCommandCenterID
            End Get
            Set(value As Nullable(Of Integer))
                _BillingCommandCenterID = value
            End Set
        End Property
        Public Property AlertAssignmentTemplate() As String
            Get
                AlertAssignmentTemplate = _AlertAssignmentTemplate
            End Get
            Set(value As String)
                _AlertAssignmentTemplate = value
            End Set
        End Property
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(value As String)
                _FunctionType = value
            End Set
        End Property
        Public Property FunctionConsolidationCode() As String
            Get
                FunctionConsolidationCode = _FunctionConsolidationCode
            End Get
            Set(value As String)
                _FunctionConsolidationCode = value
            End Set
        End Property
        Public Property FunctionConsolidation() As String
            Get
                FunctionConsolidation = _FunctionConsolidation
            End Get
            Set(value As String)
                _FunctionConsolidation = value
            End Set
        End Property
        Public Property FunctionHeading() As String
            Get
                FunctionHeading = _FunctionHeading
            End Get
            Set(value As String)
                _FunctionHeading = value
            End Set
        End Property
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        Public Property Hours() As Nullable(Of Decimal)
            Get
                Hours = _Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Hours = value
            End Set
        End Property
        Public Property Quantity() As Nullable(Of Decimal)
            Get
                Quantity = _Quantity
            End Get
            Set(value As Nullable(Of Decimal))
                _Quantity = value
            End Set
        End Property
        Public Property NetAmount() As Nullable(Of Decimal)
            Get
                NetAmount = _NetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _NetAmount = value
            End Set
        End Property
        Public Property CostAmount() As Nullable(Of Decimal)
            Get
                CostAmount = _CostAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _CostAmount = value
            End Set
        End Property
        Public Property ExtMarkupAmount() As Nullable(Of Decimal)
            Get
                ExtMarkupAmount = _ExtMarkupAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtMarkupAmount = value
            End Set
        End Property
        Public Property Total() As Nullable(Of Decimal)
            Get
                Total = _Total
            End Get
            Set(value As Nullable(Of Decimal))
                _Total = value
            End Set
        End Property
        Public Property BillableAmount() As Nullable(Of Decimal)
            Get
                BillableAmount = _BillableAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BillableAmount = value
            End Set
        End Property
        Public Property NonBillableAmount() As Nullable(Of Decimal)
            Get
                NonBillableAmount = _NonBillableAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _NonBillableAmount = value
            End Set
        End Property
        Public Property BilledHours() As Nullable(Of Decimal)
            Get
                BilledHours = _BilledHours
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledHours = value
            End Set
        End Property
        Public Property BilledQuantity() As Nullable(Of Decimal)
            Get
                BilledQuantity = _BilledQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledQuantity = value
            End Set
        End Property
        Public Property BilledAmount() As Nullable(Of Decimal)
            Get
                BilledAmount = _BilledAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledAmount = value
            End Set
        End Property
        Public Property EstimatedHours() As Nullable(Of Decimal)
            Get
                EstimatedHours = _EstimatedHours
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimatedHours = value
            End Set
        End Property
        Public Property EstimatedQuantity() As Nullable(Of Decimal)
            Get
                EstimatedQuantity = _EstimatedQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimatedQuantity = value
            End Set
        End Property
        Public Property EstimatedNetAmount() As Nullable(Of Decimal)
            Get
                EstimatedNetAmount = _EstimatedNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimatedNetAmount = value
            End Set
        End Property
        Public Property EstimatedCostAmount() As Nullable(Of Decimal)
            Get
                EstimatedCostAmount = _EstimatedCostAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimatedCostAmount = value
            End Set
        End Property
        Public Property EstimatedCostAmountHist() As Nullable(Of Decimal)
            Get
                EstimatedCostAmountHist = _EstimatedCostAmountHist
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimatedCostAmountHist = value
            End Set
        End Property
        Public Property EstimatedMarkupAmount() As Nullable(Of Decimal)
            Get
                EstimatedMarkupAmount = _EstimatedMarkupAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimatedMarkupAmount = value
            End Set
        End Property
        Public Property EstimatedTotalAmount() As Nullable(Of Decimal)
            Get
                EstimatedTotalAmount = _EstimatedTotalAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimatedTotalAmount = value
            End Set
        End Property
        Public Property EstimatedGrossIncome() As Nullable(Of Decimal)
            Get
                EstimatedGrossIncome = _EstimatedGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimatedGrossIncome = value
            End Set
        End Property
        Public Property EstimatedGrossIncomePercent() As Nullable(Of Decimal)
            Get
                EstimatedGrossIncomePercent = _EstimatedGrossIncomePercent
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimatedGrossIncomePercent = value
            End Set
        End Property
        Public Property EstimatedIncome() As Nullable(Of Decimal)
            Get
                EstimatedIncome = _EstimatedIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimatedIncome = value
            End Set
        End Property
        Public Property EstimatedIncomePercent() As Nullable(Of Decimal)
            Get
                EstimatedIncomePercent = _EstimatedIncomePercent
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimatedIncomePercent = value
            End Set
        End Property
        Public Property EstimatedIncomeHist() As Nullable(Of Decimal)
            Get
                EstimatedIncomeHist = _EstimatedIncomeHist
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimatedIncomeHist = value
            End Set
        End Property
        Public Property EstimatedIncomePercentHist() As Nullable(Of Decimal)
            Get
                EstimatedIncomePercentHist = _EstimatedIncomePercentHist
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimatedIncomePercentHist = value
            End Set
        End Property
        Public Property PlannedHours() As Nullable(Of Decimal)
            Get
                PlannedHours = _PlannedHours
            End Get
            Set(value As Nullable(Of Decimal))
                _PlannedHours = value
            End Set
        End Property
        Public Property PlannedAmount() As Nullable(Of Decimal)
            Get
                PlannedAmount = _PlannedAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _PlannedAmount = value
            End Set
        End Property
        Public Property PlannedCostAmount() As Nullable(Of Decimal)
            Get
                PlannedCostAmount = _PlannedCostAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _PlannedCostAmount = value
            End Set
        End Property
        Public Property PlannedIncome() As Nullable(Of Decimal)
            Get
                PlannedIncome = _PlannedIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _PlannedIncome = value
            End Set
        End Property
        Public Property PlannedIncomePercent() As Nullable(Of Decimal)
            Get
                PlannedIncomePercent = _PlannedIncomePercent
            End Get
            Set(value As Nullable(Of Decimal))
                _PlannedIncomePercent = value
            End Set
        End Property
        Public Property ActualGrossIncome() As Nullable(Of Decimal)
            Get
                ActualGrossIncome = _ActualGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualGrossIncome = value
            End Set
        End Property
        Public Property ActualGrossIncomePercent() As Nullable(Of Decimal)
            Get
                ActualGrossIncomePercent = _ActualGrossIncomePercent
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualGrossIncomePercent = value
            End Set
        End Property
        Public Property ActualIncome() As Nullable(Of Decimal)
            Get
                ActualIncome = _ActualIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualIncome = value
            End Set
        End Property
        Public Property ActualIncomePercent() As Nullable(Of Decimal)
            Get
                ActualIncomePercent = _ActualIncomePercent
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualIncomePercent = value
            End Set
        End Property
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        Public Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(value As String)
                _EmployeeName = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
