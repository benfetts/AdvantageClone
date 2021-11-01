Namespace Quickbooks.Classes

    Public Class IdTokenHeader
        <Newtonsoft.Json.JsonProperty("kid")>
        Public Property Kid As String
        <Newtonsoft.Json.JsonProperty("alg")>
        Public Property Alg As String
    End Class

    Public Class IdTokenPayload
        <Newtonsoft.Json.JsonProperty("sub")>
        Public Property [Sub] As String
        <Newtonsoft.Json.JsonProperty("aud")>
        Public Property Aud As List(Of String)
        <Newtonsoft.Json.JsonProperty("realmId")>
        Public Property RealmId As String
        <Newtonsoft.Json.JsonProperty("auth_time")>
        Public Property Auth_time As String
        <Newtonsoft.Json.JsonProperty("iss")>
        Public Property Iss As String
        <Newtonsoft.Json.JsonProperty("exp")>
        Public Property Exp As String
        <Newtonsoft.Json.JsonProperty("iat")>
        Public Property Iat As String
    End Class

End Namespace
