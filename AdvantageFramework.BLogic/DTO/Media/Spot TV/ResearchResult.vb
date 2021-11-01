Namespace DTO.Media.SpotTV

    Public Class ResearchResult
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IsSpill
            Station
            StationCode
            Days
            Times
            Rating
            Share
            Impressions
            HPUT
            Intab
            Universe
            ProgramName
            DemographicStream
            DemographicOrder
            DaytimeID
            Rank
            Stream
            StreamYear
            StreamMonth
            MonthYear
            BookID
            HPUTBookID
            Demographic
            MarketDescription
            Books
            ShowSpill
            NielsenTVStationID
            MediaSpotTVResearchBookID
            ShowIntabWarning
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsSpill() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Station() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StationCode() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Days() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property Times() As String
            Get
                Times = Me.DayStart & "-" & Me.DayEnd
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Rating() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Impressions() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property HPUT() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Intab() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Universe() As Int64
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProgramName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DemographicStream() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DemographicOrder() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DaytimeID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Rank() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Stream() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StreamYear() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StreamMonth() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BookID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property HPUTBookID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property MonthYear() As String
            Get
                MonthYear = MonthName(Me.StreamMonth, True) & Me.StreamYear.ToString.Substring(2)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MarketDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Demographic() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Books() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowSpill() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property NielsenTVStationID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DayStart() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DayEnd() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property StartHour() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaSpotTVResearchBookID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowIntabWarning As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ComscoreMeetsDemoThreshold As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ComscoreMeetsHighQualityDemoThreshold As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EndHour() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property MilitaryTimes() As String
            Get
                MilitaryTimes = GetMilitaryTime(Me.StartHour) & "-" & GetMilitaryTime(Me.EndHour)
            End Get
        End Property

#End Region

#Region " Methods "

        Private Function GetMilitaryTime(Hour As Short) As String

            Dim MilitaryTime As String = String.Empty

            If Hour = 0 Then

                MilitaryTime = "00:00"

            Else

                MilitaryTime = (Hour \ 100).ToString.PadLeft(2, "0") & (Hour Mod 100).ToString.PadLeft(2, "0")

            End If

            GetMilitaryTime = MilitaryTime

        End Function
        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
