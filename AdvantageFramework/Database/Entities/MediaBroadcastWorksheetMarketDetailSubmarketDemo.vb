Namespace Database.Entities

    <Table("MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_SUBMARKET_DEMO")>
    Public Class MediaBroadcastWorksheetMarketDetailSubmarketDemo
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaBroadcastWorksheetMarketSubmarketID
            MediaBroadcastWorksheetMarketDetailID
            MediaDemographicID
            BookRating
            Rating
            BookImpressions
            Impressions
            MediaBroadcastWorksheetMarketSubmarket
            MediaBroadcastWorksheetMarketDetail
            MediaDemographic
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_SUBMARKET_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_SUBMARKET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaBroadcastWorksheetMarketSubmarketID() As Integer
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaBroadcastWorksheetMarketDetailID() As Integer
        <Required>
        <Column("MEDIA_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaDemographicID() As Integer
        <Required>
        <Column("BOOK_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property BookRating() As Decimal
        <Required>
        <Column("RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property Rating() As Decimal
        <Required>
        <Column("BOOK_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property BookImpressions() As Long
        <Required>
        <Column("IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Impressions() As Long

        Public Overridable Property MediaBroadcastWorksheetMarketSubmarket As Database.Entities.MediaBroadcastWorksheetMarketSubmarket
        Public Overridable Property MediaBroadcastWorksheetMarketDetail As Database.Entities.MediaBroadcastWorksheetMarketDetail
        Public Overridable Property MediaDemographic As Database.Entities.MediaDemographic

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.MediaBroadcastWorksheetMarketSubmarketID.ToString & " - " & Me.MediaBroadcastWorksheetMarketDetailID.ToString & " - " & Me.MediaDemographicID.ToString

        End Function

#End Region

    End Class

End Namespace
