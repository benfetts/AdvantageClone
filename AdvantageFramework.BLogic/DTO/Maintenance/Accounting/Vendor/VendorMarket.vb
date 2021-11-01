Namespace DTO.Maintenance.Accounting.Vendor

    Public Class VendorMarket
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VendorCode
            MarketCode
            Order
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property VendorCode() As String
        <Required>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Market")>
        Public Property MarketCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Order() As Integer

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.VendorCode = Nothing
            Me.MarketCode = Nothing
            Me.Order = 0

        End Sub
        Public Sub New(VendorMarket As AdvantageFramework.Database.Entities.VendorMarket)

            Me.ID = VendorMarket.ID
            Me.VendorCode = VendorMarket.VendorCode
            Me.MarketCode = VendorMarket.MarketCode
            Me.Order = VendorMarket.Order

        End Sub
        Public Sub SaveToEntity(ByRef VendorMarket As AdvantageFramework.Database.Entities.VendorMarket)

            VendorMarket.VendorCode = Me.VendorCode
            VendorMarket.MarketCode = Me.MarketCode
            VendorMarket.Order = Me.Order

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.VendorCode & " - " & Me.MarketCode

        End Function
        
#End Region

    End Class

End Namespace