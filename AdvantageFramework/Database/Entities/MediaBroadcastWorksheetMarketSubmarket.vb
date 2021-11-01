Namespace Database.Entities

    <Table("MEDIA_BROADCAST_WORKSHEET_MARKET_SUBMARKET")>
    Public Class MediaBroadcastWorksheetMarketSubmarket
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaBroadcastWorksheetMarketID
            MarketCode
            Order
            MediaBroadcastWorksheetMarket
            Market
            MediaBroadcastWorksheetMarketDetailSubmarketDemos
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_SUBMARKET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaBroadcastWorksheetMarketID() As Integer
        <Required>
        <MaxLength(10)>
        <Column("MARKET_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MarketCode() As String
        <Required>
        <Column("ORDER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Order() As Integer

        Public Overridable Property MediaBroadcastWorksheetMarket As Database.Entities.MediaBroadcastWorksheetMarket
        Public Overridable Property Market As Database.Entities.Market
        Public Overridable Property MediaBroadcastWorksheetMarketDetailSubmarketDemos As ICollection(Of Database.Entities.MediaBroadcastWorksheetMarketDetailSubmarketDemo)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.MediaBroadcastWorksheetMarketID.ToString & " - " & Me.MarketCode

        End Function

#End Region

    End Class

End Namespace
