Namespace Database.Entities

	<Table("TV_DETAIL1")>
	Public Class TVOrderDetailLegacy
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			OrderNumber
			LineNumber
			RevisionNumber
			SequenceNumber
			BroadcastYear
			LinkID
			LinkDetailID
			StartTime
			EndTime
			Length
			CloseDate
			ExtendedCloseDate
			MaterialCloseDate
			ExtendedMaterialDate
			Programming
			Tag
			IsLineCancelled
			Printed
			Remarks
			Rate
			RateCard
			RateDescription
			JobNumber
			JobComponentNumber
			CommissionAmount
			RebateAmount
			GrossRate
			NetRate
			TotalSpots
			ExtendedNetAmount
			VendorTax
			StateTax
			CountyTax
			CityTax
			LineNetDiscount
			NetCharges
			VendorTaxNetCharges
			StateTaxNetCharges
			CountyTaxNetCharges
			CityTaxNetCharges
			LineTotal
			ARInvoiceNumber
			ARSequenceNumber
			ARType
			CancelledBy
			CancelledDate
			JanLineNet
			JanCommissionAmount
			JanRebateAmount
			JanDiscount
			JanVendorTax
			JanStateTax
			JanCountyTax
			JanCityTax
			JanSpots
			JanBillingAmount
			JanARInvoiceNumber
			JanARSequenceNumber
			JanARType
			FebLineNet
			FebCommissionAmount
			FebRebateAmount
			FebDiscount
			FebVendorTax
			FebStateTax
			FebCountyTax
			FebCityTax
			FebSpots
			FebBillingAmount
			FebARInvoiceNumber
			FebARSequenceNumber
			FebARType
			MarLineNet
			MarCommissionAmount
			MarRebateAmount
			MarDiscount
			MarVendorTax
			MarStateTax
			MarCountyTax
			MarCityTax
			MarSpots
			MarBillingAmount
			MarARInvoiceNumber
			MarARSequenceNumber
			MarARType
			AprLineNet
			AprCommissionAmount
			AprRebateAmount
			AprDiscount
			AprVendorTax
			AprStateTax
			AprCountyTax
			AprCityTax
			AprSpots
			AprBillingAmount
			AprARInvoiceNumber
			AprARSequenceNumber
			AprARType
			MayLineNet
			MayCommissionAmount
			MayRebateAmount
			MayDiscount
			MayVendorTax
			MayStateTax
			MayCountyTax
			MayCityTax
			MaySpots
			MayBillingAmount
			MayARInvoiceNumber
			MayARSequenceNumber
			MayARType
			JunLineNet
			JunCommissionAmount
			JunRebateAmount
			JunDiscount
			JunVendorTax
			JunStateTax
			JunCountyTax
			JunCityTax
			JunSpots
			JunBillingAmount
			JunARInvoiceNumber
			JunARSequenceNumber
			JunARType
			JulLineNet
			JulCommissionAmount
			JulRebateAmount
			JulDiscount
			JulVendorTax
			JulStateTax
			JulCountyTax
			JulCityTax
			JulSpots
			JulBillingAmount
			JulARInvoiceNumber
			JulARSequenceNumber
			JulARType
			AugLineNet
			AugCommissionAmount
			AugRebateAmount
			AugDiscount
			AugVendorTax
			AugStateTax
			AugCountyTax
			AugCityTax
			AugSpots
			AugBillingAmount
			AugARInvoiceNumber
			AugARSequenceNumber
			AugARType
			SepLineNet
			SepCommissionAmount
			SepRebateAmount
			SepDiscount
			SepVendorTax
			SepStateTax
			SepCountyTax
			SepCityTax
			SepSpots
			SepBillingAmount
			SepARInvoiceNumber
			SepARSequenceNumber
			SepARType
			OctLineNet
			OctCommissionAmount
			OctRebateAmount
			OctDiscount
			OctVendorTax
			OctStateTax
			OctCountyTax
			OctCityTax
			OctSpots
			OctBillingAmount
			OctARInvoiceNumber
			OctARSequenceNumber
			OctARType
			NovLineNet
			NovCommissionAmount
			NovRebateAmount
			NovDiscount
			NovVendorTax
			NovStateTax
			NovCountyTax
			NovCityTax
			NovSpots
			NovBillingAmount
			NovARInvoiceNumber
			NovARSequenceNumber
			NovARType
			DecLineNet
			DecCommissionAmount
			DecRebateAmount
			DecDiscount
			DecVendorTax
			DecStateTax
			DecCountyTax
			DecCityTax
			DecSpots
			DecBillingAmount
			DecARInvoiceNumber
			DecARSequenceNumber
			DecARType
			IsDeleted
			DeleteDate
			DeletedBy
			BillingUserCode
			BillMonths
			ReconcileLine
			DoNotBill
			IsReconciled
			IsReversed
			MaterialCompDate
			JobComponent
			TVOrderLegacy
			AccountReceivableApr
			AccountReceivableAug
			AccountReceivableDec
			AccountReceivableFeb
			AccountReceivableJan
			AccountReceivableJul
			AccountReceivableJun
			AccountReceivableMar
			AccountReceivableMay
			AccountReceivable
			AccountReceivableNov
			AccountReceivableOct
			AccountReceivableSep

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ORDER_NBR", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderNumber() As Integer
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
		<Key>
		<Required>
        <Column("BRDCAST_YEAR", Order:=4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BroadcastYear() As Integer
		<Column("LINK_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LinkID() As Nullable(Of Integer)
		<Column("LINK_DETID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LinkDetailID() As Nullable(Of Integer)
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
		<Column("CLOSE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CloseDate() As Nullable(Of Date)
		<Column("EXT_CLOSE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExtendedCloseDate() As Nullable(Of Date)
		<Column("MATL_CLOSE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MaterialCloseDate() As Nullable(Of Date)
		<Column("EXT_MATL_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExtendedMaterialDate() As Nullable(Of Date)
		<MaxLength(50)>
		<Column("PROGRAMMING", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Programming() As String
		<MaxLength(10)>
		<Column("TAG", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Tag() As String
		<Column("LINE_CANCELLED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsLineCancelled() As Nullable(Of Short)
		<Column("PRINTED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Printed() As Nullable(Of Short)
		<MaxLength(254)>
		<Column("REMARKS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Remarks() As String
		<Column("RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 4)>
        Public Property Rate() As Nullable(Of Decimal)
		<MaxLength(10)>
		<Column("RATE_CARD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RateCard() As String
		<MaxLength(10)>
		<Column("RATE_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RateDescription() As String
        <Column("JOB_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobNumber() As Nullable(Of Integer)
        <Column("JOB_COMPONENT_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentNumber() As Nullable(Of Short)
		<Column("COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property CommissionAmount() As Nullable(Of Decimal)
		<Column("REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property RebateAmount() As Nullable(Of Decimal)
		<Column("GROSS_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property GrossRate() As Nullable(Of Decimal)
		<Column("NET_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property NetRate() As Nullable(Of Decimal)
		<Column("TOTAL_SPOTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TotalSpots() As Nullable(Of Short)
		<Column("EXT_NET_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property ExtendedNetAmount() As Nullable(Of Decimal)
		<Column("VENDOR_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property VendorTax() As Nullable(Of Decimal)
		<Column("STATE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property StateTax() As Nullable(Of Decimal)
		<Column("COUNTY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property CountyTax() As Nullable(Of Decimal)
		<Column("CITY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property CityTax() As Nullable(Of Decimal)
		<Column("LINE_NET_DISC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property LineNetDiscount() As Nullable(Of Decimal)
		<Column("NETCHARGES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property NetCharges() As Nullable(Of Decimal)
		<Column("VENDOR_TAX_NC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property VendorTaxNetCharges() As Nullable(Of Decimal)
		<Column("STATE_TAX_NC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property StateTaxNetCharges() As Nullable(Of Decimal)
		<Column("COUNTY_TAX_NC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property CountyTaxNetCharges() As Nullable(Of Decimal)
		<Column("CITY_TAX_NC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property CityTaxNetCharges() As Nullable(Of Decimal)
		<Column("LINE_TOTAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property LineTotal() As Nullable(Of Decimal)
        <Column("AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARInvoiceNumber() As Nullable(Of Integer)
        <Column("AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARSequenceNumber() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARType() As String
        <MaxLength(100)>
        <Column("CANCELLED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CancelledBy() As String
        <Column("CANCELLED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CancelledDate() As Nullable(Of Date)
        <Column("JAN_LINE_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property JanLineNet() As Nullable(Of Decimal)
        <Column("JAN_COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JanCommissionAmount() As Nullable(Of Decimal)
        <Column("JAN_REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JanRebateAmount() As Nullable(Of Decimal)
        <Column("JAN_DISCOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JanDiscount() As Nullable(Of Decimal)
        <Column("JAN_VENDOR_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JanVendorTax() As Nullable(Of Decimal)
        <Column("JAN_STATE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JanStateTax() As Nullable(Of Decimal)
        <Column("JAN_COUNTY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JanCountyTax() As Nullable(Of Decimal)
        <Column("JAN_CITY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JanCityTax() As Nullable(Of Decimal)
        <Column("JAN_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JanSpots() As Nullable(Of Short)
        <Column("JAN_BILLING_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property JanBillingAmount() As Nullable(Of Decimal)
        <Column("JAN_AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JanARInvoiceNumber() As Nullable(Of Integer)
        <Column("JAN_AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JanARSequenceNumber() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("JAN_AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JanARType() As String
        <Column("FEB_LINE_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property FebLineNet() As Nullable(Of Decimal)
        <Column("FEB_COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property FebCommissionAmount() As Nullable(Of Decimal)
        <Column("FEB_REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property FebRebateAmount() As Nullable(Of Decimal)
        <Column("FEB_DISCOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property FebDiscount() As Nullable(Of Decimal)
        <Column("FEB_VENDOR_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property FebVendorTax() As Nullable(Of Decimal)
        <Column("FEB_STATE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property FebStateTax() As Nullable(Of Decimal)
        <Column("FEB_COUNTY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property FebCountyTax() As Nullable(Of Decimal)
        <Column("FEB_CITY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property FebCityTax() As Nullable(Of Decimal)
        <Column("FEB_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FebSpots() As Nullable(Of Short)
        <Column("FEB_BILLING_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property FebBillingAmount() As Nullable(Of Decimal)
        <Column("FEB_AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FebARInvoiceNumber() As Nullable(Of Integer)
        <Column("FEB_AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FebARSequenceNumber() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("FEB_AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FebARType() As String
        <Column("MAR_LINE_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property MarLineNet() As Nullable(Of Decimal)
        <Column("MAR_COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property MarCommissionAmount() As Nullable(Of Decimal)
        <Column("MAR_REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property MarRebateAmount() As Nullable(Of Decimal)
        <Column("MAR_DISCOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property MarDiscount() As Nullable(Of Decimal)
        <Column("MAR_VENDOR_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property MarVendorTax() As Nullable(Of Decimal)
        <Column("MAR_STATE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property MarStateTax() As Nullable(Of Decimal)
        <Column("MAR_COUNTY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property MarCountyTax() As Nullable(Of Decimal)
        <Column("MAR_CITY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property MarCityTax() As Nullable(Of Decimal)
        <Column("MAR_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarSpots() As Nullable(Of Short)
        <Column("MAR_BILLING_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property MarBillingAmount() As Nullable(Of Decimal)
        <Column("MAR_AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarARInvoiceNumber() As Nullable(Of Integer)
        <Column("MAR_AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarARSequenceNumber() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("MAR_AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarARType() As String
        <Column("APR_LINE_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property AprLineNet() As Nullable(Of Decimal)
        <Column("APR_COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property AprCommissionAmount() As Nullable(Of Decimal)
        <Column("APR_REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property AprRebateAmount() As Nullable(Of Decimal)
        <Column("APR_DISCOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property AprDiscount() As Nullable(Of Decimal)
        <Column("APR_VENDOR_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property AprVendorTax() As Nullable(Of Decimal)
        <Column("APR_STATE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property AprStateTax() As Nullable(Of Decimal)
        <Column("APR_COUNTY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property AprCountyTax() As Nullable(Of Decimal)
        <Column("APR_CITY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property AprCityTax() As Nullable(Of Decimal)
        <Column("APR_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AprSpots() As Nullable(Of Short)
        <Column("APR_BILLING_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property AprBillingAmount() As Nullable(Of Decimal)
        <Column("APR_AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AprARInvoiceNumber() As Nullable(Of Integer)
        <Column("APR_AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AprARSequenceNumber() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("APR_AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AprARType() As String
        <Column("MAY_LINE_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property MayLineNet() As Nullable(Of Decimal)
        <Column("MAY_COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property MayCommissionAmount() As Nullable(Of Decimal)
        <Column("MAY_REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property MayRebateAmount() As Nullable(Of Decimal)
        <Column("MAY_DISCOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property MayDiscount() As Nullable(Of Decimal)
        <Column("MAY_VENDOR_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property MayVendorTax() As Nullable(Of Decimal)
        <Column("MAY_STATE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property MayStateTax() As Nullable(Of Decimal)
        <Column("MAY_COUNTY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property MayCountyTax() As Nullable(Of Decimal)
        <Column("MAY_CITY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property MayCityTax() As Nullable(Of Decimal)
        <Column("MAY_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MaySpots() As Nullable(Of Short)
        <Column("MAY_BILLING_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property MayBillingAmount() As Nullable(Of Decimal)
        <Column("MAY_AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MayARInvoiceNumber() As Nullable(Of Integer)
        <Column("MAY_AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MayARSequenceNumber() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("MAY_AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MayARType() As String
        <Column("JUN_LINE_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property JunLineNet() As Nullable(Of Decimal)
        <Column("JUN_COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JunCommissionAmount() As Nullable(Of Decimal)
        <Column("JUN_REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JunRebateAmount() As Nullable(Of Decimal)
        <Column("JUN_DISCOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JunDiscount() As Nullable(Of Decimal)
        <Column("JUN_VENDOR_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JunVendorTax() As Nullable(Of Decimal)
        <Column("JUN_STATE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JunStateTax() As Nullable(Of Decimal)
        <Column("JUN_COUNTY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JunCountyTax() As Nullable(Of Decimal)
        <Column("JUN_CITY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JunCityTax() As Nullable(Of Decimal)
        <Column("JUN_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JunSpots() As Nullable(Of Short)
        <Column("JUN_BILLING_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property JunBillingAmount() As Nullable(Of Decimal)
        <Column("JUN_AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JunARInvoiceNumber() As Nullable(Of Integer)
        <Column("JUN_AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JunARSequenceNumber() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("JUN_AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JunARType() As String
        <Column("JUL_LINE_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property JulLineNet() As Nullable(Of Decimal)
        <Column("JUL_COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JulCommissionAmount() As Nullable(Of Decimal)
        <Column("JUL_REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JulRebateAmount() As Nullable(Of Decimal)
        <Column("JUL_DISCOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JulDiscount() As Nullable(Of Decimal)
        <Column("JUL_VENDOR_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JulVendorTax() As Nullable(Of Decimal)
        <Column("JUL_STATE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JulStateTax() As Nullable(Of Decimal)
        <Column("JUL_COUNTY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JulCountyTax() As Nullable(Of Decimal)
        <Column("JUL_CITY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property JulCityTax() As Nullable(Of Decimal)
        <Column("JUL_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JulSpots() As Nullable(Of Short)
        <Column("JUL_BILLING_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property JulBillingAmount() As Nullable(Of Decimal)
        <Column("JUL_AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JulARInvoiceNumber() As Nullable(Of Integer)
        <Column("JUL_AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JulARSequenceNumber() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("JUL_AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JulARType() As String
        <Column("AUG_LINE_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property AugLineNet() As Nullable(Of Decimal)
        <Column("AUG_COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property AugCommissionAmount() As Nullable(Of Decimal)
        <Column("AUG_REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property AugRebateAmount() As Nullable(Of Decimal)
        <Column("AUG_DISCOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property AugDiscount() As Nullable(Of Decimal)
        <Column("AUG_VENDOR_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property AugVendorTax() As Nullable(Of Decimal)
        <Column("AUG_STATE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property AugStateTax() As Nullable(Of Decimal)
        <Column("AUG_COUNTY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property AugCountyTax() As Nullable(Of Decimal)
        <Column("AUG_CITY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property AugCityTax() As Nullable(Of Decimal)
        <Column("AUG_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AugSpots() As Nullable(Of Short)
        <Column("AUG_BILLING_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property AugBillingAmount() As Nullable(Of Decimal)
        <Column("AUG_AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AugARInvoiceNumber() As Nullable(Of Integer)
        <Column("AUG_AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AugARSequenceNumber() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("AUG_AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AugARType() As String
        <Column("SEP_LINE_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property SepLineNet() As Nullable(Of Decimal)
        <Column("SEP_COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property SepCommissionAmount() As Nullable(Of Decimal)
        <Column("SEP_REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property SepRebateAmount() As Nullable(Of Decimal)
        <Column("SEP_DISCOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property SepDiscount() As Nullable(Of Decimal)
        <Column("SEP_VENDOR_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property SepVendorTax() As Nullable(Of Decimal)
        <Column("SEP_STATE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property SepStateTax() As Nullable(Of Decimal)
        <Column("SEP_COUNTY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property SepCountyTax() As Nullable(Of Decimal)
        <Column("SEP_CITY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property SepCityTax() As Nullable(Of Decimal)
        <Column("SEP_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SepSpots() As Nullable(Of Short)
        <Column("SEP_BILLING_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property SepBillingAmount() As Nullable(Of Decimal)
        <Column("SEP_AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SepARInvoiceNumber() As Nullable(Of Integer)
        <Column("SEP_AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SepARSequenceNumber() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("SEP_AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SepARType() As String
        <Column("OCT_LINE_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property OctLineNet() As Nullable(Of Decimal)
        <Column("OCT_COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property OctCommissionAmount() As Nullable(Of Decimal)
        <Column("OCT_REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property OctRebateAmount() As Nullable(Of Decimal)
        <Column("OCT_DISCOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property OctDiscount() As Nullable(Of Decimal)
        <Column("OCT_VENDOR_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property OctVendorTax() As Nullable(Of Decimal)
        <Column("OCT_STATE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property OctStateTax() As Nullable(Of Decimal)
        <Column("OCT_COUNTY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property OctCountyTax() As Nullable(Of Decimal)
        <Column("OCT_CITY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property OctCityTax() As Nullable(Of Decimal)
        <Column("OCT_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OctSpots() As Nullable(Of Short)
        <Column("OCT_BILLING_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property OctBillingAmount() As Nullable(Of Decimal)
        <Column("OCT_AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OctARInvoiceNumber() As Nullable(Of Integer)
        <Column("OCT_AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OctARSequenceNumber() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("OCT_AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OctARType() As String
        <Column("NOV_LINE_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property NovLineNet() As Nullable(Of Decimal)
        <Column("NOV_COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property NovCommissionAmount() As Nullable(Of Decimal)
        <Column("NOV_REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property NovRebateAmount() As Nullable(Of Decimal)
        <Column("NOV_DISCOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property NovDiscount() As Nullable(Of Decimal)
        <Column("NOV_VENDOR_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property NovVendorTax() As Nullable(Of Decimal)
        <Column("NOV_STATE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property NovStateTax() As Nullable(Of Decimal)
        <Column("NOV_COUNTY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property NovCountyTax() As Nullable(Of Decimal)
        <Column("NOV_CITY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property NovCityTax() As Nullable(Of Decimal)
        <Column("NOV_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NovSpots() As Nullable(Of Short)
        <Column("NOV_BILLING_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property NovBillingAmount() As Nullable(Of Decimal)
        <Column("NOV_AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NovARInvoiceNumber() As Nullable(Of Integer)
        <Column("NOV_AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NovARSequenceNumber() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("NOV_AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NovARType() As String
        <Column("DEC_LINE_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property DecLineNet() As Nullable(Of Decimal)
        <Column("DEC_COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property DecCommissionAmount() As Nullable(Of Decimal)
        <Column("DEC_REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property DecRebateAmount() As Nullable(Of Decimal)
        <Column("DEC_DISCOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property DecDiscount() As Nullable(Of Decimal)
        <Column("DEC_VENDOR_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property DecVendorTax() As Nullable(Of Decimal)
        <Column("DEC_STATE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property DecStatetax() As Nullable(Of Decimal)
        <Column("DEC_COUNTY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property DecCountyTax() As Nullable(Of Decimal)
        <Column("DEC_CITY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property DecCityTax() As Nullable(Of Decimal)
        <Column("DEC_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DecSpots() As Nullable(Of Short)
        <Column("DEC_BILLING_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property DecBillingAmount() As Nullable(Of Decimal)
        <Column("DEC_AR_INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DecARInvoiceNumber() As Nullable(Of Integer)
        <Column("DEC_AR_INV_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DecARSequenceNumber() As Nullable(Of Short)
        <MaxLength(3)>
        <Column("DEC_AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DecARType() As String
        <Column("DELETE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsDeleted() As Nullable(Of Short)
		<Column("DELETE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DeleteDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("DELETED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DeletedBy() As String
		<MaxLength(100)>
		<Column("BILLING_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingUserCode() As String
		<MaxLength(36)>
		<Column("BILL_MONTHS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillMonths() As String
		<Column("RECONCILE_LINE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReconcileLine() As Nullable(Of Short)
		<Column("DO_NOT_BILL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DoNotBill() As Nullable(Of Short)
		<Column("RECONCILE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsReconciled() As Nullable(Of Short)
		<Column("REVERSE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsReversed() As Nullable(Of Short)
		<Column("MAT_COMP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MaterialCompDate() As Nullable(Of Date)

        <ForeignKey("JobNumber, JobComponentNumber")>
        Public Overridable Property JobComponent As Database.Entities.JobComponent
        <ForeignKey("ARInvoiceNumber, ARSequenceNumber, ARType")>
        Public Overridable Property AccountReceivable As Database.Entities.AccountReceivable
        <ForeignKey("OrderNumber, LineNumber")>
        Public Overridable Property TVOrderLegacy As Database.Entities.TVOrderLegacy

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OrderNumber.ToString

        End Function

#End Region

	End Class

End Namespace
