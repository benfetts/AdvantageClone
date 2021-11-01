Namespace Services.ComScore.Classes

    <Serializable>
    Public Class LocalTimeViewCache

        <Newtonsoft.Json.JsonProperty("market_no")>
        Public Property MarketNumber As Integer

        <Newtonsoft.Json.JsonProperty("station_no")>
        Public Property StationNumber As Integer

        <Newtonsoft.Json.JsonProperty("qtr_hour")>
        Public Property Quarterhour As String

        <Newtonsoft.Json.JsonProperty("series_names")>
        Public Property ProgramName As String()

        <Newtonsoft.Json.JsonProperty("day")>
        Public Property Day As Date

        <Newtonsoft.Json.JsonProperty("1_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SIU As Decimal

        <Newtonsoft.Json.JsonProperty("1_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Universe As Integer

        <Newtonsoft.Json.JsonProperty("1_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AverageAudience As Decimal

        <Newtonsoft.Json.JsonProperty("1_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold As Boolean

        <Newtonsoft.Json.JsonProperty("1_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold As Boolean

        <Newtonsoft.Json.JsonProperty("1_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share As Decimal

        <Newtonsoft.Json.JsonProperty("2_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SIU2 As Decimal

        <Newtonsoft.Json.JsonProperty("2_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Universe2 As Integer

        <Newtonsoft.Json.JsonProperty("2_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AverageAudience2 As Decimal

        <Newtonsoft.Json.JsonProperty("2_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold2 As Boolean

        <Newtonsoft.Json.JsonProperty("2_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold2 As Boolean

        <Newtonsoft.Json.JsonProperty("2_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share2 As Decimal

        Public ReadOnly Property SeriesName As String
            Get
                If ProgramName IsNot Nothing AndAlso ProgramName.Length = 1 Then
                    SeriesName = ProgramName.First
                Else
                    SeriesName = ""
                End If
            End Get
        End Property

        Public ReadOnly Property QtrDateTime As Date
            Get
                QtrDateTime = CDate(Me.Day.ToString("MM/dd/yyyy") & " " & Me.Quarterhour)
            End Get
        End Property

        Public Sub New()



        End Sub

    End Class

End Namespace