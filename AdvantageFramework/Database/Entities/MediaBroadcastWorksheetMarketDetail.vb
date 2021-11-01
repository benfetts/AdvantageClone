Namespace Database.Entities

    <Table("MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL")>
    Public Class MediaBroadcastWorksheetMarketDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaBroadcastWorksheetMarketID
            OnHold
            LineNumber
            MakegoodNumber
            MakegoodDate
            MakegoodSpots
            MadegoodNumber
            RevisionNumber
            VendorCode
            CableNetworkStationCode
            CableNetworkNielsenTVStationCode
            BookProgram
            Program
            DaypartID
            Product
            Piggyback
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
            ValueAdded
            DefaultRate
            OrderComments
            BookPrimaryRating
            PrimaryRating
            BookPrimaryShare
            PrimaryShare
            PrimaryHPUT
            PrimaryCPP
            PrimaryGRP
            PrimaryReach
            PrimaryFrequency
            BookPrimaryImpressions
            PrimaryImpressions
            PrimaryGrossImpressions
            PrimaryUniverse
            PrimaryCumeImpressions
            BookPrimaryAQHRating
            PrimaryAQHRating
            BookPrimaryAQH
            PrimaryAQH
            PrimaryCumeRating
            PrimaryCume
            PrimaryCPM
            BookSecondaryRating
            SecondaryRating
            BookSecondaryShare
            SecondaryShare
            SecondaryHPUT
            SecondaryCPP
            SecondaryGRP
            SecondaryReach
            SecondaryFrequency
            BookSecondaryImpressions
            SecondaryImpressions
            SecondaryGrossImpressions
            SecondaryUniverse
            SecondaryCumeImpressions
            BookSecondaryAQHRating
            SecondaryAQHRating
            BookSecondaryAQH
            SecondaryAQH
            SecondaryCumeRating
            SecondaryCume
            SecondaryCPM
            CreatedByUserCode
            CreatedDate
            ModifiedByUserCode
            ModifiedDate
            OverridePost
            PrimaryVendorSubmittedRating
            PrimaryVendorSubmittedShare
            PrimaryVendorSubmittedImpressions
            SecondaryVendorSubmittedRating
            SecondaryVendorSubmittedShare
            SecondaryVendorSubmittedImpressions
            OverridePostImpressions
            OverridePostAQH
            MediaBroadcastWorksheetMarket
            Vendor
            Daypart
            CableNetworkStation
            MediaBroadcastWorksheetMarketDetailDates
            MediaBroadcastWorksheetMarketDetailSubmarketDemos
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaBroadcastWorksheetMarketID() As Integer
        <Required>
        <Column("ON_HOLD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OnHold() As Boolean
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
        <Column("MADEGOOD_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MadegoodNumber() As Integer
        <Required>
        <Column("REVISION_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property RevisionNumber() As Integer
        <MaxLength(6)>
        <Column("VN_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
        <MaxLength(10)>
        <Column("CABLE_NETWORK_STATION_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CableNetworkStationCode() As String
        <Column("CABLE_NETWORK_NIELSEN_TV_STATION_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CableNetworkNielsenTVStationCode() As Nullable(Of Integer)
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(100)>
        <Column("BOOK_PROGRAM", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BookProgram() As String
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(100)>
        <Column("PROGRAM", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Program() As String
        <Column("DAY_PART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DaypartID() As Nullable(Of Integer)
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(100)>
        <Column("PRODUCT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Product() As String
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(100)>
        <Column("PIGGYBACK", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Piggyback() As String
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
        <Column("VALUE_ADDED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ValueAdded() As Boolean
        <Column("DEFAULT_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(16, 4)>
        Public Property DefaultRate() As Decimal
        <Required(AllowEmptyStrings:=True)>
        <Column("ORDER_COMMENTS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OrderComments() As String

        <Required>
        <Column("BOOK_PRIMARY_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property BookPrimaryRating() As Decimal
        <Required>
        <Column("PRIMARY_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property PrimaryRating() As Decimal
        <Required>
        <Column("BOOK_PRIMARY_SHARE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property BookPrimaryShare() As Decimal
        <Required>
        <Column("PRIMARY_SHARE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property PrimaryShare() As Decimal
        <Required>
        <Column("PRIMARY_HPUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property PrimaryHPUT() As Decimal
        <Required>
        <Column("PRIMARY_CPP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(19, 2)>
        Public Property PrimaryCPP() As Decimal
        <Required>
        <Column("PRIMARY_GRP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property PrimaryGRP() As Decimal
        <Required>
        <Column("PRIMARY_REACH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 3)>
        Public Property PrimaryReach() As Decimal
        <Required>
        <Column("PRIMARY_FREQUENCY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property PrimaryFrequency() As Decimal
        <Required>
        <Column("BOOK_PRIMARY_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BookPrimaryImpressions() As Long
        <Required>
        <Column("PRIMARY_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryImpressions() As Long
        <Required>
        <Column("PRIMARY_GROSS_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryGrossImpressions() As Long
        <Required>
        <Column("PRIMARY_UNIVERSE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryUniverse() As Long
        <Required>
        <Column("PRIMARY_CUME_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryCumeImpressions() As Long
        <Required>
        <Column("BOOK_PRIMARY_AQH_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 1)>
        Public Property BookPrimaryAQHRating() As Decimal
        <Required>
        <Column("PRIMARY_AQH_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 1)>
        Public Property PrimaryAQHRating() As Decimal
        <Required>
        <Column("BOOK_PRIMARY_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BookPrimaryAQH() As Long
        <Required>
        <Column("PRIMARY_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryAQH() As Long
        <Required>
        <Column("PRIMARY_CUME_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 1)>
        Public Property PrimaryCumeRating() As Decimal
        <Required>
        <Column("PRIMARY_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryCume() As Long
        <Required>
        <Column("PRIMARY_CPM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(19, 2)>
        Public Property PrimaryCPM() As Decimal
        <Required>
        <Column("BOOK_SECONDARY_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property BookSecondaryRating() As Decimal
        <Required>
        <Column("SECONDARY_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property SecondaryRating() As Decimal
        <Required>
        <Column("BOOK_SECONDARY_SHARE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property BookSecondaryShare() As Decimal
        <Required>
        <Column("SECONDARY_SHARE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property SecondaryShare() As Decimal
        <Required>
        <Column("SECONDARY_HPUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property SecondaryHPUT() As Decimal
        <Required>
        <Column("SECONDARY_CPP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(19, 2)>
        Public Property SecondaryCPP() As Decimal
        <Required>
        <Column("SECONDARY_GRP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property SecondaryGRP() As Decimal
        <Required>
        <Column("SECONDARY_REACH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 3)>
        Public Property SecondaryReach() As Decimal
        <Required>
        <Column("SECONDARY_FREQUENCY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property SecondaryFrequency() As Decimal
        <Required>
        <Column("BOOK_SECONDARY_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BookSecondaryImpressions() As Long
        <Required>
        <Column("SECONDARY_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryImpressions() As Long
        <Required>
        <Column("SECONDARY_GROSS_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryGrossImpressions() As Long
        <Required>
        <Column("SECONDARY_UNIVERSE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryUniverse() As Long
        <Required>
        <Column("SECONDARY_CUME_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryCumeImpressions() As Long
        <Required>
        <Column("BOOK_SECONDARY_AQH_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 1)>
        Public Property BookSecondaryAQHRating() As Decimal
        <Required>
        <Column("SECONDARY_AQH_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 1)>
        Public Property SecondaryAQHRating() As Decimal
        <Required>
        <Column("BOOK_SECONDARY_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BookSecondaryAQH() As Long
        <Required>
        <Column("SECONDARY_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryAQH() As Long
        <Required>
        <Column("SECONDARY_CUME_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 1)>
        Public Property SecondaryCumeRating() As Decimal
        <Required>
        <Column("SECONDARY_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryCume() As Long
        <Required>
        <Column("SECONDARY_CPM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(19, 2)>
        Public Property SecondaryCPM() As Decimal
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
        <Column("OVERRIDE_POST")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OverridePost() As Boolean
        <Required>
        <Column("PRIMARY_VENDOR_SUBMITTED_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property PrimaryVendorSubmittedRating() As Decimal
        <Required>
        <Column("PRIMARY_VENDOR_SUBMITTED_SHARE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property PrimaryVendorSubmittedShare() As Decimal
        <Required>
        <Column("PRIMARY_VENDOR_SUBMITTED_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrimaryVendorSubmittedImpressions() As Long
        <Required>
        <Column("SECONDARY_VENDOR_SUBMITTED_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property SecondaryVendorSubmittedRating() As Decimal
        <Required>
        <Column("SECONDARY_VENDOR_SUBMITTED_SHARE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property SecondaryVendorSubmittedShare() As Decimal
        <Required>
        <Column("SECONDARY_VENDOR_SUBMITTED_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SecondaryVendorSubmittedImpressions() As Long
        <Required>
        <Column("OVERRIDE_POST_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OverridePostImpressions() As Boolean
        <Required>
        <Column("OVERRIDE_POST_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OverridePostAQH() As Boolean
        <Required>
        <Column("ROW_SOURCE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property RowSource() As Short

        Public Overridable Property MediaBroadcastWorksheetMarket As Database.Entities.MediaBroadcastWorksheetMarket
        Public Overridable Property Vendor As Database.Entities.Vendor
        Public Overridable Property Daypart As Database.Entities.Daypart
        Public Overridable Property MediaBroadcastWorksheetMarketDetailDates As ICollection(Of Database.Entities.MediaBroadcastWorksheetMarketDetailDate)
        Public Overridable Property MediaRFPAvailLines As ICollection(Of Database.Entities.MediaRFPAvailLine)
        Public Overridable Property MediaBroadcastWorksheetMarketDetailSubmarketDemos As ICollection(Of Database.Entities.MediaBroadcastWorksheetMarketDetailSubmarketDemo)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
