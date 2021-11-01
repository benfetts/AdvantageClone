Namespace National.Database.Entities

    <Table("NATIONAL_AUDIENCE_CORRECTION")>
    Public Class NationalAudienceCorrection
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MarketBreakID
            DataType
            Stream
            TimeType
            Network
            VenueCode
            AudienceDateTime
            ProgramCode
            TrackageCode
            StartDate
            CommercialProgramDuration
            EventDuration
            ProgramTotalDuration
            ProgramName
            TrackageName
            EpisodeName
            NielsenDaypart
            ProgramType
            IsCorrection
            IsBreakout
            IsSpecial
            IsRepeat
            IsPremiere
            IsDNA
            IsMulticast
            IsComplex
            IsShortDuration
            IsVariousMetadata
            IsVariousTimes
            IsGapped
            IsWeeklyAverage
            SyndicatorInfo
            TelecastNumber
            CoverageSampleIdentification
            TotalProgramIndicator
            DaysOfWeekIndicator
            StationCount
            HeadendCount
            CoveragePercent
            ProgramHUT
            HouseholdAudience
            Females2to5Audience
            Females6to8Audience
            Females9to11Audience
            Females12to14Audience
            Females15to17Audience
            Females18to20Audience
            Females21to24Audience
            Females25to29Audience
            Females30to34Audience
            Females35to39Audience
            Females40to44Audience
            Females45to49Audience
            Females50to54Audience
            Females55to64Audience
            Females65PlusAudience
            Males2to5Audience
            Males6to8Audience
            Males9to11Audience
            Males12to14Audience
            Males15to17Audience
            Males18to20Audience
            Males21to24Audience
            Males25to29Audience
            Males30to34Audience
            Males35to39Audience
            Males40to44Audience
            Males45to49Audience
            Males50to54Audience
            Males55to64Audience
            Males65PlusAudience
            WorkingWomen18to20Audience
            WorkingWomen21to24Audience
            WorkingWomen25to34Audience
            WorkingWomen35to44Audience
            WorkingWomen45to49Audience
            WorkingWomen50to54Audience
            WorkingWomen55PlusAudience
            Females2to5PUT
            Females6to8PUT
            Females9to11PUT
            Females12to14PUT
            Females15to17PUT
            Females18to20PUT
            Females21to24PUT
            Females25to29PUT
            Females30to34PUT
            Females35to39PUT
            Females40to44PUT
            Females45to49PUT
            Females50to54PUT
            Females55to64PUT
            Females65PlusPUT
            Males2to5PUT
            Males6to8PUT
            Males9to11PUT
            Males12to14PUT
            Males15to17PUT
            Males18to20PUT
            Males21to24PUT
            Males25to29PUT
            Males30to34PUT
            Males35to39PUT
            Males40to44PUT
            Males45to49PUT
            Males50to54PUT
            Males55to64PUT
            Males65PlusPUT
            WorkingWomen18to20PUT
            WorkingWomen21to24PUT
            WorkingWomen25to34PUT
            WorkingWomen35to44PUT
            WorkingWomen45to49PUT
            WorkingWomen50to54PUT
            WorkingWomen55PlusPUT
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NATIONAL_AUDIENCE_CORRECTION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Int64
        <Required>
        <Column("MARKET_BREAK_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MarketBreakID() As Integer
        <Required>
        <MaxLength(4)>
        <Column("DATA_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DataType() As String
        <Required>
        <MaxLength(2)>
        <Column("STREAM", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Stream() As String
        <Required>
        <MaxLength(1)>
        <Column("TIME_TYPE", TypeName:="char")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property TimeType() As String
        <Required>
        <MaxLength(6)>
        <Column("NETWORK", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Network() As String
        <Required>
        <Column("VENUE_CODE", TypeName:="char")>
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property VenueCode() As String
        <Required>
        <Column("AUDIENCE_DATETIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AudienceDateTime() As Date
        <Required>
        <Column("PROGRAM_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ProgramCode() As Decimal
        <Required>
        <Column("TRACKAGE_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property TrackageCode() As Short
        <Required>
        <Column("START_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartDate() As Date
        <Required>
        <Column("COMMERCIAL_PROGRAM_DURATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CommercialProgramDuration() As Integer
        <Required>
        <Column("EVENT_DURATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EventDuration() As Integer
        <Required>
        <Column("PROGRAM_TOTAL_DURATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ProgramTotalDuration() As Integer
        <Required>
        <MaxLength(25)>
        <Column("PROGRAM_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ProgramName() As String
        <Required>
        <MaxLength(25)>
        <Column("TRACKAGE_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property TrackageName() As String
        <Required>
        <MaxLength(32)>
        <Column("EPISODE_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EpisodeName() As String
        <Required>
        <MaxLength(2)>
        <Column("NIELSEN_DAYPART", TypeName:="char")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NielsenDaypart() As String
        <Required>
        <MaxLength(2)>
        <Column("PROGRAM_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ProgramType() As String
        <Required>
        <Column("IS_CORRECTION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsCorrection() As Boolean
        <Required>
        <Column("IS_BREAKOUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsBreakout() As Boolean
        <Required>
        <Column("IS_SPECIAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsSpecial() As Boolean
        <Required>
        <Column("IS_REPEAT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsRepeat() As Boolean
        <Required>
        <Column("IS_PREMIERE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsPremiere() As Boolean
        <Required>
        <Column("IS_DNA")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsDNA() As Boolean
        <Required>
        <Column("IS_MULTICAST")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsMulticast() As Boolean
        <Required>
        <Column("IS_COMPLEX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsComplex() As Boolean
        <Required>
        <Column("IS_SHORT_DURATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsShortDuration() As Boolean
        <Required>
        <Column("IS_VARIOUS_METADATA")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsVariousMetadata() As Boolean
        <Required>
        <Column("IS_VARIOUS_TIMES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsVariousTimes() As Boolean
        <Required>
        <Column("IS_GAPPED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsGapped() As Boolean
        <Required>
        <Column("IS_WEEKLY_AVERAGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsWeeklyAverage() As Boolean
        <Required(AllowEmptyStrings:=True)>
        <MaxLength(1)>
        <Column("SYNDICATOR_INFO", TypeName:="char")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SyndicatorInfo() As String
        <Required>
        <Column("TELECAST_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property TelecastNumber() As Decimal
        <Required>
        <Column("COVERAGE_SAMPLE_IDENTIFICATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CoverageSampleIdentification() As Integer
        <Required>
        <MaxLength(2)>
        <Column("TOTAL_PROGRAM_INDICATOR", TypeName:="char")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property TotalProgramIndicator() As String
        <Required>
        <MaxLength(7)>
        <Column("DAYS_OF_WEEK_INDICATOR", TypeName:="char")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DaysOfWeekIndicator() As String
        <Required>
        <Column("STATION_COUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StationCount() As Integer
        <Required>
        <Column("HEADEND_COUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property HeadendCount() As Integer
        <Required>
        <Column("COVERAGE_PERCENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CoveragePercent() As Short
        <Required>
        <Column("PROGRAM_HUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ProgramHUT() As Integer
        <Required>
        <Column("HOUSEHOLD_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property HouseholdAudience() As Integer
        <Required>
        <Column("FEMALES_2TO5_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females2to5Audience() As Integer
        <Required>
        <Column("FEMALES_6TO8_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females6to8Audience() As Integer
        <Required>
        <Column("FEMALES_9TO11_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females9to11Audience() As Integer
        <Required>
        <Column("FEMALES_12TO14_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females12to14Audience() As Integer
        <Required>
        <Column("FEMALES_15TO17_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females15to17Audience() As Integer
        <Required>
        <Column("FEMALES_18TO20_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18to20Audience() As Integer
        <Required>
        <Column("FEMALES_21TO24_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females21to24Audience() As Integer
        <Required>
        <Column("FEMALES_25TO29_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females25to29Audience() As Integer
        <Required>
        <Column("FEMALES_30TO34_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females30to34Audience() As Integer
        <Required>
        <Column("FEMALES_35TO39_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females35to39Audience() As Integer
        <Required>
        <Column("FEMALES_40TO44_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females40to44Audience() As Integer
        <Required>
        <Column("FEMALES_45TO49_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females45to49Audience() As Integer
        <Required>
        <Column("FEMALES_50TO54_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females50to54Audience() As Integer
        <Required>
        <Column("FEMALES_55TO64_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females55to64Audience() As Integer
        <Required>
        <Column("FEMALES_65PLUS_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females65PlusAudience() As Integer
        <Required>
        <Column("MALES_2TO5_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males2to5Audience() As Integer
        <Required>
        <Column("MALES_6TO8_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males6to8Audience() As Integer
        <Required>
        <Column("MALES_9TO11_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males9to11Audience() As Integer
        <Required>
        <Column("MALES_12TO14_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males12to14Audience() As Integer
        <Required>
        <Column("MALES_15TO17_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males15to17Audience() As Integer
        <Required>
        <Column("MALES_18TO20_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18to20Audience() As Integer
        <Required>
        <Column("MALES_21TO24_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males21to24Audience() As Integer
        <Required>
        <Column("MALES_25TO29_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males25to29Audience() As Integer
        <Required>
        <Column("MALES_30TO34_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males30to34Audience() As Integer
        <Required>
        <Column("MALES_35TO39_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males35to39Audience() As Integer
        <Required>
        <Column("MALES_40TO44_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males40to44Audience() As Integer
        <Required>
        <Column("MALES_45TO49_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males45to49Audience() As Integer
        <Required>
        <Column("MALES_50TO54_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males50to54Audience() As Integer
        <Required>
        <Column("MALES_55TO64_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males55to64Audience() As Integer
        <Required>
        <Column("MALES_65PLUS_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males65PlusAudience() As Integer
        <Required>
        <Column("WORKING_WOMEN_18TO20_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen18to20Audience() As Integer
        <Required>
        <Column("WORKING_WOMEN_21TO24_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen21to24Audience() As Integer
        <Required>
        <Column("WORKING_WOMEN_25TO34_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen25to34Audience() As Integer
        <Required>
        <Column("WORKING_WOMEN_35TO44_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen35to44Audience() As Integer
        <Required>
        <Column("WORKING_WOMEN_45TO49_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen45to49Audience() As Integer
        <Required>
        <Column("WORKING_WOMEN_50TO54_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen50to54Audience() As Integer
        <Required>
        <Column("WORKING_WOMEN_55PLUS_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen55PlusAudience() As Integer
        <Required>
        <Column("FEMALES_2TO5_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females2to5PUT() As Integer
        <Required>
        <Column("FEMALES_6TO8_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females6to8PUT() As Integer
        <Required>
        <Column("FEMALES_9TO11_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females9to11PUT() As Integer
        <Required>
        <Column("FEMALES_12TO14_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females12to14PUT() As Integer
        <Required>
        <Column("FEMALES_15TO17_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females15to17PUT() As Integer
        <Required>
        <Column("FEMALES_18TO20_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18to20PUT() As Integer
        <Required>
        <Column("FEMALES_21TO24_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females21to24PUT() As Integer
        <Required>
        <Column("FEMALES_25TO29_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females25to29PUT() As Integer
        <Required>
        <Column("FEMALES_30TO34_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females30to34PUT() As Integer
        <Required>
        <Column("FEMALES_35TO39_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females35to39PUT() As Integer
        <Required>
        <Column("FEMALES_40TO44_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females40to44PUT() As Integer
        <Required>
        <Column("FEMALES_45TO49_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females45to49PUT() As Integer
        <Required>
        <Column("FEMALES_50TO54_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females50to54PUT() As Integer
        <Required>
        <Column("FEMALES_55TO64_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females55to64PUT() As Integer
        <Required>
        <Column("FEMALES_65PLUS_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females65PlusPUT() As Integer
        <Required>
        <Column("MALES_2TO5_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males2to5PUT() As Integer
        <Required>
        <Column("MALES_6TO8_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males6to8PUT() As Integer
        <Required>
        <Column("MALES_9TO11_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males9to11PUT() As Integer
        <Required>
        <Column("MALES_12TO14_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males12to14PUT() As Integer
        <Required>
        <Column("MALES_15TO17_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males15to17PUT() As Integer
        <Required>
        <Column("MALES_18TO20_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18to20PUT() As Integer
        <Required>
        <Column("MALES_21TO24_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males21to24PUT() As Integer
        <Required>
        <Column("MALES_25TO29_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males25to29PUT() As Integer
        <Required>
        <Column("MALES_30TO34_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males30to34PUT() As Integer
        <Required>
        <Column("MALES_35TO39_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males35to39PUT() As Integer
        <Required>
        <Column("MALES_40TO44_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males40to44PUT() As Integer
        <Required>
        <Column("MALES_45TO49_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males45to49PUT() As Integer
        <Required>
        <Column("MALES_50TO54_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males50to54PUT() As Integer
        <Required>
        <Column("MALES_55TO64_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males55to64PUT() As Integer
        <Required>
        <Column("MALES_65PLUS_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males65PlusPUT() As Integer
        <Required>
        <Column("WORKING_WOMEN_18TO20_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen18to20PUT() As Integer
        <Required>
        <Column("WORKING_WOMEN_21TO24_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen21to24PUT() As Integer
        <Required>
        <Column("WORKING_WOMEN_25TO34_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen25to34PUT() As Integer
        <Required>
        <Column("WORKING_WOMEN_35TO44_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen35to44PUT() As Integer
        <Required>
        <Column("WORKING_WOMEN_45TO49_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen45to49PUT() As Integer
        <Required>
        <Column("WORKING_WOMEN_50TO54_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen50to54PUT() As Integer
        <Required>
        <Column("WORKING_WOMEN_55PLUS_PUT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen55PlusPUT() As Integer

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
