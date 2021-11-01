Namespace Services.ComScore.Classes

    <Serializable>
    Public Class Station

        <Newtonsoft.Json.JsonProperty("endpoint_path")>
        Public Property EndpointPath As String
        <Newtonsoft.Json.JsonProperty("request")>
        Public Property Request As String

    End Class

    Public Class StationResponse

        <Newtonsoft.Json.JsonProperty("station_no")>
        Public Property StationNumber As Integer
        <Newtonsoft.Json.JsonProperty("station_call_sign")>
        Public Property StationCallSign As String
        <Newtonsoft.Json.JsonProperty("station_name")>
        Public Property StationName As String
        <Newtonsoft.Json.JsonProperty("station_primary_market_no")>
        Public Property StationPrimaryMarketNumber As Nullable(Of Integer)
        <Newtonsoft.Json.JsonProperty("station_affiliated_network_no")>
        Public Property StationAffiliatedNetworkNumber As Integer

        Public Sub New()

        End Sub

    End Class

End Namespace