Namespace DTO.Media.SpotTVPuertoRico

    Public Class ResearchResult
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Station
            StationID
            Days
            Times
            Rating
            Share
            Impressions
            HPUT
            Intab
            Universe
            ProgramName
            DemographicOrder
            DaytimeID
            Rank
            Demographic
            NPRStationID
            ShowIntabWarning
            TrendDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Station() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StationID() As Integer
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
        Public Property Universe() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProgramName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DemographicOrder() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DaytimeID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Rank() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Demographic() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DayStart() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DayEnd() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property StartHour() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ShowIntabWarning As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EndHour() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property MilitaryTimes() As String
            Get
                MilitaryTimes = GetMilitaryTime(Me.StartHour) & "-" & GetMilitaryTime(Me.EndHour)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property TrendDate As Nullable(Of Date)

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
