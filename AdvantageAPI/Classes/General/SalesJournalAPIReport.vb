<DataContract>
Public Class SalesJournalAPIReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property OfficeCode As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property OfficeName As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientCode As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientName As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientAddress() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientAddress2() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientCity() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientCounty() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientState() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientZip() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientCountry() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientBillingAddress() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientBillingAddress2() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientBillingCity() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientBillingCounty() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientBillingState() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientBillingZip() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientBillingCountry() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property DivisionCode As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property DivisionName As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductBillingAddress() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductBillingAddress2() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductBillingCity() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductBillingCounty() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductBillingState() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductBillingZip() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductBillingCountry() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductCode As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductName As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property DefaultAECode() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property DefaultAEName() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductUDF1() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductUDF2() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductUDF3() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ProductUDF4() As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="AR Post Period")>
    Public Property ARPostPeriod As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ARPostPeriodStartDate As Nullable(Of Date)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ARPostPeriodEndDate As Nullable(Of Date)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ARPostPeriodDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ARPostPeriodGLMonth As Nullable(Of Short)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ARPostPeriodGLYear As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Sales Post Period")>
    Public Property SalePostPeriod As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property SalePostPeriodStartDate As Nullable(Of Date)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property SalePostPeriodEndDate As Nullable(Of Date)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property SalePostPeriodDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property SalePostPeriodGLMonth As Nullable(Of Short)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property SalePostPeriodGLYear As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property InvoiceDate As Nullable(Of Date)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property InvoiceNumber As Nullable(Of Integer)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Invoice SEQ")>
    Public Property InvoiceSEQ As Nullable(Of Short)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property InvoiceType As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property InvoiceDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property InvoiceAssignBy As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property InvoiceCategory As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property InvoiceDueDate As Nullable(Of Date)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property MediaType As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property MediaTypeDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ManualFlag As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property SalesClassCode As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property SalesClassDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property CampaignID As Nullable(Of Integer)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property CampaignCode As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property CampaignName As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client PO")>
    Public Property ClientPO As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property AccountExecutiveCode As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property AccountExecutive As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property JobNumber As Nullable(Of Integer)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobComponent As Nullable(Of Short)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobComponentDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property FunctionType As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property FunctionCode As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property FunctionDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property FunctionHeadingDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property OrderNumber As Nullable(Of Integer)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property OrderLine As Nullable(Of Short)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property MediaMonth As Nullable(Of Short)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property MediaYear As Nullable(Of Short)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property MediaStartDate As Nullable(Of Date)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property MediaEndDate As Nullable(Of Date)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property MediaMarket As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property MediaMarketDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property InvoiceTotal As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property Sales As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Cost of Sales")>
    Public Property CostOfSales As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property GrossIncome As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property DeferredSales As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Deferred Cost of Sales")>
    Public Property DeferredCostOfSales As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property DeferredGrossIncome As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Hours or Quantity")>
    Public Property HoursOrQuantity As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property Time As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property IncomeOnly As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property Commission As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property Cost As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property VendorTax As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property MediaNetCharge As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property MediaRebate As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property MediaAdditionalCharge As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property MediaDiscount As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property AdvanceIncome As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property AdvanceCommission As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property AdvanceCost As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property AdvanceRetainedSales As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property AdvanceNonresaleAmount As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property TotalBillLessResaleTax As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property CityTax As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property CountyTax As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property StateTax As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property ResaleTax As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
    Public Property TotalBill As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property TaxAtBilling As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property TaxCode As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
    Public Property CityTaxPct As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
    Public Property CountyTaxPct As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
    Public Property StateTaxPct As Nullable(Of Decimal)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="GL XACT")>
    Public Property GLXACT As Nullable(Of Integer)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="GL XACT Deferred")>
    Public Property GLXACTDeferred As Nullable(Of Integer)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account AR")>
    Public Property GLAccountAR As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account AR Description")>
    Public Property GLAccountARDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Sales")>
    Public Property GLAccountSales As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Sales Description")>
    Public Property GLAccountSalesDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Deferred Sales")>
    Public Property GLAccountDeferredSales As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Deferred Sales Description")>
    Public Property GLAccountDeferredSalesDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Cost of Sales")>
    Public Property GLAccountCostOfSales As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Cost of Sales Description")>
    Public Property GLAccountCostOfSalesDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Accrued AP")>
    Public Property GLAccountAccruedAP As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Accrued AP Description")>
    Public Property GLAccountAccruedAPDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Accrued COS")>
    Public Property GLAccountAccruedCOS As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account Accrued COS Description")>
    Public Property GLAccountAccruedCOSDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account WIP")>
    Public Property GLAccountWIP As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account WIP Description")>
    Public Property GLAccountWIPDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account City Tax")>
    Public Property GLAccountCityTax As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account City Tax Description")>
    Public Property GLAccountCityTaxDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account County Tax")>
    Public Property GLAccountCountyTax As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account County Tax Description")>
    Public Property GLAccountCountyTaxDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account State Tax")>
    Public Property GLAccountStateTax As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account State Tax Description")>
    Public Property GLAccountStateTaxDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property Converted As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property OrderDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property VendorCode As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property VendorName As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property CreateDate As Nullable(Of Date)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property UserID As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property IsVoided As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property VoidComment As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property FiscalMonth As Nullable(Of Short)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property ClientReference As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property EstimateNumber As Nullable(Of Integer)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property EstimateComponentNumber As Nullable(Of Short)
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Avatax Address")>
    Public Property BillingAddress As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobTypeCode As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobTypeDescription As String
    <DataMember>
    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
    Public Property JobMediaDateToBill As Nullable(Of Date)

#End Region

#Region " Methods "



#End Region

End Class
