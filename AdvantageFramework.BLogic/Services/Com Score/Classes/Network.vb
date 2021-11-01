Namespace Services.ComScore.Classes

    <Serializable>
    Public Class Network

        <Newtonsoft.Json.JsonProperty("endpoint_path")>
        Public Property EndpointPath As String
        <Newtonsoft.Json.JsonProperty("request")>
        Public Property Request As String

    End Class

    Public Class NetworkResponse

        <Newtonsoft.Json.JsonProperty("network_no")>
        Public Property NetworkNumber As Integer
        <Newtonsoft.Json.JsonProperty("network_name")>
        Public Property NetworkName As String
        <Newtonsoft.Json.JsonProperty("network_short_name")>
        Public Property NetworkShortName As String
        <Newtonsoft.Json.JsonProperty("network_type")>
        Public Property NetworkType As String
        <Newtonsoft.Json.JsonProperty("category_names")>
        Public Property CategoryNames As String()

        Public Sub New()

        End Sub

    End Class

End Namespace