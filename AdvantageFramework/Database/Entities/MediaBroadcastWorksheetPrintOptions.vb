Namespace Database.Entities

    <Table("MEDIA_BROADCAST_WORKSHEET_PRINT_OPTIONS")>
    Public Class MediaBroadcastWorksheetPrintOptions
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaBroadcastWorksheetPrintOptionsID
            UserCode
            PrintLocation
            LocationCode
            PrintOnHold
            PrintLineNumber
            PrintCableNetworkStationCode
            PrintDaypart
            PrintLength
            PrintDays
            PrintStartTime
            PrintEndTime
            PrintProgram
            PrintComments
            PrintBookend
            PrintValueAdded
            PrintDefaultRate
            PrintTotalSpots
            PrintTotalDollars
            PrintPrimaryRating
            PrintPrimaryShare
            PrintPrimaryHPUT
            PrintPrimaryAQHRating
            PrintPrimaryCPP
            PrintPrimaryGRP
            PrintPrimaryAQH
            PrintPrimaryCumeRating
            PrintPrimaryCume
            PrintPrimaryReach
            PrintPrimaryGrossImpressions
            PrintSecondaryRating
            PrintSecondaryShare
            PrintSecondaryHPUT
            PrintSecondaryAQHRating
            PrintSecondaryCPP
            PrintSecondaryGRP
            PrintSecondaryAQH
            PrintSecondaryCumeRating
            PrintSecondaryCume
            PrintSecondaryReach
            PrintSecondaryGrossImpressions
            PrintPrimaryTVCume
            PrintPrimaryTVImpressions
            PrintSecondaryTVCume
            PrintSecondaryTVImpressions
            PrintPrimaryCPM
            PrintSecondaryCPM
            PrintRemoveLinesWithoutSpots
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_PRINT_OPTIONS_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaBroadcastWorksheetPrintOptionsID As Integer
        <Required>
        <MaxLength(100)>
        <Column("USER_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UserCode As String
        <Required>
        <Column("PRINT_LOCATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintLocation As Boolean
        <MaxLength(6)>
        <Column("LOCATION_ID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LocationCode As String
        <Required>
        <Column("PRINT_ON_HOLD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintOnHold As Boolean
        <Required>
        <Column("PRINT_LINE_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintLineNumber As Boolean
        <Required>
        <Column("PRINT_CABLE_NETWORK_STATION_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintCableNetworkStationCode As Boolean
        <Required>
        <Column("PRINT_DAYPART")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintDaypart As Boolean
        <Required>
        <Column("PRINT_LENGTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintLength As Boolean
        <Required>
        <Column("PRINT_DAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintDays As Boolean
        <Required>
        <Column("PRINT_START_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintStartTime As Boolean
        <Required>
        <Column("PRINT_END_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintEndTime As Boolean
        <Required>
        <Column("PRINT_PROGRAM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintProgram As Boolean
        <Required>
        <Column("PRINT_COMMENTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintComments As Boolean
        <Required>
        <Column("PRINT_BOOKEND")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintBookend As Boolean
        <Required>
        <Column("PRINT_VALUEADDED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintValueAdded As Boolean
        <Required>
        <Column("PRINT_DEFAULT_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintDefaultRate As Boolean
        <Required>
        <Column("PRINT_TOTAL_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintTotalSpots As Boolean
        <Required>
        <Column("PRINT_TOTAL_DOLLARS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintTotalDollars As Boolean
        <Required>
        <Column("PRINT_PRIMARY_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintPrimaryRating As Boolean
        <Required>
        <Column("PRINT_PRIMARY_SHARE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintPrimaryShare As Boolean
        <Required>
        <Column("PRINT_PRIMARY_HPUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintPrimaryHPUT As Boolean
        <Required>
        <Column("PRINT_PRIMARY_AQH_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintPrimaryAQHRating As Boolean
        <Required>
        <Column("PRINT_PRIMARY_CPP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintPrimaryCPP As Boolean
        <Required>
        <Column("PRINT_PRIMARY_GRP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintPrimaryGRP As Boolean
        <Required>
        <Column("PRINT_PRIMARY_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintPrimaryAQH As Boolean
        <Required>
        <Column("PRINT_PRIMARY_CUME_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintPrimaryCumeRating As Boolean
        <Required>
        <Column("PRINT_PRIMARY_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintPrimaryCume As Boolean
        <Required>
        <Column("PRINT_PRIMARY_REACH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintPrimaryReach As Boolean
        <Required>
        <Column("PRINT_PRIMARY_GROSS_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintPrimaryGrossImpressions As Boolean
        <Required>
        <Column("PRINT_SECONDARY_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintSecondaryRating As Boolean
        <Required>
        <Column("PRINT_SECONDARY_SHARE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintSecondaryShare As Boolean
        <Required>
        <Column("PRINT_SECONDARY_HPUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintSecondaryHPUT As Boolean
        <Required>
        <Column("PRINT_SECONDARY_AQH_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintSecondaryAQHRating As Boolean
        <Required>
        <Column("PRINT_SECONDARY_CPP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintSecondaryCPP As Boolean
        <Required>
        <Column("PRINT_SECONDARY_GRP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintSecondaryGRP As Boolean
        <Required>
        <Column("PRINT_SECONDARY_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintSecondaryAQH As Boolean
        <Required>
        <Column("PRINT_SECONDARY_CUME_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintSecondaryCumeRating As Boolean
        <Required>
        <Column("PRINT_SECONDARY_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintSecondaryCume As Boolean
        <Required>
        <Column("PRINT_SECONDARY_REACH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintSecondaryReach As Boolean
        <Required>
        <Column("PRINT_SECONDARY_GROSS_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintSecondaryGrossImpressions As Boolean
        <Required>
        <Column("PRINT_PRIMARY_TV_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintPrimaryTVCume As Boolean
        <Required>
        <Column("PRINT_PRIMARY_TV_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintPrimaryTVImpressions As Boolean
        <Required>
        <Column("PRINT_SECONDARY_TV_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintSecondaryTVCume As Boolean
        <Required>
        <Column("PRINT_SECONDARY_TV_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintSecondaryTVImpressions As Boolean
        <Required>
        <Column("PRINT_PRIMARY_CPM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintPrimaryCPM As Boolean
        <Required>
        <Column("PRINT_SECONDARY_CPM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintSecondaryCPM As Boolean
        <Required>
        <Column("PRINT_REMOVE_LINES_WITHOUT_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PrintRemoveLinesWithoutSpots As Boolean

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

