Namespace Services.ComScore.Classes

    <Serializable>
    Public Class LocalTimeViews

        <Newtonsoft.Json.JsonProperty("endpoint_path")>
        Public Property EndpointPath As String
        <Newtonsoft.Json.JsonProperty("request")>
        Public Property Request As String

    End Class

    Public Class LocalTimeViewsResponse

        <Newtonsoft.Json.JsonProperty("market_no")>
        Public Property MarketNumber As Integer

        <Newtonsoft.Json.JsonProperty("market_name")>
        Public Property MarketName As String

        <Newtonsoft.Json.JsonProperty("network_name")>
        Public Property NetworkName As String

        <Newtonsoft.Json.JsonProperty("station_call_sign")>
        Public Property StationCallSign As String

        <Newtonsoft.Json.JsonProperty("station_no")>
        Public Property StationNumber As Integer

        <Newtonsoft.Json.JsonProperty("station_name")>
        Public Property StationName As String

        <Newtonsoft.Json.JsonProperty("qtr_hour")>
        Public Property Quarterhour As String

        <Newtonsoft.Json.JsonProperty("series_names")>
        Public Property ProgramName As String()

        <Newtonsoft.Json.JsonProperty("week")>
        Public Property Week As String

        Public Property AdjustedHour As Integer
        Public Property TotalMinutes As Integer
        Public Property QtrHrMinutes As Integer
        Public ReadOnly Property QuarterhourWeight As Decimal
            Get
                If QtrHrMinutes = 0 OrElse TotalMinutes = 0 Then
                    QuarterhourWeight = 1
                Else
                    QuarterhourWeight = QtrHrMinutes / TotalMinutes
                End If
            End Get
        End Property

        <Newtonsoft.Json.JsonProperty("1_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property HUT_01 As Decimal

        <Newtonsoft.Json.JsonProperty("1_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Universe_01 As Integer

        <Newtonsoft.Json.JsonProperty("1_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AvgAud_01 As Decimal

        <Newtonsoft.Json.JsonProperty("1_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_01 As Boolean

        <Newtonsoft.Json.JsonProperty("1_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_01 As Boolean

        <Newtonsoft.Json.JsonProperty("1_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_01 As Decimal

        <Newtonsoft.Json.JsonProperty("2_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_02 As Decimal

        <Newtonsoft.Json.JsonProperty("2_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_02 As Integer

        <Newtonsoft.Json.JsonProperty("2_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_02 As Decimal

        <Newtonsoft.Json.JsonProperty("2_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_02 As Boolean

        <Newtonsoft.Json.JsonProperty("2_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_02 As Boolean

        <Newtonsoft.Json.JsonProperty("2_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_02 As Decimal

        <Newtonsoft.Json.JsonProperty("3_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_03 As Decimal

        <Newtonsoft.Json.JsonProperty("3_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_03 As Integer

        <Newtonsoft.Json.JsonProperty("3_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_03 As Decimal

        <Newtonsoft.Json.JsonProperty("3_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_03 As Boolean

        <Newtonsoft.Json.JsonProperty("3_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_03 As Boolean

        <Newtonsoft.Json.JsonProperty("3_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_03 As Decimal

        <Newtonsoft.Json.JsonProperty("4_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_04 As Decimal

        <Newtonsoft.Json.JsonProperty("4_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_04 As Integer

        <Newtonsoft.Json.JsonProperty("4_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_04 As Decimal

        <Newtonsoft.Json.JsonProperty("4_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_04 As Boolean

        <Newtonsoft.Json.JsonProperty("4_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_04 As Boolean

        <Newtonsoft.Json.JsonProperty("4_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_04 As Decimal

        <Newtonsoft.Json.JsonProperty("5_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_05 As Decimal

        <Newtonsoft.Json.JsonProperty("5_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_05 As Integer

        <Newtonsoft.Json.JsonProperty("5_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_05 As Decimal

        <Newtonsoft.Json.JsonProperty("5_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_05 As Boolean

        <Newtonsoft.Json.JsonProperty("5_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_05 As Boolean

        <Newtonsoft.Json.JsonProperty("5_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_05 As Decimal

        <Newtonsoft.Json.JsonProperty("6_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_06 As Decimal

        <Newtonsoft.Json.JsonProperty("6_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_06 As Integer

        <Newtonsoft.Json.JsonProperty("6_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_06 As Decimal

        <Newtonsoft.Json.JsonProperty("6_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_06 As Boolean

        <Newtonsoft.Json.JsonProperty("6_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_06 As Boolean

        <Newtonsoft.Json.JsonProperty("6_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_06 As Decimal

        <Newtonsoft.Json.JsonProperty("7_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_07 As Decimal

        <Newtonsoft.Json.JsonProperty("7_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_07 As Integer

        <Newtonsoft.Json.JsonProperty("7_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_07 As Decimal

        <Newtonsoft.Json.JsonProperty("7_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_07 As Boolean

        <Newtonsoft.Json.JsonProperty("7_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_07 As Boolean

        <Newtonsoft.Json.JsonProperty("7_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_07 As Decimal

        <Newtonsoft.Json.JsonProperty("8_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_08 As Decimal

        <Newtonsoft.Json.JsonProperty("8_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_08 As Integer

        <Newtonsoft.Json.JsonProperty("8_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_08 As Decimal

        <Newtonsoft.Json.JsonProperty("8_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_08 As Boolean

        <Newtonsoft.Json.JsonProperty("8_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_08 As Boolean

        <Newtonsoft.Json.JsonProperty("8_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_08 As Decimal

        <Newtonsoft.Json.JsonProperty("9_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_09 As Decimal

        <Newtonsoft.Json.JsonProperty("9_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_09 As Integer

        <Newtonsoft.Json.JsonProperty("9_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_09 As Decimal

        <Newtonsoft.Json.JsonProperty("9_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_09 As Boolean

        <Newtonsoft.Json.JsonProperty("9_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_09 As Boolean

        <Newtonsoft.Json.JsonProperty("9_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_09 As Decimal

        <Newtonsoft.Json.JsonProperty("10_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_10 As Decimal

        <Newtonsoft.Json.JsonProperty("10_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_10 As Integer

        <Newtonsoft.Json.JsonProperty("10_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_10 As Decimal

        <Newtonsoft.Json.JsonProperty("10_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_10 As Boolean

        <Newtonsoft.Json.JsonProperty("10_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_10 As Boolean

        <Newtonsoft.Json.JsonProperty("10_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_10 As Decimal

        <Newtonsoft.Json.JsonProperty("11_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_11 As Decimal

        <Newtonsoft.Json.JsonProperty("11_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_11 As Integer

        <Newtonsoft.Json.JsonProperty("11_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_11 As Decimal

        <Newtonsoft.Json.JsonProperty("11_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_11 As Boolean

        <Newtonsoft.Json.JsonProperty("11_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_11 As Boolean

        <Newtonsoft.Json.JsonProperty("11_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_11 As Decimal

        <Newtonsoft.Json.JsonProperty("12_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_12 As Decimal

        <Newtonsoft.Json.JsonProperty("12_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_12 As Integer

        <Newtonsoft.Json.JsonProperty("12_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_12 As Decimal

        <Newtonsoft.Json.JsonProperty("12_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_12 As Boolean

        <Newtonsoft.Json.JsonProperty("12_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_12 As Boolean

        <Newtonsoft.Json.JsonProperty("12_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_12 As Decimal

        <Newtonsoft.Json.JsonProperty("13_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_13 As Decimal

        <Newtonsoft.Json.JsonProperty("13_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_13 As Integer

        <Newtonsoft.Json.JsonProperty("13_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_13 As Decimal

        <Newtonsoft.Json.JsonProperty("13_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_13 As Boolean

        <Newtonsoft.Json.JsonProperty("13_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_13 As Boolean

        <Newtonsoft.Json.JsonProperty("13_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_13 As Decimal

        <Newtonsoft.Json.JsonProperty("14_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_14 As Decimal

        <Newtonsoft.Json.JsonProperty("14_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_14 As Integer

        <Newtonsoft.Json.JsonProperty("14_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_14 As Decimal

        <Newtonsoft.Json.JsonProperty("14_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_14 As Boolean

        <Newtonsoft.Json.JsonProperty("14_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_14 As Boolean

        <Newtonsoft.Json.JsonProperty("14_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_14 As Decimal

        <Newtonsoft.Json.JsonProperty("15_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_15 As Decimal

        <Newtonsoft.Json.JsonProperty("15_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_15 As Integer

        <Newtonsoft.Json.JsonProperty("15_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_15 As Decimal

        <Newtonsoft.Json.JsonProperty("15_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_15 As Boolean

        <Newtonsoft.Json.JsonProperty("15_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_15 As Boolean

        <Newtonsoft.Json.JsonProperty("15_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_15 As Decimal

        <Newtonsoft.Json.JsonProperty("16_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_16 As Decimal

        <Newtonsoft.Json.JsonProperty("16_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_16 As Integer

        <Newtonsoft.Json.JsonProperty("16_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_16 As Decimal

        <Newtonsoft.Json.JsonProperty("16_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_16 As Boolean

        <Newtonsoft.Json.JsonProperty("16_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_16 As Boolean

        <Newtonsoft.Json.JsonProperty("16_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_16 As Decimal

        <Newtonsoft.Json.JsonProperty("17_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_17 As Decimal

        <Newtonsoft.Json.JsonProperty("17_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_17 As Integer

        <Newtonsoft.Json.JsonProperty("17_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_17 As Decimal

        <Newtonsoft.Json.JsonProperty("17_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_17 As Boolean

        <Newtonsoft.Json.JsonProperty("17_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_17 As Boolean

        <Newtonsoft.Json.JsonProperty("17_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_17 As Decimal

        <Newtonsoft.Json.JsonProperty("18_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_18 As Decimal

        <Newtonsoft.Json.JsonProperty("18_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_18 As Integer

        <Newtonsoft.Json.JsonProperty("18_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_18 As Decimal

        <Newtonsoft.Json.JsonProperty("18_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_18 As Boolean

        <Newtonsoft.Json.JsonProperty("18_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_18 As Boolean

        <Newtonsoft.Json.JsonProperty("18_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_18 As Decimal

        <Newtonsoft.Json.JsonProperty("19_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_19 As Decimal

        <Newtonsoft.Json.JsonProperty("19_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_19 As Integer

        <Newtonsoft.Json.JsonProperty("19_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_19 As Decimal

        <Newtonsoft.Json.JsonProperty("19_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_19 As Boolean

        <Newtonsoft.Json.JsonProperty("19_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_19 As Boolean

        <Newtonsoft.Json.JsonProperty("19_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_19 As Decimal

        <Newtonsoft.Json.JsonProperty("20_demo_hut")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HUT_20 As Decimal

        <Newtonsoft.Json.JsonProperty("20_demo_universe")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Universe_20 As Integer

        <Newtonsoft.Json.JsonProperty("20_demo_avg_aud")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AvgAud_20 As Decimal

        <Newtonsoft.Json.JsonProperty("20_demo_meets_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsDemoThreshold_20 As Boolean

        <Newtonsoft.Json.JsonProperty("20_demo_meets_high_quality_demo_threshold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MeetsHighQualityDemoThreshold_20 As Boolean

        <Newtonsoft.Json.JsonProperty("20_demo_share")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Share_20 As Decimal

        Public ReadOnly Property QuarterhourInt As Integer
            Get
                Dim Hour As Integer = 0
                Dim Minute As Integer = 0

                If String.IsNullOrWhiteSpace(Me.Quarterhour) = False AndAlso Me.Quarterhour.Length = 5 Then

                    Hour = CInt(Me.Quarterhour.Substring(0, 2))
                    Minute = CInt(Me.Quarterhour.Substring(3, 2))

                    If Hour < 3 Then

                        Hour += 24

                    End If

                End If

                QuarterhourInt = (Hour * 100) + Minute

            End Get
        End Property

        Public Property RequestProcessingTime As String

        Public Sub New()



        End Sub

    End Class

End Namespace