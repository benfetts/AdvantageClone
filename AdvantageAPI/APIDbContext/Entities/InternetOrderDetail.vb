<Table("INTERNET_DETAIL")>
Public Class InternetOrderDetail

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <Key>
    <Required>
    <Column("ORDER_NBR", Order:=0)>
    Public Property OrderNumber() As Integer
    <Key>
    <Required>
    <Column("LINE_NBR", Order:=1)>
    Public Property LineNumber() As Short
    <Key>
    <Required>
    <Column("REV_NBR", Order:=2)>
    Public Property RevisionNumber() As Short
    <Key>
    <Required>
    <Column("SEQ_NBR", Order:=3)>
    Public Property SequenceNumber() As Short
    <Column("ACTIVE_REV")>
    Public Property IsActiveRevision() As Nullable(Of Short)
    <Column("LINK_DETID")>
    Public Property LinkDetailID() As Nullable(Of Integer)
    <Column("START_DATE")>
    Public Property StartDate() As Nullable(Of Date)
    <Column("END_DATE")>
    Public Property EndDate() As Nullable(Of Date)
    <Column("CLOSE_DATE")>
    Public Property CloseDate() As Nullable(Of Date)
    <Column("MATL_CLOSE_DATE")>
    Public Property MaterialCloseDate() As Nullable(Of Date)
    <Column("EXT_CLOSE_DATE")>
    Public Property ExtendedCloseDate() As Nullable(Of Date)
    <Column("EXT_MATL_DATE")>
    Public Property ExtendedMaterialDate() As Nullable(Of Date)
    <MaxLength(60)>
    <Column("HEADLINE", TypeName:="varchar")>
    Public Property Headline() As String
    <MaxLength(6)>
    <Column("INTERNET_TYPE", TypeName:="varchar")>
    Public Property InternetTypeCode() As String
    <MaxLength(6)>
    <Column("SIZE", TypeName:="varchar")>
    Public Property Size() As String
    <Column("PROJ_IMPRESSIONS")>
    Public Property ProjectedImpressions() As Nullable(Of Integer)
    <Column("GUARANTEED_IMPRESS")>
    Public Property GuaranteedImpressions() As Nullable(Of Integer)
    <MaxLength(60)>
    <Column("URL", TypeName:="varchar")>
    Public Property Url() As String
    <MaxLength(60)>
    <Column("TARGET_AUDIENCE", TypeName:="varchar")>
    Public Property TargetAudience() As String
    <MaxLength(40)>
    <Column("COPY_AREA", TypeName:="varchar")>
    Public Property CopyArea() As String
    <Column("JOB_NUMBER")>
    Public Property JobNumber() As Nullable(Of Integer)
    <Column("JOB_COMPONENT_NBR")>
    Public Property JobComponentNumber() As Nullable(Of Short)
    <Column("QUANTITY")>
    Public Property Quantity() As Nullable(Of Integer)
    <Column("RATE")>
    Public Property Rate() As Nullable(Of Decimal)
    <Column("NET_RATE")>
    Public Property NetRate() As Nullable(Of Decimal)
    <Column("GROSS_RATE")>
    Public Property GrossRate() As Nullable(Of Decimal)
    <Column("EXT_NET_AMT")>
    Public Property ExtendedNetAmount() As Nullable(Of Decimal)
    <Column("EXT_GROSS_AMT")>
    Public Property ExtendedGrossAmount() As Nullable(Of Decimal)
    <Column("COMM_AMT")>
    Public Property CommissionAmount() As Nullable(Of Decimal)
    <Column("REBATE_AMT")>
    Public Property RebateAmount() As Nullable(Of Decimal)
    <Column("DISCOUNT_AMT")>
    Public Property DiscountAmount() As Nullable(Of Decimal)
    <MaxLength(30)>
    <Column("DISCOUNT_DESC", TypeName:="varchar")>
    Public Property DiscountDescription() As String
    <Column("STATE_AMT")>
    Public Property StateTaxAmount() As Nullable(Of Decimal)
    <Column("COUNTY_AMT")>
    Public Property CountyTaxAmount() As Nullable(Of Decimal)
    <Column("CITY_AMT")>
    Public Property CityTaxAmount() As Nullable(Of Decimal)
    <Column("NON_RESALE_AMT")>
    Public Property NonResalesAmount() As Nullable(Of Decimal)
    <Column("NETCHARGE")>
    Public Property NetCharge() As Nullable(Of Decimal)
    <MaxLength(30)>
    <Column("NCDESC", TypeName:="varchar")>
    Public Property NetChargeDescription() As String
    <Column("ADDL_CHARGE")>
    Public Property AdditionalCharge() As Nullable(Of Decimal)
    <MaxLength(30)>
    <Column("ADDL_CHARGE_DESC", TypeName:="varchar")>
    Public Property AdditionalChargeDescription() As String
    <Column("LINE_TOTAL")>
    Public Property LineTotal() As Nullable(Of Decimal)
    <Column("LINE_CANCELLED")>
    Public Property IsLineCancelled() As Nullable(Of Short)
    <Column("DATE_TO_BILL")>
    Public Property DateToBill() As Nullable(Of Date)
    <MaxLength(100)>
    <Column("BILLING_USER", TypeName:="varchar")>
    Public Property BillingUserCode() As String
    <Column("AR_INV_NBR")>
    Public Property ARInvoiceNumber() As Nullable(Of Integer)
    <MaxLength(2)>
    <Column("AR_TYPE", TypeName:="varchar")>
    Public Property ARType() As String
    <Column("AR_INV_SEQ")>
    Public Property ARSequenceNumber() As Nullable(Of Short)
    <Column("GLEXACT")>
    Public Property GLTransaction() As Nullable(Of Integer)
    <Column("GLESEQ_SALES")>
    Public Property GLSequenceSales() As Nullable(Of Short)
    <Column("GLESEQ_COS")>
    Public Property GLSequenceNumberCostOfSales() As Nullable(Of Short)
    <Column("GLESEQ_WIP")>
    Public Property GLSequenceWorkInProgress() As Nullable(Of Short)
    <Column("GLESEQ_STATE")>
    Public Property GLSequenceState() As Nullable(Of Short)
    <Column("GLESEQ_COUNTY")>
    Public Property GLSequenceNumberCounty() As Nullable(Of Short)
    <Column("GLESEQ_CITY")>
    Public Property GLSequenceNumberCity() As Nullable(Of Short)
    <Column("GLEXACT_DEF")>
    Public Property GLTransactionDeferred() As Nullable(Of Integer)
    <MaxLength(30)>
    <Column("GLACODE_SALES", TypeName:="varchar")>
    Public Property GLACodeSales() As String
    <MaxLength(30)>
    <Column("GLACODE_COS", TypeName:="varchar")>
    Public Property GLACodeCostOfSales() As String
    <MaxLength(30)>
    <Column("GLACODE_WIP", TypeName:="varchar")>
    Public Property GLACodeWorkInProgress() As String
    <MaxLength(30)>
    <Column("GLACODE_STATE", TypeName:="varchar")>
    Public Property GLACodeState() As String
    <MaxLength(30)>
    <Column("GLACODE_COUNTY", TypeName:="varchar")>
    Public Property GLACodeCounty() As String
    <MaxLength(30)>
    <Column("GLACODE_CITY", TypeName:="varchar")>
    Public Property GLACodeCity() As String
    <Column("NON_BILL_FLAG")>
    Public Property IsNonBillable() As Nullable(Of Short)
    <MaxLength(100)>
    <Column("MODIFIED_BY", TypeName:="varchar")>
    Public Property ModifiedBy() As String
    <Column("MODIFIED_DATE")>
    Public Property ModifiedDate() As Nullable(Of Date)
    <MaxLength(254)>
    <Column("MODIFIED_COMMENTS", TypeName:="varchar")>
    Public Property ModifiedComments() As String
    <Column("BILL_TYPE_FLAG")>
    Public Property BillTypeFlag() As Nullable(Of Short)
    <MaxLength(60)>
    <Column("CREATIVE_SIZE", TypeName:="varchar")>
    Public Property CreativeSize() As String
    <MaxLength(160)>
    <Column("PLACEMENT_1", TypeName:="varchar")>
    Public Property Placement1() As String
    <MaxLength(160)>
    <Column("PLACEMENT_2", TypeName:="varchar")>
    Public Property Placement2() As String
    <Column("COMM_PCT")>
    Public Property CommissionPercent() As Nullable(Of Decimal)
    <Column("MARKUP_PCT")>
    Public Property MarkupPercent() As Nullable(Of Decimal)
    <Column("REBATE_PCT")>
    Public Property RebatePercent() As Nullable(Of Decimal)
    <Column("DISCOUNT_PCT")>
    Public Property DiscountPercent() As Nullable(Of Decimal)
    <MaxLength(4)>
    <Column("TAX_CODE", TypeName:="varchar")>
    Public Property SalesTaxCode() As String
    <Column("TAX_CITY_PCT")>
    Public Property CityTaxPercent() As Nullable(Of Decimal)
    <Column("TAX_COUNTY_PCT")>
    Public Property CountyTaxPercent() As Nullable(Of Decimal)
    <Column("TAX_STATE_PCT")>
    Public Property StateTaxPercent() As Nullable(Of Decimal)
    <Column("TAX_RESALE")>
    Public Property IsResaleTax() As Nullable(Of Short)
    <Column("TAXAPPLYC")>
    Public Property TaxApplyC() As Nullable(Of Short)
    <Column("TAXAPPLYLN")>
    Public Property TaxApplyLN() As Nullable(Of Short)
    <Column("TAXAPPLYND")>
    Public Property TaxApplyLND() As Nullable(Of Short)
    <Column("TAXAPPLYNC")>
    Public Property TaxApplyNC() As Nullable(Of Short)
    <Column("TAXAPPLYR")>
    Public Property TaxApplyR() As Nullable(Of Short)
    <Column("TAXAPPLYAI")>
    Public Property TaxApplyAI() As Nullable(Of Short)
    <Column("ACT_IMPRESSIONS")>
    Public Property ActualImpressions() As Nullable(Of Integer)
    <Column("GLESEQ_SALES_DEF")>
    Public Property GLSequenceSalesDeferred() As Nullable(Of Short)
    <Column("GLESEQ_COS_DEF")>
    Public Property GLSequenceNumberCostOfSalesDeferred() As Nullable(Of Short)
    <MaxLength(30)>
    <Column("GLACODE_SALES_DEF", TypeName:="varchar")>
    Public Property GLACodeSalesDeferred() As String
    <MaxLength(30)>
    <Column("GLACODE_COS_DEF", TypeName:="varchar")>
    Public Property GLACodeCostOfSalesDeferred() As String
    <Column("BILLING_AMT")>
    Public Property BillingAmount() As Nullable(Of Decimal)
    <MaxLength(3)>
    <Column("COST_TYPE", TypeName:="varchar")>
    Public Property CostType() As String
    <Column("COST_RATE")>
    Public Property CostRate() As Nullable(Of Decimal)
    <Column("NET_BASE_RATE")>
    Public Property NetBaseRate() As Nullable(Of Decimal)
    <Column("GROSS_BASE_RATE")>
    Public Property GrossBaseRate() As Nullable(Of Decimal)
    <Column("BILL_CANCELLED")>
    Public Property IsBillCancelled() As Nullable(Of Short)
    <Column("EST_NBR")>
    Public Property EstimateNumber() As Nullable(Of Integer)
    <Column("EST_LINE_NBR")>
    Public Property EstimateLineNumber() As Nullable(Of Short)
    <Column("EST_REV_NBR")>
    Public Property EstimateRevisionNumber() As Nullable(Of Short)
    <MaxLength(30)>
    <Column("AD_NUMBER", TypeName:="varchar")>
    Public Property AdNumber() As String
    <Column("MAT_COMP")>
    Public Property MatCompDate() As Nullable(Of Date)
    <Column("AD_SERVER_PLACEMENT_ID")>
    Public Property AdServerPlacementID() As Nullable(Of Long)
    <Column("AD_SERVER_CREATED_BY", TypeName:="varchar")>
    <MaxLength(100)>
    Public Property AdServerCreatedBy() As String
    <Column("AD_SERVER_CREATED_DATETIME")>
    Public Property AdServerCreatedDateTime() As Nullable(Of Date)
    <Column("AD_SERVER_LAST_MODIFIED_BY", TypeName:="varchar")>
    <MaxLength(100)>
    Public Property AdServerLastModifiedBy() As String
    <Column("AD_SERVER_LAST_MODIFIED_DATETIME")>
    Public Property AdServerLastModifiedByDateTime() As Nullable(Of Date)
    <Column("AD_SERVER_PLACEMENT_GROUP_ID")>
    Public Property AdServerPlacementGroupID() As Nullable(Of Long)
    <Column("AD_SERVER_ID")>
    Public Property AdServerID() As Nullable(Of Short)
    <Column("MARKET_CODE")>
    Public Property MarketCode() As String
    <Column("AD_SERVER_PLACEMENT_MANUAL")>
    Public Property AdServerPlacementManual() As Nullable(Of Boolean)

#End Region

#Region " Methods "

    Public Overrides Function ToString() As String

        ToString = Me.OrderNumber.ToString

    End Function

#End Region

End Class
