Namespace DTO.Media.SpotRadioCounty

    Public Class ResearchResult
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AQH
            AQHRating
            StationShareofCountyPercent
            CountyShareofStationPercent
            Cume
            CumeRating
            StationName
            StationFrequency
            Daypart
            NielsenRadioDaypartID
            CountyName
            Demographic
            ShowFootNote
            Years
            Population
            Intab
            BookCount
            IntabFlag
            Rank
            State
            TrendBookOrder
            BookID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AQH() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AQHRating() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StationShareofCountyPercent() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CountyShareofStationPercent() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Cume() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CumeRating() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StationName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StationFrequency() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Daypart() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property NielsenRadioDaypartID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CountyName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Demographic() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowFootNote() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Years() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Population() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Intab() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BookCount As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IntabFlag() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Rank() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property State() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TrendBookOrder() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BookID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Books() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
