Namespace Database.Entities

	<Table("NEWSPAPER_DETAIL")>
	Public Class NewspaperOrderDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			NewspaperOrderOrderNumber
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
			Size
			AdNumber
			Headline
			Material
			EditionIssue
			Section
			JobNumber
			JobComponentNumber
			RateCardID
			RateDetailID
			PrintColumns
			PrintInches
			PrintLines
			ContractQuantity
			Quantity
			Rate
			NetRate
			GrossRate
			FlatNet
			FlatGross
			ExtendedNetAmount
			ExtendedGrossAmount
			CommissionAmount
			RebateAmount
			DiscountAmount
			DiscountDescription
			StateTaxAmount
			CountyTaxAmount
			CityTaxAmount
			VendorTaxAmount
			NetCharge
			NetChargeDescription
			AdditionalCharge
			AdditionalChargeDescription
			ProductionCharge
			ProductionDescription
			ColorCharge
			ColorDescription
			LineTotal
			IsLineCancelled
			DateToBill
			BillingUserCode
			ARInvoiceNumber
			ARType
			ARSequenceNumber
			GLTransaction
			GLSequenceNumberSales
			GLSequenceNumberCostOfSales
			GLSequenceNumberWorkInProgress
			GLSequenceNumberState
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
			TaxApplyND
			TaxApplyNC
			TaxApplyR
			TaxApplyAI
			IsReconciled
			GLSequenceNumberSalesDeferred
			GLSequenceNumberCostOfSalesDeferred
			GLACodeSalesDeferred
			GLACodeCostOfSalesDeferred
			BillingAmount
			IsBillCancelled
			EstimateNumber
			EstimateLineNumber
			EstimateRevisionNumber
			FlatNetCharge
			FlatAdditionalCharge
			FlatDiscountAmount
			ProductionSize
			MaterialCompDate
			SizeCode
			CostType
			CostRate
			RateType
			NewspaperCirculation
			PrintQuantity
			JobComponent
			NewspaperOrder

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("ORDER_NBR", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property NewspaperOrderOrderNumber() As Integer
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
		<MaxLength(30)>
		<Column("SIZE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Size() As String
		<MaxLength(30)>
		<Column("AD_NUMBER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdNumber() As String
		<MaxLength(60)>
		<Column("HEADLINE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Headline() As String
		<MaxLength(60)>
		<Column("MATERIAL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Material() As String
		<MaxLength(30)>
		<Column("EDITION_ISSUE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EditionIssue() As String
		<MaxLength(30)>
		<Column("SECTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Section() As String
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property JobNumber() As Nullable(Of Integer)
		<Column("JOB_COMPONENT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentNumber() As Nullable(Of Short)
		<Column("RATE_CARD_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RateCardID() As Nullable(Of Integer)
		<Column("RATE_DTL_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RateDetailID() As Nullable(Of Short)
		<Column("PRINT_COLUMNS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(6, 2)>
        Public Property PrintColumns() As Nullable(Of Decimal)
		<Column("PRINT_INCHES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(6, 2)>
        Public Property PrintInches() As Nullable(Of Decimal)
		<Column("PRINT_LINES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(11, 2)>
        Public Property PrintLines() As Nullable(Of Decimal)
		<Column("CONTRACT_QTY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(11, 2)>
        Public Property ContractQuantity() As Nullable(Of Decimal)
		<Column("QUANTITY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property Quantity() As Nullable(Of Decimal)
		<Column("RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(16, 4)>
        Public Property Rate() As Nullable(Of Decimal)
		<Column("NET_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(16, 4)>
        Public Property NetRate() As Nullable(Of Decimal)
		<Column("GROSS_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(16, 4)>
        Public Property GrossRate() As Nullable(Of Decimal)
		<Column("FLAT_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(16, 4)>
        Public Property FlatNet() As Nullable(Of Decimal)
		<Column("FLAT_GROSS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(16, 4)>
        Public Property FlatGross() As Nullable(Of Decimal)
		<Column("EXT_NET_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(15, 2)>
        Public Property ExtendedNetAmount() As Nullable(Of Decimal)
		<Column("EXT_GROSS_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(15, 2)>
        Public Property ExtendedGrossAmount() As Nullable(Of Decimal)
		<Column("COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(15, 2)>
        Public Property CommissionAmount() As Nullable(Of Decimal)
		<Column("REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(14, 2)>
        Public Property RebateAmount() As Nullable(Of Decimal)
		<Column("DISCOUNT_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(14, 2)>
        Public Property DiscountAmount() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("DISCOUNT_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DiscountDescription() As String
		<Column("STATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(14, 2)>
        Public Property StateTaxAmount() As Nullable(Of Decimal)
		<Column("COUNTY_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(14, 2)>
        Public Property CountyTaxAmount() As Nullable(Of Decimal)
		<Column("CITY_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(14, 2)>
        Public Property CityTaxAmount() As Nullable(Of Decimal)
		<Column("NON_RESALE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(14, 2)>
        Public Property VendorTaxAmount() As Nullable(Of Decimal)
		<Column("NETCHARGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(14, 2)>
        Public Property NetCharge() As Nullable(Of Decimal)
		<MaxLength(60)>
		<Column("NETCHARGE_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NetChargeDescription() As String
		<Column("ADDL_CHARGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(14, 2)>
        Public Property AdditionalCharge() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("ADDL_CHARGE_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdditionalChargeDescription() As String
		<Column("PROD_CHARGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(14, 3)>
        Public Property ProductionCharge() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("PROD_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionDescription() As String
		<Column("COLOR_CHARGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(15, 4)>
        Public Property ColorCharge() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("COLOR_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ColorDescription() As String
		<Column("LINE_TOTAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(15, 2)>
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
		Public Property GLSequenceNumberSales() As Nullable(Of Short)
		<Column("GLESEQ_COS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberCostOfSales() As Nullable(Of Short)
		<Column("GLESEQ_WIP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberWorkInProgress() As Nullable(Of Short)
		<Column("GLESEQ_STATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberState() As Nullable(Of Short)
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
		<Column("COMM_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        Public Property CommissionPercent() As Nullable(Of Decimal)
		<Column("MARKUP_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        Public Property MarkupPercent() As Nullable(Of Decimal)
		<Column("REBATE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        Public Property RebatePercent() As Nullable(Of Decimal)
		<Column("DISCOUNT_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        Public Property DiscountPercent() As Nullable(Of Decimal)
		<MaxLength(4)>
		<Column("TAX_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SalesTaxCode() As String
		<Column("TAX_CITY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        Public Property CityTaxPercent() As Nullable(Of Decimal)
		<Column("TAX_COUNTY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
        Public Property CountyTaxPercent() As Nullable(Of Decimal)
		<Column("TAX_STATE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(7, 3)>
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
		Public Property TaxApplyND() As Nullable(Of Short)
		<Column("TAXAPPLYNC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxApplyNC() As Nullable(Of Short)
		<Column("TAXAPPLYR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxApplyR() As Nullable(Of Short)
		<Column("TAXAPPLYAI")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxApplyAI() As Nullable(Of Short)
		<Column("RECONCILE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsReconciled() As Nullable(Of Short)
		<Column("GLESEQ_SALES_DEF")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberSalesDeferred() As Nullable(Of Short)
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
		<Column("BILLING_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(15, 2)>
        Public Property BillingAmount() As Nullable(Of Decimal)
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
		<Column("FLAT_NETCHARGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(15, 2)>
        Public Property FlatNetCharge() As Nullable(Of Decimal)
		<Column("FLAT_ADDL_CHARGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(15, 2)>
        Public Property FlatAdditionalCharge() As Nullable(Of Decimal)
		<Column("FLAT_DISCOUNT_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(15, 2)>
        Public Property FlatDiscountAmount() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("PRODUCTION_SIZE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionSize() As String
		<Column("MAT_COMP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MaterialCompDate() As Nullable(Of Date)
		<MaxLength(6)>
		<Column("SIZE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SizeCode() As String
		<MaxLength(3)>
		<Column("COST_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CostType() As String
		<Column("COST_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(16, 4)>
        Public Property CostRate() As Nullable(Of Decimal)
		<MaxLength(3)>
		<Column("RATE_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RateType() As String
		<Column("NP_CIRCULATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperCirculation() As Nullable(Of Integer)
		<Column("PRINT_QUANTITY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(14, 3)>
        Public Property PrintQuantity() As Nullable(Of Decimal)

        <ForeignKey("JobNumber, JobComponentNumber")>
        Public Overridable Property JobComponent As Database.Entities.JobComponent
        Public Overridable Property NewspaperOrder As Database.Entities.NewspaperOrder

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.NewspaperOrderOrderNumber.ToString

        End Function

#End Region

	End Class

End Namespace
