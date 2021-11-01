Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenNationalTVAudience

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaMarketBreakID
            TimeType
            Stream
            Network
            AudienceDate
            AudienceTime
            SequenceNumber
            ProgramDuration
            ProgramTotalDuration
            ProgramName
            TrackageName
            EpisodeName
            ProgramCode
            TrackageCode
            NielsenDaypart
            ProgramType
            IsCorrection
            IsBreakout
            IsSpecial
            IsRepeat
            IsPremiere
            IsOvernight
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
            MarketBreakIdentifier
            TotalProgramIndicator
            DaysOfWeekIndicator
            StationCount
            HeadendCount
            CoveragePercent
            DaysCount
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
            HouseholdHUT
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

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Int64
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaMarketBreakID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TimeType() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Stream() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Network() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AudienceDate() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AudienceTime() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SequenceNumber() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProgramDuration() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProgramTotalDuration() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProgramName() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TrackageName() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EpisodeName() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProgramCode() As Decimal
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TrackageCode() As Nullable(Of Short)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenDaypart() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProgramType() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsCorrection() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsBreakout() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsSpecial() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsRepeat() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsPremiere() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsOvernight() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsDNA() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsMulticast() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsComplex() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsShortDuration() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsVariousMetadata() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsVariousTimes() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsGapped() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsWeeklyAverage() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SyndicatorInfo() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TelecastNumber() As Decimal
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CoverageSampleIdentification() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketBreakIdentifier() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalProgramIndicator() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DaysOfWeekIndicator() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StationCount() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HeadendCount() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CoveragePercent() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DaysCount() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProgramHUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HouseholdAudience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females2to5Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females6to8Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females9to11Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females12to14Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females15to17Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females18to20Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females21to24Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females25to29Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females30to34Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females35to39Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females40to44Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females45to49Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females50to54Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females55to64Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females65PlusAudience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males2to5Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males6to8Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males9to11Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males12to14Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males15to17Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males18to20Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males21to24Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males25to29Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males30to34Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males35to39Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males40to44Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males45to49Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males50to54Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males55to64Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males65PlusAudience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen18to20Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen21to24Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen25to34Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen35to44Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen45to49Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen50to54Audience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen55PlusAudience() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HouseholdHUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females2to5PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females6to8PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females9to11PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females12to14PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females15to17PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females18to20PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females21to24PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females25to29PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females30to34PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females35to39PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females40to44PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females45to49PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females50to54PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females55to64PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Females65PlusPUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males2to5PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males6to8PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males9to11PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males12to14PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males15to17PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males18to20PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males21to24PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males25to29PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males30to34PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males35to39PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males40to44PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males45to49PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males50to54PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males55to64PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Males65PlusPUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen18to20PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen21to24PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen25to34PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen35to44PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen45to49PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen50to54PUT() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property WorkingWomen55PlusPUT() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(NielsenNationalTVAudience As AdvantageFramework.Nielsen.Database.Entities.NielsenNationalTVAudience)

            Me.ID = NielsenNationalTVAudience.ID
            Me.MediaMarketBreakID = NielsenNationalTVAudience.MediaMarketBreakID
            Me.TimeType = NielsenNationalTVAudience.TimeType
            Me.Stream = NielsenNationalTVAudience.Stream
            Me.Network = NielsenNationalTVAudience.Network
            Me.AudienceDate = NielsenNationalTVAudience.AudienceDate
            Me.AudienceTime = NielsenNationalTVAudience.AudienceTime
            Me.SequenceNumber = NielsenNationalTVAudience.SequenceNumber
            Me.ProgramDuration = NielsenNationalTVAudience.ProgramDuration
            Me.ProgramTotalDuration = NielsenNationalTVAudience.ProgramTotalDuration
            Me.ProgramName = NielsenNationalTVAudience.ProgramName
            Me.TrackageName = NielsenNationalTVAudience.TrackageName
            Me.EpisodeName = NielsenNationalTVAudience.EpisodeName
            Me.ProgramCode = NielsenNationalTVAudience.ProgramCode
            Me.TrackageCode = NielsenNationalTVAudience.TrackageCode
            Me.NielsenDaypart = NielsenNationalTVAudience.NielsenDaypart
            Me.ProgramType = NielsenNationalTVAudience.ProgramType
            Me.IsCorrection = NielsenNationalTVAudience.IsCorrection
            Me.IsBreakout = NielsenNationalTVAudience.IsBreakout
            Me.IsSpecial = NielsenNationalTVAudience.IsSpecial
            Me.IsRepeat = NielsenNationalTVAudience.IsRepeat
            Me.IsPremiere = NielsenNationalTVAudience.IsPremiere
            Me.IsOvernight = NielsenNationalTVAudience.IsOvernight
            Me.IsDNA = NielsenNationalTVAudience.IsDNA
            Me.IsMulticast = NielsenNationalTVAudience.IsMulticast
            Me.IsComplex = NielsenNationalTVAudience.IsComplex
            Me.IsShortDuration = NielsenNationalTVAudience.IsShortDuration
            Me.IsVariousMetadata = NielsenNationalTVAudience.IsVariousMetadata
            Me.IsVariousTimes = NielsenNationalTVAudience.IsVariousTimes
            Me.IsGapped = NielsenNationalTVAudience.IsGapped
            Me.IsWeeklyAverage = NielsenNationalTVAudience.IsWeeklyAverage
            Me.SyndicatorInfo = NielsenNationalTVAudience.SyndicatorInfo
            Me.TelecastNumber = NielsenNationalTVAudience.TelecastNumber
            Me.CoverageSampleIdentification = NielsenNationalTVAudience.CoverageSampleIdentification
            Me.MarketBreakIdentifier = NielsenNationalTVAudience.MarketBreakIdentifier
            Me.TotalProgramIndicator = NielsenNationalTVAudience.TotalProgramIndicator
            Me.DaysOfWeekIndicator = NielsenNationalTVAudience.DaysOfWeekIndicator
            Me.StationCount = NielsenNationalTVAudience.StationCount
            Me.HeadendCount = NielsenNationalTVAudience.HeadendCount
            Me.CoveragePercent = NielsenNationalTVAudience.CoveragePercent
            Me.DaysCount = NielsenNationalTVAudience.DaysCount
            Me.ProgramHUT = NielsenNationalTVAudience.ProgramHUT
            Me.HouseholdAudience = NielsenNationalTVAudience.HouseholdAudience
            Me.Females2to5Audience = NielsenNationalTVAudience.Females2to5Audience
            Me.Females6to8Audience = NielsenNationalTVAudience.Females6to8Audience
            Me.Females9to11Audience = NielsenNationalTVAudience.Females9to11Audience
            Me.Females12to14Audience = NielsenNationalTVAudience.Females12to14Audience
            Me.Females15to17Audience = NielsenNationalTVAudience.Females15to17Audience
            Me.Females18to20Audience = NielsenNationalTVAudience.Females18to20Audience
            Me.Females21to24Audience = NielsenNationalTVAudience.Females21to24Audience
            Me.Females25to29Audience = NielsenNationalTVAudience.Females25to29Audience
            Me.Females30to34Audience = NielsenNationalTVAudience.Females30to34Audience
            Me.Females35to39Audience = NielsenNationalTVAudience.Females35to39Audience
            Me.Females40to44Audience = NielsenNationalTVAudience.Females40to44Audience
            Me.Females45to49Audience = NielsenNationalTVAudience.Females45to49Audience
            Me.Females50to54Audience = NielsenNationalTVAudience.Females50to54Audience
            Me.Females55to64Audience = NielsenNationalTVAudience.Females55to64Audience
            Me.Females65PlusAudience = NielsenNationalTVAudience.Females65PlusAudience
            Me.Males2to5Audience = NielsenNationalTVAudience.Males2to5Audience
            Me.Males6to8Audience = NielsenNationalTVAudience.Males6to8Audience
            Me.Males9to11Audience = NielsenNationalTVAudience.Males9to11Audience
            Me.Males12to14Audience = NielsenNationalTVAudience.Males12to14Audience
            Me.Males15to17Audience = NielsenNationalTVAudience.Males15to17Audience
            Me.Males18to20Audience = NielsenNationalTVAudience.Males18to20Audience
            Me.Males21to24Audience = NielsenNationalTVAudience.Males21to24Audience
            Me.Males25to29Audience = NielsenNationalTVAudience.Males25to29Audience
            Me.Males30to34Audience = NielsenNationalTVAudience.Males30to34Audience
            Me.Males35to39Audience = NielsenNationalTVAudience.Males35to39Audience
            Me.Males40to44Audience = NielsenNationalTVAudience.Males40to44Audience
            Me.Males45to49Audience = NielsenNationalTVAudience.Males45to49Audience
            Me.Males50to54Audience = NielsenNationalTVAudience.Males50to54Audience
            Me.Males55to64Audience = NielsenNationalTVAudience.Males55to64Audience
            Me.Males65PlusAudience = NielsenNationalTVAudience.Males65PlusAudience
            Me.WorkingWomen18to20Audience = NielsenNationalTVAudience.WorkingWomen18to20Audience
            Me.WorkingWomen21to24Audience = NielsenNationalTVAudience.WorkingWomen21to24Audience
            Me.WorkingWomen25to34Audience = NielsenNationalTVAudience.WorkingWomen25to34Audience
            Me.WorkingWomen35to44Audience = NielsenNationalTVAudience.WorkingWomen35to44Audience
            Me.WorkingWomen45to49Audience = NielsenNationalTVAudience.WorkingWomen45to49Audience
            Me.WorkingWomen50to54Audience = NielsenNationalTVAudience.WorkingWomen50to54Audience
            Me.WorkingWomen55PlusAudience = NielsenNationalTVAudience.WorkingWomen55PlusAudience
            Me.HouseholdHUT = NielsenNationalTVAudience.HouseholdHUT
            Me.Females2to5PUT = NielsenNationalTVAudience.Females2to5PUT
            Me.Females6to8PUT = NielsenNationalTVAudience.Females6to8PUT
            Me.Females9to11PUT = NielsenNationalTVAudience.Females9to11PUT
            Me.Females12to14PUT = NielsenNationalTVAudience.Females12to14PUT
            Me.Females15to17PUT = NielsenNationalTVAudience.Females15to17PUT
            Me.Females18to20PUT = NielsenNationalTVAudience.Females18to20PUT
            Me.Females21to24PUT = NielsenNationalTVAudience.Females21to24PUT
            Me.Females25to29PUT = NielsenNationalTVAudience.Females25to29PUT
            Me.Females30to34PUT = NielsenNationalTVAudience.Females30to34PUT
            Me.Females35to39PUT = NielsenNationalTVAudience.Females35to39PUT
            Me.Females40to44PUT = NielsenNationalTVAudience.Females40to44PUT
            Me.Females45to49PUT = NielsenNationalTVAudience.Females45to49PUT
            Me.Females50to54PUT = NielsenNationalTVAudience.Females50to54PUT
            Me.Females55to64PUT = NielsenNationalTVAudience.Females55to64PUT
            Me.Females65PlusPUT = NielsenNationalTVAudience.Females65PlusPUT
            Me.Males2to5PUT = NielsenNationalTVAudience.Males2to5PUT
            Me.Males6to8PUT = NielsenNationalTVAudience.Males6to8PUT
            Me.Males9to11PUT = NielsenNationalTVAudience.Males9to11PUT
            Me.Males12to14PUT = NielsenNationalTVAudience.Males12to14PUT
            Me.Males15to17PUT = NielsenNationalTVAudience.Males15to17PUT
            Me.Males18to20PUT = NielsenNationalTVAudience.Males18to20PUT
            Me.Males21to24PUT = NielsenNationalTVAudience.Males21to24PUT
            Me.Males25to29PUT = NielsenNationalTVAudience.Males25to29PUT
            Me.Males30to34PUT = NielsenNationalTVAudience.Males30to34PUT
            Me.Males35to39PUT = NielsenNationalTVAudience.Males35to39PUT
            Me.Males40to44PUT = NielsenNationalTVAudience.Males40to44PUT
            Me.Males45to49PUT = NielsenNationalTVAudience.Males45to49PUT
            Me.Males50to54PUT = NielsenNationalTVAudience.Males50to54PUT
            Me.Males55to64PUT = NielsenNationalTVAudience.Males55to64PUT
            Me.Males65PlusPUT = NielsenNationalTVAudience.Males65PlusPUT
            Me.WorkingWomen18to20PUT = NielsenNationalTVAudience.WorkingWomen18to20PUT
            Me.WorkingWomen21to24PUT = NielsenNationalTVAudience.WorkingWomen21to24PUT
            Me.WorkingWomen25to34PUT = NielsenNationalTVAudience.WorkingWomen25to34PUT
            Me.WorkingWomen35to44PUT = NielsenNationalTVAudience.WorkingWomen35to44PUT
            Me.WorkingWomen45to49PUT = NielsenNationalTVAudience.WorkingWomen45to49PUT
            Me.WorkingWomen50to54PUT = NielsenNationalTVAudience.WorkingWomen50to54PUT
            Me.WorkingWomen55PlusPUT = NielsenNationalTVAudience.WorkingWomen55PlusPUT

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
