Namespace Database.Entities

	<Table("TV_HEADER")>
	Public Class TVOrderLegacy
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			OrderNumber
			RevisionNumber
			LinkID
			ClientCode
			DivisionCode
			ProductCode
			OrderDescription
			OrderDate
			VendorCode
			VendorRepCode1
			VendorRepCode2
			CampaignID
			CampaignLineNumber
			MediaType
			BillingCoopCode
			BillTypeFlag
			NetGross
			CommissionPercent
			MarkupPercent
			RebatePercent
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
			MarketCode
			FlightFrom
			FlightTo
			BroadcastYear1
			BroadcastYear2
			FirstMonthYear1
			LastMonthYear1
			FirstMonthYear2
			LastMonthYear2
			Status
			OrderProcessControl
			IsStation
			OrderRep1
			OrderRep2
			Service
			Buyer
			ClientPO
			HouseComment
			OrderComment
			CreateDate
			UserCode
			CancelledBy
			CancelledDate
			IsDeleted
			DeleteDate
			DeletedBy
			IsReconciled
			OfficeCode
			FiscalPeriodCode
			Campaign
			Market
			Product
			SalesClass
			SalesTax
			TVOrderDetailLegacies
			Vendor

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
        <Column("REV_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RevisionNumber() As Short
		<Column("LINK_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LinkID() As Nullable(Of Integer)
		<Required>
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientCode() As String
		<Required>
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisionCode() As String
		<Required>
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCode() As String
		<MaxLength(40)>
		<Column("ORDER_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderDescription() As String
		<Column("ORDER_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderDate() As Nullable(Of Date)
		<MaxLength(6)>
		<Column("VN_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorCode() As String
		<MaxLength(4)>
		<Column("VR_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorRepCode1() As String
		<MaxLength(4)>
		<Column("VR_CODE2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorRepCode2() As String
		<Column("CMP_IDENTIFIER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignID() As Nullable(Of Integer)
		<Column("CMP_LINE_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignLineNumber() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("MEDIA_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaType() As String
		<MaxLength(6)>
		<Column("BILL_COOP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingCoopCode() As String
		<Column("BILL_TYPE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillTypeFlag() As Nullable(Of Short)
		<Column("NET_GROSS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NetGross() As Nullable(Of Short)
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
		<Column("TAXAPPLYLND")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxApplyLND() As Nullable(Of Short)
		<Column("TAXAPPLYNC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxApplyNC() As Nullable(Of Short)
		<Column("TAXAPPLYR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaxApplyR() As Nullable(Of Short)
		<MaxLength(10)>
		<Column("MARKET_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MarketCode() As String
		<Column("FLIGHT_FROM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FlightFrom() As Nullable(Of Date)
		<Column("FLIGHT_TO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FlightTo() As Nullable(Of Date)
		<Column("BRD_YEAR1")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BroadcastYear1() As Nullable(Of Short)
		<Column("BRD_YEAR2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BroadcastYear2() As Nullable(Of Short)
		<Column("FIRST_MTH_YR1")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FirstMonthYear1() As Nullable(Of Short)
		<Column("LAST_MTH_YR1")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastMonthYear1() As Nullable(Of Short)
		<Column("FIRST_MTH_YR2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FirstMonthYear2() As Nullable(Of Short)
		<Column("LAST_MTH_YR2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastMonthYear2() As Nullable(Of Short)
		<MaxLength(3)>
		<Column("STATUS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Status() As String
		<Column("ORD_PROCESS_CONTRL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderProcessControl() As Nullable(Of Short)
		<Column("STATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsStation() As Nullable(Of Short)
		<Column("REP1")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderRep1() As Nullable(Of Short)
		<Column("REP2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderRep2() As Nullable(Of Short)
		<MaxLength(1)>
		<Column("SERVICE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Service() As String
		<MaxLength(40)>
		<Column("BUYER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Buyer() As String
		<MaxLength(25)>
		<Column("CLIENT_PO", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientPO() As String
		<Column("HOUSE_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property HouseComment() As String
		<Column("ORDER_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderComment() As String
		<Column("CREATE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreateDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("USER_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<MaxLength(100)>
		<Column("CANCELLED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CancelledBy() As String
		<Column("CANCELLED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CancelledDate() As Nullable(Of Date)
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
		<Required>
		<Column("RECONCILE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsReconciled() As Short
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OfficeCode() As String
		<MaxLength(6)>
		<Column("FISCAL_PERIOD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FiscalPeriodCode() As String

        Public Overridable Property Campaign As Database.Entities.Campaign
        Public Overridable Property Market As Database.Entities.Market
        <ForeignKey("ClientCode, DivisionCode, ProductCode")>
        Public Overridable Property Product As Database.Entities.Product
        <ForeignKey("MediaType")>
        Public Overridable Property SalesClass As Database.Entities.SalesClass
        <ForeignKey("SalesTaxCode")>
        Public Overridable Property SalesTax As Database.Entities.SalesTax
        Public Overridable Property TVOrderDetailLegacies As ICollection(Of Database.Entities.TVOrderDetailLegacy)
        Public Overridable Property Vendor As Database.Entities.Vendor

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OrderNumber.ToString

        End Function

#End Region

	End Class

End Namespace
