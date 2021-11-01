Namespace DTO.Reporting

    Public Class WorksheetMarketVendor
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaBroadcastWorksheetMarketID
            MarketCode
            MarketDescription
            VendorCode
            VendorName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetMarketID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property MarketCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property MarketDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property VendorCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property VendorName() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaBroadcastWorksheetMarketID = 0
            Me.MarketCode = String.Empty
            Me.MarketDescription = String.Empty
            Me.VendorCode = String.Empty
            Me.VendorName = String.Empty

        End Sub
        Public Sub New(MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail)

            Me.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketID
            Me.MarketCode = MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MarketCode
            Me.MarketDescription = MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.Market.Description
            Me.VendorCode = MediaBroadcastWorksheetMarketDetail.VendorCode
            Me.VendorName = MediaBroadcastWorksheetMarketDetail.Vendor.Name

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.MediaBroadcastWorksheetMarketID & " - " & Me.MarketCode & " - " & Me.VendorCode

        End Function

#End Region

    End Class

End Namespace
