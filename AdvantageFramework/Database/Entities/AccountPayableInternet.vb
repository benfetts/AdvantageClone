Namespace Database.Entities

    <Table("AP_INTERNET")>
    Public Class AccountPayableInternet
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AccountPayableID
            AccountPayableSequenceNumber
            LineNumber
            InternetOrderNumber
            InternetDetailLineNumber
            InternetDetailRevisionNumber
            InternetDetailSequenceNumber
            OfficeCode
            NetGross
            Quantity
            NetRate
            GrossRate
            NetCharges
            NetAmount
            CommissionPercent
            RebatePercent
            SalesTaxCode
            StateTaxPercent
            CountyTaxPercent
            CityTaxPercent
            TaxApplyC
            TaxApplyLN
            TaxApplyLND
            TaxApplyNC
            TaxApplyR
            IsResaleTax
            GLACode
            GLACodeDueFrom
            GLACodeDueTo
            GLTransaction
            GLSequenceNumber
            GLSequenceNumberDueFrom
            GLSequenceNumberDueTo
            CommissionAmount
            VendorTax
            StateTax
            CountyTax
            CityTax
            LineTotal
            PostPeriodCode
            IsDeleted
            RebateAmount
            DiscountAmount
            ModifyDelete
            MarkupPercent
            Impressions
            Rate
            CreatedBy
            CreateDate
            ModifiedBy
            ModifyDate
            CurrencyCode
            CurrencyCodeHome
            CurrencyRate
            AccountPayable
            GeneralLedgerAccount
            Office
            InternetOrderDetail
            GeneralLedger

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
        <Column("LINE_NUMBER", Order:=2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineNumber() As Short
        <Required>
        <Column("ORDER_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetOrderNumber() As Integer
        <Required>
        <Column("ORDER_LINE_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetDetailLineNumber() As Short
        <Required>
        <Column("REV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetDetailRevisionNumber() As Short
        <Required>
        <Column("SEQ_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetDetailSequenceNumber() As Short
        <MaxLength(4)>
        <Column("OFFICE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <Column("NET_GROSS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetGross() As Nullable(Of Short)
        <Column("QUANTITY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quantity() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <Column("NET_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetRate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <Column("GROSS_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GrossRate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("NETCHARGES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetCharges() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("NET_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
        <Column("COMM_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CommissionPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
        <Column("REBATE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RebatePercent() As Nullable(Of Decimal)
        <MaxLength(4)>
        <Column("TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
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
        <Column("TAXAPPLYR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxApplyR() As Nullable(Of Short)
        <Column("TAX_RESALE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsResaleTax() As Nullable(Of Short)
        <Required>
        <MaxLength(30)>
        <Column("GLACODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        <ForeignKey("GeneralLedgerAccount")>
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
        <ForeignKey("GeneralLedger")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
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
        <Column("COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CommissionAmount() As Nullable(Of Decimal)
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
        <Column("LINE_TOTAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineTotal() As Nullable(Of Decimal)
        <MaxLength(8)>
        <Column("POST_PERIOD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PostPeriodCode() As String
        <Column("DELETE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsDeleted() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RebateAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("DISCOUNT_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DiscountAmount() As Nullable(Of Decimal)
        <Column("MODIFY_DELETE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifyDelete() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
        <Column("MARKUP_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarkupPercent() As Nullable(Of Decimal)
        <Column("IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Impressions() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <Column("RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Rate() As Nullable(Of Decimal)
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

        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        Public Overridable Property Office As Database.Entities.Office
        <ForeignKey("InternetOrderNumber, InternetDetailLineNumber, InternetDetailRevisionNumber, InternetDetailSequenceNumber")>
        Public Overridable Property InternetOrderDetail As Database.Entities.InternetOrderDetail
        Public Overridable Property GeneralLedger As Database.Entities.GeneralLedger

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AccountPayableID.ToString

        End Function
        Public Function Copy() As AdvantageFramework.Database.Entities.AccountPayableInternet

            Dim EntityCopy As AdvantageFramework.Database.Entities.AccountPayableInternet = Nothing

            EntityCopy = New AdvantageFramework.Database.Entities.AccountPayableInternet

            With EntityCopy
                .AccountPayableID = Me.AccountPayableID
                .AccountPayableSequenceNumber = Me.AccountPayableSequenceNumber
                .LineNumber = Me.LineNumber
                .InternetOrderNumber = Me.InternetOrderNumber
                .InternetDetailLineNumber = Me.InternetDetailLineNumber
                .InternetDetailRevisionNumber = Me.InternetDetailRevisionNumber
                .InternetDetailSequenceNumber = Me.InternetDetailSequenceNumber
                .OfficeCode = Me.OfficeCode
                .NetGross = Me.NetGross
                .Quantity = Me.Quantity
                .NetRate = Me.NetRate
                .GrossRate = Me.GrossRate
                .NetCharges = Me.NetCharges
                .NetAmount = Me.NetAmount
                .CommissionPercent = Me.CommissionPercent
                .RebatePercent = Me.RebatePercent
                .SalesTaxCode = Me.SalesTaxCode
                .StateTaxPercent = Me.StateTaxPercent
                .CountyTaxPercent = Me.CountyTaxPercent
                .CityTaxPercent = Me.CityTaxPercent
                .TaxApplyC = Me.TaxApplyC
                .TaxApplyLN = Me.TaxApplyLN
                .TaxApplyLND = Me.TaxApplyLND
                .TaxApplyNC = Me.TaxApplyNC
                .TaxApplyR = Me.TaxApplyR
                .IsResaleTax = Me.IsResaleTax
                .GLACode = Me.GLACode
                .GLACodeDueFrom = Me.GLACodeDueFrom
                .GLACodeDueTo = Me.GLACodeDueTo
                .GLTransaction = Me.GLTransaction
                .GLSequenceNumber = Me.GLSequenceNumber
                .GLSequenceNumberDueFrom = Me.GLSequenceNumberDueFrom
                .GLSequenceNumberDueTo = Me.GLSequenceNumberDueTo
                .CommissionAmount = Me.CommissionAmount
                .VendorTax = Me.VendorTax
                .StateTax = Me.StateTax
                .CountyTax = Me.CountyTax
                .CityTax = Me.CityTax
                .LineTotal = Me.LineTotal
                .PostPeriodCode = Me.PostPeriodCode
                .IsDeleted = Me.IsDeleted
                .RebateAmount = Me.RebateAmount
                .DiscountAmount = Me.DiscountAmount
                .ModifyDelete = Me.ModifyDelete
                .MarkupPercent = Me.MarkupPercent
                .Impressions = Me.Impressions
                .Rate = Me.Rate
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
