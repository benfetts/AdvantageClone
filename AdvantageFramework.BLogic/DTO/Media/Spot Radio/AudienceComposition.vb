Namespace DTO.Media.SpotRadio

    Public Class AudienceComposition
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            TotalAQH
            TotalCume
            TotalExclusiveCume
            AQH
            AQHPercent
            Cume
            CumePercent
            ExclusiveCume
            ExclusiveCumePercent
            DisplayBy
            AgeFrom
            Demographic
            Daypart
            StationName
            StationFormat
            StationFrequency
            IsSpill
            Intab
            IntabFlag
            Population
            BookCount
            Copyright
            CopyrightMarketBooks
            ShowFootNote
            Rank
            Books
            ShowDiaryFootNote
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TotalAQH() As Int64

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TotalCume() As Int64

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TotalExclusiveCume() As Int64

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AQH() As Int64

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AQHPercent() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Cume() As Int64

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CumePercent() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ExclusiveCume() As Int64

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ExclusiveCumePercent() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DisplayBy() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AgeFrom() As Nullable(Of Short)

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Demographic() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Daypart() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StationName() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StationFormat() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StationFrequency() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsSpill() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Intab() As Int64

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IntabFlag() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Population() As Int64

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BookCount() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Copyright() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CopyrightMarketBooks() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowFootNote() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Rank() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Books() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowDiaryFootNote() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
