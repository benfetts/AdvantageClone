Namespace Database.Entities

    <Table("MEDIA_RFP_VENDOR_MARKET_XREF")>
    Public Class MediaRFPVendorMarketCrossReference
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VendorCode
            VendorMarketCode
            MarketCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_RFP_VENDOR_MARKET_XREF_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(6)>
        <Column("VN_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property VendorCode() As String
        <Required>
        <MaxLength(20)>
        <Column("VN_MARKET_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property VendorMarketCode() As String
        <Required>
        <MaxLength(10)>
        <Column("MARKET_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MarketCode() As String

        <ForeignKey("VendorCode")>
        Public Overridable Property Vendor As Database.Entities.Vendor
        <ForeignKey("MarketCode")>
        Public Overridable Property Market As Database.Entities.Market

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
