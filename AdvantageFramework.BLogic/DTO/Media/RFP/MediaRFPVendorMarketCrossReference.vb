Namespace DTO.Media.RFP

    Public Class MediaRFPVendorMarketCrossReference
        Inherits AdvantageFramework.DTO.BaseClass

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

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        <MaxLength(6)>
        Public Property VendorCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        <MaxLength(20)>
        Public Property VendorMarketCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.MarketCode)>
        Public Property MarketCode As String

#End Region

#Region " Methods "

        Public Sub New()


        End Sub
        Public Sub New(MediaRFPVendorMarketCrossReference As AdvantageFramework.Database.Entities.MediaRFPVendorMarketCrossReference)

            Me.ID = MediaRFPVendorMarketCrossReference.ID
            Me.VendorCode = MediaRFPVendorMarketCrossReference.VendorCode
            Me.VendorMarketCode = MediaRFPVendorMarketCrossReference.VendorMarketCode
            Me.MarketCode = MediaRFPVendorMarketCrossReference.MarketCode

        End Sub
        Public Sub SaveToEntity(ByRef MediaRFPVendorMarketCrossReference As AdvantageFramework.Database.Entities.MediaRFPVendorMarketCrossReference)

            MediaRFPVendorMarketCrossReference.ID = Me.ID
            MediaRFPVendorMarketCrossReference.VendorCode = Me.VendorCode
            MediaRFPVendorMarketCrossReference.VendorMarketCode = Me.VendorMarketCode
            MediaRFPVendorMarketCrossReference.MarketCode = Me.MarketCode

        End Sub

#End Region

    End Class

End Namespace
