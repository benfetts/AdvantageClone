Namespace ComScore

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public Const COMSCORE_URL As String = "https://tvapi.csa.comscore.com/"
        Public Const OLD_COMSCORE_URL As String = "https://api.rentrak.com"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region "  Properties "



#End Region

#Region "  Methods "

        Private Sub SetComscoreQuarterHours(ComscoreStartTime As Date, ComscoreEndTime As Date, ByRef ComscoreQuarterHourStart As Date, ByRef ComscoreQuarterHourEnd As Date)

            Dim Remainder As Integer = 0

            If {0, 15, 30, 45}.Contains(ComscoreStartTime.Minute) AndAlso ComscoreStartTime.Hour = ComscoreEndTime.Hour AndAlso ComscoreStartTime.Minute = ComscoreEndTime.Minute Then

                ComscoreEndTime = ComscoreEndTime.AddMinutes(1)

            End If

            Remainder = ComscoreStartTime.Minute Mod 15

            If Remainder <> 0 Then

                ComscoreQuarterHourStart = ComscoreStartTime.AddMinutes(-Remainder)

            Else

                ComscoreQuarterHourStart = ComscoreStartTime

            End If

            Remainder = ComscoreEndTime.Minute Mod 15

            If Remainder <> 0 Then

                ComscoreQuarterHourEnd = ComscoreEndTime.AddMinutes(15 - Remainder)

            Else

                ComscoreQuarterHourEnd = ComscoreEndTime

            End If

        End Sub
        Private Function GetLocalTimeViewsRequest(StartDate As Date, EndDate As Date, StartTime As Date, EndTime As Date, MarketNumber As Integer, ComscoreDemoNumbers As IEnumerable(Of Integer),
                                                  StationNumbers As IEnumerable(Of Integer), DaysOfWeek As IEnumerable(Of String), ByRef JSONOrdinalComscoreDemoNumbers As Dictionary(Of Integer, Integer),
                                                  ComscoreAsClientID As String, DbContext As AdvantageFramework.Database.DbContext) As String

            'objects
            Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing
            Dim JTokenWriter As Newtonsoft.Json.Linq.JTokenWriter = Nothing
            Dim Fields As IEnumerable(Of String) = Nothing
            Dim DemoCounter As Integer = 0
            Dim LocalMarketNumber As Short = 0

            LocalMarketNumber = DbContext.Database.SqlQuery(Of Short)(String.Format("exec advsp_comscore_get_new_market_number {0}", MarketNumber)).FirstOrDefault

            Fields = {"market_no", "market_name", "network_name", "station_call_sign", "station_no", "station_name", "days_of_week", "qtr_hour", "series_names"} ' "day", "universe", "avg_aud"

            JTokenWriter = New Newtonsoft.Json.Linq.JTokenWriter()
            JTokenWriter.WriteStartObject()

            JTokenWriter.WritePropertyName("as_client_id")
            JTokenWriter.WriteValue(ComscoreAsClientID)

            JTokenWriter.WritePropertyName("fields")

            JTokenWriter.WriteStartArray()

            For Each Field In Fields

                JTokenWriter.WriteValue(Field)

            Next

            For Each ComscoreDemoNumber In ComscoreDemoNumbers

                DemoCounter += 1

                If Not JSONOrdinalComscoreDemoNumbers.ContainsKey(DemoCounter) Then

                    JSONOrdinalComscoreDemoNumbers.Add(DemoCounter, ComscoreDemoNumber)

                End If

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("hut")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_hut")
                JTokenWriter.WriteEndObject()

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("universe")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_universe")
                JTokenWriter.WriteEndObject()

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("avg_aud")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_avg_aud")
                JTokenWriter.WriteEndObject()

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("meets_demo_threshold")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_meets_demo_threshold")
                JTokenWriter.WriteEndObject()

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("meets_high_quality_demo_threshold")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_meets_high_quality_demo_threshold")
                JTokenWriter.WriteEndObject()

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("share")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_share")
                JTokenWriter.WriteEndObject()

            Next

            JTokenWriter.WriteEndArray()

            'filters
            JTokenWriter.WritePropertyName("filters")

            JTokenWriter.WriteStartArray()

            JTokenWriter.WriteStartArray()
            JTokenWriter.WriteValue("range")
            JTokenWriter.WriteValue("day")
            JTokenWriter.WriteValue(StartDate.ToString("yyyy-MM-dd"))
            JTokenWriter.WriteValue(EndDate.ToString("yyyy-MM-dd"))
            JTokenWriter.WriteEndArray()

            JTokenWriter.WriteStartArray()
            JTokenWriter.WriteValue("range")
            JTokenWriter.WriteValue("qtr_hour")
            JTokenWriter.WriteValue(StartTime.ToString("HH:mm"))
            JTokenWriter.WriteValue(EndTime.ToString("HH:mm"))
            JTokenWriter.WriteEndArray()

            JTokenWriter.WriteStartArray()
            JTokenWriter.WriteValue("eq")
            JTokenWriter.WriteValue("market_no")
            JTokenWriter.WriteValue(LocalMarketNumber)
            JTokenWriter.WriteEndArray()

            JTokenWriter.WriteStartArray()
            JTokenWriter.WriteValue("in")
            JTokenWriter.WriteValue("station_no")
            For Each StationNumber In StationNumbers

                JTokenWriter.WriteValue(StationNumber)

            Next
            JTokenWriter.WriteEndArray()

            'day_of_week
            JTokenWriter.WriteStartArray()
            JTokenWriter.WriteValue("in")
            JTokenWriter.WriteValue("day_of_week")
            For Each DayOfWeek In DaysOfWeek

                JTokenWriter.WriteValue(DayOfWeek)

            Next
            JTokenWriter.WriteEndArray()

            JTokenWriter.WriteEndArray()

            'group by
            JTokenWriter.WritePropertyName("group_by")

            JTokenWriter.WriteStartArray()
            JTokenWriter.WriteValue("market_no")
            JTokenWriter.WriteValue("station_no")
            JTokenWriter.WriteValue("network_no")
            JTokenWriter.WriteValue("qtr_hour")
            JTokenWriter.WriteEndArray()

            'optional start_of_day
            JTokenWriter.WritePropertyName("start_of_day")
            JTokenWriter.WriteValue("3:00")

            JTokenWriter.WriteEndObject()

            JObject = JTokenWriter.Token

            'If Debugger.IsAttached Then

            '    Dim file As System.IO.StreamWriter
            '    file = My.Computer.FileSystem.OpenTextFileWriter("C:\Temp\Comscore\" & Now.ToString("yyyMMddhhmmssffff") & "_REQ.txt", False)
            '    file.WriteLine(JObject)
            '    file.Close()

            'End If

            GetLocalTimeViewsRequest = JObject.ToString

        End Function
        'Private Function GetMeasurementTrendDetailsRequest(StartDate As Date, EndDate As Date, StartTime As Date, EndTime As Date, MarketNumber As Integer, ComscoreDemoNumbers As IEnumerable(Of Integer),
        '                                                   StationCallLetters As IEnumerable(Of String), DaysOfWeek As IEnumerable(Of String), ByRef JSONOrdinalComscoreDemoNumbers As Dictionary(Of Integer, Integer),
        '                                                   ComscoreAsClientID As String) As String

        '    'objects
        '    Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing
        '    Dim JTokenWriter As Newtonsoft.Json.Linq.JTokenWriter = Nothing
        '    Dim Fields As IEnumerable(Of String) = Nothing
        '    Dim DemoCounter As Integer = 0

        '    Fields = {"market_no", "market_name", "network_name", "station_call_sign", "station_no", "station_name", "days_of_week", "series_names"} ' "day", "universe", "avg_aud"

        '    JTokenWriter = New Newtonsoft.Json.Linq.JTokenWriter()
        '    JTokenWriter.WriteStartObject()

        '    JTokenWriter.WritePropertyName("as_client_id")
        '    JTokenWriter.WriteValue(ComscoreAsClientID)

        '    JTokenWriter.WritePropertyName("fields")

        '    JTokenWriter.WriteStartArray()

        '    For Each Field In Fields

        '        JTokenWriter.WriteValue(Field)

        '    Next

        '    For Each ComscoreDemoNumber In ComscoreDemoNumbers

        '        DemoCounter += 1

        '        If Not JSONOrdinalComscoreDemoNumbers.ContainsKey(DemoCounter) Then

        '            JSONOrdinalComscoreDemoNumbers.Add(DemoCounter, ComscoreDemoNumber)

        '        End If

        '        JTokenWriter.WriteStartObject()
        '        JTokenWriter.WritePropertyName("field")
        '        JTokenWriter.WriteValue("hut")
        '        JTokenWriter.WritePropertyName("demo_no")
        '        JTokenWriter.WriteValue(ComscoreDemoNumber)
        '        JTokenWriter.WritePropertyName("alias")
        '        JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_hut")
        '        JTokenWriter.WriteEndObject()

        '        JTokenWriter.WriteStartObject()
        '        JTokenWriter.WritePropertyName("field")
        '        JTokenWriter.WriteValue("universe")
        '        JTokenWriter.WritePropertyName("demo_no")
        '        JTokenWriter.WriteValue(ComscoreDemoNumber)
        '        JTokenWriter.WritePropertyName("alias")
        '        JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_universe")
        '        JTokenWriter.WriteEndObject()

        '        JTokenWriter.WriteStartObject()
        '        JTokenWriter.WritePropertyName("field")
        '        JTokenWriter.WriteValue("avg_aud")
        '        JTokenWriter.WritePropertyName("demo_no")
        '        JTokenWriter.WriteValue(ComscoreDemoNumber)
        '        JTokenWriter.WritePropertyName("alias")
        '        JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_avg_aud")
        '        JTokenWriter.WriteEndObject()

        '        JTokenWriter.WriteStartObject()
        '        JTokenWriter.WritePropertyName("field")
        '        JTokenWriter.WriteValue("meets_demo_threshold")
        '        JTokenWriter.WritePropertyName("demo_no")
        '        JTokenWriter.WriteValue(ComscoreDemoNumber)
        '        JTokenWriter.WritePropertyName("alias")
        '        JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_meets_demo_threshold")
        '        JTokenWriter.WriteEndObject()

        '        JTokenWriter.WriteStartObject()
        '        JTokenWriter.WritePropertyName("field")
        '        JTokenWriter.WriteValue("meets_high_quality_demo_threshold")
        '        JTokenWriter.WritePropertyName("demo_no")
        '        JTokenWriter.WriteValue(ComscoreDemoNumber)
        '        JTokenWriter.WritePropertyName("alias")
        '        JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_meets_high_quality_demo_threshold")
        '        JTokenWriter.WriteEndObject()

        '        JTokenWriter.WriteStartObject()
        '        JTokenWriter.WritePropertyName("field")
        '        JTokenWriter.WriteValue("share")
        '        JTokenWriter.WritePropertyName("demo_no")
        '        JTokenWriter.WriteValue(ComscoreDemoNumber)
        '        JTokenWriter.WritePropertyName("alias")
        '        JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_share")
        '        JTokenWriter.WriteEndObject()

        '    Next

        '    JTokenWriter.WriteEndArray()

        '    'filters
        '    JTokenWriter.WritePropertyName("filters")

        '    JTokenWriter.WriteStartArray()

        '    JTokenWriter.WriteStartArray()
        '    JTokenWriter.WriteValue("range")
        '    JTokenWriter.WriteValue("day")
        '    JTokenWriter.WriteValue(StartDate.ToString("yyyy-MM-dd"))
        '    JTokenWriter.WriteValue(EndDate.ToString("yyyy-MM-dd"))
        '    JTokenWriter.WriteEndArray()

        '    JTokenWriter.WriteStartArray()
        '    JTokenWriter.WriteValue("range")
        '    JTokenWriter.WriteValue("qtr_hour")
        '    JTokenWriter.WriteValue(StartTime.ToString("HH:mm"))
        '    JTokenWriter.WriteValue(EndTime.ToString("HH:mm"))
        '    JTokenWriter.WriteEndArray()

        '    JTokenWriter.WriteStartArray()
        '    JTokenWriter.WriteValue("eq")
        '    JTokenWriter.WriteValue("market_no")
        '    JTokenWriter.WriteValue(MarketNumber)
        '    JTokenWriter.WriteEndArray()

        '    JTokenWriter.WriteStartArray()
        '    JTokenWriter.WriteValue("in")
        '    JTokenWriter.WriteValue("station_call_sign")
        '    For Each StationCallLetter In StationCallLetters

        '        JTokenWriter.WriteValue(StationCallLetter)

        '    Next
        '    JTokenWriter.WriteEndArray()

        '    'day_of_week
        '    JTokenWriter.WriteStartArray()
        '    JTokenWriter.WriteValue("in")
        '    JTokenWriter.WriteValue("day_of_week")
        '    For Each DayOfWeek In DaysOfWeek

        '        JTokenWriter.WriteValue(DayOfWeek)

        '    Next
        '    JTokenWriter.WriteEndArray()

        '    JTokenWriter.WriteEndArray()

        '    'group by
        '    JTokenWriter.WritePropertyName("group_by")

        '    JTokenWriter.WriteStartArray()
        '    JTokenWriter.WriteValue("market_no")
        '    JTokenWriter.WriteValue("station_no")
        '    JTokenWriter.WriteValue("network_no")
        '    JTokenWriter.WriteEndArray()

        '    'optional start_of_day
        '    JTokenWriter.WritePropertyName("start_of_day")
        '    JTokenWriter.WriteValue("3:00")

        '    JTokenWriter.WriteEndObject()

        '    JObject = JTokenWriter.Token

        '    GetMeasurementTrendDetailsRequest = JObject.ToString

        'End Function
        'Private Function GetLeadInLeadOutDetailsRequest(StartDate As Date, EndDate As Date, StartTime As Date, EndTime As Date, MarketNumber As Integer, ComscoreDemoNumbers As IEnumerable(Of Integer),
        '                                                StationCallLetters As IEnumerable(Of String), DaysOfWeek As IEnumerable(Of String), ByRef JSONOrdinalComscoreDemoNumbers As Dictionary(Of Integer, Integer),
        '                                                ComscoreAsClientID As String, Week As Date) As String

        '    'objects
        '    Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing
        '    Dim JTokenWriter As Newtonsoft.Json.Linq.JTokenWriter = Nothing
        '    Dim Fields As IEnumerable(Of String) = Nothing
        '    Dim DemoCounter As Integer = 0

        '    Fields = {"market_no", "market_name", "network_name", "station_call_sign", "station_no", "station_name", "days_of_week", "qtr_hour", "week", "series_names"} ' "day", "universe", "avg_aud"

        '    JTokenWriter = New Newtonsoft.Json.Linq.JTokenWriter()
        '    JTokenWriter.WriteStartObject()

        '    JTokenWriter.WritePropertyName("as_client_id")
        '    JTokenWriter.WriteValue(ComscoreAsClientID)

        '    JTokenWriter.WritePropertyName("fields")

        '    JTokenWriter.WriteStartArray()

        '    For Each Field In Fields

        '        JTokenWriter.WriteValue(Field)

        '    Next

        '    For Each ComscoreDemoNumber In ComscoreDemoNumbers

        '        DemoCounter += 1

        '        If Not JSONOrdinalComscoreDemoNumbers.ContainsKey(DemoCounter) Then

        '            JSONOrdinalComscoreDemoNumbers.Add(DemoCounter, ComscoreDemoNumber)

        '        End If

        '        JTokenWriter.WriteStartObject()
        '        JTokenWriter.WritePropertyName("field")
        '        JTokenWriter.WriteValue("hut")
        '        JTokenWriter.WritePropertyName("demo_no")
        '        JTokenWriter.WriteValue(ComscoreDemoNumber)
        '        JTokenWriter.WritePropertyName("alias")
        '        JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_hut")
        '        JTokenWriter.WriteEndObject()

        '        JTokenWriter.WriteStartObject()
        '        JTokenWriter.WritePropertyName("field")
        '        JTokenWriter.WriteValue("universe")
        '        JTokenWriter.WritePropertyName("demo_no")
        '        JTokenWriter.WriteValue(ComscoreDemoNumber)
        '        JTokenWriter.WritePropertyName("alias")
        '        JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_universe")
        '        JTokenWriter.WriteEndObject()

        '        JTokenWriter.WriteStartObject()
        '        JTokenWriter.WritePropertyName("field")
        '        JTokenWriter.WriteValue("avg_aud")
        '        JTokenWriter.WritePropertyName("demo_no")
        '        JTokenWriter.WriteValue(ComscoreDemoNumber)
        '        JTokenWriter.WritePropertyName("alias")
        '        JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_avg_aud")
        '        JTokenWriter.WriteEndObject()

        '        JTokenWriter.WriteStartObject()
        '        JTokenWriter.WritePropertyName("field")
        '        JTokenWriter.WriteValue("meets_demo_threshold")
        '        JTokenWriter.WritePropertyName("demo_no")
        '        JTokenWriter.WriteValue(ComscoreDemoNumber)
        '        JTokenWriter.WritePropertyName("alias")
        '        JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_meets_demo_threshold")
        '        JTokenWriter.WriteEndObject()

        '        JTokenWriter.WriteStartObject()
        '        JTokenWriter.WritePropertyName("field")
        '        JTokenWriter.WriteValue("meets_high_quality_demo_threshold")
        '        JTokenWriter.WritePropertyName("demo_no")
        '        JTokenWriter.WriteValue(ComscoreDemoNumber)
        '        JTokenWriter.WritePropertyName("alias")
        '        JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_meets_high_quality_demo_threshold")
        '        JTokenWriter.WriteEndObject()

        '        JTokenWriter.WriteStartObject()
        '        JTokenWriter.WritePropertyName("field")
        '        JTokenWriter.WriteValue("share")
        '        JTokenWriter.WritePropertyName("demo_no")
        '        JTokenWriter.WriteValue(ComscoreDemoNumber)
        '        JTokenWriter.WritePropertyName("alias")
        '        JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_share")
        '        JTokenWriter.WriteEndObject()

        '    Next

        '    JTokenWriter.WriteEndArray()

        '    'filters
        '    JTokenWriter.WritePropertyName("filters")

        '    JTokenWriter.WriteStartArray()

        '    JTokenWriter.WriteStartArray()
        '    JTokenWriter.WriteValue("range")
        '    JTokenWriter.WriteValue("day")
        '    JTokenWriter.WriteValue(StartDate.ToString("yyyy-MM-dd"))
        '    JTokenWriter.WriteValue(EndDate.ToString("yyyy-MM-dd"))
        '    JTokenWriter.WriteEndArray()

        '    JTokenWriter.WriteStartArray()
        '    JTokenWriter.WriteValue("range")
        '    JTokenWriter.WriteValue("qtr_hour")
        '    JTokenWriter.WriteValue(StartTime.ToString("HH:mm"))
        '    JTokenWriter.WriteValue(EndTime.ToString("HH:mm"))
        '    JTokenWriter.WriteEndArray()

        '    JTokenWriter.WriteStartArray()
        '    JTokenWriter.WriteValue("eq")
        '    JTokenWriter.WriteValue("market_no")
        '    JTokenWriter.WriteValue(MarketNumber)
        '    JTokenWriter.WriteEndArray()

        '    JTokenWriter.WriteStartArray()
        '    JTokenWriter.WriteValue("in")
        '    JTokenWriter.WriteValue("station_call_sign")
        '    For Each StationCallLetter In StationCallLetters

        '        JTokenWriter.WriteValue(StationCallLetter)

        '    Next
        '    JTokenWriter.WriteEndArray()

        '    'day_of_week
        '    JTokenWriter.WriteStartArray()
        '    JTokenWriter.WriteValue("in")
        '    JTokenWriter.WriteValue("day_of_week")
        '    For Each DayOfWeek In DaysOfWeek

        '        JTokenWriter.WriteValue(DayOfWeek)

        '    Next
        '    JTokenWriter.WriteEndArray()

        '    If Week <> Date.MinValue Then

        '        JTokenWriter.WriteStartArray()
        '        JTokenWriter.WriteValue("eq")
        '        JTokenWriter.WriteValue("week")
        '        JTokenWriter.WriteValue(Week.ToString("yyyy-MM-dd"))
        '        JTokenWriter.WriteEndArray()

        '    End If

        '    JTokenWriter.WriteEndArray()

        '    'group by
        '    JTokenWriter.WritePropertyName("group_by")

        '    JTokenWriter.WriteStartArray()
        '    JTokenWriter.WriteValue("market_no")
        '    JTokenWriter.WriteValue("station_no")
        '    JTokenWriter.WriteValue("network_no")
        '    JTokenWriter.WriteValue("qtr_hour")
        '    JTokenWriter.WriteEndArray()

        '    'optional start_of_day
        '    JTokenWriter.WritePropertyName("start_of_day")
        '    JTokenWriter.WriteValue("3:00")

        '    JTokenWriter.WriteEndObject()

        '    JObject = JTokenWriter.Token

        '    GetLeadInLeadOutDetailsRequest = JObject.ToString

        'End Function
        Private Function GetStreamDescription(Stream As String) As String

            'objects
            Dim StreamDescription As String = ""

            Select Case Stream
                Case "LO"
                    StreamDescription = "L"
                Case "LS"
                    StreamDescription = "LS"
                Case "L1"
                    StreamDescription = "L1"
                Case "L3"
                    StreamDescription = "L3"
                Case "L7"
                    StreamDescription = "L7"
            End Select

            GetStreamDescription = StreamDescription

        End Function
        Private Function GetHPUT(DemoNumber As Integer, ShareHUT As Decimal, HUTLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView),
                                 MarketNumber As Integer, StationNumber As Integer, ByRef UseHUT As Boolean) As Decimal

            'objects
            Dim HPUT As Nullable(Of Decimal) = Nothing
            Dim ComscoreLocalTimeView As AdvantageFramework.DTO.Media.ComscoreLocalTimeView = Nothing

            HPUT = ShareHUT

            If HUTLocalTimeViewList IsNot Nothing Then

                ComscoreLocalTimeView = (From Entity In HUTLocalTimeViewList
                                         Where Entity.MarketNumber = MarketNumber AndAlso
                                               Entity.StationNumber = StationNumber
                                         Select Entity).SingleOrDefault

                If ComscoreLocalTimeView IsNot Nothing Then

                    UseHUT = True

                    If DemoNumber = 1 Then

                        HPUT = ComscoreLocalTimeView.HUT_01

                    ElseIf DemoNumber = 2 Then

                        HPUT = ComscoreLocalTimeView.HUT_02

                    ElseIf DemoNumber = 3 Then

                        HPUT = ComscoreLocalTimeView.HUT_03

                    ElseIf DemoNumber = 4 Then

                        HPUT = ComscoreLocalTimeView.HUT_04

                    ElseIf DemoNumber = 5 Then

                        HPUT = ComscoreLocalTimeView.HUT_05

                    ElseIf DemoNumber = 6 Then

                        HPUT = ComscoreLocalTimeView.HUT_06

                    ElseIf DemoNumber = 7 Then

                        HPUT = ComscoreLocalTimeView.HUT_07

                    ElseIf DemoNumber = 8 Then

                        HPUT = ComscoreLocalTimeView.HUT_08

                    ElseIf DemoNumber = 9 Then

                        HPUT = ComscoreLocalTimeView.HUT_09

                    ElseIf DemoNumber = 10 Then

                        HPUT = ComscoreLocalTimeView.HUT_10

                    ElseIf DemoNumber = 11 Then

                        HPUT = ComscoreLocalTimeView.HUT_11

                    ElseIf DemoNumber = 12 Then

                        HPUT = ComscoreLocalTimeView.HUT_12

                    ElseIf DemoNumber = 13 Then

                        HPUT = ComscoreLocalTimeView.HUT_13

                    ElseIf DemoNumber = 14 Then

                        HPUT = ComscoreLocalTimeView.HUT_14

                    ElseIf DemoNumber = 15 Then

                        HPUT = ComscoreLocalTimeView.HUT_15

                    ElseIf DemoNumber = 16 Then

                        HPUT = ComscoreLocalTimeView.HUT_16

                    ElseIf DemoNumber = 17 Then

                        HPUT = ComscoreLocalTimeView.HUT_17

                    ElseIf DemoNumber = 18 Then

                        HPUT = ComscoreLocalTimeView.HUT_18

                    ElseIf DemoNumber = 19 Then

                        HPUT = ComscoreLocalTimeView.HUT_19

                    ElseIf DemoNumber = 20 Then

                        HPUT = ComscoreLocalTimeView.HUT_20

                    End If

                End If

            End If

            GetHPUT = HPUT

        End Function
        Private Function GetHUTDemoThreshold(DemoNumber As Integer, MarketNumber As Integer, StationNumber As Integer, HUTLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView)) As Boolean

            'objects
            Dim DemoThreshold As Boolean = False
            Dim ComscoreLocalTimeView As AdvantageFramework.DTO.Media.ComscoreLocalTimeView = Nothing

            If HUTLocalTimeViewList IsNot Nothing Then

                ComscoreLocalTimeView = (From Entity In HUTLocalTimeViewList
                                         Where Entity.MarketNumber = MarketNumber AndAlso
                                               Entity.StationNumber = StationNumber
                                         Select Entity).SingleOrDefault

                If ComscoreLocalTimeView IsNot Nothing Then

                    If DemoNumber = 1 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_01

                    ElseIf DemoNumber = 2 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_02

                    ElseIf DemoNumber = 3 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_03

                    ElseIf DemoNumber = 4 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_04

                    ElseIf DemoNumber = 5 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_05

                    ElseIf DemoNumber = 6 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_06

                    ElseIf DemoNumber = 7 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_07

                    ElseIf DemoNumber = 8 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_08

                    ElseIf DemoNumber = 9 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_09

                    ElseIf DemoNumber = 10 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_10

                    ElseIf DemoNumber = 11 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_11

                    ElseIf DemoNumber = 12 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_12

                    ElseIf DemoNumber = 13 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_13

                    ElseIf DemoNumber = 14 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_14

                    ElseIf DemoNumber = 15 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_15

                    ElseIf DemoNumber = 16 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_16

                    ElseIf DemoNumber = 17 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_17

                    ElseIf DemoNumber = 18 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_18

                    ElseIf DemoNumber = 19 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_19

                    ElseIf DemoNumber = 20 Then

                        DemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_20

                    End If

                End If

            End If

            GetHUTDemoThreshold = DemoThreshold

        End Function
        Private Function GetHUTHighQualityDemoThreshold(DemoNumber As Integer, MarketNumber As Integer, StationNumber As Integer, HUTLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView)) As Boolean

            'objects
            Dim HighQualityDemoThreshold As Boolean = False
            Dim ComscoreLocalTimeView As AdvantageFramework.DTO.Media.ComscoreLocalTimeView = Nothing

            If HUTLocalTimeViewList IsNot Nothing Then

                ComscoreLocalTimeView = (From Entity In HUTLocalTimeViewList
                                         Where Entity.MarketNumber = MarketNumber AndAlso
                                               Entity.StationNumber = StationNumber
                                         Select Entity).SingleOrDefault

                If ComscoreLocalTimeView IsNot Nothing Then

                    If DemoNumber = 1 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_01

                    ElseIf DemoNumber = 2 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_02

                    ElseIf DemoNumber = 3 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_03

                    ElseIf DemoNumber = 4 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_04

                    ElseIf DemoNumber = 5 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_05

                    ElseIf DemoNumber = 6 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_06

                    ElseIf DemoNumber = 7 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_07

                    ElseIf DemoNumber = 8 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_08

                    ElseIf DemoNumber = 9 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_09

                    ElseIf DemoNumber = 10 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_10

                    ElseIf DemoNumber = 11 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_11

                    ElseIf DemoNumber = 12 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_12

                    ElseIf DemoNumber = 13 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_13

                    ElseIf DemoNumber = 14 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_14

                    ElseIf DemoNumber = 15 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_15

                    ElseIf DemoNumber = 16 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_16

                    ElseIf DemoNumber = 17 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_17

                    ElseIf DemoNumber = 18 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_18

                    ElseIf DemoNumber = 19 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_19

                    ElseIf DemoNumber = 20 Then

                        HighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_20

                    End If

                End If

            End If

            GetHUTHighQualityDemoThreshold = HighQualityDemoThreshold

        End Function
        Private Sub SetDemoSpecificValues(DemoNumber As Integer, ComscoreLocalTimeView As AdvantageFramework.DTO.Media.ComscoreLocalTimeView, HUTLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView),
                                          ByRef ResearchResult As AdvantageFramework.DTO.Media.SpotTV.ResearchResult)

            'objects
            Dim UseHUT As Boolean = False

            If DemoNumber = 1 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_01
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_01, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_01

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_01
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_01 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_01 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_01 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 2 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_02
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_02, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_02

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_02
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_02 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_02 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_02 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 3 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_03
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_03, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_03

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_03
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_03 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_03 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_03 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 4 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_04
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_04, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_04

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_04
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_04 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_04 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_04 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 5 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_05
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_05, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_05

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_05
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_05 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_05 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_05 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 6 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_06
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_06, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_06

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_06
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_06 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_06 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_06 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 7 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_07
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_07, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_07

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_07
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_07 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_07 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_07 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 8 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_08
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_08, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_08

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_08
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_08 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_08 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_08 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 9 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_09
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_09, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_09

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_09
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_09 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_09 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_09 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 10 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_10
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_10, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_10

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_10
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_10 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_10 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_10 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 11 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_11
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_11, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_11

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_11
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_11 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_11 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_11 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 12 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_12
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_12, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_12

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_12
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_12 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_12 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_12 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 13 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_13
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_13, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_13

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_13
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_13 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_13 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_13 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 14 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_14
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_14, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_14

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_14
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_14 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_14 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_14 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 15 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_15
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_15, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_15

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_15
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_15 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_15 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_15 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 16 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_16
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_16, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_16

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_16
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_16 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_16 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_16 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 17 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_17
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_17, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_17

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_17
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_17 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_17 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_17 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 18 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_18
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_18, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_18

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_18
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_18 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_18 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_18 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 19 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_19
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_19, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_19

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_19
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_19 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_19 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_19 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 20 Then

                ResearchResult.Share = ComscoreLocalTimeView.Share_20
                ResearchResult.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_20, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                ResearchResult.Universe = ComscoreLocalTimeView.Universe_20

                If UseHUT Then

                    ResearchResult.Rating = ResearchResult.Share * ResearchResult.HPUT / 100
                    ResearchResult.Impressions = ResearchResult.Rating * ResearchResult.Universe / 100000

                Else

                    ResearchResult.Rating = ComscoreLocalTimeView.Rating_20
                    ResearchResult.Impressions = ComscoreLocalTimeView.AvgAud_20 / 1000

                End If

                ResearchResult.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_20 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                ResearchResult.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_20 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            End If

        End Sub
        Private Function GetDaysOfWeek(DaysAndTime As AdvantageFramework.DTO.DaysAndTime) As IEnumerable(Of String)

            'objects
            Dim DaysOfWeek As Generic.List(Of String) = Nothing

            DaysOfWeek = New Generic.List(Of String)

            If DaysAndTime.Sunday Then

                DaysOfWeek.Add("sun")

            End If

            If DaysAndTime.Monday Then

                DaysOfWeek.Add("mon")

            End If

            If DaysAndTime.Tuesday Then

                DaysOfWeek.Add("tue")

            End If

            If DaysAndTime.Wednesday Then

                DaysOfWeek.Add("wed")

            End If

            If DaysAndTime.Thursday Then

                DaysOfWeek.Add("thu")

            End If

            If DaysAndTime.Friday Then

                DaysOfWeek.Add("fri")

            End If

            If DaysAndTime.Saturday Then

                DaysOfWeek.Add("sat")

            End If

            GetDaysOfWeek = DaysOfWeek.ToArray

        End Function
        Private Sub GetBookData(UseNewURL As Boolean, ComscoreClientID As String, ComscoreClientSecret As String, LocalTimeViews As Services.ComScore.Classes.LocalTimeViews, ComscoreStartTime As Date, ComscoreEndTime As Date,
                                ByRef ComscoreLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView), Optional ByRef ComscoreToolResponse As Object = Nothing)

            'objects
            Dim JSONString As String = Nothing
            Dim Api As Services.ComScore.Classes.Api = Nothing
            Dim Request As Services.ComScore.Classes.Request = Nothing
            Dim Response As Services.ComScore.Classes.Response = Nothing
            Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing
            Dim JArrayColumns As Newtonsoft.Json.Linq.JArray = Nothing
            Dim Columns As List(Of String) = Nothing
            Dim JArray As Newtonsoft.Json.Linq.JArray = Nothing
            Dim LocalTimeViewsResponse As Services.ComScore.Classes.LocalTimeViewsResponse = Nothing
            Dim JsonPropertyAttribute As Newtonsoft.Json.JsonPropertyAttribute = Nothing
            Dim UnderlyingType As System.Type = Nothing
            Dim ComscoreLocalTimeViewsResponseList As Generic.List(Of Services.ComScore.Classes.LocalTimeViewsResponse) = Nothing
            Dim ProgramNames As Generic.List(Of String) = Nothing
            Dim ComscoreLocalTimeView As AdvantageFramework.DTO.Media.ComscoreLocalTimeView = Nothing

            ComscoreLocalTimeViewsResponseList = New Generic.List(Of Services.ComScore.Classes.LocalTimeViewsResponse)

            JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(LocalTimeViews)

            If UseNewURL Then

                Api = New Services.ComScore.Classes.Api(New Uri(AdvantageFramework.ComScore.COMSCORE_URL), ComscoreClientID, ComscoreClientSecret, 0)

            Else

                Api = New Services.ComScore.Classes.Api(New Uri(AdvantageFramework.ComScore.OLD_COMSCORE_URL), ComscoreClientID, ComscoreClientSecret, 0)

            End If

            Request = New Services.ComScore.Classes.Request(JSONString)

            Do While Request IsNot Nothing

                Response = Api.RetrievePage(Request)

                If Response IsNot Nothing AndAlso Response.Status = "success" Then

                    JObject = Newtonsoft.Json.Linq.JObject.Parse(Response.RawResponse)

                    ComscoreToolResponse = Response.RawResponse

                    'If Debugger.IsAttached Then

                    '    Dim file As System.IO.StreamWriter
                    '    file = My.Computer.FileSystem.OpenTextFileWriter("C:\Temp\Comscore\" & Now.ToString("yyyMMddhhmmssffff") & "_RESP.txt", False)
                    '    file.WriteLine(JObject)
                    '    file.Close()

                    'End If

                    JArrayColumns = Newtonsoft.Json.Linq.JArray.Parse(JObject.SelectToken("result_columns").ToString)

                    Columns = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of String))(JArrayColumns.ToString)

                    JArray = Newtonsoft.Json.Linq.JArray.Parse(JObject.SelectToken("result_rows").ToString)

                    For i As Integer = 0 To JArray.Count - 1

                        LocalTimeViewsResponse = New Services.ComScore.Classes.LocalTimeViewsResponse

                        For Each Column In Columns

                            For Each PropertyInfo In LocalTimeViewsResponse.GetType.GetProperties

                                JsonPropertyAttribute = (From A In PropertyInfo.GetCustomAttributes(False).OfType(Of Newtonsoft.Json.JsonPropertyAttribute)
                                                         Where A.PropertyName = Column).SingleOrDefault

                                If JsonPropertyAttribute IsNot Nothing Then

                                    UnderlyingType = AdvantageFramework.ClassUtilities.GetUnderlyingType(PropertyInfo.PropertyType)

                                    If UnderlyingType Is GetType(String) Then

                                        PropertyInfo.SetValue(LocalTimeViewsResponse, JArray(i).Item(Columns.IndexOf(Column)).ToString)
                                        Exit For

                                    ElseIf UnderlyingType Is GetType(Decimal) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(LocalTimeViewsResponse, CDec(JArray(i).Item(Columns.IndexOf(Column))))
                                            Exit For

                                        End If

                                    ElseIf UnderlyingType Is GetType(Integer) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(LocalTimeViewsResponse, CInt(JArray(i).Item(Columns.IndexOf(Column))))
                                            Exit For

                                        End If

                                    ElseIf UnderlyingType Is GetType(System.String()) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(LocalTimeViewsResponse, JArray(i).Item(Columns.IndexOf(Column)).ToObject(Of System.String()))
                                            Exit For

                                        End If

                                    ElseIf UnderlyingType Is GetType(Boolean) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(LocalTimeViewsResponse, CBool(JArray(i).Item(Columns.IndexOf(Column))))
                                            Exit For

                                        End If

                                    End If

                                End If

                            Next

                        Next

                        LocalTimeViewsResponse.RequestProcessingTime = Response.ApiTime.TotalSeconds

                        ComscoreLocalTimeViewsResponseList.Add(LocalTimeViewsResponse)

                    Next

                    Request = Api.NextPageRequest(Response)

                Else

                    Request = Nothing

                End If

            Loop

            ComscoreLocalTimeViewList = AggregateMetricsByMinuteWeights(ComscoreLocalTimeViewsResponseList, ComscoreStartTime, ComscoreEndTime)

            ProgramNames = New Generic.List(Of String)

            For Each Station In ComscoreLocalTimeViewsResponseList.Select(Function(Entity) Entity.StationNumber).Distinct.ToList

                For Each ComscoreLocalTimeViewsResponse In ComscoreLocalTimeViewsResponseList.Where(Function(Entity) Entity.StationNumber = Station).ToList.OrderBy(Function(Entity) Entity.QuarterhourInt)

                    For Each Program In ComscoreLocalTimeViewsResponse.ProgramName()

                        If Not ProgramNames.Contains(Program) Then

                            ProgramNames.Add(Program)

                        End If

                    Next

                Next

                ComscoreLocalTimeView = ComscoreLocalTimeViewList.Where(Function(Entity) Entity.StationNumber = Station).First

                If ProgramNames.Count > 2 Then

                    ComscoreLocalTimeView.ProgramName = "Various"

                Else

                    ComscoreLocalTimeView.ProgramName = String.Join("/", ProgramNames.ToArray)

                End If

                ProgramNames.Clear()

            Next

        End Sub
        'Private Sub GetBookDataForMeasurementTrendDetails(ComscoreClientID As String, ComscoreClientSecret As String, LocalTimeViews As Services.ComScore.Classes.LocalTimeViews, ComscoreStartTime As Date, ComscoreEndTime As Date,
        '                                                  ByRef ComscoreLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView))

        '    'objects
        '    Dim JSONString As String = Nothing
        '    Dim Api As Services.ComScore.Classes.Api = Nothing
        '    Dim Request As Services.ComScore.Classes.Request = Nothing
        '    Dim Response As Services.ComScore.Classes.Response = Nothing
        '    Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing
        '    Dim JArrayColumns As Newtonsoft.Json.Linq.JArray = Nothing
        '    Dim Columns As List(Of String) = Nothing
        '    Dim JArray As Newtonsoft.Json.Linq.JArray = Nothing
        '    Dim LocalTimeViewsResponse As Services.ComScore.Classes.LocalTimeViewsResponse = Nothing
        '    Dim JsonPropertyAttribute As Newtonsoft.Json.JsonPropertyAttribute = Nothing
        '    Dim UnderlyingType As System.Type = Nothing
        '    Dim ComscoreLocalTimeViewsResponseList As Generic.List(Of Services.ComScore.Classes.LocalTimeViewsResponse) = Nothing
        '    Dim ProgramNames As Generic.List(Of String) = Nothing
        '    Dim ComscoreLocalTimeView As AdvantageFramework.DTO.Media.ComscoreLocalTimeView = Nothing

        '    ComscoreLocalTimeViewsResponseList = New Generic.List(Of Services.ComScore.Classes.LocalTimeViewsResponse)

        '    JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(LocalTimeViews)

        '    Api = New Services.ComScore.Classes.Api(New Uri(AdvantageFramework.ComScore.COMSCORE_URL), ComscoreClientID, ComscoreClientSecret, 0)

        '    Request = New Services.ComScore.Classes.Request(JSONString)

        '    Do While Request IsNot Nothing

        '        Response = Api.RetrievePage(Request)

        '        If Response IsNot Nothing AndAlso Response.Status = "success" Then

        '            JObject = Newtonsoft.Json.Linq.JObject.Parse(Response.RawResponse)

        '            JArrayColumns = Newtonsoft.Json.Linq.JArray.Parse(JObject.SelectToken("result_columns").ToString)

        '            Columns = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of String))(JArrayColumns.ToString)

        '            JArray = Newtonsoft.Json.Linq.JArray.Parse(JObject.SelectToken("result_rows").ToString)

        '            For i As Integer = 0 To JArray.Count - 1

        '                LocalTimeViewsResponse = New Services.ComScore.Classes.LocalTimeViewsResponse

        '                For Each Column In Columns

        '                    For Each PropertyInfo In LocalTimeViewsResponse.GetType.GetProperties

        '                        JsonPropertyAttribute = (From A In PropertyInfo.GetCustomAttributes(False).OfType(Of Newtonsoft.Json.JsonPropertyAttribute)
        '                                                 Where A.PropertyName = Column).SingleOrDefault

        '                        If JsonPropertyAttribute IsNot Nothing Then

        '                            UnderlyingType = AdvantageFramework.ClassUtilities.GetUnderlyingType(PropertyInfo.PropertyType)

        '                            If UnderlyingType Is GetType(String) Then

        '                                PropertyInfo.SetValue(LocalTimeViewsResponse, JArray(i).Item(Columns.IndexOf(Column)).ToString)
        '                                Exit For

        '                            ElseIf UnderlyingType Is GetType(Decimal) Then

        '                                If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

        '                                    PropertyInfo.SetValue(LocalTimeViewsResponse, CDec(JArray(i).Item(Columns.IndexOf(Column))))
        '                                    Exit For

        '                                End If

        '                            ElseIf UnderlyingType Is GetType(Integer) Then

        '                                If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

        '                                    PropertyInfo.SetValue(LocalTimeViewsResponse, CInt(JArray(i).Item(Columns.IndexOf(Column))))
        '                                    Exit For

        '                                End If

        '                            ElseIf UnderlyingType Is GetType(System.String()) Then

        '                                If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

        '                                    PropertyInfo.SetValue(LocalTimeViewsResponse, JArray(i).Item(Columns.IndexOf(Column)).ToObject(Of System.String()))
        '                                    Exit For

        '                                End If

        '                            ElseIf UnderlyingType Is GetType(Boolean) Then

        '                                If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

        '                                    PropertyInfo.SetValue(LocalTimeViewsResponse, CBool(JArray(i).Item(Columns.IndexOf(Column))))
        '                                    Exit For

        '                                End If

        '                            End If

        '                        End If

        '                    Next

        '                Next

        '                ComscoreLocalTimeViewsResponseList.Add(LocalTimeViewsResponse)

        '            Next

        '            Request = Api.NextPageRequest(Response)

        '        Else

        '            Request = Nothing

        '        End If

        '    Loop

        '    ComscoreLocalTimeViewList = AggregateMetricsByMinuteWeightsForMeasurementTrendDetails(ComscoreLocalTimeViewsResponseList, ComscoreStartTime, ComscoreEndTime)

        '    ProgramNames = New Generic.List(Of String)

        '    ' For Each Week In ComscoreLocalTimeViewsResponseList.Select(Function(Entity) Entity.Week).Distinct.ToList

        '    For Each ComscoreLocalTimeViewsResponse In ComscoreLocalTimeViewsResponseList.ToList

        '        'For Each Program In ComscoreLocalTimeViewsResponse.ProgramName()

        '        '    If Not ProgramNames.Contains(Program) Then

        '        '        ProgramNames.Add(Program)

        '        '    End If

        '        'Next

        '        ComscoreLocalTimeView = ComscoreLocalTimeViewList.FirstOrDefault

        '        If ComscoreLocalTimeViewsResponse.ProgramName.Count > 2 Then

        '            ComscoreLocalTimeView.ProgramName = "Various"

        '        Else

        '            ComscoreLocalTimeView.ProgramName = String.Join("/", ComscoreLocalTimeViewsResponse.ProgramName.ToArray)

        '        End If

        '        ProgramNames.Clear()

        '    Next

        '    'Next

        'End Sub
        'Private Sub GetBookDataForLeadInLeadOutDetails(ComscoreClientID As String, ComscoreClientSecret As String, LocalTimeViews As Services.ComScore.Classes.LocalTimeViews, ComscoreStartTime As Date, ComscoreEndTime As Date,
        '                                               ByRef ComscoreLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView))

        '    'objects
        '    Dim JSONString As String = Nothing
        '    Dim Api As Services.ComScore.Classes.Api = Nothing
        '    Dim Request As Services.ComScore.Classes.Request = Nothing
        '    Dim Response As Services.ComScore.Classes.Response = Nothing
        '    Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing
        '    Dim JArrayColumns As Newtonsoft.Json.Linq.JArray = Nothing
        '    Dim Columns As List(Of String) = Nothing
        '    Dim JArray As Newtonsoft.Json.Linq.JArray = Nothing
        '    Dim LocalTimeViewsResponse As Services.ComScore.Classes.LocalTimeViewsResponse = Nothing
        '    Dim JsonPropertyAttribute As Newtonsoft.Json.JsonPropertyAttribute = Nothing
        '    Dim UnderlyingType As System.Type = Nothing
        '    Dim ComscoreLocalTimeViewsResponseList As Generic.List(Of Services.ComScore.Classes.LocalTimeViewsResponse) = Nothing
        '    Dim ProgramNames As Generic.List(Of String) = Nothing
        '    Dim ComscoreLocalTimeView As AdvantageFramework.DTO.Media.ComscoreLocalTimeView = Nothing

        '    ComscoreLocalTimeViewsResponseList = New Generic.List(Of Services.ComScore.Classes.LocalTimeViewsResponse)

        '    JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(LocalTimeViews)

        '    Api = New Services.ComScore.Classes.Api(New Uri(AdvantageFramework.ComScore.COMSCORE_URL), ComscoreClientID, ComscoreClientSecret, 0)

        '    Request = New Services.ComScore.Classes.Request(JSONString)

        '    Do While Request IsNot Nothing

        '        Response = Api.RetrievePage(Request)

        '        If Response IsNot Nothing AndAlso Response.Status = "success" Then

        '            JObject = Newtonsoft.Json.Linq.JObject.Parse(Response.RawResponse)

        '            JArrayColumns = Newtonsoft.Json.Linq.JArray.Parse(JObject.SelectToken("result_columns").ToString)

        '            Columns = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of String))(JArrayColumns.ToString)

        '            JArray = Newtonsoft.Json.Linq.JArray.Parse(JObject.SelectToken("result_rows").ToString)

        '            For i As Integer = 0 To JArray.Count - 1

        '                LocalTimeViewsResponse = New Services.ComScore.Classes.LocalTimeViewsResponse

        '                For Each Column In Columns

        '                    For Each PropertyInfo In LocalTimeViewsResponse.GetType.GetProperties

        '                        JsonPropertyAttribute = (From A In PropertyInfo.GetCustomAttributes(False).OfType(Of Newtonsoft.Json.JsonPropertyAttribute)
        '                                                 Where A.PropertyName = Column).SingleOrDefault

        '                        If JsonPropertyAttribute IsNot Nothing Then

        '                            UnderlyingType = AdvantageFramework.ClassUtilities.GetUnderlyingType(PropertyInfo.PropertyType)

        '                            If UnderlyingType Is GetType(String) Then

        '                                PropertyInfo.SetValue(LocalTimeViewsResponse, JArray(i).Item(Columns.IndexOf(Column)).ToString)
        '                                Exit For

        '                            ElseIf UnderlyingType Is GetType(Decimal) Then

        '                                If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

        '                                    PropertyInfo.SetValue(LocalTimeViewsResponse, CDec(JArray(i).Item(Columns.IndexOf(Column))))
        '                                    Exit For

        '                                End If

        '                            ElseIf UnderlyingType Is GetType(Integer) Then

        '                                If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

        '                                    PropertyInfo.SetValue(LocalTimeViewsResponse, CInt(JArray(i).Item(Columns.IndexOf(Column))))
        '                                    Exit For

        '                                End If

        '                            ElseIf UnderlyingType Is GetType(System.String()) Then

        '                                If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

        '                                    PropertyInfo.SetValue(LocalTimeViewsResponse, JArray(i).Item(Columns.IndexOf(Column)).ToObject(Of System.String()))
        '                                    Exit For

        '                                End If

        '                            ElseIf UnderlyingType Is GetType(Boolean) Then

        '                                If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

        '                                    PropertyInfo.SetValue(LocalTimeViewsResponse, CBool(JArray(i).Item(Columns.IndexOf(Column))))
        '                                    Exit For

        '                                End If

        '                            End If

        '                        End If

        '                    Next

        '                Next

        '                ComscoreLocalTimeViewsResponseList.Add(LocalTimeViewsResponse)

        '            Next

        '            Request = Api.NextPageRequest(Response)

        '        Else

        '            Request = Nothing

        '        End If

        '    Loop

        '    ComscoreLocalTimeViewList = AggregateMetricsByMinuteWeightsForLeadInLeadOutDetails(ComscoreLocalTimeViewsResponseList, ComscoreStartTime, ComscoreEndTime)

        '    ProgramNames = New Generic.List(Of String)

        '    For Each AdjustedHour In ComscoreLocalTimeViewsResponseList.Select(Function(Entity) Entity.AdjustedHour).Distinct.ToList

        '        'For Each Week In ComscoreLocalTimeViewsResponseList.Where(Function(Entity) Entity.AdjustedHour = AdjustedHour).Select(Function(Entity) Entity.Week).Distinct.ToList

        '        For Each ComscoreLocalTimeViewsResponse In ComscoreLocalTimeViewsResponseList.Where(Function(Entity) Entity.AdjustedHour = AdjustedHour).ToList

        '            For Each Program In ComscoreLocalTimeViewsResponse.ProgramName()

        '                If Not ProgramNames.Contains(Program) Then

        '                    ProgramNames.Add(Program)

        '                End If

        '            Next

        '        Next

        '        ComscoreLocalTimeView = ComscoreLocalTimeViewList.Where(Function(Entity) Entity.AdjustedHour = AdjustedHour).First

        '        If ProgramNames.Count > 2 Then

        '            ComscoreLocalTimeView.ProgramName = "Various"

        '        Else

        '            ComscoreLocalTimeView.ProgramName = String.Join("/", ProgramNames.ToArray)

        '        End If

        '        ProgramNames.Clear()

        '        'Next

        '    Next

        'End Sub
        Public Function GetLocalTimeViews(DbContext As AdvantageFramework.Database.DbContext, ViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel) As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.ResearchResult)

            'objects
            Dim ResearchResultList As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.ResearchResult) = Nothing
            Dim ComscoreClientID As String = Nothing
            Dim ComscoreClientSecret As String = Nothing
            Dim LocalTimeViews As Services.ComScore.Classes.LocalTimeViews = Nothing
            Dim StationNumbers As IEnumerable(Of Integer) = Nothing
            Dim ComscoreDemoNumbers As IEnumerable(Of Integer) = Nothing
            Dim JSONOrdinalComscoreDemoNumbers As Dictionary(Of Integer, Integer) = Nothing
            Dim ComscoreShareBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
            Dim ComscoreHUTBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
            Dim ComscoreQuarterHourStart As Date = Nothing
            Dim ComscoreQuarterHourEnd As Date = Nothing
            Dim ComscoreStartTime As Date = Nothing
            Dim ComscoreEndTime As Date = Nothing
            Dim ShareLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView) = Nothing
            Dim HUTLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView) = Nothing
            Dim DemoNumber As Integer = 0
            Dim ResearchResult As AdvantageFramework.DTO.Media.SpotTV.ResearchResult = Nothing
            Dim ComscoreTVBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
            Dim MediaSpotTVResearchBook As AdvantageFramework.Database.Entities.MediaSpotTVResearchBook = Nothing
            Dim ComscoreAsClientID As String = Nothing
            Dim EndDate As Date = Date.MinValue
            Dim ComscoreStationIDs As IEnumerable(Of Integer) = Nothing
            Dim OldEndpointPath As String = Nothing
            Dim NewEndpointPath As String = Nothing
            Dim NewURLDate As Nullable(Of Date) = Nothing
            Dim UseNewURL As Boolean = False

            ResearchResultList = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.ResearchResult)

            Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                AdvantageFramework.Services.ComScore.GetClientCredentials(DataContext, ComscoreClientID, ComscoreClientSecret, ComscoreAsClientID, OldEndpointPath, NewEndpointPath, NewURLDate)

            End Using

            ComscoreStationIDs = ViewModel.SpotTVSelectedNielsenStationList.Select(Function(E) E.ID).ToArray

            StationNumbers = (From Entity In AdvantageFramework.Database.Procedures.ComscoreTVStation.Load(DbContext)
                              Where ComscoreStationIDs.Contains(Entity.ID)
                              Select Entity.Number).ToArray

            ComscoreDemoNumbers = ViewModel.SpotTVSelectedDemographicList.Select(Function(E) E.ComscoreDemoNumber.Value).ToArray

            JSONOrdinalComscoreDemoNumbers = New Dictionary(Of Integer, Integer)

            LocalTimeViews = New Services.ComScore.Classes.LocalTimeViews

            If ViewModel.SpotTVShareHPUTBookViewModel.ShareHPUTBooks IsNot Nothing AndAlso ViewModel.SpotTVShareHPUTBookViewModel.ShareHPUTBooks.Count = 0 Then

                If ViewModel.SpotTVShareHPUTBookViewModel.UseLatest Then

                    ComscoreTVBook = (From Entity In AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadAvailable(DbContext)
                                      Where Entity.Stream = ViewModel.SpotTVShareHPUTBookViewModel.LatestStream
                                      Select Entity).OrderByDescending(Function(Entity) Entity.Year).ThenByDescending(Function(Entity) Entity.Month).FirstOrDefault

                    MediaSpotTVResearchBook = AdvantageFramework.Database.Procedures.MediaSpotTVResearchBook.LoadByMediaSpotTVResearchID(DbContext, ViewModel.SpotTVSelectedResearchCriteria.ID.Value).FirstOrDefault

                    If ComscoreTVBook IsNot Nothing AndAlso MediaSpotTVResearchBook IsNot Nothing Then

                        ViewModel.SpotTVShareHPUTBookViewModel.ShareHPUTBooks.Add(New AdvantageFramework.DTO.Media.ShareHPUTBook(ComscoreTVBook, MediaSpotTVResearchBook.ID))

                    End If

                End If

            End If

            For Each ShareHPUTBook In ViewModel.SpotTVShareHPUTBookViewModel.ShareHPUTBooks

                ComscoreShareBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, ShareHPUTBook.ShareBookID.Value)

                ComscoreHUTBook = Nothing

                HUTLocalTimeViewList = Nothing

                If ShareHPUTBook.HPUTBookID.HasValue AndAlso ShareHPUTBook.HPUTBookID.Value > 0 Then

                    ComscoreHUTBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, ShareHPUTBook.HPUTBookID.Value)

                End If

                For Each DaysAndTime In ViewModel.SpotTVDayTimeList

                    ComscoreStartTime = CDate(DaysAndTime.StartTime).ToString("HH:mm")
                    ComscoreEndTime = CDate(DaysAndTime.EndTime).ToString("HH:mm")

                    EndDate = ComscoreShareBook.EndDateTime.AddDays(-1)

                    SetComscoreQuarterHours(ComscoreStartTime, ComscoreEndTime, ComscoreQuarterHourStart, ComscoreQuarterHourEnd)

                    If NewURLDate.HasValue AndAlso ComscoreShareBook.StartDateTime >= NewURLDate.Value Then

                        LocalTimeViews.EndpointPath = NewEndpointPath & "local_time_views"
                        UseNewURL = True

                    Else

                        LocalTimeViews.EndpointPath = OldEndpointPath & "local_time_views"
                        UseNewURL = False

                    End If

                    LocalTimeViews.Request = GetLocalTimeViewsRequest(ComscoreShareBook.StartDateTime, EndDate, ComscoreQuarterHourStart, ComscoreQuarterHourEnd, ViewModel.SpotTVSelectedResearchCriteria.MarketNumber, ComscoreDemoNumbers, StationNumbers, GetDaysOfWeek(DaysAndTime), JSONOrdinalComscoreDemoNumbers, ComscoreAsClientID, DbContext)

                    GetBookData(UseNewURL, ComscoreClientID, ComscoreClientSecret, LocalTimeViews, ComscoreStartTime, ComscoreEndTime, ShareLocalTimeViewList)

                    If ShareHPUTBook.HPUTBookID.HasValue AndAlso ShareHPUTBook.HPUTBookID.Value > 0 Then

                        EndDate = ComscoreHUTBook.EndDateTime.AddDays(-1)

                        If NewURLDate.HasValue AndAlso ComscoreHUTBook.StartDateTime >= NewURLDate.Value Then

                            LocalTimeViews.EndpointPath = NewEndpointPath & "local_time_views"
                            UseNewURL = True

                        Else

                            LocalTimeViews.EndpointPath = OldEndpointPath & "local_time_views"
                            UseNewURL = False

                        End If

                        LocalTimeViews.Request = GetLocalTimeViewsRequest(ComscoreHUTBook.StartDateTime, EndDate, ComscoreQuarterHourStart, ComscoreQuarterHourEnd, ViewModel.SpotTVSelectedResearchCriteria.MarketNumber, ComscoreDemoNumbers, StationNumbers, GetDaysOfWeek(DaysAndTime), JSONOrdinalComscoreDemoNumbers, ComscoreAsClientID, DbContext)

                        GetBookData(UseNewURL, ComscoreClientID, ComscoreClientSecret, LocalTimeViews, ComscoreStartTime, ComscoreEndTime, HUTLocalTimeViewList)

                    End If

                    For Each ComscoreLocalTimeView In ShareLocalTimeViewList

                        For Each Demographic In ViewModel.SpotTVSelectedDemographicList

                            ResearchResult = New AdvantageFramework.DTO.Media.SpotTV.ResearchResult
                            ResearchResult.Station = ComscoreLocalTimeView.StationName
                            ResearchResult.StationCode = ComscoreLocalTimeView.StationNumber
                            ResearchResult.Days = DaysAndTime.Days
                            ResearchResult.DayStart = DaysAndTime.StartTime
                            ResearchResult.DayEnd = DaysAndTime.EndTime

                            ResearchResult.StartHour = (ComscoreStartTime.Hour * 100) + (ComscoreStartTime.Minute)
                            ResearchResult.EndHour = (ComscoreEndTime.Hour * 100) + (ComscoreEndTime.Minute)

                            DemoNumber = (From e In JSONOrdinalComscoreDemoNumbers
                                          Where e.Value = Demographic.ComscoreDemoNumber).Single.Key

                            SetDemoSpecificValues(DemoNumber, ComscoreLocalTimeView, HUTLocalTimeViewList, ResearchResult)

                            ResearchResult.ProgramName = ComscoreLocalTimeView.ProgramName
                            ResearchResult.DemographicStream = Demographic.Description & " / " & MonthName(ComscoreShareBook.Month, True) & ComscoreShareBook.Year.ToString.Substring(2) & "-" & GetStreamDescription(ComscoreShareBook.Stream)

                            If ComscoreHUTBook IsNot Nothing Then

                                ResearchResult.DemographicStream += " / " & MonthName(ComscoreHUTBook.Month, True) & ComscoreHUTBook.Year.ToString.Substring(2) & "-" & GetStreamDescription(ComscoreHUTBook.Stream)

                            End If

                            ResearchResult.DemographicOrder = DemoNumber
                            ResearchResult.DaytimeID = DaysAndTime.MediaSpotTVResearchDayTimeID
                            'ResearchResult.Rank 'leave blank gets filled in later
                            ResearchResult.Stream = ComscoreShareBook.Stream
                            ResearchResult.StreamYear = ComscoreShareBook.Year
                            ResearchResult.StreamMonth = ComscoreShareBook.Month

                            ResearchResult.BookID = ComscoreShareBook.ID
                            ResearchResult.HPUTBookID = If(ComscoreHUTBook IsNot Nothing, ComscoreHUTBook.ID, Nothing)
                            ResearchResult.MediaSpotTVResearchBookID = ShareHPUTBook.MediaSpotTVResearchBookID

                            ResearchResult.Demographic = Demographic.Description
                            ResearchResult.MarketDescription = ViewModel.SpotTVSelectedResearchCriteria.MarketDescription

                            ResearchResult.Books = MonthName(ComscoreShareBook.Month, True) & ComscoreShareBook.Year.ToString.Substring(2) & "-" & GetStreamDescription(ComscoreShareBook.Stream)

                            If ComscoreHUTBook IsNot Nothing Then

                                ResearchResult.Books += " / " & MonthName(ComscoreHUTBook.Month, True) & ComscoreHUTBook.Year.ToString.Substring(2) & "-" & GetStreamDescription(ComscoreHUTBook.Stream)

                            End If

                            ResearchResult.ShowSpill = False
                            ResearchResult.NielsenTVStationID = ComscoreLocalTimeView.StationNumber

                            ResearchResultList.Add(ResearchResult)

                        Next

                    Next

                Next

            Next

            GetLocalTimeViews = ResearchResultList

        End Function
        Private Function AggregateMetricsByMinuteWeights(ComscoreLocalTimeViewsResponseList As Generic.List(Of AdvantageFramework.Services.ComScore.Classes.LocalTimeViewsResponse),
                                                         ComscoreStartTime As Date, ComscoreEndTime As Date) As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView)

            'objects
            Dim ComscoreLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView) = Nothing
            Dim TotalMinutes As Integer = 0
            Dim StartTime As Integer = 0
            Dim EndTime As Integer = 0
            Dim QuarterHour As Integer = 0

            If DateDiff(DateInterval.Minute, ComscoreStartTime, ComscoreEndTime) < 0 Then

                TotalMinutes = DateDiff(DateInterval.Minute, ComscoreStartTime, DateAdd(DateInterval.Day, 1, ComscoreEndTime))

            Else

                TotalMinutes = DateDiff(DateInterval.Minute, ComscoreStartTime, ComscoreEndTime)

            End If

            If ComscoreStartTime.Hour < 3 Then

                StartTime = 2400 + (ComscoreStartTime.Hour * 100) + ComscoreStartTime.Minute

            Else

                StartTime = (ComscoreStartTime.Hour * 100) + ComscoreStartTime.Minute

            End If

            If ComscoreEndTime.Hour < 3 Then

                EndTime = 2400 + (ComscoreEndTime.Hour * 100) + ComscoreEndTime.Minute

            Else

                EndTime = (ComscoreEndTime.Hour * 100) + ComscoreEndTime.Minute

            End If

            For Each LocalTimeViewsResponse In ComscoreLocalTimeViewsResponseList

                LocalTimeViewsResponse.TotalMinutes = TotalMinutes

                If CDate(LocalTimeViewsResponse.Quarterhour).Hour < 3 Then

                    QuarterHour = 2400 + (CDate(LocalTimeViewsResponse.Quarterhour).Hour * 100) + CDate(LocalTimeViewsResponse.Quarterhour).Minute

                Else

                    QuarterHour = (CDate(LocalTimeViewsResponse.Quarterhour).Hour * 100) + CDate(LocalTimeViewsResponse.Quarterhour).Minute

                End If

                If QuarterHour < StartTime Then

                    LocalTimeViewsResponse.QtrHrMinutes = 15 - (StartTime - QuarterHour)

                ElseIf EndTime - QuarterHour < 15 Then

                    LocalTimeViewsResponse.QtrHrMinutes = EndTime - QuarterHour

                Else

                    LocalTimeViewsResponse.QtrHrMinutes = 15

                End If

                If LocalTimeViewsResponse.QtrHrMinutes > LocalTimeViewsResponse.TotalMinutes Then

                    LocalTimeViewsResponse.QtrHrMinutes = LocalTimeViewsResponse.TotalMinutes

                End If

            Next

            ComscoreLocalTimeViewList = (From Entity In ComscoreLocalTimeViewsResponseList
                                         Group By MarketNumber = Entity.MarketNumber,
                                                    MarketName = Entity.MarketName,
                                                    NetworkName = Entity.NetworkName,
                                                    StationCallSign = Entity.StationCallSign,
                                                    StationName = Entity.StationName,
                                                    StationNumber = Entity.StationNumber,
                                                    RequestProcessingTime = Entity.RequestProcessingTime
                                                   Into Group = Group
                                         Select New DTO.Media.ComscoreLocalTimeView With {
                                                            .MarketNumber = MarketNumber,
                                                            .MarketName = MarketName,
                                                            .NetworkName = NetworkName,
                                                            .StationCallSign = StationCallSign,
                                                            .StationName = StationName,
                                                            .StationNumber = StationNumber,
                                                            .RequestProcessingTime = RequestProcessingTime,
                                                            .AvgAud_01 = Group.Sum(Function(G) G.AvgAud_01 * G.QuarterhourWeight),
                                                            .Universe_01 = GetUniverse(ComscoreLocalTimeViewsResponseList, 1),
                                                            .AvgAud_02 = Group.Sum(Function(G) G.AvgAud_02 * G.QuarterhourWeight),
                                                            .Universe_02 = GetUniverse(ComscoreLocalTimeViewsResponseList, 2),
                                                            .AvgAud_03 = Group.Sum(Function(G) G.AvgAud_03 * G.QuarterhourWeight),
                                                            .Universe_03 = GetUniverse(ComscoreLocalTimeViewsResponseList, 3),
                                                            .AvgAud_04 = Group.Sum(Function(G) G.AvgAud_04 * G.QuarterhourWeight),
                                                            .Universe_04 = GetUniverse(ComscoreLocalTimeViewsResponseList, 4),
                                                            .AvgAud_05 = Group.Sum(Function(G) G.AvgAud_05 * G.QuarterhourWeight),
                                                            .Universe_05 = GetUniverse(ComscoreLocalTimeViewsResponseList, 5),
                                                            .AvgAud_06 = Group.Sum(Function(G) G.AvgAud_06 * G.QuarterhourWeight),
                                                            .Universe_06 = GetUniverse(ComscoreLocalTimeViewsResponseList, 6),
                                                            .AvgAud_07 = Group.Sum(Function(G) G.AvgAud_07 * G.QuarterhourWeight),
                                                            .Universe_07 = GetUniverse(ComscoreLocalTimeViewsResponseList, 7),
                                                            .AvgAud_08 = Group.Sum(Function(G) G.AvgAud_08 * G.QuarterhourWeight),
                                                            .Universe_08 = GetUniverse(ComscoreLocalTimeViewsResponseList, 8),
                                                            .AvgAud_09 = Group.Sum(Function(G) G.AvgAud_09 * G.QuarterhourWeight),
                                                            .Universe_09 = GetUniverse(ComscoreLocalTimeViewsResponseList, 9),
                                                            .AvgAud_10 = Group.Sum(Function(G) G.AvgAud_10 * G.QuarterhourWeight),
                                                            .Universe_10 = GetUniverse(ComscoreLocalTimeViewsResponseList, 10),
                                                            .AvgAud_11 = Group.Sum(Function(G) G.AvgAud_11 * G.QuarterhourWeight),
                                                            .Universe_11 = GetUniverse(ComscoreLocalTimeViewsResponseList, 11),
                                                            .AvgAud_12 = Group.Sum(Function(G) G.AvgAud_12 * G.QuarterhourWeight),
                                                            .Universe_12 = GetUniverse(ComscoreLocalTimeViewsResponseList, 12),
                                                            .AvgAud_13 = Group.Sum(Function(G) G.AvgAud_13 * G.QuarterhourWeight),
                                                            .Universe_13 = GetUniverse(ComscoreLocalTimeViewsResponseList, 13),
                                                            .AvgAud_14 = Group.Sum(Function(G) G.AvgAud_14 * G.QuarterhourWeight),
                                                            .Universe_14 = GetUniverse(ComscoreLocalTimeViewsResponseList, 14),
                                                            .AvgAud_15 = Group.Sum(Function(G) G.AvgAud_15 * G.QuarterhourWeight),
                                                            .Universe_15 = GetUniverse(ComscoreLocalTimeViewsResponseList, 15),
                                                            .AvgAud_16 = Group.Sum(Function(G) G.AvgAud_16 * G.QuarterhourWeight),
                                                            .Universe_16 = GetUniverse(ComscoreLocalTimeViewsResponseList, 16),
                                                            .AvgAud_17 = Group.Sum(Function(G) G.AvgAud_17 * G.QuarterhourWeight),
                                                            .Universe_17 = GetUniverse(ComscoreLocalTimeViewsResponseList, 17),
                                                            .AvgAud_18 = Group.Sum(Function(G) G.AvgAud_18 * G.QuarterhourWeight),
                                                            .Universe_18 = GetUniverse(ComscoreLocalTimeViewsResponseList, 18),
                                                            .AvgAud_19 = Group.Sum(Function(G) G.AvgAud_19 * G.QuarterhourWeight),
                                                            .Universe_19 = GetUniverse(ComscoreLocalTimeViewsResponseList, 19),
                                                            .AvgAud_20 = Group.Sum(Function(G) G.AvgAud_20 * G.QuarterhourWeight),
                                                            .Universe_20 = GetUniverse(ComscoreLocalTimeViewsResponseList, 20),
                                                            .Share_01 = Group.Average(Function(G) G.Share_01),
                                                            .Share_02 = Group.Average(Function(G) G.Share_02),
                                                            .Share_03 = Group.Average(Function(G) G.Share_03),
                                                            .Share_04 = Group.Average(Function(G) G.Share_04),
                                                            .Share_05 = Group.Average(Function(G) G.Share_05),
                                                            .Share_06 = Group.Average(Function(G) G.Share_06),
                                                            .Share_07 = Group.Average(Function(G) G.Share_07),
                                                            .Share_08 = Group.Average(Function(G) G.Share_08),
                                                            .Share_09 = Group.Average(Function(G) G.Share_09),
                                                            .Share_10 = Group.Average(Function(G) G.Share_10),
                                                            .Share_11 = Group.Average(Function(G) G.Share_11),
                                                            .Share_12 = Group.Average(Function(G) G.Share_12),
                                                            .Share_13 = Group.Average(Function(G) G.Share_13),
                                                            .Share_14 = Group.Average(Function(G) G.Share_14),
                                                            .Share_15 = Group.Average(Function(G) G.Share_15),
                                                            .Share_16 = Group.Average(Function(G) G.Share_16),
                                                            .Share_17 = Group.Average(Function(G) G.Share_17),
                                                            .Share_18 = Group.Average(Function(G) G.Share_18),
                                                            .Share_19 = Group.Average(Function(G) G.Share_19),
                                                            .Share_20 = Group.Average(Function(G) G.Share_20),
                                                            .HUT_01 = Group.Average(Function(G) G.HUT_01),
                                                            .HUT_02 = Group.Average(Function(G) G.HUT_02),
                                                            .HUT_03 = Group.Average(Function(G) G.HUT_03),
                                                            .HUT_04 = Group.Average(Function(G) G.HUT_04),
                                                            .HUT_05 = Group.Average(Function(G) G.HUT_05),
                                                            .HUT_06 = Group.Average(Function(G) G.HUT_06),
                                                            .HUT_07 = Group.Average(Function(G) G.HUT_07),
                                                            .HUT_08 = Group.Average(Function(G) G.HUT_08),
                                                            .HUT_09 = Group.Average(Function(G) G.HUT_09),
                                                            .HUT_10 = Group.Average(Function(G) G.HUT_10),
                                                            .HUT_11 = Group.Average(Function(G) G.HUT_11),
                                                            .HUT_12 = Group.Average(Function(G) G.HUT_12),
                                                            .HUT_13 = Group.Average(Function(G) G.HUT_13),
                                                            .HUT_14 = Group.Average(Function(G) G.HUT_14),
                                                            .HUT_15 = Group.Average(Function(G) G.HUT_15),
                                                            .HUT_16 = Group.Average(Function(G) G.HUT_16),
                                                            .HUT_17 = Group.Average(Function(G) G.HUT_17),
                                                            .HUT_18 = Group.Average(Function(G) G.HUT_18),
                                                            .HUT_19 = Group.Average(Function(G) G.HUT_19),
                                                            .HUT_20 = Group.Average(Function(G) G.HUT_20),
                                                            .MeetsDemoThreshold_01 = Group.Max(Function(G) G.MeetsDemoThreshold_01),
                                                            .MeetsDemoThreshold_02 = Group.Max(Function(G) G.MeetsDemoThreshold_02),
                                                            .MeetsDemoThreshold_03 = Group.Max(Function(G) G.MeetsDemoThreshold_03),
                                                            .MeetsDemoThreshold_04 = Group.Max(Function(G) G.MeetsDemoThreshold_04),
                                                            .MeetsDemoThreshold_05 = Group.Max(Function(G) G.MeetsDemoThreshold_05),
                                                            .MeetsDemoThreshold_06 = Group.Max(Function(G) G.MeetsDemoThreshold_06),
                                                            .MeetsDemoThreshold_07 = Group.Max(Function(G) G.MeetsDemoThreshold_07),
                                                            .MeetsDemoThreshold_08 = Group.Max(Function(G) G.MeetsDemoThreshold_08),
                                                            .MeetsDemoThreshold_09 = Group.Max(Function(G) G.MeetsDemoThreshold_09),
                                                            .MeetsDemoThreshold_10 = Group.Max(Function(G) G.MeetsDemoThreshold_10),
                                                            .MeetsDemoThreshold_11 = Group.Max(Function(G) G.MeetsDemoThreshold_11),
                                                            .MeetsDemoThreshold_12 = Group.Max(Function(G) G.MeetsDemoThreshold_12),
                                                            .MeetsDemoThreshold_13 = Group.Max(Function(G) G.MeetsDemoThreshold_13),
                                                            .MeetsDemoThreshold_14 = Group.Max(Function(G) G.MeetsDemoThreshold_14),
                                                            .MeetsDemoThreshold_15 = Group.Max(Function(G) G.MeetsDemoThreshold_15),
                                                            .MeetsDemoThreshold_16 = Group.Max(Function(G) G.MeetsDemoThreshold_16),
                                                            .MeetsDemoThreshold_17 = Group.Max(Function(G) G.MeetsDemoThreshold_17),
                                                            .MeetsDemoThreshold_18 = Group.Max(Function(G) G.MeetsDemoThreshold_18),
                                                            .MeetsDemoThreshold_19 = Group.Max(Function(G) G.MeetsDemoThreshold_19),
                                                            .MeetsDemoThreshold_20 = Group.Max(Function(G) G.MeetsDemoThreshold_20),
                                                            .MeetsHighQualityDemoThreshold_01 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_01),
                                                            .MeetsHighQualityDemoThreshold_02 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_02),
                                                            .MeetsHighQualityDemoThreshold_03 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_03),
                                                            .MeetsHighQualityDemoThreshold_04 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_04),
                                                            .MeetsHighQualityDemoThreshold_05 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_05),
                                                            .MeetsHighQualityDemoThreshold_06 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_06),
                                                            .MeetsHighQualityDemoThreshold_07 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_07),
                                                            .MeetsHighQualityDemoThreshold_08 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_08),
                                                            .MeetsHighQualityDemoThreshold_09 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_09),
                                                            .MeetsHighQualityDemoThreshold_10 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_10),
                                                            .MeetsHighQualityDemoThreshold_11 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_11),
                                                            .MeetsHighQualityDemoThreshold_12 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_12),
                                                            .MeetsHighQualityDemoThreshold_13 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_13),
                                                            .MeetsHighQualityDemoThreshold_14 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_14),
                                                            .MeetsHighQualityDemoThreshold_15 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_15),
                                                            .MeetsHighQualityDemoThreshold_16 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_16),
                                                            .MeetsHighQualityDemoThreshold_17 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_17),
                                                            .MeetsHighQualityDemoThreshold_18 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_18),
                                                            .MeetsHighQualityDemoThreshold_19 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_19),
                                                            .MeetsHighQualityDemoThreshold_20 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_20)}).ToList

            AggregateMetricsByMinuteWeights = ComscoreLocalTimeViewList

        End Function
        Private Function GetUniverse(ComscoreLocalTimeViewsResponseList As Generic.List(Of AdvantageFramework.Services.ComScore.Classes.LocalTimeViewsResponse), UniverseNum As Short) As Int64

            Dim Universe As Integer = 0

            Select Case UniverseNum
                Case 1
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_01).FirstOrDefault
                Case 2
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_02).FirstOrDefault
                Case 3
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_03).FirstOrDefault
                Case 4
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_04).FirstOrDefault
                Case 5
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_05).FirstOrDefault
                Case 6
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_06).FirstOrDefault
                Case 7
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_07).FirstOrDefault
                Case 8
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_08).FirstOrDefault
                Case 9
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_09).FirstOrDefault
                Case 10
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_10).FirstOrDefault
                Case 11
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_11).FirstOrDefault
                Case 12
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_12).FirstOrDefault
                Case 13
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_13).FirstOrDefault
                Case 14
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_14).FirstOrDefault
                Case 15
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_15).FirstOrDefault
                Case 16
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_16).FirstOrDefault
                Case 17
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_17).FirstOrDefault
                Case 18
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_18).FirstOrDefault
                Case 19
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_19).FirstOrDefault
                Case 20
                    Universe = ComscoreLocalTimeViewsResponseList.OrderByDescending(Function(Entity) Entity.QuarterhourInt).Select(Function(Entity) Entity.Universe_20).FirstOrDefault
            End Select

            GetUniverse = Universe

        End Function
        Private Function AggregateMetricsByMinuteWeightsForMeasurementTrendDetails(ComscoreLocalTimeViewsResponseList As Generic.List(Of AdvantageFramework.Services.ComScore.Classes.LocalTimeViewsResponse),
                                                                                   ComscoreStartTime As Date, ComscoreEndTime As Date) As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView)

            'objects
            Dim ComscoreLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView) = Nothing
            Dim TotalMinutes As Integer = 0
            Dim StartTime As Integer = 0
            Dim EndTime As Integer = 0
            Dim QuarterHour As Integer = 0

            If DateDiff(DateInterval.Minute, ComscoreStartTime, ComscoreEndTime) < 0 Then

                TotalMinutes = DateDiff(DateInterval.Minute, ComscoreStartTime, DateAdd(DateInterval.Day, 1, ComscoreEndTime))

            Else

                TotalMinutes = DateDiff(DateInterval.Minute, ComscoreStartTime, ComscoreEndTime)

            End If

            If ComscoreStartTime.Hour < 3 Then

                StartTime = 2400 + (ComscoreStartTime.Hour * 100) + ComscoreStartTime.Minute

            Else

                StartTime = (ComscoreStartTime.Hour * 100) + ComscoreStartTime.Minute

            End If

            If ComscoreEndTime.Hour < 3 Then

                EndTime = 2400 + (ComscoreEndTime.Hour * 100) + ComscoreEndTime.Minute

            Else

                EndTime = (ComscoreEndTime.Hour * 100) + ComscoreEndTime.Minute

            End If

            'For Each LocalTimeViewsResponse In ComscoreLocalTimeViewsResponseList

            '    LocalTimeViewsResponse.TotalMinutes = TotalMinutes

            '    If CDate(LocalTimeViewsResponse.Quarterhour).Hour < 3 Then

            '        QuarterHour = 2400 + (CDate(LocalTimeViewsResponse.Quarterhour).Hour * 100) + CDate(LocalTimeViewsResponse.Quarterhour).Minute

            '    Else

            '        QuarterHour = (CDate(LocalTimeViewsResponse.Quarterhour).Hour * 100) + CDate(LocalTimeViewsResponse.Quarterhour).Minute

            '    End If

            '    If QuarterHour < StartTime Then

            '        LocalTimeViewsResponse.QtrHrMinutes = 15 - (StartTime - QuarterHour)

            '    ElseIf EndTime - QuarterHour < 15 Then

            '        LocalTimeViewsResponse.QtrHrMinutes = EndTime - QuarterHour

            '    Else

            '        LocalTimeViewsResponse.QtrHrMinutes = 15

            '    End If

            '    If LocalTimeViewsResponse.QtrHrMinutes > LocalTimeViewsResponse.TotalMinutes Then

            '        LocalTimeViewsResponse.QtrHrMinutes = LocalTimeViewsResponse.TotalMinutes

            '    End If

            'Next

            ComscoreLocalTimeViewList = (From Entity In ComscoreLocalTimeViewsResponseList
                                         Group By MarketNumber = Entity.MarketNumber,
                                                    MarketName = Entity.MarketName,
                                                    NetworkName = Entity.NetworkName,
                                                    StationCallSign = Entity.StationCallSign,
                                                    StationName = Entity.StationName,
                                                    StationNumber = Entity.StationNumber
                                                   Into Group = Group
                                         Select New DTO.Media.ComscoreLocalTimeView With {
                                                            .MarketNumber = MarketNumber,
                                                            .MarketName = MarketName,
                                                            .NetworkName = NetworkName,
                                                            .StationCallSign = StationCallSign,
                                                            .StationName = StationName,
                                                            .StationNumber = StationNumber,
                                                            .AvgAud_01 = Group.Sum(Function(G) G.AvgAud_01 * G.QuarterhourWeight),
                                                            .Universe_01 = GetUniverse(ComscoreLocalTimeViewsResponseList, 1),
                                                            .AvgAud_02 = Group.Sum(Function(G) G.AvgAud_02 * G.QuarterhourWeight),
                                                            .Universe_02 = GetUniverse(ComscoreLocalTimeViewsResponseList, 2),
                                                            .AvgAud_03 = Group.Sum(Function(G) G.AvgAud_03 * G.QuarterhourWeight),
                                                            .Universe_03 = GetUniverse(ComscoreLocalTimeViewsResponseList, 3),
                                                            .AvgAud_04 = Group.Sum(Function(G) G.AvgAud_04 * G.QuarterhourWeight),
                                                            .Universe_04 = GetUniverse(ComscoreLocalTimeViewsResponseList, 4),
                                                            .AvgAud_05 = Group.Sum(Function(G) G.AvgAud_05 * G.QuarterhourWeight),
                                                            .Universe_05 = GetUniverse(ComscoreLocalTimeViewsResponseList, 5),
                                                            .AvgAud_06 = Group.Sum(Function(G) G.AvgAud_06 * G.QuarterhourWeight),
                                                            .Universe_06 = GetUniverse(ComscoreLocalTimeViewsResponseList, 6),
                                                            .AvgAud_07 = Group.Sum(Function(G) G.AvgAud_07 * G.QuarterhourWeight),
                                                            .Universe_07 = GetUniverse(ComscoreLocalTimeViewsResponseList, 7),
                                                            .AvgAud_08 = Group.Sum(Function(G) G.AvgAud_08 * G.QuarterhourWeight),
                                                            .Universe_08 = GetUniverse(ComscoreLocalTimeViewsResponseList, 8),
                                                            .AvgAud_09 = Group.Sum(Function(G) G.AvgAud_09 * G.QuarterhourWeight),
                                                            .Universe_09 = GetUniverse(ComscoreLocalTimeViewsResponseList, 9),
                                                            .AvgAud_10 = Group.Sum(Function(G) G.AvgAud_10 * G.QuarterhourWeight),
                                                            .Universe_10 = GetUniverse(ComscoreLocalTimeViewsResponseList, 10),
                                                            .AvgAud_11 = Group.Sum(Function(G) G.AvgAud_11 * G.QuarterhourWeight),
                                                            .Universe_11 = GetUniverse(ComscoreLocalTimeViewsResponseList, 11),
                                                            .AvgAud_12 = Group.Sum(Function(G) G.AvgAud_12 * G.QuarterhourWeight),
                                                            .Universe_12 = GetUniverse(ComscoreLocalTimeViewsResponseList, 12),
                                                            .AvgAud_13 = Group.Sum(Function(G) G.AvgAud_13 * G.QuarterhourWeight),
                                                            .Universe_13 = GetUniverse(ComscoreLocalTimeViewsResponseList, 13),
                                                            .AvgAud_14 = Group.Sum(Function(G) G.AvgAud_14 * G.QuarterhourWeight),
                                                            .Universe_14 = GetUniverse(ComscoreLocalTimeViewsResponseList, 14),
                                                            .AvgAud_15 = Group.Sum(Function(G) G.AvgAud_15 * G.QuarterhourWeight),
                                                            .Universe_15 = GetUniverse(ComscoreLocalTimeViewsResponseList, 15),
                                                            .AvgAud_16 = Group.Sum(Function(G) G.AvgAud_16 * G.QuarterhourWeight),
                                                            .Universe_16 = GetUniverse(ComscoreLocalTimeViewsResponseList, 16),
                                                            .AvgAud_17 = Group.Sum(Function(G) G.AvgAud_17 * G.QuarterhourWeight),
                                                            .Universe_17 = GetUniverse(ComscoreLocalTimeViewsResponseList, 17),
                                                            .AvgAud_18 = Group.Sum(Function(G) G.AvgAud_18 * G.QuarterhourWeight),
                                                            .Universe_18 = GetUniverse(ComscoreLocalTimeViewsResponseList, 18),
                                                            .AvgAud_19 = Group.Sum(Function(G) G.AvgAud_19 * G.QuarterhourWeight),
                                                            .Universe_19 = GetUniverse(ComscoreLocalTimeViewsResponseList, 19),
                                                            .AvgAud_20 = Group.Sum(Function(G) G.AvgAud_20 * G.QuarterhourWeight),
                                                            .Universe_20 = GetUniverse(ComscoreLocalTimeViewsResponseList, 20),
                                                            .Share_01 = Group.Average(Function(G) G.Share_01),
                                                            .Share_02 = Group.Average(Function(G) G.Share_02),
                                                            .Share_03 = Group.Average(Function(G) G.Share_03),
                                                            .Share_04 = Group.Average(Function(G) G.Share_04),
                                                            .Share_05 = Group.Average(Function(G) G.Share_05),
                                                            .Share_06 = Group.Average(Function(G) G.Share_06),
                                                            .Share_07 = Group.Average(Function(G) G.Share_07),
                                                            .Share_08 = Group.Average(Function(G) G.Share_08),
                                                            .Share_09 = Group.Average(Function(G) G.Share_09),
                                                            .Share_10 = Group.Average(Function(G) G.Share_10),
                                                            .Share_11 = Group.Average(Function(G) G.Share_11),
                                                            .Share_12 = Group.Average(Function(G) G.Share_12),
                                                            .Share_13 = Group.Average(Function(G) G.Share_13),
                                                            .Share_14 = Group.Average(Function(G) G.Share_14),
                                                            .Share_15 = Group.Average(Function(G) G.Share_15),
                                                            .Share_16 = Group.Average(Function(G) G.Share_16),
                                                            .Share_17 = Group.Average(Function(G) G.Share_17),
                                                            .Share_18 = Group.Average(Function(G) G.Share_18),
                                                            .Share_19 = Group.Average(Function(G) G.Share_19),
                                                            .Share_20 = Group.Average(Function(G) G.Share_20),
                                                            .HUT_01 = Group.Average(Function(G) G.HUT_01),
                                                            .HUT_02 = Group.Average(Function(G) G.HUT_02),
                                                            .HUT_03 = Group.Average(Function(G) G.HUT_03),
                                                            .HUT_04 = Group.Average(Function(G) G.HUT_04),
                                                            .HUT_05 = Group.Average(Function(G) G.HUT_05),
                                                            .HUT_06 = Group.Average(Function(G) G.HUT_06),
                                                            .HUT_07 = Group.Average(Function(G) G.HUT_07),
                                                            .HUT_08 = Group.Average(Function(G) G.HUT_08),
                                                            .HUT_09 = Group.Average(Function(G) G.HUT_09),
                                                            .HUT_10 = Group.Average(Function(G) G.HUT_10),
                                                            .HUT_11 = Group.Average(Function(G) G.HUT_11),
                                                            .HUT_12 = Group.Average(Function(G) G.HUT_12),
                                                            .HUT_13 = Group.Average(Function(G) G.HUT_13),
                                                            .HUT_14 = Group.Average(Function(G) G.HUT_14),
                                                            .HUT_15 = Group.Average(Function(G) G.HUT_15),
                                                            .HUT_16 = Group.Average(Function(G) G.HUT_16),
                                                            .HUT_17 = Group.Average(Function(G) G.HUT_17),
                                                            .HUT_18 = Group.Average(Function(G) G.HUT_18),
                                                            .HUT_19 = Group.Average(Function(G) G.HUT_19),
                                                            .HUT_20 = Group.Average(Function(G) G.HUT_20),
                                                            .MeetsDemoThreshold_01 = Group.Max(Function(G) G.MeetsDemoThreshold_01),
                                                            .MeetsDemoThreshold_02 = Group.Max(Function(G) G.MeetsDemoThreshold_02),
                                                            .MeetsDemoThreshold_03 = Group.Max(Function(G) G.MeetsDemoThreshold_03),
                                                            .MeetsDemoThreshold_04 = Group.Max(Function(G) G.MeetsDemoThreshold_04),
                                                            .MeetsDemoThreshold_05 = Group.Max(Function(G) G.MeetsDemoThreshold_05),
                                                            .MeetsDemoThreshold_06 = Group.Max(Function(G) G.MeetsDemoThreshold_06),
                                                            .MeetsDemoThreshold_07 = Group.Max(Function(G) G.MeetsDemoThreshold_07),
                                                            .MeetsDemoThreshold_08 = Group.Max(Function(G) G.MeetsDemoThreshold_08),
                                                            .MeetsDemoThreshold_09 = Group.Max(Function(G) G.MeetsDemoThreshold_09),
                                                            .MeetsDemoThreshold_10 = Group.Max(Function(G) G.MeetsDemoThreshold_10),
                                                            .MeetsDemoThreshold_11 = Group.Max(Function(G) G.MeetsDemoThreshold_11),
                                                            .MeetsDemoThreshold_12 = Group.Max(Function(G) G.MeetsDemoThreshold_12),
                                                            .MeetsDemoThreshold_13 = Group.Max(Function(G) G.MeetsDemoThreshold_13),
                                                            .MeetsDemoThreshold_14 = Group.Max(Function(G) G.MeetsDemoThreshold_14),
                                                            .MeetsDemoThreshold_15 = Group.Max(Function(G) G.MeetsDemoThreshold_15),
                                                            .MeetsDemoThreshold_16 = Group.Max(Function(G) G.MeetsDemoThreshold_16),
                                                            .MeetsDemoThreshold_17 = Group.Max(Function(G) G.MeetsDemoThreshold_17),
                                                            .MeetsDemoThreshold_18 = Group.Max(Function(G) G.MeetsDemoThreshold_18),
                                                            .MeetsDemoThreshold_19 = Group.Max(Function(G) G.MeetsDemoThreshold_19),
                                                            .MeetsDemoThreshold_20 = Group.Max(Function(G) G.MeetsDemoThreshold_20),
                                                            .MeetsHighQualityDemoThreshold_01 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_01),
                                                            .MeetsHighQualityDemoThreshold_02 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_02),
                                                            .MeetsHighQualityDemoThreshold_03 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_03),
                                                            .MeetsHighQualityDemoThreshold_04 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_04),
                                                            .MeetsHighQualityDemoThreshold_05 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_05),
                                                            .MeetsHighQualityDemoThreshold_06 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_06),
                                                            .MeetsHighQualityDemoThreshold_07 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_07),
                                                            .MeetsHighQualityDemoThreshold_08 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_08),
                                                            .MeetsHighQualityDemoThreshold_09 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_09),
                                                            .MeetsHighQualityDemoThreshold_10 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_10),
                                                            .MeetsHighQualityDemoThreshold_11 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_11),
                                                            .MeetsHighQualityDemoThreshold_12 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_12),
                                                            .MeetsHighQualityDemoThreshold_13 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_13),
                                                            .MeetsHighQualityDemoThreshold_14 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_14),
                                                            .MeetsHighQualityDemoThreshold_15 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_15),
                                                            .MeetsHighQualityDemoThreshold_16 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_16),
                                                            .MeetsHighQualityDemoThreshold_17 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_17),
                                                            .MeetsHighQualityDemoThreshold_18 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_18),
                                                            .MeetsHighQualityDemoThreshold_19 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_19),
                                                            .MeetsHighQualityDemoThreshold_20 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_20)}).ToList

            AggregateMetricsByMinuteWeightsForMeasurementTrendDetails = ComscoreLocalTimeViewList

        End Function
        Private Function AggregateMetricsByMinuteWeightsForLeadInLeadOutDetails(ComscoreLocalTimeViewsResponseList As Generic.List(Of AdvantageFramework.Services.ComScore.Classes.LocalTimeViewsResponse),
                                                                                ComscoreStartTime As Date, ComscoreEndTime As Date) As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView)

            'objects
            Dim ComscoreLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView) = Nothing
            Dim TotalMinutes As Integer = 0
            Dim StartTime As Integer = 0
            Dim EndTime As Integer = 0
            Dim QuarterHour As Integer = 0

            If DateDiff(DateInterval.Minute, ComscoreStartTime, ComscoreEndTime) < 0 Then

                TotalMinutes = DateDiff(DateInterval.Minute, ComscoreStartTime, DateAdd(DateInterval.Day, 1, ComscoreEndTime))

            Else

                TotalMinutes = DateDiff(DateInterval.Minute, ComscoreStartTime, ComscoreEndTime)

            End If

            If ComscoreStartTime.Hour < 3 Then

                StartTime = 2400 + (ComscoreStartTime.Hour * 100) + ComscoreStartTime.Minute

            Else

                StartTime = (ComscoreStartTime.Hour * 100) + ComscoreStartTime.Minute

            End If

            If ComscoreEndTime.Hour < 3 Then

                EndTime = 2400 + (ComscoreEndTime.Hour * 100) + ComscoreEndTime.Minute

            Else

                EndTime = (ComscoreEndTime.Hour * 100) + ComscoreEndTime.Minute

            End If

            For Each LocalTimeViewsResponse In ComscoreLocalTimeViewsResponseList

                LocalTimeViewsResponse.TotalMinutes = TotalMinutes

                If CDate(LocalTimeViewsResponse.Quarterhour).Hour < 3 Then

                    QuarterHour = 2400 + (CDate(LocalTimeViewsResponse.Quarterhour).Hour * 100) + CDate(LocalTimeViewsResponse.Quarterhour).Minute

                Else

                    QuarterHour = (CDate(LocalTimeViewsResponse.Quarterhour).Hour * 100) + CDate(LocalTimeViewsResponse.Quarterhour).Minute

                End If

                LocalTimeViewsResponse.AdjustedHour = QuarterHour

                If QuarterHour < StartTime Then

                    LocalTimeViewsResponse.QtrHrMinutes = 15 - (StartTime - QuarterHour)

                ElseIf EndTime - QuarterHour < 15 Then

                    LocalTimeViewsResponse.QtrHrMinutes = EndTime - QuarterHour

                Else

                    LocalTimeViewsResponse.QtrHrMinutes = 15

                End If

                If LocalTimeViewsResponse.QtrHrMinutes > LocalTimeViewsResponse.TotalMinutes Then

                    LocalTimeViewsResponse.QtrHrMinutes = LocalTimeViewsResponse.TotalMinutes

                End If

            Next

            ComscoreLocalTimeViewList = (From Entity In ComscoreLocalTimeViewsResponseList
                                         Group By MarketNumber = Entity.MarketNumber,
                                                    MarketName = Entity.MarketName,
                                                    NetworkName = Entity.NetworkName,
                                                    StationCallSign = Entity.StationCallSign,
                                                    StationName = Entity.StationName,
                                                    StationNumber = Entity.StationNumber,
                                                    Qtrhour = Entity.Quarterhour,
                                                    AdjustedHour = Entity.AdjustedHour,
                                                    Universe_01 = Entity.Universe_01,
                                                    Universe_02 = Entity.Universe_02,
                                                    Universe_03 = Entity.Universe_03,
                                                    Universe_04 = Entity.Universe_04,
                                                    Universe_05 = Entity.Universe_05,
                                                    Universe_06 = Entity.Universe_06,
                                                    Universe_07 = Entity.Universe_07,
                                                    Universe_08 = Entity.Universe_08,
                                                    Universe_09 = Entity.Universe_09,
                                                    Universe_10 = Entity.Universe_10,
                                                    Universe_11 = Entity.Universe_11,
                                                    Universe_12 = Entity.Universe_12,
                                                    Universe_13 = Entity.Universe_13,
                                                    Universe_14 = Entity.Universe_14,
                                                    Universe_15 = Entity.Universe_15,
                                                    Universe_16 = Entity.Universe_16,
                                                    Universe_17 = Entity.Universe_17,
                                                    Universe_18 = Entity.Universe_18,
                                                    Universe_19 = Entity.Universe_19,
                                                    Universe_20 = Entity.Universe_20
                                                   Into Group = Group
                                         Select New DTO.Media.ComscoreLocalTimeView With {
                                                            .MarketNumber = MarketNumber,
                                                            .MarketName = MarketName,
                                                            .NetworkName = NetworkName,
                                                            .StationCallSign = StationCallSign,
                                                            .StationName = StationName,
                                                            .StationNumber = StationNumber,
                                                            .QuarterHour = Qtrhour,
                                                            .AdjustedHour = AdjustedHour,
                                                            .AvgAud_01 = Group.Sum(Function(G) G.AvgAud_01),
                                                            .Universe_01 = Universe_01,
                                                            .AvgAud_02 = Group.Sum(Function(G) G.AvgAud_02),
                                                            .Universe_02 = Universe_02,
                                                            .AvgAud_03 = Group.Sum(Function(G) G.AvgAud_03),
                                                            .Universe_03 = Universe_03,
                                                            .AvgAud_04 = Group.Sum(Function(G) G.AvgAud_04),
                                                            .Universe_04 = Universe_04,
                                                            .AvgAud_05 = Group.Sum(Function(G) G.AvgAud_05),
                                                            .Universe_05 = Universe_05,
                                                            .AvgAud_06 = Group.Sum(Function(G) G.AvgAud_06),
                                                            .Universe_06 = Universe_06,
                                                            .AvgAud_07 = Group.Sum(Function(G) G.AvgAud_07),
                                                            .Universe_07 = Universe_07,
                                                            .AvgAud_08 = Group.Sum(Function(G) G.AvgAud_08),
                                                            .Universe_08 = Universe_08,
                                                            .AvgAud_09 = Group.Sum(Function(G) G.AvgAud_09),
                                                            .Universe_09 = Universe_09,
                                                            .AvgAud_10 = Group.Sum(Function(G) G.AvgAud_10),
                                                            .Universe_10 = Universe_10,
                                                            .AvgAud_11 = Group.Sum(Function(G) G.AvgAud_11),
                                                            .Universe_11 = Universe_11,
                                                            .AvgAud_12 = Group.Sum(Function(G) G.AvgAud_12),
                                                            .Universe_12 = Universe_12,
                                                            .AvgAud_13 = Group.Sum(Function(G) G.AvgAud_13),
                                                            .Universe_13 = Universe_13,
                                                            .AvgAud_14 = Group.Sum(Function(G) G.AvgAud_14),
                                                            .Universe_14 = Universe_14,
                                                            .AvgAud_15 = Group.Sum(Function(G) G.AvgAud_15),
                                                            .Universe_15 = Universe_15,
                                                            .AvgAud_16 = Group.Sum(Function(G) G.AvgAud_16),
                                                            .Universe_16 = Universe_16,
                                                            .AvgAud_17 = Group.Sum(Function(G) G.AvgAud_17),
                                                            .Universe_17 = Universe_17,
                                                            .AvgAud_18 = Group.Sum(Function(G) G.AvgAud_18),
                                                            .Universe_18 = Universe_18,
                                                            .AvgAud_19 = Group.Sum(Function(G) G.AvgAud_19),
                                                            .Universe_19 = Universe_19,
                                                            .AvgAud_20 = Group.Sum(Function(G) G.AvgAud_20),
                                                            .Universe_20 = Universe_20,
                                                            .Share_01 = Group.Average(Function(G) G.Share_01),
                                                            .Share_02 = Group.Average(Function(G) G.Share_02),
                                                            .Share_03 = Group.Average(Function(G) G.Share_03),
                                                            .Share_04 = Group.Average(Function(G) G.Share_04),
                                                            .Share_05 = Group.Average(Function(G) G.Share_05),
                                                            .Share_06 = Group.Average(Function(G) G.Share_06),
                                                            .Share_07 = Group.Average(Function(G) G.Share_07),
                                                            .Share_08 = Group.Average(Function(G) G.Share_08),
                                                            .Share_09 = Group.Average(Function(G) G.Share_09),
                                                            .Share_10 = Group.Average(Function(G) G.Share_10),
                                                            .Share_11 = Group.Average(Function(G) G.Share_11),
                                                            .Share_12 = Group.Average(Function(G) G.Share_12),
                                                            .Share_13 = Group.Average(Function(G) G.Share_13),
                                                            .Share_14 = Group.Average(Function(G) G.Share_14),
                                                            .Share_15 = Group.Average(Function(G) G.Share_15),
                                                            .Share_16 = Group.Average(Function(G) G.Share_16),
                                                            .Share_17 = Group.Average(Function(G) G.Share_17),
                                                            .Share_18 = Group.Average(Function(G) G.Share_18),
                                                            .Share_19 = Group.Average(Function(G) G.Share_19),
                                                            .Share_20 = Group.Average(Function(G) G.Share_20),
                                                            .HUT_01 = Group.Average(Function(G) G.HUT_01),
                                                            .HUT_02 = Group.Average(Function(G) G.HUT_02),
                                                            .HUT_03 = Group.Average(Function(G) G.HUT_03),
                                                            .HUT_04 = Group.Average(Function(G) G.HUT_04),
                                                            .HUT_05 = Group.Average(Function(G) G.HUT_05),
                                                            .HUT_06 = Group.Average(Function(G) G.HUT_06),
                                                            .HUT_07 = Group.Average(Function(G) G.HUT_07),
                                                            .HUT_08 = Group.Average(Function(G) G.HUT_08),
                                                            .HUT_09 = Group.Average(Function(G) G.HUT_09),
                                                            .HUT_10 = Group.Average(Function(G) G.HUT_10),
                                                            .HUT_11 = Group.Average(Function(G) G.HUT_11),
                                                            .HUT_12 = Group.Average(Function(G) G.HUT_12),
                                                            .HUT_13 = Group.Average(Function(G) G.HUT_13),
                                                            .HUT_14 = Group.Average(Function(G) G.HUT_14),
                                                            .HUT_15 = Group.Average(Function(G) G.HUT_15),
                                                            .HUT_16 = Group.Average(Function(G) G.HUT_16),
                                                            .HUT_17 = Group.Average(Function(G) G.HUT_17),
                                                            .HUT_18 = Group.Average(Function(G) G.HUT_18),
                                                            .HUT_19 = Group.Average(Function(G) G.HUT_19),
                                                            .HUT_20 = Group.Average(Function(G) G.HUT_20),
                                                            .MeetsDemoThreshold_01 = Group.Max(Function(G) G.MeetsDemoThreshold_01),
                                                            .MeetsDemoThreshold_02 = Group.Max(Function(G) G.MeetsDemoThreshold_02),
                                                            .MeetsDemoThreshold_03 = Group.Max(Function(G) G.MeetsDemoThreshold_03),
                                                            .MeetsDemoThreshold_04 = Group.Max(Function(G) G.MeetsDemoThreshold_04),
                                                            .MeetsDemoThreshold_05 = Group.Max(Function(G) G.MeetsDemoThreshold_05),
                                                            .MeetsDemoThreshold_06 = Group.Max(Function(G) G.MeetsDemoThreshold_06),
                                                            .MeetsDemoThreshold_07 = Group.Max(Function(G) G.MeetsDemoThreshold_07),
                                                            .MeetsDemoThreshold_08 = Group.Max(Function(G) G.MeetsDemoThreshold_08),
                                                            .MeetsDemoThreshold_09 = Group.Max(Function(G) G.MeetsDemoThreshold_09),
                                                            .MeetsDemoThreshold_10 = Group.Max(Function(G) G.MeetsDemoThreshold_10),
                                                            .MeetsDemoThreshold_11 = Group.Max(Function(G) G.MeetsDemoThreshold_11),
                                                            .MeetsDemoThreshold_12 = Group.Max(Function(G) G.MeetsDemoThreshold_12),
                                                            .MeetsDemoThreshold_13 = Group.Max(Function(G) G.MeetsDemoThreshold_13),
                                                            .MeetsDemoThreshold_14 = Group.Max(Function(G) G.MeetsDemoThreshold_14),
                                                            .MeetsDemoThreshold_15 = Group.Max(Function(G) G.MeetsDemoThreshold_15),
                                                            .MeetsDemoThreshold_16 = Group.Max(Function(G) G.MeetsDemoThreshold_16),
                                                            .MeetsDemoThreshold_17 = Group.Max(Function(G) G.MeetsDemoThreshold_17),
                                                            .MeetsDemoThreshold_18 = Group.Max(Function(G) G.MeetsDemoThreshold_18),
                                                            .MeetsDemoThreshold_19 = Group.Max(Function(G) G.MeetsDemoThreshold_19),
                                                            .MeetsDemoThreshold_20 = Group.Max(Function(G) G.MeetsDemoThreshold_20),
                                                            .MeetsHighQualityDemoThreshold_01 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_01),
                                                            .MeetsHighQualityDemoThreshold_02 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_02),
                                                            .MeetsHighQualityDemoThreshold_03 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_03),
                                                            .MeetsHighQualityDemoThreshold_04 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_04),
                                                            .MeetsHighQualityDemoThreshold_05 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_05),
                                                            .MeetsHighQualityDemoThreshold_06 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_06),
                                                            .MeetsHighQualityDemoThreshold_07 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_07),
                                                            .MeetsHighQualityDemoThreshold_08 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_08),
                                                            .MeetsHighQualityDemoThreshold_09 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_09),
                                                            .MeetsHighQualityDemoThreshold_10 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_10),
                                                            .MeetsHighQualityDemoThreshold_11 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_11),
                                                            .MeetsHighQualityDemoThreshold_12 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_12),
                                                            .MeetsHighQualityDemoThreshold_13 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_13),
                                                            .MeetsHighQualityDemoThreshold_14 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_14),
                                                            .MeetsHighQualityDemoThreshold_15 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_15),
                                                            .MeetsHighQualityDemoThreshold_16 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_16),
                                                            .MeetsHighQualityDemoThreshold_17 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_17),
                                                            .MeetsHighQualityDemoThreshold_18 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_18),
                                                            .MeetsHighQualityDemoThreshold_19 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_19),
                                                            .MeetsHighQualityDemoThreshold_20 = Group.Max(Function(G) G.MeetsHighQualityDemoThreshold_20)}).ToList

            AggregateMetricsByMinuteWeightsForLeadInLeadOutDetails = ComscoreLocalTimeViewList

        End Function
        'Public Function GetLocalTimeViews(DbContext As AdvantageFramework.Database.DbContext, CallLetters As String, DemographicList As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Demographic), ShareHPUTBooks As Generic.List(Of AdvantageFramework.DTO.Media.ShareHPUTBook),
        '                                  MediaSpotTVResearchDaytimeTypes As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaSpotTVResearchDaytimeType), MarketNumber As Integer) As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData)

        '    'objects
        '    Dim TVWorksheetRatingAndShareDataList As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData) = Nothing
        '    Dim ComscoreClientID As String = Nothing
        '    Dim ComscoreClientSecret As String = Nothing
        '    Dim LocalTimeViews As Services.ComScore.Classes.LocalTimeViews = Nothing
        '    Dim StationCallLetters As IEnumerable(Of String) = Nothing
        '    Dim ComscoreDemoNumbers As IEnumerable(Of Integer) = Nothing
        '    Dim JSONOrdinalComscoreDemoNumbers As Dictionary(Of Integer, Integer) = Nothing
        '    Dim ComscoreShareBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
        '    Dim ComscoreHUTBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
        '    Dim ComscoreQuarterHourStart As Date = Nothing
        '    Dim ComscoreQuarterHourEnd As Date = Nothing
        '    Dim ComscoreStartTime As Date = Nothing
        '    Dim ComscoreEndTime As Date = Nothing
        '    Dim ShareLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView) = Nothing
        '    Dim HUTLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView) = Nothing
        '    Dim DemoNumber As Integer = 0
        '    Dim TVWorksheetRatingAndShareData As AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData = Nothing
        '    Dim ComscoreAsClientID As String = Nothing
        '    Dim EndDate As Date = Date.MinValue

        '    TVWorksheetRatingAndShareDataList = New Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData)

        '    Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

        '        AdvantageFramework.Services.ComScore.GetClientCredentials(DataContext, ComscoreClientID, ComscoreClientSecret, ComscoreAsClientID)

        '    End Using

        '    StationCallLetters = New String() {CallLetters}

        '    ComscoreDemoNumbers = DemographicList.Select(Function(E) E.ComscoreDemoNumber.Value).ToArray

        '    JSONOrdinalComscoreDemoNumbers = New Dictionary(Of Integer, Integer)

        '    LocalTimeViews = New Services.ComScore.Classes.LocalTimeViews
        '    LocalTimeViews.EndpointPath = "/mrtv/v7/local_time_views"

        '    For Each ShareHPUTBook In ShareHPUTBooks

        '        ComscoreShareBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, ShareHPUTBook.ShareBookID.Value)

        '        ComscoreHUTBook = Nothing

        '        HUTLocalTimeViewList = Nothing

        '        If ShareHPUTBook.HPUTBookID.HasValue AndAlso ShareHPUTBook.HPUTBookID.Value > 0 Then

        '            ComscoreHUTBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, ShareHPUTBook.HPUTBookID.Value)

        '        End If

        '        For Each DaysAndTime In MediaSpotTVResearchDaytimeTypes

        '            ComscoreStartTime = CDate(DaysAndTime.StartTime).ToString("HH:mm")
        '            ComscoreEndTime = CDate(DaysAndTime.EndTime).ToString("HH:mm")

        '            EndDate = ComscoreShareBook.EndDateTime.AddDays(-1)

        '            SetComscoreQuarterHours(ComscoreStartTime, ComscoreEndTime, ComscoreQuarterHourStart, ComscoreQuarterHourEnd)

        '            LocalTimeViews.Request = GetLocalTimeViewsRequest(ComscoreShareBook.StartDateTime, EndDate, ComscoreQuarterHourStart, ComscoreQuarterHourEnd, MarketNumber, ComscoreDemoNumbers, StationCallLetters, GetDaysOfWeek(DaysAndTime), JSONOrdinalComscoreDemoNumbers, ComscoreAsClientID)

        '            GetBookData(ComscoreClientID, ComscoreClientSecret, LocalTimeViews, ComscoreStartTime, ComscoreEndTime, ShareLocalTimeViewList)

        '            If ShareHPUTBook.HPUTBookID.HasValue AndAlso ShareHPUTBook.HPUTBookID.Value > 0 Then

        '                EndDate = ComscoreHUTBook.EndDateTime.AddDays(-1)

        '                LocalTimeViews.Request = GetLocalTimeViewsRequest(ComscoreHUTBook.StartDateTime, EndDate, ComscoreQuarterHourStart, ComscoreQuarterHourEnd, MarketNumber, ComscoreDemoNumbers, StationCallLetters, GetDaysOfWeek(DaysAndTime), JSONOrdinalComscoreDemoNumbers, ComscoreAsClientID)

        '                GetBookData(ComscoreClientID, ComscoreClientSecret, LocalTimeViews, ComscoreStartTime, ComscoreEndTime, HUTLocalTimeViewList)

        '            End If

        '            For Each ComscoreLocalTimeView In ShareLocalTimeViewList

        '                For Each Demographic In DemographicList

        '                    TVWorksheetRatingAndShareData = New AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData

        '                    TVWorksheetRatingAndShareData.BookID = ShareHPUTBook.ShareBookID.Value
        '                    TVWorksheetRatingAndShareData.MediaBroadcastWorksheetMarketDetailID = DaysAndTime.ID
        '                    TVWorksheetRatingAndShareData.StationCode = ComscoreLocalTimeView.StationNumber
        '                    TVWorksheetRatingAndShareData.ComscoreDemoNumber = Demographic.ComscoreDemoNumber
        '                    TVWorksheetRatingAndShareData.ProgramName = ComscoreLocalTimeView.ProgramName & ""

        '                    DemoNumber = (From e In JSONOrdinalComscoreDemoNumbers
        '                                  Where e.Value = Demographic.ComscoreDemoNumber).Single.Key

        '                    SetDemoSpecificValues(DemoNumber, ComscoreLocalTimeView, HUTLocalTimeViewList, TVWorksheetRatingAndShareData)

        '                    TVWorksheetRatingAndShareDataList.Add(TVWorksheetRatingAndShareData)

        '                Next

        '            Next

        '        Next

        '    Next

        '    GetLocalTimeViews = TVWorksheetRatingAndShareDataList

        'End Function
        'Public Function GetMeasurementTrendDetails(DbContext As AdvantageFramework.Database.DbContext, CallLetters As String, DemographicList As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Demographic), ShareHPUTBooks As Generic.List(Of AdvantageFramework.DTO.Media.ShareHPUTBook),
        '                                           MediaSpotTVResearchDaytimeTypes As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaSpotTVResearchDaytimeType), MarketNumber As Integer) As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail)

        '    'objects
        '    Dim MeasurementTrendDetailList As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail) = Nothing
        '    Dim ComscoreClientID As String = Nothing
        '    Dim ComscoreClientSecret As String = Nothing
        '    Dim LocalTimeViews As Services.ComScore.Classes.LocalTimeViews = Nothing
        '    Dim StationCallLetters As IEnumerable(Of String) = Nothing
        '    Dim ComscoreDemoNumbers As IEnumerable(Of Integer) = Nothing
        '    Dim JSONOrdinalComscoreDemoNumbers As Dictionary(Of Integer, Integer) = Nothing
        '    Dim ComscoreShareBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
        '    Dim ComscoreHUTBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
        '    Dim ComscoreQuarterHourStart As Date = Nothing
        '    Dim ComscoreQuarterHourEnd As Date = Nothing
        '    Dim ComscoreStartTime As Date = Nothing
        '    Dim ComscoreEndTime As Date = Nothing
        '    Dim ShareLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView) = Nothing
        '    Dim HUTLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView) = Nothing
        '    Dim DemoNumber As Integer = 0
        '    Dim MeasurementTrendDetail As AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail = Nothing
        '    Dim ComscoreAsClientID As String = Nothing
        '    Dim WeekCounter As Integer = 1
        '    'Dim MediaCalendarList As Generic.List(Of AdvantageFramework.Database.Entities.MediaCalendar) = Nothing
        '    Dim BookDate As Date = Date.MinValue
        '    Dim StartDate As Date = Date.MinValue
        '    Dim EndDate As Date = Date.MinValue

        '    MeasurementTrendDetailList = New Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail)

        '    Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

        '        AdvantageFramework.Services.ComScore.GetClientCredentials(DataContext, ComscoreClientID, ComscoreClientSecret, ComscoreAsClientID)

        '    End Using

        '    StationCallLetters = New String() {CallLetters}

        '    ComscoreDemoNumbers = DemographicList.Select(Function(E) E.ComscoreDemoNumber.Value).ToArray

        '    JSONOrdinalComscoreDemoNumbers = New Dictionary(Of Integer, Integer)

        '    LocalTimeViews = New Services.ComScore.Classes.LocalTimeViews
        '    LocalTimeViews.EndpointPath = "/mrtv/v7/local_time_views"

        '    For Each ShareHPUTBook In ShareHPUTBooks

        '        ComscoreShareBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, ShareHPUTBook.ShareBookID.Value)

        '        'MediaCalendarList = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaCalendar)
        '        '                     Where Entity.BroadcastMonth = ComscoreShareBook.Month AndAlso Entity.BroadcastYear = ComscoreShareBook.Year
        '        '                     Select Entity).ToList

        '        ComscoreHUTBook = Nothing

        '        HUTLocalTimeViewList = Nothing

        '        If ShareHPUTBook.HPUTBookID.HasValue AndAlso ShareHPUTBook.HPUTBookID.Value > 0 Then

        '            ComscoreHUTBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, ShareHPUTBook.HPUTBookID.Value)

        '        End If

        '        For Each DaysAndTime In MediaSpotTVResearchDaytimeTypes

        '            ComscoreStartTime = CDate(DaysAndTime.StartTime).ToString("HH:mm")
        '            ComscoreEndTime = CDate(DaysAndTime.EndTime).ToString("HH:mm")

        '            WeekCounter = 1

        '            StartDate = ComscoreShareBook.StartDateTime

        '            Do Until StartDate > ComscoreShareBook.EndDateTime

        '                SetComscoreQuarterHours(ComscoreStartTime, ComscoreEndTime, ComscoreQuarterHourStart, ComscoreQuarterHourEnd)

        '                LocalTimeViews.Request = GetMeasurementTrendDetailsRequest(StartDate, StartDate.AddDays(6), ComscoreQuarterHourStart, ComscoreQuarterHourEnd, MarketNumber, ComscoreDemoNumbers, StationCallLetters, GetDaysOfWeek(DaysAndTime), JSONOrdinalComscoreDemoNumbers, ComscoreAsClientID)

        '                GetBookDataForMeasurementTrendDetails(ComscoreClientID, ComscoreClientSecret, LocalTimeViews, ComscoreStartTime, ComscoreEndTime, ShareLocalTimeViewList)

        '                If ShareHPUTBook.HPUTBookID.HasValue AndAlso ShareHPUTBook.HPUTBookID.Value > 0 Then

        '                    LocalTimeViews.Request = GetMeasurementTrendDetailsRequest(ComscoreHUTBook.StartDateTime, ComscoreHUTBook.EndDateTime, ComscoreQuarterHourStart, ComscoreQuarterHourEnd, MarketNumber, ComscoreDemoNumbers, StationCallLetters, GetDaysOfWeek(DaysAndTime), JSONOrdinalComscoreDemoNumbers, ComscoreAsClientID)

        '                    GetBookDataForMeasurementTrendDetails(ComscoreClientID, ComscoreClientSecret, LocalTimeViews, ComscoreStartTime, ComscoreEndTime, HUTLocalTimeViewList)

        '                End If

        '                For Each ComscoreLocalTimeView In ShareLocalTimeViewList.ToList

        '                    'If MediaCalendarList.Any(Function(Entity) Entity.Date = CDate(ComscoreLocalTimeView.Week)) Then

        '                    MeasurementTrendDetail = New AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail

        '                    MeasurementTrendDetail.Book = "Week " & WeekCounter
        '                    MeasurementTrendDetail.Program = ComscoreLocalTimeView.ProgramName
        '                    MeasurementTrendDetail.Share = ComscoreLocalTimeView.Share_01
        '                    MeasurementTrendDetail.Rating = ComscoreLocalTimeView.Rating_01
        '                    MeasurementTrendDetail.HPUT = ComscoreLocalTimeView.HUT_01
        '                    MeasurementTrendDetail.Impressions = ComscoreLocalTimeView.AvgAud_01
        '                    MeasurementTrendDetail.WeekDate = StartDate

        '                    MeasurementTrendDetailList.Add(MeasurementTrendDetail)

        '                    'End If

        '                Next

        '                WeekCounter += 1

        '                StartDate = StartDate.AddDays(7)

        '            Loop

        '        Next

        '    Next

        '    GetMeasurementTrendDetails = MeasurementTrendDetailList

        'End Function
        'Public Function GetLeadInLeadOutDetails(DbContext As AdvantageFramework.Database.DbContext, MarketNumber As Integer, ShareBookID As Integer,
        '                                        HPUTBookID As Integer, CallLetters As String, DemoNumber As Integer,
        '                                        MediaSpotTVResearchDaytimeTypes As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaSpotTVResearchDaytimeType),
        '                                        Week As Date) As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutDetail)

        '    'objects
        '    Dim LeadInLeadOutDetails As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutDetail) = Nothing
        '    Dim ComscoreClientID As String = Nothing
        '    Dim ComscoreClientSecret As String = Nothing
        '    Dim LocalTimeViews As Services.ComScore.Classes.LocalTimeViews = Nothing
        '    Dim StationCallLetters As IEnumerable(Of String) = Nothing
        '    Dim ComscoreDemoNumbers As IEnumerable(Of Integer) = Nothing
        '    Dim JSONOrdinalComscoreDemoNumbers As Dictionary(Of Integer, Integer) = Nothing
        '    Dim ComscoreShareBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
        '    Dim ComscoreHUTBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
        '    Dim ComscoreQuarterHourStart As Date = Nothing
        '    Dim ComscoreQuarterHourEnd As Date = Nothing
        '    Dim ComscoreStartTime As Date = Nothing
        '    Dim ComscoreEndTime As Date = Nothing
        '    Dim ShareLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView) = Nothing
        '    Dim HUTLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView) = Nothing
        '    Dim LeadInLeadOutDetail As AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutDetail = Nothing
        '    Dim ComscoreAsClientID As String = Nothing
        '    'Dim WeekCounter As Integer = 1
        '    'Dim MediaCalendarList As Generic.List(Of AdvantageFramework.Database.Entities.MediaCalendar) = Nothing
        '    'Dim WeekDates As Generic.List(Of Date) = Nothing
        '    Dim EndDate As Date = Date.MinValue

        '    LeadInLeadOutDetails = New Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutDetail)

        '    Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

        '        AdvantageFramework.Services.ComScore.GetClientCredentials(DataContext, ComscoreClientID, ComscoreClientSecret, ComscoreAsClientID)

        '    End Using

        '    StationCallLetters = New String() {CallLetters}

        '    ComscoreDemoNumbers = New Integer() {DemoNumber}

        '    JSONOrdinalComscoreDemoNumbers = New Dictionary(Of Integer, Integer)

        '    LocalTimeViews = New Services.ComScore.Classes.LocalTimeViews
        '    LocalTimeViews.EndpointPath = "/mrtv/v7/local_time_views"

        '    ComscoreShareBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, ShareBookID)

        '    'MediaCalendarList = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaCalendar)
        '    '                     Where Entity.BroadcastMonth = ComscoreShareBook.Month AndAlso Entity.BroadcastYear = ComscoreShareBook.Year
        '    '                     Select Entity).ToList

        '    ComscoreHUTBook = Nothing

        '    HUTLocalTimeViewList = Nothing

        '    If HPUTBookID > 0 Then

        '        ComscoreHUTBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, HPUTBookID)

        '    End If

        '    For Each DaysAndTime In MediaSpotTVResearchDaytimeTypes

        '        ComscoreStartTime = CDate(DaysAndTime.StartTime).ToString("HH:mm")
        '        ComscoreEndTime = CDate(DaysAndTime.EndTime).ToString("HH:mm")

        '        EndDate = ComscoreShareBook.EndDateTime.AddDays(-1)

        '        SetComscoreQuarterHours(ComscoreStartTime, ComscoreEndTime, ComscoreQuarterHourStart, ComscoreQuarterHourEnd)

        '        LocalTimeViews.Request = GetLeadInLeadOutDetailsRequest(ComscoreShareBook.StartDateTime, EndDate, ComscoreQuarterHourStart, ComscoreQuarterHourEnd, MarketNumber, ComscoreDemoNumbers, StationCallLetters, GetDaysOfWeek(DaysAndTime), JSONOrdinalComscoreDemoNumbers, ComscoreAsClientID, Week)

        '        GetBookDataForLeadInLeadOutDetails(ComscoreClientID, ComscoreClientSecret, LocalTimeViews, ComscoreStartTime, ComscoreEndTime, ShareLocalTimeViewList)

        '        If HPUTBookID > 0 Then

        '            EndDate = ComscoreHUTBook.EndDateTime.AddDays(-1)

        '            LocalTimeViews.Request = GetLeadInLeadOutDetailsRequest(ComscoreHUTBook.StartDateTime, EndDate, ComscoreQuarterHourStart, ComscoreQuarterHourEnd, MarketNumber, ComscoreDemoNumbers, StationCallLetters, GetDaysOfWeek(DaysAndTime), JSONOrdinalComscoreDemoNumbers, ComscoreAsClientID, Week)

        '            GetBookDataForLeadInLeadOutDetails(ComscoreClientID, ComscoreClientSecret, LocalTimeViews, ComscoreStartTime, ComscoreEndTime, HUTLocalTimeViewList)

        '        End If

        '        'WeekCounter = 1

        '        'WeekDates = MediaCalendarList.Select(Function(Entity) Entity.BroadcastWeekDate).Distinct.ToList

        '        For Each ComscoreLocalTimeView In ShareLocalTimeViewList.OrderBy(Function(Entity) Entity.AdjustedHour)

        '            'If WeekDates.Any(Function(Entity) Entity.Date = CDate(ComscoreLocalTimeView.Week)) Then

        '            LeadInLeadOutDetail = New AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutDetail

        '            LeadInLeadOutDetail.Book = ComscoreShareBook.ID
        '            LeadInLeadOutDetail.Program = ComscoreLocalTimeView.ProgramName
        '            LeadInLeadOutDetail.Share = ComscoreLocalTimeView.Share_01
        '            LeadInLeadOutDetail.Rating = ComscoreLocalTimeView.Rating_01
        '            LeadInLeadOutDetail.Impressions = ComscoreLocalTimeView.AvgAud_01
        '            LeadInLeadOutDetail.HPUT = ComscoreLocalTimeView.HUT_01
        '            LeadInLeadOutDetail.Week = 0
        '            LeadInLeadOutDetail.AdjustedHour = ComscoreLocalTimeView.AdjustedHour

        '            LeadInLeadOutDetails.Add(LeadInLeadOutDetail)

        '            'WeekCounter += 1

        '            'End If

        '        Next

        '    Next

        '    GetLeadInLeadOutDetails = LeadInLeadOutDetails

        'End Function
        Private Function GetDaysOfWeek(DaysAndTime As AdvantageFramework.Classes.Media.Nielsen.MediaSpotTVResearchDaytimeType) As IEnumerable(Of String)

            'objects
            Dim DaysOfWeek As Generic.List(Of String) = Nothing

            DaysOfWeek = New Generic.List(Of String)

            If DaysAndTime.Sunday Then

                DaysOfWeek.Add("sun")

            End If

            If DaysAndTime.Monday Then

                DaysOfWeek.Add("mon")

            End If

            If DaysAndTime.Tuesday Then

                DaysOfWeek.Add("tue")

            End If

            If DaysAndTime.Wednesday Then

                DaysOfWeek.Add("wed")

            End If

            If DaysAndTime.Thursday Then

                DaysOfWeek.Add("thu")

            End If

            If DaysAndTime.Friday Then

                DaysOfWeek.Add("fri")

            End If

            If DaysAndTime.Saturday Then

                DaysOfWeek.Add("sat")

            End If

            GetDaysOfWeek = DaysOfWeek.ToArray

        End Function
        Private Sub SetDemoSpecificValues(DemoNumber As Integer, ComscoreLocalTimeView As AdvantageFramework.DTO.Media.ComscoreLocalTimeView, HUTLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView),
                                          ByRef TVWorksheetRatingAndShareData As AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData)

            'objects
            Dim UseHUT As Boolean = False

            'NOTE: we do not want to divide impressions here by 1000 as the worksheet code already does this!  Compare to overloaded Sub SetDemoSpecificValues
            If DemoNumber = 1 Then

                TVWorksheetRatingAndShareData.Share = ComscoreLocalTimeView.Share_01
                TVWorksheetRatingAndShareData.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_01, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                TVWorksheetRatingAndShareData.Universe = ComscoreLocalTimeView.Universe_01

                If UseHUT Then

                    TVWorksheetRatingAndShareData.Rating = TVWorksheetRatingAndShareData.Share * TVWorksheetRatingAndShareData.HPUT / 100
                    TVWorksheetRatingAndShareData.Impressions = TVWorksheetRatingAndShareData.Rating * TVWorksheetRatingAndShareData.Universe / 100

                Else

                    TVWorksheetRatingAndShareData.Rating = ComscoreLocalTimeView.Rating_01
                    TVWorksheetRatingAndShareData.Impressions = ComscoreLocalTimeView.AvgAud_01

                End If

                TVWorksheetRatingAndShareData.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_01 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                TVWorksheetRatingAndShareData.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_01 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            ElseIf DemoNumber = 2 Then

                TVWorksheetRatingAndShareData.Share = ComscoreLocalTimeView.Share_02
                TVWorksheetRatingAndShareData.HPUT = GetHPUT(DemoNumber, ComscoreLocalTimeView.HUT_02, HUTLocalTimeViewList, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, UseHUT)
                TVWorksheetRatingAndShareData.Universe = ComscoreLocalTimeView.Universe_02

                If UseHUT Then

                    TVWorksheetRatingAndShareData.Rating = TVWorksheetRatingAndShareData.Share * TVWorksheetRatingAndShareData.HPUT / 100
                    TVWorksheetRatingAndShareData.Impressions = TVWorksheetRatingAndShareData.Rating * TVWorksheetRatingAndShareData.Universe / 100

                Else

                    TVWorksheetRatingAndShareData.Rating = ComscoreLocalTimeView.Rating_02
                    TVWorksheetRatingAndShareData.Impressions = ComscoreLocalTimeView.AvgAud_02

                End If

                TVWorksheetRatingAndShareData.ComscoreMeetsDemoThreshold = ComscoreLocalTimeView.MeetsDemoThreshold_02 OrElse GetHUTDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)
                TVWorksheetRatingAndShareData.ComscoreMeetsHighQualityDemoThreshold = ComscoreLocalTimeView.MeetsHighQualityDemoThreshold_02 OrElse GetHUTHighQualityDemoThreshold(DemoNumber, ComscoreLocalTimeView.MarketNumber, ComscoreLocalTimeView.StationNumber, HUTLocalTimeViewList)

            End If

        End Sub
        Public Function GetLocalTimeViews(DbContext As AdvantageFramework.Database.DbContext, MarketNumber As Integer, StationNumber As Integer, ComscoreDemoNumber As Integer,
                                          SpotStartDateTime As DateTime, Optional ByVal MediaSpotTVResearchDaytimeTypeID As Integer = 0) As AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData

            'objects
            Dim TVWorksheetRatingAndShareData As AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData = Nothing
            Dim ComscoreClientID As String = Nothing
            Dim ComscoreClientSecret As String = Nothing
            Dim LocalTimeViews As Services.ComScore.Classes.LocalTimeViews = Nothing
            Dim JSONOrdinalComscoreDemoNumbers As Dictionary(Of Integer, Integer) = Nothing
            Dim SpotEndDateTime As DateTime = Nothing
            Dim ComscoreQuarterHourStart As Date = Nothing
            Dim ComscoreQuarterHourEnd As Date = Nothing
            Dim ShareLocalTimeViewList As Generic.List(Of AdvantageFramework.DTO.Media.ComscoreLocalTimeView) = Nothing
            Dim DemoNumber As Integer = 0
            Dim ResearchResult As AdvantageFramework.DTO.Media.SpotTV.ResearchResult = Nothing
            Dim ComscoreTVBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
            Dim MediaSpotTVResearchBook As AdvantageFramework.Database.Entities.MediaSpotTVResearchBook = Nothing
            Dim ComscoreAsClientID As String = Nothing
            Dim OldEndpointPath As String = Nothing
            Dim NewEndpointPath As String = Nothing
            Dim NewURLDate As Nullable(Of Date) = Nothing
            Dim UseNewURL As Boolean = False

            TVWorksheetRatingAndShareData = New AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData

            Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                AdvantageFramework.Services.ComScore.GetClientCredentials(DataContext, ComscoreClientID, ComscoreClientSecret, ComscoreAsClientID, OldEndpointPath, NewEndpointPath, NewURLDate)

            End Using

            JSONOrdinalComscoreDemoNumbers = New Dictionary(Of Integer, Integer)

            LocalTimeViews = New Services.ComScore.Classes.LocalTimeViews

            SpotEndDateTime = SpotStartDateTime.AddMinutes(1)

            SetComscoreQuarterHours(CDate(SpotStartDateTime.ToString("HH:mm")), CDate(SpotEndDateTime.ToString("HH:mm")), ComscoreQuarterHourStart, ComscoreQuarterHourEnd)

            If NewURLDate.HasValue AndAlso SpotStartDateTime >= NewURLDate.Value Then

                LocalTimeViews.EndpointPath = NewEndpointPath & "local_time_views"
                UseNewURL = True

            Else

                LocalTimeViews.EndpointPath = OldEndpointPath & "local_time_views"
                UseNewURL = False

            End If

            LocalTimeViews.Request = GetLocalTimeViewsRequest(SpotStartDateTime, SpotStartDateTime, ComscoreQuarterHourStart, ComscoreQuarterHourEnd, MarketNumber, ({ComscoreDemoNumber}), ({StationNumber}), GetDaysOfWeek(SpotStartDateTime), JSONOrdinalComscoreDemoNumbers, ComscoreAsClientID, DbContext)

            TVWorksheetRatingAndShareData.Request = LocalTimeViews.Request

            GetBookData(UseNewURL, ComscoreClientID, ComscoreClientSecret, LocalTimeViews, SpotStartDateTime, SpotEndDateTime, ShareLocalTimeViewList, TVWorksheetRatingAndShareData.Response)

            If ShareLocalTimeViewList IsNot Nothing AndAlso ShareLocalTimeViewList.Count = 1 Then

                TVWorksheetRatingAndShareData.Rating = ShareLocalTimeViewList(0).Rating_01
                TVWorksheetRatingAndShareData.Impressions = ShareLocalTimeViewList(0).AvgAud_01
                TVWorksheetRatingAndShareData.Universe = ShareLocalTimeViewList(0).Universe_01
                TVWorksheetRatingAndShareData.Share = ShareLocalTimeViewList(0).Share_01
                TVWorksheetRatingAndShareData.HPUT = ShareLocalTimeViewList(0).HUT_01
                TVWorksheetRatingAndShareData.ElapsedTime = ShareLocalTimeViewList(0).RequestProcessingTime

                TVWorksheetRatingAndShareData.ProgramName = ShareLocalTimeViewList(0).ProgramName
                TVWorksheetRatingAndShareData.MediaBroadcastWorksheetMarketDetailID = MediaSpotTVResearchDaytimeTypeID

            End If

            GetLocalTimeViews = TVWorksheetRatingAndShareData

        End Function
        Private Function GetDaysOfWeek(SpotDate As DateTime) As IEnumerable(Of String)

            'objects
            Dim DaysOfWeek As Generic.List(Of String) = Nothing

            DaysOfWeek = New Generic.List(Of String)

            If SpotDate.DayOfWeek = DayOfWeek.Sunday Then

                DaysOfWeek.Add("sun")

            End If

            If SpotDate.DayOfWeek = DayOfWeek.Monday Then

                DaysOfWeek.Add("mon")

            End If

            If SpotDate.DayOfWeek = DayOfWeek.Tuesday Then

                DaysOfWeek.Add("tue")

            End If

            If SpotDate.DayOfWeek = DayOfWeek.Wednesday Then

                DaysOfWeek.Add("wed")

            End If

            If SpotDate.DayOfWeek = DayOfWeek.Thursday Then

                DaysOfWeek.Add("thu")

            End If

            If SpotDate.DayOfWeek = DayOfWeek.Friday Then

                DaysOfWeek.Add("fri")

            End If

            If SpotDate.DayOfWeek = DayOfWeek.Saturday Then

                DaysOfWeek.Add("sat")

            End If

            GetDaysOfWeek = DaysOfWeek.ToArray

        End Function
        Public Function GetComScoreCDMAData(NielsenMarketNumber As Integer, ComscoreStationCode As Integer, NCCTVSyscodeID As Integer, Year As Integer, Month As Integer, Session As AdvantageFramework.Security.Session) As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.ComScoreCDMA)

            'objects
            Dim ComScoreCDMAs As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.ComScoreCDMA) = Nothing
            Dim SqlParameterNielsenMarketNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterComscoreStationCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSyscode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterYear As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMonth As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterNielsenMarketNumber = New System.Data.SqlClient.SqlParameter("@NIELSEN_MARKET_NUM", SqlDbType.Int)
            SqlParameterNielsenMarketNumber.Value = NielsenMarketNumber

            SqlParameterComscoreStationCode = New System.Data.SqlClient.SqlParameter("@ComscoreStationCode", SqlDbType.Int)
            SqlParameterComscoreStationCode.Value = ComscoreStationCode

            SqlParameterSyscode = New System.Data.SqlClient.SqlParameter("@NCCTVSyscodeID", SqlDbType.Int)
            SqlParameterSyscode.Value = NCCTVSyscodeID

            SqlParameterYear = New System.Data.SqlClient.SqlParameter("@Year", SqlDbType.SmallInt)
            SqlParameterYear.Value = If(Year < 2000, Year + 2000, Year)

            SqlParameterMonth = New System.Data.SqlClient.SqlParameter("@Month", SqlDbType.SmallInt)
            SqlParameterMonth.Value = Month

            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                NielsenDbContext.Database.Connection.Open()

                ComScoreCDMAs = NielsenDbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.SpotTV.ComScoreCDMA)("EXEC advsp_tv_worksheet_comscore_cdma @NIELSEN_MARKET_NUM, @ComscoreStationCode, @NCCTVSyscodeID, @Year, @Month",
                                                                                                                         SqlParameterNielsenMarketNumber, SqlParameterComscoreStationCode, SqlParameterSyscode, SqlParameterYear, SqlParameterMonth).ToList()

            End Using

            GetComScoreCDMAData = ComScoreCDMAs

        End Function

