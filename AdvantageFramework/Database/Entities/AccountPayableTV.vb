Namespace Database.Entities

	<Table("AP_TV")>
	Public Class AccountPayableTV
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			AccountPayableID
			AccountPayableSequenceNumber
			OrderNumber
			BroadcastMonth
			BroadcastYear
			RevisionNumber
			OfficeCode
			PostPeriodCode
			LinkID
			LineNumber
			SalesTaxCode
			GLACode
			CityTax
			CommissionAmount
			CountyTax
			IsDeleted
			DiscountAmount
			ExtendedNetAmount
			GLTransaction
			GLSequenceNumber
			LineTotal
			NetCharges
			RebateAmount
			StateTax
			CityTaxPercent
			CountyTaxPercent
			StateTaxPercent
			IsResaleTax
			VendorTax
			Voucher
			TaxApplyC
			TaxApplyLN
			TaxApplyLND
			TaxApplyNC
			TaxApplyR
			ReconcileFlag
			GLACodeDueFrom
			GLACodeDueTo
			GLSequenceNumberDueFrom
			GLSequenceNumberDueTo
			ModifyDelete
            TotalSpots
            GrossRate
            NetRate
            RewriteFlag
			OrderLineNumber
			OrderLineDate
			CommissionPercent
			RebatePercent
			NetGross
			SequenceNumber
			MarkupPercent
			CreatedBy
			CreateDate
			ModifiedBy
			ModifyDate
			Length
            DaypartID
            DaysOfWeek
            StartTime
            EndTime
            RateDetail
            LineStartDate
            LineEndDate
            PlanCode
            PackageCode
            Comment
            CurrencyCode
            CurrencyCodeHome
			CurrencyRate
			SalesTax
			GeneralLedgerAccount
			AccountPayable
			GeneralLedger
            Daypart

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("AP_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountPayableID() As Integer
		<Key>
		<Required>
        <Column("AP_SEQ", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountPayableSequenceNumber() As Short
        <Key>
        <Required>
        <Column("ORDER_NBR", Order:=2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property OrderNumber() As Integer
		<MaxLength(3)>
		<Column("BRDCAST_MONTH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BroadcastMonth() As String
		<Column("BRDCAST_YEAR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BroadcastYear() As Nullable(Of Short)
		<Required>
		<Column("REV_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RevisionNumber() As Short
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OfficeCode() As String
		<MaxLength(8)>
		<Column("POST_PERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PostPeriodCode() As String
		<Column("LINK_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LinkID() As Nullable(Of Integer)
		<Key>
		<Required>
        <Column("LINE_NUMBER", Order:=3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LineNumber() As Short
		<MaxLength(4)>
		<Column("TAX_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SalesTaxCode() As String
		<MaxLength(30)>
		<Column("GLACODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <ForeignKey("GeneralLedgerAccount")>
        Public Property GLACode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("CITY_TAX")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CityTax() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CommissionAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("COUNTY_TAX")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CountyTax() As Nullable(Of Decimal)
		<Column("DELETE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsDeleted() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("DISC_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DiscountAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("EXT_NET_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExtendedNetAmount() As Nullable(Of Decimal)
        <Column("GLEXACT")>
        <ForeignKey("GeneralLedger")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLTransaction() As Nullable(Of Integer)
		<Column("GLESEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumber() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("LINE_TOTAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineTotal() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("NETCHARGES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetCharges() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RebateAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("STATE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StateTax() As Nullable(Of Decimal)
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
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("VENDOR_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorTax() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 0)>
        <Column("VOUCHER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Voucher() As Nullable(Of Decimal)
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
		<Column("RECONCILE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReconcileFlag() As Nullable(Of Short)
		<MaxLength(30)>
		<Column("GLACODE_DUE_FROM", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeDueFrom() As String
		<MaxLength(30)>
		<Column("GLACODE_DUE_TO", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeDueTo() As String
		<Column("GLESEQ_DUE_FROM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberDueFrom() As Nullable(Of Short)
		<Column("GLESEQ_DUE_TO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberDueTo() As Nullable(Of Short)
		<Column("MODIFY_DELETE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifyDelete() As Nullable(Of Short)
		<Column("TOTAL_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalSpots() As Nullable(Of Integer)
        <Column("GROSS_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        Public Property GrossRate() As Nullable(Of Decimal)
        <Column("NET_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        Public Property NetRate() As Nullable(Of Decimal)
        <Column("REWRITE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RewriteFlag() As Nullable(Of Short)
		<Column("ORDER_LINE_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderLineNumber() As Nullable(Of Short)
		<Column("ORDER_LINE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderLineDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
        <Column("COMM_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CommissionPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
        <Column("REBATE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RebatePercent() As Nullable(Of Decimal)
		<Column("NET_GROSS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NetGross() As Nullable(Of Short)
		<Column("SEQ_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SequenceNumber() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
        <Column("MARKUP_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MarkupPercent() As Nullable(Of Decimal)
		<MaxLength(100)>
		<Column("CREATED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedBy() As String
		<Column("CREATE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreateDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("MODIFIED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedBy() As String
		<Column("MODIFY_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifyDate() As Nullable(Of Date)
		<Column("LENGTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Length() As Nullable(Of Integer)
        <Column("DAY_PART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DaypartID() As Nullable(Of Integer)
        <Column("DAYS_OF_WEEK")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DaysOfWeek() As String
        <Column("START_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartTime() As TimeSpan?
        <Column("END_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EndTime() As TimeSpan?
        <Column("RATE_DETAIL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RateDetail() As String
        <Column("LINE_START_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineStartDate() As Date?
        <Column("LINE_END_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineEndDate() As Date?
        <Column("PLAN_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PlanCode() As String
        <Column("PACKAGE_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PackageCode() As String
        <Column("COMMENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comment() As String

        <ForeignKey("SalesTaxCode")>
        Public Overridable Property SalesTax As Database.Entities.SalesTax
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        Public Overridable Property GeneralLedger As Database.Entities.GeneralLedger
        Public Overridable Property Daypart As Database.Entities.Daypart

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AccountPayableID

        End Function
        Public Function Copy() As AdvantageFramework.Database.Entities.AccountPayableTV

            Dim EntityCopy As AdvantageFramework.Database.Entities.AccountPayableTV = Nothing

            EntityCopy = New AdvantageFramework.Database.Entities.AccountPayableTV

            With EntityCopy
                .AccountPayableID = Me.AccountPayableID
                .AccountPayableSequenceNumber = Me.AccountPayableSequenceNumber
                .OrderNumber = Me.OrderNumber
                .BroadcastMonth = Me.BroadcastMonth
                .BroadcastYear = Me.BroadcastYear
                .RevisionNumber = Me.RevisionNumber
                .OfficeCode = Me.OfficeCode
                .PostPeriodCode = Me.PostPeriodCode
                .LinkID = Me.LinkID
                .LineNumber = Me.LineNumber
                .SalesTaxCode = Me.SalesTaxCode
                .GLACode = Me.GLACode
                .CityTax = Me.CityTax
                .CommissionAmount = Me.CommissionAmount
                .CountyTax = Me.CountyTax
                .IsDeleted = Me.IsDeleted
                .DiscountAmount = Me.DiscountAmount
                .ExtendedNetAmount = Me.ExtendedNetAmount
                .GLTransaction = Me.GLTransaction
                .GLSequenceNumber = Me.GLSequenceNumber
                .LineTotal = Me.LineTotal
                .NetCharges = Me.NetCharges
                .RebateAmount = Me.RebateAmount
                .StateTax = Me.StateTax
                .CityTaxPercent = Me.CityTaxPercent
                .CountyTaxPercent = Me.CountyTaxPercent
                .StateTaxPercent = Me.StateTaxPercent
                .IsResaleTax = Me.IsResaleTax
                .VendorTax = Me.VendorTax
                .Voucher = Me.Voucher
                .TaxApplyC = Me.TaxApplyC
                .TaxApplyLN = Me.TaxApplyLN
                .TaxApplyLND = Me.TaxApplyLND
                .TaxApplyNC = Me.TaxApplyNC
                .TaxApplyR = Me.TaxApplyR
                .ReconcileFlag = Me.ReconcileFlag
                .GLACodeDueFrom = Me.GLACodeDueFrom
                .GLACodeDueTo = Me.GLACodeDueTo
                .GLSequenceNumberDueFrom = Me.GLSequenceNumberDueFrom
                .GLSequenceNumberDueTo = Me.GLSequenceNumberDueTo
                .ModifyDelete = Me.ModifyDelete
                .TotalSpots = Me.TotalSpots
                .GrossRate = Me.GrossRate
                .NetRate = Me.NetRate
                .RewriteFlag = Me.RewriteFlag
                .OrderLineNumber = Me.OrderLineNumber
                .OrderLineDate = Me.OrderLineDate
                .CommissionPercent = Me.CommissionPercent
                .RebatePercent = Me.RebatePercent
                .NetGross = Me.NetGross
                .SequenceNumber = Me.SequenceNumber
                .MarkupPercent = Me.MarkupPercent
                .CreatedBy = Me.CreatedBy
                .CreateDate = Me.CreateDate
                .ModifiedBy = Me.ModifiedBy
                .ModifyDate = Me.ModifyDate
            End With

            Copy = EntityCopy

        End Function
        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace
