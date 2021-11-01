Namespace Reporting.Database.Entities

    <Table("DS_JOB_DETAIL_ITEM")>
    Public Class JobDetailData
        Inherits BaseClasses.Entity

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

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        Public Property ID() As Long
        <Required>
        <Column(TypeName:="varchar")>
        Public Property ResourceType() As String
        Public Property JobNumber() As Nullable(Of Integer)
        Public Property JobComponentNumber() As Nullable(Of Short)
        <Column(TypeName:="varchar")>
        <MaxLength(4)>
        Public Property OfficeCode() As String
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property OfficeDescription() As String
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property ClientCode() As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property ClientDescription() As String
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property DivisionCode() As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property DivisionDescription() As String

        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property ProductCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property ProductDescription As String
        Public Property CampaignID As Nullable(Of Integer)
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property CampaignCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property CampaignName As String
        Public Property BillingBudget As Nullable(Of Decimal)
        Public Property IncomeBudget As Nullable(Of Decimal)
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property SalesClassCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property SalesClassDescription As String
        <Column(TypeName:="varchar")>
        <MaxLength(100)>
        Public Property UserCode As String
        Public Property JobCreateDate As Nullable(Of Date)
        <Column(TypeName:="varchar")>
        <MaxLength(60)>
        Public Property JobDescription As String
        Public Property JobDateOpened As Nullable(Of Date)
        <Column(TypeName:="varchar")>
        <MaxLength(3)>
        Public Property RushChargesApproved As String
        <Column(TypeName:="varchar")>
        <MaxLength(3)>
        Public Property ApprovedEstimateRequired As String
        <Column(TypeName:="varchar")>
        Public Property Comment As String
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property ClientReference As String
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property BillingCoopCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(8)>
        Public Property SalesClassFormatCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(8)>
        Public Property ComplexityCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(8)>
        Public Property PromotionCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(254)>
        Public Property BillingComment As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property LabelFromUDFTable1 As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property LabelFromUDFTable2 As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property LabelFromUDFTable3 As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property LabelFromUDFTable4 As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property LabelFromUDFTable5 As String
        <Column(TypeName:="varchar")>
        <MaxLength(3)>
        Public Property JobOpen As String
        <Column(TypeName:="varchar")>
        <MaxLength(20)>
        Public Property JobComponent As String
        <Column(TypeName:="varchar")>
        <MaxLength(3)>
        Public Property BillHold As String
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property AccountExecutiveCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(100)>
        Public Property AccountExecutive As String
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property ManagerCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(100)>
        Public Property Manager As String
        Public Property ComponentDateOpened As Nullable(Of Date)
        Public Property DueDate As Nullable(Of Date)
        Public Property StartDate As Nullable(Of Date)
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property Status As String
        Public Property GutPercentComplete As Nullable(Of Decimal)
        <Column(TypeName:="varchar")>
        <MaxLength(60)>
        Public Property AdSize As String
        <Column(TypeName:="varchar")>
        <MaxLength(4)>
        Public Property DepartmentTeamCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property DepartmentTeam As String
        Public Property MarkupPercent As Nullable(Of Decimal)
        <Column(TypeName:="varchar")>
        Public Property CreativeInstructions As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property JobProcessControl As String
        <Column(TypeName:="varchar")>
        <MaxLength(60)>
        Public Property ComponentDescription As String
        <Column(TypeName:="varchar")>
        Public Property ComponentComments As String
        Public Property ComponentBudget As Nullable(Of Decimal)
        Public Property EstimateNumber As Nullable(Of Integer)
        Public Property EstimateComponentNumber As Nullable(Of Short)
        <Column(TypeName:="varchar")>
        <MaxLength(3)>
        Public Property ClientApproved As String
        Public Property ClientApprovalDate As Nullable(Of Date)
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property ClientApprovedBy As String
        <Column(TypeName:="varchar")>
        <MaxLength(3)>
        Public Property InternallyApproved As String
        Public Property InternalApprovalDate As Nullable(Of Date)
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property InternallyApprovedBy As String
        <Column(TypeName:="varchar")>
        <MaxLength(100)>
        Public Property BillingUser As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property AdvanceBillFlag As String
        <Column(TypeName:="varchar")>
        Public Property DeliveryInstructions As String
        <Column(TypeName:="varchar")>
        <MaxLength(10)>
        Public Property JobTypeCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property JobTypeDescription As String
        <Column(TypeName:="varchar")>
        <MaxLength(3)>
        Public Property Taxable As String
        <Column(TypeName:="varchar")>
        <MaxLength(4)>
        Public Property TaxCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property TaxCodeDescription As String
        Public Property NonBillable As Nullable(Of Short)
        <Column(TypeName:="varchar")>
        <MaxLength(50)>
        Public Property AlertGroup As String
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property AdNumber As String
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property AccountNumber As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property AccountNumberDescription As String
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property IncomeRecognitionMethod As String
        <Column(TypeName:="varchar")>
        <MaxLength(10)>
        Public Property MarketCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property MarketDescription As String
        <Column(TypeName:="varchar")>
        <MaxLength(3)>
        Public Property ServiceFeeJob As String
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property ServiceFeeTypeCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property ServiceFeeTypeDescription As String
        <Column(TypeName:="varchar")>
        <MaxLength(3)>
        Public Property Archived As String
        <Column(TypeName:="varchar")>
        <MaxLength(3)>
        Public Property TrafficScheduleRequired As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property ClientPO As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable1 As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable2 As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable3 As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable4 As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable5 As String
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property JobTemplateCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property FiscalPeriodCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property FiscalPeriodDescription As String
        Public Property JobQuantity As Nullable(Of Integer)
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property BlackplateVersionCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(60)>
        Public Property BlackplateVersionDesc As String
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property BlackplateVersion2Code As String
        <Column(TypeName:="varchar")>
        <MaxLength(60)>
        Public Property BlackplateVersion2Desc As String
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property ClientContactCode As String
        Public Property ClientContactID As Nullable(Of Integer)
        Public Property BABatchID As Nullable(Of Integer)
        <Column(TypeName:="varchar")>
        <MaxLength(100)>
        Public Property ClientContact As String
        Public Property SelectedBABatchID As Nullable(Of Integer)
        Public Property BillingCommandCenterID As Nullable(Of Integer)
        <Column(TypeName:="varchar")>
        <MaxLength(100)>
        Public Property AlertAssignmentTemplate As String
        <Column(TypeName:="varchar")>
        <MaxLength(1)>
        Public Property FunctionType As String
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property FunctionConsolidationCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property FunctionConsolidation As String
        <Column(TypeName:="varchar")>
        <MaxLength(60)>
        Public Property FunctionHeading As String
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property FunctionCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property FunctionDescription As String
        Public Property ItemID As Nullable(Of Integer)
        Public Property ItemSequenceNumber As Nullable(Of Integer)
        Public Property ItemDate As Nullable(Of Date)
        <Column(TypeName:="varchar")>
        <MaxLength(8)>
        Public Property PostPeriodCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property ItemCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(100)>
        Public Property ItemDescription As String
        <Column(TypeName:="varchar")>
        Public Property ItemComment As String
        <Column(TypeName:="varchar")>
        <MaxLength(20)>
        Public Property ItemExtra As String
        <Column(TypeName:="varchar")>
        Public Property ItemDetailComment As String
        Public Property Hours As Nullable(Of Decimal)
        Public Property Quantity As Nullable(Of Decimal)
        Public Property NetAmount As Nullable(Of Decimal)
        Public Property CostAmount As Nullable(Of Decimal)
        Public Property ExtMarkupAmount As Nullable(Of Decimal)
        Public Property NonResaleTaxAmount As Nullable(Of Decimal)
        Public Property ResaleTaxAmount As Nullable(Of Decimal)
        Public Property Total As Nullable(Of Decimal)
        Public Property BillableLessResale As Nullable(Of Decimal)
        Public Property BillableTotal As Nullable(Of Decimal)
        Public Property FeeTime As Nullable(Of Integer)
        Public Property FeeTimeHours As Nullable(Of Decimal)
        Public Property FeeTimeAmount As Nullable(Of Decimal)
        Public Property NonBillableHours As Nullable(Of Decimal)
        Public Property NonBillableQuantity As Nullable(Of Decimal)
        Public Property NonBillableAmount As Nullable(Of Decimal)
        Public Property BilledHours As Nullable(Of Decimal)
        Public Property BilledQuantity As Nullable(Of Decimal)
        Public Property BilledAmount As Nullable(Of Decimal)
        Public Property BilledWithResale As Nullable(Of Decimal)
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property AccountsReceivablePostPeriodCode As String
        Public Property AccountsReceivableInvoiceNumber As Nullable(Of Integer)
        <Column(TypeName:="varchar")>
        <MaxLength(3)>
        Public Property AccountsReceivableInvoiceType As String
        Public Property UnbilledHours As Nullable(Of Decimal)
        Public Property UnbilledQuantity As Nullable(Of Decimal)
        Public Property UnbilledAmount As Nullable(Of Decimal)
        Public Property UnbilledAmountLessResale As Nullable(Of Decimal)
        Public Property AdvanceBillFlagDetail As Nullable(Of Integer)
        Public Property IsNonBillable As Nullable(Of Integer)
        Public Property GlexActBill As Nullable(Of Integer)
        Public Property EstimateHours As Nullable(Of Decimal)
        Public Property EstimateHoursAmount As Nullable(Of Decimal)
        Public Property EstimateQuantity As Nullable(Of Decimal)
        Public Property EstimateTotalAmount As Nullable(Of Decimal)
        Public Property EstimateContTotalAmount As Nullable(Of Decimal)
        Public Property EstimateNonResaleTaxAmount As Nullable(Of Decimal)
        Public Property EstimateResaleTaxAmount As Nullable(Of Decimal)
        Public Property EstimateMarkupAmount As Nullable(Of Decimal)
        Public Property EstimateCostAmount As Nullable(Of Decimal)
        Public Property IsEstimateNonBillable As Nullable(Of Integer)
        Public Property EstimateFeeTime As Nullable(Of Integer)
        Public Property EstimateNetAmount As Nullable(Of Decimal)
        Public Property PurchaseOrderNumber As Nullable(Of Integer)
        Public Property OpenPurchaseOrderAmount As Nullable(Of Decimal)
        Public Property OpenPurchaseOrderGrossAmount As Nullable(Of Decimal)
        Public Property IsNewBusiness As Nullable(Of Short)
        Public Property Agency As Nullable(Of Integer)
        Public Property BillingApprovalHours As Nullable(Of Decimal)
        Public Property BillingApprovalCostAmount As Nullable(Of Decimal)
        Public Property BillingApprovalExtNetAmount As Nullable(Of Decimal)
        Public Property BillingApprovalTotalAmount As Nullable(Of Decimal)
        <Column(TypeName:="varchar")>
        <MaxLength(50)>
        Public Property ProductUDF1 As String
        <Column(TypeName:="varchar")>
        <MaxLength(50)>
        Public Property ProductUDF2 As String
        <Column(TypeName:="varchar")>
        <MaxLength(50)>
        Public Property ProductUDF3 As String
        <Column(TypeName:="varchar")>
        <MaxLength(50)>
        Public Property ProductUDF4 As String
        <Column(TypeName:="varchar")>
        <MaxLength(4)>
        Public Property EmployeeDefaultDepartmentCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property EmployeeDefaultDepartmentDescription As String
        <Column(TypeName:="varchar")>
        <MaxLength(4)>
        Public Property EmployeeTimeDepartmentCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property EmployeeTimeDepartmentDescription As String
        Public Property CompletedDate As Nullable(Of Date)
        Public Property JobProcessControlDate As Nullable(Of Date)
        Public Property DateEntered As Nullable(Of Date)
        <Column(TypeName:="varchar")>
        <MaxLength(6)>
        Public Property DefaultRoleCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(40)>
        Public Property DefaultRole As String
        <Column(TypeName:="varchar")>
        <MaxLength(4)>
        Public Property EmployeeOfficeCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(30)>
        Public Property EmployeeOfficeDescription As String
        <Column(TypeName:="varchar")>
        <MaxLength(50)>
        Public Property EmployeeTitle As String
        <Column(TypeName:="varchar")>
        <MaxLength(3)>
        Public Property IsEmployeeFreelance As String
        <Column(TypeName:="varchar")>
        <MaxLength(3)>
        Public Property IsActiveFreelance As String
        <Column(TypeName:="varchar")>
        <MaxLength(254)>
        Public Property EmployeeRateFrom As String
        <Column(TypeName:="varchar")>
        <MaxLength(10)>
        Public Property ProductCategoryCode As String
        <Column(TypeName:="varchar")>
        <MaxLength(60)>
        Public Property ProductCategoryDescription As String
        Public Property DirectHoursGoalPercent
        Public Property ClientType1Code As Nullable(Of Integer)
        <Column(TypeName:="varchar")>
        <MaxLength(100)>
        Public Property ClientType1Description As String
        Public Property ClientType2Code As Nullable(Of Integer)
        <Column(TypeName:="varchar")>
        <MaxLength(100)>
        Public Property ClientType2Description As String
        Public Property ClientType3Code As Nullable(Of Integer)
        <Column(TypeName:="varchar")>
        <MaxLength(100)>
        Public Property ClientType3Description As String
        Public Property CurrentHours As Nullable(Of Decimal)
        Public Property CurrentHoursAmount As Nullable(Of Decimal)
        Public Property CurrentIncomeOnlyCharges As Nullable(Of Decimal)
        Public Property CurrentVendorCharges As Nullable(Of Decimal)
        Public Property CurrentTotal As Nullable(Of Decimal)
        Public Property PriorHours As Nullable(Of Decimal)
        Public Property PriorHoursAmount As Nullable(Of Decimal)
        Public Property PriorIncomeOnlyCharges As Nullable(Of Decimal)
        Public Property PriorVendorCharges As Nullable(Of Decimal)
        Public Property PriorTotal As Nullable(Of Decimal)
        Public Property PriorYearHours As Nullable(Of Decimal)
        Public Property PriorYearHoursAmount As Nullable(Of Decimal)
        Public Property PriorYearIncomeOnlyCharges As Nullable(Of Decimal)
        Public Property PriorYearVendorCharges As Nullable(Of Decimal)
        Public Property PriorYearTotal As Nullable(Of Decimal)
        Public Property TotalToDateHours As Nullable(Of Decimal)
        Public Property TotalToDateHoursAmount As Nullable(Of Decimal)
        Public Property TotalToDateIncomeOnlyCharges As Nullable(Of Decimal)
        Public Property TotalToDateVendorCharges As Nullable(Of Decimal)
        Public Property TotalToDate As Nullable(Of Decimal)
        Public Property EstimateIncomeOnlyCharges As Nullable(Of Decimal)
        Public Property BilledIncomeOnlyCharges As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
