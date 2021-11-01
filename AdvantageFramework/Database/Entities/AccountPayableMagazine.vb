Namespace Database.Entities

    <Table("AP_MAGAZINE")>
    Public Class AccountPayableMagazine
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AccountPayableID
            AccountPayableSequenceNumber
            LineNumber
            OrderNumber
            OrderLineNumber
            RevisionNumber
            SequenceNumber
            OfficeCode
            NetGross
            CommissionPercent
            MarkupPercent
            RebatePercent
            SalesTaxCode
            StateTaxPercent
            CountyTaxPercent
            CityTaxPercent
            TaxApplyC
            TaxApplyLN
            TaxApplyLND
            TaxApplyNC
            TaxApplyNCD
            TaxApplyR
            IsResaleTax
            PostPeriodCode
            GLACode
            GLACodeDueFrom
            GLACodeDueTo
            GLTransaction
            GLSequenceNumber
            GLSequenceNumberDueFrom
            GLSequenceNumberDueTo
            NetAmount
            GrossAmount
            CommissionAmount
            RebateAmount
            VendorTax
            StateTax
            CountyTax
            CityTax
            BleedNetAmount
            BleedGrossAmount
            ColorNetAmount
            ColorGrossAmount
            PositionNetAmount
            PositionGrossAmount
            PremiumNetAmount
            PremiumGrossAmount
            NetCharges
            DiscountLN
            DiscountNC
            NetPlus
            GrossPlus
            DisbursedAmount
            LineTotal
            ModifyDelete
            IsDeleted
            CreatedBy
            CreateDate
            ModifiedBy
            ModifyDate
            AccountPayable
            SalesTax
            GeneralLedgerAccount
            GeneralLedgerAccount1
            GeneralLedgerAccount2
            GeneralLedger
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("AP_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AccountPayableID() As Integer
        <Key>
        <Required>
        <Column("AP_SEQ", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AccountPayableSequenceNumber() As Short
        <Key>
        <Required>
        <Column("LINE_NUMBER", Order:=2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LineNumber() As Short
        <Required>
        <Column("ORDER_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OrderNumber() As Integer
        <Required>
        <Column("ORDER_LINE_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OrderLineNumber() As Short
        <Required>
        <Column("REV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property RevisionNumber() As Short
        <Required>
        <Column("SEQ_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SequenceNumber() As Short
        <MaxLength(4)>
        <Column("OFFICE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.OfficeCode)>
        Public Property OfficeCode() As String
        <Column("NET_GROSS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetGross() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
        <Column("COMM_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CommissionPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
        <Column("MARKUP_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarkupPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
        <Column("REBATE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RebatePercent() As Nullable(Of Decimal)
        <MaxLength(4)>
        <Column("TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesTaxCode)>
        Public Property SalesTaxCode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 4)>
        <Column("TAX_STATE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StateTaxPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 4)>
        <Column("TAX_COUNTY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CountyTaxPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 4)>
        <Column("TAX_CITY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CityTaxPercent() As Nullable(Of Decimal)
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
        <Column("TAXAPPLYNCD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxApplyNCD() As Nullable(Of Short)
        <Column("TAXAPPLYR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxApplyR() As Nullable(Of Short)
        <Column("TAX_RESALE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsResaleTax() As Nullable(Of Short)
        <MaxLength(8)>
        <Column("POST_PERIOD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PostPeriodCode)>
        Public Property PostPeriodCode() As String
        <Required>
        <MaxLength(30)>
        <Column("GLACODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACode() As String
        <MaxLength(30)>
        <Column("GLACODE_DUE_FROM", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeDueFrom() As String
        <MaxLength(30)>
        <Column("GLACODE_DUE_TO", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACodeDueTo() As String
        <Column("GLEXACT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <ForeignKey("GeneralLedger")>
        Public Property GLTransaction() As Nullable(Of Integer)
        <Column("GLESEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumber() As Nullable(Of Short)
        <Column("GLESEQ_DUE_FROM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberDueFrom() As Nullable(Of Short)
        <Column("GLESEQ_DUE_TO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLSequenceNumberDueTo() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("NET_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("GROSS_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GrossAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CommissionAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RebateAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("VENDOR_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorTax() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("STATE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StateTax() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("COUNTY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CountyTax() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("CITY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CityTax() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("BLEED_NET_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BleedNetAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("BLEED_GROSS_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BleedGrossAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <Column("COLOR_NET_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ColorNetAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <Column("COLOR_GROSS_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ColorGrossAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("POSITION_NET_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PositionNetAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("POSITION_GROSS_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PositionGrossAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("PREMIUM_NET_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PremiumNetAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("PREMIUM_GROSS_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PremiumGrossAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("NETCHARGES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetCharges() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("DISCOUNT_LN")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DiscountLN() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("DISCOUNT_NC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DiscountNC() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <Column("NET_PLUS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetPlus() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <Column("GROSS_PLUS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GrossPlus() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("DISBURSED_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DisbursedAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("LINE_TOTAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineTotal() As Nullable(Of Decimal)
        <Column("MODIFY_DELETE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifyDelete() As Nullable(Of Short)
        <Column("DELETE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsDeleted() As Nullable(Of Short)
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

        <ForeignKey("SalesTaxCode")>
        Public Overridable Property SalesTax As Database.Entities.SalesTax
        <ForeignKey("GLACode")>
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("GLACodeDueFrom")>
        Public Overridable Property GeneralLedgerAccount1 As Database.Entities.GeneralLedgerAccount
        <ForeignKey("GLACodeDueTo")>
        Public Overridable Property GeneralLedgerAccount2 As Database.Entities.GeneralLedgerAccount
        Public Overridable Property GeneralLedger As Database.Entities.GeneralLedger

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AccountPayableID.ToString

        End Function
        Public Function Copy() As AdvantageFramework.Database.Entities.AccountPayableMagazine

            Dim EntityCopy As AdvantageFramework.Database.Entities.AccountPayableMagazine = Nothing

            EntityCopy = New AdvantageFramework.Database.Entities.AccountPayableMagazine

            With EntityCopy
                .AccountPayableID = Me.AccountPayableID
                .AccountPayableSequenceNumber = Me.AccountPayableSequenceNumber
                .LineNumber = Me.LineNumber
                .OrderNumber = Me.OrderNumber
                .OrderLineNumber = Me.OrderLineNumber
                .RevisionNumber = Me.RevisionNumber
                .SequenceNumber = Me.SequenceNumber
                .OfficeCode = Me.OfficeCode
                .NetGross = Me.NetGross
                .CommissionPercent = Me.CommissionPercent
                .MarkupPercent = Me.MarkupPercent
                .RebatePercent = Me.RebatePercent
                .SalesTaxCode = Me.SalesTaxCode
                .StateTaxPercent = Me.StateTaxPercent
                .CountyTaxPercent = Me.CountyTaxPercent
                .CityTaxPercent = Me.CityTaxPercent
                .TaxApplyC = Me.TaxApplyC
                .TaxApplyLN = Me.TaxApplyLN
                .TaxApplyLND = Me.TaxApplyLND
                .TaxApplyNC = Me.TaxApplyNC
                .TaxApplyNCD = Me.TaxApplyNCD
                .TaxApplyR = Me.TaxApplyR
                .IsResaleTax = Me.IsResaleTax
                .PostPeriodCode = Me.PostPeriodCode
                .GLACode = Me.GLACode
                .GLACodeDueFrom = Me.GLACodeDueFrom
                .GLACodeDueTo = Me.GLACodeDueTo
                .GLTransaction = Me.GLTransaction
                .GLSequenceNumber = Me.GLSequenceNumber
                .GLSequenceNumberDueFrom = Me.GLSequenceNumberDueFrom
                .GLSequenceNumberDueTo = Me.GLSequenceNumberDueTo
                .NetAmount = Me.NetAmount
                .GrossAmount = Me.GrossAmount
                .CommissionAmount = Me.CommissionAmount
                .RebateAmount = Me.RebateAmount
                .VendorTax = Me.VendorTax
                .StateTax = Me.StateTax
                .CountyTax = Me.CountyTax
                .CityTax = Me.CityTax
                .BleedNetAmount = Me.BleedNetAmount
                .BleedGrossAmount = Me.BleedGrossAmount
                .ColorNetAmount = Me.ColorNetAmount
                .ColorGrossAmount = Me.ColorGrossAmount
                .PositionNetAmount = Me.PositionNetAmount
                .PositionGrossAmount = Me.PositionGrossAmount
                .PremiumNetAmount = Me.PremiumNetAmount
                .PremiumGrossAmount = Me.PremiumGrossAmount
                .NetCharges = Me.NetCharges
                .DiscountLN = Me.DiscountLN
                .DiscountNC = Me.DiscountNC
                .NetPlus = Me.NetPlus
                .GrossPlus = Me.GrossPlus
                .DisbursedAmount = Me.DisbursedAmount
                .LineTotal = Me.LineTotal
                .ModifyDelete = Me.ModifyDelete
                .IsDeleted = Me.IsDeleted
                .CreatedBy = Me.CreatedBy
                .CreateDate = Me.CreateDate
                .ModifiedBy = Me.ModifiedBy
                .ModifyDate = Me.ModifyDate
            End With

            Copy = EntityCopy

        End Function

#End Region

    End Class

End Namespace
