Namespace Database.Entities

    <Table("MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_DATE")>
    Public Class MediaBroadcastWorksheetMarketStagingDetailDate
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaBroadcastWorksheetMarketDetailStagingID
            [Date]
            Spots
            IsHiatus
            Rate
            AllowSpotsToBeEntered
            MakegoodSpots
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_DATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaBroadcastWorksheetMarketStagingDetailID() As Integer
        <Required>
        <Column("DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property [Date]() As Date
        <Required>
        <Column("SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Spots() As Integer
        <Required>
        <Column("IS_HIATUS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsHiatus() As Boolean
        <Required>
        <Column("RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n4")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(11, 4)>
        Public Property Rate() As Decimal
        <Required>
        <Column("ALLOW_SPOTS_TO_BE_ENTERED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AllowSpotsToBeEntered() As Boolean
        <Required>
        <Column("MAKEGOOD_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MakegoodSpots() As Integer

        <ForeignKey("MediaBroadcastWorksheetMarketStagingDetailID")>
        Public Overridable Property MediaBroadcastWorksheetMarketStagingDetail As Database.Entities.MediaBroadcastWorksheetMarketStagingDetail

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