#Region "  Caching  "

        Private Function GetLocalTimeViewsRequestCache(StartDate As Date, EndDate As Date, MarketNumber As Integer, ComscoreDemoNumbers As IEnumerable(Of Integer),
                                                       StationNumbers As IEnumerable(Of Integer), ByRef JSONOrdinalComscoreDemoNumbers As Dictionary(Of Integer, Integer),
                                                       ComscoreAsClientID As String) As String

            'objects
            Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing
            Dim JTokenWriter As Newtonsoft.Json.Linq.JTokenWriter = Nothing
            Dim Fields As IEnumerable(Of String) = Nothing
            Dim DemoCounter As Integer = 0

            Fields = {"market_no", "station_no", "qtr_hour", "series_names", "day"} '"market_name","station_name", "days_of_week","network_name",

            JTokenWriter = New Newtonsoft.Json.Linq.JTokenWriter()
            JTokenWriter.WriteStartObject()

            JTokenWriter.WritePropertyName("as_client_id")
            JTokenWriter.WriteValue(ComscoreAsClientID)

            JTokenWriter.WritePropertyName("fields")

            JTokenWriter.WriteStartArray()

            For Each Field In Fields

                JTokenWriter.WriteValue(Field)

            Next

            For Each ComscoreDemoNumber In ComscoreDemoNumbers

                DemoCounter += 1

                If Not JSONOrdinalComscoreDemoNumbers.ContainsKey(DemoCounter) Then

                    JSONOrdinalComscoreDemoNumbers.Add(DemoCounter, ComscoreDemoNumber)

                End If

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("hut")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_hut")
                JTokenWriter.WriteEndObject()

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("universe")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_universe")
                JTokenWriter.WriteEndObject()

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("avg_aud")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_avg_aud")
                JTokenWriter.WriteEndObject()

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("meets_demo_threshold")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_meets_demo_threshold")
                JTokenWriter.WriteEndObject()

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("meets_high_quality_demo_threshold")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_meets_high_quality_demo_threshold")
                JTokenWriter.WriteEndObject()

                JTokenWriter.WriteStartObject()
                JTokenWriter.WritePropertyName("field")
                JTokenWriter.WriteValue("share")
                JTokenWriter.WritePropertyName("demo_no")
                JTokenWriter.WriteValue(ComscoreDemoNumber)
                JTokenWriter.WritePropertyName("alias")
                JTokenWriter.WriteValue(DemoCounter.ToString & "_demo_share")
                JTokenWriter.WriteEndObject()

            Next

            JTokenWriter.WriteEndArray()

            'filters
            JTokenWriter.WritePropertyName("filters")

            JTokenWriter.WriteStartArray()

            JTokenWriter.WriteStartArray()
            JTokenWriter.WriteValue("range")
            JTokenWriter.WriteValue("day")
            JTokenWriter.WriteValue(StartDate.ToString("yyyy-MM-dd"))
            JTokenWriter.WriteValue(EndDate.ToString("yyyy-MM-dd"))
            JTokenWriter.WriteEndArray()

            JTokenWriter.WriteStartArray()
            JTokenWriter.WriteValue("eq")
            JTokenWriter.WriteValue("market_no")
            JTokenWriter.WriteValue(MarketNumber)
            JTokenWriter.WriteEndArray()

            JTokenWriter.WriteStartArray()
            JTokenWriter.WriteValue("in")
            JTokenWriter.WriteValue("station_no")
            For Each StationNumber In StationNumbers

                JTokenWriter.WriteValue(StationNumber)

            Next
            JTokenWriter.WriteEndArray()

            JTokenWriter.WriteEndArray()

            'group by
            JTokenWriter.WritePropertyName("group_by")

            JTokenWriter.WriteStartArray()
            JTokenWriter.WriteValue("market_no")
            JTokenWriter.WriteValue("station_no")
            JTokenWriter.WriteValue("qtr_hour")
            JTokenWriter.WriteValue("day")
            JTokenWriter.WriteEndArray()

            'optional start_of_day
            JTokenWriter.WritePropertyName("start_of_day")
            JTokenWriter.WriteValue("3:00")

            JTokenWriter.WriteEndObject()

            JObject = JTokenWriter.Token

            'If Debugger.IsAttached Then

            '    Dim file As System.IO.StreamWriter
            '    file = My.Computer.FileSystem.OpenTextFileWriter("C:\Temp\Comscore\" & Now.ToString("yyyMMddhhmmssffff") & "_REQ.txt", False)
            '    file.WriteLine(JObject)
            '    file.Close()

            'End If

            GetLocalTimeViewsRequestCache = JObject.ToString

        End Function
        Public Function GetLocalTimeViewsCache(DbContext As AdvantageFramework.Database.DbContext, StationNumber As Integer, DemographicList As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Demographic), ShareHPUTBooks As Generic.List(Of AdvantageFramework.DTO.Media.ShareHPUTBook),
                                               MediaSpotTVResearchDaytimeTypes As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaSpotTVResearchDaytimeType), MarketNumber As Integer,
                                               AllowDownloadingFromAPI As Boolean) As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData)

            'objects
            Dim TVWorksheetRatingAndShareDataList As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData) = Nothing
            Dim ComscoreClientID As String = Nothing
            Dim ComscoreClientSecret As String = Nothing
            Dim LocalTimeViews As Services.ComScore.Classes.LocalTimeViews = Nothing
            Dim StationNumbers As IEnumerable(Of Integer) = Nothing
            Dim ComscoreDemoNumbers As IEnumerable(Of Integer) = Nothing
            Dim JSONOrdinalComscoreDemoNumbers As Dictionary(Of Integer, Integer) = Nothing
            Dim ComscoreShareBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
            Dim ComscoreHUTBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
            Dim TVWorksheetRatingAndShareData As AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData = Nothing
            Dim ComscoreAsClientID As String = Nothing
            Dim EndDate As Date = Date.MinValue
            Dim DemoNumbersCached As Generic.List(Of Integer) = Nothing
            Dim DemoNumbersToCache As Generic.List(Of Integer) = Nothing
            Dim PrimaryDemoNumber As Nullable(Of Integer) = Nothing
            Dim SecondaryDemoNumber As Nullable(Of Integer) = Nothing
            Dim LocalMarketNumber As Short = 0
            Dim OldEndpointPath As String = Nothing
            Dim NewEndpointPath As String = Nothing
            Dim NewURLDate As Nullable(Of Date) = Nothing
            Dim UseNewURL As Boolean = False

            LocalMarketNumber = DbContext.Database.SqlQuery(Of Short)(String.Format("exec advsp_comscore_get_new_market_number {0}", MarketNumber)).FirstOrDefault

            StationNumbers = New Integer() {StationNumber}

            ComscoreDemoNumbers = DemographicList.Select(Function(E) E.ComscoreDemoNumber.Value).ToArray

            ' All calls from the Worksheet should pass False for this paramter
            If AllowDownloadingFromAPI Then

                Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                    AdvantageFramework.Services.ComScore.GetClientCredentials(DataContext, ComscoreClientID, ComscoreClientSecret, ComscoreAsClientID, OldEndpointPath, NewEndpointPath, NewURLDate)

                End Using

                JSONOrdinalComscoreDemoNumbers = New Dictionary(Of Integer, Integer)

                LocalTimeViews = New Services.ComScore.Classes.LocalTimeViews

                For Each ShareHPUTBook In ShareHPUTBooks

                    ComscoreHUTBook = Nothing

                    DemoNumbersCached = (From Entity In AdvantageFramework.Database.Procedures.ComscoreCacheHeader.Load(DbContext)
                                         Where Entity.BookID = ShareHPUTBook.ShareBookID.Value AndAlso
                                               Entity.MarketNumber = LocalMarketNumber AndAlso
                                               Entity.StationNumber = StationNumber AndAlso
                                               ComscoreDemoNumbers.Contains(Entity.DemoNumber)
                                         Select Entity.DemoNumber).ToList

                    DemoNumbersToCache = (From Demo In ComscoreDemoNumbers
                                          Where DemoNumbersCached.Contains(Demo) = False
                                          Select Demo).ToList

                    If DemoNumbersToCache.Count > 0 Then

                        ComscoreShareBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, ShareHPUTBook.ShareBookID.Value)

                        EndDate = ComscoreShareBook.EndDateTime.AddDays(-1)

                        If NewURLDate.HasValue AndAlso ComscoreShareBook.StartDateTime >= NewURLDate.Value Then

                            LocalTimeViews.EndpointPath = NewEndpointPath & "local_time_views"
                            UseNewURL = True

                        Else

                            LocalTimeViews.EndpointPath = OldEndpointPath & "local_time_views"
                            UseNewURL = False

                        End If

                        LocalTimeViews.Request = GetLocalTimeViewsRequestCache(ComscoreShareBook.StartDateTime, EndDate, LocalMarketNumber, DemoNumbersToCache, StationNumbers, JSONOrdinalComscoreDemoNumbers, ComscoreAsClientID)

                        CacheBookData(UseNewURL, ComscoreClientID, ComscoreClientSecret, DbContext, ComscoreShareBook.ID, JSONOrdinalComscoreDemoNumbers, LocalTimeViews, LocalMarketNumber, DemoNumbersToCache, StationNumbers)

                    End If

                    If ShareHPUTBook.HPUTBookID.HasValue AndAlso ShareHPUTBook.HPUTBookID.Value > 0 Then

                        ComscoreHUTBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, ShareHPUTBook.HPUTBookID.Value)

                        EndDate = ComscoreHUTBook.EndDateTime.AddDays(-1)

                        DemoNumbersCached = (From Entity In AdvantageFramework.Database.Procedures.ComscoreCacheHeader.Load(DbContext)
                                             Where Entity.BookID = ShareHPUTBook.HPUTBookID.Value AndAlso
                                                   Entity.MarketNumber = LocalMarketNumber AndAlso
                                                   Entity.StationNumber = StationNumber AndAlso
                                                   ComscoreDemoNumbers.Contains(Entity.DemoNumber)
                                             Select Entity.DemoNumber).ToList

                        DemoNumbersToCache = (From Demo In ComscoreDemoNumbers
                                              Where DemoNumbersCached.Contains(Demo) = False
                                              Select Demo).ToList

                        If DemoNumbersToCache.Count > 0 Then

                            If NewURLDate.HasValue AndAlso ComscoreHUTBook.StartDateTime >= NewURLDate.Value Then

                                LocalTimeViews.EndpointPath = NewEndpointPath & "local_time_views"
                                UseNewURL = True

                            Else

                                LocalTimeViews.EndpointPath = OldEndpointPath & "local_time_views"
                                UseNewURL = False

                            End If

                            LocalTimeViews.Request = GetLocalTimeViewsRequestCache(ComscoreHUTBook.StartDateTime, EndDate, LocalMarketNumber, DemoNumbersToCache, StationNumbers, JSONOrdinalComscoreDemoNumbers, ComscoreAsClientID)

                            CacheBookData(UseNewURL, ComscoreClientID, ComscoreClientSecret, DbContext, ComscoreHUTBook.ID, JSONOrdinalComscoreDemoNumbers, LocalTimeViews, LocalMarketNumber, DemoNumbersToCache, StationNumbers)

                        End If

                    End If

                Next

            End If

            If ComscoreDemoNumbers.Count > 0 Then

                PrimaryDemoNumber = ComscoreDemoNumbers(0)

            End If

            If ComscoreDemoNumbers.Count > 1 Then

                SecondaryDemoNumber = ComscoreDemoNumbers(1)

            End If

            TVWorksheetRatingAndShareDataList = New Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData)

            For Each ShareHPUTBook In ShareHPUTBooks

                TVWorksheetRatingAndShareDataList.AddRange(LoadRatingsFromCache(DbContext, LocalMarketNumber, ShareHPUTBook.ShareBookID.Value, ShareHPUTBook.HPUTBookID, StationNumbers, PrimaryDemoNumber, SecondaryDemoNumber, MediaSpotTVResearchDaytimeTypes))

            Next

            GetLocalTimeViewsCache = TVWorksheetRatingAndShareDataList

        End Function
        Private Function CacheBookData(UseNewURL As Boolean, ComscoreClientID As String, ComscoreClientSecret As String, DbContext As AdvantageFramework.Database.DbContext, BookID As Integer, JSONOrdinalComscoreDemoNumbers As Dictionary(Of Integer, Integer),
                                       LocalTimeViews As Services.ComScore.Classes.LocalTimeViews, MktNumber As Integer, DemoNumbersToCache As Generic.List(Of Integer), StationNumbers As IEnumerable(Of Integer)) As Boolean

            'objects
            Dim JSONString As String = Nothing
            Dim Api As Services.ComScore.Classes.Api = Nothing
            Dim Request As Services.ComScore.Classes.Request = Nothing
            Dim Response As Services.ComScore.Classes.Response = Nothing
            Dim JObject As Newtonsoft.Json.Linq.JObject = Nothing
            Dim JArrayColumns As Newtonsoft.Json.Linq.JArray = Nothing
            Dim Columns As List(Of String) = Nothing
            Dim JArray As Newtonsoft.Json.Linq.JArray = Nothing
            Dim LocalTimeViewCache As Services.ComScore.Classes.LocalTimeViewCache = Nothing
            Dim JsonPropertyAttribute As Newtonsoft.Json.JsonPropertyAttribute = Nothing
            Dim UnderlyingType As System.Type = Nothing
            Dim LocalTimeViewCacheList As Generic.List(Of Services.ComScore.Classes.LocalTimeViewCache) = Nothing
            Dim PropertyInfoArray As Reflection.PropertyInfo() = Nothing
            Dim DemoNumber As Integer = 0
            Dim ComscoreCacheHeaders As Generic.List(Of AdvantageFramework.Database.Entities.ComscoreCacheHeader) = Nothing
            Dim ComscoreCacheDetails As Generic.List(Of AdvantageFramework.Database.Entities.ComscoreCacheDetail) = Nothing
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim IsCached As Boolean = False
            Dim ComscoreCacheHeader As AdvantageFramework.Database.Entities.ComscoreCacheHeader = Nothing

            LocalTimeViewCacheList = New Generic.List(Of Services.ComScore.Classes.LocalTimeViewCache)

            JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(LocalTimeViews)

            If UseNewURL Then

                Api = New Services.ComScore.Classes.Api(New Uri(AdvantageFramework.ComScore.COMSCORE_URL), ComscoreClientID, ComscoreClientSecret, 0)

            Else

                Api = New Services.ComScore.Classes.Api(New Uri(AdvantageFramework.ComScore.OLD_COMSCORE_URL), ComscoreClientID, ComscoreClientSecret, 0)

            End If

            Request = New Services.ComScore.Classes.Request(JSONString)

            Do While Request IsNot Nothing

                Response = Api.RetrievePage(Request)

                If Response IsNot Nothing AndAlso Response.Status = "success" Then

                    JObject = Newtonsoft.Json.Linq.JObject.Parse(Response.RawResponse)

                    'If Debugger.IsAttached Then

                    '    Dim file As System.IO.StreamWriter
                    '    file = My.Computer.FileSystem.OpenTextFileWriter("C:\Temp\Comscore\" & Now.ToString("yyyMMddhhmmssffff") & "_RESP.txt", False)
                    '    file.WriteLine(JObject)
                    '    file.Close()

                    'End If

                    JArrayColumns = Newtonsoft.Json.Linq.JArray.Parse(JObject.SelectToken("result_columns").ToString)

                    Columns = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of String))(JArrayColumns.ToString)

                    JArray = Newtonsoft.Json.Linq.JArray.Parse(JObject.SelectToken("result_rows").ToString)

                    LocalTimeViewCache = New Services.ComScore.Classes.LocalTimeViewCache

                    PropertyInfoArray = LocalTimeViewCache.GetType.GetProperties

                    For i As Integer = 0 To JArray.Count - 1

                        LocalTimeViewCache = New Services.ComScore.Classes.LocalTimeViewCache

                        For Each Column In Columns

                            For Each PropertyInfo In PropertyInfoArray

                                JsonPropertyAttribute = (From A In PropertyInfo.GetCustomAttributes(False).OfType(Of Newtonsoft.Json.JsonPropertyAttribute)
                                                         Where A.PropertyName = Column).SingleOrDefault

                                If JsonPropertyAttribute IsNot Nothing Then

                                    UnderlyingType = AdvantageFramework.ClassUtilities.GetUnderlyingType(PropertyInfo.PropertyType)

                                    If UnderlyingType Is GetType(String) Then

                                        PropertyInfo.SetValue(LocalTimeViewCache, JArray(i).Item(Columns.IndexOf(Column)).ToString)
                                        Exit For

                                    ElseIf UnderlyingType Is GetType(Decimal) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(LocalTimeViewCache, CDec(JArray(i).Item(Columns.IndexOf(Column))))
                                            Exit For

                                        End If

                                    ElseIf UnderlyingType Is GetType(Integer) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(LocalTimeViewCache, CInt(JArray(i).Item(Columns.IndexOf(Column))))
                                            Exit For

                                        End If

                                    ElseIf UnderlyingType Is GetType(System.String()) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(LocalTimeViewCache, JArray(i).Item(Columns.IndexOf(Column)).ToObject(Of System.String()))
                                            Exit For

                                        End If

                                    ElseIf UnderlyingType Is GetType(Boolean) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(LocalTimeViewCache, CBool(JArray(i).Item(Columns.IndexOf(Column))))
                                            Exit For

                                        End If

                                    ElseIf UnderlyingType Is GetType(Date) Then

                                        If Not JArray(i).Item(Columns.IndexOf(Column)).ToString = "" Then

                                            PropertyInfo.SetValue(LocalTimeViewCache, CDate(JArray(i).Item(Columns.IndexOf(Column))))
                                            Exit For

                                        End If

                                    End If

                                End If

                            Next

                        Next

                        LocalTimeViewCacheList.Add(LocalTimeViewCache)

                    Next

                    Request = Api.NextPageRequest(Response)

                Else

                    Request = Nothing

                End If

            Loop

            If LocalTimeViewCacheList.Count > 0 Then

                ComscoreCacheHeaders = New Generic.List(Of AdvantageFramework.Database.Entities.ComscoreCacheHeader)

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    For Each KeyValuePair In JSONOrdinalComscoreDemoNumbers

                        DemoNumber = KeyValuePair.Value

                        ComscoreCacheHeaders = (From Entity In LocalTimeViewCacheList
                                                Select Entity.MarketNumber, Entity.StationNumber).Distinct.ToList.Select(Function(L) New AdvantageFramework.Database.Entities.ComscoreCacheHeader With {.BookID = BookID,
                                                                                                                      .MarketNumber = L.MarketNumber,
                                                                                                                      .StationNumber = L.StationNumber,
                                                                                                                      .DemoNumber = DemoNumber}).ToList

                        If ComscoreCacheHeaders.Count = 0 Then

                            For Each StationNbr In StationNumbers

                                If (From Entity In AdvantageFramework.Database.Procedures.ComscoreCacheHeader.Load(DbContext)
                                    Where Entity.BookID = BookID AndAlso
                                          Entity.MarketNumber = MktNumber AndAlso
                                          Entity.StationNumber = StationNbr AndAlso
                                          Entity.DemoNumber = DemoNumber
                                    Select Entity).Any = False Then

                                    ComscoreCacheHeader = New AdvantageFramework.Database.Entities.ComscoreCacheHeader
                                    ComscoreCacheHeader.BookID = BookID
                                    ComscoreCacheHeader.MarketNumber = MktNumber
                                    ComscoreCacheHeader.StationNumber = StationNbr
                                    ComscoreCacheHeader.DemoNumber = DemoNumber

                                    AdvantageFramework.Database.Procedures.ComscoreCacheHeader.Insert(DbContext, ComscoreCacheHeader)

                                End If

                            Next

                        End If

                        For Each ComscoreCacheHeader In ComscoreCacheHeaders

                            If (From Entity In AdvantageFramework.Database.Procedures.ComscoreCacheHeader.Load(DbContext)
                                Where Entity.BookID = BookID AndAlso
                                      Entity.MarketNumber = ComscoreCacheHeader.MarketNumber AndAlso
                                      Entity.StationNumber = ComscoreCacheHeader.StationNumber AndAlso
                                      Entity.DemoNumber = ComscoreCacheHeader.DemoNumber
                                Select Entity).Any = False Then

                                If AdvantageFramework.Database.Procedures.ComscoreCacheHeader.Insert(DbContext, ComscoreCacheHeader) Then

                                    If KeyValuePair.Key = 1 Then

                                        ComscoreCacheDetails = (From Entity In LocalTimeViewCacheList
                                                                Where Entity.MarketNumber = ComscoreCacheHeader.MarketNumber AndAlso
                                                                  Entity.StationNumber = ComscoreCacheHeader.StationNumber
                                                                Select Entity).ToList.Select(Function(L) New AdvantageFramework.Database.Entities.ComscoreCacheDetail With {
                                                                                    .ComscoreCacheHeaderID = ComscoreCacheHeader.ID,
                                                                                    .QuarterHour = L.QtrDateTime,
                                                                                    .SeriesName = L.SeriesName,
                                                                                    .Share = L.Share,
                                                                                    .AverageAudience = L.AverageAudience,
                                                                                    .SIU = L.SIU,
                                                                                    .Universe = L.Universe,
                                                                                    .MeetsDemoThreshold = L.MeetsDemoThreshold,
                                                                                    .MeetsHighQualityDemoThreshold = L.MeetsHighQualityDemoThreshold}).ToList

                                    Else

                                        ComscoreCacheDetails = (From Entity In LocalTimeViewCacheList
                                                                Where Entity.MarketNumber = ComscoreCacheHeader.MarketNumber AndAlso
                                                                  Entity.StationNumber = ComscoreCacheHeader.StationNumber
                                                                Select Entity).ToList.Select(Function(L) New AdvantageFramework.Database.Entities.ComscoreCacheDetail With {
                                                                                    .ComscoreCacheHeaderID = ComscoreCacheHeader.ID,
                                                                                    .QuarterHour = L.QtrDateTime,
                                                                                    .SeriesName = L.SeriesName,
                                                                                    .Share = L.Share2,
                                                                                    .AverageAudience = L.AverageAudience2,
                                                                                    .SIU = L.SIU2,
                                                                                    .Universe = L.Universe2,
                                                                                    .MeetsDemoThreshold = L.MeetsDemoThreshold2,
                                                                                    .MeetsHighQualityDemoThreshold = L.MeetsHighQualityDemoThreshold2}).ToList

                                    End If

                                    BulkInsertCacheList(DbContext, DbTransaction, ComscoreCacheDetails)

                                End If

                            End If

                        Next

                    Next

                    DbTransaction.Commit()

                    IsCached = True

            Catch ex As Exception
            DbTransaction.Rollback()

            End Try

            Else

            If Response IsNot Nothing AndAlso Response.Warnings IsNot Nothing AndAlso Response.Warnings.Any Then

                If Response.Warnings.Any(Function(W) W.Code = 75) Then 'Some demographics requested are not supported for the markets requested. - generally means they do not subscribe to this market

                    For Each StationNumber In StationNumbers

                        For Each DemoNumber In DemoNumbersToCache

                            ComscoreCacheHeader = New AdvantageFramework.Database.Entities.ComscoreCacheHeader
                            ComscoreCacheHeader.BookID = BookID
                            ComscoreCacheHeader.MarketNumber = MktNumber
                            ComscoreCacheHeader.StationNumber = StationNumber
                            ComscoreCacheHeader.DemoNumber = DemoNumber
                            ComscoreCacheHeader.Warning = String.Join(",", Response.Warnings.Select(Function(W) W.Code & "|" & W.Message).ToArray)

                            AdvantageFramework.Database.Procedures.ComscoreCacheHeader.Insert(DbContext, ComscoreCacheHeader)

                        Next

                    Next

                ElseIf Response.Warnings.Any(Function(W) W.Code = 105) Then ' generally means that a particular station cannot be reported

                    For Each StationNumber In StationNumbers

                        For Each DemoNumber In DemoNumbersToCache

                            ComscoreCacheHeader = New AdvantageFramework.Database.Entities.ComscoreCacheHeader
                            ComscoreCacheHeader.BookID = BookID
                            ComscoreCacheHeader.MarketNumber = MktNumber
                            ComscoreCacheHeader.StationNumber = StationNumber
                            ComscoreCacheHeader.DemoNumber = DemoNumber
                            ComscoreCacheHeader.Warning = String.Join(",", Response.Warnings.Select(Function(W) W.Code & "|" & W.Message).ToArray)

                            AdvantageFramework.Database.Procedures.ComscoreCacheHeader.Insert(DbContext, ComscoreCacheHeader)

                        Next

                    Next

                    IsCached = True

                ElseIf Response.Warnings.Any Then

                    For Each StationNumber In StationNumbers

                        For Each DemoNumber In DemoNumbersToCache

                            ComscoreCacheHeader = New AdvantageFramework.Database.Entities.ComscoreCacheHeader
                            ComscoreCacheHeader.BookID = BookID
                            ComscoreCacheHeader.MarketNumber = MktNumber
                            ComscoreCacheHeader.StationNumber = StationNumber
                            ComscoreCacheHeader.DemoNumber = DemoNumber
                            ComscoreCacheHeader.Warning = String.Join(",", Response.Warnings.Select(Function(W) W.Code & "|" & W.Message).ToArray)

                            AdvantageFramework.Database.Procedures.ComscoreCacheHeader.Insert(DbContext, ComscoreCacheHeader)

                        Next

                    Next

                End If

            End If

            End If

            CacheBookData = IsCached

            End Function
        Private Sub BulkInsertCacheList(DbContext As AdvantageFramework.Database.DbContext, DbContextTransaction As Entity.DbContextTransaction,
                                        ComscoreCacheDetails As Generic.List(Of AdvantageFramework.Database.Entities.ComscoreCacheDetail))

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = ComscoreCacheDetails.ToDataTable

            Using SqlBulkCopy = New System.Data.SqlClient.SqlBulkCopy(DirectCast(DbContext.Database.Connection, SqlClient.SqlConnection), SqlClient.SqlBulkCopyOptions.CheckConstraints, DirectCast(DbContextTransaction.UnderlyingTransaction, SqlClient.SqlTransaction))

                With SqlBulkCopy

                    .ColumnMappings.Add("ComscoreCacheHeaderID", "COMSCORE_CACHE_HEADER_ID")
                    .ColumnMappings.Add("QuarterHour", "QTR_HR")
                    .ColumnMappings.Add("SeriesName", "SERIES_NAME")
                    .ColumnMappings.Add("Share", "SHARE")
                    .ColumnMappings.Add("AverageAudience", "AVG_AUD")
                    .ColumnMappings.Add("SIU", "SIU")
                    .ColumnMappings.Add("Universe", "UNIVERSE")
                    .ColumnMappings.Add("MeetsDemoThreshold", "MEETS_DEMO_THRESHOLD")
                    .ColumnMappings.Add("MeetsHighQualityDemoThreshold", "MEETS_HQ_DEMO_THRESHOLD")

                    .BulkCopyTimeout = 0
                    .BatchSize = DataTable.Rows.Count
                    .DestinationTableName = "COMSCORE_CACHE_DETAIL"
                    .WriteToServer(DataTable)

                End With

            End Using

        End Sub
        <System.Runtime.CompilerServices.Extension>
        Private Function ToDataTable(Of T)(EntityList As IList(Of T)) As System.Data.DataTable

            Dim PropertyDescriptorCollection As System.ComponentModel.PropertyDescriptorCollection = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            DataTable = New System.Data.DataTable

            PropertyDescriptorCollection = System.ComponentModel.TypeDescriptor.GetProperties(GetType(T))

            For Each Prop As System.ComponentModel.PropertyDescriptor In PropertyDescriptorCollection

                DataTable.Columns.Add(Prop.Name, If(Nullable.GetUnderlyingType(Prop.PropertyType), Prop.PropertyType))

            Next

            For Each Entity As T In EntityList

                DataRow = DataTable.NewRow()

                For Each Prop As System.ComponentModel.PropertyDescriptor In PropertyDescriptorCollection

                    DataRow(Prop.Name) = If(Prop.GetValue(Entity), DBNull.Value)

                Next

                DataTable.Rows.Add(DataRow)

            Next

            Return DataTable

        End Function
        Private Function LoadRatingsFromCache(DbContext As AdvantageFramework.Database.DbContext, MarketNumber As Integer, ShareBookID As Integer, SIUBookID As Nullable(Of Integer), StationCodes As IEnumerable(Of Integer),
                                              PrimaryDemoNumber As Integer, SecondaryDemoNumber As Nullable(Of Integer),
                                              MediaSpotTVResearchDaytimeTypes As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaSpotTVResearchDaytimeType)) As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData)

            'objects
            Dim TVWorksheetRatingAndShareDataList As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData) = Nothing
            Dim SqlParameterMarketNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterShareBookID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSIUBookID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStationCodes As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPrimaryDemoNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSecondaryDemoNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaSpotTVDaytimeType As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterMarketNumber = New System.Data.SqlClient.SqlParameter("@MARKET_NUMBER", SqlDbType.Int)
            SqlParameterMarketNumber.Value = MarketNumber

            SqlParameterShareBookID = New System.Data.SqlClient.SqlParameter("@SHARE_BOOK_ID", SqlDbType.Int)
            SqlParameterShareBookID.Value = ShareBookID

            SqlParameterSIUBookID = New System.Data.SqlClient.SqlParameter("@SIU_BOOK_ID", SqlDbType.Int)

            If SIUBookID.HasValue Then

                SqlParameterSIUBookID.Value = SIUBookID.Value

            Else

                SqlParameterSIUBookID.Value = System.DBNull.Value

            End If

            SqlParameterStationCodes = New System.Data.SqlClient.SqlParameter("@STATION_CODES", SqlDbType.VarChar)
            SqlParameterStationCodes.Value = String.Join(",", StationCodes.ToArray)

            SqlParameterPrimaryDemoNumber = New System.Data.SqlClient.SqlParameter("@PRIMARY_DEMO_NUMBER", SqlDbType.Int)
            SqlParameterPrimaryDemoNumber.Value = PrimaryDemoNumber

            SqlParameterSecondaryDemoNumber = New System.Data.SqlClient.SqlParameter("@SECONDARY_DEMO_NUMBER", SqlDbType.Int)

            If SecondaryDemoNumber.HasValue Then

                SqlParameterSecondaryDemoNumber.Value = SecondaryDemoNumber

            Else

                SqlParameterSecondaryDemoNumber.Value = System.DBNull.Value

            End If

            SqlParameterMediaSpotTVDaytimeType = New System.Data.SqlClient.SqlParameter("@MEDIA_SPOT_TV_DAYTIME_TYPE", SqlDbType.Structured)
            SqlParameterMediaSpotTVDaytimeType.TypeName = "MEDIA_SPOT_TV_DAYTIME_TYPE"
            SqlParameterMediaSpotTVDaytimeType.Value = ToDataTable(MediaSpotTVResearchDaytimeTypes)

            TVWorksheetRatingAndShareDataList = DbContext.Database.SqlQuery(Of AdvantageFramework.Classes.Media.Nielsen.TVWorksheetRatingAndShareData)("EXEC advsp_comscore_tv_worksheet_rating @MARKET_NUMBER, @SHARE_BOOK_ID, @SIU_BOOK_ID, @STATION_CODES, @PRIMARY_DEMO_NUMBER, @SECONDARY_DEMO_NUMBER, @MEDIA_SPOT_TV_DAYTIME_TYPE",
                                                                                                                                                                  SqlParameterMarketNumber, SqlParameterShareBookID, SqlParameterSIUBookID, SqlParameterStationCodes,
                                                                                                                                                                  SqlParameterPrimaryDemoNumber, SqlParameterSecondaryDemoNumber, SqlParameterMediaSpotTVDaytimeType).ToList()

            LoadRatingsFromCache = TVWorksheetRatingAndShareDataList

        End Function
        Public Function CacheBooks(DbContext As AdvantageFramework.Database.DbContext, StationNumber As Integer, ComscoreDemoNumbers As IEnumerable(Of Integer), ShareHPUTBooks As Generic.List(Of AdvantageFramework.DTO.Media.ShareHPUTBook),
                                   MarketNumber As Integer) As Boolean

            'objects
            Dim ComscoreClientID As String = Nothing
            Dim ComscoreClientSecret As String = Nothing
            Dim LocalTimeViews As Services.ComScore.Classes.LocalTimeViews = Nothing
            Dim StationNumbers As IEnumerable(Of Integer) = Nothing
            Dim JSONOrdinalComscoreDemoNumbers As Dictionary(Of Integer, Integer) = Nothing
            Dim ComscoreShareBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
            Dim ComscoreHUTBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
            Dim ComscoreAsClientID As String = Nothing
            Dim EndDate As Date = Date.MinValue
            Dim DemoNumbersCached As Generic.List(Of Integer) = Nothing
            Dim DemoNumbersToCache As Generic.List(Of Integer) = Nothing
            Dim LocalMarketNumber As Short = 0
            Dim OldEndpointPath As String = Nothing
            Dim NewEndpointPath As String = Nothing
            Dim NewURLDate As Nullable(Of Date) = Nothing
            Dim UseNewURL As Boolean = False
            Dim IsCached As Boolean = True
            Dim [Continue] As Boolean = True

            LocalMarketNumber = DbContext.Database.SqlQuery(Of Short)(String.Format("exec advsp_comscore_get_new_market_number {0}", MarketNumber)).FirstOrDefault

            Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                AdvantageFramework.Services.ComScore.GetClientCredentials(DataContext, ComscoreClientID, ComscoreClientSecret, ComscoreAsClientID, OldEndpointPath, NewEndpointPath, NewURLDate)

            End Using

            StationNumbers = New Integer() {StationNumber}

            JSONOrdinalComscoreDemoNumbers = New Dictionary(Of Integer, Integer)

            LocalTimeViews = New Services.ComScore.Classes.LocalTimeViews

            For Each ShareHPUTBook In ShareHPUTBooks

                ComscoreHUTBook = Nothing

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.COMSCORE_CACHE_HEADER SET LAST_ACCESSED = getdate() WHERE COMSCORE_TV_BOOK_ID = {0} AND MARKET_NUMBER = {1} AND STATION_NUMBER = {2} AND DEMO_NUMBER IN ({3})", ShareHPUTBook.ShareBookID.Value, MarketNumber, StationNumber, String.Join(",", ComscoreDemoNumbers.ToArray)))

                DemoNumbersCached = (From Entity In AdvantageFramework.Database.Procedures.ComscoreCacheHeader.Load(DbContext)
                                     Where Entity.BookID = ShareHPUTBook.ShareBookID.Value AndAlso
                                           Entity.MarketNumber = LocalMarketNumber AndAlso
                                           Entity.StationNumber = StationNumber AndAlso
                                           ComscoreDemoNumbers.Contains(Entity.DemoNumber)
                                     Select Entity.DemoNumber).ToList

                DemoNumbersToCache = (From Demo In ComscoreDemoNumbers
                                      Where DemoNumbersCached.Contains(Demo) = False
                                      Select Demo).ToList

                If DemoNumbersToCache.Count > 0 Then

                    ComscoreShareBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, ShareHPUTBook.ShareBookID.Value)

                    EndDate = ComscoreShareBook.EndDateTime.AddDays(-1)

                    If NewURLDate.HasValue AndAlso ComscoreShareBook.StartDateTime >= NewURLDate.Value Then

                        LocalTimeViews.EndpointPath = NewEndpointPath & "local_time_views"
                        UseNewURL = True

                    Else

                        LocalTimeViews.EndpointPath = OldEndpointPath & "local_time_views"
                        UseNewURL = False

                    End If

                    LocalTimeViews.Request = GetLocalTimeViewsRequestCache(ComscoreShareBook.StartDateTime, EndDate, LocalMarketNumber, DemoNumbersToCache, StationNumbers, JSONOrdinalComscoreDemoNumbers, ComscoreAsClientID)

                    IsCached = CacheBookData(UseNewURL, ComscoreClientID, ComscoreClientSecret, DbContext, ComscoreShareBook.ID, JSONOrdinalComscoreDemoNumbers, LocalTimeViews, LocalMarketNumber, DemoNumbersToCache, StationNumbers)

                    [Continue] = IsCached

                End If

                If [Continue] AndAlso ShareHPUTBook.HPUTBookID.HasValue AndAlso ShareHPUTBook.HPUTBookID.Value > 0 Then

                    ComscoreHUTBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, ShareHPUTBook.HPUTBookID.Value)

                    EndDate = ComscoreHUTBook.EndDateTime.AddDays(-1)

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.COMSCORE_CACHE_HEADER SET LAST_ACCESSED = getdate() WHERE COMSCORE_TV_BOOK_ID = {0} AND MARKET_NUMBER = {1} AND STATION_NUMBER = {2} AND DEMO_NUMBER IN ({3})", ShareHPUTBook.HPUTBookID.Value, MarketNumber, StationNumber, String.Join(",", ComscoreDemoNumbers.ToArray)))

                    DemoNumbersCached = (From Entity In AdvantageFramework.Database.Procedures.ComscoreCacheHeader.Load(DbContext)
                                         Where Entity.BookID = ShareHPUTBook.HPUTBookID.Value AndAlso
                                               Entity.MarketNumber = LocalMarketNumber AndAlso
                                               Entity.StationNumber = StationNumber AndAlso
                                               ComscoreDemoNumbers.Contains(Entity.DemoNumber)
                                         Select Entity.DemoNumber).ToList

                    DemoNumbersToCache = (From Demo In ComscoreDemoNumbers
                                          Where DemoNumbersCached.Contains(Demo) = False
                                          Select Demo).ToList

                    If DemoNumbersToCache.Count > 0 Then

                        If NewURLDate.HasValue AndAlso ComscoreHUTBook.StartDateTime >= NewURLDate.Value Then

                            LocalTimeViews.EndpointPath = NewEndpointPath & "local_time_views"
                            UseNewURL = True

                        Else

                            LocalTimeViews.EndpointPath = OldEndpointPath & "local_time_views"
                            UseNewURL = False

                        End If

                        LocalTimeViews.Request = GetLocalTimeViewsRequestCache(ComscoreHUTBook.StartDateTime, EndDate, LocalMarketNumber, DemoNumbersToCache, StationNumbers, JSONOrdinalComscoreDemoNumbers, ComscoreAsClientID)

                        IsCached = CacheBookData(UseNewURL, ComscoreClientID, ComscoreClientSecret, DbContext, ComscoreHUTBook.ID, JSONOrdinalComscoreDemoNumbers, LocalTimeViews, LocalMarketNumber, DemoNumbersToCache, StationNumbers)

                    End If

                End If

            Next

            CacheBooks = IsCached

        End Function
        Public Function GetMeasurementTrendDetailsCache(DbContext As AdvantageFramework.Database.DbContext, StationNumber As Integer, DemographicList As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Demographic), ShareHPUTBooks As Generic.List(Of AdvantageFramework.DTO.Media.ShareHPUTBook),
                                                        MediaSpotTVResearchDaytimeTypes As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaSpotTVResearchDaytimeType), MarketNumber As Integer) As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail)

            'objects
            Dim ComscoreDemoNumbers As IEnumerable(Of Integer) = Nothing
            Dim PrimaryDemoNumber As Nullable(Of Integer) = Nothing
            Dim SecondaryDemoNumber As Nullable(Of Integer) = Nothing
            Dim MeasurementTrendDetailList As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail) = Nothing

            ComscoreDemoNumbers = DemographicList.Select(Function(E) E.ComscoreDemoNumber.Value).ToArray

            CacheBooks(DbContext, StationNumber, ComscoreDemoNumbers, ShareHPUTBooks, MarketNumber)

            If ComscoreDemoNumbers.Count > 0 Then

                PrimaryDemoNumber = ComscoreDemoNumbers(0)

            End If

            If ComscoreDemoNumbers.Count > 1 Then

                SecondaryDemoNumber = ComscoreDemoNumbers(1)

            End If

            If ShareHPUTBooks.First.ShareBookID.HasValue AndAlso PrimaryDemoNumber.HasValue Then

                MeasurementTrendDetailList = LoadTrendsFromCache(DbContext, MarketNumber, ShareHPUTBooks.First.ShareBookID.Value, StationNumber, PrimaryDemoNumber.Value, SecondaryDemoNumber, MediaSpotTVResearchDaytimeTypes)

            End If

            GetMeasurementTrendDetailsCache = MeasurementTrendDetailList

        End Function
        Private Function LoadTrendsFromCache(DbContext As AdvantageFramework.Database.DbContext, MarketNumber As Integer, ShareBookID As Integer, StationNumber As Integer,
                                             PrimaryDemoNumber As Integer, SecondaryDemoNumber As Nullable(Of Integer),
                                             MediaSpotTVResearchDaytimeTypes As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaSpotTVResearchDaytimeType)) As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail)

            'objects
            Dim MeasurementTrendDetailList As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail) = Nothing
            Dim SqlParameterMarketNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterShareBookID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStationCodes As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPrimaryDemoNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSecondaryDemoNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaSpotTVDaytimeType As System.Data.SqlClient.SqlParameter = Nothing
            Dim LocalMarketNumber As Short = 0

            LocalMarketNumber = DbContext.Database.SqlQuery(Of Short)(String.Format("exec advsp_comscore_get_new_market_number {0}", MarketNumber)).FirstOrDefault

            SqlParameterMarketNumber = New System.Data.SqlClient.SqlParameter("@MARKET_NUMBER", SqlDbType.Int)
            SqlParameterMarketNumber.Value = LocalMarketNumber

            SqlParameterShareBookID = New System.Data.SqlClient.SqlParameter("@SHARE_BOOK_ID", SqlDbType.Int)
            SqlParameterShareBookID.Value = ShareBookID

            SqlParameterStationCodes = New System.Data.SqlClient.SqlParameter("@STATION_NUMBER", SqlDbType.Int)
            SqlParameterStationCodes.Value = StationNumber

            SqlParameterPrimaryDemoNumber = New System.Data.SqlClient.SqlParameter("@PRIMARY_DEMO_NUMBER", SqlDbType.Int)
            SqlParameterPrimaryDemoNumber.Value = PrimaryDemoNumber

            SqlParameterSecondaryDemoNumber = New System.Data.SqlClient.SqlParameter("@SECONDARY_DEMO_NUMBER", SqlDbType.Int)

            If SecondaryDemoNumber.HasValue Then

                SqlParameterSecondaryDemoNumber.Value = SecondaryDemoNumber

            Else

                SqlParameterSecondaryDemoNumber.Value = System.DBNull.Value

            End If

            SqlParameterMediaSpotTVDaytimeType = New System.Data.SqlClient.SqlParameter("@MEDIA_SPOT_TV_DAYTIME_TYPE", SqlDbType.Structured)
            SqlParameterMediaSpotTVDaytimeType.TypeName = "MEDIA_SPOT_TV_DAYTIME_TYPE"
            SqlParameterMediaSpotTVDaytimeType.Value = ToDataTable(MediaSpotTVResearchDaytimeTypes)

            MeasurementTrendDetailList = DbContext.Database.SqlQuery(Of AdvantageFramework.Classes.Media.Nielsen.MeasurementTrendDetail)("EXEC advsp_comscore_tv_trends @MARKET_NUMBER, @SHARE_BOOK_ID, @STATION_NUMBER, @PRIMARY_DEMO_NUMBER, @SECONDARY_DEMO_NUMBER, @MEDIA_SPOT_TV_DAYTIME_TYPE",
                                                                                                                                                                  SqlParameterMarketNumber, SqlParameterShareBookID, SqlParameterStationCodes,
                                                                                                                                                                  SqlParameterPrimaryDemoNumber, SqlParameterSecondaryDemoNumber, SqlParameterMediaSpotTVDaytimeType).ToList()

            LoadTrendsFromCache = MeasurementTrendDetailList

        End Function
        Public Function GetLeadInLeadOutDetailsCache(DbContext As AdvantageFramework.Database.DbContext, MarketNumber As Integer, ShareBookID As Integer,
                                                     StationNumber As Integer, DemoNumber As Integer,
                                                     MediaSpotTVResearchDaytimeTypes As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaSpotTVResearchDaytimeType)) As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutDetail)

            'objects
            Dim ShareHPUTBooks As Generic.List(Of AdvantageFramework.DTO.Media.ShareHPUTBook) = Nothing
            Dim ShareHPUTBook As AdvantageFramework.DTO.Media.ShareHPUTBook = Nothing
            Dim LeadInLeadOutDetailList As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutDetail) = Nothing

            ShareHPUTBooks = New Generic.List(Of AdvantageFramework.DTO.Media.ShareHPUTBook)
            ShareHPUTBook = New AdvantageFramework.DTO.Media.ShareHPUTBook
            ShareHPUTBook.ShareBookID = ShareBookID

            ShareHPUTBooks.Add(ShareHPUTBook)

            CacheBooks(DbContext, StationNumber, {DemoNumber}, ShareHPUTBooks, MarketNumber)

            LeadInLeadOutDetailList = LoadLeadInLeadOutFromCache(DbContext, MarketNumber, ShareBookID, StationNumber, DemoNumber, MediaSpotTVResearchDaytimeTypes)

            GetLeadInLeadOutDetailsCache = LeadInLeadOutDetailList

        End Function
        Private Function LoadLeadInLeadOutFromCache(DbContext As AdvantageFramework.Database.DbContext, MarketNumber As Integer, ShareBookID As Integer, StationNumber As Integer,
                                                    PrimaryDemoNumber As Integer,
                                                    MediaSpotTVResearchDaytimeTypes As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaSpotTVResearchDaytimeType)) As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutDetail)

            'objects
            Dim LeadInLeadOutDetailList As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutDetail) = Nothing
            Dim SqlParameterMarketNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterShareBookID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStationCodes As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPrimaryDemoNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaSpotTVDaytimeType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterWeek As System.Data.SqlClient.SqlParameter = Nothing
            Dim LocalMarketNumber As Short = 0

            LocalMarketNumber = DbContext.Database.SqlQuery(Of Short)(String.Format("exec advsp_comscore_get_new_market_number {0}", MarketNumber)).FirstOrDefault

            SqlParameterMarketNumber = New System.Data.SqlClient.SqlParameter("@MARKET_NUMBER", SqlDbType.Int)
            SqlParameterMarketNumber.Value = LocalMarketNumber

            SqlParameterShareBookID = New System.Data.SqlClient.SqlParameter("@SHARE_BOOK_ID", SqlDbType.Int)
            SqlParameterShareBookID.Value = ShareBookID

            SqlParameterStationCodes = New System.Data.SqlClient.SqlParameter("@STATION_NUMBER", SqlDbType.Int)
            SqlParameterStationCodes.Value = StationNumber

            SqlParameterPrimaryDemoNumber = New System.Data.SqlClient.SqlParameter("@PRIMARY_DEMO_NUMBER", SqlDbType.Int)
            SqlParameterPrimaryDemoNumber.Value = PrimaryDemoNumber

            SqlParameterMediaSpotTVDaytimeType = New System.Data.SqlClient.SqlParameter("@MEDIA_SPOT_TV_DAYTIME_TYPE", SqlDbType.Structured)
            SqlParameterMediaSpotTVDaytimeType.TypeName = "MEDIA_SPOT_TV_DAYTIME_TYPE"
            SqlParameterMediaSpotTVDaytimeType.Value = ToDataTable(MediaSpotTVResearchDaytimeTypes)

            'SqlParameterWeek = New System.Data.SqlClient.SqlParameter("@WEEK", SqlDbType.Int)
            'SqlParameterWeek.Value = week

            LeadInLeadOutDetailList = DbContext.Database.SqlQuery(Of AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutDetail)("EXEC advsp_comscore_tv_leadinleadout @MARKET_NUMBER, @SHARE_BOOK_ID, @STATION_NUMBER, @PRIMARY_DEMO_NUMBER, @MEDIA_SPOT_TV_DAYTIME_TYPE",
                                                                                                                                    SqlParameterMarketNumber, SqlParameterShareBookID, SqlParameterStationCodes,
                                                                                                                                    SqlParameterPrimaryDemoNumber, SqlParameterMediaSpotTVDaytimeType).ToList()

            LoadLeadInLeadOutFromCache = LeadInLeadOutDetailList

        End Function
        'Public Async Function CacheBooksAsync(Session As AdvantageFramework.Security.Session, StationNumber As Integer, ComscoreDemoNumbers As IEnumerable(Of Integer), ShareHPUTBooks As Generic.List(Of AdvantageFramework.DTO.Media.ShareHPUTBook),
        '                                      MarketNumber As Integer) As Task(Of Boolean)

        '    'objects
        '    Dim ComscoreClientID As String = Nothing
        '    Dim ComscoreClientSecret As String = Nothing
        '    Dim LocalTimeViews As Services.ComScore.Classes.LocalTimeViews = Nothing
        '    Dim StationNumbers As IEnumerable(Of Integer) = Nothing
        '    Dim JSONOrdinalComscoreDemoNumbers As Dictionary(Of Integer, Integer) = Nothing
        '    Dim ComscoreShareBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
        '    Dim ComscoreHUTBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
        '    Dim ComscoreAsClientID As String = Nothing
        '    Dim EndDate As Date = Date.MinValue
        '    Dim DemoNumbersCached As Generic.List(Of Integer) = Nothing
        '    Dim DemoNumbersToCache As Generic.List(Of Integer) = Nothing
        '    Dim Tasks As Generic.List(Of System.Threading.Tasks.Task) = Nothing
        '    Dim LocalMarketNumber As Short = 0
        '    Dim OldEndpointPath As String = Nothing
        '    Dim NewEndpointPath As String = Nothing
        '    Dim NewURLDate As Nullable(Of Date) = Nothing
        '    Dim UseNewURL As Boolean = False

        '    Tasks = New Generic.List(Of System.Threading.Tasks.Task)

        '    Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

        '        AdvantageFramework.Services.ComScore.GetClientCredentials(DataContext, ComscoreClientID, ComscoreClientSecret, ComscoreAsClientID, OldEndpointPath, NewEndpointPath, NewURLDate)

        '    End Using

        '    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

        '        LocalMarketNumber = DbContext.Database.SqlQuery(Of Short)(String.Format("exec advsp_comscore_get_new_market_number {0}", MarketNumber)).FirstOrDefault

        '        StationNumbers = New Integer() {StationNumber}

        '        JSONOrdinalComscoreDemoNumbers = New Dictionary(Of Integer, Integer)

        '        LocalTimeViews = New Services.ComScore.Classes.LocalTimeViews

        '        For Each ShareHPUTBook In ShareHPUTBooks

        '            ComscoreHUTBook = Nothing

        '            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.COMSCORE_CACHE_HEADER SET LAST_ACCESSED = getdate() WHERE COMSCORE_TV_BOOK_ID = {0} AND MARKET_NUMBER = {1} AND STATION_NUMBER = {2} AND DEMO_NUMBER IN ({3})", ShareHPUTBook.ShareBookID.Value, MarketNumber, StationNumber, String.Join(",", ComscoreDemoNumbers.ToArray)))

        '            DemoNumbersCached = (From Entity In AdvantageFramework.Database.Procedures.ComscoreCacheHeader.Load(DbContext)
        '                                 Where Entity.BookID = ShareHPUTBook.ShareBookID.Value AndAlso
        '                                       Entity.MarketNumber = LocalMarketNumber AndAlso
        '                                       Entity.StationNumber = StationNumber AndAlso
        '                                       ComscoreDemoNumbers.Contains(Entity.DemoNumber)
        '                                 Select Entity.DemoNumber).ToList

        '            DemoNumbersToCache = (From Demo In ComscoreDemoNumbers
        '                                  Where DemoNumbersCached.Contains(Demo) = False
        '                                  Select Demo).ToList

        '            If DemoNumbersToCache.Count > 0 Then

        '                ComscoreShareBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, ShareHPUTBook.ShareBookID.Value)

        '                EndDate = ComscoreShareBook.EndDateTime.AddDays(-1)

        '                If NewURLDate.HasValue AndAlso ComscoreShareBook.StartDateTime >= NewURLDate.Value Then

        '                    LocalTimeViews.EndpointPath = NewEndpointPath & "local_time_views"
        '                    UseNewURL = True

        '                Else

        '                    LocalTimeViews.EndpointPath = OldEndpointPath & "local_time_views"
        '                    UseNewURL = False

        '                End If

        '                LocalTimeViews.Request = GetLocalTimeViewsRequestCache(ComscoreShareBook.StartDateTime, EndDate, LocalMarketNumber, DemoNumbersToCache, StationNumbers, JSONOrdinalComscoreDemoNumbers, ComscoreAsClientID)

        '                Tasks.Add(Task.Run(Sub()
        '                                       CacheBookData(UseNewURL, ComscoreClientID, ComscoreClientSecret, DbContext, ComscoreShareBook.ID, JSONOrdinalComscoreDemoNumbers, LocalTimeViews, LocalMarketNumber, DemoNumbersToCache, StationNumbers)
        '                                   End Sub))

        '            End If

        '            If ShareHPUTBook.HPUTBookID.HasValue AndAlso ShareHPUTBook.HPUTBookID.Value > 0 Then

        '                ComscoreHUTBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, ShareHPUTBook.HPUTBookID.Value)

        '                EndDate = ComscoreHUTBook.EndDateTime.AddDays(-1)

        '                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.COMSCORE_CACHE_HEADER SET LAST_ACCESSED = getdate() WHERE COMSCORE_TV_BOOK_ID = {0} AND MARKET_NUMBER = {1} AND STATION_NUMBER = {2} AND DEMO_NUMBER IN ({3})", ShareHPUTBook.HPUTBookID.Value, MarketNumber, StationNumber, String.Join(",", ComscoreDemoNumbers.ToArray)))

        '                DemoNumbersCached = (From Entity In AdvantageFramework.Database.Procedures.ComscoreCacheHeader.Load(DbContext)
        '                                     Where Entity.BookID = ShareHPUTBook.HPUTBookID.Value AndAlso
        '                                           Entity.MarketNumber = LocalMarketNumber AndAlso
        '                                           Entity.StationNumber = StationNumber AndAlso
        '                                           ComscoreDemoNumbers.Contains(Entity.DemoNumber)
        '                                     Select Entity.DemoNumber).ToList

        '                DemoNumbersToCache = (From Demo In ComscoreDemoNumbers
        '                                      Where DemoNumbersCached.Contains(Demo) = False
        '                                      Select Demo).ToList

        '                If DemoNumbersToCache.Count > 0 Then

        '                    If NewURLDate.HasValue AndAlso ComscoreHUTBook.StartDateTime >= NewURLDate.Value Then

        '                        LocalTimeViews.EndpointPath = NewEndpointPath & "local_time_views"
        '                        UseNewURL = True

        '                    Else

        '                        LocalTimeViews.EndpointPath = OldEndpointPath & "local_time_views"
        '                        UseNewURL = False

        '                    End If

        '                    LocalTimeViews.Request = GetLocalTimeViewsRequestCache(ComscoreHUTBook.StartDateTime, EndDate, LocalMarketNumber, DemoNumbersToCache, StationNumbers, JSONOrdinalComscoreDemoNumbers, ComscoreAsClientID)

        '                    Tasks.Add(Task.Run(Sub()
        '                                           CacheBookData(UseNewURL, ComscoreClientID, ComscoreClientSecret, DbContext, ComscoreHUTBook.ID, JSONOrdinalComscoreDemoNumbers, LocalTimeViews, LocalMarketNumber, DemoNumbersToCache, StationNumbers)
        '                                       End Sub))

        '                End If

        '            End If

        '        Next

        '        Await Task.WhenAll(Tasks)

        '    End Using

        '    Return True

        'End Function

#End Region

#End Region

    End Module

End Namespace
