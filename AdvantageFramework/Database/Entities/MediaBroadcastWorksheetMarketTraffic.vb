Namespace Database.Entities

    <Table("MEDIA_BROADCAST_WORKSHEET_MARKET_TRAFFIC")>
    Public Class MediaBroadcastWorksheetMarketTraffic
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaBroadcastWorksheetMarketID
            MediaTrafficID
            MediaBroadcastWorksheetMarket
            MediaTraffic
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_TRAFFIC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaBroadcastWorksheetMarketID() As Integer
        <Required>
        <Column("MEDIA_TRAFFIC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaTrafficID() As Integer

        Public Overridable Property MediaBroadcastWorksheetMarket As Database.Entities.MediaBroadcastWorksheetMarket
        Public Overridable Property MediaTraffic As Database.Entities.MediaTraffic

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
