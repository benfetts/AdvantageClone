
    Public Class JobDetailItemAPIReport

#Region " Constants "


#End Region

#Region " Enum "


#End Region

#Region " Variables "


#End Region

#Region " Properties "

    '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
    'Public Property ID() As System.Guid
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property JobNumber() As Nullable(Of Integer)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobComponentNumber() As Nullable(Of Short)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property OfficeCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property OfficeDescription() As String
    Public Property ClientCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientDescription() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property DivisionCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property DivisionDescription() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductDescription() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property CampaignID() As Nullable(Of Integer)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property CampaignCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property CampaignName() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property BillingBudget() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property IncomeBudget() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property SalesClassCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property SalesClassDescription() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ResourceType() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property UserCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobCreateDate() As Nullable(Of Date)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobDescription() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobDateOpened() As Nullable(Of Date)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property RushChargesApproved() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ApprovedEstimateRequired() As String

    Public Property Comment() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientReference() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property BillingCoopCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property SalesClassFormatCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ComplexityCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property PromotionCode() As String

    Public Property BillingComment() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property LabelFromUDFTable1() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property LabelFromUDFTable2() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property LabelFromUDFTable3() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property LabelFromUDFTable4() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property LabelFromUDFTable5() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobOpen() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobComponent() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property BillHold() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property AccountExecutiveCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property AccountExecutive() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ManagerCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property Manager() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ComponentDateOpened() As Nullable(Of Date)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property DueDate() As Nullable(Of Date)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property StartDate() As Nullable(Of Date)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property Status() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property GutPercentComplete() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property AdSize() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property DepartmentTeamCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property DepartmentTeam() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
    Public Property MarkupPercent() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property CreativeInstructions() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobProcessControl() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ComponentDescription() As String

    Public Property ComponentComments() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property ComponentBudget() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property EstimateNumber() As Nullable(Of Integer)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property EstimateComponentNumber() As Nullable(Of Short)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientApproved() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientApprovalDate() As Nullable(Of Date)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientApprovedBy() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property InternallyApproved() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property InternalApprovalDate() As Nullable(Of Date)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property InternallyApprovedBy() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property BillingUser() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property AdvanceBillFlag() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property DeliveryInstructions() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobTypeCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobTypeDescription() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property Taxable() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property TaxCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property TaxCodeDescription() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property NonBillable() As Nullable(Of Short)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property AlertGroup() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property AdNumber() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property AccountNumber() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property AccountNumberDescription() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property IncomeRecognitionMethod() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property MarketCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property MarketDescription() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ServiceFeeJob() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ServiceFeeTypeCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ServiceFeeTypeDescription() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property Archived() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property TrafficScheduleRequired() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientPO() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property CompLabelFromUDFTable1() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property CompLabelFromUDFTable2() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property CompLabelFromUDFTable3() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property CompLabelFromUDFTable4() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property CompLabelFromUDFTable5() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobTemplateCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property FiscalPeriodCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property FiscalPeriodDescription() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobQuantity() As Nullable(Of Integer)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property BlackplateVersionCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property BlackplateVersionDesc() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property BlackplateVersion2Code() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property BlackplateVersion2Desc() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientContactCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property ClientContactID() As Nullable(Of Integer)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property BABatchID() As Nullable(Of Integer)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientContact() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property SelectedBABatchID() As Nullable(Of Integer)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property BillingCommandCenterID() As Nullable(Of Integer)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property AlertAssignmentTemplate() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property FunctionType() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property FunctionConsolidationCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property FunctionConsolidation() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property FunctionHeading() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property FunctionCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property FunctionDescription() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property ItemID() As Integer
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ItemSequenceNumber() As Integer
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ItemDate() As Nullable(Of Date)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property PostPeriodCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ItemCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ItemDescription() As String

    Public Property ItemComment() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ItemExtra() As String

    Public Property ItemDetailComment() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property Hours() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property Quantity() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property NetAmount() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property CostAmount() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property ExtMarkupAmount() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property NonResaleTaxAmount() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property ResaleTaxAmount() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property Total() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property BillableLessResale() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property BillableTotal() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property FeeTime() As Integer
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property FeeTimeHours() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property FeeTimeAmount() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property NonBillableHours() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property NonBillableQuantity() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property NonBillableAmount() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property BilledHours() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property BilledQuantity() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property BilledAmount() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property BilledWithResale() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property AdvanceBilledTotal() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property FlatIncomeRecognized() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property AdvanceBillingBalance() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property AdvanceBillingRetained() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property AccountsReceivablePostPeriodCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property AccountsReceivableInvoiceNumber() As Nullable(Of Integer)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property AccountsReceivableInvoiceType() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property UnbilledHours() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property UnbilledQuantity() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property UnbilledAmount() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property UnbilledAmountLessResale() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property AdvanceBillFlagDetail() As Nullable(Of Integer)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property IsNonBillable() As Integer
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="GLXACT Bill")>
    Public Property GlexActBill() As Nullable(Of Integer)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property EstimateSuppliedByCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property EstimateSuppliedBy() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property EstimateHours() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property EstimateHoursAmount() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property EstimateQuantity() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property EstimateTotalAmount() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property EstimateContTotalAmount() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property EstimateNonResaleTaxAmount() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property EstimateResaleTaxAmount() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property EstimateMarkupAmount() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property EstimateCostAmount() As Decimal
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property IsEstimateNonBillable() As Integer
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property EstimateFeeTime() As Integer
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property EstimateNetAmount() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property PurchaseOrderNumber() As Integer
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property OpenPurchaseOrderAmount() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property OpenPurchaseOrderGrossAmount() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property IsNewBusiness() As Nullable(Of Short)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property Agency() As Integer
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property BillingApprovalHours() As Integer
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property BillingApprovalCostAmount() As Integer
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property BillingApprovalExtNetAmount() As Integer
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property BillingApprovalTotalAmount() As Integer
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductUDF1() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductUDF2() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductUDF3() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductUDF4() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property EmployeeDefaultDepartmentCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property EmployeeDefaultDepartmentDescription() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property EmployeeTimeDepartmentCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property EmployeeTimeDepartmentDescription() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property CompletedDate() As Date?
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobProcessControlDate() As Date?
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property DateEntered() As Nullable(Of Date)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property DefaultRoleCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property DefaultRole() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property EmployeeOfficeCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property EmployeeOfficeDescription() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property EmployeeTitle() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property IsEmployeeFreelance() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property IsActiveFreelance() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property EmployeeRateFrom() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductCategoryCode() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductCategoryDescription() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property DirectHoursGoalPercent() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Client Type 1 Code")>
    Public Property ClientType1Code() As Nullable(Of Integer)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 1 Description")>
    Public Property ClientType1Description() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Client Type 2 Code")>
    Public Property ClientType2Code() As Nullable(Of Integer)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 2 Description")>
    Public Property ClientType2Description() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Client Type 3 Code")>
    Public Property ClientType3Code() As Nullable(Of Integer)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Type 3 Description")>
    Public Property ClientType3Description() As String
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property CurrentHours() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property CurrentHoursAmount() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property CurrentIncomeOnlyCharges() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property CurrentVendorCharges() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property CurrentTotal() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property PriorHours() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property PriorHoursAmount() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property PriorIncomeOnlyCharges() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property PriorVendorCharges() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property PriorTotal() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property PriorYearHours() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property PriorYearHoursAmount() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property PriorYearIncomeOnlyCharges() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property PriorYearVendorCharges() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property PriorYearTotal() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property TotalToDateHours() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property TotalToDateHoursAmount() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property TotalToDateIncomeOnlyCharges() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property TotalToDateVendorCharges() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property TotalToDate() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property EstimateIncomeOnlyCharges() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property BilledIncomeOnlyCharges() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ComplexityDescription() As String
    Public Property PercentCompleteHours() As Nullable(Of Decimal)
    Public Property PercentCompleteAmount() As Nullable(Of Decimal)

#End Region

#Region " Methods "

    Public Overrides Function ToString() As String

        ToString = Me.JobNumber.ToString

    End Function

#End Region

End Class


