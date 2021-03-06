Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class JobDetailItemReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ResourceType
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
            CampaignID
            CampaignCode
            CampaignName
            BillingBudget
            IncomeBudget
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
            JobComponent
            BillHold
            AccountExecutiveCode
            AccountExecutive
            ManagerCode
            Manager
            ComponentDateOpened
            DueDate
            StartDate
            Status
            GutPercentComplete
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
            ClientApproved
            ClientApprovalDate
            ClientApprovedBy
            InternallyApproved
            InternalApprovalDate
            InternallyApprovedBy
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
            AccountNumberDescription
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
            BlackplateVersion2Code
            BlackplateVersion2Desc
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
            ItemID
            ItemSequenceNumber
            ItemDate
            PostPeriodCode
            ItemCode
            ItemDescription
            ItemComment
            ItemExtra
            ItemDetailComment
            Hours
            Quantity
            NetAmount
            CostAmount
            ExtMarkupAmount
            NonResaleTaxAmount
            ResaleTaxAmount
            Total
            BillableLessResale
            BillableTotal
            FeeTime
            FeeTimeHours
            FeeTimeAmount
            NonBillableHours
            NonBillableQuantity
            NonBillableAmount
            BilledHours
            BilledQuantity
            BilledAmount
            BilledWithResale
            AccountsReceivablePostPeriodCode
            AccountsReceivableInvoiceNumber
            AccountsReceivableInvoiceType
            UnbilledHours
            UnbilledQuantity
            UnbilledAmount
            UnbilledAmountLessResale
            AdvanceBillFlagDetail
            IsNonBillable
            GlexActBill
            EstimateSuppliedByCode
            EstimateSuppliedBy
            EstimateHours
            EstimateHoursAmount
            EstimateQuantity
            EstimateTotalAmount
            EstimateContTotalAmount
            EstimateNonResaleTaxAmount
            EstimateResaleTaxAmount
            EstimateMarkupAmount
            EstimateCostAmount
            IsEstimateNonBillable
            EstimateFeeTime
            EstimateNetAmount
            PurchaseOrderNumber
            OpenPurchaseOrderAmount
            OpenPurchaseOrderGrossAmount
            IsNewBusiness
            Agency
            BillingApprovalHours
            BillingApprovalCostAmount
            BillingApprovalExtNetAmount
            BillingApprovalTotalAmount
            ProductUDF1
            ProductUDF2
            ProductUDF3
            ProductUDF4
            EmployeeDefaultDepartmentCode
            EmployeeDefaultDepartmentDescription
            EmployeeTimeDepartmentCode
            EmployeeTimeDepartmentDescription
            CompletedDate
            JobProcessControlDate
            DateEntered
            DefaultRoleCode
            DefaultRole
            EmployeeOfficeCode
            EmployeeOfficeDescription
            EmployeeTitle
            IsEmployeeFreelance
            IsActiveFreelance
            EmployeeRateFrom
            ProductCategoryCode
            ProductCategoryDescription
            DirectHoursGoalPercent
            ClientType1Code
            ClientType1Description
            ClientType2Code
            ClientType2Description
            ClientType3Code
            ClientType3Description
            CurrentHours
            CurrentHoursAmount
            CurrentIncomeOnlyCharges
            CurrentVendorCharges
            CurrentTotal
            PriorHours
            PriorHoursAmount
            PriorIncomeOnlyCharges
            PriorVendorCharges
            PriorTotal
            PriorYearHours
            PriorYearHoursAmount
            PriorYearIncomeOnlyCharges
            PriorYearVendorCharges
            PriorYearTotal
            TotalToDateHours
            TotalToDateHoursAmount
            TotalToDateIncomeOnlyCharges
            TotalToDateVendorCharges
            TotalToDate
            EstimateIncomeOnlyCharges
            BilledIncomeOnlyCharges
            AdvanceBilledTotal
            FlatIncomeRecognized
            AdvanceBilledAmount
            AdvanceBillingBalance
            AdvanceBillingRetained
        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _ResourceType As String = Nothing
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
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _BillingBudget As Nullable(Of Decimal) = Nothing
        Private _IncomeBudget As Nullable(Of Decimal) = Nothing
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
        Private _JobComponent As String = Nothing
        Private _BillHold As String = Nothing
        Private _AccountExecutiveCode As String = Nothing
        Private _AccountExecutive As String = Nothing
        Private _ManagerCode As String = Nothing
        Private _Manager As String = Nothing
        Private _ComponentDateOpened As Nullable(Of Date) = Nothing
        Private _DueDate As Nullable(Of Date) = Nothing
        Private _StartDate As Nullable(Of Date) = Nothing
        Private _Status As String = Nothing
        Private _GutPercentComplete As Nullable(Of Decimal) = Nothing
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
        Private _ClientApproved As String = Nothing
        Private _ClientApprovalDate As Nullable(Of Date) = Nothing
        Private _ClientApprovedBy As String = Nothing
        Private _InternallyApproved As String = Nothing
        Private _InternalApprovalDate As Nullable(Of Date) = Nothing
        Private _InternallyApprovedBy As String = Nothing
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
        Private _AccountNumberDescription As String = Nothing
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
        Private _BlackplateVersion2Code As String = Nothing
        Private _BlackplateVersion2Desc As String = Nothing
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
        Private _ItemID As Integer = Nothing
        Private _ItemSequenceNumber As Integer = Nothing
        Private _ItemDate As Nullable(Of Date) = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _ItemCode As String = Nothing
        Private _ItemDescription As String = Nothing
        Private _ItemComment As String = Nothing
        Private _ItemExtra As String = Nothing
        Private _ItemDetailComment As String = Nothing
        Private _Hours As Decimal = Nothing
        Private _Quantity As Decimal = Nothing
        Private _NetAmount As Nullable(Of Decimal) = Nothing
        Private _CostAmount As Nullable(Of Decimal) = Nothing
        Private _ExtMarkupAmount As Decimal = Nothing
        Private _NonResaleTaxAmount As Decimal = Nothing
        Private _ResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _Total As Decimal = Nothing
        Private _BillableLessResale As Nullable(Of Decimal) = Nothing
        Private _BillableTotal As Decimal = Nothing
        Private _FeeTime As Integer = Nothing
        Private _FeeTimeHours As Decimal = Nothing
        Private _FeeTimeAmount As Nullable(Of Decimal) = Nothing
        Private _NonBillableHours As Decimal = Nothing
        Private _NonBillableQuantity As Decimal = Nothing
        Private _NonBillableAmount As Nullable(Of Decimal) = Nothing
        Private _BilledHours As Decimal = Nothing
        Private _BilledQuantity As Decimal = Nothing
        Private _BilledAmount As Nullable(Of Decimal) = Nothing
        Private _BilledWithResale As Decimal = Nothing
        Private _AccountsReceivablePostPeriodCode As String = Nothing
        Private _AccountsReceivableInvoiceNumber As Nullable(Of Integer) = Nothing
        Private _AccountsReceivableInvoiceType As String = Nothing
        Private _UnbilledHours As Decimal = Nothing
        Private _UnbilledQuantity As Decimal = Nothing
        Private _UnbilledAmount As Decimal = Nothing
        Private _UnbilledAmountLessResale As Nullable(Of Decimal) = Nothing
        Private _AdvanceBillFlagDetail As Nullable(Of Integer) = Nothing
        Private _IsNonBillable As Integer = Nothing
        Private _GlexActBill As Nullable(Of Integer) = Nothing
        Private _EstimateSuppliedByCode As String = Nothing
        Private _EstimateSuppliedBy As String = Nothing
        Private _EstimateHours As Decimal = Nothing
        Private _EstimateHoursAmount As Decimal = Nothing
        Private _EstimateQuantity As Decimal = Nothing
        Private _EstimateTotalAmount As Decimal = Nothing
        Private _EstimateContTotalAmount As Decimal = Nothing
        Private _EstimateNonResaleTaxAmount As Decimal = Nothing
        Private _EstimateResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateMarkupAmount As Decimal = Nothing
        Private _EstimateCostAmount As Decimal = Nothing
        Private _IsEstimateNonBillable As Integer = Nothing
        Private _EstimateFeeTime As Integer = Nothing
        Private _EstimateNetAmount As Nullable(Of Decimal) = Nothing
        Private _PurchaseOrderNumber As Integer = Nothing
        Private _OpenPurchaseOrderAmount As Nullable(Of Decimal) = Nothing
        Private _OpenPurchaseOrderGrossAmount As Nullable(Of Decimal) = Nothing
        Private _IsNewBusiness As Nullable(Of Short) = Nothing
        Private _Agency As Integer = Nothing
        Private _BillingApprovalHours As Integer = Nothing
        Private _BillingApprovalCostAmount As Integer = Nothing
        Private _BillingApprovalExtNetAmount As Integer = Nothing
        Private _BillingApprovalTotalAmount As Integer = Nothing
        Private _ProductUDF1 As String = Nothing
        Private _ProductUDF2 As String = Nothing
        Private _ProductUDF3 As String = Nothing
        Private _ProductUDF4 As String = Nothing
        Private _EmployeeDefaultDepartmentCode As String = Nothing
        Private _EmployeeDefaultDepartmentDescription As String = Nothing
        Private _EmployeeTimeDepartmentCode As String = Nothing
        Private _EmployeeTimeDepartmentDescription As String = Nothing
        Private _CompletedDate As Nullable(Of Date) = Nothing
        Private _JobProcessControlDate As Nullable(Of Date) = Nothing
        Private _DateEntered As Nullable(Of Date) = Nothing
        Private _DefaultRoleCode As String = Nothing
        Private _DefaultRole As String = Nothing
        Private _EmployeeOfficeCode As String = Nothing
        Private _EmployeeOfficeDescription As String = Nothing
        Private _EmployeeTitle As String = Nothing
        Private _IsEmployeeFreelance As String = Nothing
        Private _IsActiveFreelance As String = Nothing
        Private _EmployeeRateFrom As String = Nothing
        Private _ProductCategoryCode As String = Nothing
        Private _ProductCategoryDescription As String = Nothing
        Private _DirectHoursGoalPercent As Nullable(Of Decimal) = Nothing
        Private _ClientType1Code As Nullable(Of Integer) = Nothing
        Private _ClientType1Description As String = Nothing
        Private _ClientType2Code As Nullable(Of Integer) = Nothing
        Private _ClientType2Description As String = Nothing
        Private _ClientType3Code As Nullable(Of Integer) = Nothing
        Private _ClientType3Description As String = Nothing
        Private _CurrentHours As Nullable(Of Decimal) = Nothing
        Private _CurrentHoursAmount As Nullable(Of Decimal) = Nothing
        Private _CurrentIncomeOnlyCharges As Nullable(Of Decimal) = Nothing
        Private _CurrentVendorCharges As Nullable(Of Decimal) = Nothing
        Private _CurrentTotal As Nullable(Of Decimal) = Nothing
        Private _PriorHours As Nullable(Of Decimal) = Nothing
        Private _PriorHoursAmount As Nullable(Of Decimal) = Nothing
        Private _PriorIncomeOnlyCharges As Nullable(Of Decimal) = Nothing
        Private _PriorVendorCharges As Nullable(Of Decimal) = Nothing
        Private _PriorTotal As Nullable(Of Decimal) = Nothing
        Private _PriorYearHours As Nullable(Of Decimal) = Nothing
        Private _PriorYearHoursAmount As Nullable(Of Decimal) = Nothing
        Private _PriorYearIncomeOnlyCharges As Nullable(Of Decimal) = Nothing
        Private _PriorYearVendorCharges As Nullable(Of Decimal) = Nothing
        Private _PriorYearTotal As Nullable(Of Decimal) = Nothing
        Private _TotalToDateHours As Nullable(Of Decimal) = Nothing
        Private _TotalToDateHoursAmount As Nullable(Of Decimal) = Nothing
        Private _TotalToDateIncomeOnlyCharges As Nullable(Of Decimal) = Nothing
        Private _TotalToDateVendorCharges As Nullable(Of Decimal) = Nothing
        Private _TotalToDate As Nullable(Of Decimal) = Nothing
        Private _EstimateIncomeOnlyCharges As Nullable(Of Decimal) = Nothing
        Private _BilledIncomeOnlyCharges As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
            Get
                ID = _ID
            End Get
            Set(ByVal value As System.Guid)
                _ID = value
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
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(ByVal value As String)
                _OfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeDescription() As String
            Get
                OfficeDescription = _OfficeDescription
            End Get
            Set(ByVal value As String)
                _OfficeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BillingBudget() As Nullable(Of Decimal)
            Get
                BillingBudget = _BillingBudget
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BillingBudget = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property IncomeBudget() As Nullable(Of Decimal)
            Get
                IncomeBudget = _IncomeBudget
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _IncomeBudget = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ResourceType() As String
            Get
                ResourceType = _ResourceType
            End Get
            Set(ByVal value As String)
                _ResourceType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
            Set(ByVal value As String)
                _UserCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobCreateDate() As Nullable(Of Date)
            Get
                JobCreateDate = _JobCreateDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobCreateDate = value
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
        Public Property JobDateOpened() As Nullable(Of Date)
            Get
                JobDateOpened = _JobDateOpened
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobDateOpened = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RushChargesApproved() As String
            Get
                RushChargesApproved = _RushChargesApproved
            End Get
            Set(ByVal value As String)
                _RushChargesApproved = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovedEstimateRequired() As String
            Get
                ApprovedEstimateRequired = _ApprovedEstimateRequired
            End Get
            Set(ByVal value As String)
                _ApprovedEstimateRequired = value
            End Set
        End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
		Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(ByVal value As String)
                _Comment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientReference() As String
            Get
                ClientReference = _ClientReference
            End Get
            Set(ByVal value As String)
                _ClientReference = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingCoopCode() As String
            Get
                BillingCoopCode = _BillingCoopCode
            End Get
            Set(ByVal value As String)
                _BillingCoopCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassFormatCode() As String
            Get
                SalesClassFormatCode = _SalesClassFormatCode
            End Get
            Set(ByVal value As String)
                _SalesClassFormatCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComplexityCode() As String
            Get
                ComplexityCode = _ComplexityCode
            End Get
            Set(ByVal value As String)
                _ComplexityCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PromotionCode() As String
            Get
                PromotionCode = _PromotionCode
            End Get
            Set(ByVal value As String)
                _PromotionCode = value
            End Set
        End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
		Public Property BillingComment() As String
            Get
                BillingComment = _BillingComment
            End Get
            Set(ByVal value As String)
                _BillingComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelFromUDFTable1() As String
            Get
                LabelFromUDFTable1 = _LabelFromUDFTable1
            End Get
            Set(ByVal value As String)
                _LabelFromUDFTable1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelFromUDFTable2() As String
            Get
                LabelFromUDFTable2 = _LabelFromUDFTable2
            End Get
            Set(ByVal value As String)
                _LabelFromUDFTable2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelFromUDFTable3() As String
            Get
                LabelFromUDFTable3 = _LabelFromUDFTable3
            End Get
            Set(ByVal value As String)
                _LabelFromUDFTable3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelFromUDFTable4() As String
            Get
                LabelFromUDFTable4 = _LabelFromUDFTable4
            End Get
            Set(ByVal value As String)
                _LabelFromUDFTable4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LabelFromUDFTable5() As String
            Get
                LabelFromUDFTable5 = _LabelFromUDFTable5
            End Get
            Set(ByVal value As String)
                _LabelFromUDFTable5 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobOpen() As String
            Get
                JobOpen = _JobOpen
            End Get
            Set(ByVal value As String)
                _JobOpen = value
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
        Public Property BillHold() As String
            Get
                BillHold = _BillHold
            End Get
            Set(ByVal value As String)
                _BillHold = value
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
        Public Property ManagerCode() As String
            Get
                ManagerCode = _ManagerCode
            End Get
            Set(ByVal value As String)
                _ManagerCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Manager() As String
            Get
                Manager = _Manager
            End Get
            Set(ByVal value As String)
                _Manager = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentDateOpened() As Nullable(Of Date)
            Get
                ComponentDateOpened = _ComponentDateOpened
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ComponentDateOpened = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DueDate() As Nullable(Of Date)
            Get
                DueDate = _DueDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _DueDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _StartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Status() As String
            Get
                Status = _Status
            End Get
            Set(ByVal value As String)
                _Status = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property GutPercentComplete() As Nullable(Of Decimal)
            Get
                GutPercentComplete = _GutPercentComplete
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _GutPercentComplete = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdSize() As String
            Get
                AdSize = _AdSize
            End Get
            Set(ByVal value As String)
                _AdSize = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
        Public Property MarkupPercent() As Nullable(Of Decimal)
            Get
                MarkupPercent = _MarkupPercent
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _MarkupPercent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreativeInstructions() As String
            Get
                CreativeInstructions = _CreativeInstructions
            End Get
            Set(ByVal value As String)
                _CreativeInstructions = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobProcessControl() As String
            Get
                JobProcessControl = _JobProcessControl
            End Get
            Set(ByVal value As String)
                _JobProcessControl = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(ByVal value As String)
                _ComponentDescription = value
            End Set
        End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
		Public Property ComponentComments() As String
            Get
                ComponentComments = _ComponentComments
            End Get
            Set(ByVal value As String)
                _ComponentComments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ComponentBudget() As Nullable(Of Decimal)
            Get
                ComponentBudget = _ComponentBudget
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ComponentBudget = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property EstimateNumber() As Nullable(Of Integer)
            Get
                EstimateNumber = _EstimateNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _EstimateNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponentNumber() As Nullable(Of Short)
            Get
                EstimateComponentNumber = _EstimateComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _EstimateComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientApproved() As String
            Get
                ClientApproved = _ClientApproved
            End Get
            Set(ByVal value As String)
                _ClientApproved = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientApprovalDate() As Nullable(Of Date)
            Get
                ClientApprovalDate = _ClientApprovalDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ClientApprovalDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientApprovedBy() As String
            Get
                ClientApprovedBy = _ClientApprovedBy
            End Get
            Set(ByVal value As String)
                _ClientApprovedBy = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternallyApproved() As String
            Get
                InternallyApproved = _InternallyApproved
            End Get
            Set(ByVal value As String)
                _InternallyApproved = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternalApprovalDate() As Nullable(Of Date)
            Get
                InternalApprovalDate = _InternalApprovalDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InternalApprovalDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternallyApprovedBy() As String
            Get
                InternallyApprovedBy = _InternallyApprovedBy
            End Get
            Set(ByVal value As String)
                _InternallyApprovedBy = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingUser() As String
            Get
                BillingUser = _BillingUser
            End Get
            Set(ByVal value As String)
                _BillingUser = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdvanceBillFlag() As String
            Get
                AdvanceBillFlag = _AdvanceBillFlag
            End Get
            Set(ByVal value As String)
                _AdvanceBillFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DeliveryInstructions() As String
            Get
                DeliveryInstructions = _DeliveryInstructions
            End Get
            Set(ByVal value As String)
                _DeliveryInstructions = value
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
        Public Property Taxable() As String
            Get
                Taxable = _Taxable
            End Get
            Set(ByVal value As String)
                _Taxable = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCode() As String
            Get
                TaxCode = _TaxCode
            End Get
            Set(ByVal value As String)
                _TaxCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxCodeDescription() As String
            Get
                TaxCodeDescription = _TaxCodeDescription
            End Get
            Set(ByVal value As String)
                _TaxCodeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NonBillable() As Nullable(Of Short)
            Get
                NonBillable = _NonBillable
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NonBillable = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertGroup() As String
            Get
                AlertGroup = _AlertGroup
            End Get
            Set(ByVal value As String)
                _AlertGroup = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdNumber() As String
            Get
                AdNumber = _AdNumber
            End Get
            Set(ByVal value As String)
                _AdNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountNumber() As String
            Get
                AccountNumber = _AccountNumber
            End Get
            Set(ByVal value As String)
                _AccountNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountNumberDescription() As String
            Get
                AccountNumberDescription = _AccountNumberDescription
            End Get
            Set(ByVal value As String)
                _AccountNumberDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncomeRecognitionMethod() As String
            Get
                IncomeRecognitionMethod = _IncomeRecognitionMethod
            End Get
            Set(ByVal value As String)
                _IncomeRecognitionMethod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarketCode() As String
            Get
                MarketCode = _MarketCode
            End Get
            Set(ByVal value As String)
                _MarketCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarketDescription() As String
            Get
                MarketDescription = _MarketDescription
            End Get
            Set(ByVal value As String)
                _MarketDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ServiceFeeJob() As String
            Get
                ServiceFeeJob = _ServiceFeeJob
            End Get
            Set(ByVal value As String)
                _ServiceFeeJob = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ServiceFeeTypeCode() As String
            Get
                ServiceFeeTypeCode = _ServiceFeeTypeCode
            End Get
            Set(ByVal value As String)
                _ServiceFeeTypeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ServiceFeeTypeDescription() As String
            Get
                ServiceFeeTypeDescription = _ServiceFeeTypeDescription
            End Get
            Set(ByVal value As String)
                _ServiceFeeTypeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Archived() As String
            Get
                Archived = _Archived
            End Get
            Set(ByVal value As String)
                _Archived = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TrafficScheduleRequired() As String
            Get
                TrafficScheduleRequired = _TrafficScheduleRequired
            End Get
            Set(ByVal value As String)
                _TrafficScheduleRequired = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(ByVal value As String)
                _ClientPO = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CompLabelFromUDFTable1() As String
            Get
                CompLabelFromUDFTable1 = _CompLabelFromUDFTable1
            End Get
            Set(ByVal value As String)
                _CompLabelFromUDFTable1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CompLabelFromUDFTable2() As String
            Get
                CompLabelFromUDFTable2 = _CompLabelFromUDFTable2
            End Get
            Set(ByVal value As String)
                _CompLabelFromUDFTable2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CompLabelFromUDFTable3() As String
            Get
                CompLabelFromUDFTable3 = _CompLabelFromUDFTable3
            End Get
            Set(ByVal value As String)
                _CompLabelFromUDFTable3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CompLabelFromUDFTable4() As String
            Get
                CompLabelFromUDFTable4 = _CompLabelFromUDFTable4
            End Get
            Set(ByVal value As String)
                _CompLabelFromUDFTable4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CompLabelFromUDFTable5() As String
            Get
                CompLabelFromUDFTable5 = _CompLabelFromUDFTable5
            End Get
            Set(ByVal value As String)
                _CompLabelFromUDFTable5 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobTemplateCode() As String
            Get
                JobTemplateCode = _JobTemplateCode
            End Get
            Set(ByVal value As String)
                _JobTemplateCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FiscalPeriodCode() As String
            Get
                FiscalPeriodCode = _FiscalPeriodCode
            End Get
            Set(ByVal value As String)
                _FiscalPeriodCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FiscalPeriodDescription() As String
            Get
                FiscalPeriodDescription = _FiscalPeriodDescription
            End Get
            Set(ByVal value As String)
                _FiscalPeriodDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobQuantity() As Nullable(Of Integer)
            Get
                JobQuantity = _JobQuantity
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BlackplateVersionCode() As String
            Get
                BlackplateVersionCode = _BlackplateVersionCode
            End Get
            Set(ByVal value As String)
                _BlackplateVersionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BlackplateVersionDesc() As String
            Get
                BlackplateVersionDesc = _BlackplateVersionDesc
            End Get
            Set(ByVal value As String)
                _BlackplateVersionDesc = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BlackplateVersion2Code() As String
            Get
                BlackplateVersion2Code = _BlackplateVersion2Code
            End Get
            Set(ByVal value As String)
                _BlackplateVersion2Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BlackplateVersion2Desc() As String
            Get
                BlackplateVersion2Desc = _BlackplateVersion2Desc
            End Get
            Set(ByVal value As String)
                _BlackplateVersion2Desc = value
            End Set
        End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientContactCode() As String
			Get
				ClientContactCode = _ClientContactCode
			End Get
			Set(ByVal value As String)
				_ClientContactCode = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property ClientContactID() As Nullable(Of Integer)
			Get
				ClientContactID = _ClientContactID
			End Get
			Set(ByVal value As Nullable(Of Integer))
				_ClientContactID = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property BABatchID() As Nullable(Of Integer)
            Get
                BABatchID = _BABatchID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _BABatchID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContact() As String
            Get
                ClientContact = _ClientContact
            End Get
            Set(ByVal value As String)
                _ClientContact = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property SelectedBABatchID() As Nullable(Of Integer)
            Get
                SelectedBABatchID = _SelectedBABatchID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _SelectedBABatchID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property BillingCommandCenterID() As Nullable(Of Integer)
            Get
                BillingCommandCenterID = _BillingCommandCenterID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _BillingCommandCenterID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertAssignmentTemplate() As String
            Get
                AlertAssignmentTemplate = _AlertAssignmentTemplate
            End Get
            Set(ByVal value As String)
                _AlertAssignmentTemplate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(ByVal value As String)
                _FunctionType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionConsolidationCode() As String
            Get
                FunctionConsolidationCode = _FunctionConsolidationCode
            End Get
            Set(ByVal value As String)
                _FunctionConsolidationCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionConsolidation() As String
            Get
                FunctionConsolidation = _FunctionConsolidation
            End Get
            Set(ByVal value As String)
                _FunctionConsolidation = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionHeading() As String
            Get
                FunctionHeading = _FunctionHeading
            End Get
            Set(ByVal value As String)
                _FunctionHeading = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property ItemID() As Integer
            Get
                ItemID = _ItemID
            End Get
            Set(ByVal value As Integer)
                _ItemID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ItemSequenceNumber() As Integer
            Get
                ItemSequenceNumber = _ItemSequenceNumber
            End Get
            Set(ByVal value As Integer)
                _ItemSequenceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ItemDate() As Nullable(Of Date)
            Get
                ItemDate = _ItemDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ItemDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(ByVal value As String)
                _PostPeriodCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ItemCode() As String
            Get
                ItemCode = _ItemCode
            End Get
            Set(ByVal value As String)
                _ItemCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ItemDescription() As String
            Get
                ItemDescription = _ItemDescription
            End Get
            Set(ByVal value As String)
                _ItemDescription = value
            End Set
        End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
		Public Property ItemComment() As String
            Get
                ItemComment = _ItemComment
            End Get
            Set(ByVal value As String)
                _ItemComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ItemExtra() As String
            Get
                ItemExtra = _ItemExtra
            End Get
            Set(ByVal value As String)
                _ItemExtra = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property ItemDetailComment() As String
            Get
                ItemDetailComment = _ItemDetailComment
            End Get
            Set(ByVal value As String)
                _ItemDetailComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Hours() As Decimal
            Get
                Hours = _Hours
            End Get
            Set(ByVal value As Decimal)
                _Hours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Quantity() As Decimal
            Get
                Quantity = _Quantity
            End Get
            Set(ByVal value As Decimal)
                _Quantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NetAmount() As Nullable(Of Decimal)
            Get
                NetAmount = _NetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CostAmount() As Nullable(Of Decimal)
            Get
                CostAmount = _CostAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CostAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ExtMarkupAmount() As Decimal
            Get
                ExtMarkupAmount = _ExtMarkupAmount
            End Get
            Set(ByVal value As Decimal)
                _ExtMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NonResaleTaxAmount() As Decimal
            Get
                NonResaleTaxAmount = _NonResaleTaxAmount
            End Get
            Set(ByVal value As Decimal)
                _NonResaleTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ResaleTaxAmount() As Nullable(Of Decimal)
            Get
                ResaleTaxAmount = _ResaleTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ResaleTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Total() As Decimal
            Get
                Total = _Total
            End Get
            Set(ByVal value As Decimal)
                _Total = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BillableLessResale() As Nullable(Of Decimal)
            Get
                BillableLessResale = _BillableLessResale
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BillableLessResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BillableTotal() As Decimal
            Get
                BillableTotal = _BillableTotal
            End Get
            Set(ByVal value As Decimal)
                _BillableTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FeeTime() As Integer
            Get
                FeeTime = _FeeTime
            End Get
            Set(ByVal value As Integer)
                _FeeTime = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property FeeTimeHours() As Decimal
            Get
                FeeTimeHours = _FeeTimeHours
            End Get
            Set(ByVal value As Decimal)
                _FeeTimeHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property FeeTimeAmount() As Nullable(Of Decimal)
            Get
                FeeTimeAmount = _FeeTimeAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _FeeTimeAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NonBillableHours() As Decimal
            Get
                NonBillableHours = _NonBillableHours
            End Get
            Set(ByVal value As Decimal)
                _NonBillableHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NonBillableQuantity() As Decimal
            Get
                NonBillableQuantity = _NonBillableQuantity
            End Get
            Set(ByVal value As Decimal)
                _NonBillableQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NonBillableAmount() As Nullable(Of Decimal)
            Get
                NonBillableAmount = _NonBillableAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonBillableAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledHours() As Decimal
            Get
                BilledHours = _BilledHours
            End Get
            Set(ByVal value As Decimal)
                _BilledHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledQuantity() As Decimal
            Get
                BilledQuantity = _BilledQuantity
            End Get
            Set(ByVal value As Decimal)
                _BilledQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledAmount() As Nullable(Of Decimal)
            Get
                BilledAmount = _BilledAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledWithResale() As Decimal
            Get
                BilledWithResale = _BilledWithResale
            End Get
            Set(ByVal value As Decimal)
                _BilledWithResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AdvanceBilledTotal() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property FlatIncomeRecognized() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AdvanceBilledAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property AdvanceBillingBalance() As Nullable(Of Decimal)
            Get
                AdvanceBillingBalance = Me.AdvanceBilledAmount.GetValueOrDefault(0) - Me.FlatIncomeRecognized.GetValueOrDefault(0)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AdvanceBillingRetained() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountsReceivablePostPeriodCode() As String
            Get
                AccountsReceivablePostPeriodCode = _AccountsReceivablePostPeriodCode
            End Get
            Set(ByVal value As String)
                _AccountsReceivablePostPeriodCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property AccountsReceivableInvoiceNumber() As Nullable(Of Integer)
            Get
                AccountsReceivableInvoiceNumber = _AccountsReceivableInvoiceNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _AccountsReceivableInvoiceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountsReceivableInvoiceType() As String
            Get
                AccountsReceivableInvoiceType = _AccountsReceivableInvoiceType
            End Get
            Set(ByVal value As String)
                _AccountsReceivableInvoiceType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property UnbilledHours() As Decimal
            Get
                UnbilledHours = _UnbilledHours
            End Get
            Set(ByVal value As Decimal)
                _UnbilledHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property UnbilledQuantity() As Decimal
            Get
                UnbilledQuantity = _UnbilledQuantity
            End Get
            Set(ByVal value As Decimal)
                _UnbilledQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property UnbilledAmount() As Decimal
            Get
                UnbilledAmount = _UnbilledAmount
            End Get
            Set(ByVal value As Decimal)
                _UnbilledAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property UnbilledAmountLessResale() As Nullable(Of Decimal)
            Get
                UnbilledAmountLessResale = _UnbilledAmountLessResale
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _UnbilledAmountLessResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdvanceBillFlagDetail() As Nullable(Of Integer)
            Get
                AdvanceBillFlagDetail = _AdvanceBillFlagDetail
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _AdvanceBillFlagDetail = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsNonBillable() As Integer
            Get
                IsNonBillable = _IsNonBillable
            End Get
            Set(ByVal value As Integer)
                _IsNonBillable = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="GLXACT Bill")>
        Public Property GlexActBill() As Nullable(Of Integer)
            Get
                GlexActBill = _GlexActBill
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _GlexActBill = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateSuppliedByCode() As String
            Get
                EstimateSuppliedByCode = _EstimateSuppliedByCode
            End Get
            Set(ByVal value As String)
                _EstimateSuppliedByCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateSuppliedBy() As String
            Get
                EstimateSuppliedBy = _EstimateSuppliedBy
            End Get
            Set(ByVal value As String)
                _EstimateSuppliedBy = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateHours() As Decimal
            Get
                EstimateHours = _EstimateHours
            End Get
            Set(ByVal value As Decimal)
                _EstimateHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateHoursAmount() As Decimal
            Get
                EstimateHoursAmount = _EstimateHoursAmount
            End Get
            Set(ByVal value As Decimal)
                _EstimateHoursAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateQuantity() As Decimal
            Get
                EstimateQuantity = _EstimateQuantity
            End Get
            Set(ByVal value As Decimal)
                _EstimateQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateTotalAmount() As Decimal
            Get
                EstimateTotalAmount = _EstimateTotalAmount
            End Get
            Set(ByVal value As Decimal)
                _EstimateTotalAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateContTotalAmount() As Decimal
            Get
                EstimateContTotalAmount = _EstimateContTotalAmount
            End Get
            Set(ByVal value As Decimal)
                _EstimateContTotalAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateNonResaleTaxAmount() As Decimal
            Get
                EstimateNonResaleTaxAmount = _EstimateNonResaleTaxAmount
            End Get
            Set(ByVal value As Decimal)
                _EstimateNonResaleTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateResaleTaxAmount() As Nullable(Of Decimal)
            Get
                EstimateResaleTaxAmount = _EstimateResaleTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateResaleTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateMarkupAmount() As Decimal
            Get
                EstimateMarkupAmount = _EstimateMarkupAmount
            End Get
            Set(ByVal value As Decimal)
                _EstimateMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateCostAmount() As Decimal
            Get
                EstimateCostAmount = _EstimateCostAmount
            End Get
            Set(ByVal value As Decimal)
                _EstimateCostAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsEstimateNonBillable() As Integer
            Get
                IsEstimateNonBillable = _IsEstimateNonBillable
            End Get
            Set(ByVal value As Integer)
                _IsEstimateNonBillable = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateFeeTime() As Integer
            Get
                EstimateFeeTime = _EstimateFeeTime
            End Get
            Set(ByVal value As Integer)
                _EstimateFeeTime = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateNetAmount() As Nullable(Of Decimal)
            Get
                EstimateNetAmount = _EstimateNetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property PurchaseOrderNumber() As Integer
            Get
                PurchaseOrderNumber = _PurchaseOrderNumber
            End Get
            Set(ByVal value As Integer)
                _PurchaseOrderNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OpenPurchaseOrderAmount() As Nullable(Of Decimal)
            Get
                OpenPurchaseOrderAmount = _OpenPurchaseOrderAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OpenPurchaseOrderAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OpenPurchaseOrderGrossAmount() As Nullable(Of Decimal)
            Get
                OpenPurchaseOrderGrossAmount = _OpenPurchaseOrderGrossAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OpenPurchaseOrderGrossAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsNewBusiness() As Nullable(Of Short)
            Get
                IsNewBusiness = _IsNewBusiness
            End Get
            Set(ByVal value As Nullable(Of Short))
                _IsNewBusiness = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Agency() As Integer
            Get
                Agency = _Agency
            End Get
            Set(ByVal value As Integer)
                _Agency = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingApprovalHours() As Integer
            Get
                BillingApprovalHours = _BillingApprovalHours
            End Get
            Set(ByVal value As Integer)
                _BillingApprovalHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingApprovalCostAmount() As Integer
            Get
                BillingApprovalCostAmount = _BillingApprovalCostAmount
            End Get
            Set(ByVal value As Integer)
                _BillingApprovalCostAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingApprovalExtNetAmount() As Integer
            Get
                BillingApprovalExtNetAmount = _BillingApprovalExtNetAmount
            End Get
            Set(ByVal value As Integer)
                _BillingApprovalExtNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillingApprovalTotalAmount() As Integer
            Get
                BillingApprovalTotalAmount = _BillingApprovalTotalAmount
            End Get
            Set(ByVal value As Integer)
                _BillingApprovalTotalAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF1() As String
            Get
                ProductUDF1 = _ProductUDF1
            End Get
            Set(ByVal value As String)
                _ProductUDF1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF2() As String
            Get
                ProductUDF2 = _ProductUDF2
            End Get
            Set(ByVal value As String)
                _ProductUDF2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF3() As String
            Get
                ProductUDF3 = _ProductUDF3
            End Get
            Set(ByVal value As String)
                _ProductUDF3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductUDF4() As String
            Get
                ProductUDF4 = _ProductUDF4
            End Get
            Set(ByVal value As String)
                _ProductUDF4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeDefaultDepartmentCode() As String
            Get
                EmployeeDefaultDepartmentCode = _EmployeeDefaultDepartmentCode
            End Get
            Set(ByVal value As String)
                _EmployeeDefaultDepartmentCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeDefaultDepartmentDescription() As String
            Get
                EmployeeDefaultDepartmentDescription = _EmployeeDefaultDepartmentDescription
            End Get
            Set(ByVal value As String)
                _EmployeeDefaultDepartmentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeDepartmentCode() As String
            Get
                EmployeeTimeDepartmentCode = _EmployeeTimeDepartmentCode
            End Get
            Set(ByVal value As String)
                _EmployeeTimeDepartmentCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeTimeDepartmentDescription() As String
            Get
                EmployeeTimeDepartmentDescription = _EmployeeTimeDepartmentDescription
            End Get
            Set(ByVal value As String)
                _EmployeeTimeDepartmentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CompletedDate() As Date?
            Get
                CompletedDate = _CompletedDate
            End Get
            Set(ByVal value As Date?)
                _CompletedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobProcessControlDate() As Date?
            Get
                JobProcessControlDate = _JobProcessControlDate
            End Get
            Set(ByVal value As Date?)
                _JobProcessControlDate = value
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
        Public Property EmployeeOfficeCode() As String
            Get
                EmployeeOfficeCode = _EmployeeOfficeCode
            End Get
            Set(ByVal value As String)
                _EmployeeOfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeOfficeDescription() As String
            Get
                EmployeeOfficeDescription = _EmployeeOfficeDescription
            End Get
            Set(ByVal value As String)
                _EmployeeOfficeDescription = value
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
            Set(ByVal value As String)
                _IsActiveFreelance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeRateFrom() As String
            Get
                EmployeeRateFrom = _EmployeeRateFrom
            End Get
            Set(ByVal value As String)
                _EmployeeRateFrom = value
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
        Public Property DirectHoursGoalPercent() As Nullable(Of Decimal)
            Get
                DirectHoursGoalPercent = _DirectHoursGoalPercent
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _DirectHoursGoalPercent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Client Type 1 Code")>
        Public Property ClientType1Code() As Nullable(Of Integer)
            Get
                ClientType1Code = _ClientType1Code
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ClientType1Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 1 Description")>
        Public Property ClientType1Description() As String
            Get
                ClientType1Description = _ClientType1Description
            End Get
            Set(ByVal value As String)
                _ClientType1Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Client Type 2 Code")>
        Public Property ClientType2Code() As Nullable(Of Integer)
            Get
                ClientType2Code = _ClientType2Code
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ClientType2Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 2 Description")>
        Public Property ClientType2Description() As String
            Get
                ClientType2Description = _ClientType2Description
            End Get
            Set(ByVal value As String)
                _ClientType2Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Client Type 3 Code")>
        Public Property ClientType3Code() As Nullable(Of Integer)
            Get
                ClientType3Code = _ClientType3Code
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ClientType3Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 3 Description")>
        Public Property ClientType3Description() As String
            Get
                ClientType3Description = _ClientType3Description
            End Get
            Set(ByVal value As String)
                _ClientType3Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentHours() As Nullable(Of Decimal)
            Get
                CurrentHours = _CurrentHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentHoursAmount() As Nullable(Of Decimal)
            Get
                CurrentHoursAmount = _CurrentHoursAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentHoursAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentIncomeOnlyCharges() As Nullable(Of Decimal)
            Get
                CurrentIncomeOnlyCharges = _CurrentIncomeOnlyCharges
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentIncomeOnlyCharges = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentVendorCharges() As Nullable(Of Decimal)
            Get
                CurrentVendorCharges = _CurrentVendorCharges
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentVendorCharges = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentTotal() As Nullable(Of Decimal)
            Get
                CurrentTotal = _CurrentTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorHours() As Nullable(Of Decimal)
            Get
                PriorHours = _PriorHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorHoursAmount() As Nullable(Of Decimal)
            Get
                PriorHoursAmount = _PriorHoursAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorHoursAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorIncomeOnlyCharges() As Nullable(Of Decimal)
            Get
                PriorIncomeOnlyCharges = _PriorIncomeOnlyCharges
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorIncomeOnlyCharges = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorVendorCharges() As Nullable(Of Decimal)
            Get
                PriorVendorCharges = _PriorVendorCharges
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorVendorCharges = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorTotal() As Nullable(Of Decimal)
            Get
                PriorTotal = _PriorTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorYearHours() As Nullable(Of Decimal)
            Get
                PriorYearHours = _PriorYearHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorYearHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorYearHoursAmount() As Nullable(Of Decimal)
            Get
                PriorYearHoursAmount = _PriorYearHoursAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorYearHoursAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorYearIncomeOnlyCharges() As Nullable(Of Decimal)
            Get
                PriorYearIncomeOnlyCharges = _PriorYearIncomeOnlyCharges
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorYearIncomeOnlyCharges = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorYearVendorCharges() As Nullable(Of Decimal)
            Get
                PriorYearVendorCharges = _PriorYearVendorCharges
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorYearVendorCharges = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorYearTotal() As Nullable(Of Decimal)
            Get
                PriorYearTotal = _PriorYearTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorYearTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property TotalToDateHours() As Nullable(Of Decimal)
            Get
                TotalToDateHours = _TotalToDateHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalToDateHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property TotalToDateHoursAmount() As Nullable(Of Decimal)
            Get
                TotalToDateHoursAmount = _TotalToDateHoursAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalToDateHoursAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property TotalToDateIncomeOnlyCharges() As Nullable(Of Decimal)
            Get
                TotalToDateIncomeOnlyCharges = _TotalToDateIncomeOnlyCharges
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalToDateIncomeOnlyCharges = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property TotalToDateVendorCharges() As Nullable(Of Decimal)
            Get
                TotalToDateVendorCharges = _TotalToDateVendorCharges
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalToDateVendorCharges = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property TotalToDate() As Nullable(Of Decimal)
            Get
                TotalToDate = _TotalToDate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalToDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateIncomeOnlyCharges() As Nullable(Of Decimal)
            Get
                EstimateIncomeOnlyCharges = _EstimateIncomeOnlyCharges
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateIncomeOnlyCharges = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledIncomeOnlyCharges() As Nullable(Of Decimal)
            Get
                BilledIncomeOnlyCharges = _BilledIncomeOnlyCharges
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledIncomeOnlyCharges = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComplexityDescription() As String
            Get
                ComplexityDescription = _ComplexityDescription
            End Get
            Set(ByVal value As String)
                _ComplexityDescription = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(JobDetailItemData As JobDetailItemData)

            'Me.ID = JobDetailItemData.ID
            Me.ResourceType = JobDetailItemData.ResourceType
            Me.JobNumber = JobDetailItemData.JobNumber
            Me.JobComponentNumber = JobDetailItemData.JobComponentNumber
            Me.OfficeCode = JobDetailItemData.OfficeCode
            Me.OfficeDescription = JobDetailItemData.OfficeDescription
            Me.ClientCode = JobDetailItemData.ClientCode
            Me.ClientDescription = JobDetailItemData.ClientDescription
            Me.DivisionCode = JobDetailItemData.DivisionCode
            Me.DivisionDescription = JobDetailItemData.DivisionDescription
            Me.ProductCode = JobDetailItemData.ProductCode
            Me.ProductDescription = JobDetailItemData.ProductDescription
            Me.CampaignID = JobDetailItemData.CampaignID
            Me.CampaignCode = JobDetailItemData.CampaignCode
            Me.CampaignName = JobDetailItemData.CampaignName
            Me.BillingBudget = JobDetailItemData.BillingBudget
            Me.IncomeBudget = JobDetailItemData.IncomeBudget
            Me.SalesClassCode = JobDetailItemData.SalesClassCode
            Me.SalesClassDescription = JobDetailItemData.SalesClassDescription
            Me.UserCode = JobDetailItemData.UserCode
            Me.JobCreateDate = JobDetailItemData.JobCreateDate
            Me.JobDescription = JobDetailItemData.JobDescription
            Me.JobDateOpened = JobDetailItemData.JobDateOpened
            Me.RushChargesApproved = JobDetailItemData.RushChargesApproved
            Me.ApprovedEstimateRequired = JobDetailItemData.ApprovedEstimateRequired
            Me.Comment = JobDetailItemData.Comment
            Me.ClientReference = JobDetailItemData.ClientReference
            Me.BillingCoopCode = JobDetailItemData.BillingCoopCode
            Me.SalesClassFormatCode = JobDetailItemData.SalesClassFormatCode
            Me.ComplexityCode = JobDetailItemData.ComplexityCode
            Me.ComplexityDescription = JobDetailItemData.ComplexityDescription
            Me.PromotionCode = JobDetailItemData.PromotionCode
            Me.BillingComment = JobDetailItemData.BillingComment
            Me.LabelFromUDFTable1 = JobDetailItemData.LabelFromUDFTable1
            Me.LabelFromUDFTable2 = JobDetailItemData.LabelFromUDFTable2
            Me.LabelFromUDFTable3 = JobDetailItemData.LabelFromUDFTable3
            Me.LabelFromUDFTable4 = JobDetailItemData.LabelFromUDFTable4
            Me.LabelFromUDFTable5 = JobDetailItemData.LabelFromUDFTable5
            Me.JobOpen = JobDetailItemData.JobOpen
            Me.JobComponent = JobDetailItemData.JobComponent
            Me.BillHold = JobDetailItemData.BillHold
            Me.AccountExecutiveCode = JobDetailItemData.AccountExecutiveCode
            Me.AccountExecutive = JobDetailItemData.AccountExecutive
            Me.ManagerCode = JobDetailItemData.ManagerCode
            Me.Manager = JobDetailItemData.Manager
            Me.ComponentDateOpened = JobDetailItemData.ComponentDateOpened
            Me.DueDate = JobDetailItemData.DueDate
            Me.StartDate = JobDetailItemData.StartDate
            Me.Status = JobDetailItemData.Status
            Me.GutPercentComplete = JobDetailItemData.GutPercentComplete
            Me.AdSize = JobDetailItemData.AdSize
            Me.DepartmentTeamCode = JobDetailItemData.DepartmentTeamCode
            Me.DepartmentTeam = JobDetailItemData.DepartmentTeam
            Me.MarkupPercent = JobDetailItemData.MarkupPercent
            Me.CreativeInstructions = JobDetailItemData.CreativeInstructions
            Me.JobProcessControl = JobDetailItemData.JobProcessControl
            Me.ComponentDescription = JobDetailItemData.ComponentDescription
            Me.ComponentComments = JobDetailItemData.ComponentComments
            Me.ComponentBudget = JobDetailItemData.ComponentBudget
            Me.EstimateNumber = JobDetailItemData.EstimateNumber
            Me.EstimateComponentNumber = JobDetailItemData.EstimateComponentNumber
            Me.ClientApproved = JobDetailItemData.ClientApproved
            Me.ClientApprovalDate = JobDetailItemData.ClientApprovalDate
            Me.ClientApprovedBy = JobDetailItemData.ClientApprovedBy
            Me.InternallyApproved = JobDetailItemData.InternallyApproved
            Me.InternalApprovalDate = JobDetailItemData.InternalApprovalDate
            Me.InternallyApprovedBy = JobDetailItemData.InternallyApprovedBy
            Me.BillingUser = JobDetailItemData.BillingUser
            Me.AdvanceBillFlag = JobDetailItemData.AdvanceBillFlag
            Me.DeliveryInstructions = JobDetailItemData.DeliveryInstructions
            Me.JobTypeCode = JobDetailItemData.JobTypeCode
            Me.JobTypeDescription = JobDetailItemData.JobTypeDescription
            Me.Taxable = JobDetailItemData.Taxable
            Me.TaxCode = JobDetailItemData.TaxCode
            Me.TaxCodeDescription = JobDetailItemData.TaxCodeDescription
            Me.NonBillable = JobDetailItemData.NonBillable
            Me.AlertGroup = JobDetailItemData.AlertGroup
            Me.AdNumber = JobDetailItemData.AdNumber
            Me.AccountNumber = JobDetailItemData.AccountNumber
            Me.AccountNumberDescription = JobDetailItemData.AccountNumberDescription
            Me.IncomeRecognitionMethod = JobDetailItemData.IncomeRecognitionMethod
            Me.MarketCode = JobDetailItemData.MarketCode
            Me.MarketDescription = JobDetailItemData.MarketDescription
            Me.ServiceFeeJob = JobDetailItemData.ServiceFeeJob
            Me.ServiceFeeTypeCode = JobDetailItemData.ServiceFeeTypeCode
            Me.ServiceFeeTypeDescription = JobDetailItemData.ServiceFeeTypeDescription
            Me.Archived = JobDetailItemData.Archived
            Me.TrafficScheduleRequired = JobDetailItemData.TrafficScheduleRequired
            Me.ClientPO = JobDetailItemData.ClientPO
            Me.CompLabelFromUDFTable1 = JobDetailItemData.CompLabelFromUDFTable1
            Me.CompLabelFromUDFTable2 = JobDetailItemData.CompLabelFromUDFTable2
            Me.CompLabelFromUDFTable3 = JobDetailItemData.CompLabelFromUDFTable3
            Me.CompLabelFromUDFTable4 = JobDetailItemData.CompLabelFromUDFTable4
            Me.CompLabelFromUDFTable5 = JobDetailItemData.CompLabelFromUDFTable5
            Me.JobTemplateCode = JobDetailItemData.JobTemplateCode
            Me.FiscalPeriodCode = JobDetailItemData.FiscalPeriodCode
            Me.FiscalPeriodDescription = JobDetailItemData.FiscalPeriodDescription
            Me.JobQuantity = JobDetailItemData.JobQuantity
            Me.BlackplateVersionCode = JobDetailItemData.BlackplateVersionCode
            Me.BlackplateVersionDesc = JobDetailItemData.BlackplateVersionDesc
            Me.BlackplateVersion2Code = JobDetailItemData.BlackplateVersion2Code
            Me.BlackplateVersion2Desc = JobDetailItemData.BlackplateVersion2Desc
            Me.ClientContactCode = JobDetailItemData.ClientContactCode
            Me.ClientContactID = JobDetailItemData.ClientContactID
            Me.BABatchID = JobDetailItemData.BABatchID
            Me.ClientContact = JobDetailItemData.ClientContact
            Me.SelectedBABatchID = JobDetailItemData.SelectedBABatchID
            Me.BillingCommandCenterID = JobDetailItemData.BillingCommandCenterID
            Me.AlertAssignmentTemplate = JobDetailItemData.AlertAssignmentTemplate
            Me.FunctionType = JobDetailItemData.FunctionType
            Me.FunctionConsolidationCode = JobDetailItemData.FunctionConsolidationCode
            Me.FunctionConsolidation = JobDetailItemData.FunctionConsolidation
            Me.FunctionHeading = JobDetailItemData.FunctionHeading
            Me.FunctionCode = JobDetailItemData.FunctionCode
            Me.FunctionDescription = JobDetailItemData.FunctionDescription
            Me.ItemID = JobDetailItemData.ItemID.GetValueOrDefault(0)
            Me.ItemSequenceNumber = JobDetailItemData.ItemSequenceNumber.GetValueOrDefault(0)
            Me.ItemDate = JobDetailItemData.ItemDate
            Me.PostPeriodCode = JobDetailItemData.PostPeriodCode
            Me.ItemCode = JobDetailItemData.ItemCode
            Me.ItemDescription = JobDetailItemData.ItemDescription
            Me.ItemComment = JobDetailItemData.ItemComment
            Me.ItemExtra = JobDetailItemData.ItemExtra
            Me.ItemDetailComment = JobDetailItemData.ItemDetailComment
            Me.Hours = JobDetailItemData.Hours.GetValueOrDefault(0)
            Me.Quantity = JobDetailItemData.Quantity.GetValueOrDefault(0)
            Me.NetAmount = JobDetailItemData.NetAmount.GetValueOrDefault(0)
            Me.CostAmount = JobDetailItemData.CostAmount.GetValueOrDefault(0)
            Me.ExtMarkupAmount = JobDetailItemData.ExtMarkupAmount.GetValueOrDefault(0)
            Me.NonResaleTaxAmount = JobDetailItemData.NonResaleTaxAmount.GetValueOrDefault(0)
            Me.ResaleTaxAmount = JobDetailItemData.ResaleTaxAmount.GetValueOrDefault(0)
            Me.Total = JobDetailItemData.Total.GetValueOrDefault(0)
            Me.BillableLessResale = JobDetailItemData.BillableLessResale.GetValueOrDefault(0)
            Me.BillableTotal = JobDetailItemData.BillableTotal.GetValueOrDefault(0)
            Me.FeeTime = JobDetailItemData.FeeTime.GetValueOrDefault(0)
            Me.FeeTimeHours = JobDetailItemData.FeeTimeHours.GetValueOrDefault(0)
            Me.FeeTimeAmount = JobDetailItemData.FeeTimeAmount.GetValueOrDefault(0)
            Me.NonBillableHours = JobDetailItemData.NonBillableHours.GetValueOrDefault(0)
            Me.NonBillableQuantity = JobDetailItemData.NonBillableQuantity.GetValueOrDefault(0)
            Me.NonBillableAmount = JobDetailItemData.NonBillableAmount.GetValueOrDefault(0)
            Me.BilledHours = JobDetailItemData.BilledHours.GetValueOrDefault(0)
            Me.BilledQuantity = JobDetailItemData.BilledQuantity.GetValueOrDefault(0)
            Me.BilledAmount = JobDetailItemData.BilledAmount.GetValueOrDefault(0)
            Me.BilledWithResale = JobDetailItemData.BilledWithResale.GetValueOrDefault(0)
            Me.AccountsReceivablePostPeriodCode = JobDetailItemData.AccountsReceivablePostPeriodCode
            Me.AccountsReceivableInvoiceNumber = JobDetailItemData.AccountsReceivableInvoiceNumber
            Me.AccountsReceivableInvoiceType = JobDetailItemData.AccountsReceivableInvoiceType
            Me.UnbilledHours = JobDetailItemData.UnbilledHours.GetValueOrDefault(0)
            Me.UnbilledQuantity = JobDetailItemData.UnbilledQuantity.GetValueOrDefault(0)
            Me.UnbilledAmount = JobDetailItemData.UnbilledAmount.GetValueOrDefault(0)
            Me.UnbilledAmountLessResale = JobDetailItemData.UnbilledAmountLessResale.GetValueOrDefault(0)
            Me.AdvanceBillFlagDetail = JobDetailItemData.AdvanceBillFlagDetail
            Me.IsNonBillable = JobDetailItemData.IsNonBillable.GetValueOrDefault(0)
            Me.GlexActBill = JobDetailItemData.GlexActBill
            Me.EstimateSuppliedByCode = JobDetailItemData.EstimateSuppliedByCode
            Me.EstimateSuppliedBy = JobDetailItemData.EstimateSuppliedBy
            Me.EstimateHours = JobDetailItemData.EstimateHours.GetValueOrDefault(0)
            Me.EstimateHoursAmount = JobDetailItemData.EstimateHoursAmount.GetValueOrDefault(0)
            Me.EstimateQuantity = JobDetailItemData.EstimateQuantity.GetValueOrDefault(0)
            Me.EstimateTotalAmount = JobDetailItemData.EstimateTotalAmount.GetValueOrDefault(0)
            Me.EstimateContTotalAmount = JobDetailItemData.EstimateContTotalAmount.GetValueOrDefault(0)
            Me.EstimateNonResaleTaxAmount = JobDetailItemData.EstimateNonResaleTaxAmount.GetValueOrDefault(0)
            Me.EstimateResaleTaxAmount = JobDetailItemData.EstimateResaleTaxAmount.GetValueOrDefault(0)
            Me.EstimateMarkupAmount = JobDetailItemData.EstimateMarkupAmount.GetValueOrDefault(0)
            Me.EstimateCostAmount = JobDetailItemData.EstimateCostAmount.GetValueOrDefault(0)
            Me.IsEstimateNonBillable = JobDetailItemData.IsEstimateNonBillable.GetValueOrDefault(0)
            Me.EstimateFeeTime = JobDetailItemData.EstimateFeeTime.GetValueOrDefault(0)
            Me.EstimateNetAmount = JobDetailItemData.EstimateNetAmount.GetValueOrDefault(0)
            Me.PurchaseOrderNumber = JobDetailItemData.PurchaseOrderNumber.GetValueOrDefault(0)
            Me.OpenPurchaseOrderAmount = JobDetailItemData.OpenPurchaseOrderAmount.GetValueOrDefault(0)
            Me.OpenPurchaseOrderGrossAmount = JobDetailItemData.OpenPurchaseOrderGrossAmount.GetValueOrDefault(0)
            Me.IsNewBusiness = JobDetailItemData.IsNewBusiness
            Me.Agency = JobDetailItemData.Agency.GetValueOrDefault(0)
            Me.BillingApprovalHours = JobDetailItemData.BillingApprovalHours.GetValueOrDefault(0)
            Me.BillingApprovalCostAmount = JobDetailItemData.BillingApprovalCostAmount.GetValueOrDefault(0)
            Me.BillingApprovalExtNetAmount = JobDetailItemData.BillingApprovalExtNetAmount.GetValueOrDefault(0)
            Me.BillingApprovalTotalAmount = JobDetailItemData.BillingApprovalTotalAmount.GetValueOrDefault(0)
            Me.ProductUDF1 = JobDetailItemData.ProductUDF1
            Me.ProductUDF2 = JobDetailItemData.ProductUDF2
            Me.ProductUDF3 = JobDetailItemData.ProductUDF3
            Me.ProductUDF4 = JobDetailItemData.ProductUDF4
            Me.EmployeeDefaultDepartmentCode = JobDetailItemData.EmployeeDefaultDepartmentCode
            Me.EmployeeDefaultDepartmentDescription = JobDetailItemData.EmployeeDefaultDepartmentDescription
            Me.EmployeeTimeDepartmentCode = JobDetailItemData.EmployeeTimeDepartmentCode
            Me.EmployeeTimeDepartmentDescription = JobDetailItemData.EmployeeTimeDepartmentDescription
            Me.CompletedDate = JobDetailItemData.CompletedDate
            Me.JobProcessControlDate = JobDetailItemData.JobProcessControlDate
            Me.DateEntered = JobDetailItemData.DateEntered
            Me.DefaultRoleCode = JobDetailItemData.DefaultRoleCode
            Me.DefaultRole = JobDetailItemData.DefaultRole
            Me.EmployeeOfficeCode = JobDetailItemData.EmployeeOfficeCode
            Me.EmployeeOfficeDescription = JobDetailItemData.EmployeeOfficeDescription
            Me.EmployeeTitle = JobDetailItemData.EmployeeTitle
            Me.IsEmployeeFreelance = JobDetailItemData.IsEmployeeFreelance
            Me.IsActiveFreelance = JobDetailItemData.IsActiveFreelance
            Me.EmployeeRateFrom = JobDetailItemData.EmployeeRateFrom
            Me.ProductCategoryCode = JobDetailItemData.ProductCategoryCode
            Me.ProductCategoryDescription = JobDetailItemData.ProductCategoryDescription
            Me.DirectHoursGoalPercent = JobDetailItemData.DirectHoursGoalPercent
            Me.ClientType1Code = JobDetailItemData.ClientType1Code
            Me.ClientType1Description = JobDetailItemData.ClientType1Description
            Me.ClientType2Code = JobDetailItemData.ClientType2Code
            Me.ClientType2Description = JobDetailItemData.ClientType2Description
            Me.ClientType3Code = JobDetailItemData.ClientType3Code
            Me.ClientType3Description = JobDetailItemData.ClientType3Description
            Me.CurrentHours = JobDetailItemData.CurrentHours
            Me.CurrentHoursAmount = JobDetailItemData.CurrentHoursAmount
            Me.CurrentIncomeOnlyCharges = JobDetailItemData.CurrentIncomeOnlyCharges
            Me.CurrentVendorCharges = JobDetailItemData.CurrentVendorCharges
            Me.CurrentTotal = JobDetailItemData.CurrentTotal
            Me.PriorHours = JobDetailItemData.PriorHours
            Me.PriorHoursAmount = JobDetailItemData.PriorHoursAmount
            Me.PriorIncomeOnlyCharges = JobDetailItemData.PriorIncomeOnlyCharges
            Me.PriorVendorCharges = JobDetailItemData.PriorVendorCharges
            Me.PriorTotal = JobDetailItemData.PriorTotal
            Me.PriorYearHours = JobDetailItemData.PriorYearHours
            Me.PriorYearHoursAmount = JobDetailItemData.PriorYearHoursAmount
            Me.PriorYearIncomeOnlyCharges = JobDetailItemData.PriorYearIncomeOnlyCharges
            Me.PriorYearVendorCharges = JobDetailItemData.PriorYearVendorCharges
            Me.PriorYearTotal = JobDetailItemData.PriorYearTotal
            Me.TotalToDateHours = JobDetailItemData.TotalToDateHours
            Me.TotalToDateHoursAmount = JobDetailItemData.TotalToDateHoursAmount
            Me.TotalToDateIncomeOnlyCharges = JobDetailItemData.TotalToDateIncomeOnlyCharges
            Me.TotalToDateVendorCharges = JobDetailItemData.TotalToDateVendorCharges
            Me.TotalToDate = JobDetailItemData.TotalToDate
            Me.EstimateIncomeOnlyCharges = JobDetailItemData.EstimateIncomeOnlyCharges
            Me.BilledIncomeOnlyCharges = JobDetailItemData.BilledIncomeOnlyCharges
            Me.AdvanceBilledTotal = JobDetailItemData.AdvanceBilledTotal
            Me.FlatIncomeRecognized = JobDetailItemData.FlatIncomeRecognized
            Me.AdvanceBilledAmount = JobDetailItemData.AdvanceBilledAmount
            Me.AdvanceBillingRetained = JobDetailItemData.AdvanceBillingRetained

        End Sub
        'Public Sub New(ByVal JobDetailItem As AdvantageFramework.Database.Views.JobDetailItemAB)

        '    Me.ID = JobDetailItem.ID
        '    Me.ResourceType = JobDetailItem.ResourceType
        '    Me.JobNumber = JobDetailItem.JobNumber
        '    Me.JobComponentNumber = JobDetailItem.JobComponentNumber
        '    Me.OfficeCode = JobDetailItem.OfficeCode
        '    Me.OfficeDescription = JobDetailItem.OfficeDescription
        '    Me.ClientCode = JobDetailItem.ClientCode
        '    Me.ClientDescription = JobDetailItem.ClientDescription
        '    Me.DivisionCode = JobDetailItem.DivisionCode
        '    Me.DivisionDescription = JobDetailItem.DivisionDescription
        '    Me.ProductCode = JobDetailItem.ProductCode
        '    Me.ProductDescription = JobDetailItem.ProductDescription
        '    Me.CampaignID = JobDetailItem.CampaignID
        '    Me.CampaignCode = JobDetailItem.CampaignCode
        '    Me.CampaignName = JobDetailItem.CampaignName
        '    Me.SalesClassCode = JobDetailItem.SalesClassCode
        '    Me.SalesClassDescription = JobDetailItem.SalesClassDescription
        '    Me.UserCode = JobDetailItem.UserCode
        '    Me.JobCreateDate = JobDetailItem.JobCreateDate
        '    Me.JobDescription = JobDetailItem.JobDescription
        '    Me.JobDateOpened = JobDetailItem.JobDateOpened
        '    Me.RushChargesApproved = JobDetailItem.RushChargesApproved
        '    Me.ApprovedEstimateRequired = JobDetailItem.ApprovedEstimateRequired
        '    Me.Comment = JobDetailItem.Comment
        '    Me.ClientReference = JobDetailItem.ClientReference
        '    Me.BillingCoopCode = JobDetailItem.BillingCoopCode
        '    Me.SalesClassFormatCode = JobDetailItem.SalesClassFormatCode
        '    Me.ComplexityCode = JobDetailItem.ComplexityCode
        '    Me.PromotionCode = JobDetailItem.PromotionCode
        '    Me.BillingComment = JobDetailItem.BillingComment
        '    Me.LabelFromUDFTable1 = JobDetailItem.LabelFromUDFTable1
        '    Me.LabelFromUDFTable2 = JobDetailItem.LabelFromUDFTable2
        '    Me.LabelFromUDFTable3 = JobDetailItem.LabelFromUDFTable3
        '    Me.LabelFromUDFTable4 = JobDetailItem.LabelFromUDFTable4
        '    Me.LabelFromUDFTable5 = JobDetailItem.LabelFromUDFTable5
        '    Me.JobOpen = JobDetailItem.JobOpen
        '    Me.JobComponent = JobDetailItem.JobComponent
        '    Me.BillHold = JobDetailItem.BillHold
        '    Me.AccountExecutiveCode = JobDetailItem.AccountExecutiveCode
        '    Me.AccountExecutive = JobDetailItem.AccountExecutive
        '    Me.ComponentDateOpened = JobDetailItem.ComponentDateOpened
        '    Me.DueDate = JobDetailItem.DueDate
        '    Me.StartDate = JobDetailItem.StartDate
        '    Me.AdSize = JobDetailItem.AdSize
        '    Me.DepartmentTeamCode = JobDetailItem.DepartmentTeamCode
        '    Me.DepartmentTeam = JobDetailItem.DepartmentTeam
        '    Me.MarkupPercent = JobDetailItem.MarkupPercent
        '    Me.CreativeInstructions = JobDetailItem.CreativeInstructions
        '    Me.JobProcessControl = JobDetailItem.JobProcessControl
        '    Me.ComponentDescription = JobDetailItem.ComponentDescription
        '    Me.ComponentComments = JobDetailItem.ComponentComments
        '    Me.ComponentBudget = JobDetailItem.ComponentBudget
        '    Me.EstimateNumber = JobDetailItem.EstimateNumber
        '    Me.EstimateComponentNumber = JobDetailItem.EstimateComponentNumber
        '    Me.BillingUser = JobDetailItem.BillingUser
        '    Me.AdvanceBillFlag = JobDetailItem.AdvanceBillFlag
        '    Me.DeliveryInstructions = JobDetailItem.DeliveryInstructions
        '    Me.JobTypeCode = JobDetailItem.JobTypeCode
        '    Me.JobTypeDescription = JobDetailItem.JobTypeDescription
        '    Me.Taxable = JobDetailItem.Taxable
        '    Me.TaxCode = JobDetailItem.TaxCode
        '    Me.TaxCodeDescription = JobDetailItem.TaxCodeDescription
        '    Me.NonBillable = JobDetailItem.NonBillable
        '    Me.AlertGroup = JobDetailItem.AlertGroup
        '    Me.AdNumber = JobDetailItem.AdNumber
        '    Me.AccountNumber = JobDetailItem.AccountNumber
        '    Me.IncomeRecognitionMethod = JobDetailItem.IncomeRecognitionMethod
        '    Me.MarketCode = JobDetailItem.MarketCode
        '    Me.MarketDescription = JobDetailItem.MarketDescription
        '    Me.ServiceFeeJob = JobDetailItem.ServiceFeeJob
        '    Me.ServiceFeeTypeCode = JobDetailItem.ServiceFeeTypeCode
        '    Me.ServiceFeeTypeDescription = JobDetailItem.ServiceFeeTypeDescription
        '    Me.Archived = JobDetailItem.Archived
        '    Me.TrafficScheduleRequired = JobDetailItem.TrafficScheduleRequired
        '    Me.ClientPO = JobDetailItem.ClientPO
        '    Me.CompLabelFromUDFTable1 = JobDetailItem.CompLabelFromUDFTable1
        '    Me.CompLabelFromUDFTable2 = JobDetailItem.CompLabelFromUDFTable2
        '    Me.CompLabelFromUDFTable3 = JobDetailItem.CompLabelFromUDFTable3
        '    Me.CompLabelFromUDFTable4 = JobDetailItem.CompLabelFromUDFTable4
        '    Me.CompLabelFromUDFTable5 = JobDetailItem.CompLabelFromUDFTable5
        '    Me.JobTemplateCode = JobDetailItem.JobTemplateCode
        '    Me.FiscalPeriodCode = JobDetailItem.FiscalPeriodCode
        '    Me.FiscalPeriodDescription = JobDetailItem.FiscalPeriodDescription
        '    Me.JobQuantity = JobDetailItem.JobQuantity
        '    Me.BlackplateVersionCode = JobDetailItem.BlackplateVersionCode
        '    Me.BlackplateVersionDesc = JobDetailItem.BlackplateVersionDesc
        '    Me.ClientContactCode = JobDetailItem.ClientContactCode
        '    Me.ClientContactID = JobDetailItem.ClientContactID
        '    Me.BABatchID = JobDetailItem.BABatchID
        '    Me.ClientContact = JobDetailItem.ClientContact
        '    Me.SelectedBABatchID = JobDetailItem.SelectedBABatchID
        '    Me.BillingCommandCenterID = JobDetailItem.BillingCommandCenterID
        '    Me.AlertAssignmentTemplate = JobDetailItem.AlertAssignmentTemplate
        '    Me.FunctionType = JobDetailItem.FunctionType
        '    Me.FunctionConsolidationCode = JobDetailItem.FunctionConsolidationCode
        '    Me.FunctionConsolidation = JobDetailItem.FunctionConsolidation
        '    Me.FunctionHeading = JobDetailItem.FunctionHeading
        '    Me.FunctionCode = JobDetailItem.FunctionCode
        '    Me.FunctionDescription = JobDetailItem.FunctionDescription
        '    Me.ItemID = JobDetailItem.ItemID
        '    Me.ItemSequenceNumber = JobDetailItem.ItemSequenceNumber
        '    Me.ItemDate = JobDetailItem.ItemDate
        '    Me.PostPeriodCode = JobDetailItem.PostPeriodCode
        '    Me.ItemCode = JobDetailItem.ItemCode
        '    Me.ItemDescription = JobDetailItem.ItemDescription
        '    Me.ItemComment = JobDetailItem.ItemComment
        '    Me.ItemExtra = JobDetailItem.ItemExtra
        '    Me.Hours = JobDetailItem.Hours
        '    Me.Quantity = JobDetailItem.Quantity
        '    Me.NetAmount = JobDetailItem.NetAmount
        '    Me.CostAmount = JobDetailItem.CostAmount
        '    Me.ExtMarkupAmount = JobDetailItem.ExtMarkupAmount
        '    Me.NonResaleTaxAmount = JobDetailItem.NonResaleTaxAmount
        '    Me.ResaleTaxAmount = JobDetailItem.ResaleTaxAmount
        '    Me.Total = JobDetailItem.Total
        '    Me.BillableLessResale = JobDetailItem.BillableLessResale
        '    Me.BillableTotal = JobDetailItem.BillableTotal
        '    Me.FeeTime = JobDetailItem.FeeTime
        '    Me.FeeTimeHours = JobDetailItem.FeeTimeHours
        '    Me.FeeTimeAmount = JobDetailItem.FeeTimeAmount
        '    Me.NonBillableHours = JobDetailItem.NonBillableHours
        '    Me.NonBillableQuantity = JobDetailItem.NonBillableQuantity
        '    Me.NonBillableAmount = JobDetailItem.NonBillableAmount
        '    Me.BilledHours = JobDetailItem.BilledHours
        '    Me.BilledQuantity = JobDetailItem.BilledQuantity
        '    Me.BilledAmount = JobDetailItem.BilledAmount
        '    Me.BilledWithResale = JobDetailItem.BilledWithResale
        '    Me.AccountsReceivablePostPeriodCode = JobDetailItem.AccountsReceivablePostPeriodCode
        '    Me.AccountsReceivableInvoiceNumber = JobDetailItem.AccountsReceivableInvoiceNumber
        '    Me.AccountsReceivableInvoiceType = JobDetailItem.AccountsReceivableInvoiceType
        '    Me.UnbilledHours = JobDetailItem.UnbilledHours
        '    Me.UnbilledQuantity = JobDetailItem.UnbilledQuantity
        '    Me.UnbilledAmount = JobDetailItem.UnbilledAmount
        '    Me.UnbilledAmountLessResale = JobDetailItem.UnbilledAmountLessResale
        '    Me.AdvanceBillFlagDetail = JobDetailItem.AdvanceBillFlagDetail
        '    Me.IsNonBillable = JobDetailItem.IsNonBillable
        '    Me.GlexActBill = JobDetailItem.GlexActBill
        '    Me.EstimateHours = JobDetailItem.EstimateHours
        '    Me.EstimateQuantity = JobDetailItem.EstimateQuantity
        '    Me.EstimateTotalAmount = JobDetailItem.EstimateTotalAmount
        '    Me.EstimateContTotalAmount = JobDetailItem.EstimateContTotalAmount
        '    Me.EstimateNonResaleTaxAmount = JobDetailItem.EstimateNonResaleTaxAmount
        '    Me.EstimateResaleTaxAmount = JobDetailItem.EstimateResaleTaxAmount
        '    Me.EstimateMarkupAmount = JobDetailItem.EstimateMarkupAmount
        '    Me.EstimateCostAmount = JobDetailItem.EstimateCostAmount
        '    Me.IsEstimateNonBillable = JobDetailItem.IsEstimateNonBillable
        '    Me.EstimateFeeTime = JobDetailItem.EstimateFeeTime
        '    Me.EstimateNetAmount = JobDetailItem.EstimateNetAmount
        '    Me.PurchaseOrderNumber = JobDetailItem.PurchaseOrderNumber
        '    Me.OpenPurchaseOrderAmount = JobDetailItem.OpenPurchaseOrderAmount
        '    Me.OpenPurchaseOrderGrossAmount = JobDetailItem.OpenPurchaseOrderGrossAmount
        '    Me.IsNewBusiness = JobDetailItem.IsNewBusiness
        '    Me.Agency = JobDetailItem.Agency
        '    Me.BillingApprovalHours = JobDetailItem.BillingApprovalHours
        '    Me.BillingApprovalCostAmount = JobDetailItem.BillingApprovalCostAmount
        '    Me.BillingApprovalExtNetAmount = JobDetailItem.BillingApprovalExtNetAmount
        '    Me.BillingApprovalTotalAmount = JobDetailItem.BillingApprovalTotalAmount
        '    Me.ProductUDF1 = JobDetailItem.ProductUDF1
        '    Me.ProductUDF2 = JobDetailItem.ProductUDF2
        '    Me.ProductUDF3 = JobDetailItem.ProductUDF3
        '    Me.ProductUDF4 = JobDetailItem.ProductUDF4

        'End Sub
        'Public Sub New(ByVal JobDetailItem As AdvantageFramework.Database.Views.JobDetailItemC)

        '    Me.ID = JobDetailItem.ID
        '    Me.ResourceType = JobDetailItem.ResourceType
        '    Me.JobNumber = JobDetailItem.JobNumber
        '    Me.JobComponentNumber = JobDetailItem.JobComponentNumber
        '    Me.OfficeCode = JobDetailItem.OfficeCode
        '    Me.OfficeDescription = JobDetailItem.OfficeDescription
        '    Me.ClientCode = JobDetailItem.ClientCode
        '    Me.ClientDescription = JobDetailItem.ClientDescription
        '    Me.DivisionCode = JobDetailItem.DivisionCode
        '    Me.DivisionDescription = JobDetailItem.DivisionDescription
        '    Me.ProductCode = JobDetailItem.ProductCode
        '    Me.ProductDescription = JobDetailItem.ProductDescription
        '    Me.CampaignID = JobDetailItem.CampaignID
        '    Me.CampaignCode = JobDetailItem.CampaignCode
        '    Me.CampaignName = JobDetailItem.CampaignName
        '    Me.SalesClassCode = JobDetailItem.SalesClassCode
        '    Me.SalesClassDescription = JobDetailItem.SalesClassDescription
        '    Me.UserCode = JobDetailItem.UserCode
        '    Me.JobCreateDate = JobDetailItem.JobCreateDate
        '    Me.JobDescription = JobDetailItem.JobDescription
        '    Me.JobDateOpened = JobDetailItem.JobDateOpened
        '    Me.RushChargesApproved = JobDetailItem.RushChargesApproved
        '    Me.ApprovedEstimateRequired = JobDetailItem.ApprovedEstimateRequired
        '    Me.Comment = JobDetailItem.Comment
        '    Me.ClientReference = JobDetailItem.ClientReference
        '    Me.BillingCoopCode = JobDetailItem.BillingCoopCode
        '    Me.SalesClassFormatCode = JobDetailItem.SalesClassFormatCode
        '    Me.ComplexityCode = JobDetailItem.ComplexityCode
        '    Me.PromotionCode = JobDetailItem.PromotionCode
        '    Me.BillingComment = JobDetailItem.BillingComment
        '    Me.LabelFromUDFTable1 = JobDetailItem.LabelFromUDFTable1
        '    Me.LabelFromUDFTable2 = JobDetailItem.LabelFromUDFTable2
        '    Me.LabelFromUDFTable3 = JobDetailItem.LabelFromUDFTable3
        '    Me.LabelFromUDFTable4 = JobDetailItem.LabelFromUDFTable4
        '    Me.LabelFromUDFTable5 = JobDetailItem.LabelFromUDFTable5
        '    Me.JobOpen = JobDetailItem.JobOpen
        '    Me.JobComponent = JobDetailItem.JobComponent
        '    Me.BillHold = JobDetailItem.BillHold
        '    Me.AccountExecutiveCode = JobDetailItem.AccountExecutiveCode
        '    Me.AccountExecutive = JobDetailItem.AccountExecutive
        '    Me.ComponentDateOpened = JobDetailItem.ComponentDateOpened
        '    Me.DueDate = JobDetailItem.DueDate
        '    Me.StartDate = JobDetailItem.StartDate
        '    Me.AdSize = JobDetailItem.AdSize
        '    Me.DepartmentTeamCode = JobDetailItem.DepartmentTeamCode
        '    Me.DepartmentTeam = JobDetailItem.DepartmentTeam
        '    Me.MarkupPercent = JobDetailItem.MarkupPercent
        '    Me.CreativeInstructions = JobDetailItem.CreativeInstructions
        '    Me.JobProcessControl = JobDetailItem.JobProcessControl
        '    Me.ComponentDescription = JobDetailItem.ComponentDescription
        '    Me.ComponentComments = JobDetailItem.ComponentComments
        '    Me.ComponentBudget = JobDetailItem.ComponentBudget
        '    Me.EstimateNumber = JobDetailItem.EstimateNumber
        '    Me.EstimateComponentNumber = JobDetailItem.EstimateComponentNumber
        '    Me.BillingUser = JobDetailItem.BillingUser
        '    Me.AdvanceBillFlag = JobDetailItem.AdvanceBillFlag
        '    Me.DeliveryInstructions = JobDetailItem.DeliveryInstructions
        '    Me.JobTypeCode = JobDetailItem.JobTypeCode
        '    Me.JobTypeDescription = JobDetailItem.JobTypeDescription
        '    Me.Taxable = JobDetailItem.Taxable
        '    Me.TaxCode = JobDetailItem.TaxCode
        '    Me.TaxCodeDescription = JobDetailItem.TaxCodeDescription
        '    Me.NonBillable = JobDetailItem.NonBillable
        '    Me.AlertGroup = JobDetailItem.AlertGroup
        '    Me.AdNumber = JobDetailItem.AdNumber
        '    Me.AccountNumber = JobDetailItem.AccountNumber
        '    Me.IncomeRecognitionMethod = JobDetailItem.IncomeRecognitionMethod
        '    Me.MarketCode = JobDetailItem.MarketCode
        '    Me.MarketDescription = JobDetailItem.MarketDescription
        '    Me.ServiceFeeJob = JobDetailItem.ServiceFeeJob
        '    Me.ServiceFeeTypeCode = JobDetailItem.ServiceFeeTypeCode
        '    Me.ServiceFeeTypeDescription = JobDetailItem.ServiceFeeTypeDescription
        '    Me.Archived = JobDetailItem.Archived
        '    Me.TrafficScheduleRequired = JobDetailItem.TrafficScheduleRequired
        '    Me.ClientPO = JobDetailItem.ClientPO
        '    Me.CompLabelFromUDFTable1 = JobDetailItem.CompLabelFromUDFTable1
        '    Me.CompLabelFromUDFTable2 = JobDetailItem.CompLabelFromUDFTable2
        '    Me.CompLabelFromUDFTable3 = JobDetailItem.CompLabelFromUDFTable3
        '    Me.CompLabelFromUDFTable4 = JobDetailItem.CompLabelFromUDFTable4
        '    Me.CompLabelFromUDFTable5 = JobDetailItem.CompLabelFromUDFTable5
        '    Me.JobTemplateCode = JobDetailItem.JobTemplateCode
        '    Me.FiscalPeriodCode = JobDetailItem.FiscalPeriodCode
        '    Me.FiscalPeriodDescription = JobDetailItem.FiscalPeriodDescription
        '    Me.JobQuantity = JobDetailItem.JobQuantity
        '    Me.BlackplateVersionCode = JobDetailItem.BlackplateVersionCode
        '    Me.BlackplateVersionDesc = JobDetailItem.BlackplateVersionDesc
        '    Me.ClientContactCode = JobDetailItem.ClientContactCode
        '    Me.ClientContactID = JobDetailItem.ClientContactID
        '    Me.BABatchID = JobDetailItem.BABatchID
        '    Me.ClientContact = JobDetailItem.ClientContact
        '    Me.SelectedBABatchID = JobDetailItem.SelectedBABatchID
        '    Me.BillingCommandCenterID = JobDetailItem.BillingCommandCenterID
        '    Me.AlertAssignmentTemplate = JobDetailItem.AlertAssignmentTemplate
        '    Me.FunctionType = JobDetailItem.FunctionType
        '    Me.FunctionConsolidationCode = JobDetailItem.FunctionConsolidationCode
        '    Me.FunctionConsolidation = JobDetailItem.FunctionConsolidation
        '    Me.FunctionHeading = JobDetailItem.FunctionHeading
        '    Me.FunctionCode = JobDetailItem.FunctionCode
        '    Me.FunctionDescription = JobDetailItem.FunctionDescription
        '    Me.ItemID = JobDetailItem.ItemID
        '    Me.ItemSequenceNumber = JobDetailItem.ItemSequenceNumber
        '    Me.ItemDate = JobDetailItem.ItemDate
        '    Me.PostPeriodCode = JobDetailItem.PostPeriodCode
        '    Me.ItemCode = JobDetailItem.ItemCode
        '    Me.ItemDescription = JobDetailItem.ItemDescription
        '    Me.ItemComment = JobDetailItem.ItemComment
        '    Me.ItemExtra = JobDetailItem.ItemExtra
        '    Me.Hours = JobDetailItem.Hours
        '    Me.Quantity = JobDetailItem.Quantity
        '    Me.NetAmount = JobDetailItem.NetAmount
        '    Me.CostAmount = JobDetailItem.CostAmount
        '    Me.ExtMarkupAmount = JobDetailItem.ExtMarkupAmount
        '    Me.NonResaleTaxAmount = JobDetailItem.NonResaleTaxAmount
        '    Me.ResaleTaxAmount = JobDetailItem.ResaleTaxAmount
        '    Me.Total = JobDetailItem.Total
        '    Me.BillableLessResale = JobDetailItem.BillableLessResale
        '    Me.BillableTotal = JobDetailItem.BillableTotal
        '    Me.FeeTime = JobDetailItem.FeeTime
        '    Me.FeeTimeHours = JobDetailItem.FeeTimeHours
        '    Me.FeeTimeAmount = JobDetailItem.FeeTimeAmount
        '    Me.NonBillableHours = JobDetailItem.NonBillableHours
        '    Me.NonBillableQuantity = JobDetailItem.NonBillableQuantity
        '    Me.NonBillableAmount = JobDetailItem.NonBillableAmount
        '    Me.BilledHours = JobDetailItem.BilledHours
        '    Me.BilledQuantity = JobDetailItem.BilledQuantity
        '    Me.BilledAmount = JobDetailItem.BilledAmount
        '    Me.BilledWithResale = JobDetailItem.BilledWithResale
        '    Me.AccountsReceivablePostPeriodCode = JobDetailItem.AccountsReceivablePostPeriodCode
        '    Me.AccountsReceivableInvoiceNumber = JobDetailItem.AccountsReceivableInvoiceNumber
        '    Me.AccountsReceivableInvoiceType = JobDetailItem.AccountsReceivableInvoiceType
        '    Me.UnbilledHours = JobDetailItem.UnbilledHours
        '    Me.UnbilledQuantity = JobDetailItem.UnbilledQuantity
        '    Me.UnbilledAmount = JobDetailItem.UnbilledAmount
        '    Me.UnbilledAmountLessResale = JobDetailItem.UnbilledAmountLessResale
        '    Me.AdvanceBillFlagDetail = JobDetailItem.AdvanceBillFlagDetail
        '    Me.IsNonBillable = JobDetailItem.IsNonBillable
        '    Me.GlexActBill = JobDetailItem.GlexActBill
        '    Me.EstimateHours = JobDetailItem.EstimateHours
        '    Me.EstimateQuantity = JobDetailItem.EstimateQuantity
        '    Me.EstimateTotalAmount = JobDetailItem.EstimateTotalAmount
        '    Me.EstimateContTotalAmount = JobDetailItem.EstimateContTotalAmount
        '    Me.EstimateNonResaleTaxAmount = JobDetailItem.EstimateNonResaleTaxAmount
        '    Me.EstimateResaleTaxAmount = JobDetailItem.EstimateResaleTaxAmount
        '    Me.EstimateMarkupAmount = JobDetailItem.EstimateMarkupAmount
        '    Me.EstimateCostAmount = JobDetailItem.EstimateCostAmount
        '    Me.IsEstimateNonBillable = JobDetailItem.IsEstimateNonBillable
        '    Me.EstimateFeeTime = JobDetailItem.EstimateFeeTime
        '    Me.EstimateNetAmount = JobDetailItem.EstimateNetAmount
        '    Me.PurchaseOrderNumber = JobDetailItem.PurchaseOrderNumber
        '    Me.OpenPurchaseOrderAmount = JobDetailItem.OpenPurchaseOrderAmount
        '    Me.OpenPurchaseOrderGrossAmount = JobDetailItem.OpenPurchaseOrderGrossAmount
        '    Me.IsNewBusiness = JobDetailItem.IsNewBusiness
        '    Me.Agency = JobDetailItem.Agency
        '    Me.BillingApprovalHours = JobDetailItem.BillingApprovalHours
        '    Me.BillingApprovalCostAmount = JobDetailItem.BillingApprovalCostAmount
        '    Me.BillingApprovalExtNetAmount = JobDetailItem.BillingApprovalExtNetAmount
        '    Me.BillingApprovalTotalAmount = JobDetailItem.BillingApprovalTotalAmount
        '    Me.ProductUDF1 = JobDetailItem.ProductUDF1
        '    Me.ProductUDF2 = JobDetailItem.ProductUDF2
        '    Me.ProductUDF3 = JobDetailItem.ProductUDF3
        '    Me.ProductUDF4 = JobDetailItem.ProductUDF4

        'End Sub
        'Public Sub New(ByVal JobDetailItem As AdvantageFramework.Database.Views.JobDetailItemE)

        '    Me.ID = JobDetailItem.ID
        '    Me.ResourceType = JobDetailItem.ResourceType
        '    Me.JobNumber = JobDetailItem.JobNumber
        '    Me.JobComponentNumber = JobDetailItem.JobComponentNumber
        '    Me.OfficeCode = JobDetailItem.OfficeCode
        '    Me.OfficeDescription = JobDetailItem.OfficeDescription
        '    Me.ClientCode = JobDetailItem.ClientCode
        '    Me.ClientDescription = JobDetailItem.ClientDescription
        '    Me.DivisionCode = JobDetailItem.DivisionCode
        '    Me.DivisionDescription = JobDetailItem.DivisionDescription
        '    Me.ProductCode = JobDetailItem.ProductCode
        '    Me.ProductDescription = JobDetailItem.ProductDescription
        '    Me.CampaignID = JobDetailItem.CampaignID
        '    Me.CampaignCode = JobDetailItem.CampaignCode
        '    Me.CampaignName = JobDetailItem.CampaignName
        '    Me.SalesClassCode = JobDetailItem.SalesClassCode
        '    Me.SalesClassDescription = JobDetailItem.SalesClassDescription
        '    Me.UserCode = JobDetailItem.UserCode
        '    Me.JobCreateDate = JobDetailItem.JobCreateDate
        '    Me.JobDescription = JobDetailItem.JobDescription
        '    Me.JobDateOpened = JobDetailItem.JobDateOpened
        '    Me.RushChargesApproved = JobDetailItem.RushChargesApproved
        '    Me.ApprovedEstimateRequired = JobDetailItem.ApprovedEstimateRequired
        '    Me.Comment = JobDetailItem.Comment
        '    Me.ClientReference = JobDetailItem.ClientReference
        '    Me.BillingCoopCode = JobDetailItem.BillingCoopCode
        '    Me.SalesClassFormatCode = JobDetailItem.SalesClassFormatCode
        '    Me.ComplexityCode = JobDetailItem.ComplexityCode
        '    Me.PromotionCode = JobDetailItem.PromotionCode
        '    Me.BillingComment = JobDetailItem.BillingComment
        '    Me.LabelFromUDFTable1 = JobDetailItem.LabelFromUDFTable1
        '    Me.LabelFromUDFTable2 = JobDetailItem.LabelFromUDFTable2
        '    Me.LabelFromUDFTable3 = JobDetailItem.LabelFromUDFTable3
        '    Me.LabelFromUDFTable4 = JobDetailItem.LabelFromUDFTable4
        '    Me.LabelFromUDFTable5 = JobDetailItem.LabelFromUDFTable5
        '    Me.JobOpen = JobDetailItem.JobOpen
        '    Me.JobComponent = JobDetailItem.JobComponent
        '    Me.BillHold = JobDetailItem.BillHold
        '    Me.AccountExecutiveCode = JobDetailItem.AccountExecutiveCode
        '    Me.AccountExecutive = JobDetailItem.AccountExecutive
        '    Me.ComponentDateOpened = JobDetailItem.ComponentDateOpened
        '    Me.DueDate = JobDetailItem.DueDate
        '    Me.StartDate = JobDetailItem.StartDate
        '    Me.AdSize = JobDetailItem.AdSize
        '    Me.DepartmentTeamCode = JobDetailItem.DepartmentTeamCode
        '    Me.DepartmentTeam = JobDetailItem.DepartmentTeam
        '    Me.MarkupPercent = JobDetailItem.MarkupPercent
        '    Me.CreativeInstructions = JobDetailItem.CreativeInstructions
        '    Me.JobProcessControl = JobDetailItem.JobProcessControl
        '    Me.ComponentDescription = JobDetailItem.ComponentDescription
        '    Me.ComponentComments = JobDetailItem.ComponentComments
        '    Me.ComponentBudget = JobDetailItem.ComponentBudget
        '    Me.EstimateNumber = JobDetailItem.EstimateNumber
        '    Me.EstimateComponentNumber = JobDetailItem.EstimateComponentNumber
        '    Me.BillingUser = JobDetailItem.BillingUser
        '    Me.AdvanceBillFlag = JobDetailItem.AdvanceBillFlag
        '    Me.DeliveryInstructions = JobDetailItem.DeliveryInstructions
        '    Me.JobTypeCode = JobDetailItem.JobTypeCode
        '    Me.JobTypeDescription = JobDetailItem.JobTypeDescription
        '    Me.Taxable = JobDetailItem.Taxable
        '    Me.TaxCode = JobDetailItem.TaxCode
        '    Me.TaxCodeDescription = JobDetailItem.TaxCodeDescription
        '    Me.NonBillable = JobDetailItem.NonBillable
        '    Me.AlertGroup = JobDetailItem.AlertGroup
        '    Me.AdNumber = JobDetailItem.AdNumber
        '    Me.AccountNumber = JobDetailItem.AccountNumber
        '    Me.IncomeRecognitionMethod = JobDetailItem.IncomeRecognitionMethod
        '    Me.MarketCode = JobDetailItem.MarketCode
        '    Me.MarketDescription = JobDetailItem.MarketDescription
        '    Me.ServiceFeeJob = JobDetailItem.ServiceFeeJob
        '    Me.ServiceFeeTypeCode = JobDetailItem.ServiceFeeTypeCode
        '    Me.ServiceFeeTypeDescription = JobDetailItem.ServiceFeeTypeDescription
        '    Me.Archived = JobDetailItem.Archived
        '    Me.TrafficScheduleRequired = JobDetailItem.TrafficScheduleRequired
        '    Me.ClientPO = JobDetailItem.ClientPO
        '    Me.CompLabelFromUDFTable1 = JobDetailItem.CompLabelFromUDFTable1
        '    Me.CompLabelFromUDFTable2 = JobDetailItem.CompLabelFromUDFTable2
        '    Me.CompLabelFromUDFTable3 = JobDetailItem.CompLabelFromUDFTable3
        '    Me.CompLabelFromUDFTable4 = JobDetailItem.CompLabelFromUDFTable4
        '    Me.CompLabelFromUDFTable5 = JobDetailItem.CompLabelFromUDFTable5
        '    Me.JobTemplateCode = JobDetailItem.JobTemplateCode
        '    Me.FiscalPeriodCode = JobDetailItem.FiscalPeriodCode
        '    Me.FiscalPeriodDescription = JobDetailItem.FiscalPeriodDescription
        '    Me.JobQuantity = JobDetailItem.JobQuantity
        '    Me.BlackplateVersionCode = JobDetailItem.BlackplateVersionCode
        '    Me.BlackplateVersionDesc = JobDetailItem.BlackplateVersionDesc
        '    Me.ClientContactCode = JobDetailItem.ClientContactCode
        '    Me.ClientContactID = JobDetailItem.ClientContactID
        '    Me.BABatchID = JobDetailItem.BABatchID
        '    Me.ClientContact = JobDetailItem.ClientContact
        '    Me.SelectedBABatchID = JobDetailItem.SelectedBABatchID
        '    Me.BillingCommandCenterID = JobDetailItem.BillingCommandCenterID
        '    Me.AlertAssignmentTemplate = JobDetailItem.AlertAssignmentTemplate
        '    Me.FunctionType = JobDetailItem.FunctionType
        '    Me.FunctionConsolidationCode = JobDetailItem.FunctionConsolidationCode
        '    Me.FunctionConsolidation = JobDetailItem.FunctionConsolidation
        '    Me.FunctionHeading = JobDetailItem.FunctionHeading
        '    Me.FunctionCode = JobDetailItem.FunctionCode
        '    Me.FunctionDescription = JobDetailItem.FunctionDescription
        '    Me.ItemID = JobDetailItem.ItemID
        '    Me.ItemSequenceNumber = JobDetailItem.ItemSequenceNumber
        '    Me.ItemDate = JobDetailItem.ItemDate
        '    Me.PostPeriodCode = JobDetailItem.PostPeriodCode
        '    Me.ItemCode = JobDetailItem.ItemCode
        '    Me.ItemDescription = JobDetailItem.ItemDescription
        '    Me.ItemComment = JobDetailItem.ItemComment
        '    Me.ItemExtra = JobDetailItem.ItemExtra
        '    Me.Hours = JobDetailItem.Hours
        '    Me.Quantity = JobDetailItem.Quantity
        '    Me.NetAmount = JobDetailItem.NetAmount
        '    Me.CostAmount = JobDetailItem.CostAmount
        '    Me.ExtMarkupAmount = JobDetailItem.ExtMarkupAmount
        '    Me.NonResaleTaxAmount = JobDetailItem.NonResaleTaxAmount
        '    Me.ResaleTaxAmount = JobDetailItem.ResaleTaxAmount
        '    Me.Total = JobDetailItem.Total
        '    Me.BillableLessResale = JobDetailItem.BillableLessResale
        '    Me.BillableTotal = JobDetailItem.BillableTotal
        '    Me.FeeTime = JobDetailItem.FeeTime
        '    Me.FeeTimeHours = JobDetailItem.FeeTimeHours
        '    Me.FeeTimeAmount = JobDetailItem.FeeTimeAmount
        '    Me.NonBillableHours = JobDetailItem.NonBillableHours
        '    Me.NonBillableQuantity = JobDetailItem.NonBillableQuantity
        '    Me.NonBillableAmount = JobDetailItem.NonBillableAmount
        '    Me.BilledHours = JobDetailItem.BilledHours
        '    Me.BilledQuantity = JobDetailItem.BilledQuantity
        '    Me.BilledAmount = JobDetailItem.BilledAmount
        '    Me.BilledWithResale = JobDetailItem.BilledWithResale
        '    Me.AccountsReceivablePostPeriodCode = JobDetailItem.AccountsReceivablePostPeriodCode
        '    Me.AccountsReceivableInvoiceNumber = JobDetailItem.AccountsReceivableInvoiceNumber
        '    Me.AccountsReceivableInvoiceType = JobDetailItem.AccountsReceivableInvoiceType
        '    Me.UnbilledHours = JobDetailItem.UnbilledHours
        '    Me.UnbilledQuantity = JobDetailItem.UnbilledQuantity
        '    Me.UnbilledAmount = JobDetailItem.UnbilledAmount
        '    Me.UnbilledAmountLessResale = JobDetailItem.UnbilledAmountLessResale
        '    Me.AdvanceBillFlagDetail = JobDetailItem.AdvanceBillFlagDetail
        '    Me.IsNonBillable = JobDetailItem.IsNonBillable
        '    Me.GlexActBill = JobDetailItem.GlexActBill
        '    Me.EstimateHours = JobDetailItem.EstimateHours
        '    Me.EstimateQuantity = JobDetailItem.EstimateQuantity
        '    Me.EstimateTotalAmount = JobDetailItem.EstimateTotalAmount
        '    Me.EstimateContTotalAmount = JobDetailItem.EstimateContTotalAmount
        '    Me.EstimateNonResaleTaxAmount = JobDetailItem.EstimateNonResaleTaxAmount
        '    Me.EstimateResaleTaxAmount = JobDetailItem.EstimateResaleTaxAmount
        '    Me.EstimateMarkupAmount = JobDetailItem.EstimateMarkupAmount
        '    Me.EstimateCostAmount = JobDetailItem.EstimateCostAmount
        '    Me.IsEstimateNonBillable = JobDetailItem.IsEstimateNonBillable
        '    Me.EstimateFeeTime = JobDetailItem.EstimateFeeTime
        '    Me.EstimateNetAmount = JobDetailItem.EstimateNetAmount
        '    Me.PurchaseOrderNumber = JobDetailItem.PurchaseOrderNumber
        '    Me.OpenPurchaseOrderAmount = JobDetailItem.OpenPurchaseOrderAmount
        '    Me.OpenPurchaseOrderGrossAmount = JobDetailItem.OpenPurchaseOrderGrossAmount
        '    Me.IsNewBusiness = JobDetailItem.IsNewBusiness
        '    Me.Agency = JobDetailItem.Agency
        '    Me.BillingApprovalHours = JobDetailItem.BillingApprovalHours
        '    Me.BillingApprovalCostAmount = JobDetailItem.BillingApprovalCostAmount
        '    Me.BillingApprovalExtNetAmount = JobDetailItem.BillingApprovalExtNetAmount
        '    Me.BillingApprovalTotalAmount = JobDetailItem.BillingApprovalTotalAmount
        '    Me.ProductUDF1 = JobDetailItem.ProductUDF1
        '    Me.ProductUDF2 = JobDetailItem.ProductUDF2
        '    Me.ProductUDF3 = JobDetailItem.ProductUDF3
        '    Me.ProductUDF4 = JobDetailItem.ProductUDF4

        'End Sub
        'Public Sub New(ByVal JobDetailItem As AdvantageFramework.Database.Views.JobDetailItemEI)

        '    Me.ID = JobDetailItem.ID
        '    Me.ResourceType = JobDetailItem.ResourceType
        '    Me.JobNumber = JobDetailItem.JobNumber
        '    Me.JobComponentNumber = JobDetailItem.JobComponentNumber
        '    Me.OfficeCode = JobDetailItem.OfficeCode
        '    Me.OfficeDescription = JobDetailItem.OfficeDescription
        '    Me.ClientCode = JobDetailItem.ClientCode
        '    Me.ClientDescription = JobDetailItem.ClientDescription
        '    Me.DivisionCode = JobDetailItem.DivisionCode
        '    Me.DivisionDescription = JobDetailItem.DivisionDescription
        '    Me.ProductCode = JobDetailItem.ProductCode
        '    Me.ProductDescription = JobDetailItem.ProductDescription
        '    Me.CampaignID = JobDetailItem.CampaignID
        '    Me.CampaignCode = JobDetailItem.CampaignCode
        '    Me.CampaignName = JobDetailItem.CampaignName
        '    Me.SalesClassCode = JobDetailItem.SalesClassCode
        '    Me.SalesClassDescription = JobDetailItem.SalesClassDescription
        '    Me.UserCode = JobDetailItem.UserCode
        '    Me.JobCreateDate = JobDetailItem.JobCreateDate
        '    Me.JobDescription = JobDetailItem.JobDescription
        '    Me.JobDateOpened = JobDetailItem.JobDateOpened
        '    Me.RushChargesApproved = JobDetailItem.RushChargesApproved
        '    Me.ApprovedEstimateRequired = JobDetailItem.ApprovedEstimateRequired
        '    Me.Comment = JobDetailItem.Comment
        '    Me.ClientReference = JobDetailItem.ClientReference
        '    Me.BillingCoopCode = JobDetailItem.BillingCoopCode
        '    Me.SalesClassFormatCode = JobDetailItem.SalesClassFormatCode
        '    Me.ComplexityCode = JobDetailItem.ComplexityCode
        '    Me.PromotionCode = JobDetailItem.PromotionCode
        '    Me.BillingComment = JobDetailItem.BillingComment
        '    Me.LabelFromUDFTable1 = JobDetailItem.LabelFromUDFTable1
        '    Me.LabelFromUDFTable2 = JobDetailItem.LabelFromUDFTable2
        '    Me.LabelFromUDFTable3 = JobDetailItem.LabelFromUDFTable3
        '    Me.LabelFromUDFTable4 = JobDetailItem.LabelFromUDFTable4
        '    Me.LabelFromUDFTable5 = JobDetailItem.LabelFromUDFTable5
        '    Me.JobOpen = JobDetailItem.JobOpen
        '    Me.JobComponent = JobDetailItem.JobComponent
        '    Me.BillHold = JobDetailItem.BillHold
        '    Me.AccountExecutiveCode = JobDetailItem.AccountExecutiveCode
        '    Me.AccountExecutive = JobDetailItem.AccountExecutive
        '    Me.ComponentDateOpened = JobDetailItem.ComponentDateOpened
        '    Me.DueDate = JobDetailItem.DueDate
        '    Me.StartDate = JobDetailItem.StartDate
        '    Me.AdSize = JobDetailItem.AdSize
        '    Me.DepartmentTeamCode = JobDetailItem.DepartmentTeamCode
        '    Me.DepartmentTeam = JobDetailItem.DepartmentTeam
        '    Me.MarkupPercent = JobDetailItem.MarkupPercent
        '    Me.CreativeInstructions = JobDetailItem.CreativeInstructions
        '    Me.JobProcessControl = JobDetailItem.JobProcessControl
        '    Me.ComponentDescription = JobDetailItem.ComponentDescription
        '    Me.ComponentComments = JobDetailItem.ComponentComments
        '    Me.ComponentBudget = JobDetailItem.ComponentBudget
        '    Me.EstimateNumber = JobDetailItem.EstimateNumber
        '    Me.EstimateComponentNumber = JobDetailItem.EstimateComponentNumber
        '    Me.BillingUser = JobDetailItem.BillingUser
        '    Me.AdvanceBillFlag = JobDetailItem.AdvanceBillFlag
        '    Me.DeliveryInstructions = JobDetailItem.DeliveryInstructions
        '    Me.JobTypeCode = JobDetailItem.JobTypeCode
        '    Me.JobTypeDescription = JobDetailItem.JobTypeDescription
        '    Me.Taxable = JobDetailItem.Taxable
        '    Me.TaxCode = JobDetailItem.TaxCode
        '    Me.TaxCodeDescription = JobDetailItem.TaxCodeDescription
        '    Me.NonBillable = JobDetailItem.NonBillable
        '    Me.AlertGroup = JobDetailItem.AlertGroup
        '    Me.AdNumber = JobDetailItem.AdNumber
        '    Me.AccountNumber = JobDetailItem.AccountNumber
        '    Me.IncomeRecognitionMethod = JobDetailItem.IncomeRecognitionMethod
        '    Me.MarketCode = JobDetailItem.MarketCode
        '    Me.MarketDescription = JobDetailItem.MarketDescription
        '    Me.ServiceFeeJob = JobDetailItem.ServiceFeeJob
        '    Me.ServiceFeeTypeCode = JobDetailItem.ServiceFeeTypeCode
        '    Me.ServiceFeeTypeDescription = JobDetailItem.ServiceFeeTypeDescription
        '    Me.Archived = JobDetailItem.Archived
        '    Me.TrafficScheduleRequired = JobDetailItem.TrafficScheduleRequired
        '    Me.ClientPO = JobDetailItem.ClientPO
        '    Me.CompLabelFromUDFTable1 = JobDetailItem.CompLabelFromUDFTable1
        '    Me.CompLabelFromUDFTable2 = JobDetailItem.CompLabelFromUDFTable2
        '    Me.CompLabelFromUDFTable3 = JobDetailItem.CompLabelFromUDFTable3
        '    Me.CompLabelFromUDFTable4 = JobDetailItem.CompLabelFromUDFTable4
        '    Me.CompLabelFromUDFTable5 = JobDetailItem.CompLabelFromUDFTable5
        '    Me.JobTemplateCode = JobDetailItem.JobTemplateCode
        '    Me.FiscalPeriodCode = JobDetailItem.FiscalPeriodCode
        '    Me.FiscalPeriodDescription = JobDetailItem.FiscalPeriodDescription
        '    Me.JobQuantity = JobDetailItem.JobQuantity
        '    Me.BlackplateVersionCode = JobDetailItem.BlackplateVersionCode
        '    Me.BlackplateVersionDesc = JobDetailItem.BlackplateVersionDesc
        '    Me.ClientContactCode = JobDetailItem.ClientContactCode
        '    Me.ClientContactID = JobDetailItem.ClientContactID
        '    Me.BABatchID = JobDetailItem.BABatchID
        '    Me.ClientContact = JobDetailItem.ClientContact
        '    Me.SelectedBABatchID = JobDetailItem.SelectedBABatchID
        '    Me.BillingCommandCenterID = JobDetailItem.BillingCommandCenterID
        '    Me.AlertAssignmentTemplate = JobDetailItem.AlertAssignmentTemplate
        '    Me.FunctionType = JobDetailItem.FunctionType
        '    Me.FunctionConsolidationCode = JobDetailItem.FunctionConsolidationCode
        '    Me.FunctionConsolidation = JobDetailItem.FunctionConsolidation
        '    Me.FunctionHeading = JobDetailItem.FunctionHeading
        '    Me.FunctionCode = JobDetailItem.FunctionCode
        '    Me.FunctionDescription = JobDetailItem.FunctionDescription
        '    Me.ItemID = JobDetailItem.ItemID
        '    Me.ItemSequenceNumber = JobDetailItem.ItemSequenceNumber
        '    Me.ItemDate = JobDetailItem.ItemDate
        '    Me.PostPeriodCode = JobDetailItem.PostPeriodCode
        '    Me.ItemCode = JobDetailItem.ItemCode
        '    Me.ItemDescription = JobDetailItem.ItemDescription
        '    Me.ItemComment = JobDetailItem.ItemComment
        '    Me.ItemExtra = JobDetailItem.ItemExtra
        '    Me.Hours = JobDetailItem.Hours
        '    Me.Quantity = JobDetailItem.Quantity
        '    Me.NetAmount = JobDetailItem.NetAmount
        '    Me.CostAmount = JobDetailItem.CostAmount
        '    Me.ExtMarkupAmount = JobDetailItem.ExtMarkupAmount
        '    Me.NonResaleTaxAmount = JobDetailItem.NonResaleTaxAmount
        '    Me.ResaleTaxAmount = JobDetailItem.ResaleTaxAmount
        '    Me.Total = JobDetailItem.Total
        '    Me.BillableLessResale = JobDetailItem.BillableLessResale
        '    Me.BillableTotal = JobDetailItem.BillableTotal
        '    Me.FeeTime = JobDetailItem.FeeTime
        '    Me.FeeTimeHours = JobDetailItem.FeeTimeHours
        '    Me.FeeTimeAmount = JobDetailItem.FeeTimeAmount
        '    Me.NonBillableHours = JobDetailItem.NonBillableHours
        '    Me.NonBillableQuantity = JobDetailItem.NonBillableQuantity
        '    Me.NonBillableAmount = JobDetailItem.NonBillableAmount
        '    Me.BilledHours = JobDetailItem.BilledHours
        '    Me.BilledQuantity = JobDetailItem.BilledQuantity
        '    Me.BilledAmount = JobDetailItem.BilledAmount
        '    Me.BilledWithResale = JobDetailItem.BilledWithResale
        '    Me.AccountsReceivablePostPeriodCode = JobDetailItem.AccountsReceivablePostPeriodCode
        '    Me.AccountsReceivableInvoiceNumber = JobDetailItem.AccountsReceivableInvoiceNumber
        '    Me.AccountsReceivableInvoiceType = JobDetailItem.AccountsReceivableInvoiceType
        '    Me.UnbilledHours = JobDetailItem.UnbilledHours
        '    Me.UnbilledQuantity = JobDetailItem.UnbilledQuantity
        '    Me.UnbilledAmount = JobDetailItem.UnbilledAmount
        '    Me.UnbilledAmountLessResale = JobDetailItem.UnbilledAmountLessResale
        '    Me.AdvanceBillFlagDetail = JobDetailItem.AdvanceBillFlagDetail
        '    Me.IsNonBillable = JobDetailItem.IsNonBillable
        '    Me.GlexActBill = JobDetailItem.GlexActBill
        '    Me.EstimateHours = JobDetailItem.EstimateHours
        '    Me.EstimateQuantity = JobDetailItem.EstimateQuantity
        '    Me.EstimateTotalAmount = JobDetailItem.EstimateTotalAmount
        '    Me.EstimateContTotalAmount = JobDetailItem.EstimateContTotalAmount
        '    Me.EstimateNonResaleTaxAmount = JobDetailItem.EstimateNonResaleTaxAmount
        '    Me.EstimateResaleTaxAmount = JobDetailItem.EstimateResaleTaxAmount
        '    Me.EstimateMarkupAmount = JobDetailItem.EstimateMarkupAmount
        '    Me.EstimateCostAmount = JobDetailItem.EstimateCostAmount
        '    Me.IsEstimateNonBillable = JobDetailItem.IsEstimateNonBillable
        '    Me.EstimateFeeTime = JobDetailItem.EstimateFeeTime
        '    Me.EstimateNetAmount = JobDetailItem.EstimateNetAmount
        '    Me.PurchaseOrderNumber = JobDetailItem.PurchaseOrderNumber
        '    Me.OpenPurchaseOrderAmount = JobDetailItem.OpenPurchaseOrderAmount
        '    Me.OpenPurchaseOrderGrossAmount = JobDetailItem.OpenPurchaseOrderGrossAmount
        '    Me.IsNewBusiness = JobDetailItem.IsNewBusiness
        '    Me.Agency = JobDetailItem.Agency
        '    Me.BillingApprovalHours = JobDetailItem.BillingApprovalHours
        '    Me.BillingApprovalCostAmount = JobDetailItem.BillingApprovalCostAmount
        '    Me.BillingApprovalExtNetAmount = JobDetailItem.BillingApprovalExtNetAmount
        '    Me.BillingApprovalTotalAmount = JobDetailItem.BillingApprovalTotalAmount
        '    Me.ProductUDF1 = JobDetailItem.ProductUDF1
        '    Me.ProductUDF2 = JobDetailItem.ProductUDF2
        '    Me.ProductUDF3 = JobDetailItem.ProductUDF3
        '    Me.ProductUDF4 = JobDetailItem.ProductUDF4

        'End Sub
        'Public Sub New(ByVal JobDetailItem As AdvantageFramework.Database.Views.JobDetailItemES)

        '    Me.ID = JobDetailItem.ID
        '    Me.ResourceType = JobDetailItem.ResourceType
        '    Me.JobNumber = JobDetailItem.JobNumber
        '    Me.JobComponentNumber = JobDetailItem.JobComponentNumber
        '    Me.OfficeCode = JobDetailItem.OfficeCode
        '    Me.OfficeDescription = JobDetailItem.OfficeDescription
        '    Me.ClientCode = JobDetailItem.ClientCode
        '    Me.ClientDescription = JobDetailItem.ClientDescription
        '    Me.DivisionCode = JobDetailItem.DivisionCode
        '    Me.DivisionDescription = JobDetailItem.DivisionDescription
        '    Me.ProductCode = JobDetailItem.ProductCode
        '    Me.ProductDescription = JobDetailItem.ProductDescription
        '    Me.CampaignID = JobDetailItem.CampaignID
        '    Me.CampaignCode = JobDetailItem.CampaignCode
        '    Me.CampaignName = JobDetailItem.CampaignName
        '    Me.SalesClassCode = JobDetailItem.SalesClassCode
        '    Me.SalesClassDescription = JobDetailItem.SalesClassDescription
        '    Me.UserCode = JobDetailItem.UserCode
        '    Me.JobCreateDate = JobDetailItem.JobCreateDate
        '    Me.JobDescription = JobDetailItem.JobDescription
        '    Me.JobDateOpened = JobDetailItem.JobDateOpened
        '    Me.RushChargesApproved = JobDetailItem.RushChargesApproved
        '    Me.ApprovedEstimateRequired = JobDetailItem.ApprovedEstimateRequired
        '    Me.Comment = JobDetailItem.Comment
        '    Me.ClientReference = JobDetailItem.ClientReference
        '    Me.BillingCoopCode = JobDetailItem.BillingCoopCode
        '    Me.SalesClassFormatCode = JobDetailItem.SalesClassFormatCode
        '    Me.ComplexityCode = JobDetailItem.ComplexityCode
        '    Me.PromotionCode = JobDetailItem.PromotionCode
        '    Me.BillingComment = JobDetailItem.BillingComment
        '    Me.LabelFromUDFTable1 = JobDetailItem.LabelFromUDFTable1
        '    Me.LabelFromUDFTable2 = JobDetailItem.LabelFromUDFTable2
        '    Me.LabelFromUDFTable3 = JobDetailItem.LabelFromUDFTable3
        '    Me.LabelFromUDFTable4 = JobDetailItem.LabelFromUDFTable4
        '    Me.LabelFromUDFTable5 = JobDetailItem.LabelFromUDFTable5
        '    Me.JobOpen = JobDetailItem.JobOpen
        '    Me.JobComponent = JobDetailItem.JobComponent
        '    Me.BillHold = JobDetailItem.BillHold
        '    Me.AccountExecutiveCode = JobDetailItem.AccountExecutiveCode
        '    Me.AccountExecutive = JobDetailItem.AccountExecutive
        '    Me.ComponentDateOpened = JobDetailItem.ComponentDateOpened
        '    Me.DueDate = JobDetailItem.DueDate
        '    Me.StartDate = JobDetailItem.StartDate
        '    Me.AdSize = JobDetailItem.AdSize
        '    Me.DepartmentTeamCode = JobDetailItem.DepartmentTeamCode
        '    Me.DepartmentTeam = JobDetailItem.DepartmentTeam
        '    Me.MarkupPercent = JobDetailItem.MarkupPercent
        '    Me.CreativeInstructions = JobDetailItem.CreativeInstructions
        '    Me.JobProcessControl = JobDetailItem.JobProcessControl
        '    Me.ComponentDescription = JobDetailItem.ComponentDescription
        '    Me.ComponentComments = JobDetailItem.ComponentComments
        '    Me.ComponentBudget = JobDetailItem.ComponentBudget
        '    Me.EstimateNumber = JobDetailItem.EstimateNumber
        '    Me.EstimateComponentNumber = JobDetailItem.EstimateComponentNumber
        '    Me.BillingUser = JobDetailItem.BillingUser
        '    Me.AdvanceBillFlag = JobDetailItem.AdvanceBillFlag
        '    Me.DeliveryInstructions = JobDetailItem.DeliveryInstructions
        '    Me.JobTypeCode = JobDetailItem.JobTypeCode
        '    Me.JobTypeDescription = JobDetailItem.JobTypeDescription
        '    Me.Taxable = JobDetailItem.Taxable
        '    Me.TaxCode = JobDetailItem.TaxCode
        '    Me.TaxCodeDescription = JobDetailItem.TaxCodeDescription
        '    Me.NonBillable = JobDetailItem.NonBillable
        '    Me.AlertGroup = JobDetailItem.AlertGroup
        '    Me.AdNumber = JobDetailItem.AdNumber
        '    Me.AccountNumber = JobDetailItem.AccountNumber
        '    Me.IncomeRecognitionMethod = JobDetailItem.IncomeRecognitionMethod
        '    Me.MarketCode = JobDetailItem.MarketCode
        '    Me.MarketDescription = JobDetailItem.MarketDescription
        '    Me.ServiceFeeJob = JobDetailItem.ServiceFeeJob
        '    Me.ServiceFeeTypeCode = JobDetailItem.ServiceFeeTypeCode
        '    Me.ServiceFeeTypeDescription = JobDetailItem.ServiceFeeTypeDescription
        '    Me.Archived = JobDetailItem.Archived
        '    Me.TrafficScheduleRequired = JobDetailItem.TrafficScheduleRequired
        '    Me.ClientPO = JobDetailItem.ClientPO
        '    Me.CompLabelFromUDFTable1 = JobDetailItem.CompLabelFromUDFTable1
        '    Me.CompLabelFromUDFTable2 = JobDetailItem.CompLabelFromUDFTable2
        '    Me.CompLabelFromUDFTable3 = JobDetailItem.CompLabelFromUDFTable3
        '    Me.CompLabelFromUDFTable4 = JobDetailItem.CompLabelFromUDFTable4
        '    Me.CompLabelFromUDFTable5 = JobDetailItem.CompLabelFromUDFTable5
        '    Me.JobTemplateCode = JobDetailItem.JobTemplateCode
        '    Me.FiscalPeriodCode = JobDetailItem.FiscalPeriodCode
        '    Me.FiscalPeriodDescription = JobDetailItem.FiscalPeriodDescription
        '    Me.JobQuantity = JobDetailItem.JobQuantity
        '    Me.BlackplateVersionCode = JobDetailItem.BlackplateVersionCode
        '    Me.BlackplateVersionDesc = JobDetailItem.BlackplateVersionDesc
        '    Me.ClientContactCode = JobDetailItem.ClientContactCode
        '    Me.ClientContactID = JobDetailItem.ClientContactID
        '    Me.BABatchID = JobDetailItem.BABatchID
        '    Me.ClientContact = JobDetailItem.ClientContact
        '    Me.SelectedBABatchID = JobDetailItem.SelectedBABatchID
        '    Me.BillingCommandCenterID = JobDetailItem.BillingCommandCenterID
        '    Me.AlertAssignmentTemplate = JobDetailItem.AlertAssignmentTemplate
        '    Me.FunctionType = JobDetailItem.FunctionType
        '    Me.FunctionConsolidationCode = JobDetailItem.FunctionConsolidationCode
        '    Me.FunctionConsolidation = JobDetailItem.FunctionConsolidation
        '    Me.FunctionHeading = JobDetailItem.FunctionHeading
        '    Me.FunctionCode = JobDetailItem.FunctionCode
        '    Me.FunctionDescription = JobDetailItem.FunctionDescription
        '    Me.ItemID = JobDetailItem.ItemID
        '    Me.ItemSequenceNumber = JobDetailItem.ItemSequenceNumber
        '    Me.ItemDate = JobDetailItem.ItemDate
        '    Me.PostPeriodCode = JobDetailItem.PostPeriodCode
        '    Me.ItemCode = JobDetailItem.ItemCode
        '    Me.ItemDescription = JobDetailItem.ItemDescription
        '    Me.ItemComment = JobDetailItem.ItemComment
        '    Me.ItemExtra = JobDetailItem.ItemExtra
        '    Me.Hours = JobDetailItem.Hours
        '    Me.Quantity = JobDetailItem.Quantity
        '    Me.NetAmount = JobDetailItem.NetAmount
        '    Me.CostAmount = JobDetailItem.CostAmount
        '    Me.ExtMarkupAmount = JobDetailItem.ExtMarkupAmount
        '    Me.NonResaleTaxAmount = JobDetailItem.NonResaleTaxAmount
        '    Me.ResaleTaxAmount = JobDetailItem.ResaleTaxAmount
        '    Me.Total = JobDetailItem.Total
        '    Me.BillableLessResale = JobDetailItem.BillableLessResale
        '    Me.BillableTotal = JobDetailItem.BillableTotal
        '    Me.FeeTime = JobDetailItem.FeeTime
        '    Me.FeeTimeHours = JobDetailItem.FeeTimeHours
        '    Me.FeeTimeAmount = JobDetailItem.FeeTimeAmount
        '    Me.NonBillableHours = JobDetailItem.NonBillableHours
        '    Me.NonBillableQuantity = JobDetailItem.NonBillableQuantity
        '    Me.NonBillableAmount = JobDetailItem.NonBillableAmount
        '    Me.BilledHours = JobDetailItem.BilledHours
        '    Me.BilledQuantity = JobDetailItem.BilledQuantity
        '    Me.BilledAmount = JobDetailItem.BilledAmount
        '    Me.BilledWithResale = JobDetailItem.BilledWithResale
        '    Me.AccountsReceivablePostPeriodCode = JobDetailItem.AccountsReceivablePostPeriodCode
        '    Me.AccountsReceivableInvoiceNumber = JobDetailItem.AccountsReceivableInvoiceNumber
        '    Me.AccountsReceivableInvoiceType = JobDetailItem.AccountsReceivableInvoiceType
        '    Me.UnbilledHours = JobDetailItem.UnbilledHours
        '    Me.UnbilledQuantity = JobDetailItem.UnbilledQuantity
        '    Me.UnbilledAmount = JobDetailItem.UnbilledAmount
        '    Me.UnbilledAmountLessResale = JobDetailItem.UnbilledAmountLessResale
        '    Me.AdvanceBillFlagDetail = JobDetailItem.AdvanceBillFlagDetail
        '    Me.IsNonBillable = JobDetailItem.IsNonBillable
        '    Me.GlexActBill = JobDetailItem.GlexActBill
        '    Me.EstimateHours = JobDetailItem.EstimateHours
        '    Me.EstimateQuantity = JobDetailItem.EstimateQuantity
        '    Me.EstimateTotalAmount = JobDetailItem.EstimateTotalAmount
        '    Me.EstimateContTotalAmount = JobDetailItem.EstimateContTotalAmount
        '    Me.EstimateNonResaleTaxAmount = JobDetailItem.EstimateNonResaleTaxAmount
        '    Me.EstimateResaleTaxAmount = JobDetailItem.EstimateResaleTaxAmount
        '    Me.EstimateMarkupAmount = JobDetailItem.EstimateMarkupAmount
        '    Me.EstimateCostAmount = JobDetailItem.EstimateCostAmount
        '    Me.IsEstimateNonBillable = JobDetailItem.IsEstimateNonBillable
        '    Me.EstimateFeeTime = JobDetailItem.EstimateFeeTime
        '    Me.EstimateNetAmount = JobDetailItem.EstimateNetAmount
        '    Me.PurchaseOrderNumber = JobDetailItem.PurchaseOrderNumber
        '    Me.OpenPurchaseOrderAmount = JobDetailItem.OpenPurchaseOrderAmount
        '    Me.OpenPurchaseOrderGrossAmount = JobDetailItem.OpenPurchaseOrderGrossAmount
        '    Me.IsNewBusiness = JobDetailItem.IsNewBusiness
        '    Me.Agency = JobDetailItem.Agency
        '    Me.BillingApprovalHours = JobDetailItem.BillingApprovalHours
        '    Me.BillingApprovalCostAmount = JobDetailItem.BillingApprovalCostAmount
        '    Me.BillingApprovalExtNetAmount = JobDetailItem.BillingApprovalExtNetAmount
        '    Me.BillingApprovalTotalAmount = JobDetailItem.BillingApprovalTotalAmount
        '    Me.ProductUDF1 = JobDetailItem.ProductUDF1
        '    Me.ProductUDF2 = JobDetailItem.ProductUDF2
        '    Me.ProductUDF3 = JobDetailItem.ProductUDF3
        '    Me.ProductUDF4 = JobDetailItem.ProductUDF4

        'End Sub
        'Public Sub New(ByVal JobDetailItem As AdvantageFramework.Database.Views.JobDetailItemI)

        '    Me.ID = JobDetailItem.ID
        '    Me.ResourceType = JobDetailItem.ResourceType
        '    Me.JobNumber = JobDetailItem.JobNumber
        '    Me.JobComponentNumber = JobDetailItem.JobComponentNumber
        '    Me.OfficeCode = JobDetailItem.OfficeCode
        '    Me.OfficeDescription = JobDetailItem.OfficeDescription
        '    Me.ClientCode = JobDetailItem.ClientCode
        '    Me.ClientDescription = JobDetailItem.ClientDescription
        '    Me.DivisionCode = JobDetailItem.DivisionCode
        '    Me.DivisionDescription = JobDetailItem.DivisionDescription
        '    Me.ProductCode = JobDetailItem.ProductCode
        '    Me.ProductDescription = JobDetailItem.ProductDescription
        '    Me.CampaignID = JobDetailItem.CampaignID
        '    Me.CampaignCode = JobDetailItem.CampaignCode
        '    Me.CampaignName = JobDetailItem.CampaignName
        '    Me.SalesClassCode = JobDetailItem.SalesClassCode
        '    Me.SalesClassDescription = JobDetailItem.SalesClassDescription
        '    Me.UserCode = JobDetailItem.UserCode
        '    Me.JobCreateDate = JobDetailItem.JobCreateDate
        '    Me.JobDescription = JobDetailItem.JobDescription
        '    Me.JobDateOpened = JobDetailItem.JobDateOpened
        '    Me.RushChargesApproved = JobDetailItem.RushChargesApproved
        '    Me.ApprovedEstimateRequired = JobDetailItem.ApprovedEstimateRequired
        '    Me.Comment = JobDetailItem.Comment
        '    Me.ClientReference = JobDetailItem.ClientReference
        '    Me.BillingCoopCode = JobDetailItem.BillingCoopCode
        '    Me.SalesClassFormatCode = JobDetailItem.SalesClassFormatCode
        '    Me.ComplexityCode = JobDetailItem.ComplexityCode
        '    Me.PromotionCode = JobDetailItem.PromotionCode
        '    Me.BillingComment = JobDetailItem.BillingComment
        '    Me.LabelFromUDFTable1 = JobDetailItem.LabelFromUDFTable1
        '    Me.LabelFromUDFTable2 = JobDetailItem.LabelFromUDFTable2
        '    Me.LabelFromUDFTable3 = JobDetailItem.LabelFromUDFTable3
        '    Me.LabelFromUDFTable4 = JobDetailItem.LabelFromUDFTable4
        '    Me.LabelFromUDFTable5 = JobDetailItem.LabelFromUDFTable5
        '    Me.JobOpen = JobDetailItem.JobOpen
        '    Me.JobComponent = JobDetailItem.JobComponent
        '    Me.BillHold = JobDetailItem.BillHold
        '    Me.AccountExecutiveCode = JobDetailItem.AccountExecutiveCode
        '    Me.AccountExecutive = JobDetailItem.AccountExecutive
        '    Me.ComponentDateOpened = JobDetailItem.ComponentDateOpened
        '    Me.DueDate = JobDetailItem.DueDate
        '    Me.StartDate = JobDetailItem.StartDate
        '    Me.AdSize = JobDetailItem.AdSize
        '    Me.DepartmentTeamCode = JobDetailItem.DepartmentTeamCode
        '    Me.DepartmentTeam = JobDetailItem.DepartmentTeam
        '    Me.MarkupPercent = JobDetailItem.MarkupPercent
        '    Me.CreativeInstructions = JobDetailItem.CreativeInstructions
        '    Me.JobProcessControl = JobDetailItem.JobProcessControl
        '    Me.ComponentDescription = JobDetailItem.ComponentDescription
        '    Me.ComponentComments = JobDetailItem.ComponentComments
        '    Me.ComponentBudget = JobDetailItem.ComponentBudget
        '    Me.EstimateNumber = JobDetailItem.EstimateNumber
        '    Me.EstimateComponentNumber = JobDetailItem.EstimateComponentNumber
        '    Me.BillingUser = JobDetailItem.BillingUser
        '    Me.AdvanceBillFlag = JobDetailItem.AdvanceBillFlag
        '    Me.DeliveryInstructions = JobDetailItem.DeliveryInstructions
        '    Me.JobTypeCode = JobDetailItem.JobTypeCode
        '    Me.JobTypeDescription = JobDetailItem.JobTypeDescription
        '    Me.Taxable = JobDetailItem.Taxable
        '    Me.TaxCode = JobDetailItem.TaxCode
        '    Me.TaxCodeDescription = JobDetailItem.TaxCodeDescription
        '    Me.NonBillable = JobDetailItem.NonBillable
        '    Me.AlertGroup = JobDetailItem.AlertGroup
        '    Me.AdNumber = JobDetailItem.AdNumber
        '    Me.AccountNumber = JobDetailItem.AccountNumber
        '    Me.IncomeRecognitionMethod = JobDetailItem.IncomeRecognitionMethod
        '    Me.MarketCode = JobDetailItem.MarketCode
        '    Me.MarketDescription = JobDetailItem.MarketDescription
        '    Me.ServiceFeeJob = JobDetailItem.ServiceFeeJob
        '    Me.ServiceFeeTypeCode = JobDetailItem.ServiceFeeTypeCode
        '    Me.ServiceFeeTypeDescription = JobDetailItem.ServiceFeeTypeDescription
        '    Me.Archived = JobDetailItem.Archived
        '    Me.TrafficScheduleRequired = JobDetailItem.TrafficScheduleRequired
        '    Me.ClientPO = JobDetailItem.ClientPO
        '    Me.CompLabelFromUDFTable1 = JobDetailItem.CompLabelFromUDFTable1
        '    Me.CompLabelFromUDFTable2 = JobDetailItem.CompLabelFromUDFTable2
        '    Me.CompLabelFromUDFTable3 = JobDetailItem.CompLabelFromUDFTable3
        '    Me.CompLabelFromUDFTable4 = JobDetailItem.CompLabelFromUDFTable4
        '    Me.CompLabelFromUDFTable5 = JobDetailItem.CompLabelFromUDFTable5
        '    Me.JobTemplateCode = JobDetailItem.JobTemplateCode
        '    Me.FiscalPeriodCode = JobDetailItem.FiscalPeriodCode
        '    Me.FiscalPeriodDescription = JobDetailItem.FiscalPeriodDescription
        '    Me.JobQuantity = JobDetailItem.JobQuantity
        '    Me.BlackplateVersionCode = JobDetailItem.BlackplateVersionCode
        '    Me.BlackplateVersionDesc = JobDetailItem.BlackplateVersionDesc
        '    Me.ClientContactCode = JobDetailItem.ClientContactCode
        '    Me.ClientContactID = JobDetailItem.ClientContactID
        '    Me.BABatchID = JobDetailItem.BABatchID
        '    Me.ClientContact = JobDetailItem.ClientContact
        '    Me.SelectedBABatchID = JobDetailItem.SelectedBABatchID
        '    Me.BillingCommandCenterID = JobDetailItem.BillingCommandCenterID
        '    Me.AlertAssignmentTemplate = JobDetailItem.AlertAssignmentTemplate
        '    Me.FunctionType = JobDetailItem.FunctionType
        '    Me.FunctionConsolidationCode = JobDetailItem.FunctionConsolidationCode
        '    Me.FunctionConsolidation = JobDetailItem.FunctionConsolidation
        '    Me.FunctionHeading = JobDetailItem.FunctionHeading
        '    Me.FunctionCode = JobDetailItem.FunctionCode
        '    Me.FunctionDescription = JobDetailItem.FunctionDescription
        '    Me.ItemID = JobDetailItem.ItemID
        '    Me.ItemSequenceNumber = JobDetailItem.ItemSequenceNumber
        '    Me.ItemDate = JobDetailItem.ItemDate
        '    Me.PostPeriodCode = JobDetailItem.PostPeriodCode
        '    Me.ItemCode = JobDetailItem.ItemCode
        '    Me.ItemDescription = JobDetailItem.ItemDescription
        '    Me.ItemComment = JobDetailItem.ItemComment
        '    Me.ItemExtra = JobDetailItem.ItemExtra
        '    Me.Hours = JobDetailItem.Hours
        '    Me.Quantity = JobDetailItem.Quantity
        '    Me.NetAmount = JobDetailItem.NetAmount
        '    Me.CostAmount = JobDetailItem.CostAmount
        '    Me.ExtMarkupAmount = JobDetailItem.ExtMarkupAmount
        '    Me.NonResaleTaxAmount = JobDetailItem.NonResaleTaxAmount
        '    Me.ResaleTaxAmount = JobDetailItem.ResaleTaxAmount
        '    Me.Total = JobDetailItem.Total
        '    Me.BillableLessResale = JobDetailItem.BillableLessResale
        '    Me.BillableTotal = JobDetailItem.BillableTotal
        '    Me.FeeTime = JobDetailItem.FeeTime
        '    Me.FeeTimeHours = JobDetailItem.FeeTimeHours
        '    Me.FeeTimeAmount = JobDetailItem.FeeTimeAmount
        '    Me.NonBillableHours = JobDetailItem.NonBillableHours
        '    Me.NonBillableQuantity = JobDetailItem.NonBillableQuantity
        '    Me.NonBillableAmount = JobDetailItem.NonBillableAmount
        '    Me.BilledHours = JobDetailItem.BilledHours
        '    Me.BilledQuantity = JobDetailItem.BilledQuantity
        '    Me.BilledAmount = JobDetailItem.BilledAmount
        '    Me.BilledWithResale = JobDetailItem.BilledWithResale
        '    Me.AccountsReceivablePostPeriodCode = JobDetailItem.AccountsReceivablePostPeriodCode
        '    Me.AccountsReceivableInvoiceNumber = JobDetailItem.AccountsReceivableInvoiceNumber
        '    Me.AccountsReceivableInvoiceType = JobDetailItem.AccountsReceivableInvoiceType
        '    Me.UnbilledHours = JobDetailItem.UnbilledHours
        '    Me.UnbilledQuantity = JobDetailItem.UnbilledQuantity
        '    Me.UnbilledAmount = JobDetailItem.UnbilledAmount
        '    Me.UnbilledAmountLessResale = JobDetailItem.UnbilledAmountLessResale
        '    Me.AdvanceBillFlagDetail = JobDetailItem.AdvanceBillFlagDetail
        '    Me.IsNonBillable = JobDetailItem.IsNonBillable
        '    Me.GlexActBill = JobDetailItem.GlexActBill
        '    Me.EstimateHours = JobDetailItem.EstimateHours
        '    Me.EstimateQuantity = JobDetailItem.EstimateQuantity
        '    Me.EstimateTotalAmount = JobDetailItem.EstimateTotalAmount
        '    Me.EstimateContTotalAmount = JobDetailItem.EstimateContTotalAmount
        '    Me.EstimateNonResaleTaxAmount = JobDetailItem.EstimateNonResaleTaxAmount
        '    Me.EstimateResaleTaxAmount = JobDetailItem.EstimateResaleTaxAmount
        '    Me.EstimateMarkupAmount = JobDetailItem.EstimateMarkupAmount
        '    Me.EstimateCostAmount = JobDetailItem.EstimateCostAmount
        '    Me.IsEstimateNonBillable = JobDetailItem.IsEstimateNonBillable
        '    Me.EstimateFeeTime = JobDetailItem.EstimateFeeTime
        '    Me.EstimateNetAmount = JobDetailItem.EstimateNetAmount
        '    Me.PurchaseOrderNumber = JobDetailItem.PurchaseOrderNumber
        '    Me.OpenPurchaseOrderAmount = JobDetailItem.OpenPurchaseOrderAmount
        '    Me.OpenPurchaseOrderGrossAmount = JobDetailItem.OpenPurchaseOrderGrossAmount
        '    Me.IsNewBusiness = JobDetailItem.IsNewBusiness
        '    Me.Agency = JobDetailItem.Agency
        '    Me.BillingApprovalHours = JobDetailItem.BillingApprovalHours
        '    Me.BillingApprovalCostAmount = JobDetailItem.BillingApprovalCostAmount
        '    Me.BillingApprovalExtNetAmount = JobDetailItem.BillingApprovalExtNetAmount
        '    Me.BillingApprovalTotalAmount = JobDetailItem.BillingApprovalTotalAmount
        '    Me.ProductUDF1 = JobDetailItem.ProductUDF1
        '    Me.ProductUDF2 = JobDetailItem.ProductUDF2
        '    Me.ProductUDF3 = JobDetailItem.ProductUDF3
        '    Me.ProductUDF4 = JobDetailItem.ProductUDF4

        'End Sub
        'Public Sub New(ByVal JobDetailItem As AdvantageFramework.Database.Views.JobDetailItemPO)

        '    Me.ID = JobDetailItem.ID
        '    Me.ResourceType = JobDetailItem.ResourceType
        '    Me.JobNumber = JobDetailItem.JobNumber
        '    Me.JobComponentNumber = JobDetailItem.JobComponentNumber
        '    Me.OfficeCode = JobDetailItem.OfficeCode
        '    Me.OfficeDescription = JobDetailItem.OfficeDescription
        '    Me.ClientCode = JobDetailItem.ClientCode
        '    Me.ClientDescription = JobDetailItem.ClientDescription
        '    Me.DivisionCode = JobDetailItem.DivisionCode
        '    Me.DivisionDescription = JobDetailItem.DivisionDescription
        '    Me.ProductCode = JobDetailItem.ProductCode
        '    Me.ProductDescription = JobDetailItem.ProductDescription
        '    Me.CampaignID = JobDetailItem.CampaignID
        '    Me.CampaignCode = JobDetailItem.CampaignCode
        '    Me.CampaignName = JobDetailItem.CampaignName
        '    Me.SalesClassCode = JobDetailItem.SalesClassCode
        '    Me.SalesClassDescription = JobDetailItem.SalesClassDescription
        '    Me.UserCode = JobDetailItem.UserCode
        '    Me.JobCreateDate = JobDetailItem.JobCreateDate
        '    Me.JobDescription = JobDetailItem.JobDescription
        '    Me.JobDateOpened = JobDetailItem.JobDateOpened
        '    Me.RushChargesApproved = JobDetailItem.RushChargesApproved
        '    Me.ApprovedEstimateRequired = JobDetailItem.ApprovedEstimateRequired
        '    Me.Comment = JobDetailItem.Comment
        '    Me.ClientReference = JobDetailItem.ClientReference
        '    Me.BillingCoopCode = JobDetailItem.BillingCoopCode
        '    Me.SalesClassFormatCode = JobDetailItem.SalesClassFormatCode
        '    Me.ComplexityCode = JobDetailItem.ComplexityCode
        '    Me.PromotionCode = JobDetailItem.PromotionCode
        '    Me.BillingComment = JobDetailItem.BillingComment
        '    Me.LabelFromUDFTable1 = JobDetailItem.LabelFromUDFTable1
        '    Me.LabelFromUDFTable2 = JobDetailItem.LabelFromUDFTable2
        '    Me.LabelFromUDFTable3 = JobDetailItem.LabelFromUDFTable3
        '    Me.LabelFromUDFTable4 = JobDetailItem.LabelFromUDFTable4
        '    Me.LabelFromUDFTable5 = JobDetailItem.LabelFromUDFTable5
        '    Me.JobOpen = JobDetailItem.JobOpen
        '    Me.JobComponent = JobDetailItem.JobComponent
        '    Me.BillHold = JobDetailItem.BillHold
        '    Me.AccountExecutiveCode = JobDetailItem.AccountExecutiveCode
        '    Me.AccountExecutive = JobDetailItem.AccountExecutive
        '    Me.ComponentDateOpened = JobDetailItem.ComponentDateOpened
        '    Me.DueDate = JobDetailItem.DueDate
        '    Me.StartDate = JobDetailItem.StartDate
        '    Me.AdSize = JobDetailItem.AdSize
        '    Me.DepartmentTeamCode = JobDetailItem.DepartmentTeamCode
        '    Me.DepartmentTeam = JobDetailItem.DepartmentTeam
        '    Me.MarkupPercent = JobDetailItem.MarkupPercent
        '    Me.CreativeInstructions = JobDetailItem.CreativeInstructions
        '    Me.JobProcessControl = JobDetailItem.JobProcessControl
        '    Me.ComponentDescription = JobDetailItem.ComponentDescription
        '    Me.ComponentComments = JobDetailItem.ComponentComments
        '    Me.ComponentBudget = JobDetailItem.ComponentBudget
        '    Me.EstimateNumber = JobDetailItem.EstimateNumber
        '    Me.EstimateComponentNumber = JobDetailItem.EstimateComponentNumber
        '    Me.BillingUser = JobDetailItem.BillingUser
        '    Me.AdvanceBillFlag = JobDetailItem.AdvanceBillFlag
        '    Me.DeliveryInstructions = JobDetailItem.DeliveryInstructions
        '    Me.JobTypeCode = JobDetailItem.JobTypeCode
        '    Me.JobTypeDescription = JobDetailItem.JobTypeDescription
        '    Me.Taxable = JobDetailItem.Taxable
        '    Me.TaxCode = JobDetailItem.TaxCode
        '    Me.TaxCodeDescription = JobDetailItem.TaxCodeDescription
        '    Me.NonBillable = JobDetailItem.NonBillable
        '    Me.AlertGroup = JobDetailItem.AlertGroup
        '    Me.AdNumber = JobDetailItem.AdNumber
        '    Me.AccountNumber = JobDetailItem.AccountNumber
        '    Me.IncomeRecognitionMethod = JobDetailItem.IncomeRecognitionMethod
        '    Me.MarketCode = JobDetailItem.MarketCode
        '    Me.MarketDescription = JobDetailItem.MarketDescription
        '    Me.ServiceFeeJob = JobDetailItem.ServiceFeeJob
        '    Me.ServiceFeeTypeCode = JobDetailItem.ServiceFeeTypeCode
        '    Me.ServiceFeeTypeDescription = JobDetailItem.ServiceFeeTypeDescription
        '    Me.Archived = JobDetailItem.Archived
        '    Me.TrafficScheduleRequired = JobDetailItem.TrafficScheduleRequired
        '    Me.ClientPO = JobDetailItem.ClientPO
        '    Me.CompLabelFromUDFTable1 = JobDetailItem.CompLabelFromUDFTable1
        '    Me.CompLabelFromUDFTable2 = JobDetailItem.CompLabelFromUDFTable2
        '    Me.CompLabelFromUDFTable3 = JobDetailItem.CompLabelFromUDFTable3
        '    Me.CompLabelFromUDFTable4 = JobDetailItem.CompLabelFromUDFTable4
        '    Me.CompLabelFromUDFTable5 = JobDetailItem.CompLabelFromUDFTable5
        '    Me.JobTemplateCode = JobDetailItem.JobTemplateCode
        '    Me.FiscalPeriodCode = JobDetailItem.FiscalPeriodCode
        '    Me.FiscalPeriodDescription = JobDetailItem.FiscalPeriodDescription
        '    Me.JobQuantity = JobDetailItem.JobQuantity
        '    Me.BlackplateVersionCode = JobDetailItem.BlackplateVersionCode
        '    Me.BlackplateVersionDesc = JobDetailItem.BlackplateVersionDesc
        '    Me.ClientContactCode = JobDetailItem.ClientContactCode
        '    Me.ClientContactID = JobDetailItem.ClientContactID
        '    Me.BABatchID = JobDetailItem.BABatchID
        '    Me.ClientContact = JobDetailItem.ClientContact
        '    Me.SelectedBABatchID = JobDetailItem.SelectedBABatchID
        '    Me.BillingCommandCenterID = JobDetailItem.BillingCommandCenterID
        '    Me.AlertAssignmentTemplate = JobDetailItem.AlertAssignmentTemplate
        '    Me.FunctionType = JobDetailItem.FunctionType
        '    Me.FunctionConsolidationCode = JobDetailItem.FunctionConsolidationCode
        '    Me.FunctionConsolidation = JobDetailItem.FunctionConsolidation
        '    Me.FunctionHeading = JobDetailItem.FunctionHeading
        '    Me.FunctionCode = JobDetailItem.FunctionCode
        '    Me.FunctionDescription = JobDetailItem.FunctionDescription
        '    Me.ItemID = JobDetailItem.ItemID
        '    Me.ItemSequenceNumber = JobDetailItem.ItemSequenceNumber
        '    Me.ItemDate = JobDetailItem.ItemDate
        '    Me.PostPeriodCode = JobDetailItem.PostPeriodCode
        '    Me.ItemCode = JobDetailItem.ItemCode
        '    Me.ItemDescription = JobDetailItem.ItemDescription
        '    Me.ItemComment = JobDetailItem.ItemComment
        '    Me.ItemExtra = JobDetailItem.ItemExtra
        '    Me.Hours = JobDetailItem.Hours
        '    Me.Quantity = JobDetailItem.Quantity
        '    Me.NetAmount = JobDetailItem.NetAmount
        '    Me.CostAmount = JobDetailItem.CostAmount
        '    Me.ExtMarkupAmount = JobDetailItem.ExtMarkupAmount
        '    Me.NonResaleTaxAmount = JobDetailItem.NonResaleTaxAmount
        '    Me.ResaleTaxAmount = JobDetailItem.ResaleTaxAmount
        '    Me.Total = JobDetailItem.Total
        '    Me.BillableLessResale = JobDetailItem.BillableLessResale
        '    Me.BillableTotal = JobDetailItem.BillableTotal
        '    Me.FeeTime = JobDetailItem.FeeTime
        '    Me.FeeTimeHours = JobDetailItem.FeeTimeHours
        '    Me.FeeTimeAmount = JobDetailItem.FeeTimeAmount
        '    Me.NonBillableHours = JobDetailItem.NonBillableHours
        '    Me.NonBillableQuantity = JobDetailItem.NonBillableQuantity
        '    Me.NonBillableAmount = JobDetailItem.NonBillableAmount
        '    Me.BilledHours = JobDetailItem.BilledHours
        '    Me.BilledQuantity = JobDetailItem.BilledQuantity
        '    Me.BilledAmount = JobDetailItem.BilledAmount
        '    Me.BilledWithResale = JobDetailItem.BilledWithResale
        '    Me.AccountsReceivablePostPeriodCode = JobDetailItem.AccountsReceivablePostPeriodCode
        '    Me.AccountsReceivableInvoiceNumber = JobDetailItem.AccountsReceivableInvoiceNumber
        '    Me.AccountsReceivableInvoiceType = JobDetailItem.AccountsReceivableInvoiceType
        '    Me.UnbilledHours = JobDetailItem.UnbilledHours
        '    Me.UnbilledQuantity = JobDetailItem.UnbilledQuantity
        '    Me.UnbilledAmount = JobDetailItem.UnbilledAmount
        '    Me.UnbilledAmountLessResale = JobDetailItem.UnbilledAmountLessResale
        '    Me.AdvanceBillFlagDetail = JobDetailItem.AdvanceBillFlagDetail
        '    Me.IsNonBillable = JobDetailItem.IsNonBillable
        '    Me.GlexActBill = JobDetailItem.GlexActBill
        '    Me.EstimateHours = JobDetailItem.EstimateHours
        '    Me.EstimateQuantity = JobDetailItem.EstimateQuantity
        '    Me.EstimateTotalAmount = JobDetailItem.EstimateTotalAmount
        '    Me.EstimateContTotalAmount = JobDetailItem.EstimateContTotalAmount
        '    Me.EstimateNonResaleTaxAmount = JobDetailItem.EstimateNonResaleTaxAmount
        '    Me.EstimateResaleTaxAmount = JobDetailItem.EstimateResaleTaxAmount
        '    Me.EstimateMarkupAmount = JobDetailItem.EstimateMarkupAmount
        '    Me.EstimateCostAmount = JobDetailItem.EstimateCostAmount
        '    Me.IsEstimateNonBillable = JobDetailItem.IsEstimateNonBillable
        '    Me.EstimateFeeTime = JobDetailItem.EstimateFeeTime
        '    Me.EstimateNetAmount = JobDetailItem.EstimateNetAmount
        '    Me.PurchaseOrderNumber = JobDetailItem.PurchaseOrderNumber
        '    Me.OpenPurchaseOrderAmount = JobDetailItem.OpenPurchaseOrderAmount
        '    Me.OpenPurchaseOrderGrossAmount = JobDetailItem.OpenPurchaseOrderGrossAmount
        '    Me.IsNewBusiness = JobDetailItem.IsNewBusiness
        '    Me.Agency = JobDetailItem.Agency
        '    Me.BillingApprovalHours = JobDetailItem.BillingApprovalHours
        '    Me.BillingApprovalCostAmount = JobDetailItem.BillingApprovalCostAmount
        '    Me.BillingApprovalExtNetAmount = JobDetailItem.BillingApprovalExtNetAmount
        '    Me.BillingApprovalTotalAmount = JobDetailItem.BillingApprovalTotalAmount
        '    Me.ProductUDF1 = JobDetailItem.ProductUDF1
        '    Me.ProductUDF2 = JobDetailItem.ProductUDF2
        '    Me.ProductUDF3 = JobDetailItem.ProductUDF3
        '    Me.ProductUDF4 = JobDetailItem.ProductUDF4

        'End Sub
        'Public Sub New(ByVal JobDetailItem As AdvantageFramework.Database.Views.JobDetailItemV)

        '    Me.ID = JobDetailItem.ID
        '    Me.ResourceType = JobDetailItem.ResourceType
        '    Me.JobNumber = JobDetailItem.JobNumber
        '    Me.JobComponentNumber = JobDetailItem.JobComponentNumber
        '    Me.OfficeCode = JobDetailItem.OfficeCode
        '    Me.OfficeDescription = JobDetailItem.OfficeDescription
        '    Me.ClientCode = JobDetailItem.ClientCode
        '    Me.ClientDescription = JobDetailItem.ClientDescription
        '    Me.DivisionCode = JobDetailItem.DivisionCode
        '    Me.DivisionDescription = JobDetailItem.DivisionDescription
        '    Me.ProductCode = JobDetailItem.ProductCode
        '    Me.ProductDescription = JobDetailItem.ProductDescription
        '    Me.CampaignID = JobDetailItem.CampaignID
        '    Me.CampaignCode = JobDetailItem.CampaignCode
        '    Me.CampaignName = JobDetailItem.CampaignName
        '    Me.SalesClassCode = JobDetailItem.SalesClassCode
        '    Me.SalesClassDescription = JobDetailItem.SalesClassDescription
        '    Me.UserCode = JobDetailItem.UserCode
        '    Me.JobCreateDate = JobDetailItem.JobCreateDate
        '    Me.JobDescription = JobDetailItem.JobDescription
        '    Me.JobDateOpened = JobDetailItem.JobDateOpened
        '    Me.RushChargesApproved = JobDetailItem.RushChargesApproved
        '    Me.ApprovedEstimateRequired = JobDetailItem.ApprovedEstimateRequired
        '    Me.Comment = JobDetailItem.Comment
        '    Me.ClientReference = JobDetailItem.ClientReference
        '    Me.BillingCoopCode = JobDetailItem.BillingCoopCode
        '    Me.SalesClassFormatCode = JobDetailItem.SalesClassFormatCode
        '    Me.ComplexityCode = JobDetailItem.ComplexityCode
        '    Me.PromotionCode = JobDetailItem.PromotionCode
        '    Me.BillingComment = JobDetailItem.BillingComment
        '    Me.LabelFromUDFTable1 = JobDetailItem.LabelFromUDFTable1
        '    Me.LabelFromUDFTable2 = JobDetailItem.LabelFromUDFTable2
        '    Me.LabelFromUDFTable3 = JobDetailItem.LabelFromUDFTable3
        '    Me.LabelFromUDFTable4 = JobDetailItem.LabelFromUDFTable4
        '    Me.LabelFromUDFTable5 = JobDetailItem.LabelFromUDFTable5
        '    Me.JobOpen = JobDetailItem.JobOpen
        '    Me.JobComponent = JobDetailItem.JobComponent
        '    Me.BillHold = JobDetailItem.BillHold
        '    Me.AccountExecutiveCode = JobDetailItem.AccountExecutiveCode
        '    Me.AccountExecutive = JobDetailItem.AccountExecutive
        '    Me.ComponentDateOpened = JobDetailItem.ComponentDateOpened
        '    Me.DueDate = JobDetailItem.DueDate
        '    Me.StartDate = JobDetailItem.StartDate
        '    Me.AdSize = JobDetailItem.AdSize
        '    Me.DepartmentTeamCode = JobDetailItem.DepartmentTeamCode
        '    Me.DepartmentTeam = JobDetailItem.DepartmentTeam
        '    Me.MarkupPercent = JobDetailItem.MarkupPercent
        '    Me.CreativeInstructions = JobDetailItem.CreativeInstructions
        '    Me.JobProcessControl = JobDetailItem.JobProcessControl
        '    Me.ComponentDescription = JobDetailItem.ComponentDescription
        '    Me.ComponentComments = JobDetailItem.ComponentComments
        '    Me.ComponentBudget = JobDetailItem.ComponentBudget
        '    Me.EstimateNumber = JobDetailItem.EstimateNumber
        '    Me.EstimateComponentNumber = JobDetailItem.EstimateComponentNumber
        '    Me.BillingUser = JobDetailItem.BillingUser
        '    Me.AdvanceBillFlag = JobDetailItem.AdvanceBillFlag
        '    Me.DeliveryInstructions = JobDetailItem.DeliveryInstructions
        '    Me.JobTypeCode = JobDetailItem.JobTypeCode
        '    Me.JobTypeDescription = JobDetailItem.JobTypeDescription
        '    Me.Taxable = JobDetailItem.Taxable
        '    Me.TaxCode = JobDetailItem.TaxCode
        '    Me.TaxCodeDescription = JobDetailItem.TaxCodeDescription
        '    Me.NonBillable = JobDetailItem.NonBillable
        '    Me.AlertGroup = JobDetailItem.AlertGroup
        '    Me.AdNumber = JobDetailItem.AdNumber
        '    Me.AccountNumber = JobDetailItem.AccountNumber
        '    Me.IncomeRecognitionMethod = JobDetailItem.IncomeRecognitionMethod
        '    Me.MarketCode = JobDetailItem.MarketCode
        '    Me.MarketDescription = JobDetailItem.MarketDescription
        '    Me.ServiceFeeJob = JobDetailItem.ServiceFeeJob
        '    Me.ServiceFeeTypeCode = JobDetailItem.ServiceFeeTypeCode
        '    Me.ServiceFeeTypeDescription = JobDetailItem.ServiceFeeTypeDescription
        '    Me.Archived = JobDetailItem.Archived
        '    Me.TrafficScheduleRequired = JobDetailItem.TrafficScheduleRequired
        '    Me.ClientPO = JobDetailItem.ClientPO
        '    Me.CompLabelFromUDFTable1 = JobDetailItem.CompLabelFromUDFTable1
        '    Me.CompLabelFromUDFTable2 = JobDetailItem.CompLabelFromUDFTable2
        '    Me.CompLabelFromUDFTable3 = JobDetailItem.CompLabelFromUDFTable3
        '    Me.CompLabelFromUDFTable4 = JobDetailItem.CompLabelFromUDFTable4
        '    Me.CompLabelFromUDFTable5 = JobDetailItem.CompLabelFromUDFTable5
        '    Me.JobTemplateCode = JobDetailItem.JobTemplateCode
        '    Me.FiscalPeriodCode = JobDetailItem.FiscalPeriodCode
        '    Me.FiscalPeriodDescription = JobDetailItem.FiscalPeriodDescription
        '    Me.JobQuantity = JobDetailItem.JobQuantity
        '    Me.BlackplateVersionCode = JobDetailItem.BlackplateVersionCode
        '    Me.BlackplateVersionDesc = JobDetailItem.BlackplateVersionDesc
        '    Me.ClientContactCode = JobDetailItem.ClientContactCode
        '    Me.ClientContactID = JobDetailItem.ClientContactID
        '    Me.BABatchID = JobDetailItem.BABatchID
        '    Me.ClientContact = JobDetailItem.ClientContact
        '    Me.SelectedBABatchID = JobDetailItem.SelectedBABatchID
        '    Me.BillingCommandCenterID = JobDetailItem.BillingCommandCenterID
        '    Me.AlertAssignmentTemplate = JobDetailItem.AlertAssignmentTemplate
        '    Me.FunctionType = JobDetailItem.FunctionType
        '    Me.FunctionConsolidationCode = JobDetailItem.FunctionConsolidationCode
        '    Me.FunctionConsolidation = JobDetailItem.FunctionConsolidation
        '    Me.FunctionHeading = JobDetailItem.FunctionHeading
        '    Me.FunctionCode = JobDetailItem.FunctionCode
        '    Me.FunctionDescription = JobDetailItem.FunctionDescription
        '    Me.ItemID = JobDetailItem.ItemID
        '    Me.ItemSequenceNumber = JobDetailItem.ItemSequenceNumber
        '    Me.ItemDate = JobDetailItem.ItemDate
        '    Me.PostPeriodCode = JobDetailItem.PostPeriodCode
        '    Me.ItemCode = JobDetailItem.ItemCode
        '    Me.ItemDescription = JobDetailItem.ItemDescription
        '    Me.ItemComment = JobDetailItem.ItemComment
        '    Me.ItemExtra = JobDetailItem.ItemExtra
        '    Me.Hours = JobDetailItem.Hours
        '    Me.Quantity = JobDetailItem.Quantity
        '    Me.NetAmount = JobDetailItem.NetAmount
        '    Me.CostAmount = JobDetailItem.CostAmount
        '    Me.ExtMarkupAmount = JobDetailItem.ExtMarkupAmount
        '    Me.NonResaleTaxAmount = JobDetailItem.NonResaleTaxAmount
        '    Me.ResaleTaxAmount = JobDetailItem.ResaleTaxAmount
        '    Me.Total = JobDetailItem.Total
        '    Me.BillableLessResale = JobDetailItem.BillableLessResale
        '    Me.BillableTotal = JobDetailItem.BillableTotal
        '    Me.FeeTime = JobDetailItem.FeeTime
        '    Me.FeeTimeHours = JobDetailItem.FeeTimeHours
        '    Me.FeeTimeAmount = JobDetailItem.FeeTimeAmount
        '    Me.NonBillableHours = JobDetailItem.NonBillableHours
        '    Me.NonBillableQuantity = JobDetailItem.NonBillableQuantity
        '    Me.NonBillableAmount = JobDetailItem.NonBillableAmount
        '    Me.BilledHours = JobDetailItem.BilledHours
        '    Me.BilledQuantity = JobDetailItem.BilledQuantity
        '    Me.BilledAmount = JobDetailItem.BilledAmount
        '    Me.BilledWithResale = JobDetailItem.BilledWithResale
        '    Me.AccountsReceivablePostPeriodCode = JobDetailItem.AccountsReceivablePostPeriodCode
        '    Me.AccountsReceivableInvoiceNumber = JobDetailItem.AccountsReceivableInvoiceNumber
        '    Me.AccountsReceivableInvoiceType = JobDetailItem.AccountsReceivableInvoiceType
        '    Me.UnbilledHours = JobDetailItem.UnbilledHours
        '    Me.UnbilledQuantity = JobDetailItem.UnbilledQuantity
        '    Me.UnbilledAmount = JobDetailItem.UnbilledAmount
        '    Me.UnbilledAmountLessResale = JobDetailItem.UnbilledAmountLessResale
        '    Me.AdvanceBillFlagDetail = JobDetailItem.AdvanceBillFlagDetail
        '    Me.IsNonBillable = JobDetailItem.IsNonBillable
        '    Me.GlexActBill = JobDetailItem.GlexActBill
        '    Me.EstimateHours = JobDetailItem.EstimateHours
        '    Me.EstimateQuantity = JobDetailItem.EstimateQuantity
        '    Me.EstimateTotalAmount = JobDetailItem.EstimateTotalAmount
        '    Me.EstimateContTotalAmount = JobDetailItem.EstimateContTotalAmount
        '    Me.EstimateNonResaleTaxAmount = JobDetailItem.EstimateNonResaleTaxAmount
        '    Me.EstimateResaleTaxAmount = JobDetailItem.EstimateResaleTaxAmount
        '    Me.EstimateMarkupAmount = JobDetailItem.EstimateMarkupAmount
        '    Me.EstimateCostAmount = JobDetailItem.EstimateCostAmount
        '    Me.IsEstimateNonBillable = JobDetailItem.IsEstimateNonBillable
        '    Me.EstimateFeeTime = JobDetailItem.EstimateFeeTime
        '    Me.EstimateNetAmount = JobDetailItem.EstimateNetAmount
        '    Me.PurchaseOrderNumber = JobDetailItem.PurchaseOrderNumber
        '    Me.OpenPurchaseOrderAmount = JobDetailItem.OpenPurchaseOrderAmount
        '    Me.OpenPurchaseOrderGrossAmount = JobDetailItem.OpenPurchaseOrderGrossAmount
        '    Me.IsNewBusiness = JobDetailItem.IsNewBusiness
        '    Me.Agency = JobDetailItem.Agency
        '    Me.BillingApprovalHours = JobDetailItem.BillingApprovalHours
        '    Me.BillingApprovalCostAmount = JobDetailItem.BillingApprovalCostAmount
        '    Me.BillingApprovalExtNetAmount = JobDetailItem.BillingApprovalExtNetAmount
        '    Me.BillingApprovalTotalAmount = JobDetailItem.BillingApprovalTotalAmount
        '    Me.ProductUDF1 = JobDetailItem.ProductUDF1
        '    Me.ProductUDF2 = JobDetailItem.ProductUDF2
        '    Me.ProductUDF3 = JobDetailItem.ProductUDF3
        '    Me.ProductUDF4 = JobDetailItem.ProductUDF4

        'End Sub
        'Public Sub New(ByVal JobDetailItem As AdvantageFramework.Database.Views.JobDetailItemND)

        '    Me.ID = JobDetailItem.ID
        '    Me.ResourceType = JobDetailItem.ResourceType
        '    Me.JobNumber = JobDetailItem.JobNumber
        '    Me.JobComponentNumber = JobDetailItem.JobComponentNumber
        '    Me.OfficeCode = JobDetailItem.OfficeCode
        '    Me.OfficeDescription = JobDetailItem.OfficeDescription
        '    Me.ClientCode = JobDetailItem.ClientCode
        '    Me.ClientDescription = JobDetailItem.ClientDescription
        '    Me.DivisionCode = JobDetailItem.DivisionCode
        '    Me.DivisionDescription = JobDetailItem.DivisionDescription
        '    Me.ProductCode = JobDetailItem.ProductCode
        '    Me.ProductDescription = JobDetailItem.ProductDescription
        '    Me.CampaignID = JobDetailItem.CampaignID
        '    Me.CampaignCode = JobDetailItem.CampaignCode
        '    Me.CampaignName = JobDetailItem.CampaignName
        '    Me.SalesClassCode = JobDetailItem.SalesClassCode
        '    Me.SalesClassDescription = JobDetailItem.SalesClassDescription
        '    Me.UserCode = JobDetailItem.UserCode
        '    Me.JobCreateDate = JobDetailItem.JobCreateDate
        '    Me.JobDescription = JobDetailItem.JobDescription
        '    Me.JobDateOpened = JobDetailItem.JobDateOpened
        '    Me.RushChargesApproved = JobDetailItem.RushChargesApproved
        '    Me.ApprovedEstimateRequired = JobDetailItem.ApprovedEstimateRequired
        '    Me.Comment = JobDetailItem.Comment
        '    Me.ClientReference = JobDetailItem.ClientReference
        '    Me.BillingCoopCode = JobDetailItem.BillingCoopCode
        '    Me.SalesClassFormatCode = JobDetailItem.SalesClassFormatCode
        '    Me.ComplexityCode = JobDetailItem.ComplexityCode
        '    Me.PromotionCode = JobDetailItem.PromotionCode
        '    Me.BillingComment = JobDetailItem.BillingComment
        '    Me.LabelFromUDFTable1 = JobDetailItem.LabelFromUDFTable1
        '    Me.LabelFromUDFTable2 = JobDetailItem.LabelFromUDFTable2
        '    Me.LabelFromUDFTable3 = JobDetailItem.LabelFromUDFTable3
        '    Me.LabelFromUDFTable4 = JobDetailItem.LabelFromUDFTable4
        '    Me.LabelFromUDFTable5 = JobDetailItem.LabelFromUDFTable5
        '    Me.JobOpen = JobDetailItem.JobOpen
        '    Me.JobComponent = JobDetailItem.JobComponent
        '    Me.BillHold = JobDetailItem.BillHold
        '    Me.AccountExecutiveCode = JobDetailItem.AccountExecutiveCode
        '    Me.AccountExecutive = JobDetailItem.AccountExecutive
        '    Me.ComponentDateOpened = JobDetailItem.ComponentDateOpened
        '    Me.DueDate = JobDetailItem.DueDate
        '    Me.StartDate = JobDetailItem.StartDate
        '    Me.AdSize = JobDetailItem.AdSize
        '    Me.DepartmentTeamCode = JobDetailItem.DepartmentTeamCode
        '    Me.DepartmentTeam = JobDetailItem.DepartmentTeam
        '    Me.MarkupPercent = JobDetailItem.MarkupPercent
        '    Me.CreativeInstructions = JobDetailItem.CreativeInstructions
        '    Me.JobProcessControl = JobDetailItem.JobProcessControl
        '    Me.ComponentDescription = JobDetailItem.ComponentDescription
        '    Me.ComponentComments = JobDetailItem.ComponentComments
        '    Me.ComponentBudget = JobDetailItem.ComponentBudget
        '    Me.EstimateNumber = JobDetailItem.EstimateNumber
        '    Me.EstimateComponentNumber = JobDetailItem.EstimateComponentNumber
        '    Me.BillingUser = JobDetailItem.BillingUser
        '    Me.AdvanceBillFlag = JobDetailItem.AdvanceBillFlag
        '    Me.DeliveryInstructions = JobDetailItem.DeliveryInstructions
        '    Me.JobTypeCode = JobDetailItem.JobTypeCode
        '    Me.JobTypeDescription = JobDetailItem.JobTypeDescription
        '    Me.Taxable = JobDetailItem.Taxable
        '    Me.TaxCode = JobDetailItem.TaxCode
        '    Me.TaxCodeDescription = JobDetailItem.TaxCodeDescription
        '    Me.NonBillable = JobDetailItem.NonBillable
        '    Me.AlertGroup = JobDetailItem.AlertGroup
        '    Me.AdNumber = JobDetailItem.AdNumber
        '    Me.AccountNumber = JobDetailItem.AccountNumber
        '    Me.IncomeRecognitionMethod = JobDetailItem.IncomeRecognitionMethod
        '    Me.MarketCode = JobDetailItem.MarketCode
        '    Me.MarketDescription = JobDetailItem.MarketDescription
        '    Me.ServiceFeeJob = JobDetailItem.ServiceFeeJob
        '    Me.ServiceFeeTypeCode = JobDetailItem.ServiceFeeTypeCode
        '    Me.ServiceFeeTypeDescription = JobDetailItem.ServiceFeeTypeDescription
        '    Me.Archived = JobDetailItem.Archived
        '    Me.TrafficScheduleRequired = JobDetailItem.TrafficScheduleRequired
        '    Me.ClientPO = JobDetailItem.ClientPO
        '    Me.CompLabelFromUDFTable1 = JobDetailItem.CompLabelFromUDFTable1
        '    Me.CompLabelFromUDFTable2 = JobDetailItem.CompLabelFromUDFTable2
        '    Me.CompLabelFromUDFTable3 = JobDetailItem.CompLabelFromUDFTable3
        '    Me.CompLabelFromUDFTable4 = JobDetailItem.CompLabelFromUDFTable4
        '    Me.CompLabelFromUDFTable5 = JobDetailItem.CompLabelFromUDFTable5
        '    Me.JobTemplateCode = JobDetailItem.JobTemplateCode
        '    Me.FiscalPeriodCode = JobDetailItem.FiscalPeriodCode
        '    Me.FiscalPeriodDescription = JobDetailItem.FiscalPeriodDescription
        '    Me.JobQuantity = JobDetailItem.JobQuantity
        '    Me.BlackplateVersionCode = JobDetailItem.BlackplateVersionCode
        '    Me.BlackplateVersionDesc = JobDetailItem.BlackplateVersionDesc
        '    Me.ClientContactCode = JobDetailItem.ClientContactCode
        '    Me.ClientContactID = JobDetailItem.ClientContactID
        '    Me.BABatchID = JobDetailItem.BABatchID
        '    Me.ClientContact = JobDetailItem.ClientContact
        '    Me.SelectedBABatchID = JobDetailItem.SelectedBABatchID
        '    Me.BillingCommandCenterID = JobDetailItem.BillingCommandCenterID
        '    Me.AlertAssignmentTemplate = JobDetailItem.AlertAssignmentTemplate
        '    Me.FunctionType = JobDetailItem.FunctionType
        '    Me.FunctionConsolidationCode = JobDetailItem.FunctionConsolidationCode
        '    Me.FunctionConsolidation = JobDetailItem.FunctionConsolidation
        '    Me.FunctionHeading = JobDetailItem.FunctionHeading
        '    Me.FunctionCode = JobDetailItem.FunctionCode
        '    Me.FunctionDescription = JobDetailItem.FunctionDescription
        '    Me.ItemID = JobDetailItem.ItemID
        '    Me.ItemSequenceNumber = JobDetailItem.ItemSequenceNumber
        '    Me.ItemDate = JobDetailItem.ItemDate
        '    Me.PostPeriodCode = JobDetailItem.PostPeriodCode
        '    Me.ItemCode = JobDetailItem.ItemCode
        '    Me.ItemDescription = JobDetailItem.ItemDescription
        '    Me.ItemComment = JobDetailItem.ItemComment
        '    Me.ItemExtra = JobDetailItem.ItemExtra
        '    Me.Hours = JobDetailItem.Hours
        '    Me.Quantity = JobDetailItem.Quantity
        '    Me.NetAmount = JobDetailItem.NetAmount
        '    Me.CostAmount = JobDetailItem.CostAmount
        '    Me.ExtMarkupAmount = JobDetailItem.ExtMarkupAmount
        '    Me.NonResaleTaxAmount = JobDetailItem.NonResaleTaxAmount
        '    Me.ResaleTaxAmount = JobDetailItem.ResaleTaxAmount
        '    Me.Total = JobDetailItem.Total
        '    Me.BillableLessResale = JobDetailItem.BillableLessResale
        '    Me.BillableTotal = JobDetailItem.BillableTotal
        '    Me.FeeTime = JobDetailItem.FeeTime
        '    Me.FeeTimeHours = JobDetailItem.FeeTimeHours
        '    Me.FeeTimeAmount = JobDetailItem.FeeTimeAmount
        '    Me.NonBillableHours = JobDetailItem.NonBillableHours
        '    Me.NonBillableQuantity = JobDetailItem.NonBillableQuantity
        '    Me.NonBillableAmount = JobDetailItem.NonBillableAmount
        '    Me.BilledHours = JobDetailItem.BilledHours
        '    Me.BilledQuantity = JobDetailItem.BilledQuantity
        '    Me.BilledAmount = JobDetailItem.BilledAmount
        '    Me.BilledWithResale = JobDetailItem.BilledWithResale
        '    Me.AccountsReceivablePostPeriodCode = JobDetailItem.AccountsReceivablePostPeriodCode
        '    Me.AccountsReceivableInvoiceNumber = JobDetailItem.AccountsReceivableInvoiceNumber
        '    Me.AccountsReceivableInvoiceType = Nothing
        '    Me.UnbilledHours = JobDetailItem.UnbilledHours
        '    Me.UnbilledQuantity = JobDetailItem.UnbilledQuantity
        '    Me.UnbilledAmount = JobDetailItem.UnbilledAmount
        '    Me.UnbilledAmountLessResale = JobDetailItem.UnbilledAmountLessResale
        '    Me.AdvanceBillFlagDetail = JobDetailItem.AdvanceBillFlagDetail
        '    Me.IsNonBillable = JobDetailItem.IsNonBillable
        '    Me.GlexActBill = JobDetailItem.GlexActBill
        '    Me.EstimateHours = JobDetailItem.EstimateHours
        '    Me.EstimateQuantity = JobDetailItem.EstimateQuantity
        '    Me.EstimateTotalAmount = JobDetailItem.EstimateTotalAmount
        '    Me.EstimateContTotalAmount = JobDetailItem.EstimateContTotalAmount
        '    Me.EstimateNonResaleTaxAmount = JobDetailItem.EstimateNonResaleTaxAmount
        '    Me.EstimateResaleTaxAmount = JobDetailItem.EstimateResaleTaxAmount
        '    Me.EstimateMarkupAmount = JobDetailItem.EstimateMarkupAmount
        '    Me.EstimateCostAmount = JobDetailItem.EstimateCostAmount
        '    Me.IsEstimateNonBillable = JobDetailItem.IsEstimateNonBillable
        '    Me.EstimateFeeTime = JobDetailItem.EstimateFeeTime
        '    Me.EstimateNetAmount = JobDetailItem.EstimateNetAmount
        '    Me.PurchaseOrderNumber = JobDetailItem.PurchaseOrderNumber
        '    Me.OpenPurchaseOrderAmount = JobDetailItem.OpenPurchaseOrderAmount
        '    Me.OpenPurchaseOrderGrossAmount = JobDetailItem.OpenPurchaseOrderGrossAmount
        '    Me.IsNewBusiness = JobDetailItem.IsNewBusiness
        '    Me.Agency = JobDetailItem.Agency
        '    Me.BillingApprovalHours = JobDetailItem.BillingApprovalHours
        '    Me.BillingApprovalCostAmount = JobDetailItem.BillingApprovalCostAmount
        '    Me.BillingApprovalExtNetAmount = JobDetailItem.BillingApprovalExtNetAmount
        '    Me.BillingApprovalTotalAmount = JobDetailItem.BillingApprovalTotalAmount
        '    Me.ProductUDF1 = JobDetailItem.ProductUDF1
        '    Me.ProductUDF2 = JobDetailItem.ProductUDF2
        '    Me.ProductUDF3 = JobDetailItem.ProductUDF3
        '    Me.ProductUDF4 = JobDetailItem.ProductUDF4

        'End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
