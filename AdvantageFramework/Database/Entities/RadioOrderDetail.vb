Namespace Database.Entities

	<Table("RADIO_DETAIL")>
	Public Class RadioOrderDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			RadioOrderNumber
			LineNumber
			RevisionNumber
			SequenceNumber
			IsActiveRevision
			LinkDetailID
			BuyType
			StartDate
			EndDate
			MonthNumber
			YearNumber
			CloseDate
			MaterialCloseDate
			ExtendedCloseDate
			ExtendedMaterialDate
			Date1
			Date2
			Date3
			Date4
			Date5
			Date6
			Date7
			Monday
			Tuesday
			Wednesday
			Thursday
			Friday
			Saturday
			Sunday
			Spots1
			Spots2
			Spots3
			Spots4
			Spots5
			Spots6
			Spots7
			TotalSpots
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
			NonResaleAmount
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
			CostType
			CostRate
			NetBaseRate
			GrossBaseRate
			IsBillCancelled
			EstimateNumber
			EstimateLineNumber
			EstimateRevisionNumber
			AdNumber
			MaterialCompDate
			Programming
			StartTime
			EndTime
			Length
			Remarks
			Tag
			NetworkID
            LinkLineNumber
            VendorOrderLine
            DaypartID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ORDER_NBR", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RadioOrderNumber() As Integer
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
		<MaxLength(2)>
		<Column("BUY_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BuyType() As String
		<Column("START_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StartDate() As Nullable(Of Date)
		<Column("END_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EndDate() As Nullable(Of Date)
		<Required>
		<Column("MONTH_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MonthNumber() As Short
		<Required>
		<Column("YEAR_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property YearNumber() As Short
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
		<Column("DATE1")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Date1() As Nullable(Of Date)
		<Column("DATE2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Date2() As Nullable(Of Date)
		<Column("DATE3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Date3() As Nullable(Of Date)
		<Column("DATE4")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Date4() As Nullable(Of Date)
		<Column("DATE5")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Date5() As Nullable(Of Date)
		<Column("DATE6")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Date6() As Nullable(Of Date)
		<Column("DATE7")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Date7() As Nullable(Of Date)
		<Column("MONDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Monday() As Nullable(Of Short)
		<Column("TUESDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Tuesday() As Nullable(Of Short)
		<Column("WEDNESDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Wednesday() As Nullable(Of Short)
		<Column("THURSDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Thursday() As Nullable(Of Short)
		<Column("FRIDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Friday() As Nullable(Of Short)
		<Column("SATURDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Saturday() As Nullable(Of Short)
		<Column("SUNDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Sunday() As Nullable(Of Short)
		<Column("SPOTS1")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Spots1() As Nullable(Of Integer)
        <Column("SPOTS2")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Spots2() As Nullable(Of Integer)
        <Column("SPOTS3")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Spots3() As Nullable(Of Integer)
        <Column("SPOTS4")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Spots4() As Nullable(Of Integer)
        <Column("SPOTS5")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Spots5() As Nullable(Of Integer)
        <Column("SPOTS6")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Spots6() As Nullable(Of Integer)
        <Column("SPOTS7")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Spots7() As Nullable(Of Integer)
        <Column("TOTAL_SPOTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TotalSpots() As Nullable(Of Integer)
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobNumber() As Nullable(Of Integer)
		<Column("JOB_COMPONENT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentNumber() As Nullable(Of Short)
		<Column("QUANTITY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Quantity() As Nullable(Of Integer)
		<Column("RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        Public Property Rate() As Nullable(Of Decimal)
		<Column("NET_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        Public Property NetRate() As Nullable(Of Decimal)
		<Column("GROSS_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        Public Property GrossRate() As Nullable(Of Decimal)
		<Column("EXT_NET_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property ExtendedNetAmount() As Nullable(Of Decimal)
		<Column("EXT_GROSS_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property ExtendedGrossAmount() As Nullable(Of Decimal)
		<Column("COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property CommissionAmount() As Nullable(Of Decimal)
		<Column("REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property RebateAmount() As Nullable(Of Decimal)
		<Column("DISCOUNT_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property DiscountAmount() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("DISCOUNT_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DiscountDescription() As String
		<Column("STATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property StateTaxAmount() As Nullable(Of Decimal)
		<Column("COUNTY_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property CountyTaxAmount() As Nullable(Of Decimal)
		<Column("CITY_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property CityTaxAmount() As Nullable(Of Decimal)
		<Column("NON_RESALE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property NonResaleAmount() As Nullable(Of Decimal)
		<Column("NETCHARGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property NetCharge() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("NCDESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NetChargeDescription() As String
		<Column("ADDL_CHARGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property AdditionalCharge() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("ADDL_CHARGE_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdditionalChargeDescription() As String
		<Column("LINE_TOTAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
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
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property CommissionPercent() As Nullable(Of Decimal)
		<Column("MARKUP_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property MarkupPercent() As Nullable(Of Decimal)
		<Column("REBATE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property RebatePercent() As Nullable(Of Decimal)
		<Column("DISCOUNT_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property DiscountPercent() As Nullable(Of Decimal)
		<MaxLength(4)>
		<Column("TAX_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SalesTaxCode() As String
		<Column("TAX_CITY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property CityTaxPercent() As Nullable(Of Decimal)
		<Column("TAX_COUNTY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
        Public Property CountyTaxPercent() As Nullable(Of Decimal)
		<Column("TAX_STATE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 3)>
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
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property BillingAmount() As Nullable(Of Decimal)
		<MaxLength(3)>
		<Column("COST_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CostType() As String
		<Column("COST_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        Public Property CostRate() As Nullable(Of Decimal)
		<Column("NET_BASE_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        Public Property NetBaseRate() As Nullable(Of Decimal)
		<Column("GROSS_BASE_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
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
		Public Property MaterialCompDate() As Nullable(Of Date)
		<MaxLength(50)>
		<Column("PROGRAMMING", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Programming() As String
		<MaxLength(10)>
		<Column("START_TIME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StartTime() As String
		<MaxLength(10)>
		<Column("END_TIME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EndTime() As String
		<Column("LENGTH")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Length() As Nullable(Of Short)
		<MaxLength(254)>
		<Column("REMARKS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Remarks() As String
		<MaxLength(10)>
		<Column("TAG", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Tag() As String
		<MaxLength(10)>
		<Column("NETWORK_ID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetworkID() As String
        <Column("LINK_LINE_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LinkLineNumber() As Nullable(Of Integer)
        <Column("VENDOR_ORDER_LINE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorOrderLine() As Nullable(Of Integer)
        <Column("DAY_PART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DaypartID() As Nullable(Of Integer)

        '<NotMapped>
        'Public ReadOnly Property StartHourMinute As Integer
        '    Get
        '        If IsDate(Me.StartTime) Then
        '            If CDate(Me.StartTime).Hour < 5 Then
        '                StartHourMinute = (CDate(Me.StartTime).Hour + 24) * 100 + CDate(Me.StartTime).Minute
        '            Else
        '                StartHourMinute = CDate(Me.StartTime).Hour * 100 + CDate(Me.StartTime).Minute
        '            End If
        '        Else
        '            StartHourMinute = 0
        '        End If
        '    End Get
        'End Property
        '<NotMapped>
        'Public ReadOnly Property EndHourMinute As Integer
        '    Get
        '        If IsDate(Me.EndTime) Then
        '            If CDate(Me.EndTime).Hour < 5 OrElse (CDate(Me.EndTime).Hour = 5 AndAlso CDate(Me.EndTime).Minute = 0) Then
        '                EndHourMinute = (CDate(Me.EndTime).Hour + 24) * 100 + CDate(Me.EndTime).Minute
        '            Else
        '                EndHourMinute = CDate(Me.EndTime).Hour * 100 + CDate(Me.EndTime).Minute
        '            End If
        '        Else
        '            EndHourMinute = 0
        '        End If
        '    End Get
        'End Property
        <NotMapped>
        Public ReadOnly Property MinDate As Nullable(Of Date)
            Get
                MinDate = If(Date1, If(Date2, If(Date3, If(Date4, If(Date5, If(Date6, If(Date7, StartDate))))))).Value
            End Get
        End Property
        <NotMapped>
        Public ReadOnly Property MaxDate As Nullable(Of Date)
            Get
                Dim LastDate As Nullable(Of Date) = Nothing
                LastDate = If(Date7, If(Date6, If(Date5, If(Date4, If(Date3, If(Date2, Date1))))))
                If LastDate.HasValue Then
                    MaxDate = LastDate.Value.AddDays(6)
                Else
                    MaxDate = EndDate
                End If
            End Get
        End Property

#End Region

#Region " Methods "

        Public Function GetStartHourMinute(AdjacencyBefore As Short) As Integer

            Dim TempStartTime As Date = Nothing

            If IsDate(Me.StartTime) Then

                TempStartTime = CDate(Me.StartTime).AddMinutes(-1 * AdjacencyBefore)

                If CDate(TempStartTime).Hour < 5 Then

                    GetStartHourMinute = (CDate(TempStartTime).Hour + 24) * 100 + CDate(TempStartTime).Minute

                Else

                    GetStartHourMinute = CDate(TempStartTime).Hour * 100 + CDate(TempStartTime).Minute

                End If

            Else

                GetStartHourMinute = 0

            End If

        End Function
        Public Function GetEndHourMinute(AdjacencyAfter As Short) As Integer

            Dim TempEndTime As Date = Nothing

            If IsDate(Me.EndTime) Then

                TempEndTime = CDate(Me.EndTime).AddMinutes(AdjacencyAfter)

                If CDate(TempEndTime).Hour < 5 OrElse (CDate(TempEndTime).Hour = 5 AndAlso CDate(TempEndTime).Minute = 0) Then

                    GetEndHourMinute = (CDate(TempEndTime).Hour + 24) * 100 + CDate(TempEndTime).Minute

                Else

                    GetEndHourMinute = CDate(TempEndTime).Hour * 100 + CDate(TempEndTime).Minute

                End If

            Else

                GetEndHourMinute = 0

            End If

        End Function
        Public Overrides Function ToString() As String

            ToString = Me.RadioOrderNumber.ToString

        End Function

#End Region

	End Class

End Namespace
