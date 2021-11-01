Namespace Database.Entities

	<Table("INTERNET_DETAIL")>
	Public Class InternetOrderDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			InternetOrderOrderNumber
			LineNumber
			RevisionNumber
			SequenceNumber
			IsActiveRevision
			LinkDetailID
			StartDate
			EndDate
			CloseDate
			MaterialCloseDate
			ExtendedCloseDate
			ExtendedMaterialDate
			Headline
			InternetTypeCode
			Size
			ProjectedImpressions
			GuaranteedImpressions
			Url
			TargetAudience
			CopyArea
			JobNumber
			JobComponentNumber
			Quantity
			Rate
			NetRate
			GrossRate
			ExtendedNetAmount
			ExtendedGrossAmount
			CommissionAmount
			RebateAmount
			DiscountAmount
			DiscountDescription
			StateTaxAmount
			CountyTaxAmount
			CityTaxAmount
			NonResalesAmount
			NetCharge
			NetChargeDescription
			AdditionalCharge
			AdditionalChargeDescription
			LineTotal
			IsLineCancelled
			DateToBill
			BillingUserCode
			ARInvoiceNumber
			ARType
			ARSequenceNumber
			GLTransaction
			GLSequenceSales
			GLSequenceNumberCostOfSales
			GLSequenceWorkInProgress
			GLSequenceState
			GLSequenceNumberCounty
			GLSequenceNumberCity
			GLTransactionDeferred
			GLACodeSales
			GLACodeCostOfSales
			GLACodeWorkInProgress
			GLACodeState
			GLACodeCounty
			GLACodeCity
			IsNonBillable
			ModifiedBy
			ModifiedDate
			ModifiedComments
			BillTypeFlag
			CreativeSize
			Placement1
			Placement2
			CommissionPercent
			MarkupPercent
			RebatePercent
			DiscountPercent
			SalesTaxCode
			CityTaxPercent
			CountyTaxPercent
			StateTaxPercent
			IsResaleTax
			TaxApplyC
			TaxApplyLN
			TaxApplyLND
			TaxApplyNC
			TaxApplyR
			TaxApplyAI
			ActualImpressions
			GLSequenceSalesDeferred
			GLSequenceNumberCostOfSalesDeferred
			GLACodeSalesDeferred
			GLACodeCostOfSalesDeferred
			BillingAmount
			CostType
			CostRate
			NetBaseRate
			GrossBaseRate
			IsBillCancelled
			EstimateNumber
			EstimateLineNumber
			EstimateRevisionNumber
			AdNumber
            MatCompDate
            AdServerPlacementID
            AdServerCreatedBy
            AdServerCreatedDateTime
            AdServerLastModifiedBy
            AdServerLastModifiedByDateTime
            AdServerPlacementGroupID
            AdServerID
            MarketCode
            MediaChannelID
            MediaTacticID
            AccountPayableInternets
			InternetType
			JobComponent
            InternetOrder
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("ORDER_NBR", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetOrderOrderNumber() As Integer
		<Key>
		<Required>
        <Column("LINE_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LineNumber() As Short
		<Key>
		<Required>
        <Column("REV_NBR", Order:=2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RevisionNumber() As Short
		<Key>
		<Required>
        <Column("SEQ_NBR", Order:=3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SequenceNumber() As Short
		<Column("ACTIVE_REV")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsActiveRevision() As Nullable(Of Short)
		<Column("LINK_DETID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LinkDetailID() As Nullable(Of Integer)
		<Column("START_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StartDate() As Nullable(Of Date)
		<Column("END_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EndDate() As Nullable(Of Date)
		<Column("CLOSE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CloseDate() As Nullable(Of Date)
		<Column("MATL_CLOSE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MaterialCloseDate() As Nullable(Of Date)
		<Column("EXT_CLOSE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExtendedCloseDate() As Nullable(Of Date)
		<Column("EXT_MATL_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExtendedMaterialDate() As Nullable(Of Date)
		<MaxLength(60)>
		<Column("HEADLINE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Headline() As String
		<MaxLength(6)>
		<Column("INTERNET_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetTypeCode() As String
		<MaxLength(6)>
		<Column("SIZE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Size() As String
		<Column("PROJ_IMPRESSIONS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProjectedImpressions() As Nullable(Of Integer)
		<Column("GUARANTEED_IMPRESS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GuaranteedImpressions() As Nullable(Of Integer)
		<MaxLength(60)>
		<Column("URL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Url() As String
        <MaxLength(60)>
        <Column("TARGET_AUDIENCE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TargetAudience() As String
		<MaxLength(40)>
		<Column("COPY_AREA", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CopyArea() As String
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobNumber() As Nullable(Of Integer)
		<Column("JOB_COMPONENT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentNumber() As Nullable(Of Short)
		<Column("QUANTITY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quantity() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <Column("RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Rate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <Column("NET_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetRate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <Column("GROSS_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GrossRate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("EXT_NET_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedNetAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("EXT_GROSS_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedGrossAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CommissionAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RebateAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("DISCOUNT_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DiscountAmount() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("DISCOUNT_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DiscountDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("STATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StateTaxAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("COUNTY_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CountyTaxAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("CITY_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CityTaxAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("NON_RESALE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NonResalesAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("NETCHARGE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NetCharge() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("NCDESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetChargeDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("ADDL_CHARGE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdditionalCharge() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("ADDL_CHARGE_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdditionalChargeDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("LINE_TOTAL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LineTotal() As Nullable(Of Decimal)
		<Column("LINE_CANCELLED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsLineCancelled() As Nullable(Of Short)
		<Column("DATE_TO_BILL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DateToBill() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("BILLING_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingUserCode() As String
		<Column("AR_INV_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARInvoiceNumber() As Nullable(Of Integer)
		<MaxLength(2)>
		<Column("AR_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARType() As String
		<Column("AR_INV_SEQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARSequenceNumber() As Nullable(Of Short)
		<Column("GLEXACT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLTransaction() As Nullable(Of Integer)
		<Column("GLESEQ_SALES")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceSales() As Nullable(Of Short)
		<Column("GLESEQ_COS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberCostOfSales() As Nullable(Of Short)
		<Column("GLESEQ_WIP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceWorkInProgress() As Nullable(Of Short)
		<Column("GLESEQ_STATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceState() As Nullable(Of Short)
		<Column("GLESEQ_COUNTY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberCounty() As Nullable(Of Short)
		<Column("GLESEQ_CITY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberCity() As Nullable(Of Short)
		<Column("GLEXACT_DEF")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLTransactionDeferred() As Nullable(Of Integer)
		<MaxLength(30)>
		<Column("GLACODE_SALES", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeSales() As String
		<MaxLength(30)>
		<Column("GLACODE_COS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeCostOfSales() As String
		<MaxLength(30)>
		<Column("GLACODE_WIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeWorkInProgress() As String
		<MaxLength(30)>
		<Column("GLACODE_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeState() As String
		<MaxLength(30)>
		<Column("GLACODE_COUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeCounty() As String
		<MaxLength(30)>
		<Column("GLACODE_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeCity() As String
		<Column("NON_BILL_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsNonBillable() As Nullable(Of Short)
		<MaxLength(100)>
		<Column("MODIFIED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedBy() As String
		<Column("MODIFIED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)
		<MaxLength(254)>
		<Column("MODIFIED_COMMENTS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedComments() As String
		<Column("BILL_TYPE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillTypeFlag() As Nullable(Of Short)
		<MaxLength(60)>
		<Column("CREATIVE_SIZE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreativeSize() As String
        <MaxLength(256)>
        <Column("PLACEMENT_1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Placement1() As String
		<MaxLength(160)>
		<Column("PLACEMENT_2", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Placement2() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("COMM_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CommissionPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("MARKUP_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarkupPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("REBATE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RebatePercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("DISCOUNT_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DiscountPercent() As Nullable(Of Decimal)
		<MaxLength(4)>
		<Column("TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesTaxCode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("TAX_CITY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CityTaxPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("TAX_COUNTY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CountyTaxPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        <Column("TAX_STATE_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StateTaxPercent() As Nullable(Of Decimal)
		<Column("TAX_RESALE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsResaleTax() As Nullable(Of Short)
		<Column("TAXAPPLYC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxApplyC() As Nullable(Of Short)
		<Column("TAXAPPLYLN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxApplyLN() As Nullable(Of Short)
		<Column("TAXAPPLYND")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxApplyLND() As Nullable(Of Short)
		<Column("TAXAPPLYNC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxApplyNC() As Nullable(Of Short)
		<Column("TAXAPPLYR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxApplyR() As Nullable(Of Short)
		<Column("TAXAPPLYAI")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxApplyAI() As Nullable(Of Short)
		<Column("ACT_IMPRESSIONS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ActualImpressions() As Nullable(Of Integer)
		<Column("GLESEQ_SALES_DEF")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceSalesDeferred() As Nullable(Of Short)
		<Column("GLESEQ_COS_DEF")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberCostOfSalesDeferred() As Nullable(Of Short)
		<MaxLength(30)>
		<Column("GLACODE_SALES_DEF", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeSalesDeferred() As String
		<MaxLength(30)>
		<Column("GLACODE_COS_DEF", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACodeCostOfSalesDeferred() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("BILLING_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingAmount() As Nullable(Of Decimal)
		<MaxLength(3)>
		<Column("COST_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CostType() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <Column("COST_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CostRate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <Column("NET_BASE_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetBaseRate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <Column("GROSS_BASE_RATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GrossBaseRate() As Nullable(Of Decimal)
		<Column("BILL_CANCELLED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsBillCancelled() As Nullable(Of Short)
		<Column("EST_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EstimateNumber() As Nullable(Of Integer)
		<Column("EST_LINE_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EstimateLineNumber() As Nullable(Of Short)
		<Column("EST_REV_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EstimateRevisionNumber() As Nullable(Of Short)
		<MaxLength(30)>
		<Column("AD_NUMBER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdNumber() As String
		<Column("MAT_COMP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MatCompDate() As Nullable(Of Date)
        <Column("AD_SERVER_PLACEMENT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerPlacementID() As Nullable(Of Long)
        <Column("AD_SERVER_CREATED_BY", TypeName:="varchar")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerCreatedBy() As String
        <Column("AD_SERVER_CREATED_DATETIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerCreatedDateTime() As Nullable(Of Date)
        <Column("AD_SERVER_LAST_MODIFIED_BY", TypeName:="varchar")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerLastModifiedBy() As String
        <Column("AD_SERVER_LAST_MODIFIED_DATETIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerLastModifiedByDateTime() As Nullable(Of Date)
        <Column("AD_SERVER_PLACEMENT_GROUP_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerPlacementGroupID() As Nullable(Of Long)
        <Column("AD_SERVER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerID() As Nullable(Of Short)
        <Column("MARKET_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarketCode() As String
        <Column("MEDIA_CHANNEL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaChannelID() As Nullable(Of Integer)
        <Column("MEDIA_TACTIC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaTacticID() As Nullable(Of Integer)

        Public Overridable Property AccountPayableInternets As ICollection(Of Database.Entities.AccountPayableInternet)
        Public Overridable Property InternetType As Database.Entities.InternetType
        <ForeignKey("JobNumber, JobComponentNumber")>
        Public Overridable Property JobComponent As Database.Entities.JobComponent
        Public Overridable Property InternetOrder As Database.Entities.InternetOrder

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.InternetOrderOrderNumber.ToString

        End Function

#End Region

	End Class

End Namespace
