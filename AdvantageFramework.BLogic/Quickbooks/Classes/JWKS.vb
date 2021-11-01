Namespace Quickbooks.Classes

    Public Class JWKS
        <Newtonsoft.Json.JsonProperty("keys")>
        Public Property Keys As List(Of Key)
    End Class

    Public Class Key
        <Newtonsoft.Json.JsonProperty("kty")>
        Public Property Kty As String
        <Newtonsoft.Json.JsonProperty("e")>
        Public Property E As String
        <Newtonsoft.Json.JsonProperty("use")>
        Public Property Use As String
        <Newtonsoft.Json.JsonProperty("kid")>
        Public Property Kid As String
        <Newtonsoft.Json.JsonProperty("alg")>
        Public Property Alg As String
        <Newtonsoft.Json.JsonProperty("n")>
        Public Property N As String
    End Class

End Namespace
