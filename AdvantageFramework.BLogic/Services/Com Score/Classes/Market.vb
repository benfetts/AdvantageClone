Namespace Services.ComScore.Classes

    <Serializable>
    Public Class Market

        <Newtonsoft.Json.JsonProperty("endpoint_path")>
        Public Property EndpointPath As String
        <Newtonsoft.Json.JsonProperty("request")>
        Public Property Request As String

    End Class

    Public Class MarketResponse

        Public Property Market_No As Long
        Public Property Market_Name As String
        Public Property Market_Long_Name As String
        Public Property Is_Limited_Data_Market As Boolean
        Public Property Daypart_Offset_From_Eastern_Hours As Integer

        Public Sub New()

        End Sub

    End Class

End Namespace