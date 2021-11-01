Namespace Services.ComScore.Classes

    <Serializable>
    Public Class Demographic

        <Newtonsoft.Json.JsonProperty("endpoint_path")>
        Public Property EndpointPath As String
        <Newtonsoft.Json.JsonProperty("request")>
        Public Property Request As String

    End Class

    Public Class DemographicResponse

        <Newtonsoft.Json.JsonProperty("demo_no")>
        Public Property DemoNumber As Integer
        <Newtonsoft.Json.JsonProperty("ox_demo_code")>
        Public Property DemoCode As String
        <Newtonsoft.Json.JsonProperty("demo_name")>
        Public Property DemoName As String
        <Newtonsoft.Json.JsonProperty("demo_tier_a")>
        Public Property IsDemoTierA As Boolean
        <Newtonsoft.Json.JsonProperty("demo_tier_b")>
        Public Property IsDemoTierB As Boolean
        <Newtonsoft.Json.JsonProperty("demo_tier_c")>
        Public Property IsDemoTierC As Boolean
        <Newtonsoft.Json.JsonProperty("demo_tier_d")>
        Public Property IsDemoTierD As Boolean
        <Newtonsoft.Json.JsonProperty("demo_national")>
        Public Property IsDemoNational As Boolean
        <Newtonsoft.Json.JsonProperty("demo_create_date")>
        Public Property DemoCreateDate As Nullable(Of Date)
        <Newtonsoft.Json.JsonProperty("demo_group_no")>
        Public Property DemoGroupNumber As Nullable(Of Integer)
        <Newtonsoft.Json.JsonProperty("demo_sort_order")>
        Public Property DemoSortOrder As Nullable(Of Integer)
        <Newtonsoft.Json.JsonProperty("demo_group_name")>
        Public Property DemoGroupName As String
        <Newtonsoft.Json.JsonProperty("demo_group_sort_order")>
        Public Property DemoGroupSortOrder As Nullable(Of Integer)
        <Newtonsoft.Json.JsonProperty("demo_group_owner_no")>
        Public Property DemoGroupOwnerNumber As Nullable(Of Integer)
        <Newtonsoft.Json.JsonProperty("demo_group_owner_name")>
        Public Property DemoGroupOwnerName As String

        Public Sub New()

        End Sub

    End Class

End Namespace