Namespace Database.Views

    <Table("V_NEWS_DETAIL")>
    Public Class NewspaperDetail
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OrderNumber
            LineNumber
            RevisionNumber
            SequenceNumber
            InsertDate
            Source
            CloseDate
            MaterialCloseDate
            ExtendedCloseDate
            ExtendedMaterialDate
            Material
            Edition
            Section
            Headline
            SalesTaxCode
            CityTaxPercent
            CountyTaxPercent
            StateTaxPercent
            TaxApplyC
            TaxApplyLN
            TaxApplyLND
            TaxApplyNC
            TaxApplyR
            IsResaleTax
            CityTax
            CountyTax
            StateTax
            VendorTax
            TaxApplyNCD
            Rate
            FlatNet
            NetGross
            DiscountAmount
            FlatGross
            NetRate
            GrossRate
            CommissionPercent
            CommissionAmount
            MarkupPercent
            RebatePercent
            RebateAmount
            Size1
            Size2
            ColorCharge
            ColorDescription
            ColorAmount
            NetCharge
            NetChargeDescription
            AdditionalCharge
            AdditionalChargeDescription
            IsLineCancelled
            JobNumber
            JobComponentNumber
            DateToBill
            BillingUserCode
            ARInvoiceNumber
            ARType
            ARSequenceNumber
            LineTotal
            ExtendedNetAmount
            ExtendedGrossAmount
            ExtendedNetFlat
            ExtendedGrossFlat
            LinkDetailID
            IsActiveRevision

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
        <Column("INSERT_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InsertDate() As Nullable(Of Date)
        <Required>
        <MaxLength(3)>
        <Column("SOURCE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Source() As String
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
        <Column("MATERIAL", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Material() As String
        <MaxLength(30)>
        <Column("EDITION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Edition() As String
        <MaxLength(30)>
        <Column("SECTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Section() As String
        <MaxLength(60)>
        <Column("HEADLINE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Headline() As String
        <MaxLength(4)>
        <Column("TAX_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesTaxCode() As String
        <Column("TAX_CITY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CityTaxPercent() As Nullable(Of Decimal)
        <Column("TAX_COUNTY_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CountyTaxPercent() As Nullable(Of Decimal)
        <Column("TAX_STATE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StateTaxPercent() As Nullable(Of Decimal)
        <Column("TAXAPPLYC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxApplyC() As Nullable(Of Integer)
        <Column("TAXAPPLYLN")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxApplyLN() As Nullable(Of Integer)
        <Column("TAXAPPLYLND")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxApplyLND() As Nullable(Of Integer)
        <Column("TAXAPPLYNC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxApplyNC() As Nullable(Of Integer)
        <Column("TAXAPPLYR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxApplyR() As Nullable(Of Integer)
        <Column("TAX_RESALE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsResaleTax() As Nullable(Of Integer)
        <Column("CITY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CityTax() As Nullable(Of Decimal)
        <Column("COUNTY_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CountyTax() As Nullable(Of Decimal)
        <Column("STATE_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StateTax() As Nullable(Of Decimal)
        <Column("VENDOR_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorTax() As Nullable(Of Decimal)
        <Column("TAXAPPLYNCD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxApplyNCD() As Nullable(Of Integer)
        <Column("RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Rate() As Nullable(Of Decimal)
        <Column("FLAT_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FlatNet() As Nullable(Of Decimal)
        <Column("NET_GROSS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetGross() As Nullable(Of Short)
        <Column("DISCOUNT_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DiscountAmount() As Nullable(Of Decimal)
        <Column("FLAT_GROSS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FlatGross() As Nullable(Of Decimal)
        <Column("NET_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetRate() As Nullable(Of Decimal)
        <Column("GROSS_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GrossRate() As Nullable(Of Decimal)
        <Column("COMM_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CommissionPercent() As Nullable(Of Decimal)
        <Column("COMM_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CommissionAmount() As Nullable(Of Decimal)
        <Column("MARKUP_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarkupPercent() As Nullable(Of Decimal)
        <Column("REBATE_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RebatePercent() As Nullable(Of Decimal)
        <Column("REBATE_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RebateAmount() As Nullable(Of Decimal)
        <Column("SIZE1")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Size1() As Nullable(Of Decimal)
        <Column("SIZE2")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Size2() As Nullable(Of Decimal)
        <Column("COLORCHARGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ColorCharge() As Nullable(Of Decimal)
        <MaxLength(30)>
        <Column("COLORDESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ColorDescription() As String
        <Column("COLOR_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ColorAmount() As Nullable(Of Decimal)
        <Column("NETCHARGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetCharge() As Nullable(Of Decimal)
        <MaxLength(60)>
        <Column("NETCHARGE_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetChargeDescription() As String
        <Column("ADDL_CHARGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdditionalCharge() As Nullable(Of Decimal)
        <MaxLength(30)>
        <Column("ADDL_CHARGE_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdditionalChargeDescription() As String
        <Column("LINE_CANCELLED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsLineCancelled() As Nullable(Of Short)
        <Column("JOB_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobNumber() As Nullable(Of Integer)
        <Column("JOB_COMPONENT_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As Nullable(Of Short)
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
        <Column("LINE_TOTAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineTotal() As Nullable(Of Decimal)
        <Column("EXT_NET_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedNetAmount() As Nullable(Of Decimal)
        <Column("EXT_GROSS_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedGrossAmount() As Nullable(Of Decimal)
        <Column("EXT_NET_FLAT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedNetFlat() As Nullable(Of Decimal)
        <Column("EXT_GROSS_FLAT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExtendedGrossFlat() As Nullable(Of Decimal)
        <Column("LINK_DETID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LinkDetailID() As Nullable(Of Integer)
        <Column("ACTIVE_REV")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsActiveRevision() As Nullable(Of Integer)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OrderNumber.ToString

        End Function

#End Region

    End Class

End Namespace
