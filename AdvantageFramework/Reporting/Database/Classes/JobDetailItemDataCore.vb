Namespace Reporting.Database.Classes

    <Serializable>
    Public Class JobDetailItemDataCore

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
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        Public Property ID() As Long
        <Required>
        Public Property ResourceType() As String
        Public Property JobNumber() As Nullable(Of Integer)
        Public Property JobComponentNumber() As Nullable(Of Short)
        <MaxLength(4)>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        Public Property OfficeDescription() As String
        <MaxLength(6)>
        Public Property ClientCode() As String
        <MaxLength(40)>
        Public Property ClientDescription() As String
        <MaxLength(6)>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        Public Property DivisionDescription() As String
        <MaxLength(6)>
        Public Property ProductCode As String
        <MaxLength(40)>
        Public Property ProductDescription As String
        Public Property CampaignID As Nullable(Of Integer)
        <MaxLength(6)>
        Public Property CampaignCode As String
        <MaxLength(40)>
        Public Property CampaignName As String
        Public Property BillingBudget As Nullable(Of Decimal)
        Public Property IncomeBudget As Nullable(Of Decimal)
        <MaxLength(6)>
        Public Property SalesClassCode As String
        <MaxLength(30)>
        Public Property SalesClassDescription As String
        <MaxLength(100)>
        Public Property UserCode As String
        Public Property JobCreateDate As Nullable(Of Date)
        <MaxLength(60)>
        Public Property JobDescription As String
        Public Property JobDateOpened As Nullable(Of Date)
        <MaxLength(3)>
        Public Property RushChargesApproved As String
        <MaxLength(3)>
        Public Property ApprovedEstimateRequired As String
        Public Property Comment As String
        <MaxLength(30)>
        Public Property ClientReference As String
        <MaxLength(6)>
        Public Property BillingCoopCode As String
        <MaxLength(8)>
        Public Property SalesClassFormatCode As String
        <MaxLength(8)>
        Public Property ComplexityCode As String
        <MaxLength(30)>
        Public Property ComplexityDescription As String
        <MaxLength(8)>
        Public Property PromotionCode As String
        <MaxLength(254)>
        Public Property BillingComment As String
        <MaxLength(40)>
        Public Property LabelFromUDFTable1 As String
        <MaxLength(40)>
        Public Property LabelFromUDFTable2 As String
        <MaxLength(40)>
        Public Property LabelFromUDFTable3 As String
        <MaxLength(40)>
        Public Property LabelFromUDFTable4 As String
        <MaxLength(40)>
        Public Property LabelFromUDFTable5 As String
        <MaxLength(3)>
        Public Property JobOpen As String
        <MaxLength(20)>
        Public Property JobComponent As String
        <MaxLength(3)>
        Public Property BillHold As String
        <MaxLength(6)>
        Public Property AccountExecutiveCode As String
        <MaxLength(100)>
        Public Property AccountExecutive As String
        <MaxLength(6)>
        Public Property ManagerCode As String
        <MaxLength(100)>
        Public Property Manager As String
        Public Property ComponentDateOpened As Nullable(Of Date)
        Public Property DueDate As Nullable(Of Date)
        Public Property StartDate As Nullable(Of Date)
        <MaxLength(30)>
        Public Property Status As String
        Public Property GutPercentComplete As Nullable(Of Decimal)
        <MaxLength(60)>
        Public Property AdSize As String
        <MaxLength(4)>
        Public Property DepartmentTeamCode As String
        <MaxLength(30)>
        Public Property DepartmentTeam As String
        Public Property MarkupPercent As Nullable(Of Decimal)
        Public Property CreativeInstructions As String
        <MaxLength(40)>
        Public Property JobProcessControl As String
        <MaxLength(60)>
        Public Property ComponentDescription As String
        Public Property ComponentComments As String
        Public Property ComponentBudget As Nullable(Of Decimal)
        Public Property EstimateNumber As Nullable(Of Integer)
        Public Property EstimateComponentNumber As Nullable(Of Short)
        <MaxLength(3)>
        Public Property ClientApproved As String
        Public Property ClientApprovalDate As Nullable(Of Date)
        <MaxLength(40)>
        Public Property ClientApprovedBy As String
        <MaxLength(3)>
        Public Property InternallyApproved As String
        Public Property InternalApprovalDate As Nullable(Of Date)
        <MaxLength(40)>
        Public Property InternallyApprovedBy As String
        <MaxLength(100)>
        Public Property BillingUser As String
        <MaxLength(40)>
        Public Property AdvanceBillFlag As String
        Public Property DeliveryInstructions As String
        <MaxLength(10)>
        Public Property JobTypeCode As String
        <MaxLength(30)>
        Public Property JobTypeDescription As String
        <MaxLength(3)>
        Public Property Taxable As String
        <MaxLength(4)>
        Public Property TaxCode As String
        <MaxLength(30)>
        Public Property TaxCodeDescription As String
        Public Property NonBillable As Nullable(Of Short)
        <MaxLength(50)>
        Public Property AlertGroup As String
        <MaxLength(30)>
        Public Property AdNumber As String
        <MaxLength(30)>
        Public Property AccountNumber As String
        <MaxLength(40)>
        Public Property AccountNumberDescription As String
        <MaxLength(30)>
        Public Property IncomeRecognitionMethod As String
        <MaxLength(10)>
        Public Property MarketCode As String
        <MaxLength(40)>
        Public Property MarketDescription As String
        <MaxLength(3)>
        Public Property ServiceFeeJob As String
        <MaxLength(6)>
        Public Property ServiceFeeTypeCode As String
        <MaxLength(30)>
        Public Property ServiceFeeTypeDescription As String
        <MaxLength(3)>
        Public Property Archived As String
        <MaxLength(3)>
        Public Property TrafficScheduleRequired As String
        <MaxLength(40)>
        Public Property ClientPO As String
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable1 As String
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable2 As String
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable3 As String
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable4 As String
        <MaxLength(40)>
        Public Property CompLabelFromUDFTable5 As String
        <MaxLength(6)>
        Public Property JobTemplateCode As String
        <MaxLength(6)>
        Public Property FiscalPeriodCode As String
        <MaxLength(30)>
        Public Property FiscalPeriodDescription As String
        Public Property JobQuantity As Nullable(Of Integer)
        <MaxLength(6)>
        Public Property BlackplateVersionCode As String
        <MaxLength(60)>
        Public Property BlackplateVersionDesc As String
        <MaxLength(6)>
        Public Property BlackplateVersion2Code As String
        <MaxLength(60)>
        Public Property BlackplateVersion2Desc As String
        <MaxLength(6)>
        Public Property ClientContactCode As String
        Public Property ClientContactID As Nullable(Of Integer)
        Public Property BABatchID As Nullable(Of Integer)
        <MaxLength(100)>
        Public Property ClientContact As String
        Public Property SelectedBABatchID As Nullable(Of Integer)
        Public Property BillingCommandCenterID As Nullable(Of Integer)
        <MaxLength(100)>
        Public Property AlertAssignmentTemplate As String
        <MaxLength(1)>
        Public Property FunctionType As String
        <MaxLength(6)>
        Public Property FunctionConsolidationCode As String
        <MaxLength(30)>
        Public Property FunctionConsolidation As String
        <MaxLength(60)>
        Public Property FunctionHeading As String
        <MaxLength(6)>
        Public Property FunctionCode As String
        <MaxLength(30)>
        Public Property FunctionDescription As String
        Public Property ItemID As Nullable(Of Integer)
        Public Property ItemSequenceNumber As Nullable(Of Integer)
        Public Property ItemDate As Nullable(Of Date)
        <MaxLength(8)>
        Public Property PostPeriodCode As String
        <MaxLength(6)>
        Public Property ItemCode As String
        <MaxLength(100)>
        Public Property ItemDescription As String
        Public Property ItemComment As String
        <MaxLength(20)>
        Public Property ItemExtra As String
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
        <MaxLength(6)>
        Public Property AccountsReceivablePostPeriodCode As String
        Public Property AccountsReceivableInvoiceNumber As Nullable(Of Integer)
        <MaxLength(3)>
        Public Property AccountsReceivableInvoiceType As String
        Public Property UnbilledHours As Nullable(Of Decimal)
        Public Property UnbilledQuantity As Nullable(Of Decimal)
        Public Property UnbilledAmount As Nullable(Of Decimal)
        Public Property UnbilledAmountLessResale As Nullable(Of Decimal)
        Public Property AdvanceBillFlagDetail As Nullable(Of Integer)
        Public Property IsNonBillable As Nullable(Of Integer)
        Public Property GlexActBill As Nullable(Of Integer)
        Public Property EstimateSuppliedByCode As String
        Public Property EstimateSuppliedBy As String
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
        Public Property BillingApprovalHours As Nullable(Of Integer)
        Public Property BillingApprovalCostAmount As Nullable(Of Integer)
        Public Property BillingApprovalExtNetAmount As Nullable(Of Integer)
        Public Property BillingApprovalTotalAmount As Nullable(Of Integer)
        <MaxLength(50)>
        Public Property ProductUDF1 As String
        <MaxLength(50)>
        Public Property ProductUDF2 As String
        <MaxLength(50)>
        Public Property ProductUDF3 As String
        <MaxLength(50)>
        Public Property ProductUDF4 As String
        <MaxLength(4)>
        Public Property EmployeeDefaultDepartmentCode As String
        <MaxLength(30)>
        Public Property EmployeeDefaultDepartmentDescription As String
        <MaxLength(4)>
        Public Property EmployeeTimeDepartmentCode As String
        <MaxLength(30)>
        Public Property EmployeeTimeDepartmentDescription As String
        Public Property CompletedDate As Nullable(Of Date)
        Public Property JobProcessControlDate As Nullable(Of Date)
        Public Property DateEntered As Nullable(Of Date)
        <MaxLength(6)>
        Public Property DefaultRoleCode As String
        <MaxLength(40)>
        Public Property DefaultRole As String
        <MaxLength(4)>
        Public Property EmployeeOfficeCode As String
        <MaxLength(30)>
        Public Property EmployeeOfficeDescription As String
        <MaxLength(50)>
        Public Property EmployeeTitle As String
        <MaxLength(3)>
        Public Property IsEmployeeFreelance As String
        <MaxLength(3)>
        Public Property IsActiveFreelance As String
        <MaxLength(254)>
        Public Property EmployeeRateFrom As String
        <MaxLength(10)>
        Public Property ProductCategoryCode As String
        <MaxLength(60)>
        Public Property ProductCategoryDescription As String
        Public Property DirectHoursGoalPercent
        Public Property ClientType1Code As Nullable(Of Integer)
        <MaxLength(100)>
        Public Property ClientType1Description As String
        Public Property ClientType2Code As Nullable(Of Integer)
        <MaxLength(100)>
        Public Property ClientType2Description As String
        Public Property ClientType3Code As Nullable(Of Integer)
        <MaxLength(100)>
        Public Property ClientType3Description As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AdvanceBilledTotal() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property FlatIncomeRecognized() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AdvanceBilledAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AdvanceBillingRetained() As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
