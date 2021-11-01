Namespace Database.Entities

    <Table("MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL")>
    Public Class MediaBroadcastWorksheetMarketStagingDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaBroadcastWorksheetMarketDetailID
            MediaBroadcastWorksheetMarketID
            LineNumber
            MakegoodNumber
            MakegoodDate
            MakegoodSpots
            RevisionNumber
            CableNetworkStationCode
            CableNetworkNielsenTVStationCode
            Program
            DaypartID
            Length
            Days
            Sunday
            Monday
            Tuesday
            Wednesday
            Thursday
            Friday
            Saturday
            StartTime
            EndTime
            StartHour
            EndHour
            Comments
            Bookend
            DefaultRate
            IsOriginal
            MadegoodNumber
            PrimaryRating
            PrimaryCPP
            PrimaryCPM
            PrimaryImpressions
            SecondaryRating
            SecondaryCPP
            SecondaryCPM
            SecondaryImpressions
            CreatedByUserCode
            CreatedDate
            ModifiedByUserCode
            ModifiedDate
            ValueAdded
            IsSubmitted
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaBroadcastWorksheetMarketDetailID() As Integer
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaBroadcastWorksheetMarketID() As Integer
        <Required>
        <Column("LINE_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LineNumber() As Integer
        <Required>
        <Column("MAKEGOOD_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MakegoodNumber() As Integer
        <Required>
        <Column("MAKEGOOD_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MakegoodDate() As Date
        <Required>
        <Column("MAKEGOOD_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MakegoodSpots() As Integer
        <Required>
        <Column("REVISION_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property RevisionNumber() As Integer
        <MaxLength(10)>
        <Column("CABLE_NETWORK_STATION_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CableNetworkStationCode() As String
        <Column("CABLE_NETWORK_NIELSEN_TV_STATION_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CableNetworkNielsenTVStationCode() As Nullable(Of Integer)
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(100)>
        <Column("PROGRAM", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Program() As String
        <Column("DAY_PART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DaypartID() As Nullable(Of Integer)
        <Required>
        <Column("LENGTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Length() As Short
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(100)>
        <Column("DAYS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Days() As String
        <Required>
        <Column("SUNDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Sunday() As Boolean
        <Required>
        <Column("MONDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Monday() As Boolean
        <Required>
        <Column("TUESDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Tuesday() As Boolean
        <Required>
        <Column("WEDNESDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Wednesday() As Boolean
        <Required>
        <Column("THURSDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Thursday() As Boolean
        <Required>
        <Column("FRIDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Friday() As Boolean
        <Required>
        <Column("SATURDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Saturday() As Boolean
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(100)>
        <Column("START_TIME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartTime() As String
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(100)>
        <Column("END_TIME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EndTime() As String
        <Required>
        <Column("START_HOUR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property StartHour() As Short
        <Required>
        <Column("END_HOUR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EndHour() As Short
        <Required(AllowEmptyStrings:=True)>
        <Column("COMMENTS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Comments() As String
        <Required>
        <Column("BOOKEND")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Bookend() As Boolean
        <Required>
        <Column("DEFAULT_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(11, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property DefaultRate() As Decimal
        <Column("IS_ORIGINAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsOriginal() As Boolean
        <Required>
        <Column("MADEGOOD_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MadegoodNumber() As Integer
        <Required>
        <Column("PRIMARY_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property PrimaryRating() As Decimal
        <Required>
        <Column("PRIMARY_CPP")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(19, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property PrimaryCPP() As Decimal
        <Required>
        <Column("PRIMARY_CPM")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(19, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property PrimaryCPM() As Decimal
        <Required>
        <Column("PRIMARY_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property PrimaryImpressions() As Long
        <Required>
        <Column("SECONDARY_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property SecondaryRating() As Decimal
        <Required>
        <Column("SECONDARY_CPP")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(19, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property SecondaryCPP() As Decimal
        <Required>
        <Column("SECONDARY_CPM")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(19, 2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property SecondaryCPM() As Decimal
        <Required>
        <Column("SECONDARY_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property SecondaryImpressions() As Long
        <Required>
        <MaxLength(100)>
        <Column("USER_CREATED", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedByUserCode() As String
        <Required>
        <Column("CREATED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedDate() As Date
        <MaxLength(100)>
        <Column("USER_MODIFIED", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedByUserCode() As String
        <Column("MODIFIED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As Nullable(Of Date)
        <Required>
        <Column("VALUE_ADDED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ValueAdded() As Boolean
        <Required>
        <Column("IS_SUBMITTED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsSubmitted() As Boolean

        <ForeignKey("MediaBroadcastWorksheetMarketDetailID")>
        Public Overridable Property MediaBroadcastWorksheetMarketDetail As Database.Entities.MediaBroadcastWorksheetMarketDetail

        Public Overridable Property MediaBroadcastWorksheetMarketStagingDetailDates As ICollection(Of Database.Entities.MediaBroadcastWorksheetMarketStagingDetailDate)

#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaBroadcastWorksheetMarketStagingDetailDates = New HashSet(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetailDate)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
