Namespace DTO.Media.SpotRadio

    Public Class ResearchResult
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            BookID
            Demographic
            Population
            AQH
            AQHRating
            AQHShare
            PUR
            PURPercent
            Intab
            IntabFlag
            Cume
            ExclusiveCume
            CumeRating
            'CumeShare
            CumePercent
            Daypart
            NielsenRadioDaypartID
            StationName
            StationFormat
            StationFrequency
            IsSpill
            MediaSpotRadioResearchDaypartID
            Rank
            Market
            Books
            DaypartBooks
            NielsenRadioStationID
            QualitativeName
            BookCount
            Copyright
            CopyrightMarketBooks
            ShowFootNote
            TrendBookOrder
            ShowDiaryFootNote
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BookID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Demographic() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Population() As Int64

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AQH() As Int64

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AQHRating() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AQHShare() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PUR() As Int64

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PURPercent() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Intab() As Int64

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IntabFlag() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Cume() As Int64

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ExclusiveCume() As Int64

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CumeRating() As Decimal

        '<AdvantageFramework.BaseClasses.Attributes.Entity()>
        'Public Property CumeShare() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CumePercent() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Daypart() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property NielsenRadioDaypartID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StationName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StationFormat() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StationFrequency() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsSpill() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MediaSpotRadioResearchDaypartID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Rank() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Market() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Books() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DaypartBooks() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property NielsenRadioStationID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property QualitativeName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BookCount As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Copyright() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CopyrightMarketBooks() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowFootNote() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TrendBookOrder() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowDiaryFootNote() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
